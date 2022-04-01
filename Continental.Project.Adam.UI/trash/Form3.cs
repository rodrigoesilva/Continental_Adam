using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using LiveCharts;
using LiveCharts.Wpf;
using LiveCharts.WinForms;
using System.IO;
using System.Text.RegularExpressions;
using System.Globalization;
using LiveCharts.Geared;
using LiveCharts.Defaults;

namespace Continental.Project.Adam.UI.trash
{
    public partial class Form3 : Form
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
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            LoadTextFileChart(0);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            LoadTextFileChart(1);
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
                    {
                        switch (iTypeLoad)
                        {
                            case 0:
                                LoadChartNewArr();
                                break;
                            case 1:
                                LoadChartGeared();
                                break;
                            default:
                                break;
                        }
                    }
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

        private void ChartClear(LiveCharts.WinForms.CartesianChart liveChart)
        {
            // Update UI component here
            liveChart.Series.Clear();
            foreach (var item in liveChart.AxisY.Reverse())
            {
                if (liveChart.AxisY.Count() > 1)
                    liveChart.AxisY.Remove(item);
            }
        }
        public void LoadChartNewArr()
        {
            //Chart1.DisableAnimations = true;



            //Chart1.AxisX.Add(new Axis
            //{
            //    Foreground = System.Windows.Media.Brushes.Red,
            //    Position = AxisPosition.LeftBottom,
            //    Title = "Força (N)",
            //    //MaxValue = 1500

            //});


            //Chart1.AxisY.Add(new Axis
            //{
            //    Foreground = System.Windows.Media.Brushes.Black,
            //    BarUnit = 1,
            //    Title = "Pressao (bar)",
            //    MaxValue = 150,
            //    MinValue = 0,
            //});

            ////Chart1.AxisY.Add(new Axis
            ////{
            ////    Foreground = System.Windows.Media.Brushes.IndianRed,
            ////    BarUnit = 2,
            ////    Title = "Pressão (bar)",
            ////    Position = AxisPosition.LeftBottom,
            ////    MaxValue = 1500
            ////});

            ////Chart1.AxisY.Add(new Axis
            ////{
            ////    Foreground = System.Windows.Media.Brushes.DarkOliveGreen,
            ////    BarUnit = 3,
            ////    Title = "Deslocamento (mm)",
            ////    Position = AxisPosition.LeftBottom,
            ////    MaxValue = 1500
            ////});

            ////Chart1.AxisY.Add(new Axis
            ////{
            ////    Foreground = System.Windows.Media.Brushes.DarkSlateGray,
            ////    BarUnit = 4,
            ////    Title = "Velocidade (mm/s)",
            ////    Position = AxisPosition.LeftBottom
            ////});

            ////Chart1.AxisY.Add(new Axis
            ////{
            ////    Foreground = System.Windows.Media.Brushes.BlueViolet,
            ////    BarUnit = 5,
            ////    Title = "Vacuo (bar)",
            ////    Position = AxisPosition.LeftBottom
            ////});

            ////var cv = new ChartValues<double>();
            ////var cv = new ChartValues<double>();
            ////cv.AddRange(lstDblChReadFileArr[2]);
            //var cX = lstDblChReadFileArr[2].AsGearedValues().WithQuality(Quality.Medium);
            //var cY = lstDblChReadFileArr[6].AsGearedValues().WithQuality(Quality.Medium);
            //var cZ = lstDblChReadFileArr[7].AsGearedValues().WithQuality(Quality.Medium);



            ////var r = new Random();
            ////ValuesA = new ChartValues<ObservablePoint>();
            ////ValuesB = new ChartValues<ObservablePoint>();
            ////ValuesC = new ChartValues<ObservablePoint>();

            ////for (var i = 0; i < 20; i++)
            ////{
            ////    ValuesA.Add(new ObservablePoint(r.NextDouble() * 10, r.NextDouble() * 10));
            ////    ValuesB.Add(new ObservablePoint(r.NextDouble() * 10, r.NextDouble() * 10));
            ////    ValuesC.Add(new ObservablePoint(r.NextDouble() * 10, r.NextDouble() * 10));
            ////}


            ////for (var i = 0; i < 5000; i++)
            ////{
            ////    //cv.Add(5);
            ////    cv.Add(lstDblChReadFileArr[2][i]);
            ////}

            //ChartValues<ObservablePoint> ListPointsPC = new ChartValues<ObservablePoint>();
            //ChartValues<ObservablePoint> ListPointsSC = new ChartValues<ObservablePoint>();

            ////ListPoints.AddRange(new ObservablePoint {  lstDblChReadFileArr[2], lstDblChReadFileArr[7] });

            ////Chart1.Series = new SeriesCollection
            ////{
            ////    new LineSeries
            ////    {
            ////        Values = ListPoints,


            ////        PointGeometrySize = 5,
            ////        ScalesYAt = 0,
            ////        ScalesXAt = 0
            ////    },

            ////};
            //int passo = lstDblChReadFileArr[2].Count / 15000;

            //for (int i = 0; i < lstDblChReadFileArr[2].Count; i += passo) // lstDblChReadFileArr[2].Count; i++)
            //{
            //    ListPointsPC.Add(new ObservablePoint
            //    {
            //        X = lstDblChReadFileArr[2][i],
            //        Y = lstDblChReadFileArr[6][i]
            //    });
            //    ListPointsSC.Add(new ObservablePoint
            //    {
            //        X = lstDblChReadFileArr[2][i],
            //        Y = lstDblChReadFileArr[7][i]
            //    });
            //}

            //var ListPointsGearedPC = ListPointsPC.AsGearedValues().WithQuality(Quality.Medium);
            //var ListPointsGearedSC = ListPointsSC.AsGearedValues().WithQuality(Quality.Medium);

            ////Chart1.Series.Add(new LineSeries
            ////{
            ////    Values = cX,

            ////    //chart1.Series[0].Points.DataBindY(insertYourArrayHere)
            ////    StrokeThickness = 2,
            ////    Fill = System.Windows.Media.Brushes.Transparent,
            ////    PointGeometry = null,
            ////    ScalesXAt = 0,

            ////});


            //Chart1.Series.Add(new LineSeries
            //{
            //    Values = ListPointsGearedPC,

            //    StrokeThickness = 2,
            //    Fill = System.Windows.Media.Brushes.Transparent,
            //    PointGeometry = null,
            //    ScalesYAt = 0,
            //    ScalesXAt = 0

            //}); ; ;



            //Chart1.Series.Add(new LineSeries
            //{
            //    Values = ListPointsGearedSC,
            //    StrokeThickness = 2,
            //    Fill = System.Windows.Media.Brushes.Transparent,
            //    PointGeometry = null,
            //    ScalesYAt = 1,
            //    ScalesXAt = 0

            //});

            //Chart1.AxisX[0].MinValue = 0;
            //Chart1.AxisX[0].MaxValue = 1500;

            //Chart1.AxisY[0].MinValue = 0;
            //Chart1.AxisY[0].MaxValue = 150;

            //Chart1.AxisY[1].MinValue = 0;
            //Chart1.AxisY[1].MaxValue = 150;

            ////Chart1.AxisY[2].MinValue = 0;
            ////Chart1.AxisY[2].MaxValue = 1000;

            ////Chart1.AxisY[2].MinValue = 0;
            ////Chart1.AxisY[2].MaxValue = 10000;

            ////Chart1.AxisY[2].MinValue = 0;
            ////Chart1.AxisY[2].MaxValue = 100000;


        }
        public void LoadChartGeared()
        {
            /*
            lsChart.DisableAnimations = true;

            ChartValues<ObservablePoint> ListPointsPC = new ChartValues<ObservablePoint>();
            ChartValues<ObservablePoint> ListPointsSC = new ChartValues<ObservablePoint>();

            #region Passo

            int passo = lstDblChReadFileArr[2].Count / 15000;

            for (int i = 0; i < lstDblChReadFileArr[2].Count; i += passo) // lstDblChReadFileArr[2].Count; i++)
            {
                ListPointsPC.Add(new ObservablePoint
                {
                    X = lstDblChReadFileArr[2][i],
                    Y = lstDblChReadFileArr[6][i]
                });
                ListPointsSC.Add(new ObservablePoint
                {
                    X = lstDblChReadFileArr[2][i],
                    Y = lstDblChReadFileArr[7][i]
                });
            }

            var ListPointsGearedPC = ListPointsPC.AsGearedValues().WithQuality(Quality.Low);
            var ListPointsGearedSC = ListPointsSC.AsGearedValues().WithQuality(Quality.Low);

            #endregion

            #region Serie

            ChartClear(lsChart);

            if (lsChart.Series.Count() == 0)
            {
                lsChart.Series.Add(new LineSeries
                {
                    //Stroke = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(107, 185, 69)),
                    //Stroke = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(252, 180, 65)),

                    // Values = new ChartValues<double>(modelChartGVL.arrVarY2)

                    Values = ListPointsGearedPC,

                    StrokeThickness = 0.75,
                    Fill = System.Windows.Media.Brushes.Transparent,
                    LineSmoothness = 0,
                    PointGeometry = null,
                    ScalesYAt = 0,
                    ScalesXAt = 0

                });

                lsChart.Series.Add(new LineSeries
                {
                    Values = ListPointsGearedSC,
                    StrokeThickness = 2,
                    Fill = System.Windows.Media.Brushes.Transparent,
                    PointGeometry = null,
                    ScalesYAt = 1,
                    ScalesXAt = 0

                });
            }

            #endregion

            #region Eixo X

            foreach (var axisX in lsChart.AxisX.Reverse())
            {
                if (lsChart.AxisX.Count() > 1)
                    lsChart.AxisX.Remove(axisX);
            }


            var dblMaxAxisX = lstDblChReadFileArr[2].Max();

            lsChart.AxisX[0] = new LiveCharts.Wpf.Axis
            {
                Foreground = System.Windows.Media.Brushes.DarkOrange, ///color axes Y scale
                //Name = modelChartGVL.EixoX.wsTLLabel.Trim(),
                Title = "Força (N)",
                Position = AxisPosition.LeftBottom,
                MinValue = 0,
                MaxValue = 1500
            };


            #endregion

            #region Eixo Y1


            var dblMaxAxisY1 = lstDblChReadFileArr[6].Max();

            lsChart.AxisY[0] = new Axis
            {
                Foreground = System.Windows.Media.Brushes.DodgerBlue, ///color axes Y scale
                Unit = 1,
                Title = "Pressao (bar)",
                MinValue = 0,
                MaxValue = 150
            };

            #endregion

            #region escala

            //lsChart.AxisX[0].MinValue = 0;
            //lsChart.AxisX[0].MaxValue = 1500;

            //lsChart.AxisY[0].MinValue = 0;
            //lsChart.AxisY[0].MaxValue = 150;

            //lsChart.AxisY[1].MinValue = 0;
            //lsChart.AxisY[1].MaxValue = 150;

            #endregion

            //background chart
            //lsChart.Background = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(34, 46, 49));

            lsChart.DataClick += ChartLS_DataClick;

            */
        }



        private void ChartLS_DataClick(object sender, ChartPoint chartPoint)
        {
            MessageBox.Show("Information Points ( X : " + chartPoint.X + ", Y : " + chartPoint.Y + ")");
        }


    }
}
