using Continental.Project.Adam.UI.BLL;
using Continental.Project.Adam.UI.COM;
using Continental.Project.Adam.UI.Enum;
using Continental.Project.Adam.UI.Helper;
using Continental.Project.Adam.UI.Helper.Com;
using Continental.Project.Adam.UI.Helper.Tests;
using Continental.Project.Adam.UI.Models.COM;

using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

using DevExpress.XtraCharts;
using DevExpress.Utils;

namespace Continental.Project.Adam.UI.trash
{
    public partial class Form_Tests : Form
    {

        #region Define

        HelperApp _helperApp = new HelperApp();

        string dirPathTestFile = string.Empty;
        string path = string.Empty;

        public GVL_Geral GVL_Geral = new GVL_Geral();
        public GVL_Graficos GVL_Graficos = new GVL_Graficos();

        TimeSpan timeStart = new TimeSpan();
        TimeSpan timeStop = new TimeSpan();

        List<string> lstStrReturnReadFileLines = new List<string>();
        List<string> lstStrTimestamp = new List<string>();
        List<string> lstStrAnalogCh01 = new List<string>();
        List<string> lstStrAnalogCh02 = new List<string>();
        List<string> lstStrAnalogCh03 = new List<string>();
        List<string> lstStrAnalogCh04 = new List<string>();
        List<string> lstStrAnalogCh05 = new List<string>();
        List<string> lstStrAnalogCh06 = new List<string>();
        List<string> lstStrAnalogCh07 = new List<string>();
        List<string> lstStrAnalogCh08 = new List<string>();
        List<string> lstStrAnalogCh09 = new List<string>();
        List<string> lstStrAnalogCh10 = new List<string>();
        List<string> lstStrAnalogCh11 = new List<string>();
        List<string> lstStrAnalogCh12 = new List<string>();
        List<string>[] lstStrReturnReadFile = new List<string>[13];
        List<double>[] lstDblChReadFileArr = new List<double>[13];

        public ChartControl chart = new ChartControl();
        const int InitialPointsCount = 2500000;

        int totalPointsCount = 0;
        int seriesIndex = 1;

        #endregion
        public Form_Tests()
        {
            InitializeComponent();
            HelperApp.UserId = 4;
        }
        private void Form_Tests_Load(object sender, EventArgs e)
        {

            dirPathTestFile = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, _helperApp.AppTests_Path);
            //CatsDogsMethod();

            this.WindowState = FormWindowState.Maximized;

            PopulatecGeneralSettings_CoBSelectTest();
            //Actuation Mode
            mcbo_tabActParam_GenSettings_CoBActuationMode.SelectedIndex = 0;

            mcbo_tabActParam_GenSettings_CoBSelectTest.SelectedIndex = 1;
        }

        #region General

        private void clearFolder(string FolderName)
        {
            DirectoryInfo dir = new DirectoryInfo(FolderName);

            foreach (FileInfo fi in dir.GetFiles())
            {
                fi.Delete();
            }

            foreach (DirectoryInfo di in dir.GetDirectories())
            {
                clearFolder(di.FullName);
                di.Delete();
            }
        }
        #endregion

        #region timer

        List<double> xList = new List<double>();
        List<double> yList = new List<double>();

        private void timerDateTime_Tick(object sender, EventArgs e)
        {
            lblClock.Text = string.Concat(" HORA ATUAL: ", DateTime.Now.ToString("hh:mm:ss.fff tt"));
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            lblClockTick.Text = string.Concat(" TIMER 1 : ", DateTime.Now.ToString("hh:mm:ss.fff tt"));

            //if (i >= 20000)
            //{
            //    parada();
            //    MessageBox.Show("ESTOURO!", _helperApp.appMsg_Error, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return;
            //}

            //Random rnd = new Random();

            //double timeStamp = DateTime.UtcNow.Ticks;
            //string strTimestamp2 = timeStamp.ToString();

            //string strTimestamp = lblClockTick.Text;
            //double dblInputForce1 = rnd.Next(50);
            //double dblInputTravel = rnd.Next(35);
            //double dblHydraulicPressurePC = rnd.Next(70);
            //double dblHydraulicPressureSC = rnd.Next(170);

            //double x = i++;
            //double y = rnd.Next(50);

            ////xList.Add(y);
            ////yList.Add(y);

            //chartMS(x, y);

            //_helperApp.AquisitionTxtData(strTimestamp2, dblInputForce1, dblInputTravel, dblHydraulicPressurePC, dblHydraulicPressureSC);

            //chartNew(xList, yList);

            //if (_comHBM.HBM_EnableCom)
            //    timeStamp = ComHBM.rTimeStamp;

            //chartDemo();

            //cartesianChart2.Series.Add(new LineSeries
            //{
            //    Values = new ChartValues<double> { y },
            //    //ScalesYAt = 0,
            //    Title = "serie teste",
            //    PointGeometry = DefaultGeometries.Cross,
            //    PointGeometrySize = 15
            //});

            //cartesianChart2.AxisX.Add(new LiveCharts.Wpf.Axis
            //{
            //    Title = "Eixo X teste",
            //    //Labels = new[] { "Jan", "Feb", "Mar", "Apr", "May" }
            //});
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            lblClockTick2.Text = string.Concat(" TIMER 2 - 50 : ", DateTime.Now.ToString("hh:mm:ss.fff tt"));
        }

        public void chartMS(double x, double y)
        {

            chart2.Series["New"].Points.AddXY(x, y);
        }
        #endregion

        #region botoes
        private void mbtn_MA_Click(object sender, EventArgs e)
        {
            mbtn_MB.UseCustomBackColor = true;
            mbtn_MB.BackColor = Color.Green;
        }

        private void mbtn_MB_Click(object sender, EventArgs e)
        {
            mbtn_MB.BackColor = Color.Transparent; //17; 17; 17
        }

