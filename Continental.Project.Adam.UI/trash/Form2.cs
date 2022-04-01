using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using System.Globalization;
using DevExpress.XtraCharts;
using DevExpress.XtraSplashScreen;

namespace TesteGrafico
{
    public partial class Form2 : Form
    {
        #region declare

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

        LiveCharts.WinForms.CartesianChart lsChart = new LiveCharts.WinForms.CartesianChart();

        const int InitialPointsCount = 2500000;

        int totalPointsCount = 0;
        int seriesIndex = 1;

        //internal override ChartControl ChartControl
        //{
        //    get { return chart; }
        //}
        //internal override bool ChartDesignerEnabled
        //{
        //    get { return false; }
        //}

        #endregion
        public Form2()
        {
            InitializeComponent();
        }
        private void Form2_Load(object sender, EventArgs e)
        {
        }
        private void bDev_Click(object sender, EventArgs e)
        {
            LoadTextFileChart(2);
        }

        public void LoadTextFileChart(int iTypeLoad)
        {
            List<string>[] lstReturnReadArr = new List<string>[5];

            var dirPathTestFile = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            List<string> lstReturnRead = new List<string>();
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
                        lstReturnReadArr = ReadExistTestFileTextArrNew(fileName, pathWithFileName);

                    if (lstReturnReadArr[0].Count() > 0)
                        LoadChartDev();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }
        public List<string>[] ReadExistTestFileTextArrNew(string fileName, string pathWithFileName)
        {
            if (!string.IsNullOrEmpty(fileName) && !string.IsNullOrEmpty(pathWithFileName) && CheckFileExists(pathWithFileName))
            {
                using (StreamReader file = new StreamReader(pathWithFileName))
                {
                    lstStrReturnReadFileLines = File.ReadLines(pathWithFileName).ToList();

                    foreach (var line in lstStrReturnReadFileLines)
                    {
                        string[] strArray = Regex.Replace(line, @"\n|\r|", "").Split(char.Parse("\t"));

                        if (strArray.Length > 1)
                        {
                            lstStrTimestamp.Add(strArray[0].Trim().Replace(",", "."));
                            lstStrAnalogCh01.Add(strArray[1].Trim().Replace(",", "."));
                            lstStrAnalogCh02.Add(strArray[2].Trim().Replace(",", "."));
                            lstStrAnalogCh03.Add(strArray[3].Trim().Replace(",", "."));
                            lstStrAnalogCh04.Add(strArray[4].Trim().Replace(",", "."));
                            lstStrAnalogCh05.Add(strArray[5].Trim().Replace(",", "."));
                            lstStrAnalogCh06.Add(strArray[6].Trim().Replace(",", "."));
                            lstStrAnalogCh07.Add(strArray[7].Trim().Replace(",", "."));
                            lstStrAnalogCh08.Add(strArray[8].Trim().Replace(",", "."));
                            lstStrAnalogCh09.Add(strArray[9].Trim().Replace(",", "."));
                            lstStrAnalogCh10.Add(strArray[10].Trim().Replace(",", "."));
                            lstStrAnalogCh11.Add(strArray[11].Trim().Replace(",", "."));
                            lstStrAnalogCh12.Add(strArray[12].Trim().Replace(",", "."));
                        }
                    }

                    file.Close();
                }

                lstStrReturnReadFile[0] = lstStrTimestamp;      //  Time [s]
                lstStrReturnReadFile[1] = lstStrAnalogCh01;    //ch9.1 - HelperHBM._rDiffTravel - Transdutor Deslocamento Desvio Linearidade - 0-10 mm (Linearizado)
                lstStrReturnReadFile[2] = lstStrAnalogCh02;    //ch9.2 - HelperHBM._rInputForce1 - Celula Carga Forca Entrada - 0-5 kN (Linearizada)
                lstStrReturnReadFile[3] = lstStrAnalogCh03;    //ch9.3 - HelperHBM._rOutputForce - Celula Carga Forca Saída- 0-10 kN (Linearizada)
                lstStrReturnReadFile[4] = lstStrAnalogCh04;    //ch9.4 - HelperHBM._rTravelTMC - Transdutor Deslocamento Saida Booster - 0-50 mm (Linearizada)
                lstStrReturnReadFile[5] = lstStrAnalogCh05;    //ch9.5 - HelperHBM._rTravelPiston - Transdutor Deslocamento Entrada Booster - 0-50 mm (Linearizada)
                lstStrReturnReadFile[6] = lstStrAnalogCh06;    //ch9.6 - HelperHBM._rPressureSC - Pressao Camara Secundaria CS - 0-250 bar (Linearizada
                lstStrReturnReadFile[7] = lstStrAnalogCh07;    //ch9.7 - HelperHBM._rPressurePC - Pressao Camara Primaria CP - 0-250 bar (Linearizada)
                lstStrReturnReadFile[8] = lstStrAnalogCh08;    //ch9.8 - HelperHBM._rPneumTestPressure - Pressao Teste Bolhas 0-1 bar(Linearizada)
                lstStrReturnReadFile[9] = lstStrAnalogCh09;    //ch9.9 - HelperHBM._rHydrFillPressure - Pressao Sangria 0-6 bar (Linearizada)
                lstStrReturnReadFile[10] = lstStrAnalogCh10;  //ch9.10 - HelperHBM._rVaccum - Pressao Linha Vacuo (-1)-0 bar (Linearizada)
                lstStrReturnReadFile[11] = lstStrAnalogCh11;  //ch9.11 - RESERVA
                lstStrReturnReadFile[12] = lstStrAnalogCh12;  //ch9.12 - RESERVA
            }

            for (int i = 0; i < lstStrReturnReadFile.Length; i++)
                lstDblChReadFileArr[i] = lstStrReturnReadFile[i].ConvertAll(item => double.Parse(item, CultureInfo.InvariantCulture));


            return lstStrReturnReadFile;
        }
        public bool CheckFileExists(string strFilename)
        {
            if (!File.Exists(strFilename))
                return false;

            return true;
        }

