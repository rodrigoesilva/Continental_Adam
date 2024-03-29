﻿#region USING

using System;
using System.Net;

using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Drawing.Printing;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Windows.Forms;


using MetroFramework.Controls;

using Continental.Project.Adam.UI.BLL;
using Continental.Project.Adam.UI.COM;
using Continental.Project.Adam.UI.Enum;
using Continental.Project.Adam.UI.Helper.Com;
using Continental.Project.Adam.UI.Helper;
using Continental.Project.Adam.UI.Helper.Tests;
using Continental.Project.Adam.UI.Models.COM;
using Continental.Project.Adam.UI.Models.Operational;
using Continental.Project.Adam.UI.Models.Settings;

using CefSharp.WinForms;


using DevExpress.XtraCharts;
using DevExpress.Utils;
using DevExpress.Utils.Extensions;
using DevExpress.XtraPrinting;

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
using System.Drawing.Text;
using Continental.Project.Adam.UI.Models.Security;
using Continental.Project.Adam.UI.Models.Manager;

#endregion

#endregion

namespace Continental.Project.Adam.UI
{
    public delegate void dHide(bool bLoasTestConcluded);
    public partial class Form_Adam_Main : Form
    {
        #region Define

        #region Declare Variables

        private bool _bAppStart = false;
        private bool _bCoBSelectTestSelected = false;
        private bool _bUseChkGrid = false;

        private string _notReadValue = "NaN";
        private string _initialDirPathTestFile = string.Empty;

        private bool _bGetDataInfoCarregado = false;
        private bool _bPrjTestOffLineCarregado = false;
        private string _prjTestFileNameWithPath = string.Empty;
        private string _prjTestHeaderFileNameWithPath = string.Empty;
        private string _prjTestUnionFileNameWithPath = string.Empty;

        private int _prjTestMaxSampleSeq = 0;

        private string _strTimeStamp = DateTime.Now.ToString("dd/MM/yyyy - HH:mm:ss.fff", CultureInfo.InvariantCulture);

        private bool tab_ChartEnable = false;
        private bool tab_TableResultsEnable = false;

        private bool _bContinousTestConfirmed = false;

        public StringBuilder sbDataFile = new StringBuilder();

        List<string>[] lstStrChReadFileArr = new List<string>[13];

        List<double>[] lstDblChReadFileArr = new List<double>[13];

        #endregion

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

            this.Focus();
        }
        #endregion

