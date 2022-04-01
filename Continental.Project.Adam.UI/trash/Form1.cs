using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
//using LiveCharts;
//using LiveCharts.Wpf;
using System.IO;
using System.Text.RegularExpressions;
using System.Globalization;
using LiveCharts.Geared;
//using LiveCharts.Defaults;
//using LiveCharts.Configurations;
using System.Windows.Media;
using DevExpress.XtraCharts;

namespace TesteGrafico
{
    public partial class Form1 : Form
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
        List<double>[] lstDblReturnReadFile = new List<double>[13];

        #endregion
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }
        private void button2_Click(object sender, EventArgs e)
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
                        ;
                        //LoadChartNewArr();
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
                lstDblReturnReadFile[i] = lstStrReturnReadFile[i].ConvertAll(item => double.Parse(item, CultureInfo.InvariantCulture));


            return lstStrReturnReadFile;
        }
        public bool CheckFileExists(string strFilename)
        {
            if (!File.Exists(strFilename))
                return false;

            return true;
        }

        //        public void LoadChartNewArr()
        //        {

        //            foreach (var axisX in Chart1.AxisX.Reverse())
        //            {
        //                if (Chart1.AxisX.Count() > 1)
        //                    Chart1.AxisX.Remove(axisX);
        //            }

        //            Chart1.DisableAnimations = true;
        //            Chart1.Series.Clear();

        //            foreach (var axisY in Chart1.AxisY.Reverse())
        //            {
        //                if (Chart1.AxisY.Count() > 1)
        //                    Chart1.AxisY.Remove(axisY);
        //            }

        //            Chart1.AxisX[0].Foreground = System.Windows.Media.Brushes.Red;
        //            Chart1.AxisX[0].Position = AxisPosition.LeftBottom;
        //            Chart1.AxisX[0].Title = "Força (N)";
        //            Chart1.AxisX[0].MinValue = 0;
        //            Chart1.AxisX[0].MaxValue = 1200;

        //            Chart1.AxisY[0].Foreground = System.Windows.Media.Brushes.BlueViolet;
        //            Chart1.AxisY[0].Position = AxisPosition.LeftBottom;
        //            Chart1.AxisX[0].Title = "Pressao (bar)";
        //            Chart1.AxisY[0].MinValue = 0;
        //            Chart1.AxisY[0].MaxValue = 100;

        //            ChartValues<ObservablePoint> ListPointsPC = new ChartValues<ObservablePoint>();
        //        ChartValues<ObservablePoint> ListPointsSC = new ChartValues<ObservablePoint>();

        //        //    ChartValues<ObservablePoint> ListPointsPC1 = new ChartValues<ObservablePoint>();
        //        //    ChartValues<ObservablePoint> ListPointsPC2 = new ChartValues<ObservablePoint>();
        //        //    ChartValues<ObservablePoint> ListPointsPC3 = new ChartValues<ObservablePoint>();
        //        //    ChartValues<ObservablePoint> ListPointsPC4 = new ChartValues<ObservablePoint>();
        //        //    ChartValues<ObservablePoint> ListPointsPC5 = new ChartValues<ObservablePoint>();
        //        //    ChartValues<ObservablePoint> ListPointsPC6 = new ChartValues<ObservablePoint>();
        //        //    ChartValues<ObservablePoint> ListPointsPC7 = new ChartValues<ObservablePoint>();


        //        int passo = lstDblReturnReadFile[2].Count / 15000;

        //        for (int i = 0; i<lstDblReturnReadFile[2].Count; i += passo)
        //        {
        //            if (lstDblReturnReadFile[2][i] < Chart1.AxisX[0].MaxValue && lstDblReturnReadFile[6][i] < Chart1.AxisY[0].MaxValue)
        //                {
        //                ListPointsPC.Add(new ObservablePoint

        //                {
        //                    X = lstDblReturnReadFile[2][i],
        //                    Y = lstDblReturnReadFile[6][i]
        //    });
        //                }

        //if (lstDblReturnReadFile[2][i] < Chart1.AxisX[0].MaxValue && lstDblReturnReadFile[6][i] < Chart1.AxisY[0].MaxValue)
        //{
        //    ListPointsSC.Add(new ObservablePoint
        //    {
        //        X = lstDblReturnReadFile[2][i],
        //        Y = lstDblReturnReadFile[7][i]
        //    });
        //}
        //        }


        //        //    for (int i = 0; i < 10000; i +=4)
        //        //    {
        //        //        if (lstDblReturnReadFile[2][i] < Chart1.AxisX[0].MaxValue && lstDblReturnReadFile[6][i] < Chart1.AxisY[0].MaxValue)
        //        //        {
        //        //            ListPointsPC1.Add(new ObservablePoint
        //        //            {
        //        //                X = lstDblReturnReadFile[2][i],
        //        //                Y = lstDblReturnReadFile[6][i]
        //        //            });
        //        //        }
        //        //    }

        //        //    for (int i = 10000; i < 20000; i +=4)
        //        //    {
        //        //        if (lstDblReturnReadFile[2][i] < Chart1.AxisX[0].MaxValue && lstDblReturnReadFile[6][i] < Chart1.AxisY[0].MaxValue)
        //        //        {
        //        //            ListPointsPC2.Add(new ObservablePoint
        //        //            {
        //        //                X = lstDblReturnReadFile[2][i],
        //        //                Y = lstDblReturnReadFile[6][i]
        //        //            });
        //        //        }
        //        //    }

        //        //    for (int i = 20000; i < 30000; i +=4)
        //        //    {
        //        //        if (lstDblReturnReadFile[2][i] < Chart1.AxisX[0].MaxValue && lstDblReturnReadFile[6][i] < Chart1.AxisY[0].MaxValue)
        //        //        {
        //        //            ListPointsPC3.Add(new ObservablePoint
        //        //            {
        //        //                X = lstDblReturnReadFile[2][i],
        //        //                Y = lstDblReturnReadFile[6][i]
        //        //            });
        //        //        }            }

        //        //    for (int i = 30000; i < 40000; i +=4)
        //        //    {
        //        //        if (lstDblReturnReadFile[2][i] < Chart1.AxisX[0].MaxValue && lstDblReturnReadFile[6][i] < Chart1.AxisY[0].MaxValue)
        //        //        {
        //        //            ListPointsPC4.Add(new ObservablePoint
        //        //            {
        //        //                X = lstDblReturnReadFile[2][i],
        //        //                Y = lstDblReturnReadFile[6][i]
        //        //            });
        //        //        }
        //        //    }

        //        //    for (int i = 40000; i < 50000; i +=4)
        //        //    {
        //        //        if (lstDblReturnReadFile[2][i] < Chart1.AxisX[0].MaxValue && lstDblReturnReadFile[6][i] < Chart1.AxisY[0].MaxValue)
        //        //        {
        //        //            ListPointsPC5.Add(new ObservablePoint
        //        //            {
        //        //                X = lstDblReturnReadFile[2][i],
        //        //                Y = lstDblReturnReadFile[6][i]
        //        //            });
        //        //        }
        //        //    }

        //        //    for (int i = 50000; i < 60000; i +=4)
        //        //    {
        //        //        if (lstDblReturnReadFile[2][i] < Chart1.AxisX[0].MaxValue && lstDblReturnReadFile[6][i] < Chart1.AxisY[0].MaxValue)
        //        //        {
        //        //            ListPointsPC6.Add(new ObservablePoint
        //        //            {
        //        //                X = lstDblReturnReadFile[2][i],
        //        //                Y = lstDblReturnReadFile[6][i]
        //        //            });
        //        //        }
        //        //    }

        //        //    for (int i = 60000; i < 70000; i +=4)
        //        //    {
        //        //        if (lstDblReturnReadFile[2][i] < Chart1.AxisX[0].MaxValue && lstDblReturnReadFile[6][i] < Chart1.AxisY[0].MaxValue)
        //        //        {
        //        //            ListPointsPC7.Add(new ObservablePoint
        //        //            {
        //        //                X = lstDblReturnReadFile[2][i],
        //        //                Y = lstDblReturnReadFile[6][i]
        //        //            });
        //        //        }
        //        //    }

        //        //    var ListPointsGearedPC = ListPointsPC.AsGearedValues().WithQuality(Quality.Medium);
        //        //    var ListPointsGearedSC = ListPointsSC.AsGearedValues().WithQuality(Quality.Medium);

        //        //    var ListPointsGearedPC1 = ListPointsPC1.AsGearedValues().WithQuality(Quality.Medium);
        //        //    var ListPointsGearedPC2 = ListPointsPC2.AsGearedValues().WithQuality(Quality.Medium);
        //        //    var ListPointsGearedPC3 = ListPointsPC3.AsGearedValues().WithQuality(Quality.Medium);
        //        //    var ListPointsGearedPC4 = ListPointsPC4.AsGearedValues().WithQuality(Quality.Medium);
        //        //    var ListPointsGearedPC5 = ListPointsPC5.AsGearedValues().WithQuality(Quality.Medium);
        //        //    var ListPointsGearedPC6 = ListPointsPC6.AsGearedValues().WithQuality(Quality.Medium);
        //        //    var ListPointsGearedPC7 = ListPointsPC7.AsGearedValues().WithQuality(Quality.Medium);

        //        //    //Chart1.Series.Add(new LineSeries
        //        //    //{
        //        //    //    Values = ListPointsGearedPC,

        //        //    //    StrokeThickness = 1,
        //        //    //    Fill = System.Windows.Media.Brushes.Transparent,
        //        //    //    PointGeometry = null,
        //        //    //    ScalesYAt = 0,
        //        //    //    ScalesXAt = 0

        //        //    //});

        //        //    //Chart1.Series.Add(new LineSeries
        //        //    //{
        //        //    //    Values = ListPointsGearedSC,
        //        //    //    StrokeThickness = 1,
        //        //    //    Fill = System.Windows.Media.Brushes.Transparent,
        //        //    //    PointGeometry = null,
        //        //    //    ScalesYAt = 0,
        //        //    //    ScalesXAt = 0

        //        //    //});

        //        //    Chart1.Series.Add(new LineSeries
        //        //    {
        //        //        Values = ListPointsGearedPC1,
        //        //        StrokeThickness = 0.5,
        //        //        Fill = System.Windows.Media.Brushes.Transparent,
        //        //        PointGeometry = null,
        //        //        ScalesYAt = 0,
        //        //        ScalesXAt = 0

        //        //    });

        //        //    Chart1.Series.Add(new LineSeries
        //        //    {
        //        //        Values = ListPointsGearedPC2,
        //        //        StrokeThickness = 0.5,
        //        //        Fill = System.Windows.Media.Brushes.Transparent,
        //        //        PointGeometry = null,
        //        //        ScalesYAt = 0,
        //        //        ScalesXAt = 0

        //        //    });

        //        //    Chart1.Series.Add(new LineSeries
        //        //    {
        //        //        Values = ListPointsGearedPC3,
        //        //        StrokeThickness = 0.5,
        //        //        Fill = System.Windows.Media.Brushes.Transparent,
        //        //        PointGeometry = null,
        //        //        ScalesYAt = 0,
        //        //        ScalesXAt = 0

        //        //    });

        //        //    Chart1.Series.Add(new LineSeries
        //        //    {
        //        //        Values = ListPointsGearedPC4,
        //        //        StrokeThickness = 0.5,
        //        //        Fill = System.Windows.Media.Brushes.Transparent,
        //        //        PointGeometry = null,
        //        //        ScalesYAt = 0,
        //        //        ScalesXAt = 0

        //        //    });

        //        //    Chart1.Series.Add(new LineSeries
        //        //    {
        //        //        Values = ListPointsGearedPC5,
        //        //        StrokeThickness = 0.5,
        //        //        Fill = System.Windows.Media.Brushes.Transparent,
        //        //        PointGeometry = null,
        //        //        ScalesYAt = 0,
        //        //        ScalesXAt = 0

        //        //    });

        //        //    Chart1.Series.Add(new LineSeries
        //        //    {
        //        //        Values = ListPointsGearedPC6,
        //        //        StrokeThickness = 0.5,
        //        //        Fill = System.Windows.Media.Brushes.Transparent,
        //        //        PointGeometry = null,
        //        //        ScalesYAt = 0,
        //        //        ScalesXAt = 0

        //        //    });

        //        //    Chart1.Series.Add(new LineSeries
        //        //    {
        //        //        Values = ListPointsGearedPC7,
        //        //        StrokeThickness = 0.5,
        //        //        Fill = System.Windows.Media.Brushes.Transparent,
        //        //        PointGeometry = null,

        //        //        ScalesYAt = 0,
        //        //        ScalesXAt = 0

        //        //    });


        //        //    //Chart1.Series.Add(new LineSeries
        //        //    //{

        //        //    //    Values = new ChartValues<ObservablePoint>
        //        //    //        {
        //        //    //            new ObservablePoint(200, 50),
        //        //    //        },
        //        //    //    StrokeThickness = 3,
        //        //    //    Stroke = null,
        //        //    //    Fill = null,
        //        //    //    PointGeometry = DefaultGeometries.Cross,
        //        //    //    PointGeometrySize = 15

        //        //    //});

        //        //    //Chart1.Series.Add(new LineSeries
        //        //    //{

        //        //    //    Values = new ChartValues<ObservablePoint>
        //        //    //        {
        //        //    //            new ObservablePoint(500, 60),
        //        //    //        },
        //        //    //    StrokeThickness = 3,
        //        //    //    Stroke = null,
        //        //    //    Fill = null,
        //        //    //    PointGeometry = DefaultGeometries.Cross,
        //        //    //    PointGeometrySize = 15

        //        //    //});

        //        //    //Chart1.Series.Add(new LineSeries
        //        //    //{

        //        //    //    Values = new ChartValues<ObservablePoint>
        //        //    //        {
        //        //    //            new ObservablePoint(800, 70),
        //        //    //        },
        //        //    //    StrokeThickness = 3,
        //        //    //    Stroke = null,
        //        //    //    Fill = null,
        //        //    //    PointGeometry = DefaultGeometries.Cross,
        //        //    //    PointGeometrySize = 15

        //        //    //});

        //        //    //Chart1.Series.Add(new LineSeries
        //        //    //{

        //        //    //    Values = new ChartValues<ObservablePoint>
        //        //    //        {
        //        //    //            new ObservablePoint(1000, 72),
        //        //    //        },
        //        //    //    StrokeThickness = 3,
        //        //    //    Stroke = null,
        //        //    //    Fill = null,
        //        //    //    PointGeometry = DefaultGeometries.Cross,
        //        //    //    PointGeometrySize = 15

        //        //    //});

        //        //    //Chart1.Series.Add(new LineSeries
        //        //    //{

        //        //    //    Values = new ChartValues<ObservablePoint>
        //        //    //        {
        //        //    //            new ObservablePoint(50, 50),
        //        //    //        },
        //        //    //    StrokeThickness = 3,
        //        //    //    Stroke = null,
        //        //    //    Fill = null,
        //        //    //    PointGeometry = DefaultGeometries.Cross,
        //        //    //    PointGeometrySize = 15

        //        //    //});

        //        //    //Chart1.Series.Add(new LineSeries
        //        //    //{

        //        //    //    Values = new ChartValues<ObservablePoint>
        //        //    //        {
        //        //    //            new ObservablePoint(10, 10),
        //        //    //        },
        //        //    //    StrokeThickness = 3,
        //        //    //    Stroke = null,
        //        //    //    Fill = null,
        //        //    //    PointGeometry = DefaultGeometries.Cross,
        //        //    //    PointGeometrySize = 15

        //        //    //});

        //        //    //Chart1.Series.Add(new LineSeries
        //        //    //{

        //        //    //    Values = new ChartValues<ObservablePoint>
        //        //    //        {
        //        //    //            new ObservablePoint(30, 30),
        //        //    //        },
        //        //    //    StrokeThickness = 3,
        //        //    //    Stroke = null,
        //        //    //    Fill = null,
        //        //    //    PointGeometry = DefaultGeometries.Cross,
        //        //    //    PointGeometrySize = 15

        //        //    //});

        //        //    //Chart1.Series.Add(new LineSeries
        //        //    //{

        //        //    //    Values = new ChartValues<ObservablePoint>
        //        //    //        {
        //        //    //            new ObservablePoint(40, 40),
        //        //    //        },
        //        //    //    StrokeThickness = 3,
        //        //    //    Stroke = null,
        //        //    //    Fill = null,
        //        //    //    PointGeometry = DefaultGeometries.Cross,
        //        //    //    PointGeometrySize = 15

        //        //    //});

        //        //    //Chart1.Series.Add(new LineSeries
        //        //    //{

        //        //    //    Values = new ChartValues<ObservablePoint>
        //        //    //        {
        //        //    //            new ObservablePoint(50, 50),
        //        //    //        },
        //        //    //    StrokeThickness = 3,
        //        //    //    Stroke = null,
        //        //    //    Fill = null,
        //        //    //    PointGeometry = DefaultGeometries.Cross,
        //        //    //    PointGeometrySize = 15

        //        //    //});
        //    }

        private void button9_Click(object sender, EventArgs e)
        {

            Series Dvseries = chartControl1.Series[0];

            for (int i = 0; i <= 69049; i += 5)
            {
                Dvseries.Points.AddRange(
                    new SeriesPoint(lstDblReturnReadFile[2][i], lstDblReturnReadFile[6][i]));
            }


            // and another points.


            // The Points collection provides  Add...Point methods 
            // that allow you to add series points for different view types.
            //northSeries.Points.AddPoint(2011, 2.612);
            //northSeries.Points.AddBubblePoint(2011, 2.612, 1.0);





            //chartControl1.Series.Add(series);


            // The Points collection provides  Add...Point methods 
            // that allow you to add series points for different view types.
            //northSeries.Points.AddPoint(2011, 2.612);
            //northSeries.Points.AddBubblePoint(2011, 2.612, 1.0);
        }
    }
}
                   
    

        
    

