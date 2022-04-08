
#region Global Using
// =================================================================
// Copyright (c) 2014-2020 HBM GmbH
//  
// THIS SOFTWARE/SOURCE CODE IS FOR DEMONSTRATION PURPOSE ONLY, 
// WITHOUT WARRANTY OF ANY KIND!
//
// DO NOT USE THIS SOURCE CODE UNALTERED IN PRODUCTION SOFTWARE!
// =================================================================



using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

//Usings for common part of the API
using Hbm.Api.Common;
using Hbm.Api.Common.Exceptions;
using Hbm.Api.Common.Entities;
using Hbm.Api.Common.Entities.Problems;
using Hbm.Api.Common.Entities.Connectors;
using Hbm.Api.Common.Entities.Channels;
using Hbm.Api.Common.Entities.Signals;
using Hbm.Api.Common.Entities.Filters;
using Hbm.Api.Common.Entities.ConnectionInfos;
using Hbm.Api.Common.Enums;

//Usings for logging
using Hbm.Api.Logging;
using Hbm.Api.Logging.Enums;
using Hbm.Api.Logging.Logger;

using System.Reflection;


//Usings for sensor database access
using Hbm.Api.SensorDB.Entities.Sensors;
using Hbm.Api.SensorDB.Entities.Scalings;

//Usings for common API events 
using Hbm.Api.Common.Messaging;

//Usings for PMX (only necessary, if you want to use special features of PMX devices)
using Hbm.Api.Pmx;
using Hbm.Api.Pmx.Connectors;
using Hbm.Api.Pmx.Channels;
using Hbm.Api.Pmx.Signals;

//Usings for MGC (only necessary, if you want to use special features of MGC devices)
using Hbm.Api.Mgc;
using Hbm.Api.Mgc.Connectors;
using Hbm.Api.Mgc.Channels;
using Hbm.Api.Mgc.Signals;

////Usings for QuantumX (only necessary, if you want to use special features of QuantumX devices)
//using Hbm.Api.QuantumX;
//using Hbm.Api.QuantumX.Connectors;
//using Hbm.Api.QuantumX.Channels;
//using Hbm.Api.QuantumX.Signals;

//Usings for GenericStreaming (only necessary, if you want to use generic streaming devices)
//using Hbm.Api.GenericStreaming;


using System.Threading;
using Hbm.Api.SensorDB;
using Hbm.Api.SensorDB.Entities;
using System.IO;
using System.Windows.Forms.VisualStyles;

using Hbm.Api.Common.Entities.SpectrumInfos;
using Hbm.Api.Common.Entities.Values;

using System.Threading.Tasks;

#endregion


using Continental.Project.Adam.UI.Helper;
using Continental.Project.Adam.UI.Helper.Com;
using System.Diagnostics;
using Continental.Project.Adam.UI.Helper.Tests;

namespace Continental.Project.Adam.UI.COM
{
    public class ComHBM
    {
        #region Variables Config

        public static bool HBM_UseEnableCom = bool.Parse(System.Configuration.ConfigurationManager.AppSettings["Hbm_EnableCom"].ToString());

        public string _hbm_ScanIntervalSec = System.Configuration.ConfigurationManager.AppSettings["Hbm_ScanIntervalSec"].ToString();

        public string _hbm_IpDevice = System.Configuration.ConfigurationManager.AppSettings["Hbm_IpDevice"].ToString();

        public int _hbm_ConnectorlCalculetedChannelsStart = int.Parse(System.Configuration.ConfigurationManager.AppSettings["Hbm_ConnectorlCalculetedChannelsStart"].ToString());

        public int _hbm_QtdCalculetedChannels = int.Parse(System.Configuration.ConfigurationManager.AppSettings["Hbm_QtdCalculetedChannels"].ToString());

        #endregion

        #region Global variables

        HelperHBM _comReturnHBM = new HelperHBM();
        HelperLog helperLog = new HelperLog();

        HelperApp _helperApp = new HelperApp();

        List<Signal> lstSignalCalculetedChannels = new List<Signal>();

        public bool prepareContinuousMeasurement;
        public bool runContinuousMeasurement;
        public bool stopContinuousMeasurement;

        public string msgReturn;

        // Variables used to show the general workflow
        public DaqEnvironment _daqEnvironment;   // main object to scan, connect and parameterize devices
        public DaqMeasurement _daqMeasurement;   // main object to execute measurements
        public Device _myDevice;         // device to connect and to use within this demo
        public List<Signal> _signalsToMeasure; // list of signals to use for a continuous measurement
        public bool _runMeasurement;   // true, while data acquisition is running...
        public List<Device> _deviceList;       // list of devices found by the scan

        public delegate void VisualizeDeviceEventHandler(DeviceEventArgs e); // delegate for our event handling

        // Sensor data base access
        public ISensorDB _sensorDBManagerForHbmSensorDatabase;  // sensor manager, used to access the HBM sensor database
        public ISensorDB _sensorDBManagerForUserSensorDatabase; // sensor manager, used to access a user sensor database

        // Logging
        public ILogger _logger;                     // a logger object that can be used to log messages
        public LogContext _logContextApiDemoMeasuring; // context to log messages in a hierarchical way here: Messages related to measurement issues

        public LogContext
            _logContextApiDemoProblems; // context to log messages in a hierarchical way here: Messages related to problems that occurred during the execution of the demo

        public int _logNumberDummy = 0; // just a counter used to generate different log entries...

        public bool _logAddEntryToMeasurementGroup;
        public bool _logAddEntryToProblemsGroup;
        public bool _logEndLogging;
        public bool _logCreateContexts;
        public bool _logCreateLogger;

       

        #endregion

        #region Principle workflow and measurement

        /// <summary>
        /// Initialize objects that support scanning, parameterizing and measuring
        /// </summary>
        public HelperHBM InitializeObjects()
        {
            try
            {
                _daqEnvironment = DaqEnvironment.GetInstance(); //DaqEnvironment is a singleton
                _daqMeasurement = new DaqMeasurement();
                msgReturn = "DaqEnvironment and DaqMeasurement objects initialized";

                helperLog.HbmAddMessageToProtocol(msgReturn);

                _comReturnHBM.Status = true;
                _comReturnHBM.Initialized = true;
            }
            catch (Exception ex)
            {
                msgReturn = ex.Message;
                HbmDisplayException(ex);

                _comReturnHBM.Status = false;
                _comReturnHBM.Initialized = false;
            }

            _comReturnHBM.Message = msgReturn;

            return _comReturnHBM;
        }

        /// <summary>
        /// Register handler for "DeviceConnected" event
        /// DeviceConnected events will be fired asynchronously each time a device is successfully connected
        /// </summary>
        public HelperHBM HbmRegisterEvent()
        {
            try
            {
                //MessageBroker handles all events of the common API.
                //MessageBroker.DeviceConnected += HbmMessageBroker_DeviceConnected;
                //MessageBroker.DeviceDisconnected += HbmMessageBroker_DeviceDisconnected;

                msgReturn = "Device event handlers registered";

                helperLog.HbmAddMessageToProtocol(msgReturn);

                _comReturnHBM.Status = true;
                _comReturnHBM.RegisterEvent = true;
            }
            catch (Exception ex)
            {
                msgReturn = ex.Message;
                HbmDisplayException(ex);

                _comReturnHBM.Status = false;
                _comReturnHBM.RegisterEvent = false;

                HbmDisplayException(ex);
            }

            _comReturnHBM.Message = msgReturn;

            return _comReturnHBM;
        }

