namespace Continental.Project.Adam.UI
{
    partial class DEV
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DEV));
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
            this.timerMODBUS = new System.Windows.Forms.Timer(this.components);
            this.timerHBM = new System.Windows.Forms.Timer(this.components);
            this.timerDateTime = new System.Windows.Forms.Timer(this.components);
            this.metroPanel3.SuspendLayout();
            this.grpStart.SuspendLayout();
            this.grpExchange.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
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
            this.metroPanel3.Location = new System.Drawing.Point(24, 55);
            this.metroPanel3.Name = "metroPanel3";
            this.metroPanel3.Size = new System.Drawing.Size(1398, 700);
            this.metroPanel3.TabIndex = 125;
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
            // 
            // DisconnectDeviceBt
            // 
            this.DisconnectDeviceBt.Location = new System.Drawing.Point(246, 358);
            this.DisconnectDeviceBt.Name = "DisconnectDeviceBt";
            this.DisconnectDeviceBt.Size = new System.Drawing.Size(225, 35);
            this.DisconnectDeviceBt.TabIndex = 153;
            this.DisconnectDeviceBt.Text = "Disconnect from current device";
            this.DisconnectDeviceBt.UseVisualStyleBackColor = true;
            // 
            // StopContinuousMeasurementBt
            // 
            this.StopContinuousMeasurementBt.Location = new System.Drawing.Point(246, 317);
            this.StopContinuousMeasurementBt.Name = "StopContinuousMeasurementBt";
            this.StopContinuousMeasurementBt.Size = new System.Drawing.Size(225, 35);
            this.StopContinuousMeasurementBt.TabIndex = 154;
            this.StopContinuousMeasurementBt.Text = "Stop continuous measurement";
            this.StopContinuousMeasurementBt.UseVisualStyleBackColor = true;
            // 
            // RunContinuousMeasurementBt
            // 
            this.RunContinuousMeasurementBt.Location = new System.Drawing.Point(246, 276);
            this.RunContinuousMeasurementBt.Name = "RunContinuousMeasurementBt";
            this.RunContinuousMeasurementBt.Size = new System.Drawing.Size(225, 35);
            this.RunContinuousMeasurementBt.TabIndex = 155;
            this.RunContinuousMeasurementBt.Text = "Run continuous measurement";
            this.RunContinuousMeasurementBt.UseVisualStyleBackColor = true;
            // 
            // PrepareContinuousMeasurementBt
            // 
            this.PrepareContinuousMeasurementBt.Location = new System.Drawing.Point(246, 235);
            this.PrepareContinuousMeasurementBt.Name = "PrepareContinuousMeasurementBt";
            this.PrepareContinuousMeasurementBt.Size = new System.Drawing.Size(225, 35);
            this.PrepareContinuousMeasurementBt.TabIndex = 156;
            this.PrepareContinuousMeasurementBt.Text = "Prepare a continuous measurement ";
            this.PrepareContinuousMeasurementBt.UseVisualStyleBackColor = true;
            // 
            // btnRegisterEvent
            // 
            this.btnRegisterEvent.Location = new System.Drawing.Point(8, 276);
            this.btnRegisterEvent.Name = "btnRegisterEvent";
            this.btnRegisterEvent.Size = new System.Drawing.Size(220, 35);
            this.btnRegisterEvent.TabIndex = 157;
            this.btnRegisterEvent.Text = "Register event handlers";
            this.btnRegisterEvent.UseVisualStyleBackColor = true;
            // 
            // InitializeObjectsBt
            // 
            this.InitializeObjectsBt.Location = new System.Drawing.Point(8, 235);
            this.InitializeObjectsBt.Name = "InitializeObjectsBt";
            this.InitializeObjectsBt.Size = new System.Drawing.Size(220, 35);
            this.InitializeObjectsBt.TabIndex = 158;
            this.InitializeObjectsBt.Text = "Initialize some important objects of the API";
            this.InitializeObjectsBt.UseVisualStyleBackColor = true;
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
            this.txtUnit.Size = new System.Drawing.Size(50, 20);
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
            this.txtSize.Size = new System.Drawing.Size(50, 20);
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
            this.txtStartAdress.Size = new System.Drawing.Size(50, 20);
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
            this.txtIP.Size = new System.Drawing.Size(87, 20);
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
            // timerMODBUS
            // 
            this.timerMODBUS.Enabled = true;
            // 
            // timerHBM
            // 
            this.timerHBM.Interval = 200;
            // 
            // timerDateTime
            // 
            this.timerDateTime.Enabled = true;
            this.timerDateTime.Interval = 1000;
            // 
            // DEV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.ControlBox = false;
            this.Controls.Add(this.metroPanel3);
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1920, 1080);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1918, 1038);
            this.Name = "DEV";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Continental - ADAM Functional Test Bench";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Home_Load);
            this.metroPanel3.ResumeLayout(false);
            this.metroPanel3.PerformLayout();
            this.grpStart.ResumeLayout(false);
            this.grpStart.PerformLayout();
            this.grpExchange.ResumeLayout(false);
            this.grpExchange.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroPanel metroPanel3;
        private System.Windows.Forms.TextBox txtLogTestSequence;
        private System.Windows.Forms.TextBox ProtocolTb;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PropertyGrid GenericMeasurementValuesPg;
        private System.Windows.Forms.PropertyGrid MeasurmentValuesPg;
        private System.Windows.Forms.Button ConnectToCertainDevice;
        private System.Windows.Forms.Button DisconnectDeviceBt;
        private System.Windows.Forms.Button StopContinuousMeasurementBt;
        private System.Windows.Forms.Button RunContinuousMeasurementBt;
        private System.Windows.Forms.Button PrepareContinuousMeasurementBt;
        private System.Windows.Forms.Button btnRegisterEvent;
        private System.Windows.Forms.Button InitializeObjectsBt;
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
        private System.Windows.Forms.Timer timerMODBUS;
        private System.Windows.Forms.Timer timerHBM;
        private System.Windows.Forms.Timer timerDateTime;
    }
}