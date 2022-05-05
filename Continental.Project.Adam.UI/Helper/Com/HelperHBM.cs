
using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using Hbm.Api.Common.Entities;
using Hbm.Api.Common.Entities.Signals;

namespace Continental.Project.Adam.UI.Helper.Com
{
    public class HelperHBM
    {
        public bool Initialized { get; set; }
        public bool RegisterEvent{ get; set; }
        public bool DeviceSelected { get; set; }
        public bool DeviceConnected { get; set; }
        public bool PreparedContinuousMeasurement { get; set; }
        public bool RunningContinuousMeasurement { get; set; }
        public bool StopContinuousMeasurement { get; set; }
        public string Message { get; set; }
        public bool Status { get; set; }
        public Signal HbmSignal { get; set; }

       

        public string AddMessageToDisplayLog(string message)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(message + Environment.NewLine);
            Console.WriteLine(sb);

            return sb.ToString();
        }

        public bool HBM_ContinuousMeasurementAquisition(Signal signal)
        {
            string msgReadContinousData = (string.Format("Signal {0} has {1} new measurement values \r\nFirst timestamp={2} \r\nFirst measval={3}",
                                                       signal.Name,
                                                       signal.ContinuousMeasurementValues.UpdatedValueCount, //Number of new measurement values filled into Values[0..n]
                                                       signal.ContinuousMeasurementValues.Timestamps[0],     //Timestamps for measurement values
                                                       signal.ContinuousMeasurementValues.Values[0]));       //this is an array of doubles containing the measurement values


            AddMessageToDisplayLog(msgReadContinousData);

            bool acqRetrun = false;
            //ch9.1 - B01.17 - Transdutor Deslocamento Desvio Linearidade - 0-10 mm (Linearizado)
            //ch9.2 - B10.01 - Celula Carga Forca Entrada - 0-5 kN (Linearizada)
            //ch9.3 - B10.02 - Celula Carga Forca Saída- 0-10 kN (Linearizada)
            //ch9.4 - B11.01 - Transdutor Deslocamento Entrada Booster - 0-50 mm (Linearizada)
            //ch9.5 - B11.02 - Transdutor Deslocamento Saida Booster - 0-50 mm (Linearizada)
            //ch9.6 - B06.03 - Pressao Camara Secundaria CS - 0-250 bar (Linearizada
            //ch9.7 - B05.03 - Pressao Camara Primaria CP - 0-250 bar (Linearizada)
            //ch9.8 - B03.03 - Pressao Teste Bolhas 0-1 bar(Linearizada)
            //ch9.9 - B04.20 - Pressao Sangria 0-6 bar (Linearizada)
            //ch9.10 - B07.11 - Pressao Linha Vacuo (-1)-0 bar (Linearizada)

            try
            {
                HelperHBM.rTimeStamp = signal.ContinuousMeasurementValues.Timestamps[0];
                HelperHBM.strTimeStamp = signal.ContinuousMeasurementValues.Timestamps[0].ToString();

                var signalValue = signal.ContinuousMeasurementValues.Values[0].ToString();

                switch (signal.Name.Trim())
                {
                    case "ch9.1":
                        HelperHBM._rDiffTravel = Convert.ToDouble(signalValue);
                        break;
                    case "ch9.2":
                        HelperHBM._rInputForce1 = Convert.ToDouble(signalValue);
                        break;
                    case "ch9.3":
                        HelperHBM._rOutputForce = Convert.ToDouble(signalValue);
                        break;
                    case "ch9.4":
                        HelperHBM._rTravelTMC = Convert.ToDouble(signalValue);
                        break;
                    case "ch9.5":
                        HelperHBM._rTravelPiston = Convert.ToDouble(signalValue);
                        break;
                    case "ch9.6":
                        HelperHBM._rPressureSC = Convert.ToDouble(signalValue);
                        break;
                    case "ch9.7":
                        HelperHBM._rPressurePC = Convert.ToDouble(signalValue);
                        break;
                    case "ch9.8":
                        HelperHBM._rPneumTestPressure = Convert.ToDouble(signalValue);
                        break;
                    case "ch9.9":
                        HelperHBM._rHydrFillPressure = Convert.ToDouble(signalValue);
                        break;
                    case "ch9.10":
                        HelperHBM._rVacuum = Convert.ToDouble(signalValue);
                        break;
                    default:
                        // code block
                        break;
                }

                acqRetrun = true;
            }
            catch (Exception ex)
            {
                var err = ex.Message;
                acqRetrun = false;
                throw;
            }

            return acqRetrun;
        }
        public bool HBM_ContinuousMeasurementAquisition(List<string> lstSignal)
        {
            bool acqRetrun = false;
            //ch9.1 - B01.17 - Transdutor Deslocamento Desvio Linearidade - 0-10 mm (Linearizado)
            //ch9.2 - B10.01 - Celula Carga Forca Entrada - 0-5 kN (Linearizada)
            //ch9.3 - B10.02 - Celula Carga Forca Saída- 0-10 kN (Linearizada)
            //ch9.4 - B11.01 - Transdutor Deslocamento Entrada Booster - 0-50 mm (Linearizada)
            //ch9.5 - B11.02 - Transdutor Deslocamento Saida Booster - 0-50 mm (Linearizada)
            //ch9.6 - B06.03 - Pressao Camara Secundaria CS - 0-250 bar (Linearizada
            //ch9.7 - B05.03 - Pressao Camara Primaria CP - 0-250 bar (Linearizada)
            //ch9.8 - B03.03 - Pressao Teste Bolhas 0-1 bar(Linearizada)
            //ch9.9 - B04.20 - Pressao Sangria 0-6 bar (Linearizada)
            //ch9.10 - B07.11 - Pressao Linha Vacuo (-1)-0 bar (Linearizada)

            try
            {

                foreach (var item in lstSignal.Select((value, i) => (value, i)))
                {
                    var signalIndex = item.i;

                    var signalValue = item.value.ToString();
                    //var signalValue = signal.ContinuousMeasurementValues.Values[0];


                    switch (signalIndex)
                    {
                        case 0:
                            HelperHBM.strTimeStamp = signalValue;
                            break;
                        case 1:
                            HelperHBM.rDiffTravel = Convert.ToDouble(signalValue); //rDeslocamentoDiferencial_mm_Lin
                            break;
                        case 2:
                            HelperHBM.rInputForce1 = Convert.ToDouble(signalValue); //rForcaEntradaBooster_N_Lin
                            break;
                        case 3:
                            HelperHBM.rOutputForce = Convert.ToDouble(signalValue);
                            break;
                        case 4:
                            HelperHBM.rTravelTMC = Convert.ToDouble(signalValue);
                            break;
                        case 5:
                            HelperHBM._rTravelPiston = Convert.ToDouble(signalValue);
                            break;
                        case 6:
                            HelperHBM._rPressureSC = Convert.ToDouble(signalValue);
                            break;
                        case 7:
                            HelperHBM._rPressurePC = Convert.ToDouble(signalValue);
                            break;
                        case 8:
                            HelperHBM._rPneumTestPressure = Convert.ToDouble(signalValue);
                            break;
                        case 9:
                            HelperHBM._rHydrFillPressure = Convert.ToDouble(signalValue);
                            break;
                        case 10:
                            HelperHBM._rVacuum = Convert.ToDouble(signalValue);
                            break;
                        default:
                            // code block
                            break;
                    }
                }

                acqRetrun = true;
            }
            catch (Exception ex)
            {
                var err = ex.Message;
                acqRetrun = false;
                throw;
            }

            return acqRetrun;
        }