        #region FORM MAIN
        private void Form_Adam_InitializeComponents()
        {
            try
            {
                if (HelperApp.IsLoggedIn)
                {
                    Menu_Enable();

                    UI_SetupStatusBar();

                    _bAppStart = true;
                    timerMODBUS.Enabled = false;

                    HelperTestBase.ProjectTestConcluded.ProjectTestSample = new Model_Operational_Project_TestSample();

                    HelperTestBase.ProjectTestConcluded.ProjectTestSample.Project = new Model_Operational_Project();

                    //COMMUNICATION
                    if (ComHBM.HBM_UseEnableCom)
                        HBM_Initialize();

                    if (ComModbusTCP.Modbus_UserEnableCom)
                        _helperMODBUS.HelperMODBUS_Initialize();

                    MBmaster = HelperMODBUS.Modbus_MBmaster;

                    //"Check Test Running";
                    //if (HelperMODBUS.CS_wEmCiclo)
                    TEST_Stop_Command();

                    //Check Database
                    new BLL_Operational_Project().DeleteProjectTestConcludedOrphan();

                    new BLL_Operational_Project().DeleteProjectTestSampleOrphan();
                }
                else
                {
                    Execute_Logout();

                    MessageBox.Show("Not Found LoginName OR Password !", _helperApp.appMsg_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);

                    this.Hide();

                    var formWelcome = new Form_Adam_Welcome();
                    formWelcome.Closed += (s, args) => this.Close();
                    formWelcome.Show();
                }
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

            _helperApp.AppTests_Path = _initialDirPathTestFile;

            this.WindowState = FormWindowState.Maximized;

            SubMenuProject_Disable();

            TAB_Disable(_helperApp.GetMethodName());

            TAB_Main_ActivePage(2, _helperApp.GetMethodName());

            CONTROLS_EnableMetroButton();

            CONTROL_WebVisu_Header();

            LOG_Clear();

            LOG_BindViewEvents();

            LOG_TestSequence(_helperApp.AppMsg_Welcome);

            this.Activate();

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
        private void CONTROL_WebVisu_Header()
        {
            var headerBrowser = new ChromiumWebBrowser("http://192.168.0.1:8080/webvisu2.htm") { Dock = DockStyle.Fill };

            if (headerBrowser != null)
            {
                mpnl_HeaderInfoAnalogInput.SendToBack();
                mpnl_HeaderInfoAnalogInput.Visible = false;


                mpnl_HeaderInfoAnalogInputVisu.Location = new Point(5, 130);
                mpnl_HeaderInfoAnalogInputVisu.Controls.Add(headerBrowser);
                mpnl_HeaderInfoAnalogInputVisu.BringToFront();
            }
        }
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
        private void Execute_Logout()
        {
            HelperApp.IsLoggedIn = false;

            subMenu_Home_Logout.Visible = false;

            Menu_Disable();
        }
        private void Menu_Enable()
        {
            menuItemToolStrip_Home.Enabled = true;
            menuItemToolStrip_Project.Enabled = true;
            subMenu_Project_Project.Enabled = true;
            menuItemToolStrip_TestProgram.Enabled = true;
            menuItemToolStrip_Settings.Enabled = true;
        }

        private void SubMenuProject_Enable()
        {
            subMenu_Project_Project.Enabled = true;
            subMenu_Project_PrintGraphics.Enabled = true;
            subMenu_Project_ExportExcel.Enabled = true;
        }
        private void Menu_Disable()
        {
            menuItemToolStrip_Project.Enabled = false;
            menuItemToolStrip_TestProgram.Enabled = false;
            menuItemToolStrip_Settings.Enabled = false;

            SubMenuProject_Disable();
        }

        private void SubMenuProject_Disable()
        {
            subMenu_Project_PrintGraphics.Enabled = false;
            subMenu_Project_ExportExcel.Enabled = false;
        }

        #endregion

        #region MENU

        #region Menu - Home
        private void subMenu_Home_Logout_Click(object sender, EventArgs e)
        {
            _helperApp.Form_Close(this);

            Execute_Logout();
        }
        private void subMenu_Home_Exit_Click(object sender, EventArgs e)
        {
            Execute_Logout();

            Application.Exit();
        }
        private void subMenu_Home_About_Click(object sender, EventArgs e)
        {
            _helperApp.Form_Open(new Form_Adam_About(), this);
        }

        #endregion

        #region Menu - Project
        private void subMenu_Project_Project_Click(object sender, EventArgs e)
        {
            //helperAdam.SMProjectClick(sender);

            //MessageBox.Show("subMenu_Project_Project_Click !", helperApp.msgAppName);

            Form_Operational_Project formProject = new Form_Operational_Project(eEXAMTYPE.ET_NONE, string.Empty);
            formProject.delegateFnLoadTestConcluded += TEST_Concluded_LoadData;
            formProject.StartPosition = FormStartPosition.CenterScreen;
            formProject.Show();
        }

        private void subMenu_Project_PrintGraphics_Click(object sender, EventArgs e)
        {
            CHART_Print();
        }

        private void subMenu_Project_SetupPrinter_Click(object sender, EventArgs e)
        {
            //helperAdam.SMSetupPrinterClick(sender);
            printDialog.ShowDialog();
        }
        private void subMenu_Project_ExportExcel_Click(object sender, EventArgs e)
        {
            if (TXTFileHBM_HeaderUnion())
                ExportTestToXLS();
        }

        #endregion

        #region Menu - Test Program
        private void subMenu_TestProg_SelectTestProgram_Click(object sender, EventArgs e)
        {
            //helperAdam.SMSelectClick(sender);

            //MessageBox.Show("subMenu_TestProg_SelectTestProgram_Click !", helperApp.msgAppName);

            _helperApp.Form_Open(new Form_Manager_SelectEvalProgram());
        }

        private void subMenu_TestProg_Start_Click(object sender, EventArgs e)
        {
            //helperAdam.SMStartClick(sender);

            MessageBox.Show("subMenu_TestProg_Start_Click !", _helperApp.appMsg_Name);

            TEST_Start_Command();
        }

        private void subMenu_TestProg_STop_Click(object sender, EventArgs e)
        {
            //helperAdam.SMStopClick(sender);

            MessageBox.Show("subMenu_TestProg_STop_Click !", _helperApp.appMsg_Name);

            TEST_Stop_Command();
        }

        private void subMenu_TestProg_CreateUserDefinedTest_Click(object sender, EventArgs e)
        {
            //helperAdam.SMUserDefTestClick(sender);

            //MessageBox.Show("subMenu_TestProg_CreateUserDefinedTest_Click !", helperApp.msgAppName);

            _helperApp.Form_Open(new Form_Manager_CreateEvalGroup());
        }

        private void subMenu_TestProg_ManualActuation_Click(object sender, EventArgs e)
        {
            //helperAdam.SMManualActuationClick(sender);

            //MessageBox.Show("subMenu_TestProg_ManualActuation_Click !", helperApp.msgAppName);

            _helperApp.Form_Open(new Form_Operational_ManualActuation());
        }

        private void subMenu_TestProg_Calibration_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("subMenu_TestProg_Calibration_Click !", helperApp.msgAppName);

            _helperApp.Form_Open(new Form_Operational_Calibration());
        }

        private void subMenu_TestProg_Bleed_Click(object sender, EventArgs e)
        {
            //helperAdam.SMBleedDrainClick(sender);

            //MessageBox.Show("subMenu_TestProg_Bleed_Click !", helperApp.msgAppName);

            _helperApp.Form_Open(new Form_Operational_Bleed());
        }

        private void subMenu_TestProg_SaveTest_Click(object sender, EventArgs e)
        {
            //helperAdam.SaveTest1Click(sender);

            MessageBox.Show("subMenu_TestProg_SaveTest_Click !", _helperApp.appMsg_Name);
        }

        #endregion

        #region Menu - Settings
        private void subMenu_Settings_SoftwareMaintenance_Click(object sender, EventArgs e)
        {
            //helperAdam.SMPreferencesClick(sender);

            MessageBox.Show(_helperApp.AppMsg_Welcome, _helperApp.appMsg_Name);

            //  _helperApp.Form_Open(new Form_Adam_Preferences(), this);
        }

        #endregion

        #region Menu - Security
        private void subMenu_Account_SelectAccessLevel_Click(object sender, EventArgs e)
        {
           _helperApp.Form_Open(new Form_Security_UserProfile());
        }
        private void subMenu_Account_NewPassword_Click(object sender, EventArgs e)
        {
            _helperApp.Form_Open(new Form_Security_NewPassword());
        }
        private void subMenu_Security_UserManagement_Click(object sender, EventArgs e)
        {
            _helperApp.Form_Open(new Form_Security_User_Management());
        }
        
        #endregion

        #endregion

        #region TASK BAR
        private void TaskBarUpdate()
        {
            tStatusLabel01.Text = HelperApp.lblstsbar01;

            tStatusLabel02.Text = string.IsNullOrEmpty(HelperApp.lblstsbar02) ? HelperApp.UserApp.UName : HelperApp.lblstsbar02;

            var _fakeRunTestMaxSampleSeq = HelperTestBase.running ? HelperTestBase.ProjectTestConcluded.ProjectTestSample?.SampleSequence + 1 : HelperTestBase.ProjectTestConcluded.ProjectTestSample?.SampleSequence;
            HelperApp.lblstsbar03 = string.Concat("Ident # - [ ", HelperTestBase.ProjectTestConcluded.ProjectTestSample.Project?.Identification, " ]", " - # Sample : ", _fakeRunTestMaxSampleSeq, "");


            tStatusLabel03.Text = string.IsNullOrEmpty(HelperApp.lblstsbar03) ? string.Concat("Ident # - [ ", _notReadValue, " ]") : HelperApp.lblstsbar03;

            HelperApp.lblstsbar04 = DateTime.Now.ToString();
            tStatusLabel04.Text = HelperApp.lblstsbar04;
        }
        private void UI_SetupStatusBar()
        {
            Form_SetStatusBarPanelSize();

            if (!HelperApp.IsLoggedIn)
            {
                stsBar_STBMain.Items[0].Text = _helperApp.appMsg_Name;

                for (int i = 1; i < 3; i++)
                {
                    stsBar_STBMain.Items[i].Text = string.Empty;
                    stsBar_STBMain.Items[i].AutoSize = false;
                    stsBar_STBMain.Items[i].Width = 475;
                }
            }
        }
        private void Form_SetStatusBarPanelSize()
        {
            stsBar_STBMain.AutoSize = false;

            for (int i = 0; i < 4; i++)
            {
                stsBar_STBMain.Items[i].AutoSize = false;
                stsBar_STBMain.Items[i].Width = 475;
            }
        }

        #endregion

        #region BUTTONS

        #region BUTTONS HEADER
        private void mbtn_BStart_Click(object sender, EventArgs e)
        {
            TAB_Disable(_helperApp.GetMethodName());

            TEST_Start_Command();
        }
        private void mbtn_BStop_Click(object sender, EventArgs e)
        {
            TEST_Stop_Command();
        }
        private void mtbn_BExportTestToXLS_Click(object sender, EventArgs e)
        {
            if (!HelperApp.bRunTestExecuted)
            {
                MessageBox.Show("Test data unavailable !", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                if (TXTFileHBM_HeaderUnion())
                    ExportTestToXLS();
            }
        }

        private void mbtn_BReportPDF_Click(object sender, EventArgs e)
        {
            try
            {
                if (!HelperApp.bRunTestExecuted)
                {
                    MessageBox.Show("Report data unavailable !", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    if (!CHART_ExportImage())
                    {
                        MessageBox.Show("Failed, Chart Export !", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (!ReportPDF())
                    {
                        MessageBox.Show("Failed, Report PDF !", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
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
            mtbn_BExportTestToXLS.Enabled = false;
            mbtn_BReportPDF.Enabled = false;

            mcbo_tabActParam_GenSettings_CoBActuationMode.Enabled = false;

            mbtn_GeneralSettings_Minus_EParGenVacuum_Accel_L.Enabled = false;
            mbtn_GeneralSettings_Plus_EParGenVacuum_Accel_R.Enabled = false;


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

            mbtn_GeneralSettings_Minus_EParGenVacuum_Accel_L.Enabled = true;
            mbtn_GeneralSettings_Plus_EParGenVacuum_Accel_R.Enabled = true;


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

        #region TABS Methods
        public void TAB_Enable(string origin)
        {
            tab_ChartEnable = true;
            tab_TableResultsEnable = true;

            mtbn_BExportTestToXLS.Enabled = true;
            mbtn_BReportPDF.Enabled = true;
        }
        public void TAB_Disable(string origin)
        {
            tab_TableResultsEnable = false;
            tab_ChartEnable = false;

            HelperApp.bRunTestExecuted = false;
        }

        #endregion

        #region TAB - Main
        private void TAB_Main_Selecting(object sender, TabControlCancelEventArgs e)
        {
            bool bTabAccessOk = false;

            var strTabSelected = e.TabPage.Name.ToString();

            switch (strTabSelected)
            {
                case "tab_Diagram":
                    bTabAccessOk = HelperApp.bRunTestExecuted && tab_ChartEnable && HelperApp.uiTesteSelecionado > 0;
                    break;
                case "tab_TableResults":
                    bTabAccessOk = HelperApp.bRunTestExecuted && tab_TableResultsEnable && HelperApp.uiTesteSelecionado > 0;
                    break;
                case "Tab_ActuationParameters":
                    bTabAccessOk = true;
                    break;
                case "tab_CPX_Visu":
                    bTabAccessOk = HelperApp.uiTesteSelecionado > 0;
                    break;
                default:
                    bTabAccessOk = false;
                    break;
            }

            if (!bTabAccessOk)
                e.Cancel = true;
        }
        private void TAB_Main_SelectedIndexChanged(object sender, EventArgs e)
        {
            TAB_Main_ActivePage(TAB_Main.SelectedIndex, _helperApp.GetMethodName());
        }
        public void TAB_Main_ActivePage(int tabIdx, string origin)
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

                            if (!TAB_TableResult_SetData(_helperApp.GetMethodName()))
                                MessageBox.Show("Failed, TAB_TableResult_SetData !", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);

                            break;
                        }
                    case 2://TAB_ActuationParameters
                        {
                            if (TAB_Main.TabPages["tab_CPX_Visu"] == null)
                                TAB_CPXVisu_Create();

                            //if (!_bAppStart)
                            if (!TAB_ActuationParameters_SetData(_helperApp.GetMethodName()))
                            {
                                MessageBox.Show("Failed, TAB_TableResult_SetData !", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                break;
                            }

                            TAB_Main.SelectedTab = TAB_Main.TabPages["Tab_ActuationParameters"];
                            break;
                        }
                    case 3://tab_CPX
                        {
                            if (TAB_Main.TabPages["tab_CPX_Visu"] == null)
                                TAB_CPXVisu_Create();
                            else
                                TAB_Main.SelectedTab = TAB_Main.TabPages["tab_CPX_Visu"];

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
                devChart.Visible = true;
            else
                MessageBox.Show("Error, invalid test!", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        #endregion

        #region TAB - TableResults

        #region TAB - TableResults - Common
        private bool TAB_TableResult_SetData(string origin)
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
                    {
                        MessageBox.Show("Error, failed load result data test!", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        TAB_Main.SelectedTab = TAB_Main.TabPages["Tab_ActuationParameters"];

                        return false;
                    }
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
                DataTable dtTableResults = new BLL_Main_Tab_TableResults().PopulateGridTableResultsByTest(strIdxTestSelected);

                #region CheckBoxes Result Parameters

                List<Model_Operational_TestTableParameters> listResultParam = new List<Model_Operational_TestTableParameters>();

                HelperTestBase.ProjectTestConcluded.ProjectTestSample.Project = HelperTestBase.ProjectTestConcluded.ProjectTestSample?.Project == null ? new Model_Operational_Project() : HelperTestBase.ProjectTestConcluded.ProjectTestSample.Project;

                if (!HelperTestBase.ProjectTestConcluded.ProjectTestSample.Project.is_OnLIne)
                {
                    if (HelperTestBase.ProjectTestConcluded.IdProjectTestConcluded > 0 && HelperTestBase.ProjectTestConcluded.ProjectTestSample.Project.IdProject > 0)
                    {
                        #region load existent Header File project

                        if (!_helperApp.ReadTXTFileHeaderHBM())
                        {
                            MessageBox.Show("Failed, error pathWithFileNameHeader project !", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }

                        #endregion
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(HelperTestBase.ProjectTestConcluded?.ProjectTestFileName))
                            MessageBox.Show("Error no valid Test selected!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        TAB_Main.SelectedTab = TAB_Main.TabPages["Tab_ActuationParameters"];

                        return false;
                    }

                    if (HelperApp.dicReadFileHeader[0]?.Count() == 0)
                    {
                        MessageBox.Show("Error, dicReturnReadFileHeader result not load!", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }

                    if (HelperApp.dicReadFileHeader[0]?.Count() > 0)
                        listResultParam = _helperApp.TabTableParameters_GetTableParamOffLineByFile(dtTableResults, grid_tabActionParam_EvalParam, HelperApp.dicReadFileHeader);
                    else
                    {
                        MessageBox.Show("Error, .dicReadFileHeader result not load!", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }
                else
                {
                    if (dtTableResults.Rows.Count == 0)
                    {
                        MessageBox.Show("Error, failed load result data test!", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        TAB_Main.SelectedTab = TAB_Main.TabPages["Tab_ActuationParameters"];

                        return false;
                    }
                    else
                        listResultParam = _helperApp.TabTableParameters_GetTableParam(dtTableResults, grid_tabActionParam_EvalParam);
                   

                    #endregion
                }

                if (listResultParam?.Count() == 0 || listResultParam == null)
                {
                    MessageBox.Show("Error, Parm result not load!", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                //TEMPORARIO rRunOutForce do T01 para T06/07/08
                _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_dwRunOutForceRef_LW }, HelperTestBase.Model_GVL.GVL_T01.temp_rRunOutForce_Real_N);
                mbtn_EoutForce.Text = HelperTestBase.Model_GVL.GVL_T01.temp_rRunOutForce_Real_N.ToString() + " N";
                _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_dwRunOutPressureRef_LW }, HelperTestBase.Model_GVL.GVL_T01.temp_rRunOutPressure_Real_Bar);
                mbtn_EoutPressure.Text = HelperTestBase.Model_GVL.GVL_T01.temp_rRunOutPressure_Real_Bar.ToString() + " bar";

                HelperApp.lstResultParam.Clear();

                HelperApp.lstResultParam = listResultParam;

                //bind Checkboxes Table Results
                TAB_TableResults_CheckBoxes(listResultParam);

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

                    Model_Operational_TestTableParameters itemResultParam = itemResultParam_Element == itemResultParam_Name ? itemResultParam_Name : itemResultParam_Element;

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

                throw;
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
                        TAB_TableResults_Grid_WriteNominalParameters(row, strIdTestAvailable, strResultParam_Nominal);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);

                TAB_Main.SelectedTab = TAB_Main.TabPages["Tab_ActuationParameters"];

                throw;
            }
        }
        private void TAB_TableResults_Grid_WriteNominalParameters(DataGridViewRow row, string strIdTestAvailable, string strResultParam_Nominal)
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);

                TAB_Main.SelectedTab = TAB_Main.TabPages["Tab_ActuationParameters"];

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


                        }
                    }

                    if (lstChk.Count() > 0)
                        //clear checkbox
                        lstChk.ForEach(item => metroPnl.Controls.Remove(item));

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
                        mChkBox.Text = strResultParam_Caption.Replace(".", ",");
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
        private bool TAB_ActuationParameters_SetData(string origin)
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
                        case 25:    //Force Diagrams - Force/Pressure Dual Ratio
                            {
                                if (HelperTestBase.Model_GVL.GVL_Graficos.iOutput == 1)
                                {
                                    rad_EvaluationParameters_CBOutputPC.Checked = true;
                                    //rad_EvaluationParameters_CBOutputSC.Enabled = HelperTestBase.ProjectTestConcluded.IdProjectTestConcluded > 0 && HelperTestBase.ProjectTestConcluded.IdProject > 0 ? false : true;
                                }
                                else
                                {
                                    rad_EvaluationParameters_CBOutputSC.Checked = true;
                                    //rad_EvaluationParameters_CBOutputPC.Enabled = HelperTestBase.ProjectTestConcluded.IdProjectTestConcluded > 0 && HelperTestBase.ProjectTestConcluded.IdProject > 0 ? false : true;
                                }

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

                    HelperTestBase.iOutputType = _modelGVL.GVL_Graficos.iOutput;
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

                if (!TAB_ActuationParameters_PopulateData(HelperApp.uiTesteSelecionado, _helperApp.GetMethodName()))
                {
                    grid_tabActionParam_EvalParam.DataSource = null;
                    HelperApp.uiTesteSelecionado = 0;

                    _helperApp.Form_Open(new Form_Adam_Welcome());
                }

                _bAppStart = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Concat("Error - TAB_ActuationParameters_SetData : \n\n", ex.Message), _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;

                throw;
            }

            return true;
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
        private void TAB_ActuationParameters_WriteComInputTxt(string strName, string strValue)
        {
            try
            {
                var dblValue = _helperApp.NumberDoubleCheck(strValue);

                if (dblValue < 0)
                    dblValue = (dblValue * -1);

                switch (strName.Trim())
                {
                    case "mtxt_GeneralSettings_EParGenVacuum":
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
                MessageBox.Show(string.Concat("Error - TAB_ActuationParameters_WriteComInputTxt : \n\n", ex.Message), _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

                throw;
            }
        }

        #endregion

        #region TAB - ActuationParameters - Populate Data
        private bool TAB_ActuationParameters_PopulateData(int uiTesteSelecionado, string origin)
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

                            if (!_bCoBSelectTestSelected)
                            {
                                bool bReturnDataInfo = false;

                                if (!HelperTestBase.ProjectTestConcluded.ProjectTestSample.Project.is_OnLIne)
                                {
                                    if (HelperTestBase.ProjectTestConcluded.IdProjectTestConcluded > 0 && HelperTestBase.ProjectTestConcluded.ProjectTestSample.Project.IdProject > 0)
                                        bReturnDataInfo = TAB_ActuationParameters_GetDataInfoOffLineByFile(HelperApp.uiTesteSelecionado.ToString());
                                    else
                                        bReturnDataInfo = TAB_ActuationParameters_GetDataInfo(HelperApp.uiTesteSelecionado.ToString());
                                }
                                else
                                    bReturnDataInfo = TAB_ActuationParameters_GetDataInfo(HelperApp.uiTesteSelecionado.ToString());

                                if (bReturnDataInfo)
                                    _bCoBSelectTestSelected = true;
                                else
                                {
                                    MessageBox.Show("Error, failed load data test \n\n TAB_ActuationParameters_PopulateData!", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return false;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Concat("Error - TAB_ActuationParameters_PopulateData : \n\n", ex.Message), _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;

                throw;
            }

            return true;
        }
        private bool TAB_ActuationParameters_GetDataInfo(string strIdxTestSelected)
        {
            try
            {
                DataTable dtActionParameter = new BLL_Main_Tab_ActuationParameters().PopulateActionParametersByTest(strIdxTestSelected);

                if (dtActionParameter.Rows.Count == 0)
                {
                    MessageBox.Show("Error, failed load data test!", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    _bGetDataInfoCarregado = false;
                    return false;
                }
                else
                {
                    #region Actuation Parameters

                    foreach (DataRow row in dtActionParameter.Rows)
                    {
                        #region General Settings

                        //General Settings - CBO Actuation Mode
                        IdActuationMode = row.Field<int>("IdActuationMode");
                        TAB_ActuationParameters_GeneralSettings_CoBActuationMode_Change(IdActuationMode);

                        //General Settings - Panel Vacuum
                        strVacuumValue = !string.IsNullOrEmpty(row.Field<decimal?>("Vacuum").ToString()) ? row.Field<decimal?>("Vacuum").ToString() : "0";
                        TAB_ActuationParameters_GeneralSettings_Vacuum_Change(strVacuumValue);

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
                            TAB_ActuationParameters_Actuation_MaxForce_Change(strName, strMaxForceValue);
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

                    #endregion

                    #region Evaluation Parameters

                    DataTable dtGridEvalParameters = new BLL_Main_Tab_ActuationParameters().PopulateGridEvalParametersByTest(strIdxTestSelected);

                    if (dtGridEvalParameters == null)
                    {
                        MessageBox.Show("Error, failed load data test!", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        _bGetDataInfoCarregado = false;

                        return false;
                    }
                    else
                    {
                        List<ActuationParameters_EvaluationParameters> lstInfoEvaluationParameters = new List<ActuationParameters_EvaluationParameters>();

                        if (dtGridEvalParameters.Rows.Count > 0)
                        {
                            //Rows Format
                            if (TAB_ActuationParameters_EvalParameters_Grid_GridRowType(dtGridEvalParameters))
                            {
                                if (TAB_ActuationParameters_EvalParameters_Grid_Format())
                                {
                                    lstInfoEvaluationParameters = _helperApp.GridView_GetValuesEvalParam(grid_tabActionParam_EvalParam);

                                    if (HelperApp.uiTesteSelecionado > 0)
                                        TAB_ActuationParameters_WriteComGridEvalParameters(lstInfoEvaluationParameters, string.Empty, string.Empty);
                                    else
                                    {
                                        _bGetDataInfoCarregado = false;

                                        MessageBox.Show("Error no valid Test selected!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                                        TAB_Main.SelectedTab = TAB_Main.TabPages["Tab_ActuationParameters"];

                                        return false;
                                    }
                                }
                                else
                                {
                                    _bGetDataInfoCarregado = false;

                                    MessageBox.Show("Error, failed Grid_Format rows data test!", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return false;
                                }
                            }
                            else
                            {
                                _bGetDataInfoCarregado = false;

                                MessageBox.Show("Error, failed load GridRowType data test!", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return false;
                            }
                        }
                        else
                        {
                            _bGetDataInfoCarregado = false;

                            MessageBox.Show("Error, failed load rows data test!", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                    }

                    #endregion
                }
            }
            catch (Exception ex)
            {
                _bGetDataInfoCarregado = false;

                MessageBox.Show(string.Concat("Error - TAB_ActuationParameters_GetDataInfo : \n\n", ex.Message), _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;

                throw;
            }

            return true;
        }

        private bool TAB_ActuationParameters_GetDataInfoOffLineByFile(string strIdxTestSelected)
        {
            try
            {
                if (!_helperApp.ReadTXTFileHeaderHBM())
                {
                    MessageBox.Show("Failed, error path project !", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                var dicReturnReadFileHeaderPrj = HelperApp.dicReadFileHeader[0];
                var dicReturnReadFileHeaderParamGridData = HelperApp.dicReadFileHeader[1];
                var dicReturnReadFileHeaderParamGrid = HelperApp.dicReadFileHeader[2];
                var dicReturnReadFileHeaderParam = HelperApp.dicReadFileHeader[3];
                var dicReturnReadFileHeaderResults = HelperApp.dicReadFileHeader[4];

                DataTable dtActionParameter = new BLL_Main_Tab_ActuationParameters().PopulateActionParametersByTest(strIdxTestSelected);

                if (!_helperApp.TAB_ActuationParameters_GetValuesEvalParamOffLineByFile())
                {
                    MessageBox.Show("Error, failed load data offline Eval Param test!", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                else
                {
                    #region Actuation Parameters

                    #region General Settings

                    //General Settings - CBO Actuation Mode
                    IdActuationMode = HelperTestBase.iActuaionMode;
                    TAB_ActuationParameters_GeneralSettings_CoBActuationMode_Change(IdActuationMode);

                    //General Settings - Panel Vacuum
                    strVacuumValue = HelperTestBase.Vacuum.ToString();
                    TAB_ActuationParameters_GeneralSettings_Vacuum_Change(strVacuumValue);

                    //General Settings - Panel Consumers
                    iConsumerType = HelperTestBase.iTipoConsumidores;
                    iConsumerPC = HelperTestBase.iSumHoseConsumerPC;
                    iConsumerSC = HelperTestBase.iSumHoseConsumerSC;
                    bPistonLock = HelperTestBase.chkPistonLock;
                    TAB_ActuationParameters_GeneralSettings_Consumers_Change(iConsumerType, iConsumerPC, iConsumerSC, bPistonLock);

                    #endregion

                    #region Actuation

                    strName = string.Empty;

                    strMaxForceValue = HelperTestBase.MaxForce.ToString();

                    if (!string.IsNullOrEmpty(strMaxForceValue))
                        TAB_ActuationParameters_Actuation_MaxForce_Change(strName, strMaxForceValue);
                    else
                        mtxt_Actuation_E1ParMaxForce.Text = _notReadValue;


                    strGradientForceValue = HelperTestBase.ForceGradient.ToString();

                    if (!string.IsNullOrEmpty(strGradientForceValue))
                    {
                        TAB_ActuationParameters_Actuation_GradientForce_Change(strName, strGradientForceValue);

                        mtxt_Actuation_E1ParForceGrad.Text = strGradientForceValue;
                    }
                    else
                        mtxt_Actuation_E1ParForceGrad.Text = _notReadValue;

                    #endregion

                    #endregion

                    #region Evaluation Parameters

                    if (dicReturnReadFileHeaderParamGridData == null || dicReturnReadFileHeaderParamGridData.Count == 0)
                    {
                        MessageBox.Show("Error, failed load data test!", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    else
                    {
                        List<ActuationParameters_EvaluationParameters> lstInfoEvaluationParameters = new List<ActuationParameters_EvaluationParameters>();

                        //Rows Format
                        if (TAB_ActuationParameters_EvalParameters_Grid_GridRowTypeOffLineByFile(dicReturnReadFileHeaderParamGridData, dicReturnReadFileHeaderParamGrid))
                        {
                            if (TAB_ActuationParameters_EvalParameters_Grid_Format())
                            {
                                #region Update Data  OFF LINE |- PARAMETERS GRID -|

                                lstInfoEvaluationParameters = new List<ActuationParameters_EvaluationParameters>();
                                lstInfoEvaluationParameters = _helperApp.GridView_GetValuesEvalParamOffLineByFile(grid_tabActionParam_EvalParam);

                                if (lstInfoEvaluationParameters == null)
                                {
                                    MessageBox.Show("Error, failed load rows data test - GetValuesEvalParamOffLineByFile!", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Warning);

                                    return false;
                                }
                                else
                                {
                                   List<Control> lstGrpBoxRadioButton = new List<Control>();

                                    for (int i = 0; i < lstInfoEvaluationParameters.Count; i++)
                                    {
                                        int iGrid_IdEvalParam = 0;

                                        string strGrid_EvalParam_Caption = string.Empty;

                                        string strGrid_ParamHeaderFile_EvalParam_Hi = string.Empty;

                                        string strGrid_EvalParam_Mksunit = string.Empty;

                                        string strGrid_EvalParam_ResultParam_Name = string.Empty;

                                        string strGrid_EvalParam_Name = string.Empty;

                                        string strGrid_EvalParam_GridRowType = lstInfoEvaluationParameters[i].EvalParam_GridRowType;

                                        switch (strGrid_EvalParam_GridRowType)
                                        {
                                            case "ADDINPUT_CREATE_VSPACE":
                                                {
                                                    //if (HelperApp.uiTesteSelecionado != 24)
                                                    //{
                                                    //    iRowIndex = HelperApp.uiTesteSelecionado != 24 ? j : j - 3;

                                                    //    grid_tabActionParam_EvalParam[idxCol_GridRowType, iRowIndex] = TextBoxCell_GridRowType;
                                                    //    grid_tabActionParam_EvalParam[idxCol_GridRowType, iRowIndex].Value = strGridRowType;
                                                    //    dt.Rows.Add(new object[iItemArrayCount]);
                                                    //}
                                                }
                                                break;
                                            case "CREATE_ANALOG_INPUT":
                                                {
                                                    iGrid_IdEvalParam = lstInfoEvaluationParameters[i].IdEvalParam;

                                                    strGrid_EvalParam_Caption = lstInfoEvaluationParameters.Where(x => x.IdEvalParam.Equals(iGrid_IdEvalParam)).Select(a => a.EvalParam_Caption).FirstOrDefault();

                                                    strGrid_ParamHeaderFile_EvalParam_Hi = lstInfoEvaluationParameters.Where(x => x.IdEvalParam.Equals(iGrid_IdEvalParam)).Select(a => a.EvalParam_Hi).FirstOrDefault().ToString("F2")?.Trim();

                                                    strGrid_EvalParam_Mksunit = lstInfoEvaluationParameters.Where(x => x.IdEvalParam.Equals(iGrid_IdEvalParam)).Select(a => a.EvalParam_Mksunit).FirstOrDefault();

                                                    strGrid_EvalParam_ResultParam_Name = lstInfoEvaluationParameters.Where(x => x.IdEvalParam.Equals(iGrid_IdEvalParam)).Select(a => a.EvalParam_ResultParam_Name).FirstOrDefault();

                                                    strGrid_EvalParam_Name = lstInfoEvaluationParameters.Where(x => x.IdEvalParam.Equals(iGrid_IdEvalParam)).Select(a => a.EvalParam_Name).FirstOrDefault();

                                                    int j = HelperApp.uiTesteSelecionado == 24 ? i - 4 : i;

                                                    grid_tabActionParam_EvalParam.Rows[j].Cells["IdEvalParam"].Value = iGrid_IdEvalParam;
                                                    grid_tabActionParam_EvalParam.Rows[j].Cells["EvalParam_Caption"].Value = strGrid_EvalParam_Caption;
                                                    grid_tabActionParam_EvalParam.Rows[j].Cells["EvalParam_Hi"].ValueType = typeof(string);
                                                    grid_tabActionParam_EvalParam.Rows[j].Cells["EvalParam_Hi"].Value = strGrid_ParamHeaderFile_EvalParam_Hi;
                                                    grid_tabActionParam_EvalParam.Rows[j].Cells["UnitSymbol"].Value = strGrid_EvalParam_Mksunit;
                                                    grid_tabActionParam_EvalParam.Rows[j].Cells["EvalParam_ResultParam_Name"].Value = strGrid_EvalParam_ResultParam_Name;
                                                    grid_tabActionParam_EvalParam.Rows[j].Cells["EvalParam_Name"].Value = strGrid_EvalParam_Name;
                                                }
                                                break;
                                            case "CREATE_CHECKBOX_INPUT":
                                                {
                                                    grid_tabActionParam_EvalParam.Rows[i].Cells["EvalParam_Hi"].ValueType = typeof(string); //blank line

                                                    grid_tabActionParam_EvalParam.Rows[i].Cells["EvalParam_Hi"].Style.ForeColor = Color.White;
                                                    grid_tabActionParam_EvalParam.Rows[i].Cells["EvalParam_Hi"].Style.BackColor = Color.White;
                                                    grid_tabActionParam_EvalParam.Rows[i].Cells["EvalParam_Hi"].Style.SelectionBackColor = Color.White;
                                                    grid_tabActionParam_EvalParam.Rows[i].Cells["EvalParam_Hi"].Style.SelectionForeColor = Color.White;

                                                    bool chkStatus = Convert.ToBoolean(lstInfoEvaluationParameters[i].EvalParam_Hi);
                                                    grid_tabActionParam_EvalParam.Rows[i].Cells[0].Value = chkStatus;
                                                }
                                                break;
                                            case "CREATE_RADIO_INPUT":
                                                {
                                                    iGrid_IdEvalParam = lstInfoEvaluationParameters[i].IdEvalParam;

                                                    strGrid_EvalParam_Caption = lstInfoEvaluationParameters.Where(x => x.IdEvalParam.Equals(iGrid_IdEvalParam)).Select(a => a.EvalParam_Caption).FirstOrDefault();

                                                    strGrid_ParamHeaderFile_EvalParam_Hi = lstInfoEvaluationParameters.Where(x => x.IdEvalParam.Equals(iGrid_IdEvalParam)).Select(a => a.EvalParam_Hi).FirstOrDefault().ToString();

                                                    strGrid_EvalParam_Mksunit = lstInfoEvaluationParameters.Where(x => x.IdEvalParam.Equals(iGrid_IdEvalParam)).Select(a => a.EvalParam_Mksunit).FirstOrDefault();

                                                    strGrid_EvalParam_ResultParam_Name = lstInfoEvaluationParameters.Where(x => x.IdEvalParam.Equals(iGrid_IdEvalParam)).Select(a => a.EvalParam_ResultParam_Name).FirstOrDefault();

                                                    strGrid_EvalParam_Name = lstInfoEvaluationParameters.Where(x => x.IdEvalParam.Equals(iGrid_IdEvalParam)).Select(a => a.EvalParam_Name).FirstOrDefault();

                                                    Control grpBoxRadioButton = CONTROLS_GetAll(this, typeof(GroupBox)).Find(a => a.Name == "grpRadio_T24_Efficiency");

                                                    foreach (var ctrl in grpBoxRadioButton.Controls)
                                                    {
                                                        if (ctrl.GetType() == typeof(RadioButton))
                                                        {
                                                            if (((Control)ctrl).Name.Equals(strGrid_EvalParam_Name))
                                                                ((RadioButton)ctrl).Checked = strGrid_ParamHeaderFile_EvalParam_Hi.Equals("0") ? false : true;
                                                        }
                                                    }
                                                }
                                                break;
                                            default:
                                                break;
                                        }
                                    }
                                }
                                #endregion

                                if (HelperApp.uiTesteSelecionado > 0)
                                    TAB_ActuationParameters_WriteComGridEvalParameters(lstInfoEvaluationParameters, string.Empty, string.Empty);
                                else
                                {
                                    MessageBox.Show("Error no valid Test selected!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                                    TAB_Main.SelectedTab = TAB_Main.TabPages["Tab_ActuationParameters"];

                                    return false;
                                }
                            }
                            else
                            {
                                MessageBox.Show("Error, failed Grid_Format rows data test!", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return false;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Error, failed load GridRowType data test!", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                    }

                    #endregion
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Concat("Error - TAB_ActuationParameters_GetDataInfoOffLineByFile : \n\n", ex.Message), _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;

                throw;
            }

            return true;
        }

        //GridView_GetValuesEvalParamOffLineByFile
        #endregion

        #region TAB - ActuationParameters - Panel General Settings

        #region TAB - ActuationParameters - General Settings - CBO Actuation Mode
        private void TAB_ActuationParameters_GeneralSettings_CoBActuationMode_Populate()
        {
            try
            {
                _bAppStart = true;

                BLL_Main_Tab_ActuationParameters _bll_Main_Tab_ActionParameters = new BLL_Main_Tab_ActuationParameters();

                DataTable dt = _bll_Main_Tab_ActionParameters.PopulateActionMode();

                mcbo_tabActParam_GenSettings_CoBActuationMode.ValueMember = "Id";

                mcbo_tabActParam_GenSettings_CoBActuationMode.DisplayMember = "Name";
                mcbo_tabActParam_GenSettings_CoBActuationMode.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);

                TAB_Main.SelectedTab = TAB_Main.TabPages["Tab_ActuationParameters"];

                throw;
            }
        }
        private void mcbo_GeneralSettings_CoBActuationMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idxSelected = mcbo_tabActParam_GenSettings_CoBActuationMode.SelectedIndex;

            try
            {
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
                            case 5: //Vacuum Leakage - Released Position //nao tem acionamento
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);

                TAB_Main.SelectedTab = TAB_Main.TabPages["Tab_ActuationParameters"];

                throw;
            }
        }
        private void TAB_ActuationParameters_GeneralSettings_CoBActuationMode_Change(int idxSelected)
        {
            try
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
                HelperTestBase.ActuationType = idxSelected;
                HelperTestBase.iActuaionMode = idxSelected;

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
                            mtxt_Actuation_Unit_E1ParMaxForce.Text = "N";
                            mtxt_Actuation_Unit_E1ParForceGrad.Text = "N/s";

                            break;
                        }
                    case 2://ActuationMode - Pneumatic Fast
                        {
                            _modelGVL.GVL_Parametros.rGradienteForca = HelperTestBase.ForceGradient;

                            _modelGVL.GVL_Parametros.iModo = 2;
                            mtxt_Actuation_E1ParForceGrad.Text = _modelGVL.GVL_Parametros.rGradienteForca.ToString();
                            mtxt_Actuation_Unit_E1ParMaxForce.Text = "N";
                            mtxt_Actuation_Unit_E1ParForceGrad.Text = "%";
                            break;
                        }
                    case 3://ActuationMode - E-Motor
                        {
                            //set defaulty value
                            _modelGVL.GVL_Parametros.rVelocidadeAtuacao_mm_s = 1; //HelperTestBase.ForceGradient

                            _modelGVL.GVL_Parametros.iModo = 3;
                            mtxt_Actuation_E1ParForceGrad.Text = _modelGVL.GVL_Parametros.rVelocidadeAtuacao_mm_s.ToString();
                            mtxt_Actuation_Unit_E1ParMaxForce.Text = "N";
                            mtxt_Actuation_Unit_E1ParForceGrad.Text = "mm/s";
                            break;
                        }
                    default:
                        {
                            _modelGVL.GVL_Parametros.iModo = 0;
                            mtxt_Actuation_E1ParForceGrad.Text = _notReadValue;
                            mtxt_Actuation_Unit_E1ParMaxForce.Text = "---";
                            mtxt_Actuation_Unit_E1ParForceGrad.Text = "---";
                            break;
                        }
                }

                HelperApp.uiActuationMode = _modelGVL.GVL_Parametros.iModo;
                HelperTestBase.ActuationType = HelperApp.uiActuationMode;

                HelperTestBase.Model_GVL.GVL_Parametros.iModo = HelperTestBase.ActuationType;

                _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_wModo }, HelperApp.uiActuationMode);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);

                TAB_Main.SelectedTab = TAB_Main.TabPages["Tab_ActuationParameters"];

                throw;
            }
        }

        #endregion

        #region TAB - ActuationParameters - General Settings - CBO Test Type
        private void TAB_ActuationParameters_GeneralSettings_CoBSelectTest_Populate()
        {
            try
            {
                _bAppStart = true;

                DataTable dt = new BLL_Manager_TestAvailable().GetAvailableTests();

                DataRow dr = dt.NewRow();
                dr.ItemArray = new object[] { 0, "-- No Selection Test --" };
                dt.Rows.InsertAt(dr, 0);

                mcbo_tabActParam_GenSettings_CoBSelectTest.ValueMember = "Id";

                mcbo_tabActParam_GenSettings_CoBSelectTest.DisplayMember = "Name";
                mcbo_tabActParam_GenSettings_CoBSelectTest.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);

                TAB_Main.SelectedTab = TAB_Main.TabPages["Tab_ActuationParameters"];

                throw;
            }
        }
        private void mcbo_GeneralSettings_CoBSelectTest_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                TAB_Disable(_helperApp.GetMethodName());

                if (!_bAppStart)
                    if (HelperApp.uiProjectSelecionado == 0)
                        TEST_Concluded_ClearData();

                if (!_bAppStart)
                {
                    int idxSelected = mcbo_tabActParam_GenSettings_CoBSelectTest.SelectedIndex;

                    if(!TAB_ActuationParameters_GeneralSettings_CoBSelectTest_Change(idxSelected, _helperApp.GetMethodName()))
                    {
                        MessageBox.Show("Error , Fail TAB_ActuationParameters_GeneralSettings_CoBSelectTest_Change!", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);

                        TAB_Main.SelectedTab = TAB_Main.TabPages["Tab_ActuationParameters"];
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);

                TAB_Main.SelectedTab = TAB_Main.TabPages["Tab_ActuationParameters"];

                throw;
            }
        }
        public bool TAB_ActuationParameters_GeneralSettings_CoBSelectTest_Change(int idxSelected, string origin)
        {
            try
            {
                if (!_bAppStart)
                {
                    if (idxSelected == 0 && _bCoBSelectTestSelected)
                    {
                        mcbo_tabActParam_GenSettings_CoBSelectTest.SelectedIndex = 0;

                        _bCoBSelectTestSelected = false;

                        DisableButtonStart();

                        MessageBox.Show("Warning, Change SelectTest invalid option!", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        return false;
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
                                case 25:    //Force Diagrams - Force/Pressure Dual Ratio
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

                            #region Consumers                            

                            switch (idxSelected)
                            {
                                case 9:     //Hydraulic Leakage - At Low Pressure
                                case 10:     //Hydraulic Leakage - At High Pressure
                                    {
                                        grpRadConsumer.Visible = false;

                                        mtxt_GeneralSettings_ETubeConsumerPCPressSide.Enabled = false;
                                        mtxt_GeneralSettings_ETubeConsumerSCPressSide.Enabled = false;
                                        mbtn_GeneralSettings_BSelectTubeCons.Enabled = false;

                                        break;
                                    }
                                default:
                                    {
                                        grpRadConsumer.Visible = true;

                                        mtxt_GeneralSettings_ETubeConsumerPCPressSide.Enabled = false;
                                        mtxt_GeneralSettings_ETubeConsumerSCPressSide.Enabled = false;
                                        mbtn_GeneralSettings_BSelectTubeCons.Enabled = true;

                                        break;
                                    }
                            }

                            #endregion

                            if (!TAB_ActuationParameters_GeneralSettings_CoBSelectTest_SetChange(HelperApp.uiTesteSelecionado))
                            {
                                MessageBox.Show("Error , Fail TAB_ActuationParameters_GeneralSettings_CoBSelectTest_SetChange!", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);

                                TAB_Main.SelectedTab = TAB_Main.TabPages["Tab_ActuationParameters"];

                                _bCoBSelectTestSelected = false;

                                DisableButtonStart();

                                return false;
                            }

                            _bCoBSelectTestSelected = true;

                            EnableButtonStart();
                        }
                    }
                }
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
        public bool TAB_ActuationParameters_GeneralSettings_CoBSelectTest_SetChange(int idTest)
        {
            try
            {
                if (idTest == 0 && _bCoBSelectTestSelected)
                {
                    mcbo_tabActParam_GenSettings_CoBSelectTest.SelectedIndex = 0;

                    _bCoBSelectTestSelected = false;

                    MessageBox.Show("Warning, Set SelectTest invalid option!", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                else
                {
                    HelperApp.uiTesteSelecionado = mcbo_tabActParam_GenSettings_CoBSelectTest.Items.Count == 0 ? idTest : Convert.ToInt32(mcbo_tabActParam_GenSettings_CoBSelectTest.SelectedValue.ToString());

                    HelperApp.strNomeTesteSelecionado = mcbo_tabActParam_GenSettings_CoBSelectTest.Items.Count > 0 ? mcbo_tabActParam_GenSettings_CoBSelectTest.Text.Trim() : EnumExtensionMethods.GetDescriptionEXAMTYPE(HelperTestBase.eExamType).ToString();
                    mTile_LCurrentSelectedTest.Text = HelperApp.strNomeTesteSelecionado;

                    var last_sel_ix = -1;

                    if (HelperApp.uiTesteSelecionado >= 0)
                    {
                        //set Variables
                        HelperTestBase.eExamType = EnumExtensionMethods.GetEnumValue<eEXAMTYPE>(HelperApp.uiTesteSelecionado);

                        if (HelperTestBase.eExamType == eEXAMTYPE.ET_USER_DEFINED)
                            HelperTestBase.ProjectTestConcluded.ProjectTestSample.Project.is_user_defined = true;

                        //  // save edited data & load corresp. data of new selection, if user defined test
                        if (HelperTestBase.eExamType != eEXAMTYPE.ET_NONE)
                            if (HelperTestBase.ProjectTestConcluded?.ProjectTestSample?.Project != null)
                            {
                                if (HelperTestBase.ProjectTestConcluded.ProjectTestSample.Project.is_user_defined)
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

                                if (HelperTestBase.ProjectTestConcluded.ProjectTestSample.Project.is_OnLIne)
                                {
                                    HelperTestBase.Model_GVL.GVL_Graficos = _helperApp.ChartValidate(HelperApp.uiTesteSelecionado, HelperTestBase.Model_GVL.GVL_Graficos.iOutput);

                                    HelperTestBase.ProjectTestConcluded.ProjectTestSample.Project.is_Created = false;
                                }

                            }

                        tab_TableResultsEnable = false;
                        _bCoBSelectTestSelected = false;

                        if(!TAB_ActuationParameters_PopulateData(HelperApp.uiTesteSelecionado, _helperApp.GetMethodName()))
                        {
                            MessageBox.Show("Error, PopulateData!", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);

                            TAB_Main.SelectedTab = TAB_Main.TabPages["Tab_ActuationParameters"];
                            return false;
                        }

                        last_sel_ix = HelperApp.uiTesteSelecionado;
                    }

                    _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_wTesteSelecionado }, HelperApp.uiTesteSelecionado);
                }
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

                    HelperTestBase.iOutputType = HelperTestBase.Model_GVL.GVL_Graficos.iOutput;

                    _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_wOutput }, Convert.ToDouble(_modelGVL.GVL_Parametros.iOutput));

                    if (_helperApp.lstDblReturnReadFile[0] != null && HelperTestBase.ProjectTestConcluded?.ProjectTestSample?.Project != null)
                    {
                        if (HelperTestBase.ProjectTestConcluded.IdProjectTestConcluded > 0)
                        {
                            if (HelperTestBase.ProjectTestConcluded.ProjectTestSample.Project.is_OnLIne)
                            {
                                if (TXTFileHBM_LoadData(_helperApp.GetMethodName()))
                                {
                                    TAB_Enable(_helperApp.GetMethodName());
                                    TAB_Main.SelectedTab = TAB_Main.TabPages["tab_Diagram"];
                                }
                                else
                                {
                                    TAB_Disable(_helperApp.GetMethodName());
                                    TAB_Main.SelectedTab = TAB_Main.TabPages["Tab_ActuationParameters"];
                                    MessageBox.Show("Error TXTFileHBM_LoadData, failed load result data test!", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                            }
                            else
                            {
                                //if (!_bPrjTestOffLineCarregado)
                                //{
                                if (TXTFileHBM_LoadDataConcluded(_helperApp.GetMethodName()))
                                {
                                    TAB_Enable(_helperApp.GetMethodName());
                                    TAB_Main.SelectedTab = TAB_Main.TabPages["tab_Diagram"];
                                }
                                else
                                {
                                    TAB_Disable(_helperApp.GetMethodName());
                                    TAB_Main.SelectedTab = TAB_Main.TabPages["Tab_ActuationParameters"];
                                    MessageBox.Show("Error TXTFileHBM_LoadDataConcluded, failed load result data test!", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }

                                //}
                            }
                        }
                        else
                        {
                            if (TXTFileHBM_LoadData(_helperApp.GetMethodName()))
                            {
                                TAB_Enable(_helperApp.GetMethodName());
                                TAB_Main.SelectedTab = TAB_Main.TabPages["tab_Diagram"];
                            }
                            else
                            {
                                TAB_Disable(_helperApp.GetMethodName());
                                TAB_Main.SelectedTab = TAB_Main.TabPages["Tab_ActuationParameters"];
                                MessageBox.Show("Error TXTFileHBM_LoadData, failed load result data test!", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
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

                    HelperTestBase.iOutputType = HelperTestBase.Model_GVL.GVL_Graficos.iOutput;

                    _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_wOutput }, Convert.ToDouble(_modelGVL.GVL_Parametros.iOutput));

                    if (_helperApp.lstDblReturnReadFile[0] != null && HelperTestBase.ProjectTestConcluded?.ProjectTestSample?.Project != null)
                    {
                        if (HelperTestBase.ProjectTestConcluded.IdProjectTestConcluded > 0)
                        {
                            if (HelperTestBase.ProjectTestConcluded.ProjectTestSample.Project.is_OnLIne)
                            {
                                if (TXTFileHBM_LoadData(_helperApp.GetMethodName()))
                                {
                                    TAB_Enable(_helperApp.GetMethodName());
                                    TAB_Main.SelectedTab = TAB_Main.TabPages["tab_Diagram"];
                                }
                                else
                                    MessageBox.Show("Error TXTFileHBM_LoadData, failed load result data test!", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            else
                            {
                                //if (!_bPrjTestOffLineCarregado)
                                //{
                                if (TXTFileHBM_LoadDataConcluded(_helperApp.GetMethodName()))
                                {
                                    TAB_Enable(_helperApp.GetMethodName());
                                    TAB_Main.SelectedTab = TAB_Main.TabPages["tab_Diagram"];
                                }
                                else
                                    MessageBox.Show("Error TXTFileHBM_LoadDataConcluded, failed load result data test!", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                //}
                            }
                        }
                        else
                        {
                            if (TXTFileHBM_LoadData(_helperApp.GetMethodName()))
                            {
                                TAB_Enable(_helperApp.GetMethodName());
                                TAB_Main.SelectedTab = TAB_Main.TabPages["tab_Diagram"];
                            }
                            else
                                MessageBox.Show("Error TXTFileHBM_LoadData, failed load result data test!", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
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
        private void TAB_ActuationParameters_GeneralSettings_Vacuum_Change(string strValue)
        {
            if (!string.IsNullOrEmpty(strValue))
            {
                var dblValue = _helperApp.NumberDoubleCheck(strValue);

                if (dblValue > 0)
                {
                    MessageBox.Show("This value not is accept!", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    mtxt_GeneralSettings_EParGenVacuum.Text = "0";
                    return;
                }
                else
                {
                    mtxt_GeneralSettings_EParGenVacuum.Text = dblValue.ToString("N2");

                    HelperTestBase.VacuumMin = (dblValue < 0 ? (dblValue + 0.02) : (dblValue - 0.02));
                    HelperTestBase.VacuumMax = (dblValue < 0 ? (dblValue - 0.02) : (dblValue + 0.02));

                    mtxt_GeneralSettings_EParGenVacuumMin.Text = HelperTestBase.VacuumMin.ToString("N2");
                    mtxt_GeneralSettings_EParGenVacuumMax.Text = HelperTestBase.VacuumMax.ToString("N2");

                    //para conversao plc
                    dblValue = (dblValue * -1);

                    HelperTestBase.Vacuum = dblValue;

                    _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_dwVacuoNominal_Bar_LW }, dblValue);
                }
            }
        }
        private void mtxt_GeneralSettings_EParGenVacuumMin_TextChanged(object sender, EventArgs e)
        {
            string strValueText = ((MetroFramework.Controls.MetroTextBox)sender).Text;

            if (!string.IsNullOrWhiteSpace(strValueText))
            {
                if (!Regex.IsMatch(strValueText, "[^0-9]"))
                {
                    MessageBox.Show("Please enter only numbers.");
                    mtxt_GeneralSettings_EParGenVacuumMin.Text = mtxt_GeneralSettings_EParGenVacuumMin.Text.Remove(mtxt_GeneralSettings_EParGenVacuumMin.Text.Length - 1);
                }
            }
        }
        private void mtxt_GeneralSettings_EParGenVacuumMax_TextChanged(object sender, EventArgs e)
        {
            string strValueText = ((MetroFramework.Controls.MetroTextBox)sender).Text;

            if (!string.IsNullOrWhiteSpace(strValueText))
            {
                if (!Regex.IsMatch(strValueText, "[^0-9]"))
                {
                    MessageBox.Show("Please enter only numbers.");
                    mtxt_GeneralSettings_EParGenVacuumMax.Text = mtxt_GeneralSettings_EParGenVacuumMax.Text.Remove(mtxt_GeneralSettings_EParGenVacuumMax.Text.Length - 1);
                }
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

            TAB_ActuationParameters_GeneralSettings_Vacuum_Change(strValue);
        }
        private void mbtn_GeneralSettings_Minus_EParGenVaccum_Accel_L_Click(object sender, EventArgs e)
        {
            double paramStep = 0.01;

            string strName = ((System.Windows.Forms.Control)sender).Name;

            string strValue = mtxt_GeneralSettings_EParGenVacuum.Text.Trim();

            string strTypeAction = "Minus";

            if (!string.IsNullOrEmpty(strValue))
            {
                var dblValue = _helperApp.NumberDoubleCheck(strValue);

                if (dblValue > 0)
                {
                    MessageBox.Show("This value not is accept!", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    mtxt_GeneralSettings_EParGenVacuum.Text = "0";
                    return;
                }
                else
                {
                    dblValue = (dblValue < 0 ? (dblValue + paramStep) : (dblValue - paramStep));
                    mtxt_GeneralSettings_EParGenVacuum.Text = dblValue.ToString("N2");

                    mtxt_GeneralSettings_EParGenVacuumMin.Text = (dblValue < 0 ? (dblValue + paramStep) : (dblValue - paramStep)).ToString("N2");
                    mtxt_GeneralSettings_EParGenVacuumMax.Text = (dblValue < 0 ? (dblValue - paramStep) : (dblValue + paramStep)).ToString("N2");


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

            string strValue = mtxt_GeneralSettings_EParGenVacuum.Text.Trim();

            string strTypeAction = "Plus";

            if (!string.IsNullOrEmpty(strValue))
            {
                var dblValue = _helperApp.NumberDoubleCheck(strValue);

                if (dblValue > 0)
                {
                    MessageBox.Show("This value not is accept!", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    mtxt_GeneralSettings_EParGenVacuum.Text = "0";
                    return;
                }
                else
                {
                    dblValue = (dblValue < 0 ? (dblValue - paramStep) : (dblValue + paramStep));
                    mtxt_GeneralSettings_EParGenVacuum.Text = dblValue.ToString("N2");

                    mtxt_GeneralSettings_EParGenVacuumMin.Text = (dblValue < 0 ? (dblValue + paramStep) : (dblValue - paramStep)).ToString("N2");
                    mtxt_GeneralSettings_EParGenVacuumMax.Text = (dblValue < 0 ? (dblValue - paramStep) : (dblValue + paramStep)).ToString("N2");

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
        private void grid_tabActionParam_EvalParam_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var row = ((DataGridView)sender).CurrentRow;
            string strName = ((DataGridView)sender).CurrentRow.Cells["EvalParam_Name"].Value.ToString();
            string strValue = ((DataGridView)sender).CurrentCell.EditedFormattedValue.ToString();

            if (row == null)
            {
                MessageBox.Show("Error, failed selected row data test!", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }  
            else
            {
                if (!string.IsNullOrEmpty(strValue) && !string.IsNullOrEmpty(strName) && HelperApp.uiTesteSelecionado > 0)
                    TAB_ActuationParameters_WriteComGridEvalParameters(null, strName, strValue);
            }
        }
        private void grid_tabActionParam_EvalParam_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewCell gvCell = grid_tabActionParam_EvalParam.Rows[e.RowIndex].Cells[0];

                if (gvCell.GetType() == typeof(DataGridViewCheckBoxCell))
                {
                    if (HelperApp.uiTesteSelecionado != 24)
                    {
                        if (e.RowIndex >= 0)
                            gvCell.Value = !Convert.ToBoolean(gvCell.Value);
                    }
                    else
                    {
                        List<DataGridViewCell> lstGvCell = new List<DataGridViewCell>();

                        for (int i = 0; i < 3; i++)
                        {
                            var cell = grid_tabActionParam_EvalParam.Rows[i].Cells[0];

                            if (e.RowIndex >= 0)
                            {
                                cell.Value = !Convert.ToBoolean(cell.Value);
                            }

                            lstGvCell.Add(cell);
                        }
                    }
                }
            }
        }
        private void grid_tabActionParam_EvalParam_Scroll(object sender, ScrollEventArgs e)
        {
            //force redraw first row when scrolling
            for (int i = 0; i < (sender as DataGridView).ColumnCount; i++)
                (sender as DataGridView).InvalidateCell(i, 0);
        }
        private bool TAB_ActuationParameters_EvalParameters_Grid_Format()
        {
            try
            {
                grid_tabActionParam_EvalParam.Height = HelperApp.uiTesteSelecionado != 24 ? 517 : 400;
                grid_tabActionParam_EvalParam.Top = HelperApp.uiTesteSelecionado != 24 ? 51 : 170;


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

                grid_tabActionParam_EvalParam.RowHeadersVisible = false; //default column grid

                //show grid's column's
                grid_tabActionParam_EvalParam.Columns["IdEvalParam"].Visible = true; //ID
                grid_tabActionParam_EvalParam.Columns["IdEvalParam"].Width = _bUseChkGrid ? 45 : 0;

                // grid_tabActionParam_EvalParam.Columns["IdEvalParam"].DefaultCellStyle.Font = new Font("Tahoma", 15);
                grid_tabActionParam_EvalParam.Columns["IdEvalParam"].DefaultCellStyle.ForeColor = Color.White;
                grid_tabActionParam_EvalParam.Columns["IdEvalParam"].DefaultCellStyle.BackColor = Color.White;
                grid_tabActionParam_EvalParam.Columns["IdEvalParam"].DefaultCellStyle.SelectionForeColor = Color.White;
                grid_tabActionParam_EvalParam.Columns["IdEvalParam"].DefaultCellStyle.SelectionBackColor = Color.White;
                grid_tabActionParam_EvalParam.Columns["IdEvalParam"].DisplayIndex = 0;

                grid_tabActionParam_EvalParam.Columns["EvalParam_Caption"].HeaderCell.Value = "Parameter";
                grid_tabActionParam_EvalParam.Columns["EvalParam_Caption"].Visible = true; //CAPTION
                grid_tabActionParam_EvalParam.Columns["EvalParam_Caption"].Width = _bUseChkGrid ? 500 : 550;
                grid_tabActionParam_EvalParam.Columns["EvalParam_Caption"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                grid_tabActionParam_EvalParam.Columns["EvalParam_Caption"].DisplayIndex = 1;

                grid_tabActionParam_EvalParam.Columns["EvalParam_Hi"].HeaderCell.Value = "Hi Value";
                grid_tabActionParam_EvalParam.Columns["EvalParam_Hi"].ReadOnly = false;
                grid_tabActionParam_EvalParam.Columns["EvalParam_Hi"].Visible = true; //HI
                grid_tabActionParam_EvalParam.Columns["EvalParam_Hi"].Width = 200;
                grid_tabActionParam_EvalParam.Columns["EvalParam_Hi"].DisplayIndex = 2;

                grid_tabActionParam_EvalParam.Columns["UnitSymbol"].HeaderCell.Value = "Unit";
                grid_tabActionParam_EvalParam.Columns["UnitSymbol"].Visible = true; //UNIT
                grid_tabActionParam_EvalParam.Columns["UnitSymbol"].Width = _bUseChkGrid ? 135 : 150;
                grid_tabActionParam_EvalParam.Columns["UnitSymbol"].DisplayIndex = 3;

                grid_tabActionParam_EvalParam.Columns["EvalParam_ResultParam_Name"].HeaderCell.Value = "EvalParam_ResultParam_Name";
                grid_tabActionParam_EvalParam.Columns["EvalParam_ResultParam_Name"].Visible = true;
                grid_tabActionParam_EvalParam.Columns["EvalParam_ResultParam_Name"].Width = 0;
                grid_tabActionParam_EvalParam.Columns["EvalParam_ResultParam_Name"].DisplayIndex = 4;

                grid_tabActionParam_EvalParam.Columns["EvalParam_Name"].HeaderCell.Value = "Param_Name";
                grid_tabActionParam_EvalParam.Columns["EvalParam_Name"].Visible = true;
                grid_tabActionParam_EvalParam.Columns["EvalParam_Name"].Width = 0;
                grid_tabActionParam_EvalParam.Columns["EvalParam_Name"].DisplayIndex = 5;

                //set focus
                var rowIndex = 0;//grid_tabActionParam_EvalParam.Rows.Count - 1;

                grid_tabActionParam_EvalParam.CurrentCell = grid_tabActionParam_EvalParam.Rows[rowIndex].Cells["EvalParam_Hi"];
                grid_tabActionParam_EvalParam.Rows[rowIndex].Selected = true;
                grid_tabActionParam_EvalParam.Rows[rowIndex].Cells["EvalParam_Hi"].Selected = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Concat("Error - TAB_ActuationParameters_EvalParameters_Grid_Format : \n\n", ex.Message), _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;

                throw;
            }

            return true;
        }
        private bool TAB_ActuationParameters_EvalParameters_Grid_FormatRadioGroup(int rbId, string rbName, bool rbChecked)
        {
            try
            {
                // DataGridViewRow gvRow = grid_tabActionParam_EvalParam.Rows[iRowIndex];
                if (rbChecked)
                {
                    switch (rbName)
                    {
                        case "RBShowPressureForce": //Show Pressure/Force
                            HelperTestBase.Model_GVL.GVL_T24.iTipoGrafico = 0;
                            break;
                        case "RBShowPressureTimeSlow": //Show Pressure/Time Slow
                            HelperTestBase.Model_GVL.GVL_T24.iTipoGrafico = 1;
                            break;
                        case "RBShowPressureTimeFast": //Show Pressure/ Time Fast
                            HelperTestBase.Model_GVL.GVL_T24.iTipoGrafico = 2;
                            break;
                        default:
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Concat("Error - TAB_ActuationParameters_EvalParameters_Grid_FormatRadioGroup : \n\n", ex.Message), _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;

                throw;
            }

            return true;
        }
        private void TAB_ActuationParameters_EvalParameters_RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            int rbId = Convert.ToInt32(((Control)sender).Tag?.ToString()?.Trim());
            string rbName = ((Control)sender).Name?.ToString()?.Trim();
            string rbText = ((ButtonBase)sender).Text?.ToString()?.Trim();
            bool rbChecked = ((RadioButton)sender).Checked;

            TAB_ActuationParameters_EvalParameters_Grid_FormatRadioGroup(rbId, rbName, rbChecked);
        }
        private bool TAB_ActuationParameters_EvalParameters_Grid_GridRowType(DataTable dtGridEvalParameters)
        {
            try
            {
                #region Declare Variables

                string strGridRowType = string.Empty;
                string strEvalParam_Name = string.Empty;

                int countColumns = dtGridEvalParameters.Columns.Count;
                int countRows = dtGridEvalParameters.Rows.Count;
                var columnSpec = new DataColumn();

                int iRowIndex = 0;

                DataTable dt = new DataTable();
                var listOfCols = new List<DataColumn>();
                var listOfRows = new List<DataRow>();

                #endregion

                #region SET COLUMNS

                for (int k = 0; k < countColumns; k++)
                {
                    columnSpec = new DataColumn
                    {
                        DataType = dtGridEvalParameters.Columns[k].DataType, // This is of type System.Type
                        ColumnName = dtGridEvalParameters.Columns[k].ColumnName // This is of type string
                    };

                    dt.Columns.Add(columnSpec);

                    listOfCols.Add(columnSpec);
                }

                grid_tabActionParam_EvalParam.DataSource = dt;

                #endregion

                #region SET ROWS

                if (dtGridEvalParameters.Columns.Count > 0)
                {
                    //int dtRowsCount = dt.Rows.Count();

                    //// Create and initialize a GroupBox and a Button control.
                    GroupBox grpBox = new GroupBox();
                    var metroPnl = CONTROLS_GetAll(this, typeof(MetroPanel)).Find(a => a.Name == "mPnl_tabActParam_EvaluationParameters");

                    int iItemArrayCount = dtGridEvalParameters.Rows[0].ItemArray.Count();

                    for (int j = 0; j < countRows; j++)
                    {
                        #region Set Variable 

                        iRowIndex = j;

                        DataRow row = dtGridEvalParameters.Rows[iRowIndex];

                        if (!row.ItemArray[3].ToString().StartsWith("RB")) ///"EvalParam_Name"
                            dt.Rows.Add(new object[iItemArrayCount]);

                        DataGridViewTextBoxCell TextBoxCell_Id = new DataGridViewTextBoxCell();
                        int idxCol_Id = row.Table.Columns["IdEvalParam"].Ordinal;
                        int iEvalParam_Id = row.Field<int>("IdEvalParam");

                        DataGridViewTextBoxCell TextBoxCell_GridRowType = new DataGridViewTextBoxCell();
                        int idxCol_GridRowType = row.Table.Columns["EvalParam_GridRowType"].Ordinal;
                        strGridRowType = row.Field<string>("EvalParam_GridRowType").ToString();

                        DataGridViewTextBoxCell TextBoxCell_Name = new DataGridViewTextBoxCell();
                        int idxCol_Name = row.Table.Columns["EvalParam_Name"].Ordinal;

                        DataGridViewTextBoxCell TextBoxCell_EvalParam_ResultParam_Name = new DataGridViewTextBoxCell();
                        int idxCol_EvalParam_ResultParam_Name = row.Table.Columns["EvalParam_ResultParam_Name"].Ordinal;
                        string strEvalParam_ResultParam_Name = string.Empty;

                        DataGridViewTextBoxCell TextBoxCell_Caption = new DataGridViewTextBoxCell();
                        int idxCol_Caption = row.Table.Columns["EvalParam_Caption"].Ordinal;
                        string strEvalParam_Caption = string.Empty;

                        #endregion

                        switch (strGridRowType)
                        {
                            case "ADDINPUT_CREATE_VSPACE":
                                {
                                    if (HelperApp.uiTesteSelecionado != 24)
                                    {
                                        iRowIndex = HelperApp.uiTesteSelecionado != 24 ? j : j - 3;

                                        grid_tabActionParam_EvalParam[idxCol_GridRowType, iRowIndex] = TextBoxCell_GridRowType;
                                        grid_tabActionParam_EvalParam[idxCol_GridRowType, iRowIndex].Value = strGridRowType;
                                        dt.Rows.Add(new object[iItemArrayCount]);
                                    }
                                }
                                break;
                            case "CREATE_ANALOG_INPUT":
                                {
                                    iRowIndex = HelperApp.uiTesteSelecionado != 24 ? j : j - 4;

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

                                    grid_tabActionParam_EvalParam[idxCol_GridRowType, iRowIndex] = TextBoxCell_GridRowType;
                                    grid_tabActionParam_EvalParam[idxCol_GridRowType, iRowIndex].Value = strGridRowType;

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

                                    grid_tabActionParam_EvalParam[idxCol_GridRowType, iRowIndex] = TextBoxCell_GridRowType;
                                    grid_tabActionParam_EvalParam[idxCol_GridRowType, iRowIndex].Value = strGridRowType;

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
                                {
                                    strEvalParam_Name = row.Field<string>("EvalParam_Name")?.ToString()?.Trim();
                                    strEvalParam_Caption = row.Field<string>("EvalParam_Caption")?.ToString()?.Trim();
                                    strEvalParam_ResultParam_Name = row.Field<string>("EvalParam_ResultParam_Name")?.ToString()?.Trim();

                                    grid_tabActionParam_EvalParam.Height = 400;
                                    grid_tabActionParam_EvalParam.Top = 170;

                                    if (strEvalParam_Name.StartsWith("RB"))
                                    {
                                        RadioButton radBtn = new RadioButton();

                                        radBtn.Location = new Point(20, (j + 1) * 20);
                                        radBtn.CheckedChanged += TAB_ActuationParameters_EvalParameters_RadioButton_CheckedChanged;
                                        radBtn.Tag = j.ToString();
                                        radBtn.Name = !string.IsNullOrEmpty(strEvalParam_Name) ? strEvalParam_Name : string.Concat("mPnl_tabActParam_EvaluationParameters_T24_Rb", j);
                                        radBtn.Text = strEvalParam_Caption;
                                        radBtn.AutoSize = true;

                                        grpBox.Location = new Point(5, 50);

                                        // Add the Button to the GroupBox.
                                        grpBox.Controls.Add(radBtn);
                                    }

                                    // Set the FlatStyle of the GroupBox.
                                    grpBox.FlatStyle = FlatStyle.Popup;
                                    //grpBox.BackColor = Color.Blue;
                                    grpBox.Width = grid_tabActionParam_EvalParam.Width;

                                }
                                break;
                            default:
                                break;
                        }
                    }

                    // Set the name of the GroupBox and Add in main Panel.
                    if (HelperApp.uiTesteSelecionado == 24)
                    {
                        grpBox.Name = "grpRadio_T24_Efficiency";

                        var lstPnl = CONTROLS_GetAll(this, typeof(MetroPanel));

                        metroPnl.AddControl(grpBox);
                    }

                    grid_tabActionParam_EvalParam.DataSource = dt;
                }

                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Concat("Error - TAB_ActuationParameters_EvalParameters_Grid_GridRowType : \n\n", ex.Message), _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;

                throw;
            }

            return true;
        }
        private bool TAB_ActuationParameters_EvalParameters_Grid_GridRowTypeOffLineByFile(Dictionary<string, string> dicReturnReadFileHeaderParamGridData, Dictionary<string, string> dicReturnReadFileHeaderParamGrid)
        {
            try
            {
                #region Declare Variables

                DataTable dtGridEvalParameters = new BLL_Main_Tab_ActuationParameters().PopulateGridEvalParametersByTest(HelperApp.uiTesteSelecionado.ToString());

                string strGridRowType = string.Empty;
                string strEvalParam_Name = string.Empty;

                int countColumns = dtGridEvalParameters.Columns.Count;
                int countRows = dicReturnReadFileHeaderParamGridData.Count();
                var columnSpec = new DataColumn();

                int iRowIndex = 0;

                DataTable dt = new DataTable();
                var listOfCols = new List<DataColumn>();
                var listOfRows = new List<DataRow>();

                #endregion

                #region SET COLUMNS

                for (int k = 0; k < countColumns; k++)
                {
                    columnSpec = new DataColumn
                    {
                        DataType = dtGridEvalParameters.Columns[k].DataType, // This is of type System.Type
                        ColumnName = dtGridEvalParameters.Columns[k].ColumnName // This is of type string
                    };

                    dt.Columns.Add(columnSpec);

                    listOfCols.Add(columnSpec);
                }

                grid_tabActionParam_EvalParam.DataSource = dt;

                #endregion

                #region SET ROWS

                if (dtGridEvalParameters.Columns.Count > 0)
                {
                    int iItemArrayCount = dtGridEvalParameters.Rows[0].ItemArray.Count();
                    var lstFileHeaderParamGridData = dicReturnReadFileHeaderParamGridData.ToList();
                    var lstFileHeaderParamGrid = dicReturnReadFileHeaderParamGrid.ToList();

                    //// Create and initialize a GroupBox and a Button control.
                    GroupBox grpBox = new GroupBox();
                    var metroPnl = CONTROLS_GetAll(this, typeof(MetroPanel)).Find(a => a.Name == "mPnl_tabActParam_EvaluationParameters");

                    for (int j = 0; j < countRows; j++)
                    {
                        #region Set Variables

                        //iRowIndex = j;
                        iRowIndex = HelperApp.uiTesteSelecionado != 24 ? j : j == 0 ? j : j - 4;

                        iRowIndex = HelperApp.uiTesteSelecionado != 24 ? j : iRowIndex <= 0 || j <= countRows ? j : j - 4;

                        DataRow row = dtGridEvalParameters.Rows[iRowIndex];

                        // if (!row.ItemArray[3].ToString().StartsWith("RB") && HelperApp.uiTesteSelecionado != 24) ///"EvalParam_Name"
                        dt.Rows.Add(new object[iItemArrayCount]);

                        DataGridViewTextBoxCell TextBoxCell_Id = new DataGridViewTextBoxCell();
                        int idxCol_Id = row.Table.Columns["IdEvalParam"].Ordinal;
                        int iEvalParam_Id = row.Field<int>("IdEvalParam");

                        DataGridViewTextBoxCell TextBoxCell_GridRowType = new DataGridViewTextBoxCell();
                        int idxCol_GridRowType = row.Table.Columns["EvalParam_GridRowType"].Ordinal;
                        strGridRowType = lstFileHeaderParamGridData[iRowIndex].Value.ToString();

                        DataGridViewTextBoxCell TextBoxCell_Name = new DataGridViewTextBoxCell();
                        int idxCol_Name = row.Table.Columns["EvalParam_Name"].Ordinal;

                        DataGridViewTextBoxCell TextBoxCell_EvalParam_ResultParam_Name = new DataGridViewTextBoxCell();
                        int idxCol_EvalParam_ResultParam_Name = row.Table.Columns["EvalParam_ResultParam_Name"].Ordinal;
                        string strEvalParam_ResultParam_Name = string.Empty;

                        DataGridViewTextBoxCell TextBoxCell_Caption = new DataGridViewTextBoxCell();
                        int idxCol_Caption = row.Table.Columns["EvalParam_Caption"].Ordinal;
                        string strEvalParam_Caption = string.Empty;

                        #endregion

                        switch (strGridRowType)
                        {
                            case "ADDINPUT_CREATE_VSPACE":
                                {
                                    if (HelperApp.uiTesteSelecionado != 24)
                                    {
                                        grid_tabActionParam_EvalParam[idxCol_GridRowType, iRowIndex] = TextBoxCell_GridRowType;
                                        grid_tabActionParam_EvalParam[idxCol_GridRowType, iRowIndex].Value = strGridRowType;
                                        dt.Rows.Add(new object[iItemArrayCount]);
                                    }
                                }
                                break;
                            case "CREATE_ANALOG_INPUT":
                                {
                                    strEvalParam_Name = lstFileHeaderParamGridData[iRowIndex].Key.ToString()?.Trim();
                                    strEvalParam_Caption = lstFileHeaderParamGrid[iRowIndex].Key?.ToString()?.Trim();
                                    strEvalParam_ResultParam_Name = row.Field<string>("EvalParam_ResultParam_Name")?.ToString()?.Trim();

                                    DataGridViewTextBoxCell TextBoxCell_Hi = new DataGridViewTextBoxCell();
                                    int idxCol_Hi = row.Table.Columns["EvalParam_Hi"].Ordinal;
                                    double dblEvalParam_Hi = _helperApp.NumberDoubleCheck(lstFileHeaderParamGrid[iRowIndex].Value?.ToString()?.Trim()) * -1;

                                    DataGridViewTextBoxCell TextBoxCell_UnitSymbol = new DataGridViewTextBoxCell();
                                    int idxCol_UnitSymbol = row.Table.Columns["UnitSymbol"].Ordinal;
                                    string strEvalParam_UnitSymbol = row.Field<string>("UnitSymbol")?.ToString()?.Trim();

                                    grid_tabActionParam_EvalParam[idxCol_Id, iRowIndex] = TextBoxCell_Id;
                                    grid_tabActionParam_EvalParam[idxCol_Id, iRowIndex].Value = iEvalParam_Id;

                                    grid_tabActionParam_EvalParam[idxCol_GridRowType, iRowIndex] = TextBoxCell_GridRowType;
                                    grid_tabActionParam_EvalParam[idxCol_GridRowType, iRowIndex].Value = strGridRowType;

                                    grid_tabActionParam_EvalParam[idxCol_Caption, iRowIndex] = TextBoxCell_Caption;
                                    grid_tabActionParam_EvalParam[idxCol_Caption, iRowIndex].Value = strEvalParam_Caption;

                                    grid_tabActionParam_EvalParam[idxCol_Hi, iRowIndex] = TextBoxCell_Hi;
                                    grid_tabActionParam_EvalParam[idxCol_Hi, iRowIndex].Value = dblEvalParam_Hi;

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
                                    strEvalParam_Name = lstFileHeaderParamGridData[iRowIndex].Key.ToString()?.Trim();
                                    strEvalParam_Caption = lstFileHeaderParamGrid[iRowIndex].Key?.ToString()?.Trim();
                                    strEvalParam_ResultParam_Name = row.Field<string>("EvalParam_ResultParam_Name")?.ToString()?.Trim();
                                    bool chkStatus = Convert.ToBoolean(lstFileHeaderParamGrid[iRowIndex].Value?.ToString()?.Trim());

                                    DataGridViewCheckBoxCell CheckBoxCell = new DataGridViewCheckBoxCell();
                                    CheckBoxCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

                                    grid_tabActionParam_EvalParam[idxCol_Id, iRowIndex] = TextBoxCell_Id;
                                    grid_tabActionParam_EvalParam[idxCol_Id, iRowIndex].Value = iEvalParam_Id;

                                    grid_tabActionParam_EvalParam[idxCol_GridRowType, iRowIndex] = TextBoxCell_GridRowType;
                                    grid_tabActionParam_EvalParam[idxCol_GridRowType, iRowIndex].Value = strGridRowType;

                                    grid_tabActionParam_EvalParam[0, iRowIndex] = CheckBoxCell;
                                    grid_tabActionParam_EvalParam[0, iRowIndex].Value = chkStatus;

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
                                {
                                    strEvalParam_Name = lstFileHeaderParamGridData[iRowIndex].Key.ToString()?.Trim();
                                    strEvalParam_Caption = lstFileHeaderParamGrid[iRowIndex].Key?.ToString()?.Trim();
                                    strEvalParam_ResultParam_Name = row.Field<string>("EvalParam_ResultParam_Name")?.ToString()?.Trim();

                                    grid_tabActionParam_EvalParam.Height = 400;
                                    grid_tabActionParam_EvalParam.Top = 170;                                    

                                    if (strEvalParam_Name.StartsWith("RB"))
                                    {
                                        RadioButton radBtn = new RadioButton();

                                        radBtn.Location = new Point(20, (j + 1) * 20);
                                        radBtn.CheckedChanged += TAB_ActuationParameters_EvalParameters_RadioButton_CheckedChanged;
                                        radBtn.Tag = j.ToString();
                                        radBtn.Name = !string.IsNullOrEmpty(strEvalParam_Name) ? strEvalParam_Name : string.Concat("mPnl_tabActParam_EvaluationParameters_T24_Rb", j);
                                        radBtn.Text = strEvalParam_Caption;
                                        radBtn.AutoSize = true;

                                        grpBox.Location = new Point(5, 50);

                                        // Add the Button to the GroupBox.
                                        grpBox.Controls.Add(radBtn);

                                        //dt.AcceptChanges();
                                        // DataRow dr = dt.Rows[iRowIndex];
                                        //         dr.Delete();
                                        // dt.AcceptChanges();
                                    }
                                    // Set the FlatStyle of the GroupBox.
                                    grpBox.FlatStyle = FlatStyle.Standard;
                                    grpBox.Width = grid_tabActionParam_EvalParam.Width;
                                }

                                break;
                            default:
                                break;
                        }
                    }

                    // Set the name of the GroupBox and Add in main Panel.
                    grpBox.Name ="grpRadio_T24_Efficiency";
                    metroPnl.AddControl(grpBox);

                    grid_tabActionParam_EvalParam.DataSource = dt;
                }

                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Concat("Error - TAB_ActuationParameters_EvalParameters_Grid_GridRowTypeOffLineByFile : \n\n", ex.Message), _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;

                throw;
            }

            return true;
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
                        //chkStatus = Convert.ToBoolean(checkBoxCell.EditingCellFormattedValue);
                        chkStatus = Convert.ToBoolean(checkBoxCell.EditedFormattedValue);
                    }

                    switch (HelperApp.uiTesteSelecionado)
                    {
                        case 5:     //Vacuum Leakage - Released Position
                            break;
                        case 6:     //Vacuum Leakage - Fully Applied Position //CHECKBOX USE SINGLE INPUT FORCE
                            {
                                HelperTestBase.Model_GVL.GVL_T06.bForcaAbsoluta = chkStatus;
                                _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_wForcaAbsoluta_T06 }, Convert.ToDouble(chkStatus));
                            }
                            break;
                        case 7:     //Vacuum Leakage - Lap Position
                            {
                                switch (iRowIndex)
                                {
                                    case 8://CHECKBOX USE SINGLE INPUT FORCE
                                        HelperTestBase.Model_GVL.GVL_T07.bForcaAbsoluta = chkStatus;
                                        _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_wTesteSimples_T07 }, Convert.ToDouble(chkStatus));

                                        break;
                                    default://INCLUIR CHECKBOX (ABOLUTE/REATIVE)
                                        HelperTestBase.Model_GVL.GVL_T07.bForcaAbsoluta = chkStatus;
                                        _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_wForcaAbsoluta_T07 }, Convert.ToDouble(chkStatus));
                                        break;
                                }
                            }
                            break;
                        case 8:      //Hydraulic Leakage - Fully Applied Position
                            {
                                switch (iRowIndex)
                                {
                                    case 8:
                                        HelperTestBase.Model_GVL.GVL_T08.bForcaAbsoluta = chkStatus;
                                        _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_wForcaAbsoluta_T08 }, Convert.ToDouble(chkStatus));
                                        break;
                                    default:
                                        break;
                                }
                            }
                            break;
                        case 23:     //Breather Hole / Central Valve open //CHECKBOX PERFORM PRE ACTUATION
                            {
                                HelperTestBase.Model_GVL.GVL_T23.bExecutarPreAcionamento = chkStatus;
                                _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_wExecutarAcionamento_T23 }, Convert.ToDouble(chkStatus));
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
        }
        public void TAB_ActuationParameters_WriteComGridEvalParameters(List<ActuationParameters_EvaluationParameters> lstInfoEvaluationParameters, string strName, string strValue)
        {
            try
            {
                if (lstInfoEvaluationParameters == null)
                {
                    if (!string.IsNullOrEmpty(strName))
                    {
                        double dblValue = strName.StartsWith("CB") ? strValue.ToLower().Equals("true") ? 1 : 0 : Convert.ToDouble(strValue);
                        TAB_ActuationParameters_WriteComGridEvalParametersByTextName(strName, dblValue);
                    }
                    else
                        MessageBox.Show("Error, failed write runique row data test!", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    for (int i = 0; i < lstInfoEvaluationParameters.Count; i++)
                    {
                        int iRowIndex = i;

                        var itemEvalParam = lstInfoEvaluationParameters[i];

                        double dblValue = (double)itemEvalParam.EvalParam_Hi;

                        strValue = itemEvalParam.EvalParam_Hi.ToString();

                        strName = itemEvalParam.EvalParam_Name;

                        string strCaption = itemEvalParam.EvalParam_Caption;

                        string strCellType = itemEvalParam.EvalParam_GridRowType; //&& strCellType?.Equals("CREATE_ANALOG_INPUT")

                        if (!string.IsNullOrEmpty(strName))
                            TAB_ActuationParameters_WriteComGridEvalParametersByTextName(strName, dblValue);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool TAB_ActuationParameters_WriteComGridEvalParametersByTextName(string strName, double dblValue)
        {
            try
            {
                if (dblValue < 0)
                    dblValue = (dblValue * -1);

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

                                case "EActuationForceAtForce": //Actuation Force at Force = 
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
                    case 5: //Vacuum Leakage - Released Position
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
                                    _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_dwTempoTeste_T05_LW }, dblValue);
                                    break;

                                case "EStabTime": //Tempo de estabilizacao 
                                    HelperTestBase.Model_GVL.GVL_T05.rTempoEstabilizacao = dblValue;
                                    _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_dwTempoEstabilizacao_T05_LW }, dblValue);
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
                                    _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_dwTempoTeste_T06_LW }, dblValue);
                                    break;

                                case "EStabTime": //Tempo de estabilizacao
                                    HelperTestBase.Model_GVL.GVL_T06.rTempoEstabilizacao = dblValue;
                                    _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_dwTempoEstabilizacao_T06_LW }, dblValue);
                                    break;

                                case "EForcePercentEout": //Forca relativa a Eout (%)
                                    HelperTestBase.Model_GVL.GVL_T06.rForcaMaximaRelativa = dblValue;
                                    _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_dwForcaMaximaRelativa_T06_LW }, dblValue);
                                    break;

                                case "CBUseSingleInputForce": //Utilizar valor absoluto de forca
                                    HelperTestBase.Model_GVL.GVL_T06.bForcaAbsoluta = Convert.ToBoolean(dblValue);
                                    _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_wForcaAbsoluta_T06 }, dblValue);
                                    break;

                                case "EInputForce": //Forca Absoluta
                                    HelperTestBase.Model_GVL.GVL_T06.rForcaMaximaAbsoluta_N = dblValue;
                                    _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_dwForcaMaximaAbsoluta_T06_LW }, dblValue);
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

                                case "EVacuumScale":
                                    break;

                                case "ETestingTime": //Tempo de teste
                                    HelperTestBase.Model_GVL.GVL_T07.rTempoTeste = dblValue;
                                    _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_dwTempoTeste_T07_LW }, dblValue);
                                    break;

                                case "EStabTime": //Tempo de estabilizacao
                                    HelperTestBase.Model_GVL.GVL_T07.rTempoEstabilizacao = dblValue;
                                    _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_dwTempoEstabilizacao_T07_LW }, dblValue);
                                    break;

                                case "ERelInputForce1": //Forca relativa avanco intermediario
                                    HelperTestBase.Model_GVL.GVL_T07.rForcaRelativaAvanco = dblValue;
                                    _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_dwForcaRelativaAvanco_T07_LW }, dblValue);
                                    break;

                                case "ERelInputForce2": //Forca relativa retorno
                                    HelperTestBase.Model_GVL.GVL_T07.rForcaRelativaRetorno = dblValue;
                                    _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_dwForcaRelativaRetorno_T07_LW }, dblValue);
                                    break;

                                case "ERelInputForce3": //Forca relativa avanco final
                                    HelperTestBase.Model_GVL.GVL_T07.rForcaRelativaFinal = dblValue;
                                    _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_dwForcaRelativaFinal_T07_LW }, dblValue);
                                    break;

                                case "CBUseInputForce": //Utilizar valor absoluto de forca
                                    HelperTestBase.Model_GVL.GVL_T07.bTesteSimples = Convert.ToBoolean(dblValue);
                                    _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_wTesteSimples_T07 }, dblValue);
                                    break;

                                case "EInputForceRelative": //Forca relativa a Eout (%)
                                    HelperTestBase.Model_GVL.GVL_T07.rForcaMaximaRelativa = dblValue;
                                    _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_dwForcaMaximaRelativa_T07_LW }, dblValue);
                                    break;

                                case "EInputForce": //Forca Absoluta
                                    HelperTestBase.Model_GVL.GVL_T07.rForcaMaximaAbsoluta_N = dblValue;
                                    _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_dwForcaMaximaAbsoluta_T07_LW }, dblValue);
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
                                    _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_dwTempoTeste_T08_LW }, dblValue);
                                    break;

                                case "EStabTime": //Tempo de estabilizacao
                                    HelperTestBase.Model_GVL.GVL_T08.rTempoEstabilizacao = dblValue;
                                    _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_dwTempoEstabilizacao_T08_LW }, dblValue);
                                    break;

                                case "EForcePercentEout": //Forca relativa a Eout (%)
                                    HelperTestBase.Model_GVL.GVL_T08.rForcaMaximaRelativa = dblValue;
                                    _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_dwForcaMaximaRelativa_T08_LW }, dblValue);
                                    break;

                                case "CBUseSingleInputForce": //Utilizar valor absoluto de forca
                                    HelperTestBase.Model_GVL.GVL_T08.bForcaAbsoluta = Convert.ToBoolean(dblValue);
                                    _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_wForcaAbsoluta_T08 }, dblValue);
                                    break;

                                case "EInputForce": //Forca Absoluta
                                    HelperTestBase.Model_GVL.GVL_T08.rForcaMaximaAbsoluta_N = dblValue;
                                    _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_dwForcaMaximaAbsoluta_T08_LW }, dblValue);
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
                                    _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_dwPressaoTeste_T09_LW }, dblValue);
                                    break;

                                case "ETestingTime": //Tempo de teste
                                    HelperTestBase.Model_GVL.GVL_T09.rTempoTeste = dblValue;
                                    _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_dwTempoTeste_T09_LW }, dblValue);
                                    break;

                                case "EStabTime": //Tempo de estabilizacao
                                    HelperTestBase.Model_GVL.GVL_T09.rTempoEstabilizacao = dblValue;
                                    _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_dwTempoEstabilizacao_T09_LW }, dblValue);
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
                                    _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_dwPressaoTeste_T10_LW }, dblValue);
                                    break;

                                case "ETestingTime": //Tempo de teste
                                    HelperTestBase.Model_GVL.GVL_T10.rTempoTeste = dblValue;
                                    _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_dwTempoTeste_T10_LW }, dblValue);
                                    break;

                                case "EStabTime": //Tempo de estabilizacao
                                    HelperTestBase.Model_GVL.GVL_T10.rTempoEstabilizacao = dblValue;
                                    _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_dwTempoEstabilizacao_T10_LW }, dblValue);
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
                                case "ETravel3": //Curso em X pressao
                                    HelperTestBase.Model_GVL.GVL_T17.rCursoNaPressao3_Bar = dblValue;
                                    break;
                                case "ETravel4": //Curso em X pressao
                                    HelperTestBase.Model_GVL.GVL_T17.rCursoNaPressao4_Bar = dblValue;
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
                                    HelperTestBase.Model_GVL.GVL_T18.rCursoMortoNaPressao_Bar = dblValue;
                                    break;

                                case "ETravel1": //Curso em X pressao
                                    HelperTestBase.Model_GVL.GVL_T18.rCursoNaPressao1_Bar = dblValue;
                                    break;

                                case "ETravel2": //Curso em X pressao
                                    HelperTestBase.Model_GVL.GVL_T18.rCursoNaPressao2_Bar = dblValue;
                                    break;

                                case "ETravel3": //Curso em X pressao
                                    HelperTestBase.Model_GVL.GVL_T18.rCursoNaPressao3_Bar = dblValue;
                                    break;

                                case "ETravel4": //Curso em X pressao
                                    HelperTestBase.Model_GVL.GVL_T18.rCursoNaPressao4_Bar = dblValue;
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
                                    _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_dwTempoSopro_T19_LW }, dblValue);
                                    break;

                                case "EActTravel": //Deslocamento teste
                                    HelperTestBase.Model_GVL.GVL_T19.rDeslocamentoTeste = dblValue;
                                    _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_dwDeslocamentoTeste_T19_LW }, dblValue);
                                    break;

                                case "EPressureClosed": //Pressao desejada com sistema fechado
                                    HelperTestBase.Model_GVL.GVL_T19.rPressaoSistemaFechado_Bar = dblValue;
                                    _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_dwPressaoSistemaFechado_T19_LW }, dblValue);
                                    break;

                                case "EPressureOpened": //Pressao desejada com sistema aberto
                                    HelperTestBase.Model_GVL.GVL_T19.rPressaoSistemaAberto_Bar = dblValue;
                                    _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_dwPressaoSistemaAberto_T19_LW }, dblValue);
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
                                    _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_dwTempoSopro_T20_LW }, dblValue);
                                    break;

                                case "EActTravel": //Deslocamento teste
                                    HelperTestBase.Model_GVL.GVL_T20.rDeslocamentoTeste = dblValue;
                                    _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_dwDeslocamentoTeste_T20_LW }, dblValue);
                                    break;

                                case "EPressureClosed": //Pressao desejada com sistema fechado
                                    HelperTestBase.Model_GVL.GVL_T20.rPressaoSistemaFechado_Bar = dblValue;
                                    _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_dwPressaoSistemaFechado_T20_LW }, dblValue);
                                    break;

                                case "EPressureOpened": //Pressao desejada com sistema aberto
                                    HelperTestBase.Model_GVL.GVL_T20.rPressaoSistemaAberto_Bar = dblValue;
                                    _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_dwPressaoSistemaAberto_T20_LW }, dblValue);
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
                                    HelperTestBase.Model_GVL.GVL_T21.rPressaoTeste_Bar = dblValue;
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
                                    HelperTestBase.Model_GVL.GVL_T22.rForcaTempoInicialAtuacao_N = dblValue;
                                    break;

                                case "EActTimeTo": //
                                    HelperTestBase.Model_GVL.GVL_T22.rPorcentagemCalcTempoFinalAtuacao = dblValue;
                                    break;

                                case "CBMaxPress1": //
                                    if (dblValue > 0)
                                        HelperTestBase.Model_GVL.GVL_T22.iTipoAtuacaoFinal = 1;
                                    break;

                                case "CBOutPress1": //
                                    if (dblValue > 0)
                                        HelperTestBase.Model_GVL.GVL_T22.iTipoAtuacaoFinal = 2;
                                    break;

                                case "CBHelpPress1": //
                                    if (dblValue > 0)
                                        HelperTestBase.Model_GVL.GVL_T22.iTipoAtuacaoFinal = 3;
                                    break;

                                case "ERelTimeTo": //
                                    HelperTestBase.Model_GVL.GVL_T22.rPorcentagemCalcTempoFinalRetorno = dblValue;
                                    break;

                                case "CBMaxPress2": //
                                    if (dblValue > 0)
                                        HelperTestBase.Model_GVL.GVL_T22.iTipoRetornoFinal = 1;
                                    break;

                                case "CBOutPress2": //
                                    if (dblValue > 0)
                                        HelperTestBase.Model_GVL.GVL_T22.iTipoRetornoFinal = 2;
                                    break;

                                case "CBHelpPress2": //
                                    if (dblValue > 0)
                                        HelperTestBase.Model_GVL.GVL_T22.iTipoRetornoFinal = 3;
                                    break;

                                case "ERelTimeToTravelLeft": //
                                    HelperTestBase.Model_GVL.GVL_T22.rPosicaoTempoRetornoNoDeslocamento_mm = dblValue;
                                    break;

                                case "ETravelAtPOut": //
                                    HelperTestBase.Model_GVL.GVL_T22.rDeslocamentoNaPressao = dblValue;
                                    break;

                                case "EPressGradAt1": //
                                    HelperTestBase.Model_GVL.GVL_T22.rGradientePressaoMin_bar = dblValue;
                                    break;

                                case "EPressGradAt2": //
                                    HelperTestBase.Model_GVL.GVL_T22.rGradientePressaoMax_bar = dblValue;
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
                                    HelperTestBase.Model_GVL.GVL_T23.bExecutarPreAcionamento = Convert.ToBoolean(dblValue);
                                    _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_wExecutarAcionamento_T23 }, dblValue);
                                    break;

                                case "EHydrFillPressureMin": //Pressao Minima
                                    HelperTestBase.Model_GVL.GVL_T23.rPressaoHidraulicaMin_Bar = dblValue;
                                    _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_dwPressaoHidraulicaMin_T23_LW }, dblValue);
                                    break;

                                case "EHydrFillPressureMax": //Pressao Maximna
                                    HelperTestBase.Model_GVL.GVL_T23.rPressaoHidraulicaMax_Bar = dblValue;
                                    _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_dwPressaoHidraulicaMax_T23_LW }, dblValue);
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
                                case "RBShowPressureForce":
                                    if (dblValue > 0)
                                        HelperTestBase.Model_GVL.GVL_T24.iTipoGrafico = 0;
                                    break;

                                case "RBShowPressureTimeSlow":
                                    if (dblValue > 0)
                                        HelperTestBase.Model_GVL.GVL_T24.iTipoGrafico = 1;
                                    break;

                                case "RBShowPressureTimeFast":
                                    if (dblValue > 0)
                                        HelperTestBase.Model_GVL.GVL_T24.iTipoGrafico = 2;
                                    break;

                                case "EForceScale":
                                    break;

                                case "EPressureScale":
                                    break;

                                case "ETimeScale":
                                    break;

                                case "EPause": //Intervalo
                                    HelperTestBase.Model_GVL.GVL_T24.rIntervalo = dblValue;
                                    _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_dwIntervalo_T24_LW }, dblValue);
                                    break;

                                case "EFastMaxForce": //Forca Maxima modo rapido
                                    HelperTestBase.Model_GVL.GVL_T24.rForcaMaximaModoRapido = dblValue;
                                    _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_dwForcaMaximaModoRapido_T24_LW }, dblValue);
                                    break;

                                case "EFastGradient": //Gradiente abertura valvula - utilizar o parametro Geral Gradiente Pressao (%)
                                    _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_dwGradienteForca_LW }, dblValue);

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
                                case "CBShowDualRatioLines":
                                    if (dblValue > 0)
                                        HelperTestBase.Model_GVL.GVL_T25.bMostraLinhasDRAux = true;
                                    else
                                        HelperTestBase.Model_GVL.GVL_T25.bMostraLinhasDRAux = false;
                                    break;

                                case "EForceScale":
                                    break;

                                case "EPressureScale":
                                    break;

                                case "EP1AtForce": //Pressure at Force(E1)
                                    HelperTestBase.Model_GVL.GVL_T25.rForca_E1 = dblValue;
                                    break;

                                case "EP2AtForce": //Pressure at Force(E2)  
                                    HelperTestBase.Model_GVL.GVL_T25.rForca_E2 = dblValue;
                                    break;

                                case "EP3AtForce": //Pressure at Force(P1)
                                    HelperTestBase.Model_GVL.GVL_T25.rForca_P1 = dblValue;
                                    break;

                                case "EP4AtForce": //Pressure at Force(P2)
                                    HelperTestBase.Model_GVL.GVL_T25.rForca_P2 = dblValue;
                                    break;

                                case "EMeasurePointP7": //Pressure at Force(E6) =
                                    HelperTestBase.Model_GVL.GVL_T25.rPontoMedicao_P7 = dblValue;
                                    break;

                                case "EPistonTravelAtPressure": //Travel at Pressure = 
                                    HelperTestBase.Model_GVL.GVL_T25.rDeslocamentoNaPressao = dblValue;
                                    break;

                                case "EActuationForceAtPressure": //Actuation Force at Pressure = 
                                    HelperTestBase.Model_GVL.GVL_T25.rPressaoCutIn_Bar = dblValue;
                                    break;

                                case "EReleaseForceMin": //Release Force min = 
                                    HelperTestBase.Model_GVL.GVL_T25.rReleaseForcePressMin_Bar = dblValue;
                                    break;

                                case "EReleaseForceMax": //Release Force max = 
                                    HelperTestBase.Model_GVL.GVL_T25.rReleaseForcePressMax_Bar = dblValue;
                                    break;

                                case "EHysteresisAtPressure": //Hysteresis at Pressure(%) = 
                                    HelperTestBase.Model_GVL.GVL_T25.rPressaoHysterese_pout = dblValue;
                                    break;

                                case "EHysteresisAtPressure2": //Hysteresis at Pressure(bar) = 
                                    HelperTestBase.Model_GVL.GVL_T25.rPressaoHysterese_Bar = dblValue;
                                    break;

                                case "ERelForceRemainAtTravel": //Release Force Remaining at = 
                                    HelperTestBase.Model_GVL.GVL_T25.rReleaseForceAt_mm = dblValue;
                                    break;

                                case "EJumperNomGrad": //Jumper Gradient P1 = 
                                    HelperTestBase.Model_GVL.GVL_T25.rJumperGradienteNominal = dblValue;
                                    break;

                                case "EJumperPosTolerance": //Jumper Gradient P2 = 
                                    HelperTestBase.Model_GVL.GVL_T25.rJumperTolPos = dblValue;
                                    break;

                                case "EJumperNegTolerance": //Jumper Gradient P2 = 
                                    HelperTestBase.Model_GVL.GVL_T25.rJumperTolNeg = dblValue;
                                    break;

                                case "ESwitchPointNomGrad": //Jumper Gradient P2 = 
                                    HelperTestBase.Model_GVL.GVL_T25.rSwitchPointGradienteNominal = dblValue;
                                    break;

                                case "ESwitchPointPosTolerance": //Jumper Gradient P2 = 
                                    HelperTestBase.Model_GVL.GVL_T25.rSwitchPointTolPos = dblValue;
                                    break;

                                case "ESwitchPointNegTolerance": //Jumper Gradient P2 = 
                                    HelperTestBase.Model_GVL.GVL_T25.rSwitchPointTolNeg = dblValue;
                                    break;

                                case "ETMCDiameterPC": //TMC Diameter PC = 
                                    HelperTestBase.Model_GVL.GVL_T25.rDiametroCMD_mm = dblValue;
                                    break;

                                case "ETMCDiameterSC": // TMC Diameter SC = 

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
                                case "CBShowDualRatioLines":
                                    if (dblValue > 0)
                                        HelperTestBase.Model_GVL.GVL_T26.bMostraLinhasDRAux = true;
                                    else
                                        HelperTestBase.Model_GVL.GVL_T26.bMostraLinhasDRAux = false;
                                    break;

                                case "EForceScaleI":
                                    break;

                                case "EForceScaleO":
                                    break;

                                case "EP1AtForce": //Pressure at Force(E1)
                                    HelperTestBase.Model_GVL.GVL_T26.rForca_E1 = dblValue;
                                    break;

                                case "EP2AtForce": //Pressure at Force(E2)  
                                    HelperTestBase.Model_GVL.GVL_T26.rForca_E2 = dblValue;
                                    break;

                                case "EP3AtForce": //Pressure at Force(P1)
                                    HelperTestBase.Model_GVL.GVL_T26.rForca_P1 = dblValue;
                                    break;

                                case "EP4AtForce": //Pressure at Force(P2)
                                    HelperTestBase.Model_GVL.GVL_T26.rForca_P2 = dblValue;
                                    break;

                                case "EMeasurePointP7": //Pressure at Force(E6) =
                                    HelperTestBase.Model_GVL.GVL_T26.rPontoMedicao_P7 = dblValue;
                                    break;

                                case "EActuationForceAtForce": //Actuation Force at Pressure = 
                                    HelperTestBase.Model_GVL.GVL_T26.rForcaFOutCutIn_N = dblValue;
                                    break;

                                case "EReleaseForceMin": //Release Force min = 
                                    HelperTestBase.Model_GVL.GVL_T26.rReleaseForceFoutMin_N = dblValue;
                                    break;

                                case "EReleaseForceMax": //Release Force max = 
                                    HelperTestBase.Model_GVL.GVL_T26.rReleaseForceFoutMax_N = dblValue;
                                    break;

                                case "EHysteresisAtForce": //Hysteresis at Pressure(%) = 
                                    HelperTestBase.Model_GVL.GVL_T26.rForcaHysterese_Fout = dblValue;
                                    break;

                                case "ERelForceRemainAtTravel": //Release Force Remaining at = 
                                    HelperTestBase.Model_GVL.GVL_T26.rReleaseForceAt_mm = dblValue;
                                    break;

                                case "EJumperNomGrad": //Jumper Gradient P1 = 
                                    HelperTestBase.Model_GVL.GVL_T26.rJumperGradienteNominal = dblValue;
                                    break;

                                case "EJumperPosTolerance": //Jumper Gradient P2 = 
                                    HelperTestBase.Model_GVL.GVL_T26.rJumperTolPos = dblValue;
                                    break;

                                case "EJumperNegTolerance": //Jumper Gradient P2 = 
                                    HelperTestBase.Model_GVL.GVL_T26.rJumperTolNeg = dblValue;
                                    break;

                                case "ESwitchPointNomGrad": //Jumper Gradient P2 = 
                                    HelperTestBase.Model_GVL.GVL_T26.rSwitchPointGradienteNominal = dblValue;
                                    break;

                                case "ESwitchPointPosTolerance": //Jumper Gradient P2 = 
                                    HelperTestBase.Model_GVL.GVL_T26.rSwitchPointTolPos = dblValue;
                                    break;

                                case "ESwitchPointNegTolerance": //Jumper Gradient P2 = 
                                    HelperTestBase.Model_GVL.GVL_T26.rSwitchPointTolNeg = dblValue;
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
                                    if (dblValue > 0)
                                        HelperTestBase.Model_GVL.GVL_T27.iTipoGrafico = 0;
                                    _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_wTipoGrafico_T27 }, 0);
                                    break;
                                case "CBDiffTravel":
                                    if (dblValue > 0)
                                        HelperTestBase.Model_GVL.GVL_T27.iTipoGrafico = 1;
                                    _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_wTipoGrafico_T27 }, 1);
                                    break;
                                case "EForceScale":
                                    break;

                                case "EPressScale":
                                    break;

                                case "ETravelScale":
                                    break;

                                case "EDiffTravelScaleMin":
                                    break;

                                case "EDiffTravelScaleMax":
                                    break;

                                case "ETimeScale":
                                    break;

                                case "EBackwardGradient": //Vel. Retorno
                                    _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_dwVelocidadeRetorno_mms_T27_LW }, dblValue);
                                    break;

                                case "EActuationGradient1": //Vel. Avanco 1
                                    HelperTestBase.Model_GVL.GVL_T27.rVelocidadeNominal_mms = dblValue;
                                    _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_dwVelocidade_Avanco1_mms_T27_LW }, dblValue);
                                    break;

                                case "ETwoPointEvaluationTime":
                                    HelperTestBase.Model_GVL.GVL_T27.rTempoVerificacao2Pontos = dblValue;
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
                                    if (dblValue > 0)
                                        HelperTestBase.Model_GVL.GVL_T28.iTipoGrafico = 0;
                                    _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_wTipoGrafico_T28 }, 0);
                                    break;
                                case "CBDiffTravel":
                                    if (dblValue > 0)
                                        HelperTestBase.Model_GVL.GVL_T28.iTipoGrafico = 1;
                                    _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_wTipoGrafico_T28 }, 1);
                                    break;
                                case "EForceScaleI":
                                    break;

                                case "EForceScaleO":
                                    break;

                                case "ETravelScale":
                                    break;

                                case "EDiffTravelScaleMin":
                                    break;

                                case "EDiffTravelScaleMax":
                                    break;

                                case "ETimeScale":
                                    break;

                                case "EBackwardGradient": //Vel. Retorno
                                    _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_dwVelocidadeRetorno_mms_T28_LW }, dblValue);
                                    break;

                                case "EActuationGradient1": //Vel. Avanco 1
                                    HelperTestBase.Model_GVL.GVL_T28.rVelocidadeNominal_mms = dblValue;
                                    _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_dwVelocidade_Avanco1_mms_T28_LW }, dblValue);
                                    break;
                                case "ETwoPointEvaluationTime":
                                    HelperTestBase.Model_GVL.GVL_T28.rTempoVerificacao2Pontos = dblValue;
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
            catch (Exception)
            {
                return false;
                throw;
            }

            return true;
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
                    case 5:     //Vacuum Leakage - Released Position
                        switch (iRowIndex)
                        {
                            case 2://TESTING TIME
                                   //HelperTestBase.Model_GVL.GVL_T05.rTempoTeste = dblValue; já escreve no outro metodo
                                _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_dwTempoTeste_T05_LW }, dblValue);
                                break;
                            case 3://VACUUM STABILIZATION TIME
                                   //HelperTestBase.Model_GVL.GVL_T05.rTempoEstabilizacao = dblValue; //já escreve no outro metodo
                                _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_dwTempoEstabilizacao_T05_LW }, dblValue);
                                break;
                            default:
                                break;
                        }
                        break;
                    case 6:     //Vacuum Leakage - Fully Applied Position
                        switch (iRowIndex)
                        {
                            //0 "ETimeScale": Time Scaling
                            //1 "EVacuumScale": Vacuum Scaling
                            //2 "ETestingTime": Testing Time
                            //3 "EStabTime": Vacuum Stabilization Time
                            //4 "EForcePercentEout": Percent of Eout
                            //5 "CBUseSingleInputForce" Use Single Input Force(instead of Eout)
                            //6 "EInputForce": Input Force

                            case 2: //TESTING TIME
                                    //HelperTestBase.Model_GVL.GVL_T06.rTempoTeste = dblValue; já escreve no outro metodo
                                _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_dwTempoTeste_T06_LW }, dblValue);
                                break;
                            case 3: //VACUUM STABILIZATION TIME
                                    //HelperTestBase.Model_GVL.GVL_T06.rTempoEstabilizacao = dblValue; já escreve no outro metodo
                                _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_dwTempoEstabilizacao_T06_LW }, dblValue);
                                break;
                            case 4: //PERCENT OF EOUT
                                    //HelperTestBase.Model_GVL.GVL_T06.rForcaMaximaRelativa = dblValue; já escreve no outro metodo
                                _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_dwForcaMaximaRelativa_T06_LW }, dblValue);
                                break;
                            case 5: //INPUT FORCE
                                    //HelperTestBase.Model_GVL.GVL_T06.rForcaMaximaAbsoluta_N = dblValue; já escreve no outro metodo
                                _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_dwForcaMaximaAbsoluta_T06_LW }, dblValue);
                                break;
                            default:
                                break;
                        }
                        break;
                    case 7:     //Vacuum Leakage - Lap Position
                        switch (iRowIndex)
                        {
                            case 2://TESTING TIME
                                   //HelperTestBase.Model_GVL.GVL_T07.rTempoTeste = dblValue; já escreve no outro metodo
                                _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_dwTempoTeste_T07_LW }, dblValue);
                                break;
                            case 3://VACUUM STABILIZATION TIME
                                   //HelperTestBase.Model_GVL.GVL_T07.rTempoEstabilizacao = dblValue; já escreve no outro metodo
                                _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_dwTempoEstabilizacao_T07_LW }, dblValue);
                                break;
                            case 4://RELATIVE INPUT FORCE 1
                                   //HelperTestBase.Model_GVL.GVL_T07.rForcaRelativaAvanco = dblValue; já escreve no outro metodo
                                _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_dwForcaRelativaAvanco_T07_LW }, dblValue);
                                break;
                            case 5: //RELATIVE INPUT FORCE 2
                                    //HelperTestBase.Model_GVL.GVL_T07.rForcaRelativaRetorno = dblValue; já escreve no outro metodo
                                _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_dwForcaRelativaRetorno_T07_LW }, dblValue);
                                break;
                            case 6: //RELATIVE INPUT FORCE 3
                                    //HelperTestBase.Model_GVL.GVL_T07.rForcaRelativaFinal = dblValue; já escreve no outro metodo
                                _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_dwForcaRelativaFinal_T07_LW }, dblValue);
                                break;
                            case 8: //SINGLE INPUT FORCE
                                    //HelperTestBase.Model_GVL.GVL_T07.rForcaMaxima = dblValue; já escreve no outro metodo
                                _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_dwForcaMaximaRelativa_T07_LW }, dblValue);
                                break;
                            case 9: //SINGLE INPUT FORCE (% EOUT)
                                    //HelperTestBase.Model_GVL.GVL_T07.rForcaMaximaAbsoluta_N = dblValue; já escreve no outro metodo
                                _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_dwForcaMaximaAbsoluta_T07_LW }, dblValue);
                                break;
                            default:
                                break;
                        }
                        break;
                    case 8:      //Hydraulic Leakage - Fully Applied Position
                        switch (iRowIndex)
                        {
                            //iRowIndex = 0 =  "ETimeScale": Time Scaling
                            //iRowIndex = 1 =  "EVacuumScale": Vacuum Scaling
                            //iRowIndex = 2 =  "EPressureScale": Pressure Scaling
                            //iRowIndex = 3 =  "ETravelScale": Travel Scaling
                            //SPACE ?
                            //iRowIndex = 4 =  "ETestingTime": chk - Testing Time
                            //iRowIndex = 5 =  "EStabTime": Stabilization Time
                            //iRowIndex = 6 =  "EForcePercentEout": Percent of Eout
                            //iRowIndex =  ? =  "CBUseSingleInputForce": Use Single Input Force (instead of Eout)
                            //iRowIndex = 7 =  "EInputForce": Input Force

                            case 4://"EStabTime" - TESTING TIME
                                HelperTestBase.Model_GVL.GVL_T08.rTempoTeste = dblValue;
                                _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_dwTempoTeste_T08_LW }, dblValue);
                                break;
                            case 5://STABILIZATION TIME
                                HelperTestBase.Model_GVL.GVL_T08.rTempoEstabilizacao = dblValue;
                                _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_dwTempoEstabilizacao_T08_LW }, dblValue);
                                break;
                            case 6: //PERCENT OF EOUT
                                HelperTestBase.Model_GVL.GVL_T07.rForcaMaximaRelativa = dblValue;
                                _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_dwForcaMaximaAbsoluta_T08_LW }, dblValue);
                                break;
                            case 7: //INPUT FORCE
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
                            case 4: //PRESSURE PC
                                HelperTestBase.Model_GVL.GVL_T09.rPressaoTeste_Bar = dblValue;
                                _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_dwPressaoTeste_T09_LW }, dblValue);
                                break;
                            case 5://TESTING TIME
                                HelperTestBase.Model_GVL.GVL_T09.rTempoTeste = dblValue;
                                _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_dwTempoTeste_T09_LW }, dblValue);
                                break;
                            case 6://STABILIZATION TIME
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
                            case 4: //TARGET PRESSURE PC
                                    //HelperTestBase.Model_GVL.GVL_T10.rPressaoTeste_Bar = dblValue;
                                _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_dwPressaoTeste_T10_LW }, dblValue);
                                break;
                            case 5://TESTING TIME
                                   //HelperTestBase.Model_GVL.GVL_T10.rTempoTeste = dblValue;
                                _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_dwTempoTeste_T10_LW }, dblValue);
                                break;
                            case 6://STABILIZATION TIME
                                   //HelperTestBase.Model_GVL.GVL_T10.rTempoEstabilizacao = dblValue;
                                _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_dwTempoEstabilizacao_T10_LW }, dblValue);
                                break;
                            default:
                                break;
                        }
                        break;
                    case 19:    //Lost Travel ACU - Pneumatic Primary
                        switch (iRowIndex)
                        {
                            case 2: //BLOW OUT TIME
                                    //HelperTestBase.Model_GVL.GVL_T19.rTempoSopro = dblValue;
                                _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_dwTempoSopro_T19_LW }, dblValue);
                                break;
                            case 3://ACTUATION TRAVEL
                                   //HelperTestBase.Model_GVL.GVL_T19.rDeslocamentoTeste = dblValue;
                                _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_dwDeslocamentoTeste_T19_LW }, dblValue);
                                break;
                            case 4://PRESSURE SYSTEM CLOSED
                                   //HelperTestBase.Model_GVL.GVL_T19.rPressaoSistemaFechado_Bar = dblValue;
                                _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_dwPressaoSistemaFechado_T19_LW }, dblValue);
                                break;
                            case 5://PRESSURE SYSTEM OPENED
                                   //HelperTestBase.Model_GVL.GVL_T19.rPressaoSistemaAberto_Bar = dblValue;
                                _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_dwPressaoSistemaAberto_T19_LW }, dblValue);
                                break;
                            default:
                                break;
                        }
                        break;
                    case 20:    //Lost Travel ACU - Pneumatic Secondary
                        switch (iRowIndex)
                        {
                            case 1: //BLOW OUT TIME
                                    //HelperTestBase.Model_GVL.GVL_T20.rTempoSopro = dblValue;
                                _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_dwTempoSopro_T20_LW }, dblValue);
                                break;
                            case 3://ACTUATION TRAVEL
                                   //HelperTestBase.Model_GVL.GVL_T20.rDeslocamentoTeste = dblValue;
                                _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_dwDeslocamentoTeste_T20_LW }, dblValue);
                                break;
                            case 4://PRESSURE SYSTEM CLOSED
                                   //HelperTestBase.Model_GVL.GVL_T20.rPressaoSistemaFechado_Bar = dblValue;
                                _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_dwPressaoSistemaFechado_T20_LW }, dblValue);
                                break;
                            case 5://PRESSURE SYSTEM OPENED
                                   //HelperTestBase.Model_GVL.GVL_T20.rPressaoSistemaAberto_Bar = dblValue;
                                _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_dwPressaoSistemaAberto_T20_LW }, dblValue);
                                break;
                            default:
                                break;
                        }
                        break;
                    case 23:    //Breather Hole / Central Valve open
                        switch (iRowIndex)
                        {
                            case 1://Pressao Minima
                                   //HelperTestBase.Model_GVL.GVL_T23.rPressaoHidraulicaMin_Bar = dblValue;
                                _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_dwPressaoHidraulicaMin_T23_LW }, dblValue);
                                break;
                            case 2://Pressao Maxima
                                   //HelperTestBase.Model_GVL.GVL_T23.rPressaoHidraulicaMax_Bar = dblValue;
                                _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_dwPressaoHidraulicaMax_T23_LW }, dblValue);
                                break;
                            default:
                                break;
                        }
                        break;
                    case 24:    ////Efficiency
                        switch (iRowIndex)
                        {
                            case 4://intervalo
                                   //HelperTestBase.Model_GVL.GVL_T24.rIntervalo = dblValue;
                                _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_dwIntervalo_T24_LW }, dblValue);
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

        #endregion

        #region TIMERS
        private void timerDateTime_Tick(object sender, EventArgs e)
        {
            mbtn_BClock.Text = DateTime.Now.ToString("dd/MM/yyyy - HH:mm:ss", CultureInfo.InvariantCulture);

            HelperMODBUS.CS_wHandShakePC = HelperMODBUS.CS_wHandShakeCLP == false ? 1 : 0; // new Random().Next(1,150);

            TaskBarUpdate();
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
                    //MODBUS_DisplayMainDataParameters();

                    //leitura tela geral
                    MODBUS_DisplayScreenStatusData();

                    //le o passo do teste 
                    if ((HelperApp.uiTesteSelecionado == 19 || HelperApp.uiTesteSelecionado == 20) && HelperMODBUS.CS_wEmCiclo)
                        MODBUS_ContinousReadStepTest();

                    //Write Continuos HandShake
                    _helperMODBUS.HelperMODBUS_WriteHandShakeContinous();
                }
            }
        }

        #endregion

        #region TEST PROCESS

        #region START SEQUENCE PROCESS
        private void TEST_Start_Command()
        {
            var abc = HelperApp.bPrjTestCreateNewSampleOnLine;

            try
            {
                if (HelperMODBUS.CS_wPasso != 100)
                {
                    MessageBox.Show("Step Test not permited!", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (HelperApp.strActuationMode == "E-Motor")
                {
                    if (!HelperMODBUS.CS_wEixoReferenciado)
                    {
                        MessageBox.Show("TEST NOT STARTED!" + "\n\n\n" + "NOT EMotor Ref. ", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                if (HelperApp.uiTesteSelecionado == 27 || HelperApp.uiTesteSelecionado == 28)
                {
                    if (!HelperMODBUS.CS_wSens_S0702 || !HelperMODBUS.CS_wSens_S0703)
                    {
                        MessageBox.Show("TEST NOT STARTED!" + "\n\n\n" + "Fast Movement Not Allowed (Protection Bow Mounted) ", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                else
                {
                    if (HelperMODBUS.CS_wSens_S0702 || HelperMODBUS.CS_wSens_S0703)
                    {
                        MessageBox.Show("TEST NOT STARTED!" + "\n\n\n" + "Slow Movement Not Allowed (Protection Bow Not Mounted) ", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                if (HelperTestBase.eExamType == eEXAMTYPE.ET_NONE || HelperApp.uiTesteSelecionado == 0)
                    MessageBox.Show("No test selected!", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    if (HelperApp.uiProjectSelecionado == 0)
                    {
                        if (DialogResult.No == MessageBox.Show("\t    PROJECT NOT CREATED!" + "\n\n\n" + "Do you want following without create a PROJECT TEST ? ", _helperApp.appMsg_Name, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))
                            subMenu_Project_Project_Click(null, null);
                    }

                    string strTestExecute = string.Concat("T", HelperApp.uiTesteSelecionado, " - ", EnumExtensionMethods.GetDescriptionEXAMTYPE(HelperTestBase.eExamType));
                    string strMsg = String.Concat("\tSTART TEST PROCESS !", "\n\n\n", "         Do you want following with Test ? ", "\n\n\n", $"\t{strTestExecute}");

                    if (DialogResult.No == MessageBox.Show(strMsg, _helperApp.appMsg_Name, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))
                        return;
                    else
                        LOG_TestSequence("BTN START");

                    #region Start Command

                    LOG_Clear();

                    HBM_ClearBufferAquisitionData();

                    if (!_helperHBM.DeviceConnected)
                        if (ComHBM.HBM_UseEnableCom)
                            HBM_Initialize();


                    HelperTestBase.ProjectTest.is_OnLIne = true;

                    LOG_TestSequence(String.Concat(" TEST Start Sequence - ", HelperApp.uiTesteSelecionado, " Type - ", EnumExtensionMethods.GetEnumValue<eEXAMTYPE>(HelperApp.uiTesteSelecionado).ToString()));

                    _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_wCicloFinalizado }, 0);

                    _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_wConfirmacaoCicloFinalizado }, 0);

                    _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_wTesteSelecionado }, HelperApp.uiTesteSelecionado);

                    _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_wPartidaGeral }, 1);

                    _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_wGravacaoFinalizada }, 1);

                    if (!HelperMODBUS.CS_wModoAuto)
                        _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_wModoAuto }, 1);

                    LOG_TestSequence("CS_wPartidaGeral OK");

                    TAB_Main.SelectedTab = TAB_Main.TabPages["tab_CPX_Visu"];

                    #endregion
                }
            }
            catch (Exception ex)
            {
                var err = string.Concat("Exception : ", ex.Message);
                MessageBox.Show(err, _helperApp.appMsg_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool TEST_Start_Sequence()
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

                HelperTestBase.ProjectTestConcluded.ProjectTestSample.TestingDate = _strTimeStamp;

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
        private void TEST_Stop_Command()
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

                HelperApp.bRunTestExecuted = false;

                HelperTestBase.ProjectTestConcluded.ProjectTestSample.Project.is_Created = false;

                TAB_Disable(_helperApp.GetMethodName());

                SubMenuProject_Disable();

                TAB_Main.SelectedTab = TAB_Main.TabPages["Tab_ActuationParameters"];
            }
            catch (Exception ex)
            {
                var err = ex.Message;
                MessageBox.Show(err, _helperApp.appMsg_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool TEST_Stop_Sequence()
        {
            LOG_TestSequence("BTN STOP"); ;

            //// abort here, if nothing to do...
            if (!HelperTestBase.ProjectTestConcluded.ProjectTestSample.Project.is_Created)
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
                    timerHBM.Enabled = true;

                    HBM_SaveAquisitionTxtData();

                    ////INFO GRAVACAO
                    mbtn_BRecordStart.BackColor = colorON;
                    mbtn_BRecording.BackColor = colorON;

                    HelperTestBase.running = true;

                    _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_wGravacaoIniciada }, 1);

                    LOG_TestSequence("CMD START RECORD DATA HBM ");

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

                    timerHBM.Enabled = false;

                    //INFO GRAVACAO
                    mbtn_BRecordStop.BackColor = colorOFF;
                    mbtn_BRecording.BackColor = colorOFF;

                    HelperTestBase.running = false;

                    LOG_TestSequence("CMD STOP RECORD DATA HBM ");


                    HelperTestBase.ProjectTestConcluded.ProjectTestSample = HelperTestBase.ProjectTestConcluded.ProjectTestSample == null ? new Model_Operational_Project_TestSample() : HelperTestBase.ProjectTestConcluded.ProjectTestSample;

                    HelperTestBase.ProjectTestConcluded.ProjectTestSample.Project = HelperTestBase.ProjectTestConcluded.ProjectTestSample.Project == null ? new Model_Operational_Project() : HelperTestBase.ProjectTestConcluded.ProjectTestSample.Project;

                    HBM_SaveAquisitionTxtData();

                    if (TEST_Concluded_Command())
                    {
                        HelperApp.bRunTestExecuted = true;

                        HelperTestBase.ProjectTestConcluded.ProjectTestSample.Project.is_Created = true;

                        TAB_Enable(_helperApp.GetMethodName());

                        SubMenuProject_Enable();

                        HelperTestBase.ProjectTestConcluded.ProjectTestSample.Project.is_Created = true;

                        HelperApp.bPrjTestCreateNewSampleOnLine = false;

                        HelperApp.bLoadPrjTestOffLine = false;

                        TAB_Main.SelectedTab = TAB_Main.TabPages["tab_Diagram"];
                    }
                    else
                    {
                        HelperApp.bRunTestExecuted = false;

                        HelperTestBase.ProjectTestConcluded.ProjectTestSample.Project.is_Created = false;

                        TAB_Disable(_helperApp.GetMethodName());

                        SubMenuProject_Disable();

                        if (HelperApp.bDeletedTestExecuted)
                        {
                            MessageBox.Show("Test Concluded Data DELETED !", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Information);

                            TAB_Main.SelectedTab = TAB_Main.TabPages["Tab_ActuationParameters"];
                        }
                        else
                            MessageBox.Show("Error TEST_Concluded_Command, failed conclude data test!", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                TAB_Disable(_helperApp.GetMethodName());

                SubMenuProject_Disable();

                MessageBox.Show(ex.Message, _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }

            HBM_ClearBufferAquisitionData();
        }

        #endregion

        #region CONCLUDED SEQUENCE PROCESS
        private bool TEST_Concluded_Command()
        {
            try
            {
                HelperApp.bDeletedTestExecuted = false;

                string strMsgConcluded = String.Concat("\t    TEST CONCLUDED !", "\n\n\n", "\tDo you want SAVE DATA this Test ? ", "\n\n\n", $"\t{HelperApp.strNomeTesteSelecionado}");

                if (DialogResult.No == MessageBox.Show(strMsgConcluded, _helperApp.appMsg_Name, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))
                {
                    if (HelperTestBase.ProjectTestConcluded.IdProjectTestConcluded > 0 && HelperTestBase.ProjectTestConcluded.ProjectTestSample.Project.IdProject > 0)
                    {
                        int iCountProjectSampleTest = new BLL_Operational_Project().GetCountProjectSampleTestByIdProject(HelperTestBase.ProjectTestConcluded.ProjectTestSample.IdProject.ToString());

                        if (iCountProjectSampleTest == 1)
                        {
                            if (!new BLL_Operational_Project().DeleteProject(HelperTestBase.ProjectTestConcluded.ProjectTestSample.IdProject.ToString()))
                            {
                                MessageBox.Show("Test data DeleteProject Fail !", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return false;
                            }
                            else
                            {
                                //delete files test
                                if (!TEST_Concluded_DeleteFileData(true))
                                {
                                    MessageBox.Show("Error when deleting Test Files of select Test item", _helperApp.appMsg_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return false;
                                }
                                else
                                {
                                    HelperApp.bDeletedTestExecuted = true;
                                    return false;
                                }
                            }
                        }
                        else
                        {
                            //delete files test
                            if (!TEST_Concluded_DeleteFileData(true))
                            {
                                MessageBox.Show("Error when deleting Test Files of select Test item", _helperApp.appMsg_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return false;
                            }
                            else
                            {
                                HelperApp.bDeletedTestExecuted = true;
                                return false;
                            }
                        }
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(HelperTestBase.ProjectTestConcluded.ProjectTestFileName))
                        {
                            //delete files test
                            if (!TEST_Concluded_DeleteFileData(false))
                            {
                                MessageBox.Show("Error when deleting Test Files of select Test item", _helperApp.appMsg_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return false;
                            }
                            else
                            {
                                HelperApp.bDeletedTestExecuted = true;
                                return false;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Error when deleting Test Files of select Test item NOT FOUND !", _helperApp.appMsg_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                }
                else
                {
                    HelperApp.bRunTestExecuted = true;

                    if (TXTFileHBM_LoadData(_helperApp.GetMethodName()))
                    {
                        _modelGVL = HelperTestBase.Model_GVL;

                        if (TXTFileHBM_HeaderCreate(_helperApp.lstStrReturnReadFileLines, HelperTestBase.Model_GVL))
                        {
                            if (HelperTestBase.ProjectTestConcluded?.ProjectTestSample?.Project?.IdProject > 0)
                            {
                                if (TEST_Concluded_SaveData())
                                    HelperTestBase.ProjectTestConcluded.ProjectTestSample.Project.is_Created = true;
                                else
                                {
                                    HelperApp.bRunTestExecuted = false;

                                    TAB_Disable(_helperApp.GetMethodName());

                                    MessageBox.Show("Error TEST_Concluded_SaveData, failed load result data test!", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Warning);

                                    return false;
                                }
                            }
                        }
                        else
                        {
                            HelperApp.bRunTestExecuted = false;
                            TAB_Disable(_helperApp.GetMethodName());
                            MessageBox.Show("Error TXTFileHBM_HeaderCreate, failed load result data test!", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Warning);

                            return false;
                        }
                    }
                    else
                    {
                        HelperApp.bRunTestExecuted = false;
                        TAB_Disable(_helperApp.GetMethodName());
                        MessageBox.Show("Error TXTFileHBM_LoadData, failed load result data test!", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                HelperApp.bRunTestExecuted = false;
                TAB_Disable(_helperApp.GetMethodName());
                MessageBox.Show(ex.Message, _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }

            return true;
        }
        private bool TEST_Concluded_SaveData()
        {
            try
            {
                Model_Operational_Project_TestConcluded modelPrjTestConcluded = new Model_Operational_Project_TestConcluded();

                string strTimeStamp = DateTime.Now.ToString();

                modelPrjTestConcluded = new Model_Operational_Project_TestConcluded()
                {
                    IdProjectTestSample = HelperTestBase.ProjectTestConcluded.ProjectTestSample.IdProjectTestSample,
                    ProjectTestFileName = _prjTestFileNameWithPath.Replace(_initialDirPathTestFile, "").Replace(_helperApp.AppTests_DefaultExtension, ""),
                    IdTestAvailable = HelperApp.uiTesteSelecionado,
                    LastUpdatePTC = strTimeStamp
                };

                HelperApp.uiProjectTestSampleSelecionado = HelperTestBase.ProjectTestConcluded.ProjectTestSample.IdProjectTestSample;
                modelPrjTestConcluded.ProjectTestSample = HelperTestBase.ProjectTestConcluded.ProjectTestSample;

                modelPrjTestConcluded.ProjectTestSample.Project.IdProject = HelperTestBase.ProjectTestConcluded.ProjectTestSample.Project.IdProject;
                modelPrjTestConcluded.ProjectTestSample.IdProject = HelperTestBase.ProjectTestConcluded.ProjectTestSample.IdProject;
                modelPrjTestConcluded.ProjectTestSample.TestingDate = strTimeStamp;
                modelPrjTestConcluded.ProjectTestSample.LastUpdatePTS = strTimeStamp;

                HelperApp.uiProjectSelecionado = HelperTestBase.ProjectTestConcluded.ProjectTestSample.IdProject;
                modelPrjTestConcluded.ProjectTestSample.Project.LastUpdatePRJ = strTimeStamp;

                if (HelperApp.uiProjectTestSampleSelecionado == 0 || HelperTestBase.ProjectTestConcluded.IdProjectTestConcluded > 0)
                {
                    int idProjectTestSampleInsert = new BLL_Operational_Project().AddProjectTestSample(modelPrjTestConcluded.ProjectTestSample);

                    if (idProjectTestSampleInsert > 0)
                    {
                        modelPrjTestConcluded.ProjectTestSample.IdProjectTestSample = idProjectTestSampleInsert;
                        modelPrjTestConcluded.IdProjectTestSample = idProjectTestSampleInsert;
                        HelperTestBase.ProjectTestConcluded = modelPrjTestConcluded;

                        HelperTestBase.ProjectTestConcluded.ProjectTestSample = modelPrjTestConcluded.ProjectTestSample;
                    }
                    else
                    {
                        HelperApp.lblstsbar03 = string.Empty;

                        HelperTestBase.ProjectTestConcluded.ProjectTestSample.Project.is_Created = false;

                        MessageBox.Show("Failed, create Project Test Sample!", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);

                        return false;
                    }
                }

                //Update Project data
                if (new BLL_Operational_Project().UpdateProjectTestSample(HelperTestBase.ProjectTestConcluded.ProjectTestSample.IdProjectTestSample, HelperTestBase.ProjectTestConcluded.ProjectTestSample.SampleSequence, strTimeStamp))
                {
                    //Save Project Concluded Data
                    int idProjectTestConcludedInsert = new BLL_Operational_Project().AddProjectTestConcluded(modelPrjTestConcluded);

                    if (idProjectTestConcludedInsert > 0)
                    {
                        HelperApp.uiProjectTestConcludedSelecionado = idProjectTestConcludedInsert;
                        HelperTestBase.ProjectTestConcluded.IdProjectTestConcluded = idProjectTestConcludedInsert;
                        HelperApp.lblstsbar03 = string.Concat("Ident # - [ ", HelperTestBase.ProjectTestConcluded.ProjectTestSample.Project?.Identification, " ]", " - # Sample : ", HelperTestBase.ProjectTestConcluded.ProjectTestSample.SampleSequence, "");

                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Failed, create project !", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("Failed, update project !", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
                throw;
            }
        }
        private bool TEST_Concluded_DeleteFileData(bool withProject)
        {
            try
            {
                _initialDirPathTestFile = !string.IsNullOrEmpty(_initialDirPathTestFile) ? _initialDirPathTestFile : System.IO.Path.Combine(System.IO.Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.FullName, _helperApp.AppTests_Path);

                string fileIdentificationTest = string.Empty;

                string pathWithFileName = string.Empty;

                if (!withProject)
                {
                    fileIdentificationTest = string.IsNullOrEmpty(HelperTestBase.ProjectTestConcluded.ProjectTestFileName) ? _prjTestFileNameWithPath.Replace(_initialDirPathTestFile, string.Empty) : HelperTestBase.ProjectTestConcluded.ProjectTestFileName.Replace(_initialDirPathTestFile, string.Empty);

                    pathWithFileName = !string.IsNullOrEmpty(_prjTestFileNameWithPath) ? _prjTestFileNameWithPath : HelperTestBase.ProjectTestConcluded.ProjectTestFileName;

                    TXTFileHBM_DeleteData(fileIdentificationTest);
                }
                else
                {
                    if (HelperTestBase.ProjectTestConcluded != null && !string.IsNullOrEmpty(HelperTestBase.ProjectTestConcluded.ProjectTestSample?.IdProjectTestSample.ToString())) //delete SAMPLE
                        fileIdentificationTest = string.Concat('#', HelperTestBase.ProjectTestConcluded.ProjectTestSample?.SampleSequence, '#', HelperTestBase.ProjectTestConcluded.ProjectTestSample?.Project?.Identification?.Trim());
                    else
                        fileIdentificationTest = new BLL_Operational_Project().GetProjectIdentificationByIdProject(HelperTestBase.ProjectTestConcluded.IdProjectTestConcluded.ToString()); //delete PROJECT

                    string[] allFiles = System.IO.Directory.GetFiles(_initialDirPathTestFile);

                    foreach (string file in allFiles)
                    {
                        if (file.Contains(fileIdentificationTest.Trim()))
                            TXTFileHBM_DeleteData(file);
                    }
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

        #endregion

        #region LOAD DATA CONCLUDED TEST
        private void TEST_Concluded_LoadData(bool bLoasTestConcluded)
        {
            bLoasTestConcluded = bLoasTestConcluded != HelperApp.bLoadPrjTestOffLine ? HelperApp.bLoadPrjTestOffLine : bLoasTestConcluded;

            if (bLoasTestConcluded)
                TEST_FileDataConcluded_SetData();
        }
        public void TEST_FileDataConcluded_SetData()
        {
            try
            {
                if (HelperApp.bLoadPrjTestOffLine && HelperTestBase.ProjectTestConcluded.IdProjectTestConcluded > 0 && HelperTestBase.ProjectTest.IdProject > 0)
                {
                    _bPrjTestOffLineCarregado = false;

                    HelperApp.uiProjectSelecionado = HelperApp.uiProjectSelecionado > 0 ? HelperApp.uiProjectSelecionado : HelperTestBase.ProjectTest.IdProject;
                    HelperApp.uiProjectTestSampleSelecionado = HelperApp.uiProjectTestSampleSelecionado > 0 ? HelperApp.uiProjectTestSampleSelecionado : HelperTestBase.ProjectTestSample.IdProjectTestSample;
                    HelperApp.uiProjectTestConcludedSelecionado = HelperApp.uiProjectTestConcludedSelecionado > 0 ? HelperApp.uiProjectTestConcludedSelecionado : HelperTestBase.ProjectTestConcluded.IdProjectTestConcluded;

                    _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_wTesteSelecionado }, HelperApp.uiTesteSelecionado);

                    mcbo_tabActParam_GenSettings_CoBSelectTest.SelectedIndex = HelperApp.uiTesteSelecionado;

                    if (TXTFileHBM_LoadDataConcluded(_helperApp.GetMethodName()))
                    {
                        TAB_Main_ActivePage(2, _helperApp.GetMethodName());

                        MessageBox.Show($"\t {string.Concat("    ", "Test sample")} \n\n\t {string.Concat("            ", "[ ", HelperTestBase.ProjectTestConcluded.ProjectTestSample.SampleSequence, " ]")} \n\n [ { HelperApp.strNomeTesteSelecionado } ] \n\n\t {string.Concat("         ", "Ident")}\n\n\t [ { HelperTestBase.ProjectTestConcluded.ProjectTestSample.Project.Identification} ] \n\n \t loaded successfully!", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Information);

                        HelperApp.lblstsbar03 = string.Concat("Ident # - [ ", HelperTestBase.ProjectTestConcluded.ProjectTestSample.Project?.Identification, " ]", " - # Sample : ", HelperTestBase.ProjectTestConcluded.ProjectTestSample.SampleSequence, "");

                        SubMenuProject_Enable();
                    }
                    else
                    {
                        MessageBox.Show("Failed, error TXTFileHBM_LoadDataConcluded in TEST_FileDataConcluded_SetData !", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);

                        _bPrjTestOffLineCarregado = false;
                        return;
                    }
                }
                else
                {
                    _bPrjTestOffLineCarregado = false;
                    return;
                }
            }
            catch (Exception ex)
            {
                _bPrjTestOffLineCarregado = false;

                MessageBox.Show(ex.Message, _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

                throw;
            }

            _bPrjTestOffLineCarregado = true;
        }
        private void TEST_Concluded_ClearData()
        {
            HelperApp.lblstsbar03 = string.Empty;

            HelperTestBase.ProjectTestConcluded = new Model_Operational_Project_TestConcluded();

            HelperTestBase.ProjectTestSample = new Model_Operational_Project_TestSample();
            HelperTestBase.ProjectTestConcluded.ProjectTestSample = new Model_Operational_Project_TestSample();

            HelperTestBase.ProjectTest = new Model_Operational_Project();
            HelperTestBase.ProjectTestConcluded.ProjectTestSample.Project = new Model_Operational_Project();
        }

        #endregion

        #endregion

        #region TXT FILE TEST

        #region TXT File Create
        private bool TXTFileHBM_Create()
        {
            #region Name File Test

            string strTestTimeStamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            string strTestTypeName = HelperApp.uiTesteSelecionado == 0 ? EnumExtensionMethods.GetEnumValue<eEXAMTYPE>(HelperTestBase.eExamType.ToString()).ToString() : EnumExtensionMethods.GetEnumValue<eEXAMTYPE>(HelperApp.uiTesteSelecionado).ToString();
            string strTestIdentification = string.Empty;

            if (HelperTestBase.ProjectTestConcluded?.ProjectTestSample?.IdProject > 0)
            {
                _prjTestMaxSampleSeq = new BLL_Operational_Project().GetMaxProjectSampleTestByIdProject(HelperTestBase.ProjectTestConcluded.ProjectTestSample.IdProject.ToString());

                if (_prjTestMaxSampleSeq == HelperTestBase.ProjectTestConcluded.ProjectTestSample.SampleSequence && (!HelperApp.bPrjTestCreateNewSampleOnLine || HelperApp.bDeletedTestExecuted))
                    HelperTestBase.ProjectTestConcluded.ProjectTestSample.SampleSequence = _prjTestMaxSampleSeq + 1;
                else if (_prjTestMaxSampleSeq != HelperTestBase.ProjectTestConcluded.ProjectTestSample.SampleSequence && HelperApp.bPrjTestCreateNewSampleOnLine)
                    HelperTestBase.ProjectTestConcluded.ProjectTestSample.SampleSequence = HelperTestBase.ProjectTestConcluded.ProjectTestSample.SampleSequence;
                else if (HelperApp.bLoadPrjTestOffLine || HelperApp.bDeletedTestExecuted)
                    HelperTestBase.ProjectTestConcluded.ProjectTestSample.SampleSequence = _prjTestMaxSampleSeq + 1;
                else
                    HelperTestBase.ProjectTestConcluded.ProjectTestSample.SampleSequence = _prjTestMaxSampleSeq;
            }
            else
                HelperTestBase.ProjectTestConcluded.ProjectTestSample.SampleSequence = _prjTestMaxSampleSeq;

            if (HelperTestBase.ProjectTestConcluded.ProjectTestSample?.Project?.IdProject > 0)
                strTestIdentification = HelperTestBase.ProjectTestConcluded.ProjectTestSample.Project.Identification;
            else
            {
                if (HelperTestBase.ProjectTestConcluded.ProjectTestSample == null)
                {
                    HelperTestBase.ProjectTestConcluded.ProjectTestSample = new Model_Operational_Project_TestSample();

                    HelperTestBase.ProjectTestConcluded.ProjectTestSample.Project = new Model_Operational_Project();
                    HelperTestBase.ProjectTestConcluded.ProjectTestSample.User = new Model_SecurityUser();
                    HelperTestBase.ProjectTestConcluded.ProjectTestSample.TestAvailable = new Model_Manager_TestAvailable();
                }

                strTestIdentification = HelperTestBase.ProjectTestConcluded.ProjectTestSample.Project.IdProject > 0 ? HelperTestBase.ProjectTestConcluded.ProjectTestSample.Project.Identification : _helperApp.AppTests_DefaultNameData;

                HelperTestBase.ProjectTestConcluded.ProjectTestSample.TestingDate = !string.IsNullOrEmpty(HelperTestBase.ProjectTestConcluded.ProjectTestSample.TestingDate) ? HelperTestBase.ProjectTestConcluded.ProjectTestSample.TestingDate : HelperTestBase.ProjectTestConcluded.ProjectTestSample.TestingDate;
                HelperTestBase.ProjectTestConcluded.ProjectTestSample.Project.Identification = strTestIdentification;
            }

            string strTestSampleSequence = HelperTestBase.ProjectTestConcluded?.ProjectTestSample?.SampleSequence.ToString();

            string prjTestFilename = string.Concat(strTestTimeStamp, "#", HelperApp.uiTesteSelecionado, "#", strTestTypeName, "#", strTestSampleSequence, "#", strTestIdentification);

            HelperTestBase.ProjectTestConcluded.ProjectTestFileName = prjTestFilename;

            _prjTestFileNameWithPath = Path.Combine(_initialDirPathTestFile, string.Concat(prjTestFilename, _helperApp.AppTests_DefaultExtension));

            #endregion

            #region Write File Test

            try
            {
                if (!_helperApp.CheckFileExists(_prjTestFileNameWithPath))
                {
                    File.WriteAllText(_prjTestFileNameWithPath, sbexterno.ToString());
                    LOG_TestSequence("TXTFileHBM_Create - WriteAllText");
                }
                else
                {
                    File.AppendAllLines(_prjTestFileNameWithPath, sbexterno.ToString().Split(Environment.NewLine.ToCharArray()));
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

            return HelperTestBase.ProjectTestConcluded.ProjectTestSample.Project.is_Created = _helperApp.CheckFileExists(_prjTestFileNameWithPath);
        }

        #endregion

        #region TXT File Load
        private bool TXTFileHBM_LoadData(string origin)
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
                    fileName = string.IsNullOrEmpty(HelperTestBase.ProjectTestConcluded.ProjectTestFileName) ? _prjTestFileNameWithPath.Replace(_initialDirPathTestFile, string.Empty) : HelperTestBase.ProjectTestConcluded.ProjectTestFileName.Replace(_initialDirPathTestFile, string.Empty);

                    pathWithFileName = !string.IsNullOrEmpty(_prjTestFileNameWithPath) ? _prjTestFileNameWithPath : HelperTestBase.ProjectTestConcluded.ProjectTestFileName;
                }

                #endregion

                #region load data

                if (string.IsNullOrEmpty(fileName))
                {
                    MessageBox.Show("Failed, error path project !", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                else
                {
                    string[] strArray = Regex.Replace(fileName, @"\n|\r|", "").Split(char.Parse("#"));

                    if (strArray.Length > 1)
                    {
                        if (HelperApp.uiProjectSelecionado > 0)
                            if (HelperTestBase.ProjectTestConcluded.ProjectTestSample.Project?.IdProject == 0)
                                HelperTestBase.ProjectTestConcluded.ProjectTestSample.Project = new BLL_Operational_Project().GetHelperProjectByIdProject(HelperApp.uiProjectSelecionado.ToString());

                        HelperApp.uiTesteSelecionado = Convert.ToInt32(strArray[1]);
                        HelperTestBase.ProjectTestConcluded.ProjectTestSample.TestingDate = strArray[0].ToString();

                        HelperTestBase.ProjectTestConcluded.ProjectTestSample.SampleSequence = HelperTestBase.ProjectTestConcluded.ProjectTestSample.SampleSequence == 0 ? Convert.ToInt64(strArray[3].ToString().Replace(_helperApp.AppTests_DefaultExtension, string.Empty)) : HelperTestBase.ProjectTestConcluded.ProjectTestSample.SampleSequence;

                        if (HelperTestBase.ProjectTestConcluded.ProjectTestSample.Project != null)
                            if (string.IsNullOrEmpty(HelperTestBase.ProjectTestConcluded?.ProjectTestFileName))
                                HelperTestBase.ProjectTestConcluded.ProjectTestFileName = string.IsNullOrEmpty(HelperTestBase.ProjectTestConcluded.ProjectTestFileName) ? _prjTestFileNameWithPath.Replace(_initialDirPathTestFile, string.Empty) : HelperTestBase.ProjectTestConcluded.ProjectTestFileName.Replace(_initialDirPathTestFile, string.Empty);
                    }

                    lstStrChReadFileArr = new List<string>[13];
                    lstStrChReadFileArr = _helperApp.ReadTXTFileHBM(fileName, pathWithFileName);

                    if (lstStrChReadFileArr[0].Count() > 0)
                    {
                        lstDblChReadFileArr = _helperApp.lstDblReturnReadFile;

                        #region CALC TEST

                        bool breturnCalcStep = _helperApp.CalcInfoTestByStep(HelperApp.uiTesteSelecionado);

                        if (!breturnCalcStep)
                        {
                            string strMsg = "Failed, CalcInfoTestByStep -  not calculated !";

                            LOG_TestSequence(strMsg);

                            MessageBox.Show(strMsg, _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                        else
                            _modelGVL = _helperApp.CalcGraphData(HelperApp.uiTesteSelecionado, lstDblChReadFileArr);

                        #endregion

                        if (!_modelGVL.GVL_Graficos.bDadosCalculados)
                        {
                            string strMsg = "Failed, CalcGraphData test information not calculated !";

                            LOG_TestSequence(strMsg);

                            MessageBox.Show(strMsg, _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                        else
                        {
                            LOG_TestSequence("TEST CALC CONCLUDED");

                            HelperTestBase.ProjectTestConcluded.ProjectTestSample.Project = HelperTestBase.ProjectTestConcluded.ProjectTestSample.Project == null ? new Model_Operational_Project() : HelperTestBase.ProjectTestConcluded.ProjectTestSample.Project;
                            HelperTestBase.ProjectTestConcluded.ProjectTestSample.User = HelperTestBase.ProjectTestConcluded.ProjectTestSample.User == null ? new Model_SecurityUser() : HelperTestBase.ProjectTestConcluded.ProjectTestSample.User;
                            HelperTestBase.ProjectTestConcluded.ProjectTestSample.TestAvailable = HelperTestBase.ProjectTestConcluded.ProjectTestSample.TestAvailable == null ? new Model_Manager_TestAvailable() : HelperTestBase.ProjectTestConcluded.ProjectTestSample.TestAvailable;

                            HelperTestBase.ProjectTestConcluded.ProjectTestSample.Project.is_OnLIne = true;

                            if (!TAB_TableResult_SetData(_helperApp.GetMethodName()))
                            {
                                MessageBox.Show("Failed, TAB_TableResult_SetData !", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return false;
                            }

                            if (!CHART_LoadActualTestComplete())
                            {
                                MessageBox.Show("Failed, Chart Create !", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return false;
                            }

                            TAB_Enable(_helperApp.GetMethodName());

                            HelperTestBase.ProjectTestConcluded.ProjectTestSample.Project.is_Created = true;

                            if (_modelGVL.GVL_Graficos.bDadosCalculados)
                                HelperTestBase.Model_GVL = _modelGVL;

                            LOG_TestSequence("TESTE SEQUENCE STOP AND CONCLUDED");
                        }
                    }
                    else
                    {
                        TAB_Disable(_helperApp.GetMethodName());

                        MessageBox.Show("Failed, reloading project !", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
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

        private bool TXTFileHBM_LoadDataConcluded(string origin)
        {
            try
            {
                #region Define

                if (string.IsNullOrEmpty(HelperTestBase.ProjectTestConcluded?.ProjectTestFileName))
                {
                    var strTestDateFormat = string.Empty;
                    var strTestHoureFormat = string.Empty;

                    HelperTestBase.ProjectTestConcluded.ProjectTestSample.Project = new BLL_Operational_Project().GetHelperProjectByIdPrjTestConcluded(HelperApp.uiProjectTestConcludedSelecionado.ToString());

                    string prjTestFilename = HelperTestBase.ProjectTestConcluded?.ProjectTestFileName?.Trim();

                    var arrTestDate = HelperTestBase.ProjectTestConcluded.ProjectTestSample?.TestingDate.Substring(0, 10).Split('/');
                    var arrTestHour = HelperTestBase.ProjectTestConcluded.ProjectTestSample?.TestingDate.Substring(11, 8).Split(':');

                    if (arrTestDate.Count() > 0 && arrTestHour.Count() > 0 && !string.IsNullOrEmpty(HelperTestBase.ProjectTestConcluded?.ProjectTestFileName?.Trim()))
                    {
                        var strFileName = HelperTestBase.ProjectTestConcluded?.ProjectTestFileName?.Trim();
                        var strTestDate = string.Concat(arrTestDate[2], arrTestDate[0], arrTestDate[1]);
                        var strTestHour = string.Concat(arrTestHour[0], arrTestHour[1], arrTestHour[2]);

                        strTestDateFormat = !strFileName.Substring(0, 8).Equals(strTestDate) ? strFileName.Substring(0, 8) : strTestDate;
                        strTestHoureFormat = !strFileName.Substring(9, 6).Equals(strTestHour) ? strFileName.Substring(9, 6) : strTestHour;
                    }
                    else
                    {
                        strTestDateFormat = arrTestDate.Count() == 0 ? HelperTestBase.ProjectTestConcluded?.ProjectTestSample?.Project?.PartNumber?.Trim().Substring(0, 8) : string.Concat(arrTestDate[2], arrTestDate[0], arrTestDate[1]);
                        strTestHoureFormat = arrTestHour.Count() == 0 ? HelperTestBase.ProjectTestConcluded?.ProjectTestSample?.Project?.PartNumber?.Trim().Substring(9, 6) : string.Concat(arrTestHour[0], arrTestHour[1], arrTestHour[2]);
                    }


                    string testTypeName = EnumExtensionMethods.GetEnumValue<eEXAMTYPE>(HelperApp.uiTesteSelecionado).ToString();

                    string testIdentName = !string.IsNullOrEmpty(HelperTestBase.ProjectTestConcluded?.ProjectTestSample?.Project?.Identification) ? HelperTestBase.ProjectTestConcluded?.ProjectTestSample?.Project?.Identification.Trim() : _helperApp.AppTests_DefaultNameData;

                    prjTestFilename = !string.IsNullOrEmpty(HelperTestBase.ProjectTestConcluded?.ProjectTestSample?.TestingDate) ? string.Concat(strTestDateFormat, "_", strTestHoureFormat, "#", HelperApp.uiTesteSelecionado, "#", testTypeName, "#", testIdentName, _helperApp.AppTests_DefaultExtension) : string.Empty;

                    HelperTestBase.ProjectTestConcluded.ProjectTestFileName = prjTestFilename.Replace(_helperApp.AppTests_DefaultExtension, string.Empty);
                }

                string prjConcluded_FileName = string.Concat(HelperTestBase.ProjectTestConcluded.ProjectTestFileName.Trim(), _helperApp.AppTests_DefaultExtension);

                string prjConcluded_PathWithFileName = Path.Combine(_initialDirPathTestFile, prjConcluded_FileName);
                _prjTestFileNameWithPath = prjConcluded_PathWithFileName;

                //clean List Array Data
                for (int i = 0; i < lstStrChReadFileArr.Length; i++)
                {
                    if (lstStrChReadFileArr[i] != null)
                        lstStrChReadFileArr[i].Clear();
                }

                #endregion

                #region set Path

                if (HelperApp.uiTesteSelecionado == 0 && _bCoBSelectTestSelected)
                {
                    mcbo_tabActParam_GenSettings_CoBSelectTest.SelectedIndex = 0;

                    _bCoBSelectTestSelected = false;

                    MessageBox.Show("Warning, Load Data invalid option!", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                else
                {
                    if (string.IsNullOrEmpty(prjConcluded_FileName))
                    {
                        prjConcluded_FileName = HelperTestBase.ProjectTestConcluded.ProjectTestFileName.Replace(_initialDirPathTestFile, "");

                        prjConcluded_PathWithFileName = HelperTestBase.ProjectTestConcluded.ProjectTestFileName;
                    }
                }

                #endregion

                #region load data

                if (string.IsNullOrEmpty(prjConcluded_FileName) || string.IsNullOrEmpty(prjConcluded_PathWithFileName))
                {
                    MessageBox.Show("Failed, error prjConcluded_FileName or prjConcluded_PathWithFileName project !", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                else
                {
                    if (!_helperApp.CheckFileExists(prjConcluded_PathWithFileName))
                    {
                        MessageBox.Show("Test file TXTFileHBM_LoadDataConcluded NOT FOUND!", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    else
                    {
                        string[] strArray = Regex.Replace(prjConcluded_FileName, @"\n|\r|", "").Split(char.Parse("#"));

                        if (strArray.Length > 1)
                        {
                            HelperApp.uiTesteSelecionado = Convert.ToInt32(strArray[1]);

                            _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_wTesteSelecionado }, HelperApp.uiTesteSelecionado);

                            HelperTestBase.ProjectTestConcluded.ProjectTestSample.Project.Identification = string.IsNullOrWhiteSpace(HelperTestBase.ProjectTestConcluded.ProjectTestSample.Project.Identification) ? strArray[3].ToString().Replace(_helperApp.AppTests_DefaultExtension, string.Empty) : HelperTestBase.ProjectTestConcluded.ProjectTestSample.Project.Identification;

                            HelperTestBase.ProjectTestConcluded.ProjectTestSample.SampleSequence = HelperTestBase.ProjectTestConcluded.ProjectTestSample.SampleSequence == 0 ? Convert.ToInt64(strArray[4].ToString().Replace(_helperApp.AppTests_DefaultExtension, string.Empty)) : HelperTestBase.ProjectTestConcluded.ProjectTestSample.SampleSequence;
                        }


                        //Read Test File Data
                        lstStrChReadFileArr = _helperApp.ReadTXTFileHBM(prjConcluded_FileName, prjConcluded_PathWithFileName);

                        if (lstStrChReadFileArr[0]?.Count() > 0)
                        {
                            HelperApp.bRunTestExecuted = true;

                            lstDblChReadFileArr = _helperApp.lstDblReturnReadFile;

                            #region CALC TEST

                            bool bReturnCalcStep = _helperApp.CalcInfoTestByStep(HelperApp.uiTesteSelecionado);

                            if (!bReturnCalcStep)
                            {
                                string strMsg = "Failed, calc step test -  not calculated !";

                                LOG_TestSequence(strMsg);

                                MessageBox.Show(strMsg, _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return false;
                            }
                            else
                            {
                                if (!TAB_TableResult_SetData(_helperApp.GetMethodName()))
                                {
                                    MessageBox.Show("Failed, TAB_TableResult_SetData !", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return false;
                                }
                                else
                                    _modelGVL = _helperApp.CalcGraphData(HelperApp.uiTesteSelecionado, lstDblChReadFileArr);
                            }

                            #endregion

                            if (!_modelGVL.GVL_Graficos.bDadosCalculados)
                            {
                                _bPrjTestOffLineCarregado = false;

                                TAB_Disable(_helperApp.GetMethodName());

                                string strMsg = "Failed, test information not calculated !";

                                LOG_TestSequence(strMsg);

                                MessageBox.Show(strMsg, _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return false;
                            }
                            else
                            {
                                LOG_TestSequence("TESTE CALC CONCLUDED");

                                if (!CHART_LoadActualTestComplete())
                                {
                                    _bPrjTestOffLineCarregado = false;

                                    TAB_Disable(_helperApp.GetMethodName());

                                    string strMsg = "Failed, Chart Create !";

                                    LOG_TestSequence(strMsg);

                                    MessageBox.Show(strMsg, _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);

                                    return false;
                                }

                                TAB_Enable(_helperApp.GetMethodName());

                                bool bReturnDataInfo = false;

                                if (!HelperTestBase.ProjectTestConcluded.ProjectTestSample.Project.is_OnLIne)
                                {
                                    if (HelperTestBase.ProjectTestConcluded.IdProjectTestConcluded > 0 && HelperTestBase.ProjectTestConcluded.ProjectTestSample.Project.IdProject > 0)
                                        bReturnDataInfo = TAB_ActuationParameters_GetDataInfoOffLineByFile(HelperApp.uiTesteSelecionado.ToString());
                                    else
                                        bReturnDataInfo = TAB_ActuationParameters_GetDataInfo(HelperApp.uiTesteSelecionado.ToString());
                                }
                                else
                                    bReturnDataInfo = TAB_ActuationParameters_GetDataInfo(HelperApp.uiTesteSelecionado.ToString());

                                if (bReturnDataInfo)
                                    _bCoBSelectTestSelected = true;
                                else
                                {
                                    _bPrjTestOffLineCarregado = false;

                                    TAB_Disable(_helperApp.GetMethodName());

                                    string strMsg = "Error, failed load data test!";

                                    LOG_TestSequence(strMsg);

                                    MessageBox.Show(strMsg, _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);

                                    return false;
                                }

                                HelperTestBase.ProjectTestConcluded.ProjectTestSample.Project.is_Created = true;

                                if (_modelGVL.GVL_Graficos.bDadosCalculados)
                                    HelperTestBase.Model_GVL = _modelGVL;

                                LOG_TestSequence("TESTE SEQUENCE STOP AND CONCLUDED");
                            }
                        }
                        else
                        {
                            _bPrjTestOffLineCarregado = false;

                            TAB_Disable(_helperApp.GetMethodName());

                            string strMsg = "$Failed lstStrChReadFileArr[0]?.Count() \n\n Reloading project in TXTFileHBM_LoadDataConcluded !";

                            LOG_TestSequence(strMsg);

                            MessageBox.Show(strMsg, _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);

                            return false;
                        }
                    }
                }
                #endregion
            }
            catch (Exception ex)
            {
                _bPrjTestOffLineCarregado = false;

                TAB_Disable(_helperApp.GetMethodName());

                string strMsg = string.Concat("$Catch TXTFileHBM_LoadDataConcluded \n\n", ex.Message);

                LOG_TestSequence(strMsg);

                MessageBox.Show(strMsg, _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;

                throw;
            }

            _bPrjTestOffLineCarregado = true;

            return _bPrjTestOffLineCarregado;
        }
        #endregion

        #region TXT File Header
        private bool TXTFileHBM_HeaderCreate(List<string> lstFiledata, Model_GVL model_GVL)
        {
            try
            {
                #region Header Name File Test

                string strHeader = _helperApp.AppTests_DefaultNameHeader;

                _prjTestFileNameWithPath = !string.IsNullOrEmpty(_prjTestFileNameWithPath) ? _prjTestFileNameWithPath : HelperTestBase.ProjectTestConcluded.ProjectTestFileName;

                string strFileName = _prjTestFileNameWithPath.Replace(_initialDirPathTestFile, string.Empty).Replace(_helperApp.AppTests_DefaultExtension, string.Empty);

                string strHeaderTestFilename = string.Concat(strFileName.Replace(_helperApp.AppTests_DefaultNameData, string.Empty), strHeader, _helperApp.AppTests_DefaultExtension);

                _prjTestHeaderFileNameWithPath = Path.Combine(_initialDirPathTestFile, strHeaderTestFilename);

                #endregion

                #region Write Header File Test

                if (_helperApp.CheckFileExists(_prjTestFileNameWithPath))
                {
                    if (!_helperApp.CheckFileExists(_prjTestHeaderFileNameWithPath))
                    {
                        sbDataFile.Clear();
                        lstFiledata.ForEach(item => sbDataFile.Append(item + "\r\n"));

                        ////Get Info Grid Param
                        HelperApp.lstEvaluationParameters = _helperApp.GridView_GetValuesEvalParam(grid_tabActionParam_EvalParam);

                        ////Get Info Header Param
                        _helperApp.TXTFileHBM_HeaderAppendDataProjectParameters(HelperApp.uiTesteSelecionado, model_GVL, grid_tabActionParam_EvalParam);

                        if (!string.IsNullOrEmpty(HelperTestBase.sbHeaderAppendTxtData?.ToString()))
                        {
                            var strSbHeader = String.Concat(HelperTestBase.sbHeaderAppendTxtData.ToString(), Environment.NewLine);

                            ////Get Info Header Table Result
                            _helperApp.TXTFileHBM_HeaderAppendTableResults(HelperApp.uiTesteSelecionado).ToString();

                            ////Insert Curve Names
                            string strSbHeaderResults_CurverNames = String.Concat(HelperTestBase.sbHeaderResultsAppendTxtData, Environment.NewLine);

                            var strCurverNamesHeader = string.Concat(strSbHeader, strSbHeaderResults_CurverNames);

                            File.WriteAllText(_prjTestHeaderFileNameWithPath, strCurverNamesHeader);
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

                #endregion
            }
            #region Exceptions
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
            #endregion

            return true;
        }

        #endregion

        #region TXT File Union
        public bool TXTFileHBM_HeaderUnion()
        {
            try
            {
                if (!_bPrjTestOffLineCarregado)
                    if (!TXTFileHBM_LoadData(_helperApp.GetMethodName()))
                    {
                        MessageBox.Show("Failed, TXTFileHBM_LoadData project !", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                if (HelperApp.uiTesteSelecionado > 0)
                {
                    #region Name Union File Test

                    _prjTestFileNameWithPath = !string.IsNullOrEmpty(HelperTestBase.ProjectTestConcluded.ProjectTestFileName) ? string.Concat(_initialDirPathTestFile, HelperTestBase.ProjectTestConcluded.ProjectTestFileName.Replace(_helperApp.AppTests_DefaultExtension, string.Empty), _helperApp.AppTests_DefaultExtension) : _prjTestFileNameWithPath;

                    string strNameUnion = _helperApp.AppTests_DefaultNameUnion;
                    string strTestFileName = _prjTestFileNameWithPath.Replace(_initialDirPathTestFile, string.Empty).Replace(_helperApp.AppTests_DefaultExtension, string.Empty);

                    string strTestFilenameUnion = string.Concat(strTestFileName.Replace(_helperApp.AppTests_DefaultNameData, string.Empty), strNameUnion, _helperApp.AppTests_DefaultExtension);

                    _prjTestHeaderFileNameWithPath = Path.Combine(_initialDirPathTestFile, string.Concat(strTestFileName.Replace(_helperApp.AppTests_DefaultNameData, string.Empty), _helperApp.AppTests_DefaultNameHeader, _helperApp.AppTests_DefaultExtension));

                    #endregion

                    #region Write Union File Test

                    if (!_helperApp.CheckFileExists(_prjTestFileNameWithPath))
                    {
                        MessageBox.Show("Test file NOT FOUND!", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    else
                    {
                        if (!_helperApp.CheckFileExists(_prjTestHeaderFileNameWithPath))
                        {
                            MessageBox.Show("Failed, Header Test File existing !", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                        else
                        {
                            sbDataFile.Clear();
                            _helperApp.lstStrReturnReadFileLines.ForEach(item => sbDataFile.Append(item + "\r\n"));

                            ////Get Info Grid Param
                            HelperApp.lstEvaluationParameters = _helperApp.GridView_GetValuesEvalParam(grid_tabActionParam_EvalParam);

                            ////Get Info Header Param
                            _helperApp.TXTFileHBM_HeaderAppendDataProjectParameters(HelperApp.uiTesteSelecionado, HelperTestBase.Model_GVL, grid_tabActionParam_EvalParam);

                            if (string.IsNullOrEmpty(HelperTestBase.sbHeaderAppendTxtData?.ToString()))
                            {
                                MessageBox.Show("Failed, Union Header Test File sbHeaderAppendTxtData lost data !", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return false;
                            }
                            else
                            {
                                #region dialog user path

                                SaveFileDialog theDialog = new SaveFileDialog();
                                theDialog.Title = "Save Export File";
                                theDialog.Filter = "TXT files|*.txt;*.tst";
                                theDialog.FileName = strTestFilenameUnion;
                                theDialog.InitialDirectory = string.Concat(_initialDirPathTestFile, "TestsExport\\");
                                theDialog.RestoreDirectory = true;

                                if (theDialog.ShowDialog() == DialogResult.OK)
                                {
                                    _prjTestUnionFileNameWithPath = theDialog.FileName;

                                    ////Create File Union Acquisition
                                    if (_helperApp.CheckFileExists(_prjTestUnionFileNameWithPath))
                                        File.Delete(_prjTestUnionFileNameWithPath);

                                    var strSbHeader = String.Concat(HelperTestBase.sbHeaderAppendTxtData.ToString(), Environment.NewLine);

                                    ////Get Info Header Table Result
                                    if (!_bPrjTestOffLineCarregado && HelperApp.bRunTestExecuted)
                                        _helperApp.TXTFileHBM_HeaderAppendTableResults(HelperApp.uiTesteSelecionado).ToString();
                                    else
                                        _helperApp.TXTFileHBM_HeaderAppendTableResultsOffLineByFile(HelperApp.uiTesteSelecionado).ToString();

                                    ////Insert Curve Names
                                    string strSbHeaderResults_CurverNames = String.Concat(HelperTestBase.sbHeaderResultsAppendTxtData.ToString(), Environment.NewLine);

                                    var strHeaderComplete = string.Concat(strSbHeader, strSbHeaderResults_CurverNames);

                                    var strUnionAll = string.Empty;
                                    strUnionAll = string.Concat(strHeaderComplete, sbDataFile.ToString());

                                    File.WriteAllText(_prjTestUnionFileNameWithPath, strUnionAll);
                                }
                                else
                                {
                                    MessageBox.Show("User Canceled action!", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return false;
                                }

                                #endregion
                            }
                        }
                    }

                    #endregion
                }
                else
                {
                    HelperApp.bRunTestExecuted = false;
                    TAB_Disable(_helperApp.GetMethodName());
                    MessageBox.Show("Error TXTFileHBM_LoadData, failed load result data test!", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return false;
                }
            }
            #region Exceptions
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
            #endregion

            return true;
        }

        #endregion

        #region TXT File Delete
        private void TXTFileHBM_DeleteData(string fileToDelete)
        {
            try
            {
                if (_prjTestFileNameWithPath.Contains(fileToDelete))
                {
                    if (_helperApp.CheckFileExists(_prjTestFileNameWithPath))
                    {
                        File.Delete(_prjTestFileNameWithPath);
                        LOG_TestSequence("TXTFileHBM_DeleteData - WriteAllText");
                    }
                    else
                        MessageBox.Show("Test file NOT FOUND!", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        #region TXT File EXPORT TEST TO XLS
        public bool ExportTestToXLS()
        {
            string strMsg = string.Empty;

            try
            {
                if (HelperTestBase.ProjectTestConcluded.IdProjectTestConcluded == 0)
                    strMsg = $"\t  TEST FILE EXPORTED!" + "\n\n\n" + "Test file without create a PROJECT TEST! ";
                else
                    strMsg = $"\t  TEST FILE EXPORTED! \n\n\n Test with file Ident # - [ { HelperTestBase.ProjectTestConcluded.ProjectTestSample.Project.Identification} ] exported!";

                MessageBox.Show(strMsg, _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
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
                    HelperTestBase.ProjectTestConcluded.ProjectTestSample.Project = new BLL_Operational_Project().GetHelperProjectByIdPrjTestConcluded(HelperApp.uiProjectTestConcludedSelecionado.ToString());

                    HelperTestBase.ProjectTestConcluded.ProjectTestSample.Project = HelperTestBase.ProjectTestConcluded.ProjectTestSample.Project == null ? new Model_Operational_Project() : HelperTestBase.ProjectTestConcluded.ProjectTestSample.Project;

                    HelperTestBase.ProjectTestConcluded.ProjectTestSample.Project.is_Created = HelperTestBase.ProjectTestConcluded.IdProjectTestConcluded > 0 ? true : false;

                    HelperTestBase.ProjectTestConcluded.ProjectTestFileName = _prjTestFileNameWithPath.Replace(_initialDirPathTestFile, string.Empty);

                    string dirReportChartImagePath = System.IO.Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, _helperApp.AppPath_ChartImageTests);

                    string strFileName = HelperTestBase.ProjectTestConcluded.ProjectTestFileName.Replace(_initialDirPathTestFile, "").Replace(_helperApp.AppTests_DefaultExtension, string.Empty);

                    string dirReportChartImagehWithFileName = string.Concat(dirReportChartImagePath, strFileName, _helperApp.AppPath_ChartImageExtension);

                    string dirReportChartImagehWithFileNamesvg = string.Concat(dirReportChartImagePath, strFileName, @".svg");

                    DataGridViewRowCollection gridResultRows = TAB_TableResult_Grid.Rows;

                    if (!_helperApp.Report_CreatePDF(dirReportChartImagehWithFileName, dirReportChartImagehWithFileNamesvg, strFileName, gridResultRows))
                    {
                        MessageBox.Show("Error, Report_CreatePDF!", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }

                    if (!_bPrjTestOffLineCarregado)
                        HelperTestBase.ProjectTestConcluded.ProjectTestSample.Project.is_OnLIne = true;
                }
                else
                    MessageBox.Show("Error, invalid test!", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
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

            if (diagram.SecondaryAxesY.Count > 0)
                diagram.SecondaryAxesY.Clear();

            #endregion
        }
        private bool CHART_LoadActualTestComplete()
        {
            try
            {
                CHART_Clear(devChart);

                if (_modelGVL.GVL_Graficos.arrVarX.Count() != 1000000)
                {
                    int outputChecked = rad_EvaluationParameters_CBOutputPC.Checked ? 1 : rad_EvaluationParameters_CBOutputSC.Checked ? 2 : 0;

                    _modelGVL.GVL_Parametros.iOutput = outputChecked > 0 ? outputChecked : HelperTestBase.Model_GVL.GVL_Parametros.iOutput;

                    _modelGVL.GVL_Graficos.iOutput = _modelGVL.GVL_Parametros.iOutput;

                    HelperTestBase.Model_GVL = _modelGVL;

                    bool bCreateChart = CHART_BinddDataConfig(HelperTestBase.Model_GVL.GVL_Graficos, lstDblChReadFileArr);

                    if (!bCreateChart)
                    {
                        MessageBox.Show("Failed, Chart Create !", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
                else
                {
                    for (int i = 0; i < lstStrChReadFileArr.Length; i++)
                        lstStrChReadFileArr[i].Clear();

                    MessageBox.Show("Failed, CHART_LoadActualTestComplete !", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);

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

                List<ActuationParameters_EvaluationParameters> lstInfoEvaluationParameters = new List<ActuationParameters_EvaluationParameters>();

                HelperTestBase.ProjectTest.is_OnLIne = HelperTestBase.ProjectTestConcluded.ProjectTestSample.Project.is_OnLIne;

                if (!HelperTestBase.ProjectTest.is_OnLIne)
                {
                    if (HelperTestBase.ProjectTestConcluded.IdProjectTestConcluded > 0 && HelperTestBase.ProjectTestConcluded.IdProjectTestSample > 0)
                        lstInfoEvaluationParameters = _helperApp.GridView_GetValuesEvalParamOffLineByFile(grid_tabActionParam_EvalParam);

                    if (lstInfoEvaluationParameters == null)
                    {
                        MessageBox.Show("Error, failed load rows data test - GridView_GetValuesEvalParamOffLineByFile!", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        return false;
                    }
                }
                else
                    lstInfoEvaluationParameters = _helperApp.GridView_GetValuesEvalParam(grid_tabActionParam_EvalParam);


                _helperApp.GVL_Graficos = _helperApp.ChartValidate(HelperApp.uiTesteSelecionado, HelperTestBase.Model_GVL.GVL_Graficos.iOutput, lstInfoEvaluationParameters);

                modelChartGVL = HelperTestBase.Model_GVL.GVL_Graficos;

                var chartGVL = HelperTestBase.Model_GVL.GVL_Graficos;

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
                            //diagram.EnableAxisXScrolling = true;
                            //diagram.EnableAxisYZooming = true;
                            //diagram.EnableAxisYScrolling = true;

                            #endregion

                            #region Axes

                            #region AXES - X

                            Color setColor = Color.Black;

                            //diagram.AxisX.Title.EnableAntialiasing = DefaultBoolean.False;
                            diagram.AxisX.Title.Font = new Font("Tahoma", 12, FontStyle.Regular);

                            diagram.AxisX.Title.Text = chartGVL.strNomeEixoX;  //@"nome eixo X";
                            diagram.AxisX.Title.Visibility = DefaultBoolean.True;
                            diagram.AxisX.Title.TextColor = setColor;
                            diagram.AxisX.Label.TextColor = setColor;

                            diagram.AxisX.VisualRange.Auto = false;

                            diagram.AxisX.Range.MinValue = chartGVL.EixoX.rMin;
                            diagram.AxisX.Range.MaxValue = chartGVL.EixoX.rMax;
                            diagram.AxisX.VisualRange.MinValue = chartGVL.EixoX.rMin;
                            diagram.AxisX.VisualRange.MaxValue = chartGVL.EixoX.rMax;
                            //Propriedade que elimina as "bordas" para fazer o eixo iniciar exatamente na escala definida
                            diagram.AxisX.WholeRange.SideMarginsValue = 0;

                            diagram.AxisX.MinorCount = 1;

                            diagram.AxisX.GridSpacingAuto = false;

                            if (chartGVL.EixoX.rMax > 0)
                                diagram.AxisX.NumericScaleOptions.GridSpacing = chartGVL.EixoX.rMax / 10;

                            if (chartGVL.EixoX.rMax < 0)
                                diagram.AxisX.NumericScaleOptions.GridSpacing = (chartGVL.EixoX.rMax * -1) / 10;

                            if (chartGVL.EixoX.rMax == 0)
                                diagram.AxisX.NumericScaleOptions.GridSpacing = 1;

                            //diagram.AxisX.GridSpacing = 1;

                            //diagram.AxisX.DateTimeScaleOptions.MeasureUnit = DateTimeMeasureUnit.Minute;
                            //diagram.AxisX.Label.TextPattern = @"d.M";
                            //}
                            //diagram.AxisX.DateTimeScaleOptions.GridAlignment = DateTimeGridAlignment.Hour;
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

                            Series serieY1 = devChart.Series[0];
                            Series seriePontosChartY1 = devChart.Series[1];


                            //// Assign the series2 to the created axes.
                            ((PointSeriesView)seriePontosChartY1.View).AxisY = diagram.AxisY;

                            setColor = serieY1.View.Color;

                            //diagram.AxisY.Title.EnableAntialiasing = DefaultBoolean.False;
                            diagram.AxisY.Title.Font = new Font("Tahoma", 12, FontStyle.Regular);

                            diagram.AxisY.Title.Text = chartGVL.iOutput == 2 ? chartGVL.strNomeEixoY2 : chartGVL.strNomeEixoY1;
                            diagram.AxisY.Title.Visibility = DefaultBoolean.True;
                            diagram.AxisY.Title.TextColor = setColor;
                            diagram.AxisY.Label.TextColor = setColor;

                            diagram.AxisY.Alignment = AxisAlignment.Near;
                            diagram.AxisY.Color = setColor;

                            diagram.AxisY.VisualRange.Auto = false;

                            diagram.AxisY.GridSpacingAuto = false;

                            diagram.AxisY.Range.MinValue = chartGVL.iOutput == 2 ? chartGVL.EixoY2.rMin : chartGVL.EixoY1.rMin;
                            diagram.AxisY.Range.MaxValue = chartGVL.iOutput == 2 ? chartGVL.EixoY2.rMax : chartGVL.EixoY1.rMax;
                            diagram.AxisY.VisualRange.MinValue = chartGVL.iOutput == 2 ? chartGVL.EixoY2.rMin : chartGVL.EixoY1.rMin;
                            diagram.AxisY.VisualRange.MaxValue = chartGVL.iOutput == 2 ? chartGVL.EixoY2.rMax : chartGVL.EixoY1.rMax;
                            diagram.AxisY.MinorCount = 1;
                            //Propriedade que elimina as "bordas" para fazer o eixo iniciar exatamente na escala definida
                            diagram.AxisY.WholeRange.SideMarginsValue = 0;

                            diagram.AxisY.Reverse = false;

                            if (Convert.ToDouble(diagram.AxisY.Range.MaxValue) < 0)
                            {
                                diagram.AxisY.Range.MaxValue = 0;
                                diagram.AxisY.Range.MinValue = chartGVL.iOutput == 2 ? chartGVL.EixoY2.rMax : chartGVL.EixoY1.rMax;

                                diagram.AxisY.MinorCount = 1;
                                diagram.AxisY.VisualRange.MinValue = chartGVL.iOutput == 2 ? chartGVL.EixoY2.rMin : chartGVL.EixoY1.rMin;
                                diagram.AxisY.VisualRange.MaxValue = chartGVL.iOutput == 2 ? chartGVL.EixoY2.rMax : chartGVL.EixoY1.rMax;
                                //Propriedade que elimina as "bordas" para fazer o eixo iniciar exatamente na escala definida
                                diagram.AxisY.WholeRange.SideMarginsValue = 0;

                                diagram.AxisY.Reverse = true;
                            }

                            if (chartGVL.EixoY1.rMax > 0)
                                diagram.AxisY.NumericScaleOptions.GridSpacing = chartGVL.EixoY1.rMax / 10;

                            if (chartGVL.EixoY1.rMax < 0)
                                diagram.AxisY.NumericScaleOptions.GridSpacing = (chartGVL.EixoY1.rMax * -1) / 10;

                            if (chartGVL.EixoY1.rMax == 0)
                                diagram.AxisY.NumericScaleOptions.GridSpacing = 1;

                            #endregion

                            #region ADD Y

                            int countSeries = devChart.Series.Count();

                            if (countSeries >= 3) //ultima Serie = Pontos de Interesse
                            {
                                if (diagram.SecondaryAxesY.Count > 0)
                                    diagram.SecondaryAxesY.Clear();

                                #region Y02

                                chartGVL.bOcultaY2 = chartGVL.iOutput > 0 ? true : false;

                                if (!chartGVL.bOcultaY2)
                                {
                                    Series serieY2 = devChart.Series[2];
                                    Series seriePontosChartY2 = devChart.Series[3];

                                    if (serieY2 == null) return false;

                                    setColor = serieY2.View.Color;

                                    //// Create two secondary axes, and add them to the chart's Diagram.
                                    SecondaryAxisY EixoY2 = new SecondaryAxisY(chartGVL.strNomeEixoY2);
                                    EixoY2.Title.Font = new Font("Tahoma", 12, FontStyle.Regular);

                                    diagram.SecondaryAxesY.Add(EixoY2);

                                    //// Assign the series2 to the created axes.
                                    ((LineSeriesView)serieY2.View).AxisY = EixoY2;
                                    ((PointSeriesView)seriePontosChartY2.View).AxisY = EixoY2;

                                    EixoY2.Title.Text = chartGVL.strNomeEixoY2;
                                    EixoY2.Title.Visibility = DevExpress.Utils.DefaultBoolean.True;
                                    EixoY2.Title.TextColor = setColor;
                                    EixoY2.Label.TextColor = setColor;
                                    EixoY2.Alignment = AxisAlignment.Near;
                                    EixoY2.Color = setColor;

                                    EixoY2.VisualRange.Auto = false;

                                    EixoY2.GridSpacingAuto = false;

                                    EixoY2.Range.MinValue = chartGVL.EixoY2.rMin;
                                    EixoY2.Range.MaxValue = chartGVL.EixoY2.rMax;
                                    EixoY2.VisualRange.MinValue = chartGVL.EixoY2.rMin;
                                    EixoY2.VisualRange.MaxValue = chartGVL.EixoY2.rMax;
                                    //Propriedade que elimina as "bordas" para fazer o eixo iniciar exatamente na escala definida
                                    EixoY2.WholeRange.SideMarginsValue = 0;
                                    EixoY2.MinorCount = 1;

                                    if (chartGVL.EixoY2.rMax > 0)
                                        EixoY2.NumericScaleOptions.GridSpacing = chartGVL.EixoY2.rMax / 10;

                                    if (chartGVL.EixoY2.rMax < 0)
                                        EixoY2.NumericScaleOptions.GridSpacing = (chartGVL.EixoY2.rMax * -1) / 10;

                                    if (chartGVL.EixoY2.rMax == 0)
                                        EixoY2.NumericScaleOptions.GridSpacing = 1;
                                }

                                #endregion

                                #region Y03

                                if (!chartGVL.bOcultaY3)
                                {
                                    Series serieY3 = devChart.Series[4];
                                    Series seriePontosChart = devChart.Series[5];

                                    if (serieY3 == null) return false;



                                    setColor = serieY3.View.Color;


                                    //// Create two secondary axes, and add them to the chart's Diagram.
                                    SecondaryAxisY EixoY3 = new SecondaryAxisY(chartGVL.strNomeEixoY3);
                                    EixoY3.Title.Font = new Font("Tahoma", 12, FontStyle.Regular);

                                    diagram.SecondaryAxesY.Add(EixoY3);

                                    //// Assign the series3 to the created axes.
                                    ((LineSeriesView)serieY3.View).AxisY = EixoY3;
                                    ((PointSeriesView)seriePontosChart.View).AxisY = EixoY3;

                                    EixoY3.Title.Text = chartGVL.strNomeEixoY3;
                                    EixoY3.Title.Visibility = DevExpress.Utils.DefaultBoolean.True;
                                    EixoY3.Title.TextColor = setColor;
                                    EixoY3.Label.TextColor = setColor;
                                    EixoY3.Alignment = AxisAlignment.Near;
                                    EixoY3.Color = setColor;

                                    EixoY3.VisualRange.Auto = false;
                                    EixoY3.GridSpacingAuto = false;

                                    EixoY3.Range.MinValue = chartGVL.EixoY3.rMin;
                                    EixoY3.Range.MaxValue = chartGVL.EixoY3.rMax;
                                    EixoY3.VisualRange.MinValue = chartGVL.EixoY3.rMin;
                                    EixoY3.VisualRange.MaxValue = chartGVL.EixoY3.rMax;

                                    //Propriedade que elimina as "bordas" para fazer o eixo iniciar exatamente na escala definida
                                    EixoY3.WholeRange.SideMarginsValue = 0;
                                    EixoY3.MinorCount = 1;

                                    if (chartGVL.EixoY3.rMax > 0)
                                        EixoY3.NumericScaleOptions.GridSpacing = chartGVL.EixoY3.rMax / 10;

                                    if (chartGVL.EixoY3.rMax < 0)
                                        EixoY3.NumericScaleOptions.GridSpacing = (chartGVL.EixoY3.rMax * -1) / 10;

                                    if (chartGVL.EixoY3.rMax == 0)
                                        EixoY3.NumericScaleOptions.GridSpacing = 1;
                                }

                                #endregion

                                #region Y04

                                if (!chartGVL.bOcultaY4)
                                {
                                    Series serieY4 = devChart.Series[6];
                                    Series seriePontosChart = devChart.Series[7];

                                    if (serieY4 == null) return false;

                                    setColor = serieY4.View.Color;

                                    //// Create two secondary axes, and add them to the chart's Diagram.
                                    SecondaryAxisY EixoY4 = new SecondaryAxisY(chartGVL.strNomeEixoY4);
                                    diagram.SecondaryAxesY.Add(EixoY4);

                                    //// Assign the series4 to the created axes.
                                    ((LineSeriesView)serieY4.View).AxisY = EixoY4;
                                    EixoY4.Title.Font = new Font("Tahoma", 12, FontStyle.Regular);

                                    ((PointSeriesView)seriePontosChart.View).AxisY = EixoY4;

                                    EixoY4.Title.Text = chartGVL.strNomeEixoY4;
                                    EixoY4.Title.Visibility = DevExpress.Utils.DefaultBoolean.True;
                                    EixoY4.Title.TextColor = setColor;
                                    EixoY4.Label.TextColor = setColor;
                                    EixoY4.Alignment = AxisAlignment.Near;
                                    EixoY4.Color = setColor;

                                    EixoY4.VisualRange.Auto = false;
                                    EixoY4.GridSpacingAuto = false;

                                    EixoY4.Range.MinValue = chartGVL.EixoY4.rMin;
                                    EixoY4.Range.MaxValue = chartGVL.EixoY4.rMax;
                                    EixoY4.VisualRange.MinValue = chartGVL.EixoY4.rMin;
                                    EixoY4.VisualRange.MaxValue = chartGVL.EixoY4.rMax;
                                    //Propriedade que elimina as "bordas" para fazer o eixo iniciar exatamente na escala definida
                                    EixoY4.WholeRange.SideMarginsValue = 0;
                                    EixoY4.MinorCount = 1;

                                    if (chartGVL.EixoY4.rMax > 0)
                                        EixoY4.NumericScaleOptions.GridSpacing = chartGVL.EixoY4.rMax / 10;

                                    if (chartGVL.EixoY4.rMax < 0)
                                        EixoY4.NumericScaleOptions.GridSpacing = (chartGVL.EixoY4.rMax * -1) / 10;

                                    if (chartGVL.EixoY4.rMax == 0)
                                        EixoY4.NumericScaleOptions.GridSpacing = 1;
                                }

                                #endregion

                                #region Y05

                                if (!chartGVL.bOcultaY5)
                                {
                                    Series serieY5 = devChart.Series[8];
                                    Series seriePontosChart = devChart.Series[9];

                                    if (serieY5 == null) return false;

                                    setColor = serieY5.View.Color;

                                    //// Create two secondary axes, and add them to the chart's Diagram.
                                    SecondaryAxisY EixoY5 = new SecondaryAxisY(chartGVL.strNomeEixoY5);
                                    EixoY5.Title.Font = new Font("Tahoma", 12, FontStyle.Regular);

                                    diagram.SecondaryAxesY.Add(EixoY5);

                                    //// Assign the series4 to the created axes.
                                    ((LineSeriesView)serieY5.View).AxisY = EixoY5;
                                    ((PointSeriesView)seriePontosChart.View).AxisY = EixoY5;

                                    EixoY5.Title.Text = chartGVL.strNomeEixoY5;
                                    EixoY5.Title.Visibility = DevExpress.Utils.DefaultBoolean.True;
                                    EixoY5.Title.TextColor = setColor;
                                    EixoY5.Label.TextColor = setColor;
                                    EixoY5.Alignment = AxisAlignment.Near;
                                    EixoY5.Color = setColor;

                                    EixoY5.VisualRange.Auto = false;
                                    EixoY5.GridSpacingAuto = false;

                                    EixoY5.Range.MinValue = chartGVL.EixoY5.rMin;
                                    EixoY5.Range.MaxValue = chartGVL.EixoY5.rMax;
                                    EixoY5.VisualRange.MinValue = chartGVL.EixoY5.rMin;
                                    EixoY5.VisualRange.MaxValue = chartGVL.EixoY5.rMax;
                                    //Propriedade que elimina as "bordas" para fazer o eixo iniciar exatamente na escala definida
                                    EixoY5.WholeRange.SideMarginsValue = 0;
                                    EixoY5.MinorCount = 1;

                                    if (chartGVL.EixoY5.rMax > 0)
                                        EixoY5.NumericScaleOptions.GridSpacing = chartGVL.EixoY5.rMax / 10;

                                    if (chartGVL.EixoY5.rMax < 0)
                                        EixoY5.NumericScaleOptions.GridSpacing = (chartGVL.EixoY5.rMax * -1) / 10;

                                    if (chartGVL.EixoY5.rMax == 0)
                                        EixoY5.NumericScaleOptions.GridSpacing = 1;

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

                        #region Chart titles

                        ChartTitle ChartTitle = new ChartTitle();
                        ChartTitle.Text = EnumExtensionMethods.GetDescriptionEXAMTYPE(HelperTestBase.eExamType);
                        ChartTitle.Alignment = StringAlignment.Center;
                        ChartTitle.Dock = ChartTitleDockStyle.Top;
                        ChartTitle.WordWrap = true;
                        ChartTitle.MaxLineCount = 2;

                        // Customize a title's appearance.
                        //ChartTitle.Antialiasing = true;
                        ChartTitle.Font = new Font("Tahoma", 18, FontStyle.Bold);
                        //ChartTitle.TextColor = Color.Red;
                        //ChartTitle  .Indent = 10;

                        devChart.Titles.Add(ChartTitle);

                        #endregion

                        // Hide the legend (if necessary).
                        devChart.Legend.Visibility = DevExpress.Utils.DefaultBoolean.False;

                        devChart.BackColor = Color.LightGray;

                        tab_Diagram.BackColor = Color.LightGray;

                        if (Convert.ToDouble(diagram.AxisX.Range.MaxValue) != HelperTestBase.Model_GVL.GVL_Graficos.EixoX.rMax)
                        {
                            diagram.AxisX.Range.MinValue = HelperTestBase.Model_GVL.GVL_Graficos.EixoX.rMin;
                            diagram.AxisX.Range.MaxValue = HelperTestBase.Model_GVL.GVL_Graficos.EixoX.rMax;

                            diagram.AxisY.Range.MinValue = HelperTestBase.Model_GVL.GVL_Graficos.iOutput == 2 ? HelperTestBase.Model_GVL.GVL_Graficos.EixoY2.rMin : HelperTestBase.Model_GVL.GVL_Graficos.EixoY1.rMin;
                            diagram.AxisY.Range.MaxValue = HelperTestBase.Model_GVL.GVL_Graficos.iOutput == 2 ? HelperTestBase.Model_GVL.GVL_Graficos.EixoY2.rMax : HelperTestBase.Model_GVL.GVL_Graficos.EixoY1.rMax;
                        }

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
                List<double> lstAnalogCh10_Vacuum = lstDblChReadFileArr[10];            //ch9.10 - HelperHBM._rVacuum - Pressao Linha Vacuo (-1)-0 bar (Linearizada)
                List<double> lstAnalogCh11_Velocity = lstDblChReadFileArr[11];          //ch9.11 - RESERVA
                List<double> lstAnalogCh12_Power = lstDblChReadFileArr[12];             //ch9.12 - RESERVA


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

                    Series series5 = new Series(modelChartGVL.strNomeEixoY5, ViewType.ScatterLine);
                    series5.ArgumentScaleType = ScaleType.Numerical;
                    series5.View.Color = Color.DarkGray;

                    #endregion

                    #region  Serie Inclusao de Pontos de Interesse

                    Series PontosChart1 = new Series("PontosInteresseY1", ViewType.Point);
                    PontosChart1.ArgumentScaleType = ScaleType.Numerical;

                    PointSeriesView PontosChartView1 = (PointSeriesView)PontosChart1.View; //Define a visualizacao da serie
                    PontosChartView1.PointMarkerOptions.Kind = MarkerKind.Cross; //Define o X
                    PontosChartView1.PointMarkerOptions.Size = 10;
                    PontosChartView1.Color = Color.Red;

                    Series PontosChart2 = new Series("PontosInteresseY2", ViewType.Point);
                    PontosChart2.ArgumentScaleType = ScaleType.Numerical;

                    PointSeriesView PontosChartView2 = (PointSeriesView)PontosChart2.View; //Define a visualizacao da serie
                    PontosChartView2.PointMarkerOptions.Kind = MarkerKind.Cross; //Define o X
                    PontosChartView2.PointMarkerOptions.Size = 10;
                    PontosChartView2.Color = Color.Red;

                    Series PontosChart3 = new Series("PontosInteresseY3", ViewType.Point);
                    PontosChart3.ArgumentScaleType = ScaleType.Numerical;

                    PointSeriesView PontosChartView3 = (PointSeriesView)PontosChart3.View; //Define a visualizacao da serie
                    PontosChartView3.PointMarkerOptions.Kind = MarkerKind.Cross; //Define o X
                    PontosChartView3.PointMarkerOptions.Size = 10;
                    PontosChartView3.Color = Color.Red;

                    Series PontosChart4 = new Series("PontosInteresseY4", ViewType.Point);
                    PontosChart4.ArgumentScaleType = ScaleType.Numerical;

                    PointSeriesView PontosChartView4 = (PointSeriesView)PontosChart4.View; //Define a visualizacao da serie
                    PontosChartView4.PointMarkerOptions.Kind = MarkerKind.Cross; //Define o X
                    PontosChartView4.PointMarkerOptions.Size = 10;
                    PontosChartView4.Color = Color.Red;

                    Series PontosChart5 = new Series("PontosInteresseY5", ViewType.Point);
                    PontosChart5.ArgumentScaleType = ScaleType.Numerical;

                    PointSeriesView PontosChartView5 = (PointSeriesView)PontosChart5.View; //Define a visualizacao da serie
                    PontosChartView5.PointMarkerOptions.Kind = MarkerKind.Cross; //Define o X
                    PontosChartView5.PointMarkerOptions.Size = 10;
                    PontosChartView5.Color = Color.Red;

                    #endregion

                    #region Add SeriePoints Values

                    switch (HelperApp.uiTesteSelecionado)
                    {
                        case 1:     //Force Diagrams - Force/Pressure With Vacuum
                        case 3:     //Force Diagrams - Force/Pressure Without Vacuum
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
                                                PontosChart1.Points.Add(new SeriesPoint(_modelGVL.GVL_T01.rForca_P1, _modelGVL.GVL_T01.rPressao_P1_Bar));
                                                PontosChart1.Points.Add(new SeriesPoint(_modelGVL.GVL_T01.rForca_P2, _modelGVL.GVL_T01.rPressao_P2_Bar));
                                                PontosChart1.Points.Add(new SeriesPoint(_modelGVL.GVL_T01.rForca_E1, _modelGVL.GVL_T01.rPressao_E1_Bar));
                                                PontosChart1.Points.Add(new SeriesPoint(_modelGVL.GVL_T01.rForca_E2, _modelGVL.GVL_T01.rPressao_E2_Bar));

                                                if (_modelGVL.GVL_T01.bRunOutTeorico)//Ponto Runout depende do flag selecionado
                                                    PontosChart1.Points.Add(new SeriesPoint(_modelGVL.GVL_T01.rRunOutForce_LinearInt_N, _modelGVL.GVL_T01.rRunOutPressure_LinearInt_Bar));
                                                else
                                                    PontosChart1.Points.Add(new SeriesPoint(_modelGVL.GVL_T01.rRunOutForce_Real_N, _modelGVL.GVL_T01.rRunOutPressure_Real_Bar));

                                                PontosChart1.Points.Add(new SeriesPoint(_modelGVL.GVL_T01.rForcaCutIn_N, _modelGVL.GVL_T01.rPressaoJumper_Bar));

                                                PontosChart1.Points.Add(new SeriesPoint(_modelGVL.GVL_T01.rForcaAvanco_Xpout_N, _modelGVL.GVL_T01.rPressaoHysteresePout_Bar));
                                                PontosChart1.Points.Add(new SeriesPoint(_modelGVL.GVL_T01.rForcaRetorno_Xpout_N, _modelGVL.GVL_T01.rPressaoHysteresePout_Bar));
                                                PontosChart1.Points.Add(new SeriesPoint(_modelGVL.GVL_T01.rForcaAvanco_Xbar_N, _modelGVL.GVL_T01.rPressaoHysterese_Bar));
                                                PontosChart1.Points.Add(new SeriesPoint(_modelGVL.GVL_T01.rForcaRetorno_Xbar_N, _modelGVL.GVL_T01.rPressaoHysterese_Bar));
                                            }
                                            break;
                                        case 3:
                                            {
                                                PontosChart1.Points.Add(new SeriesPoint(_modelGVL.GVL_T03.rForcaReal_E1_N, _modelGVL.GVL_T03.rPressao_E1_Bar));
                                                PontosChart1.Points.Add(new SeriesPoint(_modelGVL.GVL_T03.rForcaReal_E2_N, _modelGVL.GVL_T03.rPressao_E2_Bar));
                                            }
                                            break;
                                        case 25:
                                            {
                                                PontosChart1.Points.Add(new SeriesPoint(_modelGVL.GVL_T25.rForca_E1, _modelGVL.GVL_T25.rPressao_E1_Bar));
                                                PontosChart1.Points.Add(new SeriesPoint(_modelGVL.GVL_T25.rForca_E2, _modelGVL.GVL_T25.rPressao_E2_Bar));
                                                PontosChart1.Points.Add(new SeriesPoint(_modelGVL.GVL_T25.rForcaCutIn_N, _modelGVL.GVL_T25.rPressaoJumper_Bar));
                                                PontosChart1.Points.Add(new SeriesPoint(_modelGVL.GVL_T25.rDualRatioSwithcPointF_N, _modelGVL.GVL_T25.rDualRatioSwithcPointP_Bar));
                                                PontosChart1.Points.Add(new SeriesPoint(_modelGVL.GVL_T25.rForcaAvanco_Xpout_N, _modelGVL.GVL_T25.rPressaoHysteresePout_Bar));
                                                PontosChart1.Points.Add(new SeriesPoint(_modelGVL.GVL_T25.rForcaRetorno_Xpout_N, _modelGVL.GVL_T25.rPressaoHysteresePout_Bar));
                                                PontosChart1.Points.Add(new SeriesPoint(_modelGVL.GVL_T25.rForcaAvanco_Xbar_N, _modelGVL.GVL_T25.rPressaoHysterese_Bar));
                                                PontosChart1.Points.Add(new SeriesPoint(_modelGVL.GVL_T25.rForcaRetorno_Xbar_N, _modelGVL.GVL_T25.rPressaoHysterese_Bar));
                                                PontosChart1.Points.Add(new SeriesPoint(_modelGVL.GVL_T25.rRunOutForce_Real_N, _modelGVL.GVL_T25.rRunOutPressure_Real_Bar));
                                            }
                                            break;
                                        default:
                                            break;
                                    }

                                    #endregion

                                    devChart.Series.AddRange(new Series[] { series1, PontosChart1 });// aqui tem q mudar o pontos chart.. vai criar no indice errado
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
                                                PontosChart1.Points.Add(new SeriesPoint(_modelGVL.GVL_T02.rForcaReal_P1_N, _modelGVL.GVL_T02.rForcaOut_P1_N));
                                                PontosChart1.Points.Add(new SeriesPoint(_modelGVL.GVL_T02.rForcaReal_P2_N, _modelGVL.GVL_T02.rForcaOut_P2_N));
                                                PontosChart1.Points.Add(new SeriesPoint(_modelGVL.GVL_T02.rForcaReal_E1_N, _modelGVL.GVL_T02.rForcaOut_E1_N));
                                                PontosChart1.Points.Add(new SeriesPoint(_modelGVL.GVL_T02.rForcaReal_E2_N, _modelGVL.GVL_T02.rForcaOut_E2_N));

                                                if (_modelGVL.GVL_T02.bRunOutTeorico)//Ponto Runout depende do flag selecionado
                                                    PontosChart1.Points.Add(new SeriesPoint(_modelGVL.GVL_T02.rRunOutForce_LinearInt_N, _modelGVL.GVL_T02.rRunOutForceOut_LinearInt_N));
                                                else
                                                    PontosChart1.Points.Add(new SeriesPoint(_modelGVL.GVL_T02.rRunOutForce_Real_N, _modelGVL.GVL_T02.rRunOutForceOut_Real_N));

                                                PontosChart1.Points.Add(new SeriesPoint(_modelGVL.GVL_T02.rForcaFOutCutIn_N, _modelGVL.GVL_T02.rForcaOutJumper_N));
                                                PontosChart1.Points.Add(new SeriesPoint(_modelGVL.GVL_T02.rForcaAvanco_XFout_N, _modelGVL.GVL_T02.rForcaOutHystereseFout_N));
                                                PontosChart1.Points.Add(new SeriesPoint(_modelGVL.GVL_T02.rForcaRetorno_XFout_N, _modelGVL.GVL_T02.rForcaOutHystereseFout_N));
                                            }
                                            break;
                                        case 4:
                                            {
                                                PontosChart1.Points.Add(new SeriesPoint(_modelGVL.GVL_T04.rForca_E1, _modelGVL.GVL_T04.rForcaOut_E1_N));
                                                PontosChart1.Points.Add(new SeriesPoint(_modelGVL.GVL_T04.rForca_E2, _modelGVL.GVL_T04.rForcaOut_E2_N));
                                            }
                                            break;
                                        case 26:
                                            {
                                                PontosChart1.Points.Add(new SeriesPoint(_modelGVL.GVL_T26.rForca_E1, _modelGVL.GVL_T26.rForcaOut_E1_N));
                                                PontosChart1.Points.Add(new SeriesPoint(_modelGVL.GVL_T26.rForca_E2, _modelGVL.GVL_T26.rForcaOut_E2_N));
                                                PontosChart1.Points.Add(new SeriesPoint(_modelGVL.GVL_T26.rForcaFOutCutIn_N, _modelGVL.GVL_T26.rForcaFOutCutIn_N));
                                                PontosChart1.Points.Add(new SeriesPoint(_modelGVL.GVL_T26.rDualRatioSwithcPointF_N, _modelGVL.GVL_T26.rDualRatioSwithcPointFout_N));
                                                PontosChart1.Points.Add(new SeriesPoint(_modelGVL.GVL_T26.rForcaAvanco_XFout_N, _modelGVL.GVL_T26.rForcaOutHystereseFout_N));
                                                PontosChart1.Points.Add(new SeriesPoint(_modelGVL.GVL_T26.rForcaRetorno_XFout_N, _modelGVL.GVL_T26.rForcaOutHystereseFout_N));
                                                PontosChart1.Points.Add(new SeriesPoint(_modelGVL.GVL_T26.rRunOutForce_Real_N, _modelGVL.GVL_T26.rRunOutForceOut_Real_N));
                                            }
                                            break;
                                        default:
                                            break;
                                    }

                                    #endregion

                                    devChart.Series.AddRange(new Series[] { series1, PontosChart1 });
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
                        case 5:     //Vacuum Leakage - Released Position
                        case 6:     //Vacuum Leakage - Fully Applied Position
                        case 7:     //Vacuum Leakage - Lap Position
                            {
                                try
                                {
                                    #region  Serie de Valores

                                    //GVL_Graficos.strNomeEixoX = "Time (s)";
                                    //GVL_Graficos.strNomeEixoY1 = "Vacuum (bar)";
                                    switch (HelperApp.uiTesteSelecionado)
                                    {
                                        case 5:
                                            {
                                                for (i = 0; i <= totalPointsCount - 1; i++)
                                                {
                                                    series1.Points.Add(new SeriesPoint(lstAnalogCh00_Timestamp[i], lstAnalogCh10_Vacuum[i]));
                                                }
                                            }
                                            break;
                                        case 6:
                                            {
                                                var mxtime = lstAnalogCh00_Timestamp.Max();
                                                var mxvacuo = lstAnalogCh10_Vacuum.Max();

                                                var X1_Final = mxtime - 0.5;
                                                var X1_ValIdx = lstAnalogCh00_Timestamp.Aggregate((x1, y1) => Math.Abs(x1 - X1_Final) < Math.Abs(y1 - X1_Final) ? x1 : y1);
                                                var X1_PosVacuoFinal = lstAnalogCh00_Timestamp.IndexOf(X1_ValIdx);
                                                var Y1_VacuoFinal = lstAnalogCh10_Vacuum.ElementAt(X1_PosVacuoFinal);

                                                var X2_Inicial = X1_Final - (HelperTestBase.Model_GVL.GVL_T06.rTempoTeste + HelperTestBase.Model_GVL.GVL_T06.rTempoEstabilizacao);
                                                var X2_ValIdx = lstAnalogCh00_Timestamp.Aggregate((x2, y2) => Math.Abs(x2 - X2_Inicial) < Math.Abs(y2 - X2_Inicial) ? x2 : y2);
                                                var X2_PosVacuoInicial = lstAnalogCh00_Timestamp.IndexOf(X2_ValIdx);
                                                var Y2_VacuoInicial = lstAnalogCh10_Vacuum.ElementAt(X2_PosVacuoInicial);

                                                for (i = X2_PosVacuoInicial; i <= totalPointsCount - 1; i++)
                                                {
                                                    series1.Points.Add(new SeriesPoint(lstAnalogCh00_Timestamp[i] - X2_ValIdx, lstAnalogCh10_Vacuum[i]));
                                                }
                                            }
                                            break;
                                        case 7:
                                            {
                                                var mxtime = lstAnalogCh00_Timestamp.Max();
                                                var mxvacuo = lstAnalogCh10_Vacuum.Max();

                                                var X1_Final = mxtime - 0.5;
                                                var X1_ValIdx = lstAnalogCh00_Timestamp.Aggregate((x1, y1) => Math.Abs(x1 - X1_Final) < Math.Abs(y1 - X1_Final) ? x1 : y1);
                                                var X1_PosVacuoFinal = lstAnalogCh00_Timestamp.IndexOf(X1_ValIdx);
                                                var Y1_VacuoFinal = lstAnalogCh10_Vacuum.ElementAt(X1_PosVacuoFinal);

                                                var X2_Inicial = X1_Final - (HelperTestBase.Model_GVL.GVL_T07.rTempoTeste + HelperTestBase.Model_GVL.GVL_T07.rTempoEstabilizacao);
                                                var X2_ValIdx = lstAnalogCh00_Timestamp.Aggregate((x2, y2) => Math.Abs(x2 - X2_Inicial) < Math.Abs(y2 - X2_Inicial) ? x2 : y2);
                                                var X2_PosVacuoInicial = lstAnalogCh00_Timestamp.IndexOf(X2_ValIdx);
                                                var Y2_VacuoInicial = lstAnalogCh10_Vacuum.ElementAt(X2_PosVacuoInicial);

                                                for (i = X2_PosVacuoInicial; i <= totalPointsCount - 1; i++)
                                                {
                                                    series1.Points.Add(new SeriesPoint(lstAnalogCh00_Timestamp[i] - X2_ValIdx, lstAnalogCh10_Vacuum[i]));
                                                }
                                            }
                                            break;
                                        default:
                                            break;

                                    }
                                    #endregion

                                    #region  Serie Pontos de Interesse

                                    switch (HelperApp.uiTesteSelecionado)
                                    {
                                        case 5:
                                            {
                                                var mxtime = lstAnalogCh00_Timestamp.Max();
                                                var mxvacuo = lstAnalogCh10_Vacuum.Max();

                                                var X1_Final = mxtime - 0.5;
                                                var X1_ValIdx = lstAnalogCh00_Timestamp.Aggregate((x1, y1) => Math.Abs(x1 - X1_Final) < Math.Abs(y1 - X1_Final) ? x1 : y1);
                                                var X1_PosVacuoFinal = lstAnalogCh00_Timestamp.IndexOf(X1_ValIdx);
                                                var Y1_VacuoFinal = lstAnalogCh10_Vacuum.ElementAt(X1_PosVacuoFinal);

                                                var X2_Inicial = X1_Final - HelperTestBase.Model_GVL.GVL_T05.rTempoTeste;
                                                var X2_ValIdx = lstAnalogCh00_Timestamp.Aggregate((x2, y2) => Math.Abs(x2 - X2_Inicial) < Math.Abs(y2 - X2_Inicial) ? x2 : y2);
                                                var X2_PosVacuoInicial = lstAnalogCh00_Timestamp.IndexOf(X2_ValIdx);
                                                var Y2_VacuoInicial = lstAnalogCh10_Vacuum.ElementAt(X2_PosVacuoInicial);

                                                PontosChart1.Points.Add(new SeriesPoint(X1_Final, Y1_VacuoFinal));
                                                PontosChart1.Points.Add(new SeriesPoint(X2_Inicial, Y2_VacuoInicial));
                                            }
                                            break;
                                        case 6:
                                            {
                                                var mxtime = lstAnalogCh00_Timestamp.Max();
                                                var mxvacuo = lstAnalogCh10_Vacuum.Max();

                                                var X1_Final = mxtime - 0.5;
                                                var X1_ValIdx = lstAnalogCh00_Timestamp.Aggregate((x1, y1) => Math.Abs(x1 - X1_Final) < Math.Abs(y1 - X1_Final) ? x1 : y1);
                                                var X1_PosVacuoFinal = lstAnalogCh00_Timestamp.IndexOf(X1_ValIdx);
                                                var Y1_VacuoFinal = lstAnalogCh10_Vacuum.ElementAt(X1_PosVacuoFinal);

                                                var X2_Inicial = X1_Final - HelperTestBase.Model_GVL.GVL_T06.rTempoTeste;
                                                var X2_ValIdx = lstAnalogCh00_Timestamp.Aggregate((x2, y2) => Math.Abs(x2 - X2_Inicial) < Math.Abs(y2 - X2_Inicial) ? x2 : y2);
                                                var X2_PosVacuoInicial = lstAnalogCh00_Timestamp.IndexOf(X2_ValIdx);
                                                var Y2_VacuoInicial = lstAnalogCh10_Vacuum.ElementAt(X2_PosVacuoInicial);

                                                PontosChart1.Points.Add(new SeriesPoint((X1_Final - X2_ValIdx) + HelperTestBase.Model_GVL.GVL_T06.rTempoEstabilizacao, Y1_VacuoFinal));
                                                PontosChart1.Points.Add(new SeriesPoint((X2_Inicial - X2_ValIdx) + HelperTestBase.Model_GVL.GVL_T06.rTempoEstabilizacao, Y2_VacuoInicial));
                                            }
                                            break;
                                        case 7:
                                            {
                                                var mxtime = lstAnalogCh00_Timestamp.Max();
                                                var mxvacuo = lstAnalogCh10_Vacuum.Max();

                                                var X1_Final = mxtime - 0.5;
                                                var X1_ValIdx = lstAnalogCh00_Timestamp.Aggregate((x1, y1) => Math.Abs(x1 - X1_Final) < Math.Abs(y1 - X1_Final) ? x1 : y1);
                                                var X1_PosVacuoFinal = lstAnalogCh00_Timestamp.IndexOf(X1_ValIdx);
                                                var Y1_VacuoFinal = lstAnalogCh10_Vacuum.ElementAt(X1_PosVacuoFinal);

                                                var X2_Inicial = X1_Final - HelperTestBase.Model_GVL.GVL_T07.rTempoTeste;
                                                var X2_ValIdx = lstAnalogCh00_Timestamp.Aggregate((x2, y2) => Math.Abs(x2 - X2_Inicial) < Math.Abs(y2 - X2_Inicial) ? x2 : y2);
                                                var X2_PosVacuoInicial = lstAnalogCh00_Timestamp.IndexOf(X2_ValIdx);
                                                var Y2_VacuoInicial = lstAnalogCh10_Vacuum.ElementAt(X2_PosVacuoInicial);

                                                PontosChart1.Points.Add(new SeriesPoint((X1_Final - X2_ValIdx) + HelperTestBase.Model_GVL.GVL_T07.rTempoEstabilizacao, Y1_VacuoFinal));
                                                PontosChart1.Points.Add(new SeriesPoint((X2_Inicial - X2_ValIdx) + HelperTestBase.Model_GVL.GVL_T07.rTempoEstabilizacao, Y2_VacuoInicial));
                                            }
                                            break;
                                        default:
                                            break;
                                    }

                                    #endregion

                                    devChart.Series.AddRange(new Series[] { series1, PontosChart1 });
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

                                    switch (HelperApp.uiTesteSelecionado)
                                    {
                                        case 8:
                                            {
                                                var mxtime = lstAnalogCh00_Timestamp.Max();
                                                var mxvacuo = lstAnalogCh10_Vacuum.Max();

                                                var X1_Final = mxtime - 0.5;
                                                var X1_ValIdx = lstAnalogCh00_Timestamp.Aggregate((x1, y1) => Math.Abs(x1 - X1_Final) < Math.Abs(y1 - X1_Final) ? x1 : y1);
                                                var X1_PosVacuoFinal = lstAnalogCh00_Timestamp.IndexOf(X1_ValIdx);
                                                var Y1_VacuoFinal = lstAnalogCh10_Vacuum.ElementAt(X1_PosVacuoFinal);

                                                var X2_Inicial = X1_Final - (HelperTestBase.Model_GVL.GVL_T08.rTempoTeste + HelperTestBase.Model_GVL.GVL_T08.rTempoEstabilizacao);
                                                var X2_ValIdx = lstAnalogCh00_Timestamp.Aggregate((x2, y2) => Math.Abs(x2 - X2_Inicial) < Math.Abs(y2 - X2_Inicial) ? x2 : y2);
                                                var X2_PosVacuoInicial = lstAnalogCh00_Timestamp.IndexOf(X2_ValIdx);
                                                var Y2_VacuoInicial = lstAnalogCh10_Vacuum.ElementAt(X2_PosVacuoInicial);

                                                for (i = X2_PosVacuoInicial; i <= totalPointsCount - 1; i++)
                                                {
                                                    series1.Points.Add(new SeriesPoint(lstAnalogCh00_Timestamp[i] - X2_ValIdx, lstAnalogCh10_Vacuum[i]));
                                                    series2.Points.Add(new SeriesPoint(lstAnalogCh00_Timestamp[i] - X2_ValIdx, lstAnalogCh07_PressurePC[i]));
                                                    series3.Points.Add(new SeriesPoint(lstAnalogCh00_Timestamp[i] - X2_ValIdx, lstAnalogCh06_PressureSC[i]));
                                                    series4.Points.Add(new SeriesPoint(lstAnalogCh00_Timestamp[i] - X2_ValIdx, lstAnalogCh05_TravelPiston[i]));
                                                }
                                            }
                                            break;
                                        case 9:
                                            {
                                                var mxtime = lstAnalogCh00_Timestamp.Max();
                                                var mxvacuo = lstAnalogCh10_Vacuum.Max();

                                                var X1_Final = mxtime - 0.5;
                                                var X1_ValIdx = lstAnalogCh00_Timestamp.Aggregate((x1, y1) => Math.Abs(x1 - X1_Final) < Math.Abs(y1 - X1_Final) ? x1 : y1);
                                                var X1_PosVacuoFinal = lstAnalogCh00_Timestamp.IndexOf(X1_ValIdx);
                                                var Y1_VacuoFinal = lstAnalogCh10_Vacuum.ElementAt(X1_PosVacuoFinal);

                                                var X2_Inicial = X1_Final - (HelperTestBase.Model_GVL.GVL_T09.rTempoTeste + HelperTestBase.Model_GVL.GVL_T09.rTempoEstabilizacao);
                                                var X2_ValIdx = lstAnalogCh00_Timestamp.Aggregate((x2, y2) => Math.Abs(x2 - X2_Inicial) < Math.Abs(y2 - X2_Inicial) ? x2 : y2);
                                                var X2_PosVacuoInicial = lstAnalogCh00_Timestamp.IndexOf(X2_ValIdx);
                                                var Y2_VacuoInicial = lstAnalogCh10_Vacuum.ElementAt(X2_PosVacuoInicial);

                                                for (i = X2_PosVacuoInicial; i <= totalPointsCount - 1; i++)
                                                {
                                                    series1.Points.Add(new SeriesPoint(lstAnalogCh00_Timestamp[i] - X2_ValIdx, lstAnalogCh10_Vacuum[i]));
                                                    series2.Points.Add(new SeriesPoint(lstAnalogCh00_Timestamp[i] - X2_ValIdx, lstAnalogCh07_PressurePC[i]));
                                                    series3.Points.Add(new SeriesPoint(lstAnalogCh00_Timestamp[i] - X2_ValIdx, lstAnalogCh06_PressureSC[i]));
                                                    series4.Points.Add(new SeriesPoint(lstAnalogCh00_Timestamp[i] - X2_ValIdx, lstAnalogCh05_TravelPiston[i]));
                                                }
                                            }
                                            break;
                                        case 10:
                                            {
                                                var mxtime = lstAnalogCh00_Timestamp.Max();
                                                var mxvacuo = lstAnalogCh10_Vacuum.Max();

                                                var X1_Final = mxtime - 0.5;
                                                var X1_ValIdx = lstAnalogCh00_Timestamp.Aggregate((x1, y1) => Math.Abs(x1 - X1_Final) < Math.Abs(y1 - X1_Final) ? x1 : y1);
                                                var X1_PosVacuoFinal = lstAnalogCh00_Timestamp.IndexOf(X1_ValIdx);
                                                var Y1_VacuoFinal = lstAnalogCh10_Vacuum.ElementAt(X1_PosVacuoFinal);

                                                var X2_Inicial = X1_Final - (HelperTestBase.Model_GVL.GVL_T10.rTempoTeste + HelperTestBase.Model_GVL.GVL_T10.rTempoEstabilizacao);
                                                var X2_ValIdx = lstAnalogCh00_Timestamp.Aggregate((x2, y2) => Math.Abs(x2 - X2_Inicial) < Math.Abs(y2 - X2_Inicial) ? x2 : y2);
                                                var X2_PosVacuoInicial = lstAnalogCh00_Timestamp.IndexOf(X2_ValIdx);
                                                var Y2_VacuoInicial = lstAnalogCh10_Vacuum.ElementAt(X2_PosVacuoInicial);

                                                for (i = X2_PosVacuoInicial; i <= totalPointsCount - 1; i++)
                                                {
                                                    series1.Points.Add(new SeriesPoint(lstAnalogCh00_Timestamp[i] - X2_ValIdx, lstAnalogCh10_Vacuum[i]));
                                                    series2.Points.Add(new SeriesPoint(lstAnalogCh00_Timestamp[i] - X2_ValIdx, lstAnalogCh07_PressurePC[i]));
                                                    series3.Points.Add(new SeriesPoint(lstAnalogCh00_Timestamp[i] - X2_ValIdx, lstAnalogCh06_PressureSC[i]));
                                                    series4.Points.Add(new SeriesPoint(lstAnalogCh00_Timestamp[i] - X2_ValIdx, lstAnalogCh05_TravelPiston[i]));
                                                }
                                            }
                                            break;
                                    }

                                    #endregion

                                    #region  Serie Pontos de Interesse

                                    switch (HelperApp.uiTesteSelecionado)
                                    {
                                        case 8:
                                            {
                                                var mxtime = lstAnalogCh00_Timestamp.Max();
                                                var mxvacuo = lstAnalogCh10_Vacuum.Max();

                                                var X1_Final = mxtime - 0.5;
                                                var X1_ValIdx = lstAnalogCh00_Timestamp.Aggregate((x1, y1) => Math.Abs(x1 - X1_Final) < Math.Abs(y1 - X1_Final) ? x1 : y1);
                                                var X1_PosVacuoFinal = lstAnalogCh00_Timestamp.IndexOf(X1_ValIdx);
                                                var Y1_VacuoFinal = lstAnalogCh10_Vacuum.ElementAt(X1_PosVacuoFinal);

                                                var X2_Inicial = X1_Final - HelperTestBase.Model_GVL.GVL_T08.rTempoTeste;
                                                var X2_ValIdx = lstAnalogCh00_Timestamp.Aggregate((x2, y2) => Math.Abs(x2 - X2_Inicial) < Math.Abs(y2 - X2_Inicial) ? x2 : y2);
                                                var X2_PosVacuoInicial = lstAnalogCh00_Timestamp.IndexOf(X2_ValIdx);
                                                var Y2_VacuoInicial = lstAnalogCh10_Vacuum.ElementAt(X2_PosVacuoInicial);

                                                PontosChart1.Points.Add(new SeriesPoint((X1_Final - X2_ValIdx) + HelperTestBase.Model_GVL.GVL_T08.rTempoEstabilizacao, Y1_VacuoFinal));
                                                PontosChart1.Points.Add(new SeriesPoint((X2_Inicial - X2_ValIdx) + HelperTestBase.Model_GVL.GVL_T08.rTempoEstabilizacao, Y2_VacuoInicial));


                                                var mxpressCP = lstAnalogCh07_PressurePC.Max();

                                                var X3_Final = mxtime - 0.5;
                                                var X3_ValIdx = lstAnalogCh00_Timestamp.Aggregate((x1, y1) => Math.Abs(x1 - X3_Final) < Math.Abs(y1 - X3_Final) ? x1 : y1);
                                                var X3_PosPressFinal = lstAnalogCh00_Timestamp.IndexOf(X3_ValIdx);
                                                var Y3_PressFinal = lstAnalogCh07_PressurePC.ElementAt(X3_PosPressFinal);

                                                var X4_Inicial = X3_Final - HelperTestBase.Model_GVL.GVL_T08.rTempoTeste;
                                                var X4_ValIdx = lstAnalogCh00_Timestamp.Aggregate((x2, y2) => Math.Abs(x2 - X2_Inicial) < Math.Abs(y2 - X4_Inicial) ? x2 : y2);
                                                var X4_PosPressInicial = lstAnalogCh00_Timestamp.IndexOf(X4_ValIdx);
                                                var Y4_PressInicial = lstAnalogCh07_PressurePC.ElementAt(X4_PosPressInicial);

                                                PontosChart2.Points.Add(new SeriesPoint((X3_Final - X4_ValIdx) + HelperTestBase.Model_GVL.GVL_T08.rTempoEstabilizacao, Y3_PressFinal));
                                                PontosChart2.Points.Add(new SeriesPoint((X4_Inicial - X4_ValIdx) + HelperTestBase.Model_GVL.GVL_T08.rTempoEstabilizacao, Y4_PressInicial));

                                                //Calculo da perda de pressao CS

                                                var mxpressCS = lstAnalogCh06_PressureSC.Max();

                                                var X5_Final = mxtime - 0.5;
                                                var X5_ValIdx = lstAnalogCh00_Timestamp.Aggregate((x1, y1) => Math.Abs(x1 - X3_Final) < Math.Abs(y1 - X5_Final) ? x1 : y1);
                                                var X5_PosPressFinal = lstAnalogCh00_Timestamp.IndexOf(X5_ValIdx);
                                                var Y5_PressFinal = lstAnalogCh06_PressureSC.ElementAt(X5_PosPressFinal);

                                                var X6_Inicial = X5_Final - HelperTestBase.Model_GVL.GVL_T08.rTempoTeste;
                                                var X6_ValIdx = lstAnalogCh00_Timestamp.Aggregate((x2, y2) => Math.Abs(x2 - X6_Inicial) < Math.Abs(y2 - X6_Inicial) ? x2 : y2);
                                                var X6_PosPressInicial = lstAnalogCh00_Timestamp.IndexOf(X6_ValIdx);
                                                var Y6_PressInicial = lstAnalogCh06_PressureSC.ElementAt(X6_PosPressInicial);

                                                PontosChart3.Points.Add(new SeriesPoint((X5_Final - X6_ValIdx) + HelperTestBase.Model_GVL.GVL_T08.rTempoEstabilizacao, Y5_PressFinal));
                                                PontosChart3.Points.Add(new SeriesPoint((X6_Inicial - X6_ValIdx) + HelperTestBase.Model_GVL.GVL_T08.rTempoEstabilizacao, Y6_PressInicial));

                                            }
                                            break;
                                        case 9:
                                            {
                                                var mxtime = lstAnalogCh00_Timestamp.Max();
                                                var mxvacuo = lstAnalogCh10_Vacuum.Max();

                                                var X1_Final = mxtime - 0.5;
                                                var X1_ValIdx = lstAnalogCh00_Timestamp.Aggregate((x1, y1) => Math.Abs(x1 - X1_Final) < Math.Abs(y1 - X1_Final) ? x1 : y1);
                                                var X1_PosVacuoFinal = lstAnalogCh00_Timestamp.IndexOf(X1_ValIdx);
                                                var Y1_VacuoFinal = lstAnalogCh10_Vacuum.ElementAt(X1_PosVacuoFinal);

                                                var X2_Inicial = X1_Final - HelperTestBase.Model_GVL.GVL_T09.rTempoTeste;
                                                var X2_ValIdx = lstAnalogCh00_Timestamp.Aggregate((x2, y2) => Math.Abs(x2 - X2_Inicial) < Math.Abs(y2 - X2_Inicial) ? x2 : y2);
                                                var X2_PosVacuoInicial = lstAnalogCh00_Timestamp.IndexOf(X2_ValIdx);
                                                var Y2_VacuoInicial = lstAnalogCh10_Vacuum.ElementAt(X2_PosVacuoInicial);

                                                PontosChart1.Points.Add(new SeriesPoint((X1_Final - X2_ValIdx) + HelperTestBase.Model_GVL.GVL_T09.rTempoEstabilizacao, Y1_VacuoFinal));
                                                PontosChart1.Points.Add(new SeriesPoint((X2_Inicial - X2_ValIdx) + HelperTestBase.Model_GVL.GVL_T09.rTempoEstabilizacao, Y2_VacuoInicial));

                                                var mxpressCP = lstAnalogCh07_PressurePC.Max();

                                                var X3_Final = mxtime - 0.5;
                                                var X3_ValIdx = lstAnalogCh00_Timestamp.Aggregate((x1, y1) => Math.Abs(x1 - X3_Final) < Math.Abs(y1 - X3_Final) ? x1 : y1);
                                                var X3_PosPressFinal = lstAnalogCh00_Timestamp.IndexOf(X3_ValIdx);
                                                var Y3_PressFinal = lstAnalogCh07_PressurePC.ElementAt(X3_PosPressFinal);

                                                var X4_Inicial = X3_Final - HelperTestBase.Model_GVL.GVL_T09.rTempoTeste;
                                                var X4_ValIdx = lstAnalogCh00_Timestamp.Aggregate((x2, y2) => Math.Abs(x2 - X2_Inicial) < Math.Abs(y2 - X4_Inicial) ? x2 : y2);
                                                var X4_PosPressInicial = lstAnalogCh00_Timestamp.IndexOf(X4_ValIdx);
                                                var Y4_PressInicial = lstAnalogCh07_PressurePC.ElementAt(X4_PosPressInicial);

                                                PontosChart2.Points.Add(new SeriesPoint((X3_Final - X4_ValIdx) + HelperTestBase.Model_GVL.GVL_T09.rTempoEstabilizacao, Y3_PressFinal));
                                                PontosChart2.Points.Add(new SeriesPoint((X4_Inicial - X4_ValIdx) + HelperTestBase.Model_GVL.GVL_T09.rTempoEstabilizacao, Y4_PressInicial));

                                                //Calculo da perda de pressao CS

                                                var mxpressCS = lstAnalogCh06_PressureSC.Max();

                                                var X5_Final = mxtime - 0.5;
                                                var X5_ValIdx = lstAnalogCh00_Timestamp.Aggregate((x1, y1) => Math.Abs(x1 - X3_Final) < Math.Abs(y1 - X5_Final) ? x1 : y1);
                                                var X5_PosPressFinal = lstAnalogCh00_Timestamp.IndexOf(X5_ValIdx);
                                                var Y5_PressFinal = lstAnalogCh06_PressureSC.ElementAt(X5_PosPressFinal);

                                                var X6_Inicial = X5_Final - HelperTestBase.Model_GVL.GVL_T09.rTempoTeste;
                                                var X6_ValIdx = lstAnalogCh00_Timestamp.Aggregate((x2, y2) => Math.Abs(x2 - X6_Inicial) < Math.Abs(y2 - X6_Inicial) ? x2 : y2);
                                                var X6_PosPressInicial = lstAnalogCh00_Timestamp.IndexOf(X6_ValIdx);
                                                var Y6_PressInicial = lstAnalogCh06_PressureSC.ElementAt(X6_PosPressInicial);

                                                PontosChart3.Points.Add(new SeriesPoint((X5_Final - X6_ValIdx) + HelperTestBase.Model_GVL.GVL_T09.rTempoEstabilizacao, Y5_PressFinal));
                                                PontosChart3.Points.Add(new SeriesPoint((X6_Inicial - X6_ValIdx) + HelperTestBase.Model_GVL.GVL_T09.rTempoEstabilizacao, Y6_PressInicial));
                                            }
                                            break;
                                        case 10:
                                            {
                                                var mxtime = lstAnalogCh00_Timestamp.Max();
                                                var mxvacuo = lstAnalogCh10_Vacuum.Max();

                                                var X1_Final = mxtime - 0.5;
                                                var X1_ValIdx = lstAnalogCh00_Timestamp.Aggregate((x1, y1) => Math.Abs(x1 - X1_Final) < Math.Abs(y1 - X1_Final) ? x1 : y1);
                                                var X1_PosVacuoFinal = lstAnalogCh00_Timestamp.IndexOf(X1_ValIdx);
                                                var Y1_VacuoFinal = lstAnalogCh10_Vacuum.ElementAt(X1_PosVacuoFinal);

                                                var X2_Inicial = X1_Final - HelperTestBase.Model_GVL.GVL_T10.rTempoTeste;
                                                var X2_ValIdx = lstAnalogCh00_Timestamp.Aggregate((x2, y2) => Math.Abs(x2 - X2_Inicial) < Math.Abs(y2 - X2_Inicial) ? x2 : y2);
                                                var X2_PosVacuoInicial = lstAnalogCh00_Timestamp.IndexOf(X2_ValIdx);
                                                var Y2_VacuoInicial = lstAnalogCh10_Vacuum.ElementAt(X2_PosVacuoInicial);

                                                PontosChart1.Points.Add(new SeriesPoint((X1_Final - X2_ValIdx) + HelperTestBase.Model_GVL.GVL_T10.rTempoEstabilizacao, Y1_VacuoFinal));
                                                PontosChart1.Points.Add(new SeriesPoint((X2_Inicial - X2_ValIdx) + HelperTestBase.Model_GVL.GVL_T10.rTempoEstabilizacao, Y2_VacuoInicial));

                                                var mxpressCP = lstAnalogCh07_PressurePC.Max();

                                                var X3_Final = mxtime - 0.5;
                                                var X3_ValIdx = lstAnalogCh00_Timestamp.Aggregate((x1, y1) => Math.Abs(x1 - X3_Final) < Math.Abs(y1 - X3_Final) ? x1 : y1);
                                                var X3_PosPressFinal = lstAnalogCh00_Timestamp.IndexOf(X3_ValIdx);
                                                var Y3_PressFinal = lstAnalogCh07_PressurePC.ElementAt(X3_PosPressFinal);

                                                var X4_Inicial = X3_Final - HelperTestBase.Model_GVL.GVL_T10.rTempoTeste;
                                                var X4_ValIdx = lstAnalogCh00_Timestamp.Aggregate((x2, y2) => Math.Abs(x2 - X2_Inicial) < Math.Abs(y2 - X4_Inicial) ? x2 : y2);
                                                var X4_PosPressInicial = lstAnalogCh00_Timestamp.IndexOf(X4_ValIdx);
                                                var Y4_PressInicial = lstAnalogCh07_PressurePC.ElementAt(X4_PosPressInicial);

                                                PontosChart2.Points.Add(new SeriesPoint((X3_Final - X4_ValIdx) + HelperTestBase.Model_GVL.GVL_T10.rTempoEstabilizacao, Y3_PressFinal));
                                                PontosChart2.Points.Add(new SeriesPoint((X4_Inicial - X4_ValIdx) + HelperTestBase.Model_GVL.GVL_T10.rTempoEstabilizacao, Y4_PressInicial));

                                                //Calculo da perda de pressao CS

                                                var mxpressCS = lstAnalogCh06_PressureSC.Max();

                                                var X5_Final = mxtime - 0.5;
                                                var X5_ValIdx = lstAnalogCh00_Timestamp.Aggregate((x1, y1) => Math.Abs(x1 - X3_Final) < Math.Abs(y1 - X5_Final) ? x1 : y1);
                                                var X5_PosPressFinal = lstAnalogCh00_Timestamp.IndexOf(X5_ValIdx);
                                                var Y5_PressFinal = lstAnalogCh06_PressureSC.ElementAt(X5_PosPressFinal);

                                                var X6_Inicial = X5_Final - HelperTestBase.Model_GVL.GVL_T10.rTempoTeste;
                                                var X6_ValIdx = lstAnalogCh00_Timestamp.Aggregate((x2, y2) => Math.Abs(x2 - X6_Inicial) < Math.Abs(y2 - X6_Inicial) ? x2 : y2);
                                                var X6_PosPressInicial = lstAnalogCh00_Timestamp.IndexOf(X6_ValIdx);
                                                var Y6_PressInicial = lstAnalogCh06_PressureSC.ElementAt(X6_PosPressInicial);

                                                PontosChart3.Points.Add(new SeriesPoint((X5_Final - X6_ValIdx) + HelperTestBase.Model_GVL.GVL_T10.rTempoEstabilizacao, Y5_PressFinal));
                                                PontosChart3.Points.Add(new SeriesPoint((X6_Inicial - X6_ValIdx) + HelperTestBase.Model_GVL.GVL_T10.rTempoEstabilizacao, Y6_PressInicial));
                                            }
                                            break;
                                        default:
                                            break;
                                    }

                                    #endregion

                                    devChart.Series.AddRange(new Series[] { series1, PontosChart1, series2, PontosChart2, series3, PontosChart3, series4, PontosChart4 });

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
                                    switch (HelperApp.uiTesteSelecionado)

                                    {
                                        case 11:
                                            {
                                                for (i = 0; i <= totalPointsCount - 1; i++)
                                                {
                                                    series1.Points.Add(new SeriesPoint(lstAnalogCh00_Timestamp[i], lstAnalogCh02_InputForce1[i]));
                                                }
                                                break;
                                            }
                                        case 12:
                                            {
                                                var maxValue_Force = lstAnalogCh02_InputForce1.Max();
                                                var maxPos_Force = lstAnalogCh02_InputForce1.IndexOf(maxValue_Force);
                                                var PosInt = 0;
                                                var PosFinal = 0;

                                                for (i = maxPos_Force; i < totalPointsCount - 1; i++)
                                                {
                                                    if (lstAnalogCh02_InputForce1[i] <= 1)
                                                    {
                                                        PosInt = i;
                                                        break;
                                                    }
                                                }

                                                for (i = PosInt; i < totalPointsCount - 1; i++)
                                                {
                                                    if (lstAnalogCh02_InputForce1[i] >= 10)
                                                    {
                                                        PosFinal = i - 1;
                                                        break;
                                                    }
                                                }

                                                if (PosFinal < maxPos_Force)
                                                {
                                                    PosFinal = totalPointsCount - 1;
                                                }

                                                for (i = 0; i <= PosFinal - 1; i++)
                                                {
                                                    series1.Points.Add(new SeriesPoint(lstAnalogCh00_Timestamp[i], lstAnalogCh02_InputForce1[i]));
                                                }
                                                break;
                                            }
                                    }
                                    #endregion

                                    #region  Serie Pontos de Interesse

                                    switch (HelperApp.uiTesteSelecionado)
                                    {
                                        case 11:
                                            {
                                                var PosicaoForcaMaxima = Convert.ToInt32(_modelGVL.GVL_T11.diPosicaoForcaMaxima);
                                                //Obtem o ponto X na forca máxima
                                                var ForcaMaxima = lstAnalogCh02_InputForce1[PosicaoForcaMaxima];
                                                var TempoForcaMaxima = lstAnalogCh00_Timestamp[PosicaoForcaMaxima];


                                                double Forca1Avanco = 0;
                                                double TempoForca1Avanco = 0;
                                                double Forca2Avanco = 0;
                                                double TempoForca2Avanco = 0;
                                                double Forca1Retorno = 0;
                                                double TempoForca1Retorno = 0;
                                                double Forca2Retorno = 0;
                                                double TempoForca2Retorno = 0;

                                                //Obtem o Tempo/forca de avanco em 1000 N
                                                for (i = 0; i < lstAnalogCh02_InputForce1.Count; i++)
                                                {
                                                    if (lstAnalogCh02_InputForce1[i] >= 1000) //1000 é o ponto X desejado
                                                    {
                                                        Forca1Avanco = lstAnalogCh02_InputForce1[i];
                                                        TempoForca1Avanco = lstAnalogCh00_Timestamp[i];

                                                        break; //Encerra a busca
                                                    }
                                                }

                                                //Obtem o Tempo/forca de avanco em 1400 N
                                                for (i = 0; i < lstAnalogCh02_InputForce1.Count; i++)
                                                {
                                                    if (lstAnalogCh02_InputForce1[i] >= 1400) //1400 é o ponto X desejado
                                                    {
                                                        Forca2Avanco = lstAnalogCh02_InputForce1[i];
                                                        TempoForca2Avanco = lstAnalogCh00_Timestamp[i];

                                                        break; //Encerra a busca
                                                    }
                                                }

                                                //Obtem o Tempo/forca de avanco em 1000 N
                                                for (i = PosicaoForcaMaxima; i < lstAnalogCh02_InputForce1.Count; i++)
                                                {
                                                    if (lstAnalogCh02_InputForce1[i] <= 1400) //1400 é o ponto X desejado
                                                    {
                                                        Forca1Retorno = lstAnalogCh02_InputForce1[i];
                                                        TempoForca1Retorno = lstAnalogCh00_Timestamp[i];

                                                        break; //Encerra a busca
                                                    }
                                                }

                                                //Obtem o Tempo/forca de avanco em 1400 N
                                                for (i = PosicaoForcaMaxima; i < lstAnalogCh02_InputForce1.Count; i++)
                                                {
                                                    if (lstAnalogCh02_InputForce1[i] <= 1000) //1400 é o ponto X desejado
                                                    {
                                                        Forca2Retorno = lstAnalogCh02_InputForce1[i];
                                                        TempoForca2Retorno = lstAnalogCh00_Timestamp[i];

                                                        break; //Encerra a busca
                                                    }
                                                }

                                                PontosChart1.Points.Add(new SeriesPoint(TempoForcaMaxima, ForcaMaxima));
                                                PontosChart1.Points.Add(new SeriesPoint(TempoForca1Avanco, Forca1Avanco));
                                                PontosChart1.Points.Add(new SeriesPoint(TempoForca2Avanco, Forca2Avanco));
                                                PontosChart1.Points.Add(new SeriesPoint(TempoForca1Retorno, Forca1Retorno));
                                                PontosChart1.Points.Add(new SeriesPoint(TempoForca2Retorno, Forca2Retorno));
                                            }
                                            break;
                                        case 12:
                                            {
                                                //Encontra a forca maxima e plota o X 
                                                double rForcaMaxima = 0;
                                                double rTempoForcaMaxima = 0;
                                                int diPosicaoForcaMaxima = 0;

                                                for (i = 0; i < lstAnalogCh02_InputForce1.Count; i++)
                                                {
                                                    if (lstAnalogCh02_InputForce1[i] > rForcaMaxima)
                                                    {
                                                        rForcaMaxima = lstAnalogCh02_InputForce1[i]; //Atualiza o valor de forca maxima com o maior valor obtido no array                                                        
                                                        rTempoForcaMaxima = lstAnalogCh00_Timestamp[i];
                                                        diPosicaoForcaMaxima = i;
                                                    }
                                                }


                                                //Encontra o tempo e forca referentes ao parametro de forca inicial do calculo
                                                double rForcaInicialAvanco = 0;
                                                double rTempoInicialAvanco = 0;
                                                double rForcaFinalTempoAtuacao_N = 0;
                                                double rForcaFinalAvanco = 0;
                                                double rTempoFinalAvanco = 0;
                                                double rForcaInicialRetorno = 0;
                                                double rTempoInicialRetorno = 0;
                                                double rForcaFinalRetorno = 0;
                                                double rTempoFinalRetorno = 0;

                                                for (i = 0; i <= diPosicaoForcaMaxima; i++)
                                                {
                                                    if (lstAnalogCh02_InputForce1[i] >= _modelGVL.GVL_T12.rForcaInicialTempoAtuacao_N) //Forca >= Forca inicial digitada em N
                                                    {
                                                        rForcaInicialAvanco = lstAnalogCh02_InputForce1[i]; //Valor forca inicial para calculo 
                                                        rTempoInicialAvanco = lstAnalogCh00_Timestamp[i]; //Valor to tempo em ms inicial para calculo
                                                        break; //Encerra a busca pela forca inicial
                                                    }
                                                }

                                                //Calcula o valor de forca maxima desejado como referencia (Porcentagem digitada no campo * fmax obtida no teste)
                                                double rForcaFinal = (_modelGVL.GVL_T12.rForcaFinalTempoAtuacao / 100) * rForcaMaxima;

                                                //Encontra o tempo e forca referentes ao parametro de forca final do calculo de avanco, lembrando que eh percentual, por isso a multiplicacao anterior
                                                for (i = 0; i < lstAnalogCh02_InputForce1.Count; i++)
                                                {
                                                    if (lstAnalogCh02_InputForce1[i] >= rForcaFinal) //Forca >= Forca final calculada em N
                                                    {
                                                        rForcaFinalAvanco = lstAnalogCh02_InputForce1[i]; //Valor forca final para calculo 
                                                        rTempoFinalAvanco = lstAnalogCh00_Timestamp[i]; //Valor to tempo em ms final para calculo
                                                        break; //Encerra a busca pela forca inicial
                                                    }
                                                }

                                                //Calcula o tempo de retorno

                                                double rForcaMaximaRetorno = _modelGVL.GVL_T12.rForcaMaxima * 0.9;

                                                for (i = diPosicaoForcaMaxima; i < lstAnalogCh02_InputForce1.Count; i++)
                                                {
                                                    if (lstAnalogCh02_InputForce1[i] <= rForcaMaximaRetorno) //Forca <= Forca final calculada
                                                    {
                                                        rForcaInicialRetorno = lstAnalogCh02_InputForce1[i]; //Valor forca inicial para calculo 
                                                        rTempoInicialRetorno = lstAnalogCh00_Timestamp[i]; //Valor to tempo em ms inicial para calculo
                                                        break; //Encerra a busca pela forca inicial
                                                    }
                                                }

                                                //Calcula o valor de forca maxima desejado como referencia (Porcentagem digitada no campo * fmax obtida no teste)
                                                double rForcaRetorno = (_modelGVL.GVL_T12.rForcaRetornoTempoAtuacao / 100) * _modelGVL.GVL_T12.rForcaMaxima;

                                                //Encontra o tempo de retorno, partindo de fmax ate o ponto que a forca final foi atingida
                                                for (i = diPosicaoForcaMaxima; i < lstAnalogCh02_InputForce1.Count; i++)
                                                {
                                                    if (lstAnalogCh02_InputForce1[i] <= rForcaRetorno) //Forca <= Forca final calculada
                                                    {
                                                        rForcaFinalRetorno = lstAnalogCh02_InputForce1[i]; //Valor forca inicial para calculo 
                                                        rTempoFinalRetorno = lstAnalogCh00_Timestamp[i]; //Valor to tempo em ms inicial para calculo
                                                        break; //Encerra a busca pela forca inicial
                                                    }
                                                }

                                                PontosChart1.Points.Add(new SeriesPoint(rTempoForcaMaxima, rForcaMaxima));
                                                PontosChart1.Points.Add(new SeriesPoint(rTempoInicialAvanco, rForcaInicialAvanco));
                                                PontosChart1.Points.Add(new SeriesPoint(rTempoFinalAvanco, rForcaFinalAvanco));
                                                PontosChart1.Points.Add(new SeriesPoint(rTempoInicialRetorno, rForcaInicialRetorno));
                                                PontosChart1.Points.Add(new SeriesPoint(rTempoFinalRetorno, rForcaFinalRetorno));
                                            }
                                            break;
                                        default:
                                            break;
                                    }

                                    #endregion

                                    devChart.Series.AddRange(new Series[] { series1, PontosChart1 });
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
                        case 13:    //Check Sensors - Pressure Difference
                            {
                                try
                                {
                                    #region  Serie de Valores

                                    //GVL_Graficos.strNomeEixoX = "Input Force (N)";
                                    //GVL_Graficos.strNomeEixoY1 = "Pressure PC (bar)";
                                    //GVL_Graficos.strNomeEixoY2 = "Pressure SC (bar)";

                                    for (i = 0; i <= totalPointsCount - 1; i++)
                                    {
                                        series1.Points.Add(new SeriesPoint(lstAnalogCh02_InputForce1[i], lstAnalogCh07_PressurePC[i]));
                                        series2.Points.Add(new SeriesPoint(lstAnalogCh02_InputForce1[i], lstAnalogCh06_PressureSC[i]));
                                    }

                                    #endregion

                                    #region Pontos de Interesse

                                    double rForca_P1 = 0;
                                    double rPressao_P1 = 0;
                                    double rForca_P2 = 0;
                                    double rPressao_P2 = 0;
                                    double rForca_P3 = 0;
                                    double rPressao_P3 = 0;
                                    double rForca_P4 = 0;
                                    double rPressao_P4 = 0;

                                    var maxValue_Force = lstAnalogCh02_InputForce1.Max();
                                    var maxPos_Force = lstAnalogCh02_InputForce1.IndexOf(maxValue_Force);

                                    for (i = 0; i <= maxPos_Force; i++)
                                    {
                                        if (lstAnalogCh07_PressurePC[i] >= _modelGVL.GVL_T13.rSetPointDiferencaPressaoP1Avanco_Bar)
                                        {
                                            rForca_P1 = lstAnalogCh02_InputForce1[i];
                                            rPressao_P1 = lstAnalogCh07_PressurePC[i];
                                            break;
                                        }
                                    }

                                    for (i = 0; i <= maxPos_Force; i++)
                                    {
                                        if (lstAnalogCh07_PressurePC[i] >= _modelGVL.GVL_T13.rSetPointDiferencaPressaoP2Avanco_Bar)
                                        {
                                            rForca_P2 = lstAnalogCh02_InputForce1[i];
                                            rPressao_P2 = lstAnalogCh07_PressurePC[i];
                                            break;
                                        }
                                    }

                                    for (i = maxPos_Force; i <= totalPointsCount; i++)
                                    {
                                        if (lstAnalogCh07_PressurePC[i] <= _modelGVL.GVL_T13.rSetPointDiferencaPressaoP3Retorno_Bar)
                                        {
                                            rForca_P3 = lstAnalogCh02_InputForce1[i];
                                            rPressao_P3 = lstAnalogCh07_PressurePC[i];
                                            break;
                                        }
                                    }

                                    for (i = maxPos_Force; i <= totalPointsCount; i++)
                                    {
                                        if (lstAnalogCh07_PressurePC[i] <= _modelGVL.GVL_T13.rSetPointDiferencaPressaoP4Retorno_Bar)
                                        {
                                            rForca_P4 = lstAnalogCh02_InputForce1[i];
                                            rPressao_P4 = lstAnalogCh07_PressurePC[i];
                                            break;
                                        }
                                    }
                                    PontosChart1.Points.Add(new SeriesPoint(rForca_P1, rPressao_P1));
                                    PontosChart1.Points.Add(new SeriesPoint(rForca_P2, rPressao_P2));
                                    PontosChart1.Points.Add(new SeriesPoint(rForca_P3, rPressao_P3));
                                    PontosChart1.Points.Add(new SeriesPoint(rForca_P4, rPressao_P4));

                                    #endregion

                                    devChart.Series.AddRange(new Series[] { series1, PontosChart1, series2, PontosChart2 });
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

                                    double SomaDeslocamento = 0;
                                    double MediaDeslocamento = 0;
                                    double CursoMorto = 0;
                                    double DeslocamentoCursoMorto = 0;

                                    for (i = 0; i < lstAnalogCh04_TravelTMC.Count; i++)
                                    {
                                        if (lstAnalogCh04_TravelTMC[i] > _modelGVL.GVL_T14.rCursoMortoEmDeslocamentoSaida_mm)
                                        {
                                            SomaDeslocamento = 0;

                                            for (int j = 0; j < 20; j++)
                                            {
                                                SomaDeslocamento = SomaDeslocamento + lstAnalogCh04_TravelTMC[i + j];
                                            }

                                            MediaDeslocamento = SomaDeslocamento / 20;

                                            if (MediaDeslocamento > _modelGVL.GVL_T14.rCursoMortoEmDeslocamentoSaida_mm)
                                            {
                                                CursoMorto = lstAnalogCh05_TravelPiston[i]; //Atualiza o valor de forca maxima com o maior valor obtido no array
                                                DeslocamentoCursoMorto = lstAnalogCh04_TravelTMC[i];
                                                break;
                                            }
                                        }
                                    }

                                    PontosChart1.Points.Add(new SeriesPoint(CursoMorto, DeslocamentoCursoMorto));

                                    #endregion

                                    devChart.Series.AddRange(new Series[] { series1, PontosChart1 });
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

                                    #endregion

                                    devChart.Series.AddRange(new Series[] { series1, PontosChart1 });
                                }
                                catch (Exception ex)
                                {
                                    var err = i;

                                    MessageBox.Show(ex.Message, _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            break;
                        case 16:    //Adjustment - Hose Consumer
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
                                    var PosicaoForcaMaxima = Convert.ToInt32(_modelGVL.GVL_T11.diPosicaoForcaMaxima);
                                    //Obtem o ponto X na forca máxima
                                    var ForcaMaxima = lstAnalogCh02_InputForce1[PosicaoForcaMaxima];
                                    var TempoForcaMaxima = lstAnalogCh00_Timestamp[PosicaoForcaMaxima];


                                    double PressaoTestePC = 0;
                                    double DeslocamentoTestePC = 0;
                                    double PressaoTesteSC = 0;
                                    double DeslocamentoTesteSC = 0;

                                    for (i = 0; i < lstAnalogCh07_PressurePC.Count; i++)
                                    {
                                        if (lstAnalogCh07_PressurePC[i] >= _modelGVL.GVL_T16.rDeslocamentoNaPressao_Bar)
                                        {
                                            PressaoTestePC = lstAnalogCh07_PressurePC[i];
                                            DeslocamentoTestePC = lstAnalogCh05_TravelPiston[i];
                                            break; //Encerra a busca
                                        }
                                    }

                                    for (i = 0; i < lstAnalogCh06_PressureSC.Count; i++)
                                    {
                                        if (lstAnalogCh06_PressureSC[i] >= _modelGVL.GVL_T16.rDeslocamentoNaPressao_Bar)
                                        {
                                            PressaoTesteSC = lstAnalogCh06_PressureSC[i];
                                            DeslocamentoTesteSC = lstAnalogCh05_TravelPiston[i];
                                            break; //Encerra a busca
                                        }
                                    }

                                    PontosChart1.Points.Add(new SeriesPoint(DeslocamentoTestePC, PressaoTestePC));
                                    PontosChart1.Points.Add(new SeriesPoint(DeslocamentoTesteSC, PressaoTesteSC));

                                    #endregion

                                    devChart.Series.AddRange(new Series[] { series1, PontosChart1, series2, PontosChart2 });
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
                        case 17:    //Lost Travel ACU - Hydraulic
                        case 18:    //Lost Travel ACU - Hydraulic Electrical Actuation
                            {
                                try
                                {
                                    #region  Serie de Valores

                                    //GVL_Graficos.strNomeEixoX = "Piston Travel (mm)";
                                    //GVL_Graficos.strNomeEixoY1 = "Pressure PC (bar)";
                                    //ou
                                    //GVL_Graficos.strNomeEixoX = "Piston Travel (mm)";
                                    //GVL_Graficos.strNomeEixoY2 = "Pressure SC (bar)";


                                    var maxValue_Travel = lstAnalogCh05_TravelPiston.Max();
                                    var maxPos_Travel = lstAnalogCh05_TravelPiston.IndexOf(maxValue_Travel);

                                    switch (modelChartGVL.iOutput)
                                    {
                                        case 1:
                                            {
                                                for (i = 0; i <= maxPos_Travel - 1; i++)
                                                {
                                                    series1.Points.Add(new SeriesPoint(lstAnalogCh05_TravelPiston[i], lstAnalogCh07_PressurePC[i]));
                                                }
                                            }
                                            break;
                                        case 2:
                                            {
                                                for (i = 0; i <= maxPos_Travel - 1; i++)
                                                {
                                                    series1.Points.Add(new SeriesPoint(lstAnalogCh05_TravelPiston[i], lstAnalogCh06_PressureSC[i]));
                                                }
                                            }
                                            break;
                                        default:
                                            {
                                                for (i = 0; i <= maxPos_Travel - 1; i++)
                                                {
                                                    series1.Points.Add(new SeriesPoint(lstAnalogCh05_TravelPiston[i], lstAnalogCh07_PressurePC[i]));
                                                    series2.Points.Add(new SeriesPoint(lstAnalogCh05_TravelPiston[i], lstAnalogCh06_PressureSC[i]));
                                                }
                                            }
                                            break;
                                    }

                                    #endregion

                                    #region  Serie Pontos de Interesse

                                    switch (HelperApp.uiTesteSelecionado)
                                    {
                                        case 17:
                                            {
                                                double SomaPressao = 0;
                                                double MediaPressao = 0;
                                                double CursoMorto = 0;
                                                double PressaoCursoMorto = 0;

                                                switch (modelChartGVL.iOutput)
                                                {
                                                    case 1:
                                                        {
                                                            for (i = 0; i < lstAnalogCh07_PressurePC.Count; i++)
                                                            {
                                                                if (lstAnalogCh07_PressurePC[i] > _modelGVL.GVL_T17.rCursoMortoNaPressao_Bar)
                                                                {
                                                                    SomaPressao = 0;

                                                                    for (int j = 0; j < 20; j++)
                                                                    {
                                                                        SomaPressao = SomaPressao + lstAnalogCh07_PressurePC[i + j];
                                                                    }

                                                                    MediaPressao = SomaPressao / 20;

                                                                    if (MediaPressao > _modelGVL.GVL_T17.rCursoMortoNaPressao_Bar)
                                                                    {
                                                                        CursoMorto = lstAnalogCh05_TravelPiston[i]; //Atualiza o valor de forca maxima com o maior valor obtido no array
                                                                        PressaoCursoMorto = lstAnalogCh07_PressurePC[i];
                                                                        break;
                                                                    }
                                                                }
                                                            }
                                                        }
                                                        break;
                                                    case 2:
                                                        {
                                                            for (i = 0; i < lstAnalogCh06_PressureSC.Count; i++)
                                                            {
                                                                if (lstAnalogCh06_PressureSC[i] > _modelGVL.GVL_T17.rCursoMortoNaPressao_Bar)
                                                                {
                                                                    SomaPressao = 0;

                                                                    for (int j = 0; j < 20; j++)
                                                                    {
                                                                        SomaPressao = SomaPressao + lstAnalogCh06_PressureSC[i + j];
                                                                    }

                                                                    MediaPressao = SomaPressao / 20;

                                                                    if (MediaPressao > _modelGVL.GVL_T17.rCursoMortoNaPressao_Bar)
                                                                    {
                                                                        CursoMorto = lstAnalogCh05_TravelPiston[i]; //Atualiza o valor de forca maxima com o maior valor obtido no array
                                                                        PressaoCursoMorto = lstAnalogCh06_PressureSC[i];
                                                                        break;
                                                                    }
                                                                }
                                                            }
                                                        }
                                                        break;
                                                }

                                                PontosChart1.Points.Add(new SeriesPoint(CursoMorto, PressaoCursoMorto));


                                            }
                                            break;
                                        case 18:
                                            {
                                                double SomaPressao = 0;
                                                double MediaPressao = 0;
                                                double CursoMorto = 0;
                                                double PressaoCursoMorto = 0;

                                                switch (modelChartGVL.iOutput)
                                                {
                                                    case 1:
                                                        {
                                                            for (i = 0; i < lstAnalogCh07_PressurePC.Count; i++)
                                                            {
                                                                if (lstAnalogCh07_PressurePC[i] > _modelGVL.GVL_T18.rCursoMortoNaPressao_Bar)
                                                                {
                                                                    SomaPressao = 0;

                                                                    for (int j = 0; j < 20; j++)
                                                                    {
                                                                        SomaPressao = SomaPressao + lstAnalogCh07_PressurePC[i + j];
                                                                    }

                                                                    MediaPressao = SomaPressao / 20;

                                                                    if (MediaPressao > _modelGVL.GVL_T18.rCursoMortoNaPressao_Bar)
                                                                    {
                                                                        CursoMorto = lstAnalogCh05_TravelPiston[i]; //Atualiza o valor de forca maxima com o maior valor obtido no array
                                                                        PressaoCursoMorto = lstAnalogCh07_PressurePC[i];
                                                                        break;
                                                                    }
                                                                }
                                                            }
                                                        }
                                                        break;
                                                    case 2:
                                                        {
                                                            for (i = 0; i < lstAnalogCh06_PressureSC.Count; i++)
                                                            {
                                                                if (lstAnalogCh06_PressureSC[i] > _modelGVL.GVL_T18.rCursoMortoNaPressao_Bar)
                                                                {
                                                                    SomaPressao = 0;

                                                                    for (int j = 0; j < 20; j++)
                                                                    {
                                                                        SomaPressao = SomaPressao + lstAnalogCh06_PressureSC[i + j];
                                                                    }

                                                                    MediaPressao = SomaPressao / 20;

                                                                    if (MediaPressao > _modelGVL.GVL_T18.rCursoMortoNaPressao_Bar)
                                                                    {
                                                                        CursoMorto = lstAnalogCh05_TravelPiston[i]; //Atualiza o valor de forca maxima com o maior valor obtido no array
                                                                        PressaoCursoMorto = lstAnalogCh06_PressureSC[i];
                                                                        break;
                                                                    }
                                                                }
                                                            }
                                                        }
                                                        break;
                                                }

                                                PontosChart1.Points.Add(new SeriesPoint(CursoMorto, PressaoCursoMorto));
                                            }
                                            break;
                                        default:
                                            break;
                                    }

                                    #endregion

                                    devChart.Series.AddRange(new Series[] { series1, PontosChart1, series2, PontosChart2 });
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
                                    var maxValue_Travel = lstAnalogCh05_TravelPiston.Max();
                                    var maxPos_Travel = lstAnalogCh05_TravelPiston.IndexOf(maxValue_Travel);

                                    for (i = 0; i <= maxPos_Travel - 1; i++)
                                    {
                                        series1.Points.Add(new SeriesPoint(lstAnalogCh05_TravelPiston[i], lstAnalogCh08_PneumTestPressure[i]));
                                    }

                                    #endregion

                                    #region  Serie Pontos de Interesse

                                    switch (HelperApp.uiTesteSelecionado)
                                    {
                                        case 19:
                                            PontosChart1.Points.Add(new SeriesPoint(_modelGVL.GVL_T19.rDeslocamentoNaPressao_mm, _modelGVL.GVL_T19.rDeslocamentoNaPressao_Bar));
                                            break;
                                        case 20:
                                            PontosChart1.Points.Add(new SeriesPoint(_modelGVL.GVL_T20.rDeslocamentoNaPressao_mm, _modelGVL.GVL_T20.rDeslocamentoNaPressao_Bar));
                                            break;
                                        default:
                                            break;
                                    }
                                    #endregion

                                    devChart.Series.AddRange(new Series[] { series1, PontosChart1 });
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

                                    var maxValue_Travel = lstAnalogCh05_TravelPiston.Max();
                                    var maxPos_Travel = lstAnalogCh05_TravelPiston.IndexOf(maxValue_Travel);

                                    for (i = 0; i <= maxPos_Travel - 1; i++)
                                    {
                                        series1.Points.Add(new SeriesPoint(lstAnalogCh05_TravelPiston[i], lstAnalogCh07_PressurePC[i]));
                                        series2.Points.Add(new SeriesPoint(lstAnalogCh05_TravelPiston[i], lstAnalogCh02_InputForce1[i]));
                                    }

                                    #endregion

                                    #region  Serie Pontos de Interesse

                                    double rForca_P1 = 0;
                                    double rPressao_P1 = 0;
                                    double rDeslocamento_P1 = 0;

                                    for (i = 0; i <= totalPointsCount; i++)
                                    {
                                        if (lstAnalogCh07_PressurePC[i] >= _modelGVL.GVL_T21.rPressaoTeste_Bar)
                                        {
                                            rForca_P1 = lstAnalogCh02_InputForce1[i];
                                            rPressao_P1 = lstAnalogCh07_PressurePC[i];
                                            rDeslocamento_P1 = lstAnalogCh05_TravelPiston[i];
                                            break;
                                        }
                                    }

                                    PontosChart1.Points.Add(new SeriesPoint(rDeslocamento_P1, rPressao_P1));
                                    PontosChart2.Points.Add(new SeriesPoint(rDeslocamento_P1, rForca_P1));

                                    #endregion

                                    devChart.Series.AddRange(new Series[] { series1, PontosChart1, series2, PontosChart2 });

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

                                    var maxValue_Force = lstAnalogCh02_InputForce1.Max();
                                    var maxPos_Force = lstAnalogCh02_InputForce1.IndexOf(maxValue_Force);

                                    int iPosicaoTempoInicial = 0;
                                    double rTempoInicial = 0;

                                    //Encontra o ponto onde a força é 200N e encontra 1s atrás
                                    for (i = 0; i < maxPos_Force; i++)
                                    {
                                        if (lstAnalogCh02_InputForce1[i] > 200)
                                        {
                                            rTempoInicial = lstAnalogCh00_Timestamp[i];
                                            break;
                                        }
                                    }

                                    //Define um valor de tempo -1s ao iniciar a aplicação de força
                                    if (rTempoInicial >= 1)
                                        rTempoInicial = rTempoInicial - 1;
                                    else
                                        rTempoInicial = 0;

                                    //Encontra o ponto onde a força é 200N e encontra 1s atrás
                                    for (i = 0; i < maxPos_Force; i++)
                                    {
                                        if (lstAnalogCh00_Timestamp[i] >= rTempoInicial)
                                        {
                                            rTempoInicial = lstAnalogCh00_Timestamp[i];
                                            iPosicaoTempoInicial = i;
                                            break;
                                        }
                                    }


                                    for (i = iPosicaoTempoInicial; i <= totalPointsCount - 1; i++)
                                    {
                                        series1.Points.Add(new SeriesPoint(lstAnalogCh00_Timestamp[i] - rTempoInicial, lstAnalogCh02_InputForce1[i]));
                                        series2.Points.Add(new SeriesPoint(lstAnalogCh00_Timestamp[i] - rTempoInicial, lstAnalogCh07_PressurePC[i]));
                                        series3.Points.Add(new SeriesPoint(lstAnalogCh00_Timestamp[i] - rTempoInicial, lstAnalogCh05_TravelPiston[i]));
                                    }

                                    //for (i = 0; i <= totalPointsCount - 1; i++)
                                    //{
                                    //    series1.Points.Add(new SeriesPoint(lstAnalogCh00_Timestamp[i], lstAnalogCh02_InputForce1[i]));
                                    //    series2.Points.Add(new SeriesPoint(lstAnalogCh00_Timestamp[i], lstAnalogCh07_PressurePC[i]));
                                    //    series3.Points.Add(new SeriesPoint(lstAnalogCh00_Timestamp[i], lstAnalogCh05_TravelPiston[i]));
                                    //}

                                    #endregion

                                    #region  Serie Pontos de Interesse

                                    double SomaForca = 0;
                                    double MediaForca = 0;
                                    double rPontoPressaoP1 = 0;
                                    double rPontoTempoP1 = 0;
                                    double rPontoPressaoP2 = 0;
                                    double rPontoTempoP2 = 0;
                                    double rPontoPressaoP3 = 0;
                                    double rPontoTempoP3 = 0;
                                    double rPontoPressaoP4 = 0;
                                    double rPontoTempoP4 = 0;
                                    double rPontoDeslocamentoP5 = 0;
                                    double rPontoTempoP5 = 0;


                                    //Encontra o ponto inicial de atuacao
                                    for (i = 0; i < maxPos_Force; i++)
                                    {
                                        if (lstAnalogCh02_InputForce1[i] > _modelGVL.GVL_T22.rForcaTempoInicialAtuacao_N)
                                        {
                                            SomaForca = 0;

                                            for (int j = 0; j < 20; j++)
                                            {
                                                SomaForca = SomaForca + lstAnalogCh02_InputForce1[i + j];
                                            }

                                            MediaForca = SomaForca / 20;

                                            if (MediaForca > _modelGVL.GVL_T22.rForcaTempoInicialAtuacao_N)
                                            {
                                                rPontoPressaoP1 = lstAnalogCh07_PressurePC[i];
                                                rPontoTempoP1 = lstAnalogCh00_Timestamp[i] - rTempoInicial;
                                                break;
                                            }
                                        }
                                    }

                                    //Encontra o ponto inicial de retorno
                                    for (i = maxPos_Force; i < lstAnalogCh02_InputForce1.Count; i++)
                                    {

                                        if (lstAnalogCh02_InputForce1[i] <= _modelGVL.GVL_T22.rRunOutForceRef) //Forca <= RunoutForce
                                        {
                                            rPontoPressaoP3 = lstAnalogCh07_PressurePC[i];
                                            rPontoTempoP3 = lstAnalogCh00_Timestamp[i] - rTempoInicial;
                                            break; //Encerra a busca
                                        }
                                    }

                                    //Encontra o ponto de retorno ao deslocamento
                                    for (i = maxPos_Force; i < lstAnalogCh02_InputForce1.Count; i++)
                                    {
                                        if (lstAnalogCh05_TravelPiston[i] <= _modelGVL.GVL_T22.rPosicaoTempoRetornoNoDeslocamento_mm)
                                        {
                                            rPontoDeslocamentoP5 = lstAnalogCh05_TravelPiston[i];
                                            rPontoTempoP5 = lstAnalogCh00_Timestamp[i] - rTempoInicial;
                                            break; //Encerra a busca
                                        }
                                    }

                                    //Pontos dependentes do parametro
                                    switch (_modelGVL.GVL_T22.iTipoAtuacaoFinal)
                                    {
                                        case 1:
                                            {
                                                double rPressaoXMaxAvanco = ((_modelGVL.GVL_T22.rPorcentagemCalcTempoFinalAtuacao / 100) * _modelGVL.GVL_T22.rPressaoMaxima_Bar);

                                                for (i = 0; i < maxPos_Force; i++)
                                                {

                                                    if (lstAnalogCh07_PressurePC[i] >= rPressaoXMaxAvanco)
                                                    {
                                                        rPontoPressaoP2 = lstAnalogCh07_PressurePC[i];
                                                        rPontoTempoP2 = lstAnalogCh00_Timestamp[i] - rTempoInicial;
                                                        break;
                                                    }
                                                }

                                                double rPressaoXPmaxRetorno = ((_modelGVL.GVL_T22.rPorcentagemCalcTempoFinalRetorno / 100) * _modelGVL.GVL_T22.rPressaoMaxima_Bar);

                                                for (i = maxPos_Force; i < lstAnalogCh07_PressurePC.Count; i++)
                                                {
                                                    if (lstAnalogCh07_PressurePC[i] <= rPressaoXPmaxRetorno)
                                                    {
                                                        rPontoPressaoP4 = lstAnalogCh07_PressurePC[i];
                                                        rPontoTempoP4 = lstAnalogCh00_Timestamp[i] - rTempoInicial;
                                                        break;
                                                    }
                                                }

                                                break;
                                            }
                                        case 2:
                                            {
                                                double rPressaoXPoutAvanco = ((_modelGVL.GVL_T22.rPorcentagemCalcTempoFinalAtuacao / 100) * _modelGVL.GVL_T22.rRunOutPressureRef);

                                                for (i = 0; i < maxPos_Force; i++)
                                                {

                                                    if (lstAnalogCh07_PressurePC[i] >= rPressaoXPoutAvanco) // Pressao  >= Pressao Runout
                                                    {
                                                        rPontoPressaoP2 = lstAnalogCh07_PressurePC[i];
                                                        rPontoTempoP2 = lstAnalogCh00_Timestamp[i] - rTempoInicial;
                                                        break;
                                                    }
                                                }

                                                double rPressaoXPoutRetorno = ((_modelGVL.GVL_T22.rPorcentagemCalcTempoFinalRetorno / 100) * _modelGVL.GVL_T22.rRunOutPressureRef);

                                                for (i = maxPos_Force; i < lstAnalogCh07_PressurePC.Count; i++)
                                                {
                                                    if (lstAnalogCh07_PressurePC[i] <= rPressaoXPoutRetorno) // pressao <= Pressao Runout * %
                                                    {
                                                        rPontoPressaoP4 = lstAnalogCh07_PressurePC[i];
                                                        rPontoTempoP4 = lstAnalogCh00_Timestamp[i] - rTempoInicial;
                                                        break;
                                                    }
                                                }
                                                break;
                                            }
                                        case 3:
                                            {
                                                double rPressaoXPressaoAuxAvanco = ((_modelGVL.GVL_T22.rPorcentagemCalcTempoFinalAtuacao / 100) * _modelGVL.GVL_T22.rPressaoAuxiliarRef);

                                                for (i = 0; i < maxPos_Force; i++)
                                                {

                                                    if (lstAnalogCh07_PressurePC[i] >= rPressaoXPressaoAuxAvanco) // Forca >= Forca Runout
                                                    {
                                                        rPontoPressaoP2 = lstAnalogCh07_PressurePC[i];
                                                        rPontoTempoP2 = lstAnalogCh00_Timestamp[i] - rTempoInicial;
                                                        break;
                                                    }
                                                }

                                                double rPressaoXPressaoAuxRetorno = ((_modelGVL.GVL_T22.rPorcentagemCalcTempoFinalRetorno / 100) * _modelGVL.GVL_T22.rPressaoAuxiliarRef);

                                                for (i = maxPos_Force; i < lstAnalogCh07_PressurePC.Count; i++)
                                                {
                                                    if (lstAnalogCh07_PressurePC[i] <= rPressaoXPressaoAuxRetorno) //Pressao <= Pressao aux *%
                                                    {
                                                        rPontoPressaoP4 = lstAnalogCh07_PressurePC[i];
                                                        rPontoTempoP4 = lstAnalogCh00_Timestamp[i] - rTempoInicial;
                                                        break;
                                                    }
                                                }

                                                break;
                                            }
                                        default:
                                            break;
                                    }

                                    PontosChart2.Points.Add(new SeriesPoint(rPontoTempoP1, rPontoPressaoP1));
                                    PontosChart2.Points.Add(new SeriesPoint(rPontoTempoP2, rPontoPressaoP2));
                                    PontosChart2.Points.Add(new SeriesPoint(rPontoTempoP3, rPontoPressaoP3));
                                    PontosChart2.Points.Add(new SeriesPoint(rPontoTempoP4, rPontoPressaoP4));
                                    PontosChart3.Points.Add(new SeriesPoint(rPontoTempoP5, rPontoDeslocamentoP5));

                                    #endregion

                                    devChart.Series.AddRange(new Series[] { series1, PontosChart1, series2, PontosChart2, series3, PontosChart3 });
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


                                    int iPosicaoPressaoInicial = 0;
                                    double rTempoInicial = 0;

                                    //Encontra o onde a pressao hidraulica comeca a subir
                                    for (i = 0; i < lstAnalogCh09_HydrFillPressure.Count; i++)
                                    {
                                        if (lstAnalogCh09_HydrFillPressure[i] > 0.08)
                                        {
                                            rTempoInicial = lstAnalogCh00_Timestamp[i];
                                            break;
                                        }
                                    }

                                    //Define um valor de tempo -1s ao iniciar a aplicação de força
                                    if (rTempoInicial >= 1)
                                        rTempoInicial = rTempoInicial - 1;
                                    else
                                        rTempoInicial = 0;

                                    //Encontra o ponto onde a força é 200N e encontra 1s atrás
                                    for (i = 0; i < lstAnalogCh09_HydrFillPressure.Count; i++)
                                    {
                                        if (lstAnalogCh00_Timestamp[i] >= rTempoInicial)
                                        {
                                            rTempoInicial = lstAnalogCh00_Timestamp[i];
                                            iPosicaoPressaoInicial = i;
                                            break;
                                        }
                                    }

                                    for (i = 0; i <= totalPointsCount - 1; i++)
                                    {
                                        series1.Points.Add(new SeriesPoint(lstAnalogCh00_Timestamp[i] - rTempoInicial, lstAnalogCh09_HydrFillPressure[i]));
                                    }

                                    #endregion

                                    #region  Serie Pontos de Interesse
                                    //não existem pontos de interesse
                                    #endregion

                                    devChart.Series.AddRange(new Series[] { series1, PontosChart1 });
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

                                    //GVL_Graficos.strNomeEixoX = "Input Force (N)";
                                    //GVL_Graficos.strNomeEixoY1 = "Pressure PC (bar)";
                                    //GVL_Graficos.strNomeEixoY2 = "Pressure PC (bar)";

                                    int iPontoInicialSlow = 0;
                                    int iPontoFinalSlow = 0;

                                    int iPontoInicialFast = 0;
                                    int iPontoFinalFast = 0;

                                    int diUbound = lstAnalogCh00_Timestamp.Count;

                                    double rForcaMaxSlow = 0;
                                    int iPosForcaMaxSlow = 0;

                                    double rForcaMaxFast = 0;
                                    int iPosForcaMaxFast = 0;

                                    //Encontra o ponto inicial da curva de acionamento slow 
                                    for (i = 0; i <= diUbound; i++)
                                    {
                                        if (lstAnalogCh02_InputForce1[i] > 400) //Define o ponto de 400 N como ponto de partida da primera curva 
                                        {
                                            iPontoInicialSlow = i;
                                            break;
                                        }
                                    }

                                    //Encontra o ponto final da curva de acionamento slow
                                    for (i = iPontoInicialSlow; i <= diUbound; i++)
                                    {
                                        if (lstAnalogCh02_InputForce1[i] <= 0) //Define o ponto de 50 N como ponto final da primeira curva
                                        {
                                            iPontoFinalSlow = i;
                                            break;
                                        }
                                    }

                                    //Encontra o ponto inicial da curva de acionamento fast
                                    for (i = iPontoFinalSlow; i <= diUbound; i++)
                                    {
                                        if (lstAnalogCh02_InputForce1[i] > 50) //Define o ponto de 400 N como ponto de partida da primera curva 
                                        {
                                            iPontoInicialFast = i - 10000;
                                            break;
                                        }
                                    }

                                    //Encontra o ponto final da curva de acionamento fast

                                    iPontoFinalFast = diUbound - 1;

                                    for (i = 0; i <= iPontoFinalSlow; i++)
                                    {
                                        if (lstAnalogCh02_InputForce1[i] > rForcaMaxSlow)
                                        {
                                            rForcaMaxSlow = lstAnalogCh02_InputForce1[i]; //Atualiza o valor de forca maxima com o maior valor obtido no array
                                            iPosForcaMaxSlow = i; //Indica em qual posicao do array esta a forca maxima (pico do grafico, aonde comeca o retorno do atuador)
                                        }
                                    }

                                    for (i = iPontoInicialFast; i < iPontoFinalFast; i++)
                                    {
                                        if (lstAnalogCh02_InputForce1[i] > rForcaMaxFast)
                                        {
                                            rForcaMaxFast = lstAnalogCh02_InputForce1[i]; //Atualiza o valor de forca maxima com o maior valor obtido no array
                                            iPosForcaMaxFast = i; //Indica em qual posicao do array esta a forca maxima (pico do grafico, aonde comeca o retorno do atuador)
                                        }
                                    }

                                    switch (_modelGVL.GVL_T24.iTipoGrafico)
                                    {
                                        case 0:
                                            {


                                                for (i = 0; i <= iPosForcaMaxSlow; i++)
                                                {
                                                    series1.Points.Add(new SeriesPoint(lstAnalogCh02_InputForce1[i], lstAnalogCh07_PressurePC[i]));
                                                }

                                                for (i = iPontoInicialFast; i <= iPosForcaMaxFast - 1; i++)
                                                {
                                                    series2.Points.Add(new SeriesPoint(lstAnalogCh02_InputForce1[i], lstAnalogCh07_PressurePC[i]));
                                                }

                                                break;

                                            }
                                        case 1:
                                            {
                                                if ((iPontoFinalSlow + 10000) >= lstAnalogCh00_Timestamp.Count)
                                                    iPontoFinalSlow = lstAnalogCh00_Timestamp.Count;
                                                else
                                                    iPontoFinalSlow = iPontoFinalSlow + 10000;

                                                for (i = 0; i <= iPontoFinalSlow + 10000; i++)
                                                {
                                                    series1.Points.Add(new SeriesPoint(lstAnalogCh00_Timestamp[i], lstAnalogCh07_PressurePC[i]));
                                                }

                                                break;
                                            }
                                        case 2:
                                            {
                                                for (i = iPontoInicialFast; i < lstAnalogCh00_Timestamp.Count - 1; i++)
                                                {
                                                    series1.Points.Add(new SeriesPoint(lstAnalogCh00_Timestamp[i], lstAnalogCh07_PressurePC[i]));
                                                }

                                                break;
                                            }
                                    }


                                    #endregion

                                    #region  Serie Pontos de Interesse

                                    #endregion

                                    switch (_modelGVL.GVL_T24.iTipoGrafico)
                                    {
                                        case 0:
                                            {
                                                devChart.Series.AddRange(new Series[] { series1, PontosChart1, series2, PontosChart2 });
                                                break;
                                            }
                                        case 1:
                                        case 2:
                                            {
                                                devChart.Series.AddRange(new Series[] { series1, PontosChart1 });
                                                break;
                                            }

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
                        case 27:    //ADAM - Find Switching Point With TMC
                            {
                                try
                                {
                                    if (_modelGVL.GVL_T27.iTipoGrafico == 0)
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

                                        #endregion

                                        devChart.Series.AddRange(new Series[] { series1, PontosChart1 });
                                    }
                                    else
                                    {
                                        #region  Serie de Valores

                                        //GVL_Graficos.strNomeEixoX = "Time (s)";
                                        //GVL_Graficos.strNomeEixoY1 = "Input Force (N)";
                                        //GVL_Graficos.strNomeEixoY2 = "Pressure PC (bar)";
                                        //GVL_Graficos.strNomeEixoY3 = "Piston Travel (mm)";
                                        //GVL_Graficos.strNomeEixoY4 = "Velocity (mm/s)";
                                        //GVL_Graficos.strNomeEixoY5 = "Power (W);

                                        double rDeslocamentoInicial = 0;
                                        double rTempoInicial = 0;
                                        int iPosDeslocamentoInicial = 0;

                                        for (i = 0; i <= totalPointsCount - 1; i++)
                                        {
                                            if (lstAnalogCh05_TravelPiston[i] > 0.1)
                                            {
                                                rTempoInicial = lstAnalogCh00_Timestamp[i];
                                                rDeslocamentoInicial = lstAnalogCh05_TravelPiston[i];
                                                iPosDeslocamentoInicial = i;
                                                break;
                                            }
                                        }





                                        for (i = iPosDeslocamentoInicial; i <= totalPointsCount - 1; i++)
                                        {
                                            //Calcula a velocidade
                                            if (lstAnalogCh00_Timestamp[i] > 0)
                                                lstAnalogCh11_Velocity[i] = (lstAnalogCh05_TravelPiston[i] - rDeslocamentoInicial) / (lstAnalogCh00_Timestamp[i] - rTempoInicial);
                                            else
                                                lstAnalogCh11_Velocity[i] = 0;

                                            //Calcula a potencia
                                            lstAnalogCh12_Power[i] = ((lstAnalogCh11_Velocity[i] / 1000) * lstAnalogCh02_InputForce1[i]);

                                            series1.Points.Add(new SeriesPoint(lstAnalogCh00_Timestamp[i] - rTempoInicial, lstAnalogCh02_InputForce1[i]));
                                            series2.Points.Add(new SeriesPoint(lstAnalogCh00_Timestamp[i] - rTempoInicial, lstAnalogCh07_PressurePC[i]));
                                            series3.Points.Add(new SeriesPoint(lstAnalogCh00_Timestamp[i] - rTempoInicial, lstAnalogCh05_TravelPiston[i]));
                                            series4.Points.Add(new SeriesPoint(lstAnalogCh00_Timestamp[i] - rTempoInicial, lstAnalogCh11_Velocity[i]));
                                            series5.Points.Add(new SeriesPoint(lstAnalogCh00_Timestamp[i] - rTempoInicial, lstAnalogCh12_Power[i]));
                                        }

                                        #endregion

                                        #region  Serie Pontos de Interesse

                                        #endregion

                                        devChart.Series.AddRange(new Series[] { series1, PontosChart1, series2, PontosChart2, series3, PontosChart3, series4, PontosChart4, series5, PontosChart5 });
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
                                    if (_modelGVL.GVL_T28.iTipoGrafico == 0)
                                    {
                                        #region  Serie de Valores

                                        //GVL_Graficos.strNomeEixoX = "Input Force (N)";
                                        //GVL_Graficos.strNomeEixoY1 = "Pressure PC (bar)";

                                        for (i = 0; i <= totalPointsCount - 1; i++)
                                        {
                                            series1.Points.Add(new SeriesPoint(lstAnalogCh02_InputForce1[i], lstAnalogCh03_OutputForce[i]));
                                        }

                                        #endregion

                                        #region  Serie Pontos de Interesse

                                        #endregion

                                        devChart.Series.AddRange(new Series[] { series1, PontosChart1 });
                                    }
                                    else
                                    {
                                        #region  Serie de Valores

                                        //GVL_Graficos.strNomeEixoX = "Time (s)";
                                        //GVL_Graficos.strNomeEixoY1 = "Input Force (N)";
                                        //GVL_Graficos.strNomeEixoY2 = "Output Force (N)";
                                        //GVL_Graficos.strNomeEixoY3 = "Piston Travel (mm)";
                                        //GVL_Graficos.strNomeEixoY4 = "Velocity (mm/s)";
                                        //GVL_Graficos.strNomeEixoY5 = "Power (W);

                                        double rDeslocamentoInicial = 0;
                                        double rTempoInicial = 0;
                                        int iPosDeslocamentoInicial = 0;

                                        for (i = 0; i <= totalPointsCount - 1; i++)
                                        {
                                            if (lstAnalogCh05_TravelPiston[i] > 0.1)
                                            {
                                                rTempoInicial = lstAnalogCh00_Timestamp[i];
                                                rDeslocamentoInicial = lstAnalogCh05_TravelPiston[i];
                                                iPosDeslocamentoInicial = i;
                                                break;
                                            }
                                        }





                                        for (i = iPosDeslocamentoInicial; i <= totalPointsCount - 1; i++)
                                        {
                                            //Calcula a velocidade
                                            if (lstAnalogCh00_Timestamp[i] > 0)
                                                lstAnalogCh11_Velocity[i] = (lstAnalogCh05_TravelPiston[i] - rDeslocamentoInicial) / (lstAnalogCh00_Timestamp[i] - rTempoInicial);
                                            else
                                                lstAnalogCh11_Velocity[i] = 0;

                                            //Calcula a potencia
                                            lstAnalogCh12_Power[i] = ((lstAnalogCh11_Velocity[i] / 1000) * lstAnalogCh02_InputForce1[i]);

                                            series1.Points.Add(new SeriesPoint(lstAnalogCh00_Timestamp[i] - rTempoInicial, lstAnalogCh02_InputForce1[i]));
                                            series2.Points.Add(new SeriesPoint(lstAnalogCh00_Timestamp[i] - rTempoInicial, lstAnalogCh03_OutputForce[i]));
                                            series3.Points.Add(new SeriesPoint(lstAnalogCh00_Timestamp[i] - rTempoInicial, lstAnalogCh05_TravelPiston[i]));
                                            series4.Points.Add(new SeriesPoint(lstAnalogCh00_Timestamp[i] - rTempoInicial, lstAnalogCh11_Velocity[i]));
                                            series5.Points.Add(new SeriesPoint(lstAnalogCh00_Timestamp[i] - rTempoInicial, lstAnalogCh12_Power[i]));
                                        }

                                        #endregion

                                        #region  Serie Pontos de Interesse

                                        #endregion

                                        devChart.Series.AddRange(new Series[] { series1, PontosChart1, series2, PontosChart2, series3, PontosChart3, series4, PontosChart4, series5, PontosChart5 });
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
                if (string.IsNullOrEmpty(HelperTestBase.ProjectTestConcluded?.ProjectTestFileName))
                {
                    if (string.IsNullOrEmpty(HelperTestBase.ProjectTestConcluded?.ProjectTestFileName))
                    {
                        var strTestDateFormat = string.Empty;
                        var strTestHoureFormat = string.Empty;

                        HelperApp.uiProjectTestConcludedSelecionado = HelperApp.uiProjectTestConcludedSelecionado == 0 ? Convert.ToInt32(HelperTestBase.ProjectTestConcluded.IdProjectTestConcluded) : HelperApp.uiProjectTestConcludedSelecionado;

                        HelperTestBase.ProjectTestConcluded.ProjectTestSample.Project = HelperTestBase.ProjectTestConcluded.ProjectTestSample.Project == null ? new Model_Operational_Project() : HelperTestBase.ProjectTestConcluded.ProjectTestSample.Project;

                        HelperTestBase.ProjectTestConcluded.ProjectTestSample.Project = new BLL_Operational_Project().GetHelperProjectByIdPrjTestConcluded(HelperApp.uiProjectTestConcludedSelecionado.ToString());

                        string prjTestFilename = HelperTestBase.ProjectTestConcluded?.ProjectTestFileName?.Trim();

                        var arrTestDate = HelperTestBase.ProjectTestConcluded.ProjectTestSample.TestingDate.Substring(0, 10).Split('/');
                        var arrTestHour = HelperTestBase.ProjectTestConcluded.ProjectTestSample.TestingDate.Substring(11, 8).Split(':');

                        if (arrTestDate.Count() > 0 && arrTestHour.Count() > 0 && !string.IsNullOrEmpty(HelperTestBase.ProjectTestConcluded?.ProjectTestFileName?.Trim()))
                        {
                            var strFileName = HelperTestBase.ProjectTestConcluded?.ProjectTestFileName?.Trim();
                            var strTestDate = string.Concat(arrTestDate[2], arrTestDate[0], arrTestDate[1]);
                            var strTestHour = string.Concat(arrTestHour[0], arrTestHour[1], arrTestHour[2]);

                            strTestDateFormat = !strFileName.Substring(0, 8).Equals(strTestDate) ? strFileName.Substring(0, 8) : strTestDate;
                            strTestHoureFormat = !strFileName.Substring(9, 6).Equals(strTestHour) ? strFileName.Substring(9, 6) : strTestHour;
                        }
                        else
                        {
                            strTestDateFormat = arrTestDate.Count() == 0 ? HelperTestBase.ProjectTestConcluded?.ProjectTestSample?.Project?.PartNumber?.Trim().Substring(0, 8) : string.Concat(arrTestDate[2], arrTestDate[0], arrTestDate[1]);
                            strTestHoureFormat = arrTestHour.Count() == 0 ? HelperTestBase.ProjectTestConcluded?.ProjectTestSample?.Project?.PartNumber?.Trim().Substring(9, 6) : string.Concat(arrTestHour[0], arrTestHour[1], arrTestHour[2]);
                        }

                        string testTypeName = EnumExtensionMethods.GetEnumValue<eEXAMTYPE>(HelperApp.uiTesteSelecionado).ToString();

                        string testIdentName = !string.IsNullOrEmpty(HelperTestBase.ProjectTestConcluded?.ProjectTestSample?.Project?.Identification) ? HelperTestBase.ProjectTestConcluded?.ProjectTestSample?.Project?.Identification.Trim() : _helperApp.AppTests_DefaultNameData;

                        prjTestFilename = !string.IsNullOrEmpty(HelperTestBase.ProjectTestConcluded?.ProjectTestSample?.TestingDate) ? string.Concat(strTestDateFormat, "_", strTestHoureFormat, "#", HelperApp.uiTesteSelecionado, "#", testTypeName, "#", testIdentName, _helperApp.AppTests_DefaultExtension) : string.Empty;

                        HelperTestBase.ProjectTestConcluded.ProjectTestFileName = prjTestFilename;
                    }

                    string prjConcluded_FileName = string.Concat(HelperTestBase.ProjectTestConcluded.ProjectTestFileName.Trim(), _helperApp.AppTests_DefaultExtension);

                    string prjConcluded_PathWithFileName = Path.Combine(_initialDirPathTestFile, HelperTestBase.ProjectTestConcluded.ProjectTestFileName.Trim());

                    HelperTestBase.ProjectTestConcluded.ProjectTestFileName = prjConcluded_PathWithFileName;

                    _prjTestFileNameWithPath = prjConcluded_PathWithFileName;
                }

                string dirReportChartImagePath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, _helperApp.AppPath_ChartImageTests);

                string strTestFileNameImage = HelperTestBase.ProjectTestConcluded.ProjectTestFileName.Replace(_initialDirPathTestFile, "").Replace(_helperApp.AppTests_DefaultExtension, _helperApp.AppPath_ChartImageExtension);

                strTestFileNameImage = !strTestFileNameImage.Contains(_helperApp.AppPath_ChartImageExtension) ? string.Concat(strTestFileNameImage.Trim(), _helperApp.AppPath_ChartImageExtension) : strTestFileNameImage;

                string strTestFileNameImageSVG = strTestFileNameImage.Replace(_helperApp.AppPath_ChartImageExtension, @".svg");

                string dirReportChartImagehWithFileName = string.Concat(dirReportChartImagePath, strTestFileNameImage);

                string dirReportChartImagehWithFileNamesvg = string.Concat(dirReportChartImagePath, strTestFileNameImageSVG);

                if (_helperApp.CheckFileExists(dirReportChartImagehWithFileName))
                    File.Delete(dirReportChartImagehWithFileName);

                if (_helperApp.CheckFileExists(dirReportChartImagehWithFileNamesvg))
                    File.Delete(dirReportChartImagehWithFileNamesvg);

                devChart.ExportToImage(dirReportChartImagehWithFileName, ImageFormat.Jpeg);

                //Exporta a imagem em formato .svg
                devChart.ExportToSvg(dirReportChartImagehWithFileNamesvg);

                //Faz a leitura do arquivo
                string imgTest_Chartsvg = File.ReadAllText(dirReportChartImagehWithFileNamesvg);

                //Substitui o Line Stroke de 2 para 0.01 para melhor qualidade de imagem gerada pelo iText (eliminar spikes)
                imgTest_Chartsvg = imgTest_Chartsvg.Replace(@"stroke-width=""2""", @"stroke-width=""0.01""");

                //Substitui a fonta Tahoma por Helvetica (Fonte padrao do PDF)
                imgTest_Chartsvg = imgTest_Chartsvg.Replace(@"Tahoma", @"Helvetica");

                //Salva o arquivo novamente.
                File.WriteAllText(dirReportChartImagehWithFileNamesvg, imgTest_Chartsvg);

                imgTest_Chartsvg = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
                throw;
            }

            return true;
        }
        private bool CHART_Print()
        {
            try
            {
                if (!devChart.IsPrintingAvailable)
                {
                    MessageBox.Show("The 'DevExpress.XtraPrinting' is not found", "Error");
                    return false;
                }
                else
                {
                    if (HelperTestBase.ProjectTestConcluded.ProjectTestFileName != null)
                    {
                        PrintableComponentLink pcl = new PrintableComponentLink(new PrintingSystem());
                        devChart.OptionsPrint.SizeMode = DevExpress.XtraCharts.Printing.PrintSizeMode.Stretch;
                        devChart.OptionsPrint.ImageFormat = DevExpress.XtraCharts.Printing.PrintImageFormat.Metafile;


                        pcl.Component = devChart;
                        pcl.Landscape = true;
                        pcl.PaperKind = PaperKind.A4;

                        PdfExportOptions pdfOptions = new PdfExportOptions();
                        pdfOptions.ConvertImagesToJpeg = false;

                        pcl.Print();

                        //pcl.ShowPreviewDialog();
                    }
                    else
                    {
                        MessageBox.Show("Failed, currentProjectTest NOT NAME !", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
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
                    if (HelperApp.uiTesteSelecionado == 0)
                        TEST_Stop_Command();

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

                    HelperApp.bRunTestExecuted = true;

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

                HelperTestBase.iSumHoseConsumerPC = HelperMODBUS.CS_wSomaConsumidoresCP;
                HelperTestBase.iSumHoseConsumerSC = HelperMODBUS.CS_wSomaConsumidoresCS;

                mtxt_GeneralSettings_ETubeConsumerPCPressSide.Text = HelperTestBase.iSumHoseConsumerPC.ToString();

                mtxt_GeneralSettings_ETubeConsumerSCPressSide.Text = HelperTestBase.iSumHoseConsumerSC.ToString();

                #endregion

                #endregion
            }
            catch (Exception ex)
            {
                var err = ex.Message;
                _helperMODBUS.HelperMODBUS_AddMessageToDisplayLog(err);
            }
        }

        #endregion

        #region MODBS READ STEP TEST
        public void MODBUS_ContinousReadStepTest()
        {
            if (!_bContinousTestConfirmed)
            {
                double dValPressure = 0;

                switch (HelperMODBUS.CS_wPasso)
                {
                    case 1040:
                        {
                            _bContinousTestConfirmed = true;

                            dValPressure = 0.3;

                            if (DialogResult.Yes == MessageBox.Show($"\t{String.Concat(" TEST ", HelperApp.strNomeTesteSelecionado, " RUNNING ! ")}" + "\n\n\n" + String.Concat(" You confirme apply the Pressure ", dValPressure, "bar ? "), _helperApp.appMsg_Name, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))
                            {
                                if (HelperApp.uiTesteSelecionado == 19)
                                {
                                    _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_wConfirmaP1_T19 }, 1);
                                    _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_wCancelaP1_T19 }, 0);
                                }
                                else
                                {
                                    _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_wConfirmaP1_T20 }, 1);
                                    _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_wCancelaP1_T20 }, 0);
                                }

                                _bContinousTestConfirmed = false;
                            }
                            else
                            {
                                if (HelperApp.uiTesteSelecionado == 19)
                                {
                                    _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_wConfirmaP1_T19 }, 0);
                                    _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_wCancelaP1_T19 }, 1);
                                }
                                else
                                {
                                    _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_wConfirmaP1_T20 }, 0);
                                    _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_wCancelaP1_T20 }, 1);
                                }

                                _bContinousTestConfirmed = false;
                            }
                        }
                        break;
                    case 1050:
                        {
                            _bContinousTestConfirmed = true;

                            dValPressure = 0.2;

                            if (DialogResult.Yes == MessageBox.Show($"\t{String.Concat(" TEST ", HelperApp.strNomeTesteSelecionado, " RUNNING ! ")}" + "\n\n\n" + String.Concat(" You confirme apply the Pressure ", dValPressure, "bar ? "), _helperApp.appMsg_Name, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))
                            {
                                if (HelperApp.uiTesteSelecionado == 19)
                                {
                                    _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_wConfirmaP2_T19 }, 1);
                                    _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_wCancelaP2_T19 }, 0);
                                }
                                else
                                {
                                    _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_wConfirmaP2_T20 }, 1);
                                    _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_wCancelaP2_T20 }, 0);
                                }

                                _bContinousTestConfirmed = false;
                            }
                            else
                            {
                                if (HelperApp.uiTesteSelecionado == 19)
                                {
                                    _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_wConfirmaP2_T19 }, 0);
                                    _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_wCancelaP2_T19 }, 1);
                                }
                                else
                                {
                                    _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_wConfirmaP2_T20 }, 0);
                                    _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_wCancelaP2_T20 }, 1);
                                }

                                _bContinousTestConfirmed = false;
                            }
                        }
                        break;
                    default:
                        _bContinousTestConfirmed = false;
                        break;
                }
            }
        }

        #endregion

        #endregion

        #region HBM
        private HelperHBM HBM_Initialize()
        {
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
        private void HBM_SaveAquisitionTxtData()
        {
            try
            {
                _strTimeStamp = DateTime.Now.ToString("dd/MM/yyyy - HH:mm:ss.fff", CultureInfo.InvariantCulture);

                LOG_TestSequence("Evento - HBM_ReadValues");

                //String path = string.Concat(@"D:\", _helperApp.AppTests_DefaultNameData,".txt");
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

                if (_helperHBM.PreparedContinuousMeasurement && _helperHBM.Status)
                {
                    _myDevice = _comHBM._myDevice;
                    _daqMeasurement = _comHBM._daqMeasurement;
                    _signalsToMeasure = _comHBM._signalsToMeasure;
                    _daqEnvironment = _comHBM._daqEnvironment;

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
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, ex.ToString());
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

                                    if (iUpdatedValueCount > 0)
                                    {
                                        for (i = 1; i < iUpdatedValueCount - 1; i++)
                                        {
                                            lstCh[k].Add(Math.Round(lstVal[i], 3));
                                            lstTmsCh.Add(Math.Round(lstTms[i], 5));
                                            //lstStrTimestamp.Add(formTimestamp);					   
                                            //lstTmsCh.Add(Math.Round(lstTms[i],4));
                                        }
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

                        if (iUpdatedValueCount > 0)
                        {
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

                                    if (sbexterno.Length > sbMaxCap || timerHBM.Enabled == false)
                                        if (HelperApp.uiTesteSelecionado > 0)
                                            TXTFileHBM_Create();
                                        else
                                            HBM_ClearBufferAquisitionData();
                                }
                                catch (Exception ex)
                                {
                                    var err = string.Concat("ex : ", idx, ex.Message);

                                    throw;
                                }
                            }
                            catch (Exception ex)
                            {
                                var err = string.Concat("numero : ", idx, ex.Message);

                                throw;
                            }
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, _helperApp.appMsg_Error);

                throw;
            }
        }
        private void HBM_StopContinuousMeasurement(string info)
        {
            try
            {
                timerHBM.Enabled = false;
                HelperTestBase.running = false;

                try
                {
                    // stop running data acquisition
                    _runMeasurement = false;
                    _daqMeasurement.StopDaq();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, ex.ToString());

                }
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

            ListViewItem LVI = new ListViewItem(_strTimeStamp);
            LVI.SubItems.Add(msg.Trim());
            LVI.SubItems.Add(HelperApp.UserApp.UName);
            lvLog.Items.Add(LVI);
        }
        public void LOG_Clear()
        {
            lvLog.Clear();
            lst_MemoEventLog.Items.Clear();

            if (HelperTestBase.ProjectTestConcluded.ProjectTestSample?.Project != null)
                HelperTestBase.ProjectTestConcluded.ProjectTestSample.Project.is_Created = false;
        }

        #endregion

        
    }
}