        private void btn_A_Click(object sender, EventArgs e)
        {


            MessageBox.Show("OK !", _helperApp.appMsg_Error, MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (true)
            {
                path = string.Concat(dirPathTestFile, "texstFileStream.txt");

                FileStream fs = File.OpenWrite(path);

                for (int i = 0; i < 5000000; i++)
                {
                    string time = DateTime.Now.ToString("dd/MM/yyyy - HH:mm:ss:ffff", CultureInfo.InvariantCulture);
                    string data = string.Concat(time, " - Some line of text") + Environment.NewLine;

                    //var data = "falcon\nhawk\nforest\ncloud\nsky";
                    byte[] bytes = Encoding.UTF8.GetBytes(data);

                    fs.Write(bytes, 0, bytes.Length);

                }

                fs.Close();
                fs.Dispose();
            }
            else
            {
                path = string.Concat(dirPathTestFile, "texstStreamWriter.txt");

                using (StreamWriter sw = new StreamWriter(path, false, Encoding.UTF8, 65536))
                {
                    for (int i = 1; i < 5000000; i++)
                    {
                        string time = DateTime.Now.ToString("dd/MM/yyyy - HH:mm:ss:ffff", CultureInfo.InvariantCulture);
                        string finalString = string.Concat(time, " - Some line of text") + Environment.NewLine;

                        sw.WriteLine(finalString);
                    }
                }
            }


            MessageBox.Show("fim !", _helperApp.appMsg_Error, MessageBoxButtons.OK, MessageBoxIcon.Information);

            Process.Start("notepad++.exe", path);
        }

        private void btn_B_Click(object sender, EventArgs e)
        {
            MessageBox.Show("OK !", _helperApp.appMsg_Error, MessageBoxButtons.OK, MessageBoxIcon.Information);

            StringBuilder stringbuilder = new StringBuilder();

            path = string.Concat(dirPathTestFile, "texstNEW.txt");

            for (int i = 1; i < 7000000; i++)
            {
                string time = DateTime.Now.ToString("dd/MM/yyyy - HH:mm:ss:ffff", CultureInfo.InvariantCulture);
                stringbuilder.Append(string.Concat(time, " - Some line of text") + Environment.NewLine);
            }
            File.AppendAllText(path, stringbuilder.ToString());

            MessageBox.Show("fim !", _helperApp.appMsg_Error, MessageBoxButtons.OK, MessageBoxIcon.Information);

            Process.Start("notepad++.exe", path);
        }
        private void btn_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_Main_Click(object sender, EventArgs e)
        {
            _helperApp.Form_Open(new Form_Adam_Main());
        }

        private void btnCalibration_Click(object sender, EventArgs e)
        {
            _helperApp.Form_Open(new Form_Operational_Calibration());
        }

        private void btn_LoadEval_Click(object sender, EventArgs e)
        {
            eEXAMTYPE sel_examtype = eEXAMTYPE.ET_NONE;
            string udt_filename = string.Empty;


            //if (FormSelectEvalProgram->ShowModal(sel_examtype, udt_filename) == mrOk)
            //{
            //    PCMain->ActivePage = TShActuationParams;

            //    SetNewTestProgram(sel_examtype, udt_filename);
            //}

            _helperApp.Form_Open(new Form_Operational_Project(sel_examtype, udt_filename));
        }

        private void btn_Bleed_Click(object sender, EventArgs e)
        {
            _helperApp.Form_Open(new Form_Operational_Bleed());
        }

        private void btn_SelectEvalProgram_Click(object sender, EventArgs e)
        {
            _helperApp.Form_Open(new Form_Manager_SelectEvalProgram());
        }

        private void btn_CreateEvalGroup_Click(object sender, EventArgs e)
        {
            _helperApp.Form_Open(new Form_Manager_CreateEvalGroup());
        }

        private void btn_ManualActuation_Click(object sender, EventArgs e)
        {
            _helperApp.Form_Open(new Form_Operational_ManualActuation());
        }

        private void btn_SelectTubeConsumers_Click(object sender, EventArgs e)
        {
            _helperApp.Form_Open(new Form_Operational_SelectTubeConsumers());
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void btn_NewPass_Click(object sender, EventArgs e)
        {
            if (HelperApp.UserId > 0)
                _helperApp.Form_Open(new Form_Security_NewPassword());
            else
                _helperApp.Form_Open(new Form_Adam_Welcome());
        }

        private void btn_Security_UserLevel_Click(object sender, EventArgs e)
        {
            if (HelperApp.UserId > 0)
                _helperApp.Form_Open(new Form_Security_UserLevel());
            else
                _helperApp.Form_Open(new Form_Adam_Welcome());
        }

        #endregion

        #region Comandos
        private void btntab_Click(object sender, EventArgs e)
        {

        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            Inicia();
        }
        private void btnStop_Click(object sender, EventArgs e)
        {
            try
            {
                parada();
            }
            catch (Exception ex)
            {
                var err = ex.Message;
                throw;
            }

            lblStop.Text = string.Concat(" STOP : ", DateTime.Now.ToString("hh:mm:ss.fff tt"));
        }
        private void Inicia()
        {
            //clearFolder(_initialDirPathTestFile);
            //MessageBox.Show("Action Start !", _helperApp.appMsg_Error, MessageBoxButtons.OK, MessageBoxIcon.Information);

            timer1.Enabled = true;
            timer2.Enabled = true;

            lblStart.Text = string.Concat(" START : ", DateTime.Now.ToString("hh:mm:ss.fff tt"));

            //if (timer.Enabled)
            //    timer.Stop();
            //else timer.Start();

            ChartClear(devChart);

            CoBSelectTestChange(0);

            if (HelperMODBUS.Modbus_EnableCom)
            {
                GVL_Graficos.bLimpaGrafico = true;

                GVL_Geral.bParadaGeral = false;
                GVL_Geral.bPartidaGeral = true;
            }

        }
        private void parada()
        {
            path = string.Concat(dirPathTestFile, HelperTestBase.ProjectTestConcluded.Project.PrjTestFileName);

            if (DialogResult.Yes == MessageBox.Show("Please confirm before proceed" + "\n" + "Do you want to save this Test ? ", _helperApp.appMsg_Name, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
            {
                timer1.Enabled = false;
                timer2.Enabled = false;

                //if (!IsFileInUse(path))
                Append_Header_ActuationType(path);
                //else
                //    MessageBox.Show("Save File USE ERROR!", _helperApp.appMsg_Error, MessageBoxButtons.OK, MessageBoxIcon.Information);

                //if (!IsFileInUse(path))
                Append_Header_Results(path);
                //else
                //    MessageBox.Show("Save File USE ERROR!", _helperApp.appMsg_Error, MessageBoxButtons.OK, MessageBoxIcon.Information);

                //if (!IsFileInUse(path))
                AppendData(path);
                //else
                //    MessageBox.Show("Save File USE ERROR!", _helperApp.appMsg_Error, MessageBoxButtons.OK, MessageBoxIcon.Information);

                //ClearAll(chart2);
            }
            else
            {
                timer1.Enabled = false;
                timer2.Enabled = false;

                path = string.Concat(dirPathTestFile, "texst.txt");

                //File.AppendAllText(path, _helperApp.AppendTxtData_TestConcluded_Values().ToString());
            }
        }
        public bool Append_Header_ActuationType(string path)
        {
            return true;
        }
        public bool Append_Header_Results(string path)
        {
            return true;
        }
        public bool AppendData(string path)
        {

            //File.AppendAllText(path, _helperApp.AppendTxtData_TestConcluded_Values().ToString());

            //using (MemoryStream ms1 = new MemoryStream())
            //{
            //    StreamWriter writer1 = new StreamWriter(ms1);

            //    var strAppendData = _helperApp.AcqData();
            //    writer1.WriteLine(strAppendData.ToString());

            //    writer1.Flush();

            //    var taskAppendData = AppendLineToFileAsync(path, strAppendData.ToString(), "DATA");
            //}

            return true;
        }
        private async Task AppendLineToFileAsync(string path, string line, string tt)
        {
            if (string.IsNullOrWhiteSpace(path))
                throw new ArgumentOutOfRangeException(nameof(path), path, "Was null or whitepsace.");

            if (!File.Exists(path))
                throw new FileNotFoundException("File not found.", nameof(path));

            using (var file = File.Open(path, FileMode.Append, FileAccess.Write))
            using (var writer = new StreamWriter(file))
            {
                await writer.WriteLineAsync(line);
                await writer.FlushAsync();
            }
        }
        public static bool IsFileInUse(string path)
        {
            if (string.IsNullOrEmpty(path))
                throw new ArgumentException("'path' cannot be null or empty.", "path");

            try
            {
                using (var stream = new FileStream(path, FileMode.Open, FileAccess.Read)) { }
            }
            catch (IOException)
            {
                return true;
            }

            return false;
        }
        #endregion

        #region combos

        private void PopulatecGeneralSettings_CoBSelectTest()
        {
            BLL_Manager_TestAvailable _bll_Manager_SelectEvalProgram = new BLL_Manager_TestAvailable();

            DataTable dt = _bll_Manager_SelectEvalProgram.GetAvailableTests();

            DataRow dr = dt.NewRow();
            dr.ItemArray = new object[] { 0, "-- No Selection Test --" };
            dt.Rows.InsertAt(dr, 0);

            mcbo_tabActParam_GenSettings_CoBSelectTest.ValueMember = "Id";

            mcbo_tabActParam_GenSettings_CoBSelectTest.DisplayMember = "Name";
            mcbo_tabActParam_GenSettings_CoBSelectTest.DataSource = dt;
        }

        public void CoBSelectTestChange(object Sender)
        {
            HelperApp.uiTesteSelecionado = Convert.ToInt32(mcbo_tabActParam_GenSettings_CoBSelectTest.SelectedValue.ToString());
            HelperApp.strNomeTesteSelecionado = mcbo_tabActParam_GenSettings_CoBSelectTest.Text.Trim();
            mTile_LCurrentSelectedTest.Text = HelperApp.strNomeTesteSelecionado;

            var last_sel_ix = -1;
            int sel_ix = HelperApp.uiTesteSelecionado;

            if (sel_ix > 0)
            {
                //set Variables
                HelperTestBase.eExamType = EnumExtensionMethods.GetEnumValue<eEXAMTYPE>(sel_ix);

                if (HelperTestBase.eExamType == eEXAMTYPE.ET_USER_DEFINED)
                    HelperTestBase.ProjectTestConcluded.Project.is_user_defined = true;

                //  // save edited data & load corresp. data of new selection, if user defined test
                if (HelperTestBase.eExamType != eEXAMTYPE.ET_NONE)
                    if (HelperTestBase.ProjectTestConcluded.Project.is_user_defined)
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

                ChartValidate(HelperApp.uiTesteSelecionado);

                last_sel_ix = sel_ix;
            }

            GVL_Geral.uiTesteSelecionado = HelperApp.uiTesteSelecionado;
        }
        private void mcbo_tabActParam_GenSettings_CoBSelectTest_SelectedIndexChanged(object sender, EventArgs e)
        {
            //_helperAdam.CoBSelectTestChange(sender);

            CoBSelectTestChange(sender);
        }
        public void ChartValidate(int uiTesteSelecionado)
        {
            var GVL_Graficos = _helperApp.GVL_Graficos;

            //foreach (var ca in chart_Diagram.ChartAreas)
            //    ca.Clear();

            //foreach (var serie in chart_Diagram.Series)
            //{
            //    serie.ClearPoints();
            //    serie.Points.Clear();
            //}

            //Reinicia os graficos caso o programa selecionado seja mudado
            //if (GVL_Geral.uiTesteSelecionado != GVL_Graficos.uiTesteSelecionado || GVL_Graficos.bResetEixos)
            if (uiTesteSelecionado > 0)
            {
                GVL_Graficos.bResetEixos = true;
                GVL_Graficos.uiTesteSelecionado = uiTesteSelecionado;

                switch (uiTesteSelecionado)
                {
                    case 1:     //Force Diagrams - Force/Pressure With Vacuum
                    case 3:     //Force Diagrams - Force/Pressure Without Vacuum
                    case 13:    //Check Sensors - Pressure Difference
                    case 25:    //Force Diagrams - Force/Pressure Dual Ratio
                        {
                            GVL_Graficos.rEscalaX = 1500;
                            GVL_Graficos.EixoX.wsTLLabel = "AxesChart.1";
                            GVL_Graficos.rEscalaY1 = 150;
                            GVL_Graficos.EixoY1.wsTLLabel = "AxesChart.3";
                            GVL_Graficos.rEscalaY2 = 150;
                            GVL_Graficos.EixoY2.wsTLLabel = "AxesChart.4";
                            GVL_Graficos.rEscalaY3 = 0;
                            GVL_Graficos.EixoY3.wsTLLabel = string.Empty;
                            GVL_Graficos.rEscalaY4 = 0;
                            GVL_Graficos.EixoY4.wsTLLabel = string.Empty;

                            GVL_Graficos.strNomeEixoX = "Input Force (N)";
                            GVL_Graficos.strNomeEixoY1 = "Pressure PC (bar)";
                            GVL_Graficos.strNomeEixoY2 = "Pressure SC (bar)";
                            GVL_Graficos.strNomeEixoY3 = string.Empty;
                            GVL_Graficos.strNomeEixoY4 = string.Empty;

                            GVL_Graficos.strUnidadeX = "N";
                            GVL_Graficos.strUnidadeY1 = "bar";
                            GVL_Graficos.strUnidadeY2 = "bar";
                            GVL_Graficos.strUnidadeY3 = string.Empty;
                            GVL_Graficos.strUnidadeY4 = string.Empty;

                            GVL_Graficos.bOcultaY2 = false;
                            GVL_Graficos.bOcultaY3 = true;
                            GVL_Graficos.bOcultaY4 = true;

                            break;
                        }
                    case 2:     //Force Diagrams - Force/Force With Vacuum
                    case 4:     //Force Diagrams - Force/Force Without Vacuum
                    case 26:    //Force Diagrams - Force/Force Dual Ratio
                        {
                            GVL_Graficos.rEscalaX = 1500;
                            GVL_Graficos.EixoX.wsTLLabel = "AxesChart.1";
                            GVL_Graficos.rEscalaY1 = 4000;
                            GVL_Graficos.EixoY1.wsTLLabel = "AxesChart.2";
                            GVL_Graficos.rEscalaY2 = 0;
                            GVL_Graficos.EixoY2.wsTLLabel = string.Empty;
                            GVL_Graficos.rEscalaY3 = 0;
                            GVL_Graficos.EixoY3.wsTLLabel = string.Empty;
                            GVL_Graficos.rEscalaY4 = 0;
                            GVL_Graficos.EixoY4.wsTLLabel = string.Empty;

                            GVL_Graficos.strNomeEixoX = "Input Force (N)";
                            GVL_Graficos.strNomeEixoY1 = "Output Force (N)";
                            GVL_Graficos.strNomeEixoY2 = string.Empty;
                            GVL_Graficos.strNomeEixoY3 = string.Empty;
                            GVL_Graficos.strNomeEixoY4 = string.Empty;

                            GVL_Graficos.strUnidadeX = "N";
                            GVL_Graficos.strUnidadeY1 = "N";
                            GVL_Graficos.strUnidadeY2 = string.Empty;
                            GVL_Graficos.strUnidadeY3 = string.Empty;
                            GVL_Graficos.strUnidadeY4 = string.Empty;

                            GVL_Graficos.bOcultaY2 = true;
                            GVL_Graficos.bOcultaY3 = true;
                            GVL_Graficos.bOcultaY4 = true;

                            break;
                        }
                    case 5: //Vacuum Leakage - Released Position
                    case 6: //Vacuum Leakage - Fully Applied Position
                    case 7: //Vacuum Leakage - Lap Position
                        {
                            GVL_Graficos.rEscalaX = 30;
                            GVL_Graficos.EixoX.wsTLLabel = "AxesChart.0";
                            GVL_Graficos.rEscalaY1 = -1;
                            GVL_Graficos.EixoY1.wsTLLabel = "AxesChart.7";
                            GVL_Graficos.rEscalaY2 = 0;
                            GVL_Graficos.EixoY2.wsTLLabel = string.Empty;
                            GVL_Graficos.rEscalaY3 = 0;
                            GVL_Graficos.EixoY3.wsTLLabel = string.Empty;
                            GVL_Graficos.rEscalaY4 = 0;
                            GVL_Graficos.EixoY4.wsTLLabel = string.Empty;

                            GVL_Graficos.strNomeEixoX = "Time (s)";
                            GVL_Graficos.strNomeEixoY1 = "Vacuum (bar)";
                            GVL_Graficos.strNomeEixoY2 = string.Empty;
                            GVL_Graficos.strNomeEixoY3 = string.Empty;
                            GVL_Graficos.strNomeEixoY4 = string.Empty;

                            GVL_Graficos.strUnidadeX = "s";
                            GVL_Graficos.strUnidadeY1 = "bar";
                            GVL_Graficos.strUnidadeY2 = string.Empty;
                            GVL_Graficos.strUnidadeY3 = string.Empty;
                            GVL_Graficos.strUnidadeY4 = string.Empty;

                            GVL_Graficos.bOcultaY2 = true;
                            GVL_Graficos.bOcultaY3 = true;
                            GVL_Graficos.bOcultaY4 = true;

                            break;
                        }
                    case 8:     //Hydraulic Leakage - Fully Applied Position
                    case 9:     //Hydraulic Leakage - At Low Pressure
                    case 10:    //Hydraulic Leakage - At High Pressure
                        {
                            GVL_Graficos.rEscalaX = 30;
                            GVL_Graficos.EixoX.wsTLLabel = "AxesChart.0";
                            GVL_Graficos.rEscalaY1 = -1;
                            GVL_Graficos.EixoY1.wsTLLabel = "AxesChart.7";
                            GVL_Graficos.rEscalaY2 = 150;
                            GVL_Graficos.EixoY2.wsTLLabel = "AxesChart.3";
                            GVL_Graficos.rEscalaY3 = 150;
                            GVL_Graficos.EixoY3.wsTLLabel = "AxesChart.4";
                            GVL_Graficos.rEscalaY4 = 50;
                            GVL_Graficos.EixoY4.wsTLLabel = "AxesChart.5";

                            GVL_Graficos.strNomeEixoX = "Time (s)";
                            GVL_Graficos.strNomeEixoY1 = "Vacuum (bar)";
                            GVL_Graficos.strNomeEixoY2 = "Pressure PC (bar)";
                            GVL_Graficos.strNomeEixoY3 = "Pressure SC (bar)";
                            GVL_Graficos.strNomeEixoY4 = "Piston Travel (mm)";

                            GVL_Graficos.strUnidadeX = "s";
                            GVL_Graficos.strUnidadeY1 = "bar";
                            GVL_Graficos.strUnidadeY2 = "bar";
                            GVL_Graficos.strUnidadeY3 = "bar";
                            GVL_Graficos.strUnidadeY4 = "mm";

                            GVL_Graficos.bOcultaY2 = false;
                            GVL_Graficos.bOcultaY3 = false;
                            GVL_Graficos.bOcultaY4 = false;

                            break;
                        }
                    case 11:    //Adjustment - Actuation Slow
                    case 12:    //Adjustment - Actuation Fast
                        {
                            GVL_Graficos.rEscalaX = 30;
                            GVL_Graficos.EixoX.wsTLLabel = "AxesChart.0";
                            GVL_Graficos.rEscalaY1 = 1500;
                            GVL_Graficos.EixoY1.wsTLLabel = "AxesChart.1";
                            GVL_Graficos.rEscalaY2 = 0;
                            GVL_Graficos.EixoY2.wsTLLabel = string.Empty;
                            GVL_Graficos.rEscalaY3 = 0;
                            GVL_Graficos.EixoY3.wsTLLabel = string.Empty;
                            GVL_Graficos.rEscalaY4 = 0;
                            GVL_Graficos.EixoY4.wsTLLabel = string.Empty;

                            GVL_Graficos.strNomeEixoX = "Time (s)";
                            GVL_Graficos.strNomeEixoY1 = "Input Force (N)";
                            GVL_Graficos.strNomeEixoY2 = string.Empty;
                            GVL_Graficos.strNomeEixoY3 = string.Empty;
                            GVL_Graficos.strNomeEixoY4 = string.Empty;

                            GVL_Graficos.strUnidadeX = "s";
                            GVL_Graficos.strUnidadeY1 = "N";
                            GVL_Graficos.strUnidadeY2 = string.Empty;
                            GVL_Graficos.strUnidadeY3 = string.Empty;
                            GVL_Graficos.strUnidadeY4 = string.Empty;

                            GVL_Graficos.bOcultaY2 = true;
                            GVL_Graficos.bOcultaY3 = true;
                            GVL_Graficos.bOcultaY4 = true;

                            break;
                        }
                    case 14:    //Check Sensors - Input/Output Travel
                        {
                            GVL_Graficos.rEscalaX = 50;
                            GVL_Graficos.EixoX.wsTLLabel = "AxesChart.5";
                            GVL_Graficos.rEscalaY1 = 50;
                            GVL_Graficos.EixoY1.wsTLLabel = "AxesChart.6";
                            GVL_Graficos.rEscalaY2 = 0;
                            GVL_Graficos.EixoY2.wsTLLabel = string.Empty;
                            GVL_Graficos.rEscalaY3 = 0;
                            GVL_Graficos.EixoY3.wsTLLabel = string.Empty;
                            GVL_Graficos.rEscalaY4 = 0;
                            GVL_Graficos.EixoY4.wsTLLabel = string.Empty;

                            GVL_Graficos.strNomeEixoX = "Piston Travel (mm)";
                            GVL_Graficos.strNomeEixoY1 = "TMC Travel (mm)";
                            GVL_Graficos.strNomeEixoY2 = string.Empty;
                            GVL_Graficos.strNomeEixoY3 = string.Empty;
                            GVL_Graficos.strNomeEixoY4 = string.Empty;

                            GVL_Graficos.strUnidadeX = "mm";
                            GVL_Graficos.strUnidadeY1 = "mm";
                            GVL_Graficos.strUnidadeY2 = string.Empty;
                            GVL_Graficos.strUnidadeY3 = string.Empty;
                            GVL_Graficos.strUnidadeY4 = string.Empty;

                            GVL_Graficos.bOcultaY2 = true;
                            GVL_Graficos.bOcultaY3 = true;
                            GVL_Graficos.bOcultaY4 = true;

                            break;
                        }
                    case 15:    //Adjustment - Input Travel VS Input Force
                        {
                            GVL_Graficos.rEscalaX = 1500;
                            GVL_Graficos.EixoX.wsTLLabel = "AxesChart.1";
                            GVL_Graficos.rEscalaY1 = 50;
                            GVL_Graficos.EixoY1.wsTLLabel = "AxesChart.5";
                            GVL_Graficos.rEscalaY2 = 0;
                            GVL_Graficos.EixoY2.wsTLLabel = string.Empty;
                            GVL_Graficos.rEscalaY3 = 0;
                            GVL_Graficos.EixoY3.wsTLLabel = string.Empty;
                            GVL_Graficos.rEscalaY4 = 0;
                            GVL_Graficos.EixoY4.wsTLLabel = string.Empty;

                            GVL_Graficos.strNomeEixoX = "Input Force (N)";
                            GVL_Graficos.strNomeEixoY1 = "Piston Travel (mm)";
                            GVL_Graficos.strNomeEixoY2 = string.Empty;
                            GVL_Graficos.strNomeEixoY3 = string.Empty;
                            GVL_Graficos.strNomeEixoY4 = string.Empty;

                            GVL_Graficos.strUnidadeX = "N";
                            GVL_Graficos.strUnidadeY1 = "mm";
                            GVL_Graficos.strUnidadeY2 = string.Empty;
                            GVL_Graficos.strUnidadeY3 = string.Empty;
                            GVL_Graficos.strUnidadeY4 = string.Empty;

                            GVL_Graficos.bOcultaY2 = true;
                            GVL_Graficos.bOcultaY3 = true;
                            GVL_Graficos.bOcultaY4 = true;

                            break;
                        }
                    case 16:    //Adjustment - Hose Consumer
                    case 17:    //Lost Travel ACU - Hydraulic
                    case 18:    //Lost Travel ACU - Hydraulic Electrical Actuation
                        {
                            GVL_Graficos.rEscalaX = 50;
                            GVL_Graficos.EixoX.wsTLLabel = "AxesChart.5";
                            GVL_Graficos.rEscalaY1 = 150;
                            GVL_Graficos.EixoY1.wsTLLabel = "AxesChart.3";
                            GVL_Graficos.rEscalaY2 = 150;
                            GVL_Graficos.EixoY2.wsTLLabel = "AxesChart.4";
                            GVL_Graficos.rEscalaY3 = 0;
                            GVL_Graficos.EixoY3.wsTLLabel = string.Empty;
                            GVL_Graficos.rEscalaY4 = 0;
                            GVL_Graficos.EixoY4.wsTLLabel = string.Empty;

                            GVL_Graficos.strNomeEixoX = "Piston Travel (mm)";
                            GVL_Graficos.strNomeEixoY1 = "Pressure PC (bar)";
                            GVL_Graficos.strNomeEixoY2 = "Pressure SC (bar)";
                            GVL_Graficos.strNomeEixoY3 = string.Empty;
                            GVL_Graficos.strNomeEixoY4 = string.Empty;

                            GVL_Graficos.strUnidadeX = "mm";
                            GVL_Graficos.strUnidadeY1 = "bar";
                            GVL_Graficos.strUnidadeY2 = "bar";
                            GVL_Graficos.strUnidadeY3 = string.Empty;
                            GVL_Graficos.strUnidadeY4 = string.Empty;

                            GVL_Graficos.bOcultaY2 = false;
                            GVL_Graficos.bOcultaY3 = true;
                            GVL_Graficos.bOcultaY4 = true;

                            break;
                        }
                    case 19:    //Lost Travel ACU - Pneumatic Primary
                    case 20:    //Lost Travel ACU - Pneumatic Secondary
                        {
                            GVL_Graficos.rEscalaX = 1;
                            GVL_Graficos.EixoX.wsTLLabel = "AxesChart.5";
                            GVL_Graficos.rEscalaY1 = 150;
                            GVL_Graficos.EixoY1.wsTLLabel = "AxesChart.8";
                            GVL_Graficos.rEscalaY2 = 0;
                            GVL_Graficos.EixoY2.wsTLLabel = string.Empty;
                            GVL_Graficos.rEscalaY3 = 0;
                            GVL_Graficos.EixoY3.wsTLLabel = string.Empty;
                            GVL_Graficos.rEscalaY4 = 0;
                            GVL_Graficos.EixoY4.wsTLLabel = string.Empty;

                            GVL_Graficos.strNomeEixoX = "Piston Travel (mm)";
                            GVL_Graficos.strNomeEixoY1 = "Test Pressure (bar)";
                            GVL_Graficos.strNomeEixoY2 = string.Empty;
                            GVL_Graficos.strNomeEixoY3 = string.Empty;
                            GVL_Graficos.strNomeEixoY4 = string.Empty;

                            GVL_Graficos.strUnidadeX = "mm";
                            GVL_Graficos.strUnidadeY1 = "bar";
                            GVL_Graficos.strUnidadeY2 = string.Empty;
                            GVL_Graficos.strUnidadeY3 = string.Empty;
                            GVL_Graficos.strUnidadeY4 = string.Empty;

                            GVL_Graficos.bOcultaY2 = true;
                            GVL_Graficos.bOcultaY3 = true;
                            GVL_Graficos.bOcultaY4 = true;

                            break;
                        }
                    case 21:    //Pedal Feeling Characteristics
                        {
                            GVL_Graficos.rEscalaX = 50;
                            GVL_Graficos.EixoX.wsTLLabel = "AxesChart.5";
                            GVL_Graficos.rEscalaY1 = 150;
                            GVL_Graficos.EixoY1.wsTLLabel = "AxesChart.3";
                            GVL_Graficos.rEscalaY2 = 1500;
                            GVL_Graficos.EixoY2.wsTLLabel = "AxesChart.1";
                            GVL_Graficos.rEscalaY3 = 0;
                            GVL_Graficos.EixoY3.wsTLLabel = string.Empty;
                            GVL_Graficos.rEscalaY4 = 0;
                            GVL_Graficos.EixoY4.wsTLLabel = string.Empty;

                            GVL_Graficos.strNomeEixoX = "Piston Travel (mm)";
                            GVL_Graficos.strNomeEixoY1 = "Pressure PC (bar)";
                            GVL_Graficos.strNomeEixoY2 = "Input Force (N)";
                            GVL_Graficos.strNomeEixoY3 = string.Empty;
                            GVL_Graficos.strNomeEixoY4 = string.Empty;

                            GVL_Graficos.strUnidadeX = "mm";
                            GVL_Graficos.strUnidadeY1 = "bar";
                            GVL_Graficos.strUnidadeY2 = "N";
                            GVL_Graficos.strUnidadeY3 = string.Empty;
                            GVL_Graficos.strUnidadeY4 = string.Empty;

                            GVL_Graficos.bOcultaY2 = false;
                            GVL_Graficos.bOcultaY3 = true;
                            GVL_Graficos.bOcultaY4 = true;

                            break;
                        }
                    case 22:    //Actuation / Release - Mechanical Actuation
                        {
                            GVL_Graficos.rEscalaX = 10;
                            GVL_Graficos.EixoX.wsTLLabel = "AxesChart.0";
                            GVL_Graficos.rEscalaY1 = 2000;
                            GVL_Graficos.EixoY1.wsTLLabel = "AxesChart.1";
                            GVL_Graficos.rEscalaY2 = 150;
                            GVL_Graficos.EixoY2.wsTLLabel = "AxesChart.3";
                            GVL_Graficos.rEscalaY3 = 40;
                            GVL_Graficos.EixoY3.wsTLLabel = "AxesChart.5";
                            GVL_Graficos.rEscalaY4 = 0;
                            GVL_Graficos.EixoY4.wsTLLabel = string.Empty;

                            GVL_Graficos.strNomeEixoX = "Time (s)";
                            GVL_Graficos.strNomeEixoY1 = "Input Force (N)";
                            GVL_Graficos.strNomeEixoY2 = "Pressure PC (bar)";
                            GVL_Graficos.strNomeEixoY3 = "Piston Travel (mm)";
                            GVL_Graficos.strNomeEixoY4 = string.Empty;

                            GVL_Graficos.strUnidadeX = "s";
                            GVL_Graficos.strUnidadeY1 = "N";
                            GVL_Graficos.strUnidadeY2 = "bar";
                            GVL_Graficos.strUnidadeY3 = "mm";
                            GVL_Graficos.strUnidadeY4 = string.Empty;

                            GVL_Graficos.bOcultaY2 = false;
                            GVL_Graficos.bOcultaY3 = false;
                            GVL_Graficos.bOcultaY4 = true;

                            break;
                        }
                    case 23:    //Breather Hole / Central Valve open
                        {
                            GVL_Graficos.rEscalaX = 20;
                            GVL_Graficos.EixoX.wsTLLabel = "AxesChart.0";
                            GVL_Graficos.rEscalaY1 = 2;
                            GVL_Graficos.EixoY1.wsTLLabel = "AxesChart.9";
                            GVL_Graficos.rEscalaY2 = 0;
                            GVL_Graficos.EixoY2.wsTLLabel = string.Empty;
                            GVL_Graficos.rEscalaY3 = 0;
                            GVL_Graficos.EixoY3.wsTLLabel = string.Empty;
                            GVL_Graficos.rEscalaY4 = 0;
                            GVL_Graficos.EixoY4.wsTLLabel = string.Empty;

                            GVL_Graficos.strNomeEixoX = "Time (s)";
                            GVL_Graficos.strNomeEixoY1 = "Fill Pressure (bar)";
                            GVL_Graficos.strNomeEixoY2 = string.Empty;
                            GVL_Graficos.strNomeEixoY3 = string.Empty;
                            GVL_Graficos.strNomeEixoY4 = string.Empty;

                            GVL_Graficos.strUnidadeX = "s";
                            GVL_Graficos.strUnidadeY1 = "bar";
                            GVL_Graficos.strUnidadeY2 = string.Empty;
                            GVL_Graficos.strUnidadeY3 = string.Empty;
                            GVL_Graficos.strUnidadeY4 = string.Empty;

                            GVL_Graficos.bOcultaY2 = true;
                            GVL_Graficos.bOcultaY3 = true;
                            GVL_Graficos.bOcultaY4 = true;

                            break;
                        }
                    case 24:    //Efficiency
                        {
                            //if (GVL_Parametros.iTipoGrafico_T24 == 0)
                            if (true)
                            {
                                GVL_Graficos.rEscalaX = 1500;
                                GVL_Graficos.EixoX.wsTLLabel = "AxesChart.1";
                                GVL_Graficos.rEscalaY1 = 150;
                                GVL_Graficos.EixoY1.wsTLLabel = "AxesChart.3";
                                GVL_Graficos.rEscalaY2 = 150;
                                GVL_Graficos.EixoY2.wsTLLabel = "AxesChart.3";
                                GVL_Graficos.rEscalaY3 = 0;
                                GVL_Graficos.EixoY3.wsTLLabel = string.Empty;
                                GVL_Graficos.rEscalaY4 = 0;
                                GVL_Graficos.EixoY4.wsTLLabel = string.Empty;

                                GVL_Graficos.strNomeEixoX = "Input Force (N)";
                                GVL_Graficos.strNomeEixoY1 = "Pressure PC (bar)";
                                GVL_Graficos.strNomeEixoY2 = "Pressure PC (bar)";
                                GVL_Graficos.strNomeEixoY3 = string.Empty;
                                GVL_Graficos.strNomeEixoY4 = string.Empty;

                                GVL_Graficos.strUnidadeX = "N";
                                GVL_Graficos.strUnidadeY1 = "bar";
                                GVL_Graficos.strUnidadeY2 = "bar";
                                GVL_Graficos.strUnidadeY3 = string.Empty;
                                GVL_Graficos.strUnidadeY4 = string.Empty;

                                GVL_Graficos.bOcultaY2 = false;
                                GVL_Graficos.bOcultaY3 = true;
                                GVL_Graficos.bOcultaY4 = true;
                            }
                            else
                            {
                                GVL_Graficos.rEscalaX = 60;
                                GVL_Graficos.EixoX.wsTLLabel = "AxesChart.0";
                                GVL_Graficos.rEscalaY1 = 150;
                                GVL_Graficos.EixoY1.wsTLLabel = "AxesChart.3";
                                GVL_Graficos.rEscalaY2 = 150;
                                GVL_Graficos.EixoY2.wsTLLabel = "AxesChart.3";
                                GVL_Graficos.rEscalaY3 = 0;
                                GVL_Graficos.EixoY3.wsTLLabel = string.Empty;
                                GVL_Graficos.rEscalaY4 = 0;
                                GVL_Graficos.EixoY4.wsTLLabel = string.Empty;

                                GVL_Graficos.strNomeEixoX = "Time (s)";
                                GVL_Graficos.strNomeEixoY1 = "Pressure PC (bar)";
                                GVL_Graficos.strNomeEixoY2 = "Pressure PC (bar)";
                                GVL_Graficos.strNomeEixoY3 = string.Empty;
                                GVL_Graficos.strNomeEixoY4 = string.Empty;

                                GVL_Graficos.strUnidadeX = "s";
                                GVL_Graficos.strUnidadeY1 = "bar";
                                GVL_Graficos.strUnidadeY2 = "bar";
                                GVL_Graficos.strUnidadeY3 = string.Empty;
                                GVL_Graficos.strUnidadeY4 = string.Empty;

                                GVL_Graficos.bOcultaY2 = false;
                                GVL_Graficos.bOcultaY3 = true;
                                GVL_Graficos.bOcultaY4 = true;
                            }

                            break;
                        }

                    case 27:    //ADAM - Find Switching Point With TMC
                        {
                            //IF GVL_Parametros.iTipoGrafico_T27 = 0 THEN
                            if (true)
                            {
                                GVL_Graficos.rEscalaX = 1500;
                                GVL_Graficos.EixoX.wsTLLabel = "AxesChart.1";
                                GVL_Graficos.rEscalaY1 = 150;
                                GVL_Graficos.EixoY1.wsTLLabel = "AxesChart.3";
                                GVL_Graficos.rEscalaY2 = 0;
                                GVL_Graficos.EixoY2.wsTLLabel = string.Empty;
                                GVL_Graficos.rEscalaY3 = 0;
                                GVL_Graficos.EixoY3.wsTLLabel = string.Empty;
                                GVL_Graficos.rEscalaY4 = 0;
                                GVL_Graficos.EixoY4.wsTLLabel = string.Empty;

                                GVL_Graficos.strNomeEixoX = "Input Force (N)";
                                GVL_Graficos.strNomeEixoY1 = "Pressure PC (bar)";
                                GVL_Graficos.strNomeEixoY2 = string.Empty;
                                GVL_Graficos.strNomeEixoY3 = string.Empty;
                                GVL_Graficos.strNomeEixoY4 = string.Empty;

                                GVL_Graficos.strUnidadeX = "N";
                                GVL_Graficos.strUnidadeY1 = "bar";
                                GVL_Graficos.strUnidadeY2 = string.Empty;
                                GVL_Graficos.strUnidadeY3 = string.Empty;
                                GVL_Graficos.strUnidadeY4 = string.Empty;

                                GVL_Graficos.bOcultaY2 = false;
                                GVL_Graficos.bOcultaY3 = true;
                                GVL_Graficos.bOcultaY4 = true;
                            }
                            else
                            {
                                GVL_Graficos.rEscalaX = 60;
                                GVL_Graficos.EixoX.wsTLLabel = "AxesChart.0";
                                GVL_Graficos.rEscalaY1 = 1500;
                                GVL_Graficos.EixoY1.wsTLLabel = "AxesChart.1";
                                GVL_Graficos.rEscalaY2 = 150;
                                GVL_Graficos.EixoY2.wsTLLabel = "AxesChart.3";
                                GVL_Graficos.rEscalaY3 = 40;
                                GVL_Graficos.EixoY3.wsTLLabel = "AxesChart.5";
                                GVL_Graficos.rEscalaY4 = 10;
                                GVL_Graficos.EixoY4.wsTLLabel = "AxesChart.10";

                                GVL_Graficos.strNomeEixoX = "Time (s)";
                                GVL_Graficos.strNomeEixoY1 = "Input Force (N)";
                                GVL_Graficos.strNomeEixoY2 = "Pressure PC (bar)";
                                GVL_Graficos.strNomeEixoY3 = "Piston Travel (mm)";
                                GVL_Graficos.strNomeEixoY4 = "Diff. Travel (mm)";

                                GVL_Graficos.strUnidadeX = "s";
                                GVL_Graficos.strUnidadeY1 = "N";
                                GVL_Graficos.strUnidadeY2 = "bar";
                                GVL_Graficos.strUnidadeY3 = "mm";
                                GVL_Graficos.strUnidadeY4 = "mm";

                                GVL_Graficos.bOcultaY2 = false;
                                GVL_Graficos.bOcultaY3 = false;
                                GVL_Graficos.bOcultaY4 = false;
                            }

                            break;
                        }

                    case 28:    //ADAM - Switching Point Without TMC
                        {
                            //IF GVL_Parametros.iTipoGrafico_T27 = 0 THEN
                            if (true)
                            {
                                GVL_Graficos.rEscalaX = 1500;
                                GVL_Graficos.EixoX.wsTLLabel = "AxesChart.1";
                                GVL_Graficos.rEscalaY1 = 4000;
                                GVL_Graficos.EixoY1.wsTLLabel = "AxesChart.2";
                                GVL_Graficos.rEscalaY2 = 0;
                                GVL_Graficos.EixoY2.wsTLLabel = string.Empty;
                                GVL_Graficos.rEscalaY3 = 0;
                                GVL_Graficos.EixoY3.wsTLLabel = string.Empty;
                                GVL_Graficos.rEscalaY4 = 0;
                                GVL_Graficos.EixoY4.wsTLLabel = string.Empty;

                                GVL_Graficos.strNomeEixoX = "Input Force (N)";
                                GVL_Graficos.strNomeEixoY1 = "Output Force (N)";
                                GVL_Graficos.strNomeEixoY2 = string.Empty;
                                GVL_Graficos.strNomeEixoY3 = string.Empty;
                                GVL_Graficos.strNomeEixoY4 = string.Empty;

                                GVL_Graficos.strUnidadeX = "N";
                                GVL_Graficos.strUnidadeY1 = "N";
                                GVL_Graficos.strUnidadeY2 = string.Empty;
                                GVL_Graficos.strUnidadeY3 = string.Empty;
                                GVL_Graficos.strUnidadeY4 = string.Empty;

                                GVL_Graficos.bOcultaY2 = false;
                                GVL_Graficos.bOcultaY3 = true;
                                GVL_Graficos.bOcultaY4 = true;
                            }
                            else
                            {
                                GVL_Graficos.rEscalaX = 60;
                                GVL_Graficos.EixoX.wsTLLabel = "AxesChart.0";
                                GVL_Graficos.rEscalaY1 = 1500;
                                GVL_Graficos.EixoY1.wsTLLabel = "AxesChart.1";
                                GVL_Graficos.rEscalaY2 = 4000;
                                GVL_Graficos.EixoY2.wsTLLabel = "AxesChart.2";
                                GVL_Graficos.rEscalaY3 = 40;
                                GVL_Graficos.EixoY3.wsTLLabel = "AxesChart.5";
                                GVL_Graficos.rEscalaY4 = 10;
                                GVL_Graficos.EixoY4.wsTLLabel = "AxesChart.10";

                                GVL_Graficos.strNomeEixoX = "Time (s)";
                                GVL_Graficos.strNomeEixoY1 = "Input Force (N)";
                                GVL_Graficos.strNomeEixoY2 = "Output Force (N)";
                                GVL_Graficos.strNomeEixoY3 = "Piston Travel (mm)";
                                GVL_Graficos.strNomeEixoY4 = "Diff. Travel (mm)";

                                GVL_Graficos.strUnidadeX = "s";
                                GVL_Graficos.strUnidadeY1 = "N";
                                GVL_Graficos.strUnidadeY2 = "N";
                                GVL_Graficos.strUnidadeY3 = "mm";
                                GVL_Graficos.strUnidadeY4 = "mm";

                                GVL_Graficos.bOcultaY2 = false;
                                GVL_Graficos.bOcultaY3 = false;
                                GVL_Graficos.bOcultaY4 = false;
                            }

                            break;
                        }

                    case 29:    //Bleed
                        {
                            GVL_Graficos.rEscalaX = 120;
                            GVL_Graficos.EixoX.wsTLLabel = "AxesChart.0";
                            GVL_Graficos.rEscalaY1 = 1500;
                            GVL_Graficos.EixoY1.wsTLLabel = "AxesChart.1";
                            GVL_Graficos.rEscalaY2 = 150;
                            GVL_Graficos.EixoY2.wsTLLabel = "AxesChart.3";
                            GVL_Graficos.rEscalaY3 = 150;
                            GVL_Graficos.EixoY3.wsTLLabel = "AxesChart.4";
                            GVL_Graficos.rEscalaY4 = 0;
                            GVL_Graficos.EixoY4.wsTLLabel = string.Empty;

                            GVL_Graficos.strNomeEixoX = "Time (s)";
                            GVL_Graficos.strNomeEixoY1 = "Input Force (N)";
                            GVL_Graficos.strNomeEixoY2 = "Pressure PC (bar)";
                            GVL_Graficos.strNomeEixoY3 = "Pressure SC (bar)";
                            GVL_Graficos.strNomeEixoY4 = string.Empty;

                            GVL_Graficos.strUnidadeX = "s";
                            GVL_Graficos.strUnidadeY1 = "N";
                            GVL_Graficos.strUnidadeY2 = "bar";
                            GVL_Graficos.strUnidadeY3 = "bar";
                            GVL_Graficos.strUnidadeY4 = string.Empty;

                            GVL_Graficos.bOcultaY2 = false;
                            GVL_Graficos.bOcultaY3 = false;
                            GVL_Graficos.bOcultaY4 = true;

                            break;
                        }

                    default:
                        break;
                }

                GVL_Graficos.EixoX.rMin = 0;
                GVL_Graficos.EixoX.rMax = GVL_Graficos.rEscalaX;
                GVL_Graficos.EixoY1.rMin = 0;
                GVL_Graficos.EixoY1.rMax = GVL_Graficos.rEscalaY1;
                GVL_Graficos.EixoY2.rMin = 0;
                GVL_Graficos.EixoY2.rMax = GVL_Graficos.rEscalaY2;
                GVL_Graficos.EixoY3.rMin = 0;
                GVL_Graficos.EixoY3.rMax = GVL_Graficos.rEscalaY3;
                GVL_Graficos.EixoY4.rMin = 0;
                GVL_Graficos.EixoY4.rMax = GVL_Graficos.rEscalaY4;

                //chart1_MultipleAxes(this.chart_Diagram, HelperApp.strNomeTesteSelecionado,
                //    GVL_Graficos.strNomeEixoX,
                //    GVL_Graficos.strNomeEixoY1, GVL_Graficos.strNomeEixoY2, GVL_Graficos.strNomeEixoY3, GVL_Graficos.strNomeEixoY4,
                //    GVL_Graficos.bOcultaY2, GVL_Graficos.bOcultaY3, GVL_Graficos.bOcultaY4);
            }
        }

        private void mcbo_tabActParam_GenSettings_CoBActuationMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            HelperApp.uiActuationMode = mcbo_tabActParam_GenSettings_CoBActuationMode.SelectedIndex;
            HelperApp.strActuationMode = mcbo_tabActParam_GenSettings_CoBActuationMode.Text.Trim();

            ////set title name
            //mTile_tabActParam_Actuation.Text = HelperApp.strActuationMode;
        }

        #endregion

        #region save
        private void btnSaveImg_Click(object sender, EventArgs e)
        {
            string path = "D:\\chart_img.bmp";


            using (Bitmap im = new Bitmap(chart2.Width, chart2.Height))
            {
                chart2.DrawToBitmap(im, new Rectangle(0, 0, chart2.Width, chart2.Height));
                using (Graphics gr = Graphics.FromImage(im))
                {
                    gr.DrawString("Test",
                        new Font(FontFamily.GenericSerif, 10, FontStyle.Bold),
                        new SolidBrush(Color.Red), new PointF(10, 10));
                }
                im.Save(path);
            }
        }

        private void btnSavePDF_Click(object sender, EventArgs e)
        {

        }

        private void btnSaveTxt_Click(object sender, EventArgs e)
        {
            //string memString = "Memory test string !!";
            //// convert string to stream
            //byte[] buffer = Encoding.ASCII.GetBytes(memString);
            //MemoryStream ms = new MemoryStream(buffer);
            ////write to file
            //FileStream file = new FileStream("d:\\file.txt", FileMode.Create, FileAccess.Write);
            //ms.WriteTo(file);
            //file.Close();
            //ms.Close();

            string path = "D:\\chart_txt.txt";

            _helperApp.ExportToTxtFile(chart2, path);

        }

        private void btnSaveCsv_Click(object sender, EventArgs e)
        {
            //"D:\\PROJETOS\\LUCAS\\CONTINENTAL\\Chartdata.csv"
            string path = "D:\\chart_csv.csv";

            _helperApp.ExportToCsvFile(chart2, path);
        }

        private void btnSaveXls_Click(object sender, EventArgs e)
        {
            //"D:\\PROJETOS\\LUCAS\\CONTINENTAL\\chart_informations.xls"
            string path = "D:\\chart_xls.xls";

            _helperApp.ExportToExcel(chart2, path);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ChartClear(devChart);
        }
        #endregion

        #region Load

        //btnLoadActualTestOnlyData
        private void btnLoadActualTestOnlyData_Click(object sender, EventArgs e)
        {
            LoadOnlyDataTextFile(path);

            //LoadChart(chart2);

            //LoadChartNew(cartesianChart2);

            //using (StreamReader file = new StreamReader(fname))
            //{
            //    int i = 0;
            //    string ln;

            //    List<string> lstUdt = new List<string>();

            //    while ((ln = file.ReadLine()) != null)
            //    {
            //        if (!ln.StartsWith("UDTFileGenerated_"))
            //        {
            //            string[] childArray = Regex.Replace(ln, @"\t|\n|\r|;", "").Split(char.Parse(pipeTestChar));

            //            if (childArray.Length > 0) // Check Test - Lost Travel TMC
            //            {
            //                var val = childArray[0].ToString();

            //                lstUdt.Add(val);
            //            }

            //            i++;
            //        }
            //    }

            //    file.Close();
            //}

        }
        private void btnLoadExistingTestOnlyData_Click(object sender, EventArgs e)
        {
            List<string> lstReturnRead = new List<string>();

            OpenFileDialog theDialog = new OpenFileDialog();
            theDialog.Title = "Open Text File";
            theDialog.Filter = "TXT files|*.txt;*.tst";
            theDialog.InitialDirectory = string.Concat(dirPathTestFile, "texst.txt");

            if (theDialog.ShowDialog() == DialogResult.OK)
            {
                if (!string.IsNullOrEmpty(theDialog.FileName))
                    lstReturnRead = LoadOnlyDataTextFile(theDialog.FileName);

                //if (lstReturnRead.Count() > 0)
                //    ChartLoadMeasurement(lstReturnRead);
                //else
                //    MessageBox.Show("Failed, reloading project !", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnLoadActualTestComplete_Click(object sender, EventArgs e)
        {
            
        }

        public void btnLoadExistingTestComplete_Click(object sender, EventArgs e)
        {
            OpenFileDialog theDialog = new OpenFileDialog();
            theDialog.Title = "Open Text File";
            theDialog.Filter = "TXT files|*.txt;*.tst";
            theDialog.InitialDirectory = string.Concat(dirPathTestFile, "texst.txt");
            try
            {
                if (theDialog.ShowDialog() == DialogResult.OK)
                {
                    string fileName = theDialog.SafeFileName;

                    var pathWithFileName = theDialog.FileName;

                    if (!string.IsNullOrEmpty(pathWithFileName))
                        lstStrReturnReadFile = _helperApp.ReadTXTFileHBM(fileName, pathWithFileName);

                    if (lstStrReturnReadFile[0].Count() > 0)
                        ChartLoadMeasurement(lstStrReturnReadFile);
                    else
                        MessageBox.Show("Failed, reloading project !", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }


            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
            timeStop = new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
            lblStop.Text = string.Concat(" STOP : ", DateTime.Now.ToString("hh:mm:ss.fff tt"));

            TimeSpan timeSpan = timeStart > timeStop ? timeStop - timeStart : (timeStart + TimeSpan.FromSeconds(1)) - timeStop;

            lblClockTick.Text = timeSpan.ToString();

            MessageBox.Show("Done");

        }
        public List<string> LoadOnlyDataTextFile(string filePath)
        {
            /*
            bool breakFlag = false;
            var reader = new StreamReader(File.OpenRead(filePath));
            string line;

            listlistA.Clear();
            mList.Clear();

            while (!reader.EndOfStream && !breakFlag)
            {
                while ((line = reader.ReadLine()) != null && !breakFlag)
                {
                    string[] strArray = Regex.Replace(line, @"\t|\n|\r|", "").Split(char.Parse(";"));


                    if (strArray.Length > 1) // Check Test - Lost Travel TMC
                    {
                        var Time = strArray[0].Trim().ToString();
                        var InputForce1 = strArray[1].Trim().ToString();
                        var InputTravel = strArray[2].Trim().ToString();
                        //var HydraulicPressurePC = strArray[3].Trim().ToString();
                        //var HydraulicPressureSC = strArray[4].Trim().ToString();

                        listA.Add(InputForce1);
                    }
                    else
                    {
                        MessageBox.Show("Failed, test completed !", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        breakFlag = true;
                        break;
                    }

                }
            }
            mList.Add(listA);

            return listA;
            */

            return null;
        }
        public void ChartClear(ChartControl chart)
        {
            chart.DataSource = null;
            chart.Series.Clear();
        }

        public void ChartLoadMeasurement(List<string>[] lstStrReturnReadFile)
        {
            lstDblChReadFileArr = _helperApp.lstDblReturnReadFile;

            var _modelGVL = _helperApp.CalcGraphT01_ET_ForceDiagrams_ForcePressure_WithVacuum(true, lstDblChReadFileArr);

            lblStart.Text = string.Concat(" START : ", DateTime.Now.ToString("hh:mm:ss.fff tt"));

            timeStart = new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);

            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;

            LoadChartDev(_modelGVL);

            Annottion();
        }

        #endregion

        public void loadChartDemo()
        {


            if (chart != null)
            {
                Cursor currentCursor = Cursor.Current;
                Cursor.Current = Cursors.WaitCursor;
            }
            // Create a new chart.
            ChartControl scatterLineChart = new ChartControl();

            // Create a scatter line series.
            Series series1 = new Series("Series 1", ViewType.ScatterLine);

            // Add points to it.
            //series1.Points.Add(new SeriesPoint(1, 2));
            //series1.Points.Add(new SeriesPoint(2, 10));
            //series1.Points.Add(new SeriesPoint(3, 4));
            //series1.Points.Add(new SeriesPoint(4, 12));
            //series1.Points.Add(new SeriesPoint(1.5, 17));
            //series1.Points.Add(new SeriesPoint(2.5, 3));
            //series1.Points.Add(new SeriesPoint(3.5, 14));
            //series1.Points.Add(new SeriesPoint(2, 6));

            int totalPointsCount = lstDblChReadFileArr[2].Count(); //70000
            for (int i = 0; i <= totalPointsCount; i += 4)
            {
                series1.Points.Add(new SeriesPoint(lstDblChReadFileArr[2][i], lstDblChReadFileArr[6][i]));

                //devChart.Series[0].Points.AddRange(
                //    new SeriesPoint(lstDblChReadFileArr[2][i], lstDblChReadFileArr[6][i]));
            }

            // Add the series to the chart.
            scatterLineChart.Series.Add(series1);

            // Set the numerical argument scale types for the series,
            // as it is qualitative, by default.
            series1.ArgumentScaleType = ScaleType.Numerical;

            // Access the view-type-specific options of the series.
            //((ScatterLineSeriesView)series1.View).LineStyle.DashStyle = DashStyle.Dash;

            // Access the type-specific options of the diagram.
            ((XYDiagram)scatterLineChart.Diagram).EnableAxisXZooming = true;

            // Hide the legend (if necessary).
            scatterLineChart.Legend.Visible = false;

            // Add a title to the chart (if necessary).
            scatterLineChart.Titles.Add(new ChartTitle());
            scatterLineChart.Titles[0].Text = "A Scatter Line Chart";

            // Add the chart to the form.



            scatterLineChart.Dock = DockStyle.Top;
            this.Controls.Add(scatterLineChart);
        }
        public void LoadChartDev(Model_GVL modelGVL)
        {
            var chartGVL = modelGVL.GVL_Graficos;
            //loadChartDemo();

            //var diagram = ChartControl.Diagram as DevExpress.XtraCharts.XYDiagram2D;
            //diagram.ZoomingOptions.AxisXMaxZoomPercent = 100000000;
            //diagram.ZoomingOptions.AxisYMaxZoomPercent = 100000000;

            var serieName = EnumExtensionMethods.GetDescriptionEXAMTYPE(HelperTestBase.eExamType);

            int totalPointsCount = lstDblChReadFileArr[2].Count(); //70000
            //AddSeries(InitialPointsCount, false);

            if (devChart.Series.Count > 0)
                ChartClear(devChart);


            var abc = 0;
            // Create a new chart.
            ChartControl scatterLineChart = new ChartControl();

            // Create a scatter line series.
            Series serie = new Series("Series 1", ViewType.ScatterLine);

            //Series serie = new Series();
            //serie.Name = HelperTestBase.eExamType.ToString();
            //serie.View = new ScatterLineSeriesView();

            if (serie.View != null)
                serie.View.Color = Color.DarkCyan; //color line

            int step = (totalPointsCount / 32762) + 1; //serie.Points.Capacity;

            for (int i = 0; i <= totalPointsCount; i += step)
            {
                if (lstDblChReadFileArr[2][i] == 410.297)
                    abc = 1;

                serie.Points.Add(new SeriesPoint(lstDblChReadFileArr[2][i], lstDblChReadFileArr[6][i]));

                //devChart.Series[0].Points.AddRange(
                //    new SeriesPoint(lstDblChReadFileArr[2][i], lstDblChReadFileArr[6][i]));
            }

            // Add the series to the chart.
            devChart.Series.Add(serie);

            // Set the numerical argument scale types for the series,
            // as it is qualitative, by default.
            serie.ArgumentScaleType = ScaleType.Numerical;

            // Access the view-type-specific options of the series.
            //((ScatterLineSeriesView)series1.View).LineStyle.DashStyle = DashStyle.Dash;

            // Access the view-type-specific options of the series.
            //((ScatterLineSeriesView)serie.View).MarkerVisibility = DevExpress.Utils.DefaultBoolean.True;
            //((ScatterLineSeriesView)serie.View).LineMarkerOptions.Kind = MarkerKind.Triangle;
            //((ScatterLineSeriesView)serie.View).LineStyle.DashStyle = DashStyle.Dash;
            XYDiagram diagram = (XYDiagram)devChart.Diagram;

            if (diagram != null)
            {
                #region Pane

                #region Default Pane

                diagram.DefaultPane.Title.Text = "Sales by Region (Units)";
                diagram.DefaultPane.Title.Visibility = DefaultBoolean.True;

                diagram.DefaultPane.LayoutOptions.ColumnSpan = 3;

                diagram.DefaultPane.BackColor = System.Drawing.Color.LightGray;
                diagram.DefaultPane.FillStyle.FillMode = DevExpress.XtraCharts.FillMode.Solid;

                #endregion

                if (false)
                {

                    #region Pane New

                    // Add a new additional pane to the diagram.
                    diagram.Panes.Add(new XYDiagramPane("My Pane"));

                    // Note that the created pane has the zero index in the collection,
                    // because the existing Default pane is a separate entity.
                    //myView.Pane = diagram.Panes[0];

                    // Add titles to panes.

                    diagram.Panes[0].Title.Text = "Revenue (Millions of USD)";
                    diagram.Panes[0].Title.Visibility = DefaultBoolean.True;

                    // Customize the pane layout.
                    diagram.PaneDistance = 10;
                    diagram.PaneLayout.AutoLayoutMode = PaneAutoLayoutMode.Linear;
                    diagram.PaneLayout.Direction = PaneLayoutDirection.Horizontal;

                    diagram.Panes[0].LayoutOptions.ColumnSpan = 2;

                    #endregion

                }
                #endregion

                #region Legend

                // Create a new instance of Legend.
                Legend macdLegend = new Legend();
                chart.Legends.Add(macdLegend);
                // Position it.
                //macdLegend.DockTarget = diagram.Panes.GetPaneByName("macdPane");
                macdLegend.DockTarget = diagram.DefaultPane;

                macdLegend.AlignmentHorizontal = LegendAlignmentHorizontal.Left;
                macdLegend.AlignmentVertical = LegendAlignmentVertical.Top;

                // Assign the data displayed in legend.
                //macd.Legend = macdLegend;

                #endregion

                #region Axes

                // Access the type-specific options of the diagram.
                diagram.EnableAxisXZooming = true;

                //// Set limits for an x-axis's whole range
                //diagram.AxisX.WholeRange.MinValue = 500;
                //diagram.AxisX.WholeRange.MaxValue = 2000;
                //// or use the SetMinMaxValues method to specify range limits.
                //diagram.AxisX.WholeRange.SetMinMaxValues(500, 2000);

                //// Set limits for an x-axis's visual range
                //diagram.AxisX.VisualRange.MinValue = 1000;
                //diagram.AxisX.VisualRange.MaxValue = 1500;
                //// or use the SetMinMaxValues method to specify range limits.
                //diagram.AxisX.VisualRange.SetMinMaxValues(1000, 1500);


                ////  //AXES Y
                diagram.AxisY.Title.EnableAntialiasing = DefaultBoolean.False;
                diagram.AxisY.Title.Font = new Font("Tahoma", 8, FontStyle.Regular);
                diagram.AxisY.Title.Text = chartGVL.strNomeEixoY1;
                diagram.AxisY.Title.TextColor = Color.Blue;
                diagram.AxisY.Label.TextColor = Color.Blue;
                diagram.AxisY.Title.Visibility = DefaultBoolean.True;

                ////  ///AXES X
                //diagram.AxisX.VisualRange.MinValue = diagram.AxisX.GetScaleValueFromInternal(0);
                //diagram.AxisX.VisualRange.MaxValue = diagram.AxisX.GetScaleValueFromInternal(4);

                diagram.AxisX.VisualRange.MinValue = chartGVL.EixoX.rMin;
                diagram.AxisX.VisualRange.MaxValue = chartGVL.EixoX.rMax;

                diagram.AxisX.Title.EnableAntialiasing = DefaultBoolean.False;
                diagram.AxisX.Title.Font = new Font("Tahoma", 8, FontStyle.Regular);
                diagram.AxisX.Title.Text = chartGVL.strNomeEixoX;  //@"nome eixo X";
                diagram.AxisX.Title.TextColor = Color.Red;
                diagram.AxisX.Label.TextColor = Color.Red;
                diagram.AxisX.VisualRange.Auto = false;
                diagram.AxisX.Title.Visibility = DefaultBoolean.True;


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
            }


            // Hide the legend (if necessary).
            devChart.Legend.Visibility = DevExpress.Utils.DefaultBoolean.False;

            // Add a title to the chart (if necessary).
            devChart.Titles.Add(new ChartTitle());
            devChart.Titles[0].Text = serieName;

            devChart.Series.Add(serie);

            devChart.BackColor = Color.LightGray;

            this.Controls.Add(devChart);
        }

        #region #generalcode
        private void Annottion()
        {
            // Create a text annotation. 
            SeriesPoint sp = devChart.Series[0].Points[12465];
            TextAnnotation annotation = new TextAnnotation("Annotation 1", "Lucas olha ai o tal ponto");

            // Change the text annotation font style to bold. 
            if (annotation != null)
                annotation.Font = new Font(annotation.Font.FontFamily, annotation.Font.Size, FontStyle.Bold);

            // Specify the text annotation position. 
            annotation.AnchorPoint = new SeriesPointAnchorPoint(sp);
            annotation.ShapePosition = new RelativePosition();
            RelativePosition position = annotation.ShapePosition as RelativePosition;
            position.ConnectorLength = 50;
            position.Angle = 90;
            annotation.RuntimeMoving = true;

            // Add an annotaion to the annotation repository. 
            devChart.AnnotationRepository.Add(annotation);

            // // Add a text annotation to the chart control's repository.
            // devChart.AnnotationRepository.Add(new TextAnnotation("Annotation 1"));

            // // And, assign a series point to the annotation's AnchorPoint property.
            // // This adds the annotation to the series point's Annotations collection.

            //var pt = devChart.Series[0].Points;
            //// var lst = pt.IndexOf(49861);

            ////var tt = lst.Select(a=>a.va.FindIndex(a=>a.IndexOf(410.297);

            // devChart.AnnotationRepository[0].AnchorPoint =
            //     new SeriesPointAnchorPoint(devChart.Series[0].Points[12465]);

            // // Now, create an image annotation, and add it to the chart's collection.

            // //string imgIcon = string.Concat(Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, _helperApp.AppPath_Icons), "\\ico_TreeNode_Chart2.png");

            // //devChart.Annotations.AddImageAnnotation("Annotation 2", Bitmap.FromFile(imgIcon));
            // ////Bitmap.FromFile(@"...\...\image.png"));

            // //// Define the X and Y absolute coordinates for the annotation, in pixels.
            // //((ChartAnchorPoint)devChart.Annotations[0].AnchorPoint).X = 450;
            // //((ChartAnchorPoint)devChart.Annotations[0].AnchorPoint).Y = 200;

            // //// Obtain the additional pane from the diagram's collection.
            // //XYDiagramPaneBase myPane = ((XYDiagram)devChart.Diagram).Panes[0];

            // //// And, position the chart's annotation in this pane's right top corner;
            // //((FreePosition)devChart.Annotations[0].ShapePosition).DockTarget = myPane;
            // //((FreePosition)devChart.Annotations[0].ShapePosition).DockCorner = DockCorner.RightTop;

            // //// Another annotation is now being added to the collection of this pane.
            // //myPane.Annotations.AddImageAnnotation("Annotation 3", Bitmap.FromFile(imgIcon));

            // //// Define its axis coordinates (in units appropriate for the scale type of the axes).
            // //((PaneAnchorPoint)myPane.Annotations[0].AnchorPoint).AxisXCoordinate.AxisValue = 2;
            // //((PaneAnchorPoint)myPane.Annotations[0].AnchorPoint).AxisYCoordinate.AxisValue = 180;

            // //// Position the annotation in relation to its anchor point.
            // //((RelativePosition)myPane.Annotations[0].ShapePosition).Angle = -135;
            // //((RelativePosition)myPane.Annotations[0].ShapePosition).ConnectorLength = 50;

            // // You can get an annotation either via the collection of the element to which it is anchored,
            // // or centrally, via the chart control's repository (e.g. by its name).
            // TextAnnotation myTextAnnotation =
            //     (TextAnnotation)devChart.AnnotationRepository.GetElementByName("Annotation 1");
            // //ImageAnnotation myImageAnnotation =
            // //    (ImageAnnotation)devChart.AnnotationRepository.GetElementByName("Annotation 2");

            // // Define the text for the text annotation.
            // //myTextAnnotation.Text = "<i>Lucas</i> <b>seu</b> <u>ponto sei la</u> <color=blue>aqui</color>.";
            // myTextAnnotation.Text = "Lucas olha ai o tal ponto";
            // myTextAnnotation.Angle = 0;
            // myTextAnnotation.LabelMode = true;
            // myTextAnnotation.AutoSize = false;
            // myTextAnnotation.Width = 100;
            //  myTextAnnotation.Height = 50;


            // // Enable the interactive positioning for the image annotation.
            // //myImageAnnotation.RuntimeMoving = true;
            // //myImageAnnotation.RuntimeAnchoring = true;
            // //myImageAnnotation.RuntimeResizing = true;
            // //myImageAnnotation.RuntimeRotation = true;

            // //// Specify image annotation size mode.
            // //myImageAnnotation.SizeMode = ChartImageSizeMode.Tile;

            // //// And, adjust image annotation appearance options.
            // //myImageAnnotation.ShapeKind = ShapeKind.RoundedRectangle;
            // //myImageAnnotation.ShapeFillet = 10;
            // //myImageAnnotation.ConnectorStyle = AnnotationConnectorStyle.Arrow;
        }


        #endregion #generalcode

        void AddSeries(int pointsCount, bool showProgressPanel)
        {
            try
            {
                DevExpress.XtraCharts.Series series = new DevExpress.XtraCharts.Series();
                series.Name = "Series " + seriesIndex++;
                ResamplingDataAdapter adapter = new ResamplingDataAdapter() { DataSorted = true };
                //adapter.DataSource = LargeDataGenerator.GenerateSeriesDataSourceSine(pointsCount);
                adapter.SetDataMembers("Argument", "Value");
                series.DataAdapter = adapter;
                series.CrosshairLabelPattern = "{S}:\t{V:0.0}";
                series.View = new SwiftPlotSeriesView();
                //ChartControl.Series.Add(series);
                //totalPointsCount += pointsCount;
                //ChartControl.Titles[1].Text = string.Format("Total Points Count: {0:#,0.}", totalPointsCount);
            }
            catch (OutOfMemoryException)
            {

            }
            finally
            {
            }
        }

        void AddLegend(List<Series> cpuSeries)
        {
            Legend legend;

            foreach (Series series in cpuSeries)
            {
                //series.Legend = legend;
                //series.LegendTextPattern = string.Empty;
            }
        }
    }
}