        #region Session HBM

        private static MeasurementValues _MeasurmentValuesPgSelectedObject;
        private static string _MessageToProtocol;

        public static MeasurementValues MeasurmentValuesPgSelectedObject
        {

            get { return HelperHBM._MeasurmentValuesPgSelectedObject; }
            set { HelperHBM._MeasurmentValuesPgSelectedObject = value; }
        }

        public static string MessageToProtocol
        {

            get { return HelperHBM._MessageToProtocol; }
            set { HelperHBM._MessageToProtocol = value; }
        }
        #endregion

        #region Session Tags Test TXT

        private static string _strTimeStamp;
        private static double _dblAnalogVar01;
        private static double _dblAnalogVar02;
        private static double _dblAnalogVar03;
        private static double _dblAnalogVar04;
        public static string strTimeStamp
        {
            get { return HelperHBM._strTimeStamp; }
            set { HelperHBM._strTimeStamp = value; }
        }
        public static double dblAnalogVar01
        {
            get { return HelperHBM._dblAnalogVar01; }
            set { HelperHBM._dblAnalogVar01 = value; }
        }
        public static double dblAnalogVar02
        {
            get { return HelperHBM._dblAnalogVar02; }
            set { HelperHBM._dblAnalogVar02 = value; }
        }
        public static double dblAnalogVar03
        {
            get { return HelperHBM._dblAnalogVar03; }
            set { HelperHBM._dblAnalogVar03 = value; }
        }
        public static double dblAnalogVar04
        {
            get { return HelperHBM._dblAnalogVar04; }
            set { HelperHBM._dblAnalogVar04 = value; }
        }
        #endregion

