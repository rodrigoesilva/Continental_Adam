
namespace Continental.Project.Adam.UI
{
    partial class Form_Adam_Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Adam_Main));
            this.mTile_LCurrentSelectedTest = new MetroFramework.Controls.MetroTile();
            this.lbl_RoomTemperature = new System.Windows.Forms.Label();
            this.lbl_Humidity = new System.Windows.Forms.Label();
            this.lbl_PneumTestPressure = new System.Windows.Forms.Label();
            this.lbl_HydrFillPressure = new System.Windows.Forms.Label();
            this.lbl_PressureSC = new System.Windows.Forms.Label();
            this.lbl_PressurePC = new System.Windows.Forms.Label();
            this.lbl_TravelTMC = new System.Windows.Forms.Label();
            this.lbl_TravelPiston = new System.Windows.Forms.Label();
            this.lbl_DiffTravel = new System.Windows.Forms.Label();
            this.lbl_OutputForce = new System.Windows.Forms.Label();
            this.lbl_InputForce1 = new System.Windows.Forms.Label();
            this.mtxt_MKSLRoomTemp = new MetroFramework.Controls.MetroTextBox();
            this.mtxt_MKSLHumidity = new MetroFramework.Controls.MetroTextBox();
            this.mtxt_MKSLPneumTestPressure = new MetroFramework.Controls.MetroTextBox();
            this.mtxt_MKSLHydrFillPressure = new MetroFramework.Controls.MetroTextBox();
            this.mtxt_MKSLPressureSC = new MetroFramework.Controls.MetroTextBox();
            this.mtxt_MKSLPressurePC = new MetroFramework.Controls.MetroTextBox();
            this.mtxt_MKSLTravelTMC = new MetroFramework.Controls.MetroTextBox();
            this.mtxt_MKSLTravelPiston = new MetroFramework.Controls.MetroTextBox();
            this.mtxt_MKSLDiffTravel = new MetroFramework.Controls.MetroTextBox();
            this.mtxt_MKSLOutputForce = new MetroFramework.Controls.MetroTextBox();
            this.mtxt_MKSLInputForce1 = new MetroFramework.Controls.MetroTextBox();
            this.lst_MemoEventLog = new System.Windows.Forms.ListBox();
            this.mbtn_BGlobalWarning = new MetroFramework.Controls.MetroButton();
            this.mbtn_BReportPDF = new MetroFramework.Controls.MetroButton();
            this.mtbn_BExportTestToXLS = new MetroFramework.Controls.MetroButton();
            this.mbtn_BRecordStart = new MetroFramework.Controls.MetroButton();
            this.mbtn_BStart = new MetroFramework.Controls.MetroButton();
            this.mbtn_BStop = new MetroFramework.Controls.MetroButton();
            this.mpnl_HeaderInfoAnalogInput = new MetroFramework.Controls.MetroPanel();
            this.lbl_Vaccum = new System.Windows.Forms.Label();
            this.mtxt_MKSLVacuum = new MetroFramework.Controls.MetroTextBox();
            this.mpnl_Buttons = new MetroFramework.Controls.MetroPanel();
            this.mbtn_BClock = new MetroFramework.Controls.MetroButton();
            this.mbtn_BAlarm = new MetroFramework.Controls.MetroButton();
            this.mpnl_Eventlog = new MetroFramework.Controls.MetroPanel();
            this.mlbl_EoutPressure = new MetroFramework.Controls.MetroTextBox();
            this.mlbl_EoutForce = new MetroFramework.Controls.MetroTextBox();
            this.mlbl_EoutRef = new MetroFramework.Controls.MetroTextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.mbtn_BHandshakePC = new MetroFramework.Controls.MetroButton();
            this.mbtn_BGlobalAlert = new MetroFramework.Controls.MetroButton();
            this.mbtn_BEMotorRef = new MetroFramework.Controls.MetroButton();
            this.mbtn_BRecordStop = new MetroFramework.Controls.MetroButton();
            this.mbtn_BRun = new MetroFramework.Controls.MetroButton();
            this.mbtn_BRecording = new MetroFramework.Controls.MetroButton();
            this.metroPanel5 = new MetroFramework.Controls.MetroPanel();
            this.lvLog = new System.Windows.Forms.ListView();
            this.mTile_Diagram_TestSequence = new MetroFramework.Controls.MetroTile();
            this.mbtn_BHandshakePLC = new MetroFramework.Controls.MetroButton();
            this.mbtn_BAlert = new MetroFramework.Controls.MetroButton();
            this.mTile_Diagram_TestInfo = new MetroFramework.Controls.MetroTile();
            this.timerHBM = new System.Windows.Forms.Timer(this.components);
            this.timerMODBUS = new System.Windows.Forms.Timer(this.components);
            this.Tab_ActuationParameters = new System.Windows.Forms.TabPage();
            this.mPnl_tabActParam_GenralSettings = new MetroFramework.Controls.MetroPanel();
            this.mchk_tabActParam_GenSettings_CBLock = new MetroFramework.Controls.MetroCheckBox();
            this.mTile_tabActParam_GeneralSettings = new MetroFramework.Controls.MetroTile();
            this.mcbo_tabActParam_GenSettings_CoBActuationMode = new MetroFramework.Controls.MetroComboBox();
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.mTile_tabActionParam_Consumer = new MetroFramework.Controls.MetroTile();
            this.mlbl_GeneralSettings_LTubeConsSC = new MetroFramework.Controls.MetroTextBox();
            this.mlbl_GeneralSettings_LTubeConsPC = new MetroFramework.Controls.MetroTextBox();
            this.mtxt_GeneralSettings_ETubeConsumerSCPressSide = new MetroFramework.Controls.MetroTextBox();
            this.mtxt_GeneralSettings_ETubeConsumerPCPressSide = new MetroFramework.Controls.MetroTextBox();
            this.mbtn_GeneralSettings_BSelectTubeCons = new MetroFramework.Controls.MetroButton();
            this.grpRadConsumer = new System.Windows.Forms.GroupBox();
            this.rad_GeneralSettings_CBHoseConsumer = new System.Windows.Forms.RadioButton();
            this.rad_GeneralSettings_CBOriginalConsumer = new System.Windows.Forms.RadioButton();
            this.mlbl_tabActParam_GenSettings_ActuationMode = new MetroFramework.Controls.MetroTextBox();
            this.mpnl_CurrentProject = new MetroFramework.Controls.MetroPanel();
            this.mlbl_GeneralSettings_LParGenVacuumMax = new MetroFramework.Controls.MetroTextBox();
            this.mlbl_GeneralSettings_LParGenVacuumMin = new MetroFramework.Controls.MetroTextBox();
            this.mlbl_GeneralSettings_LParGenVacuum = new MetroFramework.Controls.MetroTextBox();
            this.mbtn_GeneralSettings_Plus_EParGenVacuum_Accel_R = new MetroFramework.Controls.MetroButton();
            this.mbtn_GeneralSettings_Minus_EParGenVacuum_Accel_L = new MetroFramework.Controls.MetroButton();
            this.mtxt_GeneralSettings_EParGenVacuumMax = new MetroFramework.Controls.MetroTextBox();
            this.mtxt_GeneralSettings_EParGenVacuumMin = new MetroFramework.Controls.MetroTextBox();
            this.mtxt_GeneralSettings_Unit_EParGenVacuumMax = new MetroFramework.Controls.MetroTextBox();
            this.mtxt_GeneralSettings_Unit_EParGenVacuumMin = new MetroFramework.Controls.MetroTextBox();
            this.mtxt_GeneralSettings_Unit_EParGenVacuum = new MetroFramework.Controls.MetroTextBox();
            this.mtxt_GeneralSettings_EParGenVacuum = new MetroFramework.Controls.MetroTextBox();
            this.mTile_tabActionParam_Vacuum = new MetroFramework.Controls.MetroTile();
            this.mcbo_tabActParam_GenSettings_CoBSelectTest = new MetroFramework.Controls.MetroComboBox();
            this.mbtn_tabActParam_GenSettings_BSaveCurrentParams = new MetroFramework.Controls.MetroButton();
            this.mchk_tabActParam_GenSettings_CBStartFromSelection = new MetroFramework.Controls.MetroCheckBox();
            this.mbtn_tabActParam_GenSettings_BLoadAdjSettings = new MetroFramework.Controls.MetroButton();
            this.mchk_tabActParam_GenSettings_CBSWaitBetweenTests = new MetroFramework.Controls.MetroCheckBox();
            this.mbtn_tabActParam_GenSettings_BLoadLastestParams = new MetroFramework.Controls.MetroButton();
            this.grpOutput = new System.Windows.Forms.GroupBox();
            this.rad_EvaluationParameters_CBOutputSC = new System.Windows.Forms.RadioButton();
            this.rad_EvaluationParameters_CBOutputPC = new System.Windows.Forms.RadioButton();
            this.mPnl_tabActParam_EvaluationParameters = new MetroFramework.Controls.MetroPanel();
            this.grid_tabActionParam_EvalParam = new System.Windows.Forms.DataGridView();
            this.mTile_tabActParam_EvaluationParameters = new MetroFramework.Controls.MetroTile();
            this.mPnl_tabActParam_Actuation = new MetroFramework.Controls.MetroPanel();
            this.mbtn_Actuation_Plus_E1ParForceGrad_Accel_R = new MetroFramework.Controls.MetroButton();
            this.mbtn_Actuation_Minus_E1ParForceGrad_Accel_L = new MetroFramework.Controls.MetroButton();
            this.mbtn_Actuation_Plus_E1ParMaxForce_Accel_R = new MetroFramework.Controls.MetroButton();
            this.mTile_tabActParam_Actuation = new MetroFramework.Controls.MetroTile();
            this.mtxt_Actuation_E1ParForceGrad = new MetroFramework.Controls.MetroTextBox();
            this.mlbl_Actuation_L1MaxForce = new MetroFramework.Controls.MetroTextBox();
            this.mtxt_Actuation_Unit_E1ParForceGrad = new MetroFramework.Controls.MetroTextBox();
            this.mlbl_Actuation_L1ForceGradient = new MetroFramework.Controls.MetroTextBox();
            this.mbtn_Actuation_Minus_E1ParMaxForce_Accel_L = new MetroFramework.Controls.MetroButton();
            this.mtxt_Actuation_Unit_E1ParMaxForce = new MetroFramework.Controls.MetroTextBox();
            this.mtxt_Actuation_E1ParMaxForce = new MetroFramework.Controls.MetroTextBox();
            this.tab_TableResults = new System.Windows.Forms.TabPage();
            this.mpnl_Table_GivingOut = new MetroFramework.Controls.MetroPanel();
            this.mTile_tabTable_GivingOut = new MetroFramework.Controls.MetroTile();
            this.mpnl_Table_Results = new MetroFramework.Controls.MetroPanel();
            this.TAB_TableResult_Grid = new System.Windows.Forms.DataGridView();
            this.mTile_tabTable_Results = new MetroFramework.Controls.MetroTile();
            this.tab_Diagram = new System.Windows.Forms.TabPage();
            this.devChart = new DevExpress.XtraCharts.ChartControl();
            this.mTile_tabDiagram_GraphicalDisplay = new MetroFramework.Controls.MetroTile();
            this.TAB_Main = new System.Windows.Forms.TabControl();
            this.bgWorker = new System.ComponentModel.BackgroundWorker();
            this.timerDateTime = new System.Windows.Forms.Timer(this.components);
            this.stsBar_STBMain = new System.Windows.Forms.StatusStrip();
            this.tStatusLabel01 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tStatusLabel02 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tStatusLabel03 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tStatusLabel04 = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.menuItemToolStrip_Home = new System.Windows.Forms.ToolStripMenuItem();
            this.subMenu_Home_Logout = new System.Windows.Forms.ToolStripMenuItem();
            this.subMenu_Home_Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.subMenu_Home_About = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemToolStrip_Project = new System.Windows.Forms.ToolStripMenuItem();
            this.subMenu_Project_Project = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.subMenu_Project_PrintGraphics = new System.Windows.Forms.ToolStripMenuItem();
            this.subMenu_Project_PrintParamList = new System.Windows.Forms.ToolStripMenuItem();
            this.subMenu_Project_SetupPrinter = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.subMenu_Project_ExportExcel = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemToolStrip_TestProgram = new System.Windows.Forms.ToolStripMenuItem();
            this.subMenu_TestProg_SelectTestProgram = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.subMenu_TestProg_Start = new System.Windows.Forms.ToolStripMenuItem();
            this.subMenu_TestProg_STop = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.subMenu_TestProg_CreateUserDefinedTest = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.subMenu_TestProg_ManualActuation = new System.Windows.Forms.ToolStripMenuItem();
            this.subMenu_TestProg_Calibration = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.subMenu_TestProg_Bleed = new System.Windows.Forms.ToolStripMenuItem();
            this.subMenu_TestProg_SaveTest = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemToolStrip_Settings = new System.Windows.Forms.ToolStripMenuItem();
            this.subMenu_Settings_SoftwareMaintenance = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.subMenu_Settings_Account = new System.Windows.Forms.ToolStripMenuItem();
            this.subMenu_Account_SelectAccessLevel = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.subMenu_Account_NewPassword = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this.subMenu_Account_UserAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.subMenu_Account_UserEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.subMenu_Account_UserDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.subMenu_Account_UserReport = new System.Windows.Forms.ToolStripMenuItem();
            this.printDialog = new System.Windows.Forms.PrintDialog();
            this.mpnl_HeaderInfoAnalogInputVisu = new MetroFramework.Controls.MetroPanel();
            this.mpnl_HeaderInfoAnalogInput.SuspendLayout();
            this.mpnl_Buttons.SuspendLayout();
            this.mpnl_Eventlog.SuspendLayout();
            this.metroPanel5.SuspendLayout();
            this.Tab_ActuationParameters.SuspendLayout();
            this.mPnl_tabActParam_GenralSettings.SuspendLayout();
            this.metroPanel1.SuspendLayout();
            this.grpRadConsumer.SuspendLayout();
            this.mpnl_CurrentProject.SuspendLayout();
            this.grpOutput.SuspendLayout();
            this.mPnl_tabActParam_EvaluationParameters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_tabActionParam_EvalParam)).BeginInit();
            this.mPnl_tabActParam_Actuation.SuspendLayout();
            this.tab_TableResults.SuspendLayout();
            this.mpnl_Table_GivingOut.SuspendLayout();
            this.mpnl_Table_Results.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TAB_TableResult_Grid)).BeginInit();
            this.tab_Diagram.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.devChart)).BeginInit();
            this.TAB_Main.SuspendLayout();
            this.stsBar_STBMain.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // mTile_LCurrentSelectedTest
            // 
            this.mTile_LCurrentSelectedTest.ActiveControl = null;
            this.mTile_LCurrentSelectedTest.Location = new System.Drawing.Point(399, 3);
            this.mTile_LCurrentSelectedTest.Name = "mTile_LCurrentSelectedTest";
            this.mTile_LCurrentSelectedTest.Size = new System.Drawing.Size(1265, 40);
            this.mTile_LCurrentSelectedTest.Style = MetroFramework.MetroColorStyle.Orange;
            this.mTile_LCurrentSelectedTest.TabIndex = 21;
            this.mTile_LCurrentSelectedTest.Text = "LCurrentSelectedTest";
            this.mTile_LCurrentSelectedTest.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.mTile_LCurrentSelectedTest.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.mTile_LCurrentSelectedTest.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.mTile_LCurrentSelectedTest.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            this.mTile_LCurrentSelectedTest.UseSelectable = true;
            this.mTile_LCurrentSelectedTest.UseWaitCursor = true;
            this.mTile_LCurrentSelectedTest.Click += new System.EventHandler(this.mTile_LCurrentSelectedTest_Click);
            // 
            // lbl_RoomTemperature
            // 
            this.lbl_RoomTemperature.AutoSize = true;
            this.lbl_RoomTemperature.BackColor = System.Drawing.Color.Transparent;
            this.lbl_RoomTemperature.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lbl_RoomTemperature.ForeColor = System.Drawing.Color.Silver;
            this.lbl_RoomTemperature.Location = new System.Drawing.Point(1579, 10);
            this.lbl_RoomTemperature.Name = "lbl_RoomTemperature";
            this.lbl_RoomTemperature.Size = new System.Drawing.Size(169, 20);
            this.lbl_RoomTemperature.TabIndex = 81;
            this.lbl_RoomTemperature.Text = "Room Temperature";
            // 
            // lbl_Humidity
            // 
            this.lbl_Humidity.AutoSize = true;
            this.lbl_Humidity.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Humidity.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lbl_Humidity.ForeColor = System.Drawing.Color.Silver;
            this.lbl_Humidity.Location = new System.Drawing.Point(1775, 10);
            this.lbl_Humidity.Name = "lbl_Humidity";
            this.lbl_Humidity.Size = new System.Drawing.Size(83, 20);
            this.lbl_Humidity.TabIndex = 82;
            this.lbl_Humidity.Text = "Humidity";
            // 
            // lbl_PneumTestPressure
            // 
            this.lbl_PneumTestPressure.AutoSize = true;
            this.lbl_PneumTestPressure.BackColor = System.Drawing.Color.Transparent;
            this.lbl_PneumTestPressure.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lbl_PneumTestPressure.ForeColor = System.Drawing.Color.Silver;
            this.lbl_PneumTestPressure.Location = new System.Drawing.Point(1404, 10);
            this.lbl_PneumTestPressure.Name = "lbl_PneumTestPressure";
            this.lbl_PneumTestPressure.Size = new System.Drawing.Size(196, 20);
            this.lbl_PneumTestPressure.TabIndex = 79;
            this.lbl_PneumTestPressure.Text = "Pneum. Test Pressure";
            // 
            // lbl_HydrFillPressure
            // 
            this.lbl_HydrFillPressure.AutoSize = true;
            this.lbl_HydrFillPressure.BackColor = System.Drawing.Color.Transparent;
            this.lbl_HydrFillPressure.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lbl_HydrFillPressure.ForeColor = System.Drawing.Color.Silver;
            this.lbl_HydrFillPressure.Location = new System.Drawing.Point(1113, 10);
            this.lbl_HydrFillPressure.Name = "lbl_HydrFillPressure";
            this.lbl_HydrFillPressure.Size = new System.Drawing.Size(168, 20);
            this.lbl_HydrFillPressure.TabIndex = 80;
            this.lbl_HydrFillPressure.Text = "Hydr. Fill Pressure";
            // 
            // lbl_PressureSC
            // 
            this.lbl_PressureSC.AutoSize = true;
            this.lbl_PressureSC.BackColor = System.Drawing.Color.Transparent;
            this.lbl_PressureSC.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lbl_PressureSC.ForeColor = System.Drawing.Color.Silver;
            this.lbl_PressureSC.Location = new System.Drawing.Point(981, 10);
            this.lbl_PressureSC.Name = "lbl_PressureSC";
            this.lbl_PressureSC.Size = new System.Drawing.Size(116, 20);
            this.lbl_PressureSC.TabIndex = 77;
            this.lbl_PressureSC.Text = "Pressure SC";
            // 
            // lbl_PressurePC
            // 
            this.lbl_PressurePC.AutoSize = true;
            this.lbl_PressurePC.BackColor = System.Drawing.Color.Transparent;
            this.lbl_PressurePC.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lbl_PressurePC.ForeColor = System.Drawing.Color.Silver;
            this.lbl_PressurePC.Location = new System.Drawing.Point(824, 10);
            this.lbl_PressurePC.Name = "lbl_PressurePC";
            this.lbl_PressurePC.Size = new System.Drawing.Size(116, 20);
            this.lbl_PressurePC.TabIndex = 78;
            this.lbl_PressurePC.Text = "Pressure PC";
            // 
            // lbl_TravelTMC
            // 
            this.lbl_TravelTMC.AutoSize = true;
            this.lbl_TravelTMC.BackColor = System.Drawing.Color.Transparent;
            this.lbl_TravelTMC.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lbl_TravelTMC.ForeColor = System.Drawing.Color.Silver;
            this.lbl_TravelTMC.Location = new System.Drawing.Point(661, 10);
            this.lbl_TravelTMC.Name = "lbl_TravelTMC";
            this.lbl_TravelTMC.Size = new System.Drawing.Size(106, 20);
            this.lbl_TravelTMC.TabIndex = 75;
            this.lbl_TravelTMC.Text = "Travel TMC";
            // 
            // lbl_TravelPiston
            // 
            this.lbl_TravelPiston.AutoSize = true;
            this.lbl_TravelPiston.BackColor = System.Drawing.Color.Transparent;
            this.lbl_TravelPiston.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lbl_TravelPiston.ForeColor = System.Drawing.Color.Silver;
            this.lbl_TravelPiston.Location = new System.Drawing.Point(500, 10);
            this.lbl_TravelPiston.Name = "lbl_TravelPiston";
            this.lbl_TravelPiston.Size = new System.Drawing.Size(120, 20);
            this.lbl_TravelPiston.TabIndex = 76;
            this.lbl_TravelPiston.Text = "Travel Piston";
            // 
            // lbl_DiffTravel
            // 
            this.lbl_DiffTravel.AutoSize = true;
            this.lbl_DiffTravel.BackColor = System.Drawing.Color.Transparent;
            this.lbl_DiffTravel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lbl_DiffTravel.ForeColor = System.Drawing.Color.Silver;
            this.lbl_DiffTravel.Location = new System.Drawing.Point(351, 10);
            this.lbl_DiffTravel.Name = "lbl_DiffTravel";
            this.lbl_DiffTravel.Size = new System.Drawing.Size(103, 20);
            this.lbl_DiffTravel.TabIndex = 73;
            this.lbl_DiffTravel.Text = "Diff. Travel";
            // 
            // lbl_OutputForce
            // 
            this.lbl_OutputForce.AutoSize = true;
            this.lbl_OutputForce.BackColor = System.Drawing.Color.Transparent;
            this.lbl_OutputForce.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lbl_OutputForce.ForeColor = System.Drawing.Color.Silver;
            this.lbl_OutputForce.Location = new System.Drawing.Point(182, 10);
            this.lbl_OutputForce.Name = "lbl_OutputForce";
            this.lbl_OutputForce.Size = new System.Drawing.Size(119, 20);
            this.lbl_OutputForce.TabIndex = 74;
            this.lbl_OutputForce.Text = "Output Force";
            // 
            // lbl_InputForce1
            // 
            this.lbl_InputForce1.AutoSize = true;
            this.lbl_InputForce1.BackColor = System.Drawing.Color.Transparent;
            this.lbl_InputForce1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lbl_InputForce1.ForeColor = System.Drawing.Color.Silver;
            this.lbl_InputForce1.Location = new System.Drawing.Point(26, 10);
            this.lbl_InputForce1.Name = "lbl_InputForce1";
            this.lbl_InputForce1.Size = new System.Drawing.Size(120, 20);
            this.lbl_InputForce1.TabIndex = 72;
            this.lbl_InputForce1.Text = "Input Force 1";
            // 
            // mtxt_MKSLRoomTemp
            // 
            // 
            // 
            // 
            this.mtxt_MKSLRoomTemp.CustomButton.Image = null;
            this.mtxt_MKSLRoomTemp.CustomButton.Location = new System.Drawing.Point(101, 2);
            this.mtxt_MKSLRoomTemp.CustomButton.Name = "";
            this.mtxt_MKSLRoomTemp.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.mtxt_MKSLRoomTemp.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.mtxt_MKSLRoomTemp.CustomButton.TabIndex = 1;
            this.mtxt_MKSLRoomTemp.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.mtxt_MKSLRoomTemp.CustomButton.UseSelectable = true;
            this.mtxt_MKSLRoomTemp.CustomButton.Visible = false;
            this.mtxt_MKSLRoomTemp.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.mtxt_MKSLRoomTemp.Lines = new string[] {
        "0.00 ºC"};
            this.mtxt_MKSLRoomTemp.Location = new System.Drawing.Point(1593, 37);
            this.mtxt_MKSLRoomTemp.MaxLength = 32767;
            this.mtxt_MKSLRoomTemp.Name = "mtxt_MKSLRoomTemp";
            this.mtxt_MKSLRoomTemp.PasswordChar = '\0';
            this.mtxt_MKSLRoomTemp.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.mtxt_MKSLRoomTemp.SelectedText = "";
            this.mtxt_MKSLRoomTemp.SelectionLength = 0;
            this.mtxt_MKSLRoomTemp.SelectionStart = 0;
            this.mtxt_MKSLRoomTemp.ShortcutsEnabled = true;
            this.mtxt_MKSLRoomTemp.Size = new System.Drawing.Size(129, 30);
            this.mtxt_MKSLRoomTemp.Style = MetroFramework.MetroColorStyle.Orange;
            this.mtxt_MKSLRoomTemp.TabIndex = 55;
            this.mtxt_MKSLRoomTemp.Text = "0.00 ºC";
            this.mtxt_MKSLRoomTemp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mtxt_MKSLRoomTemp.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.mtxt_MKSLRoomTemp.UseSelectable = true;
            this.mtxt_MKSLRoomTemp.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.mtxt_MKSLRoomTemp.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // mtxt_MKSLHumidity
            // 
            // 
            // 
            // 
            this.mtxt_MKSLHumidity.CustomButton.Image = null;
            this.mtxt_MKSLHumidity.CustomButton.Location = new System.Drawing.Point(101, 2);
            this.mtxt_MKSLHumidity.CustomButton.Name = "";
            this.mtxt_MKSLHumidity.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.mtxt_MKSLHumidity.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.mtxt_MKSLHumidity.CustomButton.TabIndex = 1;
            this.mtxt_MKSLHumidity.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.mtxt_MKSLHumidity.CustomButton.UseSelectable = true;
            this.mtxt_MKSLHumidity.CustomButton.Visible = false;
            this.mtxt_MKSLHumidity.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.mtxt_MKSLHumidity.Lines = new string[] {
        "0.00 %"};
            this.mtxt_MKSLHumidity.Location = new System.Drawing.Point(1751, 37);
            this.mtxt_MKSLHumidity.MaxLength = 32767;
            this.mtxt_MKSLHumidity.Name = "mtxt_MKSLHumidity";
            this.mtxt_MKSLHumidity.PasswordChar = '\0';
            this.mtxt_MKSLHumidity.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.mtxt_MKSLHumidity.SelectedText = "";
            this.mtxt_MKSLHumidity.SelectionLength = 0;
            this.mtxt_MKSLHumidity.SelectionStart = 0;
            this.mtxt_MKSLHumidity.ShortcutsEnabled = true;
            this.mtxt_MKSLHumidity.Size = new System.Drawing.Size(129, 30);
            this.mtxt_MKSLHumidity.Style = MetroFramework.MetroColorStyle.Orange;
            this.mtxt_MKSLHumidity.TabIndex = 53;
            this.mtxt_MKSLHumidity.Text = "0.00 %";
            this.mtxt_MKSLHumidity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mtxt_MKSLHumidity.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.mtxt_MKSLHumidity.UseSelectable = true;
            this.mtxt_MKSLHumidity.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.mtxt_MKSLHumidity.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // mtxt_MKSLPneumTestPressure
            // 
            // 
            // 
            // 
            this.mtxt_MKSLPneumTestPressure.CustomButton.Image = null;
            this.mtxt_MKSLPneumTestPressure.CustomButton.Location = new System.Drawing.Point(101, 2);
            this.mtxt_MKSLPneumTestPressure.CustomButton.Name = "";
            this.mtxt_MKSLPneumTestPressure.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.mtxt_MKSLPneumTestPressure.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.mtxt_MKSLPneumTestPressure.CustomButton.TabIndex = 1;
            this.mtxt_MKSLPneumTestPressure.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.mtxt_MKSLPneumTestPressure.CustomButton.UseSelectable = true;
            this.mtxt_MKSLPneumTestPressure.CustomButton.Visible = false;
            this.mtxt_MKSLPneumTestPressure.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.mtxt_MKSLPneumTestPressure.Lines = new string[] {
        "0.00 bar"};
            this.mtxt_MKSLPneumTestPressure.Location = new System.Drawing.Point(1435, 37);
            this.mtxt_MKSLPneumTestPressure.MaxLength = 32767;
            this.mtxt_MKSLPneumTestPressure.Name = "mtxt_MKSLPneumTestPressure";
            this.mtxt_MKSLPneumTestPressure.PasswordChar = '\0';
            this.mtxt_MKSLPneumTestPressure.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.mtxt_MKSLPneumTestPressure.SelectedText = "";
            this.mtxt_MKSLPneumTestPressure.SelectionLength = 0;
            this.mtxt_MKSLPneumTestPressure.SelectionStart = 0;
            this.mtxt_MKSLPneumTestPressure.ShortcutsEnabled = true;
            this.mtxt_MKSLPneumTestPressure.Size = new System.Drawing.Size(129, 30);
            this.mtxt_MKSLPneumTestPressure.Style = MetroFramework.MetroColorStyle.Orange;
            this.mtxt_MKSLPneumTestPressure.TabIndex = 51;
            this.mtxt_MKSLPneumTestPressure.Text = "0.00 bar";
            this.mtxt_MKSLPneumTestPressure.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mtxt_MKSLPneumTestPressure.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.mtxt_MKSLPneumTestPressure.UseSelectable = true;
            this.mtxt_MKSLPneumTestPressure.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.mtxt_MKSLPneumTestPressure.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // mtxt_MKSLHydrFillPressure
            // 
            // 
            // 
            // 
            this.mtxt_MKSLHydrFillPressure.CustomButton.Image = null;
            this.mtxt_MKSLHydrFillPressure.CustomButton.Location = new System.Drawing.Point(101, 2);
            this.mtxt_MKSLHydrFillPressure.CustomButton.Name = "";
            this.mtxt_MKSLHydrFillPressure.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.mtxt_MKSLHydrFillPressure.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.mtxt_MKSLHydrFillPressure.CustomButton.TabIndex = 1;
            this.mtxt_MKSLHydrFillPressure.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.mtxt_MKSLHydrFillPressure.CustomButton.UseSelectable = true;
            this.mtxt_MKSLHydrFillPressure.CustomButton.Visible = false;
            this.mtxt_MKSLHydrFillPressure.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.mtxt_MKSLHydrFillPressure.Lines = new string[] {
        "0.00 bar"};
            this.mtxt_MKSLHydrFillPressure.Location = new System.Drawing.Point(1119, 37);
            this.mtxt_MKSLHydrFillPressure.MaxLength = 32767;
            this.mtxt_MKSLHydrFillPressure.Name = "mtxt_MKSLHydrFillPressure";
            this.mtxt_MKSLHydrFillPressure.PasswordChar = '\0';
            this.mtxt_MKSLHydrFillPressure.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.mtxt_MKSLHydrFillPressure.SelectedText = "";
            this.mtxt_MKSLHydrFillPressure.SelectionLength = 0;
            this.mtxt_MKSLHydrFillPressure.SelectionStart = 0;
            this.mtxt_MKSLHydrFillPressure.ShortcutsEnabled = true;
            this.mtxt_MKSLHydrFillPressure.Size = new System.Drawing.Size(129, 30);
            this.mtxt_MKSLHydrFillPressure.Style = MetroFramework.MetroColorStyle.Orange;
            this.mtxt_MKSLHydrFillPressure.TabIndex = 49;
            this.mtxt_MKSLHydrFillPressure.Text = "0.00 bar";
            this.mtxt_MKSLHydrFillPressure.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mtxt_MKSLHydrFillPressure.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.mtxt_MKSLHydrFillPressure.UseSelectable = true;
            this.mtxt_MKSLHydrFillPressure.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.mtxt_MKSLHydrFillPressure.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // mtxt_MKSLPressureSC
            // 
            // 
            // 
            // 
            this.mtxt_MKSLPressureSC.CustomButton.Image = null;
            this.mtxt_MKSLPressureSC.CustomButton.Location = new System.Drawing.Point(101, 2);
            this.mtxt_MKSLPressureSC.CustomButton.Name = "";
            this.mtxt_MKSLPressureSC.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.mtxt_MKSLPressureSC.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.mtxt_MKSLPressureSC.CustomButton.TabIndex = 1;
            this.mtxt_MKSLPressureSC.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.mtxt_MKSLPressureSC.CustomButton.UseSelectable = true;
            this.mtxt_MKSLPressureSC.CustomButton.Visible = false;
            this.mtxt_MKSLPressureSC.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.mtxt_MKSLPressureSC.Lines = new string[] {
        "0.00 bar"};
            this.mtxt_MKSLPressureSC.Location = new System.Drawing.Point(961, 37);
            this.mtxt_MKSLPressureSC.MaxLength = 32767;
            this.mtxt_MKSLPressureSC.Name = "mtxt_MKSLPressureSC";
            this.mtxt_MKSLPressureSC.PasswordChar = '\0';
            this.mtxt_MKSLPressureSC.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.mtxt_MKSLPressureSC.SelectedText = "";
            this.mtxt_MKSLPressureSC.SelectionLength = 0;
            this.mtxt_MKSLPressureSC.SelectionStart = 0;
            this.mtxt_MKSLPressureSC.ShortcutsEnabled = true;
            this.mtxt_MKSLPressureSC.Size = new System.Drawing.Size(129, 30);
            this.mtxt_MKSLPressureSC.Style = MetroFramework.MetroColorStyle.Orange;
            this.mtxt_MKSLPressureSC.TabIndex = 47;
            this.mtxt_MKSLPressureSC.Text = "0.00 bar";
            this.mtxt_MKSLPressureSC.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mtxt_MKSLPressureSC.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.mtxt_MKSLPressureSC.UseSelectable = true;
            this.mtxt_MKSLPressureSC.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.mtxt_MKSLPressureSC.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // mtxt_MKSLPressurePC
            // 
            // 
            // 
            // 
            this.mtxt_MKSLPressurePC.CustomButton.Image = null;
            this.mtxt_MKSLPressurePC.CustomButton.Location = new System.Drawing.Point(101, 2);
            this.mtxt_MKSLPressurePC.CustomButton.Name = "";
            this.mtxt_MKSLPressurePC.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.mtxt_MKSLPressurePC.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.mtxt_MKSLPressurePC.CustomButton.TabIndex = 1;
            this.mtxt_MKSLPressurePC.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.mtxt_MKSLPressurePC.CustomButton.UseSelectable = true;
            this.mtxt_MKSLPressurePC.CustomButton.Visible = false;
            this.mtxt_MKSLPressurePC.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.mtxt_MKSLPressurePC.Lines = new string[] {
        "0.00 bar"};
            this.mtxt_MKSLPressurePC.Location = new System.Drawing.Point(803, 37);
            this.mtxt_MKSLPressurePC.MaxLength = 32767;
            this.mtxt_MKSLPressurePC.Name = "mtxt_MKSLPressurePC";
            this.mtxt_MKSLPressurePC.PasswordChar = '\0';
            this.mtxt_MKSLPressurePC.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.mtxt_MKSLPressurePC.SelectedText = "";
            this.mtxt_MKSLPressurePC.SelectionLength = 0;
            this.mtxt_MKSLPressurePC.SelectionStart = 0;
            this.mtxt_MKSLPressurePC.ShortcutsEnabled = true;
            this.mtxt_MKSLPressurePC.Size = new System.Drawing.Size(129, 30);
            this.mtxt_MKSLPressurePC.Style = MetroFramework.MetroColorStyle.Orange;
            this.mtxt_MKSLPressurePC.TabIndex = 45;
            this.mtxt_MKSLPressurePC.Text = "0.00 bar";
            this.mtxt_MKSLPressurePC.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mtxt_MKSLPressurePC.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.mtxt_MKSLPressurePC.UseSelectable = true;
            this.mtxt_MKSLPressurePC.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.mtxt_MKSLPressurePC.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // mtxt_MKSLTravelTMC
            // 
            // 
            // 
            // 
            this.mtxt_MKSLTravelTMC.CustomButton.Image = null;
            this.mtxt_MKSLTravelTMC.CustomButton.Location = new System.Drawing.Point(101, 2);
            this.mtxt_MKSLTravelTMC.CustomButton.Name = "";
            this.mtxt_MKSLTravelTMC.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.mtxt_MKSLTravelTMC.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.mtxt_MKSLTravelTMC.CustomButton.TabIndex = 1;
            this.mtxt_MKSLTravelTMC.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.mtxt_MKSLTravelTMC.CustomButton.UseSelectable = true;
            this.mtxt_MKSLTravelTMC.CustomButton.Visible = false;
            this.mtxt_MKSLTravelTMC.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.mtxt_MKSLTravelTMC.Lines = new string[] {
        "0.00 mm"};
            this.mtxt_MKSLTravelTMC.Location = new System.Drawing.Point(645, 37);
            this.mtxt_MKSLTravelTMC.MaxLength = 32767;
            this.mtxt_MKSLTravelTMC.Name = "mtxt_MKSLTravelTMC";
            this.mtxt_MKSLTravelTMC.PasswordChar = '\0';
            this.mtxt_MKSLTravelTMC.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.mtxt_MKSLTravelTMC.SelectedText = "";
            this.mtxt_MKSLTravelTMC.SelectionLength = 0;
            this.mtxt_MKSLTravelTMC.SelectionStart = 0;
            this.mtxt_MKSLTravelTMC.ShortcutsEnabled = true;
            this.mtxt_MKSLTravelTMC.Size = new System.Drawing.Size(129, 30);
            this.mtxt_MKSLTravelTMC.Style = MetroFramework.MetroColorStyle.Orange;
            this.mtxt_MKSLTravelTMC.TabIndex = 43;
            this.mtxt_MKSLTravelTMC.Text = "0.00 mm";
            this.mtxt_MKSLTravelTMC.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mtxt_MKSLTravelTMC.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.mtxt_MKSLTravelTMC.UseSelectable = true;
            this.mtxt_MKSLTravelTMC.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.mtxt_MKSLTravelTMC.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // mtxt_MKSLTravelPiston
            // 
            // 
            // 
            // 
            this.mtxt_MKSLTravelPiston.CustomButton.Image = null;
            this.mtxt_MKSLTravelPiston.CustomButton.Location = new System.Drawing.Point(101, 2);
            this.mtxt_MKSLTravelPiston.CustomButton.Name = "";
            this.mtxt_MKSLTravelPiston.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.mtxt_MKSLTravelPiston.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.mtxt_MKSLTravelPiston.CustomButton.TabIndex = 1;
            this.mtxt_MKSLTravelPiston.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.mtxt_MKSLTravelPiston.CustomButton.UseSelectable = true;
            this.mtxt_MKSLTravelPiston.CustomButton.Visible = false;
            this.mtxt_MKSLTravelPiston.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.mtxt_MKSLTravelPiston.Lines = new string[] {
        "0.00 mm"};
            this.mtxt_MKSLTravelPiston.Location = new System.Drawing.Point(487, 37);
            this.mtxt_MKSLTravelPiston.MaxLength = 32767;
            this.mtxt_MKSLTravelPiston.Name = "mtxt_MKSLTravelPiston";
            this.mtxt_MKSLTravelPiston.PasswordChar = '\0';
            this.mtxt_MKSLTravelPiston.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.mtxt_MKSLTravelPiston.SelectedText = "";
            this.mtxt_MKSLTravelPiston.SelectionLength = 0;
            this.mtxt_MKSLTravelPiston.SelectionStart = 0;
            this.mtxt_MKSLTravelPiston.ShortcutsEnabled = true;
            this.mtxt_MKSLTravelPiston.Size = new System.Drawing.Size(129, 30);
            this.mtxt_MKSLTravelPiston.Style = MetroFramework.MetroColorStyle.Orange;
            this.mtxt_MKSLTravelPiston.TabIndex = 41;
            this.mtxt_MKSLTravelPiston.Text = "0.00 mm";
            this.mtxt_MKSLTravelPiston.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mtxt_MKSLTravelPiston.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.mtxt_MKSLTravelPiston.UseSelectable = true;
            this.mtxt_MKSLTravelPiston.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.mtxt_MKSLTravelPiston.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // mtxt_MKSLDiffTravel
            // 
            // 
            // 
            // 
            this.mtxt_MKSLDiffTravel.CustomButton.Image = null;
            this.mtxt_MKSLDiffTravel.CustomButton.Location = new System.Drawing.Point(101, 2);
            this.mtxt_MKSLDiffTravel.CustomButton.Name = "";
            this.mtxt_MKSLDiffTravel.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.mtxt_MKSLDiffTravel.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.mtxt_MKSLDiffTravel.CustomButton.TabIndex = 1;
            this.mtxt_MKSLDiffTravel.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.mtxt_MKSLDiffTravel.CustomButton.UseSelectable = true;
            this.mtxt_MKSLDiffTravel.CustomButton.Visible = false;
            this.mtxt_MKSLDiffTravel.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.mtxt_MKSLDiffTravel.Lines = new string[] {
        "0.00 mm"};
            this.mtxt_MKSLDiffTravel.Location = new System.Drawing.Point(329, 37);
            this.mtxt_MKSLDiffTravel.MaxLength = 32767;
            this.mtxt_MKSLDiffTravel.Name = "mtxt_MKSLDiffTravel";
            this.mtxt_MKSLDiffTravel.PasswordChar = '\0';
            this.mtxt_MKSLDiffTravel.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.mtxt_MKSLDiffTravel.SelectedText = "";
            this.mtxt_MKSLDiffTravel.SelectionLength = 0;
            this.mtxt_MKSLDiffTravel.SelectionStart = 0;
            this.mtxt_MKSLDiffTravel.ShortcutsEnabled = true;
            this.mtxt_MKSLDiffTravel.Size = new System.Drawing.Size(129, 30);
            this.mtxt_MKSLDiffTravel.Style = MetroFramework.MetroColorStyle.Orange;
            this.mtxt_MKSLDiffTravel.TabIndex = 39;
            this.mtxt_MKSLDiffTravel.Text = "0.00 mm";
            this.mtxt_MKSLDiffTravel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mtxt_MKSLDiffTravel.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.mtxt_MKSLDiffTravel.UseSelectable = true;
            this.mtxt_MKSLDiffTravel.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.mtxt_MKSLDiffTravel.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // mtxt_MKSLOutputForce
            // 
            // 
            // 
            // 
            this.mtxt_MKSLOutputForce.CustomButton.Image = null;
            this.mtxt_MKSLOutputForce.CustomButton.Location = new System.Drawing.Point(101, 2);
            this.mtxt_MKSLOutputForce.CustomButton.Name = "";
            this.mtxt_MKSLOutputForce.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.mtxt_MKSLOutputForce.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.mtxt_MKSLOutputForce.CustomButton.TabIndex = 1;
            this.mtxt_MKSLOutputForce.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.mtxt_MKSLOutputForce.CustomButton.UseSelectable = true;
            this.mtxt_MKSLOutputForce.CustomButton.Visible = false;
            this.mtxt_MKSLOutputForce.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.mtxt_MKSLOutputForce.Lines = new string[] {
        "0.00 N"};
            this.mtxt_MKSLOutputForce.Location = new System.Drawing.Point(171, 37);
            this.mtxt_MKSLOutputForce.MaxLength = 32767;
            this.mtxt_MKSLOutputForce.Name = "mtxt_MKSLOutputForce";
            this.mtxt_MKSLOutputForce.PasswordChar = '\0';
            this.mtxt_MKSLOutputForce.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.mtxt_MKSLOutputForce.SelectedText = "";
            this.mtxt_MKSLOutputForce.SelectionLength = 0;
            this.mtxt_MKSLOutputForce.SelectionStart = 0;
            this.mtxt_MKSLOutputForce.ShortcutsEnabled = true;
            this.mtxt_MKSLOutputForce.Size = new System.Drawing.Size(129, 30);
            this.mtxt_MKSLOutputForce.Style = MetroFramework.MetroColorStyle.Orange;
            this.mtxt_MKSLOutputForce.TabIndex = 37;
            this.mtxt_MKSLOutputForce.Text = "0.00 N";
            this.mtxt_MKSLOutputForce.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mtxt_MKSLOutputForce.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.mtxt_MKSLOutputForce.UseSelectable = true;
            this.mtxt_MKSLOutputForce.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.mtxt_MKSLOutputForce.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // mtxt_MKSLInputForce1
            // 
            // 
            // 
            // 
            this.mtxt_MKSLInputForce1.CustomButton.Image = null;
            this.mtxt_MKSLInputForce1.CustomButton.Location = new System.Drawing.Point(101, 2);
            this.mtxt_MKSLInputForce1.CustomButton.Name = "";
            this.mtxt_MKSLInputForce1.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.mtxt_MKSLInputForce1.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.mtxt_MKSLInputForce1.CustomButton.TabIndex = 1;
            this.mtxt_MKSLInputForce1.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.mtxt_MKSLInputForce1.CustomButton.UseSelectable = true;
            this.mtxt_MKSLInputForce1.CustomButton.Visible = false;
            this.mtxt_MKSLInputForce1.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.mtxt_MKSLInputForce1.Lines = new string[] {
        "0.00 N"};
            this.mtxt_MKSLInputForce1.Location = new System.Drawing.Point(13, 37);
            this.mtxt_MKSLInputForce1.MaxLength = 32767;
            this.mtxt_MKSLInputForce1.Name = "mtxt_MKSLInputForce1";
            this.mtxt_MKSLInputForce1.PasswordChar = '\0';
            this.mtxt_MKSLInputForce1.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.mtxt_MKSLInputForce1.SelectedText = "";
            this.mtxt_MKSLInputForce1.SelectionLength = 0;
            this.mtxt_MKSLInputForce1.SelectionStart = 0;
            this.mtxt_MKSLInputForce1.ShortcutsEnabled = true;
            this.mtxt_MKSLInputForce1.Size = new System.Drawing.Size(129, 30);
            this.mtxt_MKSLInputForce1.Style = MetroFramework.MetroColorStyle.Orange;
            this.mtxt_MKSLInputForce1.TabIndex = 33;
            this.mtxt_MKSLInputForce1.Text = "0.00 N";
            this.mtxt_MKSLInputForce1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mtxt_MKSLInputForce1.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.mtxt_MKSLInputForce1.UseSelectable = true;
            this.mtxt_MKSLInputForce1.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.mtxt_MKSLInputForce1.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // lst_MemoEventLog
            // 
            this.lst_MemoEventLog.FormattingEnabled = true;
            this.lst_MemoEventLog.Location = new System.Drawing.Point(5, 996);
            this.lst_MemoEventLog.Name = "lst_MemoEventLog";
            this.lst_MemoEventLog.Size = new System.Drawing.Size(1903, 56);
            this.lst_MemoEventLog.TabIndex = 25;
            // 
            // mbtn_BGlobalWarning
            // 
            this.mbtn_BGlobalWarning.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.mbtn_BGlobalWarning.Location = new System.Drawing.Point(399, 49);
            this.mbtn_BGlobalWarning.Name = "mbtn_BGlobalWarning";
            this.mbtn_BGlobalWarning.Size = new System.Drawing.Size(1265, 40);
            this.mbtn_BGlobalWarning.TabIndex = 3;
            this.mbtn_BGlobalWarning.Text = "BGlobalWarning";
            this.mbtn_BGlobalWarning.UseCustomBackColor = true;
            this.mbtn_BGlobalWarning.UseCustomForeColor = true;
            this.mbtn_BGlobalWarning.UseSelectable = true;
            this.mbtn_BGlobalWarning.Click += new System.EventHandler(this.mbtn_BGlobalWarning_Click);
            // 
            // mbtn_BReportPDF
            // 
            this.mbtn_BReportPDF.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.mbtn_BReportPDF.ForeColor = System.Drawing.SystemColors.ControlText;
            this.mbtn_BReportPDF.Location = new System.Drawing.Point(266, 49);
            this.mbtn_BReportPDF.Name = "mbtn_BReportPDF";
            this.mbtn_BReportPDF.Size = new System.Drawing.Size(127, 40);
            this.mbtn_BReportPDF.TabIndex = 33;
            this.mbtn_BReportPDF.Text = "Report PDF";
            this.mbtn_BReportPDF.UseSelectable = true;
            this.mbtn_BReportPDF.Click += new System.EventHandler(this.mbtn_BReportPDF_Click);
            // 
            // mtbn_BExportTestToXLS
            // 
            this.mtbn_BExportTestToXLS.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.mtbn_BExportTestToXLS.ForeColor = System.Drawing.SystemColors.ControlText;
            this.mtbn_BExportTestToXLS.Location = new System.Drawing.Point(266, 3);
            this.mtbn_BExportTestToXLS.Name = "mtbn_BExportTestToXLS";
            this.mtbn_BExportTestToXLS.Size = new System.Drawing.Size(127, 40);
            this.mtbn_BExportTestToXLS.TabIndex = 34;
            this.mtbn_BExportTestToXLS.Text = "Export Test XLS";
            this.mtbn_BExportTestToXLS.UseSelectable = true;
            this.mtbn_BExportTestToXLS.Click += new System.EventHandler(this.mtbn_BExportTestToXLS_Click);
            // 
            // mbtn_BRecordStart
            // 
            this.mbtn_BRecordStart.Location = new System.Drawing.Point(9, 85);
            this.mbtn_BRecordStart.Name = "mbtn_BRecordStart";
            this.mbtn_BRecordStart.Size = new System.Drawing.Size(210, 45);
            this.mbtn_BRecordStart.TabIndex = 2;
            this.mbtn_BRecordStart.Text = "HBM Data Record Start";
            this.mbtn_BRecordStart.UseCustomBackColor = true;
            this.mbtn_BRecordStart.UseCustomForeColor = true;
            this.mbtn_BRecordStart.UseSelectable = true;
            // 
            // mbtn_BStart
            // 
            this.mbtn_BStart.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.mbtn_BStart.Location = new System.Drawing.Point(4, 3);
            this.mbtn_BStart.Name = "mbtn_BStart";
            this.mbtn_BStart.Size = new System.Drawing.Size(125, 86);
            this.mbtn_BStart.TabIndex = 35;
            this.mbtn_BStart.Text = "&Start";
            this.mbtn_BStart.UseCustomBackColor = true;
            this.mbtn_BStart.UseCustomForeColor = true;
            this.mbtn_BStart.UseSelectable = true;
            this.mbtn_BStart.Click += new System.EventHandler(this.mbtn_BStart_Click);
            // 
            // mbtn_BStop
            // 
            this.mbtn_BStop.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.mbtn_BStop.Location = new System.Drawing.Point(135, 3);
            this.mbtn_BStop.Name = "mbtn_BStop";
            this.mbtn_BStop.Size = new System.Drawing.Size(125, 86);
            this.mbtn_BStop.TabIndex = 36;
            this.mbtn_BStop.Text = "&Stop";
            this.mbtn_BStop.UseCustomBackColor = true;
            this.mbtn_BStop.UseCustomForeColor = true;
            this.mbtn_BStop.UseSelectable = true;
            this.mbtn_BStop.Click += new System.EventHandler(this.mbtn_BStop_Click);
            // 
            // mpnl_HeaderInfoAnalogInput
            // 
            this.mpnl_HeaderInfoAnalogInput.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.mpnl_HeaderInfoAnalogInput.Controls.Add(this.lbl_Vaccum);
            this.mpnl_HeaderInfoAnalogInput.Controls.Add(this.mtxt_MKSLVacuum);
            this.mpnl_HeaderInfoAnalogInput.Controls.Add(this.lbl_InputForce1);
            this.mpnl_HeaderInfoAnalogInput.Controls.Add(this.mtxt_MKSLInputForce1);
            this.mpnl_HeaderInfoAnalogInput.Controls.Add(this.mtxt_MKSLOutputForce);
            this.mpnl_HeaderInfoAnalogInput.Controls.Add(this.mtxt_MKSLDiffTravel);
            this.mpnl_HeaderInfoAnalogInput.Controls.Add(this.mtxt_MKSLTravelPiston);
            this.mpnl_HeaderInfoAnalogInput.Controls.Add(this.lbl_RoomTemperature);
            this.mpnl_HeaderInfoAnalogInput.Controls.Add(this.mtxt_MKSLTravelTMC);
            this.mpnl_HeaderInfoAnalogInput.Controls.Add(this.lbl_Humidity);
            this.mpnl_HeaderInfoAnalogInput.Controls.Add(this.mtxt_MKSLPressurePC);
            this.mpnl_HeaderInfoAnalogInput.Controls.Add(this.lbl_PneumTestPressure);
            this.mpnl_HeaderInfoAnalogInput.Controls.Add(this.mtxt_MKSLPressureSC);
            this.mpnl_HeaderInfoAnalogInput.Controls.Add(this.lbl_HydrFillPressure);
            this.mpnl_HeaderInfoAnalogInput.Controls.Add(this.mtxt_MKSLHydrFillPressure);
            this.mpnl_HeaderInfoAnalogInput.Controls.Add(this.lbl_PressureSC);
            this.mpnl_HeaderInfoAnalogInput.Controls.Add(this.mtxt_MKSLPneumTestPressure);
            this.mpnl_HeaderInfoAnalogInput.Controls.Add(this.lbl_PressurePC);
            this.mpnl_HeaderInfoAnalogInput.Controls.Add(this.mtxt_MKSLHumidity);
            this.mpnl_HeaderInfoAnalogInput.Controls.Add(this.lbl_TravelTMC);
            this.mpnl_HeaderInfoAnalogInput.Controls.Add(this.mtxt_MKSLRoomTemp);
            this.mpnl_HeaderInfoAnalogInput.Controls.Add(this.lbl_TravelPiston);
            this.mpnl_HeaderInfoAnalogInput.Controls.Add(this.lbl_DiffTravel);
            this.mpnl_HeaderInfoAnalogInput.Controls.Add(this.lbl_OutputForce);
            this.mpnl_HeaderInfoAnalogInput.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.mpnl_HeaderInfoAnalogInput.HorizontalScrollbarBarColor = true;
            this.mpnl_HeaderInfoAnalogInput.HorizontalScrollbarHighlightOnWheel = false;
            this.mpnl_HeaderInfoAnalogInput.HorizontalScrollbarSize = 10;
            this.mpnl_HeaderInfoAnalogInput.Location = new System.Drawing.Point(5, 130);
            this.mpnl_HeaderInfoAnalogInput.Name = "mpnl_HeaderInfoAnalogInput";
            this.mpnl_HeaderInfoAnalogInput.Size = new System.Drawing.Size(1894, 79);
            this.mpnl_HeaderInfoAnalogInput.TabIndex = 47;
            this.mpnl_HeaderInfoAnalogInput.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.mpnl_HeaderInfoAnalogInput.VerticalScrollbarBarColor = true;
            this.mpnl_HeaderInfoAnalogInput.VerticalScrollbarHighlightOnWheel = false;
            this.mpnl_HeaderInfoAnalogInput.VerticalScrollbarSize = 10;
            // 
            // lbl_Vaccum
            // 
            this.lbl_Vaccum.AutoSize = true;
            this.lbl_Vaccum.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Vaccum.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lbl_Vaccum.ForeColor = System.Drawing.Color.Silver;
            this.lbl_Vaccum.Location = new System.Drawing.Point(1304, 10);
            this.lbl_Vaccum.Name = "lbl_Vaccum";
            this.lbl_Vaccum.Size = new System.Drawing.Size(76, 20);
            this.lbl_Vaccum.TabIndex = 84;
            this.lbl_Vaccum.Text = "Vacuum";
            // 
            // mtxt_MKSLVacuum
            // 
            // 
            // 
            // 
            this.mtxt_MKSLVacuum.CustomButton.Image = null;
            this.mtxt_MKSLVacuum.CustomButton.Location = new System.Drawing.Point(101, 2);
            this.mtxt_MKSLVacuum.CustomButton.Name = "";
            this.mtxt_MKSLVacuum.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.mtxt_MKSLVacuum.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.mtxt_MKSLVacuum.CustomButton.TabIndex = 1;
            this.mtxt_MKSLVacuum.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.mtxt_MKSLVacuum.CustomButton.UseSelectable = true;
            this.mtxt_MKSLVacuum.CustomButton.Visible = false;
            this.mtxt_MKSLVacuum.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.mtxt_MKSLVacuum.Lines = new string[] {
        "0.00 bar"};
            this.mtxt_MKSLVacuum.Location = new System.Drawing.Point(1277, 37);
            this.mtxt_MKSLVacuum.MaxLength = 32767;
            this.mtxt_MKSLVacuum.Name = "mtxt_MKSLVacuum";
            this.mtxt_MKSLVacuum.PasswordChar = '\0';
            this.mtxt_MKSLVacuum.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.mtxt_MKSLVacuum.SelectedText = "";
            this.mtxt_MKSLVacuum.SelectionLength = 0;
            this.mtxt_MKSLVacuum.SelectionStart = 0;
            this.mtxt_MKSLVacuum.ShortcutsEnabled = true;
            this.mtxt_MKSLVacuum.Size = new System.Drawing.Size(129, 30);
            this.mtxt_MKSLVacuum.Style = MetroFramework.MetroColorStyle.Orange;
            this.mtxt_MKSLVacuum.TabIndex = 83;
            this.mtxt_MKSLVacuum.Text = "0.00 bar";
            this.mtxt_MKSLVacuum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mtxt_MKSLVacuum.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.mtxt_MKSLVacuum.UseSelectable = true;
            this.mtxt_MKSLVacuum.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.mtxt_MKSLVacuum.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // mpnl_Buttons
            // 
            this.mpnl_Buttons.Controls.Add(this.mbtn_BClock);
            this.mpnl_Buttons.Controls.Add(this.mbtn_BAlarm);
            this.mpnl_Buttons.Controls.Add(this.mbtn_BStop);
            this.mpnl_Buttons.Controls.Add(this.mTile_LCurrentSelectedTest);
            this.mpnl_Buttons.Controls.Add(this.mbtn_BStart);
            this.mpnl_Buttons.Controls.Add(this.mbtn_BReportPDF);
            this.mpnl_Buttons.Controls.Add(this.mbtn_BGlobalWarning);
            this.mpnl_Buttons.Controls.Add(this.mtbn_BExportTestToXLS);
            this.mpnl_Buttons.HorizontalScrollbarBarColor = true;
            this.mpnl_Buttons.HorizontalScrollbarHighlightOnWheel = false;
            this.mpnl_Buttons.HorizontalScrollbarSize = 10;
            this.mpnl_Buttons.Location = new System.Drawing.Point(5, 25);
            this.mpnl_Buttons.Name = "mpnl_Buttons";
            this.mpnl_Buttons.Size = new System.Drawing.Size(1900, 100);
            this.mpnl_Buttons.TabIndex = 48;
            this.mpnl_Buttons.VerticalScrollbarBarColor = true;
            this.mpnl_Buttons.VerticalScrollbarHighlightOnWheel = false;
            this.mpnl_Buttons.VerticalScrollbarSize = 10;
            // 
            // mbtn_BClock
            // 
            this.mbtn_BClock.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.mbtn_BClock.Location = new System.Drawing.Point(1669, 3);
            this.mbtn_BClock.Name = "mbtn_BClock";
            this.mbtn_BClock.Size = new System.Drawing.Size(221, 40);
            this.mbtn_BClock.Style = MetroFramework.MetroColorStyle.Orange;
            this.mbtn_BClock.TabIndex = 38;
            this.mbtn_BClock.Text = "DATE / TIME";
            this.mbtn_BClock.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.mbtn_BClock.UseCustomBackColor = true;
            this.mbtn_BClock.UseCustomForeColor = true;
            this.mbtn_BClock.UseSelectable = true;
            this.mbtn_BClock.UseStyleColors = true;
            // 
            // mbtn_BAlarm
            // 
            this.mbtn_BAlarm.Location = new System.Drawing.Point(1670, 49);
            this.mbtn_BAlarm.Name = "mbtn_BAlarm";
            this.mbtn_BAlarm.Size = new System.Drawing.Size(221, 40);
            this.mbtn_BAlarm.TabIndex = 38;
            this.mbtn_BAlarm.Text = "ALARM";
            this.mbtn_BAlarm.UseCustomBackColor = true;
            this.mbtn_BAlarm.UseCustomForeColor = true;
            this.mbtn_BAlarm.UseSelectable = true;
            // 
            // mpnl_Eventlog
            // 
            this.mpnl_Eventlog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mpnl_Eventlog.Controls.Add(this.mlbl_EoutPressure);
            this.mpnl_Eventlog.Controls.Add(this.mlbl_EoutForce);
            this.mpnl_Eventlog.Controls.Add(this.mlbl_EoutRef);
            this.mpnl_Eventlog.Controls.Add(this.progressBar1);
            this.mpnl_Eventlog.Controls.Add(this.mbtn_BHandshakePC);
            this.mpnl_Eventlog.Controls.Add(this.mbtn_BGlobalAlert);
            this.mpnl_Eventlog.Controls.Add(this.mbtn_BEMotorRef);
            this.mpnl_Eventlog.Controls.Add(this.mbtn_BRecordStop);
            this.mpnl_Eventlog.Controls.Add(this.mbtn_BRun);
            this.mpnl_Eventlog.Controls.Add(this.mbtn_BRecording);
            this.mpnl_Eventlog.Controls.Add(this.mbtn_BRecordStart);
            this.mpnl_Eventlog.Controls.Add(this.metroPanel5);
            this.mpnl_Eventlog.Controls.Add(this.mbtn_BHandshakePLC);
            this.mpnl_Eventlog.Controls.Add(this.mbtn_BAlert);
            this.mpnl_Eventlog.Controls.Add(this.mTile_Diagram_TestInfo);
            this.mpnl_Eventlog.HorizontalScrollbarBarColor = true;
            this.mpnl_Eventlog.HorizontalScrollbarHighlightOnWheel = false;
            this.mpnl_Eventlog.HorizontalScrollbarSize = 10;
            this.mpnl_Eventlog.Location = new System.Drawing.Point(1449, 240);
            this.mpnl_Eventlog.Name = "mpnl_Eventlog";
            this.mpnl_Eventlog.Size = new System.Drawing.Size(450, 755);
            this.mpnl_Eventlog.TabIndex = 124;
            this.mpnl_Eventlog.VerticalScrollbarBarColor = true;
            this.mpnl_Eventlog.VerticalScrollbarHighlightOnWheel = false;
            this.mpnl_Eventlog.VerticalScrollbarSize = 10;
            // 
            // mlbl_EoutPressure
            // 
            // 
            // 
            // 
            this.mlbl_EoutPressure.CustomButton.Image = null;
            this.mlbl_EoutPressure.CustomButton.Location = new System.Drawing.Point(55, 2);
            this.mlbl_EoutPressure.CustomButton.Name = "";
            this.mlbl_EoutPressure.CustomButton.Size = new System.Drawing.Size(19, 19);
            this.mlbl_EoutPressure.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.mlbl_EoutPressure.CustomButton.TabIndex = 1;
            this.mlbl_EoutPressure.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.mlbl_EoutPressure.CustomButton.UseSelectable = true;
            this.mlbl_EoutPressure.CustomButton.Visible = false;
            this.mlbl_EoutPressure.FontWeight = MetroFramework.MetroTextBoxWeight.Bold;
            this.mlbl_EoutPressure.Lines = new string[] {
        "0,0 bar"};
            this.mlbl_EoutPressure.Location = new System.Drawing.Point(167, 287);
            this.mlbl_EoutPressure.MaxLength = 32767;
            this.mlbl_EoutPressure.Name = "mlbl_EoutPressure";
            this.mlbl_EoutPressure.PasswordChar = '\0';
            this.mlbl_EoutPressure.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.mlbl_EoutPressure.SelectedText = "";
            this.mlbl_EoutPressure.SelectionLength = 0;
            this.mlbl_EoutPressure.SelectionStart = 0;
            this.mlbl_EoutPressure.ShortcutsEnabled = true;
            this.mlbl_EoutPressure.Size = new System.Drawing.Size(77, 24);
            this.mlbl_EoutPressure.TabIndex = 127;
            this.mlbl_EoutPressure.Text = "0,0 bar";
            this.mlbl_EoutPressure.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mlbl_EoutPressure.UseSelectable = true;
            this.mlbl_EoutPressure.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.mlbl_EoutPressure.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // mlbl_EoutForce
            // 
            // 
            // 
            // 
            this.mlbl_EoutForce.CustomButton.Image = null;
            this.mlbl_EoutForce.CustomButton.Location = new System.Drawing.Point(55, 2);
            this.mlbl_EoutForce.CustomButton.Name = "";
            this.mlbl_EoutForce.CustomButton.Size = new System.Drawing.Size(19, 19);
            this.mlbl_EoutForce.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.mlbl_EoutForce.CustomButton.TabIndex = 1;
            this.mlbl_EoutForce.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.mlbl_EoutForce.CustomButton.UseSelectable = true;
            this.mlbl_EoutForce.CustomButton.Visible = false;
            this.mlbl_EoutForce.FontWeight = MetroFramework.MetroTextBoxWeight.Bold;
            this.mlbl_EoutForce.Lines = new string[] {
        "0,0 N"};
            this.mlbl_EoutForce.Location = new System.Drawing.Point(84, 287);
            this.mlbl_EoutForce.MaxLength = 32767;
            this.mlbl_EoutForce.Name = "mlbl_EoutForce";
            this.mlbl_EoutForce.PasswordChar = '\0';
            this.mlbl_EoutForce.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.mlbl_EoutForce.SelectedText = "";
            this.mlbl_EoutForce.SelectionLength = 0;
            this.mlbl_EoutForce.SelectionStart = 0;
            this.mlbl_EoutForce.ShortcutsEnabled = true;
            this.mlbl_EoutForce.Size = new System.Drawing.Size(77, 24);
            this.mlbl_EoutForce.TabIndex = 125;
            this.mlbl_EoutForce.Text = "0,0 N";
            this.mlbl_EoutForce.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mlbl_EoutForce.UseSelectable = true;
            this.mlbl_EoutForce.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.mlbl_EoutForce.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // mlbl_EoutRef
            // 
            // 
            // 
            // 
            this.mlbl_EoutRef.CustomButton.Image = null;
            this.mlbl_EoutRef.CustomButton.Location = new System.Drawing.Point(46, 2);
            this.mlbl_EoutRef.CustomButton.Name = "";
            this.mlbl_EoutRef.CustomButton.Size = new System.Drawing.Size(19, 19);
            this.mlbl_EoutRef.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.mlbl_EoutRef.CustomButton.TabIndex = 1;
            this.mlbl_EoutRef.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.mlbl_EoutRef.CustomButton.UseSelectable = true;
            this.mlbl_EoutRef.CustomButton.Visible = false;
            this.mlbl_EoutRef.FontWeight = MetroFramework.MetroTextBoxWeight.Bold;
            this.mlbl_EoutRef.Lines = new string[] {
        "Eout Ref"};
            this.mlbl_EoutRef.Location = new System.Drawing.Point(10, 287);
            this.mlbl_EoutRef.MaxLength = 32767;
            this.mlbl_EoutRef.Name = "mlbl_EoutRef";
            this.mlbl_EoutRef.PasswordChar = '\0';
            this.mlbl_EoutRef.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.mlbl_EoutRef.SelectedText = "";
            this.mlbl_EoutRef.SelectionLength = 0;
            this.mlbl_EoutRef.SelectionStart = 0;
            this.mlbl_EoutRef.ShortcutsEnabled = true;
            this.mlbl_EoutRef.Size = new System.Drawing.Size(68, 24);
            this.mlbl_EoutRef.TabIndex = 124;
            this.mlbl_EoutRef.Text = "Eout Ref";
            this.mlbl_EoutRef.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mlbl_EoutRef.UseSelectable = true;
            this.mlbl_EoutRef.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.mlbl_EoutRef.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(5, 317);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(432, 23);
            this.progressBar1.TabIndex = 27;
            // 
            // mbtn_BHandshakePC
            // 
            this.mbtn_BHandshakePC.Location = new System.Drawing.Point(231, 49);
            this.mbtn_BHandshakePC.Name = "mbtn_BHandshakePC";
            this.mbtn_BHandshakePC.Size = new System.Drawing.Size(210, 30);
            this.mbtn_BHandshakePC.TabIndex = 39;
            this.mbtn_BHandshakePC.Text = "Handshake PC";
            this.mbtn_BHandshakePC.UseCustomBackColor = true;
            this.mbtn_BHandshakePC.UseCustomForeColor = true;
            this.mbtn_BHandshakePC.UseSelectable = true;
            // 
            // mbtn_BGlobalAlert
            // 
            this.mbtn_BGlobalAlert.Location = new System.Drawing.Point(144, 246);
            this.mbtn_BGlobalAlert.Name = "mbtn_BGlobalAlert";
            this.mbtn_BGlobalAlert.Size = new System.Drawing.Size(297, 30);
            this.mbtn_BGlobalAlert.TabIndex = 39;
            this.mbtn_BGlobalAlert.Text = "BGlobalAlert";
            this.mbtn_BGlobalAlert.UseCustomBackColor = true;
            this.mbtn_BGlobalAlert.UseCustomForeColor = true;
            this.mbtn_BGlobalAlert.UseSelectable = true;
            // 
            // mbtn_BEMotorRef
            // 
            this.mbtn_BEMotorRef.Location = new System.Drawing.Point(9, 210);
            this.mbtn_BEMotorRef.Name = "mbtn_BEMotorRef";
            this.mbtn_BEMotorRef.Size = new System.Drawing.Size(432, 30);
            this.mbtn_BEMotorRef.TabIndex = 41;
            this.mbtn_BEMotorRef.Text = "EMotor Ref.";
            this.mbtn_BEMotorRef.UseCustomBackColor = true;
            this.mbtn_BEMotorRef.UseCustomForeColor = true;
            this.mbtn_BEMotorRef.UseSelectable = true;
            // 
            // mbtn_BRecordStop
            // 
            this.mbtn_BRecordStop.ForeColor = System.Drawing.SystemColors.ControlText;
            this.mbtn_BRecordStop.Location = new System.Drawing.Point(231, 85);
            this.mbtn_BRecordStop.Name = "mbtn_BRecordStop";
            this.mbtn_BRecordStop.Size = new System.Drawing.Size(210, 45);
            this.mbtn_BRecordStop.TabIndex = 37;
            this.mbtn_BRecordStop.Text = "HBM Data Record Stop";
            this.mbtn_BRecordStop.UseCustomBackColor = true;
            this.mbtn_BRecordStop.UseCustomForeColor = true;
            this.mbtn_BRecordStop.UseSelectable = true;
            // 
            // mbtn_BRun
            // 
            this.mbtn_BRun.Location = new System.Drawing.Point(9, 173);
            this.mbtn_BRun.Name = "mbtn_BRun";
            this.mbtn_BRun.Size = new System.Drawing.Size(432, 30);
            this.mbtn_BRun.TabIndex = 40;
            this.mbtn_BRun.Text = "Test Running";
            this.mbtn_BRun.UseCustomBackColor = true;
            this.mbtn_BRun.UseCustomForeColor = true;
            this.mbtn_BRun.UseSelectable = true;
            // 
            // mbtn_BRecording
            // 
            this.mbtn_BRecording.Location = new System.Drawing.Point(9, 137);
            this.mbtn_BRecording.Name = "mbtn_BRecording";
            this.mbtn_BRecording.Size = new System.Drawing.Size(432, 30);
            this.mbtn_BRecording.TabIndex = 40;
            this.mbtn_BRecording.Text = "HBM Data Recording";
            this.mbtn_BRecording.UseCustomBackColor = true;
            this.mbtn_BRecording.UseCustomForeColor = true;
            this.mbtn_BRecording.UseSelectable = true;
            // 
            // metroPanel5
            // 
            this.metroPanel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.metroPanel5.Controls.Add(this.lvLog);
            this.metroPanel5.Controls.Add(this.mTile_Diagram_TestSequence);
            this.metroPanel5.HorizontalScrollbarBarColor = true;
            this.metroPanel5.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel5.HorizontalScrollbarSize = 10;
            this.metroPanel5.Location = new System.Drawing.Point(5, 367);
            this.metroPanel5.Name = "metroPanel5";
            this.metroPanel5.Size = new System.Drawing.Size(440, 382);
            this.metroPanel5.TabIndex = 123;
            this.metroPanel5.VerticalScrollbarBarColor = true;
            this.metroPanel5.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel5.VerticalScrollbarSize = 10;
            // 
            // lvLog
            // 
            this.lvLog.HideSelection = false;
            this.lvLog.Location = new System.Drawing.Point(4, 46);
            this.lvLog.Name = "lvLog";
            this.lvLog.Size = new System.Drawing.Size(425, 331);
            this.lvLog.TabIndex = 140;
            this.lvLog.UseCompatibleStateImageBehavior = false;
            // 
            // mTile_Diagram_TestSequence
            // 
            this.mTile_Diagram_TestSequence.ActiveControl = null;
            this.mTile_Diagram_TestSequence.Location = new System.Drawing.Point(0, 0);
            this.mTile_Diagram_TestSequence.Name = "mTile_Diagram_TestSequence";
            this.mTile_Diagram_TestSequence.Size = new System.Drawing.Size(440, 40);
            this.mTile_Diagram_TestSequence.Style = MetroFramework.MetroColorStyle.Orange;
            this.mTile_Diagram_TestSequence.TabIndex = 106;
            this.mTile_Diagram_TestSequence.Text = "Test Sequence";
            this.mTile_Diagram_TestSequence.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.mTile_Diagram_TestSequence.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.mTile_Diagram_TestSequence.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            this.mTile_Diagram_TestSequence.UseSelectable = true;
            // 
            // mbtn_BHandshakePLC
            // 
            this.mbtn_BHandshakePLC.Location = new System.Drawing.Point(9, 49);
            this.mbtn_BHandshakePLC.Name = "mbtn_BHandshakePLC";
            this.mbtn_BHandshakePLC.Size = new System.Drawing.Size(210, 30);
            this.mbtn_BHandshakePLC.TabIndex = 38;
            this.mbtn_BHandshakePLC.Text = "Handshake PLC";
            this.mbtn_BHandshakePLC.UseCustomBackColor = true;
            this.mbtn_BHandshakePLC.UseCustomForeColor = true;
            this.mbtn_BHandshakePLC.UseSelectable = true;
            // 
            // mbtn_BAlert
            // 
            this.mbtn_BAlert.Location = new System.Drawing.Point(9, 246);
            this.mbtn_BAlert.Name = "mbtn_BAlert";
            this.mbtn_BAlert.Size = new System.Drawing.Size(125, 30);
            this.mbtn_BAlert.TabIndex = 38;
            this.mbtn_BAlert.Text = "ALERT";
            this.mbtn_BAlert.UseCustomBackColor = true;
            this.mbtn_BAlert.UseCustomForeColor = true;
            this.mbtn_BAlert.UseSelectable = true;
            // 
            // mTile_Diagram_TestInfo
            // 
            this.mTile_Diagram_TestInfo.ActiveControl = null;
            this.mTile_Diagram_TestInfo.Location = new System.Drawing.Point(0, 0);
            this.mTile_Diagram_TestInfo.Name = "mTile_Diagram_TestInfo";
            this.mTile_Diagram_TestInfo.Size = new System.Drawing.Size(450, 45);
            this.mTile_Diagram_TestInfo.Style = MetroFramework.MetroColorStyle.Orange;
            this.mTile_Diagram_TestInfo.TabIndex = 122;
            this.mTile_Diagram_TestInfo.Text = "Test Info";
            this.mTile_Diagram_TestInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.mTile_Diagram_TestInfo.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.mTile_Diagram_TestInfo.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.mTile_Diagram_TestInfo.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.mTile_Diagram_TestInfo.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            this.mTile_Diagram_TestInfo.UseSelectable = true;
            // 
            // timerHBM
            // 
            this.timerHBM.Interval = 200;
            this.timerHBM.Tick += new System.EventHandler(this.timerHBM_Tick);
            // 
            // timerMODBUS
            // 
            this.timerMODBUS.Enabled = true;
            this.timerMODBUS.Tick += new System.EventHandler(this.timerMODBUS_Tick);
            // 
            // Tab_ActuationParameters
            // 
            this.Tab_ActuationParameters.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Tab_ActuationParameters.Controls.Add(this.mPnl_tabActParam_GenralSettings);
            this.Tab_ActuationParameters.Controls.Add(this.mPnl_tabActParam_EvaluationParameters);
            this.Tab_ActuationParameters.Controls.Add(this.mPnl_tabActParam_Actuation);
            this.Tab_ActuationParameters.Location = new System.Drawing.Point(4, 31);
            this.Tab_ActuationParameters.Margin = new System.Windows.Forms.Padding(2);
            this.Tab_ActuationParameters.Name = "Tab_ActuationParameters";
            this.Tab_ActuationParameters.Padding = new System.Windows.Forms.Padding(2);
            this.Tab_ActuationParameters.Size = new System.Drawing.Size(1434, 745);
            this.Tab_ActuationParameters.TabIndex = 3;
            this.Tab_ActuationParameters.Text = "Actuation Parameters";
            this.Tab_ActuationParameters.UseVisualStyleBackColor = true;
            // 
            // mPnl_tabActParam_GenralSettings
            // 
            this.mPnl_tabActParam_GenralSettings.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mPnl_tabActParam_GenralSettings.Controls.Add(this.mchk_tabActParam_GenSettings_CBLock);
            this.mPnl_tabActParam_GenralSettings.Controls.Add(this.mTile_tabActParam_GeneralSettings);
            this.mPnl_tabActParam_GenralSettings.Controls.Add(this.mcbo_tabActParam_GenSettings_CoBActuationMode);
            this.mPnl_tabActParam_GenralSettings.Controls.Add(this.metroPanel1);
            this.mPnl_tabActParam_GenralSettings.Controls.Add(this.mlbl_tabActParam_GenSettings_ActuationMode);
            this.mPnl_tabActParam_GenralSettings.Controls.Add(this.mpnl_CurrentProject);
            this.mPnl_tabActParam_GenralSettings.Controls.Add(this.mcbo_tabActParam_GenSettings_CoBSelectTest);
            this.mPnl_tabActParam_GenralSettings.Controls.Add(this.mbtn_tabActParam_GenSettings_BSaveCurrentParams);
            this.mPnl_tabActParam_GenralSettings.Controls.Add(this.mchk_tabActParam_GenSettings_CBStartFromSelection);
            this.mPnl_tabActParam_GenralSettings.Controls.Add(this.mbtn_tabActParam_GenSettings_BLoadAdjSettings);
            this.mPnl_tabActParam_GenralSettings.Controls.Add(this.mchk_tabActParam_GenSettings_CBSWaitBetweenTests);
            this.mPnl_tabActParam_GenralSettings.Controls.Add(this.mbtn_tabActParam_GenSettings_BLoadLastestParams);
            this.mPnl_tabActParam_GenralSettings.Controls.Add(this.grpOutput);
            this.mPnl_tabActParam_GenralSettings.HorizontalScrollbarBarColor = true;
            this.mPnl_tabActParam_GenralSettings.HorizontalScrollbarHighlightOnWheel = false;
            this.mPnl_tabActParam_GenralSettings.HorizontalScrollbarSize = 10;
            this.mPnl_tabActParam_GenralSettings.Location = new System.Drawing.Point(2, 2);
            this.mPnl_tabActParam_GenralSettings.Name = "mPnl_tabActParam_GenralSettings";
            this.mPnl_tabActParam_GenralSettings.Size = new System.Drawing.Size(520, 740);
            this.mPnl_tabActParam_GenralSettings.TabIndex = 123;
            this.mPnl_tabActParam_GenralSettings.VerticalScrollbarBarColor = true;
            this.mPnl_tabActParam_GenralSettings.VerticalScrollbarHighlightOnWheel = false;
            this.mPnl_tabActParam_GenralSettings.VerticalScrollbarSize = 10;
            // 
            // mchk_tabActParam_GenSettings_CBLock
            // 
            this.mchk_tabActParam_GenSettings_CBLock.AutoSize = true;
            this.mchk_tabActParam_GenSettings_CBLock.FontSize = MetroFramework.MetroCheckBoxSize.Medium;
            this.mchk_tabActParam_GenSettings_CBLock.FontWeight = MetroFramework.MetroCheckBoxWeight.Bold;
            this.mchk_tabActParam_GenSettings_CBLock.Location = new System.Drawing.Point(44, 709);
            this.mchk_tabActParam_GenSettings_CBLock.Margin = new System.Windows.Forms.Padding(2);
            this.mchk_tabActParam_GenSettings_CBLock.Name = "mchk_tabActParam_GenSettings_CBLock";
            this.mchk_tabActParam_GenSettings_CBLock.Size = new System.Drawing.Size(105, 20);
            this.mchk_tabActParam_GenSettings_CBLock.Style = MetroFramework.MetroColorStyle.Orange;
            this.mchk_tabActParam_GenSettings_CBLock.TabIndex = 123;
            this.mchk_tabActParam_GenSettings_CBLock.Text = "Piston Lock";
            this.mchk_tabActParam_GenSettings_CBLock.UseCustomBackColor = true;
            this.mchk_tabActParam_GenSettings_CBLock.UseCustomForeColor = true;
            this.mchk_tabActParam_GenSettings_CBLock.UseSelectable = true;
            this.mchk_tabActParam_GenSettings_CBLock.UseStyleColors = true;
            this.mchk_tabActParam_GenSettings_CBLock.UseWaitCursor = true;
            this.mchk_tabActParam_GenSettings_CBLock.CheckedChanged += new System.EventHandler(this.mchk_tabActParam_GenSettings_CBLock_CheckedChanged);
            // 
            // mTile_tabActParam_GeneralSettings
            // 
            this.mTile_tabActParam_GeneralSettings.ActiveControl = null;
            this.mTile_tabActParam_GeneralSettings.Location = new System.Drawing.Point(0, 0);
            this.mTile_tabActParam_GeneralSettings.Name = "mTile_tabActParam_GeneralSettings";
            this.mTile_tabActParam_GeneralSettings.Size = new System.Drawing.Size(520, 45);
            this.mTile_tabActParam_GeneralSettings.Style = MetroFramework.MetroColorStyle.Orange;
            this.mTile_tabActParam_GeneralSettings.TabIndex = 122;
            this.mTile_tabActParam_GeneralSettings.Text = "General Settings";
            this.mTile_tabActParam_GeneralSettings.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.mTile_tabActParam_GeneralSettings.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.mTile_tabActParam_GeneralSettings.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.mTile_tabActParam_GeneralSettings.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.mTile_tabActParam_GeneralSettings.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            this.mTile_tabActParam_GeneralSettings.UseSelectable = true;
            // 
            // mcbo_tabActParam_GenSettings_CoBActuationMode
            // 
            this.mcbo_tabActParam_GenSettings_CoBActuationMode.FontSize = MetroFramework.MetroComboBoxSize.Tall;
            this.mcbo_tabActParam_GenSettings_CoBActuationMode.FormattingEnabled = true;
            this.mcbo_tabActParam_GenSettings_CoBActuationMode.ItemHeight = 29;
            this.mcbo_tabActParam_GenSettings_CoBActuationMode.Location = new System.Drawing.Point(260, 52);
            this.mcbo_tabActParam_GenSettings_CoBActuationMode.Margin = new System.Windows.Forms.Padding(2);
            this.mcbo_tabActParam_GenSettings_CoBActuationMode.Name = "mcbo_tabActParam_GenSettings_CoBActuationMode";
            this.mcbo_tabActParam_GenSettings_CoBActuationMode.Size = new System.Drawing.Size(250, 35);
            this.mcbo_tabActParam_GenSettings_CoBActuationMode.Style = MetroFramework.MetroColorStyle.Orange;
            this.mcbo_tabActParam_GenSettings_CoBActuationMode.TabIndex = 121;
            this.mcbo_tabActParam_GenSettings_CoBActuationMode.Theme = MetroFramework.MetroThemeStyle.Light;
            this.mcbo_tabActParam_GenSettings_CoBActuationMode.UseSelectable = true;
            this.mcbo_tabActParam_GenSettings_CoBActuationMode.SelectedIndexChanged += new System.EventHandler(this.mcbo_GeneralSettings_CoBActuationMode_SelectedIndexChanged);
            // 
            // metroPanel1
            // 
            this.metroPanel1.Controls.Add(this.mTile_tabActionParam_Consumer);
            this.metroPanel1.Controls.Add(this.mlbl_GeneralSettings_LTubeConsSC);
            this.metroPanel1.Controls.Add(this.mlbl_GeneralSettings_LTubeConsPC);
            this.metroPanel1.Controls.Add(this.mtxt_GeneralSettings_ETubeConsumerSCPressSide);
            this.metroPanel1.Controls.Add(this.mtxt_GeneralSettings_ETubeConsumerPCPressSide);
            this.metroPanel1.Controls.Add(this.mbtn_GeneralSettings_BSelectTubeCons);
            this.metroPanel1.Controls.Add(this.grpRadConsumer);
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(0, 538);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(520, 150);
            this.metroPanel1.TabIndex = 120;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // mTile_tabActionParam_Consumer
            // 
            this.mTile_tabActionParam_Consumer.ActiveControl = null;
            this.mTile_tabActionParam_Consumer.Location = new System.Drawing.Point(0, 0);
            this.mTile_tabActionParam_Consumer.Name = "mTile_tabActionParam_Consumer";
            this.mTile_tabActionParam_Consumer.Size = new System.Drawing.Size(520, 40);
            this.mTile_tabActionParam_Consumer.Style = MetroFramework.MetroColorStyle.Orange;
            this.mTile_tabActionParam_Consumer.TabIndex = 106;
            this.mTile_tabActionParam_Consumer.Text = "Consumer";
            this.mTile_tabActionParam_Consumer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.mTile_tabActionParam_Consumer.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.mTile_tabActionParam_Consumer.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            this.mTile_tabActionParam_Consumer.UseSelectable = true;
            // 
            // mlbl_GeneralSettings_LTubeConsSC
            // 
            // 
            // 
            // 
            this.mlbl_GeneralSettings_LTubeConsSC.CustomButton.Image = null;
            this.mlbl_GeneralSettings_LTubeConsSC.CustomButton.Location = new System.Drawing.Point(189, 2);
            this.mlbl_GeneralSettings_LTubeConsSC.CustomButton.Name = "";
            this.mlbl_GeneralSettings_LTubeConsSC.CustomButton.Size = new System.Drawing.Size(19, 19);
            this.mlbl_GeneralSettings_LTubeConsSC.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.mlbl_GeneralSettings_LTubeConsSC.CustomButton.TabIndex = 1;
            this.mlbl_GeneralSettings_LTubeConsSC.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.mlbl_GeneralSettings_LTubeConsSC.CustomButton.UseSelectable = true;
            this.mlbl_GeneralSettings_LTubeConsSC.CustomButton.Visible = false;
            this.mlbl_GeneralSettings_LTubeConsSC.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.mlbl_GeneralSettings_LTubeConsSC.FontWeight = MetroFramework.MetroTextBoxWeight.Bold;
            this.mlbl_GeneralSettings_LTubeConsSC.Lines = new string[] {
        "SC"};
            this.mlbl_GeneralSettings_LTubeConsSC.Location = new System.Drawing.Point(16, 118);
            this.mlbl_GeneralSettings_LTubeConsSC.MaxLength = 32767;
            this.mlbl_GeneralSettings_LTubeConsSC.Name = "mlbl_GeneralSettings_LTubeConsSC";
            this.mlbl_GeneralSettings_LTubeConsSC.PasswordChar = '\0';
            this.mlbl_GeneralSettings_LTubeConsSC.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.mlbl_GeneralSettings_LTubeConsSC.SelectedText = "";
            this.mlbl_GeneralSettings_LTubeConsSC.SelectionLength = 0;
            this.mlbl_GeneralSettings_LTubeConsSC.SelectionStart = 0;
            this.mlbl_GeneralSettings_LTubeConsSC.ShortcutsEnabled = true;
            this.mlbl_GeneralSettings_LTubeConsSC.Size = new System.Drawing.Size(211, 24);
            this.mlbl_GeneralSettings_LTubeConsSC.TabIndex = 105;
            this.mlbl_GeneralSettings_LTubeConsSC.Text = "SC";
            this.mlbl_GeneralSettings_LTubeConsSC.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mlbl_GeneralSettings_LTubeConsSC.UseSelectable = true;
            this.mlbl_GeneralSettings_LTubeConsSC.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.mlbl_GeneralSettings_LTubeConsSC.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // mlbl_GeneralSettings_LTubeConsPC
            // 
            // 
            // 
            // 
            this.mlbl_GeneralSettings_LTubeConsPC.CustomButton.Image = null;
            this.mlbl_GeneralSettings_LTubeConsPC.CustomButton.Location = new System.Drawing.Point(189, 2);
            this.mlbl_GeneralSettings_LTubeConsPC.CustomButton.Name = "";
            this.mlbl_GeneralSettings_LTubeConsPC.CustomButton.Size = new System.Drawing.Size(19, 19);
            this.mlbl_GeneralSettings_LTubeConsPC.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.mlbl_GeneralSettings_LTubeConsPC.CustomButton.TabIndex = 1;
            this.mlbl_GeneralSettings_LTubeConsPC.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.mlbl_GeneralSettings_LTubeConsPC.CustomButton.UseSelectable = true;
            this.mlbl_GeneralSettings_LTubeConsPC.CustomButton.Visible = false;
            this.mlbl_GeneralSettings_LTubeConsPC.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.mlbl_GeneralSettings_LTubeConsPC.FontWeight = MetroFramework.MetroTextBoxWeight.Bold;
            this.mlbl_GeneralSettings_LTubeConsPC.Lines = new string[] {
        "PC"};
            this.mlbl_GeneralSettings_LTubeConsPC.Location = new System.Drawing.Point(16, 88);
            this.mlbl_GeneralSettings_LTubeConsPC.MaxLength = 32767;
            this.mlbl_GeneralSettings_LTubeConsPC.Name = "mlbl_GeneralSettings_LTubeConsPC";
            this.mlbl_GeneralSettings_LTubeConsPC.PasswordChar = '\0';
            this.mlbl_GeneralSettings_LTubeConsPC.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.mlbl_GeneralSettings_LTubeConsPC.SelectedText = "";
            this.mlbl_GeneralSettings_LTubeConsPC.SelectionLength = 0;
            this.mlbl_GeneralSettings_LTubeConsPC.SelectionStart = 0;
            this.mlbl_GeneralSettings_LTubeConsPC.ShortcutsEnabled = true;
            this.mlbl_GeneralSettings_LTubeConsPC.Size = new System.Drawing.Size(211, 24);
            this.mlbl_GeneralSettings_LTubeConsPC.TabIndex = 104;
            this.mlbl_GeneralSettings_LTubeConsPC.Text = "PC";
            this.mlbl_GeneralSettings_LTubeConsPC.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mlbl_GeneralSettings_LTubeConsPC.UseSelectable = true;
            this.mlbl_GeneralSettings_LTubeConsPC.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.mlbl_GeneralSettings_LTubeConsPC.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // mtxt_GeneralSettings_ETubeConsumerSCPressSide
            // 
            // 
            // 
            // 
            this.mtxt_GeneralSettings_ETubeConsumerSCPressSide.CustomButton.Image = null;
            this.mtxt_GeneralSettings_ETubeConsumerSCPressSide.CustomButton.Location = new System.Drawing.Point(133, 1);
            this.mtxt_GeneralSettings_ETubeConsumerSCPressSide.CustomButton.Name = "";
            this.mtxt_GeneralSettings_ETubeConsumerSCPressSide.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.mtxt_GeneralSettings_ETubeConsumerSCPressSide.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.mtxt_GeneralSettings_ETubeConsumerSCPressSide.CustomButton.TabIndex = 1;
            this.mtxt_GeneralSettings_ETubeConsumerSCPressSide.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.mtxt_GeneralSettings_ETubeConsumerSCPressSide.CustomButton.UseSelectable = true;
            this.mtxt_GeneralSettings_ETubeConsumerSCPressSide.CustomButton.Visible = false;
            this.mtxt_GeneralSettings_ETubeConsumerSCPressSide.Lines = new string[0];
            this.mtxt_GeneralSettings_ETubeConsumerSCPressSide.Location = new System.Drawing.Point(233, 117);
            this.mtxt_GeneralSettings_ETubeConsumerSCPressSide.MaxLength = 32767;
            this.mtxt_GeneralSettings_ETubeConsumerSCPressSide.Name = "mtxt_GeneralSettings_ETubeConsumerSCPressSide";
            this.mtxt_GeneralSettings_ETubeConsumerSCPressSide.PasswordChar = '\0';
            this.mtxt_GeneralSettings_ETubeConsumerSCPressSide.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.mtxt_GeneralSettings_ETubeConsumerSCPressSide.SelectedText = "";
            this.mtxt_GeneralSettings_ETubeConsumerSCPressSide.SelectionLength = 0;
            this.mtxt_GeneralSettings_ETubeConsumerSCPressSide.SelectionStart = 0;
            this.mtxt_GeneralSettings_ETubeConsumerSCPressSide.ShortcutsEnabled = true;
            this.mtxt_GeneralSettings_ETubeConsumerSCPressSide.Size = new System.Drawing.Size(157, 25);
            this.mtxt_GeneralSettings_ETubeConsumerSCPressSide.TabIndex = 43;
            this.mtxt_GeneralSettings_ETubeConsumerSCPressSide.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mtxt_GeneralSettings_ETubeConsumerSCPressSide.UseSelectable = true;
            this.mtxt_GeneralSettings_ETubeConsumerSCPressSide.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.mtxt_GeneralSettings_ETubeConsumerSCPressSide.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // mtxt_GeneralSettings_ETubeConsumerPCPressSide
            // 
            // 
            // 
            // 
            this.mtxt_GeneralSettings_ETubeConsumerPCPressSide.CustomButton.Image = null;
            this.mtxt_GeneralSettings_ETubeConsumerPCPressSide.CustomButton.Location = new System.Drawing.Point(133, 1);
            this.mtxt_GeneralSettings_ETubeConsumerPCPressSide.CustomButton.Name = "";
            this.mtxt_GeneralSettings_ETubeConsumerPCPressSide.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.mtxt_GeneralSettings_ETubeConsumerPCPressSide.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.mtxt_GeneralSettings_ETubeConsumerPCPressSide.CustomButton.TabIndex = 1;
            this.mtxt_GeneralSettings_ETubeConsumerPCPressSide.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.mtxt_GeneralSettings_ETubeConsumerPCPressSide.CustomButton.UseSelectable = true;
            this.mtxt_GeneralSettings_ETubeConsumerPCPressSide.CustomButton.Visible = false;
            this.mtxt_GeneralSettings_ETubeConsumerPCPressSide.Lines = new string[0];
            this.mtxt_GeneralSettings_ETubeConsumerPCPressSide.Location = new System.Drawing.Point(233, 88);
            this.mtxt_GeneralSettings_ETubeConsumerPCPressSide.MaxLength = 32767;
            this.mtxt_GeneralSettings_ETubeConsumerPCPressSide.Name = "mtxt_GeneralSettings_ETubeConsumerPCPressSide";
            this.mtxt_GeneralSettings_ETubeConsumerPCPressSide.PasswordChar = '\0';
            this.mtxt_GeneralSettings_ETubeConsumerPCPressSide.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.mtxt_GeneralSettings_ETubeConsumerPCPressSide.SelectedText = "";
            this.mtxt_GeneralSettings_ETubeConsumerPCPressSide.SelectionLength = 0;
            this.mtxt_GeneralSettings_ETubeConsumerPCPressSide.SelectionStart = 0;
            this.mtxt_GeneralSettings_ETubeConsumerPCPressSide.ShortcutsEnabled = true;
            this.mtxt_GeneralSettings_ETubeConsumerPCPressSide.Size = new System.Drawing.Size(157, 25);
            this.mtxt_GeneralSettings_ETubeConsumerPCPressSide.TabIndex = 47;
            this.mtxt_GeneralSettings_ETubeConsumerPCPressSide.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mtxt_GeneralSettings_ETubeConsumerPCPressSide.UseSelectable = true;
            this.mtxt_GeneralSettings_ETubeConsumerPCPressSide.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.mtxt_GeneralSettings_ETubeConsumerPCPressSide.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // mbtn_GeneralSettings_BSelectTubeCons
            // 
            this.mbtn_GeneralSettings_BSelectTubeCons.Location = new System.Drawing.Point(402, 84);
            this.mbtn_GeneralSettings_BSelectTubeCons.Name = "mbtn_GeneralSettings_BSelectTubeCons";
            this.mbtn_GeneralSettings_BSelectTubeCons.Size = new System.Drawing.Size(108, 58);
            this.mbtn_GeneralSettings_BSelectTubeCons.TabIndex = 63;
            this.mbtn_GeneralSettings_BSelectTubeCons.Text = "Select";
            this.mbtn_GeneralSettings_BSelectTubeCons.UseSelectable = true;
            this.mbtn_GeneralSettings_BSelectTubeCons.Click += new System.EventHandler(this.mbtn_GeneralSettings_BSelectTubeCons_Click);
            // 
            // grpRadConsumer
            // 
            this.grpRadConsumer.Controls.Add(this.rad_GeneralSettings_CBHoseConsumer);
            this.grpRadConsumer.Controls.Add(this.rad_GeneralSettings_CBOriginalConsumer);
            this.grpRadConsumer.Location = new System.Drawing.Point(16, 36);
            this.grpRadConsumer.Name = "grpRadConsumer";
            this.grpRadConsumer.Size = new System.Drawing.Size(494, 45);
            this.grpRadConsumer.TabIndex = 109;
            this.grpRadConsumer.TabStop = false;
            // 
            // rad_GeneralSettings_CBHoseConsumer
            // 
            this.rad_GeneralSettings_CBHoseConsumer.AutoSize = true;
            this.rad_GeneralSettings_CBHoseConsumer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rad_GeneralSettings_CBHoseConsumer.Location = new System.Drawing.Point(296, 19);
            this.rad_GeneralSettings_CBHoseConsumer.Name = "rad_GeneralSettings_CBHoseConsumer";
            this.rad_GeneralSettings_CBHoseConsumer.Size = new System.Drawing.Size(165, 24);
            this.rad_GeneralSettings_CBHoseConsumer.TabIndex = 0;
            this.rad_GeneralSettings_CBHoseConsumer.TabStop = true;
            this.rad_GeneralSettings_CBHoseConsumer.Text = "Hose Consumer";
            this.rad_GeneralSettings_CBHoseConsumer.UseVisualStyleBackColor = true;
            this.rad_GeneralSettings_CBHoseConsumer.CheckedChanged += new System.EventHandler(this.rad_GeneralSettings_CBHoseConsumer_CheckedChanged);
            // 
            // rad_GeneralSettings_CBOriginalConsumer
            // 
            this.rad_GeneralSettings_CBOriginalConsumer.AutoSize = true;
            this.rad_GeneralSettings_CBOriginalConsumer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rad_GeneralSettings_CBOriginalConsumer.Location = new System.Drawing.Point(28, 19);
            this.rad_GeneralSettings_CBOriginalConsumer.Name = "rad_GeneralSettings_CBOriginalConsumer";
            this.rad_GeneralSettings_CBOriginalConsumer.Size = new System.Drawing.Size(187, 24);
            this.rad_GeneralSettings_CBOriginalConsumer.TabIndex = 0;
            this.rad_GeneralSettings_CBOriginalConsumer.TabStop = true;
            this.rad_GeneralSettings_CBOriginalConsumer.Text = "Original Consumer";
            this.rad_GeneralSettings_CBOriginalConsumer.UseVisualStyleBackColor = true;
            this.rad_GeneralSettings_CBOriginalConsumer.CheckedChanged += new System.EventHandler(this.rad_GeneralSettings_CBOriginalConsumer_CheckedChanged);
            // 
            // mlbl_tabActParam_GenSettings_ActuationMode
            // 
            this.mlbl_tabActParam_GenSettings_ActuationMode.BackColor = System.Drawing.Color.Black;
            // 
            // 
            // 
            this.mlbl_tabActParam_GenSettings_ActuationMode.CustomButton.Image = null;
            this.mlbl_tabActParam_GenSettings_ActuationMode.CustomButton.Location = new System.Drawing.Point(216, 1);
            this.mlbl_tabActParam_GenSettings_ActuationMode.CustomButton.Name = "";
            this.mlbl_tabActParam_GenSettings_ActuationMode.CustomButton.Size = new System.Drawing.Size(33, 33);
            this.mlbl_tabActParam_GenSettings_ActuationMode.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.mlbl_tabActParam_GenSettings_ActuationMode.CustomButton.TabIndex = 1;
            this.mlbl_tabActParam_GenSettings_ActuationMode.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.mlbl_tabActParam_GenSettings_ActuationMode.CustomButton.UseSelectable = true;
            this.mlbl_tabActParam_GenSettings_ActuationMode.CustomButton.Visible = false;
            this.mlbl_tabActParam_GenSettings_ActuationMode.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.mlbl_tabActParam_GenSettings_ActuationMode.FontWeight = MetroFramework.MetroTextBoxWeight.Bold;
            this.mlbl_tabActParam_GenSettings_ActuationMode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.mlbl_tabActParam_GenSettings_ActuationMode.Lines = new string[] {
        "Actuation Mode"};
            this.mlbl_tabActParam_GenSettings_ActuationMode.Location = new System.Drawing.Point(5, 52);
            this.mlbl_tabActParam_GenSettings_ActuationMode.MaxLength = 32767;
            this.mlbl_tabActParam_GenSettings_ActuationMode.Name = "mlbl_tabActParam_GenSettings_ActuationMode";
            this.mlbl_tabActParam_GenSettings_ActuationMode.PasswordChar = '\0';
            this.mlbl_tabActParam_GenSettings_ActuationMode.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.mlbl_tabActParam_GenSettings_ActuationMode.SelectedText = "";
            this.mlbl_tabActParam_GenSettings_ActuationMode.SelectionLength = 0;
            this.mlbl_tabActParam_GenSettings_ActuationMode.SelectionStart = 0;
            this.mlbl_tabActParam_GenSettings_ActuationMode.ShortcutsEnabled = true;
            this.mlbl_tabActParam_GenSettings_ActuationMode.Size = new System.Drawing.Size(250, 35);
            this.mlbl_tabActParam_GenSettings_ActuationMode.TabIndex = 114;
            this.mlbl_tabActParam_GenSettings_ActuationMode.Text = "Actuation Mode";
            this.mlbl_tabActParam_GenSettings_ActuationMode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mlbl_tabActParam_GenSettings_ActuationMode.UseSelectable = true;
            this.mlbl_tabActParam_GenSettings_ActuationMode.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.mlbl_tabActParam_GenSettings_ActuationMode.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // mpnl_CurrentProject
            // 
            this.mpnl_CurrentProject.Controls.Add(this.mlbl_GeneralSettings_LParGenVacuumMax);
            this.mpnl_CurrentProject.Controls.Add(this.mlbl_GeneralSettings_LParGenVacuumMin);
            this.mpnl_CurrentProject.Controls.Add(this.mlbl_GeneralSettings_LParGenVacuum);
            this.mpnl_CurrentProject.Controls.Add(this.mbtn_GeneralSettings_Plus_EParGenVacuum_Accel_R);
            this.mpnl_CurrentProject.Controls.Add(this.mbtn_GeneralSettings_Minus_EParGenVacuum_Accel_L);
            this.mpnl_CurrentProject.Controls.Add(this.mtxt_GeneralSettings_EParGenVacuumMax);
            this.mpnl_CurrentProject.Controls.Add(this.mtxt_GeneralSettings_EParGenVacuumMin);
            this.mpnl_CurrentProject.Controls.Add(this.mtxt_GeneralSettings_Unit_EParGenVacuumMax);
            this.mpnl_CurrentProject.Controls.Add(this.mtxt_GeneralSettings_Unit_EParGenVacuumMin);
            this.mpnl_CurrentProject.Controls.Add(this.mtxt_GeneralSettings_Unit_EParGenVacuum);
            this.mpnl_CurrentProject.Controls.Add(this.mtxt_GeneralSettings_EParGenVacuum);
            this.mpnl_CurrentProject.Controls.Add(this.mTile_tabActionParam_Vacuum);
            this.mpnl_CurrentProject.HorizontalScrollbarBarColor = true;
            this.mpnl_CurrentProject.HorizontalScrollbarHighlightOnWheel = false;
            this.mpnl_CurrentProject.HorizontalScrollbarSize = 10;
            this.mpnl_CurrentProject.Location = new System.Drawing.Point(0, 385);
            this.mpnl_CurrentProject.Name = "mpnl_CurrentProject";
            this.mpnl_CurrentProject.Size = new System.Drawing.Size(520, 145);
            this.mpnl_CurrentProject.TabIndex = 119;
            this.mpnl_CurrentProject.VerticalScrollbarBarColor = true;
            this.mpnl_CurrentProject.VerticalScrollbarHighlightOnWheel = false;
            this.mpnl_CurrentProject.VerticalScrollbarSize = 10;
            // 
            // mlbl_GeneralSettings_LParGenVacuumMax
            // 
            // 
            // 
            // 
            this.mlbl_GeneralSettings_LParGenVacuumMax.CustomButton.Image = null;
            this.mlbl_GeneralSettings_LParGenVacuumMax.CustomButton.Location = new System.Drawing.Point(189, 2);
            this.mlbl_GeneralSettings_LParGenVacuumMax.CustomButton.Name = "";
            this.mlbl_GeneralSettings_LParGenVacuumMax.CustomButton.Size = new System.Drawing.Size(19, 19);
            this.mlbl_GeneralSettings_LParGenVacuumMax.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.mlbl_GeneralSettings_LParGenVacuumMax.CustomButton.TabIndex = 1;
            this.mlbl_GeneralSettings_LParGenVacuumMax.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.mlbl_GeneralSettings_LParGenVacuumMax.CustomButton.UseSelectable = true;
            this.mlbl_GeneralSettings_LParGenVacuumMax.CustomButton.Visible = false;
            this.mlbl_GeneralSettings_LParGenVacuumMax.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.mlbl_GeneralSettings_LParGenVacuumMax.FontWeight = MetroFramework.MetroTextBoxWeight.Bold;
            this.mlbl_GeneralSettings_LParGenVacuumMax.Lines = new string[] {
        "Vacuum max."};
            this.mlbl_GeneralSettings_LParGenVacuumMax.Location = new System.Drawing.Point(16, 113);
            this.mlbl_GeneralSettings_LParGenVacuumMax.MaxLength = 32767;
            this.mlbl_GeneralSettings_LParGenVacuumMax.Name = "mlbl_GeneralSettings_LParGenVacuumMax";
            this.mlbl_GeneralSettings_LParGenVacuumMax.PasswordChar = '\0';
            this.mlbl_GeneralSettings_LParGenVacuumMax.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.mlbl_GeneralSettings_LParGenVacuumMax.SelectedText = "";
            this.mlbl_GeneralSettings_LParGenVacuumMax.SelectionLength = 0;
            this.mlbl_GeneralSettings_LParGenVacuumMax.SelectionStart = 0;
            this.mlbl_GeneralSettings_LParGenVacuumMax.ShortcutsEnabled = true;
            this.mlbl_GeneralSettings_LParGenVacuumMax.Size = new System.Drawing.Size(211, 24);
            this.mlbl_GeneralSettings_LParGenVacuumMax.TabIndex = 106;
            this.mlbl_GeneralSettings_LParGenVacuumMax.Text = "Vacuum max.";
            this.mlbl_GeneralSettings_LParGenVacuumMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mlbl_GeneralSettings_LParGenVacuumMax.UseSelectable = true;
            this.mlbl_GeneralSettings_LParGenVacuumMax.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.mlbl_GeneralSettings_LParGenVacuumMax.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // mlbl_GeneralSettings_LParGenVacuumMin
            // 
            // 
            // 
            // 
            this.mlbl_GeneralSettings_LParGenVacuumMin.CustomButton.Image = null;
            this.mlbl_GeneralSettings_LParGenVacuumMin.CustomButton.Location = new System.Drawing.Point(189, 2);
            this.mlbl_GeneralSettings_LParGenVacuumMin.CustomButton.Name = "";
            this.mlbl_GeneralSettings_LParGenVacuumMin.CustomButton.Size = new System.Drawing.Size(19, 19);
            this.mlbl_GeneralSettings_LParGenVacuumMin.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.mlbl_GeneralSettings_LParGenVacuumMin.CustomButton.TabIndex = 1;
            this.mlbl_GeneralSettings_LParGenVacuumMin.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.mlbl_GeneralSettings_LParGenVacuumMin.CustomButton.UseSelectable = true;
            this.mlbl_GeneralSettings_LParGenVacuumMin.CustomButton.Visible = false;
            this.mlbl_GeneralSettings_LParGenVacuumMin.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.mlbl_GeneralSettings_LParGenVacuumMin.FontWeight = MetroFramework.MetroTextBoxWeight.Bold;
            this.mlbl_GeneralSettings_LParGenVacuumMin.Lines = new string[] {
        "Vacuum min."};
            this.mlbl_GeneralSettings_LParGenVacuumMin.Location = new System.Drawing.Point(16, 81);
            this.mlbl_GeneralSettings_LParGenVacuumMin.MaxLength = 32767;
            this.mlbl_GeneralSettings_LParGenVacuumMin.Name = "mlbl_GeneralSettings_LParGenVacuumMin";
            this.mlbl_GeneralSettings_LParGenVacuumMin.PasswordChar = '\0';
            this.mlbl_GeneralSettings_LParGenVacuumMin.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.mlbl_GeneralSettings_LParGenVacuumMin.SelectedText = "";
            this.mlbl_GeneralSettings_LParGenVacuumMin.SelectionLength = 0;
            this.mlbl_GeneralSettings_LParGenVacuumMin.SelectionStart = 0;
            this.mlbl_GeneralSettings_LParGenVacuumMin.ShortcutsEnabled = true;
            this.mlbl_GeneralSettings_LParGenVacuumMin.Size = new System.Drawing.Size(211, 24);
            this.mlbl_GeneralSettings_LParGenVacuumMin.TabIndex = 105;
            this.mlbl_GeneralSettings_LParGenVacuumMin.Text = "Vacuum min.";
            this.mlbl_GeneralSettings_LParGenVacuumMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mlbl_GeneralSettings_LParGenVacuumMin.UseSelectable = true;
            this.mlbl_GeneralSettings_LParGenVacuumMin.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.mlbl_GeneralSettings_LParGenVacuumMin.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // mlbl_GeneralSettings_LParGenVacuum
            // 
            // 
            // 
            // 
            this.mlbl_GeneralSettings_LParGenVacuum.CustomButton.Image = null;
            this.mlbl_GeneralSettings_LParGenVacuum.CustomButton.Location = new System.Drawing.Point(189, 2);
            this.mlbl_GeneralSettings_LParGenVacuum.CustomButton.Name = "";
            this.mlbl_GeneralSettings_LParGenVacuum.CustomButton.Size = new System.Drawing.Size(19, 19);
            this.mlbl_GeneralSettings_LParGenVacuum.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.mlbl_GeneralSettings_LParGenVacuum.CustomButton.TabIndex = 1;
            this.mlbl_GeneralSettings_LParGenVacuum.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.mlbl_GeneralSettings_LParGenVacuum.CustomButton.UseSelectable = true;
            this.mlbl_GeneralSettings_LParGenVacuum.CustomButton.Visible = false;
            this.mlbl_GeneralSettings_LParGenVacuum.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.mlbl_GeneralSettings_LParGenVacuum.FontWeight = MetroFramework.MetroTextBoxWeight.Bold;
            this.mlbl_GeneralSettings_LParGenVacuum.Lines = new string[] {
        "Vacuum"};
            this.mlbl_GeneralSettings_LParGenVacuum.Location = new System.Drawing.Point(16, 47);
            this.mlbl_GeneralSettings_LParGenVacuum.MaxLength = 32767;
            this.mlbl_GeneralSettings_LParGenVacuum.Name = "mlbl_GeneralSettings_LParGenVacuum";
            this.mlbl_GeneralSettings_LParGenVacuum.PasswordChar = '\0';
            this.mlbl_GeneralSettings_LParGenVacuum.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.mlbl_GeneralSettings_LParGenVacuum.SelectedText = "";
            this.mlbl_GeneralSettings_LParGenVacuum.SelectionLength = 0;
            this.mlbl_GeneralSettings_LParGenVacuum.SelectionStart = 0;
            this.mlbl_GeneralSettings_LParGenVacuum.ShortcutsEnabled = true;
            this.mlbl_GeneralSettings_LParGenVacuum.Size = new System.Drawing.Size(211, 24);
            this.mlbl_GeneralSettings_LParGenVacuum.TabIndex = 104;
            this.mlbl_GeneralSettings_LParGenVacuum.Text = "Vacuum";
            this.mlbl_GeneralSettings_LParGenVacuum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mlbl_GeneralSettings_LParGenVacuum.UseSelectable = true;
            this.mlbl_GeneralSettings_LParGenVacuum.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.mlbl_GeneralSettings_LParGenVacuum.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // mbtn_GeneralSettings_Plus_EParGenVacuum_Accel_R
            // 
            this.mbtn_GeneralSettings_Plus_EParGenVacuum_Accel_R.Location = new System.Drawing.Point(485, 46);
            this.mbtn_GeneralSettings_Plus_EParGenVacuum_Accel_R.Name = "mbtn_GeneralSettings_Plus_EParGenVacuum_Accel_R";
            this.mbtn_GeneralSettings_Plus_EParGenVacuum_Accel_R.Size = new System.Drawing.Size(25, 25);
            this.mbtn_GeneralSettings_Plus_EParGenVacuum_Accel_R.TabIndex = 51;
            this.mbtn_GeneralSettings_Plus_EParGenVacuum_Accel_R.Text = "+";
            this.mbtn_GeneralSettings_Plus_EParGenVacuum_Accel_R.UseSelectable = true;
            this.mbtn_GeneralSettings_Plus_EParGenVacuum_Accel_R.Click += new System.EventHandler(this.mbtn_GeneralSettings_Plus_EParGenVaccum_Accel_R_Click);
            // 
            // mbtn_GeneralSettings_Minus_EParGenVacuum_Accel_L
            // 
            this.mbtn_GeneralSettings_Minus_EParGenVacuum_Accel_L.Location = new System.Drawing.Point(233, 47);
            this.mbtn_GeneralSettings_Minus_EParGenVacuum_Accel_L.Name = "mbtn_GeneralSettings_Minus_EParGenVacuum_Accel_L";
            this.mbtn_GeneralSettings_Minus_EParGenVacuum_Accel_L.Size = new System.Drawing.Size(25, 25);
            this.mbtn_GeneralSettings_Minus_EParGenVacuum_Accel_L.TabIndex = 54;
            this.mbtn_GeneralSettings_Minus_EParGenVacuum_Accel_L.Text = "-";
            this.mbtn_GeneralSettings_Minus_EParGenVacuum_Accel_L.UseSelectable = true;
            this.mbtn_GeneralSettings_Minus_EParGenVacuum_Accel_L.Click += new System.EventHandler(this.mbtn_GeneralSettings_Minus_EParGenVaccum_Accel_L_Click);
            // 
            // mtxt_GeneralSettings_EParGenVacuumMax
            // 
            // 
            // 
            // 
            this.mtxt_GeneralSettings_EParGenVacuumMax.CustomButton.Image = null;
            this.mtxt_GeneralSettings_EParGenVacuumMax.CustomButton.Location = new System.Drawing.Point(102, 1);
            this.mtxt_GeneralSettings_EParGenVacuumMax.CustomButton.Name = "";
            this.mtxt_GeneralSettings_EParGenVacuumMax.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.mtxt_GeneralSettings_EParGenVacuumMax.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.mtxt_GeneralSettings_EParGenVacuumMax.CustomButton.TabIndex = 1;
            this.mtxt_GeneralSettings_EParGenVacuumMax.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.mtxt_GeneralSettings_EParGenVacuumMax.CustomButton.UseSelectable = true;
            this.mtxt_GeneralSettings_EParGenVacuumMax.CustomButton.Visible = false;
            this.mtxt_GeneralSettings_EParGenVacuumMax.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.mtxt_GeneralSettings_EParGenVacuumMax.Lines = new string[0];
            this.mtxt_GeneralSettings_EParGenVacuumMax.Location = new System.Drawing.Point(264, 113);
            this.mtxt_GeneralSettings_EParGenVacuumMax.MaxLength = 32767;
            this.mtxt_GeneralSettings_EParGenVacuumMax.Name = "mtxt_GeneralSettings_EParGenVacuumMax";
            this.mtxt_GeneralSettings_EParGenVacuumMax.PasswordChar = '\0';
            this.mtxt_GeneralSettings_EParGenVacuumMax.ReadOnly = true;
            this.mtxt_GeneralSettings_EParGenVacuumMax.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.mtxt_GeneralSettings_EParGenVacuumMax.SelectedText = "";
            this.mtxt_GeneralSettings_EParGenVacuumMax.SelectionLength = 0;
            this.mtxt_GeneralSettings_EParGenVacuumMax.SelectionStart = 0;
            this.mtxt_GeneralSettings_EParGenVacuumMax.ShortcutsEnabled = true;
            this.mtxt_GeneralSettings_EParGenVacuumMax.Size = new System.Drawing.Size(126, 25);
            this.mtxt_GeneralSettings_EParGenVacuumMax.TabIndex = 48;
            this.mtxt_GeneralSettings_EParGenVacuumMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mtxt_GeneralSettings_EParGenVacuumMax.UseSelectable = true;
            this.mtxt_GeneralSettings_EParGenVacuumMax.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.mtxt_GeneralSettings_EParGenVacuumMax.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.mtxt_GeneralSettings_EParGenVacuumMax.TextChanged += new System.EventHandler(this.mtxt_GeneralSettings_EParGenVacuumMax_TextChanged);
            // 
            // mtxt_GeneralSettings_EParGenVacuumMin
            // 
            // 
            // 
            // 
            this.mtxt_GeneralSettings_EParGenVacuumMin.CustomButton.Image = null;
            this.mtxt_GeneralSettings_EParGenVacuumMin.CustomButton.Location = new System.Drawing.Point(102, 1);
            this.mtxt_GeneralSettings_EParGenVacuumMin.CustomButton.Name = "";
            this.mtxt_GeneralSettings_EParGenVacuumMin.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.mtxt_GeneralSettings_EParGenVacuumMin.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.mtxt_GeneralSettings_EParGenVacuumMin.CustomButton.TabIndex = 1;
            this.mtxt_GeneralSettings_EParGenVacuumMin.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.mtxt_GeneralSettings_EParGenVacuumMin.CustomButton.UseSelectable = true;
            this.mtxt_GeneralSettings_EParGenVacuumMin.CustomButton.Visible = false;
            this.mtxt_GeneralSettings_EParGenVacuumMin.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.mtxt_GeneralSettings_EParGenVacuumMin.Lines = new string[0];
            this.mtxt_GeneralSettings_EParGenVacuumMin.Location = new System.Drawing.Point(264, 80);
            this.mtxt_GeneralSettings_EParGenVacuumMin.MaxLength = 32767;
            this.mtxt_GeneralSettings_EParGenVacuumMin.Name = "mtxt_GeneralSettings_EParGenVacuumMin";
            this.mtxt_GeneralSettings_EParGenVacuumMin.PasswordChar = '\0';
            this.mtxt_GeneralSettings_EParGenVacuumMin.ReadOnly = true;
            this.mtxt_GeneralSettings_EParGenVacuumMin.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.mtxt_GeneralSettings_EParGenVacuumMin.SelectedText = "";
            this.mtxt_GeneralSettings_EParGenVacuumMin.SelectionLength = 0;
            this.mtxt_GeneralSettings_EParGenVacuumMin.SelectionStart = 0;
            this.mtxt_GeneralSettings_EParGenVacuumMin.ShortcutsEnabled = true;
            this.mtxt_GeneralSettings_EParGenVacuumMin.Size = new System.Drawing.Size(126, 25);
            this.mtxt_GeneralSettings_EParGenVacuumMin.TabIndex = 43;
            this.mtxt_GeneralSettings_EParGenVacuumMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mtxt_GeneralSettings_EParGenVacuumMin.UseSelectable = true;
            this.mtxt_GeneralSettings_EParGenVacuumMin.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.mtxt_GeneralSettings_EParGenVacuumMin.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.mtxt_GeneralSettings_EParGenVacuumMin.TextChanged += new System.EventHandler(this.mtxt_GeneralSettings_EParGenVacuumMin_TextChanged);
            // 
            // mtxt_GeneralSettings_Unit_EParGenVacuumMax
            // 
            this.mtxt_GeneralSettings_Unit_EParGenVacuumMax.BackColor = System.Drawing.SystemColors.Desktop;
            // 
            // 
            // 
            this.mtxt_GeneralSettings_Unit_EParGenVacuumMax.CustomButton.Image = null;
            this.mtxt_GeneralSettings_Unit_EParGenVacuumMax.CustomButton.Location = new System.Drawing.Point(53, 1);
            this.mtxt_GeneralSettings_Unit_EParGenVacuumMax.CustomButton.Name = "";
            this.mtxt_GeneralSettings_Unit_EParGenVacuumMax.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.mtxt_GeneralSettings_Unit_EParGenVacuumMax.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.mtxt_GeneralSettings_Unit_EParGenVacuumMax.CustomButton.TabIndex = 1;
            this.mtxt_GeneralSettings_Unit_EParGenVacuumMax.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.mtxt_GeneralSettings_Unit_EParGenVacuumMax.CustomButton.UseSelectable = true;
            this.mtxt_GeneralSettings_Unit_EParGenVacuumMax.CustomButton.Visible = false;
            this.mtxt_GeneralSettings_Unit_EParGenVacuumMax.Enabled = false;
            this.mtxt_GeneralSettings_Unit_EParGenVacuumMax.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.mtxt_GeneralSettings_Unit_EParGenVacuumMax.Lines = new string[] {
        "bar"};
            this.mtxt_GeneralSettings_Unit_EParGenVacuumMax.Location = new System.Drawing.Point(402, 113);
            this.mtxt_GeneralSettings_Unit_EParGenVacuumMax.MaxLength = 32767;
            this.mtxt_GeneralSettings_Unit_EParGenVacuumMax.Name = "mtxt_GeneralSettings_Unit_EParGenVacuumMax";
            this.mtxt_GeneralSettings_Unit_EParGenVacuumMax.PasswordChar = '\0';
            this.mtxt_GeneralSettings_Unit_EParGenVacuumMax.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.mtxt_GeneralSettings_Unit_EParGenVacuumMax.SelectedText = "";
            this.mtxt_GeneralSettings_Unit_EParGenVacuumMax.SelectionLength = 0;
            this.mtxt_GeneralSettings_Unit_EParGenVacuumMax.SelectionStart = 0;
            this.mtxt_GeneralSettings_Unit_EParGenVacuumMax.ShortcutsEnabled = true;
            this.mtxt_GeneralSettings_Unit_EParGenVacuumMax.Size = new System.Drawing.Size(77, 25);
            this.mtxt_GeneralSettings_Unit_EParGenVacuumMax.TabIndex = 44;
            this.mtxt_GeneralSettings_Unit_EParGenVacuumMax.Text = "bar";
            this.mtxt_GeneralSettings_Unit_EParGenVacuumMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mtxt_GeneralSettings_Unit_EParGenVacuumMax.UseSelectable = true;
            this.mtxt_GeneralSettings_Unit_EParGenVacuumMax.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.mtxt_GeneralSettings_Unit_EParGenVacuumMax.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // mtxt_GeneralSettings_Unit_EParGenVacuumMin
            // 
            this.mtxt_GeneralSettings_Unit_EParGenVacuumMin.BackColor = System.Drawing.SystemColors.Desktop;
            // 
            // 
            // 
            this.mtxt_GeneralSettings_Unit_EParGenVacuumMin.CustomButton.Image = null;
            this.mtxt_GeneralSettings_Unit_EParGenVacuumMin.CustomButton.Location = new System.Drawing.Point(53, 1);
            this.mtxt_GeneralSettings_Unit_EParGenVacuumMin.CustomButton.Name = "";
            this.mtxt_GeneralSettings_Unit_EParGenVacuumMin.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.mtxt_GeneralSettings_Unit_EParGenVacuumMin.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.mtxt_GeneralSettings_Unit_EParGenVacuumMin.CustomButton.TabIndex = 1;
            this.mtxt_GeneralSettings_Unit_EParGenVacuumMin.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.mtxt_GeneralSettings_Unit_EParGenVacuumMin.CustomButton.UseSelectable = true;
            this.mtxt_GeneralSettings_Unit_EParGenVacuumMin.CustomButton.Visible = false;
            this.mtxt_GeneralSettings_Unit_EParGenVacuumMin.Enabled = false;
            this.mtxt_GeneralSettings_Unit_EParGenVacuumMin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.mtxt_GeneralSettings_Unit_EParGenVacuumMin.Lines = new string[] {
        "bar"};
            this.mtxt_GeneralSettings_Unit_EParGenVacuumMin.Location = new System.Drawing.Point(402, 80);
            this.mtxt_GeneralSettings_Unit_EParGenVacuumMin.MaxLength = 32767;
            this.mtxt_GeneralSettings_Unit_EParGenVacuumMin.Name = "mtxt_GeneralSettings_Unit_EParGenVacuumMin";
            this.mtxt_GeneralSettings_Unit_EParGenVacuumMin.PasswordChar = '\0';
            this.mtxt_GeneralSettings_Unit_EParGenVacuumMin.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.mtxt_GeneralSettings_Unit_EParGenVacuumMin.SelectedText = "";
            this.mtxt_GeneralSettings_Unit_EParGenVacuumMin.SelectionLength = 0;
            this.mtxt_GeneralSettings_Unit_EParGenVacuumMin.SelectionStart = 0;
            this.mtxt_GeneralSettings_Unit_EParGenVacuumMin.ShortcutsEnabled = true;
            this.mtxt_GeneralSettings_Unit_EParGenVacuumMin.Size = new System.Drawing.Size(77, 25);
            this.mtxt_GeneralSettings_Unit_EParGenVacuumMin.TabIndex = 45;
            this.mtxt_GeneralSettings_Unit_EParGenVacuumMin.Text = "bar";
            this.mtxt_GeneralSettings_Unit_EParGenVacuumMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mtxt_GeneralSettings_Unit_EParGenVacuumMin.UseSelectable = true;
            this.mtxt_GeneralSettings_Unit_EParGenVacuumMin.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.mtxt_GeneralSettings_Unit_EParGenVacuumMin.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // mtxt_GeneralSettings_Unit_EParGenVacuum
            // 
            this.mtxt_GeneralSettings_Unit_EParGenVacuum.BackColor = System.Drawing.SystemColors.Desktop;
            // 
            // 
            // 
            this.mtxt_GeneralSettings_Unit_EParGenVacuum.CustomButton.Image = null;
            this.mtxt_GeneralSettings_Unit_EParGenVacuum.CustomButton.Location = new System.Drawing.Point(53, 1);
            this.mtxt_GeneralSettings_Unit_EParGenVacuum.CustomButton.Name = "";
            this.mtxt_GeneralSettings_Unit_EParGenVacuum.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.mtxt_GeneralSettings_Unit_EParGenVacuum.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.mtxt_GeneralSettings_Unit_EParGenVacuum.CustomButton.TabIndex = 1;
            this.mtxt_GeneralSettings_Unit_EParGenVacuum.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.mtxt_GeneralSettings_Unit_EParGenVacuum.CustomButton.UseSelectable = true;
            this.mtxt_GeneralSettings_Unit_EParGenVacuum.CustomButton.Visible = false;
            this.mtxt_GeneralSettings_Unit_EParGenVacuum.Enabled = false;
            this.mtxt_GeneralSettings_Unit_EParGenVacuum.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.mtxt_GeneralSettings_Unit_EParGenVacuum.Lines = new string[] {
        "bar"};
            this.mtxt_GeneralSettings_Unit_EParGenVacuum.Location = new System.Drawing.Point(402, 47);
            this.mtxt_GeneralSettings_Unit_EParGenVacuum.MaxLength = 32767;
            this.mtxt_GeneralSettings_Unit_EParGenVacuum.Name = "mtxt_GeneralSettings_Unit_EParGenVacuum";
            this.mtxt_GeneralSettings_Unit_EParGenVacuum.PasswordChar = '\0';
            this.mtxt_GeneralSettings_Unit_EParGenVacuum.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.mtxt_GeneralSettings_Unit_EParGenVacuum.SelectedText = "";
            this.mtxt_GeneralSettings_Unit_EParGenVacuum.SelectionLength = 0;
            this.mtxt_GeneralSettings_Unit_EParGenVacuum.SelectionStart = 0;
            this.mtxt_GeneralSettings_Unit_EParGenVacuum.ShortcutsEnabled = true;
            this.mtxt_GeneralSettings_Unit_EParGenVacuum.Size = new System.Drawing.Size(77, 25);
            this.mtxt_GeneralSettings_Unit_EParGenVacuum.TabIndex = 46;
            this.mtxt_GeneralSettings_Unit_EParGenVacuum.Text = "bar";
            this.mtxt_GeneralSettings_Unit_EParGenVacuum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mtxt_GeneralSettings_Unit_EParGenVacuum.UseSelectable = true;
            this.mtxt_GeneralSettings_Unit_EParGenVacuum.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.mtxt_GeneralSettings_Unit_EParGenVacuum.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // mtxt_GeneralSettings_EParGenVacuum
            // 
            // 
            // 
            // 
            this.mtxt_GeneralSettings_EParGenVacuum.CustomButton.Image = null;
            this.mtxt_GeneralSettings_EParGenVacuum.CustomButton.Location = new System.Drawing.Point(102, 1);
            this.mtxt_GeneralSettings_EParGenVacuum.CustomButton.Name = "";
            this.mtxt_GeneralSettings_EParGenVacuum.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.mtxt_GeneralSettings_EParGenVacuum.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.mtxt_GeneralSettings_EParGenVacuum.CustomButton.TabIndex = 1;
            this.mtxt_GeneralSettings_EParGenVacuum.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.mtxt_GeneralSettings_EParGenVacuum.CustomButton.UseSelectable = true;
            this.mtxt_GeneralSettings_EParGenVacuum.CustomButton.Visible = false;
            this.mtxt_GeneralSettings_EParGenVacuum.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.mtxt_GeneralSettings_EParGenVacuum.Lines = new string[0];
            this.mtxt_GeneralSettings_EParGenVacuum.Location = new System.Drawing.Point(264, 47);
            this.mtxt_GeneralSettings_EParGenVacuum.MaxLength = 32767;
            this.mtxt_GeneralSettings_EParGenVacuum.Name = "mtxt_GeneralSettings_EParGenVacuum";
            this.mtxt_GeneralSettings_EParGenVacuum.PasswordChar = '\0';
            this.mtxt_GeneralSettings_EParGenVacuum.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.mtxt_GeneralSettings_EParGenVacuum.SelectedText = "";
            this.mtxt_GeneralSettings_EParGenVacuum.SelectionLength = 0;
            this.mtxt_GeneralSettings_EParGenVacuum.SelectionStart = 0;
            this.mtxt_GeneralSettings_EParGenVacuum.ShortcutsEnabled = true;
            this.mtxt_GeneralSettings_EParGenVacuum.Size = new System.Drawing.Size(126, 25);
            this.mtxt_GeneralSettings_EParGenVacuum.TabIndex = 47;
            this.mtxt_GeneralSettings_EParGenVacuum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mtxt_GeneralSettings_EParGenVacuum.UseSelectable = true;
            this.mtxt_GeneralSettings_EParGenVacuum.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.mtxt_GeneralSettings_EParGenVacuum.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.mtxt_GeneralSettings_EParGenVacuum.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mtxt_GeneralSettings_EParGenVaccum_KeyPress);
            this.mtxt_GeneralSettings_EParGenVacuum.Leave += new System.EventHandler(this.mtxt_GeneralSettings_EParGenVaccum_Leave);
            // 
            // mTile_tabActionParam_Vacuum
            // 
            this.mTile_tabActionParam_Vacuum.ActiveControl = null;
            this.mTile_tabActionParam_Vacuum.Location = new System.Drawing.Point(0, 0);
            this.mTile_tabActionParam_Vacuum.Name = "mTile_tabActionParam_Vacuum";
            this.mTile_tabActionParam_Vacuum.Size = new System.Drawing.Size(520, 40);
            this.mTile_tabActionParam_Vacuum.Style = MetroFramework.MetroColorStyle.Orange;
            this.mTile_tabActionParam_Vacuum.TabIndex = 21;
            this.mTile_tabActionParam_Vacuum.Text = "Vacuum";
            this.mTile_tabActionParam_Vacuum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.mTile_tabActionParam_Vacuum.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.mTile_tabActionParam_Vacuum.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            this.mTile_tabActionParam_Vacuum.UseSelectable = true;
            // 
            // mcbo_tabActParam_GenSettings_CoBSelectTest
            // 
            this.mcbo_tabActParam_GenSettings_CoBSelectTest.FormattingEnabled = true;
            this.mcbo_tabActParam_GenSettings_CoBSelectTest.ItemHeight = 24;
            this.mcbo_tabActParam_GenSettings_CoBSelectTest.Location = new System.Drawing.Point(5, 94);
            this.mcbo_tabActParam_GenSettings_CoBSelectTest.Margin = new System.Windows.Forms.Padding(2);
            this.mcbo_tabActParam_GenSettings_CoBSelectTest.Name = "mcbo_tabActParam_GenSettings_CoBSelectTest";
            this.mcbo_tabActParam_GenSettings_CoBSelectTest.Size = new System.Drawing.Size(505, 30);
            this.mcbo_tabActParam_GenSettings_CoBSelectTest.Style = MetroFramework.MetroColorStyle.Orange;
            this.mcbo_tabActParam_GenSettings_CoBSelectTest.TabIndex = 55;
            this.mcbo_tabActParam_GenSettings_CoBSelectTest.UseSelectable = true;
            this.mcbo_tabActParam_GenSettings_CoBSelectTest.SelectedIndexChanged += new System.EventHandler(this.mcbo_GeneralSettings_CoBSelectTest_SelectedIndexChanged);
            // 
            // mbtn_tabActParam_GenSettings_BSaveCurrentParams
            // 
            this.mbtn_tabActParam_GenSettings_BSaveCurrentParams.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.mbtn_tabActParam_GenSettings_BSaveCurrentParams.Location = new System.Drawing.Point(5, 337);
            this.mbtn_tabActParam_GenSettings_BSaveCurrentParams.Name = "mbtn_tabActParam_GenSettings_BSaveCurrentParams";
            this.mbtn_tabActParam_GenSettings_BSaveCurrentParams.Size = new System.Drawing.Size(505, 40);
            this.mbtn_tabActParam_GenSettings_BSaveCurrentParams.TabIndex = 68;
            this.mbtn_tabActParam_GenSettings_BSaveCurrentParams.Text = "Save Current Parameters";
            this.mbtn_tabActParam_GenSettings_BSaveCurrentParams.UseSelectable = true;
            this.mbtn_tabActParam_GenSettings_BSaveCurrentParams.Click += new System.EventHandler(this.mbtn_GeneralSettings_BSaveCurrentParams_Click);
            // 
            // mchk_tabActParam_GenSettings_CBStartFromSelection
            // 
            this.mchk_tabActParam_GenSettings_CBStartFromSelection.AutoSize = true;
            this.mchk_tabActParam_GenSettings_CBStartFromSelection.FontSize = MetroFramework.MetroCheckBoxSize.Tall;
            this.mchk_tabActParam_GenSettings_CBStartFromSelection.FontWeight = MetroFramework.MetroCheckBoxWeight.Bold;
            this.mchk_tabActParam_GenSettings_CBStartFromSelection.Location = new System.Drawing.Point(44, 176);
            this.mchk_tabActParam_GenSettings_CBStartFromSelection.Margin = new System.Windows.Forms.Padding(2);
            this.mchk_tabActParam_GenSettings_CBStartFromSelection.Name = "mchk_tabActParam_GenSettings_CBStartFromSelection";
            this.mchk_tabActParam_GenSettings_CBStartFromSelection.Size = new System.Drawing.Size(461, 25);
            this.mchk_tabActParam_GenSettings_CBStartFromSelection.Style = MetroFramework.MetroColorStyle.Orange;
            this.mchk_tabActParam_GenSettings_CBStartFromSelection.TabIndex = 56;
            this.mchk_tabActParam_GenSettings_CBStartFromSelection.Text = "Start From actual selection (NOT from 1 st entry)";
            this.mchk_tabActParam_GenSettings_CBStartFromSelection.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.mchk_tabActParam_GenSettings_CBStartFromSelection.UseCustomBackColor = true;
            this.mchk_tabActParam_GenSettings_CBStartFromSelection.UseCustomForeColor = true;
            this.mchk_tabActParam_GenSettings_CBStartFromSelection.UseSelectable = true;
            this.mchk_tabActParam_GenSettings_CBStartFromSelection.UseStyleColors = true;
            // 
            // mbtn_tabActParam_GenSettings_BLoadAdjSettings
            // 
            this.mbtn_tabActParam_GenSettings_BLoadAdjSettings.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.mbtn_tabActParam_GenSettings_BLoadAdjSettings.Location = new System.Drawing.Point(5, 247);
            this.mbtn_tabActParam_GenSettings_BLoadAdjSettings.Name = "mbtn_tabActParam_GenSettings_BLoadAdjSettings";
            this.mbtn_tabActParam_GenSettings_BLoadAdjSettings.Size = new System.Drawing.Size(505, 40);
            this.mbtn_tabActParam_GenSettings_BLoadAdjSettings.TabIndex = 67;
            this.mbtn_tabActParam_GenSettings_BLoadAdjSettings.Text = "Load Adjustment Settings";
            this.mbtn_tabActParam_GenSettings_BLoadAdjSettings.UseSelectable = true;
            this.mbtn_tabActParam_GenSettings_BLoadAdjSettings.Click += new System.EventHandler(this.mbtn_GeneralSettings_BLoadAdjSettings_Click);
            // 
            // mchk_tabActParam_GenSettings_CBSWaitBetweenTests
            // 
            this.mchk_tabActParam_GenSettings_CBSWaitBetweenTests.AutoSize = true;
            this.mchk_tabActParam_GenSettings_CBSWaitBetweenTests.FontSize = MetroFramework.MetroCheckBoxSize.Tall;
            this.mchk_tabActParam_GenSettings_CBSWaitBetweenTests.FontWeight = MetroFramework.MetroCheckBoxWeight.Bold;
            this.mchk_tabActParam_GenSettings_CBSWaitBetweenTests.Location = new System.Drawing.Point(44, 210);
            this.mchk_tabActParam_GenSettings_CBSWaitBetweenTests.Margin = new System.Windows.Forms.Padding(2);
            this.mchk_tabActParam_GenSettings_CBSWaitBetweenTests.Name = "mchk_tabActParam_GenSettings_CBSWaitBetweenTests";
            this.mchk_tabActParam_GenSettings_CBSWaitBetweenTests.Size = new System.Drawing.Size(406, 25);
            this.mchk_tabActParam_GenSettings_CBSWaitBetweenTests.Style = MetroFramework.MetroColorStyle.Orange;
            this.mchk_tabActParam_GenSettings_CBSWaitBetweenTests.TabIndex = 57;
            this.mchk_tabActParam_GenSettings_CBSWaitBetweenTests.Text = "Wait for user conf. between two single test";
            this.mchk_tabActParam_GenSettings_CBSWaitBetweenTests.Theme = MetroFramework.MetroThemeStyle.Light;
            this.mchk_tabActParam_GenSettings_CBSWaitBetweenTests.UseSelectable = true;
            // 
            // mbtn_tabActParam_GenSettings_BLoadLastestParams
            // 
            this.mbtn_tabActParam_GenSettings_BLoadLastestParams.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.mbtn_tabActParam_GenSettings_BLoadLastestParams.Location = new System.Drawing.Point(5, 292);
            this.mbtn_tabActParam_GenSettings_BLoadLastestParams.Name = "mbtn_tabActParam_GenSettings_BLoadLastestParams";
            this.mbtn_tabActParam_GenSettings_BLoadLastestParams.Size = new System.Drawing.Size(505, 40);
            this.mbtn_tabActParam_GenSettings_BLoadLastestParams.TabIndex = 66;
            this.mbtn_tabActParam_GenSettings_BLoadLastestParams.Text = "Load Last Parameters";
            this.mbtn_tabActParam_GenSettings_BLoadLastestParams.UseSelectable = true;
            this.mbtn_tabActParam_GenSettings_BLoadLastestParams.Click += new System.EventHandler(this.mbtn_GeneralSettings_BLoadLastestParams_Click);
            // 
            // grpOutput
            // 
            this.grpOutput.Controls.Add(this.rad_EvaluationParameters_CBOutputSC);
            this.grpOutput.Controls.Add(this.rad_EvaluationParameters_CBOutputPC);
            this.grpOutput.Location = new System.Drawing.Point(5, 125);
            this.grpOutput.Name = "grpOutput";
            this.grpOutput.Size = new System.Drawing.Size(505, 46);
            this.grpOutput.TabIndex = 110;
            this.grpOutput.TabStop = false;
            this.grpOutput.Visible = false;
            // 
            // rad_EvaluationParameters_CBOutputSC
            // 
            this.rad_EvaluationParameters_CBOutputSC.AutoSize = true;
            this.rad_EvaluationParameters_CBOutputSC.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rad_EvaluationParameters_CBOutputSC.Location = new System.Drawing.Point(307, 19);
            this.rad_EvaluationParameters_CBOutputSC.Name = "rad_EvaluationParameters_CBOutputSC";
            this.rad_EvaluationParameters_CBOutputSC.Size = new System.Drawing.Size(117, 24);
            this.rad_EvaluationParameters_CBOutputSC.TabIndex = 0;
            this.rad_EvaluationParameters_CBOutputSC.TabStop = true;
            this.rad_EvaluationParameters_CBOutputSC.Text = "Output SC";
            this.rad_EvaluationParameters_CBOutputSC.UseVisualStyleBackColor = true;
            this.rad_EvaluationParameters_CBOutputSC.CheckedChanged += new System.EventHandler(this.rad_EvaluationParameters_CBOutputSC_CheckedChanged);
            // 
            // rad_EvaluationParameters_CBOutputPC
            // 
            this.rad_EvaluationParameters_CBOutputPC.AutoSize = true;
            this.rad_EvaluationParameters_CBOutputPC.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rad_EvaluationParameters_CBOutputPC.Location = new System.Drawing.Point(39, 19);
            this.rad_EvaluationParameters_CBOutputPC.Name = "rad_EvaluationParameters_CBOutputPC";
            this.rad_EvaluationParameters_CBOutputPC.Size = new System.Drawing.Size(117, 24);
            this.rad_EvaluationParameters_CBOutputPC.TabIndex = 0;
            this.rad_EvaluationParameters_CBOutputPC.TabStop = true;
            this.rad_EvaluationParameters_CBOutputPC.Text = "Output PC";
            this.rad_EvaluationParameters_CBOutputPC.UseVisualStyleBackColor = true;
            this.rad_EvaluationParameters_CBOutputPC.CheckedChanged += new System.EventHandler(this.rad_EvaluationParameters_CBOutputPC_CheckedChanged);
            // 
            // mPnl_tabActParam_EvaluationParameters
            // 
            this.mPnl_tabActParam_EvaluationParameters.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mPnl_tabActParam_EvaluationParameters.Controls.Add(this.grid_tabActionParam_EvalParam);
            this.mPnl_tabActParam_EvaluationParameters.Controls.Add(this.mTile_tabActParam_EvaluationParameters);
            this.mPnl_tabActParam_EvaluationParameters.HorizontalScrollbarBarColor = true;
            this.mPnl_tabActParam_EvaluationParameters.HorizontalScrollbarHighlightOnWheel = false;
            this.mPnl_tabActParam_EvaluationParameters.HorizontalScrollbarSize = 10;
            this.mPnl_tabActParam_EvaluationParameters.Location = new System.Drawing.Point(530, 162);
            this.mPnl_tabActParam_EvaluationParameters.Name = "mPnl_tabActParam_EvaluationParameters";
            this.mPnl_tabActParam_EvaluationParameters.Size = new System.Drawing.Size(900, 580);
            this.mPnl_tabActParam_EvaluationParameters.TabIndex = 122;
            this.mPnl_tabActParam_EvaluationParameters.VerticalScrollbarBarColor = true;
            this.mPnl_tabActParam_EvaluationParameters.VerticalScrollbarHighlightOnWheel = false;
            this.mPnl_tabActParam_EvaluationParameters.VerticalScrollbarSize = 10;
            // 
            // grid_tabActionParam_EvalParam
            // 
            this.grid_tabActionParam_EvalParam.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_tabActionParam_EvalParam.Location = new System.Drawing.Point(5, 51);
            this.grid_tabActionParam_EvalParam.Name = "grid_tabActionParam_EvalParam";
            this.grid_tabActionParam_EvalParam.RowHeadersWidth = 51;
            this.grid_tabActionParam_EvalParam.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.grid_tabActionParam_EvalParam.Size = new System.Drawing.Size(890, 517);
            this.grid_tabActionParam_EvalParam.TabIndex = 94;
            this.grid_tabActionParam_EvalParam.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_tabActionParam_EvalParam_CellClick);
            this.grid_tabActionParam_EvalParam.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_tabActionParam_EvalParam_CellContentClick);
            this.grid_tabActionParam_EvalParam.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_tabActionParam_EvalParam_CellEndEdit);
            this.grid_tabActionParam_EvalParam.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.grid_tabActionParam_EvalParam_CellPainting);
            // 
            // mTile_tabActParam_EvaluationParameters
            // 
            this.mTile_tabActParam_EvaluationParameters.ActiveControl = null;
            this.mTile_tabActParam_EvaluationParameters.Location = new System.Drawing.Point(0, 0);
            this.mTile_tabActParam_EvaluationParameters.Name = "mTile_tabActParam_EvaluationParameters";
            this.mTile_tabActParam_EvaluationParameters.Size = new System.Drawing.Size(900, 45);
            this.mTile_tabActParam_EvaluationParameters.Style = MetroFramework.MetroColorStyle.Orange;
            this.mTile_tabActParam_EvaluationParameters.TabIndex = 92;
            this.mTile_tabActParam_EvaluationParameters.Text = "Evaluation Parameters";
            this.mTile_tabActParam_EvaluationParameters.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.mTile_tabActParam_EvaluationParameters.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.mTile_tabActParam_EvaluationParameters.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.mTile_tabActParam_EvaluationParameters.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.mTile_tabActParam_EvaluationParameters.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            this.mTile_tabActParam_EvaluationParameters.UseSelectable = true;
            // 
            // mPnl_tabActParam_Actuation
            // 
            this.mPnl_tabActParam_Actuation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mPnl_tabActParam_Actuation.Controls.Add(this.mbtn_Actuation_Plus_E1ParForceGrad_Accel_R);
            this.mPnl_tabActParam_Actuation.Controls.Add(this.mbtn_Actuation_Minus_E1ParForceGrad_Accel_L);
            this.mPnl_tabActParam_Actuation.Controls.Add(this.mbtn_Actuation_Plus_E1ParMaxForce_Accel_R);
            this.mPnl_tabActParam_Actuation.Controls.Add(this.mTile_tabActParam_Actuation);
            this.mPnl_tabActParam_Actuation.Controls.Add(this.mtxt_Actuation_E1ParForceGrad);
            this.mPnl_tabActParam_Actuation.Controls.Add(this.mlbl_Actuation_L1MaxForce);
            this.mPnl_tabActParam_Actuation.Controls.Add(this.mtxt_Actuation_Unit_E1ParForceGrad);
            this.mPnl_tabActParam_Actuation.Controls.Add(this.mlbl_Actuation_L1ForceGradient);
            this.mPnl_tabActParam_Actuation.Controls.Add(this.mbtn_Actuation_Minus_E1ParMaxForce_Accel_L);
            this.mPnl_tabActParam_Actuation.Controls.Add(this.mtxt_Actuation_Unit_E1ParMaxForce);
            this.mPnl_tabActParam_Actuation.Controls.Add(this.mtxt_Actuation_E1ParMaxForce);
            this.mPnl_tabActParam_Actuation.HorizontalScrollbarBarColor = true;
            this.mPnl_tabActParam_Actuation.HorizontalScrollbarHighlightOnWheel = false;
            this.mPnl_tabActParam_Actuation.HorizontalScrollbarSize = 10;
            this.mPnl_tabActParam_Actuation.Location = new System.Drawing.Point(530, 2);
            this.mPnl_tabActParam_Actuation.Name = "mPnl_tabActParam_Actuation";
            this.mPnl_tabActParam_Actuation.Size = new System.Drawing.Size(900, 150);
            this.mPnl_tabActParam_Actuation.TabIndex = 121;
            this.mPnl_tabActParam_Actuation.VerticalScrollbarBarColor = true;
            this.mPnl_tabActParam_Actuation.VerticalScrollbarHighlightOnWheel = false;
            this.mPnl_tabActParam_Actuation.VerticalScrollbarSize = 10;
            // 
            // mbtn_Actuation_Plus_E1ParForceGrad_Accel_R
            // 
            this.mbtn_Actuation_Plus_E1ParForceGrad_Accel_R.Location = new System.Drawing.Point(717, 100);
            this.mbtn_Actuation_Plus_E1ParForceGrad_Accel_R.Name = "mbtn_Actuation_Plus_E1ParForceGrad_Accel_R";
            this.mbtn_Actuation_Plus_E1ParForceGrad_Accel_R.Size = new System.Drawing.Size(35, 35);
            this.mbtn_Actuation_Plus_E1ParForceGrad_Accel_R.TabIndex = 109;
            this.mbtn_Actuation_Plus_E1ParForceGrad_Accel_R.Text = "+";
            this.mbtn_Actuation_Plus_E1ParForceGrad_Accel_R.UseSelectable = true;
            this.mbtn_Actuation_Plus_E1ParForceGrad_Accel_R.Click += new System.EventHandler(this.mbtn_Actuation_Plus_E1ParForceGrad_Accel_R_Click);
            // 
            // mbtn_Actuation_Minus_E1ParForceGrad_Accel_L
            // 
            this.mbtn_Actuation_Minus_E1ParForceGrad_Accel_L.Location = new System.Drawing.Point(448, 101);
            this.mbtn_Actuation_Minus_E1ParForceGrad_Accel_L.Name = "mbtn_Actuation_Minus_E1ParForceGrad_Accel_L";
            this.mbtn_Actuation_Minus_E1ParForceGrad_Accel_L.Size = new System.Drawing.Size(35, 35);
            this.mbtn_Actuation_Minus_E1ParForceGrad_Accel_L.TabIndex = 112;
            this.mbtn_Actuation_Minus_E1ParForceGrad_Accel_L.Text = "-";
            this.mbtn_Actuation_Minus_E1ParForceGrad_Accel_L.UseSelectable = true;
            this.mbtn_Actuation_Minus_E1ParForceGrad_Accel_L.Click += new System.EventHandler(this.mbtn_Actuation_Minus_E1ParForceGrad_Accel_L_Click);
            // 
            // mbtn_Actuation_Plus_E1ParMaxForce_Accel_R
            // 
            this.mbtn_Actuation_Plus_E1ParMaxForce_Accel_R.Location = new System.Drawing.Point(717, 52);
            this.mbtn_Actuation_Plus_E1ParMaxForce_Accel_R.Name = "mbtn_Actuation_Plus_E1ParMaxForce_Accel_R";
            this.mbtn_Actuation_Plus_E1ParMaxForce_Accel_R.Size = new System.Drawing.Size(35, 35);
            this.mbtn_Actuation_Plus_E1ParMaxForce_Accel_R.TabIndex = 111;
            this.mbtn_Actuation_Plus_E1ParMaxForce_Accel_R.Text = "+";
            this.mbtn_Actuation_Plus_E1ParMaxForce_Accel_R.UseSelectable = true;
            this.mbtn_Actuation_Plus_E1ParMaxForce_Accel_R.Click += new System.EventHandler(this.mbtn_Actuation_Plus_E1ParMaxForce_Accel_R_Click);
            // 
            // mTile_tabActParam_Actuation
            // 
            this.mTile_tabActParam_Actuation.ActiveControl = null;
            this.mTile_tabActParam_Actuation.Location = new System.Drawing.Point(0, 0);
            this.mTile_tabActParam_Actuation.Name = "mTile_tabActParam_Actuation";
            this.mTile_tabActParam_Actuation.Size = new System.Drawing.Size(900, 45);
            this.mTile_tabActParam_Actuation.Style = MetroFramework.MetroColorStyle.Orange;
            this.mTile_tabActParam_Actuation.TabIndex = 92;
            this.mTile_tabActParam_Actuation.Text = "Actuation";
            this.mTile_tabActParam_Actuation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.mTile_tabActParam_Actuation.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.mTile_tabActParam_Actuation.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.mTile_tabActParam_Actuation.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.mTile_tabActParam_Actuation.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            this.mTile_tabActParam_Actuation.UseSelectable = true;
            // 
            // mtxt_Actuation_E1ParForceGrad
            // 
            // 
            // 
            // 
            this.mtxt_Actuation_E1ParForceGrad.CustomButton.Image = null;
            this.mtxt_Actuation_E1ParForceGrad.CustomButton.Location = new System.Drawing.Point(95, 1);
            this.mtxt_Actuation_E1ParForceGrad.CustomButton.Name = "";
            this.mtxt_Actuation_E1ParForceGrad.CustomButton.Size = new System.Drawing.Size(33, 33);
            this.mtxt_Actuation_E1ParForceGrad.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.mtxt_Actuation_E1ParForceGrad.CustomButton.TabIndex = 1;
            this.mtxt_Actuation_E1ParForceGrad.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.mtxt_Actuation_E1ParForceGrad.CustomButton.UseSelectable = true;
            this.mtxt_Actuation_E1ParForceGrad.CustomButton.Visible = false;
            this.mtxt_Actuation_E1ParForceGrad.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.mtxt_Actuation_E1ParForceGrad.Lines = new string[0];
            this.mtxt_Actuation_E1ParForceGrad.Location = new System.Drawing.Point(494, 101);
            this.mtxt_Actuation_E1ParForceGrad.MaxLength = 32767;
            this.mtxt_Actuation_E1ParForceGrad.Name = "mtxt_Actuation_E1ParForceGrad";
            this.mtxt_Actuation_E1ParForceGrad.PasswordChar = '\0';
            this.mtxt_Actuation_E1ParForceGrad.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.mtxt_Actuation_E1ParForceGrad.SelectedText = "";
            this.mtxt_Actuation_E1ParForceGrad.SelectionLength = 0;
            this.mtxt_Actuation_E1ParForceGrad.SelectionStart = 0;
            this.mtxt_Actuation_E1ParForceGrad.ShortcutsEnabled = true;
            this.mtxt_Actuation_E1ParForceGrad.Size = new System.Drawing.Size(129, 35);
            this.mtxt_Actuation_E1ParForceGrad.TabIndex = 108;
            this.mtxt_Actuation_E1ParForceGrad.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mtxt_Actuation_E1ParForceGrad.UseSelectable = true;
            this.mtxt_Actuation_E1ParForceGrad.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.mtxt_Actuation_E1ParForceGrad.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.mtxt_Actuation_E1ParForceGrad.TextChanged += new System.EventHandler(this.mtxt_Actuation_E1ParForceGrad_TextChanged);
            this.mtxt_Actuation_E1ParForceGrad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mtxt_Actuation_E1ParForceGrad_KeyPress);
            this.mtxt_Actuation_E1ParForceGrad.Leave += new System.EventHandler(this.mtxt_Actuation_E1ParForceGrad_Leave);
            // 
            // mlbl_Actuation_L1MaxForce
            // 
            // 
            // 
            // 
            this.mlbl_Actuation_L1MaxForce.CustomButton.Image = null;
            this.mlbl_Actuation_L1MaxForce.CustomButton.Location = new System.Drawing.Point(266, 1);
            this.mlbl_Actuation_L1MaxForce.CustomButton.Name = "";
            this.mlbl_Actuation_L1MaxForce.CustomButton.Size = new System.Drawing.Size(33, 33);
            this.mlbl_Actuation_L1MaxForce.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.mlbl_Actuation_L1MaxForce.CustomButton.TabIndex = 1;
            this.mlbl_Actuation_L1MaxForce.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.mlbl_Actuation_L1MaxForce.CustomButton.UseSelectable = true;
            this.mlbl_Actuation_L1MaxForce.CustomButton.Visible = false;
            this.mlbl_Actuation_L1MaxForce.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.mlbl_Actuation_L1MaxForce.FontWeight = MetroFramework.MetroTextBoxWeight.Bold;
            this.mlbl_Actuation_L1MaxForce.Lines = new string[] {
        "Max Force"};
            this.mlbl_Actuation_L1MaxForce.Location = new System.Drawing.Point(128, 53);
            this.mlbl_Actuation_L1MaxForce.MaxLength = 32767;
            this.mlbl_Actuation_L1MaxForce.Name = "mlbl_Actuation_L1MaxForce";
            this.mlbl_Actuation_L1MaxForce.PasswordChar = '\0';
            this.mlbl_Actuation_L1MaxForce.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.mlbl_Actuation_L1MaxForce.SelectedText = "";
            this.mlbl_Actuation_L1MaxForce.SelectionLength = 0;
            this.mlbl_Actuation_L1MaxForce.SelectionStart = 0;
            this.mlbl_Actuation_L1MaxForce.ShortcutsEnabled = true;
            this.mlbl_Actuation_L1MaxForce.Size = new System.Drawing.Size(300, 35);
            this.mlbl_Actuation_L1MaxForce.TabIndex = 102;
            this.mlbl_Actuation_L1MaxForce.Text = "Max Force";
            this.mlbl_Actuation_L1MaxForce.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mlbl_Actuation_L1MaxForce.UseSelectable = true;
            this.mlbl_Actuation_L1MaxForce.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.mlbl_Actuation_L1MaxForce.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // mtxt_Actuation_Unit_E1ParForceGrad
            // 
            this.mtxt_Actuation_Unit_E1ParForceGrad.BackColor = System.Drawing.SystemColors.Desktop;
            // 
            // 
            // 
            this.mtxt_Actuation_Unit_E1ParForceGrad.CustomButton.Image = null;
            this.mtxt_Actuation_Unit_E1ParForceGrad.CustomButton.Location = new System.Drawing.Point(43, 1);
            this.mtxt_Actuation_Unit_E1ParForceGrad.CustomButton.Name = "";
            this.mtxt_Actuation_Unit_E1ParForceGrad.CustomButton.Size = new System.Drawing.Size(33, 33);
            this.mtxt_Actuation_Unit_E1ParForceGrad.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.mtxt_Actuation_Unit_E1ParForceGrad.CustomButton.TabIndex = 1;
            this.mtxt_Actuation_Unit_E1ParForceGrad.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.mtxt_Actuation_Unit_E1ParForceGrad.CustomButton.UseSelectable = true;
            this.mtxt_Actuation_Unit_E1ParForceGrad.CustomButton.Visible = false;
            this.mtxt_Actuation_Unit_E1ParForceGrad.Enabled = false;
            this.mtxt_Actuation_Unit_E1ParForceGrad.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.mtxt_Actuation_Unit_E1ParForceGrad.ForeColor = System.Drawing.Color.White;
            this.mtxt_Actuation_Unit_E1ParForceGrad.Lines = new string[] {
        "N/s"};
            this.mtxt_Actuation_Unit_E1ParForceGrad.Location = new System.Drawing.Point(629, 100);
            this.mtxt_Actuation_Unit_E1ParForceGrad.MaxLength = 32767;
            this.mtxt_Actuation_Unit_E1ParForceGrad.Name = "mtxt_Actuation_Unit_E1ParForceGrad";
            this.mtxt_Actuation_Unit_E1ParForceGrad.PasswordChar = '\0';
            this.mtxt_Actuation_Unit_E1ParForceGrad.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.mtxt_Actuation_Unit_E1ParForceGrad.SelectedText = "";
            this.mtxt_Actuation_Unit_E1ParForceGrad.SelectionLength = 0;
            this.mtxt_Actuation_Unit_E1ParForceGrad.SelectionStart = 0;
            this.mtxt_Actuation_Unit_E1ParForceGrad.ShortcutsEnabled = true;
            this.mtxt_Actuation_Unit_E1ParForceGrad.Size = new System.Drawing.Size(77, 35);
            this.mtxt_Actuation_Unit_E1ParForceGrad.Style = MetroFramework.MetroColorStyle.Orange;
            this.mtxt_Actuation_Unit_E1ParForceGrad.TabIndex = 104;
            this.mtxt_Actuation_Unit_E1ParForceGrad.Text = "N/s";
            this.mtxt_Actuation_Unit_E1ParForceGrad.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mtxt_Actuation_Unit_E1ParForceGrad.Theme = MetroFramework.MetroThemeStyle.Light;
            this.mtxt_Actuation_Unit_E1ParForceGrad.UseSelectable = true;
            this.mtxt_Actuation_Unit_E1ParForceGrad.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.mtxt_Actuation_Unit_E1ParForceGrad.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // mlbl_Actuation_L1ForceGradient
            // 
            // 
            // 
            // 
            this.mlbl_Actuation_L1ForceGradient.CustomButton.Image = null;
            this.mlbl_Actuation_L1ForceGradient.CustomButton.Location = new System.Drawing.Point(266, 1);
            this.mlbl_Actuation_L1ForceGradient.CustomButton.Name = "";
            this.mlbl_Actuation_L1ForceGradient.CustomButton.Size = new System.Drawing.Size(33, 33);
            this.mlbl_Actuation_L1ForceGradient.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.mlbl_Actuation_L1ForceGradient.CustomButton.TabIndex = 1;
            this.mlbl_Actuation_L1ForceGradient.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.mlbl_Actuation_L1ForceGradient.CustomButton.UseSelectable = true;
            this.mlbl_Actuation_L1ForceGradient.CustomButton.Visible = false;
            this.mlbl_Actuation_L1ForceGradient.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.mlbl_Actuation_L1ForceGradient.FontWeight = MetroFramework.MetroTextBoxWeight.Bold;
            this.mlbl_Actuation_L1ForceGradient.Lines = new string[] {
        "Force Gradient"};
            this.mlbl_Actuation_L1ForceGradient.Location = new System.Drawing.Point(128, 101);
            this.mlbl_Actuation_L1ForceGradient.MaxLength = 32767;
            this.mlbl_Actuation_L1ForceGradient.Name = "mlbl_Actuation_L1ForceGradient";
            this.mlbl_Actuation_L1ForceGradient.PasswordChar = '\0';
            this.mlbl_Actuation_L1ForceGradient.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.mlbl_Actuation_L1ForceGradient.SelectedText = "";
            this.mlbl_Actuation_L1ForceGradient.SelectionLength = 0;
            this.mlbl_Actuation_L1ForceGradient.SelectionStart = 0;
            this.mlbl_Actuation_L1ForceGradient.ShortcutsEnabled = true;
            this.mlbl_Actuation_L1ForceGradient.Size = new System.Drawing.Size(300, 35);
            this.mlbl_Actuation_L1ForceGradient.TabIndex = 103;
            this.mlbl_Actuation_L1ForceGradient.Text = "Force Gradient";
            this.mlbl_Actuation_L1ForceGradient.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mlbl_Actuation_L1ForceGradient.UseSelectable = true;
            this.mlbl_Actuation_L1ForceGradient.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.mlbl_Actuation_L1ForceGradient.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // mbtn_Actuation_Minus_E1ParMaxForce_Accel_L
            // 
            this.mbtn_Actuation_Minus_E1ParMaxForce_Accel_L.Location = new System.Drawing.Point(448, 52);
            this.mbtn_Actuation_Minus_E1ParMaxForce_Accel_L.Name = "mbtn_Actuation_Minus_E1ParMaxForce_Accel_L";
            this.mbtn_Actuation_Minus_E1ParMaxForce_Accel_L.Size = new System.Drawing.Size(35, 35);
            this.mbtn_Actuation_Minus_E1ParMaxForce_Accel_L.TabIndex = 113;
            this.mbtn_Actuation_Minus_E1ParMaxForce_Accel_L.Text = "-";
            this.mbtn_Actuation_Minus_E1ParMaxForce_Accel_L.UseSelectable = true;
            this.mbtn_Actuation_Minus_E1ParMaxForce_Accel_L.Click += new System.EventHandler(this.mbtn_Actuation_Minus_E1ParMaxForce_Accel_L_Click);
            // 
            // mtxt_Actuation_Unit_E1ParMaxForce
            // 
            this.mtxt_Actuation_Unit_E1ParMaxForce.BackColor = System.Drawing.SystemColors.Control;
            // 
            // 
            // 
            this.mtxt_Actuation_Unit_E1ParMaxForce.CustomButton.Image = null;
            this.mtxt_Actuation_Unit_E1ParMaxForce.CustomButton.Location = new System.Drawing.Point(43, 1);
            this.mtxt_Actuation_Unit_E1ParMaxForce.CustomButton.Name = "";
            this.mtxt_Actuation_Unit_E1ParMaxForce.CustomButton.Size = new System.Drawing.Size(33, 33);
            this.mtxt_Actuation_Unit_E1ParMaxForce.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.mtxt_Actuation_Unit_E1ParMaxForce.CustomButton.TabIndex = 1;
            this.mtxt_Actuation_Unit_E1ParMaxForce.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.mtxt_Actuation_Unit_E1ParMaxForce.CustomButton.UseSelectable = true;
            this.mtxt_Actuation_Unit_E1ParMaxForce.CustomButton.Visible = false;
            this.mtxt_Actuation_Unit_E1ParMaxForce.Enabled = false;
            this.mtxt_Actuation_Unit_E1ParMaxForce.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.mtxt_Actuation_Unit_E1ParMaxForce.ForeColor = System.Drawing.Color.White;
            this.mtxt_Actuation_Unit_E1ParMaxForce.Lines = new string[] {
        "N"};
            this.mtxt_Actuation_Unit_E1ParMaxForce.Location = new System.Drawing.Point(629, 52);
            this.mtxt_Actuation_Unit_E1ParMaxForce.MaxLength = 32767;
            this.mtxt_Actuation_Unit_E1ParMaxForce.Name = "mtxt_Actuation_Unit_E1ParMaxForce";
            this.mtxt_Actuation_Unit_E1ParMaxForce.PasswordChar = '\0';
            this.mtxt_Actuation_Unit_E1ParMaxForce.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.mtxt_Actuation_Unit_E1ParMaxForce.SelectedText = "";
            this.mtxt_Actuation_Unit_E1ParMaxForce.SelectionLength = 0;
            this.mtxt_Actuation_Unit_E1ParMaxForce.SelectionStart = 0;
            this.mtxt_Actuation_Unit_E1ParMaxForce.ShortcutsEnabled = true;
            this.mtxt_Actuation_Unit_E1ParMaxForce.Size = new System.Drawing.Size(77, 35);
            this.mtxt_Actuation_Unit_E1ParMaxForce.Style = MetroFramework.MetroColorStyle.Orange;
            this.mtxt_Actuation_Unit_E1ParMaxForce.TabIndex = 107;
            this.mtxt_Actuation_Unit_E1ParMaxForce.Text = "N";
            this.mtxt_Actuation_Unit_E1ParMaxForce.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mtxt_Actuation_Unit_E1ParMaxForce.Theme = MetroFramework.MetroThemeStyle.Light;
            this.mtxt_Actuation_Unit_E1ParMaxForce.UseSelectable = true;
            this.mtxt_Actuation_Unit_E1ParMaxForce.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.mtxt_Actuation_Unit_E1ParMaxForce.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // mtxt_Actuation_E1ParMaxForce
            // 
            // 
            // 
            // 
            this.mtxt_Actuation_E1ParMaxForce.CustomButton.Image = null;
            this.mtxt_Actuation_E1ParMaxForce.CustomButton.Location = new System.Drawing.Point(95, 1);
            this.mtxt_Actuation_E1ParMaxForce.CustomButton.Name = "";
            this.mtxt_Actuation_E1ParMaxForce.CustomButton.Size = new System.Drawing.Size(33, 33);
            this.mtxt_Actuation_E1ParMaxForce.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.mtxt_Actuation_E1ParMaxForce.CustomButton.TabIndex = 1;
            this.mtxt_Actuation_E1ParMaxForce.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.mtxt_Actuation_E1ParMaxForce.CustomButton.UseSelectable = true;
            this.mtxt_Actuation_E1ParMaxForce.CustomButton.Visible = false;
            this.mtxt_Actuation_E1ParMaxForce.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.mtxt_Actuation_E1ParMaxForce.Lines = new string[0];
            this.mtxt_Actuation_E1ParMaxForce.Location = new System.Drawing.Point(494, 52);
            this.mtxt_Actuation_E1ParMaxForce.MaxLength = 32767;
            this.mtxt_Actuation_E1ParMaxForce.Name = "mtxt_Actuation_E1ParMaxForce";
            this.mtxt_Actuation_E1ParMaxForce.PasswordChar = '\0';
            this.mtxt_Actuation_E1ParMaxForce.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.mtxt_Actuation_E1ParMaxForce.SelectedText = "";
            this.mtxt_Actuation_E1ParMaxForce.SelectionLength = 0;
            this.mtxt_Actuation_E1ParMaxForce.SelectionStart = 0;
            this.mtxt_Actuation_E1ParMaxForce.ShortcutsEnabled = true;
            this.mtxt_Actuation_E1ParMaxForce.Size = new System.Drawing.Size(129, 35);
            this.mtxt_Actuation_E1ParMaxForce.TabIndex = 106;
            this.mtxt_Actuation_E1ParMaxForce.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mtxt_Actuation_E1ParMaxForce.UseSelectable = true;
            this.mtxt_Actuation_E1ParMaxForce.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.mtxt_Actuation_E1ParMaxForce.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.mtxt_Actuation_E1ParMaxForce.TextChanged += new System.EventHandler(this.mtxt_Actuation_E1ParMaxForce_TextChanged);
            this.mtxt_Actuation_E1ParMaxForce.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mtxt_Actuation_E1ParMaxForce_KeyPress);
            this.mtxt_Actuation_E1ParMaxForce.Leave += new System.EventHandler(this.mtxt_Actuation_E1ParMaxForce_Leave);
            // 
            // tab_TableResults
            // 
            this.tab_TableResults.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tab_TableResults.Controls.Add(this.mpnl_Table_GivingOut);
            this.tab_TableResults.Controls.Add(this.mpnl_Table_Results);
            this.tab_TableResults.Location = new System.Drawing.Point(4, 31);
            this.tab_TableResults.Name = "tab_TableResults";
            this.tab_TableResults.Size = new System.Drawing.Size(1434, 745);
            this.tab_TableResults.TabIndex = 2;
            this.tab_TableResults.Text = "Table";
            this.tab_TableResults.UseVisualStyleBackColor = true;
            // 
            // mpnl_Table_GivingOut
            // 
            this.mpnl_Table_GivingOut.Controls.Add(this.mTile_tabTable_GivingOut);
            this.mpnl_Table_GivingOut.HorizontalScrollbarBarColor = true;
            this.mpnl_Table_GivingOut.HorizontalScrollbarHighlightOnWheel = false;
            this.mpnl_Table_GivingOut.HorizontalScrollbarSize = 10;
            this.mpnl_Table_GivingOut.Location = new System.Drawing.Point(941, 10);
            this.mpnl_Table_GivingOut.Name = "mpnl_Table_GivingOut";
            this.mpnl_Table_GivingOut.Size = new System.Drawing.Size(490, 733);
            this.mpnl_Table_GivingOut.TabIndex = 123;
            this.mpnl_Table_GivingOut.VerticalScrollbarBarColor = true;
            this.mpnl_Table_GivingOut.VerticalScrollbarHighlightOnWheel = false;
            this.mpnl_Table_GivingOut.VerticalScrollbarSize = 10;
            // 
            // mTile_tabTable_GivingOut
            // 
            this.mTile_tabTable_GivingOut.ActiveControl = null;
            this.mTile_tabTable_GivingOut.Location = new System.Drawing.Point(2, 2);
            this.mTile_tabTable_GivingOut.Name = "mTile_tabTable_GivingOut";
            this.mTile_tabTable_GivingOut.Size = new System.Drawing.Size(490, 45);
            this.mTile_tabTable_GivingOut.Style = MetroFramework.MetroColorStyle.Orange;
            this.mTile_tabTable_GivingOut.TabIndex = 92;
            this.mTile_tabTable_GivingOut.Text = "Giving out?";
            this.mTile_tabTable_GivingOut.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.mTile_tabTable_GivingOut.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.mTile_tabTable_GivingOut.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.mTile_tabTable_GivingOut.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.mTile_tabTable_GivingOut.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            this.mTile_tabTable_GivingOut.UseSelectable = true;
            // 
            // mpnl_Table_Results
            // 
            this.mpnl_Table_Results.Controls.Add(this.TAB_TableResult_Grid);
            this.mpnl_Table_Results.Controls.Add(this.mTile_tabTable_Results);
            this.mpnl_Table_Results.HorizontalScrollbarBarColor = true;
            this.mpnl_Table_Results.HorizontalScrollbarHighlightOnWheel = false;
            this.mpnl_Table_Results.HorizontalScrollbarSize = 10;
            this.mpnl_Table_Results.Location = new System.Drawing.Point(15, 10);
            this.mpnl_Table_Results.Name = "mpnl_Table_Results";
            this.mpnl_Table_Results.Size = new System.Drawing.Size(920, 733);
            this.mpnl_Table_Results.TabIndex = 122;
            this.mpnl_Table_Results.VerticalScrollbarBarColor = true;
            this.mpnl_Table_Results.VerticalScrollbarHighlightOnWheel = false;
            this.mpnl_Table_Results.VerticalScrollbarSize = 10;
            // 
            // TAB_TableResult_Grid
            // 
            this.TAB_TableResult_Grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TAB_TableResult_Grid.Location = new System.Drawing.Point(2, 50);
            this.TAB_TableResult_Grid.Name = "TAB_TableResult_Grid";
            this.TAB_TableResult_Grid.RowHeadersWidth = 51;
            this.TAB_TableResult_Grid.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.TAB_TableResult_Grid.Size = new System.Drawing.Size(920, 680);
            this.TAB_TableResult_Grid.TabIndex = 93;
            this.TAB_TableResult_Grid.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.TAB_TableResult_Grid_CellEndEdit);
            this.TAB_TableResult_Grid.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.TAB_TableResult_Grid_DataError);
            // 
            // mTile_tabTable_Results
            // 
            this.mTile_tabTable_Results.ActiveControl = null;
            this.mTile_tabTable_Results.Location = new System.Drawing.Point(2, 2);
            this.mTile_tabTable_Results.Name = "mTile_tabTable_Results";
            this.mTile_tabTable_Results.Size = new System.Drawing.Size(920, 45);
            this.mTile_tabTable_Results.Style = MetroFramework.MetroColorStyle.Orange;
            this.mTile_tabTable_Results.TabIndex = 92;
            this.mTile_tabTable_Results.Text = "Results";
            this.mTile_tabTable_Results.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.mTile_tabTable_Results.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.mTile_tabTable_Results.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.mTile_tabTable_Results.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.mTile_tabTable_Results.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            this.mTile_tabTable_Results.UseSelectable = true;
            // 
            // tab_Diagram
            // 
            this.tab_Diagram.BackColor = System.Drawing.Color.LightGray;
            this.tab_Diagram.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tab_Diagram.Controls.Add(this.devChart);
            this.tab_Diagram.Controls.Add(this.mTile_tabDiagram_GraphicalDisplay);
            this.tab_Diagram.Location = new System.Drawing.Point(4, 31);
            this.tab_Diagram.Name = "tab_Diagram";
            this.tab_Diagram.Padding = new System.Windows.Forms.Padding(3);
            this.tab_Diagram.Size = new System.Drawing.Size(1434, 745);
            this.tab_Diagram.TabIndex = 0;
            this.tab_Diagram.Text = "Diagram";
            // 
            // devChart
            // 
            this.devChart.Location = new System.Drawing.Point(324, 49);
            this.devChart.Name = "devChart";
            this.devChart.SeriesSerializable = new DevExpress.XtraCharts.Series[0];
            this.devChart.Size = new System.Drawing.Size(800, 668);
            this.devChart.TabIndex = 131;
            // 
            // mTile_tabDiagram_GraphicalDisplay
            // 
            this.mTile_tabDiagram_GraphicalDisplay.ActiveControl = null;
            this.mTile_tabDiagram_GraphicalDisplay.Location = new System.Drawing.Point(2, 2);
            this.mTile_tabDiagram_GraphicalDisplay.Name = "mTile_tabDiagram_GraphicalDisplay";
            this.mTile_tabDiagram_GraphicalDisplay.Size = new System.Drawing.Size(1437, 45);
            this.mTile_tabDiagram_GraphicalDisplay.Style = MetroFramework.MetroColorStyle.Orange;
            this.mTile_tabDiagram_GraphicalDisplay.TabIndex = 25;
            this.mTile_tabDiagram_GraphicalDisplay.Text = "Graphical display";
            this.mTile_tabDiagram_GraphicalDisplay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.mTile_tabDiagram_GraphicalDisplay.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.mTile_tabDiagram_GraphicalDisplay.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.mTile_tabDiagram_GraphicalDisplay.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            this.mTile_tabDiagram_GraphicalDisplay.UseSelectable = true;
            // 
            // TAB_Main
            // 
            this.TAB_Main.Controls.Add(this.tab_Diagram);
            this.TAB_Main.Controls.Add(this.tab_TableResults);
            this.TAB_Main.Controls.Add(this.Tab_ActuationParameters);
            this.TAB_Main.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TAB_Main.Location = new System.Drawing.Point(5, 215);
            this.TAB_Main.Name = "TAB_Main";
            this.TAB_Main.SelectedIndex = 0;
            this.TAB_Main.Size = new System.Drawing.Size(1442, 780);
            this.TAB_Main.TabIndex = 32;
            this.TAB_Main.SelectedIndexChanged += new System.EventHandler(this.TAB_Main_SelectedIndexChanged);
            this.TAB_Main.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.TAB_Main_Selecting);
            // 
            // bgWorker
            // 
            this.bgWorker.WorkerReportsProgress = true;
            this.bgWorker.WorkerSupportsCancellation = true;
            this.bgWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWorker_DoWork);
            this.bgWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgWorker_ProgressChanged);
            this.bgWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgWorker_RunWorkerCompleted);
            // 
            // timerDateTime
            // 
            this.timerDateTime.Enabled = true;
            this.timerDateTime.Interval = 1000;
            this.timerDateTime.Tick += new System.EventHandler(this.timerDateTime_Tick);
            // 
            // stsBar_STBMain
            // 
            this.stsBar_STBMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.stsBar_STBMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tStatusLabel01,
            this.tStatusLabel02,
            this.tStatusLabel03,
            this.tStatusLabel04});
            this.stsBar_STBMain.Location = new System.Drawing.Point(0, 1050);
            this.stsBar_STBMain.Name = "stsBar_STBMain";
            this.stsBar_STBMain.Size = new System.Drawing.Size(1920, 30);
            this.stsBar_STBMain.TabIndex = 126;
            this.stsBar_STBMain.Text = "statusStrip1";
            // 
            // tStatusLabel01
            // 
            this.tStatusLabel01.BackColor = System.Drawing.Color.Transparent;
            this.tStatusLabel01.Name = "tStatusLabel01";
            this.tStatusLabel01.Size = new System.Drawing.Size(106, 24);
            this.tStatusLabel01.Text = "tStatusLabel01";
            // 
            // tStatusLabel02
            // 
            this.tStatusLabel02.BackColor = System.Drawing.Color.Transparent;
            this.tStatusLabel02.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.tStatusLabel02.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.tStatusLabel02.Name = "tStatusLabel02";
            this.tStatusLabel02.Size = new System.Drawing.Size(145, 24);
            this.tStatusLabel02.Text = "tStatusLabel02_User";
            // 
            // tStatusLabel03
            // 
            this.tStatusLabel03.BackColor = System.Drawing.Color.Transparent;
            this.tStatusLabel03.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.tStatusLabel03.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.tStatusLabel03.Name = "tStatusLabel03";
            this.tStatusLabel03.Size = new System.Drawing.Size(110, 24);
            this.tStatusLabel03.Text = "tStatusLabel03";
            // 
            // tStatusLabel04
            // 
            this.tStatusLabel04.BackColor = System.Drawing.Color.Transparent;
            this.tStatusLabel04.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.tStatusLabel04.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.tStatusLabel04.Name = "tStatusLabel04";
            this.tStatusLabel04.Size = new System.Drawing.Size(152, 24);
            this.tStatusLabel04.Text = "tStatusLabel04_Clock";
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemToolStrip_Home,
            this.menuItemToolStrip_Project,
            this.menuItemToolStrip_TestProgram,
            this.menuItemToolStrip_Settings});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(3, 1, 0, 1);
            this.menuStrip.Size = new System.Drawing.Size(1920, 26);
            this.menuStrip.TabIndex = 125;
            this.menuStrip.Text = "menuStrip";
            // 
            // menuItemToolStrip_Home
            // 
            this.menuItemToolStrip_Home.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.subMenu_Home_Logout,
            this.subMenu_Home_Exit,
            this.toolStripSeparator6,
            this.subMenu_Home_About});
            this.menuItemToolStrip_Home.Name = "menuItemToolStrip_Home";
            this.menuItemToolStrip_Home.Size = new System.Drawing.Size(66, 24);
            this.menuItemToolStrip_Home.Text = "HOME";
            // 
            // subMenu_Home_Logout
            // 
            this.subMenu_Home_Logout.Name = "subMenu_Home_Logout";
            this.subMenu_Home_Logout.Size = new System.Drawing.Size(139, 26);
            this.subMenu_Home_Logout.Text = "Logout";
            this.subMenu_Home_Logout.Visible = false;
            this.subMenu_Home_Logout.Click += new System.EventHandler(this.subMenu_Home_Logout_Click);
            // 
            // subMenu_Home_Exit
            // 
            this.subMenu_Home_Exit.Name = "subMenu_Home_Exit";
            this.subMenu_Home_Exit.Size = new System.Drawing.Size(139, 26);
            this.subMenu_Home_Exit.Text = "Exit";
            this.subMenu_Home_Exit.Click += new System.EventHandler(this.subMenu_Home_Exit_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(136, 6);
            // 
            // subMenu_Home_About
            // 
            this.subMenu_Home_About.Name = "subMenu_Home_About";
            this.subMenu_Home_About.Size = new System.Drawing.Size(139, 26);
            this.subMenu_Home_About.Text = "About";
            this.subMenu_Home_About.Click += new System.EventHandler(this.subMenu_Home_About_Click);
            // 
            // menuItemToolStrip_Project
            // 
            this.menuItemToolStrip_Project.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.subMenu_Project_Project,
            this.toolStripSeparator1,
            this.subMenu_Project_PrintGraphics,
            this.subMenu_Project_PrintParamList,
            this.subMenu_Project_SetupPrinter,
            this.toolStripSeparator2,
            this.subMenu_Project_ExportExcel});
            this.menuItemToolStrip_Project.Enabled = false;
            this.menuItemToolStrip_Project.Name = "menuItemToolStrip_Project";
            this.menuItemToolStrip_Project.ShortcutKeyDisplayString = "";
            this.menuItemToolStrip_Project.Size = new System.Drawing.Size(81, 24);
            this.menuItemToolStrip_Project.Text = "PROJECT";
            // 
            // subMenu_Project_Project
            // 
            this.subMenu_Project_Project.Name = "subMenu_Project_Project";
            this.subMenu_Project_Project.ShortcutKeyDisplayString = "";
            this.subMenu_Project_Project.Size = new System.Drawing.Size(225, 26);
            this.subMenu_Project_Project.Text = "Project";
            this.subMenu_Project_Project.Click += new System.EventHandler(this.subMenu_Project_Project_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(222, 6);
            // 
            // subMenu_Project_PrintGraphics
            // 
            this.subMenu_Project_PrintGraphics.Name = "subMenu_Project_PrintGraphics";
            this.subMenu_Project_PrintGraphics.Size = new System.Drawing.Size(225, 26);
            this.subMenu_Project_PrintGraphics.Text = "Print Graphics";
            this.subMenu_Project_PrintGraphics.Click += new System.EventHandler(this.subMenu_Project_PrintGraphics_Click);
            // 
            // subMenu_Project_PrintParamList
            // 
            this.subMenu_Project_PrintParamList.Name = "subMenu_Project_PrintParamList";
            this.subMenu_Project_PrintParamList.Size = new System.Drawing.Size(225, 26);
            this.subMenu_Project_PrintParamList.Text = "Print Parameters List";
            this.subMenu_Project_PrintParamList.Click += new System.EventHandler(this.subMenu_Project_PrintParamList_Click);
            // 
            // subMenu_Project_SetupPrinter
            // 
            this.subMenu_Project_SetupPrinter.Name = "subMenu_Project_SetupPrinter";
            this.subMenu_Project_SetupPrinter.Size = new System.Drawing.Size(225, 26);
            this.subMenu_Project_SetupPrinter.Text = "Setup Printer";
            this.subMenu_Project_SetupPrinter.Click += new System.EventHandler(this.subMenu_Project_SetupPrinter_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(222, 6);
            // 
            // subMenu_Project_ExportExcel
            // 
            this.subMenu_Project_ExportExcel.Name = "subMenu_Project_ExportExcel";
            this.subMenu_Project_ExportExcel.Size = new System.Drawing.Size(225, 26);
            this.subMenu_Project_ExportExcel.Text = "Export -> MS Excel";
            this.subMenu_Project_ExportExcel.Click += new System.EventHandler(this.subMenu_Project_ExportExcel_Click);
            // 
            // menuItemToolStrip_TestProgram
            // 
            this.menuItemToolStrip_TestProgram.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.subMenu_TestProg_SelectTestProgram,
            this.toolStripSeparator3,
            this.subMenu_TestProg_Start,
            this.subMenu_TestProg_STop,
            this.toolStripSeparator4,
            this.subMenu_TestProg_CreateUserDefinedTest,
            this.toolStripSeparator5,
            this.subMenu_TestProg_ManualActuation,
            this.subMenu_TestProg_Calibration,
            this.toolStripSeparator8,
            this.subMenu_TestProg_Bleed,
            this.subMenu_TestProg_SaveTest});
            this.menuItemToolStrip_TestProgram.Enabled = false;
            this.menuItemToolStrip_TestProgram.Name = "menuItemToolStrip_TestProgram";
            this.menuItemToolStrip_TestProgram.Size = new System.Drawing.Size(129, 24);
            this.menuItemToolStrip_TestProgram.Text = "TEST PROGRAM";
            // 
            // subMenu_TestProg_SelectTestProgram
            // 
            this.subMenu_TestProg_SelectTestProgram.Name = "subMenu_TestProg_SelectTestProgram";
            this.subMenu_TestProg_SelectTestProgram.Size = new System.Drawing.Size(255, 26);
            this.subMenu_TestProg_SelectTestProgram.Text = "Select Test Program";
            this.subMenu_TestProg_SelectTestProgram.Click += new System.EventHandler(this.subMenu_TestProg_SelectTestProgram_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(252, 6);
            // 
            // subMenu_TestProg_Start
            // 
            this.subMenu_TestProg_Start.Name = "subMenu_TestProg_Start";
            this.subMenu_TestProg_Start.Size = new System.Drawing.Size(255, 26);
            this.subMenu_TestProg_Start.Text = "Start";
            this.subMenu_TestProg_Start.Click += new System.EventHandler(this.subMenu_TestProg_Start_Click);
            // 
            // subMenu_TestProg_STop
            // 
            this.subMenu_TestProg_STop.Name = "subMenu_TestProg_STop";
            this.subMenu_TestProg_STop.Size = new System.Drawing.Size(255, 26);
            this.subMenu_TestProg_STop.Text = "Stop";
            this.subMenu_TestProg_STop.Click += new System.EventHandler(this.subMenu_TestProg_STop_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(252, 6);
            // 
            // subMenu_TestProg_CreateUserDefinedTest
            // 
            this.subMenu_TestProg_CreateUserDefinedTest.Name = "subMenu_TestProg_CreateUserDefinedTest";
            this.subMenu_TestProg_CreateUserDefinedTest.Size = new System.Drawing.Size(255, 26);
            this.subMenu_TestProg_CreateUserDefinedTest.Text = "Create User Defined Test";
            this.subMenu_TestProg_CreateUserDefinedTest.Click += new System.EventHandler(this.subMenu_TestProg_CreateUserDefinedTest_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(252, 6);
            // 
            // subMenu_TestProg_ManualActuation
            // 
            this.subMenu_TestProg_ManualActuation.Name = "subMenu_TestProg_ManualActuation";
            this.subMenu_TestProg_ManualActuation.Size = new System.Drawing.Size(255, 26);
            this.subMenu_TestProg_ManualActuation.Text = "Manual Actuation";
            this.subMenu_TestProg_ManualActuation.Click += new System.EventHandler(this.subMenu_TestProg_ManualActuation_Click);
            // 
            // subMenu_TestProg_Calibration
            // 
            this.subMenu_TestProg_Calibration.Name = "subMenu_TestProg_Calibration";
            this.subMenu_TestProg_Calibration.Size = new System.Drawing.Size(255, 26);
            this.subMenu_TestProg_Calibration.Text = "Calibration";
            this.subMenu_TestProg_Calibration.Click += new System.EventHandler(this.subMenu_TestProg_Calibration_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(252, 6);
            // 
            // subMenu_TestProg_Bleed
            // 
            this.subMenu_TestProg_Bleed.Name = "subMenu_TestProg_Bleed";
            this.subMenu_TestProg_Bleed.Size = new System.Drawing.Size(255, 26);
            this.subMenu_TestProg_Bleed.Text = "Bleed (Fillup) / Drain";
            this.subMenu_TestProg_Bleed.Click += new System.EventHandler(this.subMenu_TestProg_Bleed_Click);
            // 
            // subMenu_TestProg_SaveTest
            // 
            this.subMenu_TestProg_SaveTest.Name = "subMenu_TestProg_SaveTest";
            this.subMenu_TestProg_SaveTest.Size = new System.Drawing.Size(255, 26);
            this.subMenu_TestProg_SaveTest.Text = "Save Test";
            this.subMenu_TestProg_SaveTest.Click += new System.EventHandler(this.subMenu_TestProg_SaveTest_Click);
            // 
            // menuItemToolStrip_Settings
            // 
            this.menuItemToolStrip_Settings.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.subMenu_Settings_SoftwareMaintenance,
            this.toolStripSeparator9,
            this.subMenu_Settings_Account});
            this.menuItemToolStrip_Settings.Enabled = false;
            this.menuItemToolStrip_Settings.Name = "menuItemToolStrip_Settings";
            this.menuItemToolStrip_Settings.Size = new System.Drawing.Size(88, 24);
            this.menuItemToolStrip_Settings.Text = "SETTINGS";
            // 
            // subMenu_Settings_SoftwareMaintenance
            // 
            this.subMenu_Settings_SoftwareMaintenance.Name = "subMenu_Settings_SoftwareMaintenance";
            this.subMenu_Settings_SoftwareMaintenance.Size = new System.Drawing.Size(240, 26);
            this.subMenu_Settings_SoftwareMaintenance.Text = "Software Maintenance";
            this.subMenu_Settings_SoftwareMaintenance.Click += new System.EventHandler(this.subMenu_Settings_SoftwareMaintenance_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(237, 6);
            // 
            // subMenu_Settings_Account
            // 
            this.subMenu_Settings_Account.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.subMenu_Account_SelectAccessLevel,
            this.toolStripSeparator10,
            this.subMenu_Account_NewPassword,
            this.toolStripSeparator11,
            this.subMenu_Account_UserAdd,
            this.subMenu_Account_UserEdit,
            this.subMenu_Account_UserDelete,
            this.subMenu_Account_UserReport});
            this.subMenu_Settings_Account.Name = "subMenu_Settings_Account";
            this.subMenu_Settings_Account.Size = new System.Drawing.Size(240, 26);
            this.subMenu_Settings_Account.Text = "USER";
            // 
            // subMenu_Account_SelectAccessLevel
            // 
            this.subMenu_Account_SelectAccessLevel.Name = "subMenu_Account_SelectAccessLevel";
            this.subMenu_Account_SelectAccessLevel.Size = new System.Drawing.Size(225, 26);
            this.subMenu_Account_SelectAccessLevel.Text = "Select Access Level";
            this.subMenu_Account_SelectAccessLevel.Click += new System.EventHandler(this.subMenu_Account_SelectAccessLevel_Click);
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(222, 6);
            // 
            // subMenu_Account_NewPassword
            // 
            this.subMenu_Account_NewPassword.Name = "subMenu_Account_NewPassword";
            this.subMenu_Account_NewPassword.Size = new System.Drawing.Size(225, 26);
            this.subMenu_Account_NewPassword.Text = "New Password";
            this.subMenu_Account_NewPassword.Click += new System.EventHandler(this.subMenu_Account_NewPassword_Click);
            // 
            // toolStripSeparator11
            // 
            this.toolStripSeparator11.Name = "toolStripSeparator11";
            this.toolStripSeparator11.Size = new System.Drawing.Size(222, 6);
            // 
            // subMenu_Account_UserAdd
            // 
            this.subMenu_Account_UserAdd.Name = "subMenu_Account_UserAdd";
            this.subMenu_Account_UserAdd.Size = new System.Drawing.Size(225, 26);
            this.subMenu_Account_UserAdd.Text = "toolStripMenuItem1";
            // 
            // subMenu_Account_UserEdit
            // 
            this.subMenu_Account_UserEdit.Name = "subMenu_Account_UserEdit";
            this.subMenu_Account_UserEdit.Size = new System.Drawing.Size(225, 26);
            this.subMenu_Account_UserEdit.Text = "toolStripMenuItem1";
            // 
            // subMenu_Account_UserDelete
            // 
            this.subMenu_Account_UserDelete.Name = "subMenu_Account_UserDelete";
            this.subMenu_Account_UserDelete.Size = new System.Drawing.Size(225, 26);
            this.subMenu_Account_UserDelete.Text = "toolStripMenuItem1";
            // 
            // subMenu_Account_UserReport
            // 
            this.subMenu_Account_UserReport.Name = "subMenu_Account_UserReport";
            this.subMenu_Account_UserReport.Size = new System.Drawing.Size(225, 26);
            this.subMenu_Account_UserReport.Text = "toolStripMenuItem1";
            // 
            // printDialog
            // 
            this.printDialog.UseEXDialog = true;
            // 
            // mpnl_HeaderInfoAnalogInputVisu
            // 
            this.mpnl_HeaderInfoAnalogInputVisu.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.mpnl_HeaderInfoAnalogInputVisu.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.mpnl_HeaderInfoAnalogInputVisu.HorizontalScrollbarBarColor = true;
            this.mpnl_HeaderInfoAnalogInputVisu.HorizontalScrollbarHighlightOnWheel = false;
            this.mpnl_HeaderInfoAnalogInputVisu.HorizontalScrollbarSize = 10;
            this.mpnl_HeaderInfoAnalogInputVisu.Location = new System.Drawing.Point(71, 132);
            this.mpnl_HeaderInfoAnalogInputVisu.Name = "mpnl_HeaderInfoAnalogInputVisu";
            this.mpnl_HeaderInfoAnalogInputVisu.Size = new System.Drawing.Size(1894, 79);
            this.mpnl_HeaderInfoAnalogInputVisu.TabIndex = 85;
            this.mpnl_HeaderInfoAnalogInputVisu.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.mpnl_HeaderInfoAnalogInputVisu.VerticalScrollbarBarColor = true;
            this.mpnl_HeaderInfoAnalogInputVisu.VerticalScrollbarHighlightOnWheel = false;
            this.mpnl_HeaderInfoAnalogInputVisu.VerticalScrollbarSize = 10;
            // 
            // Form_Adam_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.ControlBox = false;
            this.Controls.Add(this.stsBar_STBMain);
            this.Controls.Add(this.menuStrip);
            this.Controls.Add(this.mpnl_HeaderInfoAnalogInputVisu);
            this.Controls.Add(this.mpnl_Eventlog);
            this.Controls.Add(this.mpnl_Buttons);
            this.Controls.Add(this.lst_MemoEventLog);
            this.Controls.Add(this.TAB_Main);
            this.Controls.Add(this.mpnl_HeaderInfoAnalogInput);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1920, 1080);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1918, 1028);
            this.Name = "Form_Adam_Main";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Continental - ADAM Functional Test Bench";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form_Adam_Main_Load);
            this.Shown += new System.EventHandler(this.Form_Adam_Main_Shown);
            this.mpnl_HeaderInfoAnalogInput.ResumeLayout(false);
            this.mpnl_HeaderInfoAnalogInput.PerformLayout();
            this.mpnl_Buttons.ResumeLayout(false);
            this.mpnl_Eventlog.ResumeLayout(false);
            this.metroPanel5.ResumeLayout(false);
            this.Tab_ActuationParameters.ResumeLayout(false);
            this.mPnl_tabActParam_GenralSettings.ResumeLayout(false);
            this.mPnl_tabActParam_GenralSettings.PerformLayout();
            this.metroPanel1.ResumeLayout(false);
            this.grpRadConsumer.ResumeLayout(false);
            this.grpRadConsumer.PerformLayout();
            this.mpnl_CurrentProject.ResumeLayout(false);
            this.grpOutput.ResumeLayout(false);
            this.grpOutput.PerformLayout();
            this.mPnl_tabActParam_EvaluationParameters.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grid_tabActionParam_EvalParam)).EndInit();
            this.mPnl_tabActParam_Actuation.ResumeLayout(false);
            this.tab_TableResults.ResumeLayout(false);
            this.mpnl_Table_GivingOut.ResumeLayout(false);
            this.mpnl_Table_Results.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TAB_TableResult_Grid)).EndInit();
            this.tab_Diagram.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.devChart)).EndInit();
            this.TAB_Main.ResumeLayout(false);
            this.stsBar_STBMain.ResumeLayout(false);
            this.stsBar_STBMain.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MetroFramework.Controls.MetroTile mTile_LCurrentSelectedTest;
        private MetroFramework.Controls.MetroTextBox mtxt_MKSLRoomTemp;
        private MetroFramework.Controls.MetroTextBox mtxt_MKSLHumidity;
        private MetroFramework.Controls.MetroTextBox mtxt_MKSLPneumTestPressure;
        private MetroFramework.Controls.MetroTextBox mtxt_MKSLHydrFillPressure;
        private MetroFramework.Controls.MetroTextBox mtxt_MKSLPressureSC;
        private MetroFramework.Controls.MetroTextBox mtxt_MKSLPressurePC;
        private MetroFramework.Controls.MetroTextBox mtxt_MKSLTravelTMC;
        private MetroFramework.Controls.MetroTextBox mtxt_MKSLTravelPiston;
        private MetroFramework.Controls.MetroTextBox mtxt_MKSLDiffTravel;
        private MetroFramework.Controls.MetroTextBox mtxt_MKSLOutputForce;
        private MetroFramework.Controls.MetroTextBox mtxt_MKSLInputForce1;
        private System.Windows.Forms.ListBox lst_MemoEventLog;
        private MetroFramework.Controls.MetroButton mbtn_BGlobalWarning;
        private MetroFramework.Controls.MetroButton mbtn_BReportPDF;
        private MetroFramework.Controls.MetroButton mtbn_BExportTestToXLS;
        private MetroFramework.Controls.MetroButton mbtn_BRecordStart;
        private MetroFramework.Controls.MetroButton mbtn_BStart;
        private MetroFramework.Controls.MetroButton mbtn_BStop;
        private System.Windows.Forms.Label lbl_InputForce1;
        private System.Windows.Forms.Label lbl_DiffTravel;
        private System.Windows.Forms.Label lbl_OutputForce;
        private System.Windows.Forms.Label lbl_RoomTemperature;
        private System.Windows.Forms.Label lbl_Humidity;
        private System.Windows.Forms.Label lbl_PneumTestPressure;
        private System.Windows.Forms.Label lbl_HydrFillPressure;
        private System.Windows.Forms.Label lbl_PressureSC;
        private System.Windows.Forms.Label lbl_PressurePC;
        private System.Windows.Forms.Label lbl_TravelTMC;
        private System.Windows.Forms.Label lbl_TravelPiston;
        private MetroFramework.Controls.MetroPanel mpnl_HeaderInfoAnalogInput;
        private MetroFramework.Controls.MetroPanel mpnl_Buttons;
        private MetroFramework.Controls.MetroPanel mpnl_Eventlog;
        private MetroFramework.Controls.MetroTile mTile_Diagram_TestInfo;
        private MetroFramework.Controls.MetroPanel metroPanel5;
        private MetroFramework.Controls.MetroTile mTile_Diagram_TestSequence;
        private MetroFramework.Controls.MetroButton mbtn_BRecordStop;
        private MetroFramework.Controls.MetroButton mbtn_BAlert;
        private MetroFramework.Controls.MetroButton mbtn_BAlarm;
        private MetroFramework.Controls.MetroButton mbtn_BGlobalAlert;
        private MetroFramework.Controls.MetroButton mbtn_BEMotorRef;
        private MetroFramework.Controls.MetroButton mbtn_BRecording;
        private MetroFramework.Controls.MetroButton mbtn_BHandshakePC;
        private System.Windows.Forms.Timer timerHBM;
        private System.Windows.Forms.Label lbl_Vaccum;
        private MetroFramework.Controls.MetroTextBox mtxt_MKSLVacuum;
        private System.Windows.Forms.Timer timerMODBUS;
        private System.Windows.Forms.TabPage Tab_ActuationParameters;
        private MetroFramework.Controls.MetroPanel mPnl_tabActParam_GenralSettings;
        private MetroFramework.Controls.MetroCheckBox mchk_tabActParam_GenSettings_CBLock;
        private MetroFramework.Controls.MetroTile mTile_tabActParam_GeneralSettings;
        private MetroFramework.Controls.MetroComboBox mcbo_tabActParam_GenSettings_CoBActuationMode;
        private MetroFramework.Controls.MetroPanel metroPanel1;
        private MetroFramework.Controls.MetroTile mTile_tabActionParam_Consumer;
        private MetroFramework.Controls.MetroTextBox mlbl_GeneralSettings_LTubeConsSC;
        private MetroFramework.Controls.MetroTextBox mlbl_GeneralSettings_LTubeConsPC;
        private MetroFramework.Controls.MetroTextBox mtxt_GeneralSettings_ETubeConsumerSCPressSide;
        private MetroFramework.Controls.MetroTextBox mtxt_GeneralSettings_ETubeConsumerPCPressSide;
        private MetroFramework.Controls.MetroButton mbtn_GeneralSettings_BSelectTubeCons;
        private MetroFramework.Controls.MetroTextBox mlbl_tabActParam_GenSettings_ActuationMode;
        private MetroFramework.Controls.MetroPanel mpnl_CurrentProject;
        private MetroFramework.Controls.MetroTextBox mlbl_GeneralSettings_LParGenVacuumMax;
        private MetroFramework.Controls.MetroTextBox mlbl_GeneralSettings_LParGenVacuumMin;
        private MetroFramework.Controls.MetroTextBox mlbl_GeneralSettings_LParGenVacuum;
        private MetroFramework.Controls.MetroButton mbtn_GeneralSettings_Plus_EParGenVacuum_Accel_R;
        private MetroFramework.Controls.MetroButton mbtn_GeneralSettings_Minus_EParGenVacuum_Accel_L;
        private MetroFramework.Controls.MetroTextBox mtxt_GeneralSettings_EParGenVacuumMax;
        private MetroFramework.Controls.MetroTextBox mtxt_GeneralSettings_EParGenVacuumMin;
        private MetroFramework.Controls.MetroTextBox mtxt_GeneralSettings_Unit_EParGenVacuumMax;
        private MetroFramework.Controls.MetroTextBox mtxt_GeneralSettings_Unit_EParGenVacuumMin;
        private MetroFramework.Controls.MetroTextBox mtxt_GeneralSettings_Unit_EParGenVacuum;
        private MetroFramework.Controls.MetroTextBox mtxt_GeneralSettings_EParGenVacuum;
        private MetroFramework.Controls.MetroTile mTile_tabActionParam_Vacuum;
        private MetroFramework.Controls.MetroComboBox mcbo_tabActParam_GenSettings_CoBSelectTest;
        private MetroFramework.Controls.MetroButton mbtn_tabActParam_GenSettings_BSaveCurrentParams;
        private MetroFramework.Controls.MetroCheckBox mchk_tabActParam_GenSettings_CBStartFromSelection;
        private MetroFramework.Controls.MetroButton mbtn_tabActParam_GenSettings_BLoadAdjSettings;
        private MetroFramework.Controls.MetroCheckBox mchk_tabActParam_GenSettings_CBSWaitBetweenTests;
        private MetroFramework.Controls.MetroButton mbtn_tabActParam_GenSettings_BLoadLastestParams;
        private MetroFramework.Controls.MetroPanel mPnl_tabActParam_EvaluationParameters;
        private System.Windows.Forms.DataGridView grid_tabActionParam_EvalParam;
        private MetroFramework.Controls.MetroTile mTile_tabActParam_EvaluationParameters;
        private MetroFramework.Controls.MetroPanel mPnl_tabActParam_Actuation;
        private MetroFramework.Controls.MetroButton mbtn_Actuation_Plus_E1ParForceGrad_Accel_R;
        private MetroFramework.Controls.MetroButton mbtn_Actuation_Minus_E1ParForceGrad_Accel_L;
        private MetroFramework.Controls.MetroButton mbtn_Actuation_Plus_E1ParMaxForce_Accel_R;
        private MetroFramework.Controls.MetroTile mTile_tabActParam_Actuation;
        private MetroFramework.Controls.MetroTextBox mtxt_Actuation_E1ParForceGrad;
        private MetroFramework.Controls.MetroTextBox mlbl_Actuation_L1MaxForce;
        private MetroFramework.Controls.MetroTextBox mtxt_Actuation_Unit_E1ParForceGrad;
        private MetroFramework.Controls.MetroTextBox mlbl_Actuation_L1ForceGradient;
        private MetroFramework.Controls.MetroButton mbtn_Actuation_Minus_E1ParMaxForce_Accel_L;
        private MetroFramework.Controls.MetroTextBox mtxt_Actuation_Unit_E1ParMaxForce;
        private MetroFramework.Controls.MetroTextBox mtxt_Actuation_E1ParMaxForce;
        private System.Windows.Forms.TabPage tab_TableResults;
        private MetroFramework.Controls.MetroPanel mpnl_Table_GivingOut;
        private MetroFramework.Controls.MetroTile mTile_tabTable_GivingOut;
        private MetroFramework.Controls.MetroPanel mpnl_Table_Results;
        private System.Windows.Forms.DataGridView TAB_TableResult_Grid;
        private MetroFramework.Controls.MetroTile mTile_tabTable_Results;
        private System.Windows.Forms.TabPage tab_Diagram;
        private MetroFramework.Controls.MetroTile mTile_tabDiagram_GraphicalDisplay;
        private System.Windows.Forms.TabControl TAB_Main;
        private MetroFramework.Controls.MetroButton mbtn_BHandshakePLC;
        private System.ComponentModel.BackgroundWorker bgWorker;
        private System.Windows.Forms.ProgressBar progressBar1;
        private MetroFramework.Controls.MetroButton mbtn_BClock;
        private MetroFramework.Controls.MetroButton mbtn_BRun;
        private System.Windows.Forms.ListView lvLog;
        private DevExpress.XtraCharts.ChartControl devChart;
        private System.Windows.Forms.GroupBox grpRadConsumer;
        private System.Windows.Forms.RadioButton rad_GeneralSettings_CBHoseConsumer;
        private System.Windows.Forms.RadioButton rad_GeneralSettings_CBOriginalConsumer;
        private System.Windows.Forms.Timer timerDateTime;
        private System.Windows.Forms.GroupBox grpOutput;
        private System.Windows.Forms.RadioButton rad_EvaluationParameters_CBOutputSC;
        private System.Windows.Forms.RadioButton rad_EvaluationParameters_CBOutputPC;
        private System.Windows.Forms.StatusStrip stsBar_STBMain;
        private System.Windows.Forms.ToolStripStatusLabel tStatusLabel01;
        private System.Windows.Forms.ToolStripStatusLabel tStatusLabel02;
        private System.Windows.Forms.ToolStripStatusLabel tStatusLabel03;
        private System.Windows.Forms.ToolStripStatusLabel tStatusLabel04;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem menuItemToolStrip_Home;
        private System.Windows.Forms.ToolStripMenuItem subMenu_Home_Logout;
        private System.Windows.Forms.ToolStripMenuItem subMenu_Home_Exit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem subMenu_Home_About;
        private System.Windows.Forms.ToolStripMenuItem menuItemToolStrip_Project;
        private System.Windows.Forms.ToolStripMenuItem subMenu_Project_Project;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem subMenu_Project_PrintGraphics;
        private System.Windows.Forms.ToolStripMenuItem subMenu_Project_PrintParamList;
        private System.Windows.Forms.ToolStripMenuItem subMenu_Project_SetupPrinter;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem subMenu_Project_ExportExcel;
        private System.Windows.Forms.ToolStripMenuItem menuItemToolStrip_TestProgram;
        private System.Windows.Forms.ToolStripMenuItem subMenu_TestProg_SelectTestProgram;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem subMenu_TestProg_Start;
        private System.Windows.Forms.ToolStripMenuItem subMenu_TestProg_STop;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem subMenu_TestProg_CreateUserDefinedTest;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem subMenu_TestProg_ManualActuation;
        private System.Windows.Forms.ToolStripMenuItem subMenu_TestProg_Calibration;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripMenuItem subMenu_TestProg_Bleed;
        private System.Windows.Forms.ToolStripMenuItem subMenu_TestProg_SaveTest;
        private System.Windows.Forms.ToolStripMenuItem menuItemToolStrip_Settings;
        private System.Windows.Forms.ToolStripMenuItem subMenu_Settings_SoftwareMaintenance;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripMenuItem subMenu_Settings_Account;
        private System.Windows.Forms.ToolStripMenuItem subMenu_Account_SelectAccessLevel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private System.Windows.Forms.ToolStripMenuItem subMenu_Account_NewPassword;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator11;
        private System.Windows.Forms.ToolStripMenuItem subMenu_Account_UserAdd;
        private System.Windows.Forms.ToolStripMenuItem subMenu_Account_UserEdit;
        private System.Windows.Forms.ToolStripMenuItem subMenu_Account_UserDelete;
        private System.Windows.Forms.ToolStripMenuItem subMenu_Account_UserReport;
        private System.Windows.Forms.PrintDialog printDialog;
        private MetroFramework.Controls.MetroPanel mpnl_HeaderInfoAnalogInputVisu;
        private MetroFramework.Controls.MetroTextBox mlbl_EoutPressure;
        private MetroFramework.Controls.MetroTextBox mlbl_EoutForce;
        private MetroFramework.Controls.MetroTextBox mlbl_EoutRef;
    }
}