        /// <summary>
        /// Scans for devices
        /// </summary>
        public HelperHBM ScanForDevices()
        {
            try
            {
                // check, which device families are supported...
                List<string> supportedDeviceFamilies = _daqEnvironment.GetAvailableDeviceFamilyNames();

                foreach (string family in supportedDeviceFamilies)
                {
                    helperLog.HbmAddMessageToProtocol("Supported device family:" + family);
                }

                // scan for all supported device families
                _deviceList = _daqEnvironment.Scan(supportedDeviceFamilies);

                // notice that the list of devices already has some information about the devices -
                // although they are NOT yet connected. The information is delivered by the scan!

                //sort the list by device name
                _deviceList = _deviceList.OrderBy(n => n.Name).ToList();

                helperLog.HbmAddMessageToProtocol(string.Format("Found devices:{0}", _deviceList.Count));

                foreach (Device dev in _deviceList)
                {
                    helperLog.HbmAddMessageToProtocol(string.Format("Devicename: {0} Serialnumber: {1}  FirmwareVersion: {2}", dev.Name.PadRight(22), dev.SerialNo.PadRight(16), dev.FirmwareVersion));
                }

                //update comboBox with found devices and their IP addresses:
                foreach (Device device in _deviceList)
                {
                    helperLog.HbmAddMessageToProtocol("Device List:" + (device.Name.PadRight(14) + " (" + (device.ConnectionInfo as EthernetConnectionInfo).IpAddress + ")"));
                }

                //select first device within the
                if (_deviceList.Count > 0)
                {
                    msgReturn = string.Format("Selected devices:{0}", _deviceList.FirstOrDefault());
                    helperLog.HbmAddMessageToProtocol(msgReturn);

                    _comReturnHBM.Status = true;
                    _comReturnHBM.DeviceSelected = true;
                }
            }
            catch (Exception ex)
            {
                msgReturn = ex.Message;
                HbmDisplayException(ex);

                _comReturnHBM.Status = false;
                _comReturnHBM.DeviceSelected = false;
            }

            _comReturnHBM.Message = msgReturn;

            return _comReturnHBM;
        }


        /// <summary>
        /// Connects the selected device
        /// </summary>
        public HelperHBM ConnectSelectedDevice()
        {
            try
            {
                if (_deviceList.Count > 0)
                {
                    List<Problem> problemList = new List<Problem>();

                    // pick the device that should be used from the scanned device list
                    _myDevice = _deviceList[0]; //connectionInfo of the device has been filled by the scan!
                    _daqEnvironment.Connect(_myDevice, out problemList);

                    // when a device is connected, the complete object representation of the device is available
                    // break here and check _deviceList[0] against e.g. _deviceList[1] to see the difference
                    msgReturn = string.Format("Device {0} is connected;  It has {1} connectors", _myDevice.Name, _myDevice.Connectors.Count);

                    helperLog.HbmAddMessageToProtocol(msgReturn);

                    _comReturnHBM.Status = true;
                    _comReturnHBM.DeviceConnected = true;
                }
            }
            catch (Exception ex)
            {
                msgReturn = ex.Message;
                HbmDisplayException(ex);

                _comReturnHBM.Status = false;
                _comReturnHBM.DeviceConnected = false;
            }

            _comReturnHBM.Message = msgReturn;

            return _comReturnHBM;
        }


