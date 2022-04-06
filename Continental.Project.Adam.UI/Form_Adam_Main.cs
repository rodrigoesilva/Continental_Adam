#region USING

using System;
using System.Windows.Forms;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Globalization;
using MetroFramework.Controls;

using Continental.Project.Adam.UI.BLL;
using Continental.Project.Adam.UI.COM;
using Continental.Project.Adam.UI.Enum;
using Continental.Project.Adam.UI.Helper.Com;
using Continental.Project.Adam.UI.Helper;

using CefSharp.WinForms;

using System.Collections;
using System.Net;

//using LiveCharts;
//using LiveCharts.Wpf;
//using LiveCharts.Geared;
//using LiveCharts.Defaults;

using DevExpress.XtraCharts;
using DevExpress.Utils;
using DevExpress.Utils.Extensions;

using Continental.Project.Adam.UI.Helper.Tests;
using Continental.Project.Adam.UI.Models.COM;
using Continental.Project.Adam.UI.Models.Operational;
using Continental.Project.Adam.UI.Models.Settings;
using System.Threading.Tasks;


#region HBM
// =================================================================
// Copyright (c) 2014-2020 HBM GmbH
//  
// THIS SOFTWARE/SOURCE CODE IS FOR DEMONSTRATION PURPOSE ONLY, 
// WITHOUT WARRANTY OF ANY KIND!
//
// DO NOT USE THIS SOURCE CODE UNALTERED IN PRODUCTION SOFTWARE!
// =================================================================

using System.ComponentModel;
using System.Text;

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

//Usings for QuantumX (only necessary, if you want to use special features of QuantumX devices)
//using Hbm.Api.QuantumX;
//using Hbm.Api.QuantumX.Connectors;
//using Hbm.Api.QuantumX.Channels;
//using Hbm.Api.QuantumX.Signals;

//Usings for GenericStreaming (only necessary, if you want to use generic streaming devices)
//using Hbm.Api.GenericStreaming;


using System.Threading;
using Hbm.Api.SensorDB;
using Hbm.Api.SensorDB.Entities;
using System.Windows.Forms.VisualStyles;

using Hbm.Api.Common.Entities.SpectrumInfos;
using Hbm.Api.Common.Entities.Values;
using static Continental.Project.Adam.UI.COM.ComHBM;

#endregion

#endregion

namespace Continental.Project.Adam.UI
{
    public partial class Form_Adam_Main : Form
    {
        #region Define

        private bool _bAppStart = false;
        private bool _bCoBSelectTestSelected = false;
        private bool _bUseChkGrid = false;

        private string _notReadValue = "NaN";
        private string _initialDirPathTestFile = string.Empty;

        private string _prjTestFilename = string.Empty;
        private string _prjTestHeaderFilename = string.Empty;
        private string _prjTestFilenameUnion = string.Empty;

        private string _strTimeStamp = DateTime.Now.ToString("dd/MM/yyyy - HH:mm:ss.fff", CultureInfo.InvariantCulture);

        private bool tab_TableResultsEnable = false;

        public StringBuilder sbDataFile = new StringBuilder();

        List<string>[] lstStrChReadFileArr = new List<string>[13];

        List<double>[] lstDblChReadFileArr = new List<double>[13];


        #region General Settings

        //General Settings - CBO Actuation Mode
        int IdActuationMode = 0;

        //General Settings - Panel Vacuum
        string strVacuumValue = string.Empty;

        //General Settings - Panel Consumers
        int iConsumerType = 0;
        int iConsumerPC = 0;
        int iConsumerSC = 0;
        bool bPistonLock = false;

        #endregion

        #region Actuation

        string strName = string.Empty;

        string strMaxForceValue = string.Empty;

        string strGradientForceValue = string.Empty;

        #endregion

        #region Helpers

        HelperApp _helperApp = new HelperApp();

        HelperCom _helperCom = new HelperCom();

        HelperHBM _helperHBM = new HelperHBM();

        HelperMODBUS _helperMODBUS = new HelperMODBUS();

        #endregion

        #region COM

        #region HBM

        ComHBM _comHBM = new ComHBM();

        string strMessageToDisplayLog = string.Empty;

        private delegate void EnableDelegate(bool enable);

        public Signal signal;

        #endregion

        #region Modbus

        Dictionary<int, string> dicCom_Modbus_CLP_To_C = new Dictionary<int, string>();
        Dictionary<int, string> dicCom_Modbus_C_To_CLP = new Dictionary<int, string>();

        private ComModbusTCP MBmaster;
        private TextBox txtData;
        private Label labData;
        private byte[] arrReadData;
        private byte[] arrWriteData;

        #endregion

        #endregion

        #region MODELS

        Model_GVL _modelGVL = new Model_GVL();

        #endregion

        #region Colors Objects

        static Color colorChart = Color.FromArgb(240, 240, 240); //GRAY CHART
        System.Windows.Media.Color colorBgChart = System.Windows.Media.Color.FromArgb(colorChart.A, colorChart.R, colorChart.G, colorChart.B);

        Color colorON = Color.FromArgb(255, 192, 192); //vermelho
        Color colorOFF = Color.FromArgb(192, 255, 192); //verde
        Color colorAlarm = Color.FromArgb(255, 192, 192); //vermelho
        Color colorAlert = Color.FromArgb(255, 192, 192); //vermelho
                                                          //224; 224; 224 cinza
        #endregion

        #endregion

        #region _Initialize
        public Form_Adam_Main()
        {
            InitializeComponent();

            Form_Adam_InitializeComponents();
        }
        #endregion

        #region FORM MAIN
        private void Form_Adam_InitializeComponents()
        {
            try
            {
                //FORMS CONFIG
                this.ShowInTaskbar = false;
                this.ControlBox = false;
                this.Text = null;

                _bAppStart = true;
                timerMODBUS.Enabled = false;

                // Para ativar o relatório de progresso do background worker precisamos definir esta propriedade
                //_helperApp.bgWorker.WorkerReportsProgress = true;

                //COMMUNICATION
                if (!_helperApp.AppUseSimulateLocal)
                {
                    if (ComHBM.HBM_UseEnableCom)
                        HBM_Initialize();

                    if (ComModbusTCP.Modbus_UserEnableCom)
                        _helperMODBUS.HelperMODBUS_Initialize();

                    MBmaster = HelperMODBUS.Modbus_MBmaster;
                }
                //else
                //    StartSimulate();
            }
            catch (Exception ex)
            {
                var exc = ex.Message;
                MessageBox.Show(exc);
            }
        }
        private void Form_Adam_Main_Load(object sender, EventArgs e)
        {
            _initialDirPathTestFile = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, _helperApp.AppTests_Path);

            this.WindowState = FormWindowState.Maximized;

            //TabPages collection
           // TAB_Main.SelectedIndex = 2;
            //TAB_Main_SelectedIndexChanged(sender, e);
            TAB_Main_ActivePage(2);

            CONTROLS_EnableMetroButton();

            LOG_Clear();

            LOG_BindViewEvents();

            //BindDataParam();

            LOG_TestSequence(_helperApp.AppMsg_Welcome);

        }
        private void Form_Adam_Main_Shown(object sender, EventArgs e)
        {
            _bAppStart = false;

            DisableButtonStart();

            //  DisableButtonInfo();

            if (!timerMODBUS.Enabled)
                timerMODBUS.Enabled = true;
        }

        #endregion

        #region CONTROLS
        private void CONTROLS_EnableMetroButton()
        {
            var lstMetroButton1 = new List<Control>();
            var lstMetroButton2 = new List<Control>();

            foreach (var metroPanel in CONTROLS_GetAll(this, typeof(MetroFramework.Controls.MetroPanel)))
                lstMetroButton1 = CONTROLS_GetAll(metroPanel, typeof(MetroButton));
            foreach (var metroButton in lstMetroButton1.Cast<MetroButton>().ToList())
                metroButton.UseCustomBackColor = true;

            foreach (var tabControl in CONTROLS_GetAll(this, typeof(System.Windows.Forms.TabControl)))
                lstMetroButton2 = CONTROLS_GetAll(tabControl, typeof(MetroButton));
            foreach (var metroButton in lstMetroButton2.Cast<MetroButton>().ToList())
                metroButton.UseCustomBackColor = true;

            var lstMetroButton3 = CONTROLS_GetAll(this, typeof(MetroButton));
            foreach (var metroButton in lstMetroButton3.Cast<MetroButton>().ToList())
                metroButton.UseCustomBackColor = true;
        }
        public List<Control> CONTROLS_GetAll(Control control, Type type)
        {
            var controls = control.Controls.Cast<Control>();

            return controls.SelectMany(ctrl => CONTROLS_GetAll(ctrl, type))
                                      .Concat(controls)
                                      .Where(c => c.GetType() == type)
                                      .ToList();
        }

        #endregion

        #region BIND
        public void BindDataParam()
        {
            if (HelperApp.uiTesteSelecionado > 0)
            {
                #region General Settings
                //set Variables
                HelperApp.uiTesteSelecionado = Convert.ToInt32(mcbo_tabActParam_GenSettings_CoBSelectTest.SelectedValue.ToString());
                HelperTestBase.eExamType = EnumExtensionMethods.GetEnumValue<eEXAMTYPE>(HelperApp.uiTesteSelecionado);

                #region check box
                HelperTestBase.chkstartFromActual = mchk_tabActParam_GenSettings_CBStartFromSelection.Checked;
                HelperTestBase.chkWaitForUse = mchk_tabActParam_GenSettings_CBSWaitBetweenTests.Checked;
                HelperTestBase.chkPistonLock = mchk_tabActParam_GenSettings_CBStartFromSelection.Checked;
                #endregion

                #region Vacuum
                HelperTestBase.Vacuum = string.IsNullOrEmpty(mtxt_GeneralSettings_EParGenVaccum.Text) ? 0 : Convert.ToDouble(mtxt_GeneralSettings_EParGenVaccum.Text);
                HelperTestBase.VacuumMin = string.IsNullOrEmpty(mtxt_GeneralSettings_EParGenVaccumMin.Text) ? 0 : Convert.ToDouble(mtxt_GeneralSettings_EParGenVaccumMin.Text);
                HelperTestBase.VacuumMax = string.IsNullOrEmpty(mtxt_GeneralSettings_EParGenVaccumMax.Text) ? 0 : Convert.ToDouble(mtxt_GeneralSettings_EParGenVaccumMax.Text);
                #endregion

                #region Consumer

                #region check box

                HelperTestBase.iTipoConsumidores = rad_GeneralSettings_CBOriginalConsumer.Checked ? 1 : 2;

                #endregion

                #region HoseConsumer
                HelperTestBase.HoseConsumerPC = string.IsNullOrEmpty(mtxt_GeneralSettings_ETubeConsumerPCPressSide.Text) ? 0 : Convert.ToInt32(mtxt_GeneralSettings_ETubeConsumerPCPressSide.Text);
                HelperTestBase.HoseConsumerSC = string.IsNullOrEmpty(mtxt_GeneralSettings_ETubeConsumerSCPressSide.Text) ? 0 : Convert.ToInt32(mtxt_GeneralSettings_ETubeConsumerSCPressSide.Text);

                #endregion

                #endregion

                #endregion

                #region Actuation

                HelperTestBase.ActuationType = mcbo_tabActParam_GenSettings_CoBActuationMode.SelectedIndex;
                HelperTestBase.MaxForce = !string.IsNullOrEmpty(mtxt_Actuation_E1ParMaxForce.Text) ? Convert.ToDouble(mtxt_Actuation_E1ParMaxForce.Text) : 0;
                HelperTestBase.ForceGradient = !string.IsNullOrEmpty(mtxt_Actuation_E1ParForceGrad.Text) ? Convert.ToDouble(mtxt_Actuation_E1ParForceGrad.Text) : 0;

                #endregion

                #region Evaluation Parameters

                #region check box

                //HelperTestBase.chkOutputPC { get; set; }
                //HelperTestBase.chkOutputPC10_1_Printer { get; set; }

                //HelperTestBase.chkOutputSC { get; set; }
                //HelperTestBase.chkOutputSC10_1_Printer { get; set; }
                #endregion

                #region ParamList

                HelperTestBase.ParamEval = _helperApp.TransfValuesEvalParam(_helperApp.GridView_GetValuesEvalParam(grid_tabActionParam_EvalParam));

                #endregion

                #endregion
            }
        }

        #endregion

        #region BUTTONS

        #region BUTTONS HEADER
        private void mbtn_BStart_Click(object sender, EventArgs e)
        {
            TEST_Start_Command();

            TAB_Main.SelectedTab = TAB_Main.TabPages["tab_CPX_Visu"];
        }
        private void mbtn_BStop_Click(object sender, EventArgs e)
        {
            TEST_Stop_Command();
        }
        private void mtbn_BExportTestToXLS_Click(object sender, EventArgs e)
        {
            //_helperAdam.SMPrintGraphicsClick(sender);
        }

        private void mbtn_BReportPDF_Click(object sender, EventArgs e)
        {
            try
            {
                if (!CHART_ExportImage())
                {
                    MessageBox.Show("Failed, Chart Export !", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                ReportPDF();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        private void DisableButtonStart()
        {
            mbtn_BStart.Enabled = false;
            mbtn_BStop.Enabled = false;

            mcbo_tabActParam_GenSettings_CoBActuationMode.Enabled = false;

            mbtn_GeneralSettings_Minus_EParGenVaccum_Accel_L.Enabled = false;
            mbtn_GeneralSettings_Plus_EParGenVaccum_Accel_R.Enabled = false;


            mbtn_Actuation_Minus_E1ParMaxForce_Accel_L.Enabled = false;
            mbtn_Actuation_Plus_E1ParMaxForce_Accel_R.Enabled = false;


            mbtn_Actuation_Minus_E1ParForceGrad_Accel_L.Enabled = false;
            mbtn_Actuation_Plus_E1ParForceGrad_Accel_R.Enabled = false;

            devChart.Visible = false;
        }

        private void EnableButtonStart()
        {
            mbtn_BStart.Enabled = true;
            mbtn_BStop.Enabled = true;

            mcbo_tabActParam_GenSettings_CoBActuationMode.Enabled = true;

            mbtn_GeneralSettings_Minus_EParGenVaccum_Accel_L.Enabled = true;
            mbtn_GeneralSettings_Plus_EParGenVaccum_Accel_R.Enabled = true;


            mbtn_Actuation_Minus_E1ParMaxForce_Accel_L.Enabled = true;
            mbtn_Actuation_Plus_E1ParMaxForce_Accel_R.Enabled = true;


            mbtn_Actuation_Minus_E1ParForceGrad_Accel_L.Enabled = true;
            mbtn_Actuation_Plus_E1ParForceGrad_Accel_R.Enabled = true;
        }

        private void DisableButtonInfo()
        {
            mbtn_BHandshakePLC.Enabled = false;
            mbtn_BHandshakePC.Enabled = false;

            mbtn_BRecordStart.Enabled = false;
            mbtn_BRecordStop.Enabled = false;

            mbtn_BRecording.Enabled = false;
            mbtn_BRun.Enabled = false;
            mbtn_BEMotorRef.Enabled = false;

            mbtn_BAlert.Enabled = false;
            mbtn_BGlobalAlert.Enabled = false;
        }

        #endregion

        #region TABS

        #region TAB - Main
        private void TAB_Main_Selecting(object sender, TabControlCancelEventArgs e)
        {
            //hide a tab by removing it from the TabPages collection
            if (!_helperApp.AppUseSimulateLocal)
            {
                bool bTabAccessOk = tab_TableResultsEnable && HelperApp.uiTesteSelecionado > 0 && HelperTestBase.currentProjectTest.is_Created;

                if (e.TabPage == tab_TableResults || e.TabPage == tab_Diagram)
                    if (!bTabAccessOk)
                        e.Cancel = true;
            }
        }
        private void TAB_Main_SelectedIndexChanged(object sender, EventArgs e)
        {
            TAB_Main_ActivePage(TAB_Main.SelectedIndex);
        }
        public void TAB_Main_ActivePage(int tabIdx)
        {
            try
            {
                switch (tabIdx)
                {
                    case 0://tab_Diagram1_1
                        {
                            TAB_Main.SelectedTab = TAB_Main.TabPages["tab_Diagram"];

                            TAB_DiagramChart_SetData();
                            break;
                        }
                    case 1://TAB_TableResult
                        {
                            TAB_Main.SelectedTab = TAB_Main.TabPages["tab_TableResults"];

                            if (!TAB_TableResult_SetData())
                                MessageBox.Show("Failed, TAB_TableResult_SetData !", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error); ;

                            break;
                        }
                    case 2://TAB_ActuationParameters
                        {
                            if (TAB_Main.TabPages["tab_CPX_Visu"] == null)
                                TAB_CPXVisu_Create();

                            TAB_ActuationParameters_SetData();

                            TAB_Main.SelectedTab = TAB_Main.TabPages["Tab_ActuationParameters"];

                            //show a tab by adding it to the TabPages collection
                            tab_TableResultsEnable = true;

                            break;
                        }
                    case 3://tab_Dev
                        {
                            break;
                        }
                    case 4://tab_CPX
                        {
                            TAB_CPXVisu_SetData();
                            break;
                        }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);

                throw;
            }
        }

        #endregion

        #region TAB - Diagram_Chart
        public void TAB_DiagramChart_SetData()
        {
            if (HelperApp.uiTesteSelecionado != 0)
            {
                devChart.Visible = true;
                //    if (!_bAppStart)
                //    TXTFileHBM_LoadData();
            }
            else
            { 
                MessageBox.Show("Error, invalid test!", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Warning);  
            }       
        }
        private void OpenURLInBrowser(string url)
        {
            try
            {
                TAB_Main.SuspendLayout();

                ChromiumWebBrowser webBrowser = new ChromiumWebBrowser(url);

                var tabWebVisuCPX = new TabPage(url)
                {
                    Dock = DockStyle.Fill,
                    Text = "CPX_Visu",
                    Name = "tab_CPX_Visu"
                };

                tabWebVisuCPX.Controls.Add(webBrowser);

                if (TAB_Main.TabPages["tab_CPX_Visu"] == null)
                    TAB_Main.TabPages.Add(tabWebVisuCPX);

                //TAB_Main.SelectedTab = tabWebVisuCPX;

                TAB_Main.ResumeLayout(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        #endregion

        #region TAB - TableResults

        #region TAB - TableResults - Common
        private bool TAB_TableResult_SetData()
        {
            try
            {
                if (HelperApp.uiTesteSelecionado != 0)
                {
                    //grid
                    for (int i = 0; i < TAB_TableResult_Grid.Rows.Count; i++)
                    {
                        var row = TAB_TableResult_Grid.Rows[i];

                        if (row.Cells[0].Value == null)
                        {
                            BindingSource source = new BindingSource();
                            TAB_TableResult_Grid.DataSource = source;
                        }
                    }

                    Control metroPnl = CONTROLS_GetAll(this, typeof(MetroPanel)).Find(a => a.Name == "mpnl_Table_GivingOut");

                    IOrderedEnumerable<Control> lstChk = CONTROLS_GetAll(metroPnl, typeof(CheckBox)).OrderBy(m => m.Text);

                    if (!TAB_TableResults_Grid_GetData(HelperApp.uiTesteSelecionado.ToString()))
                        MessageBox.Show("Error, failed load result data test!", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Error, invalid test!", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    TAB_Main.SelectedTab = TAB_Main.TabPages["Tab_ActuationParameters"];

                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);

                TAB_Main.SelectedTab = TAB_Main.TabPages["Tab_ActuationParameters"];

                return false;
            }

            return true;
        }

        #endregion

        #region TAB - TableResults - Grid
        private bool TAB_TableResults_Grid_GetData(string strIdxTestSelected)
        {
            try
            {
                #region Get Grids Info

                //data info Grid Results
                BLL_Main_Tab_TableResults _bll_Main_TableResults = new BLL_Main_Tab_TableResults();

                DataTable dtTableResults = _bll_Main_TableResults.PopulateGridTableResultsByTest(strIdxTestSelected);

                if (dtTableResults.Rows.Count == 0)
                {
                    MessageBox.Show("Error, failed load result data test!", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                else
                {
                    #region CheckBoxes Result Parameters

                    List<Model_Operational_TestTableParameters> listResultParam = _helperApp.TabTableParameters_GetTableParam(dtTableResults, grid_tabActionParam_EvalParam);

                    HelperApp.lstResultParam.Clear();

                    HelperApp.lstResultParam = listResultParam;

                    //bind Checkboxes Table Results
                    TAB_TableResults_CheckBoxes(listResultParam);

                    #endregion
                }

                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);

                TAB_Main.SelectedTab = TAB_Main.TabPages["Tab_ActuationParameters"];

                return false;

                throw;
            }

            
            return true;
        }
        private void TAB_TableResult_Grid_Format(int chkId, string chkName, bool chkChecked)
        {
            try
            {
                List<Model_Operational_TestTableParameters> listTempResultParam = HelperApp.lstTempResultParam;

                Model_Operational_TestTableParameters itemResultParam_Element = HelperApp.lstResultParam.ElementAt(chkId); //.Select(a => a.EvalParam_Hi).FirstOrDefault().ToString()?.Trim();

                if (itemResultParam_Element != null)
                {
                    Model_Operational_TestTableParameters itemResultParam_Name = HelperApp.lstResultParam.Where(x => x.IdResultParam > 0 && x.ResultParam_Name.Equals(chkName)).FirstOrDefault(); //.Select(a => a.EvalParam_Hi).FirstOrDefault().ToString()?.Trim();

                    Model_Operational_TestTableParameters itemResultParam = itemResultParam_Element == itemResultParam_Name ? itemResultParam_Element : itemResultParam_Name;

                    if (chkChecked)
                        listTempResultParam.Add(itemResultParam);
                    else
                        listTempResultParam.Remove(itemResultParam);
                }

                List<Model_Operational_TestTableParameters> listResultParam = HelperApp.lstResultParam;

                BindingSource source = new BindingSource();
                source.DataSource = listTempResultParam;

                TAB_TableResult_Grid.DataSource = source;

                HelperApp.lstTempResultParam = listTempResultParam;

                for (int i = 0; i < TAB_TableResult_Grid.Rows.Count; i++)
                {
                    var row = TAB_TableResult_Grid.Rows[i];

                    var rowValue = row.Cells["IdResultParam"].Value;

                    //TAB_TableResult_Grid.Rows[i].Cells["IdResultParam"].Style.ForeColor = TAB_TableResult_Grid.Rows[i].Cells["IdResultParam"].Value != null ? Color.Black : Color.White;
                }

                #region Format Info Columns

                //TAB_TableResult_Grid.RowHeadersVisible = false;
                //TAB_TableResult_Grid.ColumnHeadersVisible = true;


                for (int i = 0; i < TAB_TableResult_Grid.Columns.Count; i++)
                {
                    TAB_TableResult_Grid.Columns[i].Visible = false;
                    TAB_TableResult_Grid.Columns[i].ReadOnly = true;
                    TAB_TableResult_Grid.Columns[i].HeaderCell.Value = String.Empty;
                    TAB_TableResult_Grid.Columns[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    TAB_TableResult_Grid.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    TAB_TableResult_Grid.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                    TAB_TableResult_Grid.Columns[i].Resizable = DataGridViewTriState.False;
                }

                //Changes grid's column's header's font size to 10.
                TAB_TableResult_Grid.ColumnHeadersDefaultCellStyle.Font = new Font("", 10.0f, FontStyle.Bold);
                //Changes grid's data's font size to 8.
                TAB_TableResult_Grid.Font = new Font("", 8.0f);

                //grid's column's

                //hide grid's column's
                TAB_TableResult_Grid.Columns[0].Visible = false; //ID
                TAB_TableResult_Grid.Columns[0].Width = 0;

                TAB_TableResult_Grid.Columns["IdResultParam"].HeaderCell.Value = string.Empty;//ID
                TAB_TableResult_Grid.Columns["IdResultParam"].Visible = true;
                TAB_TableResult_Grid.Columns["IdResultParam"].Width = 0;

                TAB_TableResult_Grid.Columns["ResultParam_Name"].HeaderCell.Value = string.Empty; //ResultParam_Name
                TAB_TableResult_Grid.Columns["ResultParam_Name"].Visible = true;
                TAB_TableResult_Grid.Columns["ResultParam_Name"].Width = 0;

                TAB_TableResult_Grid.Columns["ResultParam_Caption"].HeaderCell.Value = "Result"; //Parameter Result
                TAB_TableResult_Grid.Columns["ResultParam_Caption"].Visible = true;
                TAB_TableResult_Grid.Columns["ResultParam_Caption"].Width = 350;
                TAB_TableResult_Grid.Columns["ResultParam_Caption"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                TAB_TableResult_Grid.Columns["ResultParam_Nominal"].HeaderText = "Nominal"; //Col02
                TAB_TableResult_Grid.Columns["ResultParam_Nominal"].Visible = true;
                TAB_TableResult_Grid.Columns["ResultParam_Nominal"].ReadOnly = false;
                TAB_TableResult_Grid.Columns["ResultParam_Nominal"].Width = 250;

                TAB_TableResult_Grid.Columns["ResultParam_Measured"].HeaderText = "Measured"; //Col03
                TAB_TableResult_Grid.Columns["ResultParam_Measured"].Visible = true;
                TAB_TableResult_Grid.Columns["ResultParam_Measured"].Width = 150;

                TAB_TableResult_Grid.Columns["ResultParam_Unit"].HeaderCell.Value = "Unit";
                TAB_TableResult_Grid.Columns["ResultParam_Unit"].Visible = true; //UNIT
                TAB_TableResult_Grid.Columns["ResultParam_Unit"].Width = 120;

                #endregion

                #region set focus

                //int rowsCount = TAB_TableResult_Grid.Rows.Count;

                //if (rowsCount > 1)
                //{
                //    var rowIndex = rowsCount - 1;

                //    TAB_TableResult_Grid.CurrentCell = TAB_TableResult_Grid.Rows[rowIndex].Cells["ResultParam_Caption"];
                //    TAB_TableResult_Grid.Rows[rowIndex].Selected = true;
                //    TAB_TableResult_Grid.Rows[rowIndex].Cells["ResultParam_Caption"].Selected = true;
                //}

                #endregion

                HelperApp.lstResultParamFormated = HelperApp.lstTempResultParam;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);

                TAB_Main.SelectedTab = TAB_Main.TabPages["Tab_ActuationParameters"];
            }
        }
        private void TAB_TableResult_Grid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    var row = ((System.Windows.Forms.DataGridView)sender).CurrentRow;
                    string strIdTestAvailable = HelperApp.uiTesteSelecionado.ToString()?.Trim();
                    string strResultParam_Nominal = ((System.Windows.Forms.DataGridView)sender).CurrentCell.EditedFormattedValue.ToString();

                    if (!string.IsNullOrEmpty(strResultParam_Nominal) && row != null)
                        TAB_TableResults_Grid_WriteNominaParameters(row, strIdTestAvailable, strResultParam_Nominal);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void TAB_TableResults_Grid_WriteNominaParameters(DataGridViewRow row, string strIdTestAvailable, string strResultParam_Nominal)
        {
            try
            {
                int idResultParam = !string.IsNullOrEmpty(row.Cells["IdResultParam"].Value?.ToString()?.Trim()) ? Convert.ToInt32(row.Cells["IdResultParam"].Value?.ToString()?.Trim()) : 0;
                int idTestAvailable = !string.IsNullOrEmpty(strIdTestAvailable) ? Convert.ToInt32(strIdTestAvailable) : 0;

                if (idResultParam > 0 && idTestAvailable > 0 && idTestAvailable == HelperApp.uiTesteSelecionado)
                {
                    HelperApp.lstTempResultParam
                        .Where(x => x.IdResultParam > 0 && x.IdResultParam.Equals(idResultParam))
                        .FirstOrDefault().ResultParam_Nominal = strResultParam_Nominal?.ToString()?.Trim(); ;

                    HelperApp.lstResultParamFormated = HelperApp.lstTempResultParam;

                    BLL_Main_Tab_TableResults _bll_Main_TableResults = new BLL_Main_Tab_TableResults();

                    bool retUpdate = _bll_Main_TableResults.UpdateGridTableResultsByTest(idResultParam, idTestAvailable, strResultParam_Nominal.Trim());

                    if (!retUpdate)
                    {
                        MessageBox.Show("Error, failed update result data information!", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Error, test information incompatible!", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

            }
            catch (Exception)
            {

                throw;
            }
            
        }
        private void TAB_TableResult_Grid_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Error happened " + e.Context.ToString());

            if (e.Context == DataGridViewDataErrorContexts.Commit)
            {
                MessageBox.Show("Commit error");
            }
            if (e.Context == DataGridViewDataErrorContexts.CurrentCellChange)
            {
                MessageBox.Show("Cell change");
            }
            if (e.Context == DataGridViewDataErrorContexts.Parsing)
            {
                MessageBox.Show("parsing error");
            }
            if (e.Context == DataGridViewDataErrorContexts.LeaveControl)
            {
                MessageBox.Show("leave control error");
            }

            if ((e.Exception) is ConstraintException)
            {
                DataGridView view = (DataGridView)sender;
                view.Rows[e.RowIndex].ErrorText = "an error";
                view.Rows[e.RowIndex].Cells[e.ColumnIndex].ErrorText = "an error";

                e.ThrowException = false;
            }
        }

        #endregion

        #region TAB - TableResults - CheckBox
        private bool TAB_TableResults_CheckBoxes(List<Model_Operational_TestTableParameters> listResultParam)
        {
            try
            {
                if (HelperApp.uiTesteSelecionado != 0)
                {
                    var metroPnl = CONTROLS_GetAll(this, typeof(MetroPanel)).Find(a => a.Name == "mpnl_Table_GivingOut");

                    var lstChk = CONTROLS_GetAll(metroPnl, typeof(CheckBox)).OrderBy(m => m.Text);

                    foreach (var chk in lstChk)
                    {
                        var chkState = ((System.Windows.Forms.CheckBox)chk).Checked;

                        if (chkState)
                        {
                            //clear checkbox
                           // lstChk.ForEach(item => metroPnl.Controls.Remove(item));
                        }
                    }

                    //add chk novo panel
                    for (int i = 0; i < listResultParam.Count(); i++)
                    {
                        long ResultParam_Id = listResultParam[i].IdResultParam;
                        string strResultParam_Name = listResultParam[i].ResultParam_Name?.Trim();
                        string strResultParam_Caption = listResultParam[i].ResultParam_Caption?.Trim();

                        //MetroCheckBox mChkBox = new MetroCheckBox();
                        CheckBox mChkBox = new CheckBox();
                        mChkBox.CheckedChanged += TAB_TableResults_CheckBoxes_CheckedChanged;
                        mChkBox.Tag = i.ToString();
                        mChkBox.Name = !string.IsNullOrEmpty(strResultParam_Name) ? strResultParam_Name : string.Concat("tab_TableResults_Chk", i);
                        mChkBox.Text = strResultParam_Caption;
                        mChkBox.AutoSize = true;
                        mChkBox.Font = new Font("", 8.0f, FontStyle.Bold);
                        mChkBox.Location = new Point(15, (i + 3) * 23); //vertical
                                                                        //horizontal = box.Location = new Point(i * 50, 10); 
                        metroPnl.AddControl(mChkBox);
                    }
                }
            }
            catch (Exception ex)
            {
                var exc = ex.Message;
                MessageBox.Show(exc);

                return false;

                throw;
            }

            return true;
        }
        private void TAB_TableResults_CheckBoxes_CheckedChanged(object sender, EventArgs e)
        {
            int chkId = Convert.ToInt32(((System.Windows.Forms.Control)sender).Tag?.ToString()?.Trim());
            string chkName = ((System.Windows.Forms.Control)sender).Name?.ToString()?.Trim();
            string chkText = ((System.Windows.Forms.ButtonBase)sender).Text?.ToString()?.Trim();
            bool chkChecked = ((System.Windows.Forms.CheckBox)sender).Checked;

            TAB_TableResult_Grid_Format(chkId, chkName, chkChecked);
        }

        #endregion

        #endregion

        #region TAB - ActuationParameters

        #region TAB - ActuationParameters - Common
        private void TAB_ActuationParameters_SetData()
        {
            try
            {
                #region TAB_ActuationParameters - General Settings - Set Data

                mtxt_Actuation_Unit_E1ParMaxForce.Enabled = false;
                mtxt_Actuation_Unit_E1ParForceGrad.Enabled = false;


                #region TAB_ActuationParameters - Evoluation Parameters - Set data

                grpOutput.Visible = false;

                #endregion

                #region TAB_ActuationParameters - General Settings - Set Combo Actuation Mode

                if (mcbo_tabActParam_GenSettings_CoBActuationMode.Items.Count <= 0)
                    TAB_ActuationParameters_GeneralSettings_CoBActuationMode_Populate();

                if (mcbo_tabActParam_GenSettings_CoBActuationMode.SelectedIndex != 0)
                    mcbo_tabActParam_GenSettings_CoBActuationMode.SelectedIndex = HelperApp.uiActuationMode;

                #endregion

                #region TAB_ActuationParameters - General Settings - Set Combo Tests

                if (mcbo_tabActParam_GenSettings_CoBSelectTest.Items.Count <= 0)
                    TAB_ActuationParameters_GeneralSettings_CoBSelectTest_Populate();

                if (mcbo_tabActParam_GenSettings_CoBSelectTest.SelectedIndex != 0)
                {
                    mcbo_tabActParam_GenSettings_CoBSelectTest.SelectedIndex = HelperApp.uiTesteSelecionado;

                    #region Radio Output

                    switch (mcbo_tabActParam_GenSettings_CoBSelectTest.SelectedIndex)
                    {
                        case 1:     //Force Diagrams - Force/Pressure With Vacuum
                        case 3:     //Force Diagrams - Force/Pressure Without Vacuum
                        case 17:    //Lost Travel ACU - Hydraulic
                        case 18:    //Lost Travel ACU - Hydraulic Electrical Actuation
                            {
                                if(HelperTestBase.Model_GVL.GVL_Graficos.iOutput == 1)
                                    rad_EvaluationParameters_CBOutputPC.Checked = true;
                                else
                                    rad_EvaluationParameters_CBOutputSC.Checked = true;

                                grpOutput.Visible = true;

                                break;
                            }
                        default:
                            {
                                rad_EvaluationParameters_CBOutputPC.Checked = false;
                                rad_EvaluationParameters_CBOutputSC.Checked = false;

                                grpOutput.Visible = false;

                                break;
                            }
                    }

                    _modelGVL.GVL_Parametros.iOutput = rad_EvaluationParameters_CBOutputPC.Checked ? 1 : 0;

                    _modelGVL.GVL_Graficos.iOutput = _modelGVL.GVL_Parametros.iOutput;

                    HelperTestBase.Model_GVL.GVL_Graficos = _modelGVL.GVL_Graficos;

                    #endregion
                }

                #endregion

                #region TAB_ActuationParameters - General Settings - Set Consumers

                if (mcbo_tabActParam_GenSettings_CoBSelectTest.SelectedIndex == 0)
                {
                    rad_GeneralSettings_CBOriginalConsumer.Checked = false;
                    rad_GeneralSettings_CBHoseConsumer.Checked = false;
                }

                #endregion

                #endregion

                #region TAB_ActuationParameters - Actuation - Set data

                if (HelperApp.uiTesteSelecionado == 0)
                {
                    mtxt_Actuation_E1ParMaxForce.Text = _notReadValue;
                    mtxt_Actuation_E1ParForceGrad.Text = _notReadValue;
                }

                #endregion

                TAB_ActuationParameters_PopulateData(HelperApp.uiTesteSelecionado);

                _bAppStart = false;
            }
            catch (Exception ex)
            {
                var exc = ex.Message;
                MessageBox.Show(exc);
            }
        }
        private bool TAB_ActuationParameters_ValidateInputTxt(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (ch == 46 && ((MetroFramework.Controls.MetroTextBox)sender).Text.IndexOf(".") != -1)
                return true;

            if (!Char.IsDigit(ch) && ch != 8 && ch != 46 && ch != 45) //8= backspace, 45 - negative
                return true;

            return false;
        }
        private void TAB_ActuationParameters_ValidateInputBtnMinPlus(string strName, string strValue, double paramStep, string strTypeAction)
        {
            if (!string.IsNullOrEmpty(strValue))
            {
                var dblValue = Convert.ToDouble(strValue.Replace(",", "."));

                strValue = (dblValue < 0 ? (dblValue + paramStep) : (dblValue - paramStep)).ToString("N2");

                TAB_ActuationParameters_WriteComInputTxt(strName, strValue);
            }
        }
        private void TAB_ActuationParameters_WriteComInputTxt(string strName, string strValue)
        {
            try
            {
                var dblValue = _helperApp.NumberDoubleCheck(strValue);

                if (dblValue < 0)
                    dblValue = (dblValue * -1);

                switch (strName.Trim())
                {
                    case "mtxt_GeneralSettings_EParGenVaccum":
                        {
                            HelperTestBase.Vacuum = dblValue;
                            _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_dwVacuo_Bar_LW }, dblValue < 0 ? (dblValue * -1) : dblValue);
                        }
                        break;
                    case "mtxt_Actuation_E1ParMaxForce":
                        {
                            HelperTestBase.MaxForce = dblValue;
                            _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_dwForcaMaxima_N_LW }, dblValue);
                        }
                        break;
                    case "mtxt_Actuation_E1ParForceGrad":
                        {
                            HelperTestBase.Model_GVL.GVL_Parametros.iModo = HelperTestBase.ActuationType;

                            switch (HelperTestBase.Model_GVL.GVL_Parametros.iModo)
                            {
                                case 1://ActuationMode - Pneumatic Slow
                                    {
                                        _modelGVL.GVL_Parametros.rGradienteForca_Ns = dblValue;

                                        _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_dwGradienteForca_Ns_LW }, dblValue);
                                        break;
                                    }
                                case 2://ActuationMode - Pneumatic Fast
                                    {
                                        _modelGVL.GVL_Parametros.rGradienteForca = dblValue;

                                        _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_dwGradienteForca_LW }, dblValue);
                                        break;
                                    }
                                case 3://ActuationMode - E-Motor
                                    {
                                        dblValue = dblValue < 1 ? 1 : dblValue;
                                        _modelGVL.GVL_Parametros.rVelocidadeAtuacao_mm_s = dblValue; //HelperTestBase.ForceGradient

                                        _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_dwVelocidadeAtuacao_mm_s_LW }, dblValue);
                                        break;
                                    }
                                default:
                                    {
                                        break;
                                    }
                            }

                            HelperTestBase.ForceGradient = dblValue;
                        }
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                var err = ex.Message;
                throw;
            }
        }

        #endregion

        #region TAB - ActuationParameters - Populate Data
        private bool TAB_ActuationParameters_PopulateData(int uiTesteSelecionado)
        {
            try
            {
                if (!_bAppStart)
                {
                    if (uiTesteSelecionado == 0 && _bCoBSelectTestSelected)
                    {
                        mcbo_tabActParam_GenSettings_CoBSelectTest.SelectedIndex = 0;

                        _bCoBSelectTestSelected = false;

                        MessageBox.Show("Error, invalid test!", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    else
                    {
                        if (uiTesteSelecionado != 0)
                        {
                            HelperApp.uiTesteSelecionado = uiTesteSelecionado;

                            //if (HelperTestBase.ParamEval == null)
                            //    BindDataParam();

                            if (!_bCoBSelectTestSelected)
                            {
                                bool bReturn = TAB_ActuationParameters_GetDataInfo(HelperApp.uiTesteSelecionado.ToString());

                                if (bReturn)
                                    _bCoBSelectTestSelected = true;
                                else
                                {
                                    MessageBox.Show("Error, failed load data test!", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return false;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                var exc = ex.Message;
                MessageBox.Show(exc);
                return false;
            }

            return true;
        }
        private bool TAB_ActuationParameters_GetDataInfo(string strIdxTestSelected)
        {
            try
            {
                BLL_Main_Tab_ActuationParameters _bll_Main_Tab_ActionParameters = new BLL_Main_Tab_ActuationParameters();

                DataTable dtActionParameter = _bll_Main_Tab_ActionParameters.PopulateActionParametersByTest(strIdxTestSelected);

                if (dtActionParameter.Rows.Count == 0)
                {
                    MessageBox.Show("Error, failed load data test!", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                else
                {
                    foreach (DataRow row in dtActionParameter.Rows)
                    {
                        #region General Settings

                        //General Settings - CBO Actuation Mode
                        IdActuationMode = row.Field<int>("IdActuationMode");
                        TAB_ActuationParameters_GeneralSettings_CoBActuationMode_Change(IdActuationMode);

                        //General Settings - Panel Vacuum
                        strVacuumValue = !string.IsNullOrEmpty(row.Field<decimal?>("Vacuum").ToString()) ? row.Field<decimal?>("Vacuum").ToString() : "0";
                        TAB_ActuationParameters_GeneralSettings_Vaccum_Change(strVacuumValue);

                        //General Settings - Panel Consumers
                        iConsumerType = row.Field<int>("IdConsumerType");
                        iConsumerPC = !string.IsNullOrEmpty(row.Field<int?>("PC").ToString()) ? row.Field<int>("PC") : 0;
                        iConsumerSC = !string.IsNullOrEmpty(row.Field<int?>("SC").ToString()) ? row.Field<int>("SC") : 0;
                        bPistonLock = row.Field<bool>("Chk_PistonLock");
                        TAB_ActuationParameters_GeneralSettings_Consumers_Change(iConsumerType, iConsumerPC, iConsumerSC, bPistonLock);

                        #endregion

                        #region Actuation

                        strName = string.Empty;

                        strMaxForceValue = row.Field<decimal?>("Actuation_MaxForce").ToString();

                        if (!string.IsNullOrEmpty(strMaxForceValue))
                        {
                            TAB_ActuationParameters_Actuation_MaxForce_Change(strName, strMaxForceValue);
                        }
                        else
                            mtxt_Actuation_E1ParMaxForce.Text = _notReadValue;


                        strGradientForceValue = row.Field<decimal?>("Actuation_ForceGradient").ToString();

                        if (!string.IsNullOrEmpty(strGradientForceValue))
                        {
                            TAB_ActuationParameters_Actuation_GradientForce_Change(strName, strGradientForceValue);

                            mtxt_Actuation_E1ParForceGrad.Text = strGradientForceValue;
                        }
                        else
                            mtxt_Actuation_E1ParForceGrad.Text = _notReadValue;

                        #endregion
                    }

                    #region Evaluation Parameters

                    DataTable dtGridEvalParameters = _bll_Main_Tab_ActionParameters.PopulateGridEvalParametersByTest(strIdxTestSelected);

                    if (dtGridEvalParameters == null)
                    {
                        MessageBox.Show("Error, failed load data test!", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    else
                    {
                        if (dtGridEvalParameters.Rows.Count > 0)
                        {
                            //Rows Format
                            TAB_ActuationParameters_EvalParameters_Grid_GridRowType(dtGridEvalParameters);

                            //grid_tabActionParam_EvalParam.DataSource = dtGridEvalParameters;

                            TAB_ActuationParameters_EvalParameters_Grid_Format();

                            List<ActuationParameters_EvaluationParameters> lstInfoEvaluationParameters = _helperApp.GridView_GetValuesEvalParam(grid_tabActionParam_EvalParam);

                            if (HelperApp.uiTesteSelecionado > 0)
                                TAB_ActuationParameters_WriteComGridEvalParameters(lstInfoEvaluationParameters);
                        }
                        else
                        {
                            MessageBox.Show("Error, failed load rows data test!", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                    }

                    #endregion
                }
            }
            catch (Exception ex)
            {
                var exc = ex.Message;
                MessageBox.Show(exc);
                return false;
            }

            return true;
        }

        #endregion

        #region TAB - ActuationParameters - Panel General Settings

        #region TAB - ActuationParameters - General Settings - CBO Actuation Mode
        private void TAB_ActuationParameters_GeneralSettings_CoBActuationMode_Populate()
        {
            _bAppStart = true;

            BLL_Main_Tab_ActuationParameters _bll_Main_Tab_ActionParameters = new BLL_Main_Tab_ActuationParameters();

            DataTable dt = _bll_Main_Tab_ActionParameters.PopulateActionMode();

            mcbo_tabActParam_GenSettings_CoBActuationMode.ValueMember = "Id";

            mcbo_tabActParam_GenSettings_CoBActuationMode.DisplayMember = "Name";
            mcbo_tabActParam_GenSettings_CoBActuationMode.DataSource = dt;
        }
        private void mcbo_GeneralSettings_CoBActuationMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idxSelected = mcbo_tabActParam_GenSettings_CoBActuationMode.SelectedIndex;

            if (!_bAppStart)
            {
                if (idxSelected != 0)
                {
                    #region Verificacao do tipo de atuacao

                    switch (HelperApp.uiTesteSelecionado)
                    {
                        case 1:     //Force Diagrams - Force/Pressure With Vacuum 
                            {
                                if (idxSelected == 0 || idxSelected == 2) //0-Off 1-Slow 2- Fast -3 E-motor //slow ou emotor
                                {
                                    MessageBox.Show("Warning, ActuationMode invalid option!", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Warning);

                                    mcbo_tabActParam_GenSettings_CoBActuationMode.SelectedIndex = IdActuationMode;

                                    return;
                                }
                                else
                                    TAB_ActuationParameters_GeneralSettings_CoBActuationMode_Change(idxSelected);

                                break;
                            }
                        case 2:     //Force Diagrams - Force/Force With Vacuum //slow ou emotor
                            {
                                if (idxSelected == 0 || idxSelected == 2) //0-Off 1-Slow 2- Fast -3 E-motor
                                {
                                    MessageBox.Show("Warning, ActuationMode invalid option!", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Warning);

                                    mcbo_tabActParam_GenSettings_CoBActuationMode.SelectedIndex = IdActuationMode;

                                    return;
                                }
                                else
                                    TAB_ActuationParameters_GeneralSettings_CoBActuationMode_Change(idxSelected);

                                break;
                            }
                        case 3:     //Force Diagrams - Force/Pressure Without Vacuum //slow ou emotor
                            {
                                if (idxSelected == 0 || idxSelected == 2) //0-Off 1-Slow 2- Fast -3 E-motor
                                {
                                    MessageBox.Show("Warning, ActuationMode invalid option!", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Warning);

                                    mcbo_tabActParam_GenSettings_CoBActuationMode.SelectedIndex = IdActuationMode;

                                    return;
                                }
                                else
                                    TAB_ActuationParameters_GeneralSettings_CoBActuationMode_Change(idxSelected);

                                break;
                            }
                        case 4:     //Force Diagrams - Force/Force Without Vacuum //slow ou emotor
                            {
                                if (idxSelected == 0 || idxSelected == 2) //0-Off 1-Slow 2- Fast -3 E-motor
                                {
                                    MessageBox.Show("Warning, ActuationMode invalid option!", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Warning);

                                    mcbo_tabActParam_GenSettings_CoBActuationMode.SelectedIndex = IdActuationMode;

                                    return;
                                }
                                else
                                    TAB_ActuationParameters_GeneralSettings_CoBActuationMode_Change(idxSelected);

                                break;
                            }
                        case 5: //Vaccum Leakage - Released Position //nao tem acionamento
                            {
                                //indiferente
                                break;
                            }
                        case 6: //Vacuum Leakage - Fully Applied Position //somente slow
                            {
                                if (idxSelected != 1) //0-Off 1-Slow 2- Fast -3 E-motor
                                {
                                    MessageBox.Show("Warning, ActuationMode invalid option!", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Warning);

                                    mcbo_tabActParam_GenSettings_CoBActuationMode.SelectedIndex = IdActuationMode;

                                    return;
                                }
                                else
                                    TAB_ActuationParameters_GeneralSettings_CoBActuationMode_Change(idxSelected);

                                break;
                            }
                        case 7: //Vacuum Leakage - Lap Position //somente slow
                            {
                                if (idxSelected != 1) //0-Off 1-Slow 2- Fast -3 E-motor
                                {
                                    MessageBox.Show("Warning, ActuationMode invalid option!", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Warning);

                                    mcbo_tabActParam_GenSettings_CoBActuationMode.SelectedIndex = IdActuationMode;

                                    return;
                                }
                                else
                                    TAB_ActuationParameters_GeneralSettings_CoBActuationMode_Change(idxSelected);

                                break;
                            }
                        case 8:     //Hydraulic Leakage - Fully Applied Position //somente slow
                            {
                                if (idxSelected != 1) //0-Off 1-Slow 2- Fast -3 E-motor
                                {
                                    MessageBox.Show("Warning, ActuationMode invalid option!", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Warning);

                                    mcbo_tabActParam_GenSettings_CoBActuationMode.SelectedIndex = IdActuationMode;

                                    return;
                                }
                                else
                                    TAB_ActuationParameters_GeneralSettings_CoBActuationMode_Change(idxSelected);

                                break;
                            }
                        case 9:     //Hydraulic Leakage - At Low Pressure //somente emotor
                            {
                                if (idxSelected != 3) //0-Off 1-Slow 2- Fast -3 E-motor
                                {
                                    MessageBox.Show("Warning, ActuationMode invalid option!", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Warning);

                                    mcbo_tabActParam_GenSettings_CoBActuationMode.SelectedIndex = IdActuationMode;

                                    return;
                                }
                                else
                                    TAB_ActuationParameters_GeneralSettings_CoBActuationMode_Change(idxSelected);

                                break;
                            }
                        case 10:    //Hydraulic Leakage - At High Pressure //somente slow
                            {
                                if (idxSelected != 1) //0-Off 1-Slow 2- Fast -3 E-motor
                                {
                                    MessageBox.Show("Warning, ActuationMode invalid option!", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Warning);

                                    mcbo_tabActParam_GenSettings_CoBActuationMode.SelectedIndex = IdActuationMode;

                                    return;
                                }
                                else
                                    TAB_ActuationParameters_GeneralSettings_CoBActuationMode_Change(idxSelected);

                                break;
                            }
                        case 11:    //Adjustment - Actuation Slow //somente slow
                            {
                                if (idxSelected != 1) //0-Off 1-Slow 2- Fast -3 E-motor
                                {
                                    MessageBox.Show("Warning, ActuationMode invalid option!", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Warning);

                                    mcbo_tabActParam_GenSettings_CoBActuationMode.SelectedIndex = IdActuationMode;

                                    return;
                                }
                                else
                                    TAB_ActuationParameters_GeneralSettings_CoBActuationMode_Change(idxSelected);

                                break;
                            }
                        case 12:    //Adjustment - Actuation Fast //somente fast
                            {
                                if (idxSelected != 2) //0-Off 1-Slow 2- Fast -3 E-motor
                                {
                                    MessageBox.Show("Warning, ActuationMode invalid option!", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Warning);

                                    mcbo_tabActParam_GenSettings_CoBActuationMode.SelectedIndex = IdActuationMode;

                                    return;
                                }
                                else
                                    TAB_ActuationParameters_GeneralSettings_CoBActuationMode_Change(idxSelected);

                                break;
                            }
                        case 13:    //Check Sensors - Pressure Difference //somente slow
                            {
                                if (idxSelected != 1) //0-Off 1-Slow 2- Fast -3 E-motor
                                {
                                    MessageBox.Show("Warning, ActuationMode invalid option!", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Warning);

                                    mcbo_tabActParam_GenSettings_CoBActuationMode.SelectedIndex = IdActuationMode;

                                    return;
                                }
                                else
                                    TAB_ActuationParameters_GeneralSettings_CoBActuationMode_Change(idxSelected);

                                break;
                            }
                        case 14:    //Check Sensors - Input/Output Travel //somente slow
                            {
                                if (idxSelected != 1) //0-Off 1-Slow 2- Fast -3 E-motor
                                {
                                    MessageBox.Show("Warning, ActuationMode invalid option!", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Warning);

                                    mcbo_tabActParam_GenSettings_CoBActuationMode.SelectedIndex = IdActuationMode;

                                    return;
                                }
                                else
                                    TAB_ActuationParameters_GeneralSettings_CoBActuationMode_Change(idxSelected);

                                break;
                            }
                        case 15:    //Adjustment - Input Travel VS Input Force //somente slow
                            {
                                if (idxSelected != 1) //0-Off 1-Slow 2- Fast -3 E-motor
                                {
                                    MessageBox.Show("Warning, ActuationMode invalid option!", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Warning);

                                    mcbo_tabActParam_GenSettings_CoBActuationMode.SelectedIndex = IdActuationMode;

                                    return;
                                }
                                else
                                    TAB_ActuationParameters_GeneralSettings_CoBActuationMode_Change(idxSelected);

                                break;
                            }
                        case 16:    //Adjustment - Hose Consumer //somente slow
                            {
                                if (idxSelected != 1) //0-Off 1-Slow 2- Fast -3 E-motor
                                {
                                    MessageBox.Show("Warning, ActuationMode invalid option!", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Warning);

                                    mcbo_tabActParam_GenSettings_CoBActuationMode.SelectedIndex = IdActuationMode;

                                    return;
                                }
                                else
                                    TAB_ActuationParameters_GeneralSettings_CoBActuationMode_Change(idxSelected);

                                break;
                            }
                        case 17:    //Lost Travel ACU - Hydraulic //somente slow
                            {
                                if (idxSelected != 1) //0-Off 1-Slow 2- Fast -3 E-motor
                                {
                                    MessageBox.Show("Warning, ActuationMode invalid option!", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Warning);

                                    mcbo_tabActParam_GenSettings_CoBActuationMode.SelectedIndex = IdActuationMode;

                                    return;
                                }
                                else
                                    TAB_ActuationParameters_GeneralSettings_CoBActuationMode_Change(idxSelected);

                                break;
                            }
                        case 18:    //Lost Travel ACU - Hydraulic Electrical Actuation //somente emotor
                            {
                                if (idxSelected != 3) //0-Off 1-Slow 2- Fast -3 E-motor
                                {
                                    MessageBox.Show("Warning, ActuationMode invalid option!", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Warning);

                                    mcbo_tabActParam_GenSettings_CoBActuationMode.SelectedIndex = IdActuationMode;

                                    return;
                                }
                                else
                                    TAB_ActuationParameters_GeneralSettings_CoBActuationMode_Change(idxSelected);

                                break;
                            }
                        case 19:    //Lost Travel ACU - Pneumatic Primary //somente emotor
                            {
                                if (idxSelected != 3) //0-Off 1-Slow 2- Fast -3 E-motor
                                {
                                    MessageBox.Show("Warning, ActuationMode invalid option!", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Warning);

                                    mcbo_tabActParam_GenSettings_CoBActuationMode.SelectedIndex = IdActuationMode;

                                    return;
                                }
                                else
                                    TAB_ActuationParameters_GeneralSettings_CoBActuationMode_Change(idxSelected);

                                break;
                            }
                        case 20:    //Lost Travel ACU - Pneumatic Secondary //somente emotor
                            {
                                if (idxSelected != 3) //0-Off 1-Slow 2- Fast -3 E-motor
                                {
                                    MessageBox.Show("Warning, ActuationMode invalid option!", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Warning);

                                    mcbo_tabActParam_GenSettings_CoBActuationMode.SelectedIndex = IdActuationMode;

                                    return;
                                }
                                else
                                    TAB_ActuationParameters_GeneralSettings_CoBActuationMode_Change(idxSelected);

                                break;
                            }
                        case 21:    //Pedal Feeling Characteristics //somente slow
                            {
                                if (idxSelected != 1) //0-Off 1-Slow 2- Fast -3 E-motor
                                {
                                    MessageBox.Show("Warning, ActuationMode invalid option!", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Warning);

                                    mcbo_tabActParam_GenSettings_CoBActuationMode.SelectedIndex = IdActuationMode;

                                    return;
                                }
                                else
                                    TAB_ActuationParameters_GeneralSettings_CoBActuationMode_Change(idxSelected);

                                break;
                            }
                        case 22:    //Actuation / Release - Mechanical Actuation //somente fast
                            {
                                if (idxSelected != 2) //0-Off 1-Slow 2- Fast -3 E-motor
                                {
                                    MessageBox.Show("Warning, ActuationMode invalid option!", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Warning);

                                    mcbo_tabActParam_GenSettings_CoBActuationMode.SelectedIndex = IdActuationMode;

                                    return;
                                }
                                else
                                    TAB_ActuationParameters_GeneralSettings_CoBActuationMode_Change(idxSelected);

                                break;
                            }
                        case 23:    //Breather Hole / Central Valve open //somente slow
                            {
                                if (idxSelected != 1) //0-Off 1-Slow 2- Fast -3 E-motor
                                {
                                    MessageBox.Show("Warning, ActuationMode invalid option!", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Warning);

                                    mcbo_tabActParam_GenSettings_CoBActuationMode.SelectedIndex = IdActuationMode;

                                    return;
                                }
                                else
                                    TAB_ActuationParameters_GeneralSettings_CoBActuationMode_Change(idxSelected);

                                break;
                            }
                        case 24:    //Efficiency  //somente slow
                            {
                                if (idxSelected != 1) //0-Off 1-Slow 2- Fast -3 E-motor
                                {
                                    MessageBox.Show("Warning, ActuationMode invalid option!", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Warning);

                                    mcbo_tabActParam_GenSettings_CoBActuationMode.SelectedIndex = IdActuationMode;

                                    return;
                                }
                                else
                                    TAB_ActuationParameters_GeneralSettings_CoBActuationMode_Change(idxSelected);

                                break;
                            }
                        case 25:    //Force Diagrams - Force/Pressure Dual Ratio //slow ou emotor
                            {
                                if (idxSelected == 0 || idxSelected == 2) //0-Off 1-Slow 2- Fast -3 E-motor
                                {
                                    MessageBox.Show("Warning, ActuationMode invalid option!", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Warning);

                                    mcbo_tabActParam_GenSettings_CoBActuationMode.SelectedIndex = IdActuationMode;

                                    return;
                                }
                                else
                                    TAB_ActuationParameters_GeneralSettings_CoBActuationMode_Change(idxSelected);

                                break;
                            }
                        case 26:    //Force Diagrams - Force/Force Dual Ratio //slow ou emotor
                            {
                                if (idxSelected == 0 || idxSelected == 2) //0-Off 1-Slow 2- Fast -3 E-motor
                                {
                                    MessageBox.Show("Warning, ActuationMode invalid option!", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Warning);

                                    mcbo_tabActParam_GenSettings_CoBActuationMode.SelectedIndex = IdActuationMode;

                                    return;
                                }
                                else
                                    TAB_ActuationParameters_GeneralSettings_CoBActuationMode_Change(idxSelected);

                                break;
                            }
                        case 27:    //ADAM - Find Switching Point With TMC //somente e-motor
                            {
                                if (idxSelected != 3) //0-Off 1-Slow 2- Fast -3 E-motor
                                {
                                    MessageBox.Show("Warning, ActuationMode invalid option!", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Warning);

                                    mcbo_tabActParam_GenSettings_CoBActuationMode.SelectedIndex = IdActuationMode;

                                    return;
                                }
                                else
                                    TAB_ActuationParameters_GeneralSettings_CoBActuationMode_Change(idxSelected);

                                break;
                            }
                        case 28:    //ADAM - Switching Point Without TMC //somente e-motor
                            {
                                if (idxSelected != 3) //0-Off 1-Slow 2- Fast -3 E-motor
                                {
                                    MessageBox.Show("Warning, ActuationMode invalid option!", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Warning);

                                    mcbo_tabActParam_GenSettings_CoBActuationMode.SelectedIndex = IdActuationMode;

                                    return;
                                }
                                else
                                    TAB_ActuationParameters_GeneralSettings_CoBActuationMode_Change(idxSelected);

                                break;
                            }
                        case 29: //Bleed //somente slow
                            {
                                if (idxSelected != 1) //0-Off 1-Slow 2- Fast -3 E-motor
                                {
                                    MessageBox.Show("Warning, ActuationMode invalid option!", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Warning);

                                    mcbo_tabActParam_GenSettings_CoBActuationMode.SelectedIndex = IdActuationMode;

                                    return;
                                }
                                else
                                    TAB_ActuationParameters_GeneralSettings_CoBActuationMode_Change(idxSelected);

                                break;
                            }
                        default:
                            break;
                    }
                    #endregion
                }
                else
                {
                    if (HelperApp.uiTesteSelecionado != 5)
                    {
                        MessageBox.Show("Warning, ActuationMode invalid option!", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
            }
        }
        private void TAB_ActuationParameters_GeneralSettings_CoBActuationMode_Change(int idxSelected)
        {
            mcbo_tabActParam_GenSettings_CoBActuationMode.SelectedIndex = idxSelected;

            if (!string.IsNullOrEmpty(strMaxForceValue) && !strMaxForceValue.Equals(_notReadValue))
            {
                var dblValue = _helperApp.NumberDoubleCheck(strMaxForceValue);

                if (dblValue < 0)
                    dblValue = (dblValue * -1);

                if (dblValue != HelperTestBase.MaxForce)
                    HelperTestBase.MaxForce = Math.Round(Convert.ToDouble(strMaxForceValue), 2);
            }

            if (!string.IsNullOrEmpty(strGradientForceValue) && !strGradientForceValue.Equals(_notReadValue))
            {
                var dblValue = _helperApp.NumberDoubleCheck(strGradientForceValue);

                if (dblValue < 0)
                    dblValue = (dblValue * -1);

                if (dblValue != HelperTestBase.ForceGradient)
                    HelperTestBase.ForceGradient = Math.Round(Convert.ToDouble(strGradientForceValue), 2);
            }

            HelperApp.uiActuationMode = idxSelected;
            HelperTestBase.ActuationType = HelperApp.uiActuationMode;

            HelperApp.strActuationMode = mcbo_tabActParam_GenSettings_CoBActuationMode.Text.Trim();

            //set title name
            mTile_tabActParam_Actuation.Text = HelperApp.strActuationMode;

            _modelGVL.GVL_Parametros.rForcaMaxima_N = HelperTestBase.MaxForce;

            switch (HelperApp.uiActuationMode)
            {
                case 1://ActuationMode - Pneumatic Slow
                    {
                        _modelGVL.GVL_Parametros.rGradienteForca_Ns = HelperTestBase.ForceGradient;

                        _modelGVL.GVL_Parametros.iModo = 1;
                        mtxt_Actuation_E1ParForceGrad.Text = _modelGVL.GVL_Parametros.rGradienteForca_Ns.ToString();
                        mtxt_Actuation_Unit_E1ParForceGrad.Text = "N/s";

                        break;
                    }
                case 2://ActuationMode - Pneumatic Fast
                    {
                        _modelGVL.GVL_Parametros.rGradienteForca = HelperTestBase.ForceGradient;

                        _modelGVL.GVL_Parametros.iModo = 2;
                        mtxt_Actuation_E1ParForceGrad.Text = _modelGVL.GVL_Parametros.rGradienteForca.ToString();
                        mtxt_Actuation_Unit_E1ParForceGrad.Text = "%";
                        break;
                    }
                case 3://ActuationMode - E-Motor
                    {
                        //set defaulty value
                        _modelGVL.GVL_Parametros.rVelocidadeAtuacao_mm_s = 1; //HelperTestBase.ForceGradient

                        _modelGVL.GVL_Parametros.iModo = 3;
                        mtxt_Actuation_E1ParForceGrad.Text = _modelGVL.GVL_Parametros.rVelocidadeAtuacao_mm_s.ToString();
                        mtxt_Actuation_Unit_E1ParForceGrad.Text = "mm/s";
                        break;
                    }
                default:
                    {
                        _modelGVL.GVL_Parametros.iModo = 0;
                        mtxt_Actuation_E1ParForceGrad.Text = _notReadValue;
                        mtxt_Actuation_Unit_E1ParForceGrad.Text = string.Empty;
                        break;
                    }
            }

            HelperApp.uiActuationMode = _modelGVL.GVL_Parametros.iModo;
            HelperTestBase.ActuationType = HelperApp.uiActuationMode;

            HelperTestBase.Model_GVL.GVL_Parametros.iModo = HelperTestBase.ActuationType;

            _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_wModo }, HelperApp.uiActuationMode);
        }

        #endregion

        #region TAB - ActuationParameters - General Settings - CBO Test Type
        private void TAB_ActuationParameters_GeneralSettings_CoBSelectTest_Populate()
        {
            _bAppStart = true;

            BLL_Manager_SelectEvalProgram _bll_Manager_SelectEvalProgram = new BLL_Manager_SelectEvalProgram();

            DataTable dt = _bll_Manager_SelectEvalProgram.GetAvailableTests();

            DataRow dr = dt.NewRow();
            dr.ItemArray = new object[] { 0, "-- No Selection Test --" };
            dt.Rows.InsertAt(dr, 0);

            mcbo_tabActParam_GenSettings_CoBSelectTest.ValueMember = "Id";

            mcbo_tabActParam_GenSettings_CoBSelectTest.DisplayMember = "Name";
            mcbo_tabActParam_GenSettings_CoBSelectTest.DataSource = dt;
        }
        private void mcbo_GeneralSettings_CoBSelectTest_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idxSelected = mcbo_tabActParam_GenSettings_CoBSelectTest.SelectedIndex;

            TAB_ActuationParameters_GeneralSettings_CoBSelectTest_Change(idxSelected, this.ToString());

        }
        public void TAB_ActuationParameters_GeneralSettings_CoBSelectTest_Change(int idxSelected, string origin)
        {
            if (!_bAppStart)
            {
                if (idxSelected == 0 && _bCoBSelectTestSelected)
                {
                    mcbo_tabActParam_GenSettings_CoBSelectTest.SelectedIndex = 0;

                    _bCoBSelectTestSelected = false;

                    DisableButtonStart();

                    MessageBox.Show("Warning, Change SelectTest invalid option!", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    if (idxSelected != 0)
                    {
                        if (origin.Equals("Form_Manager_SelectEvalProgram"))
                            mcbo_tabActParam_GenSettings_CoBSelectTest.SelectedIndex = HelperApp.uiTesteSelecionado;

                        HelperApp.uiTesteSelecionado = mcbo_tabActParam_GenSettings_CoBSelectTest.SelectedIndex;

                        #region Radio Output

                        switch (idxSelected)
                        {
                            case 1:     //Force Diagrams - Force/Pressure With Vacuum
                            case 3:     //Force Diagrams - Force/Pressure Without Vacuum
                            case 17:    //Lost Travel ACU - Hydraulic
                            case 18:    //Lost Travel ACU - Hydraulic Electrical Actuation
                                {
                                    rad_EvaluationParameters_CBOutputPC.Checked = true;
                                    rad_EvaluationParameters_CBOutputSC.Checked = false;

                                    grpOutput.Visible = true;

                                    break;
                                }
                            default:
                                {
                                    rad_EvaluationParameters_CBOutputPC.Checked = false;
                                    rad_EvaluationParameters_CBOutputSC.Checked = false;

                                    grpOutput.Visible = false;

                                    break;
                                }
                        }

                        _modelGVL.GVL_Parametros.iOutput = rad_EvaluationParameters_CBOutputPC.Checked ? 1 : 0;

                        _modelGVL.GVL_Graficos.iOutput = _modelGVL.GVL_Parametros.iOutput;

                        HelperTestBase.Model_GVL.GVL_Graficos = _modelGVL.GVL_Graficos;

                        #endregion

                        TAB_ActuationParameters_GeneralSettings_CoBSelectTest_SetChange(HelperApp.uiTesteSelecionado);

                        _bCoBSelectTestSelected = true;



                        EnableButtonStart();
                    }
                }
            }
        }
        public void TAB_ActuationParameters_GeneralSettings_CoBSelectTest_SetChange(int idTest)
        {
            if (idTest == 0 && _bCoBSelectTestSelected)
            {
                mcbo_tabActParam_GenSettings_CoBSelectTest.SelectedIndex = 0;

                _bCoBSelectTestSelected = false;

                MessageBox.Show("Warning, Set SelectTest invalid option!", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                HelperApp.uiTesteSelecionado = mcbo_tabActParam_GenSettings_CoBSelectTest.Items.Count == 0 ? idTest : Convert.ToInt32(mcbo_tabActParam_GenSettings_CoBSelectTest.SelectedValue.ToString());

                HelperApp.strNomeTesteSelecionado = mcbo_tabActParam_GenSettings_CoBSelectTest.Items.Count > 0 ? mcbo_tabActParam_GenSettings_CoBSelectTest.Text.Trim() : EnumExtensionMethods.GetDescriptionEXAMTYPE(HelperTestBase.eExamType).ToString();
                mTile_LCurrentSelectedTest.Text = HelperApp.strNomeTesteSelecionado;

                var last_sel_ix = -1;
                int sel_ix = HelperApp.uiTesteSelecionado;

                if (sel_ix >= 0)
                {
                    //set Variables
                    HelperTestBase.eExamType = EnumExtensionMethods.GetEnumValue<eEXAMTYPE>(sel_ix);

                    if (HelperTestBase.eExamType == eEXAMTYPE.ET_USER_DEFINED)
                        HelperTestBase.currentProjectTest.is_user_defined = true;

                    //  // save edited data & load corresp. data of new selection, if user defined test
                    if (HelperTestBase.eExamType != eEXAMTYPE.ET_NONE)
                        if (HelperTestBase.currentProjectTest.is_user_defined)
                        {
                            if (last_sel_ix >= 0)
                            {
                                //     DialogToParams(&((*(current_exam.user_defined.Params ()[last_sel_ix]))->base_params),
                                //					        &((*(current_exam.user_defined.Params ()[last_sel_ix]))->add_params));

                                //     current_exam.Batch()->Results();    // transfer evtl. made changes of the ref.-column of the result table to the storage
                                //    }

                                //    // set actual param-set
                                //    current_exam.base_params = (*(current_exam.user_defined.Params ()[sel_ix]))->base_params;

                                //    current_exam.add_params.Flush();
                                //    unsigned int n_avail = (*(current_exam.user_defined.Params()[sel_ix]))->add_params.DataAvail();
                                //    for (unsigned int i = 0; i<n_avail; i++)
                                //     current_exam.add_params.DoExpPut((*(current_exam.user_defined.Params ()[sel_ix]))->add_params[i]);
                            }
                            else
                            {
                                //    DialogToParams(&(current_exam.base_params),
                                //                                    &(current_exam.add_params));

                                //    current_exam.Batch()->Results();    // transfer evtl. made changes of the ref.-column of the result table to the storage
                            }

                            //SetNewBasicTestProgram((eEXAMTYPE)(CoBSelectTest->Items->Objects[sel_ix]));
                        }

                    HelperTestBase.Model_GVL.GVL_Graficos = _helperApp.ChartValidate(HelperApp.uiTesteSelecionado, HelperTestBase.Model_GVL.GVL_Graficos.iOutput);

                    tab_TableResultsEnable = false;
                    HelperTestBase.currentProjectTest.is_Created = false;

                    _bCoBSelectTestSelected = false;

                    TAB_ActuationParameters_PopulateData(HelperApp.uiTesteSelecionado);

                    last_sel_ix = sel_ix;
                }

                _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_wTesteSelecionado }, HelperApp.uiTesteSelecionado);
            }
        }

        #endregion

        #region TAB - ActuationParameters - General Settings - Chk Output
        private void rad_EvaluationParameters_CBOutputPC_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rad_EvaluationParameters_CBOutputPC.Checked)
                {
                    int statusCheck = rad_EvaluationParameters_CBOutputPC.Checked ? 1 : 0;

                    _modelGVL.GVL_Parametros.iOutput = statusCheck;

                    HelperTestBase.Model_GVL.GVL_Graficos.iOutput = _modelGVL.GVL_Parametros.iOutput;

                    _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_wOutput }, Convert.ToDouble(_modelGVL.GVL_Parametros.iOutput));

                    if (_helperApp.lstDblReturnReadFile[0] != null)
                    {
                        if (TXTFileHBM_LoadData())
                        {
                            tab_TableResultsEnable = true;
                            TAB_Main.SelectedTab = TAB_Main.TabPages["tab_Diagram"];
                        }
                        else
                            MessageBox.Show("Error TXTFileHBM_LoadData, failed load result data test!", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);

                throw;
            }
        }

        private void rad_EvaluationParameters_CBOutputSC_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rad_EvaluationParameters_CBOutputSC.Checked)
                {
                    int statusCheck = rad_EvaluationParameters_CBOutputSC.Checked ? 2 : 0;

                    _modelGVL.GVL_Parametros.iOutput = statusCheck;

                    HelperTestBase.Model_GVL.GVL_Graficos.iOutput = _modelGVL.GVL_Parametros.iOutput;

                    _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_wOutput }, Convert.ToDouble(_modelGVL.GVL_Parametros.iOutput));

                    if (_helperApp.lstDblReturnReadFile[0] != null)
                    {
                        if (TXTFileHBM_LoadData())
                        {
                            tab_TableResultsEnable = true;
                            TAB_Main.SelectedTab = TAB_Main.TabPages["tab_Diagram"];
                        }
                        else
                            MessageBox.Show("Error TXTFileHBM_LoadData, failed load result data test!", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);

                throw;
            }
        }

        #endregion

        #region TAB - ActuationParameters - General Settings - Buttons Parameters
        private void mbtn_GeneralSettings_BLoadAdjSettings_Click(object sender, EventArgs e)
        {
            //_helperAdam.BLoadAdjSettingsClick(sender);
        }

        private void mbtn_GeneralSettings_BLoadLastestParams_Click(object sender, EventArgs e)
        {
            //_helperAdam.BLoadLatestParamsClick(sender);
        }

        private void mbtn_GeneralSettings_BSaveCurrentParams_Click(object sender, EventArgs e)
        {
            //_helperAdam.BSaveCurrentParamsClick(sender);
        }
        #endregion

        #region TAB - ActuationParameters - General Settings - Panel Vacuum
        private void TAB_ActuationParameters_GeneralSettings_Vaccum_Change(string strValue)
        {
            if (!string.IsNullOrEmpty(strValue))
            {
                var dblValue = _helperApp.NumberDoubleCheck(strValue);

                if (dblValue > 0)
                {
                    MessageBox.Show("This value not is accept!", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    mtxt_GeneralSettings_EParGenVaccum.Text = "0";
                    return;
                }
                else
                {
                    mtxt_GeneralSettings_EParGenVaccum.Text = dblValue.ToString("N2");

                    HelperTestBase.VacuumMin = (dblValue < 0 ? (dblValue + 0.02) : (dblValue - 0.02));
                    HelperTestBase.VacuumMax = (dblValue < 0 ? (dblValue - 0.02) : (dblValue + 0.02));

                    mtxt_GeneralSettings_EParGenVaccumMin.Text = HelperTestBase.VacuumMin.ToString("N2");
                    mtxt_GeneralSettings_EParGenVaccumMax.Text = HelperTestBase.VacuumMax.ToString("N2");

                    //para conversao plc
                    dblValue = (dblValue * -1);

                    HelperTestBase.Vacuum = dblValue;

                    _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_dwVacuoNominal_Bar_LW }, dblValue);
                }
            }
        }
        private void mtxt_GeneralSettings_EParGenVacuumMin_TextChanged(object sender, EventArgs e)
        {
            //_helperAdam.EParGenVacuumMinChange(sender);

            if (System.Text.RegularExpressions.Regex.IsMatch(this.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                this.Text = this.Text.Remove(this.Text.Length - 1);
            }
        }
        private void mtxt_GeneralSettings_EParGenVacuumMax_TextChanged(object sender, EventArgs e)
        {
            //_helperAdam.EParGenVacuumMaxChange(sender);
            if (System.Text.RegularExpressions.Regex.IsMatch(this.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                this.Text = this.Text.Remove(this.Text.Length - 1);
            }
        }
        private void mtxt_GeneralSettings_EParGenVaccum_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = TAB_ActuationParameters_ValidateInputTxt(sender, e);
        }
        private void mtxt_GeneralSettings_EParGenVaccum_Leave(object sender, EventArgs e)
        {
            string strName = ((System.Windows.Forms.Control)sender).Name;

            string strValue = ((MetroFramework.Controls.MetroTextBox)sender).Text;

            TAB_ActuationParameters_GeneralSettings_Vaccum_Change(strValue);
        }
        private void mbtn_GeneralSettings_Minus_EParGenVaccum_Accel_L_Click(object sender, EventArgs e)
        {
            double paramStep = 0.01;

            string strName = ((System.Windows.Forms.Control)sender).Name;

            string strValue = mtxt_GeneralSettings_EParGenVaccum.Text.Trim();

            string strTypeAction = "Minus";

            if (!string.IsNullOrEmpty(strValue))
            {
                var dblValue = _helperApp.NumberDoubleCheck(strValue);

                if (dblValue > 0)
                {
                    MessageBox.Show("This value not is accept!", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    mtxt_GeneralSettings_EParGenVaccum.Text = "0";
                    return;
                }
                else
                {
                    dblValue = (dblValue < 0 ? (dblValue + paramStep) : (dblValue - paramStep));
                    mtxt_GeneralSettings_EParGenVaccum.Text = dblValue.ToString("N2");

                    mtxt_GeneralSettings_EParGenVaccumMin.Text = (dblValue < 0 ? (dblValue + paramStep) : (dblValue - paramStep)).ToString("N2");
                    mtxt_GeneralSettings_EParGenVaccumMax.Text = (dblValue < 0 ? (dblValue - paramStep) : (dblValue + paramStep)).ToString("N2");


                    //para conversao plc
                    dblValue = (dblValue * -1);

                    _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_dwVacuoNominal_Bar_LW }, dblValue);
                }
            }
        }
        private void mbtn_GeneralSettings_Plus_EParGenVaccum_Accel_R_Click(object sender, EventArgs e)
        {
            double paramStep = 0.01;

            string strName = ((System.Windows.Forms.Control)sender).Name;

            string strValue = mtxt_GeneralSettings_EParGenVaccum.Text.Trim();

            string strTypeAction = "Plus";

            if (!string.IsNullOrEmpty(strValue))
            {
                var dblValue = _helperApp.NumberDoubleCheck(strValue);

                if (dblValue > 0)
                {
                    MessageBox.Show("This value not is accept!", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    mtxt_GeneralSettings_EParGenVaccum.Text = "0";
                    return;
                }
                else
                {
                    dblValue = (dblValue < 0 ? (dblValue - paramStep) : (dblValue + paramStep));
                    mtxt_GeneralSettings_EParGenVaccum.Text = dblValue.ToString("N2");

                    mtxt_GeneralSettings_EParGenVaccumMin.Text = (dblValue < 0 ? (dblValue + paramStep) : (dblValue - paramStep)).ToString("N2");
                    mtxt_GeneralSettings_EParGenVaccumMax.Text = (dblValue < 0 ? (dblValue - paramStep) : (dblValue + paramStep)).ToString("N2");

                    //para conversao plc
                    dblValue = (dblValue * -1);

                    _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_dwVacuoNominal_Bar_LW }, dblValue);
                }
            }
        }

        #endregion

        #region TAB - ActuationParameters - General Settings - Panel Consumers

        private void rad_GeneralSettings_CBOriginalConsumer_CheckedChanged(object sender, EventArgs e)
        {
            int statusCheck = rad_GeneralSettings_CBOriginalConsumer.Checked ? 1 : 0;

            HelperTestBase.iTipoConsumidores = statusCheck;

            _modelGVL.GVL_Parametros.iTipoConsumidores = HelperTestBase.iTipoConsumidores;

            _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_wTipoConsumidores }, Convert.ToDouble(_modelGVL.GVL_Parametros.iTipoConsumidores));
        }
        private void rad_GeneralSettings_CBHoseConsumer_CheckedChanged(object sender, EventArgs e)
        {
            int statusCheck = rad_GeneralSettings_CBHoseConsumer.Checked ? 2 : 0;

            HelperTestBase.iTipoConsumidores = statusCheck;

            _modelGVL.GVL_Parametros.iTipoConsumidores = HelperTestBase.iTipoConsumidores;

            _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_wTipoConsumidores }, Convert.ToDouble(_modelGVL.GVL_Parametros.iTipoConsumidores));
        }
        private void TAB_ActuationParameters_GeneralSettings_Consumers_Change(int iConsumerType, int iConsumerPC, int iConsumerSC, bool bPistonLock)
        {
            switch (iConsumerType)
            {
                case 1:
                    rad_GeneralSettings_CBOriginalConsumer.Checked = true;
                    break;
                case 2:
                    rad_GeneralSettings_CBHoseConsumer.Checked = true;
                    break;
                default:
                    rad_GeneralSettings_CBOriginalConsumer.Checked = false;
                    rad_GeneralSettings_CBHoseConsumer.Checked = false;
                    break;
            }

            HelperTestBase.iTipoConsumidores = iConsumerType;

            HelperMODBUS.CS_wTipoConsumidores = iConsumerType;

            mtxt_GeneralSettings_ETubeConsumerPCPressSide.Text = iConsumerPC.ToString();

            mtxt_GeneralSettings_ETubeConsumerSCPressSide.Text = iConsumerSC.ToString();

            mchk_tabActParam_GenSettings_CBLock.Checked = bPistonLock;

            _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_wTipoConsumidores }, Convert.ToDouble(iConsumerType));
        }
        private void mbtn_GeneralSettings_BSelectTubeCons_Click(object sender, EventArgs e)
        {
            //_helperAdam.BSelectTubeConsClick(sender);
            _helperApp.Form_Open(new Form_Operational_SelectTubeConsumers());
        }

        #endregion

        #region TAB - ActuationParameters - General Settings - CHK Piston Lock
        private void mchk_tabActParam_GenSettings_CBLock_CheckedChanged(object sender, EventArgs e)
        {
            string strStatusCheck = mchk_tabActParam_GenSettings_CBLock.Checked ? "True" : "False";

            double dblValue = 0;

            if (strStatusCheck.Equals("True") || strStatusCheck.Equals("False"))
                dblValue = strStatusCheck.Equals("True") ? 1 : 0;
            else
                dblValue = Convert.ToDouble(strStatusCheck.Replace(",", "."));

            HelperTestBase.chkPistonLock = Convert.ToBoolean(strStatusCheck);

            _modelGVL.GVL_Parametros.bHabilitaTravaPistao = HelperTestBase.chkPistonLock;

            _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_wHabilitaTravaPistao }, dblValue);
        }

        #endregion

        #endregion

        #region TAB - ActuationParameters - Panel Actuation

        #region TAB - ActuationParameters - Panel Actuation - Max Force
        private void TAB_ActuationParameters_Actuation_MaxForce_Change(string strName, string strValue)
        {
            if (string.IsNullOrEmpty(strName))
                strName = "mtxt_Actuation_E1ParMaxForce";

            if (!string.IsNullOrEmpty(strValue) && !strValue.Equals(_notReadValue))
            {
                TAB_ActuationParameters_WriteComInputTxt(strName, strValue);

                mtxt_Actuation_E1ParMaxForce.Text = strValue;
            }
        }
        private void mtxt_Actuation_E1ParMaxForce_TextChanged(object sender, EventArgs e)
        {
            string strName = ((System.Windows.Forms.Control)sender).Name;

            string strValue = ((MetroFramework.Controls.MetroTextBox)sender).Text;

            if (!string.IsNullOrEmpty(strValue) && !strValue.Equals(_notReadValue))
            {
                var dblValue = _helperApp.NumberDoubleCheck(strValue);

                if (dblValue < 0)
                    dblValue = (dblValue * -1);

                TAB_ActuationParameters_Actuation_MaxForce_Change(strName, strValue);
            }
        }
        private void mtxt_Actuation_E1ParMaxForce_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = TAB_ActuationParameters_ValidateInputTxt(sender, e);
        }
        private void mtxt_Actuation_E1ParMaxForce_Leave(object sender, EventArgs e)
        {
            string strName = ((System.Windows.Forms.Control)sender).Name;

            string strValue = ((MetroFramework.Controls.MetroTextBox)sender).Text;

            TAB_ActuationParameters_Actuation_MaxForce_Change(strName, strValue);
        }
        private void mbtn_Actuation_Minus_E1ParMaxForce_Accel_L_Click(object sender, EventArgs e)
        {
            double paramStep = 1;

            string strName = ((System.Windows.Forms.Control)sender).Name;

            string strValue = mtxt_Actuation_E1ParMaxForce.Text.Trim();

            string strTypeAction = "Minus";

            if (!string.IsNullOrEmpty(strValue) && !strValue.Equals(_notReadValue))
            {
                var dblValue = _helperApp.NumberDoubleCheck(strValue);

                if (dblValue < 0)
                    dblValue = (dblValue * -1);

                dblValue = (dblValue < 0 ? (dblValue + paramStep) : (dblValue - paramStep));

                strValue = String.Format("{0:0.00}", dblValue);

                TAB_ActuationParameters_Actuation_MaxForce_Change(string.Empty, strValue);
            }
        }
        private void mbtn_Actuation_Plus_E1ParMaxForce_Accel_R_Click(object sender, EventArgs e)
        {
            double paramStep = 1;

            string strName = ((System.Windows.Forms.Control)sender).Name;

            string strValue = mtxt_Actuation_E1ParMaxForce.Text.Trim();

            string strTypeAction = "Plus";

            if (!string.IsNullOrEmpty(strValue) && !strValue.Equals(_notReadValue))
            {
                var dblValue = _helperApp.NumberDoubleCheck(strValue);

                if (dblValue < 0)
                    dblValue = (dblValue * -1);

                dblValue = (dblValue < 0 ? (dblValue - paramStep) : (dblValue + paramStep));

                strValue = String.Format("{0:0.00}", dblValue);

                TAB_ActuationParameters_Actuation_MaxForce_Change(string.Empty, strValue);
            }
        }

        #endregion

        #region TAB - ActuationParameters - Panel Actuation - Gradient Force
        private void TAB_ActuationParameters_Actuation_GradientForce_Change(string strName, string strValue)
        {
            if (string.IsNullOrEmpty(strName))
                strName = "mtxt_Actuation_E1ParForceGrad";

            if (!string.IsNullOrEmpty(strValue) && !strValue.Equals(_notReadValue))
                TAB_ActuationParameters_WriteComInputTxt(strName, strValue);
        }
        private void mtxt_Actuation_E1ParForceGrad_TextChanged(object sender, EventArgs e)
        {
            string strName = ((System.Windows.Forms.Control)sender).Name;

            string strValue = ((MetroFramework.Controls.MetroTextBox)sender).Text;

            if (!string.IsNullOrEmpty(strValue) && !strValue.Equals(_notReadValue))
            {
                var dblValue = _helperApp.NumberDoubleCheck(strValue);

                if (dblValue < 0)
                    dblValue = (dblValue * -1);

                TAB_ActuationParameters_Actuation_GradientForce_Change(strName, strValue);
            }
        }
        private void mtxt_Actuation_E1ParForceGrad_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = TAB_ActuationParameters_ValidateInputTxt(sender, e);
        }
        private void mtxt_Actuation_E1ParForceGrad_Leave(object sender, EventArgs e)
        {
            string strName = ((System.Windows.Forms.Control)sender).Name;

            string strValue = ((MetroFramework.Controls.MetroTextBox)sender).Text;

            TAB_ActuationParameters_Actuation_GradientForce_Change(strName, strValue);
        }
        private void mbtn_Actuation_Minus_E1ParForceGrad_Accel_L_Click(object sender, EventArgs e)
        {
            double paramStep = 1;

            string strName = ((System.Windows.Forms.Control)sender).Name;

            string strValue = mtxt_Actuation_E1ParForceGrad.Text.Trim();

            string strTypeAction = "Minus";

            if (!string.IsNullOrEmpty(strValue) && !strValue.Equals(_notReadValue))
            {
                var dblValue = _helperApp.NumberDoubleCheck(strValue);

                if (dblValue < 0)
                    dblValue = (dblValue * -1);

                dblValue = (dblValue < 0 ? (dblValue + paramStep) : (dblValue - paramStep));

                strValue = String.Format("{0:0.00}", dblValue);

                mtxt_Actuation_E1ParForceGrad.Text = strValue;
            }
        }
        private void mbtn_Actuation_Plus_E1ParForceGrad_Accel_R_Click(object sender, EventArgs e)
        {
            double paramStep = 1;

            string strName = ((System.Windows.Forms.Control)sender).Name;

            string strValue = mtxt_Actuation_E1ParForceGrad.Text.Trim();

            string strTypeAction = "Plus";

            if (!string.IsNullOrEmpty(strValue) && !strValue.Equals(_notReadValue))
            {
                var dblValue = _helperApp.NumberDoubleCheck(strValue);

                if (dblValue < 0)
                    dblValue = (dblValue * -1);

                dblValue = (dblValue < 0 ? (dblValue - paramStep) : (dblValue + paramStep));

                strValue = String.Format("{0:0.00}", dblValue);

                mtxt_Actuation_E1ParForceGrad.Text = strValue;
            }
        }

        #endregion

        #endregion

        #region TAB - ActuationParameters - Panel Evaluation Parameters

        #region TAB - ActuationParameters - Evaluation Parameters - Grid
        private void TAB_ActuationParameters_EvalParameters_Grid_Format()
        {
            try
            {
                //Columns
                for (int i = 0; i < grid_tabActionParam_EvalParam.Columns.Count; i++)
                {
                    grid_tabActionParam_EvalParam.Columns[i].Visible = false;
                    grid_tabActionParam_EvalParam.Columns[i].ReadOnly = true;
                    grid_tabActionParam_EvalParam.Columns[i].HeaderCell.Value = String.Empty;
                    grid_tabActionParam_EvalParam.Columns[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    grid_tabActionParam_EvalParam.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    grid_tabActionParam_EvalParam.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                    grid_tabActionParam_EvalParam.Columns[i].Resizable = DataGridViewTriState.False;
                }

                //show grid's column's
                grid_tabActionParam_EvalParam.Columns["IdEvalParam"].Visible = true; //ID
                grid_tabActionParam_EvalParam.Columns["IdEvalParam"].Width = _bUseChkGrid ? 40 : 0;
                grid_tabActionParam_EvalParam.Columns["IdEvalParam"].DefaultCellStyle.BackColor = Color.White;
                grid_tabActionParam_EvalParam.Columns["IdEvalParam"].DefaultCellStyle.ForeColor = Color.White;

                grid_tabActionParam_EvalParam.Columns["EvalParam_Caption"].HeaderCell.Value = "Parameter";
                grid_tabActionParam_EvalParam.Columns["EvalParam_Caption"].Visible = true; //CAPTION
                grid_tabActionParam_EvalParam.Columns["EvalParam_Caption"].Width = _bUseChkGrid ? 500 : 550;
                grid_tabActionParam_EvalParam.Columns["EvalParam_Caption"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                grid_tabActionParam_EvalParam.Columns["EvalParam_Hi"].HeaderCell.Value = "Hi Value";
                grid_tabActionParam_EvalParam.Columns["EvalParam_Hi"].ReadOnly = false;
                grid_tabActionParam_EvalParam.Columns["EvalParam_Hi"].Visible = true; //HI
                grid_tabActionParam_EvalParam.Columns["EvalParam_Hi"].Width = 185;

                grid_tabActionParam_EvalParam.Columns["UnitSymbol"].HeaderCell.Value = "Unit";
                grid_tabActionParam_EvalParam.Columns["UnitSymbol"].Visible = true; //UNIT

                grid_tabActionParam_EvalParam.Columns["EvalParam_Name"].HeaderCell.Value = "Param_Name";
                grid_tabActionParam_EvalParam.Columns["EvalParam_Name"].Visible = true;
                grid_tabActionParam_EvalParam.Columns["EvalParam_Name"].Width = 0;
                grid_tabActionParam_EvalParam.Columns["EvalParam_Name"].DisplayIndex = 19;

                grid_tabActionParam_EvalParam.Columns["EvalParam_ResultParam_Name"].HeaderCell.Value = "EvalParam_ResultParam_Name";
                grid_tabActionParam_EvalParam.Columns["EvalParam_ResultParam_Name"].Visible = true;
                grid_tabActionParam_EvalParam.Columns["EvalParam_ResultParam_Name"].Width = 0;
                grid_tabActionParam_EvalParam.Columns["EvalParam_ResultParam_Name"].DisplayIndex = 20;

                //set focus
                var rowIndex = grid_tabActionParam_EvalParam.Rows.Count - 1;

                grid_tabActionParam_EvalParam.CurrentCell = grid_tabActionParam_EvalParam.Rows[rowIndex].Cells["EvalParam_Hi"];
                grid_tabActionParam_EvalParam.Rows[rowIndex].Selected = true;
                grid_tabActionParam_EvalParam.Rows[rowIndex].Cells["EvalParam_Hi"].Selected = true;
            }
            catch (Exception ex)
            {
                var exc = ex.Message;
                MessageBox.Show(exc);
            }

        }
        private void TAB_ActuationParameters_EvalParameters_Grid_GridRowType(DataTable dtGridEvalParameters)
        {
            try
            {
                string strGridRowType = string.Empty;
                string strEvalParam_Name = string.Empty;

                int countColumns = dtGridEvalParameters.Columns.Count;
                int countRows = dtGridEvalParameters.Rows.Count;
                var columnSpec = new DataColumn();

                int iRowIndex = 0;

                //DataTable dt = new DataTable();
                //dt.Columns.Add("name");
                //for (int j = 0; j < 10; j++)
                //{
                //    dt.Rows.Add("");
                //}
                //this.dataGridView1.DataSource = dt;
                //this.dataGridView1.Columns[0].Width = 200;

                ///*
                // * First method : Convert to an existed cell type such ComboBox cell,etc
                // */

                //DataGridViewComboBoxCell ComboBoxCell = new DataGridViewComboBoxCell();
                //ComboBoxCell.Items.AddRange(new string[] { "aaa", "bbb", "ccc" });
                //this.dataGridView1[0, 0] = ComboBoxCell;
                //this.dataGridView1[0, 0].Value = "bbb";

                //DataGridViewTextBoxCell TextBoxCell = new DataGridViewTextBoxCell();
                //this.dataGridView1[0, 1] = TextBoxCell;
                //this.dataGridView1[0, 1].Value = "some text";

                //DataGridViewCheckBoxCell CheckBoxCell = new DataGridViewCheckBoxCell();
                //CheckBoxCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                //this.dataGridView1[0, 2] = CheckBoxCell;
                //this.dataGridView1[0, 2].Value = true;

                DataTable dt = new DataTable();

                #region SET COLUMNS

                for (int k = 0; k < countColumns; k++)
                {
                    columnSpec = new DataColumn
                    {
                        DataType = dtGridEvalParameters.Columns[k].DataType, // This is of type System.Type
                        ColumnName = dtGridEvalParameters.Columns[k].ColumnName // This is of type string
                    };

                    dt.Columns.Add(columnSpec);
                }

                grid_tabActionParam_EvalParam.DataSource = dt;

                #endregion

                #region SET ROWS

                if (dtGridEvalParameters.Columns.Count > 0)
                {
                    int iItemArrayCount = dtGridEvalParameters.Rows[0].ItemArray.Count(); ;

                    for (int j = 0; j < countRows; j++)
                    {
                        dt.Rows.Add(new object[iItemArrayCount]);

                        DataRow row = dtGridEvalParameters.Rows[j];

                        iRowIndex = j;

                        DataGridViewTextBoxCell TextBoxCell_Id = new DataGridViewTextBoxCell();
                        int idxCol_Id = row.Table.Columns["IdEvalParam"].Ordinal;
                        int iEvalParam_Id = row.Field<int>("IdEvalParam");

                        DataGridViewTextBoxCell TextBoxCell_Name = new DataGridViewTextBoxCell();
                        int idxCol_Name = row.Table.Columns["EvalParam_Name"].Ordinal;

                        DataGridViewTextBoxCell TextBoxCell_EvalParam_ResultParam_Name = new DataGridViewTextBoxCell();
                        int idxCol_EvalParam_ResultParam_Name = row.Table.Columns["EvalParam_ResultParam_Name"].Ordinal;
                        string strEvalParam_ResultParam_Name = string.Empty;

                        DataGridViewTextBoxCell TextBoxCell_Caption = new DataGridViewTextBoxCell();
                        int idxCol_Caption = row.Table.Columns["EvalParam_Caption"].Ordinal;
                        string strEvalParam_Caption = string.Empty;

                        strGridRowType = row.Field<string>("EvalParam_GridRowType").ToString();

                        switch (strGridRowType)
                        {
                            case "ADDINPUT_CREATE_VSPACE":
                                dt.Rows.Add(new object[iItemArrayCount]);
                                break;
                            case "CREATE_ANALOG_INPUT":
                                {
                                    strEvalParam_Name = row.Field<string>("EvalParam_Name")?.ToString()?.Trim();
                                    strEvalParam_Caption = row.Field<string>("EvalParam_Caption")?.ToString()?.Trim();
                                    strEvalParam_ResultParam_Name = row.Field<string>("EvalParam_ResultParam_Name")?.ToString()?.Trim();

                                    DataGridViewTextBoxCell TextBoxCell_Hi = new DataGridViewTextBoxCell();
                                    int idxCol_Hi = row.Table.Columns["EvalParam_Hi"].Ordinal;
                                    decimal decEvalParam_Hi = row.Field<decimal>("EvalParam_Hi");

                                    DataGridViewTextBoxCell TextBoxCell_UnitSymbol = new DataGridViewTextBoxCell();
                                    int idxCol_UnitSymbol = row.Table.Columns["UnitSymbol"].Ordinal;
                                    string strEvalParam_UnitSymbol = row.Field<string>("UnitSymbol")?.ToString()?.Trim();

                                    grid_tabActionParam_EvalParam[idxCol_Id, iRowIndex] = TextBoxCell_Id;
                                    grid_tabActionParam_EvalParam[idxCol_Id, iRowIndex].Value = iEvalParam_Id;

                                    grid_tabActionParam_EvalParam[idxCol_Caption, iRowIndex] = TextBoxCell_Caption;
                                    grid_tabActionParam_EvalParam[idxCol_Caption, iRowIndex].Value = strEvalParam_Caption;

                                    grid_tabActionParam_EvalParam[idxCol_Hi, iRowIndex] = TextBoxCell_Hi;
                                    grid_tabActionParam_EvalParam[idxCol_Hi, iRowIndex].Value = decEvalParam_Hi;

                                    grid_tabActionParam_EvalParam[idxCol_UnitSymbol, iRowIndex] = TextBoxCell_UnitSymbol;
                                    grid_tabActionParam_EvalParam[idxCol_UnitSymbol, iRowIndex].Value = strEvalParam_UnitSymbol;

                                    grid_tabActionParam_EvalParam[idxCol_Name, iRowIndex] = TextBoxCell_Name;
                                    grid_tabActionParam_EvalParam[idxCol_Name, iRowIndex].Value = strEvalParam_Name;

                                    grid_tabActionParam_EvalParam[idxCol_EvalParam_ResultParam_Name, iRowIndex] = TextBoxCell_EvalParam_ResultParam_Name;
                                    grid_tabActionParam_EvalParam[idxCol_EvalParam_ResultParam_Name, iRowIndex].Value = strEvalParam_ResultParam_Name;
                                }
                                break;
                            case "CREATE_CHECKBOX_INPUT":
                                {
                                    strEvalParam_Name = row.Field<string>("EvalParam_Name")?.ToString()?.Trim();
                                    strEvalParam_Caption = row.Field<string>("EvalParam_Caption")?.ToString()?.Trim();
                                    strEvalParam_ResultParam_Name = row.Field<string>("EvalParam_ResultParam_Name")?.ToString()?.Trim();

                                    DataGridViewCheckBoxCell CheckBoxCell = new DataGridViewCheckBoxCell();
                                    CheckBoxCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

                                    grid_tabActionParam_EvalParam[idxCol_Id, iRowIndex] = TextBoxCell_Id;
                                    grid_tabActionParam_EvalParam[idxCol_Id, iRowIndex].Value = iEvalParam_Id;

                                    grid_tabActionParam_EvalParam[0, iRowIndex] = CheckBoxCell;
                                    grid_tabActionParam_EvalParam[0, iRowIndex].Value = false;

                                    grid_tabActionParam_EvalParam[idxCol_Caption, iRowIndex] = TextBoxCell_Caption;
                                    grid_tabActionParam_EvalParam[idxCol_Caption, iRowIndex].Value = strEvalParam_Caption;

                                    grid_tabActionParam_EvalParam[idxCol_Name, iRowIndex] = TextBoxCell_Name;
                                    grid_tabActionParam_EvalParam[idxCol_Name, iRowIndex].Value = strEvalParam_Name;

                                    grid_tabActionParam_EvalParam[idxCol_EvalParam_ResultParam_Name, iRowIndex] = TextBoxCell_EvalParam_ResultParam_Name;
                                    grid_tabActionParam_EvalParam[idxCol_EvalParam_ResultParam_Name, iRowIndex].Value = strEvalParam_ResultParam_Name;

                                    _bUseChkGrid = true;
                                }
                                break;
                            case "CREATE_RADIO_INPUT":
                                break;
                            case "CREATE_COMBO_INPUT":
                                DataGridViewComboBoxCell ComboBoxCell = new DataGridViewComboBoxCell();
                                ComboBoxCell.Items.AddRange(new string[] { "aaa", "bbb", "ccc" });

                                iRowIndex = 0;
                                grid_tabActionParam_EvalParam[idxCol_Caption, iRowIndex] = ComboBoxCell;
                                grid_tabActionParam_EvalParam[idxCol_Caption, iRowIndex].Value = "bbb";
                                break;
                            default:
                                break;
                        }
                    }

                    grid_tabActionParam_EvalParam.DataSource = dt;
                }

                #endregion
            }
            catch (Exception ex)
            {
                var exc = ex.Message;
                MessageBox.Show(exc);
            }
        }
        private void grid_tabActionParam_EvalParam_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var row = ((System.Windows.Forms.DataGridView)sender).CurrentRow;
            string strName = ((System.Windows.Forms.DataGridView)sender).CurrentRow.Cells["EvalParam_Hi"].Value.ToString();
            string strValue = ((System.Windows.Forms.DataGridView)sender).CurrentCell.EditedFormattedValue.ToString();

            if (!string.IsNullOrEmpty(strValue) && row != null)
            {
                List<ActuationParameters_EvaluationParameters> lstInfoEvaluationParameters = _helperApp.GridView_GetValuesEvalParam(grid_tabActionParam_EvalParam);

                if (HelperApp.uiTesteSelecionado > 0)
                    TAB_ActuationParameters_WriteComGridEvalParameters(lstInfoEvaluationParameters);
            }
            //tab_ActionParameters_WriteComEditGridEvalParameters(row.Index, strName, strValue);
        }
        private void grid_tabActionParam_EvalParam_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewCell gvCell = grid_tabActionParam_EvalParam.Rows[e.RowIndex].Cells[0];

                if (gvCell.GetType() == typeof(DataGridViewCheckBoxCell))
                {
                    if (e.RowIndex >= 0)
                        gvCell.Value = !Convert.ToBoolean(gvCell.Value);


                    if (Convert.ToBoolean(gvCell.Value))
                    {

                    }
                }
            }
        }
        private void grid_tabActionParam_EvalParam_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int iRowIndex = e.RowIndex;
                bool chkStatus = false;

                DataGridViewRow gvRow = grid_tabActionParam_EvalParam.Rows[iRowIndex];

                DataGridViewCell gvCell = gvRow.Cells[0];

                int iItemArrayCount = gvRow.Cells.Count;

                if (gvCell.GetType() == typeof(DataGridViewCheckBoxCell))
                {
                    DataGridViewCheckBoxCell checkBoxCell = gvCell as DataGridViewCheckBoxCell;

                    //We don't want a null exception!
                    if (checkBoxCell.Value != null)
                    {
                        //enable cell with check
                        checkBoxCell.ReadOnly = false;

                        //set value
                        chkStatus = Convert.ToBoolean(checkBoxCell.EditedFormattedValue);
                    }

                    switch (HelperApp.uiTesteSelecionado)
                    {
                        case 5:     //Vaccum Leakage - Released Position
                            break;
                        case 6:     //Vacuum Leakage - Fully Applied Position
                                    //CHECKBOX USE SINGLE INPUT FORCE
                            HelperTestBase.Model_GVL.GVL_T06.bForcaAbsoluta = chkStatus;
                            _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_wForcaAbsoluta_T06 }, Convert.ToDouble(chkStatus));
                            break;
                        case 7:     //Vacuum Leakage - Lap Position
                            switch (iRowIndex)
                            {
                                case 8://CHECKBOX USE SINGLE INPUT FORCE
                                    HelperTestBase.Model_GVL.GVL_T07.bForcaAbsoluta = chkStatus;
                                    _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_wTesteSimples_T07 }, Convert.ToDouble(chkStatus));

                                    if (chkStatus)
                                    {
                                        //iRowIndex = iRowIndex + 1;

                                        //DataTable dataTable = (DataTable)grid_tabActionParam_EvalParam.DataSource;
                                        //DataRow drToAdd = dataTable.NewRow();

                                        ////drToAdd["EvalParam_Caption"] = "ABOLUTE/REATIVE";

                                        //var strEvalParam_Caption = "ABOLUTE/REATIVE";

                                        //DataGridViewCheckBoxCell CheckBoxCell = new DataGridViewCheckBoxCell();
                                        //CheckBoxCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

                                        //grid_tabActionParam_EvalParam[0, iRowIndex] = CheckBoxCell;
                                        //grid_tabActionParam_EvalParam[0, iRowIndex].Value = false;

                                        //DataGridViewTextBoxCell TextBoxCell_Caption = new DataGridViewTextBoxCell();
                                        //grid_tabActionParam_EvalParam[4, iRowIndex] = TextBoxCell_Caption;
                                        //grid_tabActionParam_EvalParam[4, iRowIndex].Value = strEvalParam_Caption;

                                        //_bUseChkGrid = true;

                                        //dataTable.Rows.InsertAt(drToAdd, iRowIndex);
                                        //dataTable.AcceptChanges();
                                    }
                                    break;
                                default://INCLUIR CHECKBOX (ABOLUTE/REATIVE)
                                    HelperTestBase.Model_GVL.GVL_T07.bForcaAbsoluta = chkStatus;
                                    _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_wForcaAbsoluta_T07 }, Convert.ToDouble(chkStatus));
                                    break;
                            }
                            break;
                        case 8:      //Hydraulic Leakage - Fully Applied Position
                                     //CHECKBOX USE SINGLE INPUT FORCE
                            HelperTestBase.Model_GVL.GVL_T08.bForcaAbsoluta = chkStatus;
                            _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_wForcaAbsoluta_T08 }, Convert.ToDouble(chkStatus));
                            break;
                        default:
                            break;
                    }
                }
            }
        }
        public void TAB_ActuationParameters_WriteComGridEvalParameters(List<ActuationParameters_EvaluationParameters> lstInfoEvaluationParameters)
        {
            for (int i = 0; i < lstInfoEvaluationParameters.Count; i++)
            {
                int iRowIndex = i;

                var itemEvalParam = lstInfoEvaluationParameters[i];

                double dblValue = itemEvalParam.EvalParam_Hi;

                string strValue = itemEvalParam.EvalParam_Hi.ToString();

                string strName = itemEvalParam.EvalParam_Name;

                string strCellType = itemEvalParam.EvalParam_GridRowType; //&& strCellType?.Equals("CREATE_ANALOG_INPUT")

                if (!string.IsNullOrEmpty(strName))
                {
                    if (dblValue < 0)
                        dblValue = (dblValue * -1);

                    if (HelperApp.uiTesteSelecionado > 4)
                        TAB_ActuationParameters_WriteComEditGridEvalParameters(iRowIndex, strName, strValue);
                    else
                    {
                        switch (HelperApp.uiTesteSelecionado)
                        {
                            case 1:     //Force Diagrams - Force/Pressure With Vacuum
                                {
                                    #region Case Param

                                    switch (strName.Trim())
                                    {
                                        case "EForceScale":
                                            break;

                                        case "EPressureScale":
                                            break;

                                        case "EP3AtForce": //Pressure at Force(E3) =
                                            HelperTestBase.Model_GVL.GVL_T01.rForca_E1 = dblValue;
                                            break;

                                        case "EP4AtForce": //Pressure at Force(E4) = 
                                            HelperTestBase.Model_GVL.GVL_T01.rForca_E2 = dblValue;
                                            break;

                                        case "EP5AtForce": //Pressure at Force(E5) = 
                                            HelperTestBase.Model_GVL.GVL_T01.rForca_P1 = dblValue;
                                            break;

                                        case "EP6AtForce": //Pressure at Force(E6) =
                                            HelperTestBase.Model_GVL.GVL_T01.rForca_P2 = dblValue;
                                            break;

                                        case "EPistonTravelAtPressure": //Travel at Pressure = 
                                            HelperTestBase.Model_GVL.GVL_T01.rDeslocamentoNaPressao = dblValue;
                                            break;

                                        case "EActuationForceAtPressure": //Actuation Force at Pressure = 
                                            HelperTestBase.Model_GVL.GVL_T01.rPressaoCutIn_Bar = dblValue;
                                            break;

                                        case "EReleaseForceMin": //Release Force min = 
                                            HelperTestBase.Model_GVL.GVL_T01.rReleaseForcePressMin_Bar = dblValue;
                                            break;

                                        case "EReleaseForceMax": //Release Force max = 
                                            HelperTestBase.Model_GVL.GVL_T01.rReleaseForcePressMax_Bar = dblValue;
                                            break;

                                        case "EHysteresisAtPressure": //Hysteresis at Pressure(%) = 
                                            HelperTestBase.Model_GVL.GVL_T01.rPressaoHysterese_pout = dblValue;
                                            break;

                                        case "EHysteresisAtPressure2": //Hysteresis at Pressure(bar) = 
                                            HelperTestBase.Model_GVL.GVL_T01.rPressaoHysterese_Bar = dblValue;
                                            break;

                                        case "ERelForceRemainAtTravel": //Release Force Remaining at = 
                                            HelperTestBase.Model_GVL.GVL_T01.rReleaseForceAt_mm = dblValue;
                                            break;

                                        case "ETMCDiameterPC": //TMC Diameter PC = 
                                            HelperTestBase.Model_GVL.GVL_T01.rDiametroCMD_mm = dblValue;
                                            break;

                                        case "ETMCDiameterSC": // TMC Diameter SC = 
                                            HelperTestBase.Model_GVL.GVL_T01.rDiametroCMD_mm = dblValue;
                                            break;

                                        case "EJumperGradientP1": //Jumper Gradient P1 = 
                                            HelperTestBase.Model_GVL.GVL_T01.rGradienteJumper_P1_Bar = dblValue;
                                            break;

                                        case "EJumperGradientP2": //Jumper Gradient P2 = 
                                            HelperTestBase.Model_GVL.GVL_T01.rGradienteJumper_P2_Bar = dblValue;
                                            break;

                                        case "CBUseLinearIntersection": //checkbox - 
                                                                        //HelperTestBase.Model_GVL.GVL_T01.bRunOutTeorico = false; 
                                            break;

                                        default:
                                            break;
                                    }

                                    #endregion

                                    HelperTestBase.Model_GVL.helperTestBase_ModelGVL_Test = HelperTestBase.Model_GVL.GVL_T01;

                                    break;
                                }
                            case 2:     //Force Diagrams - Force/Force With Vacuum
                                {
                                    #region Case Param

                                    switch (strName.Trim())
                                    {

                                        case "EForceScaleI":
                                            break;

                                        case "EForceScaleO":
                                            break;

                                        case "EP3AtForce": //Pressure at Force(E3) =
                                            HelperTestBase.Model_GVL.GVL_T02.rForca_E1 = dblValue;
                                            break;

                                        case "EP4AtForce": //Pressure at Force(E4) = 
                                            HelperTestBase.Model_GVL.GVL_T02.rForca_E2 = dblValue;
                                            break;

                                        case "EP5AtForce": //Pressure at Force(E5) = 
                                            HelperTestBase.Model_GVL.GVL_T02.rForca_P1 = dblValue;
                                            break;

                                        case "EP6AtForce": //Pressure at Force(E6) =
                                            HelperTestBase.Model_GVL.GVL_T02.rForca_P2 = dblValue;
                                            break;

                                        case "EPistonTravelAtForce": //Travel at Pressure = 
                                            HelperTestBase.Model_GVL.GVL_T02.rDeslocamentoNaForca = dblValue;
                                            break;

                                        case "EActuationForceAtForce": //Actuation Force at Pressure = 
                                            HelperTestBase.Model_GVL.GVL_T02.rForcaCutIn_N = dblValue;
                                            break;

                                        case "EReleaseForceMin": //Release Force min = 
                                            HelperTestBase.Model_GVL.GVL_T02.rReleaseForceFoutMin_N = dblValue;
                                            break;

                                        case "EReleaseForceMax": //Release Force max = 
                                            HelperTestBase.Model_GVL.GVL_T02.rReleaseForceFoutMax_N = dblValue;
                                            break;

                                        case "EHysteresisAtForce": //Hysteresis at Pressure(%) = 
                                            HelperTestBase.Model_GVL.GVL_T02.rForcaHysterese_pout = dblValue;
                                            break;

                                        case "ERelForceRemainAtTravel": //Release Force Remaining at = 
                                            HelperTestBase.Model_GVL.GVL_T02.rReleaseForceAt_mm = dblValue;
                                            break;

                                        case "EJumperGradientF1": //Jumper Gradient P1 = 
                                            HelperTestBase.Model_GVL.GVL_T02.rGradienteJumper_P1_N = dblValue;
                                            break;

                                        case "EJumperGradientF2": //Jumper Gradient P2 = 
                                            HelperTestBase.Model_GVL.GVL_T02.rGradienteJumper_P2_N = dblValue;
                                            break;

                                        case "CBUseLinearIntersection": //checkbox - 
                                                                        //  HelperTestBase.Model_GVL.GVL_T02.bRunOutTeorico = false; 
                                            break;

                                        default:
                                            break;
                                    }

                                    #endregion

                                    HelperTestBase.Model_GVL.helperTestBase_ModelGVL_Test = HelperTestBase.Model_GVL.GVL_T02;

                                    break;
                                }
                            case 3:     //Force Diagrams - Force/Pressure Without Vacuum
                                {
                                    #region Case Param

                                    switch (strName.Trim())
                                    {
                                        case "EForceScale":
                                            break;

                                        case "EPressureScale":
                                            break;

                                        case "EP3AtForce": //Pressure at Force(E3) =
                                            HelperTestBase.Model_GVL.GVL_T03.rForca_E1 = dblValue;
                                            break;

                                        case "EP4AtForce": //Pressure at Force(E4) = 
                                            HelperTestBase.Model_GVL.GVL_T03.rForca_E2 = dblValue;
                                            break;

                                        case "EP5AtForce": //Pressure at Force(E5) = 
                                            HelperTestBase.Model_GVL.GVL_T03.rForca_P1 = dblValue;
                                            break;

                                        case "EP6AtForce": //Pressure at Force(E6) =
                                            HelperTestBase.Model_GVL.GVL_T03.rForca_P2 = dblValue;
                                            break;


                                        case "EActuationForceAtPressure": //Actuation Force at Pressure = 
                                            HelperTestBase.Model_GVL.GVL_T03.rPressaoCutIn_Bar = dblValue;
                                            break;

                                        case "EReleaseForceMin": //Release Force min = 
                                            HelperTestBase.Model_GVL.GVL_T03.rReleaseForcePressMin_Bar = dblValue;
                                            break;

                                        case "EReleaseForceMax": //Release Force max = 
                                            HelperTestBase.Model_GVL.GVL_T03.rReleaseForcePressMax_Bar = dblValue;
                                            break;

                                        case "ERelForceRemainAtTravel": //Release Force Remaining at = 
                                            HelperTestBase.Model_GVL.GVL_T03.rReleaseForceAt_mm = dblValue;
                                            break;

                                        default:
                                            break;
                                    }

                                    #endregion

                                    HelperTestBase.Model_GVL.helperTestBase_ModelGVL_Test = HelperTestBase.Model_GVL.GVL_T03;

                                    break;
                                }
                            case 4:     //Force Diagrams - Force/Force Without Vacuum
                                {
                                    #region Case Param

                                    switch (strName.Trim())
                                    {

                                        case "EForceScaleI":
                                            break;

                                        case "EForceScaleO":
                                            break;

                                        case "EP3AtForce": //Pressure at Force(E3) =
                                            HelperTestBase.Model_GVL.GVL_T04.rForca_E1 = dblValue;
                                            break;

                                        case "EP4AtForce": //Pressure at Force(E4) = 
                                            HelperTestBase.Model_GVL.GVL_T04.rForca_E2 = dblValue;
                                            break;

                                        case "EActuationForceAtForce": //Actuation Force at Pressure = 
                                            HelperTestBase.Model_GVL.GVL_T04.rForcaCutIn_N = dblValue;
                                            break;

                                        case "EReleaseForceMin": //Release Force min = 
                                            HelperTestBase.Model_GVL.GVL_T04.rReleaseForceFoutMin_N = dblValue;
                                            break;

                                        case "EReleaseForceMax": //Release Force max = 
                                            HelperTestBase.Model_GVL.GVL_T04.rReleaseForceFoutMax_N = dblValue;
                                            break;


                                        case "ERelForceRemainAtTravel": //Release Force Remaining at = 
                                            HelperTestBase.Model_GVL.GVL_T04.rReleaseForceAt_mm = dblValue;
                                            break;

                                        default:
                                            break;
                                    }

                                    #endregion

                                    HelperTestBase.Model_GVL.helperTestBase_ModelGVL_Test = HelperTestBase.Model_GVL.GVL_T04;

                                    break;
                                }
                            case 5: //Vaccum Leakage - Released Position
                                {
                                    #region Case Param

                                    switch (strName.Trim())
                                    {

                                        case "ETimeScale":
                                            break;

                                        case "EVacuumScale":
                                            break;

                                        case "ETestingTime": //Tempo de teste
                                            HelperTestBase.Model_GVL.GVL_T05.rTempoTeste = dblValue;
                                            //_helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_dwTempoTeste_T05_LW }, dblValue);
                                            break;

                                        case "EStabTime": //Tempo de estabilizacao 
                                            HelperTestBase.Model_GVL.GVL_T05.rTempoEstabilizacao = dblValue;
                                            //_helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_dwTempoEstabilizacao_T05_LW }, dblValue);
                                            break;

                                        default:
                                            break;
                                    }

                                    #endregion

                                    HelperTestBase.Model_GVL.helperTestBase_ModelGVL_Test = HelperTestBase.Model_GVL.GVL_T05;

                                    break;
                                }
                            case 6: //Vacuum Leakage - Fully Applied Position
                                {
                                    #region Case Param

                                    switch (strName.Trim())
                                    {
                                        case "ETimeScale":
                                            break;

                                        case "EVacuumScale":
                                            break;

                                        case "ETestingTime": //Tempo de teste
                                            HelperTestBase.Model_GVL.GVL_T06.rTempoTeste = dblValue;
                                            //_helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_dwTempoTeste_T06_LW }, dblValue);
                                            break;

                                        case "EStabTime": //Tempo de estabilizacao
                                            HelperTestBase.Model_GVL.GVL_T06.rTempoEstabilizacao = dblValue;
                                            //_helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_dwTempoEstabilizacao_T06_LW }, dblValue);
                                            break;

                                        case "EForcePercentEout": //Forca relativa a Eout (%)
                                            HelperTestBase.Model_GVL.GVL_T06.rForcaMaximaRelativa = dblValue;
                                            //_helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_dwForcaMaximaRelativa_T06_LW }, dblValue);
                                            break;

                                        case "CBUseSingleInputForce": //Utilizar valor absoluto de forca
                                            break;

                                        case "EInputForce": //Forca Absoluta
                                            HelperTestBase.Model_GVL.GVL_T06.rForcaMaximaAbsoluta_N = dblValue;
                                            //_helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_dwForcaMaximaAbsoluta_T06_LW }, dblValue);
                                            break;

                                        default:
                                            break;
                                    }

                                    #endregion

                                    HelperTestBase.Model_GVL.helperTestBase_ModelGVL_Test = HelperTestBase.Model_GVL.GVL_T06;

                                    break;
                                }
                            case 7: //Vacuum Leakage - Lap Position
                                {
                                    #region Case Param

                                    switch (strName.Trim())
                                    {
                                        case "ETimeScale":
                                            break;

                                        case "EPressureScale":
                                            break;

                                        case "ETestingTime": //Tempo de teste
                                            HelperTestBase.Model_GVL.GVL_T07.rTempoTeste = dblValue;
                                            //_helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_dwTempoTeste_T07_LW }, dblValue);
                                            break;

                                        case "EStabTime": //Tempo de estabilizacao
                                            HelperTestBase.Model_GVL.GVL_T07.rTempoEstabilizacao = dblValue;
                                            //_helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_dwTempoEstabilizacao_T07_LW }, dblValue);
                                            break;

                                        case "ERelInputForce1": //Forca relativa avanco intermediario
                                            HelperTestBase.Model_GVL.GVL_T07.rForcaRelativaAvanco = dblValue;
                                            //_helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_dwForcaRelativaAvanco_T07_LW }, dblValue);
                                            break;

                                        case "ERelInputForce2": //Forca relativa retorno
                                            HelperTestBase.Model_GVL.GVL_T07.rForcaRelativaRetorno = dblValue;
                                            //_helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_dwForcaRelativaRetorno_T07_LW }, dblValue);
                                            break;

                                        case "ERelInputForce3": //Forca relativa avanco final
                                            HelperTestBase.Model_GVL.GVL_T07.rForcaRelativaFinal = dblValue;
                                            //_helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_dwForcaRelativaFinal_T07_LW }, dblValue);
                                            break;

                                        case "CBUseInputForce": //Utilizar valor absoluto de forca
                                            break;

                                        case "EInputForceRelative": //Forca relativa a Eout (%)
                                            HelperTestBase.Model_GVL.GVL_T07.rForcaMaximaRelativa = dblValue;
                                            //_helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_dwForcaMaximaRelativa_T07_LW }, dblValue);
                                            break;

                                        case "EInputForce": //Forca Absoluta
                                            HelperTestBase.Model_GVL.GVL_T07.rForcaMaximaAbsoluta_N = dblValue;
                                            //_helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_dwForcaMaximaAbsoluta_T07_LW }, dblValue);
                                            break;

                                        default:
                                            break;
                                    }

                                    #endregion

                                    HelperTestBase.Model_GVL.helperTestBase_ModelGVL_Test = HelperTestBase.Model_GVL.GVL_T07;

                                    break;
                                }
                            case 8:     //Hydraulic Leakage - Fully Applied Position
                                {
                                    #region Case Param

                                    switch (strName.Trim())
                                    {

                                        case "ETimeScale":
                                            break;

                                        case "EVacuumScale":
                                            break;

                                        case "EPressureScale":
                                            break;

                                        case "ETravelScale":
                                            break;

                                        case "ETestingTime": //Tempo de teste
                                            HelperTestBase.Model_GVL.GVL_T08.rTempoTeste = dblValue;
                                            //_helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_dwTempoTeste_T08_LW }, dblValue);
                                            break;

                                        case "EStabTime": //Tempo de estabilizacao
                                            HelperTestBase.Model_GVL.GVL_T08.rTempoEstabilizacao = dblValue;
                                            //_helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_dwTempoEstabilizacao_T08_LW }, dblValue);
                                            break;

                                        case "EForcePercentEout": //Forca relativa a Eout (%)
                                            HelperTestBase.Model_GVL.GVL_T08.rForcaMaximaRelativa = dblValue;
                                            //_helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_dwForcaMaximaRelativa_T08_LW }, dblValue);
                                            break;

                                        case "CBUseSingleInputForce": //Utilizar valor absoluto de forca
                                            break;

                                        case "EInputForce": //Forca Absoluta
                                            HelperTestBase.Model_GVL.GVL_T08.rForcaMaximaAbsoluta_N = dblValue;
                                            //_helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_dwForcaMaximaAbsoluta_T08_LW }, dblValue);
                                            break;

                                        default:
                                            break;
                                    }

                                    #endregion

                                    HelperTestBase.Model_GVL.helperTestBase_ModelGVL_Test = HelperTestBase.Model_GVL.GVL_T08;

                                    break;
                                }
                            case 9:     //Hydraulic Leakage - At Low Pressure
                                {
                                    #region Case Param

                                    switch (strName.Trim())
                                    {

                                        case "ETimeScale":
                                            break;

                                        case "EVacuumScale":
                                            break;

                                        case "EPressureScale":
                                            break;

                                        case "ETravelScale":
                                            break;

                                        case "EPressurePC": //Target pressao
                                            HelperTestBase.Model_GVL.GVL_T09.rPressaoTeste_Bar = dblValue;
                                            //_helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_dwPressaoTeste_T09_LW }, dblValue);
                                            break;

                                        case "ETestingTime": //Tempo de teste
                                            HelperTestBase.Model_GVL.GVL_T09.rTempoTeste = dblValue;
                                            //_helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_dwTempoTeste_T09_LW }, dblValue);
                                            break;

                                        case "EStabTime": //Tempo de estabilizacao
                                            HelperTestBase.Model_GVL.GVL_T09.rTempoEstabilizacao = dblValue;
                                            //_helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_dwTempoEstabilizacao_T09_LW }, dblValue);
                                            break;

                                        default:
                                            break;
                                    }

                                    #endregion

                                    HelperTestBase.Model_GVL.helperTestBase_ModelGVL_Test = HelperTestBase.Model_GVL.GVL_T09;

                                    break;
                                }
                            case 10:    //Hydraulic Leakage - At High Pressure
                                {
                                    #region Case Param

                                    switch (strName.Trim())
                                    {

                                        case "ETimeScale":
                                            break;

                                        case "EVacuumScale":
                                            break;

                                        case "EPressureScale":
                                            break;

                                        case "ETravelScale":
                                            break;

                                        case "ETargetPressurePC": //Target pressao
                                            HelperTestBase.Model_GVL.GVL_T10.rPressaoTeste_Bar = dblValue;
                                            //_helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_dwPressaoTeste_T10_LW }, dblValue);
                                            break;

                                        case "ETestingTime": //Tempo de teste
                                            HelperTestBase.Model_GVL.GVL_T10.rTempoTeste = dblValue;
                                            //_helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_dwTempoTeste_T10_LW }, dblValue);
                                            break;

                                        case "EStabTime": //Tempo de estabilizacao
                                            HelperTestBase.Model_GVL.GVL_T10.rTempoEstabilizacao = dblValue;
                                            //_helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_dwTempoEstabilizacao_T10_LW }, dblValue);
                                            break;

                                        default:
                                            break;
                                    }

                                    #endregion

                                    HelperTestBase.Model_GVL.helperTestBase_ModelGVL_Test = HelperTestBase.Model_GVL.GVL_T10;

                                    break;
                                }
                            case 11:    //Adjustment - Actuation Slow
                                {
                                    #region Case Param

                                    switch (strName.Trim())
                                    {


                                        case "EScaleTime":
                                            break;

                                        case "EScaleForce":
                                            break;

                                        default:
                                            break;
                                    }

                                    #endregion

                                    HelperTestBase.Model_GVL.helperTestBase_ModelGVL_Test = HelperTestBase.Model_GVL.GVL_T11;
                                    break;
                                }
                            case 12:    //Adjustment - Actuation Fast
                                {
                                    #region Case Param

                                    switch (strName.Trim())
                                    {

                                        case "EScaleTime":
                                            break;

                                        case "EScaleForce":
                                            break;

                                        case "EActuationTimeFrom": //Forca para iniciar calculo tempo atuacao
                                            HelperTestBase.Model_GVL.GVL_T12.rForcaInicialTempoAtuacao_N = dblValue;
                                            break;

                                        case "EActuationTimeTo": //Forca final para tempo de atuacao (% fmax do teste)
                                            HelperTestBase.Model_GVL.GVL_T12.rForcaFinalTempoAtuacao = dblValue;
                                            break;

                                        case "EReleaseTimeTo": //% forca no retorno para calcuo do tempo de retorno
                                            HelperTestBase.Model_GVL.GVL_T12.rForcaRetornoTempoAtuacao = dblValue;
                                            break;

                                        default:
                                            break;
                                    }

                                    #endregion

                                    HelperTestBase.Model_GVL.helperTestBase_ModelGVL_Test = HelperTestBase.Model_GVL.GVL_T12;

                                    break;
                                }
                            case 13:    //Check Sensors - Pressure Difference
                                {
                                    #region Case Param

                                    switch (strName.Trim())
                                    {

                                        case "EIForceScale":
                                            break;

                                        case "EOPressScale":
                                            break;

                                        case "EDeltaAtPressure1": //Ponto verificacao dif pressao 1
                                            HelperTestBase.Model_GVL.GVL_T13.rSetPointDiferencaPressaoP1Avanco_Bar = dblValue;
                                            break;

                                        case "EDeltaAtPressure2": //Ponto verificacao dif pressao 2
                                            HelperTestBase.Model_GVL.GVL_T13.rSetPointDiferencaPressaoP2Avanco_Bar = dblValue;
                                            break;

                                        case "EDeltaAtPressure3": //Ponto verificacao dif pressao 3
                                            HelperTestBase.Model_GVL.GVL_T13.rSetPointDiferencaPressaoP3Retorno_Bar = dblValue;
                                            break;

                                        case "EDeltaAtPressure4": //Ponto verificacao dif pressao 4
                                            HelperTestBase.Model_GVL.GVL_T13.rSetPointDiferencaPressaoP4Retorno_Bar = dblValue;
                                            break;

                                        default:
                                            break;
                                    }

                                    #endregion

                                    HelperTestBase.Model_GVL.helperTestBase_ModelGVL_Test = HelperTestBase.Model_GVL.GVL_T13;

                                    break;
                                }
                            case 14:    //Check Sensors - Input/Output Travel
                                {

                                    #region Case Param                                   

                                    switch (strName.Trim())
                                    {

                                        case "EITravelScale":
                                            break;

                                        case "EOTravelScale":
                                            break;

                                        case "EEmptyTravel": //Curso Morto
                                            HelperTestBase.Model_GVL.GVL_T14.rCursoMortoEmDeslocamentoSaida_mm = dblValue;
                                            break;

                                        default:
                                            break;
                                    }

                                    #endregion

                                    HelperTestBase.Model_GVL.helperTestBase_ModelGVL_Test = HelperTestBase.Model_GVL.GVL_T14;

                                    break;
                                }
                            case 15:    //Adjustment - Input Travel VS Input Force
                                {

                                    #region Case Param                                   

                                    switch (strName.Trim())
                                    {

                                        case "EScaleTravel":
                                            break;

                                        case "EScaleForce":
                                            break;

                                        default:
                                            break;
                                    }

                                    #endregion

                                    HelperTestBase.Model_GVL.helperTestBase_ModelGVL_Test = HelperTestBase.Model_GVL.GVL_T15;

                                    break;
                                }
                            case 16:    //Adjustment - Hose Consumer
                                {
                                    #region Case Param

                                    switch (strName.Trim())
                                    {

                                        case "EScaleTravel":
                                            break;

                                        case "EScalePressure":
                                            break;

                                        case "ETestpressure": //Pressao Teste
                                            HelperTestBase.Model_GVL.GVL_T16.rDeslocamentoNaPressao_Bar = dblValue;
                                            break;

                                        default:
                                            break;
                                    }

                                    #endregion

                                    HelperTestBase.Model_GVL.helperTestBase_ModelGVL_Test = HelperTestBase.Model_GVL.GVL_T16;

                                    break;
                                }
                            case 17:    //Lost Travel ACU - Hydraulic
                                {
                                    #region Case Param

                                    switch (strName.Trim())
                                    {

                                        case "ETravelScale":
                                            break;

                                        case "EPressScale":
                                            break;

                                        case "ETravelEmpty": //Curso Morto
                                            HelperTestBase.Model_GVL.GVL_T17.rCursoMortoNaPressao_Bar = dblValue;
                                            break;

                                        case "ETravel1": //Curso em X pressao
                                            HelperTestBase.Model_GVL.GVL_T17.rCursoNaPressao1_Bar = dblValue;
                                            break;

                                        case "ETravel2": //Curso em X pressao
                                            HelperTestBase.Model_GVL.GVL_T17.rCursoNaPressao2_Bar = dblValue;
                                            break;

                                        default:
                                            break;
                                    }

                                    #endregion

                                    HelperTestBase.Model_GVL.helperTestBase_ModelGVL_Test = HelperTestBase.Model_GVL.GVL_T17;

                                    break;
                                }
                            case 18:    //Lost Travel ACU - Hydraulic Electrical Actuation
                                {
                                    #region Case Param


                                    switch (strName.Trim())
                                    {

                                        case "ETravelScale":
                                            break;

                                        case "EPressScale":
                                            break;

                                        case "ETargetForce": //Target Forca EDrive - Utilizar campo max Force
                                            //utilizar campo de parametro padrao Forca Maxima
                                            break;

                                        case "ETravelEmpty": //Forca para iniciar calculo tempo atuacao
                                            HelperTestBase.Model_GVL.GVL_T18.rCursoNaPressao1_Bar = dblValue;
                                            break;

                                        case "ETravel1": //Curso em X pressao
                                            HelperTestBase.Model_GVL.GVL_T18.rCursoNaPressao1_Bar = dblValue;
                                            break;

                                        case "ETravel2": //Curso em X pressao
                                            HelperTestBase.Model_GVL.GVL_T18.rCursoNaPressao2_Bar = dblValue;
                                            break;

                                        case "ETravel3": //Curso em X pressao
                                            HelperTestBase.Model_GVL.GVL_T18.rCursoNaPressao2_Bar = dblValue;
                                            break;

                                        case "ETravel4": //Curso em X pressao
                                            HelperTestBase.Model_GVL.GVL_T18.rCursoNaPressao2_Bar = dblValue;
                                            break;

                                        default:
                                            break;
                                    }

                                    #endregion

                                    HelperTestBase.Model_GVL.helperTestBase_ModelGVL_Test = HelperTestBase.Model_GVL.GVL_T18;

                                    break;
                                }
                            case 19:    //Lost Travel ACU - Pneumatic Primary
                                {
                                    #region Case Param


                                    switch (strName.Trim())
                                    {

                                        case "ETravelScale":
                                            break;

                                        case "EPressureScale":
                                            break;

                                        case "EBlowTime": //Tempo sopro Blow Out
                                            HelperTestBase.Model_GVL.GVL_T19.rTempoSopro = dblValue;
                                            //_helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_dwTempoSopro_T19_LW }, dblValue);
                                            break;

                                        case "EActTravel": //Deslocamento teste
                                            HelperTestBase.Model_GVL.GVL_T19.rDeslocamentoTeste = dblValue;
                                            //_helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_dwDeslocamentoTeste_T19_LW}, dblValue);
                                            break;

                                        case "EPressureClosed": //Pressao desejada com sistema fechado
                                            HelperTestBase.Model_GVL.GVL_T19.rPressaoSistemaFechado_Bar = dblValue;
                                            //_helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_dwPressaoSistemaFechado_T19_LW}, dblValue);
                                            break;

                                        case "EPressureOpened": //Pressao desejada com sistema aberto
                                            HelperTestBase.Model_GVL.GVL_T19.rPressaoSistemaAberto_Bar = dblValue;
                                            //_helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_dwPressaoSistemaAberto_T19_LW}, dblValue);
                                            break;

                                        case "ETravelBeforeEndPressure": //Deslocamento na pressao
                                            HelperTestBase.Model_GVL.GVL_T19.rDeslocamentoNaPressao_Bar = dblValue;
                                            break;


                                        default:
                                            break;
                                    }

                                    #endregion

                                    HelperTestBase.Model_GVL.helperTestBase_ModelGVL_Test = HelperTestBase.Model_GVL.GVL_T19;

                                    break;
                                }
                            case 20:    //Lost Travel ACU - Pneumatic Secondary
                                {
                                    #region Case Param

                                    switch (strName.Trim())
                                    {

                                        case "ETravelScale":
                                            break;

                                        case "EPressureScale":
                                            break;

                                        case "EBlowTime": //Tempo sopro Blow Out
                                            HelperTestBase.Model_GVL.GVL_T20.rTempoSopro = dblValue;
                                            //_helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_dwTempoSopro_T20_LW }, dblValue);
                                            break;

                                        case "EActTravel": //Deslocamento teste
                                            HelperTestBase.Model_GVL.GVL_T20.rDeslocamentoTeste = dblValue;
                                            //_helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_dwDeslocamentoTeste_T20_LW}, dblValue);
                                            break;

                                        case "EPressureClosed": //Pressao desejada com sistema fechado
                                            HelperTestBase.Model_GVL.GVL_T20.rPressaoSistemaFechado_Bar = dblValue;
                                            //_helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_dwPressaoSistemaFechado_T20_LW}, dblValue);
                                            break;

                                        case "EPressureOpened": //Pressao desejada com sistema aberto
                                            HelperTestBase.Model_GVL.GVL_T20.rPressaoSistemaAberto_Bar = dblValue;
                                            //_helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_dwPressaoSistemaAberto_T20_LW}, dblValue);
                                            break;

                                        case "ETravelBeforeEndPressure": //Deslocamento na pressao
                                            HelperTestBase.Model_GVL.GVL_T20.rDeslocamentoNaPressao_Bar = dblValue;
                                            break;

                                        default:
                                            break;
                                    }

                                    #endregion

                                    HelperTestBase.Model_GVL.helperTestBase_ModelGVL_Test = HelperTestBase.Model_GVL.GVL_T20;

                                    break;
                                }
                            case 21:    //Pedal Feeling Characteristics
                                {
                                    #region Case Param

                                    switch (strName.Trim())
                                    {

                                        case "ETravelScaleLo":
                                            break;

                                        case "ETravelScaleHi":
                                            break;

                                        case "EPressScale":
                                            break;

                                        case "EForceScale":
                                            break;

                                        case "ETravelEmpty": //Curso morto
                                            HelperTestBase.Model_GVL.GVL_T21.rPressaoCutIn_Bar = dblValue;
                                            break;

                                        default:
                                            break;
                                    }

                                    #endregion

                                    HelperTestBase.Model_GVL.helperTestBase_ModelGVL_Test = HelperTestBase.Model_GVL.GVL_T21;

                                    break;
                                }
                            case 22:    //Actuation / Release - Mechanical Actuation
                                {
                                    #region Case Param

                                    switch (strName.Trim())
                                    {

                                        case "ETimeScale":
                                            break;

                                        case "EForceScale":
                                            break;

                                        case "EPressureScale":
                                            break;

                                        case "ETravelScale":
                                            break;

                                        case "EActTimeFrom": //
                                            //HelperTestBase.Model_GVL.GVL_T22. = dblValue;
                                            break;

                                        case "EActTimeTo": //
                                            //HelperTestBase.Model_GVL.GVL_T22. = dblValue;
                                            break;

                                        case "CBMaxPress1": //
                                                            //HelperTestBase.Model_GVL.GVL_T22. = dblValue;
                                            break;
                                        case "CBOutPress1": //
                                            //HelperTestBase.Model_GVL.GVL_T22. = dblValue;
                                            break;

                                        case "CBHelpPress1": //
                                            //HelperTestBase.Model_GVL.GVL_T22. = dblValue;
                                            break;

                                        case "CBMaxPress2": //
                                                            //HelperTestBase.Model_GVL.GVL_T22. = dblValue;
                                            break;
                                        case "CBOutPress2": //
                                            //HelperTestBase.Model_GVL.GVL_T22. = dblValue;
                                            break;

                                        case "CBHelpPress2": //
                                            //HelperTestBase.Model_GVL.GVL_T22. = dblValue;
                                            break;

                                        case "ERelTimeToTravelLeft": //
                                                                     //HelperTestBase.Model_GVL.GVL_T22. = dblValue;
                                            break;

                                        case "ETravelAtPOut": //
                                                              //HelperTestBase.Model_GVL.GVL_T22. = dblValue;
                                            break;
                                        case "EPressGradAt1": //
                                                              //HelperTestBase.Model_GVL.GVL_T22. = dblValue;
                                            break;
                                        case "EPressGradAt2": //
                                                              //HelperTestBase.Model_GVL.GVL_T22. = dblValue;
                                            break;

                                        default:
                                            break;
                                    }

                                    #endregion

                                    HelperTestBase.Model_GVL.helperTestBase_ModelGVL_Test = HelperTestBase.Model_GVL.GVL_T22;

                                    break;
                                }
                            case 23:    //Breather Hole / Central Valve open
                                {
                                    #region Case Param

                                    switch (strName.Trim())
                                    {

                                        case "CBPerformPreActuation":
                                            break;

                                        case "EHydrFillPressureMin": //Tempo sopro Blow Out
                                            HelperTestBase.Model_GVL.GVL_T23.rPressaoHidraulicaMin_Bar = dblValue;
                                            //_helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_dwPressaoHidraulicaMin_T23_LW }, dblValue);
                                            break;

                                        case "EHydrFillPressureMax": //Deslocamento teste
                                            HelperTestBase.Model_GVL.GVL_T23.rPressaoHidraulicaMax_Bar = dblValue;
                                            //_helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_dwPressaoHidraulicaMax_T23_LW }, dblValue);
                                            break;

                                        default:
                                            break;
                                    }

                                    #endregion

                                    HelperTestBase.Model_GVL.helperTestBase_ModelGVL_Test = HelperTestBase.Model_GVL.GVL_T23;

                                    break;
                                }
                            case 24:    //Efficiency
                                {
                                    #region Case Param

                                    switch (strName.Trim())
                                    {
                                        case "CBShowPressureForce":
                                            break;

                                        case "CBShowPressureTimeSlow":
                                            break;

                                        case "CBShowPressureTimeFast":
                                            break;

                                        case "EForceScale":
                                            break;

                                        case "EPressureScale":
                                            break;

                                        case "EPause": //Intervalo
                                            HelperTestBase.Model_GVL.GVL_T24.rIntervalo = dblValue;
                                            //_helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_dwIntervalo_T24_LW }, dblValue);
                                            break;

                                        case "EFastMaxForce": //Forca Maxima modo rapido
                                            HelperTestBase.Model_GVL.GVL_T24.rForcaMaximaModoRapido = dblValue;
                                            //_helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_dwForcaMaximaModoRapido_T24_LW }, dblValue);
                                            break;

                                        case "EFastGradient": //Gradiente abertura valvula - utilizar o parametro Geral Gradiente Pressao (%)
                                            //HelperTestBase.Model_GVL.GVL_T24.rGradientePressaoFast = dblValue;

                                            break;
                                        case "EPressGradAt1": //Ref Calculo Gradiente Pressao
                                            HelperTestBase.Model_GVL.GVL_T24.rInicioGradientePressao_Bar = dblValue;

                                            break;
                                        case "EPressGradAt2": //Ref Calculo Gradiente Pressao
                                            HelperTestBase.Model_GVL.GVL_T24.rFimGradientePressao_Bar = dblValue;

                                            break;
                                        case "EEfficiencyAtForce": //Eficiencia em .. 
                                            HelperTestBase.Model_GVL.GVL_T24.rEficienciaNaForca_N = dblValue;
                                            break;
                                        default:
                                            break;
                                    }

                                    #endregion

                                    HelperTestBase.Model_GVL.helperTestBase_ModelGVL_Test = HelperTestBase.Model_GVL.GVL_T24;

                                    break;
                                }
                            case 25:    //Force Diagrams - Force/Pressure Dual Ratio
                                {
                                    #region Case Param

                                    switch (strName.Trim())
                                    {
                                        case "EForceScale":
                                            break;

                                        case "EPressureScale":
                                            break;

                                        case "EP1AtForce": //Pressure at Force(E1)
                                            //HelperTestBase.Model_GVL.GVL_T25. = dblValue;
                                            break;

                                        case "EP2AtForce": //Pressure at Force(E2)  
                                            //HelperTestBase.Model_GVL.GVL_T25. = dblValue;
                                            break;

                                        case "EP3AtForce": //Pressure at Force(P1)
                                            //HelperTestBase.Model_GVL.GVL_T25. = dblValue;
                                            break;

                                        case "EP4AtForce": //Pressure at Force(P2)
                                            //HelperTestBase.Model_GVL.GVL_T25. = dblValue;
                                            break;

                                        case "EMeasurePointP7": //Pressure at Force(E6) =
                                            //HelperTestBase.Model_GVL.GVL_T25. = dblValue;
                                            break;

                                        case "EPistonTravelAtPressure": //Travel at Pressure = 
                                            //HelperTestBase.Model_GVL.GVL_T25. = dblValue;
                                            break;

                                        case "EActuationForceAtPressure": //Actuation Force at Pressure = 
                                            //HelperTestBase.Model_GVL.GVL_T25. = dblValue;
                                            break;

                                        case "EReleaseForceMin": //Release Force min = 
                                            //HelperTestBase.Model_GVL.GVL_T25. = dblValue;
                                            break;

                                        case "EReleaseForceMax": //Release Force max = 
                                            //HelperTestBase.Model_GVL.GVL_T25. = dblValue;
                                            break;

                                        case "EHysteresisAtPressure": //Hysteresis at Pressure(%) = 
                                            //HelperTestBase.Model_GVL.GVL_T25. = dblValue;
                                            break;

                                        case "//EHysteresisAtPressure2": //Hysteresis at Pressure(bar) = 
                                            //HelperTestBase.Model_GVL.GVL_T25. = dblValue;
                                            break;

                                        case "ERelForceRemainAtTravel": //Release Force Remaining at = 
                                            //HelperTestBase.Model_GVL.GVL_T25. = dblValue;
                                            break;

                                        case "ETMCDiameterPC": //TMC Diameter PC = 
                                            //HelperTestBase.Model_GVL.GVL_T25.rDiametroCMD_mm = dblValue;
                                            break;

                                        case "ETMCDiameterSC": // TMC Diameter SC = 
                                            //HelperTestBase.Model_GVL.GVL_T25. = dblValue;
                                            break;

                                        case "EJumperNomGrad": //Jumper Gradient P1 = 
                                            //HelperTestBase.Model_GVL.GVL_T25. = dblValue;
                                            break;

                                        case "EJumperPosTolerance": //Jumper Gradient P2 = 
                                            //HelperTestBase.Model_GVL.GVL_T25. = dblValue;
                                            break;

                                        case "EJumperNegTolerance": //Jumper Gradient P2 = 
                                            //HelperTestBase.Model_GVL.GVL_T25. = dblValue;
                                            break;

                                        case "ESwitchPointNomGrad": //Jumper Gradient P2 = 
                                            //HelperTestBase.Model_GVL.GVL_T25. = dblValue;
                                            break;

                                        case "ESwitchPointPosTolerance": //Jumper Gradient P2 = 
                                            //HelperTestBase.Model_GVL.GVL_T25. = dblValue;
                                            break;

                                        case "ESwitchPointNegTolerance": //Jumper Gradient P2 = 
                                            //HelperTestBase.Model_GVL.GVL_T25. = dblValue;
                                            break;


                                        default:
                                            break;
                                    }

                                    #endregion

                                    HelperTestBase.Model_GVL.helperTestBase_ModelGVL_Test = HelperTestBase.Model_GVL.GVL_T25;

                                    break;
                                }
                            case 26:    //Force Diagrams - Force/Force Dual Ratio
                                {
                                    #region Case Param

                                    switch (strName.Trim())
                                    {
                                        case "EForceScaleI":
                                            break;

                                        case "EForceScaleO":
                                            break;

                                        case "EP1AtForce": //Pressure at Force(E1)
                                            //HelperTestBase.Model_GVL.GVL_T26. = dblValue;
                                            break;

                                        case "EP2AtForce": //Pressure at Force(E2)  
                                            //HelperTestBase.Model_GVL.GVL_T26. = dblValue;
                                            break;

                                        case "EP3AtForce": //Pressure at Force(P1)
                                            //HelperTestBase.Model_GVL.GVL_T26. = dblValue;
                                            break;

                                        case "EP4AtForce": //Pressure at Force(P2)
                                            //HelperTestBase.Model_GVL.GVL_T26. = dblValue;
                                            break;

                                        case "EMeasurePointP7": //Pressure at Force(E6) =
                                            //HelperTestBase.Model_GVL.GVL_T26. = dblValue;
                                            break;

                                        case "EActuationForceAtForce": //Actuation Force at Pressure = 
                                            //HelperTestBase.Model_GVL.GVL_T26. = dblValue;
                                            break;

                                        case "EReleaseForceMin": //Release Force min = 
                                            //HelperTestBase.Model_GVL.GVL_T26. = dblValue;
                                            break;

                                        case "EReleaseForceMax": //Release Force max = 
                                            //HelperTestBase.Model_GVL.GVL_T26. = dblValue;
                                            break;

                                        case "EHysteresisAtForce": //Hysteresis at Pressure(%) = 
                                            //HelperTestBase.Model_GVL.GVL_T26. = dblValue;
                                            break;

                                        case "EJumperNomGrad": //Jumper Gradient P1 = 
                                            //HelperTestBase.Model_GVL.GVL_T26. = dblValue;
                                            break;

                                        case "EJumperPosTolerance": //Jumper Gradient P2 = 
                                            //HelperTestBase.Model_GVL.GVL_T26. = dblValue;
                                            break;

                                        case "EJumperNegTolerance": //Jumper Gradient P2 = 
                                            //HelperTestBase.Model_GVL.GVL_T26. = dblValue;
                                            break;

                                        case "ESwitchPointNomGrad": //Jumper Gradient P2 = 
                                            //HelperTestBase.Model_GVL.GVL_T26. = dblValue;
                                            break;

                                        case "ESwitchPointPosTolerance": //Jumper Gradient P2 = 
                                            //HelperTestBase.Model_GVL.GVL_T26. = dblValue;
                                            break;

                                        case "ESwitchPointNegTolerance": //Jumper Gradient P2 = 
                                            //HelperTestBase.Model_GVL.GVL_T26. = dblValue;
                                            break;

                                        default:
                                            break;
                                    }

                                    #endregion

                                    HelperTestBase.Model_GVL.helperTestBase_ModelGVL_Test = HelperTestBase.Model_GVL.GVL_T26;

                                    break;
                                }
                            case 27:    //ADAM - Find Switching Point With TMC
                                {
                                    #region Case Param

                                    switch (strName.Trim())
                                    {
                                        case "CBForcePressDiagram":
                                            break;

                                        case "EForceScale":
                                            break;

                                        case "EPressScale":
                                            break;

                                        case "ETravelScale":
                                            break;

                                        case "EDiffTravelScale":
                                            break;

                                        case "ETimeScale":
                                            break;

                                        case "EBackwardGradient": //Vel. Retorno
                                            //HelperTestBase.Model_GVL.GVL_T27. = dblValue;
                                            break;

                                        case "EActuationGradient1": //Vel. Avanco 1
                                            //HelperTestBase.Model_GVL.GVL_T27. = dblValue;
                                            break;

                                        case "EActuationGradient2": //Vel. Avanco 2
                                            //HelperTestBase.Model_GVL.GVL_T27. = dblValue;
                                            break;

                                        case "EActuationGradient3": //Vel. Avanco 3
                                            //HelperTestBase.Model_GVL.GVL_T27. = dblValue;
                                            break;

                                        case "EActuationGradient4": //Vel. Avanco 4
                                            //HelperTestBase.Model_GVL.GVL_T27. = dblValue;
                                            break;

                                        case "EActuationGradient5": //Vel. Avanco 5
                                            //HelperTestBase.Model_GVL.GVL_T27. = dblValue;
                                            break;


                                        default:
                                            break;
                                    }

                                    #endregion

                                    HelperTestBase.Model_GVL.helperTestBase_ModelGVL_Test = HelperTestBase.Model_GVL.GVL_T27;

                                    break;
                                }
                            case 28:    //ADAM - Switching Point Without TMC
                                {
                                    #region Case Param

                                    switch (strName.Trim())
                                    {
                                        case "CBForcePressDiagram":
                                            break;

                                        case "EForceScale":
                                            break;

                                        case "EPressScale":
                                            break;

                                        case "ETravelScale":
                                            break;

                                        case "EDiffTravelScale":
                                            break;

                                        case "ETimeScale":
                                            break;

                                        case "EBackwardGradient": //Vel. Retorno
                                            //HelperTestBase.Model_GVL.GVL_T28. = dblValue;
                                            break;

                                        case "EActuationGradient1": //Vel. Avanco 1
                                            //HelperTestBase.Model_GVL.GVL_T28. = dblValue;
                                            break;

                                        case "EActuationGradient2": //Vel. Avanco 2
                                            //HelperTestBase.Model_GVL.GVL_T28. = dblValue;
                                            break;

                                        case "EActuationGradient3": //Vel. Avanco 3
                                            //HelperTestBase.Model_GVL.GVL_T28. = dblValue;
                                            break;

                                        case "EActuationGradient4": //Vel. Avanco 4
                                            //HelperTestBase.Model_GVL.GVL_T28. = dblValue;
                                            break;

                                        case "EActuationGradient5": //Vel. Avanco 5
                                            //HelperTestBase.Model_GVL.GVL_T28. = dblValue;
                                            break;


                                        default:
                                            break;
                                    }

                                    #endregion

                                    HelperTestBase.Model_GVL.helperTestBase_ModelGVL_Test = HelperTestBase.Model_GVL.GVL_T28;

                                    break;
                                }
                            case 29:    //Bleed
                                {
                                    #region Case Param

                                    switch (strName.Trim())
                                    {


                                        case "Actuations": //
                                            //HelperTestBase.Model_GVL.GVL_T29. = dblValue;
                                            //_helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_wNumeroAtuacoes_T29 }, dblValue);
                                            break;

                                        case "Repetitions": //
                                            //HelperTestBase.Model_GVL.GVL_T29. = dblValue;
                                            //_helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_wNumeroRepeticoes_T29 }, dblValue);
                                            break;

                                        case "PumpingTime": //
                                            //HelperTestBase.Model_GVL.GVL_T29. = dblValue;
                                            //_helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_dwTempoBombeamento_T29_LW }, dblValue);
                                            break;


                                        default:
                                            break;
                                    }

                                    #endregion

                                    HelperTestBase.Model_GVL.helperTestBase_ModelGVL_Test = HelperTestBase.Model_GVL.GVL_T28;

                                    break;
                                }

                            default:
                                break;
                        }
                    }
                }
                else
                {
                    var abc = 1;
                }
            }
        }
        public void TAB_ActuationParameters_WriteComEditGridEvalParameters(int iRowIndex, string strName, string strValue)
        {
            if (!string.IsNullOrEmpty(strValue))
            {
                double dblValue = 0;

                if (strValue.Equals("True") || strValue.Equals("False"))
                    dblValue = strValue.Equals("True") ? 1 : 0;
                else
                    dblValue = Convert.ToDouble(strValue.Replace(",", "."));

                switch (HelperApp.uiTesteSelecionado)
                {
                    case 5:     //Vaccum Leakage - Released Position
                        switch (iRowIndex)
                        {
                            case 3://TESTING TIME
                                HelperTestBase.Model_GVL.GVL_T05.rTempoTeste = dblValue;
                                _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_dwTempoTeste_T05_LW }, dblValue);
                                break;
                            case 4://VACUUM STABILIZATION TIME
                                HelperTestBase.Model_GVL.GVL_T05.rTempoEstabilizacao = dblValue;
                                _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_dwTempoEstabilizacao_T05_LW }, dblValue);
                                break;
                            default:
                                break;
                        }
                        break;
                    case 6:     //Vacuum Leakage - Fully Applied Position
                        switch (iRowIndex)
                        {
                            case 2: //TESTING TIME
                                HelperTestBase.Model_GVL.GVL_T06.rTempoTeste = dblValue;
                                _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_dwTempoTeste_T06_LW }, dblValue);
                                break;
                            case 3: //VACUUM STABILIZATION TIME
                                HelperTestBase.Model_GVL.GVL_T06.rTempoEstabilizacao = dblValue;
                                _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_dwTempoEstabilizacao_T06_LW }, dblValue);
                                break;
                            case 4: //PERCENT OF EOUT
                                HelperTestBase.Model_GVL.GVL_T06.rForcaMaximaRelativa = dblValue;
                                _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_dwForcaMaximaRelativa_T06_LW }, dblValue);
                                break;
                            case 6: //INPUT FORCE
                                HelperTestBase.Model_GVL.GVL_T06.rForcaMaximaAbsoluta_N = dblValue;
                                _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_dwForcaMaximaAbsoluta_T06_LW }, dblValue);
                                break;
                            default:
                                break;
                        }
                        break;
                    case 7:     //Vacuum Leakage - Lap Position
                        switch (iRowIndex)
                        {
                            case 3://TESTING TIME
                                HelperTestBase.Model_GVL.GVL_T07.rTempoTeste = dblValue;
                                _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_dwTempoTeste_T07_LW }, dblValue);
                                break;
                            case 4://VACUUM STABILIZATION TIME
                                HelperTestBase.Model_GVL.GVL_T07.rTempoEstabilizacao = dblValue;
                                _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_dwTempoEstabilizacao_T07_LW }, dblValue);
                                break;
                            case 5://RELATIVE INPUT FORCE 1
                                HelperTestBase.Model_GVL.GVL_T07.rForcaRelativaAvanco = dblValue;
                                _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_dwForcaRelativaAvanco_T07_LW }, dblValue);
                                break;
                            case 6: //RELATIVE INPUT FORCE 2
                                HelperTestBase.Model_GVL.GVL_T07.rForcaRelativaRetorno = dblValue;
                                _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_dwForcaRelativaRetorno_T07_LW }, dblValue);
                                break;
                            case 7: //RELATIVE INPUT FORCE 3
                                HelperTestBase.Model_GVL.GVL_T07.rForcaRelativaFinal = dblValue;
                                _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_dwForcaRelativaFinal_T07_LW }, dblValue);
                                break;
                            case 9: //SINGLE INPUT FORCE
                                HelperTestBase.Model_GVL.GVL_T07.rForcaMaxima = dblValue;
                                _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_dwForcaMaximaAbsoluta_T07_LW }, dblValue);
                                break;
                            case 10: //SINGLE INPUT FORCE (% EOUT)
                                HelperTestBase.Model_GVL.GVL_T07.rForcaMaximaAbsoluta_N = dblValue;
                                _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_dwForcaMaximaAbsoluta_T07_LW }, dblValue);
                                break;
                            default:
                                break;
                        }
                        break;
                    case 8:      //Hydraulic Leakage - Fully Applied Position
                        switch (iRowIndex)
                        {
                            case 5://TESTING TIME
                                HelperTestBase.Model_GVL.GVL_T08.rTempoTeste = dblValue;
                                _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_dwTempoTeste_T08_LW }, dblValue);
                                break;
                            case 6://STABILIZATION TIME
                                HelperTestBase.Model_GVL.GVL_T08.rTempoEstabilizacao = dblValue;
                                _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_dwTempoEstabilizacao_T08_LW }, dblValue);
                                break;
                            case 7: //PERCENT OF EOUT
                                HelperTestBase.Model_GVL.GVL_T07.rForcaMaximaRelativa = dblValue;
                                _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_dwForcaMaximaAbsoluta_T08_LW }, dblValue);
                                break;
                            case 9: //INPUT FORCE
                                HelperTestBase.Model_GVL.GVL_T07.rForcaRelativaRetorno = dblValue;
                                _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_dwForcaMaximaRelativa_T08_LW }, dblValue);
                                break;
                            default:
                                break;
                        }
                        break;
                    case 9:     //Hydraulic Leakage - At Low Pressure
                        switch (iRowIndex)
                        {
                            case 5: //PRESSURE PC
                                HelperTestBase.Model_GVL.GVL_T09.rPressaoTeste_Bar = dblValue;
                                _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_dwPressaoTeste_T09_LW }, dblValue);
                                break;
                            case 6://TESTING TIME
                                HelperTestBase.Model_GVL.GVL_T09.rTempoTeste = dblValue;
                                _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_dwTempoTeste_T09_LW }, dblValue);
                                break;
                            case 7://STABILIZATION TIME
                                HelperTestBase.Model_GVL.GVL_T09.rTempoEstabilizacao = dblValue;
                                _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_dwTempoEstabilizacao_T09_LW }, dblValue);
                                break;
                            default:
                                break;
                        }
                        break;
                    case 10:    //Hydraulic Leakage - At High Pressure
                        switch (iRowIndex)
                        {
                            case 5: //TARGET PRESSURE PC
                                HelperTestBase.Model_GVL.GVL_T10.rPressaoTeste_Bar = dblValue;
                                _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_dwPressaoTeste_T10_LW }, dblValue);
                                break;
                            case 6://TESTING TIME
                                HelperTestBase.Model_GVL.GVL_T10.rTempoTeste = dblValue;
                                _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_dwTempoTeste_T10_LW }, dblValue);
                                break;
                            case 7://STABILIZATION TIME
                                HelperTestBase.Model_GVL.GVL_T10.rTempoEstabilizacao = dblValue;
                                _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_dwTempoEstabilizacao_T10_LW }, dblValue);
                                break;
                            default:
                                break;
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        #endregion

        #endregion

        #endregion

        #region TAB - CPX Visu
        private void TAB_CPXVisu_Create()
        {
            try
            {
                var tabVisu = TAB_Main.TabPages["tab_CPX_Visu"];

                if (tabVisu == null)
                    TAB_CPXVisu_SetData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }
        private void TAB_CPXVisu_SetData()
        {
            try
            {
                string urlVisuPMX = !_helperApp.AppUseSimulateLocal ? _helperCom.Modbus_ServerVisuUrl.ToString() : "http://www.google.com.br";

                OpenURLInBrowser(urlVisuPMX);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        #endregion

        #endregion

        #region TIMERS
        private void timerDateTime_Tick(object sender, EventArgs e)
        {
            mbtn_BClock.Text = DateTime.Now.ToString("dd/MM/yyyy - HH:mm:ss", CultureInfo.InvariantCulture);
        }
        private void timerHBM_Tick(object sender, EventArgs e)
        {
            try
            {
                lst_MemoEventLog.Items.Clear();

                if (!_helperApp.AppUseSimulateLocal)
                    if (ComHBM.HBM_UseEnableCom)
                    {
                        if (timerHBM.Enabled)
                        {
                            LOG_TestSequence(" TIMER HBM : ");

                            HBM_SaveAquisitionTxtData();
                        }
                    }
            }
            catch (Exception ex)
            {
                var err = ex.Message;
            }
        }
        private void timerMODBUS_Tick(object sender, EventArgs e)
        {
            if (!_helperApp.AppUseSimulateLocal)
            {
                if (ComModbusTCP.connected)
                {
                    //_helperMODBUS.ReadInpReg();

                    //Read Continuos
                    _helperMODBUS.HelperMODBUS_ReadInputReg();

                    //leitura tela analogicas header
                    MODBUS_DisplayMainDataParameters();

                    //leitura tela geral
                    MODBUS_DisplayScreenStatusData();

                    //Write Continuos HandShake
                    _helperMODBUS.HelperMODBUS_WriteHandShakeContinous();
                }
            }
        }

        #endregion

        #region TEST PROCESS

        #region START SEQUENCE PROCESS
        public void TEST_Start_Command()
        {
            try
            {
                if (HelperMODBUS.CS_wPasso != 100)
                {
                    MessageBox.Show("Step Test not permited!", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (HelperTestBase.eExamType == eEXAMTYPE.ET_NONE || HelperApp.uiTesteSelecionado == 0)
                    MessageBox.Show("No test selected!", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    if (!HelperTestBase.currentProjectTest.is_Created)
                    {
                        if (DialogResult.No == MessageBox.Show("\tPROJECT NOT CREATED!" + "\n\n\n" + "Do you want following without create a PROJECT TEST ? ", _helperApp.appMsg_Name, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))
                            return;
                    }

                    string strMsg = String.Concat("\tSTART TEST PROCESS !", "\n\n\n", "\tDo you want following with Test ? ", "\n\n\n", $"\t{EnumExtensionMethods.GetDescriptionEXAMTYPE(HelperTestBase.eExamType)}");

                    if (DialogResult.No == MessageBox.Show(strMsg, _helperApp.appMsg_Name, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))
                        return;
                    else
                        LOG_TestSequence("BTN START");

                    #region Start Command

                    if (_helperApp.AppUseSimulateLocal)
                    {
                        MessageBox.Show("AppUseSimulateLocal", _helperApp.appMsg_Error, MessageBoxButtons.OK, MessageBoxIcon.Information);

                        //IWin32Window parent

                        //MessageBox.Show(parent, message, title, MessageBoxButtons.OK,
                        //MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign & MessageBoxOptions.RtlReading);

                        if (false)
                        {
                            if (!bgWorker.IsBusy)
                            {
                                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;

                                //bgWorker.RunWorkerAsync();

                                //Create File Acquisition
                                File.AppendAllText(_prjTestFilename, sbDataFile.ToString());

                                if (_helperApp.CheckFileExists(_prjTestFilename))
                                {
                                    HelperTestBase.currentProjectTest.is_Created = true;
                                    LOG_TestSequence("SIMULATE MODE OK");
                                }
                                else
                                    LOG_TestSequence("SIMULATE MODE NOK");

                            }

                            mbtn_BStart.Enabled = false;
                            mbtn_BStop.Enabled = true;
                        }
                    }
                    else
                    {
                        LOG_Clear();

                        HBM_ClearBufferAquisitionData();

                        if (!_helperHBM.DeviceConnected)
                            if (ComHBM.HBM_UseEnableCom)
                                HBM_Initialize();

                        //if (TEST_StartSequence())
                        //{
                        LOG_TestSequence(String.Concat(" TEST Start Sequence - ", HelperApp.uiTesteSelecionado, " Type - ", EnumExtensionMethods.GetEnumValue<eEXAMTYPE>(HelperApp.uiTesteSelecionado).ToString()));

                        _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_wCicloFinalizado }, 0);

                        _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_wConfirmacaoCicloFinalizado }, 0);

                        _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_wTesteSelecionado }, HelperApp.uiTesteSelecionado);

                        _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_wPartidaGeral }, 1);

                        _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_wGravacaoFinalizada }, 1);

                        //_helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_wPartidaGeral }, 0);

                        if (!HelperMODBUS.CS_wModoAuto)
                            _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_wModoAuto }, 1);

                        LOG_TestSequence("CS_wPartidaGeral OK");
                        //}
                        //else
                        //    MessageBox.Show("TEST Start Sequence Failed!", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    #endregion
                }
            }
            catch (Exception ex)
            {
                var err = string.Concat("Exception : ", ex.Message);
                MessageBox.Show(err, _helperApp.appMsg_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public bool TEST_Start_Sequence()
        {
            //// abort here, if nothing to do...
            if (HelperTestBase.eExamType == eEXAMTYPE.ET_NONE || HelperApp.uiTesteSelecionado == 0)
            {
                MessageBox.Show("No test selected!", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else
            {
                LOG_TestSequence("TESTE SEQUENCE START");

                //// abort here, if any precondition violated...
                if (!TEST_Start_ValidatePreCondition())
                    return false;

                if (mchk_tabActParam_GenSettings_CBStartFromSelection.Checked)
                    mcbo_tabActParam_GenSettings_CoBSelectTest.SelectedIndex = 0;
                else
                    mchk_tabActParam_GenSettings_CBStartFromSelection.Checked = false;


                //// sepcial conditions if to run these tests with the eletric motor (normally run with pneumatic slow)
                switch (HelperTestBase.eExamType)
                {
                    case eEXAMTYPE.ET_ForceDiagrams_ForceForce_WithVacuum:
                    case eEXAMTYPE.ET_ForceDiagrams_ForceForce_DualRatio:
                    case eEXAMTYPE.ET_ForceDiagrams_ForceForce_WithoutVacuum:
                    case eEXAMTYPE.ET_ForceDiagrams_ForcePressure_DualRatio:
                    case eEXAMTYPE.ET_ForceDiagrams_ForcePressure_WithoutVacuum:
                    case eEXAMTYPE.ET_ForceDiagrams_ForcePressure_WithVacuum:
                        //if (mcbo_tabActParam_GenSettings_CoBActuationMode.SelectedIndex == 2 && (pb_connector.FastMotorActAllowed1() && pb_connector.FastMotorActAllowed2()))
                        //{
                        //    MessageBox.Show("The motor-bow has to be assembled to run this type of test with the electric motor!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //    return;
                        //}
                        break;
                }

                HelperTestBase.currentProjectTest.TestingDate = _strTimeStamp;

                #region Escrita Modbus Parametros comuns

                _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_wTesteSelecionado }, HelperApp.uiTesteSelecionado);

                //============================================================================================================================

                // iModo: INT;  1-Pneumatico Lento 2-Pneumatico Rapido 3- E-Drive
                // _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_wModo }, (int)HelperTestBase.ETestActuationType);
                _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_wModo }, HelperApp.uiTesteSelecionado);
                //Forca Maxima do teste- rForcaMaxima_N: REAL; 
                // (2200 N) Limite de forca de entrada, limitado a 10KN, mas podemos limitar a 5KN
                _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_dwForcaMaxima_N_LW }, HelperTestBase.MaxForce);

                switch (HelperTestBase.ETestActuationType)
                {
                    case E_TestActuationType.PneumaticSlow:
                        //Pneumatic Slow - rGradienteForca_Ns: REAL; 
                        //(200 Ns) Limitado a 10KN, mas deve ser limitado a foca x pressao do atuador pneumático
                        _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_dwGradienteForca_Ns_LW }, HelperTestBase.ForceGradient);
                        break;
                    case E_TestActuationType.PneumaticFast:
                        //Pneumatic Fast - rGradienteForca: REAL; //0-100%
                        _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_dwGradienteForca_LW }, HelperTestBase.ForceGradient);
                        break;
                    case E_TestActuationType.E_Motor:
                        //E-Motor -rVelocidadeAtuacao_mm_s: REAL; 
                        //(Velocidade de atuação do eixo elético em mm/s (limitar a 200mm/s)
                        _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_dwVelocidadeAtuacao_mm_s_LW }, HelperTestBase.ForceGradient);
                        break;
                    default:
                        break;
                }

                //Controle Vacuo	- rVacuoNominal_Bar: REAL;
                //Vacuo Nominal do teste, limitado a -1;
                _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_dwVacuoNominal_Bar_LW }, HelperTestBase.Vacuum);

                //Trava do Pistao - bHabilitaTravaPistao: BOOL;
                _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_wHabilitaTravaPistao }, Convert.ToDouble(HelperTestBase.chkPistonLock));

                //Bypass da Tara  - wBypassTara: WORD;
                //Bit0 - rDeslocamentoDiferencial_mm_Lin
                //Bit1 - rForcaEntradaBooster_N_Lin
                //Bit2 - rForcaSaidaBooster_N_Lin
                //Bit3 - rDeslocamentoSaidaBooster_mm_Lin
                //Bit4 - rDeslocamentoEntradaBooster_mm_Lin
                //Bit5 - rPressaoCS_Bar_Lin
                //Bit6 - rPressaoCP_Bar_Lin
                //Bit7 - rPressaoBubbleTest_Bar_Lin
                //Bit8 - rPressaoHidraulica_Bar_Lin
                // _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_wTaraSensores}, 0);

                //Consumidores (Hose Consumers)
                //iTipoConsumidores: INT; //0=OFF 1=Original 2=Hose
                _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_wTipoConsumidores }, Convert.ToDouble(HelperTestBase.Model_GVL.GVL_Parametros.iTipoConsumidores));
                //bConsumidorOriginalCP: BOOL;
                _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_wConsumidorOriginalCP }, Convert.ToDouble(HelperTestBase.Model_GVL.GVL_Parametros.bConsumidorOriginalCP));
                //bConsumidorOriginalCS: BOOL;
                _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_wConsumidorOriginalCS }, Convert.ToDouble(HelperTestBase.Model_GVL.GVL_Parametros.bConsumidorOriginalCS));
                //bMangueirasConsumoCP: BOOL;
                _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_wMangueirasConsumoCP }, Convert.ToDouble(HelperTestBase.Model_GVL.GVL_Parametros.bMangueirasConsumoCP));
                //bMangueirasConsumoCS: BOOL;
                _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_wMangueirasConsumoCS }, Convert.ToDouble(HelperTestBase.Model_GVL.GVL_Parametros.bMangueirasConsumoCP));
                //bLiga1MangueiraCP: BOOL;
                _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_wLiga1MangueiraCP }, Convert.ToDouble(HelperTestBase.Model_GVL.GVL_Parametros.bLiga1MangueiraCP));
                //bLiga2MangueirasCP: BOOL;
                _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_wLiga2MangueirasCP }, Convert.ToDouble(HelperTestBase.Model_GVL.GVL_Parametros.bLiga2MangueirasCP));
                //bLiga4MangueirasCP: BOOL;
                _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_wLiga4MangueirasCP }, Convert.ToDouble(HelperTestBase.Model_GVL.GVL_Parametros.bLiga4MangueirasCP));
                //bLiga8mangueirasCP: BOOL;
                _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_wLiga8MangueirasCP }, Convert.ToDouble(HelperTestBase.Model_GVL.GVL_Parametros.bLiga8MangueirasCP));
                //bLiga10MangueirasCP: BOOL;
                _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_wLiga10MangueirasCP }, Convert.ToDouble(HelperTestBase.Model_GVL.GVL_Parametros.bLiga10MangueirasCP));
                //bLiga17MangueirasCP: BOOL;
                _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_wLiga17MangueirasCP }, Convert.ToDouble(HelperTestBase.Model_GVL.GVL_Parametros.bLiga17MangueirasCP));
                //bLiga1MangueiraCS: BOOL;
                _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_wLiga1MangueiraCS }, Convert.ToDouble(HelperTestBase.Model_GVL.GVL_Parametros.bLiga1MangueiraCS));
                //bLiga2MangueirasCS: BOOL;
                _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_wLiga2MangueirasCS }, Convert.ToDouble(HelperTestBase.Model_GVL.GVL_Parametros.bLiga2MangueirasCS));
                //bLiga4MangueirasCS: BOOL;
                _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_wLiga4MangueirasCS }, Convert.ToDouble(HelperTestBase.Model_GVL.GVL_Parametros.bLiga4MangueirasCS));
                //bLiga8mangueirasCS: BOOL;
                _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_wLiga8MangueirasCS }, Convert.ToDouble(HelperTestBase.Model_GVL.GVL_Parametros.bLiga8MangueirasCS));
                //bLiga10MangueirasCS: BOOL;
                _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_wLiga10MangueirasCS }, Convert.ToDouble(HelperTestBase.Model_GVL.GVL_Parametros.bLiga10MangueirasCS));
                //bLiga17MangueirasCS: BOOL;
                _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_wLiga17MangueirasCS }, Convert.ToDouble(HelperTestBase.Model_GVL.GVL_Parametros.bLiga17MangueirasCS));

                #endregion

                _helperCom.SelecaoPrograma();

                CHART_Clear(devChart);

                _helperApp.GVL_Graficos = _helperApp.ChartValidate(HelperApp.uiTesteSelecionado, HelperTestBase.Model_GVL.GVL_Graficos.iOutput);

                HelperTestBase.Model_GVL.GVL_Graficos = _helperApp.GVL_Graficos;

                // ActivePage(0);
            }

            LOG_TestSequence("TESTE SEQUENCE START");

            return true;
        }
        private bool TEST_Start_ValidatePreCondition()
        {
            //// abort here, if nothing to do...
            //if (!HelperTestBase.currentTestFile.is_Created)
            //{
            //    //IWin32Window parent

            //    //MessageBox.Show(parent, message, title, MessageBoxButtons.OK,
            //    //MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign & MessageBoxOptions.RtlReading);
            //    if (CreateSimulateTestFile())
            //        return true;
            //    else
            //        return false;
            //}

            #region Actuation Parameters

            //if (!_helperApp.TabActionParameters_GetEvaluationParam(HelperApp.uiTesteSelecionado))
            //{
            //    MessageBox.Show("Parameters_GetEvaluationParam Failed !", _helperApp.appMsg_Error, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return false;
            //}

            if (HelperApp.uiActuationMode == 0)
            {
                MessageBox.Show("Actuation Mode Invalid !", _helperApp.appMsg_Error, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (HelperApp.uiTesteSelecionado == 0)
            {
                MessageBox.Show("Test Invalid !", _helperApp.appMsg_Error, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrEmpty(mtxt_Actuation_E1ParMaxForce.Text) || mtxt_Actuation_E1ParMaxForce.Text == "0" || HelperTestBase.MaxForce == 0)
            {
                MessageBox.Show("Max Force Invalid !", _helperApp.appMsg_Error, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrEmpty(mtxt_Actuation_E1ParForceGrad.Text) || mtxt_Actuation_E1ParForceGrad.Text == "0")
            {
                MessageBox.Show("Force Gradient Invalid !", _helperApp.appMsg_Error, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            #endregion

            if (!ComModbusTCP.connected)
            {
                MessageBox.Show("MODBUS COM Failed !", _helperApp.appMsg_Error, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!_helperHBM.PreparedContinuousMeasurement || !_helperHBM.Status)
            {
                MessageBox.Show("HBM COM Failed !", _helperApp.appMsg_Error, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            //// abort here, if security nok...
            if (!HelperMODBUS.CS_wSegurancaOK)
            {
                MessageBox.Show("Security Failed !", _helperApp.appMsg_Error, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            //// abort here, if Alarms nok...
            if (HelperMODBUS.CS_wAlarmeAtivo)
            {
                MessageBox.Show("Alarm Activated!", _helperApp.appMsg_Error, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            //// abort here, if protection nok...
            if (!HelperMODBUS.CS_wProtecoes)
            {
                MessageBox.Show("Protection Failed !", _helperApp.appMsg_Error, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            //// abort here, if cover is open...
            if (HelperMODBUS.CS_wBypassPortas)
            {
                MessageBox.Show("Cover By-Pass ", _helperApp.appMsg_Error, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            //// abort Emergency, if nothing to do...Status Normal = True!
            if (!HelperMODBUS.CS_wEmergencia)
            {
                MessageBox.Show("Emergency Activated!", _helperApp.appMsg_Error, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (HelperMODBUS.CS_wConfirmacaoCicloFinalizado)
            {
                _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_wConfirmacaoCicloFinalizado }, 0);
                return false;
            }

            LOG_TestSequence("TESTE SEQUENCE ValidatePreCondition OK");

            return true;
        }

        #endregion

        #region STOP SEQUENCE PROCESS
        public void TEST_Stop_Command()
        {
            try
            {
                LOG_TestSequence("BTN STOP");

                HBM_ClearBufferAquisitionData();

                _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_wPartidaGeral }, 0);

                _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_wCicloFinalizado }, 1);

                _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_wConfirmacaoCicloFinalizado }, 1);

                _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_wGravacaoFinalizada }, 1);

                LOG_TestSequence("CMD STOP RECORD DATA HBM ");

                _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_wParadaGeral }, 1);

                _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_wFinalizaGravacao }, 1);

                _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_wParadaGeral }, 0);

                CHART_Clear(devChart);

                LOG_TestSequence("TESTE SEQUENCE STOP");
            }
            catch (Exception ex)
            {
                var err = ex.Message;
                MessageBox.Show(err, _helperApp.appMsg_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public bool TEST_Stop_Sequence()
        {
            LOG_TestSequence("BTN STOP"); ;

            //// abort here, if nothing to do...
            if (!HelperTestBase.currentProjectTest.is_Created)
            {
                if (DialogResult.No == MessageBox.Show("NOT CREATED TEST FILE!" + "\n\n\n" + "Do you want STOP with SIMULATED Test ? ", _helperApp.appMsg_Name, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))
                    return false;
            }

            LOG_TestSequence("TESTE SEQUENCE STOP");

            //// abort here, if any precondition violated...
            //if (!TEST_StopValidatePreCondition())
            //    return false;

            CHART_Clear(devChart);

            return true;
        }

        #endregion

        #region DATA RECORD PROCESS
        private void TEST_DataRecord_Start()
        {
            try
            {
                if (!HelperMODBUS.CS_wGravacaoIniciada)
                {
                    _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_wGravacaoIniciada }, 1);

                    ////INFO GRAVACAO
                    mbtn_BRecordStart.BackColor = colorON;
                    mbtn_BRecording.BackColor = colorON;

                    HelperTestBase.running = true;

                    LOG_TestSequence("CMD START RECORD DATA HBM ");

                    timerHBM.Enabled = true;

                    //HBM_SaveAquisitionTxtData();

                    //if (_helperApp.bgWorker.IsBusy != true)
                    //    _helperApp.bgWorker.RunWorkerAsync();
                }
                else
                {
                    mbtn_BRecordStart.BackColor = colorOFF;
                    mbtn_BRecording.BackColor = colorOFF;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }
        private void TEST_DataRecord_Stop()
        {
            try
            {
                if (!HelperMODBUS.CS_wGravacaoFinalizada)
                {
                    _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_wGravacaoFinalizada }, 1);

                    //INFO GRAVACAO
                    mbtn_BRecordStop.BackColor = colorOFF;
                    mbtn_BRecording.BackColor = colorOFF;

                    HelperTestBase.running = false;

                    LOG_TestSequence("CMD STOP RECORD DATA HBM ");

                    if (!HelperTestBase.currentProjectTest.is_Created)
                    {
                        if (sbexterno.Length > 0)
                        {
                            if (TXTFileHBM_Create())
                            {
                                timerHBM.Enabled = false;

                                TEST_Concluded_Command();

                                HBM_ClearBufferAquisitionData();
                            }
                            else
                                MessageBox.Show("Failed, create test file !", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                        MessageBox.Show("Failed, test existing file !", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);

                    //_helperApp.bgWorker.CancelAsync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        #endregion

        #region CONCLUDED SEQUENCE PROCESS
        private void TEST_Concluded_Command()
        {
            try
            {
                string strMsgConcluded = String.Concat("\tTEST CONCLUDED !", "\n\n\n", "\tDo you want SAVE DATA this Test ? ", "\n\n\n", $"\t{HelperApp.strNomeTesteSelecionado}");

                if (DialogResult.No == MessageBox.Show(strMsgConcluded, _helperApp.appMsg_Name, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))
                {
                    //delet files test
                    TEST_Concluded_DeleteData();

                    MessageBox.Show("Test data DELETED !", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    if (!HelperTestBase.currentProjectTest.is_Created)
                    {
                        if (DialogResult.No == MessageBox.Show("\tPROJECT NOT CREATED!" + "\n\n\n" + "Do you want following without create a PROJECT TEST ? ", _helperApp.appMsg_Name, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))
                            return;
                    }
                    else
                    {
                        HelperTestBase.currentProjectTest.is_OnLIne = true;

                        if (TXTFileHBM_LoadData())
                        {
                            _modelGVL = HelperTestBase.Model_GVL;

                            TXTFileHBM_HeaderCreate(_helperApp.lstStrReturnReadFileLines, HelperTestBase.Model_GVL);

                            tab_TableResultsEnable = true;

                            TAB_Main.SelectedTab = TAB_Main.TabPages["tab_Diagram"];
                        } 
                        else
                            MessageBox.Show("Error TXTFileHBM_LoadData, failed load result data test!", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Warning);
 
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }
        private void TEST_Concluded_DeleteData()
        {
            try
            {
                TXTFileHBM_DeleteData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        #endregion

        #endregion

        #region TXT FILE TEST

        #region TXT File Create
        private bool TXTFileHBM_Create()
        {
            #region Name File Test

            string testTypeName = HelperApp.uiTesteSelecionado == 0 ? EnumExtensionMethods.GetEnumValue<eEXAMTYPE>(HelperTestBase.eExamType.ToString()).ToString() : EnumExtensionMethods.GetEnumValue<eEXAMTYPE>(HelperApp.uiTesteSelecionado).ToString();

            string testIdentName = "HBM_SaveAquisitionTxtData";

            string prjTestFilename = string.Concat(DateTime.Now.ToString("yyyyMMdd_HHmmss"), "#", HelperApp.uiTesteSelecionado, "#", testTypeName, "#", testIdentName, _helperApp.AppTests_DefaultExtension);

            _prjTestFilename = Path.Combine(_initialDirPathTestFile, prjTestFilename);

            #endregion

            #region WRite File Test

            try
            {
                if (!_helperApp.CheckFileExists(_prjTestFilename))
                {
                    File.WriteAllText(_prjTestFilename, sbexterno.ToString());
                    LOG_TestSequence("TXTFileHBM_Create - WriteAllText");
                }
                else
                {
                    File.AppendAllLines(_prjTestFilename, sbexterno.ToString().Split(Environment.NewLine.ToCharArray()));
                    LOG_TestSequence("TXTFileHBM_Create - AppendAllLines");
                }
            }
            catch (DirectoryNotFoundException dirNotFoundException)
            {
                var err = string.Concat("DirectoryNotFoundException : ", dirNotFoundException.Message);
                MessageBox.Show(err, _helperApp.appMsg_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Show a message to the user
            }
            catch (UnauthorizedAccessException unauthorizedAccessException)
            {
                var err = string.Concat("UnauthorizedAccessException : ", unauthorizedAccessException.Message);
                MessageBox.Show(err, _helperApp.appMsg_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Show a message to the user
            }
            catch (IOException ioException)
            {
                var err = string.Concat("IOException : ", ioException.Message);
                MessageBox.Show(err, _helperApp.appMsg_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Show a message to the user
            }
            catch (Exception ex)
            {
                var err = string.Concat("Exception : ", ex.Message);
                MessageBox.Show(err, _helperApp.appMsg_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            #endregion

            //clean data test file
            sbexterno.Clear();

            HelperTestBase.currentProjectTest.PrjTestFileName = _prjTestFilename;

            return HelperTestBase.currentProjectTest.is_Created = _helperApp.CheckFileExists(_prjTestFilename);
        }

        #endregion

        #region TXT File Load
        private bool TXTFileHBM_LoadData()
        {
            try
            {
                #region Define

                string fileName = string.Empty;

                string pathWithFileName = string.Empty;

                //clean List Array Data
                for (int i = 0; i < lstStrChReadFileArr.Length; i++)
                {
                    if (lstStrChReadFileArr[i] != null)
                        lstStrChReadFileArr[i].Clear();
                }

                #endregion

                #region set Path

                if (_helperApp.AppUseSimulateLocal)
                {
                    OpenFileDialog theDialog = new OpenFileDialog();
                    theDialog.Title = "Open Text File";
                    theDialog.Filter = "TXT files|*.txt;*.tst";
                    theDialog.InitialDirectory = string.Concat(_initialDirPathTestFile, "texst.txt");

                    if (theDialog.ShowDialog() == DialogResult.OK)
                    {
                        fileName = theDialog.SafeFileName;

                        _prjTestFilename = theDialog.FileName;

                        HelperTestBase.currentProjectTest.PrjTestFileName = _prjTestFilename;

                        pathWithFileName = HelperTestBase.currentProjectTest.PrjTestFileName;
                    }
                }
                else
                {
                    int idTest = HelperApp.uiTesteSelecionado;

                    if (idTest == 0 && _bCoBSelectTestSelected)
                    {
                        mcbo_tabActParam_GenSettings_CoBSelectTest.SelectedIndex = 0;

                        _bCoBSelectTestSelected = false;

                        MessageBox.Show("Warning, Load Data invalid option!", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    else
                    {
                        fileName = HelperTestBase.currentProjectTest.PrjTestFileName.Replace(_initialDirPathTestFile, "");

                        pathWithFileName = HelperTestBase.currentProjectTest.PrjTestFileName;
                    }
                }

                #endregion

                #region load data

                if (!string.IsNullOrEmpty(pathWithFileName))
                    lstStrChReadFileArr = _helperApp.ReadExistTestFileTextArrNew(fileName, pathWithFileName);

                if (lstStrChReadFileArr[0].Count() > 0)
                {
                    lstDblChReadFileArr = _helperApp.lstDblReturnReadFile;

                    #region CALC TEST

                    bool breturnCalcStep = _helperApp.CalcInfoTestByStep(HelperApp.uiTesteSelecionado);

                    if (!breturnCalcStep)
                    {
                        string strMsg = "Failed, calc step test -  not calculated !";

                        LOG_TestSequence(strMsg);

                        MessageBox.Show(strMsg, _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    else
                        _modelGVL = _helperApp.CalcGraphData(HelperApp.uiTesteSelecionado, lstDblChReadFileArr);

                    #endregion

                    if (!_modelGVL.GVL_Graficos.bDadosCalculados)
                    {
                        string strMsg = "Failed, test information not calculated !";

                        LOG_TestSequence(strMsg);

                        MessageBox.Show(strMsg, _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    else
                    {
                        LOG_TestSequence("TESTE CALC CONCLUDED");

                        if (!TAB_TableResult_SetData())
                            MessageBox.Show("Failed, TAB_TableResult_SetData !", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else
                        {
                            if (!CHART_LoadActualTestComplete())
                                MessageBox.Show("Failed, Chart Create !", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            //if (!ReportPDF())
                            //    MessageBox.Show("Failed, Report Create !", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);

                            // ChartPointsAnnottion(HelperTestBase.Model_GVL.GVL_Graficos);
                        }

                        if (tab_TableResultsEnable)
                        {
                            //else
                            //{
                            //    if (!ReportPDF())
                            //        MessageBox.Show("Failed, Report Create !", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            //}
                        }

                        tab_TableResultsEnable = false;
                        HelperTestBase.currentProjectTest.is_Created = true;

                        if (_modelGVL.GVL_Graficos.bDadosCalculados)
                            HelperTestBase.Model_GVL = _modelGVL;

                        LOG_TestSequence("TESTE SEQUENCE STOP AND CONCLUDED");
                    }
                }
                else
                {
                    MessageBox.Show("Failed, reloading project !", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;

                throw;
            }

            return true;
        }
        private void TXTFileHBM_LoadData_AppUseSimulateLocal()
        {
            OpenFileDialog theDialog = new OpenFileDialog();
            theDialog.Title = "Open Text File";
            theDialog.Filter = "TXT files|*.txt;*.tst";
            theDialog.InitialDirectory = string.Concat(_initialDirPathTestFile, "texst.txt");
            try
            {
                if (theDialog.ShowDialog() == DialogResult.OK)
                {
                    string fileName = theDialog.SafeFileName;

                    var pathWithFileName = theDialog.FileName;

                    HelperTestBase.currentProjectTest.PrjTestFileName = pathWithFileName;

                    if (!string.IsNullOrEmpty(pathWithFileName))
                        lstStrChReadFileArr = _helperApp.ReadExistTestFileTextArrNew(fileName, pathWithFileName);

                    if (lstStrChReadFileArr[0].Count() > 0)
                    {
                        lstDblChReadFileArr = _helperApp.lstDblReturnReadFile;

                        HelperApp.uiTesteSelecionado = HelperApp.uiTesteSelecionado == 0 ? 1 : HelperApp.uiTesteSelecionado;

                        #region CALC TEST

                        bool breturnCalcStep = _helperApp.CalcInfoTestByStep(HelperApp.uiTesteSelecionado);

                        if (!breturnCalcStep)
                        {
                            string strMsg = "Failed, calc step test -  not calculated !";

                            LOG_TestSequence(strMsg);

                            MessageBox.Show(strMsg, _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        else
                            _modelGVL = _helperApp.CalcGraphData(HelperApp.uiTesteSelecionado, lstDblChReadFileArr);

                        #endregion

                        if (!_modelGVL.GVL_Graficos.bDadosCalculados)
                        {
                            string strMsg = "Failed, test information not calculated !";

                            LOG_TestSequence(strMsg);

                            MessageBox.Show(strMsg, _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        else
                        {
                            HelperTestBase.Model_GVL = _modelGVL;

                            LOG_TestSequence("TESTE CALC CONCLUDED");

                            if (!TAB_TableResult_SetData())
                                MessageBox.Show("Failed, TAB_TableResult_SetData !", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            else
                            {
                                if (!CHART_LoadActualTestComplete())
                                    MessageBox.Show("Failed, Chart Create !", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                else
                                    TXTFileHBM_HeaderCreate(_helperApp.lstStrReturnReadFileLines, HelperTestBase.Model_GVL);
                                //if (!ReportPDF())
                                //    MessageBox.Show("Failed, Report Create !", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);

                                // ChartPointsAnnottion(HelperTestBase.Model_GVL.GVL_Graficos);
                            }
                        }
                    }
                    else
                        MessageBox.Show("Failed, reloading project !", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        #endregion

        #region TXT File Header
        private bool TXTFileHBM_HeaderCreate(List<string> lstFiledata, Model_GVL model_GVL)
        {
            try
            {
                #region Header Name File Test

                string strHeader = "HBM_AquisitionHeader";
                string strUnion = "HBM_AquisitionUnion";

                _prjTestFilename = !string.IsNullOrEmpty(_prjTestFilename) ? _prjTestFilename : HelperTestBase.currentProjectTest.PrjTestFileName;

                string strFileName = _prjTestFilename.Replace(_initialDirPathTestFile, string.Empty).Replace(_helperApp.AppTests_DefaultExtension, string.Empty);

                string strHeaderTestFilename = string.Concat(strFileName.Replace("HBM_SaveAquisitionTxtData", string.Empty), strHeader, _helperApp.AppTests_DefaultExtension);
                string strTestFilenameUnion = string.Concat(strFileName.Replace("HBM_SaveAquisitionTxtData", string.Empty), strUnion, _helperApp.AppTests_DefaultExtension);

                _prjTestHeaderFilename = Path.Combine(_initialDirPathTestFile, strHeaderTestFilename);
                _prjTestFilenameUnion = Path.Combine(_initialDirPathTestFile, strTestFilenameUnion);

                #endregion

                if (_helperApp.CheckFileExists(_prjTestFilename))
                {
                    if (!_helperApp.CheckFileExists(_prjTestHeaderFilename))
                    {

                        lstFiledata.ForEach(item => sbDataFile.Append(item + "\r\n"));

                        _helperApp.TXTFileHBM_HeaderAppendData(HelperApp.uiTesteSelecionado, model_GVL);

                        if (!string.IsNullOrEmpty(HelperTestBase.sbHeaderAppendTxtData?.ToString()))
                        {
                            var strSbHeader = String.Concat(HelperTestBase.sbHeaderAppendTxtData.ToString(), Environment.NewLine);

                            _helperApp.TXTFileHBM_HeaderAppendTableResults(HelperApp.uiTesteSelecionado).ToString();

                            string strSbHeaderResults_CurverNames = String.Concat(HelperTestBase.sbHeaderResultsAppendTxtData, Environment.NewLine);

                            var strUnionHeader = string.Concat(strSbHeader, strSbHeaderResults_CurverNames);

                            var strUnionAll = string.Concat(strUnionHeader, sbDataFile.ToString());

                            ////Create File Acquisition
                            File.WriteAllText(_prjTestHeaderFilename, strUnionHeader);

                            File.WriteAllText(_prjTestFilenameUnion, strUnionAll);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Failed, Header Test File existing !", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    } 
                }
                else
                {
                    MessageBox.Show("Test file NOT FOUND!", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                } 
            }
            catch (DirectoryNotFoundException dirNotFoundException)
            {
                var err = string.Concat("DirectoryNotFoundException : ", dirNotFoundException.Message);
                MessageBox.Show(err, _helperApp.appMsg_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch (UnauthorizedAccessException unauthorizedAccessException)
            {
                var err = string.Concat("UnauthorizedAccessException : ", unauthorizedAccessException.Message);
                MessageBox.Show(err, _helperApp.appMsg_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch (IOException ioException)
            {
                var err = string.Concat("IOException : ", ioException.Message);
                MessageBox.Show(err, _helperApp.appMsg_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch (Exception ex)
            {
                var err = string.Concat("Exception : ", ex.Message);
                MessageBox.Show(err, _helperApp.appMsg_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
        public bool TXTFileHBM_HeaderInsert(List<string> lstFiledata)
        {
            try
            {
                #region Name File Test

                string testTypeName = HelperApp.uiTesteSelecionado == 0 ? EnumExtensionMethods.GetEnumValue<eEXAMTYPE>(HelperTestBase.eExamType.ToString()).ToString() : EnumExtensionMethods.GetEnumValue<eEXAMTYPE>(HelperApp.uiTesteSelecionado).ToString();

                string testIdentName = "HBM_SaveAquisitionTxtData";

                string prjTestFilename = string.Concat(DateTime.Now.ToString("yyyyMMdd_HHmmss"), "#", HelperApp.uiTesteSelecionado, "#", testTypeName, "#", testIdentName, _helperApp.AppTests_DefaultExtension);

                _prjTestFilename = Path.Combine(_initialDirPathTestFile, prjTestFilename);

                #endregion

                #region WRite File Test

                try
                {
                    if (!_helperApp.CheckFileExists(_prjTestFilename))
                    {
                        lstFiledata.ForEach(item => sbDataFile.Append(item + "\r\n"));

                       // _helperApp.TXTFileHBM_HeaderAppendData(HelperApp.uiTesteSelecionado, model_GVL);

                        if (!string.IsNullOrEmpty(HelperTestBase.sbHeaderAppendTxtData?.ToString()))
                        {
                            var strSbHeader = String.Concat(HelperTestBase.sbHeaderAppendTxtData.ToString(), Environment.NewLine);

                            sbDataFile.Insert(0, strSbHeader);

                            string strSbHeaderResults_CurverNames = _helperApp.TXTFileHBM_HeaderAppendTableResults(HelperApp.uiTesteSelecionado).ToString();

                            sbDataFile.Insert(strSbHeader.ToString().Split('\n').Length, String.Concat(strSbHeaderResults_CurverNames, Environment.NewLine));

                            ////Create File Acquisition
                            _prjTestFilename = Path.Combine(_initialDirPathTestFile, "novo.txt");
                            File.WriteAllText(_prjTestFilename, sbDataFile.ToString());
                        }
                    }
                    else
                        MessageBox.Show("Failed, Header Test File existing !", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (DirectoryNotFoundException dirNotFoundException)
                {
                    var err = string.Concat("DirectoryNotFoundException : ", dirNotFoundException.Message);
                    MessageBox.Show(err, _helperApp.appMsg_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    // Show a message to the user
                }
                catch (UnauthorizedAccessException unauthorizedAccessException)
                {
                    var err = string.Concat("UnauthorizedAccessException : ", unauthorizedAccessException.Message);
                    MessageBox.Show(err, _helperApp.appMsg_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    // Show a message to the user
                }
                catch (IOException ioException)
                {
                    var err = string.Concat("IOException : ", ioException.Message);
                    MessageBox.Show(err, _helperApp.appMsg_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    // Show a message to the user
                }
                catch (Exception ex)
                {
                    var err = string.Concat("Exception : ", ex.Message);
                    MessageBox.Show(err, _helperApp.appMsg_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                #endregion

                //clean data test file
                sbexterno.Clear();

                HelperTestBase.currentProjectTest.PrjTestFileName = _prjTestFilename;
            }
            catch (Exception ex)
            {
                var err = string.Concat("Exception : ", ex.Message);
                MessageBox.Show(err, _helperApp.appMsg_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return HelperTestBase.currentProjectTest.is_Created = _helperApp.CheckFileExists(_prjTestFilename);
        }

        #endregion

        #region TXT File Delete
        private void TXTFileHBM_DeleteData()
        {
            try
            {
                if (!_helperApp.CheckFileExists(_prjTestFilename))
                {
                    File.Delete(_prjTestFilename);
                    LOG_TestSequence("TXTFileHBM_DeleteData - WriteAllText");
                }
                else
                    MessageBox.Show("Test file NOT FOUND!", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (DirectoryNotFoundException dirNotFoundException)
            {
                var err = string.Concat("DirectoryNotFoundException : ", dirNotFoundException.Message);
                MessageBox.Show(err, _helperApp.appMsg_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Show a message to the user
            }
            catch (UnauthorizedAccessException unauthorizedAccessException)
            {
                var err = string.Concat("UnauthorizedAccessException : ", unauthorizedAccessException.Message);
                MessageBox.Show(err, _helperApp.appMsg_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Show a message to the user
            }
            catch (IOException ioException)
            {
                var err = string.Concat("IOException : ", ioException.Message);
                MessageBox.Show(err, _helperApp.appMsg_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Show a message to the user
            }
            catch (Exception ex)
            {
                var err = string.Concat("Exception : ", ex.Message);
                MessageBox.Show(err, _helperApp.appMsg_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #endregion

        #region REPORT PDF
        public bool ReportPDF()
        {
            try
            {
                if (HelperApp.uiTesteSelecionado != 0)
                {
                    if (HelperTestBase.currentProjectTest.PrjTestFileName != null)
                    {
                        string dirReportChartImagePath = System.IO.Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, _helperApp.AppPath_ChartImageTests);

                        string strFileName = HelperTestBase.currentProjectTest.PrjTestFileName.Replace(_initialDirPathTestFile, "").Replace(_helperApp.AppTests_DefaultExtension, string.Empty);

                        string dirReportChartImagehWithFileName = string.Concat(dirReportChartImagePath, strFileName, _helperApp.AppPath_ChartImageExtension);

                        DataGridViewRowCollection gridResultRows = TAB_TableResult_Grid.Rows;

                        _helperApp.Report_CreatePDF(dirReportChartImagehWithFileName, strFileName, gridResultRows);
                    }
                    else
                    {
                        MessageBox.Show("Failed, currentProjectTest NOT NAME !", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
                else
                    MessageBox.Show("Error, invalid test!", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
                throw;
            }

            return true;
        }

        #endregion

        #region CHART
        private void CHART_Clear(ChartControl chart)
        {
            chart.DataSource = null;
            chart.Titles.Clear();
            chart.Series.Clear();
        }
        private void CHART_ClearAxes(XYDiagram diagram)
        {
            int iValueDeafult = 0;
            string strValueDefault = string.Empty;
            Color colorValueDefault = Color.Black;

            #region AXES - X

            diagram.AxisX.Title.Text = strValueDefault;
            diagram.AxisX.Title.TextColor = colorValueDefault;
            diagram.AxisX.Label.TextColor = colorValueDefault;

            diagram.AxisX.VisualRange.MinValue = iValueDeafult;
            diagram.AxisX.VisualRange.MaxValue = iValueDeafult;
            diagram.AxisX.Range.MinValue = iValueDeafult;
            diagram.AxisX.Range.MaxValue = iValueDeafult;

            #endregion

            #region AXES - Y

            diagram.AxisY.Title.Text = strValueDefault;
            diagram.AxisY.Title.TextColor = colorValueDefault;
            diagram.AxisY.Label.TextColor = colorValueDefault;
            diagram.AxisY.Color = colorValueDefault;

            diagram.AxisY.VisualRange.MinValue = iValueDeafult;
            diagram.AxisY.VisualRange.MaxValue = iValueDeafult;
            diagram.AxisY.Range.MinValue = iValueDeafult;
            diagram.AxisY.Range.MaxValue = iValueDeafult;

            #endregion
        }
        private bool CHART_LoadActualTestComplete()
        {
            try
            {
                if (_modelGVL.GVL_Graficos.arrVarX.Count() != 1000000)
                {

                    int outputChecked = rad_EvaluationParameters_CBOutputPC.Checked ? 1 : rad_EvaluationParameters_CBOutputSC.Checked ? 2 : 0;

                    _modelGVL.GVL_Parametros.iOutput = outputChecked;

                    _modelGVL.GVL_Graficos.iOutput = _modelGVL.GVL_Parametros.iOutput;

                    HelperTestBase.Model_GVL = _modelGVL;

                    //ChartLoadData(HelperTestBase.Model_GVL.GVL_Graficos, lstDblChReadFileArr);
                    bool bCreateChart = CHART_BinddDataConfig(HelperTestBase.Model_GVL.GVL_Graficos, lstDblChReadFileArr);

                    if (!bCreateChart)
                    {
                        MessageBox.Show("Failed, Chart Create !", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    else
                    {
                        //if (!CHART_ExportImage())
                        //    MessageBox.Show("Failed, Chart Export !", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);

                        // ChartPointsAnnottion(HelperTestBase.Model_GVL.GVL_Graficos);
                    }
                }
                else
                {
                    for (int i = 0; i < lstStrChReadFileArr.Length; i++)
                        lstStrChReadFileArr[i].Clear();

                    MessageBox.Show("Failed, reloading project !", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
                throw;
            }

            return true;
        }
        public bool CHART_BinddDataConfig(GVL_Graficos modelChartGVL, List<double>[] lstDblChReadFileArr)
        {
            try
            {
                #region Variable
                List<ActuationParameters_EvaluationParameters> lstInfoEvaluationParameters = _helperApp.GridView_GetValuesEvalParam(grid_tabActionParam_EvalParam);

                int outputChecked = rad_EvaluationParameters_CBOutputPC.Checked ? 1 : rad_EvaluationParameters_CBOutputSC.Checked ? 2 : 0;

                _modelGVL.GVL_Parametros.iOutput = outputChecked;

                _modelGVL.GVL_Graficos.iOutput = _modelGVL.GVL_Parametros.iOutput;

                HelperTestBase.Model_GVL = _modelGVL;

                _helperApp.GVL_Graficos = _helperApp.ChartValidate(HelperApp.uiTesteSelecionado, HelperTestBase.Model_GVL.GVL_Graficos.iOutput, lstInfoEvaluationParameters);

                HelperTestBase.Model_GVL.GVL_Graficos = _helperApp.GVL_Graficos;

                var chartGVL = modelChartGVL;

                #endregion

                #region  Create a new chart.

                if (devChart.Series.Count > 0)
                    CHART_Clear(devChart);


                if (!CHART_CreateSerie(modelChartGVL, lstDblChReadFileArr))
                {
                    MessageBox.Show("Chart Create Series Failed!", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                else
                {
                    if (devChart.Series.Count == 0)
                    {
                        MessageBox.Show("Chart Count Series Failed!", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    else
                    {
                        XYDiagram diagram = (XYDiagram)devChart.Diagram;

                        if (diagram == null)
                            MessageBox.Show("Failed, loading XYDiagram !", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else
                        {

                            CHART_ClearAxes(diagram);

                            #region Zoom

                            // Access the type-specific options of the diagram.
                            diagram.EnableAxisXZooming = true;

                            #endregion

                            #region Axes

                            #region AXES - X

                             Color setColor = Color.Black;

                            //diagram.AxisX.Title.EnableAntialiasing = DefaultBoolean.False;
                            //diagram.AxisX.Title.Font = new Font("Tahoma", 8, FontStyle.Regular);

                            diagram.AxisX.Title.Text = chartGVL.strNomeEixoX;  //@"nome eixo X";
                            diagram.AxisX.Title.Visibility = DefaultBoolean.True;
                            diagram.AxisX.Title.TextColor = setColor;
                            diagram.AxisX.Label.TextColor = setColor;

                            diagram.AxisX.VisualRange.Auto = false;
                            diagram.AxisX.VisualRange.MinValue = chartGVL.EixoX.rMin;
                            diagram.AxisX.VisualRange.MaxValue = chartGVL.EixoX.rMax;
                            diagram.AxisX.Range.MinValue = chartGVL.EixoX.rMin;
                            diagram.AxisX.Range.MaxValue = chartGVL.EixoX.rMax;

                            diagram.AxisX.DateTimeScaleOptions.MeasureUnit = DateTimeMeasureUnit.Minute;
                            //diagram.AxisX.Label.TextPattern = @"d.M";
                            //}
                            diagram.AxisX.DateTimeScaleOptions.GridAlignment = DateTimeGridAlignment.Hour;
                            // Vertical Day-GridLines, short Label-Days and rotated
                            diagram.AxisX.GridLines.Visible = true;
                            diagram.AxisX.Label.Angle = -90;
                            //diagram.AxisX.GridSpacingAuto = false;
                            //diagram.AxisX.GridSpacing = 1;
                            diagram.AxisX.Tickmarks.CrossAxis = false;
                            diagram.AxisX.Tickmarks.MinorVisible = false;
                            diagram.AxisX.CrosshairAxisLabelOptions.Visibility = DefaultBoolean.False;
                            diagram.AxisX.CrosshairAxisLabelOptions.Visibility = DefaultBoolean.False;
                            diagram.AxisX.DateTimeScaleOptions.AggregateFunction = AggregateFunction.None;
                            //    return diagram;
                            //    When I compare this with your designer - file, I can see that following is missing:
                            //diagram.AxisX.VisibleInPanesSerializable = "-1";
                            //    diagram.AxisY.VisibleInPanesSerializable = "-1";
                            //    diagram.EnableAxisXScrolling = true;
                            //    diagram.EnableAxisXZooming = true;
                            //    diagram.EnableAxisYScrolling = true;
                            //    diagram.EnableAxisYZooming = true;

                            #endregion

                            #region AXES - Y

                            #region Y01

                            setColor = devChart.Series[0].View.Color;

                            //diagram.AxisY.Title.EnableAntialiasing = DefaultBoolean.False;
                            //diagram.AxisY.Title.Font = new Font("Tahoma", 8, FontStyle.Regular);

                            diagram.AxisY.Title.Text = chartGVL.iOutput == 2 ? chartGVL.strNomeEixoY2 : chartGVL.strNomeEixoY1;
                            diagram.AxisY.Title.Visibility = DefaultBoolean.True;
                            diagram.AxisY.Title.TextColor = setColor;
                            diagram.AxisY.Label.TextColor = setColor;

                            diagram.AxisY.Alignment = AxisAlignment.Near;
                            diagram.AxisY.Color = setColor;

                            diagram.AxisY.VisualRange.Auto = false;
                            diagram.AxisY.VisualRange.MinValue = chartGVL.iOutput == 2 ? chartGVL.EixoY2.rMin : chartGVL.EixoY1.rMin;
                            diagram.AxisY.VisualRange.MaxValue = chartGVL.iOutput == 2 ? chartGVL.EixoY2.rMax : chartGVL.EixoY1.rMax;
                            diagram.AxisY.Range.MinValue = chartGVL.iOutput == 2 ? chartGVL.EixoY2.rMin : chartGVL.EixoY1.rMin;
                            diagram.AxisY.Range.MaxValue = chartGVL.iOutput == 2 ? chartGVL.EixoY2.rMax : chartGVL.EixoY1.rMax;

                            #endregion

                            #region ADD Y

                            int countSeries = devChart.Series.Count();

                            if (countSeries >= 3)
                            {
                                if (diagram.SecondaryAxesY.Count > 0)
                                    diagram.SecondaryAxesY.Clear();

                                #region Y02

                                chartGVL.bOcultaY2 = chartGVL.iOutput > 0 ? true : false;

                                if (!chartGVL.bOcultaY2)
                                {
                                    setColor = devChart.Series[1].View.Color;

                                    //// Create two secondary axes, and add them to the chart's Diagram.
                                    SecondaryAxisY EixoY2 = new SecondaryAxisY(chartGVL.strNomeEixoY2);
                                    diagram.SecondaryAxesY.Add(EixoY2);

                                    //// Assign the series2 to the created axes.
                                    //((LineSeriesView)series2.View).AxisY = EixoY2;

                                    EixoY2.Title.Text = chartGVL.strNomeEixoY2;
                                    EixoY2.Title.Visibility = DevExpress.Utils.DefaultBoolean.True;
                                    EixoY2.Title.TextColor = setColor;
                                    EixoY2.Label.TextColor = setColor;
                                    EixoY2.Alignment = AxisAlignment.Near;
                                    EixoY2.Color = setColor;

                                    EixoY2.VisualRange.Auto = false;
                                    EixoY2.VisualRange.MinValue = chartGVL.EixoY2.rMin;
                                    EixoY2.VisualRange.MaxValue = chartGVL.EixoY2.rMax;
                                    EixoY2.Range.MinValue = chartGVL.EixoY2.rMin;
                                    EixoY2.Range.MaxValue = chartGVL.EixoY2.rMax;
                                }

                                #endregion

                                #region Y03

                                if (!chartGVL.bOcultaY3)
                                {
                                    setColor = devChart.Series[2].View.Color;

                                    //// Create two secondary axes, and add them to the chart's Diagram.
                                    SecondaryAxisY EixoY3 = new SecondaryAxisY(chartGVL.strNomeEixoY3);
                                    diagram.SecondaryAxesY.Add(EixoY3);

                                    //// Assign the series3 to the created axes.
                                    //((LineSeriesView)series3.View).AxisY = EixoY3;

                                    EixoY3.Title.Text = chartGVL.strNomeEixoY3;
                                    EixoY3.Title.Visibility = DevExpress.Utils.DefaultBoolean.True;
                                    EixoY3.Title.TextColor = setColor;
                                    EixoY3.Label.TextColor = setColor;
                                    EixoY3.Alignment = AxisAlignment.Near;
                                    EixoY3.Color = setColor;

                                    EixoY3.VisualRange.Auto = false;
                                    EixoY3.VisualRange.MinValue = chartGVL.EixoY3.rMin;
                                    EixoY3.VisualRange.MaxValue = chartGVL.EixoY3.rMax;
                                    EixoY3.Range.MinValue = chartGVL.EixoY3.rMin;
                                    EixoY3.Range.MaxValue = chartGVL.EixoY3.rMax;
                                }

                                #endregion

                                #region Y04

                                if (!chartGVL.bOcultaY4)
                                {
                                    setColor = devChart.Series[1].View.Color;

                                    //// Create two secondary axes, and add them to the chart's Diagram.
                                    SecondaryAxisY EixoY4 = new SecondaryAxisY(chartGVL.strNomeEixoY4);
                                    diagram.SecondaryAxesY.Add(EixoY4);

                                    //// Assign the series4 to the created axes.
                                    //((LineSeriesView)series4.View).AxisY = EixoY4;

                                    EixoY4.Title.Text = chartGVL.strNomeEixoY4;
                                    EixoY4.Title.Visibility = DevExpress.Utils.DefaultBoolean.True;
                                    EixoY4.Title.TextColor = setColor;
                                    EixoY4.Label.TextColor = setColor;
                                    EixoY4.Alignment = AxisAlignment.Near;
                                    EixoY4.Color = setColor;

                                    EixoY4.VisualRange.Auto = false;
                                    EixoY4.VisualRange.MinValue = chartGVL.EixoY4.rMin;
                                    EixoY4.VisualRange.MaxValue = chartGVL.EixoY4.rMax;
                                    EixoY4.Range.MinValue = chartGVL.EixoY4.rMin;
                                    EixoY4.Range.MaxValue = chartGVL.EixoY4.rMax;
                                }

                                #endregion
                            }

                            #endregion

                            #endregion

                            #endregion
                        }

                        #region Chart Set info

                        #region  CrosshairEnabled

                        // The property below sets whether the Chart displays the Crosshair Cursor:
                        devChart.CrosshairEnabled = DefaultBoolean.True;
                        devChart.CrosshairOptions.ShowArgumentLine = true;
                        devChart.CrosshairOptions.ShowArgumentLabels = false;
                        devChart.CrosshairOptions.ShowValueLine = true;
                        devChart.CrosshairOptions.ShowValueLabels = true;
                        devChart.CrosshairOptions.ShowCrosshairLabels = true;
                        devChart.CrosshairOptions.ShowGroupHeaders = false;

                        //Color orangeColor = Color.FromArgb(247, 129, 25);
                        Color mainColor = Color.FromArgb(0, 0, 0);
                        // Note that Argument Line Labels use this color by default.
                        devChart.CrosshairOptions.ArgumentLineColor = mainColor;
                        devChart.CrosshairOptions.ShowValueLine = true;
                        devChart.CrosshairOptions.ShowValueLabels = true;


                        // Note that Value Line Labels use this color by default.
                        devChart.CrosshairOptions.ValueLineColor = mainColor;
                        devChart.CrosshairOptions.ValueLineStyle.DashStyle = DashStyle.Dash;
                        // The axis can customize the Crosshair label that is displayed on it.
                        ((XYDiagram)devChart.Diagram).AxisY.CrosshairAxisLabelOptions.BackColor = Color.Red;

                        devChart.CrosshairOptions.CrosshairLabelBackColor = Color.FromArgb(63, 63, 63);
                        devChart.CrosshairOptions.GroupHeaderTextOptions.TextColor = mainColor;
                        devChart.CrosshairOptions.CrosshairLabelTextOptions.TextColor = Color.White;

                        // An axis can hide the Crosshair Cursor's Axis Label that is displayed on this axis:
                        //((XYDiagram)devChart.Diagram).AxisY.CrosshairAxisLabelOptions.Visibility = DefaultBoolean.False;

                        // The Crosshair Options contains a pattern specifying Crosshair Label Group Headers' texts:
                        devChart.CrosshairOptions.GroupHeaderPattern = "{A:F0}";
                        // The Series' property formats the Crosshair element's text:
                        devChart.SeriesTemplate.CrosshairLabelPattern = "{S}: {V:F2}";
                        // The axis provides a property formatting the Crosshair Axis Label's text:
                        ((XYDiagram)devChart.Diagram).AxisY.CrosshairAxisLabelOptions.Pattern = "{V:F1}";

                        #endregion

                        #region Chart titles.

                        ChartTitle ChartTitle = new ChartTitle();
                        ChartTitle.Text = EnumExtensionMethods.GetDescriptionEXAMTYPE(HelperTestBase.eExamType);
                        ChartTitle.Alignment = StringAlignment.Center;
                        ChartTitle.Dock = ChartTitleDockStyle.Top;
                        ChartTitle.WordWrap = true;
                        ChartTitle.MaxLineCount = 2;

                        // Customize a title's appearance.
                        //ChartTitle.Antialiasing = true;
                        //ChartTitle.Font = new Font("Tahoma", 14, FontStyle.Bold);
                        //ChartTitle.TextColor = Color.Red;
                        //ChartTitle  .Indent = 10;

                        devChart.Titles.Add(ChartTitle);

                        #endregion

                        // Hide the legend (if necessary).
                        devChart.Legend.Visibility = DevExpress.Utils.DefaultBoolean.False;

                        devChart.BackColor = Color.LightGray;

                        tab_Diagram.BackColor = Color.LightGray;

                        #endregion
                    }
                }

                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
                throw;
            }

            return true;
        }
        public bool CHART_CreateSerie(GVL_Graficos modelChartGVL, List<double>[] lstDblChReadFileArr)
        {
            bool bCharSeriesOK = false;

            try
            {
                #region Variable

                HelperTestBase.Model_GVL.GVL_Graficos = _helperApp.GVL_Graficos;

                List<double> lstAnalogCh00_Timestamp = lstDblChReadFileArr[0];          //  Time [s]
                List<double> lstAnalogCh01_DiffTravel = lstDblChReadFileArr[1];         //ch9.1 - HelperHBM._rDiffTravel - Transdutor Deslocamento Desvio Linearidade - 0-10 mm (Linearizado)
                List<double> lstAnalogCh02_InputForce1 = lstDblChReadFileArr[2];        //ch9.2 - HelperHBM._rInputForce1 - Celula Carga Forca Entrada - 0-5 kN (Linearizada)
                List<double> lstAnalogCh03_OutputForce = lstDblChReadFileArr[3];        //ch9.3 - HelperHBM._rOutputForce - Celula Carga Forca Saída- 0-10 kN (Linearizada)
                List<double> lstAnalogCh04_TravelTMC = lstDblChReadFileArr[4];          //ch9.4 - HelperHBM._rTravelTMC - Transdutor Deslocamento Saida Booster - 0-50 mm (Linearizada)
                List<double> lstAnalogCh05_TravelPiston = lstDblChReadFileArr[5];       //ch9.5 - HelperHBM._rTravelPiston - Transdutor Deslocamento Entrada Booster - 0-50 mm (Linearizada)
                List<double> lstAnalogCh06_PressureSC = lstDblChReadFileArr[6];         //ch9.6 - HelperHBM._rPressureSC - Pressao Camara Secundaria CS - 0-250 bar (Linearizada
                List<double> lstAnalogCh07_PressurePC = lstDblChReadFileArr[7];         //ch9.7 - HelperHBM._rPressurePC - Pressao Camara Primaria CP - 0-250 bar (Linearizada)
                List<double> lstAnalogCh08_PneumTestPressure = lstDblChReadFileArr[8];  //ch9.8 - HelperHBM._rPneumTestPressure - Pressao Teste Bolhas 0-1 bar(Linearizada)
                List<double> lstAnalogCh09_HydrFillPressure = lstDblChReadFileArr[9];   //ch9.9 - HelperHBM._rHydrFillPressure - Pressao Sangria 0-6 bar (Linearizada)
                List<double> lstAnalogCh10_Vaccum = lstDblChReadFileArr[10];            //ch9.10 - HelperHBM._rVaccum - Pressao Linha Vacuo (-1)-0 bar (Linearizada)
                List<double> lstAnalogCh11_Reserv = lstDblChReadFileArr[11];            //ch9.11 - RESERVA
                List<double> lstAnalogCh12_Reserv = lstDblChReadFileArr[12];            //ch9.12 - RESERVA

                int totalPointsCount = lstDblChReadFileArr[0].Count(); //70000

                int step = (totalPointsCount % 32762) > 0 ? (totalPointsCount / 32762) : (totalPointsCount / 32762) + 1; //series1.Points.Capacity;

                int i = 0;

                #endregion

                if (HelperApp.uiTesteSelecionado > 0)
                {
                    if (devChart.Series.Count > 0)
                        CHART_Clear(devChart);

                    #region Create a scatter line series.

                    //Series 01
                    Series series1 = new Series(modelChartGVL.strNomeEixoY1, ViewType.ScatterLine);
                    series1.ArgumentScaleType = ScaleType.Numerical;
                    series1.View.Color = modelChartGVL.iOutput == 2 ? Color.Green : Color.Blue;

                    //Series 02
                    Series series2 = new Series(modelChartGVL.strNomeEixoY2, ViewType.ScatterLine);
                    series2.ArgumentScaleType = ScaleType.Numerical;
                    series2.View.Color = Color.Green;

                    Series series3 = new Series(modelChartGVL.strNomeEixoY3, ViewType.ScatterLine);
                    series3.ArgumentScaleType = ScaleType.Numerical;
                    series3.View.Color = Color.Brown;

                    Series series4 = new Series(modelChartGVL.strNomeEixoY4, ViewType.ScatterLine);
                    series4.ArgumentScaleType = ScaleType.Numerical;
                    series4.View.Color = Color.Magenta;

                    #endregion

                    #region  Serie Inclusao de Pontos de Interesse

                    Series PontosChart = new Series("PontosInteresse", ViewType.Point);
                    PontosChart.ArgumentScaleType = ScaleType.Numerical;

                    PointSeriesView PontosChartView = (PointSeriesView)PontosChart.View; //Define a visualizacao da serie
                    PontosChartView.PointMarkerOptions.Kind = MarkerKind.Cross; //Define o X
                    PontosChartView.PointMarkerOptions.Size = 10;
                    PontosChartView.Color = Color.Brown;

                    #endregion

                    #region Add SeriePoints Values

                    switch (HelperApp.uiTesteSelecionado)
                    {
                        case 1:     //Force Diagrams - Force/Pressure With Vacuum
                        case 3:     //Force Diagrams - Force/Pressure Without Vacuum
                        case 13:    //Check Sensors - Pressure Difference
                        case 25:    //Force Diagrams - Force/Pressure Dual Ratio
                            {
                                try
                                {
                                    #region  Serie de Valores

                                    //GVL_Graficos.strNomeEixoX = "Input Force (N)";
                                    //GVL_Graficos.strNomeEixoY1 = "Pressure PC (bar)";
                                    //GVL_Graficos.strNomeEixoY2 = "Pressure SC (bar)";

                                    switch (modelChartGVL.iOutput)
                                    {
                                        case 1:
                                            {
                                                for (i = 0; i <= totalPointsCount - 1; i++)
                                                {
                                                    series1.Points.Add(new SeriesPoint(lstAnalogCh02_InputForce1[i], lstAnalogCh07_PressurePC[i]));
                                                }
                                            }
                                            break;
                                        case 2:
                                            {
                                                for (i = 0; i <= totalPointsCount - 1; i++)
                                                {
                                                    series1.Points.Add(new SeriesPoint(lstAnalogCh02_InputForce1[i], lstAnalogCh06_PressureSC[i]));
                                                }
                                            }
                                            break;
                                        default:
                                            {
                                                for (i = 0; i <= totalPointsCount - 1; i++)
                                                {
                                                    series1.Points.Add(new SeriesPoint(lstAnalogCh02_InputForce1[i], lstAnalogCh07_PressurePC[i]));
                                                    series2.Points.Add(new SeriesPoint(lstAnalogCh02_InputForce1[i], lstAnalogCh06_PressureSC[i]));
                                                }
                                            }
                                            break;
                                    }

                                    #endregion

                                    #region  Serie Pontos de Interesse

                                    switch (HelperApp.uiTesteSelecionado)
                                    {
                                        case 1:
                                            {
                                                PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T01.rForca_P1, _modelGVL.GVL_T01.rPressao_P1_Bar));
                                                PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T01.rForca_P2, _modelGVL.GVL_T01.rPressao_P2_Bar));
                                                PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T01.rForca_E1, _modelGVL.GVL_T01.rPressao_E1_Bar));
                                                PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T01.rForca_E2, _modelGVL.GVL_T01.rPressao_E2_Bar));

                                                if (_modelGVL.GVL_T01.bRunOutTeorico)//Ponto Runout depende do flag selecionado
                                                    PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T01.rRunOutForce_LinearInt_N, _modelGVL.GVL_T01.rRunOutPressure_LinearInt_Bar));
                                                else
                                                    PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T01.rRunOutForce_Real_N, _modelGVL.GVL_T01.rRunOutPressure_Real_Bar));

                                                PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T01.rForcaCutIn_N, _modelGVL.GVL_T01.rPressaoJumper_Bar));
                                                PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T01.rForcaAvanco_Xpout_N, _modelGVL.GVL_T01.rPressaoHysteresePout_Bar));
                                                PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T01.rForcaRetorno_Xpout_N, _modelGVL.GVL_T01.rPressaoHysteresePout_Bar));
                                                PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T01.rForcaAvanco_Xbar_N, _modelGVL.GVL_T01.rPressaoHysterese_Bar));
                                                PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T01.rForcaRetorno_Xbar_N, _modelGVL.GVL_T01.rPressaoHysterese_Bar));
                                            }
                                            break;
                                        case 3:
                                            {
                                                PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T03.rForcaReal_E1_N, _modelGVL.GVL_T03.rPressao_E1_Bar));
                                                PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T03.rForcaReal_E2_N, _modelGVL.GVL_T03.rPressao_E2_Bar));
                                            }
                                            break;
                                        case 13:
                                            {
                                                //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T13.rForcaP1Avanco_N, _modelGVL.GVL_T13.rSetPointDiferencaPressaoP1Avanco_Bar));
                                                //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T13.rForcaP2Avanco_N, _modelGVL.GVL_T13.rSetPointDiferencaPressaoP2Avanco_Bar));
                                                //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T13.rForcaP3Retoro_N, _modelGVL.GVL_T13.rSetPointDiferencaPressaoP3Avanco_Bar));
                                                //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T13.rForcaP4Retorno_N, _modelGVL.GVL_T13.rSetPointDiferencaPressaoP4Avanco_Bar));

                                            }
                                            break;
                                        case 25:
                                            {
                                                //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T25.rForcaReal_P1_N, _modelGVL.GVL_T25.rPressao_P1_Bar));
                                                //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T25.rForcaReal_P2_N, _modelGVL.GVL_T25.rPressao_P2_Bar));
                                                //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T25.rForcaReal_E1_N, _modelGVL.GVL_T25.rPressao_E1_Bar));
                                                //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T25.rForcaReal_E2_N, _modelGVL.GVL_T25.rPressao_E2_Bar));
                                                //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T25.rRunOutForce_Real_N, _modelGVL.GVL_T25.rRunOutPressure_Real_Bar));
                                                //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T25.rForcaCutIn_N, _modelGVL.GVL_T25.rPressaoJumper_Bar));
                                                //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T25.rForcaAvanco_Xpout_N, _modelGVL.GVL_T25.rPressaoHysteresePout_Bar));
                                                //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T25.rForcaRetorno_Xpout_N, _modelGVL.GVL_T25.rPressaoHysteresePout_Bar));
                                                //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T25.rForcaAvanco_Xbar_N, _modelGVL.GVL_T25.rPressaoHysterese_Bar));
                                                //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T25.rForcaRetorno_Xbar_N, _modelGVL.GVL_T25.rPressaoHysterese_Bar));
                                            }
                                            break;
                                        default:
                                            break;
                                    }

                                    #endregion

                                    devChart.Series.AddRange(new Series[] { series1, series2, PontosChart });
                                }
                                catch (Exception ex)
                                {
                                    var err = i;
                                    bCharSeriesOK = false;

                                    MessageBox.Show(ex.Message, _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    throw;
                                }
                            }
                            break;
                        case 2:     //Force Diagrams - Force/Force With Vacuum
                        case 4:     //Force Diagrams - Force/Force Without Vacuum
                        case 26:    //Force Diagrams - Force/Force Dual Ratio
                            {
                                try
                                {
                                    #region  Serie de Valores

                                    //GVL_Graficos.strNomeEixoX = "Input Force (N)";
                                    //GVL_Graficos.strNomeEixoY1 = "Output Force (N)";

                                    for (i = 0; i <= totalPointsCount - 1; i++)
                                    {
                                        series1.Points.Add(new SeriesPoint(lstAnalogCh02_InputForce1[i], lstAnalogCh03_OutputForce[i]));
                                    }

                                    #endregion

                                    #region  Serie Pontos de Interesse

                                    switch (HelperApp.uiTesteSelecionado)
                                    {
                                        case 2:
                                            {
                                                PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T02.rForca_P1, _modelGVL.GVL_T02.rForcaOut_P1_N));
                                                PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T02.rForca_P2, _modelGVL.GVL_T02.rForcaOut_P2_N));
                                                PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T02.rForca_E1, _modelGVL.GVL_T02.rForcaOut_E1_N));
                                                PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T02.rForca_E2, _modelGVL.GVL_T02.rForcaOut_E2_N));

                                                if (_modelGVL.GVL_T02.bRunOutTeorico)//Ponto Runout depende do flag selecionado
                                                    PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T02.rRunOutForce_Real_N, _modelGVL.GVL_T02.rRunOutForceOut_Real_N));
                                                else
                                                    PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T02.rRunOutForce_LinearInt_N, _modelGVL.GVL_T02.rRunOutForceOut_LinearInt_N));

                                                PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T02.rForcaCutIn_N, _modelGVL.GVL_T02.rForcaOutJumper_N));
                                                PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T02.rForcaAvanco_XFout_N, _modelGVL.GVL_T02.rForcaOutHystereseFout_N));
                                                PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T02.rForcaRetorno_XFout_N, _modelGVL.GVL_T02.rForcaOutHystereseFout_N));
                                            }
                                            break;
                                        case 4:
                                            {
                                                PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T04.rForca_E1, _modelGVL.GVL_T04.rForcaOut_E1_N));
                                                PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T04.rForca_E2, _modelGVL.GVL_T04.rForcaOut_E2_N));
                                            }
                                            break;
                                        case 26:
                                            {
                                                //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T26.rForcaReal_P1_N, _modelGVL.GVL_T26.rPressao_P1_Bar));
                                                //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T26.rForcaReal_P2_N, _modelGVL.GVL_T26.rPressao_P2_Bar));
                                                //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T26.rForcaReal_E1_N, _modelGVL.GVL_T26.rPressao_E1_Bar));
                                                //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T26.rForcaReal_E2_N, _modelGVL.GVL_T26.rPressao_E2_Bar));
                                                //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T26.rRunOutForce_Real_N, _modelGVL.GVL_T26.rRunOutPressure_Real_Bar));
                                                //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T26.rForcaCutIn_N, _modelGVL.GVL_T26.rPressaoJumper_Bar));
                                                //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T26.rForcaAvanco_Xpout_N, _modelGVL.GVL_T26.rPressaoHysteresePout_Bar));
                                                //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T26.rForcaRetorno_Xpout_N, _modelGVL.GVL_T26.rPressaoHysteresePout_Bar));
                                                //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T26.rForcaAvanco_Xbar_N, _modelGVL.GVL_T26.rPressaoHysterese_Bar));
                                                //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T26.rForcaRetorno_Xbar_N, _modelGVL.GVL_T26.rPressaoHysterese_Bar));
                                            }
                                            break;
                                        default:
                                            break;
                                    }

                                    #endregion

                                    devChart.Series.AddRange(new Series[] { series1, PontosChart });
                                }
                                catch (Exception ex)
                                {
                                    var err = i;
                                    bCharSeriesOK = false;

                                    MessageBox.Show(ex.Message, _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    throw;
                                }
                            }
                            break;
                        case 5:     //Vaccum Leakage - Released Position
                        case 6:     //Vacuum Leakage - Fully Applied Position
                        case 7:     //Vacuum Leakage - Lap Position
                            {
                                try
                                {
                                    #region  Serie de Valores

                                    //GVL_Graficos.strNomeEixoX = "Time (s)";
                                    //GVL_Graficos.strNomeEixoY1 = "Vacuum (bar)";

                                    for (i = 0; i <= totalPointsCount - 1; i++)
                                    {
                                        series1.Points.Add(new SeriesPoint(lstAnalogCh00_Timestamp[i], lstAnalogCh10_Vaccum[i]));
                                    }

                                    #endregion

                                    #region  Serie Pontos de Interesse

                                    switch (HelperApp.uiTesteSelecionado)
                                    {
                                        case 5:
                                            {
                                                //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T05.rForcaReal_P1_N, _modelGVL.GVL_T05.rPressao_P1_Bar));
                                                //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T05.rForcaReal_P2_N, _modelGVL.GVL_T05.rPressao_P2_Bar));
                                                //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T05.rForcaReal_E1_N, _modelGVL.GVL_T05.rPressao_E1_Bar));
                                                //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T05.rForcaReal_E2_N, _modelGVL.GVL_T05.rPressao_E2_Bar));
                                                //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T05.rRunOutForce_Real_N, _modelGVL.GVL_T05.rRunOutPressure_Real_Bar));
                                                //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T05.rForcaCutIn_N, _modelGVL.GVL_T05.rPressaoJumper_Bar));
                                                //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T05.rForcaAvanco_Xpout_N, _modelGVL.GVL_T05.rPressaoHysteresePout_Bar));
                                                //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T05.rForcaRetorno_Xpout_N, _modelGVL.GVL_T05.rPressaoHysteresePout_Bar));
                                                //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T05.rForcaAvanco_Xbar_N, _modelGVL.GVL_T05.rPressaoHysterese_Bar));
                                                //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T05.rForcaRetorno_Xbar_N, _modelGVL.GVL_T05.rPressaoHysterese_Bar));
                                            }
                                            break;
                                        case 6:
                                            {
                                                //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T06.rForcaReal_P1_N, _modelGVL.GVL_T06.rPressao_P1_Bar));
                                                //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T06.rForcaReal_P2_N, _modelGVL.GVL_T06.rPressao_P2_Bar));
                                                //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T06.rForcaReal_E1_N, _modelGVL.GVL_T06.rPressao_E1_Bar));
                                                //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T06.rForcaReal_E2_N, _modelGVL.GVL_T06.rPressao_E2_Bar));
                                                //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T06.rRunOutForce_Real_N, _modelGVL.GVL_T06.rRunOutPressure_Real_Bar));
                                                //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T06.rForcaCutIn_N, _modelGVL.GVL_T06.rPressaoJumper_Bar));
                                                //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T06.rForcaAvanco_Xpout_N, _modelGVL.GVL_T06.rPressaoHysteresePout_Bar));
                                                //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T06.rForcaRetorno_Xpout_N, _modelGVL.GVL_T06.rPressaoHysteresePout_Bar));
                                                //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T06.rForcaAvanco_Xbar_N, _modelGVL.GVL_T06.rPressaoHysterese_Bar));
                                                //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T06.rForcaRetorno_Xbar_N, _modelGVL.GVL_T06.rPressaoHysterese_Bar));
                                            }
                                            break;
                                        case 7:
                                            {
                                                //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T07.rForcaReal_P1_N, _modelGVL.GVL_T07.rPressao_P1_Bar));
                                                //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T07.rForcaReal_P2_N, _modelGVL.GVL_T07.rPressao_P2_Bar));
                                                //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T07.rForcaReal_E1_N, _modelGVL.GVL_T07.rPressao_E1_Bar));
                                                //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T07.rForcaReal_E2_N, _modelGVL.GVL_T07.rPressao_E2_Bar));
                                                //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T07.rRunOutForce_Real_N, _modelGVL.GVL_T07.rRunOutPressure_Real_Bar));
                                                //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T07.rForcaCutIn_N, _modelGVL.GVL_T07.rPressaoJumper_Bar));
                                                //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T07.rForcaAvanco_Xpout_N, _modelGVL.GVL_T07.rPressaoHysteresePout_Bar));
                                                //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T07.rForcaRetorno_Xpout_N, _modelGVL.GVL_T07.rPressaoHysteresePout_Bar));
                                                //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T07.rForcaAvanco_Xbar_N, _modelGVL.GVL_T07.rPressaoHysterese_Bar));
                                                //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T07.rForcaRetorno_Xbar_N, _modelGVL.GVL_T07.rPressaoHysterese_Bar));
                                            }
                                            break;
                                        default:
                                            break;
                                    }

                                    #endregion

                                    devChart.Series.AddRange(new Series[] { series1, PontosChart });
                                }
                                catch (Exception ex)
                                {
                                    var err = i;
                                    bCharSeriesOK = false;

                                    MessageBox.Show(ex.Message, _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    throw;
                                }
                            }
                            break;
                        case 8:     //Hydraulic Leakage - Fully Applied Position
                        case 9:     //Hydraulic Leakage - At Low Pressure
                        case 10:    //Hydraulic Leakage - At High Pressure
                            {
                                try
                                {
                                    #region  Serie de Valores

                                    //GVL_Graficos.strNomeEixoX = "Time (s)";
                                    //GVL_Graficos.strNomeEixoY1 = "Vacuum (bar)";
                                    //GVL_Graficos.strNomeEixoY2 = "Pressure PC (bar)";
                                    //GVL_Graficos.strNomeEixoY3 = "Pressure SC (bar)";
                                    //GVL_Graficos.strNomeEixoY4 = "Piston Travel (mm)";

                                    for (i = 0; i <= totalPointsCount - 1; i++)
                                    {
                                        series1.Points.Add(new SeriesPoint(lstAnalogCh00_Timestamp[i], lstAnalogCh10_Vaccum[i]));
                                        series2.Points.Add(new SeriesPoint(lstAnalogCh00_Timestamp[i], lstAnalogCh07_PressurePC[i]));
                                        series3.Points.Add(new SeriesPoint(lstAnalogCh00_Timestamp[i], lstAnalogCh06_PressureSC[i]));
                                        series4.Points.Add(new SeriesPoint(lstAnalogCh00_Timestamp[i], lstAnalogCh05_TravelPiston[i]));
                                    }

                                    #endregion

                                    #region  Serie Pontos de Interesse

                                    switch (HelperApp.uiTesteSelecionado)
                                    {
                                        case 8:
                                            {
                                                //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T08.rForcaReal_P1_N, _modelGVL.GVL_T08.rPressao_P1_Bar));
                                                //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T08.rForcaReal_P2_N, _modelGVL.GVL_T08.rPressao_P2_Bar));
                                                //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T08.rForcaReal_E1_N, _modelGVL.GVL_T08.rPressao_E1_Bar));
                                                //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T08.rForcaReal_E2_N, _modelGVL.GVL_T08.rPressao_E2_Bar));
                                                //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T08.rRunOutForce_Real_N, _modelGVL.GVL_T08.rRunOutPressure_Real_Bar));
                                                //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T08.rForcaCutIn_N, _modelGVL.GVL_T08.rPressaoJumper_Bar));
                                                //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T08.rForcaAvanco_Xpout_N, _modelGVL.GVL_T08.rPressaoHysteresePout_Bar));
                                                //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T08.rForcaRetorno_Xpout_N, _modelGVL.GVL_T08.rPressaoHysteresePout_Bar));
                                                //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T08.rForcaAvanco_Xbar_N, _modelGVL.GVL_T08.rPressaoHysterese_Bar));
                                                //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T08.rForcaRetorno_Xbar_N, _modelGVL.GVL_T08.rPressaoHysterese_Bar));
                                            }
                                            break;
                                        case 9:
                                            {
                                                //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T09.rForcaReal_P1_N, _modelGVL.GVL_T09.rPressao_P1_Bar));
                                                //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T09.rForcaReal_P2_N, _modelGVL.GVL_T09.rPressao_P2_Bar));
                                                //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T09.rForcaReal_E1_N, _modelGVL.GVL_T09.rPressao_E1_Bar));
                                                //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T09.rForcaReal_E2_N, _modelGVL.GVL_T09.rPressao_E2_Bar));
                                                //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T09.rRunOutForce_Real_N, _modelGVL.GVL_T09.rRunOutPressure_Real_Bar));
                                                //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T09.rForcaCutIn_N, _modelGVL.GVL_T09.rPressaoJumper_Bar));
                                                //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T09.rForcaAvanco_Xpout_N, _modelGVL.GVL_T09.rPressaoHysteresePout_Bar));
                                                //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T09.rForcaRetorno_Xpout_N, _modelGVL.GVL_T09.rPressaoHysteresePout_Bar));
                                                //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T09.rForcaAvanco_Xbar_N, _modelGVL.GVL_T09.rPressaoHysterese_Bar));
                                                //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T09.rForcaRetorno_Xbar_N, _modelGVL.GVL_T09.rPressaoHysterese_Bar));
                                            }
                                            break;
                                        case 10:
                                            {
                                                //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T10.rForcaReal_P1_N, _modelGVL.GVL_T10.rPressao_P1_Bar));
                                                //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T10.rForcaReal_P2_N, _modelGVL.GVL_T10.rPressao_P2_Bar));
                                                //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T10.rForcaReal_E1_N, _modelGVL.GVL_T10.rPressao_E1_Bar));
                                                //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T10.rForcaReal_E2_N, _modelGVL.GVL_T10.rPressao_E2_Bar));
                                                //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T10.rRunOutForce_Real_N, _modelGVL.GVL_T10.rRunOutPressure_Real_Bar));
                                                //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T10.rForcaCutIn_N, _modelGVL.GVL_T10.rPressaoJumper_Bar));
                                                //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T10.rForcaAvanco_Xpout_N, _modelGVL.GVL_T10.rPressaoHysteresePout_Bar));
                                                //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T10.rForcaRetorno_Xpout_N, _modelGVL.GVL_T10.rPressaoHysteresePout_Bar));
                                                //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T10.rForcaAvanco_Xbar_N, _modelGVL.GVL_T10.rPressaoHysterese_Bar));
                                                //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T10.rForcaRetorno_Xbar_N, _modelGVL.GVL_T10.rPressaoHysterese_Bar));
                                            }
                                            break;
                                        default:
                                            break;
                                    }

                                    #endregion

                                    devChart.Series.AddRange(new Series[] { series1, series2, series3, series4, PontosChart });
                                }
                                catch (Exception ex)
                                {
                                    var err = i;
                                    bCharSeriesOK = false;

                                    MessageBox.Show(ex.Message, _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    throw;
                                }
                            }
                            break;
                        case 11:    //Adjustment - Actuation Slow
                        case 12:    //Adjustment - Actuation Fast
                            {
                                try
                                {
                                    #region  Serie de Valores

                                    //GVL_Graficos.strNomeEixoX = "Time (s)";
                                    //GVL_Graficos.strNomeEixoY1 = "Input Force (N)";

                                    for (i = 0; i <= totalPointsCount - 1; i++)
                                    {
                                        series1.Points.Add(new SeriesPoint(lstAnalogCh00_Timestamp[i], lstAnalogCh02_InputForce1[i]));
                                    }

                                    #endregion

                                    #region  Serie Pontos de Interesse

                                    switch (HelperApp.uiTesteSelecionado)
                                    {
                                        case 11:
                                            {
                                                //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T11.rForcaReal_P1_N, _modelGVL.GVL_T11.rPressao_P1_Bar));
                                                //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T11.rForcaReal_P2_N, _modelGVL.GVL_T11.rPressao_P2_Bar));
                                                //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T11.rForcaReal_E1_N, _modelGVL.GVL_T11.rPressao_E1_Bar));
                                                //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T11.rForcaReal_E2_N, _modelGVL.GVL_T11.rPressao_E2_Bar));
                                                //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T11.rRunOutForce_Real_N, _modelGVL.GVL_T11.rRunOutPressure_Real_Bar));
                                                //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T11.rForcaCutIn_N, _modelGVL.GVL_T11.rPressaoJumper_Bar));
                                                //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T11.rForcaAvanco_Xpout_N, _modelGVL.GVL_T11.rPressaoHysteresePout_Bar));
                                                //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T11.rForcaRetorno_Xpout_N, _modelGVL.GVL_T11.rPressaoHysteresePout_Bar));
                                                //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T11.rForcaAvanco_Xbar_N, _modelGVL.GVL_T11.rPressaoHysterese_Bar));
                                                //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T11.rForcaRetorno_Xbar_N, _modelGVL.GVL_T11.rPressaoHysterese_Bar));
                                            }
                                            break;
                                        case 12:
                                            {
                                                //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T12.rForcaReal_P1_N, _modelGVL.GVL_T12.rPressao_P1_Bar));
                                                //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T12.rForcaReal_P2_N, _modelGVL.GVL_T12.rPressao_P2_Bar));
                                                //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T12.rForcaReal_E1_N, _modelGVL.GVL_T12.rPressao_E1_Bar));
                                                //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T12.rForcaReal_E2_N, _modelGVL.GVL_T12.rPressao_E2_Bar));
                                                //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T12.rRunOutForce_Real_N, _modelGVL.GVL_T12.rRunOutPressure_Real_Bar));
                                                //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T12.rForcaCutIn_N, _modelGVL.GVL_T12.rPressaoJumper_Bar));
                                                //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T12.rForcaAvanco_Xpout_N, _modelGVL.GVL_T12.rPressaoHysteresePout_Bar));
                                                //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T12.rForcaRetorno_Xpout_N, _modelGVL.GVL_T12.rPressaoHysteresePout_Bar));
                                                //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T12.rForcaAvanco_Xbar_N, _modelGVL.GVL_T12.rPressaoHysterese_Bar));
                                                //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T12.rForcaRetorno_Xbar_N, _modelGVL.GVL_T12.rPressaoHysterese_Bar));
                                            }
                                            break;
                                        default:
                                            break;
                                    }

                                    #endregion

                                    devChart.Series.AddRange(new Series[] { series1, PontosChart });
                                }
                                catch (Exception ex)
                                {
                                    var err = i;
                                    bCharSeriesOK = false;

                                    MessageBox.Show(ex.Message, _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    throw;
                                }
                            }
                            break;
                        case 14:    //Check Sensors - Input/Output Travel
                            {
                                try
                                {
                                    #region  Serie de Valores

                                    //GVL_Graficos.strNomeEixoX = "Piston Travel (mm)";
                                    //GVL_Graficos.strNomeEixoY1 = "TMC Travel (mm)";

                                    for (i = 0; i <= totalPointsCount - 1; i++)
                                    {
                                        series1.Points.Add(new SeriesPoint(lstAnalogCh05_TravelPiston[i], lstAnalogCh04_TravelTMC[i]));
                                    }

                                    #endregion

                                    #region  Serie Pontos de Interesse

                                    //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T14.rForcaReal_P1_N, _modelGVL.GVL_T14.rPressao_P1_Bar));
                                    //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T14.rForcaReal_P2_N, _modelGVL.GVL_T14.rPressao_P2_Bar));
                                    //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T14.rForcaReal_E1_N, _modelGVL.GVL_T14.rPressao_E1_Bar));
                                    //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T14.rForcaReal_E2_N, _modelGVL.GVL_T14.rPressao_E2_Bar));
                                    //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T14.rRunOutForce_Real_N, _modelGVL.GVL_T14.rRunOutPressure_Real_Bar));
                                    //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T14.rForcaCutIn_N, _modelGVL.GVL_T14.rPressaoJumper_Bar));
                                    //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T14.rForcaAvanco_Xpout_N, _modelGVL.GVL_T14.rPressaoHysteresePout_Bar));
                                    //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T14.rForcaRetorno_Xpout_N, _modelGVL.GVL_T14.rPressaoHysteresePout_Bar));
                                    //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T14.rForcaAvanco_Xbar_N, _modelGVL.GVL_T14.rPressaoHysterese_Bar));
                                    //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T14.rForcaRetorno_Xbar_N, _modelGVL.GVL_T14.rPressaoHysterese_Bar));

                                    #endregion

                                    devChart.Series.AddRange(new Series[] { series1, PontosChart });
                                }
                                catch (Exception ex)
                                {
                                    var err = i;
                                    bCharSeriesOK = false;

                                    MessageBox.Show(ex.Message, _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    throw;
                                }
                            }
                            break;
                        case 15:    //Adjustment - Input Travel VS Input Force
                            {
                                try
                                {
                                    #region  Serie de Valores

                                    //GVL_Graficos.strNomeEixoX = "Input Force (N)";
                                    //GVL_Graficos.strNomeEixoY1 = "Piston Travel (mm)";

                                    for (i = 0; i <= totalPointsCount - 1; i++)
                                    {
                                        series1.Points.Add(new SeriesPoint(lstAnalogCh02_InputForce1[i], lstAnalogCh05_TravelPiston[i]));
                                    }

                                    #endregion

                                    #region  Serie Pontos de Interesse

                                    //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T15.rForcaReal_P1_N, _modelGVL.GVL_T15.rPressao_P1_Bar));
                                    //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T15.rForcaReal_P2_N, _modelGVL.GVL_T15.rPressao_P2_Bar));
                                    //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T15.rForcaReal_E1_N, _modelGVL.GVL_T15.rPressao_E1_Bar));
                                    //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T15.rForcaReal_E2_N, _modelGVL.GVL_T15.rPressao_E2_Bar));
                                    //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T15.rRunOutForce_Real_N, _modelGVL.GVL_T15.rRunOutPressure_Real_Bar));
                                    //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T15.rForcaCutIn_N, _modelGVL.GVL_T15.rPressaoJumper_Bar));
                                    //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T15.rForcaAvanco_Xpout_N, _modelGVL.GVL_T15.rPressaoHysteresePout_Bar));
                                    //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T15.rForcaRetorno_Xpout_N, _modelGVL.GVL_T15.rPressaoHysteresePout_Bar));
                                    //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T15.rForcaAvanco_Xbar_N, _modelGVL.GVL_T15.rPressaoHysterese_Bar));
                                    //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T15.rForcaRetorno_Xbar_N, _modelGVL.GVL_T15.rPressaoHysterese_Bar));

                                    #endregion

                                    devChart.Series.AddRange(new Series[] { series1, PontosChart });
                                }
                                catch (Exception ex)
                                {
                                    var err = i;

                                    MessageBox.Show(ex.Message, _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            break;
                        case 16:    //Adjustment - Hose Consumer
                        case 17:    //Lost Travel ACU - Hydraulic
                        case 18:    //Lost Travel ACU - Hydraulic Electrical Actuation
                            {
                                try
                                {
                                    #region  Serie de Valores

                                    //GVL_Graficos.strNomeEixoX = "Piston Travel (mm)";
                                    //GVL_Graficos.strNomeEixoY1 = "Pressure PC (bar)";
                                    //GVL_Graficos.strNomeEixoY2 = "Pressure SC (bar)";

                                    for (i = 0; i <= totalPointsCount - 1; i++)
                                    {
                                        series1.Points.Add(new SeriesPoint(lstAnalogCh05_TravelPiston[i], lstAnalogCh07_PressurePC[i]));
                                        series2.Points.Add(new SeriesPoint(lstAnalogCh05_TravelPiston[i], lstAnalogCh06_PressureSC[i]));
                                    }

                                    #endregion

                                    #region  Serie Pontos de Interesse

                                    switch (HelperApp.uiTesteSelecionado)
                                    {
                                        case 16:
                                            {
                                                //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T16.rForcaReal_P1_N, _modelGVL.GVL_T16.rPressao_P1_Bar));
                                                //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T16.rForcaReal_P2_N, _modelGVL.GVL_T16.rPressao_P2_Bar));
                                                //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T16.rForcaReal_E1_N, _modelGVL.GVL_T16.rPressao_E1_Bar));
                                                //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T16.rForcaReal_E2_N, _modelGVL.GVL_T16.rPressao_E2_Bar));
                                                //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T16.rRunOutForce_Real_N, _modelGVL.GVL_T16.rRunOutPressure_Real_Bar));
                                                //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T16.rForcaCutIn_N, _modelGVL.GVL_T16.rPressaoJumper_Bar));
                                                //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T16.rForcaAvanco_Xpout_N, _modelGVL.GVL_T16.rPressaoHysteresePout_Bar));
                                                //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T16.rForcaRetorno_Xpout_N, _modelGVL.GVL_T16.rPressaoHysteresePout_Bar));
                                                //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T16.rForcaAvanco_Xbar_N, _modelGVL.GVL_T16.rPressaoHysterese_Bar));
                                                //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T16.rForcaRetorno_Xbar_N, _modelGVL.GVL_T16.rPressaoHysterese_Bar));
                                            }
                                            break;
                                        case 17:
                                            {
                                                //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T17.rForcaReal_P1_N, _modelGVL.GVL_T17.rPressao_P1_Bar));
                                                //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T17.rForcaReal_P2_N, _modelGVL.GVL_T17.rPressao_P2_Bar));
                                                //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T17.rForcaReal_E1_N, _modelGVL.GVL_T17.rPressao_E1_Bar));
                                                //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T17.rForcaReal_E2_N, _modelGVL.GVL_T17.rPressao_E2_Bar));
                                                //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T17.rRunOutForce_Real_N, _modelGVL.GVL_T17.rRunOutPressure_Real_Bar));
                                                //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T17.rForcaCutIn_N, _modelGVL.GVL_T17.rPressaoJumper_Bar));
                                                //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T17.rForcaAvanco_Xpout_N, _modelGVL.GVL_T17.rPressaoHysteresePout_Bar));
                                                //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T17.rForcaRetorno_Xpout_N, _modelGVL.GVL_T17.rPressaoHysteresePout_Bar));
                                                //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T17.rForcaAvanco_Xbar_N, _modelGVL.GVL_T17.rPressaoHysterese_Bar));
                                                //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T17.rForcaRetorno_Xbar_N, _modelGVL.GVL_T17.rPressaoHysterese_Bar));
                                            }
                                            break;
                                        case 18:
                                            {
                                                //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T18.rForcaReal_P1_N, _modelGVL.GVL_T18.rPressao_P1_Bar));
                                                //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T18.rForcaReal_P2_N, _modelGVL.GVL_T18.rPressao_P2_Bar));
                                                //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T18.rForcaReal_E1_N, _modelGVL.GVL_T18.rPressao_E1_Bar));
                                                //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T18.rForcaReal_E2_N, _modelGVL.GVL_T18.rPressao_E2_Bar));
                                                //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T18.rRunOutForce_Real_N, _modelGVL.GVL_T18.rRunOutPressure_Real_Bar));
                                                //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T18.rForcaCutIn_N, _modelGVL.GVL_T18.rPressaoJumper_Bar));
                                                //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T18.rForcaAvanco_Xpout_N, _modelGVL.GVL_T18.rPressaoHysteresePout_Bar));
                                                //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T18.rForcaRetorno_Xpout_N, _modelGVL.GVL_T18.rPressaoHysteresePout_Bar));
                                                //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T18.rForcaAvanco_Xbar_N, _modelGVL.GVL_T18.rPressaoHysterese_Bar));
                                                //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T18.rForcaRetorno_Xbar_N, _modelGVL.GVL_T18.rPressaoHysterese_Bar));
                                            }
                                            break;
                                        default:
                                            break;
                                    }

                                    #endregion

                                    devChart.Series.AddRange(new Series[] { series1, series2, PontosChart });
                                }
                                catch (Exception ex)
                                {
                                    var err = i;
                                    bCharSeriesOK = false;

                                    MessageBox.Show(ex.Message, _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    throw;
                                }
                            }
                            break;
                        case 19:    //Lost Travel ACU - Pneumatic Primary
                        case 20:    //Lost Travel ACU - Pneumatic Secondary
                            {
                                try
                                {
                                    #region  Serie de Valores

                                    //GVL_Graficos.strNomeEixoX = "Piston Travel (mm)";
                                    //GVL_Graficos.strNomeEixoY1 = "Test Pressure (bar)";

                                    for (i = 0; i <= totalPointsCount - 1; i++)
                                    {
                                        series1.Points.Add(new SeriesPoint(lstAnalogCh05_TravelPiston[i], lstAnalogCh08_PneumTestPressure[i]));
                                    }

                                    #endregion

                                    #region  Serie Pontos de Interesse

                                    switch (HelperApp.uiTesteSelecionado)
                                    {
                                        case 19:
                                            {
                                                //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T19.rForcaReal_P1_N, _modelGVL.GVL_T19.rPressao_P1_Bar));
                                                //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T19.rForcaReal_P2_N, _modelGVL.GVL_T19.rPressao_P2_Bar));
                                                //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T19.rForcaReal_E1_N, _modelGVL.GVL_T19.rPressao_E1_Bar));
                                                //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T19.rForcaReal_E2_N, _modelGVL.GVL_T19.rPressao_E2_Bar));
                                                //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T19.rRunOutForce_Real_N, _modelGVL.GVL_T19.rRunOutPressure_Real_Bar));
                                                //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T19.rForcaCutIn_N, _modelGVL.GVL_T19.rPressaoJumper_Bar));
                                                //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T19.rForcaAvanco_Xpout_N, _modelGVL.GVL_T19.rPressaoHysteresePout_Bar));
                                                //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T19.rForcaRetorno_Xpout_N, _modelGVL.GVL_T19.rPressaoHysteresePout_Bar));
                                                //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T19.rForcaAvanco_Xbar_N, _modelGVL.GVL_T19.rPressaoHysterese_Bar));
                                                //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T19.rForcaRetorno_Xbar_N, _modelGVL.GVL_T19.rPressaoHysterese_Bar));
                                            }
                                            break;
                                        case 20:
                                            {
                                                //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T20.rForcaReal_P1_N, _modelGVL.GVL_T20.rPressao_P1_Bar));
                                                //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T20.rForcaReal_P2_N, _modelGVL.GVL_T20.rPressao_P2_Bar));
                                                //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T20.rForcaReal_E1_N, _modelGVL.GVL_T20.rPressao_E1_Bar));
                                                //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T20.rForcaReal_E2_N, _modelGVL.GVL_T20.rPressao_E2_Bar));
                                                //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T20.rRunOutForce_Real_N, _modelGVL.GVL_T20.rRunOutPressure_Real_Bar));
                                                //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T20.rForcaCutIn_N, _modelGVL.GVL_T20.rPressaoJumper_Bar));
                                                //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T20.rForcaAvanco_Xpout_N, _modelGVL.GVL_T20.rPressaoHysteresePout_Bar));
                                                //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T20.rForcaRetorno_Xpout_N, _modelGVL.GVL_T20.rPressaoHysteresePout_Bar));
                                                //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T20.rForcaAvanco_Xbar_N, _modelGVL.GVL_T20.rPressaoHysterese_Bar));
                                                //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T20.rForcaRetorno_Xbar_N, _modelGVL.GVL_T20.rPressaoHysterese_Bar));
                                            }
                                            break;
                                        default:
                                            break;
                                    }
                                    #endregion

                                    devChart.Series.AddRange(new Series[] { series1, PontosChart });
                                }
                                catch (Exception ex)
                                {
                                    var err = i;
                                    bCharSeriesOK = false;

                                    MessageBox.Show(ex.Message, _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    throw;
                                }
                            }
                            break;
                        case 21:    //Pedal Feeling Characteristics
                            {
                                try
                                {
                                    #region  Serie de Valores

                                    //GVL_Graficos.strNomeEixoX = "Piston Travel (mm)";
                                    //GVL_Graficos.strNomeEixoY1 = "Pressure PC (bar)";
                                    //GVL_Graficos.strNomeEixoY2 = "Input Force (N)";

                                    for (i = 0; i <= totalPointsCount - 1; i++)
                                    {
                                        series1.Points.Add(new SeriesPoint(lstAnalogCh05_TravelPiston[i], lstAnalogCh07_PressurePC[i]));
                                        series2.Points.Add(new SeriesPoint(lstAnalogCh05_TravelPiston[i], lstAnalogCh02_InputForce1[i]));
                                    }

                                    #endregion

                                    #region  Serie Pontos de Interesse

                                    //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T21.rForcaReal_P1_N, _modelGVL.GVL_T21.rPressao_P1_Bar));
                                    //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T21.rForcaReal_P2_N, _modelGVL.GVL_T21.rPressao_P2_Bar));
                                    //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T21.rForcaReal_E1_N, _modelGVL.GVL_T21.rPressao_E1_Bar));
                                    //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T21.rForcaReal_E2_N, _modelGVL.GVL_T21.rPressao_E2_Bar));
                                    //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T21.rRunOutForce_Real_N, _modelGVL.GVL_T21.rRunOutPressure_Real_Bar));
                                    //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T21.rForcaCutIn_N, _modelGVL.GVL_T21.rPressaoJumper_Bar));
                                    //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T21.rForcaAvanco_Xpout_N, _modelGVL.GVL_T21.rPressaoHysteresePout_Bar));
                                    //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T21.rForcaRetorno_Xpout_N, _modelGVL.GVL_T21.rPressaoHysteresePout_Bar));
                                    //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T21.rForcaAvanco_Xbar_N, _modelGVL.GVL_T21.rPressaoHysterese_Bar));
                                    //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T21.rForcaRetorno_Xbar_N, _modelGVL.GVL_T21.rPressaoHysterese_Bar));

                                    #endregion

                                    devChart.Series.AddRange(new Series[] { series1, series2, PontosChart });
                                }
                                catch (Exception ex)
                                {
                                    var err = i;
                                    bCharSeriesOK = false;

                                    MessageBox.Show(ex.Message, _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    throw;
                                }
                            }
                            break;
                        case 22:    //Actuation / Release - Mechanical Actuation
                            {
                                try
                                {
                                    #region  Serie de Valores

                                    //GVL_Graficos.strNomeEixoX = "Time (s)";
                                    //GVL_Graficos.strNomeEixoY1 = "Input Force (N)";
                                    //GVL_Graficos.strNomeEixoY2 = "Pressure PC (bar)";
                                    //GVL_Graficos.strNomeEixoY3 = "Piston Travel (mm)";

                                    for (i = 0; i <= totalPointsCount - 1; i++)
                                    {
                                        series1.Points.Add(new SeriesPoint(lstAnalogCh00_Timestamp[i], lstAnalogCh02_InputForce1[i]));
                                        series2.Points.Add(new SeriesPoint(lstAnalogCh00_Timestamp[i], lstAnalogCh07_PressurePC[i]));
                                        series3.Points.Add(new SeriesPoint(lstAnalogCh00_Timestamp[i], lstAnalogCh05_TravelPiston[i]));
                                    }

                                    #endregion

                                    #region  Serie Pontos de Interesse

                                    //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T22.rForcaReal_P1_N, _modelGVL.GVL_T22.rPressao_P1_Bar));
                                    //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T22.rForcaReal_P2_N, _modelGVL.GVL_T22.rPressao_P2_Bar));
                                    //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T22.rForcaReal_E1_N, _modelGVL.GVL_T22.rPressao_E1_Bar));
                                    //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T22.rForcaReal_E2_N, _modelGVL.GVL_T22.rPressao_E2_Bar));
                                    //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T22.rRunOutForce_Real_N, _modelGVL.GVL_T22.rRunOutPressure_Real_Bar));
                                    //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T22.rForcaCutIn_N, _modelGVL.GVL_T22.rPressaoJumper_Bar));
                                    //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T22.rForcaAvanco_Xpout_N, _modelGVL.GVL_T22.rPressaoHysteresePout_Bar));
                                    //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T22.rForcaRetorno_Xpout_N, _modelGVL.GVL_T22.rPressaoHysteresePout_Bar));
                                    //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T22.rForcaAvanco_Xbar_N, _modelGVL.GVL_T22.rPressaoHysterese_Bar));
                                    //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T22.rForcaRetorno_Xbar_N, _modelGVL.GVL_T22.rPressaoHysterese_Bar));

                                    #endregion

                                    devChart.Series.AddRange(new Series[] { series1, series2, series3, PontosChart });
                                }
                                catch (Exception ex)
                                {
                                    var err = i;
                                    bCharSeriesOK = false;

                                    MessageBox.Show(ex.Message, _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    throw;
                                }
                            }
                            break;
                        case 23:    //Breather Hole / Central Valve open
                            {
                                try
                                {
                                    #region  Serie de Valores

                                    //GVL_Graficos.strNomeEixoX = "Time (s)";
                                    //GVL_Graficos.strNomeEixoY1 = "Fill Pressure (bar)";

                                    for (i = 0; i <= totalPointsCount - 1; i++)
                                    {
                                        series1.Points.Add(new SeriesPoint(lstAnalogCh00_Timestamp[i], lstAnalogCh09_HydrFillPressure[i]));
                                    }

                                    #endregion

                                    #region  Serie Pontos de Interesse

                                    //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T23.rForcaReal_P1_N, _modelGVL.GVL_T23.rPressao_P1_Bar));
                                    //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T23.rForcaReal_P2_N, _modelGVL.GVL_T23.rPressao_P2_Bar));
                                    //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T23.rForcaReal_E1_N, _modelGVL.GVL_T23.rPressao_E1_Bar));
                                    //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T23.rForcaReal_E2_N, _modelGVL.GVL_T23.rPressao_E2_Bar));
                                    //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T23.rRunOutForce_Real_N, _modelGVL.GVL_T23.rRunOutPressure_Real_Bar));
                                    //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T23.rForcaCutIn_N, _modelGVL.GVL_T23.rPressaoJumper_Bar));
                                    //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T23.rForcaAvanco_Xpout_N, _modelGVL.GVL_T23.rPressaoHysteresePout_Bar));
                                    //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T23.rForcaRetorno_Xpout_N, _modelGVL.GVL_T23.rPressaoHysteresePout_Bar));
                                    //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T23.rForcaAvanco_Xbar_N, _modelGVL.GVL_T23.rPressaoHysterese_Bar));
                                    //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T23.rForcaRetorno_Xbar_N, _modelGVL.GVL_T23.rPressaoHysterese_Bar));

                                    #endregion

                                    devChart.Series.AddRange(new Series[] { series1, PontosChart });
                                }
                                catch (Exception ex)
                                {
                                    var err = i;
                                    bCharSeriesOK = false;

                                    MessageBox.Show(ex.Message, _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    throw;
                                }
                            }
                            break;
                        case 24:    //Efficiency
                            {
                                try
                                {
                                    #region  Serie de Valores

                                    if (_modelGVL.GVL_Parametros.iTipoGrafico_T24 == 0)
                                    {
                                        //GVL_Graficos.strNomeEixoX = "Input Force (N)";
                                        //GVL_Graficos.strNomeEixoY1 = "Pressure PC (bar)";
                                        //GVL_Graficos.strNomeEixoY2 = "Pressure PC (bar)";

                                        for (i = 0; i <= totalPointsCount - 1; i++)
                                        {
                                            series1.Points.Add(new SeriesPoint(lstAnalogCh02_InputForce1[i], lstAnalogCh07_PressurePC[i]));
                                            series2.Points.Add(new SeriesPoint(lstAnalogCh02_InputForce1[i], lstAnalogCh07_PressurePC[i]));
                                        }
                                    }
                                    else
                                    {
                                        //GVL_Graficos.strNomeEixoX = "Time (s)";
                                        //GVL_Graficos.strNomeEixoY1 = "Pressure PC (bar)";
                                        //GVL_Graficos.strNomeEixoY2 = "Pressure PC (bar)";

                                        for (i = 0; i <= totalPointsCount - 1; i++)
                                        {
                                            series1.Points.Add(new SeriesPoint(lstAnalogCh00_Timestamp[i], lstAnalogCh07_PressurePC[i]));
                                            series2.Points.Add(new SeriesPoint(lstAnalogCh00_Timestamp[i], lstAnalogCh07_PressurePC[i]));
                                        }
                                    }

                                    #endregion

                                    #region  Serie Pontos de Interesse

                                    //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T24.rForcaReal_P1_N, _modelGVL.GVL_T24.rPressao_P1_Bar));
                                    //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T24.rForcaReal_P2_N, _modelGVL.GVL_T24.rPressao_P2_Bar));
                                    //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T24.rForcaReal_E1_N, _modelGVL.GVL_T24.rPressao_E1_Bar));
                                    //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T24.rForcaReal_E2_N, _modelGVL.GVL_T24.rPressao_E2_Bar));
                                    //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T24.rRunOutForce_Real_N, _modelGVL.GVL_T24.rRunOutPressure_Real_Bar));
                                    //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T24.rForcaCutIn_N, _modelGVL.GVL_T24.rPressaoJumper_Bar));
                                    //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T24.rForcaAvanco_Xpout_N, _modelGVL.GVL_T24.rPressaoHysteresePout_Bar));
                                    //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T24.rForcaRetorno_Xpout_N, _modelGVL.GVL_T24.rPressaoHysteresePout_Bar));
                                    //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T24.rForcaAvanco_Xbar_N, _modelGVL.GVL_T24.rPressaoHysterese_Bar));
                                    //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T24.rForcaRetorno_Xbar_N, _modelGVL.GVL_T24.rPressaoHysterese_Bar));

                                    #endregion

                                    devChart.Series.AddRange(new Series[] { series1, series2, PontosChart });
                                }
                                catch (Exception ex)
                                {
                                    var err = i;
                                    bCharSeriesOK = false;

                                    MessageBox.Show(ex.Message, _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    throw;
                                }
                            }
                            break;
                        case 27:    //ADAM - Find Switching Point With TMC
                            {
                                try
                                {
                                    if (_modelGVL.GVL_Parametros.iTipoGrafico_T27 == 0)
                                    {
                                        #region  Serie de Valores

                                        //GVL_Graficos.strNomeEixoX = "Input Force (N)";
                                        //GVL_Graficos.strNomeEixoY1 = "Pressure PC (bar)";

                                        for (i = 0; i <= totalPointsCount - 1; i++)
                                        {
                                            series1.Points.Add(new SeriesPoint(lstAnalogCh02_InputForce1[i], lstAnalogCh07_PressurePC[i]));
                                        }

                                        #endregion

                                        #region  Serie Pontos de Interesse

                                        //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T27.rForcaReal_P1_N, _modelGVL.GVL_T27.rPressao_P1_Bar));
                                        //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T27.rForcaReal_P2_N, _modelGVL.GVL_T27.rPressao_P2_Bar));
                                        //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T27.rForcaReal_E1_N, _modelGVL.GVL_T27.rPressao_E1_Bar));
                                        //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T27.rForcaReal_E2_N, _modelGVL.GVL_T27.rPressao_E2_Bar));
                                        //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T27.rRunOutForce_Real_N, _modelGVL.GVL_T27.rRunOutPressure_Real_Bar));
                                        //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T27.rForcaCutIn_N, _modelGVL.GVL_T27.rPressaoJumper_Bar));
                                        //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T27.rForcaAvanco_Xpout_N, _modelGVL.GVL_T27.rPressaoHysteresePout_Bar));
                                        //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T27.rForcaRetorno_Xpout_N, _modelGVL.GVL_T27.rPressaoHysteresePout_Bar));
                                        //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T27.rForcaAvanco_Xbar_N, _modelGVL.GVL_T27.rPressaoHysterese_Bar));
                                        //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T27.rForcaRetorno_Xbar_N, _modelGVL.GVL_T27.rPressaoHysterese_Bar));

                                        #endregion

                                        devChart.Series.AddRange(new Series[] { series1, PontosChart });
                                    }
                                    else
                                    {
                                        #region  Serie de Valores

                                        //GVL_Graficos.strNomeEixoX = "Time (s)";
                                        //GVL_Graficos.strNomeEixoY1 = "Input Force (N)";
                                        //GVL_Graficos.strNomeEixoY2 = "Pressure PC (bar)";
                                        //GVL_Graficos.strNomeEixoY3 = "Piston Travel (mm)";
                                        //GVL_Graficos.strNomeEixoY4 = "Diff. Travel (mm)";

                                        for (i = 0; i <= totalPointsCount - 1; i++)
                                        {
                                            series1.Points.Add(new SeriesPoint(lstAnalogCh00_Timestamp[i], lstAnalogCh02_InputForce1[i]));
                                            series2.Points.Add(new SeriesPoint(lstAnalogCh00_Timestamp[i], lstAnalogCh07_PressurePC[i]));
                                            series3.Points.Add(new SeriesPoint(lstAnalogCh00_Timestamp[i], lstAnalogCh05_TravelPiston[i]));
                                            series4.Points.Add(new SeriesPoint(lstAnalogCh00_Timestamp[i], lstAnalogCh01_DiffTravel[i]));
                                        }

                                        #endregion

                                        #region  Serie Pontos de Interesse

                                        //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T27.rForcaReal_P1_N, _modelGVL.GVL_T27.rPressao_P1_Bar));
                                        //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T27.rForcaReal_P2_N, _modelGVL.GVL_T27.rPressao_P2_Bar));
                                        //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T27.rForcaReal_E1_N, _modelGVL.GVL_T27.rPressao_E1_Bar));
                                        //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T27.rForcaReal_E2_N, _modelGVL.GVL_T27.rPressao_E2_Bar));
                                        //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T27.rRunOutForce_Real_N, _modelGVL.GVL_T27.rRunOutPressure_Real_Bar));
                                        //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T27.rForcaCutIn_N, _modelGVL.GVL_T27.rPressaoJumper_Bar));
                                        //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T27.rForcaAvanco_Xpout_N, _modelGVL.GVL_T27.rPressaoHysteresePout_Bar));
                                        //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T27.rForcaRetorno_Xpout_N, _modelGVL.GVL_T27.rPressaoHysteresePout_Bar));
                                        //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T27.rForcaAvanco_Xbar_N, _modelGVL.GVL_T27.rPressaoHysterese_Bar));
                                        //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T27.rForcaRetorno_Xbar_N, _modelGVL.GVL_T27.rPressaoHysterese_Bar));

                                        #endregion

                                        devChart.Series.AddRange(new Series[] { series1, series2, series3, series4, PontosChart });
                                    }
                                }
                                catch (Exception ex)
                                {
                                    var err = i;
                                    bCharSeriesOK = false;

                                    MessageBox.Show(ex.Message, _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    throw;
                                }
                            }
                            break;
                        case 28:    //ADAM - Switching Point Without TMC
                            {
                                try
                                {
                                    if (_modelGVL.GVL_Parametros.iTipoGrafico_T28 == 0)
                                    {
                                        #region  Serie de Valores

                                        //GVL_Graficos.strNomeEixoX = "Input Force (N)";
                                        //GVL_Graficos.strNomeEixoY1 = "Pressure PC (bar)";

                                        for (i = 0; i <= totalPointsCount - 1; i++)
                                        {
                                            series1.Points.Add(new SeriesPoint(lstAnalogCh02_InputForce1[i], lstAnalogCh07_PressurePC[i]));
                                        }

                                        #endregion

                                        #region  Serie Pontos de Interesse

                                        //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T28.rForcaReal_P1_N, _modelGVL.GVL_T28.rPressao_P1_Bar));
                                        //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T28.rForcaReal_P2_N, _modelGVL.GVL_T28.rPressao_P2_Bar));
                                        //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T28.rForcaReal_E1_N, _modelGVL.GVL_T28.rPressao_E1_Bar));
                                        //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T28.rForcaReal_E2_N, _modelGVL.GVL_T28.rPressao_E2_Bar));
                                        //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T28.rRunOutForce_Real_N, _modelGVL.GVL_T28.rRunOutPressure_Real_Bar));
                                        //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T28.rForcaCutIn_N, _modelGVL.GVL_T28.rPressaoJumper_Bar));
                                        //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T28.rForcaAvanco_Xpout_N, _modelGVL.GVL_T28.rPressaoHysteresePout_Bar));
                                        //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T28.rForcaRetorno_Xpout_N, _modelGVL.GVL_T28.rPressaoHysteresePout_Bar));
                                        //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T28.rForcaAvanco_Xbar_N, _modelGVL.GVL_T28.rPressaoHysterese_Bar));
                                        //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T28.rForcaRetorno_Xbar_N, _modelGVL.GVL_T28.rPressaoHysterese_Bar));

                                        #endregion

                                        devChart.Series.AddRange(new Series[] { series1, PontosChart });
                                    }
                                    else
                                    {
                                        #region  Serie de Valores

                                        //GVL_Graficos.strNomeEixoX = "Time (s)";
                                        //GVL_Graficos.strNomeEixoY1 = "Input Force (N)";
                                        //GVL_Graficos.strNomeEixoY2 = "Pressure PC (bar)";
                                        //GVL_Graficos.strNomeEixoY3 = "Piston Travel (mm)";
                                        //GVL_Graficos.strNomeEixoY4 = "Diff. Travel (mm)";

                                        for (i = 0; i <= totalPointsCount - 1; i++)
                                        {
                                            series1.Points.Add(new SeriesPoint(lstAnalogCh00_Timestamp[i], lstAnalogCh02_InputForce1[i]));
                                            series2.Points.Add(new SeriesPoint(lstAnalogCh00_Timestamp[i], lstAnalogCh07_PressurePC[i]));
                                            series3.Points.Add(new SeriesPoint(lstAnalogCh00_Timestamp[i], lstAnalogCh05_TravelPiston[i]));
                                            series4.Points.Add(new SeriesPoint(lstAnalogCh00_Timestamp[i], lstAnalogCh01_DiffTravel[i]));
                                        }

                                        #endregion

                                        #region  Serie Pontos de Interesse

                                        //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T28.rForcaReal_P1_N, _modelGVL.GVL_T28.rPressao_P1_Bar));
                                        //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T28.rForcaReal_P2_N, _modelGVL.GVL_T28.rPressao_P2_Bar));
                                        //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T28.rForcaReal_E1_N, _modelGVL.GVL_T28.rPressao_E1_Bar));
                                        //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T28.rForcaReal_E2_N, _modelGVL.GVL_T28.rPressao_E2_Bar));
                                        //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T28.rRunOutForce_Real_N, _modelGVL.GVL_T28.rRunOutPressure_Real_Bar));
                                        //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T28.rForcaCutIn_N, _modelGVL.GVL_T28.rPressaoJumper_Bar));
                                        //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T28.rForcaAvanco_Xpout_N, _modelGVL.GVL_T28.rPressaoHysteresePout_Bar));
                                        //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T28.rForcaRetorno_Xpout_N, _modelGVL.GVL_T28.rPressaoHysteresePout_Bar));
                                        //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T28.rForcaAvanco_Xbar_N, _modelGVL.GVL_T28.rPressaoHysterese_Bar));
                                        //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T28.rForcaRetorno_Xbar_N, _modelGVL.GVL_T28.rPressaoHysterese_Bar));

                                        #endregion

                                        devChart.Series.AddRange(new Series[] { series1, series2, series3, series4, PontosChart });
                                    }
                                }
                                catch (Exception ex)
                                {
                                    var err = i;
                                    bCharSeriesOK = false;

                                    MessageBox.Show(ex.Message, _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    throw;
                                }
                            }
                            break;
                        case 29:    //Bleed
                            {
                                try
                                {
                                    #region  Serie de Valores

                                    //GVL_Graficos.strNomeEixoX = "Time (s)";
                                    //GVL_Graficos.strNomeEixoY1 = "Input Force (N)";
                                    //GVL_Graficos.strNomeEixoY2 = "Pressure PC (bar)";
                                    //GVL_Graficos.strNomeEixoY3 = "Pressure SC (bar)";

                                    for (i = 0; i <= totalPointsCount - 1; i++)
                                    {
                                        series1.Points.Add(new SeriesPoint(lstAnalogCh00_Timestamp[i], lstAnalogCh02_InputForce1[i]));
                                        series2.Points.Add(new SeriesPoint(lstAnalogCh00_Timestamp[i], lstAnalogCh07_PressurePC[i]));
                                        series3.Points.Add(new SeriesPoint(lstAnalogCh00_Timestamp[i], lstAnalogCh06_PressureSC[i]));
                                    }

                                    #endregion

                                    #region  Serie Pontos de Interesse

                                    //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T29.rForcaReal_P1_N, _modelGVL.GVL_T29.rPressao_P1_Bar));
                                    //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T29.rForcaReal_P2_N, _modelGVL.GVL_T29.rPressao_P2_Bar));
                                    //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T29.rForcaReal_E1_N, _modelGVL.GVL_T29.rPressao_E1_Bar));
                                    //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T29.rForcaReal_E2_N, _modelGVL.GVL_T29.rPressao_E2_Bar));
                                    //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T29.rRunOutForce_Real_N, _modelGVL.GVL_T29.rRunOutPressure_Real_Bar));
                                    //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T29.rForcaCutIn_N, _modelGVL.GVL_T29.rPressaoJumper_Bar));
                                    //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T29.rForcaAvanco_Xpout_N, _modelGVL.GVL_T29.rPressaoHysteresePout_Bar));
                                    //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T29.rForcaRetorno_Xpout_N, _modelGVL.GVL_T29.rPressaoHysteresePout_Bar));
                                    //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T29.rForcaAvanco_Xbar_N, _modelGVL.GVL_T29.rPressaoHysterese_Bar));
                                    //PontosChart.Points.Add(new SeriesPoint(_modelGVL.GVL_T29.rForcaRetorno_Xbar_N, _modelGVL.GVL_T29.rPressaoHysterese_Bar));

                                    #endregion

                                    devChart.Series.AddRange(new Series[] { series1, series2, series3, PontosChart });
                                }
                                catch (Exception ex)
                                {
                                    var err = i;
                                    bCharSeriesOK = false;

                                    MessageBox.Show(ex.Message, _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    throw;
                                }
                            }
                            break;
                        default:
                            break;
                    }

                    #endregion
                }

                bCharSeriesOK = true;
            }
            catch (Exception ex)
            {
                var err = ex.Message;
                bCharSeriesOK = false;
                throw;
            }

            return bCharSeriesOK;
        }
        private bool CHART_ExportImage()
        {
            try
            {
                if (HelperTestBase.currentProjectTest.PrjTestFileName != null)
                {
                    string dirReportChartImagePath = System.IO.Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, _helperApp.AppPath_ChartImageTests);

                    string fileName = HelperTestBase.currentProjectTest.PrjTestFileName.Replace(_initialDirPathTestFile, "").Replace(_helperApp.AppTests_DefaultExtension, _helperApp.AppPath_ChartImageExtension);

                    string dirReportChartImagehWithFileName = string.Concat(dirReportChartImagePath, fileName);

                    if (_helperApp.CheckFileExists(dirReportChartImagehWithFileName))
                        File.Delete(dirReportChartImagehWithFileName);

                    devChart.ExportToImage(dirReportChartImagehWithFileName, ImageFormat.Jpeg);
                }
                else
                {
                    MessageBox.Show("Failed, currentProjectTest NOT NAME !", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
                throw;
            }

            return true;
        }

        //Metodo para maracaco de X no chart
        public void CHART_PointsAnnottion(GVL_Graficos modelChartGVL)
        {
            try
            {
                var helperTestBase = HelperTestBase.Model_GVL.helperTestBase_ModelGVL_Test;

                var dictXMarkedPoint = modelChartGVL.dictXMarkedPoint;
                var dictYMarkedPoint = modelChartGVL.dictYMarkedPoint;

                List<double> lstMarkedPoint_X = modelChartGVL.lstMarkedPoint_X;
                List<double> lstMarkedPoint_Y = modelChartGVL.lstMarkedPoint_Y;
                List<string> lstMarkedPoint_Name = modelChartGVL.lstMarkedPoint_Name;

                var idxPointX = devChart.Series[0].Points.IndexOf(a => Convert.ToDouble(a.Argument) == 200.067);

                SeriesPoint targetPoint = devChart.Series[0].Points[idxPointX];
                ControlCoordinates coordinates = (devChart.Diagram as XYDiagram2D).DiagramToPoint(targetPoint.Argument, targetPoint.Values[0]);
                Point point = coordinates.Point;

                #region teste
                // Add a text annotation to the chart control's repository.
                devChart.AnnotationRepository.Add(new TextAnnotation("Annotation 1"));

                // And, assign a series point to the annotation's AnchorPoint property.
                // This adds the annotation to the series point's Annotations collection.
                devChart.AnnotationRepository[0].AnchorPoint =
                    new SeriesPointAnchorPoint(devChart.Series[0].Points[35000]);

                // You can get an annotation either via the collection of the element to which it is anchored,
                // or centrally, via the chart control's repository (e.g. by its name).
                TextAnnotation myTextAnnotation =
                    (TextAnnotation)devChart.AnnotationRepository.GetElementByName("Annotation 1");

                // Define the text for the text annotation.
                myTextAnnotation.Text = "<i>Basic</i> <b>HTML</b> <u>is</u> <color=blue>supported</color>.";

                #endregion

                #region OK

                //// Create a text annotation. 
                //SeriesPoint sp = devChart.Series[0].Points[idxPointX];
                //TextAnnotation annotation = new TextAnnotation("Annotation 1", "test");

                //// Change the text annotation font style to bold.  
                //if (annotation != null)
                //    annotation.Font = new Font(annotation.Font.FontFamily, annotation.Font.Size, FontStyle.Bold);

                //// Specify the text annotation position. 
                //annotation.AnchorPoint = new SeriesPointAnchorPoint(sp);
                //annotation.ShapePosition = new RelativePosition();
                //RelativePosition position = annotation.ShapePosition as RelativePosition;
                //position.ConnectorLength = 50;
                //position.Angle = 90;
                //annotation.RuntimeMoving = true;

                //// Add an annotaion to the annotation repository. 
                //devChart.AnnotationRepository.Add(annotation);

                //// And, assign a series point to the annotation's AnchorPoint property.
                //// This adds the annotation to the series point's Annotations collection.
                //devChart.AnnotationRepository[0].AnchorPoint =
                //    new SeriesPointAnchorPoint(sp);


                //// Define the X and Y absolute coordinates for the annotation, in pixels.
                //if (devChart.Annotations.Count > 0)
                //{
                //    ((ChartAnchorPoint)devChart.Annotations[0].AnchorPoint).X = point.X;
                //    ((ChartAnchorPoint)devChart.Annotations[0].AnchorPoint).Y = point.Y;
                //}

                #endregion

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        #endregion

        #region COM

        #region MODBUS

        #region MODBUS READ DATA DISPLAY DATA SCREEN
        private void MODBUS_DisplayScreenStatusData()
        {
            try
            {
                #region MENU INFO

                #region TEST DISPLAY

                mTile_LCurrentSelectedTest.Text = HelperApp.strNomeTesteSelecionado;

                if (HelperMODBUS.CS_wCicloFinalizado)
                {
                    //HBM_StopContinuousMeasurement("MODBUS_DisplayScreenStatusData");

                    if (!HelperMODBUS.CS_wConfirmacaoCicloFinalizado)
                    {
                        _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_wPartidaGeral }, 0);
                        _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_wConfirmacaoCicloFinalizado }, 1);

                        if (HelperMODBUS.CS_wConfirmacaoCicloFinalizado)
                        {
                            Thread.Sleep(100);

                            string msg = "TEST CONCLUDED";

                            LOG_TestSequence(msg);

                            mTile_LCurrentSelectedTest.Text = msg;

                            MessageBox.Show(msg, _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }

                #endregion

                #region ALARMS / ALERTS

                if (HelperMODBUS.CS_wAlarmeAtivo)
                {
                    int iMensagemAlarme = HelperMODBUS.CS_wMensagemAlarme;
                    mbtn_BAlarm.BackColor = colorAlarm;
                    mbtn_BGlobalWarning.BackColor = colorAlarm;
                    mbtn_BGlobalWarning.Text = _helperMODBUS.HelperMODBUS_DisplayMainMessageAlarm(iMensagemAlarme);
                }
                else
                {
                    int iMensagemAlarme = HelperMODBUS.CS_wMensagemAlarme;
                    mbtn_BAlarm.BackColor = colorOFF;
                    mbtn_BGlobalWarning.BackColor = colorOFF;
                    mbtn_BGlobalWarning.Text = _helperMODBUS.HelperMODBUS_DisplayMainMessageAlarm(iMensagemAlarme);
                }

                if (HelperMODBUS.CS_wAlertaAtivo)
                {
                    int iMensagemAlerta = HelperMODBUS.CS_wMensagemAlerta;
                    mbtn_BAlert.BackColor = colorAlert;
                    mbtn_BGlobalAlert.BackColor = colorAlert;
                    mbtn_BGlobalAlert.Text = _helperMODBUS.HelperMODBUS_DisplayMainMessageAlert(iMensagemAlerta);
                }
                else
                {
                    int iMensagemAlerta = HelperMODBUS.CS_wMensagemAlerta;
                    mbtn_BAlert.BackColor = colorOFF;
                    mbtn_BGlobalAlert.BackColor = colorOFF;
                    mbtn_BGlobalAlert.Text = _helperMODBUS.HelperMODBUS_DisplayMainMessageAlert(iMensagemAlerta);
                }

                #endregion

                #region BUTTONS INFO

                mbtn_BHandshakePLC.BackColor = HelperMODBUS.CS_wHandShakeCLP ? colorON : colorOFF;

                mbtn_BHandshakePC.BackColor = HelperMODBUS.CS_wHandShakePC != 0 ? colorON : colorOFF;

                mbtn_BStart.BackColor = HelperMODBUS.CS_wPartidaGeral ? colorON : colorOFF;

                mbtn_BStop.BackColor = HelperMODBUS.CS_wParadaGeral ? colorON : colorOFF;

                //"Test Running";
                if (HelperMODBUS.CS_wEmCiclo)
                {
                    mbtn_BRun.BackColor = colorON;

                    mbtn_GeneralSettings_BSelectTubeCons.Enabled = false;

                    grpRadConsumer.Enabled = false;
                }
                else
                {
                    mbtn_BRun.BackColor = colorOFF;

                    mbtn_GeneralSettings_BSelectTubeCons.Enabled = true;

                    grpRadConsumer.Enabled = true;
                }

                mbtn_BRecordStart.BackColor = HelperMODBUS.CS_wGravacaoIniciada ? colorON : colorOFF;

                #endregion

                #region RECORD DATA

                //"HBM Data Recording"
                mbtn_BRecording.BackColor = HelperMODBUS.CS_wGravacaoIniciada ? colorON : colorOFF;

                //"EMotor Ref.";
                mbtn_BEMotorRef.BackColor = HelperMODBUS.CS_wEixoReferenciado ? colorOFF : colorON;

                if (HelperMODBUS.CS_wIniciaGravacao)
                {
                    LOG_TestSequence("Evento by CLP - CS_wIniciaGravacao");

                    TEST_DataRecord_Start();
                }
                else
                {
                    //mbtn_BRecordStart.BackColor = colorOFF;
                    Thread.Sleep(50);
                    _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_wGravacaoIniciada }, 0);
                }


                if (HelperMODBUS.CS_wFinalizaGravacao)
                {
                    LOG_TestSequence("Evento by CLP - CS_wFinalizaGravacao");

                    TEST_DataRecord_Stop();
                }
                else
                {
                    mbtn_BRecordStop.BackColor = colorOFF;
                    Thread.Sleep(50);
                    _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_wGravacaoFinalizada }, 0);
                }
                #endregion

                #region CONSUMERS INFO

                HelperTestBase.HoseConsumerPC = HelperMODBUS.CS_wSomaConsumidoresCP;
                HelperTestBase.HoseConsumerSC = HelperMODBUS.CS_wSomaConsumidoresCS;

                mtxt_GeneralSettings_ETubeConsumerPCPressSide.Text = HelperTestBase.HoseConsumerPC.ToString();

                mtxt_GeneralSettings_ETubeConsumerSCPressSide.Text = HelperTestBase.HoseConsumerSC.ToString();

                #endregion

                #endregion
            }
            catch (Exception ex)
            {
                var err = ex.Message;
                _helperMODBUS.HelperMODBUS_AddMessageToDisplayLog(err);
            }
        }
        private bool MODBUS_DisplayMainDataParameters()
        {
            try
            {
                #region Info GVL_Analogicas

                int divfactor = 1000;
                string strDecimalFormat = "N3";

                _modelGVL.GVL_Analogicas.rForcaEntradaBooster_N = ((HelperMODBUS.CS_dwForcaEntradaBooster_N_HW * 65536) + HelperMODBUS.CS_dwForcaEntradaBooster_N_LW) / divfactor;
                _modelGVL.GVL_Analogicas.rForcaSaidaBooster_N = ((HelperMODBUS.CS_dwForcaSaidaBooster_N_HW * 65536) + HelperMODBUS.CS_dwForcaSaidaBooster_N_LW) / divfactor;
                _modelGVL.GVL_Analogicas.rDeslocamentoDiferencial_mm = ((HelperMODBUS.CS_dwDeslocamentoDiferencial_mm_HW * 65536) + HelperMODBUS.CS_dwDeslocamentoDiferencial_mm_LW) / divfactor;
                _modelGVL.GVL_Analogicas.rDeslocamentoEntradaBooster_mm = ((HelperMODBUS.CS_dwDeslocamentoEntradaBooster_mm_HW * 65536) + HelperMODBUS.CS_dwDeslocamentoEntradaBooster_mm_LW) / divfactor;
                _modelGVL.GVL_Analogicas.rDeslocamentoSaidaBooster_mm = ((HelperMODBUS.CS_dwDeslocamentoSaidaBooster_mm_HW * 65536) + HelperMODBUS.CS_dwDeslocamentoSaidaBooster_mm_LW) / divfactor;
                _modelGVL.GVL_Analogicas.rPressaoCP_Bar = ((HelperMODBUS.CS_dwPressaoCP_Bar_HW * 65536) + HelperMODBUS.CS_dwPressaoCP_Bar_LW) / divfactor;
                _modelGVL.GVL_Analogicas.rPressaoCS_Bar = ((HelperMODBUS.CS_dwPressaoCS_Bar_HW * 65536) + HelperMODBUS.CS_dwPressaoCS_Bar_LW) / divfactor;
                _modelGVL.GVL_Analogicas.rPressaoHidraulica_Bar = ((HelperMODBUS.CS_dwPressaoHidraulica_Bar_HW * 65536) + HelperMODBUS.CS_dwPressaoHidraulica_Bar_LW) / divfactor;
                _modelGVL.GVL_Analogicas.rVacuo_Bar = ((HelperMODBUS.CS_dwVacuo_Bar_HW * 65536) + HelperMODBUS.CS_dwVacuo_Bar_LW) / divfactor;
                _modelGVL.GVL_Analogicas.rPressaoBubbleTest_Bar = ((HelperMODBUS.CS_dwPressaoBubbleTest_Bar_HW * 65536) + HelperMODBUS.CS_dwPressaoBubbleTest_Bar_LW) / divfactor;
                _modelGVL.GVL_Analogicas.rTemperaturaAmbiente_C = ((HelperMODBUS.CS_dwTemperaturaAmbiente_C_HW * 65536) + HelperMODBUS.CS_dwTemperaturaAmbiente_C_LW) / divfactor;
                _modelGVL.GVL_Analogicas.rUmidadeRelativa = ((HelperMODBUS.CS_dwUmidadeRelativa_HW * 65536) + HelperMODBUS.CS_dwUmidadeRelativa_LW) / divfactor;

                mtxt_MKSLInputForce1.Text = string.Concat(_modelGVL.GVL_Analogicas.rForcaEntradaBooster_N.ToString(strDecimalFormat), " N");
                mtxt_MKSLOutputForce.Text = string.Concat(_modelGVL.GVL_Analogicas.rForcaSaidaBooster_N.ToString(strDecimalFormat), " N");
                mtxt_MKSLDiffTravel.Text = string.Concat(_modelGVL.GVL_Analogicas.rDeslocamentoDiferencial_mm.ToString(strDecimalFormat), " mm");
                mtxt_MKSLTravelPiston.Text = string.Concat(_modelGVL.GVL_Analogicas.rDeslocamentoEntradaBooster_mm.ToString(strDecimalFormat), " mm");
                mtxt_MKSLTravelTMC.Text = string.Concat(_modelGVL.GVL_Analogicas.rDeslocamentoSaidaBooster_mm.ToString(strDecimalFormat), " mm");
                mtxt_MKSLPressurePC.Text = string.Concat(_modelGVL.GVL_Analogicas.rPressaoCP_Bar.ToString(strDecimalFormat), " bar");
                mtxt_MKSLPressureSC.Text = string.Concat(_modelGVL.GVL_Analogicas.rPressaoCS_Bar.ToString(strDecimalFormat), " bar");
                mtxt_MKSLHydrFillPressure.Text = string.Concat(_modelGVL.GVL_Analogicas.rPressaoHidraulica_Bar.ToString(strDecimalFormat), " bar");
                mtxt_MKSLVaccum.Text = string.Concat(_modelGVL.GVL_Analogicas.rVacuo_Bar.ToString(strDecimalFormat), " bar");
                mtxt_MKSLPneumTestPressure.Text = string.Concat(_modelGVL.GVL_Analogicas.rPressaoBubbleTest_Bar.ToString(strDecimalFormat), " bar");
                mtxt_MKSLRoomTemp.Text = string.Concat(_modelGVL.GVL_Analogicas.rTemperaturaAmbiente_C.ToString(strDecimalFormat), " ºC");
                mtxt_MKSLHumidity.Text = string.Concat(_modelGVL.GVL_Analogicas.rUmidadeRelativa.ToString(strDecimalFormat), " %");

                #endregion
            }
            catch (Exception ex)
            {
                var err = ex.Message;
                _helperMODBUS.HelperMODBUS_AddMessageToDisplayLog(err);
                return false;
            }

            return true;
        }

        #endregion

        #endregion

        #region HBM
        private HelperHBM HBM_Initialize()
        {
            this.RunContinuousMeasurementBt.Enabled = false;
            this.StopContinuousMeasurementBt.Enabled = false;

            try
            {
                while (!_helperHBM.Initialized)
                    _helperHBM = _comHBM.InitializeObjects();


                if (_helperHBM != null)
                {
                    _myDevice = _comHBM._myDevice;
                    _daqMeasurement = _comHBM._daqMeasurement;
                    _signalsToMeasure = _comHBM._signalsToMeasure;
                    _daqEnvironment = _comHBM._daqEnvironment;

                    HBM_ClearBufferAquisitionData();

                    strMessageToDisplayLog = _helperHBM.AddMessageToDisplayLog(_helperHBM.Message);

                    if (_helperHBM.Initialized && _helperHBM.Status)
                        _helperHBM = _comHBM.HbmRegisterEvent();

                    //CONECT SPECIFIC IP  DEVICE
                    if (_helperHBM.RegisterEvent && _helperHBM.Status)
                        while (!_helperHBM.DeviceConnected)
                            _comHBM.ConnectToCertainDevice();
                    else
                    {
                        strMessageToDisplayLog = _helperHBM.AddMessageToDisplayLog(String.Concat("Fail ! - ", _helperHBM.Message));
                        MessageBox.Show(strMessageToDisplayLog);
                        return _helperHBM;
                    }

                    //PREPARE CONTINOUS
                    strMessageToDisplayLog = _helperHBM.AddMessageToDisplayLog(_helperHBM.Message);
                    if (_helperHBM.DeviceConnected && _helperHBM.Status)
                        _helperHBM = _comHBM.PrepareContinuousMeasurement();


                    //START RUN CONTINOUS
                    strMessageToDisplayLog = _helperHBM.AddMessageToDisplayLog(_helperHBM.Message);
                    //if (_helperHBM.PreparedContinuousMeasurement && _helperHBM.Status)
                    //    _comHBM.RunContinuousMeasurement();

                    strMessageToDisplayLog = _helperHBM.AddMessageToDisplayLog(_helperHBM.Message);
                }
                else
                {
                    strMessageToDisplayLog = _helperHBM.AddMessageToDisplayLog("HBM Communication Failed !");


                    MessageBox.Show(strMessageToDisplayLog, _helperApp.appMsg_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, _helperApp.appMsg_Error);
            }

            return _helperHBM;
        }
        private void HBM_ClearBufferAquisitionData()
        {
            if (_helperHBM.Status)
            {
                if (_daqMeasurement != null)
                    HBM_StopContinuousMeasurement("HBM_ClearBufferAquisitionData");

                sbinterno.Clear();
                sbexterno.Clear();
            }
        }
        private void HBM_Disconnect()
        {
            if (_daqMeasurement != null)
                if (_helperHBM.DeviceConnected && _helperHBM.Status)
                {
                    _daqEnvironment.Disconnect(_myDevice);
                    AddToProtocol(string.Format("Device {0} has been disconnected.", _myDevice.Name));
                    AddToProtocol("\n\n\n\n\n\n\n\n\n **************** \n\n\n\n\n\n");
                }
        }
        private void HBM_SaveAquisitionTxtData()
        {
            _strTimeStamp = DateTime.Now.ToString("dd/MM/yyyy - HH:mm:ss.fff", CultureInfo.InvariantCulture);

            LOG_TestSequence("Evento - HBM_ReadValues");

            String path = @"D:\HBM_SaveAquisitionTxtData.txt";
            this.RunContinuousMeasurementBt.Enabled = false;
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

            this.RunContinuousMeasurementBt.Enabled = false;

            string strLinha = string.Empty;

            if (_helperHBM.PreparedContinuousMeasurement && _helperHBM.Status)
            {
                _myDevice = _comHBM._myDevice;
                _daqMeasurement = _comHBM._daqMeasurement;
                _signalsToMeasure = _comHBM._signalsToMeasure;
                _daqEnvironment = _comHBM._daqEnvironment;




                //try
                //{
                try
                {
                    if (!_runMeasurement)
                    {
                        // add the chosen signals to the measurement
                        _daqMeasurement.AddSignals(_myDevice, _signalsToMeasure);

                        _daqMeasurement.PrepareDaq(5000, 10, 1000, false, false);

                        // run continuous measurement with the signals that were added to the measurement
                        // if (_signalsToMeasure.Count > 0)
                        _daqMeasurement.StartDaq(DataAcquisitionMode.TimestampSynchronized); //DataAcquisitionMode.Unsynchronized

                        _runMeasurement = true;
                    }
                    this.StopContinuousMeasurementBt.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, ex.ToString());
                    this.StopContinuousMeasurementBt.PerformClick();
                }

                //try
                //{
                if (_runMeasurement)
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
                        try
                        {
                            signal = _signalsToMeasure[k];

                            // this is the way you get the measurement values (as doubles) from ALL signals (no matter what type of signal)
                            // that take part in the measurement (check Signal.ContinuousMeasurementValues)
                            if (signal.ContinuousMeasurementValues.UpdatedValueCount > 0)
                            {
                                //AddToProtocol("-------------------------");

                                //var data = string.Format("CH {0} has {1} new measurement values",
                                //                            signal.Name,
                                //                            signal.ContinuousMeasurementValues.UpdatedValueCount //Number of new measurement values filled into Values[0..n]
                                //                            );

                                //AddToProtocol(data);       //this is an array of doubles containing the measurement values

                                //// have a look at the continuousMeasurementValues in the property grid (see tab "MeasurementValues...") during execution
                                //MeasurmentValuesPg.SelectedObject = signal.ContinuousMeasurementValues;

                                formTimestamp = DateTime.Now.ToString("dd/MM/yyyy-HH:mm:ss.ffff",
                                        CultureInfo.InvariantCulture);

                                string nms = signal.Name;


                                lstStrTimestamp.Clear();
                                lstTms.Clear();
                                lstVal.Clear();
                                lstTmsCh.Clear();

                                iUpdatedValueCount = signal.ContinuousMeasurementValues.UpdatedValueCount;
                                lstTms = signal.ContinuousMeasurementValues.Timestamps.ToList();
                                lstVal = signal.ContinuousMeasurementValues.Values.ToList();


                                lstCh[k] = new List<double>();

                                for (i = 1; i < iUpdatedValueCount - 1; i++)
                                {
                                    lstCh[k].Add(Math.Round(lstVal[i], 3));
                                    lstTmsCh.Add(Math.Round(lstTms[i], 5));
                                    //lstStrTimestamp.Add(formTimestamp);

                                    //lstTmsCh.Add(Math.Round(lstTms[i],4));
                                }
                            }

                        }
                        catch (Exception ex)
                        {
                            var abc = k;
                            MessageBox.Show(ex.Message, _helperApp.appMsg_Error);
                        }
                    }

                    int idx = 0;

                    try
                    {
                        lstStrCh.Clear();
                        //lstTmsCh.Clear();

                        //lstTmsCh = lstTms;

                        if (lstCh[0].Count() < iUpdatedValueCount)
                            iUpdatedValueCount = lstCh[0].Count() - 1;

                        try
                        {
                            for (j = 0; j < iUpdatedValueCount; j++)
                            {
                                idx = j;

                                string row = string.Empty;

                                //row = string.Format("{0}\t\t" +
                                //"{1}\t\t {2}\t\t {3}\t\t {4}\t\t {5}\t\t {6}\t\t " +
                                //"{7}\t\t {8}\t\t {9}\t\t {10}\t\t {11}\t\t {12}\t\t\n ",

                                row = string.Format("{0}\t" +
                               "{1}\t{2}\t{3}\t{4}\t{5}\t{6}\t" +
                               "{7}\t{8}\t{9}\t{10}\t{11}\t{12}\t",

                               lstTmsCh[j].ToString(),
                                lstCh[0][j].ToString(), lstCh[1][j].ToString(), lstCh[2][j].ToString(), lstCh[3][j].ToString(), lstCh[4][j].ToString(), lstCh[5][j].ToString(),
                                lstCh[6][j].ToString(), lstCh[7][j].ToString(), lstCh[8][j].ToString(), lstCh[9][j].ToString(), lstCh[10][j].ToString(), lstCh[11][j].ToString());

                                lstStrCh.Add(row + Environment.NewLine);

                                if (lstStrCh.Count() > 0)
                                    sbinterno.Append(row + Environment.NewLine);

                            }

                            if (lstStrCh.Count() > 0)
                            {
                                sbexterno.Append(sbinterno.ToString());
                                sbinterno.Clear();
                            }


                            var sbMaxCap = (sbexterno.MaxCapacity * 0.1);

                            if (sbexterno.Length > sbMaxCap)
                                TXTFileHBM_Create();
                        }
                        catch (Exception ex)
                        {
                            var err = string.Concat("ex : ", idx, ex.Message);

                            throw;
                        }

                        timerHBM.Enabled = true;
                    }
                    catch (Exception ex)
                    {
                        var err = string.Concat("nuemro : ", idx, ex.Message);

                        throw;
                    }
                }
                else
                {
                    timerHBM.Enabled = false;
                }
                //    }
                //        catch (Exception ex)
                //    {
                //        MessageBox.Show(ex.Message, ex.ToString());
                //        this.StopContinuousMeasurementBt.PerformClick();
                //    }
                //}
                //catch (Exception ex)
                //{
                //    MessageBox.Show(ex.Message, ex.ToString());
                //    this.StopContinuousMeasurementBt.PerformClick();
                //}

            }
        }

        //todo
        private void HBM_SaveAquisitionTxtData_OLD()
        {
            try
            {
                _prjTestFilename = HelperTestBase.currentProjectTest.PrjTestFileName;

                List<string> lstChNames = new List<string>();

                if (_helperHBM.PreparedContinuousMeasurement && _helperHBM.Status)
                {
                    if (!_helperHBM.RunningContinuousMeasurement)
                    {
                        //_comHBM.RunContinuousMeasurement();

                        _prjTestFilename = string.Concat(_initialDirPathTestFile, "HBM_LUCAS.txt");

                        _comHBM.HBM_SaveRunContinuousMeasurement(_prjTestFilename, lstChNames);

                        HelperTestBase.currentProjectTest.is_Created = _helperApp.CheckFileExists(_prjTestFilename);
                    }
                    else
                        MessageBox.Show("HBM_SaveAquisitionTxtData - HBM RunContinuous Measurement Data acquisition is already running !", _helperApp.appMsg_Error, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("HBM Communication Failed !", _helperApp.appMsg_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, _helperApp.appMsg_Error);
            }

            try
            {
                ////Força Pressao variavies
                /////$"Time [s]\t Input Force 1 [N]\t Input Travel [m]\t Hydraulic Pressure PC [bar]\t Hydraulic Pressure SC [bar]");
                HelperTestBase.strTimeStamp = _strTimeStamp; //HelperHBM.strTimeStamp;  //string formatada
                //HelperTestBase.strTimeStamp = HelperHBM.rTimeStamp.ToString();  //value double

                HelperTestBase.dblAnalogVar01 = HelperHBM.rInputForce1;
                HelperTestBase.dblAnalogVar02 = HelperHBM.rTravelPiston;
                HelperTestBase.dblAnalogVar03 = HelperHBM.rPressurePC;
                HelperTestBase.dblAnalogVar04 = HelperHBM.rPressureSC;

                _prjTestFilename = string.Concat(_initialDirPathTestFile, "HBM_SaveAquisitionTxtData.txt");

                using (StreamWriter sw = new StreamWriter(_prjTestFilename, true, Encoding.UTF8, 65536))
                {
                    string finalString = $"{HelperTestBase.strTimeStamp};\t\t\t{ HelperTestBase.dblAnalogVar01};\t\t\t{HelperTestBase.dblAnalogVar02};\t\t\t{HelperTestBase.dblAnalogVar03};\t\t\t{HelperTestBase.dblAnalogVar04};" + "\r\n";

                    sw.WriteLine(finalString);
                }

                HelperTestBase.currentProjectTest.is_Created = _helperApp.CheckFileExists(_prjTestFilename);

                //_helperApp.AquisitionTxtData(HelperTestBase.strTimeStamp, HelperTestBase.dblAnalogVar01, HelperTestBase.dblAnalogVar02, HelperTestBase.dblAnalogVar03, HelperTestBase.dblAnalogVar04);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, _helperApp.appMsg_Error);
            }
        }
        private void HBM_StartRunContinousRead()
        {
            //try
            //{
            //    List<string> lstChNames = new List<string>();
            //    _prjTestFilename = HelperTestBase.currentTestFile.PrjTestFileName;

            //    _comHBM.HBM_SaveRunContinuousMeasurement(_prjTestFilename, lstChNames);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, _helperApp.appMsg_Error);
            //}
        }
        private void HBM_StopContinuousMeasurement(string info)
        {
            AddToProtocol(info);

            try
            {
                this.StopContinuousMeasurementBt.Enabled = false;
                timerHBM.Enabled = false;
                HelperTestBase.running = false;

                try
                {
                    // stop running data acquisition
                    _runMeasurement = false;
                    _daqMeasurement.StopDaq();
                    AddToProtocol("Continuous measuring stopped!");

                    AddToProtocol("\n\n\n\n\n\n\n\n\n **************** \n\n\n\n\n\n");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, ex.ToString());

                }

                // sbexterno.Clear();
                this.PrepareContinuousMeasurementBt.Enabled = true;

                //if (_helperHBM.PreparedContinuousMeasurement && _helperHBM.Status)
                //    if (!_helperHBM.RunningContinuousMeasurement)
                //    {
                //        _comHBM.StopContinuousMeasurement(_prjTestFilename);
                //    }
                //    else
                //        MessageBox.Show("HBM_StopContinuousMeasurement - HBM RunContinuous Measurement Data acquisition is already running !", _helperApp.appMsg_Error, MessageBoxButtons.OK, MessageBoxIcon.Information);
                //else
                //    MessageBox.Show("HBM Communication Failed !", _helperApp.appMsg_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, _helperApp.appMsg_Error);
            }
        }

        #endregion

        #region HBM MAIN

        #region Global variables

        // Variables used to show the general workflow 
        private DaqEnvironment _daqEnvironment;   // main object to scan, connect and parameterize devices
        private DaqMeasurement _daqMeasurement;   // main object to execute measurements
        private Device _myDevice;         // device to connect and to use within this demo
        private List<Signal> _signalsToMeasure; // list of signals to use for a continuous measurement
        private bool _runMeasurement;   // true, while data acquisition is running...
        private List<Device> _deviceList;       // list of devices found by the scan

        private delegate void VisualizeDeviceEventHandler(DeviceEventArgs e); // delegate for our event handling

        // Sensor data base access
        private ISensorDB _sensorDBManagerForHbmSensorDatabase;  // sensor manager, used to access the HBM sensor database 
        private ISensorDB _sensorDBManagerForUserSensorDatabase; // sensor manager, used to access a user sensor database

        // Logging
        private ILogger _logger;                     // a logger object that can be used to log messages
        private LogContext _logContextApiDemoMeasuring; // context to log messages in a hierarchical way here: Messages related to measurement issues

        private LogContext
            _logContextApiDemoProblems; // context to log messages in a hierarchical way here: Messages related to problems that occurred during the execution of the demo

        private int _logNumberDummy = 0; // just a counter used to generate different log entries...

        StringBuilder sbinterno = new StringBuilder();
        StringBuilder sbexterno = new StringBuilder();

        #endregion

        #region Principle workflow and measurement

        /// <summary>
        /// Initialize objects that support scanning, parameterizing and measuring
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event arguments</param>
        private void InitializeObjectsBt_Click(object sender, EventArgs e)
        {
            try
            {
                _daqEnvironment = DaqEnvironment.GetInstance(); //DaqEnvironment is a singleton
                _daqMeasurement = new DaqMeasurement();
                AddToProtocol("DaqEnvironment and DaqMeasurement objects initialized");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.ToString());
            }
        }

        /// <summary>
        /// Register handler for "DeviceConnected" event
        /// DeviceConnected events will be fired asynchronously each time a device is successfully connected
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event arguments</param>
        private void btnRegisterEvent_Click(object sender, EventArgs e)
        {
            try
            {
                //MessageBroker handles all events of the common API.
                MessageBroker.DeviceConnected += MessageBroker_DeviceConnected;
                MessageBroker.DeviceDisconnected += MessageBroker_DeviceDisconnected;
                AddToProtocol("Device event handlers registered");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.ToString());
            }
        }

        #region --- Event stuff

        /// <summary>
        /// DeviceConnected event handler
        /// </summary>
        void MessageBroker_DeviceConnected(object sender, DeviceEventArgs e)
        {
            // Show info in our console
            UpdateConsoleDeviceConnected(e);
        }

        /// <summary>
        /// DeviceDisconnected event handler
        /// </summary>
        void MessageBroker_DeviceDisconnected(object sender, DeviceEventArgs e)
        {
            // Show info in our console
            UpdateConsoleDeviceDisConnected(e);
        }

        /// <summary>
        /// Show connected info
        /// </summary>
        private void UpdateConsoleDeviceConnected(DeviceEventArgs e)
        {
            if (ProtocolTb.InvokeRequired)
            {
                // Call this method again but on the GUI thread
                ProtocolTb.Invoke(new VisualizeDeviceEventHandler(UpdateConsoleDeviceConnected), new object[] { e });
            }
            else
            {
                AddToProtocol("Connected to device: " + e.UniqueDeviceID);
            }
        }

        /// <summary>
        /// Show disconnected info
        /// </summary>
        private void UpdateConsoleDeviceDisConnected(DeviceEventArgs e)
        {
            if (ProtocolTb.InvokeRequired)
            {
                // Call this method again but on the GUI thread
                ProtocolTb.Invoke(new VisualizeDeviceEventHandler(UpdateConsoleDeviceDisConnected), new object[] { e });
            }
            else
            {
                AddToProtocol("DisConnected from device: " + e.UniqueDeviceID);
            }
        }

        #endregion

        /// <summary>
        /// Adds a given string to the protocol
        /// </summary>
        /// <param name="message">Message to add</param>
        private void AddToProtocol(string message)
        {
            ProtocolTb.AppendText(message + Environment.NewLine);
        }

        /// <summary>
        /// Connect to a device without using scan (e.g. MGC devices do not support scan)
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event arguments</param> 
        private void ConnectToCertainDevice_Click(object sender, EventArgs e)
        {
            try
            {
                List<Problem> problemList = new List<Problem>();

                // To connect a device without using the results of the scan, you have to define at least the
                // type of the device and its IP address. E.g.:

                //_myDevice = new PmxDevice();
                //_myDevice.ConnectionInfo = new EthernetConnectionInfo("172.19.191.113",55000);
                // or:
                _myDevice = new PmxDevice("192.168.0.20"); //this constructor uses the PMX default port (55000)

                //_myDevice = new MgcDevice();
                //_myDevice.ConnectionInfo = new EthernetConnectionInfo("172.19.169.133",7);
                // or:
                //_myDevice = new MgcDevice("172.19.169.133"); //this constructor uses the MGCplus default port (7)

                //_myDevice = new QuantumXDevice();
                //_myDevice.ConnectionInfo = new StreamingConnectionInfo("172.19.191.113",5001,7411,80);
                // or:
                // _myDevice = new QuantumXDevice("172.19.202.19"); //this constructor uses the QuantumX default port (5001), 

                //its default streaming port (7411) and its default HTTP port (80)

                //_myDevice = new MgcDevice("172.19.169.133");
                if (_daqEnvironment.Connect(_myDevice, out problemList)) //connect the defined device
                {
                    // when a device is connected, the complete object representation of the device is available
                    // break here and check _deviceList[0] against e.g. _deviceList[1] to see the difference
                    AddToProtocol(string.Format("Device {0} is connected;  It has {1} connectors", _myDevice.Name, _myDevice.Connectors.Count));
                }
                else
                {
                    //there occurred errors during connect to the device
                    AddToProtocol("Connection to device failed!");

                    foreach (Problem problem in problemList)
                    {
                        AddToProtocol(problem.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.ToString());
            }
        }

        /// <summary>
        /// Prepares a continuous measurement
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event arguments</param>
        private void PrepareContinuousMeasurementBt_Click(object sender, EventArgs e)
        {
            this.PrepareContinuousMeasurementBt.Enabled = false;
            this.RunContinuousMeasurementBt.Enabled = false;
            this.StopContinuousMeasurementBt.Enabled = false;

            try
            {
                // prepare a continuous measurement with 1 signal
                // use the first signals of the first  connector of the device
                //_signalsToMeasure = new List<Signal>();
                //_signalsToMeasure.Add(_myDevice.Connectors[0].Channels[0].Signals[0]);
                List<Signal> lstSignalCalculetedChannels = new List<Signal>();

                _signalsToMeasure = new List<Signal>();

                for (int i = 0; i < 12; i++)
                    lstSignalCalculetedChannels.Add(_myDevice.Connectors[16 + i].Channels[0].Signals[0]);

                _signalsToMeasure.Add(_myDevice.Connectors[0].Channels[0].Signals[0]);

                if (_signalsToMeasure?.Count > 0)
                    _signalsToMeasure = lstSignalCalculetedChannels;

                // try adding some more signals to the measurement....:
                //_signalsToMeasure.Add(_myDevice.Connectors[1].Channels[0].Signals[0]);

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
                AddToProtocol("Added " + _signalsToMeasure.Count + " signals to the measurement.");

                // prepare data acqusisition;
                //_daqMeasurement.PrepareDaq(); // use standard parameters
                // or: setup certain features of the measurement:
                _daqMeasurement.PrepareDaq(5000, 10, 1000, false, false);

                // try overloaded version of PrepareDaq ( e.g. to control number of filled timestamps- default is "timeStamp for the first measurement value only")
                //_daqMeasurement.PrepareDaq(2400, 1, 2400, false, false);// use this to get a timeStamp and a status for each measurement value
                AddToProtocol("Measurement is prepared.");

                this.RunContinuousMeasurementBt.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.ToString());
            }
        }

        /// <summary>
        /// Runs continuous measurement with the signals that were added to the measurement
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event arguments</param>
        /// 
        public void originalrun()
        {
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
        }

        private void RunContinuousMeasurementBt_Click(object sender, EventArgs e)
        {

            timerHBM.Enabled = true;

            //    String path = @"D:\HBM_SaveAquisitionTxtData.txt";
            //    this.RunContinuousMeasurementBt.Enabled = false;
            //    List<string> lstStr = new List<string>();
            //    string formTimestamp = string.Empty;

            //    List<double> lstTms = new List<double>();
            //    List<double> lstVal = new List<double>();

            //    List<string> lstStrCh = new List<string>();
            //    List<string> lstStrTimestamp = new List<string>();
            //    List<double> lstTmsCh = new List<double>();
            //    List<double>[] lstCh = new List<double>[12];

            //    int iUpdatedValueCount = 0;
            //    int k = 0;
            //    int i = 0;
            //    int j = 0;

            //    this.RunContinuousMeasurementBt.Enabled = false;


            //    string strLinha = string.Empty;

            //    try
            //    {
            //        // run continuous measurement with the signals that were added to the measurement
            //        _daqMeasurement.StartDaq(DataAcquisitionMode.TimestampSynchronized); //DataAcquisitionMode.Unsynchronized
            //        _runMeasurement = true;

            //        this.StopContinuousMeasurementBt.Enabled = true;

            //        if (_runMeasurement)
            //        {
            //            // update measurement values of the signals that were added to the measurement:
            //            _daqMeasurement.FillMeasurementValues();

            //            // FillMeasurements updates the ContinuousMeasurementValues of all signals that
            //            // were added to the measurement
            //            // The next call of FillMeasurementValues will overwrite them again with new values....

            //            // check the signals that were added to the measurement for new measurement values...
            //            //foreach (Signal signal in _signalsToMeasure)
            //            //{
            //            for (k = 0; k < _signalsToMeasure.Count; k++)
            //            {
            //                Signal signal = _signalsToMeasure[k];

            //                // this is the way you get the measurement values (as doubles) from ALL signals (no matter what type of signal)
            //                // that take part in the measurement (check Signal.ContinuousMeasurementValues)
            //                if (signal.ContinuousMeasurementValues.UpdatedValueCount > 0)
            //                {
            //                    AddToProtocol("-------------------------");

            //                    var data = string.Format("Signal {0} has {1} new measurement values \r\nFirst timestamp={2} \r\nFirst measval={3}",
            //                                                signal.Name,
            //                                                signal.ContinuousMeasurementValues.UpdatedValueCount, //Number of new measurement values filled into Values[0..n]
            //                                                signal.ContinuousMeasurementValues.Timestamps,     //Timestamps for measurement values
            //                                                signal.ContinuousMeasurementValues.Values);

            //                    AddToProtocol(data);       //this is an array of doubles containing the measurement values

            //                    // have a look at the continuousMeasurementValues in the property grid (see tab "MeasurementValues...") during execution
            //                    MeasurmentValuesPg.SelectedObject = signal.ContinuousMeasurementValues;

            //                    formTimestamp = DateTime.Now.ToString("dd/MM/yyyy-HH:mm:ss.ffff",
            //                            CultureInfo.InvariantCulture);

            //                    string nms = signal.Name;


            //                    lstStrTimestamp.Clear();
            //                    lstTms.Clear();
            //                    lstVal.Clear();

            //                    iUpdatedValueCount = signal.ContinuousMeasurementValues.UpdatedValueCount;
            //                    lstTms = signal.ContinuousMeasurementValues.Timestamps.ToList();
            //                    lstVal = signal.ContinuousMeasurementValues.Values.ToList();


            //                    lstCh[k] = new List<double>();

            //                    for (i = 1; i < iUpdatedValueCount - 1; i++)
            //                    {
            //                        lstCh[k].Add(lstVal[i]);
            //                        lstStrTimestamp.Add(formTimestamp);
            //                    }
            //                }
            //                else
            //                {
            //                    _myDevice.ReadSingleMeasurementValue(new List<Signal>() { signal });

            //                    // get a measurement value from all signals of the device:
            //                    //_myDevice.ReadSingleMeasurementValueOfAllSignals();

            //                    double dblSigValue = signal.GetSingleMeasurementValue().Value;
            //                    string strSigValue = dblSigValue.ToString("F3");

            //                    AddToProtocol(string.Format("Measurement value of first signal={0}", strSigValue));
            //                    AddToProtocol(string.Format("Timestamp of first signal={0}", signal.GetSingleMeasurementValue().Timestamp));

            //                    double dblTime = signal.GetSingleMeasurementValue().Timestamp;

            //                    //TimeSpan t = TimeSpan.FromMilliseconds(dblTime);
            //                    //string answer = string.Format("{0:D2}h:{1:D2}m:{2:D2}s:{3:D3}ms",
            //                    //        t.Hours,
            //                    //        t.Minutes,
            //                    //        t.Seconds,
            //                    //        t.Milliseconds);

            //                    //DateTime dt = DateTime.Now + t;
            //                    //var tmestamp = dt.ToString();

            //                    //DateTime dt1 = new DateTime().Add(TimeSpan.FromMilliseconds(dblTime));

            //                    string timestamp = DateTime.Now.ToString("dd/MM/yyyy - HH:mm:ss.fff",
            //                                    CultureInfo.InvariantCulture);


            //                    AddToProtocol(string.Format("Timestamp of first signal={0}", timestamp));

            //                    MeasurmentValuesPg.SelectedObject = signal.ContinuousMeasurementValues;
            //                }

            //                // With ComnmonAPI V6.0 it is possible to measure GenericSignals. Until now the only genericSignal that is implemented is
            //                // the CanRawSignal, which delivers CanRawMessages as measurement values. Generic signals support an ADDITIONAL way to get measurement values
            //                // of a certain type (here:CanRawMessages instead of doubles, which are however also filled for GenericSignals in a special way to keep the used way
            //                // of getting measurement values also working)
            //                // AccessMeasurementValuesOfGenericSignal(signal);
            //            }


            //            int idx = 0;

            //            try
            //            {
            //                lstStrCh.Clear();
            //                lstTmsCh.Clear();

            //                lstTmsCh = lstTms;

            //                if (lstCh[0].Count() < iUpdatedValueCount)
            //                    iUpdatedValueCount = lstCh[0].Count() - 1;

            //                try
            //                {


            //                    for (j = 0; j < iUpdatedValueCount; j += 2)
            //                    {
            //                        idx = j;

            //                        string row = string.Empty;

            //                        row = string.Format("{0}\t\t" +
            //                        "{1}\t\t {2}\t\t {3}\t\t {4}\t\t {5}\t\t {6}\t\t " +
            //                        "{7}\t\t {8}\t\t {9}\t\t {10}\t\t {11}\t\t {12}\t\t\n ",
            //                        lstTmsCh[j].ToString(),
            //                        lstCh[0][j].ToString(), lstCh[1][j].ToString(), lstCh[2][j].ToString(), lstCh[3][j].ToString(), lstCh[4][j].ToString(), lstCh[5][j].ToString(),
            //                        lstCh[6][j].ToString(), lstCh[7][j].ToString(), lstCh[8][j].ToString(), lstCh[9][j].ToString(), lstCh[10][j].ToString(), lstCh[11][j].ToString());

            //                        lstStrCh.Add(row);

            //                        if (lstStrCh.Count() > 0)
            //                            sbinterno.Append(row);

            //                    }

            //                    if (lstStrCh.Count() > 0)
            //                    {
            //                        sbexterno.Append(sbinterno.ToString());
            //                        sbinterno.Clear();
            //                    }


            //                    var sbMaxCap = (sbexterno.MaxCapacity * 0.1);

            //                    if (sbexterno.Length > sbMaxCap)
            //                    {
            //                        if (!File.Exists(path))
            //                            File.WriteAllText(path, sbexterno.ToString());
            //                        else
            //                            File.AppendAllLines(path, sbexterno.ToString().Split(Environment.NewLine.ToCharArray()));

            //                        sbexterno.Clear();
            //                    }
            //                    else
            //                        sbexterno.Append(lstStrCh);

            //                }
            //                catch (Exception ex)
            //                {
            //                    var err = string.Concat("ex : ", idx, ex.Message);

            //                    throw;
            //                }

            //                //Application.DoEvents(); // respond to GUI events

            //                System.Threading.Thread.Sleep(500);
            //            }
            //            catch (Exception ex)
            //            {
            //                var err = string.Concat("nuemro : ", idx, ex.Message);

            //                throw;
            //            }
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show(ex.Message, ex.ToString());
            //        this.StopContinuousMeasurementBt.PerformClick();
            //    }
        }

        /// <summary>
        /// Handles CanRawMessages of GenericSignal (CanRawSignal)
        /// </summary>
        /// <param name="signal">Signal whose generic measurement values should be displayed</param>
        private void AccessMeasurementValuesOfGenericSignal(Signal signal)
        {
            if (!(signal is IGenericSignal genericSignal))
            {
                // this is a normal signal (not a generic signal like CanRawSignal)
                // => nothing to do here...
                GenericMeasurementValuesPg.SelectedObject = null;
                //CANRawMessagePg.SelectedObject = null;

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
                AddToProtocol($"Signal {signal.Name} has {canRawMeasurementValues.UpdatedValueCount} new CanRawMessages \r\n1.timestamp={canRawMeasurementValues.Timestamps[0]} \r\n1.CanMessageTimestamp = {canRawMeasurementValues.Values[0].Timestamp} \r\nHeader = {canRawMeasurementValues.Values[0].Header}");

                // Build Hex-string of the concatenated payloads...64Byte (always CanFD)
                StringBuilder sb = new StringBuilder();

                for (int i = 0; i < 64; i += 8)
                {
                    sb.Clear();

                    for (int ii = 0; ii < 8; ii++)
                    {
                        sb.Append($" {canRawMeasurementValues.Values[0].Payload[i + ii]:x2}");
                    }

                    AddToProtocol($"Payload[{i} - {i + 7}] = {sb.ToString()}");
                }

                // show data in the property grid
                GenericMeasurementValuesPg.SelectedObject = canRawMeasurementValues; //the genericMeasurementValues of the signal (has to be a CanRawSignal in this case)
                //CANRawMessagePg.SelectedObject = canRawMeasurementValues.Values[0]; //first CanRawMessage (in this case Values[0] is NOT just a double but a CanRawMessage object)
                //CANRawMessagePg.ExpandAllGridItems();

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
        private void StopContinuousMeasurementBt_Click(object sender, EventArgs e)
        {
            HBM_StopContinuousMeasurement("StopContinuousMeasurementBt_Click");
        }

        /// <summary>
        /// Disconnects the device
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event arguments</param>
        private void DisconnectDeviceBt_Click(object sender, EventArgs e)
        {
            if (_runMeasurement)
            {
                this.StopContinuousMeasurementBt.PerformClick();
            }

            try
            {
                // disconnect the device
                _daqEnvironment.Disconnect(_myDevice);
                AddToProtocol(string.Format("Device {0} has been disconnected.", _myDevice.Name));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.ToString());
            }
        }

        /// <summary>
        /// Ends the demo and disposes DaqEnvironment
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event arguments</param>
        private void EndDemoBt_Click(object sender, EventArgs e)
        {
            // Unregister event handlers
            MessageBroker.DeviceConnected -= MessageBroker_DeviceConnected;
            MessageBroker.DeviceDisconnected -= MessageBroker_DeviceDisconnected;
            AddToProtocol("Device event handlers deregistered");

            if (_daqEnvironment != null)
            {
                _daqEnvironment.Dispose(); //clean up underlying DLLs
            }

            AddToProtocol("DaqEnvironment.Dispose() has been called. Program ends now.");
            MessageBox.Show("OK to end program");
            this.Close();
        }

        #endregion

        #endregion

        #endregion

        #region LOG Events
        public void LOG_BindViewEvents()
        {
            lvLog.View = View.Details;
            // Display grid lines.
            lvLog.GridLines = true;

            // Sort the items in the list in ascending order.
            lvLog.Sorting = SortOrder.Ascending;

            lvLog.FullRowSelect = true;
            lvLog.HeaderStyle = ColumnHeaderStyle.Nonclickable;

            // Create columns for the items and subitems.
            // Width of -2 indicates auto-size.
            lvLog.Columns.Add("Timestamp", -2, HorizontalAlignment.Center);
            lvLog.Columns.Add("Info", -2, HorizontalAlignment.Left);
            lvLog.Columns.Add("User", -2, HorizontalAlignment.Center);

            lvLog.Columns[0].Width = 140;
            lvLog.Columns[1].Width = 200;
            lvLog.Columns[2].Width = 70;
        }
        public void LOG_TestSequence(string msg)
        {
            LOG_TestSequenceTxt(msg);

            ListViewItem LVI = new ListViewItem(_strTimeStamp);
            LVI.SubItems.Add(msg.Trim());
            LVI.SubItems.Add(HelperApp.UserName);
            lvLog.Items.Add(LVI);
        }
        public void LOG_TestSequenceTxt(string msg)
        {
            StringBuilder sb = new StringBuilder();

            txtLogTestSequence.Text = string.Concat(txtLogTestSequence.Text, _strTimeStamp, " - ", msg, "\n\n\n");

            sb.Append(txtLogTestSequence.Text + Environment.NewLine);

            txtLogTestSequence.Text = sb.ToString();
        }
        public void LOG_Clear()
        {
            lvLog.Clear();
            lst_MemoEventLog.Items.Clear();
            txtLogTestSequence.Text = string.Empty;

            HelperTestBase.currentProjectTest.is_Created = false;
        }

        #endregion

        #region Testes de execucao DEV

        #region Background Worker
        private void bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            //List<int> temp = new List<int>();
            //for (int i = 0; i <= 10; i++)
            //{
            //    if (bgWorker.CancellationPending)
            //    {
            //        e.Cancel = true;
            //        break;
            //    }
            //    bgWorker.ReportProgress(i * 10);
            //    Thread.Sleep(500);
            //    temp.Add(i);
            //}
            //e.Result = temp;

            //if (!HelperTestBase.running)
            //    HBM_SaveAquisitionTxtData();
        }
        private void bgWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.progressBar1.Value = e.ProgressPercentage;
        }
        private void bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                MessageBox.Show("Rotina Cancelada!!");
            }
            else
            {
                //MessageBox.Show("Rotina Completada!!");
            }

            //if (e.Cancelled)
            //{
            //    //toolStripStatusLabel1.Text = "Cancelado pelo usuáio...";
            //    //toolStripProgressBar1.Value = 0;
            //}
            //// Verifica se ocorreu algum  erro no processo em background
            //else if (e.Error != null)
            //{
            //    //toolStripStatusLabel1.Text = e.Error.Message;
            //}
            //else
            //{
            //    // A tarefa em BackGround foi completada sem erros
            //    //toolStripStatusLabel1.Text = " Todos os registros foram carregados...";

            //    System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
            //    MessageBox.Show("Done");
            //}
        }

        #endregion

        #region TODO
        //TODO
        public void SaveCurrentMeasurement()
        {
            if (HelperTestBase.eExamType == eEXAMTYPE.ET_NONE)
                MessageBox.Show("No test selected!", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                //DialogToParams(&(current_exam.base_params),
                //                                &(current_exam.add_params));

                //currentTestFile.base_params = current_exam.base_params;
                //currentTestFile.add_params = current_exam.add_params;
                //currentTestFile.results = current_exam.Batch()->Results();
                //currentTestFile.graph_data = current_exam.Batch()->GraphData();

                //currentTestFile.header.ExamType = current_exam.base_type;

                //if (!database.SaveExam(&currentTestFile))
                //    MessageBox.Show("Error while saving to database!", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                //else
                //    MessageBox.Show("Ok!", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            //if (current_exam.base_type == ET_NONE)
            //    FormErrorMessage->ShowModal("No test selected!");
            //else
            //{
            //    DialogToParams(&(current_exam.base_params),
            //                                    &(current_exam.add_params));

            //    currentTestFile.base_params = current_exam.base_params;
            //    currentTestFile.add_params = current_exam.add_params;
            //    currentTestFile.results = current_exam.Batch()->Results();
            //    currentTestFile.graph_data = current_exam.Batch()->GraphData();

            //    currentTestFile.header.ExamType = current_exam.base_type;

            //    if (!database.SaveExam(&currentTestFile))
            //        FormErrorMessage->ShowModal("Error while saving to database!");
            //    else
            //        FormOkSplash->Show();
            //}
        }
        //TODO
        public void SetNewTestProgram(eEXAMTYPE examtype, string udt_filename)
        {
            // pre-check
            if (examtype == eEXAMTYPE.ET_NONE)
                return;

            //// set main information label & dropdown-list for test-selection
            mcbo_tabActParam_GenSettings_CoBSelectTest.DataSource = null;
            //current_exam.base_type = eEXAMTYPE.ET_NONE;
            //current_exam.user_defined_ix = 0;

            if (examtype != eEXAMTYPE.ET_USER_DEFINED)
            {
                //    AnsiString label = examdefs.ExamName(examtype);

                //    CoBSelectTest->Items->Add(label);
                //    CoBSelectTest->Items->Objects[0] = (TObject*)examtype;

                //    current_exam.is_user_defined = false;

                //    // preset with default values
                //    current_exam.base_params = *(current_exam.batch[examtype]->DefaultBaseParams());

                //    SBEvaluation->Visible = false;                  // reduce flickering
                //    SBEvaluation->Update();
                //    current_exam.batch[examtype]->InitPanels();     // to initialize the add_param_fifo...
                //    SBEvaluation->Visible = true;                     // reduce flickering
                //    current_exam.add_params.Flush();
                //    unsigned int n_avail = current_exam.batch[examtype]->AddParams().DataAvail();
                //    for (unsigned int add_param_ix = 0; add_param_ix < n_avail; add_param_ix++)
                //    {
                //        current_exam.batch[examtype]->AddParams()[add_param_ix]->value = 0.0;
                //        current_exam.add_params.DoExpPut(current_exam.batch[examtype]->AddParams()[add_param_ix]);
                //    }
            }
            else
            {
                //    // load test
                //    current_exam.user_defined.Filename(udt_filename.c_str());

                //    // setup all basic-tests
                //    for (unsigned int i = 0; i < current_exam.user_defined.Params().DataAvail(); i++)
                //    {
                //        eEXAMTYPE et = (*(current_exam.user_defined.Params()[i]))->examtype;


                //        AnsiString label = examdefs.ExamName(et);

                //        CoBSelectTest->Items->Add(label);
                //        CoBSelectTest->Items->Objects[i] = (TObject*)et;

                //        // preset with default values
                //        (*(current_exam.user_defined.Params()[i]))->base_params = *(current_exam.batch[et]->DefaultBaseParams());

                //        SBEvaluation->Visible = false;            // reduce flickering
                //        SBEvaluation->Update();
                //        current_exam.batch[et]->InitPanels();       // to initialize the add_param_fifo...
                //        SBEvaluation->Visible = true;               // reduce flickering
                //        (*(current_exam.user_defined.Params()[i]))->add_params.Flush();
                //        unsigned int n_avail = current_exam.batch[et]->AddParams().DataAvail();
                //        for (unsigned int add_param_ix = 0; add_param_ix < n_avail; add_param_ix++)
                //        {
                //            current_exam.batch[et]->AddParams()[add_param_ix]->value = 0.0;
                //            (*(current_exam.user_defined.Params()[i]))->add_params.DoExpPut(current_exam.batch[et]->AddParams()[add_param_ix]);
                //        }
                //    }

                //    current_exam.is_user_defined = true;
            }

            if (mcbo_tabActParam_GenSettings_CoBSelectTest.Items.Count > 0)
            {
                mcbo_tabActParam_GenSettings_CoBSelectTest.SelectedIndex = 0;
                //    CoBSelectTestChange(0);         // simulate "selection changed"
            }

            //// update the access-status
            //cCX_ACCESSBASE accessbase;
            //accessbase.Refresh();
        }

        
        #endregion

        #endregion
        
        private void mTile_LCurrentSelectedTest_Click(object sender, EventArgs e)
        {
            if (_helperApp.AppUseSimulateLocal)
                if (!_bAppStart)
                    if (TXTFileHBM_LoadData())
                        if(TXTFileHBM_HeaderCreate(_helperApp.lstStrReturnReadFileLines, HelperTestBase.Model_GVL))
                            TAB_Main.SelectedTab = TAB_Main.TabPages["tab_Diagram"];
                        else
                            MessageBox.Show("Error TXTFileHBM_LoadData, failed load result data test!", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                       
        }

    }
}