        #region Session Tags EtherCAT_IO_Analogicas

        private static double _rTimeStamp;
        
        private static double _rDiffTravel;         //ch9.1 - DeslocamentoDiferencial_mm_Lin - B01.17 - Transdutor Deslocamento Desvio Linearidade - 0-10 mm (Linearizado)
        private static double _rInputForce1;        //ch9.2 - rForcaEntradaBooster_N - B10.01 - Celula Carga Forca Entrada - 0-5 kN (Linearizada)
        private static double _rOutputForce;        //ch9.3 - rForcaSaidaBooster_N - B10.02 - Celula Carga Forca Saída- 0-10 kN (Linearizada)
        private static double _rTravelPiston;       //ch9.4 - DeslocamentoEntradaBooster_mm_Lin  -B11.01 - Transdutor Deslocamento Entrada Booster - 0-50 mm (Linearizada)
        private static double _rTravelTMC;          //ch9.5 - DeslocamentoSaidaBooster_mm_Lin - B11.02 - Transdutor Deslocamento Saida Booster - 0-50 mm (Linearizada)
        private static double _rPressureSC;         //ch9.6 - PressaoCS_Bar_Lin - B06.03 - Pressao Camara Secundaria CS - 0-250 bar (Linearizada
        private static double _rPressurePC;         //ch9.7 - PressaoCP_Bar_Lin - B05.03 - Pressao Camara Primaria CP - 0-250 bar (Linearizada)
        private static double _rPneumTestPressure;  //ch9.8 - PressaoBubbleTest_Bar_Lin - B03.03 - Pressao Teste Bolhas 0-1 bar(Linearizada)
        private static double _rHydrFillPressure;   //ch9.9 - PressaoHidraulica_Bar_Lin - B04.20 - Pressao Sangria 0-6 bar (Linearizada)
        private static double _rVacuum;             //ch9.10 - Vacuo_Bar_Lin - B07.11 - Pressao Linha Vacuo (-1)-0 bar (Linearizada)

        //get e set
        public static double rTimeStamp
        {

            get { return HelperHBM._rTimeStamp; }
            set { HelperHBM._rTimeStamp = value; }
        }
        public static double rDiffTravel
        {
            get { return HelperHBM._rDiffTravel; }
            set { HelperHBM._rDiffTravel = value; }
        } //ch9.1 - DeslocamentoDiferencial_mm_Lin
        public static double rInputForce1
        {
            get { return HelperHBM._rInputForce1; }
            set { HelperHBM._rInputForce1 = value; }
        } //ch9.2 - rForcaEntradaBooster_N
        public static double rOutputForce  //ch9.3 - rForcaSaidaBooster_N
        {
            get { return HelperHBM._rOutputForce; }
            set { HelperHBM._rOutputForce = value; }
        }
        public static double rTravelTMC
        {
            get { return HelperHBM._rTravelTMC; }
            set { HelperHBM._rTravelTMC = value; }
        } //ch9.5 - DeslocamentoSaidaBooster_mm_Lin
        public static double rTravelPiston
        {
            get { return HelperHBM._rTravelPiston; }
            set { HelperHBM._rTravelPiston = value; }
        } //ch9.4 - DeslocamentoEntradaBooster_mm_Lin
        public static double rPressureSC
        {
            get { return HelperHBM._rPressureSC; }
            set { HelperHBM._rPressureSC = value; }
        } //ch9.6 - PressaoCS_Bar_Lin
        public static double rPressurePC
        {
            get { return HelperHBM._rPressurePC; }
            set { HelperHBM._rPressurePC = value; }
        } //ch9.7 - PressaoCP_Bar_Lin
        public static double rPneumTestPressure
        {
            get { return HelperHBM._rPneumTestPressure; }
            set { HelperHBM._rPneumTestPressure = value; }
        } //ch9.8 - PressaoBubbleTest_Bar_Lin
        public static double rHydrFillPressure
        {
            get { return HelperHBM._rHydrFillPressure; }
            set { HelperHBM._rHydrFillPressure = value; }
        } //ch9.9 - PressaoHidraulica_Bar_Lin
        public static double rVacuum
        {
            get { return HelperHBM._rVacuum; }
            set { HelperHBM._rVacuum = value; }
        } //ch9.10 - Vacuo_Bar_Lin

        #endregion
    }
}
