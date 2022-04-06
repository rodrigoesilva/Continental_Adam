
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
            this.mpnl_BackupAssistent = new MetroFramework.Controls.MetroPanel();
            this.lbl_Vaccum = new System.Windows.Forms.Label();
            this.mtxt_MKSLVaccum = new MetroFramework.Controls.MetroTextBox();
            this.metroPanel2 = new MetroFramework.Controls.MetroPanel();
            this.mbtn_BClock = new MetroFramework.Controls.MetroButton();
            this.mbtn_BAlarm = new MetroFramework.Controls.MetroButton();
            this.mpnl_Eventlog = new MetroFramework.Controls.MetroPanel();
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
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.metroPanel3 = new MetroFramework.Controls.MetroPanel();
            this.txtLogTestSequence = new System.Windows.Forms.TextBox();
            this.ProtocolTb = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.GenericMeasurementValuesPg = new System.Windows.Forms.PropertyGrid();
            this.MeasurmentValuesPg = new System.Windows.Forms.PropertyGrid();
            this.ConnectToCertainDevice = new System.Windows.Forms.Button();
            this.DisconnectDeviceBt = new System.Windows.Forms.Button();
            this.StopContinuousMeasurementBt = new System.Windows.Forms.Button();
            this.RunContinuousMeasurementBt = new System.Windows.Forms.Button();
            this.PrepareContinuousMeasurementBt = new System.Windows.Forms.Button();
            this.btnRegisterEvent = new System.Windows.Forms.Button();
            this.InitializeObjectsBt = new System.Windows.Forms.Button();
            this.grpStart = new System.Windows.Forms.GroupBox();
            this.grpExchange = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtUnit = new System.Windows.Forms.TextBox();
            this.btnWriteMultipleReg = new System.Windows.Forms.Button();
            this.btnWriteMultipleCoils = new System.Windows.Forms.Button();
            this.btnWriteSingleReg = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radWord = new System.Windows.Forms.RadioButton();
            this.radBytes = new System.Windows.Forms.RadioButton();
            this.radBits = new System.Windows.Forms.RadioButton();
            this.btnWriteSingleCoil = new System.Windows.Forms.Button();
            this.btnReadInpReg = new System.Windows.Forms.Button();
            this.btnReadHoldReg = new System.Windows.Forms.Button();
            this.btnReadDisInp = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.txtSize = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtStartAdress = new System.Windows.Forms.TextBox();
            this.btnReadCoils = new System.Windows.Forms.Button();
            this.grpData = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.btnConnect = new System.Windows.Forms.Button();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.metroTile1 = new MetroFramework.Controls.MetroTile();
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
            this.mlbl_GeneralSettings_LParGenVaccumMax = new MetroFramework.Controls.MetroTextBox();
            this.mlbl_GeneralSettings_LParGenVaccumMin = new MetroFramework.Controls.MetroTextBox();
            this.mlbl_GeneralSettings_LParGenVaccum = new MetroFramework.Controls.MetroTextBox();
            this.mbtn_GeneralSettings_Plus_EParGenVaccum_Accel_R = new MetroFramework.Controls.MetroButton();
            this.mbtn_GeneralSettings_Minus_EParGenVaccum_Accel_L = new MetroFramework.Controls.MetroButton();
            this.mtxt_GeneralSettings_EParGenVaccumMax = new MetroFramework.Controls.MetroTextBox();
            this.mtxt_GeneralSettings_EParGenVaccumMin = new MetroFramework.Controls.MetroTextBox();
            this.mtxt_GeneralSettings_Unit_EParGenVaccumMax = new MetroFramework.Controls.MetroTextBox();
            this.mtxt_GeneralSettings_Unit_EParGenVaccumMin = new MetroFramework.Controls.MetroTextBox();
            this.mtxt_GeneralSettings_Unit_EParGenVaccum = new MetroFramework.Controls.MetroTextBox();
            this.mtxt_GeneralSettings_EParGenVaccum = new MetroFramework.Controls.MetroTextBox();
            this.mTile_tabActionParam_Vaccum = new MetroFramework.Controls.MetroTile();
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
            this.mpnl_BackupAssistent.SuspendLayout();
            this.metroPanel2.SuspendLayout();
            this.mpnl_Eventlog.SuspendLayout();
            this.metroPanel5.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.metroPanel3.SuspendLayout();
            this.grpStart.SuspendLayout();
            this.grpExchange.SuspendLayout();
            this.groupBox1.SuspendLayout();
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
            this.lbl_RoomTemperature.Size = new System.Drawing.Size(147, 17);
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
            this.lbl_Humidity.Size = new System.Drawing.Size(70, 17);
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
            this.lbl_PneumTestPressure.Size = new System.Drawing.Size(169, 17);
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
            this.lbl_HydrFillPressure.Size = new System.Drawing.Size(143, 17);
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
            this.lbl_PressureSC.Size = new System.Drawing.Size(98, 17);
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
            this.lbl_PressurePC.Size = new System.Drawing.Size(98, 17);
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
            this.lbl_TravelTMC.Size = new System.Drawing.Size(91, 17);
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
            this.lbl_TravelPiston.Size = new System.Drawing.Size(104, 17);
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
            this.lbl_DiffTravel.Size = new System.Drawing.Size(89, 17);
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
            this.lbl_OutputForce.Size = new System.Drawing.Size(103, 17);
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
            this.lbl_InputForce1.Size = new System.Drawing.Size(104, 17);
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
            this.lst_MemoEventLog.Location = new System.Drawing.Point(7, 984);
            this.lst_MemoEventLog.Name = "lst_MemoEventLog";
            this.lst_MemoEventLog.Size = new System.Drawing.Size(1900, 43);
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
            // mpnl_BackupAssistent
            // 
            this.mpnl_BackupAssistent.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.mpnl_BackupAssistent.Controls.Add(this.lbl_Vaccum);
            this.mpnl_BackupAssistent.Controls.Add(this.mtxt_MKSLVaccum);
            this.mpnl_BackupAssistent.Controls.Add(this.lbl_InputForce1);
            this.mpnl_BackupAssistent.Controls.Add(this.mtxt_MKSLInputForce1);
            this.mpnl_BackupAssistent.Controls.Add(this.mtxt_MKSLOutputForce);
            this.mpnl_BackupAssistent.Controls.Add(this.mtxt_MKSLDiffTravel);
            this.mpnl_BackupAssistent.Controls.Add(this.mtxt_MKSLTravelPiston);
            this.mpnl_BackupAssistent.Controls.Add(this.lbl_RoomTemperature);
            this.mpnl_BackupAssistent.Controls.Add(this.mtxt_MKSLTravelTMC);
            this.mpnl_BackupAssistent.Controls.Add(this.lbl_Humidity);
            this.mpnl_BackupAssistent.Controls.Add(this.mtxt_MKSLPressurePC);
            this.mpnl_BackupAssistent.Controls.Add(this.lbl_PneumTestPressure);
            this.mpnl_BackupAssistent.Controls.Add(this.mtxt_MKSLPressureSC);
            this.mpnl_BackupAssistent.Controls.Add(this.lbl_HydrFillPressure);
            this.mpnl_BackupAssistent.Controls.Add(this.mtxt_MKSLHydrFillPressure);
            this.mpnl_BackupAssistent.Controls.Add(this.lbl_PressureSC);
            this.mpnl_BackupAssistent.Controls.Add(this.mtxt_MKSLPneumTestPressure);
            this.mpnl_BackupAssistent.Controls.Add(this.lbl_PressurePC);
            this.mpnl_BackupAssistent.Controls.Add(this.mtxt_MKSLHumidity);
            this.mpnl_BackupAssistent.Controls.Add(this.lbl_TravelTMC);
            this.mpnl_BackupAssistent.Controls.Add(this.mtxt_MKSLRoomTemp);
            this.mpnl_BackupAssistent.Controls.Add(this.lbl_TravelPiston);
            this.mpnl_BackupAssistent.Controls.Add(this.lbl_DiffTravel);
            this.mpnl_BackupAssistent.Controls.Add(this.lbl_OutputForce);
            this.mpnl_BackupAssistent.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.mpnl_BackupAssistent.HorizontalScrollbarBarColor = true;
            this.mpnl_BackupAssistent.HorizontalScrollbarHighlightOnWheel = false;
            this.mpnl_BackupAssistent.HorizontalScrollbarSize = 10;
            this.mpnl_BackupAssistent.Location = new System.Drawing.Point(5, 143);
            this.mpnl_BackupAssistent.Name = "mpnl_BackupAssistent";
            this.mpnl_BackupAssistent.Size = new System.Drawing.Size(1894, 79);
            this.mpnl_BackupAssistent.TabIndex = 47;
            this.mpnl_BackupAssistent.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.mpnl_BackupAssistent.VerticalScrollbarBarColor = true;
            this.mpnl_BackupAssistent.VerticalScrollbarHighlightOnWheel = false;
            this.mpnl_BackupAssistent.VerticalScrollbarSize = 10;
            // 
            // lbl_Vaccum
            // 
            this.lbl_Vaccum.AutoSize = true;
            this.lbl_Vaccum.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Vaccum.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lbl_Vaccum.ForeColor = System.Drawing.Color.Silver;
            this.lbl_Vaccum.Location = new System.Drawing.Point(1304, 10);
            this.lbl_Vaccum.Name = "lbl_Vaccum";
            this.lbl_Vaccum.Size = new System.Drawing.Size(64, 17);
            this.lbl_Vaccum.TabIndex = 84;
            this.lbl_Vaccum.Text = "Vaccum";
            // 
            // mtxt_MKSLVaccum
            // 
            // 
            // 
            // 
            this.mtxt_MKSLVaccum.CustomButton.Image = null;
            this.mtxt_MKSLVaccum.CustomButton.Location = new System.Drawing.Point(101, 2);
            this.mtxt_MKSLVaccum.CustomButton.Name = "";
            this.mtxt_MKSLVaccum.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.mtxt_MKSLVaccum.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.mtxt_MKSLVaccum.CustomButton.TabIndex = 1;
            this.mtxt_MKSLVaccum.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.mtxt_MKSLVaccum.CustomButton.UseSelectable = true;
            this.mtxt_MKSLVaccum.CustomButton.Visible = false;
            this.mtxt_MKSLVaccum.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.mtxt_MKSLVaccum.Lines = new string[] {
        "0.00 bar"};
            this.mtxt_MKSLVaccum.Location = new System.Drawing.Point(1277, 37);
            this.mtxt_MKSLVaccum.MaxLength = 32767;
            this.mtxt_MKSLVaccum.Name = "mtxt_MKSLVaccum";
            this.mtxt_MKSLVaccum.PasswordChar = '\0';
            this.mtxt_MKSLVaccum.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.mtxt_MKSLVaccum.SelectedText = "";
            this.mtxt_MKSLVaccum.SelectionLength = 0;
            this.mtxt_MKSLVaccum.SelectionStart = 0;
            this.mtxt_MKSLVaccum.ShortcutsEnabled = true;
            this.mtxt_MKSLVaccum.Size = new System.Drawing.Size(129, 30);
            this.mtxt_MKSLVaccum.Style = MetroFramework.MetroColorStyle.Orange;
            this.mtxt_MKSLVaccum.TabIndex = 83;
            this.mtxt_MKSLVaccum.Text = "0.00 bar";
            this.mtxt_MKSLVaccum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mtxt_MKSLVaccum.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.mtxt_MKSLVaccum.UseSelectable = true;
            this.mtxt_MKSLVaccum.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.mtxt_MKSLVaccum.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroPanel2
            // 
            this.metroPanel2.Controls.Add(this.mbtn_BClock);
            this.metroPanel2.Controls.Add(this.mbtn_BAlarm);
            this.metroPanel2.Controls.Add(this.mbtn_BStop);
            this.metroPanel2.Controls.Add(this.mTile_LCurrentSelectedTest);
            this.metroPanel2.Controls.Add(this.mbtn_BStart);
            this.metroPanel2.Controls.Add(this.mbtn_BReportPDF);
            this.metroPanel2.Controls.Add(this.mbtn_BGlobalWarning);
            this.metroPanel2.Controls.Add(this.mtbn_BExportTestToXLS);
            this.metroPanel2.HorizontalScrollbarBarColor = true;
            this.metroPanel2.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel2.HorizontalScrollbarSize = 10;
            this.metroPanel2.Location = new System.Drawing.Point(5, 38);
            this.metroPanel2.Name = "metroPanel2";
            this.metroPanel2.Size = new System.Drawing.Size(1900, 99);
            this.metroPanel2.TabIndex = 48;
            this.metroPanel2.VerticalScrollbarBarColor = true;
            this.metroPanel2.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel2.VerticalScrollbarSize = 10;
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
            this.mpnl_Eventlog.Location = new System.Drawing.Point(1449, 255);
            this.mpnl_Eventlog.Name = "mpnl_Eventlog";
            this.mpnl_Eventlog.Size = new System.Drawing.Size(450, 726);
            this.mpnl_Eventlog.TabIndex = 124;
            this.mpnl_Eventlog.VerticalScrollbarBarColor = true;
            this.mpnl_Eventlog.VerticalScrollbarHighlightOnWheel = false;
            this.mpnl_Eventlog.VerticalScrollbarSize = 10;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(9, 282);
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
            this.metroPanel5.Size = new System.Drawing.Size(440, 357);
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
            this.lvLog.Size = new System.Drawing.Size(425, 305);
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
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.metroPanel3);
            this.tabPage1.Location = new System.Drawing.Point(4, 27);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(1434, 725);
            this.tabPage1.TabIndex = 4;
            this.tabPage1.Text = "Dev. Page";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // metroPanel3
            // 
            this.metroPanel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.metroPanel3.Controls.Add(this.txtLogTestSequence);
            this.metroPanel3.Controls.Add(this.ProtocolTb);
            this.metroPanel3.Controls.Add(this.label9);
            this.metroPanel3.Controls.Add(this.label8);
            this.metroPanel3.Controls.Add(this.GenericMeasurementValuesPg);
            this.metroPanel3.Controls.Add(this.MeasurmentValuesPg);
            this.metroPanel3.Controls.Add(this.ConnectToCertainDevice);
            this.metroPanel3.Controls.Add(this.DisconnectDeviceBt);
            this.metroPanel3.Controls.Add(this.StopContinuousMeasurementBt);
            this.metroPanel3.Controls.Add(this.RunContinuousMeasurementBt);
            this.metroPanel3.Controls.Add(this.PrepareContinuousMeasurementBt);
            this.metroPanel3.Controls.Add(this.btnRegisterEvent);
            this.metroPanel3.Controls.Add(this.InitializeObjectsBt);
            this.metroPanel3.Controls.Add(this.grpStart);
            this.metroPanel3.Controls.Add(this.label12);
            this.metroPanel3.Controls.Add(this.metroTile1);
            this.metroPanel3.HorizontalScrollbarBarColor = true;
            this.metroPanel3.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel3.HorizontalScrollbarSize = 10;
            this.metroPanel3.Location = new System.Drawing.Point(28, 26);
            this.metroPanel3.Name = "metroPanel3";
            this.metroPanel3.Size = new System.Drawing.Size(1398, 700);
            this.metroPanel3.TabIndex = 124;
            this.metroPanel3.VerticalScrollbarBarColor = true;
            this.metroPanel3.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel3.VerticalScrollbarSize = 10;
            // 
            // txtLogTestSequence
            // 
            this.txtLogTestSequence.Location = new System.Drawing.Point(11, 46);
            this.txtLogTestSequence.Multiline = true;
            this.txtLogTestSequence.Name = "txtLogTestSequence";
            this.txtLogTestSequence.ReadOnly = true;
            this.txtLogTestSequence.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLogTestSequence.Size = new System.Drawing.Size(466, 58);
            this.txtLogTestSequence.TabIndex = 165;
            // 
            // ProtocolTb
            // 
            this.ProtocolTb.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ProtocolTb.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProtocolTb.Location = new System.Drawing.Point(11, 154);
            this.ProtocolTb.Multiline = true;
            this.ProtocolTb.Name = "ProtocolTb";
            this.ProtocolTb.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.ProtocolTb.Size = new System.Drawing.Size(460, 75);
            this.ProtocolTb.TabIndex = 164;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label9.Location = new System.Drawing.Point(247, 402);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(230, 15);
            this.label9.TabIndex = 162;
            this.label9.Text = "CanRawSignal.GenericMeasurementValues";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label8.Location = new System.Drawing.Point(11, 402);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(230, 15);
            this.label8.TabIndex = 163;
            this.label8.Text = "Signal.ContinuousMeasurementValues";
            // 
            // GenericMeasurementValuesPg
            // 
            this.GenericMeasurementValuesPg.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GenericMeasurementValuesPg.HelpVisible = false;
            this.GenericMeasurementValuesPg.Location = new System.Drawing.Point(247, 418);
            this.GenericMeasurementValuesPg.Name = "GenericMeasurementValuesPg";
            this.GenericMeasurementValuesPg.Size = new System.Drawing.Size(230, 278);
            this.GenericMeasurementValuesPg.TabIndex = 160;
            // 
            // MeasurmentValuesPg
            // 
            this.MeasurmentValuesPg.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MeasurmentValuesPg.HelpVisible = false;
            this.MeasurmentValuesPg.Location = new System.Drawing.Point(11, 418);
            this.MeasurmentValuesPg.Name = "MeasurmentValuesPg";
            this.MeasurmentValuesPg.Size = new System.Drawing.Size(230, 278);
            this.MeasurmentValuesPg.TabIndex = 161;
            // 
            // ConnectToCertainDevice
            // 
            this.ConnectToCertainDevice.Location = new System.Drawing.Point(8, 317);
            this.ConnectToCertainDevice.Name = "ConnectToCertainDevice";
            this.ConnectToCertainDevice.Size = new System.Drawing.Size(220, 55);
            this.ConnectToCertainDevice.TabIndex = 159;
            this.ConnectToCertainDevice.Text = "Connect to a device with a certain IP address";
            this.ConnectToCertainDevice.UseVisualStyleBackColor = true;
            this.ConnectToCertainDevice.Click += new System.EventHandler(this.ConnectToCertainDevice_Click);
            // 
            // DisconnectDeviceBt
            // 
            this.DisconnectDeviceBt.Location = new System.Drawing.Point(246, 358);
            this.DisconnectDeviceBt.Name = "DisconnectDeviceBt";
            this.DisconnectDeviceBt.Size = new System.Drawing.Size(225, 35);
            this.DisconnectDeviceBt.TabIndex = 153;
            this.DisconnectDeviceBt.Text = "Disconnect from current device";
            this.DisconnectDeviceBt.UseVisualStyleBackColor = true;
            this.DisconnectDeviceBt.Click += new System.EventHandler(this.DisconnectDeviceBt_Click);
            // 
            // StopContinuousMeasurementBt
            // 
            this.StopContinuousMeasurementBt.Location = new System.Drawing.Point(246, 317);
            this.StopContinuousMeasurementBt.Name = "StopContinuousMeasurementBt";
            this.StopContinuousMeasurementBt.Size = new System.Drawing.Size(225, 35);
            this.StopContinuousMeasurementBt.TabIndex = 154;
            this.StopContinuousMeasurementBt.Text = "Stop continuous measurement";
            this.StopContinuousMeasurementBt.UseVisualStyleBackColor = true;
            this.StopContinuousMeasurementBt.Click += new System.EventHandler(this.StopContinuousMeasurementBt_Click);
            // 
            // RunContinuousMeasurementBt
            // 
            this.RunContinuousMeasurementBt.Location = new System.Drawing.Point(246, 276);
            this.RunContinuousMeasurementBt.Name = "RunContinuousMeasurementBt";
            this.RunContinuousMeasurementBt.Size = new System.Drawing.Size(225, 35);
            this.RunContinuousMeasurementBt.TabIndex = 155;
            this.RunContinuousMeasurementBt.Text = "Run continuous measurement";
            this.RunContinuousMeasurementBt.UseVisualStyleBackColor = true;
            this.RunContinuousMeasurementBt.Click += new System.EventHandler(this.RunContinuousMeasurementBt_Click);
            // 
            // PrepareContinuousMeasurementBt
            // 
            this.PrepareContinuousMeasurementBt.Location = new System.Drawing.Point(246, 235);
            this.PrepareContinuousMeasurementBt.Name = "PrepareContinuousMeasurementBt";
            this.PrepareContinuousMeasurementBt.Size = new System.Drawing.Size(225, 35);
            this.PrepareContinuousMeasurementBt.TabIndex = 156;
            this.PrepareContinuousMeasurementBt.Text = "Prepare a continuous measurement ";
            this.PrepareContinuousMeasurementBt.UseVisualStyleBackColor = true;
            this.PrepareContinuousMeasurementBt.Click += new System.EventHandler(this.PrepareContinuousMeasurementBt_Click);
            // 
            // btnRegisterEvent
            // 
            this.btnRegisterEvent.Location = new System.Drawing.Point(8, 276);
            this.btnRegisterEvent.Name = "btnRegisterEvent";
            this.btnRegisterEvent.Size = new System.Drawing.Size(220, 35);
            this.btnRegisterEvent.TabIndex = 157;
            this.btnRegisterEvent.Text = "Register event handlers";
            this.btnRegisterEvent.UseVisualStyleBackColor = true;
            this.btnRegisterEvent.Click += new System.EventHandler(this.btnRegisterEvent_Click);
            // 
            // InitializeObjectsBt
            // 
            this.InitializeObjectsBt.Location = new System.Drawing.Point(8, 235);
            this.InitializeObjectsBt.Name = "InitializeObjectsBt";
            this.InitializeObjectsBt.Size = new System.Drawing.Size(220, 35);
            this.InitializeObjectsBt.TabIndex = 158;
            this.InitializeObjectsBt.Text = "Initialize some important objects of the API";
            this.InitializeObjectsBt.UseVisualStyleBackColor = true;
            this.InitializeObjectsBt.Click += new System.EventHandler(this.InitializeObjectsBt_Click);
            // 
            // grpStart
            // 
            this.grpStart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpStart.Controls.Add(this.grpExchange);
            this.grpStart.Controls.Add(this.grpData);
            this.grpStart.Controls.Add(this.label13);
            this.grpStart.Controls.Add(this.btnConnect);
            this.grpStart.Controls.Add(this.txtIP);
            this.grpStart.Location = new System.Drawing.Point(501, 46);
            this.grpStart.Name = "grpStart";
            this.grpStart.Size = new System.Drawing.Size(872, 623);
            this.grpStart.TabIndex = 152;
            this.grpStart.TabStop = false;
            this.grpStart.Text = "Start communication";
            // 
            // grpExchange
            // 
            this.grpExchange.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpExchange.Controls.Add(this.label14);
            this.grpExchange.Controls.Add(this.txtUnit);
            this.grpExchange.Controls.Add(this.btnWriteMultipleReg);
            this.grpExchange.Controls.Add(this.btnWriteMultipleCoils);
            this.grpExchange.Controls.Add(this.btnWriteSingleReg);
            this.grpExchange.Controls.Add(this.groupBox1);
            this.grpExchange.Controls.Add(this.btnWriteSingleCoil);
            this.grpExchange.Controls.Add(this.btnReadInpReg);
            this.grpExchange.Controls.Add(this.btnReadHoldReg);
            this.grpExchange.Controls.Add(this.btnReadDisInp);
            this.grpExchange.Controls.Add(this.label15);
            this.grpExchange.Controls.Add(this.txtSize);
            this.grpExchange.Controls.Add(this.label16);
            this.grpExchange.Controls.Add(this.txtStartAdress);
            this.grpExchange.Controls.Add(this.btnReadCoils);
            this.grpExchange.Location = new System.Drawing.Point(11, 66);
            this.grpExchange.Name = "grpExchange";
            this.grpExchange.Size = new System.Drawing.Size(855, 125);
            this.grpExchange.TabIndex = 16;
            this.grpExchange.TabStop = false;
            this.grpExchange.Text = "Data exhange";
            this.grpExchange.Visible = false;
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(13, 27);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(74, 14);
            this.label14.TabIndex = 25;
            this.label14.Text = "Unit";
            // 
            // txtUnit
            // 
            this.txtUnit.Location = new System.Drawing.Point(87, 25);
            this.txtUnit.Name = "txtUnit";
            this.txtUnit.Size = new System.Drawing.Size(50, 24);
            this.txtUnit.TabIndex = 24;
            this.txtUnit.Text = "0";
            this.txtUnit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnWriteMultipleReg
            // 
            this.btnWriteMultipleReg.Location = new System.Drawing.Point(573, 76);
            this.btnWriteMultipleReg.Name = "btnWriteMultipleReg";
            this.btnWriteMultipleReg.Size = new System.Drawing.Size(87, 44);
            this.btnWriteMultipleReg.TabIndex = 23;
            this.btnWriteMultipleReg.Text = "Write multiple register";
            // 
            // btnWriteMultipleCoils
            // 
            this.btnWriteMultipleCoils.Location = new System.Drawing.Point(573, 28);
            this.btnWriteMultipleCoils.Name = "btnWriteMultipleCoils";
            this.btnWriteMultipleCoils.Size = new System.Drawing.Size(87, 42);
            this.btnWriteMultipleCoils.TabIndex = 22;
            this.btnWriteMultipleCoils.Text = "Write multiple coils";
            // 
            // btnWriteSingleReg
            // 
            this.btnWriteSingleReg.Location = new System.Drawing.Point(473, 76);
            this.btnWriteSingleReg.Name = "btnWriteSingleReg";
            this.btnWriteSingleReg.Size = new System.Drawing.Size(87, 44);
            this.btnWriteSingleReg.TabIndex = 21;
            this.btnWriteSingleReg.Text = "Write single register";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radWord);
            this.groupBox1.Controls.Add(this.radBytes);
            this.groupBox1.Controls.Add(this.radBits);
            this.groupBox1.Location = new System.Drawing.Point(160, 21);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(87, 90);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Show as";
            // 
            // radWord
            // 
            this.radWord.Checked = true;
            this.radWord.Location = new System.Drawing.Point(13, 62);
            this.radWord.Name = "radWord";
            this.radWord.Size = new System.Drawing.Size(67, 21);
            this.radWord.TabIndex = 2;
            this.radWord.TabStop = true;
            this.radWord.Text = "Word";
            // 
            // radBytes
            // 
            this.radBytes.Location = new System.Drawing.Point(13, 42);
            this.radBytes.Name = "radBytes";
            this.radBytes.Size = new System.Drawing.Size(67, 20);
            this.radBytes.TabIndex = 1;
            this.radBytes.Text = "Bytes";
            // 
            // radBits
            // 
            this.radBits.Location = new System.Drawing.Point(13, 21);
            this.radBits.Name = "radBits";
            this.radBits.Size = new System.Drawing.Size(67, 21);
            this.radBits.TabIndex = 0;
            this.radBits.Text = "Bits";
            // 
            // btnWriteSingleCoil
            // 
            this.btnWriteSingleCoil.Location = new System.Drawing.Point(473, 28);
            this.btnWriteSingleCoil.Name = "btnWriteSingleCoil";
            this.btnWriteSingleCoil.Size = new System.Drawing.Size(87, 42);
            this.btnWriteSingleCoil.TabIndex = 19;
            this.btnWriteSingleCoil.Text = "Write single coil";
            // 
            // btnReadInpReg
            // 
            this.btnReadInpReg.Location = new System.Drawing.Point(373, 76);
            this.btnReadInpReg.Name = "btnReadInpReg";
            this.btnReadInpReg.Size = new System.Drawing.Size(87, 44);
            this.btnReadInpReg.TabIndex = 18;
            this.btnReadInpReg.Text = "Read input register";
            // 
            // btnReadHoldReg
            // 
            this.btnReadHoldReg.Location = new System.Drawing.Point(373, 28);
            this.btnReadHoldReg.Name = "btnReadHoldReg";
            this.btnReadHoldReg.Size = new System.Drawing.Size(87, 42);
            this.btnReadHoldReg.TabIndex = 17;
            this.btnReadHoldReg.Text = "Read holding register";
            // 
            // btnReadDisInp
            // 
            this.btnReadDisInp.Location = new System.Drawing.Point(273, 76);
            this.btnReadDisInp.Name = "btnReadDisInp";
            this.btnReadDisInp.Size = new System.Drawing.Size(87, 44);
            this.btnReadDisInp.TabIndex = 16;
            this.btnReadDisInp.Text = "Read discrete inputs";
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(13, 78);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(74, 14);
            this.label15.TabIndex = 15;
            this.label15.Text = "Size";
            // 
            // txtSize
            // 
            this.txtSize.Location = new System.Drawing.Point(87, 78);
            this.txtSize.Name = "txtSize";
            this.txtSize.Size = new System.Drawing.Size(50, 24);
            this.txtSize.TabIndex = 14;
            this.txtSize.Text = "60";
            this.txtSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(13, 53);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(74, 14);
            this.label16.TabIndex = 13;
            this.label16.Text = "Start Adress";
            // 
            // txtStartAdress
            // 
            this.txtStartAdress.Location = new System.Drawing.Point(87, 51);
            this.txtStartAdress.Name = "txtStartAdress";
            this.txtStartAdress.Size = new System.Drawing.Size(50, 24);
            this.txtStartAdress.TabIndex = 12;
            this.txtStartAdress.Text = "0";
            this.txtStartAdress.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnReadCoils
            // 
            this.btnReadCoils.Location = new System.Drawing.Point(273, 28);
            this.btnReadCoils.Name = "btnReadCoils";
            this.btnReadCoils.Size = new System.Drawing.Size(87, 42);
            this.btnReadCoils.TabIndex = 11;
            this.btnReadCoils.Text = "Read coils";
            // 
            // grpData
            // 
            this.grpData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpData.Location = new System.Drawing.Point(11, 197);
            this.grpData.Name = "grpData";
            this.grpData.Size = new System.Drawing.Size(855, 420);
            this.grpData.TabIndex = 14;
            this.grpData.TabStop = false;
            this.grpData.Text = "Data";
            this.grpData.Visible = false;
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(13, 28);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(74, 14);
            this.label13.TabIndex = 7;
            this.label13.Text = "IP Address";
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(187, 21);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(86, 28);
            this.btnConnect.TabIndex = 6;
            this.btnConnect.Text = "Connect";
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(93, 25);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(87, 24);
            this.txtIP.TabIndex = 5;
            this.txtIP.Text = "192.168.0.1";
            this.txtIP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label12.Location = new System.Drawing.Point(11, 123);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(463, 18);
            this.label12.TabIndex = 150;
            this.label12.Text = "HBM Protocol output:";
            // 
            // metroTile1
            // 
            this.metroTile1.ActiveControl = null;
            this.metroTile1.Location = new System.Drawing.Point(0, 0);
            this.metroTile1.Name = "metroTile1";
            this.metroTile1.Size = new System.Drawing.Size(1395, 40);
            this.metroTile1.Style = MetroFramework.MetroColorStyle.Orange;
            this.metroTile1.TabIndex = 106;
            this.metroTile1.Text = "Tests Communication";
            this.metroTile1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroTile1.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroTile1.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            this.metroTile1.UseSelectable = true;
            // 
            // Tab_ActuationParameters
            // 
            this.Tab_ActuationParameters.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Tab_ActuationParameters.Controls.Add(this.mPnl_tabActParam_GenralSettings);
            this.Tab_ActuationParameters.Controls.Add(this.mPnl_tabActParam_EvaluationParameters);
            this.Tab_ActuationParameters.Controls.Add(this.mPnl_tabActParam_Actuation);
            this.Tab_ActuationParameters.Location = new System.Drawing.Point(4, 27);
            this.Tab_ActuationParameters.Margin = new System.Windows.Forms.Padding(2);
            this.Tab_ActuationParameters.Name = "Tab_ActuationParameters";
            this.Tab_ActuationParameters.Padding = new System.Windows.Forms.Padding(2);
            this.Tab_ActuationParameters.Size = new System.Drawing.Size(1434, 725);
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
            this.mPnl_tabActParam_GenralSettings.Size = new System.Drawing.Size(520, 726);
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
            this.mchk_tabActParam_GenSettings_CBLock.Location = new System.Drawing.Point(44, 693);
            this.mchk_tabActParam_GenSettings_CBLock.Margin = new System.Windows.Forms.Padding(2);
            this.mchk_tabActParam_GenSettings_CBLock.Name = "mchk_tabActParam_GenSettings_CBLock";
            this.mchk_tabActParam_GenSettings_CBLock.Size = new System.Drawing.Size(101, 19);
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
            this.rad_GeneralSettings_CBHoseConsumer.Size = new System.Drawing.Size(136, 20);
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
            this.rad_GeneralSettings_CBOriginalConsumer.Size = new System.Drawing.Size(153, 20);
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
            this.mpnl_CurrentProject.Controls.Add(this.mlbl_GeneralSettings_LParGenVaccumMax);
            this.mpnl_CurrentProject.Controls.Add(this.mlbl_GeneralSettings_LParGenVaccumMin);
            this.mpnl_CurrentProject.Controls.Add(this.mlbl_GeneralSettings_LParGenVaccum);
            this.mpnl_CurrentProject.Controls.Add(this.mbtn_GeneralSettings_Plus_EParGenVaccum_Accel_R);
            this.mpnl_CurrentProject.Controls.Add(this.mbtn_GeneralSettings_Minus_EParGenVaccum_Accel_L);
            this.mpnl_CurrentProject.Controls.Add(this.mtxt_GeneralSettings_EParGenVaccumMax);
            this.mpnl_CurrentProject.Controls.Add(this.mtxt_GeneralSettings_EParGenVaccumMin);
            this.mpnl_CurrentProject.Controls.Add(this.mtxt_GeneralSettings_Unit_EParGenVaccumMax);
            this.mpnl_CurrentProject.Controls.Add(this.mtxt_GeneralSettings_Unit_EParGenVaccumMin);
            this.mpnl_CurrentProject.Controls.Add(this.mtxt_GeneralSettings_Unit_EParGenVaccum);
            this.mpnl_CurrentProject.Controls.Add(this.mtxt_GeneralSettings_EParGenVaccum);
            this.mpnl_CurrentProject.Controls.Add(this.mTile_tabActionParam_Vaccum);
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
            // mlbl_GeneralSettings_LParGenVaccumMax
            // 
            // 
            // 
            // 
            this.mlbl_GeneralSettings_LParGenVaccumMax.CustomButton.Image = null;
            this.mlbl_GeneralSettings_LParGenVaccumMax.CustomButton.Location = new System.Drawing.Point(189, 2);
            this.mlbl_GeneralSettings_LParGenVaccumMax.CustomButton.Name = "";
            this.mlbl_GeneralSettings_LParGenVaccumMax.CustomButton.Size = new System.Drawing.Size(19, 19);
            this.mlbl_GeneralSettings_LParGenVaccumMax.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.mlbl_GeneralSettings_LParGenVaccumMax.CustomButton.TabIndex = 1;
            this.mlbl_GeneralSettings_LParGenVaccumMax.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.mlbl_GeneralSettings_LParGenVaccumMax.CustomButton.UseSelectable = true;
            this.mlbl_GeneralSettings_LParGenVaccumMax.CustomButton.Visible = false;
            this.mlbl_GeneralSettings_LParGenVaccumMax.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.mlbl_GeneralSettings_LParGenVaccumMax.FontWeight = MetroFramework.MetroTextBoxWeight.Bold;
            this.mlbl_GeneralSettings_LParGenVaccumMax.Lines = new string[] {
        "Vaccum max."};
            this.mlbl_GeneralSettings_LParGenVaccumMax.Location = new System.Drawing.Point(16, 113);
            this.mlbl_GeneralSettings_LParGenVaccumMax.MaxLength = 32767;
            this.mlbl_GeneralSettings_LParGenVaccumMax.Name = "mlbl_GeneralSettings_LParGenVaccumMax";
            this.mlbl_GeneralSettings_LParGenVaccumMax.PasswordChar = '\0';
            this.mlbl_GeneralSettings_LParGenVaccumMax.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.mlbl_GeneralSettings_LParGenVaccumMax.SelectedText = "";
            this.mlbl_GeneralSettings_LParGenVaccumMax.SelectionLength = 0;
            this.mlbl_GeneralSettings_LParGenVaccumMax.SelectionStart = 0;
            this.mlbl_GeneralSettings_LParGenVaccumMax.ShortcutsEnabled = true;
            this.mlbl_GeneralSettings_LParGenVaccumMax.Size = new System.Drawing.Size(211, 24);
            this.mlbl_GeneralSettings_LParGenVaccumMax.TabIndex = 106;
            this.mlbl_GeneralSettings_LParGenVaccumMax.Text = "Vaccum max.";
            this.mlbl_GeneralSettings_LParGenVaccumMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mlbl_GeneralSettings_LParGenVaccumMax.UseSelectable = true;
            this.mlbl_GeneralSettings_LParGenVaccumMax.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.mlbl_GeneralSettings_LParGenVaccumMax.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // mlbl_GeneralSettings_LParGenVaccumMin
            // 
            // 
            // 
            // 
            this.mlbl_GeneralSettings_LParGenVaccumMin.CustomButton.Image = null;
            this.mlbl_GeneralSettings_LParGenVaccumMin.CustomButton.Location = new System.Drawing.Point(189, 2);
            this.mlbl_GeneralSettings_LParGenVaccumMin.CustomButton.Name = "";
            this.mlbl_GeneralSettings_LParGenVaccumMin.CustomButton.Size = new System.Drawing.Size(19, 19);
            this.mlbl_GeneralSettings_LParGenVaccumMin.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.mlbl_GeneralSettings_LParGenVaccumMin.CustomButton.TabIndex = 1;
            this.mlbl_GeneralSettings_LParGenVaccumMin.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.mlbl_GeneralSettings_LParGenVaccumMin.CustomButton.UseSelectable = true;
            this.mlbl_GeneralSettings_LParGenVaccumMin.CustomButton.Visible = false;
            this.mlbl_GeneralSettings_LParGenVaccumMin.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.mlbl_GeneralSettings_LParGenVaccumMin.FontWeight = MetroFramework.MetroTextBoxWeight.Bold;
            this.mlbl_GeneralSettings_LParGenVaccumMin.Lines = new string[] {
        "Vaccum min."};
            this.mlbl_GeneralSettings_LParGenVaccumMin.Location = new System.Drawing.Point(16, 81);
            this.mlbl_GeneralSettings_LParGenVaccumMin.MaxLength = 32767;
            this.mlbl_GeneralSettings_LParGenVaccumMin.Name = "mlbl_GeneralSettings_LParGenVaccumMin";
            this.mlbl_GeneralSettings_LParGenVaccumMin.PasswordChar = '\0';
            this.mlbl_GeneralSettings_LParGenVaccumMin.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.mlbl_GeneralSettings_LParGenVaccumMin.SelectedText = "";
            this.mlbl_GeneralSettings_LParGenVaccumMin.SelectionLength = 0;
            this.mlbl_GeneralSettings_LParGenVaccumMin.SelectionStart = 0;
            this.mlbl_GeneralSettings_LParGenVaccumMin.ShortcutsEnabled = true;
            this.mlbl_GeneralSettings_LParGenVaccumMin.Size = new System.Drawing.Size(211, 24);
            this.mlbl_GeneralSettings_LParGenVaccumMin.TabIndex = 105;
            this.mlbl_GeneralSettings_LParGenVaccumMin.Text = "Vaccum min.";
            this.mlbl_GeneralSettings_LParGenVaccumMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mlbl_GeneralSettings_LParGenVaccumMin.UseSelectable = true;
            this.mlbl_GeneralSettings_LParGenVaccumMin.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.mlbl_GeneralSettings_LParGenVaccumMin.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // mlbl_GeneralSettings_LParGenVaccum
            // 
            // 
            // 
            // 
            this.mlbl_GeneralSettings_LParGenVaccum.CustomButton.Image = null;
            this.mlbl_GeneralSettings_LParGenVaccum.CustomButton.Location = new System.Drawing.Point(189, 2);
            this.mlbl_GeneralSettings_LParGenVaccum.CustomButton.Name = "";
            this.mlbl_GeneralSettings_LParGenVaccum.CustomButton.Size = new System.Drawing.Size(19, 19);
            this.mlbl_GeneralSettings_LParGenVaccum.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.mlbl_GeneralSettings_LParGenVaccum.CustomButton.TabIndex = 1;
            this.mlbl_GeneralSettings_LParGenVaccum.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.mlbl_GeneralSettings_LParGenVaccum.CustomButton.UseSelectable = true;
            this.mlbl_GeneralSettings_LParGenVaccum.CustomButton.Visible = false;
            this.mlbl_GeneralSettings_LParGenVaccum.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.mlbl_GeneralSettings_LParGenVaccum.FontWeight = MetroFramework.MetroTextBoxWeight.Bold;
            this.mlbl_GeneralSettings_LParGenVaccum.Lines = new string[] {
        "Vaccum"};
            this.mlbl_GeneralSettings_LParGenVaccum.Location = new System.Drawing.Point(16, 47);
            this.mlbl_GeneralSettings_LParGenVaccum.MaxLength = 32767;
            this.mlbl_GeneralSettings_LParGenVaccum.Name = "mlbl_GeneralSettings_LParGenVaccum";
            this.mlbl_GeneralSettings_LParGenVaccum.PasswordChar = '\0';
            this.mlbl_GeneralSettings_LParGenVaccum.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.mlbl_GeneralSettings_LParGenVaccum.SelectedText = "";
            this.mlbl_GeneralSettings_LParGenVaccum.SelectionLength = 0;
            this.mlbl_GeneralSettings_LParGenVaccum.SelectionStart = 0;
            this.mlbl_GeneralSettings_LParGenVaccum.ShortcutsEnabled = true;
            this.mlbl_GeneralSettings_LParGenVaccum.Size = new System.Drawing.Size(211, 24);
            this.mlbl_GeneralSettings_LParGenVaccum.TabIndex = 104;
            this.mlbl_GeneralSettings_LParGenVaccum.Text = "Vaccum";
            this.mlbl_GeneralSettings_LParGenVaccum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mlbl_GeneralSettings_LParGenVaccum.UseSelectable = true;
            this.mlbl_GeneralSettings_LParGenVaccum.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.mlbl_GeneralSettings_LParGenVaccum.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // mbtn_GeneralSettings_Plus_EParGenVaccum_Accel_R
            // 
            this.mbtn_GeneralSettings_Plus_EParGenVaccum_Accel_R.Location = new System.Drawing.Point(485, 46);
            this.mbtn_GeneralSettings_Plus_EParGenVaccum_Accel_R.Name = "mbtn_GeneralSettings_Plus_EParGenVaccum_Accel_R";
            this.mbtn_GeneralSettings_Plus_EParGenVaccum_Accel_R.Size = new System.Drawing.Size(25, 25);
            this.mbtn_GeneralSettings_Plus_EParGenVaccum_Accel_R.TabIndex = 51;
            this.mbtn_GeneralSettings_Plus_EParGenVaccum_Accel_R.Text = "+";
            this.mbtn_GeneralSettings_Plus_EParGenVaccum_Accel_R.UseSelectable = true;
            this.mbtn_GeneralSettings_Plus_EParGenVaccum_Accel_R.Click += new System.EventHandler(this.mbtn_GeneralSettings_Plus_EParGenVaccum_Accel_R_Click);
            // 
            // mbtn_GeneralSettings_Minus_EParGenVaccum_Accel_L
            // 
            this.mbtn_GeneralSettings_Minus_EParGenVaccum_Accel_L.Location = new System.Drawing.Point(233, 47);
            this.mbtn_GeneralSettings_Minus_EParGenVaccum_Accel_L.Name = "mbtn_GeneralSettings_Minus_EParGenVaccum_Accel_L";
            this.mbtn_GeneralSettings_Minus_EParGenVaccum_Accel_L.Size = new System.Drawing.Size(25, 25);
            this.mbtn_GeneralSettings_Minus_EParGenVaccum_Accel_L.TabIndex = 54;
            this.mbtn_GeneralSettings_Minus_EParGenVaccum_Accel_L.Text = "-";
            this.mbtn_GeneralSettings_Minus_EParGenVaccum_Accel_L.UseSelectable = true;
            this.mbtn_GeneralSettings_Minus_EParGenVaccum_Accel_L.Click += new System.EventHandler(this.mbtn_GeneralSettings_Minus_EParGenVaccum_Accel_L_Click);
            // 
            // mtxt_GeneralSettings_EParGenVaccumMax
            // 
            // 
            // 
            // 
            this.mtxt_GeneralSettings_EParGenVaccumMax.CustomButton.Image = null;
            this.mtxt_GeneralSettings_EParGenVaccumMax.CustomButton.Location = new System.Drawing.Point(102, 1);
            this.mtxt_GeneralSettings_EParGenVaccumMax.CustomButton.Name = "";
            this.mtxt_GeneralSettings_EParGenVaccumMax.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.mtxt_GeneralSettings_EParGenVaccumMax.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.mtxt_GeneralSettings_EParGenVaccumMax.CustomButton.TabIndex = 1;
            this.mtxt_GeneralSettings_EParGenVaccumMax.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.mtxt_GeneralSettings_EParGenVaccumMax.CustomButton.UseSelectable = true;
            this.mtxt_GeneralSettings_EParGenVaccumMax.CustomButton.Visible = false;
            this.mtxt_GeneralSettings_EParGenVaccumMax.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.mtxt_GeneralSettings_EParGenVaccumMax.Lines = new string[0];
            this.mtxt_GeneralSettings_EParGenVaccumMax.Location = new System.Drawing.Point(264, 113);
            this.mtxt_GeneralSettings_EParGenVaccumMax.MaxLength = 32767;
            this.mtxt_GeneralSettings_EParGenVaccumMax.Name = "mtxt_GeneralSettings_EParGenVaccumMax";
            this.mtxt_GeneralSettings_EParGenVaccumMax.PasswordChar = '\0';
            this.mtxt_GeneralSettings_EParGenVaccumMax.ReadOnly = true;
            this.mtxt_GeneralSettings_EParGenVaccumMax.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.mtxt_GeneralSettings_EParGenVaccumMax.SelectedText = "";
            this.mtxt_GeneralSettings_EParGenVaccumMax.SelectionLength = 0;
            this.mtxt_GeneralSettings_EParGenVaccumMax.SelectionStart = 0;
            this.mtxt_GeneralSettings_EParGenVaccumMax.ShortcutsEnabled = true;
            this.mtxt_GeneralSettings_EParGenVaccumMax.Size = new System.Drawing.Size(126, 25);
            this.mtxt_GeneralSettings_EParGenVaccumMax.TabIndex = 48;
            this.mtxt_GeneralSettings_EParGenVaccumMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mtxt_GeneralSettings_EParGenVaccumMax.UseSelectable = true;
            this.mtxt_GeneralSettings_EParGenVaccumMax.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.mtxt_GeneralSettings_EParGenVaccumMax.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.mtxt_GeneralSettings_EParGenVaccumMax.TextChanged += new System.EventHandler(this.mtxt_GeneralSettings_EParGenVacuumMax_TextChanged);
            // 
            // mtxt_GeneralSettings_EParGenVaccumMin
            // 
            // 
            // 
            // 
            this.mtxt_GeneralSettings_EParGenVaccumMin.CustomButton.Image = null;
            this.mtxt_GeneralSettings_EParGenVaccumMin.CustomButton.Location = new System.Drawing.Point(102, 1);
            this.mtxt_GeneralSettings_EParGenVaccumMin.CustomButton.Name = "";
            this.mtxt_GeneralSettings_EParGenVaccumMin.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.mtxt_GeneralSettings_EParGenVaccumMin.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.mtxt_GeneralSettings_EParGenVaccumMin.CustomButton.TabIndex = 1;
            this.mtxt_GeneralSettings_EParGenVaccumMin.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.mtxt_GeneralSettings_EParGenVaccumMin.CustomButton.UseSelectable = true;
            this.mtxt_GeneralSettings_EParGenVaccumMin.CustomButton.Visible = false;
            this.mtxt_GeneralSettings_EParGenVaccumMin.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.mtxt_GeneralSettings_EParGenVaccumMin.Lines = new string[0];
            this.mtxt_GeneralSettings_EParGenVaccumMin.Location = new System.Drawing.Point(264, 80);
            this.mtxt_GeneralSettings_EParGenVaccumMin.MaxLength = 32767;
            this.mtxt_GeneralSettings_EParGenVaccumMin.Name = "mtxt_GeneralSettings_EParGenVaccumMin";
            this.mtxt_GeneralSettings_EParGenVaccumMin.PasswordChar = '\0';
            this.mtxt_GeneralSettings_EParGenVaccumMin.ReadOnly = true;
            this.mtxt_GeneralSettings_EParGenVaccumMin.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.mtxt_GeneralSettings_EParGenVaccumMin.SelectedText = "";
            this.mtxt_GeneralSettings_EParGenVaccumMin.SelectionLength = 0;
            this.mtxt_GeneralSettings_EParGenVaccumMin.SelectionStart = 0;
            this.mtxt_GeneralSettings_EParGenVaccumMin.ShortcutsEnabled = true;
            this.mtxt_GeneralSettings_EParGenVaccumMin.Size = new System.Drawing.Size(126, 25);
            this.mtxt_GeneralSettings_EParGenVaccumMin.TabIndex = 43;
            this.mtxt_GeneralSettings_EParGenVaccumMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mtxt_GeneralSettings_EParGenVaccumMin.UseSelectable = true;
            this.mtxt_GeneralSettings_EParGenVaccumMin.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.mtxt_GeneralSettings_EParGenVaccumMin.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.mtxt_GeneralSettings_EParGenVaccumMin.TextChanged += new System.EventHandler(this.mtxt_GeneralSettings_EParGenVacuumMin_TextChanged);
            // 
            // mtxt_GeneralSettings_Unit_EParGenVaccumMax
            // 
            this.mtxt_GeneralSettings_Unit_EParGenVaccumMax.BackColor = System.Drawing.SystemColors.Desktop;
            // 
            // 
            // 
            this.mtxt_GeneralSettings_Unit_EParGenVaccumMax.CustomButton.Image = null;
            this.mtxt_GeneralSettings_Unit_EParGenVaccumMax.CustomButton.Location = new System.Drawing.Point(53, 1);
            this.mtxt_GeneralSettings_Unit_EParGenVaccumMax.CustomButton.Name = "";
            this.mtxt_GeneralSettings_Unit_EParGenVaccumMax.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.mtxt_GeneralSettings_Unit_EParGenVaccumMax.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.mtxt_GeneralSettings_Unit_EParGenVaccumMax.CustomButton.TabIndex = 1;
            this.mtxt_GeneralSettings_Unit_EParGenVaccumMax.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.mtxt_GeneralSettings_Unit_EParGenVaccumMax.CustomButton.UseSelectable = true;
            this.mtxt_GeneralSettings_Unit_EParGenVaccumMax.CustomButton.Visible = false;
            this.mtxt_GeneralSettings_Unit_EParGenVaccumMax.Enabled = false;
            this.mtxt_GeneralSettings_Unit_EParGenVaccumMax.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.mtxt_GeneralSettings_Unit_EParGenVaccumMax.Lines = new string[] {
        "bar"};
            this.mtxt_GeneralSettings_Unit_EParGenVaccumMax.Location = new System.Drawing.Point(402, 113);
            this.mtxt_GeneralSettings_Unit_EParGenVaccumMax.MaxLength = 32767;
            this.mtxt_GeneralSettings_Unit_EParGenVaccumMax.Name = "mtxt_GeneralSettings_Unit_EParGenVaccumMax";
            this.mtxt_GeneralSettings_Unit_EParGenVaccumMax.PasswordChar = '\0';
            this.mtxt_GeneralSettings_Unit_EParGenVaccumMax.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.mtxt_GeneralSettings_Unit_EParGenVaccumMax.SelectedText = "";
            this.mtxt_GeneralSettings_Unit_EParGenVaccumMax.SelectionLength = 0;
            this.mtxt_GeneralSettings_Unit_EParGenVaccumMax.SelectionStart = 0;
            this.mtxt_GeneralSettings_Unit_EParGenVaccumMax.ShortcutsEnabled = true;
            this.mtxt_GeneralSettings_Unit_EParGenVaccumMax.Size = new System.Drawing.Size(77, 25);
            this.mtxt_GeneralSettings_Unit_EParGenVaccumMax.TabIndex = 44;
            this.mtxt_GeneralSettings_Unit_EParGenVaccumMax.Text = "bar";
            this.mtxt_GeneralSettings_Unit_EParGenVaccumMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mtxt_GeneralSettings_Unit_EParGenVaccumMax.UseSelectable = true;
            this.mtxt_GeneralSettings_Unit_EParGenVaccumMax.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.mtxt_GeneralSettings_Unit_EParGenVaccumMax.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // mtxt_GeneralSettings_Unit_EParGenVaccumMin
            // 
            this.mtxt_GeneralSettings_Unit_EParGenVaccumMin.BackColor = System.Drawing.SystemColors.Desktop;
            // 
            // 
            // 
            this.mtxt_GeneralSettings_Unit_EParGenVaccumMin.CustomButton.Image = null;
            this.mtxt_GeneralSettings_Unit_EParGenVaccumMin.CustomButton.Location = new System.Drawing.Point(53, 1);
            this.mtxt_GeneralSettings_Unit_EParGenVaccumMin.CustomButton.Name = "";
            this.mtxt_GeneralSettings_Unit_EParGenVaccumMin.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.mtxt_GeneralSettings_Unit_EParGenVaccumMin.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.mtxt_GeneralSettings_Unit_EParGenVaccumMin.CustomButton.TabIndex = 1;
            this.mtxt_GeneralSettings_Unit_EParGenVaccumMin.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.mtxt_GeneralSettings_Unit_EParGenVaccumMin.CustomButton.UseSelectable = true;
            this.mtxt_GeneralSettings_Unit_EParGenVaccumMin.CustomButton.Visible = false;
            this.mtxt_GeneralSettings_Unit_EParGenVaccumMin.Enabled = false;
            this.mtxt_GeneralSettings_Unit_EParGenVaccumMin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.mtxt_GeneralSettings_Unit_EParGenVaccumMin.Lines = new string[] {
        "bar"};
            this.mtxt_GeneralSettings_Unit_EParGenVaccumMin.Location = new System.Drawing.Point(402, 80);
            this.mtxt_GeneralSettings_Unit_EParGenVaccumMin.MaxLength = 32767;
            this.mtxt_GeneralSettings_Unit_EParGenVaccumMin.Name = "mtxt_GeneralSettings_Unit_EParGenVaccumMin";
            this.mtxt_GeneralSettings_Unit_EParGenVaccumMin.PasswordChar = '\0';
            this.mtxt_GeneralSettings_Unit_EParGenVaccumMin.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.mtxt_GeneralSettings_Unit_EParGenVaccumMin.SelectedText = "";
            this.mtxt_GeneralSettings_Unit_EParGenVaccumMin.SelectionLength = 0;
            this.mtxt_GeneralSettings_Unit_EParGenVaccumMin.SelectionStart = 0;
            this.mtxt_GeneralSettings_Unit_EParGenVaccumMin.ShortcutsEnabled = true;
            this.mtxt_GeneralSettings_Unit_EParGenVaccumMin.Size = new System.Drawing.Size(77, 25);
            this.mtxt_GeneralSettings_Unit_EParGenVaccumMin.TabIndex = 45;
            this.mtxt_GeneralSettings_Unit_EParGenVaccumMin.Text = "bar";
            this.mtxt_GeneralSettings_Unit_EParGenVaccumMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mtxt_GeneralSettings_Unit_EParGenVaccumMin.UseSelectable = true;
            this.mtxt_GeneralSettings_Unit_EParGenVaccumMin.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.mtxt_GeneralSettings_Unit_EParGenVaccumMin.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // mtxt_GeneralSettings_Unit_EParGenVaccum
            // 
            this.mtxt_GeneralSettings_Unit_EParGenVaccum.BackColor = System.Drawing.SystemColors.Desktop;
            // 
            // 
            // 
            this.mtxt_GeneralSettings_Unit_EParGenVaccum.CustomButton.Image = null;
            this.mtxt_GeneralSettings_Unit_EParGenVaccum.CustomButton.Location = new System.Drawing.Point(53, 1);
            this.mtxt_GeneralSettings_Unit_EParGenVaccum.CustomButton.Name = "";
            this.mtxt_GeneralSettings_Unit_EParGenVaccum.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.mtxt_GeneralSettings_Unit_EParGenVaccum.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.mtxt_GeneralSettings_Unit_EParGenVaccum.CustomButton.TabIndex = 1;
            this.mtxt_GeneralSettings_Unit_EParGenVaccum.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.mtxt_GeneralSettings_Unit_EParGenVaccum.CustomButton.UseSelectable = true;
            this.mtxt_GeneralSettings_Unit_EParGenVaccum.CustomButton.Visible = false;
            this.mtxt_GeneralSettings_Unit_EParGenVaccum.Enabled = false;
            this.mtxt_GeneralSettings_Unit_EParGenVaccum.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.mtxt_GeneralSettings_Unit_EParGenVaccum.Lines = new string[] {
        "bar"};
            this.mtxt_GeneralSettings_Unit_EParGenVaccum.Location = new System.Drawing.Point(402, 47);
            this.mtxt_GeneralSettings_Unit_EParGenVaccum.MaxLength = 32767;
            this.mtxt_GeneralSettings_Unit_EParGenVaccum.Name = "mtxt_GeneralSettings_Unit_EParGenVaccum";
            this.mtxt_GeneralSettings_Unit_EParGenVaccum.PasswordChar = '\0';
            this.mtxt_GeneralSettings_Unit_EParGenVaccum.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.mtxt_GeneralSettings_Unit_EParGenVaccum.SelectedText = "";
            this.mtxt_GeneralSettings_Unit_EParGenVaccum.SelectionLength = 0;
            this.mtxt_GeneralSettings_Unit_EParGenVaccum.SelectionStart = 0;
            this.mtxt_GeneralSettings_Unit_EParGenVaccum.ShortcutsEnabled = true;
            this.mtxt_GeneralSettings_Unit_EParGenVaccum.Size = new System.Drawing.Size(77, 25);
            this.mtxt_GeneralSettings_Unit_EParGenVaccum.TabIndex = 46;
            this.mtxt_GeneralSettings_Unit_EParGenVaccum.Text = "bar";
            this.mtxt_GeneralSettings_Unit_EParGenVaccum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mtxt_GeneralSettings_Unit_EParGenVaccum.UseSelectable = true;
            this.mtxt_GeneralSettings_Unit_EParGenVaccum.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.mtxt_GeneralSettings_Unit_EParGenVaccum.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // mtxt_GeneralSettings_EParGenVaccum
            // 
            // 
            // 
            // 
            this.mtxt_GeneralSettings_EParGenVaccum.CustomButton.Image = null;
            this.mtxt_GeneralSettings_EParGenVaccum.CustomButton.Location = new System.Drawing.Point(102, 1);
            this.mtxt_GeneralSettings_EParGenVaccum.CustomButton.Name = "";
            this.mtxt_GeneralSettings_EParGenVaccum.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.mtxt_GeneralSettings_EParGenVaccum.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.mtxt_GeneralSettings_EParGenVaccum.CustomButton.TabIndex = 1;
            this.mtxt_GeneralSettings_EParGenVaccum.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.mtxt_GeneralSettings_EParGenVaccum.CustomButton.UseSelectable = true;
            this.mtxt_GeneralSettings_EParGenVaccum.CustomButton.Visible = false;
            this.mtxt_GeneralSettings_EParGenVaccum.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.mtxt_GeneralSettings_EParGenVaccum.Lines = new string[0];
            this.mtxt_GeneralSettings_EParGenVaccum.Location = new System.Drawing.Point(264, 47);
            this.mtxt_GeneralSettings_EParGenVaccum.MaxLength = 32767;
            this.mtxt_GeneralSettings_EParGenVaccum.Name = "mtxt_GeneralSettings_EParGenVaccum";
            this.mtxt_GeneralSettings_EParGenVaccum.PasswordChar = '\0';
            this.mtxt_GeneralSettings_EParGenVaccum.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.mtxt_GeneralSettings_EParGenVaccum.SelectedText = "";
            this.mtxt_GeneralSettings_EParGenVaccum.SelectionLength = 0;
            this.mtxt_GeneralSettings_EParGenVaccum.SelectionStart = 0;
            this.mtxt_GeneralSettings_EParGenVaccum.ShortcutsEnabled = true;
            this.mtxt_GeneralSettings_EParGenVaccum.Size = new System.Drawing.Size(126, 25);
            this.mtxt_GeneralSettings_EParGenVaccum.TabIndex = 47;
            this.mtxt_GeneralSettings_EParGenVaccum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mtxt_GeneralSettings_EParGenVaccum.UseSelectable = true;
            this.mtxt_GeneralSettings_EParGenVaccum.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.mtxt_GeneralSettings_EParGenVaccum.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.mtxt_GeneralSettings_EParGenVaccum.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mtxt_GeneralSettings_EParGenVaccum_KeyPress);
            this.mtxt_GeneralSettings_EParGenVaccum.Leave += new System.EventHandler(this.mtxt_GeneralSettings_EParGenVaccum_Leave);
            // 
            // mTile_tabActionParam_Vaccum
            // 
            this.mTile_tabActionParam_Vaccum.ActiveControl = null;
            this.mTile_tabActionParam_Vaccum.Location = new System.Drawing.Point(0, 0);
            this.mTile_tabActionParam_Vaccum.Name = "mTile_tabActionParam_Vaccum";
            this.mTile_tabActionParam_Vaccum.Size = new System.Drawing.Size(520, 40);
            this.mTile_tabActionParam_Vaccum.Style = MetroFramework.MetroColorStyle.Orange;
            this.mTile_tabActionParam_Vaccum.TabIndex = 21;
            this.mTile_tabActionParam_Vaccum.Text = "Vaccum";
            this.mTile_tabActionParam_Vaccum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.mTile_tabActionParam_Vaccum.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.mTile_tabActionParam_Vaccum.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            this.mTile_tabActionParam_Vaccum.UseSelectable = true;
            // 
            // mcbo_tabActParam_GenSettings_CoBSelectTest
            // 
            this.mcbo_tabActParam_GenSettings_CoBSelectTest.FormattingEnabled = true;
            this.mcbo_tabActParam_GenSettings_CoBSelectTest.ItemHeight = 23;
            this.mcbo_tabActParam_GenSettings_CoBSelectTest.Location = new System.Drawing.Point(5, 94);
            this.mcbo_tabActParam_GenSettings_CoBSelectTest.Margin = new System.Windows.Forms.Padding(2);
            this.mcbo_tabActParam_GenSettings_CoBSelectTest.Name = "mcbo_tabActParam_GenSettings_CoBSelectTest";
            this.mcbo_tabActParam_GenSettings_CoBSelectTest.Size = new System.Drawing.Size(505, 29);
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
            this.mchk_tabActParam_GenSettings_CBStartFromSelection.Size = new System.Drawing.Size(445, 25);
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
            this.mchk_tabActParam_GenSettings_CBSWaitBetweenTests.Size = new System.Drawing.Size(392, 25);
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
            this.rad_EvaluationParameters_CBOutputSC.Size = new System.Drawing.Size(94, 20);
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
            this.rad_EvaluationParameters_CBOutputPC.Size = new System.Drawing.Size(94, 20);
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
            this.mPnl_tabActParam_EvaluationParameters.Size = new System.Drawing.Size(900, 566);
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
            this.grid_tabActionParam_EvalParam.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.grid_tabActionParam_EvalParam.Size = new System.Drawing.Size(890, 506);
            this.grid_tabActionParam_EvalParam.TabIndex = 94;
            this.grid_tabActionParam_EvalParam.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_tabActionParam_EvalParam_CellClick);
            this.grid_tabActionParam_EvalParam.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_tabActionParam_EvalParam_CellContentClick);
            this.grid_tabActionParam_EvalParam.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_tabActionParam_EvalParam_CellEndEdit);
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
            this.tab_TableResults.Location = new System.Drawing.Point(4, 27);
            this.tab_TableResults.Name = "tab_TableResults";
            this.tab_TableResults.Size = new System.Drawing.Size(1434, 725);
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
            this.mpnl_Table_GivingOut.Size = new System.Drawing.Size(490, 685);
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
            this.mpnl_Table_Results.Size = new System.Drawing.Size(920, 685);
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
            this.TAB_TableResult_Grid.Size = new System.Drawing.Size(920, 630);
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
            this.tab_Diagram.Location = new System.Drawing.Point(4, 27);
            this.tab_Diagram.Name = "tab_Diagram";
            this.tab_Diagram.Padding = new System.Windows.Forms.Padding(3);
            this.tab_Diagram.Size = new System.Drawing.Size(1434, 725);
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
            this.TAB_Main.Controls.Add(this.tabPage1);
            this.TAB_Main.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TAB_Main.Location = new System.Drawing.Point(5, 228);
            this.TAB_Main.Name = "TAB_Main";
            this.TAB_Main.SelectedIndex = 0;
            this.TAB_Main.Size = new System.Drawing.Size(1442, 756);
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
            // Form_Adam_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1910, 1030);
            this.ControlBox = false;
            this.Controls.Add(this.mpnl_Eventlog);
            this.Controls.Add(this.metroPanel2);
            this.Controls.Add(this.mpnl_BackupAssistent);
            this.Controls.Add(this.lst_MemoEventLog);
            this.Controls.Add(this.TAB_Main);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(0, 25);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1920, 1080);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1150, 668);
            this.Name = "Form_Adam_Main";
            this.Padding = new System.Windows.Forms.Padding(20, 60, 20, 20);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Continental - ADAM Functional Test Bench";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form_Adam_Main_Load);
            this.Shown += new System.EventHandler(this.Form_Adam_Main_Shown);
            this.mpnl_BackupAssistent.ResumeLayout(false);
            this.mpnl_BackupAssistent.PerformLayout();
            this.metroPanel2.ResumeLayout(false);
            this.mpnl_Eventlog.ResumeLayout(false);
            this.metroPanel5.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.metroPanel3.ResumeLayout(false);
            this.metroPanel3.PerformLayout();
            this.grpStart.ResumeLayout(false);
            this.grpStart.PerformLayout();
            this.grpExchange.ResumeLayout(false);
            this.grpExchange.PerformLayout();
            this.groupBox1.ResumeLayout(false);
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
            this.ResumeLayout(false);

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
        private MetroFramework.Controls.MetroPanel mpnl_BackupAssistent;
        private MetroFramework.Controls.MetroPanel metroPanel2;
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
        private MetroFramework.Controls.MetroTextBox mtxt_MKSLVaccum;
        private System.Windows.Forms.Timer timerMODBUS;
        private System.Windows.Forms.TabPage tabPage1;
        private MetroFramework.Controls.MetroPanel metroPanel3;
        private System.Windows.Forms.GroupBox grpStart;
        private System.Windows.Forms.GroupBox grpExchange;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtUnit;
        private System.Windows.Forms.Button btnWriteMultipleReg;
        private System.Windows.Forms.Button btnWriteMultipleCoils;
        private System.Windows.Forms.Button btnWriteSingleReg;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radWord;
        private System.Windows.Forms.RadioButton radBytes;
        private System.Windows.Forms.RadioButton radBits;
        private System.Windows.Forms.Button btnWriteSingleCoil;
        private System.Windows.Forms.Button btnReadInpReg;
        private System.Windows.Forms.Button btnReadHoldReg;
        private System.Windows.Forms.Button btnReadDisInp;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtSize;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtStartAdress;
        private System.Windows.Forms.Button btnReadCoils;
        private System.Windows.Forms.GroupBox grpData;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.Label label12;
        private MetroFramework.Controls.MetroTile metroTile1;
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
        private MetroFramework.Controls.MetroTextBox mlbl_GeneralSettings_LParGenVaccumMax;
        private MetroFramework.Controls.MetroTextBox mlbl_GeneralSettings_LParGenVaccumMin;
        private MetroFramework.Controls.MetroTextBox mlbl_GeneralSettings_LParGenVaccum;
        private MetroFramework.Controls.MetroButton mbtn_GeneralSettings_Plus_EParGenVaccum_Accel_R;
        private MetroFramework.Controls.MetroButton mbtn_GeneralSettings_Minus_EParGenVaccum_Accel_L;
        private MetroFramework.Controls.MetroTextBox mtxt_GeneralSettings_EParGenVaccumMax;
        private MetroFramework.Controls.MetroTextBox mtxt_GeneralSettings_EParGenVaccumMin;
        private MetroFramework.Controls.MetroTextBox mtxt_GeneralSettings_Unit_EParGenVaccumMax;
        private MetroFramework.Controls.MetroTextBox mtxt_GeneralSettings_Unit_EParGenVaccumMin;
        private MetroFramework.Controls.MetroTextBox mtxt_GeneralSettings_Unit_EParGenVaccum;
        private MetroFramework.Controls.MetroTextBox mtxt_GeneralSettings_EParGenVaccum;
        private MetroFramework.Controls.MetroTile mTile_tabActionParam_Vaccum;
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
        private System.Windows.Forms.Button ConnectToCertainDevice;
        private System.Windows.Forms.Button DisconnectDeviceBt;
        private System.Windows.Forms.Button StopContinuousMeasurementBt;
        private System.Windows.Forms.Button RunContinuousMeasurementBt;
        private System.Windows.Forms.Button PrepareContinuousMeasurementBt;
        private System.Windows.Forms.Button btnRegisterEvent;
        private System.Windows.Forms.Button InitializeObjectsBt;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PropertyGrid GenericMeasurementValuesPg;
        private System.Windows.Forms.PropertyGrid MeasurmentValuesPg;
        private System.Windows.Forms.TextBox ProtocolTb;
        private MetroFramework.Controls.MetroButton mbtn_BClock;
        private MetroFramework.Controls.MetroButton mbtn_BRun;
        private System.Windows.Forms.ListView lvLog;
        private System.Windows.Forms.TextBox txtLogTestSequence;
        private DevExpress.XtraCharts.ChartControl devChart;
        private System.Windows.Forms.GroupBox grpRadConsumer;
        private System.Windows.Forms.RadioButton rad_GeneralSettings_CBHoseConsumer;
        private System.Windows.Forms.RadioButton rad_GeneralSettings_CBOriginalConsumer;
        private System.Windows.Forms.Timer timerDateTime;
        private System.Windows.Forms.GroupBox grpOutput;
        private System.Windows.Forms.RadioButton rad_EvaluationParameters_CBOutputSC;
        private System.Windows.Forms.RadioButton rad_EvaluationParameters_CBOutputPC;
    }
}