        /// <summary>
        /// Connect to a device without using scan (e.g. MGC devices do not support scan)
        /// </summary>
        public void ConnectToCertainDevice()
        {
            try
            {
                List<Problem> problemList = new List<Problem>();

                // To connect a device without using the results of the scan, you have to define at least the
                // type of the device and its IP address. E.g.:

                //_myDevice = new PmxDevice();
                //_myDevice.ConnectionInfo = new EthernetConnectionInfo("172.19.191.113",55000);
                // or:
                _myDevice = new PmxDevice(_hbm_IpDevice); //this constructor uses the PMX default port (55000)

                //its default streaming port (7411) and its default HTTP port (80)
                if (_daqEnvironment.Connect(_myDevice, out problemList)) //connect the defined device
                {
                    // when a device is connected, the complete object representation of the device is available
                    // break here and check _deviceList[0] against e.g. _deviceList[1] to see the difference
                    helperLog.HbmAddMessageToProtocol(string.Format("Device {0} is connected;  It has {1} connectors", _myDevice.Name, _myDevice.Connectors.Count));
                    _comReturnHBM.DeviceConnected = true;
                }
                else
                {
                    //there occurred errors during connect to the device
                    helperLog.HbmAddMessageToProtocol("Connection to device failed!");

                    foreach (Problem problem in problemList)
                    {
                        helperLog.HbmAddMessageToProtocol(problem.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                HbmDisplayException(ex);
            }
        }

        /// <summary>
        /// Get further information about the device
        /// like channel names and sensor types
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event arguments</param>
        public void ExploreDevice()
        {
            try
            {
                foreach (Connector con in _myDevice.Connectors)
                {
                    if (con is CanConnector)
                    {
                        // this is a CAN connector and it could be possible that its first channel is the special one for CAN RAW
                        // however.. if CAN RAW is not supported, the first channel is NULL!!!! ATTENTION!!!
                        if (con.Channels[0] == null)
                        {
                            helperLog.HbmAddMessageToProtocol($"ConnectorType = {con.GetType()};  Number of channels below connector = {con.Channels.Count}; CAN connector of this device does not support CAN RAW => first CAN channel is NULL");
                        }
                        else
                        {
                            helperLog.HbmAddMessageToProtocol($"ConnectorType = {con.GetType()};  Number of channels below connector = {con.Channels.Count}; Name of first channel = {(con.Channels[0].Name.Trim())}");
                        }
                    }
                    else
                    {
                        // all other connector types except CAN
                        helperLog.HbmAddMessageToProtocol($"ConnectorType = {con.GetType()};  Number of channels below connector = {con.Channels.Count}; Name of first channel = {(con.Channels[0].Name.Trim())}");
                    }
                }
            }
            catch (Exception ex)
            {
                HbmDisplayException(ex);
            }
        }

        /// <summary>
        /// Gets a measurement value (directly - not via a continuous measurement..)
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event arguments</param>
        public void GetMeasurementValue_org()
        {
            try
            {
                // get a measurement value of the first signal of the first channel of the first connector
                helperLog.HbmAddMessageToProtocol("Get a single measurement value of first signal");



                // Signal tempSignal = _myDevice.Connectors[0].Channels[0].Signals[1];

                Signal tempSignal = _myDevice.Connectors[19].Channels[0].Signals[0]; //rDeslocamentoSaidaBooster_mm_Lin;     //ch9.4 - B11.02 - Transdutor Deslocamento Saida Booster - 0-50 mm (Linearizada)

                _myDevice.ReadSingleMeasurementValue(new List<Signal>() { tempSignal });

                //ComHBM.rTimeStamp = tempSignal.GetSingleMeasurementValue().Timestamp;
                //ComHBM.rDeslocamentoSaidaBooster_mm_Lin = tempSignal.GetSingleMeasurementValue().Value;


                // get a measurement value from all signals of the device:
                //_myDevice.ReadSingleMeasurementValueOfAllSignals();

                helperLog.HbmAddMessageToProtocol(string.Format("Measurement value of first signal={0}", tempSignal.GetSingleMeasurementValue().Value));
                helperLog.HbmAddMessageToProtocol(string.Format("Timestamp of first signal={0}", tempSignal.GetSingleMeasurementValue().Timestamp));
            }
            catch (Exception ex)
            {
                HbmDisplayException(ex);
            }
        }

        public bool GetMeasurementValue()
        {
            try
            {
                // get a measurement value of the first signal of the first channel of the first connector
                helperLog.HbmAddMessageToProtocol("Get a single measurement value of first signal");

                lstSignalCalculetedChannels.Clear();

                for (int i = 0; i < _hbm_QtdCalculetedChannels; i++)
                    lstSignalCalculetedChannels.Add(_myDevice.Connectors[_hbm_ConnectorlCalculetedChannelsStart + i].Channels[0].Signals[0]);

                foreach (var item in lstSignalCalculetedChannels.Select((value, i) => (value, i)))
                {
                    int channelVariableIndex = item.i;

                    Signal channelVariable = item.value;

                    _myDevice.ReadSingleMeasurementValue(new List<Signal>() { channelVariable });

                    var signalValue = channelVariable.GetSingleMeasurementValue().Value;
                    var dblTimeStamp = channelVariable.GetSingleMeasurementValue().Timestamp;

                    TimeSpan t = TimeSpan.FromMilliseconds(dblTimeStamp);
                    string strTimeStamp = string.Format("{0:D2}h:{1:D2}m:{2:D2}s:{3:D3}ms",
                            t.Hours,
                            t.Minutes,
                            t.Seconds,
                            t.Milliseconds);

                    string strSignalFormatedValue = String.Format("{0:0.000}", signalValue);
                    string strSignalCalculetedTimestamp = String.Format("{0:d/M/yyyy HH:mm:ss}", strTimeStamp);

                    HelperHBM.rTimeStamp = dblTimeStamp;
                    HelperHBM.strTimeStamp = strSignalCalculetedTimestamp;

                    //ch9.1 - B01.17 - Transdutor Deslocamento Desvio Linearidade - 0-10 mm (Linearizado)
                    //ch9.2 - B10.01 - Celula Carga Forca Entrada - 0-5 kN (Linearizada)
                    //ch9.3 - B10.02 - Celula Carga Forca Saída- 0-10 kN (Linearizada)
                    //ch9.4 - B11.02 - Transdutor Deslocamento Saida Booster - 0-50 mm (Linearizada)
                    //ch9.5 - B11.01 - Transdutor Deslocamento Entrada Booster - 0-50 mm (Linearizada)
                    //ch9.6 - B06.03 - Pressao Camara Secundaria CS - 0-250 bar (Linearizada
                    //ch9.7 - B05.03 - Pressao Camara Primaria CP - 0-250 bar (Linearizada)
                    //ch9.8 - B03.03 - Pressao Teste Bolhas 0-1 bar(Linearizada)
                    //ch9.9 - B04.20 - Pressao Sangria 0-6 bar (Linearizada)
                    //ch9.10 - B07.11 - Pressao Linha Vacuo (-1)-0 bar (Linearizada)

                    switch (channelVariableIndex)
                    {
                        case 0:
                            //HelperHBM._rTimeStamp = Convert.ToDouble(strSignalFormatedValue);
                            break;
                        case 1:
                            HelperHBM.rDiffTravel = Convert.ToDouble(signalValue); //rDeslocamentoDiferencial_mm_Lin 
                            break;
                        case 2:
                            HelperHBM.rInputForce1 = Convert.ToDouble(signalValue); //rForcaEntradaBooster_N_Lin
                            break;
                        case 3:
                            HelperHBM.rOutputForce = Convert.ToDouble(signalValue); //rForcaSaidaBooster_N_Lin
                            break;
                        case 4:
                            HelperHBM.rTravelTMC = Convert.ToDouble(signalValue);
                            break;
                        case 5:
                            HelperHBM.rTravelPiston = Convert.ToDouble(signalValue);
                            break;
                        case 6:
                            HelperHBM.rPressureSC = Convert.ToDouble(signalValue);
                            break;
                        case 7:
                            HelperHBM.rPressurePC = Convert.ToDouble(signalValue);
                            break;
                        case 8:
                            HelperHBM.rPneumTestPressure = Convert.ToDouble(signalValue);
                            break;
                        case 9:
                            HelperHBM.rHydrFillPressure = Convert.ToDouble(signalValue);
                            break;
                        case 10:
                            HelperHBM.rVaccum = Convert.ToDouble(signalValue);
                            break;
                        case 11:
                            break;
                        case 12:
                            break;
                        default:
                            // code block
                            break;
                    }

                    helperLog.HbmAddMessageToProtocol(string.Format("Measurement value of first signal={0}", signalValue));
                    helperLog.HbmAddMessageToProtocol(string.Format("Timestamp of first signal={0}", dblTimeStamp));
                }

                return true;
            }
            catch (Exception ex)
            {
                HbmDisplayException(ex);
            }

            return false;
        }

        /// <summary>
        /// Changes the name of the first signal of the first channel of the first connector
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event arguments</param>
        public void ChangeSignalName()
        {
            try
            {
                List<Problem> problemList; // List that contains all problems that occurred during the last assign

                // process....see below
                helperLog.HbmAddMessageToProtocol("Renaming Signal");

                // Change the name of the first signal of the first channel of the first connector of the device
                _myDevice.Connectors[0].Channels[0].Signals[0].Name = "Hello world";

                // ( you could also change e.g. the SampleRate here... just uncomment following lines to do that.
                // _myDevice.Connectors[0].Channels[0].Signals[0].SampleRate = 1200; )
                //
                // In your object representation the name is changed now... but the device itself doesn't know it yet
                // so, to update your physical device, you have to assign the changed signal.
                // There are several Assign functions... in this case it would be sufficient to assign only the signal
                // e.g. with
                // _myDevice.AssignSignal(_deviceList[0].Connectors[0].Channels[0].Signals[0], out problemList);
                // but here we just assign the whole connector....so you could change any properties of any object
                // under the connector (not only some signal properties)...
                _myDevice.AssignConnector(_myDevice.Connectors[0], out problemList);

                // if there were any problems during assign, problemsList will tell us ...
                // in case of using a PMX or MGC device, you will get some warnings when Signal.Name is changed.
                // this is, because channel name is not supported by the PMX and the MGC and it will
                // get the same name as the signal!
                if (problemList.Count == 0)
                {
                    helperLog.HbmAddMessageToProtocol("Signal has been renamed without any warnings or errors!");
                }
                else
                {
                    //oops... something went wrong..
                    foreach (Problem problem in problemList)
                    {
                        helperLog.HbmAddMessageToProtocol("Problem type=" + problem.GetType().ToString());

                        if (problem is Warning)
                        {
                            helperLog.HbmAddMessageToProtocol("Warning:" + problem.Message);
                        }

                        if (problem is Error)
                        {
                            helperLog.HbmAddMessageToProtocol("Error:" + problem.Message);
                        }

                        helperLog.HbmAddMessageToProtocol("at location:" + problem.Position);
                        helperLog.HbmAddMessageToProtocol("Property that caused the problem:" + problem.PropertyName);
                    }
                }
            }
            catch (Exception ex)
            {
                HbmDisplayException(ex);
            }
        }

        /// <summary>
        /// Prepares a continuous measurement
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event arguments</param>
        public HelperHBM PrepareContinuousMeasurement()
        {

            try
            {
                // prepare a continuous measurement with 1 signal
                // use the first signals of the first  connector of the device
                List<Signal> lstSignalCalculetedChannels = new List<Signal>();

                _signalsToMeasure = new List<Signal>();

                for (int i = 0; i < _hbm_QtdCalculetedChannels; i++)
                {
                    Signal actualCh = _myDevice.Connectors[_hbm_ConnectorlCalculetedChannelsStart + i].Channels[0].Signals[0];

                    lstSignalCalculetedChannels.Add(actualCh);
                }

                _signalsToMeasure.Add(_myDevice.Connectors[0].Channels[0].Signals[0]);

                if (_signalsToMeasure?.Count > 0)
                    _signalsToMeasure = lstSignalCalculetedChannels;

                ////set sample rate for signals
                //List<Problem> problems = new List<Problem>(); //this list of problems will be used to get the problems during a assign process
                //foreach (Signal sig in _signalsToMeasure)
                //{
                //    sig.SampleRate = 2400; //check what happens, if you assign e.g. sig.SampleRate = 1234;
                //    _myDevice.AssignSignal(sig, out problems);
                //    if (problems.Count > 0)
                //    {
                //        foreach (Problem prob in problems)
                //        {
                //            AddToProtocol(string.Concat("Problem with ", prob.PropertyName, " occurred: ", prob.Message, " (", prob.OriginalMessage, " - ", prob.DemandedValue, ")"));
                //        }

                //        if (problems.HasError())
                //        {
                //            AddToProtocol("Preparation terminated (due to error).");
                //            this.PrepareContinuousMeasurementBt.Enabled = true;
                //            return;
                //        }
                //        else
                //        {
                //            this.RunContinuousMeasurementBt.Enabled = true;
                //        }
                //    }
                //}

                // add the chosen signals to the measurement
                _daqMeasurement.AddSignals(_myDevice, _signalsToMeasure);
                msgReturn = "Added " + _signalsToMeasure.Count + " signals to the measurement.";
                helperLog.HbmAddMessageToProtocol(msgReturn);

                // prepare data acqusisition;
                //_daqMeasurement.PrepareDaq(); // use standard parameters
                // or: setup certain features of the measurement:
                _daqMeasurement.PrepareDaq(5000, 10, 1000, false, false);

                // try overloaded version of PrepareDaq ( e.g. to control number of filled timestamps- default is "timeStamp for the first measurement value only")
                //_daqMeasurement.PrepareDaq(2400, 1, 2400, false, false);// use this to get a timeStamp and a status for each measurement value
                msgReturn = "Continuous Measurement is prepared.";
                helperLog.HbmAddMessageToProtocol(msgReturn);

                _comReturnHBM.Status = true;
                _comReturnHBM.PreparedContinuousMeasurement = true;
            }
            catch (Exception ex)
            {
                msgReturn = ex.Message;
                //HbmDisplayException(ex);

                _comReturnHBM.Status = false;
                _comReturnHBM.PreparedContinuousMeasurement = false;
            }

            _comReturnHBM.Message = msgReturn;

            return _comReturnHBM;
        }

        /// <summary>
        /// Runs continuous measurement with the signals that were added to the measurement
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event arguments</param>
        /// 
        public void RunContinuousMeasurement()
        {
            /*Original Method
             * 
            this.RunContinuousMeasurementBt.Enabled = false;

            try
            {
                // run continuous measurement with the signals that were added to the measurement
                _daqMeasurement.StartDaq(DataAcquisitionMode.TimestampSynchronized); //DataAcquisitionMode.Unsynchronized
                _runMeasurement = true;

                this.StopContinuousMeasurementBt.Enabled = true;

                while (_runMeasurement)
                {
                    // update measurement values of the signals that were added to the measurement:
                    _daqMeasurement.FillMeasurementValues();

                    // FillMeasurements updates the ContinuousMeasurementValues of all signals that
                    // were added to the measurement
                    // The next call of FillMeasurementValues will overwrite them again with new values....

                    // check the signals that were added to the measurement for new measurement values...
                    foreach (Signal signal in _signalsToMeasure)
                    {
                        // this is the way you get the measurement values (as doubles) from ALL signals (no matter what type of signal)
                        // that take part in the measurement (check Signal.ContinuousMeasurementValues)
                        if (signal.ContinuousMeasurementValues.UpdatedValueCount > 0)
                        {
                            AddToProtocol("-------------------------");
                            AddToProtocol(string.Format("Signal {0} has {1} new measurement values \r\nFirst timestamp={2} \r\nFirst measval={3}",
                                                        signal.Name,
                                                        signal.ContinuousMeasurementValues.UpdatedValueCount, //Number of new measurement values filled into Values[0..n]
                                                        signal.ContinuousMeasurementValues.Timestamps[0],     //Timestamps for measurement values
                                                        signal.ContinuousMeasurementValues.Values[0]));       //this is an array of doubles containing the measurement values

                            // have a look at the continuousMeasurementValues in the property grid (see tab "MeasurementValues...") during execution
                            MeasurmentValuesPg.SelectedObject = signal.ContinuousMeasurementValues;
                        }

                        // With ComnmonAPI V6.0 it is possible to measure GenericSignals. Until now the only genericSignal that is implemented is
                        // the CanRawSignal, which delivers CanRawMessages as measurement values. Generic signals support an ADDITIONAL way to get measurement values
                        // of a certain type (here:CanRawMessages instead of doubles, which are however also filled for GenericSignals in a special way to keep the used way
                        // of getting measurement values also working)
                        AccessMeasurementValuesOfGenericSignal(signal);
                    }

                    Application.DoEvents(); // respond to GUI events

                    // wait a little to accumulate new measurement values
                    System.Threading.Thread.Sleep(50); //
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.ToString());
                this.StopContinuousMeasurementBt.PerformClick();
            }
            */
        }

        public void HBM_SaveRunContinuousMeasurement(string pathTestFile, List<string> lstChNames)
        {
            String path = !string.IsNullOrEmpty(pathTestFile) ? pathTestFile : @"D:\HBM_SaveAquisitionTxtData.txt";

            HelperTestBase.ProjectTest.Project.PrjTestFileName = path;
            //
            //this.RunContinuousMeasurementBt.Enabled = false;
            List<string> lstStr = new List<string>();
            string formTimestamp = string.Empty;

            List<double> lstTms = new List<double>();
            List<double> lstVal = new List<double>();

            List<string> lstStrCh = new List<string>();
            List<string> lstStrTimestamp = new List<string>();
            List<double> lstTmsCh = new List<double>();
            List<double>[] lstCh = new List<double>[12];

            int iUpdatedValueCount = 0;
            int k = 0;
            int i = 0;
            int j = 0;


            string strLinha = string.Empty;

            try
            {
                // run continuous measurement with the signals that were added to the measurement
                _daqMeasurement.StartDaq(DataAcquisitionMode.TimestampSynchronized); //DataAcquisitionMode.Unsynchronized
                _runMeasurement = true;
                HelperTestBase.running = true;

                while (_runMeasurement)
                {
                    // update measurement values of the signals that were added to the measurement:
                    _daqMeasurement.FillMeasurementValues();

                    // FillMeasurements updates the ContinuousMeasurementValues of all signals that
                    // were added to the measurement
                    // The next call of FillMeasurementValues will overwrite them again with new values....

                    // check the signals that were added to the measurement for new measurement values...
                    //foreach (Signal signal in _signalsToMeasure)
                    //{
                    for (k = 0; k < _signalsToMeasure.Count; k++)
                    {
                        Signal signal = _signalsToMeasure[k];

                        // this is the way you get the measurement values (as doubles) from ALL signals (no matter what type of signal)
                        // that take part in the measurement (check Signal.ContinuousMeasurementValues)
                        if (signal.ContinuousMeasurementValues.UpdatedValueCount > 0)
                        {
                            try
                            {
                                helperLog.HbmAddMessageToProtocol("-------------------------");

                                var data = string.Format("Signal {0} has {1} new measurement values \r\nFirst timestamp={2} \r\nFirst measval={3}",
                                signal.Name,
                                signal.ContinuousMeasurementValues.UpdatedValueCount, //Number of new measurement values filled into Values[0..n]
                                signal.ContinuousMeasurementValues.Timestamps,     //Timestamps for measurement values
                                signal.ContinuousMeasurementValues.Values);

                                helperLog.HbmAddMessageToProtocol(data);       //this is an array of doubles containing the measurement values

                                // have a look at the continuousMeasurementValues in the property grid (see tab "MeasurementValues...") during execution
                                //MeasurmentValuesPg.SelectedObject = signal.ContinuousMeasurementValues;

                                formTimestamp = DateTime.Now.ToString("dd/MM/yyyy-HH:mm:ss.ffff",
                                        CultureInfo.InvariantCulture);

                                string nms = signal.Name;


                                lstStrTimestamp.Clear();
                                lstTms.Clear();
                                lstVal.Clear();
                                //

                                iUpdatedValueCount = signal.ContinuousMeasurementValues.UpdatedValueCount;
                                lstTms = signal.ContinuousMeasurementValues.Timestamps.ToList();
                                lstVal = signal.ContinuousMeasurementValues.Values.ToList();


                                lstCh[k] = new List<double>();

                                for (i = 1; i < iUpdatedValueCount - 1; i++)
                                {
                                    lstCh[k].Add(Math.Round(lstVal[i], 4));
                                    lstStrTimestamp.Add(formTimestamp);

                                    //lstTmsCh.Add(Math.Round(lstTms[i],4));
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message, ex.ToString());
                                StopContinuousMeasurement(pathTestFile);
                                //this.StopContinuousMeasurementBt.PerformClick();
                            }
                        }
                        else
                        {
                            _myDevice.ReadSingleMeasurementValue(new List<Signal>() { signal });

                            // get a measurement value from all signals of the device:
                            //_myDevice.ReadSingleMeasurementValueOfAllSignals();

                            double dblSigValue = signal.GetSingleMeasurementValue().Value;
                            string strSigValue = dblSigValue.ToString("F3");

                            //AddToProtocol(string.Format("Measurement value of first signal={0}", strSigValue));
                            //AddToProtocol(string.Format("Timestamp of first signal={0}", signal.GetSingleMeasurementValue().Timestamp));

                            double dblTime = signal.GetSingleMeasurementValue().Timestamp;

                            //TimeSpan t = TimeSpan.FromMilliseconds(dblTime);
                            //string answer = string.Format("{0:D2}h:{1:D2}m:{2:D2}s:{3:D3}ms",
                            //        t.Hours,
                            //        t.Minutes,
                            //        t.Seconds,
                            //        t.Milliseconds);

                            //DateTime dt = DateTime.Now + t;
                            //var tmestamp = dt.ToString();

                            //DateTime dt1 = new DateTime().Add(TimeSpan.FromMilliseconds(dblTime));

                            string timestamp = DateTime.Now.ToString("dd/MM/yyyy - HH:mm:ss.fff",
                                            CultureInfo.InvariantCulture);


                            //AddToProtocol(string.Format("Timestamp of first signal={0}", timestamp));

                           // MeasurmentValuesPg.SelectedObject = signal.ContinuousMeasurementValues;
                        }

                        // With ComnmonAPI V6.0 it is possible to measure GenericSignals. Until now the only genericSignal that is implemented is
                        // the CanRawSignal, which delivers CanRawMessages as measurement values. Generic signals support an ADDITIONAL way to get measurement values
                        // of a certain type (here:CanRawMessages instead of doubles, which are however also filled for GenericSignals in a special way to keep the used way
                        // of getting measurement values also working)
                        // AccessMeasurementValuesOfGenericSignal(signal);
                    }


                    int idx = 0;

                    try
                    {
                        lstStrCh.Clear();
                        lstTmsCh.Clear();

                        lstTmsCh = lstTms;

                        if (lstCh[0].Count() < iUpdatedValueCount)
                            iUpdatedValueCount = lstCh[0].Count() - 1;

                        try
                        {
                            for (j = 0; j < iUpdatedValueCount; j += 50)
                            {
                                idx = j;

                                string row = string.Empty;

                                row = string.Format("{0}\t\t" +
                                "{1}\t\t {2}\t\t {3}\t\t {4}\t\t {5}\t {6}\t\t " +
                                "{7}\t\t {8}\t\t {9}\t\t {10}\t\t {11}\t\t {12}\t\t ",
                                lstTmsCh[j].ToString(),
                                lstCh[0][j].ToString(), lstCh[1][j].ToString(), lstCh[2][j].ToString(), lstCh[3][j].ToString(), lstCh[4][j].ToString(), lstCh[5][j].ToString(),
                                lstCh[6][j].ToString(), lstCh[7][j].ToString(), lstCh[8][j].ToString(), lstCh[9][j].ToString(), lstCh[10][j].ToString(), lstCh[11][j].ToString());

                                row = row.Replace("System.Collections.Generic.List`1[System.String]", "");

                                lstStrCh.Add(row);

                                if (lstStrCh.Count() > 0)
                                    _helperApp.sbinterno.Append(row);
                            }

                            if (lstStrCh.Count() > 0)
                                _helperApp.sbexterno.Append(_helperApp.sbinterno.ToString() + Environment.NewLine);

                            var sbMaxCap = (_helperApp.sbexterno.MaxCapacity * 0.1);

                            if (_helperApp.sbexterno.Length > sbMaxCap)
                            {
                                if (!_helperApp.CheckFileExists(path))
                                    File.WriteAllText(path, _helperApp.sbexterno.ToString());
                                else
                                    File.AppendAllLines(path, _helperApp.sbexterno.ToString().Split(Environment.NewLine.ToCharArray()));

                                HelperTestBase.ProjectTest.Project.is_Created = _helperApp.CheckFileExists(path);

                                _helperApp.sbexterno.Clear();
                            }
                            else
                                _helperApp.sbexterno.Append(lstStrCh);

                        }
                        catch (Exception ex)
                        {
                            var err = string.Concat("ex : ", idx, ex.Message);

                            throw;
                        }

                        Application.DoEvents(); // respond to GUI events

                        // wait a little to accumulate new measurement values
                        System.Threading.Thread.Sleep(50); //
                    }
                    catch (Exception ex)
                    {
                        var err = string.Concat("numero : ", idx, ex.Message);

                        throw;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.ToString());
                StopContinuousMeasurement(pathTestFile);
                //this.StopContinuousMeasurementBt.PerformClick();
            }
        }

        /// <summary>
        /// Handles CanRawMessages of GenericSignal (CanRawSignal)
        /// </summary>
        /// <param name="signal">Signal whose generic measurement values should be displayed</param>
        public void HbmAccessMeasurementValuesOfGenericSignal(Signal signal)
        {
            if (!(signal is IGenericSignal genericSignal))
            {
                // this is a normal signal (not a generic signal like CanRawSignal)
                // => nothing to do here...

                return;
            }

            if (genericSignal.GenericMeasurementValues.UpdatedValueCount <= 0)
            {
                return;
            }

            // until now we only have CanRawSignal implemented as generic signal
            // so we try to cast the GenericMeasurementValues into MeasurementValuesBase<CanRawMessage> to access the details
            if (genericSignal.GenericMeasurementValues is MeasurementValuesBase<CanRawMessage> canRawMeasurementValues)
            {
                helperLog.HbmAddMessageToProtocol($"Signal {signal.Name} has {canRawMeasurementValues.UpdatedValueCount} new CanRawMessages \r\n1.timestamp={canRawMeasurementValues.Timestamps[0]} \r\n1.CanMessageTimestamp = {canRawMeasurementValues.Values[0].Timestamp} \r\nHeader = {canRawMeasurementValues.Values[0].Header}");

                // Build Hex-string of the concatenated payloads...64Byte (always CanFD)
                StringBuilder sb = new StringBuilder();

                for (int i = 0; i < 64; i += 8)
                {
                    sb.Clear();

                    for (int ii = 0; ii < 8; ii++)
                    {
                        sb.Append($" {canRawMeasurementValues.Values[0].Payload[i + ii]:x2}");
                    }

                    helperLog.HbmAddMessageToProtocol($"Payload[{i} - {i + 7}] = {sb.ToString()}");
                }

                // show data in the property grid
                Console.WriteLine(canRawMeasurementValues); //the genericMeasurementValues of the signal (has to be a CanRawSignal in this case)
                Console.WriteLine(canRawMeasurementValues.Values[0]); //first CanRawMessage (in this case Values[0] is NOT just a double but a CanRawMessage object)

                // this is how to access the measurement values [0...canRawMeasurementValues.UpdatedValueCount-1]:
                // here: just access the first timestamp, state and value (CanRawMessage)
                // double relativeTimestampOfCanRawMessage = canRawMeasurementValues.Timestamps[0]; // relative timestamps (relative to measurement start) of the received CanRawMessages
                // MeasurementValueState state = canRawMeasurementValues.States[0];                 // states of the CanRawMessages (ALWAYS valid - just to be compatible to ContinuousMeasurementValues)
                // CanRawMessage canRawMessage = canRawMeasurementValues.Values[0];                 // CanRawMessages according to relative timestamps
                // ulong header = canRawMessage.Header;                                             // header of the CanRawMessage (4 bytes ID, 2 bytes length, 2 bytes not used)
                // double timestamp = canRawMessage.Timestamp;                                      // absolute timestamp of the CanRawMessage
                // byte[] payload = canRawMessage.Payload;                                          // 64 bytes payload (if CAN FD is not used, only the first 8 bytes contain data) of the CanRawMessage

                // if it is really a CanRawSignal, you can also access it directly via:
                // (((signal as IGenericSignal).GenericMeasurementValues) as MeasurementValuesBase<CanRawMessage>).Values[x] or .Timestamps[x].or.States[x], etc. or ever more simple:
                // (((signal as IGenericSignal).GenericMeasurementValues) as CanRawMeasurementValues).Values[0].Header or Values[0].Timestamp  or.Timestamps[x] or.States[x], etc.
            }
            else
            {
                //unknown type of generic signal measurement values so...skip
            }
        }

        /// <summary>
        /// Stops running measurement
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event arguments</param>
        public HelperHBM StopContinuousMeasurement(string pathTestFile)
        {
            try
            {
                // stop running data acquisition
                _runMeasurement = false;
                _daqMeasurement.StopDaq();

                //String path = !string.IsNullOrEmpty(pathTestFile) ? pathTestFile : @"D:\HBM_SaveAquisitionTxtData.txt";
                //File.AppendAllLines(path, _helperApp.sbexterno.ToString().Split(Environment.NewLine.ToCharArray()));


                msgReturn = "Continuous measuring stopped!";

                helperLog.HbmAddMessageToProtocol(msgReturn);

                _comReturnHBM.Status = true;
                _comReturnHBM.StopContinuousMeasurement = true;
            }
            catch (Exception ex)
            {
                msgReturn = ex.Message;
                HbmDisplayException(ex);

                _comReturnHBM.Status = false;
                _comReturnHBM.StopContinuousMeasurement = false;
            }

            _comReturnHBM.Message = msgReturn;

            return _comReturnHBM;
        }

        /// <summary>
        /// Disconnects the device
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event arguments</param>
        public void DisconnectDevice()
        {
            if (_runMeasurement)
                stopContinuousMeasurement = true;

            try
            {
                // disconnect the device
                _daqEnvironment.Disconnect(_myDevice);
                helperLog.HbmAddMessageToProtocol(string.Format("Device {0} has been disconnected.", _myDevice.Name));
            }
            catch (Exception ex)
            {
                HbmDisplayException(ex);
            }
        }

        //TODO
        public async Task<HelperHBM> StartAquisitionAsync()
        {
            try
            {
                _comReturnHBM = InitializeObjects();

                if (_comReturnHBM != null)
                {
                    msgReturn = _comReturnHBM.Message;

                    if (_comReturnHBM.Initialized && _comReturnHBM.Status)
                    {

                        int secDelay = int.Parse(_hbm_ScanIntervalSec) * 1000; //will sleep for x sec

                        for (int i = 1; i <= 5; i++) //will try for 5 scan
                        {
                            Console.WriteLine("Thread paused for {0} second", secDelay);
                            // Pause thread for 1 second
                            await Task.Delay(secDelay);

                            _comReturnHBM = ScanForDevices();

                            if (_comReturnHBM.DeviceSelected)
                                break;
                        }
                    }
                    else
                    {
                        msgReturn = string.Concat(_comReturnHBM.Message, "Fail ! ");
                    }

                    if (_comReturnHBM.DeviceSelected && _comReturnHBM.Status)
                        _comReturnHBM = ConnectSelectedDevice();

                    if (_comReturnHBM.DeviceConnected && _comReturnHBM.Status)
                        _comReturnHBM = PrepareContinuousMeasurement();

                    if (_comReturnHBM.PreparedContinuousMeasurement && _comReturnHBM.Status)
                        RunContinuousMeasurement();
                }
                else
                    msgReturn = string.Concat("HBM Communication Failed !", _helperApp.appMsg_Error);
            }
            catch (Exception ex)
            {
                msgReturn = string.Concat(ex.Message, _helperApp.appMsg_Error);
            }

            _comReturnHBM.Message = msgReturn;

            return _comReturnHBM;
        }
        #endregion

        #region Sensor database access

        /// <summary>
        /// Open HBM sensor database in readonly mode
        /// </summary>
        public void HbmOpenHbmSensorDb()
        {
            #region Enable/disable some buttons

            _logCreateLogger = true;

            #endregion

            try
            {
                helperLog.HbmAddMessageToProtocol("Open HBM Sensor Database for readonly access...");

                // _sensorDBManager = new SensorDBManager("en", String.Format("Data Source={0}", dlg.FileName) + ";Pooling=true;Open Mode=ExclusiveReadWrite;", "System.Data.VistaDB5");

                // Generate path to the location of the HBM sensor database
                string hbmSensorDatabaseFullFilename = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "HBMSensorDatabase.vdb5");

                // Create a sensorDBManager to get access to the sensor database (readonly)
                _sensorDBManagerForHbmSensorDatabase =
                    new SensorDBManager("en", "Data Source=" + hbmSensorDatabaseFullFilename + ";Open Mode=NonExclusiveReadOnly;", "System.Data.VistaDB5");

                helperLog.HbmAddMessageToProtocol("Database: HBMSensorDatabase.vdb5");
                helperLog.HbmAddMessageToProtocol("DatabaseProvioder: " + _sensorDBManagerForHbmSensorDatabase.ProviderInvariantName);
                helperLog.HbmAddMessageToProtocol("Connectionstring: " + _sensorDBManagerForHbmSensorDatabase.ConnectionString);
                helperLog.HbmAddMessageToProtocol("Database version: "
                            + _sensorDBManagerForHbmSensorDatabase.GetVersionInfo().Description
                            + " V."
                            + _sensorDBManagerForHbmSensorDatabase.GetVersionInfo().VersionNumber);
            }
            catch (Exception ex)
            {
                helperLog.HbmAddMessageToProtocol("Database error: " + ex.Message);

                while (ex.InnerException != null)
                {
                    HbmDisplayException(ex);
                    helperLog.HbmAddMessageToProtocol("Inner exception: " + ex.Message);
                    ex = ex.InnerException;
                }

                helperLog.HbmAddMessageToProtocol("**** Please copy HBMSensorDatabase.vdb5 and UserSensorDatabase.vdb5 into the executing directory of this demo!****");
            }
        }

        /// <summary>
        /// Gets a certain sensor from sensor database
        /// </summary>
        public void HbmGetCertainSensor()
        {
            Sensor sensor;

            // there are various ways to get a sensor...
            // e.g. by getting a list of all sensors of the sensor database (do that only once...) and search
            // for a specific sensor on your own...
            List<Sensor> listOfAllSensors = _sensorDBManagerForHbmSensorDatabase.GetSensors();               //gets a list of all sensors
            sensor = listOfAllSensors.Where(p => p.SensorType == Hbm.Api.SensorDB.Enums.SensorType.Voltage).First(); //searches for the first voltage sensor...

            // or e.g. let the sensorDBManager search for a sensor with a certain ID
            sensor = _sensorDBManagerForHbmSensorDatabase.GetSensor(112);

            // or e.g. let the sensorDBManager search for a sensor with a certain unique name
            sensor = _sensorDBManagerForHbmSensorDatabase.GetSensor("HBM_T22_50Nm");

            // update the propertyGrids to display the sensor settings and the scaling settings of the sensor
            var SensorSelectedObject = sensor;
            var SensorScalingSelectedObject = sensor.Scaling;
        }

        #endregion

        #region Logging

        /// <summary>
        /// Create a new logger object and start logging
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event arguments</param>
        public void HbmCreateLogger()
        {
            #region Enable/disable some buttons

            _logCreateContexts = true;
            _logCreateLogger = false;

            #endregion


            // Start logging with a certain LoggingFramework (Loupe or NLog) and a combination of "ORed" LogLevels:
            // e.g.: LogManager.Start(LoggingFramework.Loupe, LogLevel.Error | LogLevel.Warn | LogLevel.Info );
            // e.g.: LogManager.Start(LoggingFramework.Loupe, LogLevel.All);
            // e.g.: LogManager.Start(LoggingFramework.NLog, LogLevel.Error | LogLevel.Warn | LogLevel.Info);
            // The directory, in which the logfiles will be saved, can be queried using the LogManager:
            // LogManager.LogFolder returns the path that is used to save the logfiles.
            // e.g.: C:\Users\Username\AppData\Local\HBM\Logs\Hbm.Api.DemoProject
            LogManager.Start(LoggingFramework.NLog, LogLevel.Error | LogLevel.Warn | LogLevel.Info);

            // See http://www.gibraltarsoftware.com/ for a free logging viewer for the Loupe logging framework
            // (otherwise you can not read the logfile since Loupe saves the logfile in a binary format)

            // NLog logs into a textfile and you do not need a special viewer. LogEntries with low LogLevels like
            // LogLevel.Info or LogLevel.Trace will be buffered until a certain number of entries has been
            // accumulated or an entry with a higher LogLevel (e.g.LogLevel.Error) will be logged.

            // Create a logger object that has to be used to log messages
            _logger = LogManager.CreateLogger("ApiDemo");

            helperLog.HbmAddMessageToProtocol("Logging has been started...");
        }

        /// <summary>
        /// Create different LogContexts to group log messages
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event arguments</param>
        public void HbmCreateLogContexts()
        {
            #region Enable/disable some buttons

            _logAddEntryToMeasurementGroup = true;
            _logAddEntryToProblemsGroup = true;
            _logEndLogging = true;
            _logCreateContexts = false;

            #endregion

            // We want to group our log entries into different parts. Logging uses LogContext objects to define these groups.
            // Notice: The Hbm.CommonAPI will also log messages additional to the messages that will be logged here!

            // E.g.: One group to collect entries concerning measurement tasks:
            _logContextApiDemoMeasuring = new LogContext("ApiDemo.Measurement"); // context to log messages in a hierarchical way here: Messages related to measurement issues

            // E.g.: One group to collect entries concerning problems:
            _logContextApiDemoProblems =
                new LogContext("ApiDemo.Problems"); // context to log messages in a hierarchical way here: Messages related to problems that occurred during the execution of the demo

            // The resulting hierarchy into which the entries can be logged (using Loupe) is now:
            // Categories
            //  - ApiDemo
            //      - Measurement
            //          - Error: Log entry number 0 for measurement context from ApiDemo!
            //          - Info: Log entry number 1 for measurement context from ApiDemo!
            //          ...
            //      - Problems
            //          - Debug: Log entry number 2 for problems context from ApiDemo!
            //          - Info: Log entry number 3 for problems context from ApiDemo!
            //          ...
            // using Nlog, these hierarchy infos are included in the line that will be appended to the logfile
            // e.g.: 2015-09-10 09:37:25.1234 [10] ERROR |ApiDemo.Measurement| ApiDemo: Error: Log entry number 0 for measurement context from ApiDemo!

            helperLog.HbmAddMessageToProtocol("LogContext for ApiDemo.Measurement and ApiDemo.Problems have been created");
        }

        /// <summary>
        /// Create different log entries for the group "ApiDemo.Measuring" (using the related LogContext)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void HbmAddLogEntryToMeasurementGroup()
        {
            // this entry will be logged because we started logging with LogManager.Start(LoggingFramework.NLog, LogLevel.Error | LogLevel.Warn | LogLevel.Info)
            _logger.ErrorFormat(_logContextApiDemoMeasuring, "Error: Log entry number {0} for measurement context from ApiDemo!", _logNumberDummy++);

            // this entry will *** N O T *** be logged because we started logging with LogManager.Start(LoggingFramework.NLog, LogLevel.Error | LogLevel.Warn | LogLevel.Info)
            // change the start command to LogManager.Start(LoggingFramework.NLog, LogLevel.Error | LogLevel.Warn | LogLevel.Info | LogLevel.Debug) to log the following entry!
            _logger.DebugFormat(_logContextApiDemoMeasuring, "Debug: Log entry number {0} for measurement context from ApiDemo!", _logNumberDummy++);

            helperLog.HbmAddMessageToProtocol("Various log entries have been added to the ApiDemo.Measuring group of the log file.");
        }

        /// <summary>
        /// Create different log entries for the group "ApiDemo.Problems" (using the related LogContext)
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event arguments</param>
        public void HbmAddLogEntryToProblemsGroup()
        {
            // following entry will be logged:
            _logger.InfoFormat(_logContextApiDemoProblems, "Info: Log entry number {0} for problems context from ApiDemo!", _logNumberDummy++);

            helperLog.HbmAddMessageToProtocol("Various log entries have been added to the ApiDemo.Problems group of the log file.");
        }

        /// <summary>
        /// End logging
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event arguments</param>
        public void HbmEndLogging()
        {
            #region Enable/disable some buttons

            _logAddEntryToMeasurementGroup = false;
            _logAddEntryToProblemsGroup = false;
            _logEndLogging = false;
            _logCreateLogger = true;

            #endregion

            // End logging.
            LogManager.Stop();
            helperLog.HbmAddMessageToProtocol("Logging has been stopped.");
        }

        /// <summary>
        /// Opens the directory in which the logfile will be created if logging is enabled.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event arguments</param>
        public void HbmOpenLogfileDirectoryInExplorer()
        {
            try
            {
                // Open the directory in which the logfile will be created
                Process.Start("explorer.exe", LogManager.LogFolder);

                // Use LogManager.CurrentLogFile to get the full path including the filename of the logfile
                helperLog.HbmAddMessageToProtocol("Full path to logfile is: " + LogManager.CurrentLogFile);
            }
            catch (Exception ex)
            {
                HbmDisplayException(ex);
                helperLog.HbmAddMessageToProtocol("Problems opening path to logfile: " + ex.Message);
            }
        }

        #endregion

        public string HbmDisplayException(Exception exception)
        {
            Console.WriteLine(exception.Message);

            return exception == null ? "" : exception.GetBaseException().Message;
        }

        #region Session HBM

        private static bool _HBM_EnableCom;
        public static bool HBM_EnableCom
        {

            get { return ComHBM._HBM_EnableCom; }
            set { ComHBM._HBM_EnableCom = value; }
        }

        #region Session Tags EtherCAT_IO_Analogicas

        private static double _rTimeStamp;                       //ch9.10 - B07.11 - Pressao Linha Vacuo (-1)-0 bar (Linearizada)
        private static double _rDeslocamentoDiferencial_mm_Lin;      //ch9.1 - B01.17 - Transdutor Deslocamento Desvio Linearidade - 0-10 mm (Linearizado)
        private static double _rForcaEntradaBooster_N_Lin;           //ch9.2 - B10.01 - Celula Carga Forca Entrada - 0-5 kN (Linearizada)
        private static double _rForcaSaidaBooster_N_Lin;             //ch9.3 - B10.02 - Celula Carga Forca Saída- 0-10 kN (Linearizada)
        private static double _rDeslocamentoSaidaBooster_mm_Lin;     //ch9.4 - B11.02 - Transdutor Deslocamento Saida Booster - 0-50 mm (Linearizada)
        private static double _rDeslocamentoEntradaBooster_mm_Lin;   //ch9.5 - B11.01 - Transdutor Deslocamento Entrada Booster - 0-50 mm (Linearizada)
        private static double _rPressaoCS_Bar_Lin;                   //ch9.6 - B06.03 - Pressao Camara Secundaria CS - 0-250 bar (Linearizada
        private static double _rPressaoCP_Bar_Lin;                   //ch9.7 - B05.03 - Pressao Camara Primaria CP - 0-250 bar (Linearizada)
        private static double _rPressaoBubbleTest_Bar_Lin;           //ch9.8 - B03.03 - Pressao Teste Bolhas 0-1 bar(Linearizada)
        private static double _rPressaoHidraulica_Bar_Lin;           //ch9.9 - B04.20 - Pressao Sangria 0-6 bar (Linearizada)
        private static double _rVacuo_Bar_Lin;                       //ch9.10 - B07.11 - Pressao Linha Vacuo (-1)-0 bar (Linearizada)

        //get e set
        public static double rTimeStamp
        {

            get { return ComHBM._rTimeStamp; }
            set { ComHBM._rTimeStamp = value; }
        }
        public static double rDeslocamentoDiferencial_mm_Lin
        {

            get { return ComHBM._rDeslocamentoDiferencial_mm_Lin; }
            set { ComHBM._rDeslocamentoDiferencial_mm_Lin = value; }
        }
        public static double rForcaEntradaBooster_N_Lin
        {

            get { return ComHBM._rForcaEntradaBooster_N_Lin; }
            set { ComHBM._rForcaEntradaBooster_N_Lin = value; }
        }
        public static double rForcaSaidaBooster_N_Lin
        {

            get { return ComHBM._rForcaSaidaBooster_N_Lin; }
            set { ComHBM._rForcaSaidaBooster_N_Lin = value; }
        }
        public static double rDeslocamentoSaidaBooster_mm_Lin
        {

            get { return ComHBM._rDeslocamentoSaidaBooster_mm_Lin; }
            set { ComHBM._rDeslocamentoSaidaBooster_mm_Lin = value; }
        }
        public static double rDeslocamentoEntradaBooster_mm_Lin
        {

            get { return ComHBM._rDeslocamentoEntradaBooster_mm_Lin; }
            set { ComHBM._rDeslocamentoEntradaBooster_mm_Lin = value; }
        }
        public static double rPressaoCS_Bar_Lin
        {

            get { return ComHBM._rPressaoCS_Bar_Lin; }
            set { ComHBM._rPressaoCS_Bar_Lin = value; }
        }
        public static double rPressaoCP_Bar_Lin
        {

            get { return ComHBM._rPressaoCP_Bar_Lin; }
            set { ComHBM._rPressaoCP_Bar_Lin = value; }
        }
        public static double rPressaoBubbleTest_Bar_Lin
        {

            get { return ComHBM._rPressaoBubbleTest_Bar_Lin; }
            set { ComHBM._rPressaoBubbleTest_Bar_Lin = value; }
        }
        public static double rPressaoHidraulica_Bar_Lin
        {

            get { return ComHBM._rPressaoHidraulica_Bar_Lin; }
            set { ComHBM._rPressaoHidraulica_Bar_Lin = value; }
        }
        public static double rVacuo_Bar_Lin
        {

            get { return ComHBM._rVacuo_Bar_Lin; }
            set { ComHBM._rVacuo_Bar_Lin = value; }
        }

        #endregion
        #endregion
    }

    #region Tags EtherCAT_IO_Analogicas

    /*
    public class EtherCAT_IO_Analogicas
    {
        public double rTimeStamp;                       //ch9.10 - B07.11 - Pressao Linha Vacuo (-1)-0 bar (Linearizada)
        public double rDeslocamentoDiferencial_mm_Lin;      //ch9.1 - B01.17 - Transdutor Deslocamento Desvio Linearidade - 0-10 mm (Linearizado)
        public double rForcaEntradaBooster_N_Lin;           //ch9.2 - B10.01 - Celula Carga Forca Entrada - 0-5 kN (Linearizada)
        public double rForcaSaidaBooster_N_Lin;             //ch9.3 - B10.02 - Celula Carga Forca Saída- 0-10 kN (Linearizada)
        public double rDeslocamentoSaidaBooster_mm_Lin;     //ch9.4 - B11.02 - Transdutor Deslocamento Saida Booster - 0-50 mm (Linearizada)
        public double rDeslocamentoEntradaBooster_mm_Lin;   //ch9.5 - B11.01 - Transdutor Deslocamento Entrada Booster - 0-50 mm (Linearizada)
        public double rPressaoCS_Bar_Lin;                   //ch9.6 - B06.03 - Pressao Camara Secundaria CS - 0-250 bar (Linearizada
        public double rPressaoCP_Bar_Lin;                   //ch9.7 - B05.03 - Pressao Camara Primaria CP - 0-250 bar (Linearizada)
        public double rPressaoBubbleTest_Bar_Lin;           //ch9.8 - B03.03 - Pressao Teste Bolhas 0-1 bar(Linearizada)
        public double rPressaoHidraulica_Bar_Lin;           //ch9.9 - B04.20 - Pressao Sangria 0-6 bar (Linearizada)
        public double rVacuo_Bar_Lin;                       //ch9.10 - B07.11 - Pressao Linha Vacuo (-1)-0 bar (Linearizada)
    }
    */
    #endregion
}
