using System;
using System.Net;
using System.Collections;
using System.Windows.Forms;
using Continental.Project.Adam.UI.COM;

namespace Continental.Project.Adam.UI.trash.Modbus
{
    public partial class Form_Modbus_Test : Form
    {
        private ComModbusTCP MBmaster;
        private TextBox txtData;
        private Label labData;
        private byte[] data;

        public Form_Modbus_Test()
        {
            InitializeComponent();
        }

        // ------------------------------------------------------------------------
        // Programm start
        // ------------------------------------------------------------------------
        private void Form_Modbus_Test_Load(object sender, EventArgs e)
        {
            // Set standard format byte, make some textboxes
            radBytes.Checked = true;
            data = new byte[0];
			ResizeData();
        }

        // ------------------------------------------------------------------------
        // Programm stop
        // ------------------------------------------------------------------------
        private void Form_Modbus_Test_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MBmaster != null)
            {
                MBmaster.Dispose();
                MBmaster = null;
            }
            Application.Exit();
        }

        // ------------------------------------------------------------------------
        // Button connect
        // ------------------------------------------------------------------------
        private void btnConnect_Click(object sender, System.EventArgs e)
        {
            try
            {
                // Create new modbus master and add event functions
                MBmaster = new ComModbusTCP(txtIP.Text, 502, true);
                MBmaster.OnResponseData += new ComModbusTCP.ResponseData(MBmaster_OnResponseData);
                MBmaster.OnException += new ComModbusTCP.ExceptionData(MBmaster_OnException);
                // Show additional fields, enable watchdog
                grpExchange.Visible = true;
                grpData.Visible = true;
            }
            catch (SystemException error)
            {
                MessageBox.Show(error.Message);
            }
        }

        // ------------------------------------------------------------------------
        // Button read coils
        // ------------------------------------------------------------------------
        private void btnReadCoils_Click(object sender, System.EventArgs e)
        {
            ushort ID = 1;
            byte unit = Convert.ToByte(txtUnit.Text);
            ushort StartAddress = ReadStartAdr();
            UInt16 Length = Convert.ToUInt16(txtSize.Text);

            MBmaster.ReadCoils(ID, unit, StartAddress, Length);
        }

		// ------------------------------------------------------------------------
		// Button read discrete inputs
		// ------------------------------------------------------------------------
		private void btnReadDisInp_Click(object sender, System.EventArgs e)
		{
			ushort ID = 2;
			byte unit = Convert.ToByte(txtUnit.Text);
			ushort StartAddress = ReadStartAdr();
			UInt16 Length = Convert.ToUInt16(txtSize.Text);

			MBmaster.ReadDiscreteInputs(ID, unit, StartAddress, Length);
		}

		// ------------------------------------------------------------------------
		// Button read holding register
		// ------------------------------------------------------------------------
		private void btnReadHoldReg_Click(object sender, System.EventArgs e)
		{
			ushort ID = 3;
			byte unit = Convert.ToByte(txtUnit.Text);
			ushort StartAddress = ReadStartAdr();
			UInt16 Length = Convert.ToUInt16(txtSize.Text);

			MBmaster.ReadHoldingRegister(ID, unit, StartAddress, Length);
		}

		// ------------------------------------------------------------------------
		// Button read holding register
		// ------------------------------------------------------------------------
		private void btnReadInpReg_Click(object sender, System.EventArgs e)
		{
			ushort ID = 4;
			byte unit = Convert.ToByte(txtUnit.Text);
			ushort StartAddress = ReadStartAdr();
			UInt16 Length = Convert.ToUInt16(txtSize.Text);

			MBmaster.ReadInputRegister(ID, unit, StartAddress, Length);
		}

		// ------------------------------------------------------------------------
		// Button write single coil
		// ------------------------------------------------------------------------
		private void btnWriteSingleCoil_Click(object sender, System.EventArgs e)
		{
			ushort ID = 5;
			byte unit = Convert.ToByte(txtUnit.Text);
			ushort StartAddress = ReadStartAdr();

			data = GetData(1);
			txtSize.Text = "1";

			MBmaster.WriteSingleCoils(ID, unit, StartAddress, Convert.ToBoolean(data[0]));
		}

		// ------------------------------------------------------------------------
		// Button write multiple coils
		// ------------------------------------------------------------------------	
		private void btnWriteMultipleCoils_Click(object sender, System.EventArgs e)
		{
			ushort ID = 6;
			byte unit = Convert.ToByte(txtUnit.Text);
			ushort StartAddress = ReadStartAdr();
			UInt16 Length = Convert.ToUInt16(txtSize.Text);

			data = GetData(Convert.ToUInt16(txtSize.Text));
			MBmaster.WriteMultipleCoils(ID, unit, StartAddress, Length, data);
		}

		// ------------------------------------------------------------------------
		// Button write single register
		// ------------------------------------------------------------------------
		private void btnWriteSingleReg_Click(object sender, System.EventArgs e)
		{
			ushort ID = 7;
			byte unit = Convert.ToByte(txtUnit.Text);
			ushort StartAddress = ReadStartAdr();

			if (radBits.Checked) data = GetData(16);
			else if (radBytes.Checked) data = GetData(2);
			else data = GetData(1);
			txtSize.Text = "1";
			txtData.Text = data[0].ToString();

			MBmaster.WriteSingleRegister(ID, unit, StartAddress, data);
		}

		// ------------------------------------------------------------------------
		// Button write multiple register
		// ------------------------------------------------------------------------	
		private void btnWriteMultipleReg_Click(object sender, System.EventArgs e)
		{
			ushort ID = 8;
			byte unit = Convert.ToByte(txtUnit.Text);
			ushort StartAddress = ReadStartAdr();

			data = GetData(Convert.ToByte(txtSize.Text));
			MBmaster.WriteMultipleRegister(ID, unit, StartAddress, data);
		}

		// ------------------------------------------------------------------------
		// Event for response data
		// ------------------------------------------------------------------------
		private void MBmaster_OnResponseData(ushort ID, byte unit, byte function, byte[] values)
		{
			// ------------------------------------------------------------------
			// Seperate calling threads
			if (this.InvokeRequired)
			{
				this.BeginInvoke(new ComModbusTCP.ResponseData(MBmaster_OnResponseData), new object[] { ID, unit, function, values });
				return;
			}

			// ------------------------------------------------------------------------
			// Identify requested data
			switch (ID)
			{
				case 1:
					grpData.Text = "Read coils";
					data = values;
					ShowAs(null, null);
					break;
				case 2:
					grpData.Text = "Read discrete inputs";
					data = values;
					ShowAs(null, null);
					break;
				case 3:
					grpData.Text = "Read holding register";
					data = values;
					ShowAs(null, null);
					break;
				case 4:
					grpData.Text = "Read input register";
					data = values;
					ShowAs(null, null);
					break;
				case 5:
					grpData.Text = "Write single coil";
					break;
				case 6:
					grpData.Text = "Write multiple coils";
					break;
				case 7:
					grpData.Text = "Write single register";
					break;
				case 8:
					grpData.Text = "Write multiple register";
					break;
			}
		}

		// ------------------------------------------------------------------------
		// Modbus TCP slave exception
		// ------------------------------------------------------------------------
		private void MBmaster_OnException(ushort id, byte unit, byte function, byte exception,int wrdStartDoubleAddress, string varNames)
		{
			string exc = "Modbus says error: ";
			switch (exception)
			{
				case ComModbusTCP.excIllegalFunction: exc += "Illegal function!"; break;
				case ComModbusTCP.excIllegalDataAdr: exc += "Illegal data adress!"; break;
				case ComModbusTCP.excIllegalDataVal: exc += "Illegal data value!"; break;
				case ComModbusTCP.excSlaveDeviceFailure: exc += "Slave device failure!"; break;
				case ComModbusTCP.excAck: exc += "Acknoledge!"; break;
				case ComModbusTCP.excGatePathUnavailable: exc += "Gateway path unavailbale!"; break;
				case ComModbusTCP.excExceptionTimeout: exc += "Slave timed out!"; break;
				case ComModbusTCP.excExceptionConnectionLost: exc += "Connection is lost!"; break;
				case ComModbusTCP.excExceptionNotConnected: exc += "Not connected!"; break;
			}

			MessageBox.Show(exc, "Modbus slave exception");
		}

		// ------------------------------------------------------------------------
		// Generate new number of text boxes
		// ------------------------------------------------------------------------
		private void ResizeData()
		{
			// Create as many textboxes as fit into window
			grpData.Controls.Clear();
			int x = 0;
			int y = 10;
			int z = 20;
			while (y < grpData.Size.Width - 100)
			{
				labData = new Label();
				grpData.Controls.Add(labData);
				labData.Size = new System.Drawing.Size(30, 20);
				labData.Location = new System.Drawing.Point(y, z);
				labData.Text = Convert.ToString(x + 1);

				txtData = new TextBox();
				grpData.Controls.Add(txtData);
				txtData.Size = new System.Drawing.Size(50, 20);
				txtData.Location = new System.Drawing.Point(y + 30, z);
				txtData.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
				txtData.Tag = x;

				x++;
				z = z + txtData.Size.Height + 5;
				if (z > grpData.Size.Height - 40)
				{
					y = y + 100;
					z = 20;
				}
			}
		}

		// ------------------------------------------------------------------------
		// Resize form elements
		// ------------------------------------------------------------------------
		private void frmStart_Resize(object sender, System.EventArgs e)
		{
			if (grpData.Visible == true) ResizeData();
		}

		// ------------------------------------------------------------------------
		// Read start address
		// ------------------------------------------------------------------------
		private ushort ReadStartAdr()
		{
			// Convert hex numbers into decimal
			if (txtStartAdress.Text.IndexOf("0x", 0, txtStartAdress.Text.Length) == 0)
			{
				string str = txtStartAdress.Text.Replace("0x", "");
				ushort hex = Convert.ToUInt16(str, 16);
				return hex;
			}
			else
			{
				return Convert.ToUInt16(txtStartAdress.Text);
			}
		}

		// ------------------------------------------------------------------------
		// Read values from textboxes
		// ------------------------------------------------------------------------
		private byte[] GetData(int num)
		{
			bool[] bits = new bool[num];
			byte[] data = new Byte[num];
			int[] word = new int[num];

			// ------------------------------------------------------------------------
			// Convert data from text boxes
			foreach (Control ctrl in grpData.Controls)
			{
				if (ctrl is TextBox)
				{
					int x = Convert.ToInt16(ctrl.Tag);
					if (radBits.Checked)
					{
						if ((x <= bits.GetUpperBound(0)) && (ctrl.Text != "")) bits[x] = Convert.ToBoolean(Convert.ToByte(ctrl.Text));
						else break;
					}
					if (radBytes.Checked)
					{
						if ((x <= data.GetUpperBound(0)) && (ctrl.Text != "")) data[x] = Convert.ToByte(ctrl.Text);
						else break;
					}
					if (radWord.Checked)
					{
						if ((x <= data.GetUpperBound(0)) && (ctrl.Text != ""))
						{
							try { word[x] = Convert.ToInt16(ctrl.Text); }
							catch (SystemException) { word[x] = Convert.ToUInt16(ctrl.Text); };
						}
						else break;
					}
				}
			}
			if (radBits.Checked)
			{
				int numBytes = (num / 8 + (num % 8 > 0 ? 1 : 0));
				data = new Byte[numBytes];
				BitArray bitArray = new BitArray(bits);
				bitArray.CopyTo(data, 0);
			}
			if (radWord.Checked)
			{
				data = new Byte[num * 2];
				for (int x = 0; x < num; x++)
				{
					byte[] dat = BitConverter.GetBytes((short)IPAddress.HostToNetworkOrder((short)word[x]));
					data[x * 2] = dat[0];
					data[x * 2 + 1] = dat[1];
				}
			}
			return data;
		}

		// ------------------------------------------------------------------------
		// Show values in selected way
		// ------------------------------------------------------------------------
		private void ShowAs(object sender, System.EventArgs e)
		{
			RadioButton rad;
			if (sender is RadioButton)
			{
				rad = (RadioButton)sender;
				if (rad.Checked == false) return;
			}

			bool[] bits = new bool[1];
			int[] word = new int[1];

			// Convert data to selected data type
			if (radBits.Checked == true)
			{
				BitArray bitArray = new BitArray(data);
				bits = new bool[bitArray.Count];
				bitArray.CopyTo(bits, 0);
			}
			if (radWord.Checked == true)
			{
				if (data.Length < 2) return;
				int length = data.Length / 2 + Convert.ToInt16(data.Length % 2 > 0);
				word = new int[length];
				for (int x = 0; x < length; x += 1)
				{
					word[x] = data[x * 2] * 256 + data[x * 2 + 1];
				}
			}

			// ------------------------------------------------------------------------
			// Put new data into text boxes
			foreach (Control ctrl in grpData.Controls)
			{
				if (ctrl is TextBox)
				{
					int x = Convert.ToInt16(ctrl.Tag);
					if (radBits.Checked)
					{
						if (x <= bits.GetUpperBound(0))
						{
							ctrl.Text = Convert.ToByte(bits[x]).ToString();
							ctrl.Visible = true;
						}
						else ctrl.Text = "";
					}
					if (radBytes.Checked)
					{
						if (x <= data.GetUpperBound(0))
						{
							ctrl.Text = data[x].ToString();
							ctrl.Visible = true;
						}
						else ctrl.Text = "";
					}
					if (radWord.Checked)
					{
						if (x <= word.GetUpperBound(0))
						{
							ctrl.Text = word[x].ToString();
							ctrl.Visible = true;
						}
						else ctrl.Text = "";
					}
				}
			}
		}

	}
}