        public void LoadChartDev()
        {
            //var diagram = ChartControl.Diagram as DevExpress.XtraCharts.XYDiagram2D;
            //diagram.ZoomingOptions.AxisXMaxZoomPercent = 100000000;
            //diagram.ZoomingOptions.AxisYMaxZoomPercent = 100000000;

            totalPointsCount = lstDblChReadFileArr[2].Count(); //70000
            //AddSeries(InitialPointsCount, false);

            if (chartControl1.Series.Count == 0)
            {
                Series series1 = chartControl2.Series[0];

                Series series2 = new Series("Series " + seriesIndex++, ViewType.ScatterLine);
                series2.ArgumentScaleType = ScaleType.Numerical;

                //series1.ArgumentScaleType = ScaleType.Auto;
                //series1.ValueScaleType = ScaleType.Numerical;

                chartControl1.Series.Add(series2);
            }

            // Hide the legend (if necessary).
            chartControl1.Legend.Visibility = DevExpress.Utils.DefaultBoolean.False;


            //XYDiagram diagram = chartControl1.Diagram as XYDiagram;
            //if (diagram != null)
            //{
            //    diagram.AxisY.Title.Text = "Population mid-year, millions";
            //}

            //DevExpress.XtraCharts.Series Dvseries = chartControl1.Series[0];

            for (int i = 0; i <= totalPointsCount; i += 4)
            {
                chartControl1.Series[0].Points.AddRange(
                    new SeriesPoint(lstDblChReadFileArr[2][i], lstDblChReadFileArr[6][i]));
            }

            // Create two secondary axes, and add them to the chart's Diagram.
            //SecondaryAxisX myAxisX = new SecondaryAxisX("my X-Axis");
            //SecondaryAxisY myAxisY = new SecondaryAxisY("my Y-Axis");

            //((XYDiagram)chartControl1.Diagram).SecondaryAxesX.Add(myAxisX);
            //((XYDiagram)chartControl1.Diagram).SecondaryAxesY.Add(myAxisY);

            //// Assign the series2 to the created axes.
            //((LineSeriesView)series2.View).AxisX = myAxisX;
            //((LineSeriesView)series2.View).AxisY = myAxisY;

            //// Customize the appearance of the secondary axes (optional).
            //myAxisX.Title.Text = "A Secondary X-Axis";
            //myAxisX.Title.Visible = true;
            //myAxisX.Title.TextColor = Color.Red;
            //myAxisX.Label.TextColor = Color.Red;
            //myAxisX.Color = Color.Red;

            //myAxisY.Title.Text = "A Secondary Y-Axis";
            //myAxisY.Title.Visible = true;
            //myAxisY.Title.TextColor = Color.Blue;
            //myAxisY.Label.TextColor = Color.Blue;
            //myAxisY.Color = Color.Blue;

            // Add the chart to the form.
            chartControl1.Dock = DockStyle.Fill;
            this.Controls.Add(chartControl1);
        }

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
    }
}
