using Continental.Project.Adam.UI.BLL;
using Continental.Project.Adam.UI.Enum;
using Continental.Project.Adam.UI.Helper.Com;
using Continental.Project.Adam.UI.Helper.Tests;
using Continental.Project.Adam.UI.Models.COM;
using Continental.Project.Adam.UI.Models.Operational;
using Continental.Project.Adam.UI.Models.Security;
using Continental.Project.Adam.UI.Models.Settings;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Excel = Microsoft.Office.Interop.Excel;

#region PDF

using iText.IO.Font;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Draw;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using iText.Pdfa;
using iText.Kernel.Geom;
using iText.Kernel.Colors;
using iText.Layout.Borders;
using iText.IO.Image;

#endregion

namespace Continental.Project.Adam.UI.Helper
{
    public class HelperApp
    {
        #region Variable

        public string appTime = DateTime.Now.ToString("HH:mm:ss");

        public string appDate = DateTime.Now.ToString("dd/MM/yyyy");

        //Test Executing
        public bool Running { get; set; }

        //Builder TXT
        public StringBuilder sbinterno = new StringBuilder();
        public StringBuilder sbexterno = new StringBuilder();


        Dictionary<string, double> dictVarList = new Dictionary<string, double>();

        HelperAdam _helperAdam = new HelperAdam();

        public Model_GVL _modelGVL = new Model_GVL();

        public StringBuilder sbTestData = new StringBuilder();

        public HelperTestBase _helperTestBase = new HelperTestBase();

        public Model_TabActuationParameters_EvaluationParameters evalParam = new Model_TabActuationParameters_EvaluationParameters();

        public GVL_Graficos GVL_Graficos = new GVL_Graficos();


        List<List<string>> mList = new List<List<string>>();


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


        public List<string> lstStrReturnReadFileLines = new List<string>();
        public List<string>[] lstStrReturnReadFile = new List<string>[13];

        public List<double>[] lstDblReturnReadFile = new List<double>[13];

        Dictionary<string, string>[] dicReturnReadFileHeader = new Dictionary<string, string>[3];
        public string strCharSplit_TXTHeader_Data = "*";

        #endregion

        #region Variable AppConfig

        public string appMsg_Name = ConfigurationManager.AppSettings["AppName"].ToString();

        public string AppMsg_Welcome = ConfigurationManager.AppSettings["AppMsg_Welcome"].ToString();

        public string appMsg_Error = ConfigurationManager.AppSettings["AppMsg_Error"].ToString();

        public bool AppUseSimulateLocal = bool.Parse(ConfigurationManager.AppSettings["AppUseSimulateLocal"].ToString());

        //appImages
        public string AppPath_Imagens = ConfigurationManager.AppSettings["AppPath_Imagens"].ToString();
        public string AppPath_Icons = ConfigurationManager.AppSettings["AppPath_Icons"].ToString();

        //user defined tests
        public string AppUserDefinedTests_Path = ConfigurationManager.AppSettings["AppUserDefinedTests_Path"].ToString();
        public string AppUserDefinedTests_DefaultExtension = ConfigurationManager.AppSettings["AppUserDefinedTests_DefaultExtension"].ToString();

        //user tests
        public bool AppTests_UseBinFormat = bool.Parse(ConfigurationManager.AppSettings["AppTests_UseBinFormat"].ToString());
        public string AppTests_Path = ConfigurationManager.AppSettings["AppTests_Path"].ToString();
        public string AppTests_DefaultExtension = ConfigurationManager.AppSettings["AppTests_DefaultExtension"].ToString();

        //report tests
        public string AppReport_PathTests = ConfigurationManager.AppSettings["AppReport_PathTests"].ToString();
        public string AppReport_PathResources = ConfigurationManager.AppSettings["AppReport_PathResources"].ToString();
        public string AppReport_DefaultExtension = ConfigurationManager.AppSettings["AppReport_DefaultExtension"].ToString();

        //chart Imagens
        public string AppPath_ChartImageTests = ConfigurationManager.AppSettings["AppPath_ChartImageTests"].ToString();
        public string AppPath_ChartImageExtension = ConfigurationManager.AppSettings["AppPath_ChartImageExtension"].ToString();

        //Security        
        public string appCrypto_Key = ConfigurationManager.AppSettings["AppCrypto_Key"].ToString();

        #endregion

        #region Forms

        public BackgroundWorker bgWorker = new BackgroundWorker();

        #region Methods Forms
        //---------------------------------------------------------------------------
        public void Form_Close(Form formOrigin)
        {
            if (formOrigin.IsMdiChild)
                formOrigin.ActiveMdiChild?.Close();

            formOrigin.Hide();
            formOrigin.Close();
        }

        //---------------------------------------------------------------------------
        public void Form_Open(Form formOpen, Form formOrigin)
        {
            // Defined father this screen
            if (formOrigin != null)
            {
                if (formOrigin.IsMdiContainer)
                    formOpen.MdiParent = formOrigin;
            }

            formOpen.StartPosition = FormStartPosition.CenterScreen;
            formOpen.Show();
        }
        //---------------------------------------------------------------------------

        public void Form_Open(Form formOpen)
        {
            formOpen.StartPosition = FormStartPosition.CenterScreen;
            formOpen.Show();
        }
        //---------------------------------------------------------------------------

        public void Form_Center(Form formParent, Form formChild)
        {
            int iTop;
            int iLeft;
            if (formParent.WindowState != 0)
                return;
            iTop = ((formParent.Height - formChild.Height) / 2);
            iLeft = ((formParent.Width - formChild.Width) / 2);

            formChild.Left = iLeft;
            formChild.Top = iTop;
        }

        #endregion

        #region FORM MAIN

        #region FORM MAIN  - TABS

        #region tab_TableParameters
        public List<Model_Operational_TestTableParameters> TabTableParameters_GetTableParam(DataTable dtTableResults, DataGridView grid_tabActionParam_EvalParam, Dictionary<string, string>[] dicReturnReadFileHeader)
        {
            Dictionary<string, string> dicResultParam = new Dictionary<string, string>();

            List<Model_Operational_TestTableParameters> listResultParam = new List<Model_Operational_TestTableParameters>();

            try
            {
                List<ActuationParameters_EvaluationParameters> lstInfoEvaluationParameters = GridView_GetValuesEvalParam(grid_tabActionParam_EvalParam);

                #region Check TEST Results

                switch (HelperApp.uiTesteSelecionado)
                {
                    case 1:     //Force Diagrams - Force/Pressure With Vacuum
                        {
                            #region Results

                            #region Resuls Load Offline

                            if (dicReturnReadFileHeader[0]?.Count() > 0 && HelperTestBase.ProjectTestConcluded.IdProjectTestConcluded > 0 && HelperTestBase.ProjectTestConcluded.IdProject > 0)
                            {
                                var dicReturnReadFileHeaderPrj = dicReturnReadFileHeader[0];
                                var dicReturnReadFileHeaderParam = dicReturnReadFileHeader[1];
                                var dicReturnReadFileHeaderResults = dicReturnReadFileHeader[2];

                                #region Results

                                #region Results_Header

                                HelperTestBase.Model_GVL.GVL_T01.rVacuoInicial = dicReturnReadFileHeaderResults.ContainsKey("Vacuum") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Vacuum"]) : 0;
                                HelperTestBase.Model_GVL.GVL_T01.rGradienteForcaAvanco = dicReturnReadFileHeaderResults.ContainsKey("Force Increase Gradient") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Force Increase Gradient"]) * -1 : 0;
                                HelperTestBase.Model_GVL.GVL_T01.rGradienteDeslocamentoAvanco = dicReturnReadFileHeaderResults.ContainsKey("Actuation Gradient Forward") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Actuation Gradient Forward"]) * -1 : 0;
                                HelperTestBase.Model_GVL.GVL_T01.rForcaMaxima = dicReturnReadFileHeaderResults.ContainsKey("Actuation Force") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Actuation Force"]) * -1 : 0;
                                HelperTestBase.Model_GVL.GVL_T01.rGradienteForcaRetorno = dicReturnReadFileHeaderResults.ContainsKey("Force Decrease Gradient") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Force Decrease Gradient"]) : 0;
                                HelperTestBase.Model_GVL.GVL_T01.rGradienteDeslocamentoRetorno = dicReturnReadFileHeaderResults.ContainsKey("Actuation Gradient Backward") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Actuation Gradient Backward"]) : 0;

                                #endregion

                                #region Results

                                //recupera VARIOS itens que contenham o memso texto e guarda a qtd
                                var matchesPressureAtForce = from k in dicReturnReadFileHeaderResults
                                              where k.Key.Contains("Pressure at")
                                              select new
                                              {
                                                  k.Key,
                                                  k.Value
                                              };

                                HelperTestBase.Model_GVL.GVL_T01.rPressao_E1_Bar = matchesPressureAtForce.Count() > 0 ? NumberDoubleCheck(matchesPressureAtForce.ToList()[0].Value) * -1 : 0;
                                HelperTestBase.Model_GVL.GVL_T01.rPressao_E2_Bar = matchesPressureAtForce.Count() > 0 ? NumberDoubleCheck(matchesPressureAtForce.ToList()[1].Value) * -1 : 0;
                                HelperTestBase.Model_GVL.GVL_T01.rPressao_P1_Bar = matchesPressureAtForce.Count() > 0 ? NumberDoubleCheck(matchesPressureAtForce.ToList()[2].Value) * -1 : 0;
                                HelperTestBase.Model_GVL.GVL_T01.rPressao_P2_Bar = matchesPressureAtForce.Count() > 0 ? NumberDoubleCheck(matchesPressureAtForce.ToList()[3].Value) * -1 : 0;
                                HelperTestBase.Model_GVL.GVL_T01.rRunOutPressure_Real_Bar = dicReturnReadFileHeaderResults.ContainsKey("Runout Pressure") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Runout Pressure"]) * -1 : 0;
                                HelperTestBase.Model_GVL.GVL_T01.rRunOutForce_Real_N = dicReturnReadFileHeaderResults.ContainsKey("Runout Force") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Runout Force"]) * -1 : 0;
                                HelperTestBase.Model_GVL.GVL_T01.rDeslocamentoNaPressao_mm = dicReturnReadFileHeaderResults.Keys.Any(k => k.StartsWith("Travel at")) ? NumberDoubleCheck(dicReturnReadFileHeaderResults.ElementAt(dicReturnReadFileHeaderResults.Keys.Select(x => x.Contains("Travel at")).ToList().FindIndex(a => a.Equals(true))).Value) * -1 : 0;
                                HelperTestBase.Model_GVL.GVL_T01.rPressaoJumper_Bar = dicReturnReadFileHeaderResults.ContainsKey("Jumper") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Jumper"]) * -1 : 0;
                                HelperTestBase.Model_GVL.GVL_T01.rForcaCutIn_N = dicReturnReadFileHeaderResults.ContainsKey("Cut-in Force") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Cut-in Force"]) * -1 : 0;
                                HelperTestBase.Model_GVL.GVL_T01.rReleaseForce_N = dicReturnReadFileHeaderResults.ContainsKey("Release Force") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Release Force"]) * -1 : 0;
                                HelperTestBase.Model_GVL.GVL_T01.rHysterese_Xpout_N = dicReturnReadFileHeaderResults.ContainsKey("Hysteresis at 50 % p out") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Hysteresis at 50 % p out"]) : 0;
                                HelperTestBase.Model_GVL.GVL_T01.rHysterese_Xbar_N = dicReturnReadFileHeaderResults.ContainsKey("Hysteresis at 50 bar") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Hysteresis at 50 bar"]) : 0;
                                HelperTestBase.Model_GVL.GVL_T01.rReleaseForceAt_N = dicReturnReadFileHeaderResults.Keys.Any(k => k.StartsWith("Realease Force at")) ? NumberDoubleCheck(dicReturnReadFileHeaderResults.ElementAt(dicReturnReadFileHeaderResults.Keys.Select(x => x.Contains("Realease Force at")).ToList().FindIndex(a => a.Equals(true))).Value) * -1 : 0;
                                HelperTestBase.Model_GVL.GVL_T01.rPressaoAuxiliar_P3_Bar = dicReturnReadFileHeaderResults.ContainsKey("Auxiliary Pressure") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Auxiliary Pressure"]) : 0;
                                HelperTestBase.Model_GVL.GVL_T01.rTaxaAmplificacao = dicReturnReadFileHeaderResults.ContainsKey("Output Input Radio") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Output Input Radio"]) : 0;
                                HelperTestBase.Model_GVL.GVL_T01.rPressao_90pout_bar = dicReturnReadFileHeaderResults.Keys.Any(k => k.StartsWith("Pressure at 90.0 %")) ? NumberDoubleCheck(dicReturnReadFileHeaderResults.ElementAt(dicReturnReadFileHeaderResults.Keys.Select(x => x.Contains("Pressure at 90.0 %")).ToList().FindIndex(a => a.Equals(true))).Value) * -1 : 0;
                                HelperTestBase.Model_GVL.GVL_T01.rPressao_70pout_bar = dicReturnReadFileHeaderResults.Keys.Any(k => k.StartsWith("Pressure at 70.0 %")) ? NumberDoubleCheck(dicReturnReadFileHeaderResults.ElementAt(dicReturnReadFileHeaderResults.Keys.Select(x => x.Contains("Pressure at 70.0 %")).ToList().FindIndex(a => a.Equals(true))).Value) * -1 : 0;
                                
                                //define captions data
                                HelperTestBase.Model_GVL.GVL_T01.rForca_90pout_N = dicReturnReadFileHeaderResults.ContainsKey("") ? Convert.ToDouble(dicReturnReadFileHeaderResults["Vacuum"]) : 0;
                                HelperTestBase.Model_GVL.GVL_T01.rForca_70pout_N = dicReturnReadFileHeaderResults.ContainsKey("") ? Convert.ToDouble(dicReturnReadFileHeaderResults["Vacuum"]) : 0;

                                //jumper gradient
                                HelperTestBase.Model_GVL.GVL_T01.rForcaP2Jumper_N = dicReturnReadFileHeaderResults.ContainsKey("") ? Convert.ToDouble(dicReturnReadFileHeaderResults["Vacuum"]) : 0;
                                HelperTestBase.Model_GVL.GVL_T01.rGradienteJumper_P2_Bar = dicReturnReadFileHeaderResults.ContainsKey("") ? Convert.ToDouble(dicReturnReadFileHeaderResults["Vacuum"]) : 0;
                                HelperTestBase.Model_GVL.GVL_T01.rForcaP1Jumper_N = dicReturnReadFileHeaderResults.ContainsKey("") ? Convert.ToDouble(dicReturnReadFileHeaderResults["Vacuum"]) : 0;
                                HelperTestBase.Model_GVL.GVL_T01.rGradienteJumper_P1_Bar = dicReturnReadFileHeaderResults.Keys.Any(k => k.StartsWith("Jumper Gradient (")) ? Convert.ToDouble(dicReturnReadFileHeaderResults.Keys.Any(k => k.StartsWith("Jumper Gradient ("))) : 0;


                                //TEMPORARIO
                                HelperTestBase.Model_GVL.GVL_T01.temp_rRunOutForce_Real_N = HelperTestBase.Model_GVL.GVL_T01.rRunOutForce_Real_N;
                                HelperTestBase.Model_GVL.GVL_T01.temp_rRunOutPressure_Real_Bar = HelperTestBase.Model_GVL.GVL_T01.rRunOutPressure_Real_Bar;

                                #endregion

                                #region Results_Footer

                                HelperTestBase.Model_GVL.GVL_T01.iConsumidoresCP = dicReturnReadFileHeaderResults.ContainsKey("PC Hose Consumers") ? Convert.ToInt32(dicReturnReadFileHeaderResults["PC Hose Consumers"]) : 0;
                                HelperTestBase.Model_GVL.GVL_T01.iConsumidoresCS = dicReturnReadFileHeaderResults.ContainsKey("SC Hose Consumers") ? Convert.ToInt32(dicReturnReadFileHeaderResults["SC Hose Consumers"]) : 0;
                                HelperTestBase.Model_GVL.GVL_T01.rTemperaturaInicial = dicReturnReadFileHeaderResults.ContainsKey("Room Temperature") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Room Temperature"]) * -1 : 0;

                                #endregion

                                #endregion

                            }

                            #endregion

                            #region #region Results_Header

                            dicResultParam.Add("resultCalcTestParam_Vacuum", Math.Round(HelperTestBase.Model_GVL.GVL_T01.rVacuoInicial, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_ForceIncreaseGradient", Math.Round(HelperTestBase.Model_GVL.GVL_T01.rGradienteForcaAvanco, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_ActuationGradientForward", Math.Round(HelperTestBase.Model_GVL.GVL_T01.rGradienteDeslocamentoAvanco, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_ActuationForce", Math.Round(HelperTestBase.Model_GVL.GVL_T01.rForcaMaxima, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_ForceDecreaseGradient", Math.Round(HelperTestBase.Model_GVL.GVL_T01.rGradienteForcaRetorno, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_ActuationGradientBackward", Math.Round(HelperTestBase.Model_GVL.GVL_T01.rGradienteDeslocamentoRetorno, 2).ToString());

                            #endregion

                            #region Results

                            dicResultParam.Add("resultCalcTestParam_PressureAtForceE1", Math.Round(HelperTestBase.Model_GVL.GVL_T01.rPressao_E1_Bar, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_PressureAtForceE2", Math.Round(HelperTestBase.Model_GVL.GVL_T01.rPressao_E2_Bar, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_PressureAtForceP1", Math.Round(HelperTestBase.Model_GVL.GVL_T01.rPressao_P1_Bar, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_PressureAtForceP2", Math.Round(HelperTestBase.Model_GVL.GVL_T01.rPressao_P2_Bar, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_RunoutPressure", Math.Round(HelperTestBase.Model_GVL.GVL_T01.rRunOutPressure_Real_Bar, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_RunoutForce", Math.Round(HelperTestBase.Model_GVL.GVL_T01.rRunOutForce_Real_N, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_TravelAtPressure", Math.Round(HelperTestBase.Model_GVL.GVL_T01.rDeslocamentoNaPressao_mm, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_Jumper", Math.Round(HelperTestBase.Model_GVL.GVL_T01.rPressaoJumper_Bar, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_CutInForce", Math.Round(HelperTestBase.Model_GVL.GVL_T01.rForcaCutIn_N, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_ReleaseForce", Math.Round(HelperTestBase.Model_GVL.GVL_T01.rReleaseForce_N, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_HysteresisAtPressure", Math.Round(HelperTestBase.Model_GVL.GVL_T01.rHysterese_Xpout_N, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_HysteresisAtPressure2", Math.Round(HelperTestBase.Model_GVL.GVL_T01.rHysterese_Xbar_N, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_ReleaseForceRemainingAt", Math.Round(HelperTestBase.Model_GVL.GVL_T01.rReleaseForceAt_N, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_AuxiliaryPressure", Math.Round(HelperTestBase.Model_GVL.GVL_T01.rPressaoAuxiliar_P3_Bar, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_OutputInputRadio", Math.Round(HelperTestBase.Model_GVL.GVL_T01.rTaxaAmplificacao, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_PressureAt90Percent", Math.Round(HelperTestBase.Model_GVL.GVL_T01.rPressao_90pout_bar, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_PressureAt70Percent", Math.Round(HelperTestBase.Model_GVL.GVL_T01.rPressao_70pout_bar, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_JumperGradient", Math.Round(HelperTestBase.Model_GVL.GVL_T01.rGradientJumper, 2).ToString());

                            //define captions data
                            dicResultParam.Add("resultCalcTestParam_ForcaAt90Percent", Math.Round(HelperTestBase.Model_GVL.GVL_T01.rForca_90pout_N, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_ForcaAt70Percent", Math.Round(HelperTestBase.Model_GVL.GVL_T01.rForca_70pout_N, 2).ToString());

                            //jumper gradient
                            dicResultParam.Add("resultCalcTestParam_ForcaP2Jumper_N", Math.Round(HelperTestBase.Model_GVL.GVL_T01.rForcaP2Jumper_N, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_GradienteJumper_P2_Bar", Math.Round(HelperTestBase.Model_GVL.GVL_T01.rGradienteJumper_P2_Bar, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_ForcaP1Jumper_N", Math.Round(HelperTestBase.Model_GVL.GVL_T01.rForcaP1Jumper_N, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_GradienteJumper_P1_Bar", Math.Round(HelperTestBase.Model_GVL.GVL_T01.rGradienteJumper_P1_Bar, 2).ToString());


                            //TEMPORARIO
                            HelperTestBase.Model_GVL.GVL_T01.temp_rRunOutForce_Real_N = HelperTestBase.Model_GVL.GVL_T01.rRunOutForce_Real_N;
                            HelperTestBase.Model_GVL.GVL_T01.temp_rRunOutPressure_Real_Bar = HelperTestBase.Model_GVL.GVL_T01.rRunOutPressure_Real_Bar;

                            #endregion

                            #region Results_Footer

                            dicResultParam.Add("resultCalcTestParam_PCHoseConsumers", HelperTestBase.Model_GVL.GVL_T01.iConsumidoresCP.ToString());
                            dicResultParam.Add("resultCalcTestParam_SCHoseConsumers", HelperTestBase.Model_GVL.GVL_T01.iConsumidoresCS.ToString());
                            dicResultParam.Add("resultCalcTestParam_RoomTemperature", Math.Round(HelperTestBase.Model_GVL.GVL_T01.rTemperaturaInicial, 2).ToString());

                            #endregion

                            HelperTestBase.Model_GVL.helperTestBase_ModelGVL_Test = HelperTestBase.Model_GVL.GVL_T01;

                            #endregion

                            break;
                        }
                    case 2:     //Force Diagrams - Force/Force With Vacuum
                        {
                            #region Results

                            #region Resuls Load Offline

                            if (dicReturnReadFileHeader[0]?.Count() > 0 && HelperTestBase.ProjectTestConcluded.IdProjectTestConcluded > 0 && HelperTestBase.ProjectTestConcluded.IdProject > 0)
                            {
                                var dicReturnReadFileHeaderPrj = dicReturnReadFileHeader[0];
                                var dicReturnReadFileHeaderParam = dicReturnReadFileHeader[1];
                                var dicReturnReadFileHeaderResults = dicReturnReadFileHeader[2];

                                #region Results

                                #region Results_Header

                                HelperTestBase.Model_GVL.GVL_T02.rVacuoInicial = dicReturnReadFileHeaderResults.ContainsKey("Vacuum") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Vacuum"]) : 0;
                                HelperTestBase.Model_GVL.GVL_T02.rGradienteForcaAvanco = dicReturnReadFileHeaderResults.ContainsKey("Force Increase Gradient") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Force Increase Gradient"]) * -1 : 0;
                                HelperTestBase.Model_GVL.GVL_T02.rGradienteDeslocamentoAvanco = dicReturnReadFileHeaderResults.ContainsKey("Actuation Gradient Forward") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Actuation Gradient Forward"]) * -1 : 0;
                                HelperTestBase.Model_GVL.GVL_T02.rForcaMaxima = dicReturnReadFileHeaderResults.ContainsKey("Actuation Force") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Actuation Force"]) * -1 : 0;
                                HelperTestBase.Model_GVL.GVL_T02.rGradienteForcaRetorno = dicReturnReadFileHeaderResults.ContainsKey("Force Decrease Gradient") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Force Decrease Gradient"]) : 0;
                                HelperTestBase.Model_GVL.GVL_T02.rGradienteDeslocamentoRetorno = dicReturnReadFileHeaderResults.ContainsKey("Actuation Gradient Backward") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Actuation Gradient Backward"]) : 0;

                                #endregion

                                #region Results

                                //recupera VARIOS itens que contenham o memso texto e guarda a qtd
                                var matchesOutputForceAt = from k in dicReturnReadFileHeaderResults
                                                             where k.Key.Contains("Output Force at")
                                                             select new
                                                             {
                                                                 k.Key,
                                                                 k.Value
                                                             };
                                HelperTestBase.Model_GVL.GVL_T02.rForcaOutJumper_N = dicReturnReadFileHeaderResults.ContainsKey("Jumper") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Jumper"]) * -1 : 0;
                                HelperTestBase.Model_GVL.GVL_T02.rForca_E1 = matchesOutputForceAt.Count() > 0 ? NumberDoubleCheck(matchesOutputForceAt.ToList()[0].Value) * -1 : 0;
                                HelperTestBase.Model_GVL.GVL_T02.rForca_E2 = matchesOutputForceAt.Count() > 0 ? NumberDoubleCheck(matchesOutputForceAt.ToList()[1].Value) * -1 : 0;
                                HelperTestBase.Model_GVL.GVL_T02.rForca_P1 = matchesOutputForceAt.Count() > 0 ? NumberDoubleCheck(matchesOutputForceAt.ToList()[2].Value) * -1 : 0;
                                HelperTestBase.Model_GVL.GVL_T02.rForca_P2 = matchesOutputForceAt.Count() > 0 ? NumberDoubleCheck(matchesOutputForceAt.ToList()[3].Value) * -1 : 0;
                                HelperTestBase.Model_GVL.GVL_T02.rRunOutForceOut_Real_N = dicReturnReadFileHeaderResults.ContainsKey("Output Force Runout") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Output Force Runout"]) * -1 : 0;
                                HelperTestBase.Model_GVL.GVL_T02.rRunOutForce_Real_N = dicReturnReadFileHeaderResults.ContainsKey("Runout Force") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Runout Force"]) * -1 : 0;
                                HelperTestBase.Model_GVL.GVL_T02.rTaxaAmplificacao = dicReturnReadFileHeaderResults.ContainsKey("Output Input Radio") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Output Input Radio"]) : 0;
                                //HelperTestBase.Model_GVL.GVL_T02.rDeslocamentoNaForca_mm = dicReturnReadFileHeaderResults.Keys.Any(k => k.StartsWith("Travel at")) ? NumberDoubleCheck(dicReturnReadFileHeaderResults.ElementAt(dicReturnReadFileHeaderResults.Keys.Select(x => x.Contains("Travel at")).ToList().FindIndex(a => a.Equals(true))).Value) * -1 : 0;
                                HelperTestBase.Model_GVL.GVL_T02.rForcaCutIn_N = dicReturnReadFileHeaderResults.ContainsKey("Cut-in Force") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Cut-in Force"]) * -1 : 0;
                                HelperTestBase.Model_GVL.GVL_T02.rReleaseForce_N = dicReturnReadFileHeaderResults.ContainsKey("Release Force") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Release Force"]) * -1 : 0;
                                HelperTestBase.Model_GVL.GVL_T02.rHysterese_XFout_N= dicReturnReadFileHeaderResults.ContainsKey("Hysteresis at {0} % f out") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Hysteresis at 50 % p out"]) : 0;
                                //HelperTestBase.Model_GVL.GVL_T02.rHysterese_XFout_N = dicReturnReadFileHeaderResults.ContainsKey("Hysteresis at 50 bar") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Hysteresis at 50 bar"]) : 0;
                                HelperTestBase.Model_GVL.GVL_T02.rReleaseForceAt_N = dicReturnReadFileHeaderResults.Keys.Any(k => k.StartsWith("Release Force at {0} mm")) ? NumberDoubleCheck(dicReturnReadFileHeaderResults.ElementAt(dicReturnReadFileHeaderResults.Keys.Select(x => x.Contains("Realease Force at")).ToList().FindIndex(a => a.Equals(true))).Value) * -1 : 0;
                                HelperTestBase.Model_GVL.GVL_T02.rForcaAuxiliar_P3_N = dicReturnReadFileHeaderResults.ContainsKey("Auxiliary Force") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Auxiliary Pressure"]) : 0;
                                
                                HelperTestBase.Model_GVL.GVL_T02.rForcaOut_90Fout_N = dicReturnReadFileHeaderResults.Keys.Any(k => k.StartsWith("Output Force at 90.0 % (= {0} N)")) ? NumberDoubleCheck(dicReturnReadFileHeaderResults.ElementAt(dicReturnReadFileHeaderResults.Keys.Select(x => x.Contains("Pressure at 90.0 %")).ToList().FindIndex(a => a.Equals(true))).Value) * -1 : 0;
                                HelperTestBase.Model_GVL.GVL_T02.rForcaOut_70Fout_N = dicReturnReadFileHeaderResults.Keys.Any(k => k.StartsWith("Output Force at 70.0 % (= {0} N)")) ? NumberDoubleCheck(dicReturnReadFileHeaderResults.ElementAt(dicReturnReadFileHeaderResults.Keys.Select(x => x.Contains("Pressure at 70.0 %")).ToList().FindIndex(a => a.Equals(true))).Value) * -1 : 0;

                                //define captions data
                                HelperTestBase.Model_GVL.GVL_T02.rForcaOut_90Fout_N = dicReturnReadFileHeaderResults.ContainsKey("") ? Convert.ToDouble(dicReturnReadFileHeaderResults["Vacuum"]) : 0;
                                HelperTestBase.Model_GVL.GVL_T02.rForcaOut_70Fout_N = dicReturnReadFileHeaderResults.ContainsKey("") ? Convert.ToDouble(dicReturnReadFileHeaderResults["Vacuum"]) : 0;

                                //jumper gradient
                                HelperTestBase.Model_GVL.GVL_T02.rForcaP2Jumper_N = dicReturnReadFileHeaderResults.ContainsKey("") ? Convert.ToDouble(dicReturnReadFileHeaderResults["Vacuum"]) : 0;
                                HelperTestBase.Model_GVL.GVL_T02.rGradienteJumper_P2_N = dicReturnReadFileHeaderResults.Keys.Any(k => k.StartsWith("Jumper Gradient (")) ? Convert.ToDouble(dicReturnReadFileHeaderResults.Keys.Any(k => k.StartsWith("Jumper Gradient ("))) : 0;
                                HelperTestBase.Model_GVL.GVL_T02.rForcaP1Jumper_N = dicReturnReadFileHeaderResults.ContainsKey("") ? Convert.ToDouble(dicReturnReadFileHeaderResults["Vacuum"]) : 0;
                                HelperTestBase.Model_GVL.GVL_T02.rGradienteJumper_P1_N = dicReturnReadFileHeaderResults.Keys.Any(k => k.StartsWith("Jumper Gradient (")) ? Convert.ToDouble(dicReturnReadFileHeaderResults.Keys.Any(k => k.StartsWith("Jumper Gradient ("))) : 0;


                                #endregion

                                #region Results_Footer

                                HelperTestBase.Model_GVL.GVL_T02.iConsumidoresCP = dicReturnReadFileHeaderResults.ContainsKey("PC Hose Consumers") ? Convert.ToInt32(dicReturnReadFileHeaderResults["PC Hose Consumers"]) : 0;
                                HelperTestBase.Model_GVL.GVL_T02.iConsumidoresCS = dicReturnReadFileHeaderResults.ContainsKey("SC Hose Consumers") ? Convert.ToInt32(dicReturnReadFileHeaderResults["SC Hose Consumers"]) : 0;
                                HelperTestBase.Model_GVL.GVL_T02.rTemperaturaInicial = dicReturnReadFileHeaderResults.ContainsKey("Room Temperature") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Room Temperature"]) * -1 : 0;

                                #endregion

                                #endregion

                            }

                            #endregion

                            #region #region Results_Header

                            dicResultParam.Add("resultCalcTestParam_T02_Vacuum", Math.Round(HelperTestBase.Model_GVL.GVL_T02.rVacuoInicial, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_T02_ForceIncreaseGradient", Math.Round(HelperTestBase.Model_GVL.GVL_T02.rGradienteForcaAvanco, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_T02_ActuationGradientForward", Math.Round(HelperTestBase.Model_GVL.GVL_T02.rGradienteDeslocamentoAvanco, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_T02_ActuationForce", Math.Round(HelperTestBase.Model_GVL.GVL_T02.rForcaMaxima, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_T02_ForceDecreaseGradient", Math.Round(HelperTestBase.Model_GVL.GVL_T02.rGradienteForcaRetorno, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_T02_ActuationGradientBackward", Math.Round(HelperTestBase.Model_GVL.GVL_T02.rGradienteDeslocamentoRetorno, 2).ToString());

                            #endregion

                            #region Results

                            dicResultParam.Add("resultCalcTestParam_T02_Jumper", Math.Round(HelperTestBase.Model_GVL.GVL_T02.rForcaOutJumper_N, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_T02_OutputForceAtE1", Math.Round(HelperTestBase.Model_GVL.GVL_T02.rForcaOut_E1_N, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_T02_OutputForceAtE2", Math.Round(HelperTestBase.Model_GVL.GVL_T02.rForcaOut_E2_N, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_T02_OutputForceAtE5", Math.Round(HelperTestBase.Model_GVL.GVL_T02.rForcaOut_P1_N, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_T02_OutputForceAtE6", Math.Round(HelperTestBase.Model_GVL.GVL_T02.rForcaOut_P2_N, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_T02_OutputForceRunout", Math.Round(HelperTestBase.Model_GVL.GVL_T02.rRunOutForceOut_Real_N, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_T02_RunoutForce", Math.Round(HelperTestBase.Model_GVL.GVL_T02.rRunOutForce_Real_N, 2).ToString());                            
                            dicResultParam.Add("resultCalcTestParam_T02_OutputInputRatio", Math.Round(HelperTestBase.Model_GVL.GVL_T02.rTaxaAmplificacao, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_T02_CutInForce", Math.Round(HelperTestBase.Model_GVL.GVL_T02.rForcaCutIn_N, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_T02_ReleaseForce", Math.Round(HelperTestBase.Model_GVL.GVL_T02.rReleaseForce_N, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_T02_HysteresisAtForce", Math.Round(HelperTestBase.Model_GVL.GVL_T02.rHysterese_XFout_N, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_T02_ReleaseForceRemainingAt", Math.Round(HelperTestBase.Model_GVL.GVL_T02.rReleaseForceAt_N, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_T02_AuxiliaryForce", Math.Round(HelperTestBase.Model_GVL.GVL_T02.rForcaAuxiliar_P3_N, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_T02_ForceAt90Percent", Math.Round(HelperTestBase.Model_GVL.GVL_T02.rForcaOut_90Fout_N, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_T02_ForceAt70Percent", Math.Round(HelperTestBase.Model_GVL.GVL_T02.rForcaOut_70Fout_N, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_T02_JumperGradient", Math.Round(HelperTestBase.Model_GVL.GVL_T02.rGradientJumper, 2).ToString());

                            //jumper gradient
                            dicResultParam.Add("resultCalcTestParam_T02_ForcaP2Jumper_N", Math.Round(HelperTestBase.Model_GVL.GVL_T02.rForcaP2Jumper_N, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_T02_GradienteJumper_P2_Bar", Math.Round(HelperTestBase.Model_GVL.GVL_T02.rGradienteJumper_P2_N, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_T02_ForcaP1Jumper_N", Math.Round(HelperTestBase.Model_GVL.GVL_T02.rForcaP1Jumper_N, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_T02_GradienteJumper_P1_Bar", Math.Round(HelperTestBase.Model_GVL.GVL_T02.rGradienteJumper_P1_N, 2).ToString());

                            #endregion

                            #region Results_Footer

                            dicResultParam.Add("resultCalcTestParam_T02_PCHoseConsumers", 0.ToString());
                            dicResultParam.Add("resultCalcTestParam_T02_SCHoseConsumers", 0.ToString());
                            dicResultParam.Add("resultCalcTestParam_T02_RoomTemperature", Math.Round(HelperTestBase.Model_GVL.GVL_T02.rTemperaturaInicial, 2).ToString());

                            #endregion

                            HelperTestBase.Model_GVL.helperTestBase_ModelGVL_Test = HelperTestBase.Model_GVL.GVL_T02;

                            #endregion

                            break;
                        }
                    case 3:     //Force Diagrams - Force/Pressure Without Vacuum
                        {
                            #region Results

                            #region Resuls Load Offline

                            if (dicReturnReadFileHeader[0]?.Count() > 0 && HelperTestBase.ProjectTestConcluded.IdProjectTestConcluded > 0 && HelperTestBase.ProjectTestConcluded.IdProject > 0)
                            {
                                var dicReturnReadFileHeaderPrj = dicReturnReadFileHeader[0];
                                var dicReturnReadFileHeaderParam = dicReturnReadFileHeader[1];
                                var dicReturnReadFileHeaderResults = dicReturnReadFileHeader[2];

                                #region Results

                                #region Results_Header

                                HelperTestBase.Model_GVL.GVL_T03.rVacuoInicial = dicReturnReadFileHeaderResults.ContainsKey("Vacuum") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Vacuum"]) : 0;
                                HelperTestBase.Model_GVL.GVL_T03.rGradienteForcaAvanco = dicReturnReadFileHeaderResults.ContainsKey("Force Increase Gradient") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Force Increase Gradient"]) * -1 : 0;
                                HelperTestBase.Model_GVL.GVL_T03.rGradienteDeslocamentoAvanco = dicReturnReadFileHeaderResults.ContainsKey("Actuation Gradient Forward") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Actuation Gradient Forward"]) * -1 : 0;
                                HelperTestBase.Model_GVL.GVL_T03.rForcaMaxima = dicReturnReadFileHeaderResults.ContainsKey("Actuation Force") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Actuation Force"]) * -1 : 0;
                                HelperTestBase.Model_GVL.GVL_T03.rGradienteForcaRetorno = dicReturnReadFileHeaderResults.ContainsKey("Force Decrease Gradient") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Force Decrease Gradient"]) : 0;
                                HelperTestBase.Model_GVL.GVL_T03.rGradienteDeslocamentoRetorno = dicReturnReadFileHeaderResults.ContainsKey("Actuation Gradient Backward") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Actuation Gradient Backward"]) : 0;

                                #endregion

                                #region Results

                                //dicReturnReadFileHeaderResults.Keys.Any(k => k.StartsWith("Jumper Gradient ("))
                                var matchesPressureAtForce = from k in dicReturnReadFileHeaderResults
                                                             where k.Key.Contains("Pressure at")
                                                             select new
                                                             {
                                                                 k.Key,
                                                                 k.Value
                                                             };

                                HelperTestBase.Model_GVL.GVL_T03.rForcaCutIn_N = dicReturnReadFileHeaderResults.ContainsKey("Cut-in Force") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Cut-in Force"]) * -1 : 0;
                                HelperTestBase.Model_GVL.GVL_T03.rReleaseForce_N = dicReturnReadFileHeaderResults.ContainsKey("Release Force") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Release Force"]) * -1 : 0;
                                HelperTestBase.Model_GVL.GVL_T03.rReleaseForceAt_N = dicReturnReadFileHeaderResults.Keys.Any(k => k.StartsWith("Realease Force at")) ? NumberDoubleCheck(dicReturnReadFileHeaderResults.ElementAt(dicReturnReadFileHeaderResults.Keys.Select(x => x.Contains("Realease Force at")).ToList().FindIndex(a => a.Equals(true))).Value) * -1 : 0;
                                HelperTestBase.Model_GVL.GVL_T03.rPressao_E1_Bar = matchesPressureAtForce.Count() > 0 ? NumberDoubleCheck(matchesPressureAtForce.ToList()[0].Value) * -1 : 0;
                                HelperTestBase.Model_GVL.GVL_T03.rPressao_E2_Bar = matchesPressureAtForce.Count() > 0 ? NumberDoubleCheck(matchesPressureAtForce.ToList()[1].Value) * -1 : 0;
                                HelperTestBase.Model_GVL.GVL_T03.rPressao_P1_Bar = matchesPressureAtForce.Count() > 0 ? NumberDoubleCheck(matchesPressureAtForce.ToList()[2].Value) * -1 : 0;
                                HelperTestBase.Model_GVL.GVL_T03.rPressao_P2_Bar = matchesPressureAtForce.Count() > 0 ? NumberDoubleCheck(matchesPressureAtForce.ToList()[3].Value) * -1 : 0;

                                #endregion

                                #region Results_Footer

                                HelperTestBase.Model_GVL.GVL_T03.iConsumidoresCP = dicReturnReadFileHeaderResults.ContainsKey("PC Hose Consumers") ? Convert.ToInt32(dicReturnReadFileHeaderResults["PC Hose Consumers"]) : 0;
                                HelperTestBase.Model_GVL.GVL_T03.iConsumidoresCS = dicReturnReadFileHeaderResults.ContainsKey("SC Hose Consumers") ? Convert.ToInt32(dicReturnReadFileHeaderResults["SC Hose Consumers"]) : 0;
                                HelperTestBase.Model_GVL.GVL_T03.rTemperaturaInicial = dicReturnReadFileHeaderResults.ContainsKey("Room Temperature") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Room Temperature"]) * -1 : 0;

                                #endregion

                                #endregion

                            }

                            #endregion

                            #region #region Results_Header

                            dicResultParam.Add("resultCalcTestParam_Vacuum", Math.Round(HelperTestBase.Model_GVL.GVL_T03.rVacuoInicial, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_ForceIncreaseGradient", Math.Round(HelperTestBase.Model_GVL.GVL_T03.rGradienteForcaAvanco, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_ActuationGradientForward", Math.Round(HelperTestBase.Model_GVL.GVL_T03.rGradienteDeslocamentoAvanco, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_ActuationForce", Math.Round(HelperTestBase.Model_GVL.GVL_T03.rForcaMaxima, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_ForceDecreaseGradient", Math.Round(HelperTestBase.Model_GVL.GVL_T03.rGradienteForcaRetorno, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_ActuationGradientBackward", Math.Round(HelperTestBase.Model_GVL.GVL_T03.rGradienteDeslocamentoRetorno, 2).ToString());

                            #endregion

                            #region Results

                            dicResultParam.Add("resultCalcTestParam_CutInForce", Math.Round(HelperTestBase.Model_GVL.GVL_T03.rForcaCutIn_N, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_ReleaseForce", Math.Round(HelperTestBase.Model_GVL.GVL_T03.rReleaseForce_N, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_ReleaseForceRemainingAt", Math.Round(HelperTestBase.Model_GVL.GVL_T03.rReleaseForceAt_N, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_PressureAtForceE1", Math.Round(HelperTestBase.Model_GVL.GVL_T03.rPressao_E1_Bar, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_PressureAtForceE2", Math.Round(HelperTestBase.Model_GVL.GVL_T03.rPressao_E2_Bar, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_PressureAtForceP1", Math.Round(HelperTestBase.Model_GVL.GVL_T03.rPressao_P1_Bar, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_PressureAtForceP2", Math.Round(HelperTestBase.Model_GVL.GVL_T03.rPressao_P2_Bar, 2).ToString());

                            #endregion

                            #region Results_Footer

                            dicResultParam.Add("resultCalcTestParam_PCHoseConsumers", HelperTestBase.Model_GVL.GVL_T03.iConsumidoresCP.ToString());
                            dicResultParam.Add("resultCalcTestParam_SCHoseConsumers", HelperTestBase.Model_GVL.GVL_T03.iConsumidoresCS.ToString());
                            dicResultParam.Add("resultCalcTestParam_RoomTemperature", Math.Round(HelperTestBase.Model_GVL.GVL_T03.rTemperaturaInicial, 2).ToString());

                            #endregion

                            HelperTestBase.Model_GVL.helperTestBase_ModelGVL_Test = HelperTestBase.Model_GVL.GVL_T03;

                            #endregion

                            break;
                        }
                    case 4:     //Force Diagrams - Force/Force Without Vacuum
                        {
                            #region Results

                            #region Resuls Load Offline

                            if (dicReturnReadFileHeader[0]?.Count() > 0 && HelperTestBase.ProjectTestConcluded.IdProjectTestConcluded > 0 && HelperTestBase.ProjectTestConcluded.IdProject > 0)
                            {
                                var dicReturnReadFileHeaderPrj = dicReturnReadFileHeader[0];
                                var dicReturnReadFileHeaderParam = dicReturnReadFileHeader[1];
                                var dicReturnReadFileHeaderResults = dicReturnReadFileHeader[2];

                                #region Results

                                #region Results_Header

                                HelperTestBase.Model_GVL.GVL_T04.rVacuoInicial = dicReturnReadFileHeaderResults.ContainsKey("Vacuum") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Vacuum"]) : 0;
                                HelperTestBase.Model_GVL.GVL_T04.rGradienteForcaAvanco = dicReturnReadFileHeaderResults.ContainsKey("Force Increase Gradient") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Force Increase Gradient"]) * -1 : 0;
                                HelperTestBase.Model_GVL.GVL_T04.rGradienteDeslocamentoAvanco = dicReturnReadFileHeaderResults.ContainsKey("Actuation Gradient Forward") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Actuation Gradient Forward"]) * -1 : 0;
                                HelperTestBase.Model_GVL.GVL_T04.rForcaMaxima = dicReturnReadFileHeaderResults.ContainsKey("Actuation Force") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Actuation Force"]) * -1 : 0;
                                HelperTestBase.Model_GVL.GVL_T04.rGradienteForcaRetorno = dicReturnReadFileHeaderResults.ContainsKey("Force Decrease Gradient") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Force Decrease Gradient"]) : 0;
                                HelperTestBase.Model_GVL.GVL_T04.rGradienteDeslocamentoRetorno = dicReturnReadFileHeaderResults.ContainsKey("Actuation Gradient Backward") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Actuation Gradient Backward"]) : 0;

                                #endregion

                                #region Results

                                //recupera VARIOS itens que contenham o memso texto e guarda a qtd
                                var matchesOutputForceAt = from k in dicReturnReadFileHeaderResults
                                                           where k.Key.Contains("Output Force at")
                                                           select new
                                                           {
                                                               k.Key,
                                                               k.Value
                                                           };
                                HelperTestBase.Model_GVL.GVL_T04.rForca_E1 = matchesOutputForceAt.Count() > 0 ? NumberDoubleCheck(matchesOutputForceAt.ToList()[0].Value) * -1 : 0;
                                HelperTestBase.Model_GVL.GVL_T04.rForca_E2 = matchesOutputForceAt.Count() > 0 ? NumberDoubleCheck(matchesOutputForceAt.ToList()[1].Value) * -1 : 0;
                                //HelperTestBase.Model_GVL.GVL_T04.rDeslocamentoNaForca_mm = dicReturnReadFileHeaderResults.Keys.Any(k => k.StartsWith("Travel at")) ? NumberDoubleCheck(dicReturnReadFileHeaderResults.ElementAt(dicReturnReadFileHeaderResults.Keys.Select(x => x.Contains("Travel at")).ToList().FindIndex(a => a.Equals(true))).Value) * -1 : 0;
                                HelperTestBase.Model_GVL.GVL_T04.rForcaCutIn_N = dicReturnReadFileHeaderResults.ContainsKey("Cut-in Force") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Cut-in Force"]) * -1 : 0;
                                HelperTestBase.Model_GVL.GVL_T04.rReleaseForce_N = dicReturnReadFileHeaderResults.ContainsKey("Release Force") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Release Force"]) * -1 : 0;
                                //HelperTestBase.Model_GVL.GVL_T04.rHysterese_XFout_N = dicReturnReadFileHeaderResults.ContainsKey("Hysteresis at 50 bar") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Hysteresis at 50 bar"]) : 0;
                                HelperTestBase.Model_GVL.GVL_T04.rReleaseForceAt_N = dicReturnReadFileHeaderResults.Keys.Any(k => k.StartsWith("Release Force at")) ? NumberDoubleCheck(dicReturnReadFileHeaderResults.ElementAt(dicReturnReadFileHeaderResults.Keys.Select(x => x.Contains("Realease Force at")).ToList().FindIndex(a => a.Equals(true))).Value) * -1 : 0;


                                #endregion

                                #region Results_Footer

                                HelperTestBase.Model_GVL.GVL_T04.iConsumidoresCP = dicReturnReadFileHeaderResults.ContainsKey("PC Hose Consumers") ? Convert.ToInt32(dicReturnReadFileHeaderResults["PC Hose Consumers"]) : 0;
                                HelperTestBase.Model_GVL.GVL_T04.iConsumidoresCS = dicReturnReadFileHeaderResults.ContainsKey("SC Hose Consumers") ? Convert.ToInt32(dicReturnReadFileHeaderResults["SC Hose Consumers"]) : 0;
                                HelperTestBase.Model_GVL.GVL_T04.rTemperaturaInicial = dicReturnReadFileHeaderResults.ContainsKey("Room Temperature") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Room Temperature"]) * -1 : 0;

                                #endregion

                                #endregion

                            }

                            #endregion

                            #region #region Results_Header

                            dicResultParam.Add("resultCalcTestParam_T04_Vacuum", Math.Round(HelperTestBase.Model_GVL.GVL_T04.rVacuoInicial, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_T04_ForceIncreaseGradient", Math.Round(HelperTestBase.Model_GVL.GVL_T04.rGradienteForcaAvanco, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_T04_ActuationGradientForward", Math.Round(HelperTestBase.Model_GVL.GVL_T04.rGradienteDeslocamentoAvanco, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_T04_ActuationForce", Math.Round(HelperTestBase.Model_GVL.GVL_T04.rForcaMaxima, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_T04_ForceDecreaseGradient", Math.Round(HelperTestBase.Model_GVL.GVL_T04.rGradienteForcaRetorno, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_T04_ActuationGradientBackward", Math.Round(HelperTestBase.Model_GVL.GVL_T04.rGradienteDeslocamentoRetorno, 2).ToString());

                            #endregion

                            #region Results
                            
                            dicResultParam.Add("resultCalcTestParam_T04_OutputForceAtE1", Math.Round(HelperTestBase.Model_GVL.GVL_T04.rForcaOut_E1_N, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_T04_OutputForceAtE2", Math.Round(HelperTestBase.Model_GVL.GVL_T04.rForcaOut_E2_N, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_T04_OutputInputRatio", "123"); // Math.Round(HelperTestBase.Model_GVL.GVL_T04.rTaxaAmplificacao, 2).ToString()));// ;//vou criar
                            dicResultParam.Add("resultCalcTestParam_T04_CutInForce", Math.Round(HelperTestBase.Model_GVL.GVL_T04.rForcaCutIn_N, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_T04_ReleaseForce", Math.Round(HelperTestBase.Model_GVL.GVL_T04.rReleaseForce_N, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_T04_ReleaseForceRemainingAt", Math.Round(HelperTestBase.Model_GVL.GVL_T04.rReleaseForceAt_N, 2).ToString());

                            #endregion

                            #region Results_Footer

                            dicResultParam.Add("resultCalcTestParam_T04_PCHoseConsumers", 0.ToString());
                            dicResultParam.Add("resultCalcTestParam_T04_SCHoseConsumers", 0.ToString());
                            dicResultParam.Add("resultCalcTestParam_T04_RoomTemperature", Math.Round(HelperTestBase.Model_GVL.GVL_T04.rTemperaturaInicial, 2).ToString());

                            #endregion

                            HelperTestBase.Model_GVL.helperTestBase_ModelGVL_Test = HelperTestBase.Model_GVL.GVL_T04;

                            #endregion

                            break;
                        }
                    case 5: //Vacuum Leakage - Released Position
                        {
                            #region Results

                            #region Resuls Load Offline

                            if (dicReturnReadFileHeader[0]?.Count() > 0 && HelperTestBase.ProjectTestConcluded.IdProjectTestConcluded > 0 && HelperTestBase.ProjectTestConcluded.IdProject > 0)
                            {
                                var dicReturnReadFileHeaderPrj = dicReturnReadFileHeader[0];
                                var dicReturnReadFileHeaderParam = dicReturnReadFileHeader[1];
                                var dicReturnReadFileHeaderResults = dicReturnReadFileHeader[2];

                                #region Results

                                #region Results_Header

                                HelperTestBase.Model_GVL.GVL_T05.rVacuoInicial = dicReturnReadFileHeaderResults.ContainsKey("Vacuum") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Vacuum"]) : 0;

                                #endregion

                                #region Results
                                HelperTestBase.Model_GVL.GVL_T05.rTempoTotal = dicReturnReadFileHeaderResults.ContainsKey("Total Time") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Total Time"]) * -1 : 0;
                                HelperTestBase.Model_GVL.GVL_T05.rPerdaVacuo = dicReturnReadFileHeaderResults.ContainsKey("Vacuum Loss while testing") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Vacuum Loss while testing"]) * -1 : 0;

                                #endregion

                                #region Results_Footer

                                HelperTestBase.Model_GVL.GVL_T05.rTemperaturaInicial = dicReturnReadFileHeaderResults.ContainsKey("Room Temperature") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Room Temperature"]) * -1 : 0;

                                #endregion

                                #endregion

                            }

                            #endregion

                            #region #region Results_Header

                            dicResultParam.Add("resultCalcTestParam_Vacuum", Math.Round(HelperTestBase.Model_GVL.GVL_T05.rVacuoInicial, 2).ToString());

                            #endregion

                            #region Results

                            dicResultParam.Add("resultCalcTestParam_TotalTime", Math.Round(HelperTestBase.Model_GVL.GVL_T05.rTempoTotal, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_VacuumLossWhileTesting", Math.Round(HelperTestBase.Model_GVL.GVL_T05.rPerdaVacuo, 2).ToString());

                            #endregion

                            #region Results_Footer

                            dicResultParam.Add("resultCalcTestParam_RoomTemperature", Math.Round(HelperTestBase.Model_GVL.GVL_T05.rTemperaturaInicial, 2).ToString());

                            #endregion

                            HelperTestBase.Model_GVL.helperTestBase_ModelGVL_Test = HelperTestBase.Model_GVL.GVL_T05;

                            #endregion

                            break;
                        }
                    case 6: //Vacuum Leakage - Fully Applied Position
                        {
                            #region Results

                            #region Resuls Load Offline

                            if (dicReturnReadFileHeader[0]?.Count() > 0 && HelperTestBase.ProjectTestConcluded.IdProjectTestConcluded > 0 && HelperTestBase.ProjectTestConcluded.IdProject > 0)
                            {
                                var dicReturnReadFileHeaderPrj = dicReturnReadFileHeader[0];
                                var dicReturnReadFileHeaderParam = dicReturnReadFileHeader[1];
                                var dicReturnReadFileHeaderResults = dicReturnReadFileHeader[2];

                                #region Results

                                #region Results_Header

                                HelperTestBase.Model_GVL.GVL_T06.rVacuoInicial = dicReturnReadFileHeaderResults.ContainsKey("Vacuum") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Vacuum"]) : 0;
                                HelperTestBase.Model_GVL.GVL_T06.rForcaMaxima = dicReturnReadFileHeaderResults.ContainsKey("Actuation Force") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Actuation Force"]) * -1 : 0;

                                #endregion

                                #region Results
                                HelperTestBase.Model_GVL.GVL_T06.rRunOutForceRef = dicReturnReadFileHeaderResults.ContainsKey("Runout Force") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Runout Force"]) * -1 : 0;
                                HelperTestBase.Model_GVL.GVL_T06.rDeslocamentoEmFmax = dicReturnReadFileHeaderResults.ContainsKey("Travel at") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Travel at"]) * -1 : 0;
                                HelperTestBase.Model_GVL.GVL_T06.rTempoTotal = dicReturnReadFileHeaderResults.ContainsKey("Total Time") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Total Time"]) * -1 : 0;
                                HelperTestBase.Model_GVL.GVL_T06.rPerdaVacuo = dicReturnReadFileHeaderResults.ContainsKey("Vacuum Loss while testing") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Vacuum Loss while testing"]) * -1 : 0;

                                #endregion

                                #region Results_Footer

                                HelperTestBase.Model_GVL.GVL_T06.iConsumidoresCP = dicReturnReadFileHeaderResults.ContainsKey("PC Hose Consumers") ? Convert.ToInt32(dicReturnReadFileHeaderResults["PC Hose Consumers"]) : 0;
                                HelperTestBase.Model_GVL.GVL_T06.iConsumidoresCS = dicReturnReadFileHeaderResults.ContainsKey("SC Hose Consumers") ? Convert.ToInt32(dicReturnReadFileHeaderResults["SC Hose Consumers"]) : 0;
                                HelperTestBase.Model_GVL.GVL_T06.rTemperaturaInicial = dicReturnReadFileHeaderResults.ContainsKey("Room Temperature") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Room Temperature"]) * -1 : 0;

                                #endregion

                                #endregion

                            }

                            #endregion

                            #region #region Results_Header

                            dicResultParam.Add("resultCalcTestParam_Vacuum", Math.Round(HelperTestBase.Model_GVL.GVL_T06.rVacuoInicial, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_ActuationForceXX", Math.Round(HelperTestBase.Model_GVL.GVL_T06.rForcaMaxima, 2).ToString());

                            #endregion

                            #region Results

                            dicResultParam.Add("resultCalcTestParam_RunoutForce ", Math.Round(HelperTestBase.Model_GVL.GVL_T06.rRunOutForceRef, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_TravelAtXX", Math.Round(HelperTestBase.Model_GVL.GVL_T06.rDeslocamentoEmFmax, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_TotalTime", Math.Round(HelperTestBase.Model_GVL.GVL_T06.rTempoTotal, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_VacuumLossWhileTesting", Math.Round(HelperTestBase.Model_GVL.GVL_T06.rPerdaVacuo, 2).ToString());

                            #endregion

                            #region Results_Footer
                            dicResultParam.Add("resultCalcTestParam_PCHoseConsumers", HelperTestBase.Model_GVL.GVL_T06.iConsumidoresCP.ToString());
                            dicResultParam.Add("resultCalcTestParam_SCHoseConsumers", HelperTestBase.Model_GVL.GVL_T06.iConsumidoresCS.ToString());
                            dicResultParam.Add("resultCalcTestParam_RoomTemperature", Math.Round(HelperTestBase.Model_GVL.GVL_T06.rTemperaturaInicial, 2).ToString());

                            #endregion

                            HelperTestBase.Model_GVL.helperTestBase_ModelGVL_Test = HelperTestBase.Model_GVL.GVL_T06;

                            #endregion

                            break;
                        }
                    case 7: //Vacuum Leakage - Lap Position
                        {
                            #region Results

                            #region Resuls Load Offline

                            if (dicReturnReadFileHeader[0]?.Count() > 0 && HelperTestBase.ProjectTestConcluded.IdProjectTestConcluded > 0 && HelperTestBase.ProjectTestConcluded.IdProject > 0)
                            {
                                var dicReturnReadFileHeaderPrj = dicReturnReadFileHeader[0];
                                var dicReturnReadFileHeaderParam = dicReturnReadFileHeader[1];
                                var dicReturnReadFileHeaderResults = dicReturnReadFileHeader[2];

                                #region Results

                                #region Results_Header

                                HelperTestBase.Model_GVL.GVL_T07.rVacuoInicial = dicReturnReadFileHeaderResults.ContainsKey("Vacuum") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Vacuum"]) : 0;
                                //HelperTestBase.Model_GVL.GVL_T07.rForcaMaxima = dicReturnReadFileHeaderResults.ContainsKey("Actuation Force") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Actuation Force"]) * -1 : 0;

                                #endregion

                                #region Results
                                //recupera VARIOS itens que contenham o memso texto e guarda a qtd
                                var matchesActuationForceAt = from k in dicReturnReadFileHeaderResults
                                                             where k.Key.Contains("Actuation Force")
                                                             select new
                                                             {
                                                                 k.Key,
                                                                 k.Value
                                                             };

                                HelperTestBase.Model_GVL.GVL_T07.rForcaRelativaAvanco = matchesActuationForceAt.Count() > 0 ? NumberDoubleCheck(matchesActuationForceAt.ToList()[0].Value) * -1 : 0;
                                HelperTestBase.Model_GVL.GVL_T07.rForcaRelativaRetorno = matchesActuationForceAt.Count() > 0 ? NumberDoubleCheck(matchesActuationForceAt.ToList()[0].Value) * -1 : 0;
                                HelperTestBase.Model_GVL.GVL_T07.rForcaRelativaFinal = matchesActuationForceAt.Count() > 0 ? NumberDoubleCheck(matchesActuationForceAt.ToList()[0].Value) * -1 : 0;

                                HelperTestBase.Model_GVL.GVL_T07.rRunOutForceRef = dicReturnReadFileHeaderResults.ContainsKey("Runout Force") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Runout Force"]) * -1 : 0;

                                var matchesTravelAtAt = from k in dicReturnReadFileHeaderResults
                                                              where k.Key.Contains("Travel at")
                                                              select new
                                                              {
                                                                  k.Key,
                                                                  k.Value
                                                              };

                                HelperTestBase.Model_GVL.GVL_T07.rDeslocamentoEmFRelativaAvanco = matchesTravelAtAt.Count() > 0 ? NumberDoubleCheck(matchesTravelAtAt.ToList()[0].Value) * -1 : 0;
                                HelperTestBase.Model_GVL.GVL_T07.rDeslocamentoEmFRelativaRetorno = matchesTravelAtAt.Count() > 0 ? NumberDoubleCheck(matchesTravelAtAt.ToList()[0].Value) * -1 : 0;
                                HelperTestBase.Model_GVL.GVL_T07.rDeslocamentoEmFRelativaFinal = matchesTravelAtAt.Count() > 0 ? NumberDoubleCheck(matchesTravelAtAt.ToList()[0].Value) * -1 : 0;

                                HelperTestBase.Model_GVL.GVL_T07.rTempoTotal = dicReturnReadFileHeaderResults.ContainsKey("Total Time") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Total Time"]) * -1 : 0;
                                HelperTestBase.Model_GVL.GVL_T07.rPerdaVacuo = dicReturnReadFileHeaderResults.ContainsKey("Vacuum Loss while testing") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Vacuum Loss while testing"]) * -1 : 0;

                                #endregion

                                #region Results_Footer

                                HelperTestBase.Model_GVL.GVL_T07.iConsumidoresCP = dicReturnReadFileHeaderResults.ContainsKey("PC Hose Consumers") ? Convert.ToInt32(dicReturnReadFileHeaderResults["PC Hose Consumers"]) : 0;
                                HelperTestBase.Model_GVL.GVL_T07.iConsumidoresCS = dicReturnReadFileHeaderResults.ContainsKey("SC Hose Consumers") ? Convert.ToInt32(dicReturnReadFileHeaderResults["SC Hose Consumers"]) : 0;
                                HelperTestBase.Model_GVL.GVL_T07.rTemperaturaInicial = dicReturnReadFileHeaderResults.ContainsKey("Room Temperature") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Room Temperature"]) * -1 : 0;

                                #endregion

                                #endregion

                            }

                            #endregion

                            #region #region Results_Header

                            dicResultParam.Add("resultCalcTestParam_Vacuum", Math.Round(HelperTestBase.Model_GVL.GVL_T07.rVacuoInicial, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_ActuationForce1", Math.Round(HelperTestBase.Model_GVL.GVL_T07.rForcaRelativaAvancoReal_N, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_ActuationForce2", Math.Round(HelperTestBase.Model_GVL.GVL_T07.rForcaRelativaRetornoReal_N, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_ActuationForce3", Math.Round(HelperTestBase.Model_GVL.GVL_T07.rForcaRelativaFinalReal_N, 2).ToString());

                            #endregion

                            #region Results

                            dicResultParam.Add("resultCalcTestParam_RunoutForce ", Math.Round(HelperTestBase.Model_GVL.GVL_T07.rRunOutForceRef, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_TravelAt1", Math.Round(HelperTestBase.Model_GVL.GVL_T07.rDeslocamentoEmFRelativaAvanco, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_TravelAt2", Math.Round(HelperTestBase.Model_GVL.GVL_T07.rDeslocamentoEmFRelativaRetorno, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_TravelAt3", Math.Round(HelperTestBase.Model_GVL.GVL_T07.rDeslocamentoEmFRelativaFinal, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_TotalTime", Math.Round(HelperTestBase.Model_GVL.GVL_T07.rTempoTotal, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_VacuumLossWwhileTesting", Math.Round(HelperTestBase.Model_GVL.GVL_T07.rPerdaVacuo, 2).ToString());
                            #endregion

                            #region Results_Footer
                            dicResultParam.Add("resultCalcTestParam_PCHoseConsumers", HelperTestBase.Model_GVL.GVL_T07.iConsumidoresCP.ToString());
                            dicResultParam.Add("resultCalcTestParam_SCHoseConsumers", HelperTestBase.Model_GVL.GVL_T07.iConsumidoresCS.ToString());
                            dicResultParam.Add("resultCalcTestParam_RoomTemperature", Math.Round(HelperTestBase.Model_GVL.GVL_T07.rTemperaturaInicial, 2).ToString());

                            #endregion

                            HelperTestBase.Model_GVL.helperTestBase_ModelGVL_Test = HelperTestBase.Model_GVL.GVL_T07;

                            #endregion

                            break;
                        }
                    case 8:     //Hydraulic Leakage - Fully Applied Position
                        {
                            #region Results

                            #region Resuls Load Offline

                            if (dicReturnReadFileHeader[0]?.Count() > 0 && HelperTestBase.ProjectTestConcluded.IdProjectTestConcluded > 0 && HelperTestBase.ProjectTestConcluded.IdProject > 0)
                            {
                                var dicReturnReadFileHeaderPrj = dicReturnReadFileHeader[0];
                                var dicReturnReadFileHeaderParam = dicReturnReadFileHeader[1];
                                var dicReturnReadFileHeaderResults = dicReturnReadFileHeader[2];

                                #region Results

                                #region Results_Header

                                HelperTestBase.Model_GVL.GVL_T08.rVacuoInicial = dicReturnReadFileHeaderResults.ContainsKey("Vacuum") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Vacuum"]) : 0;
                                HelperTestBase.Model_GVL.GVL_T08.rForcaMaxima = dicReturnReadFileHeaderResults.ContainsKey("Actuation Force") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Actuation Force"]) * -1 : 0;

                                #endregion

                                #region Results

                                HelperTestBase.Model_GVL.GVL_T08.rRunOutForceRef = dicReturnReadFileHeaderResults.ContainsKey("Runout Force") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Runout Force"]) * -1 : 0;
                                HelperTestBase.Model_GVL.GVL_T08.rDeslocamentoEmFMax = dicReturnReadFileHeaderResults.ContainsKey("Travel at") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Travel at"]) * -1 : 0;
                                HelperTestBase.Model_GVL.GVL_T08.rPerdaPressaoCP = dicReturnReadFileHeaderResults.ContainsKey("Pressure Loss PC while testing") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Pressure Loss PC while testing"]) * -1 : 0;
                                HelperTestBase.Model_GVL.GVL_T08.rPerdaPressaoCS = dicReturnReadFileHeaderResults.ContainsKey("Pressure Loss SC while testing") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Pressure Loss SC while testing"]) * -1 : 0;
                                HelperTestBase.Model_GVL.GVL_T08.rPerdaVacuo = dicReturnReadFileHeaderResults.ContainsKey("Vacuum Loss while testing") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Vacuum Loss while testing"]) * -1 : 0;

                                #endregion

                                #region Results_Footer

                                HelperTestBase.Model_GVL.GVL_T08.iConsumidoresCP = dicReturnReadFileHeaderResults.ContainsKey("PC Hose Consumers") ? Convert.ToInt32(dicReturnReadFileHeaderResults["PC Hose Consumers"]) : 0;
                                HelperTestBase.Model_GVL.GVL_T08.iConsumidoresCS = dicReturnReadFileHeaderResults.ContainsKey("SC Hose Consumers") ? Convert.ToInt32(dicReturnReadFileHeaderResults["SC Hose Consumers"]) : 0;
                                HelperTestBase.Model_GVL.GVL_T08.rTemperaturaInicial = dicReturnReadFileHeaderResults.ContainsKey("Room Temperature") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Room Temperature"]) * -1 : 0;

                                #endregion

                                #endregion

                            }

                            #endregion

                            #region #region Results_Header

                            dicResultParam.Add("resultCalcTestParam_Vacuum", Math.Round(HelperTestBase.Model_GVL.GVL_T08.rVacuoInicial, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_ActuationForce", Math.Round(HelperTestBase.Model_GVL.GVL_T08.rForcaMaxima, 2).ToString());

                            #endregion

                            #region Results

                            dicResultParam.Add("resultCalcTestParam_RunoutForce", Math.Round(HelperTestBase.Model_GVL.GVL_T08.rRunOutForceRef, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_TravelAt", Math.Round(HelperTestBase.Model_GVL.GVL_T08.rDeslocamentoEmFMax, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_PressureLossPCWhileTesting", Math.Round(HelperTestBase.Model_GVL.GVL_T08.rPerdaPressaoCP, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_PressureLossSCWhileTesting", Math.Round(HelperTestBase.Model_GVL.GVL_T08.rPerdaPressaoCS, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_VacuumLossWhileTesting", Math.Round(HelperTestBase.Model_GVL.GVL_T08.rPerdaVacuo, 2).ToString());

                            #endregion

                            #region Results_Footer
                            dicResultParam.Add("resultCalcTestParam_PCHoseConsumers", 0.ToString());
                            dicResultParam.Add("resultCalcTestParam_SCHoseConsumers", 0.ToString());
                            dicResultParam.Add("resultCalcTestParam_RoomTemperature", Math.Round(HelperTestBase.Model_GVL.GVL_T08.rTemperaturaInicial, 2).ToString());

                            #endregion

                            HelperTestBase.Model_GVL.helperTestBase_ModelGVL_Test = HelperTestBase.Model_GVL.GVL_T08;

                            #endregion

                            break;
                        }
                    case 9:     //Hydraulic Leakage - At Low Pressure
                        {
                            #region Results

                            #region Resuls Load Offline

                            if (dicReturnReadFileHeader[0]?.Count() > 0 && HelperTestBase.ProjectTestConcluded.IdProjectTestConcluded > 0 && HelperTestBase.ProjectTestConcluded.IdProject > 0)
                            {
                                var dicReturnReadFileHeaderPrj = dicReturnReadFileHeader[0];
                                var dicReturnReadFileHeaderParam = dicReturnReadFileHeader[1];
                                var dicReturnReadFileHeaderResults = dicReturnReadFileHeader[2];

                                #region Results

                                #region Results_Header

                                HelperTestBase.Model_GVL.GVL_T09.rVacuoInicial = dicReturnReadFileHeaderResults.ContainsKey("Vacuum") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Vacuum"]) : 0;
                                HelperTestBase.Model_GVL.GVL_T09.rForcaMaxima = dicReturnReadFileHeaderResults.ContainsKey("Actuation Force") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Actuation Force"]) * -1 : 0;

                                #endregion

                                #region Results

                                HelperTestBase.Model_GVL.GVL_T09.rPressaoInicialCP = dicReturnReadFileHeaderResults.ContainsKey("Pressure PC") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Pressure PC"]) * -1 : 0;
                                HelperTestBase.Model_GVL.GVL_T09.rPerdaPressaoCP = dicReturnReadFileHeaderResults.ContainsKey("Pressure Loss PC while testing") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Pressure Loss PC while testing"]) * -1 : 0;
                                HelperTestBase.Model_GVL.GVL_T09.rPerdaPressaoCS = dicReturnReadFileHeaderResults.ContainsKey("Pressure Loss SC while testing") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Pressure Loss SC while testing"]) * -1 : 0;
                                HelperTestBase.Model_GVL.GVL_T09.rPerdaVacuo = dicReturnReadFileHeaderResults.ContainsKey("Vacuum Loss while testing") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Vacuum Loss while testing"]) * -1 : 0;

                                #endregion

                                #region Results_Footer

                                HelperTestBase.Model_GVL.GVL_T09.iConsumidoresCP = dicReturnReadFileHeaderResults.ContainsKey("PC Hose Consumers") ? Convert.ToInt32(dicReturnReadFileHeaderResults["PC Hose Consumers"]) : 0;
                                HelperTestBase.Model_GVL.GVL_T09.iConsumidoresCS = dicReturnReadFileHeaderResults.ContainsKey("SC Hose Consumers") ? Convert.ToInt32(dicReturnReadFileHeaderResults["SC Hose Consumers"]) : 0;
                                HelperTestBase.Model_GVL.GVL_T09.rTemperaturaInicial = dicReturnReadFileHeaderResults.ContainsKey("Room Temperature") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Room Temperature"]) * -1 : 0;

                                #endregion

                                #endregion

                            }

                            #endregion

                            #region #region Results_Header

                            dicResultParam.Add("resultCalcTestParam_Vacuum", Math.Round(HelperTestBase.Model_GVL.GVL_T09.rVacuoInicial, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_ActuationForce", Math.Round(HelperTestBase.Model_GVL.GVL_T09.rForcaMaxima, 2).ToString());

                            #endregion

                            #region Results

                            dicResultParam.Add("resultCalcTestParam_PressurePC", Math.Round(HelperTestBase.Model_GVL.GVL_T09.rPressaoInicialCP, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_InputTravel", Math.Round(HelperTestBase.Model_GVL.GVL_T09.rDeslocamentoEmPMax, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_PressureLossPCWhileTesting", Math.Round(HelperTestBase.Model_GVL.GVL_T09.rPerdaPressaoCP, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_PressureLossSCWhileTesting", Math.Round(HelperTestBase.Model_GVL.GVL_T09.rPerdaPressaoCS, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_VacuumLossWhileTesting", Math.Round(HelperTestBase.Model_GVL.GVL_T09.rPerdaVacuo, 2).ToString());

                            #endregion

                            #region Results_Footer
                            dicResultParam.Add("resultCalcTestParam_PCHoseConsumers", 0.ToString());
                            dicResultParam.Add("resultCalcTestParam_SCHoseConsumers", 0.ToString());
                            dicResultParam.Add("resultCalcTestParam_RoomTemperature", Math.Round(HelperTestBase.Model_GVL.GVL_T09.rTemperaturaInicial, 2).ToString());

                            #endregion

                            HelperTestBase.Model_GVL.helperTestBase_ModelGVL_Test = HelperTestBase.Model_GVL.GVL_T09;

                            #endregion

                            break;
                        }
                    case 10:    //Hydraulic Leakage - At High Pressure
                        {
                            #region Results

                            #region Resuls Load Offline

                            if (dicReturnReadFileHeader[0]?.Count() > 0 && HelperTestBase.ProjectTestConcluded.IdProjectTestConcluded > 0 && HelperTestBase.ProjectTestConcluded.IdProject > 0)
                            {
                                var dicReturnReadFileHeaderPrj = dicReturnReadFileHeader[0];
                                var dicReturnReadFileHeaderParam = dicReturnReadFileHeader[1];
                                var dicReturnReadFileHeaderResults = dicReturnReadFileHeader[2];

                                #region Results

                                #region Results_Header

                                HelperTestBase.Model_GVL.GVL_T10.rVacuoInicial = dicReturnReadFileHeaderResults.ContainsKey("Vacuum") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Vacuum"]) : 0;
                                HelperTestBase.Model_GVL.GVL_T10.rForcaMaxima = dicReturnReadFileHeaderResults.ContainsKey("Actuation Force") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Actuation Force"]) * -1 : 0;

                                #endregion

                                #region Results

                                HelperTestBase.Model_GVL.GVL_T10.rPressaoInicialCP = dicReturnReadFileHeaderResults.ContainsKey("Pressure PC") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Pressure PC"]) * -1 : 0;
                                HelperTestBase.Model_GVL.GVL_T10.rDeslocamentoEmPMax = dicReturnReadFileHeaderResults.ContainsKey("Input Travel") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Pressure PC"]) * -1 : 0;
                                HelperTestBase.Model_GVL.GVL_T10.rPerdaPressaoCP = dicReturnReadFileHeaderResults.ContainsKey("Pressure Loss PC while testing") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Input Travel"]) * -1 : 0;
                                HelperTestBase.Model_GVL.GVL_T10.rPerdaPressaoCS = dicReturnReadFileHeaderResults.ContainsKey("Pressure Loss SC while testing") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Pressure Loss SC while testing"]) * -1 : 0;
                                HelperTestBase.Model_GVL.GVL_T10.rPerdaVacuo = dicReturnReadFileHeaderResults.ContainsKey("Vacuum Loss while testing") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Vacuum Loss while testing"]) * -1 : 0;

                                #endregion

                                #region Results_Footer

                                HelperTestBase.Model_GVL.GVL_T10.iConsumidoresCP = dicReturnReadFileHeaderResults.ContainsKey("PC Hose Consumers") ? Convert.ToInt32(dicReturnReadFileHeaderResults["PC Hose Consumers"]) : 0;
                                HelperTestBase.Model_GVL.GVL_T10.iConsumidoresCS = dicReturnReadFileHeaderResults.ContainsKey("SC Hose Consumers") ? Convert.ToInt32(dicReturnReadFileHeaderResults["SC Hose Consumers"]) : 0;
                                HelperTestBase.Model_GVL.GVL_T10.rTemperaturaInicial = dicReturnReadFileHeaderResults.ContainsKey("Room Temperature") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Room Temperature"]) * -1 : 0;

                                #endregion

                                #endregion

                            }

                            #endregion

                            #region #region Results_Header

                            dicResultParam.Add("resultCalcTestParam_Vacuum", Math.Round(HelperTestBase.Model_GVL.GVL_T10.rVacuoInicial, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_ActuationForce", Math.Round(HelperTestBase.Model_GVL.GVL_T10.rForcaMaxima, 2).ToString());

                            #endregion

                            #region Results

                            dicResultParam.Add("resultCalcTestParam_PressurePC", Math.Round(HelperTestBase.Model_GVL.GVL_T10.rPressaoFinalCP, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_InputTravel", Math.Round(HelperTestBase.Model_GVL.GVL_T10.rDeslocamentoEmPMax, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_PressureLossPCWhileTesting", Math.Round(HelperTestBase.Model_GVL.GVL_T10.rPerdaPressaoCP, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_PressureLossSCWhileTesting", Math.Round(HelperTestBase.Model_GVL.GVL_T10.rPerdaPressaoCS, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_VacuumLossWhileTesting", Math.Round(HelperTestBase.Model_GVL.GVL_T10.rPerdaVacuo, 2).ToString());

                            #endregion

                            #region Results_Footer
                            dicResultParam.Add("resultCalcTestParam_PCHoseConsumers", 0.ToString());
                            dicResultParam.Add("resultCalcTestParam_SCHoseConsumers", 0.ToString());
                            dicResultParam.Add("resultCalcTestParam_RoomTemperature", Math.Round(HelperTestBase.Model_GVL.GVL_T10.rTemperaturaInicial, 2).ToString());

                            #endregion

                            HelperTestBase.Model_GVL.helperTestBase_ModelGVL_Test = HelperTestBase.Model_GVL.GVL_T10;

                            #endregion

                            break;
                        }
                    case 11:    //Adjustment - Actuation Slow
                        {
                            #region Results

                            #region Resuls Load Offline

                            if (dicReturnReadFileHeader[0]?.Count() > 0 && HelperTestBase.ProjectTestConcluded.IdProjectTestConcluded > 0 && HelperTestBase.ProjectTestConcluded.IdProject > 0)
                            {
                                var dicReturnReadFileHeaderPrj = dicReturnReadFileHeader[0];
                                var dicReturnReadFileHeaderParam = dicReturnReadFileHeader[1];
                                var dicReturnReadFileHeaderResults = dicReturnReadFileHeader[2];

                                #region Results

                                #region Results_Header

                                HelperTestBase.Model_GVL.GVL_T11.rVacuoInicial = dicReturnReadFileHeaderResults.ContainsKey("Vacuum") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Vacuum"]) : 0;
                                HelperTestBase.Model_GVL.GVL_T11.rGradienteForcaAvanco = dicReturnReadFileHeaderResults.ContainsKey("Force Increase Gradient") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Force Increase Gradient"]) * -1 : 0;
                                HelperTestBase.Model_GVL.GVL_T11.rGradienteDeslocamentoAvanco = dicReturnReadFileHeaderResults.ContainsKey("Actuation Gradient Forward") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Actuation Gradient Forward"]) * -1 : 0;
                                HelperTestBase.Model_GVL.GVL_T11.rForcaMaxima = dicReturnReadFileHeaderResults.ContainsKey("Actuation Force") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Actuation Force"]) * -1 : 0;
                                HelperTestBase.Model_GVL.GVL_T11.rGradienteForcaRetorno = dicReturnReadFileHeaderResults.ContainsKey("Force Decrease Gradient") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Force Decrease Gradient"]) : 0;
                                HelperTestBase.Model_GVL.GVL_T11.rGradienteDeslocamentoRetorno = dicReturnReadFileHeaderResults.ContainsKey("Actuation Gradient Backward") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Actuation Gradient Backward"]) : 0;

                                #endregion

                                #region Results
                                #endregion

                                #region Results_Footer

                                HelperTestBase.Model_GVL.GVL_T11.iConsumidoresCP = dicReturnReadFileHeaderResults.ContainsKey("PC Hose Consumers") ? Convert.ToInt32(dicReturnReadFileHeaderResults["PC Hose Consumers"]) : 0;
                                HelperTestBase.Model_GVL.GVL_T11.iConsumidoresCS = dicReturnReadFileHeaderResults.ContainsKey("SC Hose Consumers") ? Convert.ToInt32(dicReturnReadFileHeaderResults["SC Hose Consumers"]) : 0;
                                HelperTestBase.Model_GVL.GVL_T11.rTemperaturaInicial = dicReturnReadFileHeaderResults.ContainsKey("Room Temperature") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Room Temperature"]) * -1 : 0;

                                #endregion

                                #endregion

                            }

                            #endregion

                            #region #region Results_Header

                            dicResultParam.Add("resultCalcTestParam_Vacuum", Math.Round(HelperTestBase.Model_GVL.GVL_T11.rVacuoInicial, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_ForceIncreaseGradient", Math.Round(HelperTestBase.Model_GVL.GVL_T11.rGradienteForcaAvanco, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_ActuationGradientForward", Math.Round(HelperTestBase.Model_GVL.GVL_T11.rGradienteDeslocamentoAvanco, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_ActuationForce", Math.Round(HelperTestBase.Model_GVL.GVL_T11.rForcaMaxima, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_ForceDecreaseGradient", Math.Round(HelperTestBase.Model_GVL.GVL_T11.rGradienteForcaRetorno, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_ActuationGradientBackward", Math.Round(HelperTestBase.Model_GVL.GVL_T11.rGradienteDeslocamentoRetorno, 2).ToString());

                            #endregion

                            #region Results

                            #endregion

                            #region Results_Footer

                            dicResultParam.Add("resultCalcTestParam_PCHoseConsumers", HelperTestBase.Model_GVL.GVL_T11.iConsumidoresCP.ToString());
                            dicResultParam.Add("resultCalcTestParam_SCHoseConsumers", HelperTestBase.Model_GVL.GVL_T11.iConsumidoresCS.ToString());
                            dicResultParam.Add("resultCalcTestParam_RoomTemperature", Math.Round(HelperTestBase.Model_GVL.GVL_T11.rTemperaturaInicial, 2).ToString());

                            #endregion

                            HelperTestBase.Model_GVL.helperTestBase_ModelGVL_Test = HelperTestBase.Model_GVL.GVL_T11;

                            #endregion

                            break;
                        }
                    case 12:    //Adjustment - Actuation Fast
                        {
                            #region Results

                            #region Resuls Load Offline

                            if (dicReturnReadFileHeader[0]?.Count() > 0 && HelperTestBase.ProjectTestConcluded.IdProjectTestConcluded > 0 && HelperTestBase.ProjectTestConcluded.IdProject > 0)
                            {
                                var dicReturnReadFileHeaderPrj = dicReturnReadFileHeader[0];
                                var dicReturnReadFileHeaderParam = dicReturnReadFileHeader[1];
                                var dicReturnReadFileHeaderResults = dicReturnReadFileHeader[2];

                                #region Results

                                #region Results_Header

                                HelperTestBase.Model_GVL.GVL_T12.rVacuoInicial = dicReturnReadFileHeaderResults.ContainsKey("Vacuum") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Vacuum"]) : 0;
                                HelperTestBase.Model_GVL.GVL_T12.rGradienteForcaAvanco = dicReturnReadFileHeaderResults.ContainsKey("Force Increase Gradient") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Force Increase Gradient"]) * -1 : 0;
                                HelperTestBase.Model_GVL.GVL_T12.rGradienteDeslocamentoAvanco = dicReturnReadFileHeaderResults.ContainsKey("Actuation Gradient Forward") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Actuation Gradient Forward"]) * -1 : 0;
                                HelperTestBase.Model_GVL.GVL_T12.rForcaMaxima = dicReturnReadFileHeaderResults.ContainsKey("Actuation Force") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Actuation Force"]) * -1 : 0;
                                HelperTestBase.Model_GVL.GVL_T12.rGradienteForcaRetorno = dicReturnReadFileHeaderResults.ContainsKey("Force Decrease Gradient") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Force Decrease Gradient"]) : 0;
                                HelperTestBase.Model_GVL.GVL_T12.rGradienteDeslocamentoRetorno = dicReturnReadFileHeaderResults.ContainsKey("Actuation Gradient Backward") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Actuation Gradient Backward"]) : 0;

                                #endregion

                                #region Results


                                HelperTestBase.Model_GVL.GVL_T12.rDeslocamentoMaximo = dicReturnReadFileHeaderResults.ContainsKey("Input Travel") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Input Travel"]) * -1 : 0;
                                HelperTestBase.Model_GVL.GVL_T12.rTempoAtuacao = dicReturnReadFileHeaderResults.ContainsKey("Actuation Time") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Actuation Time"]) * -1 : 0;
                                HelperTestBase.Model_GVL.GVL_T12.rTempoRetorno = dicReturnReadFileHeaderResults.ContainsKey("Release Time") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Release Time"]) * -1 : 0;
                                HelperTestBase.Model_GVL.GVL_T12.rPressaoMaximaCP_bar = dicReturnReadFileHeaderResults.ContainsKey("Max. Pressure PC") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Max. Pressure PC"]) * -1 : 0;
                                HelperTestBase.Model_GVL.GVL_T12.rPressaoMaximaCS_bar = dicReturnReadFileHeaderResults.ContainsKey("Max. pressure SC") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Max. pressure SC"]) * -1 : 0;

                                #endregion

                                #region Results_Footer

                                HelperTestBase.Model_GVL.GVL_T12.iConsumidoresCP = dicReturnReadFileHeaderResults.ContainsKey("PC Hose Consumers") ? Convert.ToInt32(dicReturnReadFileHeaderResults["PC Hose Consumers"]) : 0;
                                HelperTestBase.Model_GVL.GVL_T12.iConsumidoresCS = dicReturnReadFileHeaderResults.ContainsKey("SC Hose Consumers") ? Convert.ToInt32(dicReturnReadFileHeaderResults["SC Hose Consumers"]) : 0;
                                HelperTestBase.Model_GVL.GVL_T12.rTemperaturaInicial = dicReturnReadFileHeaderResults.ContainsKey("Room Temperature") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Room Temperature"]) * -1 : 0;

                                #endregion

                                #endregion

                            }

                            #endregion

                            #region #region Results_Header

                            dicResultParam.Add("resultCalcTestParam_Vacuum", Math.Round(HelperTestBase.Model_GVL.GVL_T12.rVacuoInicial, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_ForceIncreaseGradient", Math.Round(HelperTestBase.Model_GVL.GVL_T12.rGradienteForcaAvanco, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_ActuationGradientForward", Math.Round(HelperTestBase.Model_GVL.GVL_T12.rGradienteDeslocamentoAvanco, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_ActuationForce", Math.Round(HelperTestBase.Model_GVL.GVL_T12.rForcaMaxima, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_ForceDecreaseGradient", Math.Round(HelperTestBase.Model_GVL.GVL_T12.rGradienteForcaRetorno, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_ActuationGradientBackward", Math.Round(HelperTestBase.Model_GVL.GVL_T12.rGradienteDeslocamentoRetorno, 2).ToString());

                            #endregion

                            #region Results

                            dicResultParam.Add("resultCalcTestParam_InputTravel", Math.Round(HelperTestBase.Model_GVL.GVL_T12.rDeslocamentoMaximo, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_ActuationTime", Math.Round(HelperTestBase.Model_GVL.GVL_T12.rTempoAtuacao, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_ReleaseTime", Math.Round(HelperTestBase.Model_GVL.GVL_T12.rTempoRetorno, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_MaxPressurePC", Math.Round(HelperTestBase.Model_GVL.GVL_T12.rPressaoMaximaCP_bar, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_MaxPressureSC", Math.Round(HelperTestBase.Model_GVL.GVL_T12.rPressaoMaximaCS_bar, 2).ToString());

                            #endregion

                            #region Results_Footer

                            dicResultParam.Add("resultCalcTestParam_PCHoseConsumers", HelperTestBase.Model_GVL.GVL_T12.iConsumidoresCP.ToString());
                            dicResultParam.Add("resultCalcTestParam_SCHoseConsumers", HelperTestBase.Model_GVL.GVL_T12.iConsumidoresCS.ToString());
                            dicResultParam.Add("resultCalcTestParam_RoomTemperature", Math.Round(HelperTestBase.Model_GVL.GVL_T12.rTemperaturaInicial, 2).ToString());

                            #endregion

                            HelperTestBase.Model_GVL.helperTestBase_ModelGVL_Test = HelperTestBase.Model_GVL.GVL_T12;

                            #endregion

                            break;
                        }
                    case 13:    //Check Sensors - Pressure Difference
                        {
                            #region Results

                            #region Resuls Load Offline

                            if (dicReturnReadFileHeader[0]?.Count() > 0 && HelperTestBase.ProjectTestConcluded.IdProjectTestConcluded > 0 && HelperTestBase.ProjectTestConcluded.IdProject > 0)
                            {
                                var dicReturnReadFileHeaderPrj = dicReturnReadFileHeader[0];
                                var dicReturnReadFileHeaderParam = dicReturnReadFileHeader[1];
                                var dicReturnReadFileHeaderResults = dicReturnReadFileHeader[2];

                                #region Results

                                #region Results_Header

                                HelperTestBase.Model_GVL.GVL_T13.rVacuoInicial = dicReturnReadFileHeaderResults.ContainsKey("Vacuum") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Vacuum"]) : 0;
                                HelperTestBase.Model_GVL.GVL_T13.rGradienteForcaAvanco = dicReturnReadFileHeaderResults.ContainsKey("Force Increase Gradient") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Force Increase Gradient"]) * -1 : 0;
                                HelperTestBase.Model_GVL.GVL_T13.rGradienteDeslocamentoAvanco = dicReturnReadFileHeaderResults.ContainsKey("Actuation Gradient Forward") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Actuation Gradient Forward"]) * -1 : 0;
                                HelperTestBase.Model_GVL.GVL_T13.rForcaMaxima = dicReturnReadFileHeaderResults.ContainsKey("Actuation Force") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Actuation Force"]) * -1 : 0;
                                HelperTestBase.Model_GVL.GVL_T13.rGradienteForcaRetorno = dicReturnReadFileHeaderResults.ContainsKey("Force Decrease Gradient") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Force Decrease Gradient"]) : 0;
                                HelperTestBase.Model_GVL.GVL_T13.rGradienteDeslocamentoRetorno = dicReturnReadFileHeaderResults.ContainsKey("Actuation Gradient Backward") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Actuation Gradient Backward"]) : 0;

                                #endregion

                                #region Results
                                //recupera VARIOS itens que contenham o memso texto e guarda a qtd
                                var matchesDifferenceAtForce = from k in dicReturnReadFileHeaderResults
                                                             where k.Key.Contains("Difference at")
                                                             select new
                                                             {
                                                                 k.Key,
                                                                 k.Value
                                                             };


                                HelperTestBase.Model_GVL.GVL_T13.rDiferencaPressaoP1_bar = matchesDifferenceAtForce.Count() > 0 ? NumberDoubleCheck(matchesDifferenceAtForce.ToList()[0].Value) * -1 : 0;
                                HelperTestBase.Model_GVL.GVL_T13.rDiferencaPressaoP2_bar = matchesDifferenceAtForce.Count() > 0 ? NumberDoubleCheck(matchesDifferenceAtForce.ToList()[1].Value) * -1 : 0;
                                HelperTestBase.Model_GVL.GVL_T13.rDiferencaPressaoP3_bar = matchesDifferenceAtForce.Count() > 0 ? NumberDoubleCheck(matchesDifferenceAtForce.ToList()[2].Value) * -1 : 0;
                                HelperTestBase.Model_GVL.GVL_T13.rDiferencaPressaoP4_bar = matchesDifferenceAtForce.Count() > 0 ? NumberDoubleCheck(matchesDifferenceAtForce.ToList()[3].Value) * -1 : 0;

                                #endregion

                                #region Results_Footer

                                HelperTestBase.Model_GVL.GVL_T13.iConsumidoresCP = dicReturnReadFileHeaderResults.ContainsKey("PC Hose Consumers") ? Convert.ToInt32(dicReturnReadFileHeaderResults["PC Hose Consumers"]) : 0;
                                HelperTestBase.Model_GVL.GVL_T13.iConsumidoresCS = dicReturnReadFileHeaderResults.ContainsKey("SC Hose Consumers") ? Convert.ToInt32(dicReturnReadFileHeaderResults["SC Hose Consumers"]) : 0;
                                HelperTestBase.Model_GVL.GVL_T13.rTemperaturaInicial = dicReturnReadFileHeaderResults.ContainsKey("Room Temperature") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Room Temperature"]) * -1 : 0;

                                #endregion

                                #endregion

                            }

                            #endregion

                            #region #region Results_Header

                            dicResultParam.Add("resultCalcTestParam_Vacuum", Math.Round(HelperTestBase.Model_GVL.GVL_T13.rVacuoInicial, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_ForceIncreaseGradient", Math.Round(HelperTestBase.Model_GVL.GVL_T13.rGradienteForcaAvanco, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_ActuationGradientForward", Math.Round(HelperTestBase.Model_GVL.GVL_T13.rGradienteDeslocamentoAvanco, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_ActuationForce", Math.Round(HelperTestBase.Model_GVL.GVL_T13.rForcaMaxima, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_ForceDecreaseGradient", Math.Round(HelperTestBase.Model_GVL.GVL_T13.rGradienteForcaRetorno, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_ActuationGradientBackward", Math.Round(HelperTestBase.Model_GVL.GVL_T13.rGradienteDeslocamentoRetorno, 2).ToString());

                            #endregion

                            #region Results

                            dicResultParam.Add("resultCalcTestParam_DifferenceAt1", Math.Round(HelperTestBase.Model_GVL.GVL_T13.rDiferencaPressaoP1_bar, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_DifferenceAt2", Math.Round(HelperTestBase.Model_GVL.GVL_T13.rDiferencaPressaoP2_bar, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_DifferenceAt3", Math.Round(HelperTestBase.Model_GVL.GVL_T13.rDiferencaPressaoP3_bar, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_DifferenceAt4", Math.Round(HelperTestBase.Model_GVL.GVL_T13.rDiferencaPressaoP4_bar, 2).ToString());

                            #endregion

                            #region Results_Footer

                            dicResultParam.Add("resultCalcTestParam_PCHoseConsumers", HelperTestBase.Model_GVL.GVL_T13.iConsumidoresCP.ToString());
                            dicResultParam.Add("resultCalcTestParam_SCHoseConsumers", HelperTestBase.Model_GVL.GVL_T13.iConsumidoresCS.ToString());
                            dicResultParam.Add("resultCalcTestParam_RoomTemperature", Math.Round(HelperTestBase.Model_GVL.GVL_T13.rTemperaturaInicial, 2).ToString());

                            #endregion

                            HelperTestBase.Model_GVL.helperTestBase_ModelGVL_Test = HelperTestBase.Model_GVL.GVL_T13;

                            #endregion

                            break;
                        }
                    case 14:    //Check Sensors - Input/Output Travel
                        {
                            #region Results

                            #region Resuls Load Offline

                            if (dicReturnReadFileHeader[0]?.Count() > 0 && HelperTestBase.ProjectTestConcluded.IdProjectTestConcluded > 0 && HelperTestBase.ProjectTestConcluded.IdProject > 0)
                            {
                                var dicReturnReadFileHeaderPrj = dicReturnReadFileHeader[0];
                                var dicReturnReadFileHeaderParam = dicReturnReadFileHeader[1];
                                var dicReturnReadFileHeaderResults = dicReturnReadFileHeader[2];

                                #region Results

                                #region Results_Header

                                HelperTestBase.Model_GVL.GVL_T14.rVacuoInicial = dicReturnReadFileHeaderResults.ContainsKey("Vacuum") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Vacuum"]) : 0;
                                HelperTestBase.Model_GVL.GVL_T14.rGradienteForcaAvanco = dicReturnReadFileHeaderResults.ContainsKey("Force Increase Gradient") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Force Increase Gradient"]) * -1 : 0;
                                HelperTestBase.Model_GVL.GVL_T14.rGradienteDeslocamentoAvanco = dicReturnReadFileHeaderResults.ContainsKey("Actuation Gradient Forward") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Actuation Gradient Forward"]) * -1 : 0;
                                HelperTestBase.Model_GVL.GVL_T14.rForcaMaxima = dicReturnReadFileHeaderResults.ContainsKey("Actuation Force") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Actuation Force"]) * -1 : 0;
                                HelperTestBase.Model_GVL.GVL_T14.rGradienteForcaRetorno = dicReturnReadFileHeaderResults.ContainsKey("Force Decrease Gradient") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Force Decrease Gradient"]) : 0;
                                HelperTestBase.Model_GVL.GVL_T14.rGradienteDeslocamentoRetorno = dicReturnReadFileHeaderResults.ContainsKey("Actuation Gradient Backward") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Actuation Gradient Backward"]) : 0;

                                #endregion

                                #region Results

                                HelperTestBase.Model_GVL.GVL_T14.rDeslocamentoMaximo = dicReturnReadFileHeaderResults.ContainsKey("Input Travel") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Input Travel"]) * -1 : 0;
                                HelperTestBase.Model_GVL.GVL_T14.rCursoMorto_mm = dicReturnReadFileHeaderResults.ContainsKey("Lost Travel") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Lost Travel"]) * -1 : 0;

                                #endregion

                                #region Results_Footer

                                HelperTestBase.Model_GVL.GVL_T14.iConsumidoresCP = dicReturnReadFileHeaderResults.ContainsKey("PC Hose Consumers") ? Convert.ToInt32(dicReturnReadFileHeaderResults["PC Hose Consumers"]) : 0;
                                HelperTestBase.Model_GVL.GVL_T14.iConsumidoresCS = dicReturnReadFileHeaderResults.ContainsKey("SC Hose Consumers") ? Convert.ToInt32(dicReturnReadFileHeaderResults["SC Hose Consumers"]) : 0;
                                HelperTestBase.Model_GVL.GVL_T14.rTemperaturaInicial = dicReturnReadFileHeaderResults.ContainsKey("Room Temperature") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Room Temperature"]) * -1 : 0;

                                #endregion

                                #endregion

                            }

                            #endregion

                            #region #region Results_Header

                            dicResultParam.Add("resultCalcTestParam_Vacuum", Math.Round(HelperTestBase.Model_GVL.GVL_T14.rVacuoInicial, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_ForceIncreaseGradient", Math.Round(HelperTestBase.Model_GVL.GVL_T14.rGradienteForcaAvanco, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_ActuationGradientForward", Math.Round(HelperTestBase.Model_GVL.GVL_T14.rGradienteDeslocamentoAvanco, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_ActuationForce", Math.Round(HelperTestBase.Model_GVL.GVL_T14.rForcaMaxima, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_ForceDecreaseGradient", Math.Round(HelperTestBase.Model_GVL.GVL_T14.rGradienteForcaRetorno, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_ActuationGradientBackward", Math.Round(HelperTestBase.Model_GVL.GVL_T14.rGradienteDeslocamentoRetorno, 2).ToString());

                            #endregion

                            #region Results

                            dicResultParam.Add("resultCalcTestParam_InputTravel", Math.Round(HelperTestBase.Model_GVL.GVL_T14.rDeslocamentoMaximo, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_LostTravel", Math.Round(HelperTestBase.Model_GVL.GVL_T14.rCursoMorto_mm, 2).ToString());

                            #endregion

                            #region Results_Footer

                            dicResultParam.Add("resultCalcTestParam_PCHoseConsumers", HelperTestBase.Model_GVL.GVL_T14.iConsumidoresCP.ToString());
                            dicResultParam.Add("resultCalcTestParam_SCHoseConsumers", HelperTestBase.Model_GVL.GVL_T14.iConsumidoresCS.ToString());
                            dicResultParam.Add("resultCalcTestParam_RoomTemperature", Math.Round(HelperTestBase.Model_GVL.GVL_T14.rTemperaturaInicial, 2).ToString());

                            #endregion

                            HelperTestBase.Model_GVL.helperTestBase_ModelGVL_Test = HelperTestBase.Model_GVL.GVL_T14;

                            #endregion

                            break;
                        }
                    case 15:    //Adjustment - Input Travel VS Input Force
                        {
                            #region Results

                            #region Resuls Load Offline

                            if (dicReturnReadFileHeader[0]?.Count() > 0 && HelperTestBase.ProjectTestConcluded.IdProjectTestConcluded > 0 && HelperTestBase.ProjectTestConcluded.IdProject > 0)
                            {
                                var dicReturnReadFileHeaderPrj = dicReturnReadFileHeader[0];
                                var dicReturnReadFileHeaderParam = dicReturnReadFileHeader[1];
                                var dicReturnReadFileHeaderResults = dicReturnReadFileHeader[2];

                                #region Results

                                #region Results_Header

                                HelperTestBase.Model_GVL.GVL_T15.rVacuoInicial = dicReturnReadFileHeaderResults.ContainsKey("Vacuum") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Vacuum"]) : 0;
                                HelperTestBase.Model_GVL.GVL_T15.rGradienteForcaAvanco = dicReturnReadFileHeaderResults.ContainsKey("Force Increase Gradient") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Force Increase Gradient"]) * -1 : 0;
                                HelperTestBase.Model_GVL.GVL_T15.rGradienteDeslocamentoAvanco = dicReturnReadFileHeaderResults.ContainsKey("Actuation Gradient Forward") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Actuation Gradient Forward"]) * -1 : 0;
                                HelperTestBase.Model_GVL.GVL_T15.rForcaMaxima = dicReturnReadFileHeaderResults.ContainsKey("Actuation Force") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Actuation Force"]) * -1 : 0;
                                HelperTestBase.Model_GVL.GVL_T15.rGradienteForcaRetorno = dicReturnReadFileHeaderResults.ContainsKey("Force Decrease Gradient") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Force Decrease Gradient"]) : 0;
                                HelperTestBase.Model_GVL.GVL_T15.rGradienteDeslocamentoRetorno = dicReturnReadFileHeaderResults.ContainsKey("Actuation Gradient Backward") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Actuation Gradient Backward"]) : 0;

                                #endregion

                                #region Results

                                #endregion

                                #region Results_Footer

                                HelperTestBase.Model_GVL.GVL_T15.iConsumidoresCP = dicReturnReadFileHeaderResults.ContainsKey("PC Hose Consumers") ? Convert.ToInt32(dicReturnReadFileHeaderResults["PC Hose Consumers"]) : 0;
                                HelperTestBase.Model_GVL.GVL_T15.iConsumidoresCS = dicReturnReadFileHeaderResults.ContainsKey("SC Hose Consumers") ? Convert.ToInt32(dicReturnReadFileHeaderResults["SC Hose Consumers"]) : 0;
                                HelperTestBase.Model_GVL.GVL_T15.rTemperaturaInicial = dicReturnReadFileHeaderResults.ContainsKey("Room Temperature") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Room Temperature"]) * -1 : 0;

                                #endregion

                                #endregion

                            }

                            #endregion

                            #region #region Results_Header

                            dicResultParam.Add("resultCalcTestParam_Vacuum", Math.Round(HelperTestBase.Model_GVL.GVL_T15.rVacuoInicial, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_ForceIncreaseGradient", Math.Round(HelperTestBase.Model_GVL.GVL_T15.rGradienteForcaAvanco, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_ActuationGradientForward", Math.Round(HelperTestBase.Model_GVL.GVL_T15.rGradienteDeslocamentoAvanco, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_ActuationForce", Math.Round(HelperTestBase.Model_GVL.GVL_T15.rForcaMaxima, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_ForceDecreaseGradient", Math.Round(HelperTestBase.Model_GVL.GVL_T15.rGradienteForcaRetorno, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_ActuationGradientBackward", Math.Round(HelperTestBase.Model_GVL.GVL_T15.rGradienteDeslocamentoRetorno, 2).ToString());

                            #endregion

                            #region Results

                            #endregion

                            #region Results_Footer

                            dicResultParam.Add("resultCalcTestParam_PCHoseConsumers", HelperTestBase.Model_GVL.GVL_T15.iConsumidoresCP.ToString());
                            dicResultParam.Add("resultCalcTestParam_SCHoseConsumers", HelperTestBase.Model_GVL.GVL_T15.iConsumidoresCS.ToString());
                            dicResultParam.Add("resultCalcTestParam_RoomTemperature", Math.Round(HelperTestBase.Model_GVL.GVL_T15.rTemperaturaInicial, 2).ToString());

                            #endregion

                            HelperTestBase.Model_GVL.helperTestBase_ModelGVL_Test = HelperTestBase.Model_GVL.GVL_T15;

                            #endregion

                            break;
                        }
                    case 16:    //Adjustment - Hose Consumer
                        {
                            #region Results

                            #region Resuls Load Offline

                            if (dicReturnReadFileHeader[0]?.Count() > 0 && HelperTestBase.ProjectTestConcluded.IdProjectTestConcluded > 0 && HelperTestBase.ProjectTestConcluded.IdProject > 0)
                            {
                                var dicReturnReadFileHeaderPrj = dicReturnReadFileHeader[0];
                                var dicReturnReadFileHeaderParam = dicReturnReadFileHeader[1];
                                var dicReturnReadFileHeaderResults = dicReturnReadFileHeader[2];

                                #region Results

                                #region Results_Header

                                HelperTestBase.Model_GVL.GVL_T16.rVacuoInicial = dicReturnReadFileHeaderResults.ContainsKey("Vacuum") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Vacuum"]) : 0;
                                HelperTestBase.Model_GVL.GVL_T16.rGradienteForcaAvanco = dicReturnReadFileHeaderResults.ContainsKey("Force Increase Gradient") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Force Increase Gradient"]) * -1 : 0;
                                HelperTestBase.Model_GVL.GVL_T16.rGradienteDeslocamentoAvanco = dicReturnReadFileHeaderResults.ContainsKey("Actuation Gradient Forward") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Actuation Gradient Forward"]) * -1 : 0;
                                HelperTestBase.Model_GVL.GVL_T16.rForcaMaxima = dicReturnReadFileHeaderResults.ContainsKey("Actuation Force") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Actuation Force"]) * -1 : 0;
                                HelperTestBase.Model_GVL.GVL_T16.rGradienteForcaRetorno = dicReturnReadFileHeaderResults.ContainsKey("Force Decrease Gradient") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Force Decrease Gradient"]) : 0;
                                HelperTestBase.Model_GVL.GVL_T16.rGradienteDeslocamentoRetorno = dicReturnReadFileHeaderResults.ContainsKey("Actuation Gradient Backward") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Actuation Gradient Backward"]) : 0;

                                #endregion

                                #region Results

                                HelperTestBase.Model_GVL.GVL_T16.rDeslocamentoMaximo_mm = dicReturnReadFileHeaderResults.ContainsKey("Input Travel") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Input Travel"]) * -1 : 0;
                                HelperTestBase.Model_GVL.GVL_T16.rDeslocamentoNaPressao_mm = dicReturnReadFileHeaderResults.ContainsKey("Input Travel at") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Input Travel at"]) * -1 : 0;

                                #endregion

                                #region Results_Footer

                                HelperTestBase.Model_GVL.GVL_T16.iConsumidoresCP = dicReturnReadFileHeaderResults.ContainsKey("PC Hose Consumers") ? Convert.ToInt32(dicReturnReadFileHeaderResults["PC Hose Consumers"]) : 0;
                                HelperTestBase.Model_GVL.GVL_T16.iConsumidoresCS = dicReturnReadFileHeaderResults.ContainsKey("SC Hose Consumers") ? Convert.ToInt32(dicReturnReadFileHeaderResults["SC Hose Consumers"]) : 0;
                                HelperTestBase.Model_GVL.GVL_T16.rTemperaturaInicial = dicReturnReadFileHeaderResults.ContainsKey("Room Temperature") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Room Temperature"]) * -1 : 0;

                                #endregion

                                #endregion

                            }

                            #endregion

                            #region #region Results_Header

                            dicResultParam.Add("resultCalcTestParam_T16_Vacuum", Math.Round(HelperTestBase.Model_GVL.GVL_T16.rVacuoInicial, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_T16_ForceIncreaseGradient", Math.Round(HelperTestBase.Model_GVL.GVL_T16.rGradienteForcaAvanco, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_T16_ActuationGradientForward", Math.Round(HelperTestBase.Model_GVL.GVL_T16.rGradienteDeslocamentoAvanco, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_T16_ActuationForce", Math.Round(HelperTestBase.Model_GVL.GVL_T16.rForcaMaxima, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_T16_ForceDecreaseGradient", Math.Round(HelperTestBase.Model_GVL.GVL_T16.rGradienteForcaRetorno, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_T16_ActuationGradientBackward", Math.Round(HelperTestBase.Model_GVL.GVL_T16.rGradienteDeslocamentoRetorno, 2).ToString());

                            #endregion

                            #region Results

                            dicResultParam.Add("resultCalcTestParam_T16_InputTravel", Math.Round(HelperTestBase.Model_GVL.GVL_T16.rDeslocamentoMaximo_mm, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_T16_InputTravelBar", Math.Round(HelperTestBase.Model_GVL.GVL_T16.rDeslocamentoNaPressao_mm, 2).ToString());

                            #endregion

                            #region Results_Footer

                            dicResultParam.Add("resultCalcTestParam_T16_PCHoseConsumers", HelperTestBase.Model_GVL.GVL_T16.iConsumidoresCP.ToString());
                            dicResultParam.Add("resultCalcTestParam_T16_SCHoseConsumers", HelperTestBase.Model_GVL.GVL_T16.iConsumidoresCS.ToString());
                            dicResultParam.Add("resultCalcTestParam_T16_RoomTemperature", Math.Round(HelperTestBase.Model_GVL.GVL_T16.rTemperaturaInicial, 2).ToString());

                            #endregion

                            HelperTestBase.Model_GVL.helperTestBase_ModelGVL_Test = HelperTestBase.Model_GVL.GVL_T16;

                            #endregion

                            break;
                        }
                    case 17:    //Lost Travel ACU - Hydraulic
                        {
                            #region Results

                            #region Resuls Load Offline

                            if (dicReturnReadFileHeader[0]?.Count() > 0 && HelperTestBase.ProjectTestConcluded.IdProjectTestConcluded > 0 && HelperTestBase.ProjectTestConcluded.IdProject > 0)
                            {
                                var dicReturnReadFileHeaderPrj = dicReturnReadFileHeader[0];
                                var dicReturnReadFileHeaderParam = dicReturnReadFileHeader[1];
                                var dicReturnReadFileHeaderResults = dicReturnReadFileHeader[2];

                                #region Results

                                #region Results_Header

                                HelperTestBase.Model_GVL.GVL_T17.rVacuoInicial = dicReturnReadFileHeaderResults.ContainsKey("Vacuum") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Vacuum"]) : 0;
                                HelperTestBase.Model_GVL.GVL_T17.rGradienteForcaAvanco = dicReturnReadFileHeaderResults.ContainsKey("Force Increase Gradient") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Force Increase Gradient"]) * -1 : 0;
                                HelperTestBase.Model_GVL.GVL_T17.rGradienteDeslocamentoAvanco = dicReturnReadFileHeaderResults.ContainsKey("Actuation Gradient Forward") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Actuation Gradient Forward"]) * -1 : 0;
                                HelperTestBase.Model_GVL.GVL_T17.rForcaMaxima = dicReturnReadFileHeaderResults.ContainsKey("Actuation Force") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Actuation Force"]) * -1 : 0;
                                HelperTestBase.Model_GVL.GVL_T17.rGradienteForcaRetorno = dicReturnReadFileHeaderResults.ContainsKey("Force Decrease Gradient") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Force Decrease Gradient"]) : 0;
                                HelperTestBase.Model_GVL.GVL_T17.rGradienteDeslocamentoRetorno = dicReturnReadFileHeaderResults.ContainsKey("Actuation Gradient Backward") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Actuation Gradient Backward"]) : 0;

                                #endregion

                                #region Results

                                //dicReturnReadFileHeaderResults.Keys.Any(k => k.StartsWith("Jumper Gradient ("))
                                var matchesPressureAtForce = from k in dicReturnReadFileHeaderResults
                                                             where k.Key.Contains("Travel At")
                                                             select new
                                                             {
                                                                 k.Key,
                                                                 k.Value
                                                             };

                                HelperTestBase.Model_GVL.GVL_T17.rCursoMorto_mm = dicReturnReadFileHeaderResults.Keys.Any(k => k.StartsWith("Lost Travel")) ? NumberDoubleCheck(dicReturnReadFileHeaderResults.ElementAt(dicReturnReadFileHeaderResults.Keys.Select(x => x.Contains("Lost Travel")).ToList().FindIndex(a => a.Equals(true))).Value) * -1 : 0;
                                HelperTestBase.Model_GVL.GVL_T17.rCursoNaPressao1_mm = dicReturnReadFileHeaderResults.Keys.Any(k => k.StartsWith("Travel At")) ? NumberDoubleCheck(dicReturnReadFileHeaderResults.ElementAt(dicReturnReadFileHeaderResults.Keys.Select(x => x.Contains("Travel At")).ToList().FindIndex(a => a.Equals(true))).Value) * -1 : 0;
                                HelperTestBase.Model_GVL.GVL_T17.rCursoNaPressao2_mm = dicReturnReadFileHeaderResults.Keys.Any(k => k.StartsWith("Travel At")) ? NumberDoubleCheck(dicReturnReadFileHeaderResults.ElementAt(dicReturnReadFileHeaderResults.Keys.Select(x => x.Contains("Travel At")).ToList().FindIndex(a => a.Equals(true))).Value) * -1 : 0;
                                HelperTestBase.Model_GVL.GVL_T17.rCursoNaPressao3_mm = dicReturnReadFileHeaderResults.Keys.Any(k => k.StartsWith("Travel At")) ? NumberDoubleCheck(dicReturnReadFileHeaderResults.ElementAt(dicReturnReadFileHeaderResults.Keys.Select(x => x.Contains("Travel At")).ToList().FindIndex(a => a.Equals(true))).Value) * -1 : 0;
                                HelperTestBase.Model_GVL.GVL_T17.rCursoNaPressao4_mm = dicReturnReadFileHeaderResults.Keys.Any(k => k.StartsWith("Travel At")) ? NumberDoubleCheck(dicReturnReadFileHeaderResults.ElementAt(dicReturnReadFileHeaderResults.Keys.Select(x => x.Contains("Travel At")).ToList().FindIndex(a => a.Equals(true))).Value) * -1 : 0;

                                #endregion

                                #region Results_Footer

                                HelperTestBase.Model_GVL.GVL_T17.iConsumidoresCP = dicReturnReadFileHeaderResults.ContainsKey("PC Hose Consumers") ? Convert.ToInt32(dicReturnReadFileHeaderResults["PC Hose Consumers"]) : 0;
                                HelperTestBase.Model_GVL.GVL_T17.iConsumidoresCS = dicReturnReadFileHeaderResults.ContainsKey("SC Hose Consumers") ? Convert.ToInt32(dicReturnReadFileHeaderResults["SC Hose Consumers"]) : 0;
                                HelperTestBase.Model_GVL.GVL_T17.rTemperaturaInicial = dicReturnReadFileHeaderResults.ContainsKey("Room Temperature") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Room Temperature"]) * -1 : 0;

                                #endregion

                                #endregion

                            }

                            #endregion

                            #region #region Results_Header

                            dicResultParam.Add("resultCalcTestParam_Vacuum", Math.Round(HelperTestBase.Model_GVL.GVL_T17.rVacuoInicial, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_ForceIncreaseGradient", Math.Round(HelperTestBase.Model_GVL.GVL_T17.rGradienteForcaAvanco, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_ActuationGradientForward", Math.Round(HelperTestBase.Model_GVL.GVL_T17.rGradienteDeslocamentoAvanco, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_ActuationForce", Math.Round(HelperTestBase.Model_GVL.GVL_T17.rForcaMaxima, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_ForceDecreaseGradient", Math.Round(HelperTestBase.Model_GVL.GVL_T17.rGradienteForcaRetorno, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_ActuationGradientBackward", Math.Round(HelperTestBase.Model_GVL.GVL_T17.rGradienteDeslocamentoRetorno, 2).ToString());

                            #endregion

                            #region Results

                            dicResultParam.Add("resultCalcTestParam_LostTravel", Math.Round(HelperTestBase.Model_GVL.GVL_T17.rCursoMorto_mm, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_TravelAt1", Math.Round(HelperTestBase.Model_GVL.GVL_T17.rCursoNaPressao1_mm, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_TravelAt2", Math.Round(HelperTestBase.Model_GVL.GVL_T17.rCursoNaPressao2_mm, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_TravelAt3", Math.Round(HelperTestBase.Model_GVL.GVL_T17.rCursoNaPressao3_mm, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_TravelAt4", Math.Round(HelperTestBase.Model_GVL.GVL_T17.rCursoNaPressao4_mm, 2).ToString());

                            #endregion

                            #region Results_Footer

                            dicResultParam.Add("resultCalcTestParam_PCHoseConsumers", HelperTestBase.Model_GVL.GVL_T17.iConsumidoresCP.ToString());
                            dicResultParam.Add("resultCalcTestParam_SCHoseConsumers", HelperTestBase.Model_GVL.GVL_T17.iConsumidoresCS.ToString());
                            dicResultParam.Add("resultCalcTestParam_RoomTemperature", Math.Round(HelperTestBase.Model_GVL.GVL_T17.rTemperaturaInicial, 2).ToString());

                            #endregion

                            HelperTestBase.Model_GVL.helperTestBase_ModelGVL_Test = HelperTestBase.Model_GVL.GVL_T17;

                            #endregion

                            break;
                        }
                    case 18:    //Lost Travel ACU - Hydraulic Electrical Actuation
                        {
                            #region Results

                            #region Resuls Load Offline

                            if (dicReturnReadFileHeader[0]?.Count() > 0 && HelperTestBase.ProjectTestConcluded.IdProjectTestConcluded > 0 && HelperTestBase.ProjectTestConcluded.IdProject > 0)
                            {
                                var dicReturnReadFileHeaderPrj = dicReturnReadFileHeader[0];
                                var dicReturnReadFileHeaderParam = dicReturnReadFileHeader[1];
                                var dicReturnReadFileHeaderResults = dicReturnReadFileHeader[2];

                                #region Results

                                #region Results_Header

                                HelperTestBase.Model_GVL.GVL_T18.rVacuoInicial = dicReturnReadFileHeaderResults.ContainsKey("Vacuum") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Vacuum"]) : 0;
                                HelperTestBase.Model_GVL.GVL_T18.rGradienteForcaAvanco = dicReturnReadFileHeaderResults.ContainsKey("Force Increase Gradient") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Force Increase Gradient"]) * -1 : 0;
                                HelperTestBase.Model_GVL.GVL_T18.rGradienteDeslocamentoAvanco = dicReturnReadFileHeaderResults.ContainsKey("Actuation Gradient Forward") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Actuation Gradient Forward"]) * -1 : 0;
                                HelperTestBase.Model_GVL.GVL_T18.rForcaMaxima = dicReturnReadFileHeaderResults.ContainsKey("Actuation Force") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Actuation Force"]) * -1 : 0;

                                #endregion

                                #region Results

                                //dicReturnReadFileHeaderResults.Keys.Any(k => k.StartsWith("Jumper Gradient ("))
                                var matchesPressureAtForce = from k in dicReturnReadFileHeaderResults
                                                             where k.Key.Contains("Travel At")
                                                             select new
                                                             {
                                                                 k.Key,
                                                                 k.Value
                                                             };

                                HelperTestBase.Model_GVL.GVL_T18.rCursoMorto_mm = dicReturnReadFileHeaderResults.Keys.Any(k => k.StartsWith("Lost Travel")) ? NumberDoubleCheck(dicReturnReadFileHeaderResults.ElementAt(dicReturnReadFileHeaderResults.Keys.Select(x => x.Contains("Lost Travel")).ToList().FindIndex(a => a.Equals(true))).Value) * -1 : 0;
                                HelperTestBase.Model_GVL.GVL_T18.rCursoNaPressao1_mm = dicReturnReadFileHeaderResults.Keys.Any(k => k.StartsWith("Travel At")) ? NumberDoubleCheck(dicReturnReadFileHeaderResults.ElementAt(dicReturnReadFileHeaderResults.Keys.Select(x => x.Contains("Travel At")).ToList().FindIndex(a => a.Equals(true))).Value) * -1 : 0;
                                HelperTestBase.Model_GVL.GVL_T18.rCursoNaPressao2_mm = dicReturnReadFileHeaderResults.Keys.Any(k => k.StartsWith("Travel At")) ? NumberDoubleCheck(dicReturnReadFileHeaderResults.ElementAt(dicReturnReadFileHeaderResults.Keys.Select(x => x.Contains("Travel At")).ToList().FindIndex(a => a.Equals(true))).Value) * -1 : 0;
                                HelperTestBase.Model_GVL.GVL_T18.rCursoNaPressao3_mm = dicReturnReadFileHeaderResults.Keys.Any(k => k.StartsWith("Travel At")) ? NumberDoubleCheck(dicReturnReadFileHeaderResults.ElementAt(dicReturnReadFileHeaderResults.Keys.Select(x => x.Contains("Travel At")).ToList().FindIndex(a => a.Equals(true))).Value) * -1 : 0;
                                HelperTestBase.Model_GVL.GVL_T18.rCursoNaPressao4_mm = dicReturnReadFileHeaderResults.Keys.Any(k => k.StartsWith("Travel At")) ? NumberDoubleCheck(dicReturnReadFileHeaderResults.ElementAt(dicReturnReadFileHeaderResults.Keys.Select(x => x.Contains("Travel At")).ToList().FindIndex(a => a.Equals(true))).Value) * -1 : 0;

                                #endregion

                                #region Results_Footer

                                HelperTestBase.Model_GVL.GVL_T18.iConsumidoresCP = dicReturnReadFileHeaderResults.ContainsKey("PC Hose Consumers") ? Convert.ToInt32(dicReturnReadFileHeaderResults["PC Hose Consumers"]) : 0;
                                HelperTestBase.Model_GVL.GVL_T18.iConsumidoresCS = dicReturnReadFileHeaderResults.ContainsKey("SC Hose Consumers") ? Convert.ToInt32(dicReturnReadFileHeaderResults["SC Hose Consumers"]) : 0;
                                HelperTestBase.Model_GVL.GVL_T18.rTemperaturaInicial = dicReturnReadFileHeaderResults.ContainsKey("Room Temperature") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Room Temperature"]) * -1 : 0;

                                #endregion

                                #endregion

                            }

                            #endregion

                            #region #region Results_Header

                            dicResultParam.Add("resultCalcTestParam_Vacuum", Math.Round(HelperTestBase.Model_GVL.GVL_T18.rVacuoInicial, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_ActuationGradientForward", Math.Round(HelperTestBase.Model_GVL.GVL_T18.rGradienteDeslocamentoAvanco, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_ActuationForce", Math.Round(HelperTestBase.Model_GVL.GVL_T18.rForcaMaxima, 2).ToString());

                            #endregion

                            #region Results

                            dicResultParam.Add("resultCalcTestParam_LostTravel", Math.Round(HelperTestBase.Model_GVL.GVL_T18.rCursoMorto_mm, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_TravelAt1", Math.Round(HelperTestBase.Model_GVL.GVL_T18.rCursoNaPressao1_mm, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_TravelAt2", Math.Round(HelperTestBase.Model_GVL.GVL_T18.rCursoNaPressao2_mm, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_TravelAt3", Math.Round(HelperTestBase.Model_GVL.GVL_T18.rCursoNaPressao3_mm, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_TravelAt4", Math.Round(HelperTestBase.Model_GVL.GVL_T18.rCursoNaPressao4_mm, 2).ToString());

                            #endregion

                            #region Results_Footer

                            dicResultParam.Add("resultCalcTestParam_PCHoseConsumers", HelperTestBase.Model_GVL.GVL_T18.iConsumidoresCP.ToString());
                            dicResultParam.Add("resultCalcTestParam_SCHoseConsumers", HelperTestBase.Model_GVL.GVL_T18.iConsumidoresCS.ToString());
                            dicResultParam.Add("resultCalcTestParam_RoomTemperature", Math.Round(HelperTestBase.Model_GVL.GVL_T18.rTemperaturaInicial, 2).ToString());

                            #endregion

                            HelperTestBase.Model_GVL.helperTestBase_ModelGVL_Test = HelperTestBase.Model_GVL.GVL_T18;

                            #endregion

                            break;
                        }
                    case 19:    //Lost Travel ACU - Pneumatic Primary
                        {
                            #region Results

                            #region Resuls Load Offline

                            if (dicReturnReadFileHeader[0]?.Count() > 0 && HelperTestBase.ProjectTestConcluded.IdProjectTestConcluded > 0 && HelperTestBase.ProjectTestConcluded.IdProject > 0)
                            {
                                var dicReturnReadFileHeaderPrj = dicReturnReadFileHeader[0];
                                var dicReturnReadFileHeaderParam = dicReturnReadFileHeader[1];
                                var dicReturnReadFileHeaderResults = dicReturnReadFileHeader[2];

                                #region Results

                                #region Results_Header

                                HelperTestBase.Model_GVL.GVL_T19.rVacuoInicial = dicReturnReadFileHeaderResults.ContainsKey("Vacuum") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Vacuum"]) : 0;
                                HelperTestBase.Model_GVL.GVL_T19.rGradienteForcaAvanco = dicReturnReadFileHeaderResults.ContainsKey("Force Increase Gradient") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Force Increase Gradient"]) * -1 : 0;
                                HelperTestBase.Model_GVL.GVL_T19.rGradienteDeslocamentoAvanco = dicReturnReadFileHeaderResults.ContainsKey("Actuation Gradient Forward") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Actuation Gradient Forward"]) * -1 : 0;
                                HelperTestBase.Model_GVL.GVL_T19.rForcaMaxima = dicReturnReadFileHeaderResults.ContainsKey("Actuation Force") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Actuation Force"]) * -1 : 0;
                                HelperTestBase.Model_GVL.GVL_T19.rGradienteForcaRetorno = dicReturnReadFileHeaderResults.ContainsKey("Force Decrease Gradient") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Force Decrease Gradient"]) : 0;
                                HelperTestBase.Model_GVL.GVL_T19.rGradienteDeslocamentoRetorno = dicReturnReadFileHeaderResults.ContainsKey("Actuation Gradient Backward") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Actuation Gradient Backward"]) : 0;

                                #endregion

                                #region Results
                                
                                HelperTestBase.Model_GVL.GVL_T19.rPressaoSistemaFechadoReal_Bar = dicReturnReadFileHeaderResults.ContainsKey("Pressure with closed system") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Pressure with closed system"]) : 0;
                                HelperTestBase.Model_GVL.GVL_T19.rPressaoSistemaAbertoReal_Bar = dicReturnReadFileHeaderResults.ContainsKey("Pressure with opened system") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Pressure with opened system"]) : 0;
                                HelperTestBase.Model_GVL.GVL_T19.rDeslocamentoNaPressao_mm = dicReturnReadFileHeaderResults.ContainsKey("Travel at") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Travel at"]) : 0;

                                #endregion

                                #region Results_Footer

                                HelperTestBase.Model_GVL.GVL_T19.rTemperaturaInicial = dicReturnReadFileHeaderResults.ContainsKey("Room Temperature") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Room Temperature"]) * -1 : 0;

                                #endregion

                                #endregion

                            }

                            #endregion

                            #region #region Results_Header

                            dicResultParam.Add("resultCalcTestParam_Vacuum", Math.Round(HelperTestBase.Model_GVL.GVL_T19.rVacuoInicial, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_ActuationGradientForward", Math.Round(HelperTestBase.Model_GVL.GVL_T19.rGradienteDeslocamentoAvanco, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_ActuationForce", Math.Round(HelperTestBase.Model_GVL.GVL_T19.rForcaMaxima, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_ActuationGradientBackward", Math.Round(HelperTestBase.Model_GVL.GVL_T19.rGradienteDeslocamentoRetorno, 2).ToString());

                            #endregion

                            #region Results

                            dicResultParam.Add("resultCalcTestParam_PressureWithClosedSystem", Math.Round(HelperTestBase.Model_GVL.GVL_T19.rPressaoSistemaFechadoReal_Bar, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_PressureWithOpenedSystem", Math.Round(HelperTestBase.Model_GVL.GVL_T19.rPressaoSistemaAbertoReal_Bar, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_LostTravelClosingTravel", Math.Round(HelperTestBase.Model_GVL.GVL_T19.rDeslocamentoNaPressao_mm, 2).ToString());

                            #endregion

                            #region Results_Footer

                            dicResultParam.Add("resultCalcTestParam_RoomTemperature", Math.Round(HelperTestBase.Model_GVL.GVL_T19.rTemperaturaInicial, 2).ToString());

                            #endregion

                            HelperTestBase.Model_GVL.helperTestBase_ModelGVL_Test = HelperTestBase.Model_GVL.GVL_T19;

                            #endregion

                            break;
                        }
                    case 20:    //Lost Travel ACU - Pneumatic Secondary
                        {
                            #region Results

                            #region Resuls Load Offline

                            if (dicReturnReadFileHeader[0]?.Count() > 0 && HelperTestBase.ProjectTestConcluded.IdProjectTestConcluded > 0 && HelperTestBase.ProjectTestConcluded.IdProject > 0)
                            {
                                var dicReturnReadFileHeaderPrj = dicReturnReadFileHeader[0];
                                var dicReturnReadFileHeaderParam = dicReturnReadFileHeader[1];
                                var dicReturnReadFileHeaderResults = dicReturnReadFileHeader[2];

                                #region Results

                                #region Results_Header

                                HelperTestBase.Model_GVL.GVL_T20.rVacuoInicial = dicReturnReadFileHeaderResults.ContainsKey("Vacuum") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Vacuum"]) : 0;
                                HelperTestBase.Model_GVL.GVL_T20.rGradienteForcaAvanco = dicReturnReadFileHeaderResults.ContainsKey("Force Increase Gradient") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Force Increase Gradient"]) * -1 : 0;
                                HelperTestBase.Model_GVL.GVL_T20.rGradienteDeslocamentoAvanco = dicReturnReadFileHeaderResults.ContainsKey("Actuation Gradient Forward") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Actuation Gradient Forward"]) * -1 : 0;
                                HelperTestBase.Model_GVL.GVL_T20.rForcaMaxima = dicReturnReadFileHeaderResults.ContainsKey("Actuation Force") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Actuation Force"]) * -1 : 0;
                                HelperTestBase.Model_GVL.GVL_T20.rGradienteForcaRetorno = dicReturnReadFileHeaderResults.ContainsKey("Force Decrease Gradient") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Force Decrease Gradient"]) : 0;
                                HelperTestBase.Model_GVL.GVL_T20.rGradienteDeslocamentoRetorno = dicReturnReadFileHeaderResults.ContainsKey("Actuation Gradient Backward") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Actuation Gradient Backward"]) : 0;

                                #endregion

                                #region Results

                                HelperTestBase.Model_GVL.GVL_T20.rPressaoSistemaFechadoReal_Bar = dicReturnReadFileHeaderResults.ContainsKey("Pressure with closed system") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Pressure with closed system"]) : 0;
                                HelperTestBase.Model_GVL.GVL_T20.rPressaoSistemaAbertoReal_Bar = dicReturnReadFileHeaderResults.ContainsKey("Pressure with opened system") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Pressure with opened system"]) : 0;
                                HelperTestBase.Model_GVL.GVL_T20.rDeslocamentoNaPressao_mm = dicReturnReadFileHeaderResults.ContainsKey("Travel at") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Travel at"]) : 0;

                                #endregion

                                #region Results_Footer

                                HelperTestBase.Model_GVL.GVL_T20.rTemperaturaInicial = dicReturnReadFileHeaderResults.ContainsKey("Room Temperature") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Room Temperature"]) * -1 : 0;

                                #endregion

                                #endregion

                            }

                            #endregion

                            #region #region Results_Header

                            dicResultParam.Add("resultCalcTestParam_Vacuum", Math.Round(HelperTestBase.Model_GVL.GVL_T20.rVacuoInicial, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_ActuationGradientForward", Math.Round(HelperTestBase.Model_GVL.GVL_T20.rGradienteDeslocamentoAvanco, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_ActuationForce", Math.Round(HelperTestBase.Model_GVL.GVL_T20.rForcaMaxima, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_ActuationGradientBackward", Math.Round(HelperTestBase.Model_GVL.GVL_T20.rGradienteDeslocamentoRetorno, 2).ToString());

                            #endregion

                            #region Results

                            dicResultParam.Add("resultCalcTestParam_PressureWithClosedSystem", Math.Round(HelperTestBase.Model_GVL.GVL_T20.rPressaoSistemaFechadoReal_Bar, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_PressureWithOpenedSystem", Math.Round(HelperTestBase.Model_GVL.GVL_T20.rPressaoSistemaAbertoReal_Bar, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_LostTravelClosingTravel", Math.Round(HelperTestBase.Model_GVL.GVL_T20.rDeslocamentoNaPressao_mm, 2).ToString());

                            #endregion

                            #region Results_Footer

                            dicResultParam.Add("resultCalcTestParam_RoomTemperature", Math.Round(HelperTestBase.Model_GVL.GVL_T20.rTemperaturaInicial, 2).ToString());

                            #endregion

                            HelperTestBase.Model_GVL.helperTestBase_ModelGVL_Test = HelperTestBase.Model_GVL.GVL_T20;

                            #endregion

                            break;
                        }
                    case 21:    //Pedal Feeling Characteristics
                        {
                            #region Results

                            #region Resuls Load Offline

                            if (dicReturnReadFileHeader[0]?.Count() > 0 && HelperTestBase.ProjectTestConcluded.IdProjectTestConcluded > 0 && HelperTestBase.ProjectTestConcluded.IdProject > 0)
                            {
                                var dicReturnReadFileHeaderPrj = dicReturnReadFileHeader[0];
                                var dicReturnReadFileHeaderParam = dicReturnReadFileHeader[1];
                                var dicReturnReadFileHeaderResults = dicReturnReadFileHeader[2];

                                #region Results

                                #region Results_Header

                                HelperTestBase.Model_GVL.GVL_T21.rVacuoInicial = dicReturnReadFileHeaderResults.ContainsKey("Vacuum") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Vacuum"]) : 0;
                                HelperTestBase.Model_GVL.GVL_T21.rGradienteForcaAvanco = dicReturnReadFileHeaderResults.ContainsKey("Force Increase Gradient") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Force Increase Gradient"]) * -1 : 0;
                                //HelperTestBase.Model_GVL.GVL_T21.rGradienteDeslocamentoAvanco = dicReturnReadFileHeaderResults.ContainsKey("Actuation Gradient Forward") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Actuation Gradient Forward"]) * -1 : 0;
                                HelperTestBase.Model_GVL.GVL_T21.rForcaMaxima = dicReturnReadFileHeaderResults.ContainsKey("Actuation Force") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Actuation Force"]) * -1 : 0;
                                HelperTestBase.Model_GVL.GVL_T21.rGradienteForcaRetorno = dicReturnReadFileHeaderResults.ContainsKey("Force Decrease Gradient") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Force Decrease Gradient"]) : 0;
                                //HelperTestBase.Model_GVL.GVL_T21.rGradienteDeslocamentoRetorno = dicReturnReadFileHeaderResults.ContainsKey("Actuation Gradient Backward") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Actuation Gradient Backward"]) : 0;

                                #endregion

                                #region Results

                              
                                HelperTestBase.Model_GVL.GVL_T21.rForcaCutIn_N = dicReturnReadFileHeaderResults.ContainsKey("Cut-in Force") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Cut-in Force"]) * -1 : 0;
                                HelperTestBase.Model_GVL.GVL_T21.rPressaoJumper_Bar = dicReturnReadFileHeaderResults.ContainsKey("Jumper") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Jumper"]) * -1 : 0;
                                HelperTestBase.Model_GVL.GVL_T21.rForcaNoJumper_N = dicReturnReadFileHeaderResults.ContainsKey("Input force at jumper") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Input force at jumper"]) * -1 : 0;
                                HelperTestBase.Model_GVL.GVL_T21.rDeslocamentoNoJumper_mm = dicReturnReadFileHeaderResults.ContainsKey("Travel at jumper") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Travel at jumper"]) * -1 : 0;
                                
                                //verificar
                                HelperTestBase.Model_GVL.GVL_T21.rForcaNaPressao_N = dicReturnReadFileHeaderResults.ContainsKey("Force at {0} bar") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Force at {0} bar"]) * -1 : 0;
                                HelperTestBase.Model_GVL.GVL_T21.rForcaNaPressao_N = dicReturnReadFileHeaderResults.ContainsKey("Travel at {0} bar") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Travel at {0} bar"]) * -1 : 0;
                                //

                                #endregion

                                #region Results_Footer

                                HelperTestBase.Model_GVL.GVL_T21.iConsumidoresCP = dicReturnReadFileHeaderResults.ContainsKey("PC Hose Consumers") ? Convert.ToInt32(dicReturnReadFileHeaderResults["PC Hose Consumers"]) : 0;
                                HelperTestBase.Model_GVL.GVL_T21.iConsumidoresCS = dicReturnReadFileHeaderResults.ContainsKey("SC Hose Consumers") ? Convert.ToInt32(dicReturnReadFileHeaderResults["SC Hose Consumers"]) : 0;
                                HelperTestBase.Model_GVL.GVL_T21.rTemperaturaInicial = dicReturnReadFileHeaderResults.ContainsKey("Room Temperature") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Room Temperature"]) * -1 : 0;

                                #endregion

                                #endregion

                            }

                            #endregion

                            #region #region Results_Header
                            //VERIFICAR
                            dicResultParam.Add("resultCalcTestParam_Vacuum", Math.Round(HelperTestBase.Model_GVL.GVL_T21.rVacuoInicial, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_ForceIncreaseGradient", Math.Round(HelperTestBase.Model_GVL.GVL_T21.rGradienteForcaAvanco, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_ActuationForce", Math.Round(HelperTestBase.Model_GVL.GVL_T21.rForcaMaxima, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_ForceDecreaseGradient", Math.Round(HelperTestBase.Model_GVL.GVL_T21.rGradienteForcaRetorno, 2).ToString());

                            #endregion

                            #region Results

                            dicResultParam.Add("resultCalcTestParam_CutInForce", Math.Round(HelperTestBase.Model_GVL.GVL_T21.rForcaCutIn_N, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_Jumper", Math.Round(HelperTestBase.Model_GVL.GVL_T21.rPressaoJumper_Bar, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_InputForceAtJumper", Math.Round(HelperTestBase.Model_GVL.GVL_T21.rForcaNoJumper_N, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_TravelAtJumper", Math.Round(HelperTestBase.Model_GVL.GVL_T21.rDeslocamentoNoJumper_mm, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_ForceAtXXbar", Math.Round(HelperTestBase.Model_GVL.GVL_T21.rForcaNaPressao_N, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_TravelAtXXbar", Math.Round(HelperTestBase.Model_GVL.GVL_T21.rDeslocamentoNaPressao_mm, 2).ToString());

                            #endregion

                            #region Results_Footer

                            dicResultParam.Add("resultCalcTestParam_PCHoseConsumers", HelperTestBase.Model_GVL.GVL_T21.iConsumidoresCP.ToString());
                            dicResultParam.Add("resultCalcTestParam_SCHoseConsumers", HelperTestBase.Model_GVL.GVL_T21.iConsumidoresCS.ToString());
                            dicResultParam.Add("resultCalcTestParam_RoomTemperature", Math.Round(HelperTestBase.Model_GVL.GVL_T21.rTemperaturaInicial, 2).ToString());

                            #endregion

                            HelperTestBase.Model_GVL.helperTestBase_ModelGVL_Test = HelperTestBase.Model_GVL.GVL_T21;

                            #endregion

                            break;
                        }
                    case 22:    //Actuation / Release - Mechanical Actuation
                        {
                            #region Results

                            #region Resuls Load Offline

                            if (dicReturnReadFileHeader[0]?.Count() > 0 && HelperTestBase.ProjectTestConcluded.IdProjectTestConcluded > 0 && HelperTestBase.ProjectTestConcluded.IdProject > 0)
                            {
                                var dicReturnReadFileHeaderPrj = dicReturnReadFileHeader[0];
                                var dicReturnReadFileHeaderParam = dicReturnReadFileHeader[1];
                                var dicReturnReadFileHeaderResults = dicReturnReadFileHeader[2];

                                #region Results

                                #region Results_Header

                                HelperTestBase.Model_GVL.GVL_T22.rVacuoInicial = dicReturnReadFileHeaderResults.ContainsKey("Vacuum") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Vacuum"]) : 0;
                                HelperTestBase.Model_GVL.GVL_T22.rGradienteForcaAvanco = dicReturnReadFileHeaderResults.ContainsKey("Force Increase Gradient") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Force Increase Gradient"]) * -1 : 0;
                                HelperTestBase.Model_GVL.GVL_T22.rGradienteDeslocamentoAvanco = dicReturnReadFileHeaderResults.ContainsKey("Actuation Gradient Forward") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Actuation Gradient Forward"]) * -1 : 0;
                                HelperTestBase.Model_GVL.GVL_T22.rForcaMaxima = dicReturnReadFileHeaderResults.ContainsKey("Actuation Force") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Actuation Force"]) * -1 : 0;
                                HelperTestBase.Model_GVL.GVL_T22.rGradienteForcaRetorno = dicReturnReadFileHeaderResults.ContainsKey("Force Decrease Gradient") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Force Decrease Gradient"]) : 0;
                                HelperTestBase.Model_GVL.GVL_T22.rGradienteDeslocamentoRetorno = dicReturnReadFileHeaderResults.ContainsKey("Actuation Gradient Backward") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Actuation Gradient Backward"]) : 0;

                                #endregion

                                #region Results

                                HelperTestBase.Model_GVL.GVL_T22.rDeslocamentoMaximo = dicReturnReadFileHeaderResults.ContainsKey("Input Travel") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Input Travel"]) * -1 : 0;
                                HelperTestBase.Model_GVL.GVL_T22.rTempoAtuacao_s = dicReturnReadFileHeaderResults.ContainsKey("Actuation Time") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Actuation Time"]) * -1 : 0;

                                //recupera VARIOS itens que contenham o memso texto e guarda a qtd
                                var matchesReleaseTime = from k in dicReturnReadFileHeaderResults
                                                         where k.Key.Contains("Release Time")
                                                         select new
                                                         {
                                                             k.Key,
                                                             k.Value
                                                         };

                                HelperTestBase.Model_GVL.GVL_T22.rTempoRetorno_s = matchesReleaseTime.Count() > 0 ? NumberDoubleCheck(matchesReleaseTime.ToList()[0].Value) * -1 : 0;
                                HelperTestBase.Model_GVL.GVL_T22.rTempoRetornoNoDeslocamento_s = matchesReleaseTime.Count() > 0 ? NumberDoubleCheck(matchesReleaseTime.ToList()[1].Value) * -1 : 0;
                                //HelperTestBase.Model_GVL.GVL_T22.rTempoRetorno_s = dicReturnReadFileHeaderResults.ContainsKey("Release Time") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Release Time"]) * -1 : 0;
                                //HelperTestBase.Model_GVL.GVL_T22.rTempoRetornoNoDeslocamento_s = dicReturnReadFileHeaderResults.ContainsKey("Release Time") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Release Time"]) * -1 : 0;

                                HelperTestBase.Model_GVL.GVL_T22.rDiferencaPressaoPCSC_bar = dicReturnReadFileHeaderResults.ContainsKey("Pressure Difference PC SC") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Pressure Difference PC SC"]) * -1 : 0;
                                HelperTestBase.Model_GVL.GVL_T22.rPressaoAuxiliarRef = dicReturnReadFileHeaderResults.ContainsKey("Auxiliary Pressure") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Auxiliary Pressure"]) * -1 : 0;
                                HelperTestBase.Model_GVL.GVL_T22.rDeslocamentoNaPressao_mm = dicReturnReadFileHeaderResults.ContainsKey("Input Travel at") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Input Travel at"]) * -1 : 0;

                                #endregion

                                #region Results_Footer

                                HelperTestBase.Model_GVL.GVL_T22.iConsumidoresCP = dicReturnReadFileHeaderResults.ContainsKey("PC Hose Consumers") ? Convert.ToInt32(dicReturnReadFileHeaderResults["PC Hose Consumers"]) : 0;
                                HelperTestBase.Model_GVL.GVL_T22.iConsumidoresCS = dicReturnReadFileHeaderResults.ContainsKey("SC Hose Consumers") ? Convert.ToInt32(dicReturnReadFileHeaderResults["SC Hose Consumers"]) : 0;
                                HelperTestBase.Model_GVL.GVL_T22.rTemperaturaInicial = dicReturnReadFileHeaderResults.ContainsKey("Room Temperature") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Room Temperature"]) * -1 : 0;

                                #endregion

                                #endregion

                            }

                            #endregion

                            #region #region Results_Header

                            dicResultParam.Add("resultCalcTestParam_Vacuum", Math.Round(HelperTestBase.Model_GVL.GVL_T22.rVacuoInicial, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_ForceIncreaseGradient", Math.Round(HelperTestBase.Model_GVL.GVL_T22.rGradienteForcaAvanco, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_ActuationGradientForward", Math.Round(HelperTestBase.Model_GVL.GVL_T22.rGradienteDeslocamentoAvanco, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_ActuationForce", Math.Round(HelperTestBase.Model_GVL.GVL_T22.rForcaMaxima, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_ForceDecreaseGradient", Math.Round(HelperTestBase.Model_GVL.GVL_T22.rGradienteForcaRetorno, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_ActuationGradientBackward", Math.Round(HelperTestBase.Model_GVL.GVL_T22.rGradienteDeslocamentoRetorno, 2).ToString());

                            #endregion

                            #region Results

                            dicResultParam.Add("resultCalcTestParam_InputTravel", Math.Round(HelperTestBase.Model_GVL.GVL_T22.rDeslocamentoMaximo, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_ActuationTime", Math.Round(HelperTestBase.Model_GVL.GVL_T22.rTempoAtuacao_s, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_ReleaseTime", Math.Round(HelperTestBase.Model_GVL.GVL_T22.rTempoRetorno_s, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_ReleaseTimeToTravel", Math.Round(HelperTestBase.Model_GVL.GVL_T22.rTempoFinalRetornoNoDeslocamento_s, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_PressureDifferencePCSC", Math.Round(HelperTestBase.Model_GVL.GVL_T22.rDiferencaPressaoPCSC_bar, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_AuxiliaryPressure", Math.Round(HelperTestBase.Model_GVL.GVL_T22.rPressaoAuxiliarRef, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_InputTraveAt", Math.Round(HelperTestBase.Model_GVL.GVL_T22.rDeslocamentoNaPressao, 2).ToString());

                            #endregion

                            #region Results_Footer

                            dicResultParam.Add("resultCalcTestParam_PCHoseConsumers", HelperTestBase.Model_GVL.GVL_T22.iConsumidoresCP.ToString());
                            dicResultParam.Add("resultCalcTestParam_SCHoseConsumers", HelperTestBase.Model_GVL.GVL_T22.iConsumidoresCS.ToString());
                            dicResultParam.Add("resultCalcTestParam_RoomTemperature", Math.Round(HelperTestBase.Model_GVL.GVL_T22.rTemperaturaInicial, 2).ToString());

                            #endregion

                            HelperTestBase.Model_GVL.helperTestBase_ModelGVL_Test = HelperTestBase.Model_GVL.GVL_T22;

                            #endregion

                            break;
                        }
                    case 23:    //Breather Hole / Central Valve open
                        {
                            #region Results

                                #region Resuls Load Offline

                            if (dicReturnReadFileHeader[0]?.Count() > 0 && HelperTestBase.ProjectTestConcluded.IdProjectTestConcluded > 0 && HelperTestBase.ProjectTestConcluded.IdProject > 0)
                            {
                                var dicReturnReadFileHeaderPrj = dicReturnReadFileHeader[0];
                                var dicReturnReadFileHeaderParam = dicReturnReadFileHeader[1];
                                var dicReturnReadFileHeaderResults = dicReturnReadFileHeader[2];

                                #region Results

                                #region Results_Header

                                HelperTestBase.Model_GVL.GVL_T23.rVacuoInicial = dicReturnReadFileHeaderResults.ContainsKey("Vacuum") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Vacuum"]) : 0;
                                HelperTestBase.Model_GVL.GVL_T23.rGradienteForcaAvanco = dicReturnReadFileHeaderResults.ContainsKey("Force Increase Gradient") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Force Increase Gradient"]) * -1 : 0;
                                HelperTestBase.Model_GVL.GVL_T23.rGradienteDeslocamentoAvanco = dicReturnReadFileHeaderResults.ContainsKey("Actuation Gradient Forward") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Actuation Gradient Forward"]) * -1 : 0;
                                HelperTestBase.Model_GVL.GVL_T23.rForcaMaxima = dicReturnReadFileHeaderResults.ContainsKey("Actuation Force") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Actuation Force"]) * -1 : 0;
                                HelperTestBase.Model_GVL.GVL_T23.rGradienteForcaRetorno = dicReturnReadFileHeaderResults.ContainsKey("Force Decrease Gradient") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Force Decrease Gradient"]) : 0;
                                HelperTestBase.Model_GVL.GVL_T23.rGradienteDeslocamentoRetorno = dicReturnReadFileHeaderResults.ContainsKey("Actuation Gradient Backward") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Actuation Gradient Backward"]) : 0;

                                #endregion

                                #region Results


                                HelperTestBase.Model_GVL.GVL_T23.rDeslocamentoMaximo_mm = dicReturnReadFileHeaderResults.ContainsKey("Input Travel") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Input Travel"]) * -1 : 0;
                                HelperTestBase.Model_GVL.GVL_T23.rPressaoHidraulicaAbertura_Bar = dicReturnReadFileHeaderResults.ContainsKey("Testing Pressure at Aperture") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Testing Pressure at Aperture"]) * -1 : 0;
                                HelperTestBase.Model_GVL.GVL_T23.rPressaoHidraulicaRespiro_Bar = dicReturnReadFileHeaderResults.ContainsKey("Filling Pressure at Breather") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Filling Pressure at Breather"]) * -1 : 0;

                                #endregion

                                #region Results_Footer

                                HelperTestBase.Model_GVL.GVL_T23.iConsumidoresCP = dicReturnReadFileHeaderResults.ContainsKey("PC Hose Consumers") ? Convert.ToInt32(dicReturnReadFileHeaderResults["PC Hose Consumers"]) : 0;
                                HelperTestBase.Model_GVL.GVL_T23.iConsumidoresCS = dicReturnReadFileHeaderResults.ContainsKey("SC Hose Consumers") ? Convert.ToInt32(dicReturnReadFileHeaderResults["SC Hose Consumers"]) : 0;
                                HelperTestBase.Model_GVL.GVL_T23.rTemperaturaInicial = dicReturnReadFileHeaderResults.ContainsKey("Room Temperature") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Room Temperature"]) * -1 : 0;

                                #endregion

                                #endregion

                            }

                            #endregion

                            #region #region Results_Header

                            dicResultParam.Add("resultCalcTestParam_Vacuum", Math.Round(HelperTestBase.Model_GVL.GVL_T23.rVacuoInicial, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_ForceIncreaseGradient", Math.Round(HelperTestBase.Model_GVL.GVL_T23.rGradienteForcaAvanco, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_ActuationGradientForward", Math.Round(HelperTestBase.Model_GVL.GVL_T23.rGradienteDeslocamentoAvanco, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_ActuationForce", Math.Round(HelperTestBase.Model_GVL.GVL_T23.rForcaMaxima, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_ForceDecreaseGradient", Math.Round(HelperTestBase.Model_GVL.GVL_T23.rGradienteForcaRetorno, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_ActuationGradientBackward", Math.Round(HelperTestBase.Model_GVL.GVL_T23.rGradienteDeslocamentoRetorno, 2).ToString());

                            #endregion

                            #region Results

                            dicResultParam.Add("resultCalcTestParam_InputTravel", Math.Round(HelperTestBase.Model_GVL.GVL_T23.rDeslocamentoMaximo_mm, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_TestingPressureAtAperture", Math.Round(HelperTestBase.Model_GVL.GVL_T23.rPressaoHidraulicaAbertura_Bar, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_FillingPressureAtBreather", Math.Round(HelperTestBase.Model_GVL.GVL_T23.rPressaoHidraulicaRespiro_Bar, 2).ToString());

                            #endregion

                            #region Results_Footer

                            dicResultParam.Add("resultCalcTestParam_PCHoseConsumers", HelperTestBase.Model_GVL.GVL_T23.iConsumidoresCP.ToString());
                            dicResultParam.Add("resultCalcTestParam_SCHoseConsumers", HelperTestBase.Model_GVL.GVL_T23.iConsumidoresCS.ToString());
                            dicResultParam.Add("resultCalcTestParam_RoomTemperature", Math.Round(HelperTestBase.Model_GVL.GVL_T23.rTemperaturaInicial, 2).ToString());

                            #endregion

                            HelperTestBase.Model_GVL.helperTestBase_ModelGVL_Test = HelperTestBase.Model_GVL.GVL_T23;
                            #endregion

                            break;
                        }
                    case 24:    //Efficiency
                        {
                            #region Results

                            #region Resuls Load Offline

                            if (dicReturnReadFileHeader[0]?.Count() > 0 && HelperTestBase.ProjectTestConcluded.IdProjectTestConcluded > 0 && HelperTestBase.ProjectTestConcluded.IdProject > 0)
                            {
                                var dicReturnReadFileHeaderPrj = dicReturnReadFileHeader[0];
                                var dicReturnReadFileHeaderParam = dicReturnReadFileHeader[1];
                                var dicReturnReadFileHeaderResults = dicReturnReadFileHeader[2];

                                #region Results

                                #region Results_Header

                                HelperTestBase.Model_GVL.GVL_T24.rVacuoInicial = dicReturnReadFileHeaderResults.ContainsKey("Vacuum") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Vacuum"]) : 0;
                                
                                #endregion

                                #region Results

                                HelperTestBase.Model_GVL.GVL_T24.rForcaMaximaSlow = dicReturnReadFileHeaderResults.ContainsKey("Actuation Force Slow") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Actuation Force Slow"]) * -1 : 0;
                                HelperTestBase.Model_GVL.GVL_T24.rForcaMaximaFast = dicReturnReadFileHeaderResults.ContainsKey("Actuation Force Fast") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Actuation Force Fast"]) * -1 : 0;
                                HelperTestBase.Model_GVL.GVL_T24.rGradientePressaoSlow = dicReturnReadFileHeaderResults.ContainsKey("Pressure Gradient Slow") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Pressure Gradient Slow"]) * -1 : 0;
                                HelperTestBase.Model_GVL.GVL_T24.rGradientePressaoFast = dicReturnReadFileHeaderResults.ContainsKey("Pressure Gradient Fast") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Pressure Gradient Fast"]) * -1 : 0;
                                HelperTestBase.Model_GVL.GVL_T24.rEficiencia = dicReturnReadFileHeaderResults.ContainsKey("Efficiency at") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Efficiency at"]) * -1 : 0;

                                #endregion

                                #region Results_Footer

                                HelperTestBase.Model_GVL.GVL_T24.iConsumidoresCP = dicReturnReadFileHeaderResults.ContainsKey("PC Hose Consumers") ? Convert.ToInt32(dicReturnReadFileHeaderResults["PC Hose Consumers"]) : 0;
                                HelperTestBase.Model_GVL.GVL_T24.iConsumidoresCS = dicReturnReadFileHeaderResults.ContainsKey("SC Hose Consumers") ? Convert.ToInt32(dicReturnReadFileHeaderResults["SC Hose Consumers"]) : 0;
                                HelperTestBase.Model_GVL.GVL_T24.rTemperaturaInicial = dicReturnReadFileHeaderResults.ContainsKey("Room Temperature") ? NumberDoubleCheck(dicReturnReadFileHeaderResults["Room Temperature"]) * -1 : 0;

                                #endregion

                                #endregion

                            }

                            #endregion

                            #region #region Results_Header

                            dicResultParam.Add("resultCalcTestParam_Vacuum", Math.Round(HelperTestBase.Model_GVL.GVL_T24.rVacuoInicial, 2).ToString());

                            #endregion

                            #region Results

                            dicResultParam.Add("resultCalcTestParam_ActuationForceSlow", Math.Round(HelperTestBase.Model_GVL.GVL_T24.rForcaMaximaSlow, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_ActuationForceFast", Math.Round(HelperTestBase.Model_GVL.GVL_T24.rForcaMaximaFast, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_PressureGradientSlow", Math.Round(HelperTestBase.Model_GVL.GVL_T24.rGradientePressaoSlow, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_PressureGradientFast", Math.Round(HelperTestBase.Model_GVL.GVL_T24.rGradientePressaoFast, 2).ToString());
                            dicResultParam.Add("resultCalcTestParam_Efficiency", Math.Round(HelperTestBase.Model_GVL.GVL_T24.rEficiencia, 2).ToString());

                            #endregion

                            #region Results_Footer

                            dicResultParam.Add("resultCalcTestParam_PCHoseConsumers", HelperTestBase.Model_GVL.GVL_T24.iConsumidoresCP.ToString());
                            dicResultParam.Add("resultCalcTestParam_SCHoseConsumers", HelperTestBase.Model_GVL.GVL_T24.iConsumidoresCS.ToString());
                            dicResultParam.Add("resultCalcTestParam_RoomTemperature", Math.Round(HelperTestBase.Model_GVL.GVL_T24.rTemperaturaInicial, 2).ToString());

                            #endregion

                            HelperTestBase.Model_GVL.helperTestBase_ModelGVL_Test = HelperTestBase.Model_GVL.GVL_T24;

                            #endregion

                            break;
                        }
                    case 25:    //Force Diagrams - Force/Pressure Dual Ratio
                        {
                            break;
                        }
                    case 26:    //Force Diagrams - Force/Force Dual Ratio
                        {
                            break;
                        }
                    case 27:    //ADAM - Find Switching Point With TMC
                        {
                            break;
                        }
                    case 28:    //ADAM - Switching Point Without TMC
                        {
                            break;
                        }
                    case 29:    //Bleed
                        {
                            #region Results

                            #region #region Results_Header

                            #endregion

                            #region Results

                            //dicResultParam.Add("resultCalcTestParam_Actuations", Math.Round(HelperTestBase.Model_GVL.GVL_T29. , 2).ToString());
                            //dicResultParam.Add("resultCalcTestParam_Repetitions", Math.Round(HelperTestBase.Model_GVL.GVL_T29. , 2).ToString());
                            //dicResultParam.Add("resultCalcTestParam_PumpingTime", Math.Round(HelperTestBase.Model_GVL.GVL_T29. , 2).ToString());

                            #endregion

                            #region Results_Footer

                            #endregion

                            HelperTestBase.Model_GVL.helperTestBase_ModelGVL_Test = HelperTestBase.Model_GVL.GVL_T24;

                            #endregion

                            break;
                        }

                    default:
                        break;
                }

                #endregion


                listResultParam = TabTableParameters_FormatResultParam(dtTableResults, lstInfoEvaluationParameters, dicResultParam);
            }
            catch (Exception ex)
            {
                var err = ex.Message;
                throw;
            }

            return listResultParam;
        }

        public List<Model_Operational_TestTableParameters> TabTableParameters_FormatResultParam(DataTable dtTableResults, List<ActuationParameters_EvaluationParameters> lstInfoEvaluationParameters, Dictionary<string, string> dicResultParam)
        {
            int i = 0;

            List<Model_Operational_TestTableParameters> listResultParamFormated = new List<Model_Operational_TestTableParameters>();

            try
            {
                //if (lstInfoEvaluationParameters.Count() != dicResultParam.Count())
                //{
                //    MessageBox.Show("Error, Parm result data error!", appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    return null;
                //}

                for (i = 0; i < dtTableResults.Rows.Count; i++)
                {
                    #region Get BD List Results

                    DataRow row = dtTableResults.Rows[i];


                    string strResultParam_Id = row.Field<int>("IdResultParam").ToString()?.Trim();

                    string strResultParam_Name = row.Field<string>("ResultParam_Name")?.ToString()?.Trim();

                    string strResultParam_Caption = row.Field<string>("ResultParam_Caption")?.ToString()?.Trim();

                    string strResultParam_Nominal = row.Field<string>("ResultParam_Nominal")?.ToString()?.Trim();

                    string strResultParam_Measured = row.Field<string>("ResultParam_Measured")?.ToString()?.Trim();

                    string strResultParam_Unit = row.Field<string>("UnitSymbol")?.ToString()?.Trim();

                    #endregion

                    #region Format Data Captions And Results

                    string keyResultParam_Name = dicResultParam.ElementAt(i).Key?.Replace("resultCalcTestParam_", "")?.Trim();

                    string keyResultParam_Value = dicResultParam.ElementAt(i).Value?.Trim();

                    char ch = '{';

                    if (strResultParam_Caption.Contains(ch))
                    {
                        int numStrFormat = strResultParam_Caption.Where(x => (x == ch)).Count();

                        if (keyResultParam_Name.Equals(strResultParam_Name))
                        {
                            switch (strResultParam_Name.Trim())
                            {
                                #region T01

                                case "PressureAt90Percent": //T01
                                    {
                                        strResultParam_Caption = String.Format(strResultParam_Caption, dicResultParam["resultCalcTestParam_ForcaAt90Percent"])?.Trim();
                                        strResultParam_Measured = dicResultParam["resultCalcTestParam_PressureAt90Percent"]?.Trim();
                                        break;
                                    }
                                case "PressureAt70Percent": //T01
                                    {
                                        strResultParam_Caption = String.Format(strResultParam_Caption, dicResultParam["resultCalcTestParam_ForcaAt70Percent"])?.Trim();
                                        strResultParam_Measured = dicResultParam["resultCalcTestParam_PressureAt70Percent"]?.Trim();
                                        break;
                                    }
                                case "JumperGradient": //T01
                                    {
                                        string str01_ForcaP2Jumper_N = dicResultParam["resultCalcTestParam_ForcaP2Jumper_N"]?.Trim();
                                        string str02_GradienteJumper_P2_Bar = dicResultParam["resultCalcTestParam_GradienteJumper_P2_Bar"]?.Trim();
                                        string str03_ForcaP1Jumper_N = dicResultParam["resultCalcTestParam_ForcaP1Jumper_N"]?.Trim();
                                        string str04_GradienteJumper_P1_Bar = dicResultParam["resultCalcTestParam_GradienteJumper_P1_Bar"]?.Trim();

                                        strResultParam_Caption = String.Format(strResultParam_Caption, str01_ForcaP2Jumper_N, str02_GradienteJumper_P2_Bar, str03_ForcaP1Jumper_N, str04_GradienteJumper_P1_Bar);
                                        strResultParam_Measured = dicResultParam["resultCalcTestParam_JumperGradient"]?.Trim();
                                    }
                                    break;

                                #endregion

                                #region T02

                                case "T02_ForceAt90Percent": //T02
                                    {
                                        strResultParam_Caption = String.Format(strResultParam_Caption, dicResultParam["resultCalcTestParam_T02_ForceAt90Percent"])?.Trim();
                                        strResultParam_Measured = dicResultParam["resultCalcTestParam_T02_ForceAt90Percent"]?.Trim();
                                        break;
                                    }
                                case "T02_ForceAt70Percent": //T02
                                    {
                                        strResultParam_Caption = String.Format(strResultParam_Caption, dicResultParam["resultCalcTestParam_T02_ForceAt70Percent"])?.Trim();
                                        strResultParam_Measured = dicResultParam["resultCalcTestParam_T02_ForceAt70Percent"]?.Trim();
                                        break;
                                    }
                               case "T02_JumperGradient": //T02
                                //    {
                                //        string str01_ForcaP2Jumper_N = dicResultParam["resultCalcTestParam_T02_ForcaP2Jumper_N"]?.Trim();
                                //        string str02_GradienteJumper_P2_Bar = dicResultParam["resultCalcTestParam_T02_GradienteJumper_P2_Bar"]?.Trim();
                                //        string str03_ForcaP1Jumper_N = dicResultParam["resultCalcTestParam_T02_ForcaP1Jumper_N"]?.Trim();
                                //        string str04_GradienteJumper_P1_Bar = dicResultParam["resultCalcTestParam_T02_GradienteJumper_P1_Bar"]?.Trim();

                                //        strResultParam_Caption = String.Format(strResultParam_Caption, str01_ForcaP2Jumper_N, str02_GradienteJumper_P2_Bar, str03_ForcaP1Jumper_N, str04_GradienteJumper_P1_Bar);
                                //        strResultParam_Measured = dicResultParam["resultCalcTestParam_T02_JumperGradient"]?.Trim();
                                //    }
                                break;

                                #endregion

                                #region T04

                                case "T04_OutputForceAtE1": //T04
                                    {
                                        strResultParam_Caption = String.Format(strResultParam_Caption, dicResultParam["resultCalcTestParam_T04_OutputForceAtE1"])?.Trim();
                                        strResultParam_Measured = dicResultParam["resultCalcTestParam_T04_OutputForceAtE1"]?.Trim();
                                        break;
                                    }
                                case "T04_OutputForceAtE2": //T04
                                    {
                                        strResultParam_Caption = String.Format(strResultParam_Caption, dicResultParam["resultCalcTestParam_T04_OutputForceAtE2"])?.Trim();
                                        strResultParam_Measured = dicResultParam["resultCalcTestParam_T04_OutputForceAtE2"]?.Trim();
                                        break;
                                    }
                                case "T04_ReleaseForceRemainingAt": //T04
                                    {
                                        strResultParam_Caption = String.Format(strResultParam_Caption, dicResultParam["resultCalcTestParam_T04_ReleaseForceRemainingAt"])?.Trim();
                                        strResultParam_Measured = dicResultParam["resultCalcTestParam_T04_ReleaseForceRemainingAt"]?.Trim();
                                        break;
                                    }

                                #endregion

                                #region T06

                                case "ActuationForceXX":
                                case "TravelAtXX":
                                    {
                                        strResultParam_Name = "ForcePercentEout";
                                        string strInputTableParam = lstInfoEvaluationParameters.Where(x => x.EvalParam_ResultParam_Name.Equals(strResultParam_Name)).Select(a => a.EvalParam_Hi).FirstOrDefault().ToString()?.Trim();

                                        strResultParam_Caption = String.Format(strResultParam_Caption, strInputTableParam);
                                        strResultParam_Measured = keyResultParam_Value;
                                        break;
                                    }

                                #endregion

                                #region T07

                                case "ActuationForce1": //T07_
                                case "TravelAt1": //T07_
                                    {
                                        strResultParam_Name = "ActuationForceAt1";
                                        string strInputTableParam = lstInfoEvaluationParameters.Where(x => x.EvalParam_ResultParam_Name.Equals(strResultParam_Name)).Select(a => a.EvalParam_Hi).FirstOrDefault().ToString()?.Trim();

                                        strResultParam_Caption = String.Format(strResultParam_Caption, strInputTableParam);
                                        strResultParam_Measured = keyResultParam_Value;
                                        break;
                                    }
                                case "ActuationForce2": //T07_
                                case "TravelAt2": //T07_
                                    {
                                        strResultParam_Name = "ActuationForceAt2";
                                        string strInputTableParam = lstInfoEvaluationParameters.Where(x => x.EvalParam_ResultParam_Name.Equals(strResultParam_Name)).Select(a => a.EvalParam_Hi).FirstOrDefault().ToString()?.Trim();

                                        strResultParam_Caption = String.Format(strResultParam_Caption, strInputTableParam);
                                        strResultParam_Measured = keyResultParam_Value;
                                        break;
                                    }
                                case "ActuationForce3": //T07_
                                case "TravelAt3": //T07_
                                    {
                                        strResultParam_Name = "ActuationForceAt3";
                                        string strInputTableParam = lstInfoEvaluationParameters.Where(x => x.EvalParam_ResultParam_Name.Equals(strResultParam_Name)).Select(a => a.EvalParam_Hi).FirstOrDefault().ToString()?.Trim();

                                        strResultParam_Caption = String.Format(strResultParam_Caption, strInputTableParam);
                                        strResultParam_Measured = keyResultParam_Value;
                                        break;
                                    }
                                #endregion

                                #region T08

                                case "ActuationForce": //T08_
                                case "TravelAt": //T08_
                                    {
                                        strResultParam_Name = "ActuationForce";
                                        string strInputTableParam = lstInfoEvaluationParameters.Where(x => x.EvalParam_ResultParam_Name.Equals(strResultParam_Name)).Select(a => a.EvalParam_Hi).FirstOrDefault().ToString()?.Trim();

                                        strResultParam_Caption = String.Format(strResultParam_Caption, strInputTableParam);
                                        strResultParam_Measured = keyResultParam_Value;
                                        break;
                                    }

                                #endregion

                                #region T12

                                case "ActuationTime": //T12_
                                    {
                                        strResultParam_Name = "ActuationTimePercent";
                                        string strInputTableParam = lstInfoEvaluationParameters.Where(x => x.EvalParam_ResultParam_Name.Equals(strResultParam_Name)).Select(a => a.EvalParam_Hi).FirstOrDefault().ToString()?.Trim();

                                        strResultParam_Caption = String.Format(strResultParam_Caption, strInputTableParam);
                                        strResultParam_Measured = keyResultParam_Value;
                                        break;
                                    }
                                case "ReleaseTime": //T12_
                                    {
                                        strResultParam_Name = "ReleaseTimePercent";
                                        string strInputTableParam = lstInfoEvaluationParameters.Where(x => x.EvalParam_ResultParam_Name.Equals(strResultParam_Name)).Select(a => a.EvalParam_Hi).FirstOrDefault().ToString()?.Trim();

                                        strResultParam_Caption = String.Format(strResultParam_Caption, strInputTableParam);
                                        strResultParam_Measured = keyResultParam_Value;
                                        break;
                                    }

                                #endregion

                                #region T21

                                case "ForceAtXXbar": //T21_
                                case "TravelAtXXbar": //T21_
                                    {
                                        strResultParam_Name = "LostTravel";
                                        string strInputTableParam = lstInfoEvaluationParameters.Where(x => x.EvalParam_ResultParam_Name.Equals(strResultParam_Name)).Select(a => a.EvalParam_Hi).FirstOrDefault().ToString()?.Trim();

                                        strResultParam_Caption = String.Format(strResultParam_Caption, strInputTableParam);
                                        strResultParam_Measured = keyResultParam_Value;
                                        break;
                                    }

                                #endregion

                                default:
                                    {
                                        for (int j = 0; j < numStrFormat; j++)
                                        {
                                            string strInputTableParam = lstInfoEvaluationParameters.Where(x => x.EvalParam_ResultParam_Name.Equals(strResultParam_Name)).Select(a => a.EvalParam_Hi).FirstOrDefault().ToString()?.Trim();

                                            strResultParam_Caption = String.Format(strResultParam_Caption, strInputTableParam);
                                            strResultParam_Measured = keyResultParam_Value;
                                        }
                                    }
                                    break;
                            }
                        }
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(strResultParam_Name))
                        {
                            string strInputTableParamVal = lstInfoEvaluationParameters.Where(x => x.EvalParam_ResultParam_Name.Equals(strResultParam_Name)).Select(a => a.EvalParam_Hi).FirstOrDefault().ToString()?.Trim();

                            switch (strResultParam_Name.Trim())
                            {
                                case "PCHoseConsumers":
                                    {
                                        strResultParam_Measured = dicResultParam["resultCalcTestParam_PCHoseConsumers"]?.Trim();
                                        break;
                                    }
                                case "SCHoseConsumers":
                                    {
                                        strResultParam_Measured = dicResultParam["resultCalcTestParam_SCHoseConsumers"]?.Trim();
                                        break;
                                    }
                                case "RoomTemperature":
                                    {
                                        strResultParam_Measured = dicResultParam["resultCalcTestParam_RoomTemperature"]?.Trim();
                                        break;
                                    }
                                default:
                                    {
                                        strResultParam_Measured = keyResultParam_Value;
                                        break;
                                    }
                            }
                        }
                    }


                    #endregion

                    #region List Data

                    listResultParamFormated.Add(new Model_Operational_TestTableParameters()
                    {
                        IdResultParam = Convert.ToInt32(strResultParam_Id),
                        ResultParam_Name = strResultParam_Name,
                        ResultParam_Caption = strResultParam_Caption,
                        ResultParam_Nominal = strResultParam_Nominal,
                        ResultParam_Measured = strResultParam_Measured,
                        ResultParam_Unit = strResultParam_Unit
                    });

                    #endregion
                }
            }
            catch (Exception ex)
            {
                var iErrorIdx = i;
                var err = ex.Message;
                throw;
            }

            HelperApp.lstResultParamFormated.Clear();

            HelperApp.dicResultParam = dicResultParam;
            HelperApp.lstResultParamFormated = listResultParamFormated;

            return listResultParamFormated;
        }

        #endregion

        #region tab_ActionParameters
        public List<ActuationParameters_EvaluationParameters> GridView_GetValuesEvalParam(DataGridView grid)
        {
            //Setup list object
            var lstParamAnalog = new List<ActuationParameters_EvaluationParameters>();

            try
            {
                //Loop through datagridview rows
                foreach (DataGridViewRow row in grid.Rows)
                {
                    if (row.Cells.Count > 0)
                    {
                        var obj = new ActuationParameters_EvaluationParameters()
                        {
                            IdEvalParam = !string.IsNullOrEmpty(row.Cells["IdEvalParam"]?.Value?.ToString()) ? Convert.ToInt32(row.Cells["IdEvalParam"]?.Value) : 0,
                            //IdTestAvailable = !!string.IsNullOrEmpty(row.Cells["IdTestAvailable"]?.Value?.ToString()) ? Convert.ToInt32(row.Cells["IdTestAvailable"]?.Value) : 0,
                            //EvalParam_GridRowType = !string.IsNullOrEmpty(row.Cells["EvalParam_GridRowType"]?.Value?.ToString()) ? row.Cells["EvalParam_GridRowType"]?.Value?.ToString()?.Trim() : string.Empty,
                            EvalParam_Name = !string.IsNullOrEmpty(row.Cells["EvalParam_Name"]?.Value?.ToString()) ? row.Cells["EvalParam_Name"]?.Value?.ToString()?.Trim() : string.Empty,
                            EvalParam_Caption = !string.IsNullOrEmpty(row.Cells["EvalParam_Caption"]?.Value?.ToString()) ? row.Cells["EvalParam_Caption"]?.Value?.ToString()?.Trim() : string.Empty,
                            EvalParam_ResultParam_Name = !string.IsNullOrEmpty(row.Cells["EvalParam_ResultParam_Name"]?.Value?.ToString()) ? row.Cells["EvalParam_ResultParam_Name"]?.Value?.ToString()?.Trim() : string.Empty,
                            EvalParam_Hi = !string.IsNullOrEmpty(row.Cells["EvalParam_Hi"]?.Value?.ToString()) ? Convert.ToDouble(row.Cells["EvalParam_Hi"]?.Value) : 0,
                            //EvalParam_Precision = !string.IsNullOrEmpty(row.Cells["EvalParam_Precision"]?.Value?.ToString()) ? Convert.ToDouble(row.Cells["EvalParam_Precision"]?.Value) : 0,
                            //EvalParam_Step = !string.IsNullOrEmpty(row.Cells["EvalParam_Step"]?.Value?.ToString()) ? Convert.ToDouble(row.Cells["EvalParam_Step"]?.Value) : 0,
                            EvalParam_Mksunit = !string.IsNullOrEmpty(row.Cells["UnitSymbol"]?.Value?.ToString()) ? row.Cells["UnitSymbol"]?.Value?.ToString()?.Trim() : string.Empty
                        };

                        if (obj.IdEvalParam > 0)
                            lstParamAnalog.Add(obj);
                    }
                }
            }
            catch (Exception ex)
            {
                var err = ex.Message;
                throw;
            }

            HelperApp.lstEvaluationParameters.Clear();
            HelperApp.lstEvaluationParameters = lstParamAnalog;

            return lstParamAnalog;
        }
        public Model_TabActuationParameters_EvaluationParameters TransfValuesEvalParam(List<ActuationParameters_EvaluationParameters> lstParamAnalog)
        {

            var evalParamAnalog = new Model_TabActuationParameters_EvaluationParameters();

            try
            {
                if (lstParamAnalog?.Count > 0)
                {
                    evalParamAnalog = new Model_TabActuationParameters_EvaluationParameters()
                    {
                        EForceScale = lstParamAnalog.Where(x => x.EvalParam_Name.Equals("EForceScale")).Select(a => a.EvalParam_Hi).FirstOrDefault().ToString(),
                        EPressureScale = lstParamAnalog.Where(x => x.EvalParam_Name.Equals("EPressureScale")).Select(a => a.EvalParam_Hi).FirstOrDefault().ToString(),
                        EP3AtForce = lstParamAnalog.Where(x => x.EvalParam_Name.Equals("EP3AtForce")).Select(a => a.EvalParam_Hi).FirstOrDefault().ToString(),
                        EP4AtForce = lstParamAnalog.Where(x => x.EvalParam_Name.Equals("EP4AtForce")).Select(a => a.EvalParam_Hi).FirstOrDefault().ToString(),
                        EP5AtForce = lstParamAnalog.Where(x => x.EvalParam_Name.Equals("EP5AtForce")).Select(a => a.EvalParam_Hi).FirstOrDefault().ToString(),
                        EP6AtForce = lstParamAnalog.Where(x => x.EvalParam_Name.Equals("EP6AtForce")).Select(a => a.EvalParam_Hi).FirstOrDefault().ToString(),
                        EPistonTravelAtPressure = lstParamAnalog.Where(x => x.EvalParam_Name.Equals("EPistonTravelAtPressure")).Select(a => a.EvalParam_Hi).FirstOrDefault().ToString(),
                        EActuationForceAtPressure = lstParamAnalog.Where(x => x.EvalParam_Name.Equals("EActuationForceAtPressure")).Select(a => a.EvalParam_Hi).FirstOrDefault().ToString(),
                        EReleaseForceMin = lstParamAnalog.Where(x => x.EvalParam_Name.Equals("EReleaseForceMin")).Select(a => a.EvalParam_Hi).FirstOrDefault().ToString(),
                        EReleaseForceMax = lstParamAnalog.Where(x => x.EvalParam_Name.Equals("EReleaseForceMax")).Select(a => a.EvalParam_Hi).FirstOrDefault().ToString(),
                        EHysteresisAtPressure = lstParamAnalog.Where(x => x.EvalParam_Name.Equals("EHysteresisAtPressure")).Select(a => a.EvalParam_Hi).FirstOrDefault().ToString(),
                        EHysteresisAtPressure2 = lstParamAnalog.Where(x => x.EvalParam_Name.Equals("EHysteresisAtPressure2")).Select(a => a.EvalParam_Hi).FirstOrDefault().ToString(),
                        ERelForceRemainAtTravel = lstParamAnalog.Where(x => x.EvalParam_Name.Equals("ERelForceRemainAtTravel")).Select(a => a.EvalParam_Hi).FirstOrDefault().ToString(),
                        ETMCDiameterPC = lstParamAnalog.Where(x => x.EvalParam_Name.Equals("ETMCDiameterPC")).Select(a => a.EvalParam_Hi).FirstOrDefault().ToString(),
                        ETMCDiameterSC = lstParamAnalog.Where(x => x.EvalParam_Name.Equals("ETMCDiameterSC")).Select(a => a.EvalParam_Hi).FirstOrDefault().ToString(),
                        EJumperGradientP1 = lstParamAnalog.Where(x => x.EvalParam_Name.Equals("EJumperGradientP1")).Select(a => a.EvalParam_Hi).FirstOrDefault().ToString(),
                        EJumperGradientP2 = lstParamAnalog.Where(x => x.EvalParam_Name.Equals("EJumperGradientP2")).Select(a => a.EvalParam_Hi).FirstOrDefault().ToString(),
                        CBUseLinearIntersection = lstParamAnalog.Where(x => x.EvalParam_Name.Equals("CBUseLinearIntersection")).Select(a => a.EvalParam_Hi).FirstOrDefault().ToString(),
                    };
                }
                else
                {
                    evalParamAnalog = new Model_TabActuationParameters_EvaluationParameters()
                    {
                        EForceScale = string.Empty,
                        EPressureScale = string.Empty,
                        EP3AtForce = string.Empty,
                        EP4AtForce = string.Empty,
                        EP5AtForce = string.Empty,
                        EP6AtForce = string.Empty,
                        EPistonTravelAtPressure = string.Empty,
                        EActuationForceAtPressure = string.Empty,
                        EReleaseForceMin = string.Empty,
                        EReleaseForceMax = string.Empty,
                        EHysteresisAtPressure = string.Empty,
                        EHysteresisAtPressure2 = string.Empty,
                        ERelForceRemainAtTravel = string.Empty,
                        ETMCDiameterPC = string.Empty,
                        ETMCDiameterSC = string.Empty,
                        EJumperGradientP1 = string.Empty,
                        EJumperGradientP2 = string.Empty,
                        CBUseLinearIntersection = string.Empty,
                    };
                }
            }
            catch (Exception ex)
            {
                var err = ex.Message;
                throw;
            }

            return evalParamAnalog;
        }

        #endregion

        #endregion

        #endregion

        #endregion

        #region Methods
        public NumberFormatInfo NumberDoubleFormat()
        {
            var format = new NumberFormatInfo();
            format.NegativeSign = "-";
            format.NumberNegativePattern = 1;
            format.NumberDecimalSeparator = ".";

            return format;
        }
        public double NumberDoubleCheck(string strValue)
        {
            decimal decValue = 0;

            double dblValue = 0;

            Decimal.TryParse(strValue.Replace(",", "."), NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign, NumberDoubleFormat(), out decValue);

            if (!strValue.Contains(NumberDoubleFormat().NegativeSign))
                decValue = (decValue * -1);

            Double.TryParse(decValue.ToString().Replace(",", "."), NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign, NumberDoubleFormat(), out dblValue);

            dblValue = Math.Round(dblValue, 2);

            return dblValue;
        }

        #endregion

        #region Methods TESTS
        public Dictionary<string, string>[] ReadTXTFileHeaderHBM(string fileName, string pathWithFileName)
        {
            List<string> lstReturnRead = new List<string>();

            int k = 0;
            string line = string.Empty;

            try
            {
                if (!string.IsNullOrEmpty(fileName) && !string.IsNullOrEmpty(pathWithFileName))
                {
                    // Read the file as one string.
                    if (File.Exists(pathWithFileName))
                    {
                        // Read a text file line by line.
                        string[] lines = File.ReadAllLines(pathWithFileName);

                        //project 5->13
                        //parameters 17->27
                        //results 32->58

                        #region HEADER - PROJECT

                        var lstProject = lines
                            .SkipWhile(lin => !lin.Contains("|-"))
                            .Skip(1)
                            .TakeWhile(lin => !lin.Contains("|-"))
                            .ToList();

                        Dictionary<string, string> dicReturnReadFileHeaderPrj = new Dictionary<string, string>();

                        foreach (var headerItem in lstProject)
                        {
                            if (!string.IsNullOrWhiteSpace(headerItem))
                            {
                                string[] strArray = Regex.Replace(headerItem.Trim(), @"\t|\n|\r|", "").Split(char.Parse(strCharSplit_TXTHeader_Data));

                                if (strArray.Length > 0)
                                {
                                    var headerVariableName = strArray[0]?.Trim();
                                    var headerVariableValue = strArray[1]?.Trim();

                                    dicReturnReadFileHeaderPrj.Add(headerVariableName, headerVariableValue);
                                }
                            }
                        }

                        #endregion

                        #region HEADER - PARAMETERS

                        var lstParam = lines
                            .SkipWhile(lin1 => !lin1.Contains("|-"))
                            .Skip(lstProject.Count() + 2)
                            .TakeWhile(lin1 => !lin1.Contains("|-"))
                            .ToList();

                        Dictionary<string, string> dicReturnReadFileHeaderParam = new Dictionary<string, string>();

                        foreach (var headerItem in lstParam)
                        {
                            if (!string.IsNullOrWhiteSpace(headerItem))
                            {
                                string[] strArray = Regex.Replace(headerItem.Trim(), @"\t|\n|\r|", "").Split(char.Parse(strCharSplit_TXTHeader_Data));

                                if (strArray.Length > 0)
                                {
                                    var headerVariableName = strArray[0]?.Trim();
                                    var headerVariableValue = strArray[1]?.Trim();

                                    dicReturnReadFileHeaderParam.Add(headerVariableName, headerVariableValue);
                                }
                            }
                        }

                        #endregion

                        #region HEADER - RESULTS

                        var lstResults = lines
                            .SkipWhile(lin => !lin.Contains("|-"))
                            .Skip(lstProject.Count() + lstParam.Count() + 3)
                            .TakeWhile(lin => !lin.Contains("|-"))
                            .ToList();

                        Dictionary<string, string> dicReturnReadFileHeaderResults = new Dictionary<string, string>();

                        foreach (var headerItem in lstResults)
                        {
                            if (!string.IsNullOrWhiteSpace(headerItem))
                            {
                                string[] strArray = Regex.Replace(headerItem.Trim(), @"\t|\n|\r|", "").Split(char.Parse(strCharSplit_TXTHeader_Data));

                                if (strArray.Length > 0)
                                {
                                    var headerVariableName = strArray[0]?.Trim();
                                    var headerVariableValue = !string.IsNullOrEmpty(strArray[1]) ? strArray[1].Substring(0, strArray[1].IndexOf("[")).Trim() : strArray[1]?.Trim();

                                    dicReturnReadFileHeaderResults.Add(headerVariableName, headerVariableValue);
                                }
                            }
                        }

                        #endregion

                        #region HEADER - DICTIONARY

                        dicReturnReadFileHeader[0] = dicReturnReadFileHeaderPrj;
                        dicReturnReadFileHeader[1] = dicReturnReadFileHeaderParam;
                        dicReturnReadFileHeader[2] = dicReturnReadFileHeaderResults;

                        #endregion
                    }
                }
            }
            catch (Exception ex)
            {
                var abc = k;
                var defe = line;

                var err = ex.Message;
                throw;
            }

            return dicReturnReadFileHeader;
        }
        public List<string>[] ReadTXTFileHBM(string fileName, string pathWithFileName)
        {
            int k = 0;
            int i = 0;
            string line = string.Empty;

            try
            {
                if (!string.IsNullOrEmpty(fileName) && !string.IsNullOrEmpty(pathWithFileName) && CheckFileExists(pathWithFileName))
                {
                    using (StreamReader file = new StreamReader(pathWithFileName))
                    {
                        lstStrReturnReadFileLines = File.ReadLines(pathWithFileName).ToList();

                        for (k = 0; k < lstStrReturnReadFileLines.Count; k++)
                        {
                            line = lstStrReturnReadFileLines[k];

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

                    lstStrReturnReadFile[0] = lstStrTimestamp;       //  Time [s]
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


                    for (i = 0; i < lstStrReturnReadFile.Length; i++)
                        lstDblReturnReadFile[i] = lstStrReturnReadFile[i].ConvertAll(item => double.Parse(item, CultureInfo.InvariantCulture));

                }
            }
            catch (Exception ex)
            {
                var abc = k;
                var defe = line;
                var ghi = i;

                var err = ex.Message;
                throw;
            }

            return lstStrReturnReadFile;
        }

        #endregion

        #region Methods CALC TESTS

        // LISTA DAS VARIAVEIS E ARRAYS DE CANAIS

        //List<double> lstAnalogCh00_Timestamp = lstDblChReadFileArr[0];          //  Time [s]
        //List<double> lstAnalogCh01_DiffTravel = lstDblChReadFileArr[1];         //ch9.1 - HelperHBM._rDiffTravel - Transdutor Deslocamento Desvio Linearidade - 0-10 mm (Linearizado)
        //List<double> lstAnalogCh02_InputForce1 = lstDblChReadFileArr[2];        //ch9.2 - HelperHBM._rInputForce1 - Celula Carga Forca Entrada - 0-5 kN (Linearizada)
        //List<double> lstAnalogCh03_OutputForce = lstDblChReadFileArr[3];        //ch9.3 - HelperHBM._rOutputForce - Celula Carga Forca Saída- 0-10 kN (Linearizada)
        //List<double> lstAnalogCh04_TravelTMC = lstDblChReadFileArr[4];          //ch9.4 - HelperHBM._rTravelTMC - Transdutor Deslocamento Saida Booster - 0-50 mm (Linearizada)
        //List<double> lstAnalogCh05_TravelPiston = lstDblChReadFileArr[5];       //ch9.5 - HelperHBM._rTravelPiston - Transdutor Deslocamento Entrada Booster - 0-50 mm (Linearizada)
        //List<double> lstAnalogCh06_PressureSC = lstDblChReadFileArr[6];         //ch9.6 - HelperHBM._rPressureSC - Pressao Camara Secundaria CS - 0-250 bar (Linearizada
        //List<double> lstAnalogCh07_PressurePC = lstDblChReadFileArr[7];         //ch9.7 - HelperHBM._rPressurePC - Pressao Camara Primaria CP - 0-250 bar (Linearizada)
        //List<double> lstAnalogCh08_PneumTestPressure = lstDblChReadFileArr[8];  //ch9.8 - HelperHBM._rPneumTestPressure - Pressao Teste Bolhas 0-1 bar(Linearizada)
        //List<double> lstAnalogCh09_HydrFillPressure = lstDblChReadFileArr[9];   //ch9.9 - HelperHBM._rHydrFillPressure - Pressao Sangria 0-6 bar (Linearizada)
        //List<double> lstAnalogCh10_Vaccum = lstDblChReadFileArr[10];            //ch9.10 - HelperHBM._rVaccum - Pressao Linha Vacuo (-1)-0 bar (Linearizada)
        //List<double> lstAnalogCh11_Reserv = lstDblChReadFileArr[11];            //ch9.11 - RESERVA
        //List<double> lstAnalogCh12_Reserv = lstDblChReadFileArr[12];            //ch9.12 - RESERVA
        public Model_GVL CalcGraphData(int iTesteSelecionado, List<double>[] lstDblReturnReadFile)
        {
            Model_GVL _modelGVLCalc = new Model_GVL();

            try
            {
                if (iTesteSelecionado == 0) //eEXAMTYPE.ET_NONE:
                    return _modelGVLCalc;
                else
                {
                    //set Variables
                    bool bCalculaResultados = true;

                    HelperApp.uiTesteSelecionado = iTesteSelecionado;
                    HelperTestBase.eExamType = EnumExtensionMethods.GetEnumValue<eEXAMTYPE>(HelperApp.uiTesteSelecionado);

                    switch (iTesteSelecionado)
                    {
                        case 1:     //Force Diagrams - Force/Pressure With Vacuum
                            _modelGVLCalc = CalcGraphT01_ET_ForceDiagrams_ForcePressure_WithVacuum(bCalculaResultados, lstDblReturnReadFile);
                            break;
                        case 2:     //Force Diagrams - Force/Force With Vacuum
                            _modelGVLCalc = CalcGraphT02_ET_ForceDiagrams_ForceForce_WithVacuum(bCalculaResultados, lstDblReturnReadFile);
                            break;
                        case 3:     //Force Diagrams - Force/Pressure Without Vacuum
                            _modelGVLCalc = CalcGraphT03_ET_ForceDiagrams_ForcePressure_WithoutVacuum(bCalculaResultados, lstDblReturnReadFile);
                            break;
                        case 4:     //Force Diagrams - Force/Force Without Vacuum
                            _modelGVLCalc = CalcGraphT04_ET_ForceDiagrams_ForceForce_WithoutVacuum(bCalculaResultados, lstDblReturnReadFile);
                            break;
                        case 5: //Vacuum Leakage - Released Position
                            _modelGVLCalc = CalcGraphT05_ET_VacuumLeakage_ReleasedPosition(bCalculaResultados, lstDblReturnReadFile);
                            break;
                        case 6: //Vacuum Leakage - Fully Applied Position
                            _modelGVLCalc = CalcGraphT06_ET_VacuumLeakage_FullyAppliedPosition(bCalculaResultados, lstDblReturnReadFile);
                            break;
                        case 7: //Vacuum Leakage - Lap Position
                            _modelGVLCalc = CalcGraphT07_ET_VacuumLeakage_LapPosition(bCalculaResultados, lstDblReturnReadFile);
                            break;
                        case 8:     //Hydraulic Leakage - Fully Applied Position
                            _modelGVLCalc = CalcGraphT08_ET_HydraulicLeakage_FullyAppliedPosition(bCalculaResultados, lstDblReturnReadFile);
                            break;
                        case 9:     //Hydraulic Leakage - At Low Pressure
                            _modelGVLCalc = CalcGraphT09_ET_HydraulicLeakage_AtLowPressure(bCalculaResultados, lstDblReturnReadFile);
                            break;
                        case 10:    //Hydraulic Leakage - At High Pressure
                            _modelGVLCalc = CalcGraphT10_ET_HydraulicLeakage_AtHighPressure(bCalculaResultados, lstDblReturnReadFile);
                            break;
                        case 11:    //Adjustment - Actuation Slow
                            _modelGVLCalc = CalcGraphT11_ET_ActuationSlow(bCalculaResultados, lstDblReturnReadFile);
                            break;
                        case 12:    //Adjustment - Actuation Fast
                            _modelGVLCalc = CalcGraphT12_ET_ActuationFast(bCalculaResultados, lstDblReturnReadFile);
                            break;
                        case 13:    //Check Sensors - Pressure Difference
                            _modelGVLCalc = CalcGraphT13_ET_PressureDifference(bCalculaResultados, lstDblReturnReadFile);
                            break;
                        case 14:    //Check Sensors - Input/Output Travel
                            _modelGVLCalc = CalcGraphT14_ET_InputOutputTravel(bCalculaResultados, lstDblReturnReadFile);
                            break;
                        case 15:    //Adjustment - Input Travel VS Input Force
                            _modelGVLCalc = CalcGraphT15_ET_Adjustment_InputTravelVsInputForce(bCalculaResultados, lstDblReturnReadFile);
                            break;
                        case 16:    //Adjustment - Hose Consumer
                            _modelGVLCalc = CalcGraphT16_ET_Adjustment_HoseConsumers(bCalculaResultados, lstDblReturnReadFile);
                            break;
                        case 17:    //Lost Travel ACU - Hydraulic
                            _modelGVLCalc = CalcGraphT17_ET_Adjustment_LostTravelACUHydraulic(bCalculaResultados, lstDblReturnReadFile);
                            break;
                        case 18:    //Lost Travel ACU - Hydraulic Electrical Actuation
                            _modelGVLCalc = CalcGraphT18_ET_Adjustment_LostTravelACUHydraulic_ElectricActuation(bCalculaResultados, lstDblReturnReadFile);
                            break;
                        case 19:    //Lost Travel ACU - Pneumatic Primary
                            CalcGraphT19_ET_Adjustment_LostTravelACUPneumatic_Primary(bCalculaResultados, lstDblReturnReadFile);
                            break;
                        case 20:    //Lost Travel ACU - Pneumatic Secondary
                            _modelGVLCalc = CalcGraphT20_ET_Adjustment_LostTravelACUPneumatic_Secondary(bCalculaResultados, lstDblReturnReadFile);
                            break;
                        case 21:    //Pedal Feeling Characteristics
                            _modelGVLCalc = CalcGraphT21_ET_Adjustment_PedalFellingCharacteristics(bCalculaResultados, lstDblReturnReadFile);
                            break;
                        case 22:    //Actuation / Release - Mechanical Actuation
                            _modelGVLCalc = CalcGraphT22_ET_ActuationRelease_MechanicalActuation(bCalculaResultados, lstDblReturnReadFile);
                            break;
                        case 23:    //Breather Hole / Central Valve open
                            _modelGVLCalc = CalcGraphT23_ET_BreatherHoleCentralValveOpen(bCalculaResultados, lstDblReturnReadFile);
                            break;
                        case 24:    //Efficiency
                            _modelGVLCalc = CalcGraphT24_ET_Efficiency(bCalculaResultados, lstDblReturnReadFile);
                            break;
                        case 25:    //Force Diagrams - Force/Pressure Dual Ratio
                            break;
                        case 26:    //Force Diagrams - Force/Force Dual Ratio
                            break;
                        case 27:    //ADAM - Find Switching Point With TMC
                            break;
                        case 28:    //ADAM - Switching Point Without TMC
                            break;
                        case 29:    //Bleed
                            break;

                        default:
                            break;
                    }
                }

                #region Scales Chart

                int iStartEscalaMin = 9;

                _modelGVLCalc.GVL_Graficos.EixoX.rMin = iStartEscalaMin;
                _modelGVLCalc.GVL_Graficos.EixoX.rMax = _modelGVLCalc.GVL_Graficos.rEscalaX;
                _modelGVLCalc.GVL_Graficos.EixoY1.rMin = iStartEscalaMin;
                _modelGVLCalc.GVL_Graficos.EixoY1.rMax = _modelGVLCalc.GVL_Graficos.rEscalaY1;
                _modelGVLCalc.GVL_Graficos.EixoY2.rMin = iStartEscalaMin;
                _modelGVLCalc.GVL_Graficos.EixoY2.rMax = _modelGVLCalc.GVL_Graficos.rEscalaY2;
                _modelGVLCalc.GVL_Graficos.EixoY3.rMin = iStartEscalaMin;
                _modelGVLCalc.GVL_Graficos.EixoY3.rMax = _modelGVLCalc.GVL_Graficos.rEscalaY3;
                _modelGVLCalc.GVL_Graficos.EixoY4.rMin = iStartEscalaMin;
                _modelGVLCalc.GVL_Graficos.EixoY4.rMax = _modelGVLCalc.GVL_Graficos.rEscalaY4;

                #endregion

                _modelGVLCalc.GVL_Graficos.uiTesteSelecionado = iTesteSelecionado;


                HelperTestBase.Model_GVL = _modelGVLCalc;

            }
            catch (Exception ex)
            {

                var err = ex.Message;
                throw;
            }
            return _modelGVLCalc;
        }
        public bool CalcInfoTestByStep(int iTesteSelecionado)
        {
            try
            {
                if (iTesteSelecionado == 0)
                    return false;
                else
                {
                    #region Variables

                    int divfactor = 1000;

                    HelperApp.uiTesteSelecionado = iTesteSelecionado;
                    HelperTestBase.eExamType = EnumExtensionMethods.GetEnumValue<eEXAMTYPE>(HelperApp.uiTesteSelecionado);

                    //rVacuoInicial / rVacuoFinal
                    double dblVacuoInicial = ((HelperMODBUS.CS_dwVacuoInicial_HW * 65536) + HelperMODBUS.CS_dwVacuoInicial_LW) / divfactor;
                    double dblVacuoFinal = ((HelperMODBUS.CS_dwVacuoFinal_HW * 65536) + HelperMODBUS.CS_dwVacuoFinal_LW) / divfactor;

                    //.rTemperaturaInicial = 
                    double dblTemperaturaInicial = ((HelperMODBUS.CS_dwTemperaturaInicial_HW * 65536) + HelperMODBUS.CS_dwTemperaturaInicial_LW) / divfactor;

                    //rPressaoInicialCP / rPressaoFinalCP
                    double dblPressaoInicialCP = ((HelperMODBUS.CS_PressaoInicialCP_HW * 65536) + HelperMODBUS.CS_PressaoInicialCP_LW) / divfactor;
                    double dblPressaoFinalCP = ((HelperMODBUS.CS_PressaoFinalCP_HW * 65536) + HelperMODBUS.CS_PressaoFinalCP_LW) / divfactor;

                    //rPressaoInicialCS / rPressaoFinalCS
                    double dblPressaoInicialCS = ((HelperMODBUS.CS_PressaoInicialCS_HW * 65536) + HelperMODBUS.CS_PressaoInicialCS_LW) / divfactor;
                    double dblPressaoFinalCS = ((HelperMODBUS.CS_PressaoFinalCS_HW * 65536) + HelperMODBUS.CS_PressaoFinalCS_LW) / divfactor;



                    _modelGVL.GVL_Analogicas.rVacuo_Bar = dblVacuoInicial;
                    _modelGVL.GVL_Analogicas.rTemperaturaAmbiente_C = dblTemperaturaInicial;
                    _modelGVL.GVL_Analogicas.rPressaoCP_Bar = dblPressaoInicialCP;
                    _modelGVL.GVL_Analogicas.rPressaoCS_Bar = dblPressaoInicialCS;

                    #endregion

                    #region Dados de VAcuo, Temperatura, PressaoCP e CS - Inicio  Fianl de Ciclo

                    switch (iTesteSelecionado)
                    {
                        case 1:     //Force Diagrams - Force/Pressure With Vacuum
                            {
                                HelperTestBase.Model_GVL.GVL_T01.rVacuoInicial = dblVacuoInicial;
                                HelperTestBase.Model_GVL.GVL_T01.rTemperaturaInicial = dblTemperaturaInicial;

                                break;
                            }
                        case 2:     //Force Diagrams - Force/Force With Vacuum
                            {
                                HelperTestBase.Model_GVL.GVL_T02.rVacuoInicial = dblVacuoInicial;
                                HelperTestBase.Model_GVL.GVL_T02.rTemperaturaInicial = dblTemperaturaInicial;

                                break;
                            }
                        case 3:     //Force Diagrams - Force/Pressure Without Vacuum
                            {
                                HelperTestBase.Model_GVL.GVL_T03.rVacuoInicial = dblVacuoInicial;
                                HelperTestBase.Model_GVL.GVL_T03.rTemperaturaInicial = dblTemperaturaInicial;

                                break;
                            }
                        case 4:     //Force Diagrams - Force/Force Without Vacuum
                            {
                                HelperTestBase.Model_GVL.GVL_T04.rVacuoInicial = dblVacuoInicial;
                                HelperTestBase.Model_GVL.GVL_T04.rTemperaturaInicial = dblTemperaturaInicial;

                                break;
                            }
                        case 5: //Vacuum Leakage - Released Position
                            {
                                HelperTestBase.Model_GVL.GVL_T05.rVacuoInicial = dblVacuoInicial;
                                HelperTestBase.Model_GVL.GVL_T05.rVacuoFinal = dblVacuoFinal;
                                HelperTestBase.Model_GVL.GVL_T05.rTemperaturaInicial = dblTemperaturaInicial;

                                break;
                            }
                        case 6: //Vacuum Leakage - Fully Applied Position
                            {
                                HelperTestBase.Model_GVL.GVL_T06.rVacuoInicial = dblVacuoInicial;
                                HelperTestBase.Model_GVL.GVL_T06.rTemperaturaInicial = dblTemperaturaInicial;

                                break;
                            }
                        case 7: //Vacuum Leakage - Lap Position
                            {
                                HelperTestBase.Model_GVL.GVL_T07.rVacuoInicial = dblVacuoInicial;
                                HelperTestBase.Model_GVL.GVL_T07.rTemperaturaInicial = dblTemperaturaInicial;

                                break;
                            }

                        case 8:     //Hydraulic Leakage - Fully Applied Position
                            {
                                HelperTestBase.Model_GVL.GVL_T08.rVacuoInicial = dblVacuoInicial;
                                HelperTestBase.Model_GVL.GVL_T08.rTemperaturaInicial = dblTemperaturaInicial;
                                HelperTestBase.Model_GVL.GVL_T08.rPressaoInicialCP = dblPressaoInicialCP;
                                HelperTestBase.Model_GVL.GVL_T08.rPressaoFinalCP = dblPressaoFinalCP;
                                HelperTestBase.Model_GVL.GVL_T08.rPressaoInicialCS = dblPressaoInicialCS;
                                HelperTestBase.Model_GVL.GVL_T08.rPressaoFinalCS = dblPressaoFinalCS;
                                break;
                            }
                        case 9:     //Hydraulic Leakage - At Low Pressure
                            {
                                HelperTestBase.Model_GVL.GVL_T09.rVacuoInicial = dblVacuoInicial;
                                HelperTestBase.Model_GVL.GVL_T09.rTemperaturaInicial = dblTemperaturaInicial;
                                HelperTestBase.Model_GVL.GVL_T09.rPressaoInicialCP = dblPressaoInicialCP;
                                HelperTestBase.Model_GVL.GVL_T09.rPressaoFinalCP = dblPressaoFinalCP;
                                HelperTestBase.Model_GVL.GVL_T09.rPressaoInicialCS = dblPressaoInicialCS;
                                HelperTestBase.Model_GVL.GVL_T09.rPressaoFinalCS = dblPressaoFinalCS;

                                break;
                            }
                        case 10:    //Hydraulic Leakage - At High Pressure
                            {
                                HelperTestBase.Model_GVL.GVL_T10.rVacuoInicial = dblVacuoInicial;
                                HelperTestBase.Model_GVL.GVL_T10.rTemperaturaInicial = dblTemperaturaInicial;
                                HelperTestBase.Model_GVL.GVL_T10.rPressaoInicialCP = dblPressaoInicialCP;
                                HelperTestBase.Model_GVL.GVL_T10.rPressaoFinalCP = dblPressaoFinalCP;
                                HelperTestBase.Model_GVL.GVL_T10.rPressaoInicialCS = dblPressaoInicialCS;
                                HelperTestBase.Model_GVL.GVL_T10.rPressaoFinalCS = dblPressaoFinalCS;

                                break;
                            }
                        case 11:    //Adjustment - Actuation Slow
                            {
                                HelperTestBase.Model_GVL.GVL_T11.rVacuoInicial = dblVacuoInicial;
                                HelperTestBase.Model_GVL.GVL_T11.rTemperaturaInicial = dblTemperaturaInicial;

                                break;
                            }
                        case 12:    //Adjustment - Actuation Fast
                            {
                                HelperTestBase.Model_GVL.GVL_T12.rVacuoInicial = dblVacuoInicial;
                                HelperTestBase.Model_GVL.GVL_T12.rTemperaturaInicial = dblTemperaturaInicial;

                                break;
                            }
                        case 13:    //Check Sensors - Pressure Difference
                            {
                                HelperTestBase.Model_GVL.GVL_T13.rVacuoInicial = dblVacuoInicial;
                                HelperTestBase.Model_GVL.GVL_T13.rTemperaturaInicial = dblTemperaturaInicial;

                                break;
                            }
                        case 14:    //Check Sensors - Input/Output Travel
                            {
                                HelperTestBase.Model_GVL.GVL_T14.rVacuoInicial = dblVacuoInicial;
                                HelperTestBase.Model_GVL.GVL_T14.rTemperaturaInicial = dblTemperaturaInicial;

                                break;
                            }
                        case 15:    //Adjustment - Input Travel VS Input Force
                            {
                                HelperTestBase.Model_GVL.GVL_T15.rVacuoInicial = dblVacuoInicial;
                                HelperTestBase.Model_GVL.GVL_T15.rTemperaturaInicial = dblTemperaturaInicial;

                                break;
                            }
                        case 16:    //Adjustment - Hose Consumer
                            {
                                HelperTestBase.Model_GVL.GVL_T16.rVacuoInicial = dblVacuoInicial;
                                HelperTestBase.Model_GVL.GVL_T16.rTemperaturaInicial = dblTemperaturaInicial;

                                break;
                            }
                        case 17:    //Lost Travel ACU - Hydraulic
                            {
                                HelperTestBase.Model_GVL.GVL_T17.rVacuoInicial = dblVacuoInicial;
                                HelperTestBase.Model_GVL.GVL_T17.rTemperaturaInicial = dblTemperaturaInicial;

                                break;
                            }
                        case 18:    //Lost Travel ACU - Hydraulic Electrical Actuation
                            {
                                HelperTestBase.Model_GVL.GVL_T18.rVacuoInicial = dblVacuoInicial;
                                HelperTestBase.Model_GVL.GVL_T18.rTemperaturaInicial = dblTemperaturaInicial;

                                break;
                            }
                        case 19:    //Lost Travel ACU - Pneumatic Primary
                            {
                                HelperTestBase.Model_GVL.GVL_T19.rVacuoInicial = dblVacuoInicial;
                                HelperTestBase.Model_GVL.GVL_T19.rTemperaturaInicial = dblTemperaturaInicial;
                                HelperTestBase.Model_GVL.GVL_T19.rPressaoSistemaFechadoReal_Bar = dblPressaoInicialCP;
                                HelperTestBase.Model_GVL.GVL_T19.rPressaoSistemaAbertoReal_Bar = dblPressaoFinalCP;

                                break;
                            }
                        case 20:    //Lost Travel ACU - Pneumatic Secondary
                            {
                                HelperTestBase.Model_GVL.GVL_T20.rVacuoInicial = dblVacuoInicial;
                                HelperTestBase.Model_GVL.GVL_T20.rTemperaturaInicial = dblTemperaturaInicial;
                                HelperTestBase.Model_GVL.GVL_T20.rPressaoSistemaFechadoReal_Bar = dblPressaoInicialCP;
                                HelperTestBase.Model_GVL.GVL_T20.rPressaoSistemaAbertoReal_Bar = dblPressaoFinalCP;

                                break;
                            }
                        case 21:    //Pedal Feeling Characteristics
                            {
                                HelperTestBase.Model_GVL.GVL_T21.rVacuoInicial = dblVacuoInicial;
                                HelperTestBase.Model_GVL.GVL_T21.rTemperaturaInicial = dblTemperaturaInicial;

                                break;
                            }
                        case 22:    //Actuation / Release - Mechanical Actuation
                            {
                                //HelperTestBase.Model_GVL.GVL_T22.rVacuoInicial = dblVacuoInicial;
                                //HelperTestBase.Model_GVL.GVL_T22.rTemperaturaInicial = dblTemperaturaInicial;

                                break;
                            }
                        case 23:    //Breather Hole / Central Valve open
                            {
                                HelperTestBase.Model_GVL.GVL_T23.rVacuoInicial = dblVacuoInicial;
                                HelperTestBase.Model_GVL.GVL_T23.rTemperaturaInicial = dblTemperaturaInicial;
                                HelperTestBase.Model_GVL.GVL_T23.rPressaoHidraulicaAbertura_Bar = dblPressaoInicialCP;// : REAL;
                                HelperTestBase.Model_GVL.GVL_T23.rPressaoHidraulicaRespiro_Bar = dblPressaoFinalCP;// : REAL;

                                break;
                            }
                        case 24:    //Efficiency
                            {
                                HelperTestBase.Model_GVL.GVL_T24.rVacuoInicial = dblVacuoInicial;
                                HelperTestBase.Model_GVL.GVL_T24.rTemperaturaInicial = dblTemperaturaInicial;

                                break;
                            }
                        case 25:    //Force Diagrams - Force/Pressure Dual Ratio
                            {
                                //GVL_T25.rVacuoInicial = dblVacuoInicial;
                                //GVL_T25.rTemperaturaInicial = dblTemperaturaInicial;

                                break;
                            }
                        case 26:    //Force Diagrams - Force/Force Dual Ratio
                            {
                                //GVL_T26.rVacuoInicial = dblVacuoInicial;
                                //GVL_T26.rTemperaturaInicial = dblTemperaturaInicial;

                                break;
                            }
                        case 27:    //ADAM - Find Switching Point With TMC
                            {
                                //GVL_T27.rVacuoInicial = dblVacuoInicial;
                                //GVL_T27.rTemperaturaInicial = dblTemperaturaInicial;

                                break;
                            }
                        case 28:    //ADAM - Switching Point Without TMC
                            {
                                //GVL_T28.rVacuoInicial = dblVacuoInicial;
                                //GVL_T28.rTemperaturaInicial = dblTemperaturaInicial;

                                break;
                            }
                        case 29:
                            {
                                break;
                            }
                        default:
                            break;
                    }

                    #endregion
                }
            }
            catch (Exception ex)
            {
                var err = ex.Message;
                throw;
            }

            return true;
        }

        #region CALC TESTS

        #region T01 - Calculos Forca Pressao - ET_ForceDiagrams_ForcePressure_WithVacuum
        public Model_GVL CalcGraphT01_ET_ForceDiagrams_ForcePressure_WithVacuum(bool bCalculaResultados, List<double>[] lstDblReturnReadFile)
        {
            #region PROGRAM T01_Calculos_Resultados

            try
            {
                #region Limpa ultimos resultados

                dictVarList.Clear();

                _modelGVL.GVL_T01.rForcaReal_P1_N = 0;
                _modelGVL.GVL_T01.rPressao_P1_Bar = 0;
                _modelGVL.GVL_T01.rForcaReal_P2_N = 0;
                _modelGVL.GVL_T01.rPressao_P2_Bar = 0;
                _modelGVL.GVL_T01.rForcaReal_E1_N = 0;
                _modelGVL.GVL_T01.rPressao_E1_Bar = 0;
                _modelGVL.GVL_T01.rForcaReal_E2_N = 0;
                _modelGVL.GVL_T01.rPressao_E2_Bar = 0;
                _modelGVL.GVL_T01.rForcaMaxima = 0; //Zera o ultimo valor de força obtido
                _modelGVL.GVL_T01.rGradienteForcaAvanco = 0; //Zera o ultimo valor obtido
                _modelGVL.GVL_T01.rGradienteForcaRetorno = 0; //Zera o ultimo valor obtido
                _modelGVL.GVL_T01.rGradienteDeslocamentoAvanco = 0; //Zera o ultimo valor obtido
                _modelGVL.GVL_T01.rGradienteDeslocamentoRetorno = 0; //Zera o ultimo valor obtido
                _modelGVL.GVL_T01.rRunOutForce_LinearInt_N = 0; //RunOut por intersecção linear
                _modelGVL.GVL_T01.rRunOutPressure_LinearInt_Bar = 0; //RunOut por intersecção linear
                _modelGVL.GVL_T01.rPressaoAuxiliar_P3_Bar = 0;
                _modelGVL.GVL_T01.rPressao_P4_Bar = 0;
                //_modelGVL.GVL_T01.rForca_P4_Bar = 0;
                _modelGVL.GVL_T01.rRunOutForce_Real_N = 0;
                _modelGVL.GVL_T01.rRunOutPressure_Real_Bar = 0;
                _modelGVL.GVL_T01.rPressao_70pout_bar = 0;
                _modelGVL.GVL_T01.rForca_70pout_N = 0;
                _modelGVL.GVL_T01.rPressao_90pout_bar = 0;
                _modelGVL.GVL_T01.rForca_90pout_N = 0;
                _modelGVL.GVL_T01.rDeslocamento_90pout_mm = 0;
                _modelGVL.GVL_T01.rDeslocamentoNaPressao_mm = 0;
                _modelGVL.GVL_T01.rPressao_P5_Bar = 0;
                _modelGVL.GVL_T01.rForca_F5_N = 0;
                _modelGVL.GVL_T01.rPressao_P6_Bar = 0;
                _modelGVL.GVL_T01.rForca_F6_N = 0;
                _modelGVL.GVL_T01.rForcaCutIn_N = 0;
                _modelGVL.GVL_T01.rPressaoJumper_Bar = 0;
                _modelGVL.GVL_T01.rGradientJumper = 0;
                _modelGVL.GVL_T01.rReleaseForce_N = 0;
                _modelGVL.GVL_T01.rReleaseForceAt_N = 0;
                _modelGVL.GVL_T01.rReleaseForceAtReal_mm = 0;
                _modelGVL.GVL_T01.rPressaoHysteresePout_Bar = 0;
                _modelGVL.GVL_T01.rForcaAvanco_Xpout_N = 0;
                _modelGVL.GVL_T01.rForcaRetorno_Xpout_N = 0;
                _modelGVL.GVL_T01.rHysterese_Xpout_N = 0;
                _modelGVL.GVL_T01.rForcaAvanco_Xbar_N = 0;
                _modelGVL.GVL_T01.rForcaRetorno_Xbar_N = 0;
                _modelGVL.GVL_T01.rHysterese_Xbar_N = 0;
                _modelGVL.GVL_T01.rTaxaAmplificacao = 0;
                _modelGVL.GVL_T01.iConsumidoresCP = 0;
                _modelGVL.GVL_T01.iConsumidoresCS = 0;
                _modelGVL.GVL_T01.bCalculaResultados = bCalculaResultados;

                #region VARIABLES

                long diUbound = 0; //  ; DINT;
                long di = 0; //  ; DINT;
                double rForcaInicialGradiente = 0; //  ; REAL;
                double rForcaFinalGradiente = 0; //  ; REAL;
                double rDeslocamentoInicialGradiente = 0; //   ; REAL;
                double rDeslocamentoFinalGradiente = 0; //  ; REAL;
                double rTempoInicialGradiente = 0; //  ; REAL;
                double rTempoFinalGradiente = 0; //   ; REAL;

                double rCoeficienteAngular_L1 = 0; //   = 0; REAL = 0;
                double rCoeficienteLinear_L1 = 0; //   = 0; REAL = 0;
                double rCoeficienteAngular_L2 = 0; //   = 0; REAL = 0;
                double rCoeficienteLinear_L2 = 0; //   = 0; REAL = 0;
                double rCoeficienteAngular_L3 = 0; //   = 0; REAL = 0;
                double rCoeficienteLinear_L3 = 0; //   = 0; REAL = 0;

                long diIndice_P4 = 0; //   = 0; DINT = 0;
                long diIndice_P2 = 0; //   = 0; DINT = 0;
                long diIndice_p70 = 0; //   = 0; DINT = 0;
                long diIndice_p90 = 0; //   = 0; DINT = 0;
                long diIndice_ReleaseMax = 0; //   = 0; DINT = 0;
                long diIndice_ReleaseMin = 0; //   = 0; DINT = 0;

                double rA_L3 = 0; //   = 0; REAL = 0;
                double rB_L3 = 0; //   = 0; REAL = 0;
                double rC_L3 = 0; //   = 0; REAL = 0;
                double rRaizAB = 0; //   = 0; REAL = 0;

                double rCoordX = 0; //   = 0; REAL = 0;
                double rCoordY = 0; //   = 0; REAL = 0;

                double rResulTemp = 0; //   = 0; REAL = 0;
                double rMaiorDistancia = 0; //   = 0; REAL = 0;

                #endregion

                #endregion

                #region Variaveis Grafico

                _modelGVL.GVL_Graficos.rEscalaX = 1500;
                _modelGVL.GVL_Graficos.EixoX.wsTLLabel = "AxesChart.1";
                _modelGVL.GVL_Graficos.rEscalaY1 = 150;
                _modelGVL.GVL_Graficos.EixoY1.wsTLLabel = "AxesChart.3";
                _modelGVL.GVL_Graficos.rEscalaY2 = 150;
                _modelGVL.GVL_Graficos.EixoY2.wsTLLabel = "AxesChart.4";
                _modelGVL.GVL_Graficos.rEscalaY3 = 0;
                _modelGVL.GVL_Graficos.EixoY3.wsTLLabel = string.Empty;
                _modelGVL.GVL_Graficos.rEscalaY4 = 0;
                _modelGVL.GVL_Graficos.EixoY4.wsTLLabel = string.Empty;

                _modelGVL.GVL_Graficos.strNomeEixoX = "Input Force (N)";
                _modelGVL.GVL_Graficos.strNomeEixoY1 = "Pressure PC (bar)";
                _modelGVL.GVL_Graficos.strNomeEixoY2 = "Pressure SC (bar)";
                _modelGVL.GVL_Graficos.strNomeEixoY3 = string.Empty;
                _modelGVL.GVL_Graficos.strNomeEixoY4 = string.Empty;

                _modelGVL.GVL_Graficos.strUnidadeX = "N";
                _modelGVL.GVL_Graficos.strUnidadeY1 = "bar";
                _modelGVL.GVL_Graficos.strUnidadeY2 = "bar";
                _modelGVL.GVL_Graficos.strUnidadeY3 = string.Empty;
                _modelGVL.GVL_Graficos.strUnidadeY4 = string.Empty;

                _modelGVL.GVL_Graficos.bOcultaY2 = false;
                _modelGVL.GVL_Graficos.bOcultaY3 = true;
                _modelGVL.GVL_Graficos.bOcultaY4 = true;

                //Marcacoes Grafico
                int pointArr = 0;
                int pointPos = 0;
                string pointName = string.Empty;

                #endregion

                #region Varriaveis Array Dados
                //os arrays dinamicos obtidos neste teste contem as seguintes grandezas:
                //GVL_Graficos.arrVarX  = //ch9.2 - HelperHBM._rInputForce1 - Valores Forca Entrada                 //Input Force 1 [N]
                //GVL_Graficos.arrVarY1 = //ch9.7 - HelperHBM._rPressurePC - Valores Pressao PC                     //Hydraulic Pressure PC [bar]
                //GVL_Graficos.arrVarY2 = //ch9.6 - HelperHBM._rPressureSC - Valores Pressao SC                     //Hydraulic Pressure SC [bar]
                //GVL_Graficos.arrVarY3 = //ch9.5 - HelperHBM._rTravelPiston - Valores Deslocamento Pistao (Entrada)   //Input Travel [m]

                ClearArrayGVL_Graficos();

                _modelGVL.GVL_Graficos.arrVarTimeStamp = lstDblReturnReadFile[0].ToArray();
                _modelGVL.GVL_Graficos.arrVarX = lstDblReturnReadFile[2].ToArray();

                if (_modelGVL.GVL_Parametros.iOutput < 2) //OutputPC
                {
                    _modelGVL.GVL_Parametros.iOutput = 1;
                    _modelGVL.GVL_Graficos.arrVarY1 = lstDblReturnReadFile[7].ToArray();
                    _modelGVL.GVL_Graficos.arrVarY2 = lstDblReturnReadFile[6].ToArray();
                }
                else  //OutputSC
                {
                    _modelGVL.GVL_Graficos.arrVarY1 = lstDblReturnReadFile[6].ToArray();
                    _modelGVL.GVL_Graficos.arrVarY2 = lstDblReturnReadFile[7].ToArray();
                }

                _modelGVL.GVL_Graficos.arrVarY3 = lstDblReturnReadFile[5].ToArray();

                #endregion

                #region Calculos 

                if (_modelGVL.GVL_T01.bCalculaResultados)
                {
                    _modelGVL.GVL_T01 = HelperTestBase.Model_GVL.GVL_T01;

                    //Define o ponto maximo do array que foi plotado durante o teste
                    _modelGVL.GVL_Graficos.diBuffer = lstDblReturnReadFile[0].Count() > 0 ? lstDblReturnReadFile[0].Count() : 0;

                    diUbound = _modelGVL.GVL_Graficos.diBuffer - 1;

                    #region Loop para identificar a forca maxima do teste, e armazenar o ponto de inflexao do teste (quando o atuador comeca a retornar)
                    //========================================================================================================================================================

                    //for (di = 0; di < diUbound; di++)
                    //{
                    //    if (_modelGVL.GVL_Graficos.arrVarX[di] > _modelGVL.GVL_T01.rForcaMaxima)
                    //    {
                    //        _modelGVL.GVL_T01.rForcaMaxima = _modelGVL.GVL_Graficos.arrVarX[di]; //Atualiza o valor de forca maxima com o maior valor obtido no array
                    //        _modelGVL.GVL_T01.diPosicaoForcaMaxima = di; //Indica em qual posicao do array esta a forca maxima (pico do grafico, aonde comeca o retorno do atuador)
                    //    }
                    //}


                    var lstInputForce1 = lstDblReturnReadFile[2];

                    _modelGVL.GVL_T01.rForcaMaxima = lstInputForce1.Max(); //1243.34

                    _modelGVL.GVL_T01.diPosicaoForcaMaxima = lstInputForce1.IndexOf(_modelGVL.GVL_T01.rForcaMaxima); //34272 //Indica em qual posicao do array esta a forca maxima (pico do grafico, aonde comeca o retorno do atuador)

                    HelperTestBase.MaxForce = _modelGVL.GVL_T01.rForcaMaxima; //Atualiza o valor de forca maxima com o maior valor obtido no array

                    //========================================================================================================================================================
                    #endregion

                    #region Calculo do gradiente de aplicacao de força no avanço
                    //========================================================================================================================================================

                    //Busca no array o momento em que a forca comecou a subir (forca >= 100N) e o tempo decorrido desta forca

                    //for (di = 0; di <= _modelGVL.GVL_T01.diPosicaoForcaMaxima; di++)
                    //{
                    //    if (_modelGVL.GVL_Graficos.arrVarX[di] >= 100)//forca comecou a subir (>=100N)
                    //    {
                    //        rForcaInicialGradiente = _modelGVL.GVL_Graficos.arrVarX[di]; //Valor forca inicial para calculo 
                    //        rTempoInicialGradiente = _modelGVL.GVL_Graficos.arrVarTimeStamp[di]; //Valor to tempo em ms inicial para calculo

                    //        break; //Encerra a busca pela forca inicial
                    //    }
                    //}

                    var idxUpForce = lstInputForce1.FindIndex(v => v >= 100);//forca comecou a subir (>=100N) - 16544
                    rForcaInicialGradiente = lstInputForce1.ElementAt(idxUpForce); //Valor forca inicial para calculo - 100.37

                    var lstTime = lstDblReturnReadFile[0];
                    rTempoInicialGradiente = lstTime.ElementAt(idxUpForce); //Valor to tempo em ms inicial para calculo - 6.90084

                    //Define a forca final e o tempo final do gradiente como a FMAX obtida no calculo anterior, utilizando seu indice para coletar o tempo respectivo
                    rForcaFinalGradiente = _modelGVL.GVL_Graficos.arrVarX[_modelGVL.GVL_T01.diPosicaoForcaMaxima]; //1243.34
                    rTempoFinalGradiente = _modelGVL.GVL_Graficos.arrVarTimeStamp[_modelGVL.GVL_T01.diPosicaoForcaMaxima]; //14.29448

                    //Calcula o gradiente de aplicacao de forca no avanco
                    _modelGVL.GVL_T01.rGradienteForcaAvanco = Math.Round((rForcaFinalGradiente - rForcaInicialGradiente) / (rTempoFinalGradiente - rTempoInicialGradiente), 2); //154.59
                                                                                                                                                                                //========================================================================================================================================================

                    #endregion

                    #region Calculo do gradiente de aplicacao de força no retorno
                    //========================================================================================================================================================

                    //Busca no array o momento em que a forca caiu abaixo de 100N (forca <= 100N) e o tempo decorrido desta forca

                    //Busca no array o momento em que a forca caiu abaixo de 100N (forca <= 100N) e o tempo decorrido desta forca
                    for (di = _modelGVL.GVL_T01.diPosicaoForcaMaxima; di < diUbound; di++)
                    {
                        if (_modelGVL.GVL_Graficos.arrVarX[di] <= 100) //Forca proxima de 0 (<=100N)
                        {
                            rForcaFinalGradiente = _modelGVL.GVL_Graficos.arrVarX[di]; //Valor forca final para calculo  //99.934
                            rTempoFinalGradiente = _modelGVL.GVL_Graficos.arrVarTimeStamp[di]; //Valor to tempo em ms final para calculo //22.74662

                            break; //Encerra a busca pela forca final
                        }
                    }

                    //var idxDownForce = lstInputForce1.FindIndex(v => v <= 100 &&);//Forca proxima de 0 (<=100N)
                    //rForcaFinalGradiente = lstInputForce1.ElementAt(idxDownForce); //Valor forca final para calculo 
                    //rTempoFinalGradiente = lstTime.ElementAt(idxDownForce); //Valor to tempo em ms final para calculo

                    //Define a forca inicial e o tempo inicial do gradiente como a FMAX obtida no calculo anterior, utilizando seu indice para coletar o tempo respectivo
                    rForcaInicialGradiente = _modelGVL.GVL_Graficos.arrVarX[_modelGVL.GVL_T01.diPosicaoForcaMaxima]; //1240.597
                    rTempoInicialGradiente = _modelGVL.GVL_Graficos.arrVarTimeStamp[_modelGVL.GVL_T01.diPosicaoForcaMaxima]; //14.36238


                    //Calcula o gradiente de aplicacao de forca no retorno
                    _modelGVL.GVL_T01.rGradienteForcaRetorno = Math.Round((rForcaFinalGradiente - rForcaInicialGradiente) / (rTempoFinalGradiente - rTempoInicialGradiente), 2); //	-1140.663 / 8.38424	= -136.05

                    //========================================================================================================================================================
                    #endregion

                    #region Calculo do gradiente de avanço 
                    //========================================================================================================================================================

                    //Busca no array o momento em que o deslocamento comecou a variar (deslocamento >= 1)
                    for (di = 0; di <= _modelGVL.GVL_T01.diPosicaoForcaMaxima; di++)
                    {
                        if (_modelGVL.GVL_Graficos.arrVarY3[di] >= 1) //Deslocamento >= 1mm
                        {
                            rDeslocamentoInicialGradiente = _modelGVL.GVL_Graficos.arrVarY3[di]; //Valor deslocamento inicial para calculo  //1
                            rTempoInicialGradiente = _modelGVL.GVL_Graficos.arrVarTimeStamp[di]; //Valor to tempo em ms inicial para calculo //6.46803

                            break; //Encerra a busca pelo deslocamento inicial
                        }
                    }

                    //Define a forca final e o tempo final do gradiente como a FMAX obtida no calculo anterior, utilizando seu indice para coletar o tempo respectivo
                    rDeslocamentoFinalGradiente = _modelGVL.GVL_Graficos.arrVarY3[_modelGVL.GVL_T01.diPosicaoForcaMaxima]; //13.01
                    rTempoFinalGradiente = _modelGVL.GVL_Graficos.arrVarTimeStamp[_modelGVL.GVL_T01.diPosicaoForcaMaxima]; //14.36238

                    //Calcula o gradiente de aplicacao de forca no avanco
                    _modelGVL.GVL_T01.rGradienteDeslocamentoAvanco = (rDeslocamentoFinalGradiente - rDeslocamentoInicialGradiente) / (rTempoFinalGradiente - rTempoInicialGradiente); //12.01 / 7.89435	= 1.5213412123860735

                    //========================================================================================================================================================

                    #endregion

                    #region Calculo do gradiente de deslocamento no retorno

                    //========================================================================================================================================================

                    //Busca no array o momento em que o deslocamento <= 1
                    for (di = _modelGVL.GVL_T01.diPosicaoForcaMaxima; di < diUbound; di++)
                    {
                        if (_modelGVL.GVL_Graficos.arrVarY3[di] <= 1) //Deslocamento <= 1
                        {
                            rDeslocamentoFinalGradiente = _modelGVL.GVL_Graficos.arrVarY3[di]; //Deslocamento final para calculo //1
                            rTempoFinalGradiente = _modelGVL.GVL_Graficos.arrVarTimeStamp[di]; //Valor to tempo em ms final para calculo //24.10504

                            break; //Encerra a busca pelo deslocamento final
                        }
                    }


                    //Define o deslocamento inicial e o tempo inicial do gradiente como a FMAX obtida no calculo anterior, utilizando seu indice para coletar o tempo respectivo
                    rDeslocamentoInicialGradiente = _modelGVL.GVL_Graficos.arrVarY3[_modelGVL.GVL_T01.diPosicaoForcaMaxima]; //13.01
                    rTempoInicialGradiente = _modelGVL.GVL_Graficos.arrVarTimeStamp[_modelGVL.GVL_T01.diPosicaoForcaMaxima]; //14.36238

                    //Calcula o gradiente de aplicacao de forca no retorno
                    _modelGVL.GVL_T01.rGradienteDeslocamentoRetorno = (rDeslocamentoFinalGradiente - rDeslocamentoInicialGradiente) / (rTempoFinalGradiente - rTempoInicialGradiente); //-12.01 / 9.742659999999999	= 1.2327228908737451

                    //========================================================================================================================================================

                    #endregion

                    #region Pega os valores de pressão no cruzamento com as forças solicitadas: P1

                    //========================================================================================================================================================
                    for (di = 0; di < diUbound; di++)
                    {
                        if (_modelGVL.GVL_Graficos.arrVarX[di] >= _modelGVL.GVL_T01.rForca_P1) //Encontrou a forca >= parametro definido
                        {
                            _modelGVL.GVL_T01.rForcaReal_P1_N = _modelGVL.GVL_Graficos.arrVarX[di]; //Armazena o valor real encontrado (>=) //0.29
                            _modelGVL.GVL_T01.rPressao_P1_Bar = _modelGVL.GVL_Graficos.arrVarY1[di]; //Armazena a pressao correspondente encontrada //0

                            break; //Encerra a busca
                        }
                    }

                    #region Gera o ponto (X) no grafico

                    //pointArr = 0;
                    //pointPos = 6;
                    //pointName = "P1";

                    //_modelGVL.GVL_Graficos.arrVarXPoint1[pointArr] = _modelGVL.GVL_T01.rForcaReal_P1_N;
                    //_modelGVL.GVL_Graficos.arrVarYPoint1[pointArr] = _modelGVL.GVL_T01.rPressao_P1_Bar;

                    ////Marcacoes no Grafico
                    //_modelGVL.GVL_Graficos.lstMarkedPoint_Name[pointPos] = pointName;
                    //_modelGVL.GVL_Graficos.lstMarkedPoint_X[pointPos] = _modelGVL.GVL_Graficos.arrVarXPoint1[pointArr];
                    //_modelGVL.GVL_Graficos.lstMarkedPoint_Y[pointPos] = _modelGVL.GVL_Graficos.arrVarYPoint1[pointArr];
                    //_modelGVL.GVL_Graficos.dictXMarkedPoint.Add($"PX{pointPos}_{pointName}", _modelGVL.GVL_Graficos.arrVarXPoint1[pointArr]);
                    //_modelGVL.GVL_Graficos.dictYMarkedPoint.Add($"PY{pointPos}_{pointName}", _modelGVL.GVL_Graficos.arrVarYPoint1[pointArr]);

                    #endregion

                    #endregion

                    #region Pega os valores de pressão no cruzamento com as forças solicitadas: P2

                    for (di = 0; di < diUbound; di++)
                    {
                        if (_modelGVL.GVL_Graficos.arrVarX[di] >= _modelGVL.GVL_T01.rForca_P2) //Encontrou a forca >= parametro definido
                        {
                            _modelGVL.GVL_T01.rForcaReal_P2_N = _modelGVL.GVL_Graficos.arrVarX[di]; //Armazena o valor real encontrado (>=)
                            _modelGVL.GVL_T01.rPressao_P2_Bar = _modelGVL.GVL_Graficos.arrVarY1[di]; //Armazena a pressao correspondente encontrada

                            diIndice_P2 = di; //Armazena o Indice de P2 para o calculo posterior, runoutpoint

                            break; //Encerra a busca
                        }
                    }

                    #region Gera o ponto (X) no grafico

                    //pointArr = 1;
                    //pointPos = 7;
                    //pointName = "P2";

                    //_modelGVL.GVL_Graficos.arrVarXPoint1[pointArr] = _modelGVL.GVL_T01.rForcaReal_P2_N;
                    //_modelGVL.GVL_Graficos.arrVarYPoint1[pointArr] = _modelGVL.GVL_T01.rPressao_P2_Bar;

                    ////Marcacoes no Grafico
                    //_modelGVL.GVL_Graficos.lstMarkedPoint_Name[pointPos] = pointName;
                    //_modelGVL.GVL_Graficos.lstMarkedPoint_X[pointPos] = _modelGVL.GVL_Graficos.arrVarXPoint1[pointArr];
                    //_modelGVL.GVL_Graficos.lstMarkedPoint_Y[pointPos] = _modelGVL.GVL_Graficos.arrVarYPoint1[pointArr];
                    //_modelGVL.GVL_Graficos.dictXMarkedPoint.Add($"PX{pointPos}_{pointName}", _modelGVL.GVL_Graficos.arrVarXPoint1[pointArr]);
                    //_modelGVL.GVL_Graficos.dictYMarkedPoint.Add($"PY{pointPos}_{pointName}", _modelGVL.GVL_Graficos.arrVarYPoint1[pointArr]);

                    #endregion

                    #endregion

                    #region Pega os valores de pressão no cruzamento com as forças solicitadas: E1

                    for (di = 0; di < diUbound; di++)
                    {
                        if (_modelGVL.GVL_Graficos.arrVarX[di] >= _modelGVL.GVL_T01.rForca_E1) //Encontrou a forca >= parametro definido
                        {
                            _modelGVL.GVL_T01.rForcaReal_E1_N = _modelGVL.GVL_Graficos.arrVarX[di]; //Armazena o valor real encontrado (>=)
                            _modelGVL.GVL_T01.rPressao_E1_Bar = _modelGVL.GVL_Graficos.arrVarY1[di]; //Armazena a pressao correspondente encontrada

                            break; //Encerra a busca
                        }
                    }

                    #region Gera o ponto (X) no grafico

                    //pointArr = 2;
                    //pointPos = 1;
                    //pointName = "E1";

                    //_modelGVL.GVL_Graficos.arrVarXPoint1[pointArr] = _modelGVL.GVL_T01.rForcaReal_E1_N;
                    //_modelGVL.GVL_Graficos.arrVarYPoint1[pointArr] = _modelGVL.GVL_T01.rPressao_E1_Bar;

                    ////Marcacoes no Grafico
                    //_modelGVL.GVL_Graficos.lstMarkedPoint_Name[pointPos] = pointName;
                    //_modelGVL.GVL_Graficos.lstMarkedPoint_X[pointPos] = _modelGVL.GVL_Graficos.arrVarXPoint1[pointArr];
                    //_modelGVL.GVL_Graficos.lstMarkedPoint_Y[pointPos] = _modelGVL.GVL_Graficos.arrVarYPoint1[pointArr];
                    //_modelGVL.GVL_Graficos.dictXMarkedPoint.Add($"PX{pointPos}_{pointName}", _modelGVL.GVL_Graficos.arrVarXPoint1[pointArr]);
                    //_modelGVL.GVL_Graficos.dictYMarkedPoint.Add($"PY{pointPos}_{pointName}", _modelGVL.GVL_Graficos.arrVarYPoint1[pointArr]);

                    #endregion

                    #endregion

                    #region Pega os valores de pressão no cruzamento com as forças solicitadas: E2

                    for (di = 0; di < diUbound; di++)
                    {
                        if (_modelGVL.GVL_Graficos.arrVarX[di] >= _modelGVL.GVL_T01.rForca_E2) //Encontrou a forca >= parametro definido
                        {
                            _modelGVL.GVL_T01.rForcaReal_E2_N = _modelGVL.GVL_Graficos.arrVarX[di]; //Armazena o valor real encontrado (>=)
                            _modelGVL.GVL_T01.rPressao_E2_Bar = _modelGVL.GVL_Graficos.arrVarY1[di]; //Armazena a pressao correspondente encontrada

                            break; //Encerra a busca
                        }
                    }

                    #region Gera o ponto (X) no grafico

                    //pointArr = 3;
                    //pointPos = 4;
                    //pointName = "E2";

                    //_modelGVL.GVL_Graficos.arrVarXPoint1[pointArr] = _modelGVL.GVL_T01.rForcaReal_E2_N;
                    //_modelGVL.GVL_Graficos.arrVarYPoint1[pointArr] = _modelGVL.GVL_T01.rPressao_E2_Bar;

                    ////Marcacoes no Grafico
                    //_modelGVL.GVL_Graficos.lstMarkedPoint_Name[pointPos] = pointName;
                    //_modelGVL.GVL_Graficos.lstMarkedPoint_X[pointPos] = _modelGVL.GVL_Graficos.arrVarXPoint1[pointArr];
                    //_modelGVL.GVL_Graficos.lstMarkedPoint_Y[pointPos] = _modelGVL.GVL_Graficos.arrVarYPoint1[pointArr];
                    //_modelGVL.GVL_Graficos.dictXMarkedPoint.Add($"PX{pointPos}_{pointName}", _modelGVL.GVL_Graficos.arrVarXPoint1[pointArr]);
                    //_modelGVL.GVL_Graficos.dictYMarkedPoint.Add($"PY{pointPos}_{pointName}", _modelGVL.GVL_Graficos.arrVarYPoint1[pointArr]);

                    //========================================================================================================================================================

                    #endregion

                    #endregion

                    #region Calculo do runout point por intersecção linear (cruzamento das retas 1 (amplificação) e 2 (saturação)
                    //========================================================================================================================================================

                    //Reta 1 tambem chamada de L1
                    // Y = m.X + n onde:
                    // Y/X pontos na curva
                    // m - coeficiente angular da reta
                    // n - coeficiente linear da reta
                    //m pode ser calculado pela variacao entre 2 pontos (y2-y1)/(x2-x1)

                    //Retal L1
                    //Define o coeficiente angular e linear da reta 1 (amplificacao)
                    rCoeficienteAngular_L1 = (_modelGVL.GVL_T01.rPressao_E2_Bar - _modelGVL.GVL_T01.rPressao_E1_Bar) / (_modelGVL.GVL_T01.rForcaReal_E2_N - _modelGVL.GVL_T01.rForcaReal_E1_N);
                    rCoeficienteLinear_L1 = _modelGVL.GVL_T01.rPressao_E1_Bar - (rCoeficienteAngular_L1 * _modelGVL.GVL_T01.rForcaReal_E1_N); //(Y = m.X + n) > n = Y-(m.X)

                    //Retal L2
                    //Define o coeficiente angular e linear da reta 2 (saturacao)
                    rCoeficienteAngular_L2 = (_modelGVL.GVL_T01.rPressao_P2_Bar - _modelGVL.GVL_T01.rPressao_P1_Bar) / (_modelGVL.GVL_T01.rForcaReal_P2_N - _modelGVL.GVL_T01.rForcaReal_P1_N);
                    rCoeficienteLinear_L2 = _modelGVL.GVL_T01.rPressao_P1_Bar - (rCoeficienteAngular_L2 * _modelGVL.GVL_T01.rForcaReal_P1_N); //(Y = m.X + n) > n = Y-(m.X)

                    //Cruzamento das retas para calculo das coordenadas de runoutForce e runoutPressure por instersecção linear

                    _modelGVL.GVL_T01.rRunOutForce_LinearInt_N = ((rCoeficienteLinear_L1 - rCoeficienteLinear_L2) / (rCoeficienteAngular_L1 - rCoeficienteAngular_L2)) * -1;
                    _modelGVL.GVL_T01.rRunOutPressure_LinearInt_Bar = (rCoeficienteAngular_L1 * _modelGVL.GVL_T01.rRunOutForce_LinearInt_N) + rCoeficienteLinear_L1;
                    //========================================================================================================================================================
                    #endregion

                    #region Calculo do auxiliary pressure P3, pressao auxiliar para calculo do runout point real (vide norma continental)
                    //========================================================================================================================================================

                    //Pressao auxiliar P3 eh o rebatimento da linha L2 (reta de saturacao) aonde o valor de forca (eixo x) = 0, ou seja, P3=Coeficiente Linear de L2
                    _modelGVL.GVL_T01.rPressaoAuxiliar_P3_Bar = rCoeficienteLinear_L2;
                    //A pressao P4 é o rebatimento da forca p3 no grafico, porem com o valor de um ponto real o mais proximo possivel do valor p3.
                    //Busca no array o valor mais proximo da pressao p3 para obter a pressao real p4 e a forca p4
                    for (di = 0; di <= _modelGVL.GVL_T01.diPosicaoForcaMaxima; di++)
                    {
                        if (_modelGVL.GVL_Graficos.arrVarY1[di] >= _modelGVL.GVL_T01.rPressaoAuxiliar_P3_Bar) //Pressao no array >= Pressao auxiliar P3
                        {
                            _modelGVL.GVL_T01.rPressao_P4_Bar = _modelGVL.GVL_Graficos.arrVarY1[di]; //Valor da pressao real obtida no grafico valida para P3 
                            _modelGVL.GVL_T01.rForca_P4_N = _modelGVL.GVL_Graficos.arrVarX[di]; //Valor da forca no ponto de pressao real P4

                            diIndice_P4 = di; //Memoriza o indice do parametro P4 para o calculo de distancia do ponto (runout, proximo calculo)

                            break; //Encerra a busca
                        }
                    }

                    //========================================================================================================================================================

                    #endregion

                    #region Calculo da reta auxiliar L3, utilizada para identificar o ponto mais distante (runoutpoint)

                    //========================================================================================================================================================
                    // Y = m.X + n onde:
                    // Y/X pontos na curva
                    // m - coeficiente angular da reta
                    // n - coeficiente linear da reta
                    //m pode ser calculado pela variacao entre 2 pontos (y2-y1)/(x2-x1)

                    //Reta L3 - entre o ponto P2 e o Ponto P4
                    //Define o coeficiente angular e linear da reta 3 (reta auxiliar)
                    rCoeficienteAngular_L3 = (_modelGVL.GVL_T01.rPressao_P2_Bar - _modelGVL.GVL_T01.rPressao_P4_Bar) / (_modelGVL.GVL_T01.rForcaReal_P2_N - _modelGVL.GVL_T01.rForca_P4_N);
                    rCoeficienteLinear_L3 = _modelGVL.GVL_T01.rPressao_P2_Bar - (rCoeficienteAngular_L3 * _modelGVL.GVL_T01.rForcaReal_P2_N); //(Y = m.X + n) > n = Y-(m.X)

                    //Medicao da distancia perpendicular de todos os pontos, partindo das coordenadas de P4 ate P2, para identificar o ponto mais distante (runoutpoint).
                    //Formula da geometria analitica para encontrar a distancia entre o ponto e a reta:
                    //Primeiro, encontrar a equacao da reta e localizar os pontos a, b e c onde
                    // eq da reta ||aX + bY + c = 0
                    //DistanciaAB = | aX + bY + c |
                    //				|-------------|
                    //				|   √(a²+b²)  |

                    rA_L3 = rCoeficienteAngular_L3 * -1;
                    rB_L3 = 1;
                    rC_L3 = (rCoeficienteAngular_L3 * _modelGVL.GVL_T01.rForca_P4_N) - _modelGVL.GVL_T01.rPressao_P4_Bar;

                    rRaizAB = Math.Sqrt((rA_L3 * rA_L3) + (rB_L3 * rB_L3));

                    for (di = diIndice_P4; di <= diIndice_P2; di++)
                    {
                        rCoordX = _modelGVL.GVL_Graficos.arrVarX[di]; //Valor do Ponto na coordenada X
                        rCoordY = _modelGVL.GVL_Graficos.arrVarY1[di]; //Valor do ponto na coordenada Y

                        rResulTemp = ((rCoordX * rA_L3) + (rCoordY * rB_L3) + rC_L3) / rRaizAB;

                        //arResultados[di - diIndice_P4] = rResulTemp;

                        if (rResulTemp > rMaiorDistancia) //Pressao no array >= Pressao auxiliar P3
                        {
                            rMaiorDistancia = rResulTemp;
                            _modelGVL.GVL_T01.rRunOutForce_Real_N = _modelGVL.GVL_Graficos.arrVarX[di];
                            _modelGVL.GVL_T01.rRunOutPressure_Real_Bar = _modelGVL.GVL_Graficos.arrVarY1[di];
                        }
                    }

                    #region Gera o ponto (X) no grafico

                    //pointArr = 4;
                    //pointPos = 5;
                    //pointName = _modelGVL.GVL_T01.bRunOutTeorico ? "RunOut-Teorico" : "RunOut-Real";

                    //if (!_modelGVL.GVL_T01.bRunOutTeorico)
                    //{
                    //    _modelGVL.GVL_Graficos.arrVarXPoint1[pointArr] = _modelGVL.GVL_T01.rRunOutForce_Real_N;
                    //    _modelGVL.GVL_Graficos.arrVarYPoint1[pointArr] = _modelGVL.GVL_T01.rRunOutPressure_Real_Bar;
                    //}
                    //else
                    //{
                    //    _modelGVL.GVL_Graficos.arrVarXPoint1[pointArr] = _modelGVL.GVL_T01.rRunOutForce_LinearInt_N;
                    //    _modelGVL.GVL_Graficos.arrVarYPoint1[pointArr] = _modelGVL.GVL_T01.rRunOutPressure_LinearInt_Bar;
                    //}

                    ////Marcacoes no Grafico
                    //_modelGVL.GVL_Graficos.lstMarkedPoint_Name[pointPos] = pointName;
                    //_modelGVL.GVL_Graficos.lstMarkedPoint_X[pointPos] = _modelGVL.GVL_Graficos.arrVarXPoint1[pointArr];
                    //_modelGVL.GVL_Graficos.lstMarkedPoint_Y[pointPos] = _modelGVL.GVL_Graficos.arrVarYPoint1[pointArr];
                    //_modelGVL.GVL_Graficos.dictXMarkedPoint.Add($"PX{pointPos}_{pointName}", _modelGVL.GVL_Graficos.arrVarXPoint1[pointArr]);
                    //_modelGVL.GVL_Graficos.dictYMarkedPoint.Add($"PY{pointPos}_{pointName}", _modelGVL.GVL_Graficos.arrVarYPoint1[pointArr]);

                    #endregion

                    //========================================================================================================================================================

                    #endregion

                    #region Calcula a forca a 70%pout e encontra um ponto real no grafico

                    //========================================================================================================================================================

                    for (di = 0; di <= _modelGVL.GVL_T01.diPosicaoForcaMaxima; di++)
                    {
                        if (_modelGVL.GVL_Graficos.arrVarY1[di] >= (_modelGVL.GVL_T01.rRunOutPressure_Real_Bar * 0.7)) //Pressao no array >= (Pressao runout *0.7)
                        {
                            _modelGVL.GVL_T01.rPressao_70pout_bar = _modelGVL.GVL_Graficos.arrVarY1[di]; //Valor da pressao real obtida no grafico valida para 70% runout 
                            _modelGVL.GVL_T01.rForca_70pout_N = _modelGVL.GVL_Graficos.arrVarX[di]; //Valor da forca real obtida no grafico valida para 70% runout (apnas exibe)
                            diIndice_p70 = di; //Memoriza o indice do parametro

                            break; //Encerra a busca
                        }
                    }

                    //========================================================================================================================================================
                    #endregion

                    #region Calcula a forca a 90%pout e encontra um ponto real no grafico

                    //========================================================================================================================================================
                    //tambem salva o deslocamento a 90% do runout, aproveitando o loop de busca
                    _modelGVL.GVL_T01.rPressao_90pout_bar = _modelGVL.GVL_T01.rRunOutPressure_Real_Bar * 0.9; //Calcula a pressao teorica 90%pout

                    for (di = 0; di <= _modelGVL.GVL_T01.diPosicaoForcaMaxima; di++)
                    {
                        if (_modelGVL.GVL_Graficos.arrVarY1[di] >= _modelGVL.GVL_T01.rPressao_90pout_bar)  //Pressao no array >= Pressao RUnout * 0.9
                        {
                            _modelGVL.GVL_T01.rPressao_90pout_bar = _modelGVL.GVL_Graficos.arrVarY1[di]; //Valor da pressao real obtida no grafico valida para 90 runout 
                            _modelGVL.GVL_T01.rDeslocamento_90pout_mm = _modelGVL.GVL_Graficos.arrVarY3[di]; //Valor de deslocamento a 90% pout
                            _modelGVL.GVL_T01.rForca_90pout_N = _modelGVL.GVL_Graficos.arrVarX[di]; //Valor da Forca relacionada a pressao 90% pout
                            _modelGVL.GVL_T01.rForca_F6_N = _modelGVL.GVL_Graficos.arrVarX[di]; //Valor da Forca relacionada a pressao 90% pout
                            _modelGVL.GVL_T01.rPressao_P6_Bar = _modelGVL.GVL_Graficos.arrVarY1[di];
                            diIndice_p90 = di; //Memoriza o indice do parametro 

                            break; //Encerra a busca
                        }
                    }

                    //========================================================================================================================================================
                    #endregion

                    #region Obtem valor de deslocamento em funcao do parametro DeslocamentoNaPressao (%Pout)

                    //========================================================================================================================================================

                    for (di = 0; di <= _modelGVL.GVL_T01.diPosicaoForcaMaxima; di++)
                    {
                        if (_modelGVL.GVL_Graficos.arrVarY1[di] >= ((_modelGVL.GVL_T01.rDeslocamentoNaPressao / 100) * _modelGVL.GVL_T01.rRunOutPressure_Real_Bar))  //Valor do deslocamento obtido na pressao definida
                        {
                            _modelGVL.GVL_T01.rDeslocamentoNaPressao_mm = _modelGVL.GVL_Graficos.arrVarY3[di]; //Valor do deslocamento obtido na pressao definida

                            break; //Encerra a busca
                        }
                    }

                    //========================================================================================================================================================

                    #endregion

                    #region Calcula a forca Cut IN

                    //========================================================================================================================================================

                    for (di = 0; di <= _modelGVL.GVL_T01.diPosicaoForcaMaxima; di++)
                    {
                        if (_modelGVL.GVL_Graficos.arrVarY1[di] >= _modelGVL.GVL_T01.rPressaoCutIn_Bar)  //Pressao de cut in
                        {
                            _modelGVL.GVL_T01.rForcaCutIn_N = _modelGVL.GVL_Graficos.arrVarX[di]; //Valor da forca obtida na pressao de cut in

                            break; //Encerra a busca
                        }
                    }

                    //========================================================================================================================================================

                    #endregion

                    #region Calculo do Jumper

                    //========================================================================================================================================================
                    //Formula na norma - Pjumper = P5 + (Fcutin - Fe200)*((P6-P5)/(F6-FE200))
                    //P6 = pressao runout * 0.9, obtido anteriormente
                    //F6 = Forca correspondente a P6, obtido anteriormente
                    //FE200 = 200N, esta na norma, so muda se for especificado "The point P5 is calculated with an input force of FE200 = 200N, unless otherwise specified"
                    //FAN=Fcutin

                    //Encontra a pressao P5, que corresponde na tabela de dados a forca = 200N

                    for (di = 0; di <= _modelGVL.GVL_T01.diPosicaoForcaMaxima; di++)
                    {
                        if (_modelGVL.GVL_Graficos.arrVarX[di] >= 200) //Pressao de cut in.
                        {
                            _modelGVL.GVL_T01.rPressao_P5_Bar = _modelGVL.GVL_Graficos.arrVarY1[di]; //Valor da pressao correspondente a uma forca 200N

                            break; //Encerra a busca
                        }
                    }

                    _modelGVL.GVL_T01.rPressaoJumper_Bar = _modelGVL.GVL_T01.rPressao_P5_Bar + (_modelGVL.GVL_T01.rForcaCutIn_N - 200) *
                                                            ((_modelGVL.GVL_T01.rPressao_P6_Bar - _modelGVL.GVL_T01.rPressao_P5_Bar) / (_modelGVL.GVL_T01.rForca_F6_N - 200));

                    _modelGVL.GVL_Graficos.arrVarXPoint1[5] = _modelGVL.GVL_T01.rForcaCutIn_N;
                    _modelGVL.GVL_Graficos.arrVarYPoint1[5] = _modelGVL.GVL_T01.rPressaoJumper_Bar;

                    //========================================================================================================================================================

                    #endregion

                    #region Jumper Gradient

                    //========================================================================================================================================================

                    //Obtem a pressão e forca no ponto definido nos parametros

                    //        FOR di := 0 TO GVL_T01.diPosicaoForcaMaxima DO //Pressao >= parametro Jumper P1
                    //            IF GVL_Graficos.arrVarY1[di] >= GVL_T01.rGradienteJumper_P1_Bar THEN //Pressao no array  >= pressao P1 Jumper
                    //                GVL_T01.rPressaoP1Jumper_Bar  := GVL_Graficos.arrVarY1[di]; //Valor da pressao real de jumper P1
                    //        GVL_T01.rForcaP1Jumper_N  := GVL_Graficos.arrVarX[di]; //Valor da forca real de jumper P1
                    //        EXIT; //Encerra a busca
                    //        END_IF
                    //END_FOR

                    //                //Obtem a pressão e forca no ponto definido nos parametros
                    //        FOR di := 0 TO GVL_T01.diPosicaoForcaMaxima DO //Pressao >= parametro Jumper P1
                    //            IF GVL_Graficos.arrVarY1[di] >= GVL_T01.rGradienteJumper_P2_Bar THEN //Pressao no array  >= pressao P1 Jumper
                    //                GVL_T01.rPressaoP2Jumper_Bar  := GVL_Graficos.arrVarY1[di]; //Valor da pressao real de jumper P1
                    //        GVL_T01.rForcaP2Jumper_N  := GVL_Graficos.arrVarX[di]; //Valor da forca real de jumper P1
                    //        EXIT; //Encerra a busca
                    //        END_IF
                    //END_FOR

                    //        GVL_T01.rGradientJumper := (GVL_T01.rForcaP2Jumper_N - GVL_T01.rForcaP1Jumper_N) / (GVL_T01.rPressaoP2Jumper_Bar - GVL_T01.rPressaoP1Jumper_Bar);


                    //Obtem a pressão e forca no ponto definido nos parametros
                    for (di = 0; di <= _modelGVL.GVL_T01.diPosicaoForcaMaxima; di++)
                    {
                        if (_modelGVL.GVL_Graficos.arrVarY1[di] >= _modelGVL.GVL_T01.rGradienteJumper_P1_Bar) //Pressao no array  >= pressao P1 Jumper
                        {
                            _modelGVL.GVL_T01.rPressaoP1Jumper_Bar = _modelGVL.GVL_Graficos.arrVarY1[di]; //Valor da pressao real de jumper P1
                            _modelGVL.GVL_T01.rForcaP1Jumper_N = _modelGVL.GVL_Graficos.arrVarX[di]; //Valor da forca real de jumper P1

                            break; //Encerra a busca
                        }
                    }

                    //Obtem a pressão e forca no ponto definido nos parametros
                    for (di = 0; di <= _modelGVL.GVL_T01.diPosicaoForcaMaxima; di++)
                    {
                        if (_modelGVL.GVL_Graficos.arrVarY1[di] >= _modelGVL.GVL_T01.rGradienteJumper_P2_Bar) //Pressao no array  >= pressao P2 Jumper
                        {
                            _modelGVL.GVL_T01.rPressaoP2Jumper_Bar = _modelGVL.GVL_Graficos.arrVarY1[di]; //Valor da pressao real de jumper P2
                            _modelGVL.GVL_T01.rForcaP2Jumper_N = _modelGVL.GVL_Graficos.arrVarX[di]; //Valor da forca real de jumper P2

                            break; //Encerra a busca
                        }
                    }

                    //     //Calcula o gradiente de Jumper (N/bar)
                    _modelGVL.GVL_T01.rGradientJumper = (_modelGVL.GVL_T01.rForcaP2Jumper_N - _modelGVL.GVL_T01.rForcaP1Jumper_N) / (_modelGVL.GVL_T01.rPressaoP2Jumper_Bar - _modelGVL.GVL_T01.rPressaoP1Jumper_Bar);

                    #region Gera o ponto (X) no grafico

                    //pointArr = 0;
                    //pointPos = 10;
                    //pointName = "Jumper Gradient";

                    //////Marcacoes no Grafico
                    //_modelGVL.GVL_Graficos.lstMarkedPoint_Name[pointPos] = pointName;
                    //_modelGVL.GVL_Graficos.lstMarkedPoint_X[pointPos] = pointArr;
                    //_modelGVL.GVL_Graficos.lstMarkedPoint_Y[pointPos] = pointArr;
                    //_modelGVL.GVL_Graficos.dictXMarkedPoint.Add($"PX{pointPos}_{pointName}", pointArr);
                    //_modelGVL.GVL_Graficos.dictYMarkedPoint.Add($"PY{pointPos}_{pointName}", pointArr);

                    #endregion

                    //========================================================================================================================================================

                    #endregion

                    #region Calcula a release force

                    //========================================================================================================================================================
                    //Release force é o pico de força no retorno encontrado na tabela de pontos, entre os parametros release force min/ release force max.

                    //Encontra o indice do release force max (como é decrescente, max primeiro, min depois na tabela)
                    for (di = _modelGVL.GVL_T01.diPosicaoForcaMaxima; di < diUbound; di++)
                    {
                        if (_modelGVL.GVL_Graficos.arrVarY1[di] <= _modelGVL.GVL_T01.rReleaseForcePressMax_Bar)
                        {
                            diIndice_ReleaseMax = di; //Indice aonde esta a pressao maxima para avaliar o pico de forca no retorno 

                            break; //Encerra a busca
                        }
                    }

                    //Encontra o indice do release force min (como é decrescente, max primeiro, min depois na tabela)
                    for (di = diIndice_ReleaseMax; di < diUbound; di++)
                    {
                        if (_modelGVL.GVL_Graficos.arrVarY1[di] <= _modelGVL.GVL_T01.rReleaseForcePressMin_Bar)
                        {
                            diIndice_ReleaseMin = di; //Indice aonde esta a pressao minima para avaliar o pico de forca no retorno 

                            break; //Encerra a busca
                        }
                    }


                    //Encontra o pico de forca entre Max e Min
                    for (di = diIndice_ReleaseMax; di <= diIndice_ReleaseMin; di++)
                    {
                        if (_modelGVL.GVL_Graficos.arrVarX[di] > _modelGVL.GVL_T01.rReleaseForce_N)
                        {
                            _modelGVL.GVL_T01.rReleaseForce_N = _modelGVL.GVL_Graficos.arrVarX[di]; //Pico de forca entre as pressoes definidas no retorno                     
                        }
                    }

                    double ReleaseTravel = 0;

                    //Encontra o pico de forca no deslocamento de retorno definido
                    for (di = _modelGVL.GVL_T01.diPosicaoForcaMaxima; di < diUbound; di++)
                    {
                        ReleaseTravel = Math.Round(_modelGVL.GVL_Graficos.arrVarY3[di], 1);

                        if (ReleaseTravel <= _modelGVL.GVL_T01.rReleaseForceAt_mm) // Deslocamento no ponto <= o valor definido no parametro
                        {
                            _modelGVL.GVL_T01.rReleaseForceAt_N = _modelGVL.GVL_Graficos.arrVarX[di]; //Forca Obtida no ponto de retorno
                            _modelGVL.GVL_T01.rReleaseForceAtReal_mm = _modelGVL.GVL_Graficos.arrVarY3[di]; //Valor de deslocamento real obtido

                            break; //Encerra a busca
                        }
                    }

                    //========================================================================================================================================================

                    #endregion

                    #region Calcula a hysterese (diferenca de forca na ida e na volta, com pontos de pressao iguais

                    //========================================================================================================================================================

                    _modelGVL.GVL_T01.rPressaoHysteresePout_Bar = _modelGVL.GVL_T01.rRunOutPressure_Real_Bar * (_modelGVL.GVL_T01.rPressaoHysterese_pout / 100);

                    //Obtem a forca relacionada a pressao x% pout no avanco
                    for (di = 0; di <= _modelGVL.GVL_T01.diPosicaoForcaMaxima; di++)
                    {
                        if (_modelGVL.GVL_Graficos.arrVarY1[di] >= _modelGVL.GVL_T01.rPressaoHysteresePout_Bar)//Pressao no array >= Pressao Runout * x%
                        {
                            _modelGVL.GVL_T01.rForcaAvanco_Xpout_N = _modelGVL.GVL_Graficos.arrVarX[di]; //Valor da Forca relacionada a pressao x% pout no avanco

                            break; //Encerra a busca
                        }
                    }

                    #region Gera o ponto (X) no grafico

                    //pointArr = 6;
                    //pointPos = 2;
                    //pointName = "Hysterese50_Perc_Up";

                    //_modelGVL.GVL_Graficos.arrVarXPoint1[pointArr] = _modelGVL.GVL_T01.rForcaAvanco_Xpout_N;
                    //_modelGVL.GVL_Graficos.arrVarYPoint1[pointArr] = _modelGVL.GVL_T01.rPressaoHysteresePout_Bar;

                    ////Marcacoes no Grafico
                    //_modelGVL.GVL_Graficos.lstMarkedPoint_Name[pointPos] = pointName;
                    //_modelGVL.GVL_Graficos.lstMarkedPoint_X[pointPos] = _modelGVL.GVL_Graficos.arrVarXPoint1[pointArr];
                    //_modelGVL.GVL_Graficos.lstMarkedPoint_Y[pointPos] = _modelGVL.GVL_Graficos.arrVarYPoint1[pointArr];
                    //_modelGVL.GVL_Graficos.dictXMarkedPoint.Add($"PX{pointPos}_{pointName}", _modelGVL.GVL_Graficos.arrVarXPoint1[pointArr]);
                    //_modelGVL.GVL_Graficos.dictYMarkedPoint.Add($"PY{pointPos}_{pointName}", _modelGVL.GVL_Graficos.arrVarYPoint1[pointArr]);

                    #endregion

                    //Obtem a forca relacionada a pressao x% pout no retorno
                    for (di = _modelGVL.GVL_T01.diPosicaoForcaMaxima; di < diUbound; di++)
                    {
                        if (_modelGVL.GVL_Graficos.arrVarY1[di] <= _modelGVL.GVL_T01.rPressaoHysteresePout_Bar) //Pressao no array <= Pressao Runout * x%
                        {
                            _modelGVL.GVL_T01.rForcaRetorno_Xpout_N = _modelGVL.GVL_Graficos.arrVarX[di]; //Valor da Forca relacionada a pressao x% pout no retorno

                            break; //Encerra a busca
                        }
                    }

                    #region Gera o ponto (X) no grafico

                    //pointArr = 7;
                    //pointPos = 9;
                    //pointName = "Hysterese50_Perc_Down";

                    //_modelGVL.GVL_Graficos.arrVarXPoint1[pointArr] = _modelGVL.GVL_T01.rForcaRetorno_Xpout_N;
                    //_modelGVL.GVL_Graficos.arrVarYPoint1[pointArr] = _modelGVL.GVL_T01.rPressaoHysteresePout_Bar;

                    ////Marcacoes no Grafico
                    //_modelGVL.GVL_Graficos.lstMarkedPoint_Name[pointPos] = pointName;
                    //_modelGVL.GVL_Graficos.lstMarkedPoint_X[pointPos] = _modelGVL.GVL_Graficos.arrVarXPoint1[pointArr];
                    //_modelGVL.GVL_Graficos.lstMarkedPoint_Y[pointPos] = _modelGVL.GVL_Graficos.arrVarYPoint1[pointArr];
                    //_modelGVL.GVL_Graficos.dictXMarkedPoint.Add($"PX{pointPos}_{pointName}", _modelGVL.GVL_Graficos.arrVarXPoint1[pointArr]);
                    //_modelGVL.GVL_Graficos.dictYMarkedPoint.Add($"PY{pointPos}_{pointName}", _modelGVL.GVL_Graficos.arrVarYPoint1[pointArr]);

                    #endregion

                    ////Calculo do hysterese (diferenca de forca no avanco e no retorno, no mesmo ponto de pressao)
                    _modelGVL.GVL_T01.rHysterese_Xpout_N = _modelGVL.GVL_T01.rForcaAvanco_Xpout_N - _modelGVL.GVL_T01.rForcaRetorno_Xpout_N;

                    //Obtem a forca relacionada a pressao Xbar pout no avanco
                    for (di = 0; di <= _modelGVL.GVL_T01.diPosicaoForcaMaxima; di++)
                    {
                        if (_modelGVL.GVL_Graficos.arrVarY1[di] >= _modelGVL.GVL_T01.rPressaoHysterese_Bar) //Pressao no array >= xbar
                        {
                            _modelGVL.GVL_T01.rForcaAvanco_Xbar_N = _modelGVL.GVL_Graficos.arrVarX[di]; //Valor da Forca relacionada a pressao xbar no avanco

                            break; //Encerra a busca
                        }
                    }

                    #region Gera o ponto (X) no grafico

                    //pointArr = 8;
                    //pointPos = 3;
                    //pointName = "Hysterese50_Bar_Up";

                    //_modelGVL.GVL_Graficos.arrVarXPoint1[pointArr] = _modelGVL.GVL_T01.rForcaAvanco_Xbar_N;
                    //_modelGVL.GVL_Graficos.arrVarYPoint1[pointArr] = _modelGVL.GVL_T01.rPressaoHysterese_Bar;

                    ////Marcacoes no Grafico
                    //_modelGVL.GVL_Graficos.lstMarkedPoint_Name[pointPos] = pointName;
                    //_modelGVL.GVL_Graficos.lstMarkedPoint_X[pointPos] = _modelGVL.GVL_Graficos.arrVarXPoint1[pointArr];
                    //_modelGVL.GVL_Graficos.lstMarkedPoint_Y[pointPos] = _modelGVL.GVL_Graficos.arrVarYPoint1[pointArr];
                    //_modelGVL.GVL_Graficos.dictXMarkedPoint.Add($"PX{pointPos}_{pointName}", _modelGVL.GVL_Graficos.arrVarXPoint1[pointArr]);
                    //_modelGVL.GVL_Graficos.dictYMarkedPoint.Add($"PY{pointPos}_{pointName}", _modelGVL.GVL_Graficos.arrVarYPoint1[pointArr]);

                    #endregion

                    //Obtem a forca relacionada a pressao Xbar pout no retorno
                    for (di = _modelGVL.GVL_T01.diPosicaoForcaMaxima; di < diUbound; di++)
                    {
                        if (_modelGVL.GVL_Graficos.arrVarY1[di] <= _modelGVL.GVL_T01.rPressaoHysterese_Bar) //Pressao no array <= xbar
                        {
                            _modelGVL.GVL_T01.rForcaRetorno_Xbar_N = _modelGVL.GVL_Graficos.arrVarX[di]; //Valor da Forca relacionada a pressao xbar no retorno

                            break; //Encerra a busca
                        }
                    }

                    #region Gera o ponto (X) no grafico

                    //pointArr = 9;
                    //pointPos = 8;
                    //pointName = "Hysterese50_Bar_Down";

                    //_modelGVL.GVL_Graficos.arrVarXPoint1[pointArr] = _modelGVL.GVL_T01.rForcaRetorno_Xbar_N;
                    //_modelGVL.GVL_Graficos.arrVarYPoint1[pointArr] = _modelGVL.GVL_T01.rPressaoHysterese_Bar;

                    ////Marcacoes no Grafico
                    //_modelGVL.GVL_Graficos.lstMarkedPoint_Name[pointPos] = pointName;
                    //_modelGVL.GVL_Graficos.lstMarkedPoint_X[pointPos] = _modelGVL.GVL_Graficos.arrVarXPoint1[pointArr];
                    //_modelGVL.GVL_Graficos.lstMarkedPoint_Y[pointPos] = _modelGVL.GVL_Graficos.arrVarYPoint1[pointArr];
                    //_modelGVL.GVL_Graficos.dictXMarkedPoint.Add($"PX{pointPos}_{pointName}", _modelGVL.GVL_Graficos.arrVarXPoint1[pointArr]);
                    //_modelGVL.GVL_Graficos.dictYMarkedPoint.Add($"PY{pointPos}_{pointName}", _modelGVL.GVL_Graficos.arrVarYPoint1[pointArr]);

                    #endregion

                    //Calculo do hysterese (diferenca de forca no avanco e no retorno, no mesmo ponto de pressao)
                    _modelGVL.GVL_T01.rHysterese_Xbar_N = _modelGVL.GVL_T01.rForcaAvanco_Xbar_N - _modelGVL.GVL_T01.rForcaRetorno_Xbar_N;
                    //========================================================================================================================================================

                    #endregion

                    #region Calcula a taxa de amplificacao (ratio) do booster

                    //========================================================================================================================================================

                    //Formula conforma norma || ieff (ratio) = ((P6-P5)*(d^2)*pi)/((F6-FE200)*4)
                    //Obs 1 estamos usando o ponto E2, e nao P6 da norma, solicitacao da continental
                    //Obs 2 valor total dividido por 10 para converter de MPa para Bar...

                    _modelGVL.GVL_T01.rTaxaAmplificacao = ((((_modelGVL.GVL_T01.rPressao_E2_Bar - _modelGVL.GVL_T01.rPressao_P5_Bar) * (_modelGVL.GVL_T01.rDiametroCMD_mm * _modelGVL.GVL_T01.rDiametroCMD_mm) * 3.141516)) / ((_modelGVL.GVL_T01.rForca_E2 - 200) * 4)) / 10;

                    //========================================================================================================================================================

                    #endregion

                    #region Calculo dos Consumidores Utilizados

                    //========================================================================================================================================================

                    _modelGVL.GVL_T01.iConsumidoresCP = 0;
                    _modelGVL.GVL_T01.iConsumidoresCS = 0;

                    HelperTestBase.Model_GVL.GVL_Parametros.iTipoConsumidores = HelperMODBUS.CS_wTipoConsumidores;

                    if (HelperMODBUS.CS_wTipoConsumidores != 2)
                    {
                        _modelGVL.GVL_T01.iConsumidoresCP = 0;
                        _modelGVL.GVL_T01.iConsumidoresCS = 0;
                    }
                    else
                    {
                        //HelperMODBUS.CS_wStatusLiga17MangueirasCS 
                        if (HelperMODBUS.CS_wStatusLiga1MangueiraCP)
                            _modelGVL.GVL_T01.iConsumidoresCP = _modelGVL.GVL_T01.iConsumidoresCP + 1;

                        if (HelperMODBUS.CS_wStatusLiga2MangueirasCP)
                            _modelGVL.GVL_T01.iConsumidoresCP = _modelGVL.GVL_T01.iConsumidoresCP + 2;

                        if (HelperMODBUS.CS_wStatusLiga4MangueirasCP)
                            _modelGVL.GVL_T01.iConsumidoresCP = _modelGVL.GVL_T01.iConsumidoresCP + 4;

                        if (HelperMODBUS.CS_wStatusLiga8MangueirasCP)
                            _modelGVL.GVL_T01.iConsumidoresCP = _modelGVL.GVL_T01.iConsumidoresCP + 8;

                        if (HelperMODBUS.CS_wStatusLiga10MangueirasCP)
                            _modelGVL.GVL_T01.iConsumidoresCP = _modelGVL.GVL_T01.iConsumidoresCP + 10;

                        if (HelperMODBUS.CS_wStatusLiga17MangueirasCP)
                            _modelGVL.GVL_T01.iConsumidoresCP = _modelGVL.GVL_T01.iConsumidoresCP + 17;

                        if (HelperMODBUS.CS_wStatusLiga1MangueiraCS)
                            _modelGVL.GVL_T01.iConsumidoresCS = _modelGVL.GVL_T01.iConsumidoresCS + 1;

                        if (HelperMODBUS.CS_wStatusLiga2MangueirasCS)
                            _modelGVL.GVL_T01.iConsumidoresCS = _modelGVL.GVL_T01.iConsumidoresCS + 2;

                        if (HelperMODBUS.CS_wStatusLiga4MangueirasCS)
                            _modelGVL.GVL_T01.iConsumidoresCS = _modelGVL.GVL_T01.iConsumidoresCS + 4;

                        if (HelperMODBUS.CS_wStatusLiga8MangueirasCS)
                            _modelGVL.GVL_T01.iConsumidoresCS = _modelGVL.GVL_T01.iConsumidoresCS + 8;

                        if (HelperMODBUS.CS_wStatusLiga10MangueirasCS)
                            _modelGVL.GVL_T01.iConsumidoresCS = _modelGVL.GVL_T01.iConsumidoresCS + 10;

                        if (HelperMODBUS.CS_wStatusLiga17MangueirasCS)
                            _modelGVL.GVL_T01.iConsumidoresCS = _modelGVL.GVL_T01.iConsumidoresCS + 17;
                    }
                    //============================. ============================================================================================================================

                    #endregion

                    _modelGVL.GVL_T01.bCalculaResultados = false;

                    _modelGVL.GVL_Graficos.bDadosCalculados = true;
                }

                HelperTestBase.Model_GVL.helperTestBase_ModelGVL_Test = HelperTestBase.Model_GVL.GVL_T01;

                HelperTestBase.Model_GVL = _modelGVL;

                #endregion

            }
            catch (Exception ex)
            {
                var err = ex.Message;
                throw;
            }

            return _modelGVL;

            #endregion
        }

        #endregion

        #region T02 - Calculos Forca Forca - ET_ForceDiagrams_ForceForce_WithVacuum
        public Model_GVL CalcGraphT02_ET_ForceDiagrams_ForceForce_WithVacuum(bool bCalculaResultados, List<double>[] lstDblReturnReadFile)
        {
            #region PROGRAM T02_Calculos_Resultados

            try
            {
                #region Limpa ultimos resultados

                dictVarList.Clear();

                _modelGVL.GVL_T02.rForcaReal_P1_N = 0;
                _modelGVL.GVL_T02.rForcaOut_P1_N = 0;
                _modelGVL.GVL_T02.rForcaReal_P2_N = 0;
                _modelGVL.GVL_T02.rForcaOut_P2_N = 0;
                _modelGVL.GVL_T02.rForcaReal_E1_N = 0;
                _modelGVL.GVL_T02.rForcaOut_E1_N = 0;
                _modelGVL.GVL_T02.rForcaReal_E2_N = 0;
                _modelGVL.GVL_T02.rForcaOut_E2_N = 0;
                _modelGVL.GVL_T02.rForcaMaxima = 0; //Zera o ultimo valor de força obtido
                _modelGVL.GVL_T02.rGradienteForcaAvanco = 0; //Zera o ultimo valor obtido
                _modelGVL.GVL_T02.rGradienteForcaRetorno = 0; //Zera o ultimo valor obtido
                _modelGVL.GVL_T02.rGradienteDeslocamentoAvanco = 0; //Zera o ultimo valor obtido
                _modelGVL.GVL_T02.rGradienteDeslocamentoRetorno = 0; //Zera o ultimo valor obtido
                _modelGVL.GVL_T02.rRunOutForce_LinearInt_N = 0; //RunOut por intersecção linear
                _modelGVL.GVL_T02.rRunOutForceOut_LinearInt_N = 0; //RunOut por intersecção linear
                _modelGVL.GVL_T02.rForcaAuxiliar_P3_N = 0;
                _modelGVL.GVL_T02.rForca_P4_N = 0;
                _modelGVL.GVL_T02.rForcaOut_P4_N = 0;
                _modelGVL.GVL_T02.rRunOutForce_Real_N = 0;
                _modelGVL.GVL_T02.rRunOutForceOut_Real_N = 0;
                _modelGVL.GVL_T02.rForca_70Fout_N = 0;
                _modelGVL.GVL_T02.rForcaOut_70Fout_N = 0;
                _modelGVL.GVL_T02.rForca_90Fout_N = 0;
                _modelGVL.GVL_T02.rForcaOut_90Fout_N = 0;
                _modelGVL.GVL_T02.rDeslocamento_90Fout_mm = 0;
                _modelGVL.GVL_T02.rDeslocamentoNaForca_mm = 0;
                _modelGVL.GVL_T02.rForcaOut_P5_N = 0;
                _modelGVL.GVL_T02.rForca_F5_N = 0;
                _modelGVL.GVL_T02.rForcaOut_P6_N = 0;
                _modelGVL.GVL_T02.rForca_F6_N = 0;
                _modelGVL.GVL_T02.rForcaCutIn_N = 0;
                _modelGVL.GVL_T02.rForcaOutJumper_N = 0;
                _modelGVL.GVL_T02.rGradientJumper = 0;
                _modelGVL.GVL_T02.rForcaOutP1Jumper_N = 0;
                _modelGVL.GVL_T02.rForcaP1Jumper_N = 0;
                _modelGVL.GVL_T02.rForcaOutP2Jumper_N = 0;
                _modelGVL.GVL_T02.rForcaP2Jumper_N = 0;
                _modelGVL.GVL_T02.rReleaseForce_N = 0;
                _modelGVL.GVL_T02.rReleaseForceAt_N = 0;
                _modelGVL.GVL_T02.rReleaseForceAtReal_mm = 0;
                _modelGVL.GVL_T02.rForcaOutHystereseFout_N = 0;
                _modelGVL.GVL_T02.rForcaAvanco_XFout_N = 0;
                _modelGVL.GVL_T02.rForcaRetorno_XFout_N = 0;
                _modelGVL.GVL_T02.rHysterese_XFout_N = 0;
                _modelGVL.GVL_T02.rTaxaAmplificacao = 0;
                _modelGVL.GVL_T02.iConsumidoresCP = 0;
                _modelGVL.GVL_T02.iConsumidoresCS = 0;

                _modelGVL.GVL_T02.bCalculaResultados = bCalculaResultados;

                #region VARIABLES

                long diUbound = 0; //  ; DINT;
                long di = 0; //  ; DINT;
                double rForcaInicialGradiente = 0; //  ; REAL;
                double rForcaFinalGradiente = 0; //  ; REAL;
                double rDeslocamentoInicialGradiente = 0; //   ; REAL;
                double rDeslocamentoFinalGradiente = 0; //  ; REAL;
                double rTempoInicialGradiente = 0; //  ; REAL;
                double rTempoFinalGradiente = 0; //   ; REAL;

                double rCoeficienteAngular_L1 = 0; //   = 0; REAL = 0;
                double rCoeficienteLinear_L1 = 0; //   = 0; REAL = 0;
                double rCoeficienteAngular_L2 = 0; //   = 0; REAL = 0;
                double rCoeficienteLinear_L2 = 0; //   = 0; REAL = 0;
                double rCoeficienteAngular_L3 = 0; //   = 0; REAL = 0;
                double rCoeficienteLinear_L3 = 0; //   = 0; REAL = 0;

                long diIndice_P4 = 0; //   = 0; DINT = 0;
                long diIndice_P2 = 0; //   = 0; DINT = 0;
                long diIndice_p70 = 0; //   = 0; DINT = 0;
                long diIndice_p90 = 0; //   = 0; DINT = 0;
                long diIndice_ReleaseMax = 0; //   = 0; DINT = 0;
                long diIndice_ReleaseMin = 0; //   = 0; DINT = 0;

                double rA_L3 = 0; //   = 0; REAL = 0;
                double rB_L3 = 0; //   = 0; REAL = 0;
                double rC_L3 = 0; //   = 0; REAL = 0;
                double rRaizAB = 0; //   = 0; REAL = 0;

                double rCoordX = 0; //   = 0; REAL = 0;
                double rCoordY = 0; //   = 0; REAL = 0;

                double rResulTemp = 0; //   = 0; REAL = 0;
                double rMaiorDistancia = 0; //   = 0; REAL = 0;

                #endregion

                #endregion

                #region Variaveis Grafico

                _modelGVL.GVL_Graficos.rEscalaX = 1500;
                _modelGVL.GVL_Graficos.EixoX.wsTLLabel = "AxesChart.1";
                _modelGVL.GVL_Graficos.rEscalaY1 = 4000;
                _modelGVL.GVL_Graficos.EixoY1.wsTLLabel = "AxesChart.3";
                _modelGVL.GVL_Graficos.rEscalaY2 = 0;
                _modelGVL.GVL_Graficos.EixoY2.wsTLLabel = string.Empty;
                _modelGVL.GVL_Graficos.rEscalaY3 = 0;
                _modelGVL.GVL_Graficos.EixoY3.wsTLLabel = string.Empty;
                _modelGVL.GVL_Graficos.rEscalaY4 = 0;
                _modelGVL.GVL_Graficos.EixoY4.wsTLLabel = string.Empty;

                _modelGVL.GVL_Graficos.strNomeEixoX = "Input Force (N)";
                _modelGVL.GVL_Graficos.strNomeEixoY1 = "Output Force (N)";
                _modelGVL.GVL_Graficos.strNomeEixoY2 = string.Empty;
                _modelGVL.GVL_Graficos.strNomeEixoY3 = string.Empty;
                _modelGVL.GVL_Graficos.strNomeEixoY4 = string.Empty;

                _modelGVL.GVL_Graficos.strUnidadeX = "N";
                _modelGVL.GVL_Graficos.strUnidadeY1 = "N";
                _modelGVL.GVL_Graficos.strUnidadeY2 = string.Empty;
                _modelGVL.GVL_Graficos.strUnidadeY3 = string.Empty;
                _modelGVL.GVL_Graficos.strUnidadeY4 = string.Empty;

                _modelGVL.GVL_Graficos.bOcultaY2 = true;
                _modelGVL.GVL_Graficos.bOcultaY3 = true;
                _modelGVL.GVL_Graficos.bOcultaY4 = true;

                //Marcacoes Grafico
                int pointArr = 0;
                int pointPos = 0;
                string pointName = string.Empty;

                #endregion

                #region Varriaveis Array Dados

                ClearArrayGVL_Graficos();

                _modelGVL.GVL_Graficos.arrVarTimeStamp = lstDblReturnReadFile[0].ToArray();
                _modelGVL.GVL_Graficos.arrVarX = lstDblReturnReadFile[2].ToArray();
                _modelGVL.GVL_Graficos.arrVarY1 = lstDblReturnReadFile[3].ToArray();
                _modelGVL.GVL_Graficos.arrVarY3 = lstDblReturnReadFile[5].ToArray();

                #endregion

                #region Calculos

                if (_modelGVL.GVL_T02.bCalculaResultados)
                {
                    _modelGVL.GVL_T02 = HelperTestBase.Model_GVL.GVL_T02;

                    //Define o ponto maximo do array que foi plotado durante o teste
                    _modelGVL.GVL_Graficos.diBuffer = lstDblReturnReadFile[0].Count() > 0 ? lstDblReturnReadFile[0].Count() : 0;

                    diUbound = _modelGVL.GVL_Graficos.diBuffer; //Define o ponto maximo do array que foi plotado durante o teste

                    #region Loop para identificar a forca maxima do teste, e armazenar o ponto de inflexao do teste (quando o atuador comeca a retornar)
                    //========================================================================================================================================================

                    for (di = 0; di < diUbound; di++)
                    {
                        if (_modelGVL.GVL_Graficos.arrVarX[di] > _modelGVL.GVL_T02.rForcaMaxima)
                        {
                            _modelGVL.GVL_T02.rForcaMaxima = _modelGVL.GVL_Graficos.arrVarX[di]; //Atualiza o valor de forca maxima com o maior valor obtido no array
                            _modelGVL.GVL_T02.diPosicaoForcaMaxima = di; //Indica em qual posicao do array esta a forca maxima (pico do grafico, aonde comeca o retorno do atuador)
                        }
                    }

                    //========================================================================================================================================================
                    #endregion

                    #region Calculo do gradiente de aplicacao de força no avanço
                    //========================================================================================================================================================

                    //Busca no array o momento em que a forca comecou a subir (forca >= 100N) e o tempo decorrido desta forca
                    for (di = 0; di <= _modelGVL.GVL_T02.diPosicaoForcaMaxima; di++)
                    {
                        if (_modelGVL.GVL_Graficos.arrVarX[di] >= 100)//forca comecou a subir (>=100N)
                        {
                            rForcaInicialGradiente = _modelGVL.GVL_Graficos.arrVarX[di]; //Valor forca inicial para calculo 
                            rTempoInicialGradiente = _modelGVL.GVL_Graficos.arrVarTimeStamp[di]; //Valor to tempo em ms inicial para calculo

                            break; //Encerra a busca pela forca inicial
                        }
                    }

                    //Define a forca final e o tempo final do gradiente como a FMAX obtida no calculo anterior, utilizando seu indice para coletar o tempo respectivo
                    rForcaFinalGradiente = _modelGVL.GVL_Graficos.arrVarX[_modelGVL.GVL_T02.diPosicaoForcaMaxima];
                    rTempoFinalGradiente = _modelGVL.GVL_Graficos.arrVarTimeStamp[_modelGVL.GVL_T02.diPosicaoForcaMaxima];

                    //Calcula o gradiente de aplicacao de forca no avanco
                    _modelGVL.GVL_T02.rGradienteForcaAvanco = (rForcaFinalGradiente - rForcaInicialGradiente) / (rTempoFinalGradiente - rTempoInicialGradiente);
                    //========================================================================================================================================================

                    #endregion

                    #region Calculo do gradiente de aplicacao de força no retorno
                    //========================================================================================================================================================

                    //Busca no array o momento em que a forca caiu abaixo de 100N (forca <= 100N) e o tempo decorrido desta forca
                    for (di = _modelGVL.GVL_T02.diPosicaoForcaMaxima; di < diUbound; di++)
                    {
                        if (_modelGVL.GVL_Graficos.arrVarX[di] <= 100) //Forca proxima de 0 (<=100N)
                        {
                            rForcaFinalGradiente = _modelGVL.GVL_Graficos.arrVarX[di]; //Valor forca final para calculo 
                            rTempoFinalGradiente = _modelGVL.GVL_Graficos.arrVarTimeStamp[di]; //Valor to tempo em ms final para calculo

                            break; //Encerra a busca pela forca final
                        }
                    }

                    //Define a forca inicial e o tempo inicial do gradiente como a FMAX obtida no calculo anterior, utilizando seu indice para coletar o tempo respectivo
                    rForcaInicialGradiente = _modelGVL.GVL_Graficos.arrVarX[_modelGVL.GVL_T02.diPosicaoForcaMaxima];
                    rTempoInicialGradiente = _modelGVL.GVL_Graficos.arrVarTimeStamp[_modelGVL.GVL_T02.diPosicaoForcaMaxima];

                    //Calcula o gradiente de aplicacao de forca no retorno
                    _modelGVL.GVL_T02.rGradienteForcaRetorno = (rForcaFinalGradiente - rForcaInicialGradiente) / (rTempoFinalGradiente - rTempoInicialGradiente);
                    //========================================================================================================================================================
                    #endregion

                    #region Calculo do gradiente deslocamento de avanço 
                    //========================================================================================================================================================

                    //Busca no array o momento em que o deslocamento comecou a variar (deslocamento >= 1)
                    for (di = 0; di <= _modelGVL.GVL_T02.diPosicaoForcaMaxima; di++)
                    {
                        if (_modelGVL.GVL_Graficos.arrVarY3[di] >= 1) //Deslocamento >= 1mm
                        {
                            rDeslocamentoInicialGradiente = _modelGVL.GVL_Graficos.arrVarY3[di]; //Valor deslocamento inicial para calculo 
                            rTempoInicialGradiente = _modelGVL.GVL_Graficos.arrVarTimeStamp[di]; //Valor to tempo em ms inicial para calculo

                            break; //Encerra a busca pelo deslocamento inicial
                        }
                    }

                    //Define a forca final e o tempo final do gradiente como a FMAX obtida no calculo anterior, utilizando seu indice para coletar o tempo respectivo
                    rDeslocamentoFinalGradiente = _modelGVL.GVL_Graficos.arrVarY3[_modelGVL.GVL_T02.diPosicaoForcaMaxima];
                    rTempoFinalGradiente = _modelGVL.GVL_Graficos.arrVarTimeStamp[_modelGVL.GVL_T02.diPosicaoForcaMaxima];

                    //Calcula o gradiente de aplicacao de forca no avanco
                    _modelGVL.GVL_T02.rGradienteDeslocamentoAvanco = (rDeslocamentoFinalGradiente - rDeslocamentoInicialGradiente) / (rTempoFinalGradiente - rTempoInicialGradiente);
                    //========================================================================================================================================================

                    #endregion

                    #region Calculo do gradiente de deslocamento no retorno

                    //========================================================================================================================================================

                    //Busca no array o momento em que o deslocamento <= 1
                    for (di = _modelGVL.GVL_T02.diPosicaoForcaMaxima; di < diUbound; di++)
                    {
                        if (_modelGVL.GVL_Graficos.arrVarY3[di] <= 1) //Deslocamento <= 1
                        {
                            rDeslocamentoFinalGradiente = _modelGVL.GVL_Graficos.arrVarY3[di]; //Deslocamento final para calculo 
                            rTempoFinalGradiente = _modelGVL.GVL_Graficos.arrVarTimeStamp[di]; //Valor to tempo em ms final para calculo

                            break; //Encerra a busca pelo deslocamento final
                        }
                    }


                    //Define o deslocamento inicial e o tempo inicial do gradiente como a FMAX obtida no calculo anterior, utilizando seu indice para coletar o tempo respectivo
                    rDeslocamentoInicialGradiente = _modelGVL.GVL_Graficos.arrVarY3[_modelGVL.GVL_T02.diPosicaoForcaMaxima];
                    rTempoInicialGradiente = _modelGVL.GVL_Graficos.arrVarTimeStamp[_modelGVL.GVL_T02.diPosicaoForcaMaxima];

                    //Calcula o gradiente de aplicacao de forca no retorno
                    _modelGVL.GVL_T02.rGradienteDeslocamentoRetorno = (rDeslocamentoFinalGradiente - rDeslocamentoInicialGradiente) / (rTempoFinalGradiente - rTempoInicialGradiente);
                    //========================================================================================================================================================

                    #endregion

                    #region Pega os valores de pressão no cruzamento com as forças solicitadas: P1

                    //========================================================================================================================================================

                    for (di = 0; di < diUbound; di++)
                    {
                        if (_modelGVL.GVL_Graficos.arrVarX[di] >= _modelGVL.GVL_T02.rForca_P1) //Encontrou a forca >= parametro definido
                        {
                            _modelGVL.GVL_T02.rForcaReal_P1_N = _modelGVL.GVL_Graficos.arrVarX[di]; //Armazena o valor real encontrado (>=)
                            _modelGVL.GVL_T02.rForcaOut_P1_N = _modelGVL.GVL_Graficos.arrVarY1[di]; //Armazena a ForcaFOut correspondente encontrada

                            break; //Encerra a busca
                        }
                    }

                    #region Gera o ponto (X) no grafico

                    //_modelGVL.GVL_Graficos.arrVarXPoint1[0] = _modelGVL.GVL_T02.rForcaReal_P1_N;
                    //_modelGVL.GVL_Graficos.arrVarYPoint1[0] = _modelGVL.GVL_T02.rForcaOut_P1_N;

                    #endregion

                    #endregion

                    #region Pega os valores de pressão no cruzamento com as forças solicitadas: P2

                    for (di = 0; di < diUbound; di++)
                    {
                        if (_modelGVL.GVL_Graficos.arrVarX[di] >= _modelGVL.GVL_T02.rForca_P2) //Encontrou a forca >= parametro definido
                        {
                            _modelGVL.GVL_T02.rForcaReal_P2_N = _modelGVL.GVL_Graficos.arrVarX[di]; //Armazena o valor real encontrado (>=)
                            _modelGVL.GVL_T02.rForcaOut_P2_N = _modelGVL.GVL_Graficos.arrVarY1[di]; //Armazena a ForcaFOut correspondente encontrada

                            diIndice_P2 = di; //Armazena o Indice de P2 para o calculo posterior, runoutpoint

                            break; //Encerra a busca
                        }
                    }

                    #region Gera o ponto (X) no grafico

                    //_modelGVL.GVL_Graficos.arrVarXPoint1[1] = _modelGVL.GVL_T02.rForcaReal_P2_N;
                    //_modelGVL.GVL_Graficos.arrVarYPoint1[1] = _modelGVL.GVL_T02.rForcaOut_P2_N;

                    #endregion

                    #endregion

                    #region Pega os valores de pressão no cruzamento com as forças solicitadas: E1

                    for (di = 0; di < diUbound; di++)
                    {
                        if (_modelGVL.GVL_Graficos.arrVarX[di] >= _modelGVL.GVL_T02.rForca_E1) //Encontrou a forca >= parametro definido
                        {
                            _modelGVL.GVL_T02.rForcaReal_E1_N = _modelGVL.GVL_Graficos.arrVarX[di]; //Armazena o valor real encontrado (>=)
                            _modelGVL.GVL_T02.rForcaOut_E1_N = _modelGVL.GVL_Graficos.arrVarY1[di]; //Armazena a ForcaFOut correspondente encontrada

                            break; //Encerra a busca
                        }
                    }

                    #region Gera o ponto (X) no grafico

                    //_modelGVL.GVL_Graficos.arrVarXPoint1[2] = _modelGVL.GVL_T02.rForcaReal_E1_N;
                    //_modelGVL.GVL_Graficos.arrVarYPoint1[2] = _modelGVL.GVL_T02.rForcaOut_E1_N;

                    #endregion

                    #endregion

                    #region Pega os valores de pressão no cruzamento com as forças solicitadas: E2

                    for (di = 0; di < diUbound; di++)
                    {
                        if (_modelGVL.GVL_Graficos.arrVarX[di] >= _modelGVL.GVL_T02.rForca_E2) //Encontrou a forca >= parametro definido
                        {
                            _modelGVL.GVL_T02.rForcaReal_E2_N = _modelGVL.GVL_Graficos.arrVarX[di]; //Armazena o valor real encontrado (>=)
                            _modelGVL.GVL_T02.rForcaOut_E2_N = _modelGVL.GVL_Graficos.arrVarY1[di]; //Armazena a ForcaFOut correspondente encontrada

                            break; //Encerra a busca
                        }
                    }

                    #region Gera o ponto (X) no grafico

                    //_modelGVL.GVL_Graficos.arrVarXPoint1[3] = _modelGVL.GVL_T02.rForcaReal_E2_N;
                    //_modelGVL.GVL_Graficos.arrVarYPoint1[3] = _modelGVL.GVL_T02.rForcaOut_E2_N;

                    #endregion

                    //========================================================================================================================================================
                    #endregion

                    #region Calculo do runout point por intersecção linear (cruzamento das retas 1 (amplificação) e 2 (saturação)
                    //========================================================================================================================================================

                    //Reta 1 tambem chamada de L1
                    // Y = m.X + n onde:
                    // Y/X pontos na curva
                    // m - coeficiente angular da reta
                    // n - coeficiente linear da reta
                    //m pode ser calculado pela variacao entre 2 pontos (y2-y1)/(x2-x1)

                    //Retal L1
                    //Define o coeficiente angular e linear da reta 1 (amplificacao)
                    rCoeficienteAngular_L1 = (_modelGVL.GVL_T02.rForcaOut_E2_N - _modelGVL.GVL_T02.rForcaOut_E1_N) / (_modelGVL.GVL_T02.rForcaReal_E2_N - _modelGVL.GVL_T02.rForcaReal_E1_N);
                    rCoeficienteLinear_L1 = _modelGVL.GVL_T02.rForcaOut_E1_N - (rCoeficienteAngular_L1 * _modelGVL.GVL_T02.rForcaReal_E1_N); //(Y = m.X + n) > n = Y-(m.X)

                    //Retal L2
                    //Define o coeficiente angular e linear da reta 2 (saturacao)
                    rCoeficienteAngular_L2 = (_modelGVL.GVL_T02.rForcaOut_P2_N - _modelGVL.GVL_T02.rForcaOut_P1_N) / (_modelGVL.GVL_T02.rForcaReal_P2_N - _modelGVL.GVL_T02.rForcaReal_P1_N);
                    rCoeficienteLinear_L2 = _modelGVL.GVL_T02.rForcaOut_P1_N - (rCoeficienteAngular_L2 * _modelGVL.GVL_T02.rForcaReal_P1_N); //(Y = m.X + n) > n = Y-(m.X)

                    //Cruzamento das retas para calculo das coordenadas de runoutForce e runoutForceOut por instersecção linear

                    _modelGVL.GVL_T02.rRunOutForce_LinearInt_N = ((rCoeficienteLinear_L1 - rCoeficienteLinear_L2) / (rCoeficienteAngular_L1 - rCoeficienteAngular_L2)) * -1;
                    _modelGVL.GVL_T02.rRunOutForceOut_LinearInt_N = (rCoeficienteAngular_L1 * _modelGVL.GVL_T02.rRunOutForce_LinearInt_N) + rCoeficienteLinear_L1;

                    //========================================================================================================================================================

                    #endregion

                    #region Calculo do auxiliary force P3, ForcaFOut auxiliar para calculo do runout point real (vide norma continental)

                    //========================================================================================================================================================

                    //ForcaFOut auxiliar P3 eh o rebatimento da linha L2 (reta de saturacao) aonde o valor de forca (eixo x) = 0, ou seja, P3=Coeficiente Linear de L2
                    _modelGVL.GVL_T02.rForcaAuxiliar_P3_N = rCoeficienteLinear_L2;
                    //A ForcaFOut P4 é o rebatimento da forca p3 no grafico, porem com o valor de um ponto real o mais proximo possivel do valor p3.
                    //Busca no array o valor mais proximo da ForcaFOut p3 para obter a ForcaFOut real p4 e a forca p4
                    for (di = 0; di <= _modelGVL.GVL_T02.diPosicaoForcaMaxima; di++)
                    {
                        if (_modelGVL.GVL_Graficos.arrVarY1[di] >= _modelGVL.GVL_T02.rForcaAuxiliar_P3_N) //ForcaFOut no array >= ForcaFOut auxiliar P3
                        {
                            _modelGVL.GVL_T02.rForcaOut_P4_N = _modelGVL.GVL_Graficos.arrVarY1[di]; //Valor da ForcaFOut real obtida no grafico valida para P3 
                            _modelGVL.GVL_T02.rForca_P4_N = _modelGVL.GVL_Graficos.arrVarX[di]; //Valor da forca no ponto de ForcaFOut real P4

                            diIndice_P4 = di; //Memoriza o indice do parametro P4 para o calculo de distancia do ponto (runout, proximo calculo)

                            break; //Encerra a busca
                        }
                    }

                    //========================================================================================================================================================

                    #endregion

                    #region Calculo da reta auxiliar L3, utilizada para identificar o ponto mais distante (runoutpoint)

                    //========================================================================================================================================================
                    // Y = m.X + n onde:
                    // Y/X pontos na curva
                    // m - coeficiente angular da reta
                    // n - coeficiente linear da reta
                    //m pode ser calculado pela variacao entre 2 pontos (y2-y1)/(x2-x1)

                    //Reta L3 - entre o ponto P2 e o Ponto P4
                    //Define o coeficiente angular e linear da reta 3 (reta auxiliar)
                    rCoeficienteAngular_L3 = (_modelGVL.GVL_T02.rForcaOut_P2_N - _modelGVL.GVL_T02.rForcaOut_P4_N) / (_modelGVL.GVL_T02.rForcaReal_P2_N - _modelGVL.GVL_T02.rForca_P4_N);
                    rCoeficienteLinear_L3 = _modelGVL.GVL_T02.rForcaOut_P2_N - (rCoeficienteAngular_L3 * _modelGVL.GVL_T02.rForcaReal_P2_N); //(Y = m.X + n) > n = Y-(m.X)

                    //Medicao da distancia perpendicular de todos os pontos, partindo das coordenadas de P4 ate P2, para identificar o ponto mais distante (runoutpoint).
                    //Formula da geometria analitica para encontrar a distancia entre o ponto e a reta:
                    //Primeiro, encontrar a equacao da reta e localizar os pontos a, b e c onde
                    // eq da reta ||aX + bY + c = 0
                    //DistanciaAB = | aX + bY + c |
                    //				|-------------|
                    //				|   √(a²+b²)  |

                    rA_L3 = rCoeficienteAngular_L3 * -1;
                    rB_L3 = 1;
                    rC_L3 = (rCoeficienteAngular_L3 * _modelGVL.GVL_T02.rForca_P4_N) - _modelGVL.GVL_T02.rForcaOut_P4_N;

                    rRaizAB = Math.Sqrt((rA_L3 * rA_L3) + (rB_L3 * rB_L3));

                    for (di = diIndice_P4; di <= diIndice_P2; di++)
                    {
                        rCoordX = _modelGVL.GVL_Graficos.arrVarX[di]; //Valor do Ponto na coordenada X
                        rCoordY = _modelGVL.GVL_Graficos.arrVarY1[di]; //Valor do ponto na coordenada Y

                        rResulTemp = ((rCoordX * rA_L3) + (rCoordY * rB_L3) + rC_L3) / rRaizAB;

                        //arResultados[di - diIndice_P4] = rResulTemp;

                        if (rResulTemp > rMaiorDistancia) //ForcaFOut no array >= ForcaFOut auxiliar P3
                        {
                            rMaiorDistancia = rResulTemp;
                            _modelGVL.GVL_T02.rRunOutForce_Real_N = _modelGVL.GVL_Graficos.arrVarX[di];
                            _modelGVL.GVL_T02.rRunOutForceOut_Real_N = _modelGVL.GVL_Graficos.arrVarY1[di];
                        }
                    }

                    #region Gera o ponto (X) no grafico

                    //if (!_modelGVL.GVL_T02.bRunOutTeorico)
                    //{
                    //    _modelGVL.GVL_Graficos.arrVarXPoint1[4] = _modelGVL.GVL_T02.rRunOutForce_Real_N;
                    //    _modelGVL.GVL_Graficos.arrVarYPoint1[4] = _modelGVL.GVL_T02.rRunOutForceOut_Real_N;
                    //}
                    //else
                    //{
                    //    _modelGVL.GVL_Graficos.arrVarXPoint1[4] = _modelGVL.GVL_T02.rRunOutForce_LinearInt_N;
                    //    _modelGVL.GVL_Graficos.arrVarYPoint1[4] = _modelGVL.GVL_T02.rRunOutForceOut_LinearInt_N;
                    //}

                    #endregion

                    //========================================================================================================================================================

                    #endregion

                    #region Calcula a forca a 70%fout e encontra um ponto real no grafico

                    //========================================================================================================================================================

                    for (di = 0; di <= _modelGVL.GVL_T02.diPosicaoForcaMaxima; di++)
                    {
                        if (_modelGVL.GVL_Graficos.arrVarY1[di] >= (_modelGVL.GVL_T02.rRunOutForceOut_Real_N * 0.7)) //ForcaFOut no array >= (ForcaFOut runout *0.7)
                        {
                            _modelGVL.GVL_T02.rForcaOut_70Fout_N = _modelGVL.GVL_Graficos.arrVarY1[di]; //Valor da ForcaFOut real obtida no grafico valida para 70% runout 
                            _modelGVL.GVL_T02.rForca_70Fout_N = _modelGVL.GVL_Graficos.arrVarX[di]; //Valor da forca real obtida no grafico valida para 70% runout (apnas exibe)
                            diIndice_p70 = di; //Memoriza o indice do parametro

                            break; //Encerra a busca
                        }
                    }

                    //========================================================================================================================================================

                    #endregion

                    #region Calcula a forca a 90%Fout e encontra um ponto real no grafico

                    //========================================================================================================================================================
                    //tambem salva o deslocamento a 90% do runout, aproveitando o loop de busca
                    _modelGVL.GVL_T02.rForcaOut_90Fout_N = _modelGVL.GVL_T02.rRunOutForceOut_Real_N * 0.9; //Calcula a ForcaFOut teorica 90% Fout

                    for (di = 0; di <= _modelGVL.GVL_T02.diPosicaoForcaMaxima; di++)
                    {
                        if (_modelGVL.GVL_Graficos.arrVarY1[di] >= _modelGVL.GVL_T02.rForcaOut_90Fout_N)  //ForcaFOut no array >= ForcaFOut RUnout * 0.9
                        {
                            _modelGVL.GVL_T02.rForcaOut_90Fout_N = _modelGVL.GVL_Graficos.arrVarY1[di]; //Valor da ForcaFOut real obtida no grafico valida para 90 runout 
                            _modelGVL.GVL_T02.rDeslocamento_90Fout_mm = _modelGVL.GVL_Graficos.arrVarY3[di]; //Valor de deslocamento a 90% Fout
                            _modelGVL.GVL_T02.rForca_90Fout_N = _modelGVL.GVL_Graficos.arrVarX[di]; //Valor da Forca relacionada a ForcaFOut 90% Fout
                            _modelGVL.GVL_T02.rForca_F6_N = _modelGVL.GVL_Graficos.arrVarX[di]; //Valor da Forca relacionada a ForcaFOut 90% Fout
                            _modelGVL.GVL_T02.rForcaOut_P6_N = _modelGVL.GVL_Graficos.arrVarY1[di];
                            diIndice_p90 = di; //Memoriza o indice do parametro 

                            break; //Encerra a busca
                        }
                    }

                    //========================================================================================================================================================

                    #endregion

                    #region Obtem valor de deslocamento em funcao do parametro DeslocamentoNaFout (%Fout)

                    //========================================================================================================================================================

                    for (di = 0; di <= _modelGVL.GVL_T02.diPosicaoForcaMaxima; di++)
                    {
                        if (_modelGVL.GVL_Graficos.arrVarY1[di] >= ((_modelGVL.GVL_T02.rDeslocamentoNaForca / 100) * _modelGVL.GVL_T02.rRunOutForceOut_Real_N))  //Valor do deslocamento obtido na ForcaFOut definida
                        {
                            _modelGVL.GVL_T02.rDeslocamentoNaForca_mm = _modelGVL.GVL_Graficos.arrVarY3[di]; //Valor do deslocamento obtido na ForcaFOut definida

                            break; //Encerra a busca
                        }
                    }

                    //========================================================================================================================================================

                    #endregion

                    #region Calcula a forca Cut IN

                    //========================================================================================================================================================

                    for (di = 0; di <= _modelGVL.GVL_T02.diPosicaoForcaMaxima; di++)
                    {
                        if (_modelGVL.GVL_Graficos.arrVarY1[di] >= _modelGVL.GVL_T02.rForcaFOutCutIn_N)  //ForcaFOut de cut in
                        {
                            _modelGVL.GVL_T02.rForcaCutIn_N = _modelGVL.GVL_Graficos.arrVarX[di]; //Valor da forca obtida na Fout de Cut IN

                            break; //Encerra a busca
                        }
                    }

                    //========================================================================================================================================================

                    #endregion

                    #region Calculo do Jumper

                    //========================================================================================================================================================
                    //Formula na norma - Pjumper = P5 + (Fcutin - Fe200)*((P6-P5)/(F6-FE200))
                    //P6 = ForcaFOut runout * 0.9, obtido anteriormente
                    //F6 = Forca correspondente a P6, obtido anteriormente
                    //FE200 = 200N, esta na norma, so muda se for especificado "The point P5 is calculated with an input force of FE200 = 200N, unless otherwise specified"
                    //FAN=Fcutin

                    //Encontra a ForcaFOut P5, que corresponde na tabela de dados a forca = 200N

                    for (di = 0; di <= _modelGVL.GVL_T02.diPosicaoForcaMaxima; di++)
                    {
                        if (_modelGVL.GVL_Graficos.arrVarX[di] >= 200) //ForcaFOut de cut in.
                        {
                            _modelGVL.GVL_T02.rForcaOut_P5_N = _modelGVL.GVL_Graficos.arrVarY1[di]; //Valor da ForcaFOut correspondente a uma forca 200N

                            break; //Encerra a busca
                        }
                    }

                    _modelGVL.GVL_T02.rForcaOutJumper_N = _modelGVL.GVL_T02.rForcaOut_P5_N + (_modelGVL.GVL_T02.rForcaCutIn_N - 200) *
                                                            ((_modelGVL.GVL_T02.rForcaOut_P6_N - _modelGVL.GVL_T02.rForcaOut_P5_N) / (_modelGVL.GVL_T02.rForca_F6_N - 200));

                    _modelGVL.GVL_Graficos.arrVarXPoint1[5] = _modelGVL.GVL_T02.rForcaCutIn_N;
                    _modelGVL.GVL_Graficos.arrVarYPoint1[5] = _modelGVL.GVL_T02.rForcaOutJumper_N;

                    //========================================================================================================================================================

                    #endregion

                    #region Jumper Gradient

                    //========================================================================================================================================================

                    //Obtem a pressão e forca no ponto definido nos parametros

                    //Obtem a pressão e forca no ponto definido nos parametros
                    for (di = 0; di <= _modelGVL.GVL_T02.diPosicaoForcaMaxima; di++)
                    {
                        if (_modelGVL.GVL_Graficos.arrVarY1[di] >= _modelGVL.GVL_T02.rGradienteJumper_P1_N) //Forca no array  >= Forca P1 Jumper
                        {
                            _modelGVL.GVL_T02.rForcaOutP1Jumper_N = _modelGVL.GVL_Graficos.arrVarY1[di]; //Valor da pressao real de jumper P1
                            _modelGVL.GVL_T02.rForcaP1Jumper_N = _modelGVL.GVL_Graficos.arrVarX[di]; //Valor da forca real de jumper P1

                            break; //Encerra a busca
                        }
                    }

                    //Obtem a pressão e forca no ponto definido nos parametros
                    for (di = 0; di <= _modelGVL.GVL_T02.diPosicaoForcaMaxima; di++)
                    {
                        if (_modelGVL.GVL_Graficos.arrVarY1[di] >= _modelGVL.GVL_T02.rGradienteJumper_P2_N) //Pressao no array  >= pressao P2 Jumper
                        {
                            _modelGVL.GVL_T02.rForcaOutP2Jumper_N = _modelGVL.GVL_Graficos.arrVarY1[di]; //Valor da pressao real de jumper P2
                            _modelGVL.GVL_T02.rForcaP2Jumper_N = _modelGVL.GVL_Graficos.arrVarX[di]; //Valor da forca real de jumper P2

                            break; //Encerra a busca
                        }
                    }

                    //     //Calcula o gradiente de Jumper (N/bar)
                    _modelGVL.GVL_T02.rGradientJumper = (_modelGVL.GVL_T02.rForcaP2Jumper_N - _modelGVL.GVL_T02.rForcaP1Jumper_N) / (_modelGVL.GVL_T02.rForcaOutP2Jumper_N - _modelGVL.GVL_T02.rForcaOutP1Jumper_N);

                    #region Gera o ponto (X) no grafico

                    //pointArr = 0;
                    //pointPos = 10;
                    //pointName = "Jumper Gradient";

                    //////Marcacoes no Grafico
                    //_modelGVL.GVL_Graficos.lstMarkedPoint_Name[pointPos] = pointName;
                    //_modelGVL.GVL_Graficos.lstMarkedPoint_X[pointPos] = pointArr;
                    //_modelGVL.GVL_Graficos.lstMarkedPoint_Y[pointPos] = pointArr;
                    //_modelGVL.GVL_Graficos.dictXMarkedPoint.Add($"PX{pointPos}_{pointName}", pointArr);
                    //_modelGVL.GVL_Graficos.dictYMarkedPoint.Add($"PY{pointPos}_{pointName}", pointArr);

                    #endregion

                    //========================================================================================================================================================

                    #endregion

                    #region Calcula a release force

                    //========================================================================================================================================================
                    //Release force é o pico de força no retorno encontrado na tabela de pontos, entre os parametros release force min/ release force max.

                    //Encontra o indice do release force max (como é decrescente, max primeiro, min depois na tabela)

                    for (di = _modelGVL.GVL_T02.diPosicaoForcaMaxima; di < diUbound; di++)
                    {
                        if (_modelGVL.GVL_Graficos.arrVarY1[di] <= _modelGVL.GVL_T02.rReleaseForceFoutMax_N)
                        {
                            diIndice_ReleaseMax = di; //Indice aonde esta a pressao maxima para avaliar o pico de forca no retorno 

                            break; //Encerra a busca
                        }
                    }

                    //Encontra o indice do release force min (como é decrescente, max primeiro, min depois na tabela)
                    for (di = diIndice_ReleaseMax; di < diUbound; di++)
                    {
                        if (_modelGVL.GVL_Graficos.arrVarY1[di] <= _modelGVL.GVL_T02.rReleaseForceFoutMin_N)
                        {
                            diIndice_ReleaseMin = di; //Indice aonde esta a pressao minima para avaliar o pico de forca no retorno 

                            break; //Encerra a busca
                        }
                    }


                    //Encontra o pico de forca entre Max e Min
                    for (di = diIndice_ReleaseMax; di <= diIndice_ReleaseMin; di++)
                    {
                        if (_modelGVL.GVL_Graficos.arrVarX[di] > _modelGVL.GVL_T02.rReleaseForce_N)
                        {
                            _modelGVL.GVL_T02.rReleaseForce_N = _modelGVL.GVL_Graficos.arrVarX[di]; //Pico de forca entre as pressoes definidas no retorno                     
                        }
                    }

                    //Encontra o pico de forca no deslocamento de retorno definido
                    for (di = _modelGVL.GVL_T02.diPosicaoForcaMaxima; di <= diUbound; di++)
                    {
                        if (_modelGVL.GVL_Graficos.arrVarY3[di] <= _modelGVL.GVL_T02.rReleaseForceAt_mm) // Deslocamento no ponto <= o valor definido no parametro
                        {
                            _modelGVL.GVL_T02.rReleaseForceAt_N = _modelGVL.GVL_Graficos.arrVarX[di]; //Forca Obtida no ponto de retorno
                            _modelGVL.GVL_T02.rReleaseForceAtReal_mm = _modelGVL.GVL_Graficos.arrVarY3[di]; //Valor de deslocamento real obtido

                            break; //Encerra a busca
                        }
                    }

                    //========================================================================================================================================================

                    #endregion

                    #region Calcula a hysterese (diferenca de forca na ida e na volta, com pontos de ForcaFOut iguais

                    //========================================================================================================================================================

                    _modelGVL.GVL_T02.rForcaOutHystereseFout_N = _modelGVL.GVL_T02.rRunOutForceOut_Real_N * (_modelGVL.GVL_T02.rForcaHysterese_pout / 100);

                    //Obtem a forca relacionada a ForcaFOut x% Fout no avanco
                    for (di = 0; di <= _modelGVL.GVL_T02.diPosicaoForcaMaxima; di++)
                    {
                        if (_modelGVL.GVL_Graficos.arrVarY1[di] >= _modelGVL.GVL_T02.rForcaOutHystereseFout_N)//ForcaFOut no array >= ForcaFOut Runout * x%
                        {
                            _modelGVL.GVL_T02.rForcaAvanco_XFout_N = _modelGVL.GVL_Graficos.arrVarX[di]; //Valor da Forca relacionada a ForcaFOut x% pout no avanco

                            break; //Encerra a busca
                        }
                    }

                    _modelGVL.GVL_Graficos.arrVarXPoint1[6] = _modelGVL.GVL_T02.rForcaAvanco_XFout_N;
                    _modelGVL.GVL_Graficos.arrVarYPoint1[6] = _modelGVL.GVL_T02.rForcaOutHystereseFout_N;

                    //Obtem a forca relacionada a ForcaFOut x% Fout no retorno
                    for (di = _modelGVL.GVL_T02.diPosicaoForcaMaxima; di < diUbound; di++)
                    {
                        if (_modelGVL.GVL_Graficos.arrVarY1[di] <= _modelGVL.GVL_T02.rForcaOutHystereseFout_N) //ForcaFOut no array <= ForcaFOut Runout * x%
                        {
                            _modelGVL.GVL_T02.rForcaRetorno_XFout_N = _modelGVL.GVL_Graficos.arrVarX[di]; //Valor da Forca relacionada a ForcaFOut x% pout no retorno

                            break; //Encerra a busca
                        }
                    }


                    _modelGVL.GVL_Graficos.arrVarXPoint1[7] = _modelGVL.GVL_T02.rForcaRetorno_XFout_N;
                    _modelGVL.GVL_Graficos.arrVarYPoint1[7] = _modelGVL.GVL_T02.rForcaOutHystereseFout_N;

                    //Calculo do hysterese (diferenca de forca no avanco e no retorno, no mesmo ponto de ForcaFOut)
                    _modelGVL.GVL_T02.rHysterese_XFout_N = _modelGVL.GVL_T02.rForcaAvanco_XFout_N - _modelGVL.GVL_T02.rForcaRetorno_XFout_N;

                    //Obtem a forca relacionada a ForcaFOut xN Fout no avanco
                    for (di = 0; di <= _modelGVL.GVL_T02.diPosicaoForcaMaxima; di++)
                    {
                        if (_modelGVL.GVL_Graficos.arrVarY1[di] >= _modelGVL.GVL_T02.rForcaHysterese_N) //ForcaFOut no array >= xN
                        {
                            _modelGVL.GVL_T02.rForcaAvanco_XFout_N = _modelGVL.GVL_Graficos.arrVarX[di]; //Valor da Forca relacionada a ForcaFOut xbar no avanco

                            break; //Encerra a busca
                        }
                    }


                    _modelGVL.GVL_Graficos.arrVarXPoint1[8] = _modelGVL.GVL_T02.rForcaRetorno_XFout_N;
                    _modelGVL.GVL_Graficos.arrVarYPoint1[8] = _modelGVL.GVL_T02.rForcaHysterese_N;

                    //Obtem a forca relacionada a ForcaFOut Xbar pout no retorno
                    for (di = _modelGVL.GVL_T02.diPosicaoForcaMaxima; di < diUbound; di++)
                    {
                        if (_modelGVL.GVL_Graficos.arrVarY1[di] <= _modelGVL.GVL_T02.rForcaHysterese_N) //ForcaFOut no array <= xbar
                        {
                            _modelGVL.GVL_T02.rForcaRetorno_XFout_N = _modelGVL.GVL_Graficos.arrVarX[di]; //Valor da Forca relacionada a ForcaFOut xbar no retorno

                            break; //Encerra a busca
                        }
                    }

                    _modelGVL.GVL_Graficos.arrVarXPoint1[9] = _modelGVL.GVL_T02.rForcaRetorno_XFout_N;
                    _modelGVL.GVL_Graficos.arrVarYPoint1[9] = _modelGVL.GVL_T02.rForcaHysterese_N;

                    //Calculo do hysterese (diferenca de forca no avanco e no retorno, no mesmo ponto de pressao)
                    _modelGVL.GVL_T02.rHysterese_XFout_N = _modelGVL.GVL_T02.rForcaAvanco_XFout_N - _modelGVL.GVL_T02.rForcaRetorno_XFout_N;
                    //========================================================================================================================================================

                    #endregion

                    #region Calculo dos Consumidores Utilizados

                    // nao usa consumers
                    //========================================================================================================================================================
                    _modelGVL.GVL_T02.iConsumidoresCP = 0;
                    _modelGVL.GVL_T02.iConsumidoresCS = 0;
                    //========================================================================================================================================================

                    #endregion

                    _modelGVL.GVL_T02.bCalculaResultados = false;

                    _modelGVL.GVL_Graficos.bDadosCalculados = true;
                }

                HelperTestBase.Model_GVL.helperTestBase_ModelGVL_Test = HelperTestBase.Model_GVL.GVL_T02;

                HelperTestBase.Model_GVL = _modelGVL;

                #endregion

            }
            catch (Exception ex)
            {
                var err = ex.Message;
                throw;
            }

            return _modelGVL;

            #endregion
        }

        #endregion

        #region T03 - Calculos Forca Pressao - ET_ForceDiagrams_ForcePressure_WithoutVacuum
        public Model_GVL CalcGraphT03_ET_ForceDiagrams_ForcePressure_WithoutVacuum(bool bCalculaResultados, List<double>[] lstDblReturnReadFile)
        {
            #region PROGRAM T03_Calculos_Resultados

            try
            {
                #region Limpa ultimos resultados

                dictVarList.Clear();

                _modelGVL.GVL_T03.rForcaReal_P1_N = 0;
                _modelGVL.GVL_T03.rPressao_P1_Bar = 0;
                _modelGVL.GVL_T03.rForcaReal_P2_N = 0;
                _modelGVL.GVL_T03.rPressao_P2_Bar = 0;
                _modelGVL.GVL_T03.rForcaReal_E1_N = 0;
                _modelGVL.GVL_T03.rPressao_E1_Bar = 0;
                _modelGVL.GVL_T03.rForcaReal_E2_N = 0;
                _modelGVL.GVL_T03.rPressao_E2_Bar = 0;
                _modelGVL.GVL_T03.rForcaMaxima = 0; //Zera o ultimo valor de força obtido
                _modelGVL.GVL_T03.rGradienteForcaAvanco = 0; //Zera o ultimo valor obtido
                _modelGVL.GVL_T03.rGradienteForcaRetorno = 0; //Zera o ultimo valor obtido
                _modelGVL.GVL_T03.rGradienteDeslocamentoAvanco = 0; //Zera o ultimo valor obtido
                _modelGVL.GVL_T03.rGradienteDeslocamentoRetorno = 0; //Zera o ultimo valor obtido
                _modelGVL.GVL_T03.rDeslocamentoNaPressao_mm = 0;
                _modelGVL.GVL_T03.rPressao_P5_Bar = 0;
                _modelGVL.GVL_T03.rForca_F5_N = 0;
                _modelGVL.GVL_T03.rPressao_P6_Bar = 0;
                _modelGVL.GVL_T03.rForca_F6_N = 0;
                _modelGVL.GVL_T03.rForcaCutIn_N = 0;
                _modelGVL.GVL_T03.rPressaoJumper_Bar = 0;
                _modelGVL.GVL_T03.rGradientJumper = 0;
                _modelGVL.GVL_T03.rReleaseForce_N = 0;
                _modelGVL.GVL_T03.rReleaseForceAt_N = 0;
                _modelGVL.GVL_T03.rReleaseForceAtReal_mm = 0;
                _modelGVL.GVL_T03.iConsumidoresCP = 0;
                _modelGVL.GVL_T03.iConsumidoresCS = 0;

                _modelGVL.GVL_T03.bCalculaResultados = bCalculaResultados;

                #region VARIABLES

                long diUbound = 0; //  ; DINT;
                long di = 0; //  ; DINT;
                double rForcaInicialGradiente = 0; //  ; REAL;
                double rForcaFinalGradiente = 0; //  ; REAL;
                double rDeslocamentoInicialGradiente = 0; //   ; REAL;
                double rDeslocamentoFinalGradiente = 0; //  ; REAL;
                double rTempoInicialGradiente = 0; //  ; REAL;
                double rTempoFinalGradiente = 0; //   ; REAL;

                long diIndice_P2 = 0;
                long diIndice_ReleaseMax = 0; //   = 0; DINT = 0;
                long diIndice_ReleaseMin = 0; //   = 0; DINT = 0;

                #endregion

                #endregion

                #region Variaveis Grafico

                _modelGVL.GVL_Graficos.rEscalaX = 1500;
                _modelGVL.GVL_Graficos.EixoX.wsTLLabel = "AxesChart.1";
                _modelGVL.GVL_Graficos.rEscalaY1 = 150;
                _modelGVL.GVL_Graficos.EixoY1.wsTLLabel = "AxesChart.3";
                _modelGVL.GVL_Graficos.rEscalaY2 = 150;
                _modelGVL.GVL_Graficos.EixoY2.wsTLLabel = "AxesChart.4";
                _modelGVL.GVL_Graficos.rEscalaY3 = 0;
                _modelGVL.GVL_Graficos.EixoY3.wsTLLabel = string.Empty;
                _modelGVL.GVL_Graficos.rEscalaY4 = 0;
                _modelGVL.GVL_Graficos.EixoY4.wsTLLabel = string.Empty;

                _modelGVL.GVL_Graficos.strNomeEixoX = "Input Force (N)";
                _modelGVL.GVL_Graficos.strNomeEixoY1 = "Pressure PC (bar)";
                _modelGVL.GVL_Graficos.strNomeEixoY2 = "Pressure SC (bar)";
                _modelGVL.GVL_Graficos.strNomeEixoY3 = string.Empty;
                _modelGVL.GVL_Graficos.strNomeEixoY4 = string.Empty;

                _modelGVL.GVL_Graficos.strUnidadeX = "N";
                _modelGVL.GVL_Graficos.strUnidadeY1 = "bar";
                _modelGVL.GVL_Graficos.strUnidadeY2 = "bar";
                _modelGVL.GVL_Graficos.strUnidadeY3 = string.Empty;
                _modelGVL.GVL_Graficos.strUnidadeY4 = string.Empty;

                _modelGVL.GVL_Graficos.bOcultaY2 = false;
                _modelGVL.GVL_Graficos.bOcultaY3 = true;
                _modelGVL.GVL_Graficos.bOcultaY4 = true;

                #endregion

                #region Varriaveis Array Dados

                ClearArrayGVL_Graficos();

                _modelGVL.GVL_Graficos.arrVarTimeStamp = lstDblReturnReadFile[0].ToArray();
                _modelGVL.GVL_Graficos.arrVarX = lstDblReturnReadFile[2].ToArray();
                _modelGVL.GVL_Graficos.arrVarY1 = lstDblReturnReadFile[7].ToArray();
                _modelGVL.GVL_Graficos.arrVarY2 = lstDblReturnReadFile[6].ToArray();
                _modelGVL.GVL_Graficos.arrVarY3 = lstDblReturnReadFile[5].ToArray();

                #endregion

                #region Calculos

                if (_modelGVL.GVL_T03.bCalculaResultados)
                {
                    _modelGVL.GVL_T03 = HelperTestBase.Model_GVL.GVL_T03;

                    //Define o ponto maximo do array que foi plotado durante o teste
                    _modelGVL.GVL_Graficos.diBuffer = lstDblReturnReadFile[0].Count() > 0 ? lstDblReturnReadFile[0].Count() : 0;

                    diUbound = _modelGVL.GVL_Graficos.diBuffer; //Define o ponto maximo do array que foi plotado durante o teste

                    #region Loop para identificar a forca maxima do teste, e armazenar o ponto de inflexao do teste (quando o atuador comeca a retornar)
                    //========================================================================================================================================================

                    for (di = 0; di < diUbound; di++)
                    {
                        if (_modelGVL.GVL_Graficos.arrVarX[di] > _modelGVL.GVL_T03.rForcaMaxima)
                        {
                            _modelGVL.GVL_T03.rForcaMaxima = _modelGVL.GVL_Graficos.arrVarX[di]; //Atualiza o valor de forca maxima com o maior valor obtido no array
                            _modelGVL.GVL_T03.diPosicaoForcaMaxima = di; //Indica em qual posicao do array esta a forca maxima (pico do grafico, aonde comeca o retorno do atuador)
                        }
                    }

                    //========================================================================================================================================================
                    #endregion

                    #region Calculo do gradiente de aplicacao de força no avanço
                    //========================================================================================================================================================

                    //Busca no array o momento em que a forca comecou a subir (forca >= 100N) e o tempo decorrido desta forca
                    for (di = 0; di <= _modelGVL.GVL_T03.diPosicaoForcaMaxima; di++)
                    {
                        if (_modelGVL.GVL_Graficos.arrVarX[di] >= 100)//forca comecou a subir (>=100N)
                        {
                            rForcaInicialGradiente = _modelGVL.GVL_Graficos.arrVarX[di]; //Valor forca inicial para calculo 
                            rTempoInicialGradiente = _modelGVL.GVL_Graficos.arrVarTimeStamp[di]; //Valor to tempo em ms inicial para calculo

                            break; //Encerra a busca pela forca inicial
                        }
                    }

                    //Define a forca final e o tempo final do gradiente como a FMAX obtida no calculo anterior, utilizando seu indice para coletar o tempo respectivo
                    rForcaFinalGradiente = _modelGVL.GVL_Graficos.arrVarX[_modelGVL.GVL_T03.diPosicaoForcaMaxima];
                    rTempoFinalGradiente = _modelGVL.GVL_Graficos.arrVarTimeStamp[_modelGVL.GVL_T03.diPosicaoForcaMaxima];

                    //Calcula o gradiente de aplicacao de forca no avanco
                    _modelGVL.GVL_T03.rGradienteForcaAvanco = (rForcaFinalGradiente - rForcaInicialGradiente) / (rTempoFinalGradiente - rTempoInicialGradiente);
                    //========================================================================================================================================================

                    #endregion

                    #region Calculo do gradiente de aplicacao de força no retorno
                    //========================================================================================================================================================

                    //Busca no array o momento em que a forca caiu abaixo de 100N (forca <= 100N) e o tempo decorrido desta forca
                    for (di = _modelGVL.GVL_T03.diPosicaoForcaMaxima; di < diUbound; di++)
                    {
                        if (_modelGVL.GVL_Graficos.arrVarX[di] <= 100) //Forca proxima de 0 (<=100N)
                        {
                            rForcaFinalGradiente = _modelGVL.GVL_Graficos.arrVarX[di]; //Valor forca final para calculo 
                            rTempoFinalGradiente = _modelGVL.GVL_Graficos.arrVarTimeStamp[di]; //Valor to tempo em ms final para calculo

                            break; //Encerra a busca pela forca final
                        }
                    }

                    //Define a forca inicial e o tempo inicial do gradiente como a FMAX obtida no calculo anterior, utilizando seu indice para coletar o tempo respectivo
                    rForcaInicialGradiente = _modelGVL.GVL_Graficos.arrVarX[_modelGVL.GVL_T03.diPosicaoForcaMaxima];
                    rTempoInicialGradiente = _modelGVL.GVL_Graficos.arrVarTimeStamp[_modelGVL.GVL_T03.diPosicaoForcaMaxima];

                    //Calcula o gradiente de aplicacao de forca no retorno
                    _modelGVL.GVL_T03.rGradienteForcaRetorno = (rForcaFinalGradiente - rForcaInicialGradiente) / (rTempoFinalGradiente - rTempoInicialGradiente);
                    //========================================================================================================================================================
                    #endregion

                    #region Calculo do gradiente de avanço 
                    //========================================================================================================================================================

                    //Busca no array o momento em que o deslocamento comecou a variar (deslocamento >= 1)
                    for (di = 0; di <= _modelGVL.GVL_T03.diPosicaoForcaMaxima; di++)
                    {
                        if (_modelGVL.GVL_Graficos.arrVarY3[di] >= 1) //Deslocamento >= 1mm
                        {
                            rDeslocamentoInicialGradiente = _modelGVL.GVL_Graficos.arrVarY3[di]; //Valor deslocamento inicial para calculo 
                            rTempoInicialGradiente = _modelGVL.GVL_Graficos.arrVarTimeStamp[di]; //Valor to tempo em ms inicial para calculo

                            break; //Encerra a busca pelo deslocamento inicial
                        }
                    }

                    //Define a forca final e o tempo final do gradiente como a FMAX obtida no calculo anterior, utilizando seu indice para coletar o tempo respectivo
                    rDeslocamentoFinalGradiente = _modelGVL.GVL_Graficos.arrVarY3[_modelGVL.GVL_T03.diPosicaoForcaMaxima];
                    rTempoFinalGradiente = _modelGVL.GVL_Graficos.arrVarTimeStamp[_modelGVL.GVL_T03.diPosicaoForcaMaxima];

                    //Calcula o gradiente de aplicacao de forca no avanco
                    _modelGVL.GVL_T03.rGradienteDeslocamentoAvanco = (rDeslocamentoFinalGradiente - rDeslocamentoInicialGradiente) / (rTempoFinalGradiente - rTempoInicialGradiente);
                    //========================================================================================================================================================

                    #endregion

                    #region Calculo do gradiente de deslocamento no retorno

                    //========================================================================================================================================================

                    //Busca no array o momento em que o deslocamento <= 1
                    for (di = _modelGVL.GVL_T03.diPosicaoForcaMaxima; di < diUbound; di++)
                    {
                        if (_modelGVL.GVL_Graficos.arrVarY3[di] <= 1) //Deslocamento <= 1
                        {
                            rDeslocamentoFinalGradiente = _modelGVL.GVL_Graficos.arrVarY3[di]; //Deslocamento final para calculo 
                            rTempoFinalGradiente = _modelGVL.GVL_Graficos.arrVarTimeStamp[di]; //Valor to tempo em ms final para calculo

                            break; //Encerra a busca pelo deslocamento final
                        }
                    }


                    //Define o deslocamento inicial e o tempo inicial do gradiente como a FMAX obtida no calculo anterior, utilizando seu indice para coletar o tempo respectivo
                    rDeslocamentoInicialGradiente = _modelGVL.GVL_Graficos.arrVarY3[_modelGVL.GVL_T03.diPosicaoForcaMaxima];
                    rTempoInicialGradiente = _modelGVL.GVL_Graficos.arrVarTimeStamp[_modelGVL.GVL_T03.diPosicaoForcaMaxima];

                    //Calcula o gradiente de aplicacao de forca no retorno
                    _modelGVL.GVL_T03.rGradienteDeslocamentoRetorno = (rDeslocamentoFinalGradiente - rDeslocamentoInicialGradiente) / (rTempoFinalGradiente - rTempoInicialGradiente);
                    //========================================================================================================================================================

                    #endregion

                    #region Pega os valores de pressão no cruzamento com as forças solicitadas: P1

                    //========================================================================================================================================================

                    for (di = 0; di < diUbound; di++)
                    {
                        if (_modelGVL.GVL_Graficos.arrVarX[di] >= _modelGVL.GVL_T03.rForca_P1) //Encontrou a forca >= parametro definido
                        {
                            _modelGVL.GVL_T03.rForcaReal_P1_N = _modelGVL.GVL_Graficos.arrVarX[di]; //Armazena o valor real encontrado (>=)
                            _modelGVL.GVL_T03.rPressao_P1_Bar = _modelGVL.GVL_Graficos.arrVarY1[di]; //Armazena a pressao correspondente encontrada

                            break; //Encerra a busca
                        }
                    }

                    #region Gera o ponto (X) no grafico

                    //_modelGVL.GVL_Graficos.arrVarXPoint1[0] = _modelGVL.GVL_T03.rForcaReal_P1_N;
                    //_modelGVL.GVL_Graficos.arrVarYPoint1[0] = _modelGVL.GVL_T03.rPressao_P1_Bar;

                    #endregion

                    #endregion

                    #region Pega os valores de pressão no cruzamento com as forças solicitadas: P2

                    for (di = 0; di < diUbound; di++)
                    {
                        if (_modelGVL.GVL_Graficos.arrVarX[di] >= _modelGVL.GVL_T03.rForca_P2) //Encontrou a forca >= parametro definido
                        {
                            _modelGVL.GVL_T03.rForcaReal_P2_N = _modelGVL.GVL_Graficos.arrVarX[di]; //Armazena o valor real encontrado (>=)
                            _modelGVL.GVL_T03.rPressao_P2_Bar = _modelGVL.GVL_Graficos.arrVarY1[di]; //Armazena a pressao correspondente encontrada

                            diIndice_P2 = di; //Armazena o Indice de P2 para o calculo posterior, runoutpoint

                            break; //Encerra a busca
                        }
                    }

                    #region Gera o ponto (X) no grafico

                    //_modelGVL.GVL_Graficos.arrVarXPoint1[1] = _modelGVL.GVL_T03.rForcaReal_P2_N;
                    //_modelGVL.GVL_Graficos.arrVarYPoint1[1] = _modelGVL.GVL_T03.rPressao_P2_Bar;

                    #endregion

                    #endregion

                    #region Pega os valores de pressão no cruzamento com as forças solicitadas: E1

                    for (di = 0; di < diUbound; di++)
                    {
                        if (_modelGVL.GVL_Graficos.arrVarX[di] >= _modelGVL.GVL_T03.rForca_E1) //Encontrou a forca >= parametro definido
                        {
                            _modelGVL.GVL_T03.rForcaReal_E1_N = _modelGVL.GVL_Graficos.arrVarX[di]; //Armazena o valor real encontrado (>=)
                            _modelGVL.GVL_T03.rPressao_E1_Bar = _modelGVL.GVL_Graficos.arrVarY1[di]; //Armazena a pressao correspondente encontrada

                            break; //Encerra a busca
                        }
                    }

                    #region Gera o ponto (X) no grafico

                    //_modelGVL.GVL_Graficos.arrVarXPoint1[2] = _modelGVL.GVL_T03.rForcaReal_E1_N;
                    //_modelGVL.GVL_Graficos.arrVarYPoint1[2] = _modelGVL.GVL_T03.rPressao_E1_Bar;

                    #endregion

                    #endregion

                    #region Pega os valores de pressão no cruzamento com as forças solicitadas: E2

                    for (di = 0; di < diUbound; di++)
                    {
                        if (_modelGVL.GVL_Graficos.arrVarX[di] >= _modelGVL.GVL_T03.rForca_E2) //Encontrou a forca >= parametro definido
                        {
                            _modelGVL.GVL_T03.rForcaReal_E2_N = _modelGVL.GVL_Graficos.arrVarX[di]; //Armazena o valor real encontrado (>=)
                            _modelGVL.GVL_T03.rPressao_E2_Bar = _modelGVL.GVL_Graficos.arrVarY1[di]; //Armazena a pressao correspondente encontrada

                            break; //Encerra a busca
                        }
                    }

                    #region Gera o ponto (X) no grafico

                    //_modelGVL.GVL_Graficos.arrVarXPoint1[3] = _modelGVL.GVL_T03.rForcaReal_E2_N;
                    //_modelGVL.GVL_Graficos.arrVarYPoint1[3] = _modelGVL.GVL_T03.rPressao_E2_Bar;

                    #endregion

                    //========================================================================================================================================================
                    #endregion

                    #region Calcula a forca Cut IN

                    //========================================================================================================================================================

                    for (di = 0; di <= _modelGVL.GVL_T03.diPosicaoForcaMaxima; di++)
                    {
                        if (_modelGVL.GVL_Graficos.arrVarY1[di] >= _modelGVL.GVL_T03.rPressaoCutIn_Bar)  //Pressao de cut in
                        {
                            _modelGVL.GVL_T03.rForcaCutIn_N = _modelGVL.GVL_Graficos.arrVarX[di]; //Valor da forca obtida na pressao de cut in

                            break; //Encerra a busca
                        }
                    }

                    //========================================================================================================================================================

                    #endregion

                    #region Calcula a release force

                    //========================================================================================================================================================
                    //Release force é o pico de força no retorno encontrado na tabela de pontos, entre os parametros release force min/ release force max.

                    //Encontra o indice do release force max (como é decrescente, max primeiro, min depois na tabela)
                    for (di = _modelGVL.GVL_T03.diPosicaoForcaMaxima; di < diUbound; di++)
                    {
                        if (_modelGVL.GVL_Graficos.arrVarY1[di] <= _modelGVL.GVL_T03.rReleaseForcePressMax_Bar)
                        {
                            diIndice_ReleaseMax = di; //Indice aonde esta a pressao maxima para avaliar o pico de forca no retorno 

                            break; //Encerra a busca
                        }
                    }

                    //Encontra o indice do release force min (como é decrescente, max primeiro, min depois na tabela)
                    for (di = diIndice_ReleaseMax; di < diUbound; di++)
                    {
                        if (_modelGVL.GVL_Graficos.arrVarY1[di] <= _modelGVL.GVL_T03.rReleaseForcePressMin_Bar)
                        {
                            diIndice_ReleaseMin = di; //Indice aonde esta a pressao minima para avaliar o pico de forca no retorno 

                            break; //Encerra a busca
                        }
                    }


                    //Encontra o pico de forca entre Max e Min
                    for (di = diIndice_ReleaseMax; di <= diIndice_ReleaseMin; di++)
                    {
                        if (_modelGVL.GVL_Graficos.arrVarX[di] > _modelGVL.GVL_T03.rReleaseForce_N)
                        {
                            _modelGVL.GVL_T03.rReleaseForce_N = _modelGVL.GVL_Graficos.arrVarX[di]; //Pico de forca entre as pressoes definidas no retorno                     
                        }
                    }

                    //Encontra o pico de forca no deslocamento de retorno definido
                    for (di = _modelGVL.GVL_T03.diPosicaoForcaMaxima; di <= diUbound; di++)
                    {
                        if (_modelGVL.GVL_Graficos.arrVarY3[di] <= _modelGVL.GVL_T03.rReleaseForceAt_mm) // Deslocamento no ponto <= o valor definido no parametro
                        {
                            _modelGVL.GVL_T03.rReleaseForceAt_N = _modelGVL.GVL_Graficos.arrVarX[di]; //Forca Obtida no ponto de retorno
                            _modelGVL.GVL_T03.rReleaseForceAtReal_mm = _modelGVL.GVL_Graficos.arrVarY3[di]; //Valor de deslocamento real obtido

                            break; //Encerra a busca
                        }
                    }

                    //========================================================================================================================================================

                    #endregion

                    #region Calculo dos Consumidores Utilizados

                    //========================================================================================================================================================

                    _modelGVL.GVL_T03.iConsumidoresCP = 0;
                    _modelGVL.GVL_T03.iConsumidoresCS = 0;

                    HelperTestBase.Model_GVL.GVL_Parametros.iTipoConsumidores = HelperMODBUS.CS_wTipoConsumidores;

                    if (HelperMODBUS.CS_wTipoConsumidores != 2)
                    {
                        _modelGVL.GVL_T03.iConsumidoresCP = 0;
                        _modelGVL.GVL_T03.iConsumidoresCS = 0;
                    }
                    else
                    {
                        //HelperMODBUS.CS_wStatusLiga17MangueirasCS 
                        if (HelperMODBUS.CS_wStatusLiga1MangueiraCP)
                            _modelGVL.GVL_T03.iConsumidoresCP = _modelGVL.GVL_T03.iConsumidoresCP + 1;

                        if (HelperMODBUS.CS_wStatusLiga2MangueirasCP)
                            _modelGVL.GVL_T03.iConsumidoresCP = _modelGVL.GVL_T03.iConsumidoresCP + 2;

                        if (HelperMODBUS.CS_wStatusLiga4MangueirasCP)
                            _modelGVL.GVL_T03.iConsumidoresCP = _modelGVL.GVL_T03.iConsumidoresCP + 4;

                        if (HelperMODBUS.CS_wStatusLiga8MangueirasCP)
                            _modelGVL.GVL_T03.iConsumidoresCP = _modelGVL.GVL_T03.iConsumidoresCP + 8;

                        if (HelperMODBUS.CS_wStatusLiga10MangueirasCP)
                            _modelGVL.GVL_T03.iConsumidoresCP = _modelGVL.GVL_T03.iConsumidoresCP + 10;

                        if (HelperMODBUS.CS_wStatusLiga17MangueirasCP)
                            _modelGVL.GVL_T03.iConsumidoresCP = _modelGVL.GVL_T03.iConsumidoresCP + 17;

                        if (HelperMODBUS.CS_wStatusLiga1MangueiraCS)
                            _modelGVL.GVL_T03.iConsumidoresCS = _modelGVL.GVL_T03.iConsumidoresCS + 1;

                        if (HelperMODBUS.CS_wStatusLiga2MangueirasCS)
                            _modelGVL.GVL_T03.iConsumidoresCS = _modelGVL.GVL_T03.iConsumidoresCS + 2;

                        if (HelperMODBUS.CS_wStatusLiga4MangueirasCS)
                            _modelGVL.GVL_T03.iConsumidoresCS = _modelGVL.GVL_T03.iConsumidoresCS + 4;

                        if (HelperMODBUS.CS_wStatusLiga8MangueirasCS)
                            _modelGVL.GVL_T03.iConsumidoresCS = _modelGVL.GVL_T03.iConsumidoresCS + 8;

                        if (HelperMODBUS.CS_wStatusLiga10MangueirasCS)
                            _modelGVL.GVL_T03.iConsumidoresCS = _modelGVL.GVL_T03.iConsumidoresCS + 10;

                        if (HelperMODBUS.CS_wStatusLiga17MangueirasCS)
                            _modelGVL.GVL_T03.iConsumidoresCS = _modelGVL.GVL_T03.iConsumidoresCS + 17;
                    }
                    //============================. ============================================================================================================================

                    #endregion

                    _modelGVL.GVL_T03.bCalculaResultados = false;

                    _modelGVL.GVL_Graficos.bDadosCalculados = true;
                }

                HelperTestBase.Model_GVL.helperTestBase_ModelGVL_Test = HelperTestBase.Model_GVL.GVL_T03;

                HelperTestBase.Model_GVL = _modelGVL;

                #endregion

            }
            catch (Exception ex)
            {
                var err = ex.Message;
                throw;
            }

            return _modelGVL;

            #endregion
        }


        #endregion

        #region T04 - Calculos Forca Forca - ET_ForceDiagrams_ForceForce_WithoutVacuum
        public Model_GVL CalcGraphT04_ET_ForceDiagrams_ForceForce_WithoutVacuum(bool bCalculaResultados, List<double>[] lstDblReturnReadFile)
        {
            #region PROGRAM T04_Calculos_Resultados

            try
            {
                #region Limpa ultimos resultados

                dictVarList.Clear();

                _modelGVL.GVL_T04.rForcaReal_P1_N = 0;
                _modelGVL.GVL_T04.rForcaOut_P1_N = 0;
                _modelGVL.GVL_T04.rForcaReal_P2_N = 0;
                _modelGVL.GVL_T04.rForcaOut_P2_N = 0;
                _modelGVL.GVL_T04.rForcaReal_E1_N = 0;
                _modelGVL.GVL_T04.rForcaOut_E1_N = 0;
                _modelGVL.GVL_T04.rForcaReal_E2_N = 0;
                _modelGVL.GVL_T04.rForcaOut_E2_N = 0;
                _modelGVL.GVL_T04.rForcaMaxima = 0; //Zera o ultimo valor de força obtido
                _modelGVL.GVL_T04.rGradienteForcaAvanco = 0; //Zera o ultimo valor obtido
                _modelGVL.GVL_T04.rGradienteForcaRetorno = 0; //Zera o ultimo valor obtido
                _modelGVL.GVL_T04.rGradienteDeslocamentoAvanco = 0; //Zera o ultimo valor obtido
                _modelGVL.GVL_T04.rGradienteDeslocamentoRetorno = 0; //Zera o ultimo valor obtido
                _modelGVL.GVL_T04.rDeslocamentoNaForca_mm = 0;
                _modelGVL.GVL_T04.rForcaOut_P5_N = 0;
                _modelGVL.GVL_T04.rForca_F5_N = 0;
                _modelGVL.GVL_T04.rForcaOut_P6_N = 0;
                _modelGVL.GVL_T04.rForca_F6_N = 0;
                _modelGVL.GVL_T04.rForcaCutIn_N = 0;
                _modelGVL.GVL_T04.rForcaOutJumper_N = 0;
                _modelGVL.GVL_T04.rGradientJumper = 0;
                _modelGVL.GVL_T04.rReleaseForce_N = 0;
                _modelGVL.GVL_T04.rReleaseForceAt_N = 0;
                _modelGVL.GVL_T04.rReleaseForceAtReal_mm = 0;

                _modelGVL.GVL_T04.bCalculaResultados = bCalculaResultados;

                #region VARIABLES

                long diUbound = 0; //  ; DINT;
                long di = 0; //  ; DINT;
                double rForcaInicialGradiente = 0; //  ; REAL;
                double rForcaFinalGradiente = 0; //  ; REAL;
                double rDeslocamentoInicialGradiente = 0; //   ; REAL;
                double rDeslocamentoFinalGradiente = 0; //  ; REAL;
                double rTempoInicialGradiente = 0; //  ; REAL;
                double rTempoFinalGradiente = 0; //   ; REAL;

                long diIndice_P2 = 0; //   = 0; DINT = 0;
                long diIndice_ReleaseMax = 0; //   = 0; DINT = 0;
                long diIndice_ReleaseMin = 0; //   = 0; DINT = 0;

                #endregion

                #endregion

                #region Variaveis Grafico

                _modelGVL.GVL_Graficos.rEscalaX = 1500;
                _modelGVL.GVL_Graficos.EixoX.wsTLLabel = "AxesChart.1";
                _modelGVL.GVL_Graficos.rEscalaY1 = 4000;
                _modelGVL.GVL_Graficos.EixoY1.wsTLLabel = "AxesChart.3";
                _modelGVL.GVL_Graficos.rEscalaY2 = 0;
                _modelGVL.GVL_Graficos.EixoY2.wsTLLabel = string.Empty;
                _modelGVL.GVL_Graficos.rEscalaY3 = 0;
                _modelGVL.GVL_Graficos.EixoY3.wsTLLabel = string.Empty;
                _modelGVL.GVL_Graficos.rEscalaY4 = 0;
                _modelGVL.GVL_Graficos.EixoY4.wsTLLabel = string.Empty;

                _modelGVL.GVL_Graficos.strNomeEixoX = "Input Force (N)";
                _modelGVL.GVL_Graficos.strNomeEixoY1 = "Output Force (N)";
                _modelGVL.GVL_Graficos.strNomeEixoY2 = string.Empty;
                _modelGVL.GVL_Graficos.strNomeEixoY3 = string.Empty;
                _modelGVL.GVL_Graficos.strNomeEixoY4 = string.Empty;

                _modelGVL.GVL_Graficos.strUnidadeX = "N";
                _modelGVL.GVL_Graficos.strUnidadeY1 = "N";
                _modelGVL.GVL_Graficos.strUnidadeY2 = string.Empty;
                _modelGVL.GVL_Graficos.strUnidadeY3 = string.Empty;
                _modelGVL.GVL_Graficos.strUnidadeY4 = string.Empty;

                _modelGVL.GVL_Graficos.bOcultaY2 = true;
                _modelGVL.GVL_Graficos.bOcultaY3 = true;
                _modelGVL.GVL_Graficos.bOcultaY4 = true;

                #endregion

                #region Varriaveis Array Dados

                //os arrays dinamicos obtidos neste teste contem as seguintes grandezas:
                //GVL_Graficos.arrVarX = Valores Forca Entrada
                //GVL_Graficos.arrVarY1 = Valores Forca Saida
                //GVL_Graficos.arrVarY2 = 
                //GVL_Graficos.arrVarY3 = Valores Deslocamento Pistao (Entrada)

                ClearArrayGVL_Graficos();

                _modelGVL.GVL_Graficos.arrVarTimeStamp = lstDblReturnReadFile[0].ToArray();
                _modelGVL.GVL_Graficos.arrVarX = lstDblReturnReadFile[2].ToArray();
                _modelGVL.GVL_Graficos.arrVarY1 = lstDblReturnReadFile[3].ToArray();
                //_modelGVL.GVL_Graficos.arrVarY2 = lstDblReturnReadFile[6].ToArray();
                _modelGVL.GVL_Graficos.arrVarY3 = lstDblReturnReadFile[5].ToArray();

                #endregion

                #region Calculos

                if (_modelGVL.GVL_T04.bCalculaResultados)
                {
                    _modelGVL.GVL_T04 = HelperTestBase.Model_GVL.GVL_T04;

                    //Define o ponto maximo do array que foi plotado durante o teste
                    _modelGVL.GVL_Graficos.diBuffer = lstDblReturnReadFile[0].Count() > 0 ? lstDblReturnReadFile[0].Count() : 0;

                    diUbound = _modelGVL.GVL_Graficos.diBuffer; //Define o ponto maximo do array que foi plotado durante o teste

                    #region Loop para identificar a forca maxima do teste, e armazenar o ponto de inflexao do teste (quando o atuador comeca a retornar)
                    //========================================================================================================================================================

                    for (di = 0; di < diUbound; di++)
                    {
                        if (_modelGVL.GVL_Graficos.arrVarX[di] > _modelGVL.GVL_T04.rForcaMaxima)
                        {
                            _modelGVL.GVL_T04.rForcaMaxima = _modelGVL.GVL_Graficos.arrVarX[di]; //Atualiza o valor de forca maxima com o maior valor obtido no array
                            _modelGVL.GVL_T04.diPosicaoForcaMaxima = di; //Indica em qual posicao do array esta a forca maxima (pico do grafico, aonde comeca o retorno do atuador)
                        }
                    }

                    //========================================================================================================================================================
                    #endregion

                    #region Calculo do gradiente de aplicacao de força no avanço
                    //========================================================================================================================================================

                    //Busca no array o momento em que a forca comecou a subir (forca >= 100N) e o tempo decorrido desta forca
                    for (di = 0; di <= _modelGVL.GVL_T04.diPosicaoForcaMaxima; di++)
                    {
                        if (_modelGVL.GVL_Graficos.arrVarX[di] >= 100)//forca comecou a subir (>=100N)
                        {
                            rForcaInicialGradiente = _modelGVL.GVL_Graficos.arrVarX[di]; //Valor forca inicial para calculo 
                            rTempoInicialGradiente = _modelGVL.GVL_Graficos.arrVarTimeStamp[di]; //Valor to tempo em ms inicial para calculo

                            break; //Encerra a busca pela forca inicial
                        }
                    }

                    //Define a forca final e o tempo final do gradiente como a FMAX obtida no calculo anterior, utilizando seu indice para coletar o tempo respectivo
                    rForcaFinalGradiente = _modelGVL.GVL_Graficos.arrVarX[_modelGVL.GVL_T04.diPosicaoForcaMaxima];
                    rTempoFinalGradiente = _modelGVL.GVL_Graficos.arrVarTimeStamp[_modelGVL.GVL_T04.diPosicaoForcaMaxima];

                    //Calcula o gradiente de aplicacao de forca no avanco
                    _modelGVL.GVL_T04.rGradienteForcaAvanco = (rForcaFinalGradiente - rForcaInicialGradiente) / (rTempoFinalGradiente - rTempoInicialGradiente);
                    //========================================================================================================================================================

                    #endregion

                    #region Calculo do gradiente de aplicacao de força no retorno
                    //========================================================================================================================================================

                    //Busca no array o momento em que a forca caiu abaixo de 100N (forca <= 100N) e o tempo decorrido desta forca
                    for (di = _modelGVL.GVL_T04.diPosicaoForcaMaxima; di < diUbound; di++)
                    {
                        if (_modelGVL.GVL_Graficos.arrVarX[di] <= 100) //Forca proxima de 0 (<=100N)
                        {
                            rForcaFinalGradiente = _modelGVL.GVL_Graficos.arrVarX[di]; //Valor forca final para calculo 
                            rTempoFinalGradiente = _modelGVL.GVL_Graficos.arrVarTimeStamp[di]; //Valor to tempo em ms final para calculo

                            break; //Encerra a busca pela forca final
                        }
                    }

                    //Define a forca inicial e o tempo inicial do gradiente como a FMAX obtida no calculo anterior, utilizando seu indice para coletar o tempo respectivo
                    rForcaInicialGradiente = _modelGVL.GVL_Graficos.arrVarX[_modelGVL.GVL_T04.diPosicaoForcaMaxima];
                    rTempoInicialGradiente = _modelGVL.GVL_Graficos.arrVarTimeStamp[_modelGVL.GVL_T04.diPosicaoForcaMaxima];

                    //Calcula o gradiente de aplicacao de forca no retorno
                    _modelGVL.GVL_T04.rGradienteForcaRetorno = (rForcaFinalGradiente - rForcaInicialGradiente) / (rTempoFinalGradiente - rTempoInicialGradiente);
                    //========================================================================================================================================================
                    #endregion

                    #region Calculo do gradiente deslocamento de avanço 
                    //========================================================================================================================================================

                    //Busca no array o momento em que o deslocamento comecou a variar (deslocamento >= 1)
                    for (di = 0; di <= _modelGVL.GVL_T04.diPosicaoForcaMaxima; di++)
                    {
                        if (_modelGVL.GVL_Graficos.arrVarY3[di] >= 1) //Deslocamento >= 1mm
                        {
                            rDeslocamentoInicialGradiente = _modelGVL.GVL_Graficos.arrVarY3[di]; //Valor deslocamento inicial para calculo 
                            rTempoInicialGradiente = _modelGVL.GVL_Graficos.arrVarTimeStamp[di]; //Valor to tempo em ms inicial para calculo

                            break; //Encerra a busca pelo deslocamento inicial
                        }
                    }

                    //Define a forca final e o tempo final do gradiente como a FMAX obtida no calculo anterior, utilizando seu indice para coletar o tempo respectivo
                    rDeslocamentoFinalGradiente = _modelGVL.GVL_Graficos.arrVarY3[_modelGVL.GVL_T04.diPosicaoForcaMaxima];
                    rTempoFinalGradiente = _modelGVL.GVL_Graficos.arrVarTimeStamp[_modelGVL.GVL_T04.diPosicaoForcaMaxima];

                    //Calcula o gradiente de aplicacao de forca no avanco
                    _modelGVL.GVL_T04.rGradienteDeslocamentoAvanco = (rDeslocamentoFinalGradiente - rDeslocamentoInicialGradiente) / (rTempoFinalGradiente - rTempoInicialGradiente);
                    //========================================================================================================================================================

                    #endregion

                    #region Calculo do gradiente de deslocamento no retorno

                    //========================================================================================================================================================

                    //Busca no array o momento em que o deslocamento <= 1
                    for (di = _modelGVL.GVL_T04.diPosicaoForcaMaxima; di < diUbound; di++)
                    {
                        if (_modelGVL.GVL_Graficos.arrVarY3[di] <= 1) //Deslocamento <= 1
                        {
                            rDeslocamentoFinalGradiente = _modelGVL.GVL_Graficos.arrVarY3[di]; //Deslocamento final para calculo 
                            rTempoFinalGradiente = _modelGVL.GVL_Graficos.arrVarTimeStamp[di]; //Valor to tempo em ms final para calculo

                            break; //Encerra a busca pelo deslocamento final
                        }
                    }


                    //Define o deslocamento inicial e o tempo inicial do gradiente como a FMAX obtida no calculo anterior, utilizando seu indice para coletar o tempo respectivo
                    rDeslocamentoInicialGradiente = _modelGVL.GVL_Graficos.arrVarY3[_modelGVL.GVL_T04.diPosicaoForcaMaxima];
                    rTempoInicialGradiente = _modelGVL.GVL_Graficos.arrVarTimeStamp[_modelGVL.GVL_T04.diPosicaoForcaMaxima];

                    //Calcula o gradiente de aplicacao de forca no retorno
                    _modelGVL.GVL_T04.rGradienteDeslocamentoRetorno = (rDeslocamentoFinalGradiente - rDeslocamentoInicialGradiente) / (rTempoFinalGradiente - rTempoInicialGradiente);
                    //========================================================================================================================================================

                    #endregion

                    #region Pega os valores de pressão no cruzamento com as forças solicitadas: P1

                    //========================================================================================================================================================

                    for (di = 0; di < diUbound; di++)
                    {
                        if (_modelGVL.GVL_Graficos.arrVarX[di] >= _modelGVL.GVL_T04.rForca_P1) //Encontrou a forca >= parametro definido
                        {
                            _modelGVL.GVL_T04.rForcaReal_P1_N = _modelGVL.GVL_Graficos.arrVarX[di]; //Armazena o valor real encontrado (>=)
                            _modelGVL.GVL_T04.rForcaOut_P1_N = _modelGVL.GVL_Graficos.arrVarY1[di]; //Armazena a ForcaFOut correspondente encontrada

                            break; //Encerra a busca
                        }
                    }

                    #region Gera o ponto (X) no grafico

                    //_modelGVL.GVL_Graficos.arrVarXPoint1[0] = _modelGVL.GVL_T04.rForcaReal_P1_N;
                    //_modelGVL.GVL_Graficos.arrVarYPoint1[0] = _modelGVL.GVL_T04.rForcaOut_P1_N;

                    #endregion

                    #endregion

                    #region Pega os valores de pressão no cruzamento com as forças solicitadas: P2

                    for (di = 0; di < diUbound; di++)
                    {
                        if (_modelGVL.GVL_Graficos.arrVarX[di] >= _modelGVL.GVL_T04.rForca_P2) //Encontrou a forca >= parametro definido
                        {
                            _modelGVL.GVL_T04.rForcaReal_P2_N = _modelGVL.GVL_Graficos.arrVarX[di]; //Armazena o valor real encontrado (>=)
                            _modelGVL.GVL_T04.rForcaOut_P2_N = _modelGVL.GVL_Graficos.arrVarY1[di]; //Armazena a ForcaFOut correspondente encontrada

                            diIndice_P2 = di; //Armazena o Indice de P2 para o calculo posterior, runoutpoint

                            break; //Encerra a busca
                        }
                    }

                    #region Gera o ponto (X) no grafico

                    //_modelGVL.GVL_Graficos.arrVarXPoint1[1] = _modelGVL.GVL_T04.rForcaReal_P2_N;
                    //_modelGVL.GVL_Graficos.arrVarYPoint1[1] = _modelGVL.GVL_T04.rForcaOut_P2_N;

                    #endregion

                    #endregion

                    #region Pega os valores de pressão no cruzamento com as forças solicitadas: E1

                    for (di = 0; di < diUbound; di++)
                    {
                        if (_modelGVL.GVL_Graficos.arrVarX[di] >= _modelGVL.GVL_T04.rForca_E1) //Encontrou a forca >= parametro definido
                        {
                            _modelGVL.GVL_T04.rForcaReal_E1_N = _modelGVL.GVL_Graficos.arrVarX[di]; //Armazena o valor real encontrado (>=)
                            _modelGVL.GVL_T04.rForcaOut_E1_N = _modelGVL.GVL_Graficos.arrVarY1[di]; //Armazena a ForcaFOut correspondente encontrada

                            break; //Encerra a busca
                        }
                    }

                    #region Gera o ponto (X) no grafico

                    //_modelGVL.GVL_Graficos.arrVarXPoint1[2] = _modelGVL.GVL_T04.rForcaReal_E1_N;
                    //_modelGVL.GVL_Graficos.arrVarYPoint1[2] = _modelGVL.GVL_T04.rForcaOut_E1_N;

                    #endregion

                    #endregion

                    #region Pega os valores de pressão no cruzamento com as forças solicitadas: E2

                    for (di = 0; di < diUbound; di++)
                    {
                        if (_modelGVL.GVL_Graficos.arrVarX[di] >= _modelGVL.GVL_T04.rForca_E2) //Encontrou a forca >= parametro definido
                        {
                            _modelGVL.GVL_T04.rForcaReal_E2_N = _modelGVL.GVL_Graficos.arrVarX[di]; //Armazena o valor real encontrado (>=)
                            _modelGVL.GVL_T04.rForcaOut_E2_N = _modelGVL.GVL_Graficos.arrVarY1[di]; //Armazena a ForcaFOut correspondente encontrada

                            break; //Encerra a busca
                        }
                    }

                    #region Gera o ponto (X) no grafico

                    //_modelGVL.GVL_Graficos.arrVarXPoint1[3] = _modelGVL.GVL_T04.rForcaReal_E2_N;
                    //_modelGVL.GVL_Graficos.arrVarYPoint1[3] = _modelGVL.GVL_T04.rForcaOut_E2_N;

                    #endregion

                    //========================================================================================================================================================
                    #endregion

                    #region Calcula a forca Cut IN

                    //========================================================================================================================================================

                    for (di = 0; di <= _modelGVL.GVL_T04.diPosicaoForcaMaxima; di++)
                    {
                        if (_modelGVL.GVL_Graficos.arrVarY1[di] >= _modelGVL.GVL_T04.rForcaCutIn_N)  //ForcaFOut de cut in
                        {
                            _modelGVL.GVL_T04.rForcaCutIn_N = _modelGVL.GVL_Graficos.arrVarX[di]; //Valor da forca obtida na forca Out de cut in

                            break; //Encerra a busca
                        }
                    }

                    //========================================================================================================================================================

                    #endregion

                    #region Calcula a release force

                    //========================================================================================================================================================
                    //Release force é o pico de força no retorno encontrado na tabela de pontos, entre os parametros release force min/ release force max.

                    //Encontra o indice do release force max (como é decrescente, max primeiro, min depois na tabela)
                    for (di = _modelGVL.GVL_T04.diPosicaoForcaMaxima; di < diUbound; di++)
                    {
                        if (_modelGVL.GVL_Graficos.arrVarY1[di] <= _modelGVL.GVL_T04.rReleaseForceFoutMax_N)
                        {
                            diIndice_ReleaseMax = di; //Indice aonde esta a pressao maxima para avaliar o pico de forca no retorno 

                            break; //Encerra a busca
                        }
                    }

                    //Encontra o indice do release force min (como é decrescente, max primeiro, min depois na tabela)
                    for (di = diIndice_ReleaseMax; di < diUbound; di++)
                    {
                        if (_modelGVL.GVL_Graficos.arrVarY1[di] <= _modelGVL.GVL_T04.rReleaseForceFoutMin_N)
                        {
                            diIndice_ReleaseMin = di; //Indice aonde esta a pressao minima para avaliar o pico de forca no retorno 

                            break; //Encerra a busca
                        }
                    }


                    //Encontra o pico de forca entre Max e Min
                    for (di = diIndice_ReleaseMax; di <= diIndice_ReleaseMin; di++)
                    {
                        if (_modelGVL.GVL_Graficos.arrVarX[di] > _modelGVL.GVL_T04.rReleaseForce_N)
                        {
                            _modelGVL.GVL_T04.rReleaseForce_N = _modelGVL.GVL_Graficos.arrVarX[di]; //Pico de forca entre as pressoes definidas no retorno                     
                        }
                    }

                    //Encontra o pico de forca no deslocamento de retorno definido
                    for (di = _modelGVL.GVL_T04.diPosicaoForcaMaxima; di <= diUbound; di++)
                    {
                        if (_modelGVL.GVL_Graficos.arrVarY3[di] <= _modelGVL.GVL_T04.rReleaseForceAt_mm) // Deslocamento no ponto <= o valor definido no parametro
                        {
                            _modelGVL.GVL_T04.rReleaseForceAt_N = _modelGVL.GVL_Graficos.arrVarX[di]; //Forca Obtida no ponto de retorno
                            _modelGVL.GVL_T04.rReleaseForceAtReal_mm = _modelGVL.GVL_Graficos.arrVarY3[di]; //Valor de deslocamento real obtido

                            break; //Encerra a busca
                        }
                    }

                    //========================================================================================================================================================

                    #endregion

                    _modelGVL.GVL_T04.bCalculaResultados = false;

                    _modelGVL.GVL_Graficos.bDadosCalculados = true;
                }

                HelperTestBase.Model_GVL.helperTestBase_ModelGVL_Test = HelperTestBase.Model_GVL.GVL_T04;

                HelperTestBase.Model_GVL = _modelGVL;

                #endregion

            }
            catch (Exception ex)
            {
                var err = ex.Message;
                throw;
            }

            return _modelGVL;

            #endregion
        }


        #endregion

        #region T05 - Calculos Vazamento Vacuo - ET_VacuumLeakage_ReleasedPosition
        public Model_GVL CalcGraphT05_ET_VacuumLeakage_ReleasedPosition(bool bCalculaResultados, List<double>[] lstDblReturnReadFile)
        {
            #region PROGRAM T05_Calculos_Resultados

            try
            {
                #region Limpa ultimos resultados

                dictVarList.Clear();

                _modelGVL.GVL_T05.rPerdaVacuo = 0;
                _modelGVL.GVL_T05.rTempoTotal = 0;

                _modelGVL.GVL_T05.bCalculaResultados = bCalculaResultados;

                #region VARIABLES

                long diUbound = 0; //  ; DINT;
                long di = 0; //  ; DINT;

                #endregion

                #endregion

                #region Variaveis Grafico

                _modelGVL.GVL_Graficos.rEscalaX = 30;
                _modelGVL.GVL_Graficos.EixoX.wsTLLabel = "AxesChart.1";
                _modelGVL.GVL_Graficos.rEscalaY1 = -1;
                _modelGVL.GVL_Graficos.EixoY1.wsTLLabel = "AxesChart.7";
                _modelGVL.GVL_Graficos.rEscalaY2 = 0;
                _modelGVL.GVL_Graficos.EixoY2.wsTLLabel = string.Empty;
                _modelGVL.GVL_Graficos.rEscalaY3 = 0;
                _modelGVL.GVL_Graficos.EixoY3.wsTLLabel = string.Empty;
                _modelGVL.GVL_Graficos.rEscalaY4 = 0;
                _modelGVL.GVL_Graficos.EixoY4.wsTLLabel = string.Empty;

                _modelGVL.GVL_Graficos.strNomeEixoX = "Time (s)";
                _modelGVL.GVL_Graficos.strNomeEixoY1 = "Vacuum (bar)";
                _modelGVL.GVL_Graficos.strNomeEixoY2 = string.Empty;
                _modelGVL.GVL_Graficos.strNomeEixoY3 = string.Empty;
                _modelGVL.GVL_Graficos.strNomeEixoY4 = string.Empty;

                _modelGVL.GVL_Graficos.strUnidadeX = "s";
                _modelGVL.GVL_Graficos.strUnidadeY1 = "bar";
                _modelGVL.GVL_Graficos.strUnidadeY2 = string.Empty;
                _modelGVL.GVL_Graficos.strUnidadeY3 = string.Empty;
                _modelGVL.GVL_Graficos.strUnidadeY4 = string.Empty;

                _modelGVL.GVL_Graficos.bOcultaY2 = true;
                _modelGVL.GVL_Graficos.bOcultaY3 = true;
                _modelGVL.GVL_Graficos.bOcultaY4 = true;

                #endregion

                #region Varriaveis Array Dados

                //os arrays dinamicos obtidos neste teste contem as seguintes grandezas:
                //GVL_Graficos.arrVarX = Tempo (ms)
                //GVL_Graficos.arrVarY1 = Vacuo (bar)

                //lstStrChReadFileArr[0] = lstStrTimestamp;       //Time [s]
                //lstStrChReadFileArr[1] = lstStrAnalogVarY01;    //Input Force 1 [N]
                //lstStrChReadFileArr[2] = lstStrAnalogVarY02;    //Input Travel [m]
                //lstStrChReadFileArr[3] = lstStrAnalogVarY03;    //Hydraulic Pressure PC [bar]
                //lstStrChReadFileArr[4] = lstStrAnalogVarY04;    //Hydraulic Pressure SC [bar]

                ClearArrayGVL_Graficos();

                _modelGVL.GVL_Graficos.arrVarTimeStamp = lstDblReturnReadFile[0].ToArray();
                _modelGVL.GVL_Graficos.arrVarX = lstDblReturnReadFile[0].ToArray();
                _modelGVL.GVL_Graficos.arrVarY1 = lstDblReturnReadFile[10].ToArray();

                #endregion

                #region Calculos

                if (_modelGVL.GVL_T05.bCalculaResultados)
                {
                    _modelGVL.GVL_T05 = HelperTestBase.Model_GVL.GVL_T05;

                    //Define o ponto maximo do array que foi plotado durante o teste
                    _modelGVL.GVL_Graficos.diBuffer = lstDblReturnReadFile[0].Count() > 0 ? lstDblReturnReadFile[0].Count() : 0;

                    diUbound = _modelGVL.GVL_Graficos.diBuffer; //Define o ponto maximo do array que foi plotado durante o teste


                    #region Calculo da perda total de vacuo

                    var mxtime = lstDblReturnReadFile[0].Max();
                    var mxvacuo = lstDblReturnReadFile[10].Max();

                    var X1_Final = mxtime - 0.5;
                    var X1_ValIdx = lstDblReturnReadFile[0].Aggregate((x1, y1) => Math.Abs(x1 - X1_Final) < Math.Abs(y1 - X1_Final) ? x1 : y1);
                    var X1_PosVacuoFinal = lstDblReturnReadFile[0].IndexOf(X1_ValIdx);
                    var Y1_VacuoFinal = lstDblReturnReadFile[10].ElementAt(X1_PosVacuoFinal);

                    var X2_Inicial = X1_Final - HelperTestBase.Model_GVL.GVL_T05.rTempoTeste;
                    var X2_ValIdx = lstDblReturnReadFile[0].Aggregate((x2, y2) => Math.Abs(x2 - X2_Inicial) < Math.Abs(y2 - X2_Inicial) ? x2 : y2);
                    var X2_PosVacuoInicial = lstDblReturnReadFile[0].IndexOf(X2_ValIdx);
                    var Y2_VacuoInicial = lstDblReturnReadFile[10].ElementAt(X2_PosVacuoInicial);

                    //HelperTestBase.Model_GVL.GVL_T05.rVacuoInicial = Y1_VacuoInicial;
                    //HelperTestBase.Model_GVL.GVL_T05.rVacuoFinal = Y2_VacuoInicial;
                    _modelGVL.GVL_T05.rVacuoInicial = Y2_VacuoInicial;
                    _modelGVL.GVL_T05.rPerdaVacuo = Y2_VacuoInicial - Y1_VacuoFinal;

                    #endregion

                    #region Tempo Teste

                    _modelGVL.GVL_T05.rTempoTotal = _modelGVL.GVL_T05.rTempoTeste;

                    #endregion

                    _modelGVL.GVL_T05.bCalculaResultados = false;

                    _modelGVL.GVL_Graficos.bDadosCalculados = true;
                }

                HelperTestBase.Model_GVL.helperTestBase_ModelGVL_Test = HelperTestBase.Model_GVL.GVL_T05;

                HelperTestBase.Model_GVL = _modelGVL;

                #endregion

            }
            catch (Exception ex)
            {
                var err = ex.Message;
                throw;
            }

            return _modelGVL;

            #endregion
        }


        #endregion

        #region T06 - Calculos Vazamento Vacuo - ET_VacuumLeakage_FullyAppliedPosition
        public Model_GVL CalcGraphT06_ET_VacuumLeakage_FullyAppliedPosition(bool bCalculaResultados, List<double>[] lstDblReturnReadFile)
        {
            #region PROGRAM T06_Calculos_Resultados

            try
            {
                #region Limpa ultimos resultados

                dictVarList.Clear();

                _modelGVL.GVL_T06.rForcaMaxima = 0;
                _modelGVL.GVL_T06.rDeslocamentoEmFmax = 0;
                _modelGVL.GVL_T06.iConsumidoresCP = 0;
                _modelGVL.GVL_T06.iConsumidoresCS = 0;
                _modelGVL.GVL_T06.rPerdaVacuo = 0;
                _modelGVL.GVL_T06.rTempoTotal = 0;

                _modelGVL.GVL_T06.bCalculaResultados = bCalculaResultados;

                #region VARIABLES

                long diUbound = 0; //  ; DINT;
                long di = 0; //  ; DINT;

                #endregion

                #endregion

                #region Variaveis Grafico

                _modelGVL.GVL_Graficos.rEscalaX = 30;
                _modelGVL.GVL_Graficos.EixoX.wsTLLabel = "AxesChart.1";
                _modelGVL.GVL_Graficos.rEscalaY1 = -1;
                _modelGVL.GVL_Graficos.EixoY1.wsTLLabel = "AxesChart.7";
                _modelGVL.GVL_Graficos.rEscalaY2 = 0;
                _modelGVL.GVL_Graficos.EixoY2.wsTLLabel = string.Empty;
                _modelGVL.GVL_Graficos.rEscalaY3 = 0;
                _modelGVL.GVL_Graficos.EixoY3.wsTLLabel = string.Empty;
                _modelGVL.GVL_Graficos.rEscalaY4 = 0;
                _modelGVL.GVL_Graficos.EixoY4.wsTLLabel = string.Empty;

                _modelGVL.GVL_Graficos.strNomeEixoX = "Time (s)";
                _modelGVL.GVL_Graficos.strNomeEixoY1 = "Vacuum (bar)";
                _modelGVL.GVL_Graficos.strNomeEixoY2 = string.Empty;
                _modelGVL.GVL_Graficos.strNomeEixoY3 = string.Empty;
                _modelGVL.GVL_Graficos.strNomeEixoY4 = string.Empty;

                _modelGVL.GVL_Graficos.strUnidadeX = "s";
                _modelGVL.GVL_Graficos.strUnidadeY1 = "bar";
                _modelGVL.GVL_Graficos.strUnidadeY2 = string.Empty;
                _modelGVL.GVL_Graficos.strUnidadeY3 = string.Empty;
                _modelGVL.GVL_Graficos.strUnidadeY4 = string.Empty;

                _modelGVL.GVL_Graficos.bOcultaY2 = true;
                _modelGVL.GVL_Graficos.bOcultaY3 = true;
                _modelGVL.GVL_Graficos.bOcultaY4 = true;

                #endregion

                #region Varriaveis Array Dados

                //os arrays dinamicos obtidos neste teste contem as seguintes grandezas:
                //GVL_Graficos.arrVarX[GVL_Graficos.diBuffer] := TIME_TO_REAL(etTempoCiclo)/1000;
                //GVL_Graficos.arrVarY1[GVL_Graficos.diBuffer] := rVacuo_Bar_Lin;
                //GVL_Graficos.arrVarY2[GVL_Graficos.diBuffer] := rForcaEntradaBooster_N_Lin;
                //GVL_Graficos.arrVarY3[GVL_Graficos.diBuffer] := rDeslocamentoEntradaBooster_mm_Lin;

                ClearArrayGVL_Graficos();

                _modelGVL.GVL_Graficos.arrVarTimeStamp = lstDblReturnReadFile[0].ToArray();
                _modelGVL.GVL_Graficos.arrVarX = lstDblReturnReadFile[0].ToArray();
                _modelGVL.GVL_Graficos.arrVarY1 = lstDblReturnReadFile[10].ToArray();
                _modelGVL.GVL_Graficos.arrVarY2 = lstDblReturnReadFile[2].ToArray();
                _modelGVL.GVL_Graficos.arrVarY3 = lstDblReturnReadFile[5].ToArray();

                #endregion

                #region Calculos

                if (_modelGVL.GVL_T06.bCalculaResultados)
                {
                    _modelGVL.GVL_T06 = HelperTestBase.Model_GVL.GVL_T06;

                    //Define o ponto maximo do array que foi plotado durante o teste
                    _modelGVL.GVL_Graficos.diBuffer = lstDblReturnReadFile[0].Count() > 0 ? lstDblReturnReadFile[0].Count() : 0;

                    diUbound = _modelGVL.GVL_Graficos.diBuffer; //Define o ponto maximo do array que foi plotado durante o teste

                    #region Calculo da perda total de vacuo

                    var mxtime = lstDblReturnReadFile[0].Max();
                    var mxvacuo = lstDblReturnReadFile[10].Max();

                    var X1_Final = mxtime - 0.5;
                    var X1_ValIdx = lstDblReturnReadFile[0].Aggregate((x1, y1) => Math.Abs(x1 - X1_Final) < Math.Abs(y1 - X1_Final) ? x1 : y1);
                    var X1_PosVacuoFinal = lstDblReturnReadFile[0].IndexOf(X1_ValIdx);
                    var Y1_VacuoFinal = lstDblReturnReadFile[10].ElementAt(X1_PosVacuoFinal);

                    var X2_Inicial = X1_Final - HelperTestBase.Model_GVL.GVL_T06.rTempoTeste;
                    var X2_ValIdx = lstDblReturnReadFile[0].Aggregate((x2, y2) => Math.Abs(x2 - X2_Inicial) < Math.Abs(y2 - X2_Inicial) ? x2 : y2);
                    var X2_PosVacuoInicial = lstDblReturnReadFile[0].IndexOf(X2_ValIdx);
                    var Y2_VacuoInicial = lstDblReturnReadFile[10].ElementAt(X2_PosVacuoInicial);

                    _modelGVL.GVL_T06.rVacuoInicial = Y2_VacuoInicial;
                    _modelGVL.GVL_T06.rPerdaVacuo = Y2_VacuoInicial - Y1_VacuoFinal;

                    //========================================================================================================================================================
                    #endregion

                    #region Loop para identificar a forca maxima do teste, e armazenar o ponto de inflexao do teste (quando o atuador comeca a retornar)
                    //========================================================================================================================================================

                    for (di = 0; di < diUbound; di++)
                    {
                        if (_modelGVL.GVL_Graficos.arrVarY2[di] > _modelGVL.GVL_T06.rForcaMaxima)
                        {
                            _modelGVL.GVL_T06.rForcaMaxima = _modelGVL.GVL_Graficos.arrVarY2[di]; //Atualiza o valor de forca maxima com o maior valor obtido no array                        
                            _modelGVL.GVL_T06.rDeslocamentoEmFmax = _modelGVL.GVL_Graficos.arrVarY3[di]; ; //Indica em qual posicao do array esta o deslocamento maximo
                        }
                    }
                    //========================================================================================================================================================
                    #endregion

                    #region RunOut Force Referencia
                    //Transfere a forca runout de T01 para o resultado de T06
                    _modelGVL.GVL_T06.rRunOutForceRef = _modelGVL.GVL_T01.temp_rRunOutForce_Real_N;
                    #endregion

                    #region Tempo Total
                    _modelGVL.GVL_T06.rTempoTotal = _modelGVL.GVL_T06.rTempoTeste;
                    #endregion

                    #region Calculo dos Consumidores Utilizados

                    //========================================================================================================================================================

                    _modelGVL.GVL_T06.iConsumidoresCP = 0;
                    _modelGVL.GVL_T06.iConsumidoresCS = 0;

                    HelperTestBase.Model_GVL.GVL_Parametros.iTipoConsumidores = HelperMODBUS.CS_wTipoConsumidores;

                    if (HelperMODBUS.CS_wTipoConsumidores != 2)
                    {
                        _modelGVL.GVL_T06.iConsumidoresCP = 0;
                        _modelGVL.GVL_T06.iConsumidoresCS = 0;
                    }
                    else
                    {
                        //HelperMODBUS.CS_wStatusLiga17MangueirasCS 
                        if (HelperMODBUS.CS_wStatusLiga1MangueiraCP)
                            _modelGVL.GVL_T06.iConsumidoresCP = _modelGVL.GVL_T06.iConsumidoresCP + 1;

                        if (HelperMODBUS.CS_wStatusLiga2MangueirasCP)
                            _modelGVL.GVL_T06.iConsumidoresCP = _modelGVL.GVL_T06.iConsumidoresCP + 2;

                        if (HelperMODBUS.CS_wStatusLiga4MangueirasCP)
                            _modelGVL.GVL_T06.iConsumidoresCP = _modelGVL.GVL_T06.iConsumidoresCP + 4;

                        if (HelperMODBUS.CS_wStatusLiga8MangueirasCP)
                            _modelGVL.GVL_T06.iConsumidoresCP = _modelGVL.GVL_T06.iConsumidoresCP + 8;

                        if (HelperMODBUS.CS_wStatusLiga10MangueirasCP)
                            _modelGVL.GVL_T06.iConsumidoresCP = _modelGVL.GVL_T06.iConsumidoresCP + 10;

                        if (HelperMODBUS.CS_wStatusLiga17MangueirasCP)
                            _modelGVL.GVL_T06.iConsumidoresCP = _modelGVL.GVL_T06.iConsumidoresCP + 17;

                        if (HelperMODBUS.CS_wStatusLiga1MangueiraCS)
                            _modelGVL.GVL_T06.iConsumidoresCS = _modelGVL.GVL_T06.iConsumidoresCS + 1;

                        if (HelperMODBUS.CS_wStatusLiga2MangueirasCS)
                            _modelGVL.GVL_T06.iConsumidoresCS = _modelGVL.GVL_T06.iConsumidoresCS + 2;

                        if (HelperMODBUS.CS_wStatusLiga4MangueirasCS)
                            _modelGVL.GVL_T06.iConsumidoresCS = _modelGVL.GVL_T06.iConsumidoresCS + 4;

                        if (HelperMODBUS.CS_wStatusLiga8MangueirasCS)
                            _modelGVL.GVL_T06.iConsumidoresCS = _modelGVL.GVL_T06.iConsumidoresCS + 8;

                        if (HelperMODBUS.CS_wStatusLiga10MangueirasCS)
                            _modelGVL.GVL_T06.iConsumidoresCS = _modelGVL.GVL_T06.iConsumidoresCS + 10;

                        if (HelperMODBUS.CS_wStatusLiga17MangueirasCS)
                            _modelGVL.GVL_T06.iConsumidoresCS = _modelGVL.GVL_T06.iConsumidoresCS + 17;
                    }
                    //============================. ============================================================================================================================

                    #endregion

                    _modelGVL.GVL_T06.bCalculaResultados = false;

                    _modelGVL.GVL_Graficos.bDadosCalculados = true;
                }

                HelperTestBase.Model_GVL.helperTestBase_ModelGVL_Test = HelperTestBase.Model_GVL.GVL_T06;

                HelperTestBase.Model_GVL = _modelGVL;

                #endregion

            }
            catch (Exception ex)
            {
                var err = ex.Message;
                throw;
            }

            return _modelGVL;

            #endregion
        }


        #endregion

        #region T07 - Calculos Vazamento Vacuo - ET_VacuumLeakage_LapPosition
        public Model_GVL CalcGraphT07_ET_VacuumLeakage_LapPosition(bool bCalculaResultados, List<double>[] lstDblReturnReadFile)
        {
            #region PROGRAM T07_Calculos_Resultados

            try
            {
                #region Limpa ultimos resultados

                dictVarList.Clear();

                _modelGVL.GVL_T07.rForcaMaxima = 0;
                _modelGVL.GVL_T07.rDeslocamentoEmFmax = 0;
                _modelGVL.GVL_T07.iConsumidoresCP = 0;
                _modelGVL.GVL_T07.iConsumidoresCS = 0;
                _modelGVL.GVL_T07.rPerdaVacuo = 0;
                _modelGVL.GVL_T07.rTempoTotal = 0;

                _modelGVL.GVL_T07.rForcaRelativaAvancoReal_N = 0;
                _modelGVL.GVL_T07.rForcaRelativaRetornoReal_N = 0;
                _modelGVL.GVL_T07.rForcaRelativaFinalReal_N = 0;
                _modelGVL.GVL_T07.rDeslocamentoEmFRelativaAvanco = 0;
                _modelGVL.GVL_T07.rDeslocamentoEmFRelativaRetorno = 0;
                _modelGVL.GVL_T07.rDeslocamentoEmFRelativaFinal = 0;

                _modelGVL.GVL_T07.bCalculaResultados = bCalculaResultados;

                #region VARIABLES

                long diUbound = 0; //  ; DINT;
                long di = 0; //  ; DINT;
                long diIndiceFRelativaAvanco = 0;
                long diIndiceFRelativaRetorno = 0;

                #endregion

                #endregion

                #region Variaveis Grafico

                _modelGVL.GVL_Graficos.rEscalaX = 30;
                _modelGVL.GVL_Graficos.EixoX.wsTLLabel = "AxesChart.1";
                _modelGVL.GVL_Graficos.rEscalaY1 = -1;
                _modelGVL.GVL_Graficos.EixoY1.wsTLLabel = "AxesChart.7";
                _modelGVL.GVL_Graficos.rEscalaY2 = 0;
                _modelGVL.GVL_Graficos.EixoY2.wsTLLabel = string.Empty;
                _modelGVL.GVL_Graficos.rEscalaY3 = 0;
                _modelGVL.GVL_Graficos.EixoY3.wsTLLabel = string.Empty;
                _modelGVL.GVL_Graficos.rEscalaY4 = 0;
                _modelGVL.GVL_Graficos.EixoY4.wsTLLabel = string.Empty;

                _modelGVL.GVL_Graficos.strNomeEixoX = "Time (s)";
                _modelGVL.GVL_Graficos.strNomeEixoY1 = "Vacuum (bar)";
                _modelGVL.GVL_Graficos.strNomeEixoY2 = string.Empty;
                _modelGVL.GVL_Graficos.strNomeEixoY3 = string.Empty;
                _modelGVL.GVL_Graficos.strNomeEixoY4 = string.Empty;

                _modelGVL.GVL_Graficos.strUnidadeX = "s";
                _modelGVL.GVL_Graficos.strUnidadeY1 = "bar";
                _modelGVL.GVL_Graficos.strUnidadeY2 = string.Empty;
                _modelGVL.GVL_Graficos.strUnidadeY3 = string.Empty;
                _modelGVL.GVL_Graficos.strUnidadeY4 = string.Empty;

                _modelGVL.GVL_Graficos.bOcultaY2 = true;
                _modelGVL.GVL_Graficos.bOcultaY3 = true;
                _modelGVL.GVL_Graficos.bOcultaY4 = true;

                #endregion

                #region Varriaveis Array Dados

                //os arrays dinamicos obtidos neste teste contem as seguintes grandezas:
                //GVL_Graficos.arrVarX[GVL_Graficos.diBuffer] := TIME_TO_REAL(etTempoCiclo)/1000;
                //GVL_Graficos.arrVarY1[GVL_Graficos.diBuffer] := rVacuo_Bar_Lin;
                //GVL_Graficos.arrVarY2[GVL_Graficos.diBuffer] := rForcaEntradaBooster_N_Lin;
                //GVL_Graficos.arrVarY3[GVL_Graficos.diBuffer] := rDeslocamentoEntradaBooster_mm_Lin;

                ClearArrayGVL_Graficos();

                _modelGVL.GVL_Graficos.arrVarTimeStamp = lstDblReturnReadFile[0].ToArray();
                _modelGVL.GVL_Graficos.arrVarX = lstDblReturnReadFile[0].ToArray();
                _modelGVL.GVL_Graficos.arrVarY1 = lstDblReturnReadFile[10].ToArray();
                _modelGVL.GVL_Graficos.arrVarY2 = lstDblReturnReadFile[2].ToArray();
                _modelGVL.GVL_Graficos.arrVarY3 = lstDblReturnReadFile[5].ToArray();

                #endregion

                #region Calculos

                if (_modelGVL.GVL_T07.bCalculaResultados)
                {
                    _modelGVL.GVL_T07 = HelperTestBase.Model_GVL.GVL_T07;

                    //Define o ponto maximo do array que foi plotado durante o teste
                    _modelGVL.GVL_Graficos.diBuffer = lstDblReturnReadFile[0].Count() > 0 ? lstDblReturnReadFile[0].Count() : 0;

                    diUbound = _modelGVL.GVL_Graficos.diBuffer; //Define o ponto maximo do array que foi plotado durante o teste

                    #region Calculo da perda total de vacuo

                    var mxtime = lstDblReturnReadFile[0].Max();
                    var mxvacuo = lstDblReturnReadFile[10].Max();

                    var X1_Final = mxtime - 0.5;
                    var X1_ValIdx = lstDblReturnReadFile[0].Aggregate((x1, y1) => Math.Abs(x1 - X1_Final) < Math.Abs(y1 - X1_Final) ? x1 : y1);
                    var X1_PosVacuoFinal = lstDblReturnReadFile[0].IndexOf(X1_ValIdx);
                    var Y1_VacuoFinal = lstDblReturnReadFile[10].ElementAt(X1_PosVacuoFinal);

                    var X2_Inicial = X1_Final - HelperTestBase.Model_GVL.GVL_T07.rTempoTeste;
                    var X2_ValIdx = lstDblReturnReadFile[0].Aggregate((x2, y2) => Math.Abs(x2 - X2_Inicial) < Math.Abs(y2 - X2_Inicial) ? x2 : y2);
                    var X2_PosVacuoInicial = lstDblReturnReadFile[0].IndexOf(X2_ValIdx);
                    var Y2_VacuoInicial = lstDblReturnReadFile[10].ElementAt(X2_PosVacuoInicial);

                    _modelGVL.GVL_T07.rVacuoInicial = Y2_VacuoInicial;
                    _modelGVL.GVL_T07.rPerdaVacuo = Y2_VacuoInicial - Y1_VacuoFinal;

                    #endregion

                    #region Tempo Total

                    _modelGVL.GVL_T07.rTempoTotal = _modelGVL.GVL_T07.rTempoTeste;

                    #endregion

                    #region Loop para identificar a forca maxima do teste, e armazenar o ponto de inflexao do teste (quando o atuador comeca a retornar)
                    //========================================================================================================================================================

                    for (di = 0; di < diUbound; di++)
                    {
                        if (_modelGVL.GVL_Graficos.arrVarY2[di] > _modelGVL.GVL_T07.rForcaMaxima)
                        {
                            _modelGVL.GVL_T07.rForcaMaxima = _modelGVL.GVL_Graficos.arrVarY2[di]; //Atualiza o valor de forca maxima com o maior valor obtido no array                        
                            _modelGVL.GVL_T07.rDeslocamentoEmFmax = _modelGVL.GVL_Graficos.arrVarY3[di]; ; //Indica em qual posicao do array esta o deslocamento maximo
                        }
                    }
                    //========================================================================================================================================================
                    #endregion

                    #region Loop para identificar Forcas e deslocamentos
                    //Loop para identificar forcas e deslocamentos
                    long diIndicaFRelativaAvanco = 0;
                    long diIndicaFRelativaRetorno = 0;

                    if (!_modelGVL.GVL_T07.bTesteSimples)
                    {
                        for (di = 0; di < diUbound; di++)
                        {
                            if (_modelGVL.GVL_Graficos.arrVarY2[di] > _modelGVL.GVL_T07.rForcaRelativaAvanco_N)
                            {

                                _modelGVL.GVL_T07.rForcaRelativaAvancoReal_N = _modelGVL.GVL_Graficos.arrVarY2[di]; //Pega o valor real obtido
                                _modelGVL.GVL_T07.rDeslocamentoEmFRelativaAvanco = _modelGVL.GVL_Graficos.arrVarY3[di]; //Indica em qual posicao do array esta a forca maxima (pico do grafico, aonde comeca o retorno do atuador)
                                diIndicaFRelativaAvanco = di;
                                break;
                            }
                        }

                        //Loop para identificar o deslocamento ao retornar
                        for (di = diIndicaFRelativaAvanco; di < diUbound; di++)
                        {
                            if (_modelGVL.GVL_Graficos.arrVarY2[di] < _modelGVL.GVL_T07.rForcaRelativaRetorno_N)
                            {

                                _modelGVL.GVL_T07.rForcaRelativaRetornoReal_N = _modelGVL.GVL_Graficos.arrVarY2[di]; //Pega o valor real obtido
                                _modelGVL.GVL_T07.rDeslocamentoEmFRelativaRetorno = _modelGVL.GVL_Graficos.arrVarY3[di]; //Indica em qual posicao do array esta a forca maxima (pico do grafico, aonde comeca o retorno do atuador)
                                diIndicaFRelativaRetorno = di;
                                break;
                            }
                        }

                        //Loop para identificar o deslocamento ao atingir a forca final
                        for (di = diIndicaFRelativaRetorno; di < diUbound; di++)
                        {
                            if (GVL_Graficos.arrVarY2[di] > _modelGVL.GVL_T07.rForcaRelativaFinal_N)
                            {

                                _modelGVL.GVL_T07.rForcaRelativaFinalReal_N = _modelGVL.GVL_Graficos.arrVarY2[di]; //Pega o valor real obtido
                                _modelGVL.GVL_T07.rDeslocamentoEmFRelativaFinal = _modelGVL.GVL_Graficos.arrVarY3[di]; //Indica em qual posicao do array esta a forca maxima (pico do grafico, aonde comeca o retorno do atuador)
                                break;
                            }
                        }
                    }
                    else
                    {

                        for (di = 0; di < diUbound; di++)
                        {
                            if (_modelGVL.GVL_Graficos.arrVarY2[di] >= _modelGVL.GVL_T07.rForcaMaxima)
                            {

                                _modelGVL.GVL_T07.rForcaRelativaFinalReal_N = _modelGVL.GVL_Graficos.arrVarY2[di]; //Pega o valor real obtido
                                _modelGVL.GVL_T07.rDeslocamentoEmFRelativaFinal = _modelGVL.GVL_Graficos.arrVarY3[di]; //Indica em qual posicao do array esta a forca maxima (pico do grafico, aonde comeca o retorno do atuador)
                                _modelGVL.GVL_T07.rForcaRelativaRetornoReal_N = 0;
                                _modelGVL.GVL_T07.rForcaRelativaAvancoReal_N = 0;
                                _modelGVL.GVL_T07.rDeslocamentoEmFRelativaRetorno = 0;
                                _modelGVL.GVL_T07.rDeslocamentoEmFRelativaAvanco = 0;
                                diIndicaFRelativaAvanco = di;
                                break;
                            }
                        }

                    }
                    #endregion

                    #region RunOut Force Referencia
                    //Transfere a forca runout de T01 para o resultado de T07
                    _modelGVL.GVL_T07.rRunOutForceRef = _modelGVL.GVL_T01.temp_rRunOutForce_Real_N;

                    #endregion

                    #region Calculo dos Consumidores Utilizados

                    //========================================================================================================================================================

                    _modelGVL.GVL_T07.iConsumidoresCP = 0;
                    _modelGVL.GVL_T07.iConsumidoresCS = 0;

                    HelperTestBase.Model_GVL.GVL_Parametros.iTipoConsumidores = HelperMODBUS.CS_wTipoConsumidores;

                    if (HelperMODBUS.CS_wTipoConsumidores != 2)
                    {
                        _modelGVL.GVL_T07.iConsumidoresCP = 0;
                        _modelGVL.GVL_T07.iConsumidoresCS = 0;
                    }
                    else
                    {
                        //HelperMODBUS.CS_wStatusLiga17MangueirasCS 
                        if (HelperMODBUS.CS_wStatusLiga1MangueiraCP)
                            _modelGVL.GVL_T07.iConsumidoresCP = _modelGVL.GVL_T07.iConsumidoresCP + 1;

                        if (HelperMODBUS.CS_wStatusLiga2MangueirasCP)
                            _modelGVL.GVL_T07.iConsumidoresCP = _modelGVL.GVL_T07.iConsumidoresCP + 2;

                        if (HelperMODBUS.CS_wStatusLiga4MangueirasCP)
                            _modelGVL.GVL_T07.iConsumidoresCP = _modelGVL.GVL_T07.iConsumidoresCP + 4;

                        if (HelperMODBUS.CS_wStatusLiga8MangueirasCP)
                            _modelGVL.GVL_T07.iConsumidoresCP = _modelGVL.GVL_T07.iConsumidoresCP + 8;

                        if (HelperMODBUS.CS_wStatusLiga10MangueirasCP)
                            _modelGVL.GVL_T07.iConsumidoresCP = _modelGVL.GVL_T07.iConsumidoresCP + 10;

                        if (HelperMODBUS.CS_wStatusLiga17MangueirasCP)
                            _modelGVL.GVL_T07.iConsumidoresCP = _modelGVL.GVL_T07.iConsumidoresCP + 17;

                        if (HelperMODBUS.CS_wStatusLiga1MangueiraCS)
                            _modelGVL.GVL_T07.iConsumidoresCS = _modelGVL.GVL_T07.iConsumidoresCS + 1;

                        if (HelperMODBUS.CS_wStatusLiga2MangueirasCS)
                            _modelGVL.GVL_T07.iConsumidoresCS = _modelGVL.GVL_T07.iConsumidoresCS + 2;

                        if (HelperMODBUS.CS_wStatusLiga4MangueirasCS)
                            _modelGVL.GVL_T07.iConsumidoresCS = _modelGVL.GVL_T07.iConsumidoresCS + 4;

                        if (HelperMODBUS.CS_wStatusLiga8MangueirasCS)
                            _modelGVL.GVL_T07.iConsumidoresCS = _modelGVL.GVL_T07.iConsumidoresCS + 8;

                        if (HelperMODBUS.CS_wStatusLiga10MangueirasCS)
                            _modelGVL.GVL_T07.iConsumidoresCS = _modelGVL.GVL_T07.iConsumidoresCS + 10;

                        if (HelperMODBUS.CS_wStatusLiga17MangueirasCS)
                            _modelGVL.GVL_T07.iConsumidoresCS = _modelGVL.GVL_T07.iConsumidoresCS + 17;
                    }
                    //============================. ============================================================================================================================

                    #endregion

                    _modelGVL.GVL_T07.bCalculaResultados = false;

                    _modelGVL.GVL_Graficos.bDadosCalculados = true;
                }

                HelperTestBase.Model_GVL.helperTestBase_ModelGVL_Test = HelperTestBase.Model_GVL.GVL_T07;

                HelperTestBase.Model_GVL = _modelGVL;

                #endregion

            }
            catch (Exception ex)
            {
                var err = ex.Message;
                throw;
            }

            return _modelGVL;

            #endregion
        }


        #endregion

        #region T08 - Calculos Vazamento Hidraulico - ET_HydraulicLeakage_FullyAppliedPosition
        public Model_GVL CalcGraphT08_ET_HydraulicLeakage_FullyAppliedPosition(bool bCalculaResultados, List<double>[] lstDblReturnReadFile)
        {
            #region PROGRAM T08_Calculos_Resultados

            try
            {
                #region Limpa ultimos resultados

                dictVarList.Clear();

                _modelGVL.GVL_T08.rForcaMaxima = 0;
                _modelGVL.GVL_T08.rDeslocamentoEmFMax = 0;
                _modelGVL.GVL_T08.rPerdaVacuo = 0;
                _modelGVL.GVL_T08.rPerdaPressaoCP = 0;
                _modelGVL.GVL_T08.rPerdaPressaoCS = 0;

                _modelGVL.GVL_T08.bCalculaResultados = bCalculaResultados;

                #region VARIABLES

                long diUbound = 0; //  ; DINT;
                long di = 0; //  ; DINT;

                #endregion

                #endregion

                #region Variaveis Grafico

                _modelGVL.GVL_Graficos.rEscalaX = 30;
                _modelGVL.GVL_Graficos.EixoX.wsTLLabel = "AxesChart.1";
                _modelGVL.GVL_Graficos.rEscalaY1 = -1;
                _modelGVL.GVL_Graficos.EixoY1.wsTLLabel = "AxesChart.7";
                _modelGVL.GVL_Graficos.rEscalaY2 = 0;
                _modelGVL.GVL_Graficos.EixoY2.wsTLLabel = string.Empty;
                _modelGVL.GVL_Graficos.rEscalaY3 = 0;
                _modelGVL.GVL_Graficos.EixoY3.wsTLLabel = string.Empty;
                _modelGVL.GVL_Graficos.rEscalaY4 = 0;
                _modelGVL.GVL_Graficos.EixoY4.wsTLLabel = string.Empty;

                _modelGVL.GVL_Graficos.strNomeEixoX = "Time (s)";
                _modelGVL.GVL_Graficos.strNomeEixoY1 = "Vacuum (bar)";
                _modelGVL.GVL_Graficos.strNomeEixoY2 = "Pressure (CP)";
                _modelGVL.GVL_Graficos.strNomeEixoY3 = "Pressure (CS)";
                _modelGVL.GVL_Graficos.strNomeEixoY4 = string.Empty;

                _modelGVL.GVL_Graficos.strUnidadeX = "s";
                _modelGVL.GVL_Graficos.strUnidadeY1 = "bar";
                _modelGVL.GVL_Graficos.strUnidadeY2 = "bar";
                _modelGVL.GVL_Graficos.strUnidadeY3 = "bar";
                _modelGVL.GVL_Graficos.strUnidadeY4 = string.Empty;

                _modelGVL.GVL_Graficos.bOcultaY2 = false;
                _modelGVL.GVL_Graficos.bOcultaY3 = false;
                _modelGVL.GVL_Graficos.bOcultaY4 = true;

                #endregion

                #region Varriaveis Array Dados

                //GVL_Graficos.arrVarX[GVL_Graficos.diBuffer] := TIME_TO_REAL(etTempoCiclo)/1000;
                //GVL_Graficos.arrVarY1[GVL_Graficos.diBuffer] := rVacuo_Bar_Lin;
                //GVL_Graficos.arrVarY2[GVL_Graficos.diBuffer] := rPressaoCP_Bar_Lin;
                //GVL_Graficos.arrVarY3[GVL_Graficos.diBuffer] := rPressaoCS_Bar_Lin;
                //GVL_Graficos.arrVarY4[GVL_Graficos.diBuffer] := rDeslocamentoEntradaBooster_mm_Lin;	
                //GVL_Graficos.arrVarY5[GVL_Graficos.diBuffer] := rForcaEntradaBooster_N_Lin;

                ClearArrayGVL_Graficos();

                _modelGVL.GVL_Graficos.arrVarTimeStamp = lstDblReturnReadFile[0].ToArray();
                _modelGVL.GVL_Graficos.arrVarX = lstDblReturnReadFile[0].ToArray();
                _modelGVL.GVL_Graficos.arrVarY1 = lstDblReturnReadFile[10].ToArray();
                _modelGVL.GVL_Graficos.arrVarY2 = lstDblReturnReadFile[7].ToArray();
                _modelGVL.GVL_Graficos.arrVarY3 = lstDblReturnReadFile[6].ToArray();
                _modelGVL.GVL_Graficos.arrVarY4 = lstDblReturnReadFile[5].ToArray();
                _modelGVL.GVL_Graficos.arrVarY5 = lstDblReturnReadFile[2].ToArray();

                #endregion

                #region Calculos

                if (_modelGVL.GVL_T08.bCalculaResultados)
                {
                    _modelGVL.GVL_T08 = HelperTestBase.Model_GVL.GVL_T08;

                    //Define o ponto maximo do array que foi plotado durante o teste
                    _modelGVL.GVL_Graficos.diBuffer = lstDblReturnReadFile[0].Count() > 0 ? lstDblReturnReadFile[0].Count() : 0;

                    diUbound = _modelGVL.GVL_Graficos.diBuffer; //Define o ponto maximo do array que foi plotado durante o teste

                    #region Loop para identificar a forca maxima do teste, e armazenar o ponto de inflexao do teste (quando o atuador comeca a retornar)
                    //========================================================================================================================================================

                    for (di = 0; di < diUbound; di++)
                    {
                        if (_modelGVL.GVL_Graficos.arrVarY5[di] > _modelGVL.GVL_T08.rForcaMaxima)
                        {
                            _modelGVL.GVL_T08.rForcaMaxima = _modelGVL.GVL_Graficos.arrVarY5[di]; //Atualiza o valor de forca maxima com o maior valor obtido no array                        
                            _modelGVL.GVL_T08.rDeslocamentoEmFMax = _modelGVL.GVL_Graficos.arrVarY4[di]; ; //Indica em qual posicao do array esta o deslocamento maximo
                        }
                    }
                    //========================================================================================================================================================
                    #endregion

                    #region RunOut Force Referencia
                    //Transfere a forca runout de T01 para o resultado de T08
                    _modelGVL.GVL_T08.rRunOutForceRef = _modelGVL.GVL_T01.temp_rRunOutForce_Real_N;

                    #endregion

                    #region Calculo da perda total de vacuo

                    var mxtime = lstDblReturnReadFile[0].Max();

                    var X1_Final = mxtime - 0.5;
                    var X1_ValIdx = lstDblReturnReadFile[0].Aggregate((x1, y1) => Math.Abs(x1 - X1_Final) < Math.Abs(y1 - X1_Final) ? x1 : y1);
                    var X1_PosVacuoFinal = lstDblReturnReadFile[0].IndexOf(X1_ValIdx);
                    var Y1_VacuoFinal = lstDblReturnReadFile[10].ElementAt(X1_PosVacuoFinal);

                    var X2_Inicial = X1_Final - HelperTestBase.Model_GVL.GVL_T08.rTempoTeste;
                    var X2_ValIdx = lstDblReturnReadFile[0].Aggregate((x2, y2) => Math.Abs(x2 - X2_Inicial) < Math.Abs(y2 - X2_Inicial) ? x2 : y2);
                    var X2_PosVacuoInicial = lstDblReturnReadFile[0].IndexOf(X2_ValIdx);
                    var Y2_VacuoInicial = lstDblReturnReadFile[10].ElementAt(X2_PosVacuoInicial);

                    _modelGVL.GVL_T08.rVacuoInicial = Y2_VacuoInicial;
                    _modelGVL.GVL_T08.rPerdaVacuo = Y2_VacuoInicial - Y1_VacuoFinal;
                    #endregion

                    #region Calculo da perda total de Pressao CP
                    var X3_Final = mxtime - 0.5;
                    var X3_ValIdx = lstDblReturnReadFile[0].Aggregate((x1, y1) => Math.Abs(x1 - X3_Final) < Math.Abs(y1 - X3_Final) ? x1 : y1);
                    var X3_PosPressCPFinal = lstDblReturnReadFile[0].IndexOf(X3_ValIdx);
                    var Y3_PressCPFinal = lstDblReturnReadFile[7].ElementAt(X3_PosPressCPFinal);

                    var X4_Inicial = X3_Final - HelperTestBase.Model_GVL.GVL_T08.rTempoTeste;
                    var X4_ValIdx = lstDblReturnReadFile[0].Aggregate((x2, y2) => Math.Abs(x2 - X4_Inicial) < Math.Abs(y2 - X4_Inicial) ? x2 : y2);
                    var X4_PosPressCPInicial = lstDblReturnReadFile[0].IndexOf(X4_ValIdx);
                    var Y4_PressCPInicial = lstDblReturnReadFile[7].ElementAt(X4_PosPressCPInicial);

                    _modelGVL.GVL_T08.rPressaoInicialCP = Y4_PressCPInicial;
                    _modelGVL.GVL_T08.rPressaoFinalCP = Y3_PressCPFinal;

                    _modelGVL.GVL_T08.rPerdaPressaoCP = Y4_PressCPInicial - Y3_PressCPFinal;
                    #endregion

                    #region Calculo da perda total de Pressao CS
                    var X5_Final = mxtime - 0.5;
                    var X5_ValIdx = lstDblReturnReadFile[0].Aggregate((x1, y1) => Math.Abs(x1 - X5_Final) < Math.Abs(y1 - X5_Final) ? x1 : y1);
                    var X5_PosPressCSFinal = lstDblReturnReadFile[0].IndexOf(X5_ValIdx);
                    var Y5_PressCSFinal = lstDblReturnReadFile[6].ElementAt(X5_PosPressCSFinal);

                    var X6_Inicial = X5_Final - HelperTestBase.Model_GVL.GVL_T08.rTempoTeste;
                    var X6_ValIdx = lstDblReturnReadFile[0].Aggregate((x2, y2) => Math.Abs(x2 - X6_Inicial) < Math.Abs(y2 - X6_Inicial) ? x2 : y2);
                    var X6_PosPressCSInicial = lstDblReturnReadFile[0].IndexOf(X6_ValIdx);
                    var Y6_PressCSInicial = lstDblReturnReadFile[6].ElementAt(X6_PosPressCSInicial);

                    _modelGVL.GVL_T08.rPressaoInicialCS = Y6_PressCSInicial;
                    _modelGVL.GVL_T08.rPressaoFinalCS = Y5_PressCSFinal;

                    _modelGVL.GVL_T08.rPerdaPressaoCS = Y6_PressCSInicial - Y5_PressCSFinal;
                    #endregion

                    #region Calculo dos Consumidores Utilizados

                    _modelGVL.GVL_T08.iConsumidoresCP = 0;
                    _modelGVL.GVL_T08.iConsumidoresCS = 0;

                    #endregion

                    _modelGVL.GVL_T08.bCalculaResultados = false;

                    _modelGVL.GVL_Graficos.bDadosCalculados = true;
                }

                HelperTestBase.Model_GVL.helperTestBase_ModelGVL_Test = HelperTestBase.Model_GVL.GVL_T08;

                HelperTestBase.Model_GVL = _modelGVL;

                #endregion

            }
            catch (Exception ex)
            {
                var err = ex.Message;
                throw;
            }

            return _modelGVL;

            #endregion
        }


        #endregion

        #region T09 - Calculos Vazamento Hidraulico - ET_HydraulicLeakage_AtLowPressure

        public Model_GVL CalcGraphT09_ET_HydraulicLeakage_AtLowPressure(bool bCalculaResultados, List<double>[] lstDblReturnReadFile)
        {
            #region PROGRAM T09_Calculos_Resultados

            try
            {
                #region Limpa ultimos resultados

                dictVarList.Clear();

                _modelGVL.GVL_T09.rForcaMaxima = 0;
                _modelGVL.GVL_T09.rPressaoMaxima = 0;
                _modelGVL.GVL_T09.rDeslocamentoEmPMax = 0;
                _modelGVL.GVL_T09.rPerdaVacuo = 0;
                _modelGVL.GVL_T09.rPerdaPressaoCP = 0;
                _modelGVL.GVL_T09.rPerdaPressaoCS = 0;

                _modelGVL.GVL_T09.bCalculaResultados = bCalculaResultados;

                #region VARIABLES

                long diUbound = 0; //  ; DINT;
                long di = 0; //  ; DINT;

                #endregion

                #endregion

                #region Variaveis Grafico

                _modelGVL.GVL_Graficos.rEscalaX = 30;
                _modelGVL.GVL_Graficos.EixoX.wsTLLabel = "AxesChart.1";
                _modelGVL.GVL_Graficos.rEscalaY1 = -1;
                _modelGVL.GVL_Graficos.EixoY1.wsTLLabel = "AxesChart.1";
                _modelGVL.GVL_Graficos.rEscalaY2 = 0;
                _modelGVL.GVL_Graficos.EixoY2.wsTLLabel = "AxesChart.1";
                _modelGVL.GVL_Graficos.rEscalaY3 = 0;
                _modelGVL.GVL_Graficos.EixoY3.wsTLLabel = "AxesChart.1";
                _modelGVL.GVL_Graficos.rEscalaY4 = 0;
                _modelGVL.GVL_Graficos.EixoY4.wsTLLabel = string.Empty;

                _modelGVL.GVL_Graficos.strNomeEixoX = "Time (s)";
                _modelGVL.GVL_Graficos.strNomeEixoY1 = "Vacuum (bar)";
                _modelGVL.GVL_Graficos.strNomeEixoY2 = "Pressure (CP)";
                _modelGVL.GVL_Graficos.strNomeEixoY3 = "Pressure (CS)";
                _modelGVL.GVL_Graficos.strNomeEixoY4 = string.Empty;

                _modelGVL.GVL_Graficos.strUnidadeX = "s";
                _modelGVL.GVL_Graficos.strUnidadeY1 = "bar";
                _modelGVL.GVL_Graficos.strUnidadeY2 = "bar";
                _modelGVL.GVL_Graficos.strUnidadeY3 = "bar";
                _modelGVL.GVL_Graficos.strUnidadeY4 = string.Empty;

                _modelGVL.GVL_Graficos.bOcultaY2 = false;
                _modelGVL.GVL_Graficos.bOcultaY3 = false;
                _modelGVL.GVL_Graficos.bOcultaY4 = true;

                #endregion

                #region Varriaveis Array Dados

                //os arrays dinamicos obtidos neste teste contem as seguintes grandezas:
                //GVL_Graficos.arrVarX[GVL_Graficos.diBuffer] := TIME_TO_REAL(etTempoCiclo)/1000;
                //GVL_Graficos.arrVarY1[GVL_Graficos.diBuffer] := rVacuo_Bar_Lin;
                //GVL_Graficos.arrVarY2[GVL_Graficos.diBuffer] := rPressaoCP_Bar_Lin;
                //GVL_Graficos.arrVarY3[GVL_Graficos.diBuffer] := rPressaoCS_Bar_Lin;
                //GVL_Graficos.arrVarY4[GVL_Graficos.diBuffer] := rDeslocamentoEntradaBooster_mm_Lin;	
                //GVL_Graficos.arrVarY5[GVL_Graficos.diBuffer] := rForcaEntradaBooster_N_Lin;	

                ClearArrayGVL_Graficos();

                _modelGVL.GVL_Graficos.arrVarTimeStamp = lstDblReturnReadFile[0].ToArray();
                _modelGVL.GVL_Graficos.arrVarX = lstDblReturnReadFile[0].ToArray();
                _modelGVL.GVL_Graficos.arrVarY1 = lstDblReturnReadFile[10].ToArray();
                _modelGVL.GVL_Graficos.arrVarY2 = lstDblReturnReadFile[7].ToArray();
                _modelGVL.GVL_Graficos.arrVarY3 = lstDblReturnReadFile[6].ToArray();
                _modelGVL.GVL_Graficos.arrVarY4 = lstDblReturnReadFile[5].ToArray();
                _modelGVL.GVL_Graficos.arrVarY5 = lstDblReturnReadFile[2].ToArray();

                #endregion

                #region Calculos

                if (_modelGVL.GVL_T09.bCalculaResultados)
                {
                    _modelGVL.GVL_T09 = HelperTestBase.Model_GVL.GVL_T09;

                    //Define o ponto maximo do array que foi plotado durante o teste
                    _modelGVL.GVL_Graficos.diBuffer = lstDblReturnReadFile[0].Count() > 0 ? lstDblReturnReadFile[0].Count() : 0;

                    diUbound = _modelGVL.GVL_Graficos.diBuffer; //Define o ponto maximo do array que foi plotado durante o teste

                    #region Loop para identificar a pressao maxima, fmax e deslocamento max
                    //========================================================================================================================================================

                    for (di = 0; di < diUbound; di++)
                    {
                        if (_modelGVL.GVL_Graficos.arrVarY2[di] > _modelGVL.GVL_T09.rPressaoMaxima)
                        {
                            _modelGVL.GVL_T09.rPressaoMaxima = _modelGVL.GVL_Graficos.arrVarY2[di];
                            _modelGVL.GVL_T09.rForcaMaxima = _modelGVL.GVL_Graficos.arrVarY5[di]; //Atualiza o valor de forca maxima com o maior valor obtido no array
                            _modelGVL.GVL_T09.rDeslocamentoEmPMax = _modelGVL.GVL_Graficos.arrVarY4[di]; ; //Indica em qual posicao do array esta a forca maxima (pico do grafico, aonde comeca o retorno do atuador)
                        }
                    }
                    //========================================================================================================================================================
                    #endregion

                    #region Calculo da perda total de vacuo

                    var mxtime = lstDblReturnReadFile[0].Max();

                    var X1_Final = mxtime - 0.5;
                    var X1_ValIdx = lstDblReturnReadFile[0].Aggregate((x1, y1) => Math.Abs(x1 - X1_Final) < Math.Abs(y1 - X1_Final) ? x1 : y1);
                    var X1_PosVacuoFinal = lstDblReturnReadFile[0].IndexOf(X1_ValIdx);
                    var Y1_VacuoFinal = lstDblReturnReadFile[10].ElementAt(X1_PosVacuoFinal);

                    var X2_Inicial = X1_Final - HelperTestBase.Model_GVL.GVL_T09.rTempoTeste;
                    var X2_ValIdx = lstDblReturnReadFile[0].Aggregate((x2, y2) => Math.Abs(x2 - X2_Inicial) < Math.Abs(y2 - X2_Inicial) ? x2 : y2);
                    var X2_PosVacuoInicial = lstDblReturnReadFile[0].IndexOf(X2_ValIdx);
                    var Y2_VacuoInicial = lstDblReturnReadFile[10].ElementAt(X2_PosVacuoInicial);

                    _modelGVL.GVL_T09.rVacuoInicial = Y2_VacuoInicial;
                    _modelGVL.GVL_T09.rPerdaVacuo = Y2_VacuoInicial - Y1_VacuoFinal;

 
                    #endregion

                    #region  Calculo da perda de pressao CP

                    //Calculo da perda de pressao CP

                    var mxpressCP = lstDblReturnReadFile[7].Max();

                    var X3_Final = mxtime - 0.5;
                    var X3_ValIdx = lstDblReturnReadFile[0].Aggregate((x1, y1) => Math.Abs(x1 - X3_Final) < Math.Abs(y1 - X3_Final) ? x1 : y1);
                    var X3_PosPressFinal = lstDblReturnReadFile[0].IndexOf(X3_ValIdx);
                    var Y3_PressFinal = lstDblReturnReadFile[7].ElementAt(X3_PosPressFinal);

                    var X4_Inicial = X3_Final - HelperTestBase.Model_GVL.GVL_T09.rTempoTeste;
                    var X4_ValIdx = lstDblReturnReadFile[0].Aggregate((x2, y2) => Math.Abs(x2 - X2_Inicial) < Math.Abs(y2 - X4_Inicial) ? x2 : y2);
                    var X4_PosPressInicial = lstDblReturnReadFile[0].IndexOf(X4_ValIdx);
                    var Y4_PressInicial = lstDblReturnReadFile[7].ElementAt(X4_PosPressInicial);

                    _modelGVL.GVL_T09.rPressaoInicialCP = Y4_PressInicial;
                    _modelGVL.GVL_T09.rPressaoFinalCP = Y3_PressFinal;
                    _modelGVL.GVL_T09.rPerdaPressaoCP = Y4_PressInicial - Y3_PressFinal;

                    #endregion

                    #region  Calculo da perda de pressao CS

                    var X5_Final = mxtime - 0.5;
                    var X5_ValIdx = lstDblReturnReadFile[0].Aggregate((x1, y1) => Math.Abs(x1 - X3_Final) < Math.Abs(y1 - X5_Final) ? x1 : y1);
                    var X5_PosPressFinal = lstDblReturnReadFile[0].IndexOf(X5_ValIdx);
                    var Y5_PressFinal = lstDblReturnReadFile[6].ElementAt(X5_PosPressFinal);

                    var X6_Inicial = X5_Final - HelperTestBase.Model_GVL.GVL_T09.rTempoTeste;
                    var X6_ValIdx = lstDblReturnReadFile[0].Aggregate((x2, y2) => Math.Abs(x2 - X6_Inicial) < Math.Abs(y2 - X6_Inicial) ? x2 : y2);
                    var X6_PosPressInicial = lstDblReturnReadFile[0].IndexOf(X6_ValIdx);
                    var Y6_PressInicial = lstDblReturnReadFile[6].ElementAt(X6_PosPressInicial);

                    _modelGVL.GVL_T09.rPressaoInicialCS = Y6_PressInicial;
                    _modelGVL.GVL_T09.rPressaoFinalCS = Y5_PressFinal;
                    _modelGVL.GVL_T09.rPerdaPressaoCS = Y6_PressInicial - Y5_PressFinal;

                    #endregion

                    #region Calculo dos Consumidores Utilizados

                    _modelGVL.GVL_T09.iConsumidoresCP = 0;
                    _modelGVL.GVL_T09.iConsumidoresCS = 0;

                    #endregion

                    _modelGVL.GVL_T09.bCalculaResultados = false;

                    _modelGVL.GVL_Graficos.bDadosCalculados = true;
                }

                HelperTestBase.Model_GVL.helperTestBase_ModelGVL_Test = HelperTestBase.Model_GVL.GVL_T09;

                HelperTestBase.Model_GVL = _modelGVL;

                #endregion

            }
            catch (Exception ex)
            {
                var err = ex.Message;
                throw;
            }

            return _modelGVL;

            #endregion
        }


        #endregion

        #region T10 - Calculos Vazamento Hidraulico - ET_HydraulicLeakage_AtHighPressure
        public Model_GVL CalcGraphT10_ET_HydraulicLeakage_AtHighPressure(bool bCalculaResultados, List<double>[] lstDblReturnReadFile)
        {
            #region PROGRAM T10_Calculos_Resultados

            try
            {
                #region Limpa ultimos resultados

                dictVarList.Clear();

                _modelGVL.GVL_T10.rForcaMaxima = 0;
                _modelGVL.GVL_T10.rPressaoMaxima = 0;
                _modelGVL.GVL_T10.rDeslocamentoEmPMax = 0;
                _modelGVL.GVL_T10.rPerdaVacuo = 0;
                _modelGVL.GVL_T10.rPerdaPressaoCP = 0;
                _modelGVL.GVL_T10.rPerdaPressaoCS = 0;

                _modelGVL.GVL_T10.bCalculaResultados = bCalculaResultados;

                #region VARIABLES

                long diUbound = 0; //  ; DINT;
                long di = 0; //  ; DINT;

                #endregion

                #endregion

                #region Variaveis Grafico

                _modelGVL.GVL_Graficos.rEscalaX = 200;
                _modelGVL.GVL_Graficos.EixoX.wsTLLabel = "AxesChart.1";
                _modelGVL.GVL_Graficos.rEscalaY1 = -1;
                _modelGVL.GVL_Graficos.EixoY1.wsTLLabel = "AxesChart.1";
                _modelGVL.GVL_Graficos.rEscalaY2 = 0;
                _modelGVL.GVL_Graficos.EixoY2.wsTLLabel = "AxesChart.1";
                _modelGVL.GVL_Graficos.rEscalaY3 = 0;
                _modelGVL.GVL_Graficos.EixoY3.wsTLLabel = "AxesChart.1";
                _modelGVL.GVL_Graficos.rEscalaY4 = 0;
                _modelGVL.GVL_Graficos.EixoY4.wsTLLabel = string.Empty;

                _modelGVL.GVL_Graficos.strNomeEixoX = "Time (s)";
                _modelGVL.GVL_Graficos.strNomeEixoY1 = "Vacuum (bar)";
                _modelGVL.GVL_Graficos.strNomeEixoY2 = "Pressure (CP)";
                _modelGVL.GVL_Graficos.strNomeEixoY3 = "Pressure (CS)";
                _modelGVL.GVL_Graficos.strNomeEixoY4 = string.Empty;

                _modelGVL.GVL_Graficos.strUnidadeX = "s";
                _modelGVL.GVL_Graficos.strUnidadeY1 = "bar";
                _modelGVL.GVL_Graficos.strUnidadeY2 = "bar";
                _modelGVL.GVL_Graficos.strUnidadeY3 = "bar";
                _modelGVL.GVL_Graficos.strUnidadeY4 = string.Empty;

                _modelGVL.GVL_Graficos.bOcultaY2 = false;
                _modelGVL.GVL_Graficos.bOcultaY3 = false;
                _modelGVL.GVL_Graficos.bOcultaY4 = true;

                #endregion

                #region Varriaveis Array Dados

                //os arrays dinamicos obtidos neste teste contem as seguintes grandezas:
                //GVL_Graficos.arrVarX[GVL_Graficos.diBuffer] := TIME_TO_REAL(etTempoCiclo)/1000;
                //GVL_Graficos.arrVarY1[GVL_Graficos.diBuffer] := rVacuo_Bar_Lin;
                //GVL_Graficos.arrVarY2[GVL_Graficos.diBuffer] := rPressaoCP_Bar_Lin;
                //GVL_Graficos.arrVarY3[GVL_Graficos.diBuffer] := rPressaoCS_Bar_Lin;
                //GVL_Graficos.arrVarY4[GVL_Graficos.diBuffer] := rDeslocamentoEntradaBooster_mm_Lin;	
                //GVL_Graficos.arrVarY5[GVL_Graficos.diBuffer] := rForcaEntradaBooster_N_Lin;	

                ClearArrayGVL_Graficos();

                _modelGVL.GVL_Graficos.arrVarTimeStamp = lstDblReturnReadFile[0].ToArray();
                _modelGVL.GVL_Graficos.arrVarX = lstDblReturnReadFile[0].ToArray();
                _modelGVL.GVL_Graficos.arrVarY1 = lstDblReturnReadFile[10].ToArray();
                _modelGVL.GVL_Graficos.arrVarY2 = lstDblReturnReadFile[7].ToArray();
                _modelGVL.GVL_Graficos.arrVarY3 = lstDblReturnReadFile[6].ToArray();
                _modelGVL.GVL_Graficos.arrVarY4 = lstDblReturnReadFile[5].ToArray();
                _modelGVL.GVL_Graficos.arrVarY5 = lstDblReturnReadFile[2].ToArray();

                #endregion

                #region Calculos

                if (_modelGVL.GVL_T10.bCalculaResultados)
                {
                    _modelGVL.GVL_T10 = HelperTestBase.Model_GVL.GVL_T10;

                    //Define o ponto maximo do array que foi plotado durante o teste
                    _modelGVL.GVL_Graficos.diBuffer = lstDblReturnReadFile[0].Count() > 0 ? lstDblReturnReadFile[0].Count() : 0;

                    diUbound = _modelGVL.GVL_Graficos.diBuffer; //Define o ponto maximo do array que foi plotado durante o teste

                    #region Loop para identificar a pressao maxima do teste
                    
                    for (di = 0; di < diUbound; di++)
                    {
                        if (_modelGVL.GVL_Graficos.arrVarY2[di] > _modelGVL.GVL_T10.rPressaoMaxima)
                        {
                            _modelGVL.GVL_T10.rPressaoMaxima = _modelGVL.GVL_Graficos.arrVarY2[di];
                            _modelGVL.GVL_T10.rForcaMaxima = _modelGVL.GVL_Graficos.arrVarY5[di]; //Atualiza o valor de forca maxima com o maior valor obtido no array
                            _modelGVL.GVL_T10.rDeslocamentoEmPMax = _modelGVL.GVL_Graficos.arrVarY4[di]; ; //Indica em qual posicao do array esta a forca maxima (pico do grafico, aonde comeca o retorno do atuador)
                        }
                    }

                    #endregion

                    #region Calculo da perda total de vacuo

                    var mxtime = lstDblReturnReadFile[0].Max();
                    var mxvacuo = lstDblReturnReadFile[10].Max();

                    var X1_Final = mxtime - 0.5;
                    var X1_ValIdx = lstDblReturnReadFile[0].Aggregate((x1, y1) => Math.Abs(x1 - X1_Final) < Math.Abs(y1 - X1_Final) ? x1 : y1);
                    var X1_PosVacuoFinal = lstDblReturnReadFile[0].IndexOf(X1_ValIdx);
                    var Y1_VacuoFinal = lstDblReturnReadFile[10].ElementAt(X1_PosVacuoFinal);

                    var X2_Inicial = X1_Final - HelperTestBase.Model_GVL.GVL_T10.rTempoTeste;
                    var X2_ValIdx = lstDblReturnReadFile[0].Aggregate((x2, y2) => Math.Abs(x2 - X2_Inicial) < Math.Abs(y2 - X2_Inicial) ? x2 : y2);
                    var X2_PosVacuoInicial = lstDblReturnReadFile[0].IndexOf(X2_ValIdx);
                    var Y2_VacuoInicial = lstDblReturnReadFile[10].ElementAt(X2_PosVacuoInicial);

                    _modelGVL.GVL_T10.rVacuoInicial = Y2_VacuoInicial;
                    _modelGVL.GVL_T10.rPerdaVacuo = Y2_VacuoInicial - Y1_VacuoFinal;

                    #endregion

                    #region  Calculo da perda de pressao CP

                    var mxpressCP = lstDblReturnReadFile[7].Max();

                    var X3_Final = mxtime - 0.5;
                    var X3_ValIdx = lstDblReturnReadFile[0].Aggregate((x1, y1) => Math.Abs(x1 - X3_Final) < Math.Abs(y1 - X3_Final) ? x1 : y1);
                    var X3_PosPressFinal = lstDblReturnReadFile[0].IndexOf(X3_ValIdx);
                    var Y3_PressFinal = lstDblReturnReadFile[7].ElementAt(X3_PosPressFinal);

                    var X4_Inicial = X3_Final - HelperTestBase.Model_GVL.GVL_T10.rTempoTeste;
                    var X4_ValIdx = lstDblReturnReadFile[0].Aggregate((x2, y2) => Math.Abs(x2 - X2_Inicial) < Math.Abs(y2 - X4_Inicial) ? x2 : y2);
                    var X4_PosPressInicial = lstDblReturnReadFile[0].IndexOf(X4_ValIdx);
                    var Y4_PressInicial = lstDblReturnReadFile[7].ElementAt(X4_PosPressInicial);

                    _modelGVL.GVL_T10.rPressaoInicialCP = Y4_PressInicial;
                    _modelGVL.GVL_T10.rPressaoFinalCP = Y3_PressFinal;
                    _modelGVL.GVL_T10.rPerdaPressaoCP = Y4_PressInicial - Y3_PressFinal;

                    #endregion

                    #region  Calculo da perda de pressao CS

                    var mxpressCS = lstDblReturnReadFile[6].Max();

                    var X5_Final = mxtime - 0.5;
                    var X5_ValIdx = lstDblReturnReadFile[0].Aggregate((x1, y1) => Math.Abs(x1 - X3_Final) < Math.Abs(y1 - X5_Final) ? x1 : y1);
                    var X5_PosPressFinal = lstDblReturnReadFile[0].IndexOf(X5_ValIdx);
                    var Y5_PressFinal = lstDblReturnReadFile[6].ElementAt(X5_PosPressFinal);

                    var X6_Inicial = X5_Final - HelperTestBase.Model_GVL.GVL_T10.rTempoTeste;
                    var X6_ValIdx = lstDblReturnReadFile[0].Aggregate((x2, y2) => Math.Abs(x2 - X6_Inicial) < Math.Abs(y2 - X6_Inicial) ? x2 : y2);
                    var X6_PosPressInicial = lstDblReturnReadFile[0].IndexOf(X6_ValIdx);
                    var Y6_PressInicial = lstDblReturnReadFile[6].ElementAt(X6_PosPressInicial);

                    _modelGVL.GVL_T10.rPressaoInicialCS = Y6_PressInicial;
                    _modelGVL.GVL_T10.rPressaoFinalCS = Y5_PressFinal;
                    _modelGVL.GVL_T10.rPerdaPressaoCS = Y6_PressInicial - Y5_PressFinal;

                    #endregion

                    #region Calculo dos Consumidores Utilizados

                    _modelGVL.GVL_T10.iConsumidoresCP = 0;
                    _modelGVL.GVL_T10.iConsumidoresCS = 0;

                    #endregion

                    _modelGVL.GVL_T10.bCalculaResultados = false;

                    _modelGVL.GVL_Graficos.bDadosCalculados = true;
                }

                HelperTestBase.Model_GVL.helperTestBase_ModelGVL_Test = HelperTestBase.Model_GVL.GVL_T10;

                HelperTestBase.Model_GVL = _modelGVL;

                #endregion

            }
            catch (Exception ex)
            {
                var err = ex.Message;
                throw;
            }

            return _modelGVL;

            #endregion
        }


        #endregion

        #region T11 - Calculos Ajustes - ET_Adjustment_ActuationSlow
        public Model_GVL CalcGraphT11_ET_ActuationSlow(bool bCalculaResultados, List<double>[] lstDblReturnReadFile)
        {
            #region PROGRAM T11_Calculos_Resultados

            try
            {
                #region Limpa ultimos resultados

                dictVarList.Clear();

                _modelGVL.GVL_T11.rForcaMaxima = 0; //Zera o ultimo valor de força obtido
                _modelGVL.GVL_T11.rGradienteForcaAvanco = 0; //Zera o ultimo valor obtido
                _modelGVL.GVL_T11.rGradienteForcaRetorno = 0; //Zera o ultimo valor obtido
                _modelGVL.GVL_T11.rGradienteDeslocamentoAvanco = 0; //Zera o ultimo valor obtido
                _modelGVL.GVL_T11.rGradienteDeslocamentoRetorno = 0; //Zera o ultimo valor obtido
                _modelGVL.GVL_T11.iConsumidoresCP = 0;
                _modelGVL.GVL_T11.iConsumidoresCS = 0;

                _modelGVL.GVL_T11.bCalculaResultados = bCalculaResultados;

                #region VARIABLES

                long diUbound = 0; //  ; DINT;
                long di = 0; //  ; DINT;
                double rForcaInicialGradiente = 0; //  ; REAL;
                double rForcaFinalGradiente = 0; //  ; REAL;
                double rDeslocamentoInicialGradiente = 0; //   ; REAL;
                double rDeslocamentoFinalGradiente = 0; //  ; REAL;
                double rTempoInicialGradiente = 0; //  ; REAL;
                double rTempoFinalGradiente = 0; //   ; REAL;

                #endregion

                #endregion

                #region Variaveis Grafico

                _modelGVL.GVL_Graficos.rEscalaX = 1500;
                _modelGVL.GVL_Graficos.EixoX.wsTLLabel = "AxesChart.1";
                _modelGVL.GVL_Graficos.rEscalaY1 = 150;
                _modelGVL.GVL_Graficos.EixoY1.wsTLLabel = "AxesChart.3";
                _modelGVL.GVL_Graficos.rEscalaY2 = 150;
                _modelGVL.GVL_Graficos.EixoY2.wsTLLabel = "AxesChart.4";
                _modelGVL.GVL_Graficos.rEscalaY3 = 0;
                _modelGVL.GVL_Graficos.EixoY3.wsTLLabel = string.Empty;
                _modelGVL.GVL_Graficos.rEscalaY4 = 0;
                _modelGVL.GVL_Graficos.EixoY4.wsTLLabel = string.Empty;

                _modelGVL.GVL_Graficos.strNomeEixoX = "Time (s)";
                _modelGVL.GVL_Graficos.strNomeEixoY1 = "Input Force (N)";
                _modelGVL.GVL_Graficos.strNomeEixoY2 = "Input Travel (mm)";
                _modelGVL.GVL_Graficos.strNomeEixoY3 = string.Empty;
                _modelGVL.GVL_Graficos.strNomeEixoY4 = string.Empty;

                _modelGVL.GVL_Graficos.strUnidadeX = "s";
                _modelGVL.GVL_Graficos.strUnidadeY1 = "N";
                _modelGVL.GVL_Graficos.strUnidadeY2 = "mm";
                _modelGVL.GVL_Graficos.strUnidadeY3 = string.Empty;
                _modelGVL.GVL_Graficos.strUnidadeY4 = string.Empty;

                _modelGVL.GVL_Graficos.bOcultaY2 = false;
                _modelGVL.GVL_Graficos.bOcultaY3 = true;
                _modelGVL.GVL_Graficos.bOcultaY4 = true;

                #endregion

                #region Varriaveis Array Dados

                //os arrays dinamicos obtidos neste teste contem as seguintes grandezas:
                //GVL_Graficos.arrVarX[GVL_Graficos.diBuffer] := TIME_TO_REAL(etTempoCiclo)/1000;
                //GVL_Graficos.arrVarY1[GVL_Graficos.diBuffer] := rForcaEntradaBooster_N_Lin;
                //GVL_Graficos.arrVarY3[GVL_Graficos.diBuffer] := rDeslocamentoEntradaBooster_mm_Lin;

                ClearArrayGVL_Graficos();

                _modelGVL.GVL_Graficos.arrVarTimeStamp = lstDblReturnReadFile[0].ToArray();
                _modelGVL.GVL_Graficos.arrVarX = lstDblReturnReadFile[0].ToArray();
                _modelGVL.GVL_Graficos.arrVarY1 = lstDblReturnReadFile[2].ToArray();
                _modelGVL.GVL_Graficos.arrVarY3 = lstDblReturnReadFile[5].ToArray();

                #endregion

                #region Calculos

                if (_modelGVL.GVL_T11.bCalculaResultados)
                {
                    _modelGVL.GVL_T11 = HelperTestBase.Model_GVL.GVL_T11;

                    //Define o ponto maximo do array que foi plotado durante o teste
                    _modelGVL.GVL_Graficos.diBuffer = lstDblReturnReadFile[0].Count() > 0 ? lstDblReturnReadFile[0].Count() : 0;

                    diUbound = _modelGVL.GVL_Graficos.diBuffer; //Define o ponto maximo do array que foi plotado durante o teste

                    #region Loop para identificar a forca maxima do teste, e armazenar o ponto de inflexao do teste (quando o atuador comeca a retornar)
                    //========================================================================================================================================================

                    for (di = 0; di < diUbound; di++)
                    {
                        if (_modelGVL.GVL_Graficos.arrVarY1[di] > _modelGVL.GVL_T11.rForcaMaxima)
                        {
                            _modelGVL.GVL_T11.rForcaMaxima = _modelGVL.GVL_Graficos.arrVarY1[di]; //Atualiza o valor de forca maxima com o maior valor obtido no array
                            _modelGVL.GVL_T11.diPosicaoForcaMaxima = di; //Indica em qual posicao do array esta a forca maxima (pico do grafico, aonde comeca o retorno do atuador)
                        }
                    }

                    //========================================================================================================================================================
                    #endregion

                    #region Calculo do gradiente de aplicacao de força no avanço
                    //========================================================================================================================================================

                    //Busca no array o momento em que a forca comecou a subir (forca >= 100N) e o tempo decorrido desta forca
                    for (di = 0; di <= _modelGVL.GVL_T11.diPosicaoForcaMaxima; di++)
                    {
                        if (_modelGVL.GVL_Graficos.arrVarY1[di] >= 100)//forca comecou a subir (>=100N)
                        {
                            rForcaInicialGradiente = _modelGVL.GVL_Graficos.arrVarY1[di]; //Valor forca inicial para calculo 
                            rTempoInicialGradiente = _modelGVL.GVL_Graficos.arrVarTimeStamp[di]; //Valor to tempo em ms inicial para calculo

                            break; //Encerra a busca pela forca inicial
                        }
                    }

                    //Define a forca final e o tempo final do gradiente como a FMAX obtida no calculo anterior, utilizando seu indice para coletar o tempo respectivo
                    rForcaFinalGradiente = _modelGVL.GVL_Graficos.arrVarY1[_modelGVL.GVL_T11.diPosicaoForcaMaxima];
                    rTempoFinalGradiente = _modelGVL.GVL_Graficos.arrVarTimeStamp[_modelGVL.GVL_T11.diPosicaoForcaMaxima];

                    //Calcula o gradiente de aplicacao de forca no avanco
                    _modelGVL.GVL_T11.rGradienteForcaAvanco = (rForcaFinalGradiente - rForcaInicialGradiente) / (rTempoFinalGradiente - rTempoInicialGradiente);
                    //========================================================================================================================================================

                    #endregion

                    #region Calculo do gradiente de aplicacao de força no retorno
                    //========================================================================================================================================================

                    //Busca no array o momento em que a forca caiu abaixo de 100N (forca <= 100N) e o tempo decorrido desta forca
                    for (di = _modelGVL.GVL_T11.diPosicaoForcaMaxima; di < diUbound; di++)
                    {
                        if (_modelGVL.GVL_Graficos.arrVarY1[di] <= 100) //Forca proxima de 0 (<=100N)
                        {
                            rForcaFinalGradiente = _modelGVL.GVL_Graficos.arrVarY1[di]; //Valor forca final para calculo 
                            rTempoFinalGradiente = _modelGVL.GVL_Graficos.arrVarTimeStamp[di]; //Valor to tempo em ms final para calculo

                            break; //Encerra a busca pela forca final
                        }
                    }

                    //Define a forca inicial e o tempo inicial do gradiente como a FMAX obtida no calculo anterior, utilizando seu indice para coletar o tempo respectivo
                    rForcaInicialGradiente = _modelGVL.GVL_Graficos.arrVarY1[_modelGVL.GVL_T11.diPosicaoForcaMaxima];
                    rTempoInicialGradiente = _modelGVL.GVL_Graficos.arrVarTimeStamp[_modelGVL.GVL_T11.diPosicaoForcaMaxima];

                    //Calcula o gradiente de aplicacao de forca no retorno
                    _modelGVL.GVL_T11.rGradienteForcaRetorno = (rForcaFinalGradiente - rForcaInicialGradiente) / (rTempoFinalGradiente - rTempoInicialGradiente);
                    //========================================================================================================================================================
                    #endregion

                    #region Calculo do gradiente de avanço 
                    //========================================================================================================================================================

                    //Busca no array o momento em que o deslocamento comecou a variar (deslocamento >= 1)
                    for (di = 0; di <= _modelGVL.GVL_T11.diPosicaoForcaMaxima; di++)
                    {
                        if (_modelGVL.GVL_Graficos.arrVarY3[di] >= 1) //Deslocamento >= 1mm
                        {
                            rDeslocamentoInicialGradiente = _modelGVL.GVL_Graficos.arrVarY3[di]; //Valor deslocamento inicial para calculo 
                            rTempoInicialGradiente = _modelGVL.GVL_Graficos.arrVarTimeStamp[di]; //Valor to tempo em ms inicial para calculo

                            break; //Encerra a busca pelo deslocamento inicial
                        }
                    }

                    //Define a forca final e o tempo final do gradiente como a FMAX obtida no calculo anterior, utilizando seu indice para coletar o tempo respectivo
                    rDeslocamentoFinalGradiente = _modelGVL.GVL_Graficos.arrVarY3[_modelGVL.GVL_T11.diPosicaoForcaMaxima];
                    rTempoFinalGradiente = _modelGVL.GVL_Graficos.arrVarTimeStamp[_modelGVL.GVL_T11.diPosicaoForcaMaxima];

                    //Calcula o gradiente de aplicacao de forca no avanco
                    _modelGVL.GVL_T11.rGradienteDeslocamentoAvanco = (rDeslocamentoFinalGradiente - rDeslocamentoInicialGradiente) / (rTempoFinalGradiente - rTempoInicialGradiente);
                    //========================================================================================================================================================

                    #endregion

                    #region Calculo do gradiente de deslocamento no retorno

                    //========================================================================================================================================================

                    //Busca no array o momento em que o deslocamento <= 1
                    for (di = _modelGVL.GVL_T11.diPosicaoForcaMaxima; di < diUbound; di++)
                    {
                        if (_modelGVL.GVL_Graficos.arrVarY3[di] <= 1) //Deslocamento <= 1
                        {
                            rDeslocamentoFinalGradiente = _modelGVL.GVL_Graficos.arrVarY3[di]; //Deslocamento final para calculo 
                            rTempoFinalGradiente = _modelGVL.GVL_Graficos.arrVarTimeStamp[di]; //Valor to tempo em ms final para calculo

                            break; //Encerra a busca pelo deslocamento final
                        }
                    }


                    //Define o deslocamento inicial e o tempo inicial do gradiente como a FMAX obtida no calculo anterior, utilizando seu indice para coletar o tempo respectivo
                    rDeslocamentoInicialGradiente = _modelGVL.GVL_Graficos.arrVarY3[_modelGVL.GVL_T11.diPosicaoForcaMaxima];
                    rTempoInicialGradiente = _modelGVL.GVL_Graficos.arrVarTimeStamp[_modelGVL.GVL_T11.diPosicaoForcaMaxima];

                    //Calcula o gradiente de aplicacao de forca no retorno
                    _modelGVL.GVL_T11.rGradienteDeslocamentoRetorno = (rDeslocamentoFinalGradiente - rDeslocamentoInicialGradiente) / (rTempoFinalGradiente - rTempoInicialGradiente);
                    //========================================================================================================================================================

                    #endregion

                    #region Calculo dos Consumidores Utilizados

                    //========================================================================================================================================================

                    _modelGVL.GVL_T11.iConsumidoresCP = 0;
                    _modelGVL.GVL_T11.iConsumidoresCS = 0;

                    HelperTestBase.Model_GVL.GVL_Parametros.iTipoConsumidores = HelperMODBUS.CS_wTipoConsumidores;

                    if (HelperMODBUS.CS_wTipoConsumidores != 2)
                    {
                        _modelGVL.GVL_T11.iConsumidoresCP = 0;
                        _modelGVL.GVL_T11.iConsumidoresCS = 0;
                    }
                    else
                    {
                        //HelperMODBUS.CS_wStatusLiga17MangueirasCS 
                        if (HelperMODBUS.CS_wStatusLiga1MangueiraCP)
                            _modelGVL.GVL_T11.iConsumidoresCP = _modelGVL.GVL_T11.iConsumidoresCP + 1;

                        if (HelperMODBUS.CS_wStatusLiga2MangueirasCP)
                            _modelGVL.GVL_T11.iConsumidoresCP = _modelGVL.GVL_T11.iConsumidoresCP + 2;

                        if (HelperMODBUS.CS_wStatusLiga4MangueirasCP)
                            _modelGVL.GVL_T11.iConsumidoresCP = _modelGVL.GVL_T11.iConsumidoresCP + 4;

                        if (HelperMODBUS.CS_wStatusLiga8MangueirasCP)
                            _modelGVL.GVL_T11.iConsumidoresCP = _modelGVL.GVL_T11.iConsumidoresCP + 8;

                        if (HelperMODBUS.CS_wStatusLiga10MangueirasCP)
                            _modelGVL.GVL_T11.iConsumidoresCP = _modelGVL.GVL_T11.iConsumidoresCP + 10;

                        if (HelperMODBUS.CS_wStatusLiga17MangueirasCP)
                            _modelGVL.GVL_T11.iConsumidoresCP = _modelGVL.GVL_T11.iConsumidoresCP + 17;

                        if (HelperMODBUS.CS_wStatusLiga1MangueiraCS)
                            _modelGVL.GVL_T11.iConsumidoresCS = _modelGVL.GVL_T11.iConsumidoresCS + 1;

                        if (HelperMODBUS.CS_wStatusLiga2MangueirasCS)
                            _modelGVL.GVL_T11.iConsumidoresCS = _modelGVL.GVL_T11.iConsumidoresCS + 2;

                        if (HelperMODBUS.CS_wStatusLiga4MangueirasCS)
                            _modelGVL.GVL_T11.iConsumidoresCS = _modelGVL.GVL_T11.iConsumidoresCS + 4;

                        if (HelperMODBUS.CS_wStatusLiga8MangueirasCS)
                            _modelGVL.GVL_T11.iConsumidoresCS = _modelGVL.GVL_T11.iConsumidoresCS + 8;

                        if (HelperMODBUS.CS_wStatusLiga10MangueirasCS)
                            _modelGVL.GVL_T11.iConsumidoresCS = _modelGVL.GVL_T11.iConsumidoresCS + 10;

                        if (HelperMODBUS.CS_wStatusLiga17MangueirasCS)
                            _modelGVL.GVL_T11.iConsumidoresCS = _modelGVL.GVL_T11.iConsumidoresCS + 17;
                    }
                    //============================. ============================================================================================================================

                    #endregion

                    _modelGVL.GVL_T11.bCalculaResultados = false;

                    _modelGVL.GVL_Graficos.bDadosCalculados = true;
                }

                HelperTestBase.Model_GVL.helperTestBase_ModelGVL_Test = HelperTestBase.Model_GVL.GVL_T11;

                HelperTestBase.Model_GVL = _modelGVL;

                #endregion

            }
            catch (Exception ex)
            {
                var err = ex.Message;
                throw;
            }

            return _modelGVL;

            #endregion
        }


        #endregion

        #region T12 -Calculos Ajustes - ET_Adjustment_ActuationFast

        public Model_GVL CalcGraphT12_ET_ActuationFast(bool bCalculaResultados, List<double>[] lstDblReturnReadFile)
        {
            #region PROGRAM T12_Calculos_Resultados

            try
            {
                #region Limpa ultimos resultados

                dictVarList.Clear();
                _modelGVL.GVL_T12.rForcaMaxima = 0; //Zera o ultimo valor de força obtido
                _modelGVL.GVL_T12.diPosicaoForcaMaxima = 0;
                _modelGVL.GVL_T12.rDeslocamentoMaximo = 0;
                _modelGVL.GVL_T12.rGradienteForcaAvanco = 0; //Zera o ultimo valor obtido
                _modelGVL.GVL_T12.rGradienteForcaRetorno = 0; //Zera o ultimo valor obtido
                _modelGVL.GVL_T12.rGradienteDeslocamentoAvanco = 0; //Zera o ultimo valor obtido
                _modelGVL.GVL_T12.rGradienteDeslocamentoRetorno = 0; //Zera o ultimo valor obtido
                _modelGVL.GVL_T12.iConsumidoresCP = 0;
                _modelGVL.GVL_T12.iConsumidoresCS = 0;
                _modelGVL.GVL_T12.rForcaFinalTempoAtuacao_N = 0; //Valor em N calculado para avanco
                _modelGVL.GVL_T12.rForcaRetornoTempoAtuacao_N = 0; //Valor em N calculado para retorno
                _modelGVL.GVL_T12.rTempoAtuacao = 0;
                _modelGVL.GVL_T12.rTempoRetorno = 0;
                _modelGVL.GVL_T12.rGradienteForcaAvanco = 0;
                _modelGVL.GVL_T12.rGradienteDeslocamentoAvanco = 0;
                _modelGVL.GVL_T12.rGradienteForcaRetorno = 0;
                _modelGVL.GVL_T12.rGradienteDeslocamentoRetorno = 0;
                _modelGVL.GVL_T12.rPressaoMaximaCP_bar = 0;
                _modelGVL.GVL_T12.rPressaoMaximaCS_bar = 0;

                _modelGVL.GVL_T12.bCalculaResultados = bCalculaResultados;

                #region VARIABLES
                long diUbound = 0; //  ; DINT;
                long di = 0; //  ; DINT;
                double rForcaInicialGradiente = 0; //  ; REAL;
                double rForcaFinalGradiente = 0; //  ; REAL;
                double rDeslocamentoInicialGradiente = 0; //   ; REAL;
                double rDeslocamentoFinalGradiente = 0; //  ; REAL;
                double rTempoInicialGradiente = 0; //  ; REAL;
                double rTempoFinalGradiente = 0; //   ; REAL;
                double rForcaInicialAvanco = 0;
                double rTempoInicialAvanco = 0;
                double rForcaFinalAvanco = 0;
                double rTempoFinalAvanco = 0;
                double rForcaInicialRetorno = 0;
                double rTempoInicialRetorno = 0;
                double rForcaFinalRetorno = 0;
                double rTempoFinalRetorno = 0;

                #endregion

                #endregion

                #region Variaveis Grafico

                _modelGVL.GVL_Graficos.rEscalaX = 1500;
                _modelGVL.GVL_Graficos.EixoX.wsTLLabel = "AxesChart.1";
                _modelGVL.GVL_Graficos.rEscalaY1 = 150;
                _modelGVL.GVL_Graficos.EixoY1.wsTLLabel = "AxesChart.3";
                _modelGVL.GVL_Graficos.rEscalaY2 = 150;
                _modelGVL.GVL_Graficos.EixoY2.wsTLLabel = "AxesChart.4";
                _modelGVL.GVL_Graficos.rEscalaY3 = 0;
                _modelGVL.GVL_Graficos.EixoY3.wsTLLabel = string.Empty;
                _modelGVL.GVL_Graficos.rEscalaY4 = 0;
                _modelGVL.GVL_Graficos.EixoY4.wsTLLabel = string.Empty;

                _modelGVL.GVL_Graficos.strNomeEixoX = "Time (s)";
                _modelGVL.GVL_Graficos.strNomeEixoY1 = "Input Force (N)";
                _modelGVL.GVL_Graficos.strNomeEixoY2 = "Input Travel (mm)";
                _modelGVL.GVL_Graficos.strNomeEixoY3 = "Pressure PC (bar)";
                _modelGVL.GVL_Graficos.strNomeEixoY4 = "Pressure SC (bar)";

                _modelGVL.GVL_Graficos.strUnidadeX = "s";
                _modelGVL.GVL_Graficos.strUnidadeY1 = "N";
                _modelGVL.GVL_Graficos.strUnidadeY2 = "mm";
                _modelGVL.GVL_Graficos.strUnidadeY3 = "bar";
                _modelGVL.GVL_Graficos.strUnidadeY4 = "bar";

                _modelGVL.GVL_Graficos.bOcultaY2 = false;
                _modelGVL.GVL_Graficos.bOcultaY3 = true;
                _modelGVL.GVL_Graficos.bOcultaY4 = true;

                #endregion

                #region Varriaveis Array Dados

                //os arrays dinamicos obtidos neste teste contem as seguintes grandezas:
                //GVL_Graficos.arrVarX[GVL_Graficos.diBuffer] := TIME_TO_REAL(etTempoCiclo)/1000;
                //GVL_Graficos.arrVarY1[GVL_Graficos.diBuffer] := rForcaEntradaBooster_N_Lin;
                //GVL_Graficos.arrVarY2[GVL_Graficos.diBuffer] := rDeslocamentoEntradaBooster_mm_Lin;
                //GVL_Graficos.arrVarY3[GVL_Graficos.diBuffer] := rPressaoCP_Bar_Lin;
                //GVL_Graficos.arrVarY4[GVL_Graficos.diBuffer] := rPressaoCS_Bar_Lin;

                ClearArrayGVL_Graficos();

                _modelGVL.GVL_Graficos.arrVarTimeStamp = lstDblReturnReadFile[0].ToArray();
                _modelGVL.GVL_Graficos.arrVarX = lstDblReturnReadFile[0].ToArray();
                _modelGVL.GVL_Graficos.arrVarY1 = lstDblReturnReadFile[2].ToArray();
                _modelGVL.GVL_Graficos.arrVarY2 = lstDblReturnReadFile[5].ToArray();
                _modelGVL.GVL_Graficos.arrVarY3 = lstDblReturnReadFile[7].ToArray();
                _modelGVL.GVL_Graficos.arrVarY4 = lstDblReturnReadFile[6].ToArray();

                #endregion

                #region Calculos

                if (_modelGVL.GVL_T12.bCalculaResultados)
                {
                    _modelGVL.GVL_T12 = HelperTestBase.Model_GVL.GVL_T12;

                    //Define o ponto maximo do array que foi plotado durante o teste
                    _modelGVL.GVL_Graficos.diBuffer = lstDblReturnReadFile[0].Count() > 0 ? lstDblReturnReadFile[0].Count() : 0;

                    diUbound = _modelGVL.GVL_Graficos.diBuffer; //Define o ponto maximo do array que foi plotado durante o teste

                    #region Loop para identificar a forca maxima do teste, e armazenar o ponto de inflexao do teste (quando o atuador comeca a retornar)
                    //========================================================================================================================================================

                    for (di = 0; di < diUbound; di++)
                    {
                        if (_modelGVL.GVL_Graficos.arrVarY1[di] > _modelGVL.GVL_T12.rForcaMaxima)
                        {
                            _modelGVL.GVL_T12.rForcaMaxima = _modelGVL.GVL_Graficos.arrVarY1[di]; //Atualiza o valor de forca maxima com o maior valor obtido no array
                            _modelGVL.GVL_T12.diPosicaoForcaMaxima = di; //Indica em qual posicao do array esta a forca maxima (pico do grafico, aonde comeca o retorno do atuador)
                        }
                    }

                    //========================================================================================================================================================
                    #endregion

                    #region Loop para identificar o deslocamento maximo
                    //========================================================================================================================================================

                    for (di = 0; di < diUbound; di++)
                    {
                        if (_modelGVL.GVL_Graficos.arrVarY2[di] > _modelGVL.GVL_T12.rDeslocamentoMaximo)
                        {
                            _modelGVL.GVL_T12.rDeslocamentoMaximo = _modelGVL.GVL_Graficos.arrVarY2[di]; //Atualiza o valor de deslocamento maximo
                        }
                    }
                    #endregion

                    #region Calculo do gradiente de aplicacao de força no avanço
                    //========================================================================================================================================================

                    //Busca no array o momento em que a forca comecou a subir (forca >= 100N) e o tempo decorrido desta forca
                    for (di = 0; di <= _modelGVL.GVL_T12.diPosicaoForcaMaxima; di++)
                    {
                        if (_modelGVL.GVL_Graficos.arrVarY1[di] >= 100)//forca comecou a subir (>=100N)
                        {
                            rForcaInicialGradiente = _modelGVL.GVL_Graficos.arrVarY1[di]; //Valor forca inicial para calculo 
                            rTempoInicialGradiente = _modelGVL.GVL_Graficos.arrVarTimeStamp[di]; //Valor to tempo em ms inicial para calculo

                            break; //Encerra a busca pela forca inicial
                        }
                    }

                    //Define a forca final e o tempo final do gradiente como a FMAX obtida no calculo anterior, utilizando seu indice para coletar o tempo respectivo
                    rForcaFinalGradiente = _modelGVL.GVL_Graficos.arrVarY1[_modelGVL.GVL_T12.diPosicaoForcaMaxima];
                    rTempoFinalGradiente = _modelGVL.GVL_Graficos.arrVarTimeStamp[_modelGVL.GVL_T12.diPosicaoForcaMaxima];

                    //Calcula o gradiente de aplicacao de forca no avanco
                    _modelGVL.GVL_T12.rGradienteForcaAvanco = (rForcaFinalGradiente - rForcaInicialGradiente) / (rTempoFinalGradiente - rTempoInicialGradiente);
                    //========================================================================================================================================================

                    #endregion

                    #region Calculo do gradiente de aplicacao de força no retorno
                    //========================================================================================================================================================

                    //Busca no array o momento em que a forca caiu abaixo de 100N (forca <= 100N) e o tempo decorrido desta forca
                    for (di = _modelGVL.GVL_T12.diPosicaoForcaMaxima; di < diUbound; di++)
                    {
                        if (_modelGVL.GVL_Graficos.arrVarY1[di] <= 100) //Forca proxima de 0 (<=100N)
                        {
                            rForcaFinalGradiente = _modelGVL.GVL_Graficos.arrVarY1[di]; //Valor forca final para calculo 
                            rTempoFinalGradiente = _modelGVL.GVL_Graficos.arrVarTimeStamp[di]; //Valor to tempo em ms final para calculo

                            break; //Encerra a busca pela forca final
                        }
                    }

                    //Define a forca inicial e o tempo inicial do gradiente como a FMAX obtida no calculo anterior, utilizando seu indice para coletar o tempo respectivo
                    rForcaInicialGradiente = _modelGVL.GVL_Graficos.arrVarY1[_modelGVL.GVL_T12.diPosicaoForcaMaxima];
                    rTempoInicialGradiente = _modelGVL.GVL_Graficos.arrVarTimeStamp[_modelGVL.GVL_T12.diPosicaoForcaMaxima];

                    //Calcula o gradiente de aplicacao de forca no retorno
                    _modelGVL.GVL_T12.rGradienteForcaRetorno = (rForcaFinalGradiente - rForcaInicialGradiente) / (rTempoFinalGradiente - rTempoInicialGradiente);
                    //========================================================================================================================================================
                    #endregion

                    #region Calculo do gradiente de avanço 
                    //========================================================================================================================================================

                    //Busca no array o momento em que o deslocamento comecou a variar (deslocamento >= 1)
                    for (di = 0; di <= _modelGVL.GVL_T12.diPosicaoForcaMaxima; di++)
                    {
                        if (_modelGVL.GVL_Graficos.arrVarY3[di] >= 1) //Deslocamento >= 1mm
                        {
                            rDeslocamentoInicialGradiente = _modelGVL.GVL_Graficos.arrVarY3[di]; //Valor deslocamento inicial para calculo 
                            rTempoInicialGradiente = _modelGVL.GVL_Graficos.arrVarTimeStamp[di]; //Valor to tempo em ms inicial para calculo

                            break; //Encerra a busca pelo deslocamento inicial
                        }
                    }

                    //Define a forca final e o tempo final do gradiente como a FMAX obtida no calculo anterior, utilizando seu indice para coletar o tempo respectivo
                    rDeslocamentoFinalGradiente = _modelGVL.GVL_Graficos.arrVarY3[_modelGVL.GVL_T12.diPosicaoForcaMaxima];
                    rTempoFinalGradiente = _modelGVL.GVL_Graficos.arrVarTimeStamp[_modelGVL.GVL_T12.diPosicaoForcaMaxima];

                    //Calcula o gradiente de aplicacao de forca no avanco
                    _modelGVL.GVL_T12.rGradienteDeslocamentoAvanco = (rDeslocamentoFinalGradiente - rDeslocamentoInicialGradiente) / (rTempoFinalGradiente - rTempoInicialGradiente);
                    //========================================================================================================================================================

                    #endregion

                    #region Calculo do gradiente de deslocamento no retorno

                    //========================================================================================================================================================

                    //Busca no array o momento em que o deslocamento <= 1
                    for (di = _modelGVL.GVL_T12.diPosicaoForcaMaxima; di < diUbound; di++)
                    {
                        if (_modelGVL.GVL_Graficos.arrVarY3[di] <= 1) //Deslocamento <= 1
                        {
                            rDeslocamentoFinalGradiente = _modelGVL.GVL_Graficos.arrVarY3[di]; //Deslocamento final para calculo 
                            rTempoFinalGradiente = _modelGVL.GVL_Graficos.arrVarTimeStamp[di]; //Valor to tempo em ms final para calculo

                            break; //Encerra a busca pelo deslocamento final
                        }
                    }


                    //Define o deslocamento inicial e o tempo inicial do gradiente como a FMAX obtida no calculo anterior, utilizando seu indice para coletar o tempo respectivo
                    rDeslocamentoInicialGradiente = _modelGVL.GVL_Graficos.arrVarY3[_modelGVL.GVL_T12.diPosicaoForcaMaxima];
                    rTempoInicialGradiente = _modelGVL.GVL_Graficos.arrVarTimeStamp[_modelGVL.GVL_T12.diPosicaoForcaMaxima];

                    //Calcula o gradiente de aplicacao de forca no retorno
                    _modelGVL.GVL_T12.rGradienteDeslocamentoRetorno = (rDeslocamentoFinalGradiente - rDeslocamentoInicialGradiente) / (rTempoFinalGradiente - rTempoInicialGradiente);
                    //========================================================================================================================================================

                    #endregion

                    #region Calcula o tempo de avanco

                    //Encontra o tempo e forca referentes ao parametro de forca inicial do calculo
                    for (di = 0; di <= _modelGVL.GVL_T12.diPosicaoForcaMaxima; di++)
                    {
                        if (_modelGVL.GVL_Graficos.arrVarY1[di] >= _modelGVL.GVL_T12.rForcaInicialTempoAtuacao_N) //Forca >= Forca inicial digitada em N
                        {
                            rForcaInicialAvanco = _modelGVL.GVL_Graficos.arrVarY1[di]; //Valor forca inicial para calculo 
                            rTempoInicialAvanco = _modelGVL.GVL_Graficos.arrVarTimeStamp[di]; //Valor to tempo em ms inicial para calculo
                            break; //Encerra a busca pela forca inicial
                        }
                    }


                    //Calcula o valor de forca maxima desejado como referencia (Porcentagem digitada no campo * fmax obtida no teste)
                    double rForcaFinalTempoAtuacao_N = (_modelGVL.GVL_T12.rForcaFinalTempoAtuacao / 100) * _modelGVL.GVL_T12.rForcaMaxima;

                    //Encontra o tempo e forca referentes ao parametro de forca final do calculo de avanco, lembrando que eh percentual, por isso a multiplicacao anterior
                    for (di = 0; di < diUbound; di++)
                    {
                        if (_modelGVL.GVL_Graficos.arrVarY1[di] >= rForcaFinalTempoAtuacao_N) //Forca >= Forca final calculada em N
                        {
                            rForcaFinalAvanco = _modelGVL.GVL_Graficos.arrVarY1[di]; //Valor forca inicial para calculo 
                            rTempoFinalAvanco = _modelGVL.GVL_Graficos.arrVarTimeStamp[di]; //Valor to tempo em ms inicial para calculo
                            break; //Encerra a busca pela forca inicial
                        }
                    }

                    //Calcula o gradiente de aplicacao de forca no retorno
                    _modelGVL.GVL_T12.rTempoAtuacao = (rTempoFinalAvanco - rTempoInicialAvanco);

                    #endregion

                    #region Calcula o tempo de retorno                    
                    //Calcula o tempo de retorno
                    //Encontra o tempo e forca referentes ao parametro de forca inicial do calculo
                    double rForcaMaximaRetorno = _modelGVL.GVL_T12.rForcaMaxima * 0.9;

                    for (di = _modelGVL.GVL_T12.diPosicaoForcaMaxima; di < diUbound; di++)
                    {
                        if (_modelGVL.GVL_Graficos.arrVarY1[di] <= rForcaMaximaRetorno) //Forca <= Forca final calculada
                        {
                            rForcaInicialRetorno = _modelGVL.GVL_Graficos.arrVarY1[di]; //Valor forca inicial para calculo 
                            rTempoInicialRetorno = _modelGVL.GVL_Graficos.arrVarTimeStamp[di]; //Valor to tempo em ms inicial para calculo
                            break; //Encerra a busca pela forca inicial
                        }
                    }

                    //Calcula o valor de forca maxima desejado como referencia (Porcentagem digitada no campo * fmax obtida no teste)
                    double rForcaRetornoTempoAtuacao_N = (_modelGVL.GVL_T12.rForcaRetornoTempoAtuacao / 100) * _modelGVL.GVL_T12.rForcaMaxima;

                    //Encontra o tempo de retorno, partindo de fmax ate o ponto que a forca final foi atingida
                    for (di = _modelGVL.GVL_T12.diPosicaoForcaMaxima; di < diUbound; di++)
                    {
                        if (_modelGVL.GVL_Graficos.arrVarY1[di] <= rForcaRetornoTempoAtuacao_N) //Forca <= Forca final calculada
                        {
                            rForcaFinalRetorno = _modelGVL.GVL_Graficos.arrVarY1[di]; //Valor forca inicial para calculo 
                            rTempoFinalRetorno = _modelGVL.GVL_Graficos.arrVarTimeStamp[di]; //Valor to tempo em ms inicial para calculo
                            break; //Encerra a busca pela forca inicial
                        }
                    }

                    //Calcula o gradiente de aplicacao de forca no retorno
                    _modelGVL.GVL_T12.rTempoRetorno = (rTempoFinalRetorno - rTempoInicialRetorno);

                    #endregion

                    #region Loop para encontrar pressao maxima CP/CS
                    //========================================================================================================================================================
                    //Loop para encontrar pressao maxima CP
                    for (di = 0; di < diUbound; di++)
                    {
                        if (_modelGVL.GVL_Graficos.arrVarY3[di] > _modelGVL.GVL_T12.rPressaoMaximaCP_bar)
                        {
                            _modelGVL.GVL_T12.rPressaoMaximaCP_bar = _modelGVL.GVL_Graficos.arrVarY3[di];
                        }
                    }

                    //========================================================================================================================================================
                    //Loop para encontrar pressao maxima CS
                    for (di = 0; di < diUbound; di++)
                    {
                        if (GVL_Graficos.arrVarY4[di] > _modelGVL.GVL_T12.rPressaoMaximaCS_bar)
                        {
                            _modelGVL.GVL_T12.rPressaoMaximaCS_bar = GVL_Graficos.arrVarY4[di];
                        }
                    }

                    #endregion

                    #region Calculo dos Consumidores Utilizados

                    //========================================================================================================================================================

                    _modelGVL.GVL_T12.iConsumidoresCP = 0;
                    _modelGVL.GVL_T12.iConsumidoresCS = 0;

                    HelperTestBase.Model_GVL.GVL_Parametros.iTipoConsumidores = HelperMODBUS.CS_wTipoConsumidores;

                    if (HelperMODBUS.CS_wTipoConsumidores != 2)
                    {
                        _modelGVL.GVL_T12.iConsumidoresCP = 0;
                        _modelGVL.GVL_T12.iConsumidoresCS = 0;
                    }
                    else
                    {
                        //HelperMODBUS.CS_wStatusLiga17MangueirasCS 
                        if (HelperMODBUS.CS_wStatusLiga1MangueiraCP)
                            _modelGVL.GVL_T12.iConsumidoresCP = _modelGVL.GVL_T12.iConsumidoresCP + 1;

                        if (HelperMODBUS.CS_wStatusLiga2MangueirasCP)
                            _modelGVL.GVL_T12.iConsumidoresCP = _modelGVL.GVL_T12.iConsumidoresCP + 2;

                        if (HelperMODBUS.CS_wStatusLiga4MangueirasCP)
                            _modelGVL.GVL_T12.iConsumidoresCP = _modelGVL.GVL_T12.iConsumidoresCP + 4;

                        if (HelperMODBUS.CS_wStatusLiga8MangueirasCP)
                            _modelGVL.GVL_T12.iConsumidoresCP = _modelGVL.GVL_T12.iConsumidoresCP + 8;

                        if (HelperMODBUS.CS_wStatusLiga10MangueirasCP)
                            _modelGVL.GVL_T12.iConsumidoresCP = _modelGVL.GVL_T12.iConsumidoresCP + 10;

                        if (HelperMODBUS.CS_wStatusLiga17MangueirasCP)
                            _modelGVL.GVL_T12.iConsumidoresCP = _modelGVL.GVL_T12.iConsumidoresCP + 17;

                        if (HelperMODBUS.CS_wStatusLiga1MangueiraCS)
                            _modelGVL.GVL_T12.iConsumidoresCS = _modelGVL.GVL_T12.iConsumidoresCS + 1;

                        if (HelperMODBUS.CS_wStatusLiga2MangueirasCS)
                            _modelGVL.GVL_T12.iConsumidoresCS = _modelGVL.GVL_T12.iConsumidoresCS + 2;

                        if (HelperMODBUS.CS_wStatusLiga4MangueirasCS)
                            _modelGVL.GVL_T12.iConsumidoresCS = _modelGVL.GVL_T12.iConsumidoresCS + 4;

                        if (HelperMODBUS.CS_wStatusLiga8MangueirasCS)
                            _modelGVL.GVL_T12.iConsumidoresCS = _modelGVL.GVL_T12.iConsumidoresCS + 8;

                        if (HelperMODBUS.CS_wStatusLiga10MangueirasCS)
                            _modelGVL.GVL_T12.iConsumidoresCS = _modelGVL.GVL_T12.iConsumidoresCS + 10;

                        if (HelperMODBUS.CS_wStatusLiga17MangueirasCS)
                            _modelGVL.GVL_T12.iConsumidoresCS = _modelGVL.GVL_T12.iConsumidoresCS + 17;
                    }
                    //============================. ============================================================================================================================

                    #endregion

                    _modelGVL.GVL_T12.bCalculaResultados = false;

                    _modelGVL.GVL_Graficos.bDadosCalculados = true;
                }

                HelperTestBase.Model_GVL.helperTestBase_ModelGVL_Test = HelperTestBase.Model_GVL.GVL_T12;

                HelperTestBase.Model_GVL = _modelGVL;

                #endregion

            }
            catch (Exception ex)
            {
                var err = ex.Message;
                throw;
            }

            return _modelGVL;

            #endregion
        }


        #endregion

        #region T13 - Calculos verificacao Sensores - ET_PressureDifference
        public Model_GVL CalcGraphT13_ET_PressureDifference(bool bCalculaResultados, List<double>[] lstDblReturnReadFile)
        {
            #region PROGRAM T13_Calculos_Resultados

            try
            {
                #region Limpa ultimos resultados

                dictVarList.Clear();

                _modelGVL.GVL_T13.rForcaMaxima = 0; //Zera o ultimo valor de força obtido
                _modelGVL.GVL_T13.rGradienteForcaAvanco = 0; //Zera o ultimo valor obtido
                _modelGVL.GVL_T13.rGradienteForcaRetorno = 0; //Zera o ultimo valor obtido
                _modelGVL.GVL_T13.rGradienteDeslocamentoAvanco = 0; //Zera o ultimo valor obtido
                _modelGVL.GVL_T13.rGradienteDeslocamentoRetorno = 0; //Zera o ultimo valor obtido
                _modelGVL.GVL_T13.iConsumidoresCP = 0;
                _modelGVL.GVL_T13.iConsumidoresCS = 0;

                _modelGVL.GVL_T13.rDiferencaPressaoP1_bar = 0;
                _modelGVL.GVL_T13.rDiferencaPressaoP2_bar = 0;
                _modelGVL.GVL_T13.rDiferencaPressaoP3_bar = 0;
                _modelGVL.GVL_T13.rDiferencaPressaoP4_bar = 0;

                _modelGVL.GVL_T13.bCalculaResultados = bCalculaResultados;

                #region VARIABLES

                long diUbound = 0; //  ; DINT;
                long di = 0; //  ; DINT;
                double rForcaInicialGradiente = 0; //  ; REAL;
                double rForcaFinalGradiente = 0; //  ; REAL;
                double rDeslocamentoInicialGradiente = 0; //   ; REAL;
                double rDeslocamentoFinalGradiente = 0; //  ; REAL;
                double rTempoInicialGradiente = 0; //  ; REAL;
                double rTempoFinalGradiente = 0; //   ; REAL;
                double rPressaoCP_P1 = 0;//: REAL;
                double rPressaoCS_P1 = 0;//: REAL;
                double rPressaoCP_P2 = 0;//: REAL;
                double rPressaoCS_P2 = 0;//: REAL;
                double rPressaoCP_P3 = 0;//: REAL;
                double rPressaoCS_P3 = 0;//: REAL;
                double rPressaoCP_P4 = 0;//: REAL;
                double rPressaoCS_P4 = 0;//: REAL;

                #endregion

                #endregion

                #region Variaveis Grafico

                _modelGVL.GVL_Graficos.rEscalaX = 1500;
                _modelGVL.GVL_Graficos.EixoX.wsTLLabel = "AxesChart.1";
                _modelGVL.GVL_Graficos.rEscalaY1 = 150;
                _modelGVL.GVL_Graficos.EixoY1.wsTLLabel = "AxesChart.3";
                _modelGVL.GVL_Graficos.rEscalaY2 = 150;
                _modelGVL.GVL_Graficos.EixoY2.wsTLLabel = "AxesChart.4";
                _modelGVL.GVL_Graficos.rEscalaY3 = 0;
                _modelGVL.GVL_Graficos.EixoY3.wsTLLabel = string.Empty;
                _modelGVL.GVL_Graficos.rEscalaY4 = 0;
                _modelGVL.GVL_Graficos.EixoY4.wsTLLabel = string.Empty;

                _modelGVL.GVL_Graficos.strNomeEixoX = "Input Force (N)";
                _modelGVL.GVL_Graficos.strNomeEixoY1 = "Pressure PC (bar)";
                _modelGVL.GVL_Graficos.strNomeEixoY2 = "Pressure SC (bar)";
                _modelGVL.GVL_Graficos.strNomeEixoY3 = "Input Travel (mm)";
                _modelGVL.GVL_Graficos.strNomeEixoY4 = string.Empty;

                _modelGVL.GVL_Graficos.strUnidadeX = "N";
                _modelGVL.GVL_Graficos.strUnidadeY1 = "bar";
                _modelGVL.GVL_Graficos.strUnidadeY2 = "bar";
                _modelGVL.GVL_Graficos.strUnidadeY3 = "mm";
                _modelGVL.GVL_Graficos.strUnidadeY4 = string.Empty;

                _modelGVL.GVL_Graficos.bOcultaY2 = false;
                _modelGVL.GVL_Graficos.bOcultaY3 = true;
                _modelGVL.GVL_Graficos.bOcultaY4 = true;

                #endregion

                #region Varriaveis Array Dados

                //os arrays dinamicos obtidos neste teste contem as seguintes grandezas:
                //GVL_Graficos.arrVarX[GVL_Graficos.diBuffer] := rForcaEntradaBooster_N_Lin;
                //GVL_Graficos.arrVarY1[GVL_Graficos.diBuffer] := rPressaoCP_Bar_Lin;
                //GVL_Graficos.arrVarY2[GVL_Graficos.diBuffer] := rPressaoCS_Bar_Lin;
                //GVL_Graficos.arrVarY3[GVL_Graficos.diBuffer] := rDeslocamentoEntradaBooster_mm_Lin;

                ClearArrayGVL_Graficos();

                _modelGVL.GVL_Graficos.arrVarTimeStamp = lstDblReturnReadFile[0].ToArray();
                _modelGVL.GVL_Graficos.arrVarX = lstDblReturnReadFile[2].ToArray();
                _modelGVL.GVL_Graficos.arrVarY1 = lstDblReturnReadFile[7].ToArray();
                _modelGVL.GVL_Graficos.arrVarY2 = lstDblReturnReadFile[6].ToArray();
                _modelGVL.GVL_Graficos.arrVarY3 = lstDblReturnReadFile[5].ToArray();

                #endregion

                #region Calculos

                if (_modelGVL.GVL_T13.bCalculaResultados)
                {
                    _modelGVL.GVL_T13 = HelperTestBase.Model_GVL.GVL_T13;

                    //Define o ponto maximo do array que foi plotado durante o teste
                    _modelGVL.GVL_Graficos.diBuffer = lstDblReturnReadFile[0].Count() > 0 ? lstDblReturnReadFile[0].Count() : 0;

                    diUbound = _modelGVL.GVL_Graficos.diBuffer; //Define o ponto maximo do array que foi plotado durante o teste

                    #region Loop para identificar a forca maxima do teste, e armazenar o ponto de inflexao do teste (quando o atuador comeca a retornar)
                    //========================================================================================================================================================

                    for (di = 0; di < diUbound; di++)
                    {
                        if (_modelGVL.GVL_Graficos.arrVarX[di] > _modelGVL.GVL_T13.rForcaMaxima)
                        {
                            _modelGVL.GVL_T13.rForcaMaxima = _modelGVL.GVL_Graficos.arrVarX[di]; //Atualiza o valor de forca maxima com o maior valor obtido no array
                            _modelGVL.GVL_T13.diPosicaoForcaMaxima = di; //Indica em qual posicao do array esta a forca maxima (pico do grafico, aonde comeca o retorno do atuador)
                        }
                    }

                    //========================================================================================================================================================
                    #endregion

                    #region Calculo do gradiente de aplicacao de força no avanço
                    //========================================================================================================================================================

                    //Busca no array o momento em que a forca comecou a subir (forca >= 100N) e o tempo decorrido desta forca
                    for (di = 0; di <= _modelGVL.GVL_T13.diPosicaoForcaMaxima; di++)
                    {
                        if (_modelGVL.GVL_Graficos.arrVarX[di] >= 100)//forca comecou a subir (>=100N)
                        {
                            rForcaInicialGradiente = _modelGVL.GVL_Graficos.arrVarX[di]; //Valor forca inicial para calculo 
                            rTempoInicialGradiente = _modelGVL.GVL_Graficos.arrVarTimeStamp[di]; //Valor to tempo em ms inicial para calculo

                            break; //Encerra a busca pela forca inicial
                        }
                    }

                    //Define a forca final e o tempo final do gradiente como a FMAX obtida no calculo anterior, utilizando seu indice para coletar o tempo respectivo
                    rForcaFinalGradiente = _modelGVL.GVL_Graficos.arrVarX[_modelGVL.GVL_T13.diPosicaoForcaMaxima];
                    rTempoFinalGradiente = _modelGVL.GVL_Graficos.arrVarTimeStamp[_modelGVL.GVL_T13.diPosicaoForcaMaxima];

                    //Calcula o gradiente de aplicacao de forca no avanco
                    _modelGVL.GVL_T13.rGradienteForcaAvanco = (rForcaFinalGradiente - rForcaInicialGradiente) / (rTempoFinalGradiente - rTempoInicialGradiente);
                    //========================================================================================================================================================

                    #endregion

                    #region Calculo do gradiente de aplicacao de força no retorno
                    //========================================================================================================================================================

                    //Busca no array o momento em que a forca caiu abaixo de 100N (forca <= 100N) e o tempo decorrido desta forca
                    for (di = _modelGVL.GVL_T13.diPosicaoForcaMaxima; di < diUbound; di++)
                    {
                        if (_modelGVL.GVL_Graficos.arrVarX[di] <= 100) //Forca proxima de 0 (<=100N)
                        {
                            rForcaFinalGradiente = _modelGVL.GVL_Graficos.arrVarX[di]; //Valor forca final para calculo 
                            rTempoFinalGradiente = _modelGVL.GVL_Graficos.arrVarTimeStamp[di]; //Valor to tempo em ms final para calculo

                            break; //Encerra a busca pela forca final
                        }
                    }

                    //Define a forca inicial e o tempo inicial do gradiente como a FMAX obtida no calculo anterior, utilizando seu indice para coletar o tempo respectivo
                    rForcaInicialGradiente = _modelGVL.GVL_Graficos.arrVarX[_modelGVL.GVL_T13.diPosicaoForcaMaxima];
                    rTempoInicialGradiente = _modelGVL.GVL_Graficos.arrVarTimeStamp[_modelGVL.GVL_T13.diPosicaoForcaMaxima];

                    //Calcula o gradiente de aplicacao de forca no retorno
                    _modelGVL.GVL_T13.rGradienteForcaRetorno = (rForcaFinalGradiente - rForcaInicialGradiente) / (rTempoFinalGradiente - rTempoInicialGradiente);
                    //========================================================================================================================================================
                    #endregion

                    #region Calculo do gradiente de avanço 
                    //========================================================================================================================================================

                    //Busca no array o momento em que o deslocamento comecou a variar (deslocamento >= 1)
                    for (di = 0; di <= _modelGVL.GVL_T13.diPosicaoForcaMaxima; di++)
                    {
                        if (_modelGVL.GVL_Graficos.arrVarY3[di] >= 1) //Deslocamento >= 1mm
                        {
                            rDeslocamentoInicialGradiente = _modelGVL.GVL_Graficos.arrVarY3[di]; //Valor deslocamento inicial para calculo 
                            rTempoInicialGradiente = _modelGVL.GVL_Graficos.arrVarTimeStamp[di]; //Valor to tempo em ms inicial para calculo

                            break; //Encerra a busca pelo deslocamento inicial
                        }
                    }

                    //Define a forca final e o tempo final do gradiente como a FMAX obtida no calculo anterior, utilizando seu indice para coletar o tempo respectivo
                    rDeslocamentoFinalGradiente = _modelGVL.GVL_Graficos.arrVarY3[_modelGVL.GVL_T13.diPosicaoForcaMaxima];
                    rTempoFinalGradiente = _modelGVL.GVL_Graficos.arrVarTimeStamp[_modelGVL.GVL_T13.diPosicaoForcaMaxima];

                    //Calcula o gradiente de aplicacao de forca no avanco
                    _modelGVL.GVL_T13.rGradienteDeslocamentoAvanco = (rDeslocamentoFinalGradiente - rDeslocamentoInicialGradiente) / (rTempoFinalGradiente - rTempoInicialGradiente);
                    //========================================================================================================================================================

                    #endregion

                    #region Calculo do gradiente de deslocamento no retorno

                    //========================================================================================================================================================

                    //Busca no array o momento em que o deslocamento <= 1
                    for (di = _modelGVL.GVL_T13.diPosicaoForcaMaxima; di < diUbound; di++)
                    {
                        if (_modelGVL.GVL_Graficos.arrVarY3[di] <= 1) //Deslocamento <= 1
                        {
                            rDeslocamentoFinalGradiente = _modelGVL.GVL_Graficos.arrVarY3[di]; //Deslocamento final para calculo 
                            rTempoFinalGradiente = _modelGVL.GVL_Graficos.arrVarTimeStamp[di]; //Valor to tempo em ms final para calculo

                            break; //Encerra a busca pelo deslocamento final
                        }
                    }


                    //Define o deslocamento inicial e o tempo inicial do gradiente como a FMAX obtida no calculo anterior, utilizando seu indice para coletar o tempo respectivo
                    rDeslocamentoInicialGradiente = _modelGVL.GVL_Graficos.arrVarY3[_modelGVL.GVL_T13.diPosicaoForcaMaxima];
                    rTempoInicialGradiente = _modelGVL.GVL_Graficos.arrVarTimeStamp[_modelGVL.GVL_T13.diPosicaoForcaMaxima];

                    //Calcula o gradiente de aplicacao de forca no retorno
                    _modelGVL.GVL_T13.rGradienteDeslocamentoRetorno = (rDeslocamentoFinalGradiente - rDeslocamentoInicialGradiente) / (rTempoFinalGradiente - rTempoInicialGradiente);
                    //========================================================================================================================================================

                    #endregion

                    #region Loop para encontrar pressoes no ponto de medida 1
                    //========================================================================================================================================================
                    //Loop para encontrar pressoes no ponto de medida 1
                    for (di = 0; di <= _modelGVL.GVL_T13.diPosicaoForcaMaxima; di++)
                    {
                        if (_modelGVL.GVL_Graficos.arrVarY1[di] >= _modelGVL.GVL_T13.rSetPointDiferencaPressaoP1Avanco_Bar)
                        {
                            rPressaoCP_P1 = _modelGVL.GVL_Graficos.arrVarY1[di];
                            rPressaoCS_P1 = _modelGVL.GVL_Graficos.arrVarY2[di];
                            break;
                        }
                    }
                    _modelGVL.GVL_T13.rDiferencaPressaoP1_bar = rPressaoCP_P1 - rPressaoCS_P1;

                    #endregion

                    #region Loop para encontrar pressoes no ponto de medida 2
                    //========================================================================================================================================================
                    //Loop para encontrar pressoes no ponto de medida 2
                    for (di = 0; di <= _modelGVL.GVL_T13.diPosicaoForcaMaxima; di++)
                    {
                        if (_modelGVL.GVL_Graficos.arrVarY1[di] >= _modelGVL.GVL_T13.rSetPointDiferencaPressaoP2Avanco_Bar)
                        {
                            rPressaoCP_P2 = _modelGVL.GVL_Graficos.arrVarY1[di];
                            rPressaoCS_P2 = _modelGVL.GVL_Graficos.arrVarY2[di];
                            break;
                        }
                    }

                    _modelGVL.GVL_T13.rDiferencaPressaoP2_bar = rPressaoCP_P2 - rPressaoCS_P2;

                    #endregion

                    #region Loop para encontrar pressoes no ponto de medida 3
                    //========================================================================================================================================================
                    //Loop para encontrar pressoes no ponto de medida 3
                    for (di = _modelGVL.GVL_T13.diPosicaoForcaMaxima; di < diUbound; di++)
                    {
                        if (_modelGVL.GVL_Graficos.arrVarY1[di] <= _modelGVL.GVL_T13.rSetPointDiferencaPressaoP3Retorno_Bar)
                        {
                            rPressaoCP_P3 = _modelGVL.GVL_Graficos.arrVarY1[di];
                            rPressaoCS_P3 = _modelGVL.GVL_Graficos.arrVarY2[di];
                            break;
                        }
                    }

                    _modelGVL.GVL_T13.rDiferencaPressaoP3_bar = rPressaoCP_P3 - rPressaoCS_P3;

                    #endregion

                    #region Loop para encontrar pressoes no ponto de medida 4
                    //========================================================================================================================================================
                    //Loop para encontrar pressoes no ponto de medida 4
                    for (di = _modelGVL.GVL_T13.diPosicaoForcaMaxima; di < diUbound; di++)
                    {
                        if (_modelGVL.GVL_Graficos.arrVarY1[di] <= _modelGVL.GVL_T13.rSetPointDiferencaPressaoP4Retorno_Bar)
                        {
                            rPressaoCP_P4 = _modelGVL.GVL_Graficos.arrVarY1[di];
                            rPressaoCS_P4 = _modelGVL.GVL_Graficos.arrVarY2[di];
                            break;
                        }
                    }

                    _modelGVL.GVL_T13.rDiferencaPressaoP4_bar = rPressaoCP_P4 - rPressaoCS_P4;
                    #endregion

                    #region Calculo dos Consumidores Utilizados

                    //========================================================================================================================================================

                    _modelGVL.GVL_T13.iConsumidoresCP = 0;
                    _modelGVL.GVL_T13.iConsumidoresCS = 0;

                    HelperTestBase.Model_GVL.GVL_Parametros.iTipoConsumidores = HelperMODBUS.CS_wTipoConsumidores;

                    if (HelperMODBUS.CS_wTipoConsumidores != 2)
                    {
                        _modelGVL.GVL_T13.iConsumidoresCP = 0;
                        _modelGVL.GVL_T13.iConsumidoresCS = 0;
                    }
                    else
                    {
                        //HelperMODBUS.CS_wStatusLiga17MangueirasCS 
                        if (HelperMODBUS.CS_wStatusLiga1MangueiraCP)
                            _modelGVL.GVL_T13.iConsumidoresCP = _modelGVL.GVL_T13.iConsumidoresCP + 1;

                        if (HelperMODBUS.CS_wStatusLiga2MangueirasCP)
                            _modelGVL.GVL_T13.iConsumidoresCP = _modelGVL.GVL_T13.iConsumidoresCP + 2;

                        if (HelperMODBUS.CS_wStatusLiga4MangueirasCP)
                            _modelGVL.GVL_T13.iConsumidoresCP = _modelGVL.GVL_T13.iConsumidoresCP + 4;

                        if (HelperMODBUS.CS_wStatusLiga8MangueirasCP)
                            _modelGVL.GVL_T13.iConsumidoresCP = _modelGVL.GVL_T13.iConsumidoresCP + 8;

                        if (HelperMODBUS.CS_wStatusLiga10MangueirasCP)
                            _modelGVL.GVL_T13.iConsumidoresCP = _modelGVL.GVL_T13.iConsumidoresCP + 10;

                        if (HelperMODBUS.CS_wStatusLiga17MangueirasCP)
                            _modelGVL.GVL_T13.iConsumidoresCP = _modelGVL.GVL_T13.iConsumidoresCP + 17;

                        if (HelperMODBUS.CS_wStatusLiga1MangueiraCS)
                            _modelGVL.GVL_T13.iConsumidoresCS = _modelGVL.GVL_T13.iConsumidoresCS + 1;

                        if (HelperMODBUS.CS_wStatusLiga2MangueirasCS)
                            _modelGVL.GVL_T13.iConsumidoresCS = _modelGVL.GVL_T13.iConsumidoresCS + 2;

                        if (HelperMODBUS.CS_wStatusLiga4MangueirasCS)
                            _modelGVL.GVL_T13.iConsumidoresCS = _modelGVL.GVL_T13.iConsumidoresCS + 4;

                        if (HelperMODBUS.CS_wStatusLiga8MangueirasCS)
                            _modelGVL.GVL_T13.iConsumidoresCS = _modelGVL.GVL_T13.iConsumidoresCS + 8;

                        if (HelperMODBUS.CS_wStatusLiga10MangueirasCS)
                            _modelGVL.GVL_T13.iConsumidoresCS = _modelGVL.GVL_T13.iConsumidoresCS + 10;

                        if (HelperMODBUS.CS_wStatusLiga17MangueirasCS)
                            _modelGVL.GVL_T13.iConsumidoresCS = _modelGVL.GVL_T13.iConsumidoresCS + 17;
                    }
                    //============================. ============================================================================================================================

                    #endregion

                    _modelGVL.GVL_T13.bCalculaResultados = false;

                    _modelGVL.GVL_Graficos.bDadosCalculados = true;
                }

                HelperTestBase.Model_GVL.helperTestBase_ModelGVL_Test = HelperTestBase.Model_GVL.GVL_T13;

                HelperTestBase.Model_GVL = _modelGVL;

                #endregion

            }
            catch (Exception ex)
            {
                var err = ex.Message;
                throw;
            }

            return _modelGVL;

            #endregion
        }

        #endregion

        #region T14 - Calculos verificacao Sensores - ET_InputOutputTravel
        public Model_GVL CalcGraphT14_ET_InputOutputTravel(bool bCalculaResultados, List<double>[] lstDblReturnReadFile)
        {
            #region PROGRAM T14_Calculos_Resultados

            try
            {
                #region Limpa ultimos resultados

                dictVarList.Clear();

                _modelGVL.GVL_T14.rForcaMaxima = 0; //Zera o ultimo valor de força obtido
                _modelGVL.GVL_T14.rGradienteForcaAvanco = 0; //Zera o ultimo valor obtido
                _modelGVL.GVL_T14.rGradienteForcaRetorno = 0; //Zera o ultimo valor obtido
                _modelGVL.GVL_T14.rGradienteDeslocamentoAvanco = 0; //Zera o ultimo valor obtido
                _modelGVL.GVL_T14.rGradienteDeslocamentoRetorno = 0; //Zera o ultimo valor obtido
                _modelGVL.GVL_T14.iConsumidoresCP = 0;
                _modelGVL.GVL_T14.iConsumidoresCS = 0;

                _modelGVL.GVL_T14.rGradienteForcaAvanco = 0;
                _modelGVL.GVL_T14.rGradienteDeslocamentoAvanco = 0;
                _modelGVL.GVL_T14.rGradienteForcaRetorno = 0;
                _modelGVL.GVL_T14.rGradienteDeslocamentoRetorno = 0;
                _modelGVL.GVL_T14.rCursoMorto_mm = 0;

                _modelGVL.GVL_T14.bCalculaResultados = bCalculaResultados;

                #region VARIABLES

                long diUbound = 0; //  ; DINT;
                long di = 0; //  ; DINT;
                double rForcaInicialGradiente = 0; //  ; REAL;
                double rForcaFinalGradiente = 0; //  ; REAL;
                double rDeslocamentoInicialGradiente = 0; //   ; REAL;
                double rDeslocamentoFinalGradiente = 0; //  ; REAL;
                double rTempoInicialGradiente = 0; //  ; REAL;
                double rTempoFinalGradiente = 0; //   ; REAL;


                #endregion

                #endregion

                #region Variaveis Grafico

                _modelGVL.GVL_Graficos.rEscalaX = 1500;
                _modelGVL.GVL_Graficos.EixoX.wsTLLabel = "AxesChart.1";
                _modelGVL.GVL_Graficos.rEscalaY1 = 150;
                _modelGVL.GVL_Graficos.EixoY1.wsTLLabel = "AxesChart.3";
                _modelGVL.GVL_Graficos.rEscalaY2 = 150;
                _modelGVL.GVL_Graficos.EixoY2.wsTLLabel = "AxesChart.4";
                _modelGVL.GVL_Graficos.rEscalaY3 = 0;
                _modelGVL.GVL_Graficos.EixoY3.wsTLLabel = string.Empty;
                _modelGVL.GVL_Graficos.rEscalaY4 = 0;
                _modelGVL.GVL_Graficos.EixoY4.wsTLLabel = string.Empty;

                _modelGVL.GVL_Graficos.strNomeEixoX = "Input Travel (mm)";
                _modelGVL.GVL_Graficos.strNomeEixoY1 = "Output Travel (mm)";
                _modelGVL.GVL_Graficos.strNomeEixoY2 = "Input Force (N)";
                _modelGVL.GVL_Graficos.strNomeEixoY3 = string.Empty;
                _modelGVL.GVL_Graficos.strNomeEixoY4 = string.Empty;

                _modelGVL.GVL_Graficos.strUnidadeX = "mm";
                _modelGVL.GVL_Graficos.strUnidadeY1 = "mm";
                _modelGVL.GVL_Graficos.strUnidadeY2 = "N";
                _modelGVL.GVL_Graficos.strUnidadeY3 = string.Empty;
                _modelGVL.GVL_Graficos.strUnidadeY4 = string.Empty;

                _modelGVL.GVL_Graficos.bOcultaY2 = false;
                _modelGVL.GVL_Graficos.bOcultaY3 = true;
                _modelGVL.GVL_Graficos.bOcultaY4 = true;

                #endregion

                #region Varriaveis Array Dados

                //os arrays dinamicos obtidos neste teste contem as seguintes grandezas:
                //GVL_Graficos.arrVarX[GVL_Graficos.diBuffer] := rDeslocamentoEntradaBooster_mm_Lin;
                //GVL_Graficos.arrVarY1[GVL_Graficos.diBuffer] := rDeslocamentoSaidaBooster_mm_Lin;
                //GVL_Graficos.arrVarY2[GVL_Graficos.diBuffer] := rForcaEntradaBooster_N_Lin;	

                ClearArrayGVL_Graficos();

                _modelGVL.GVL_Graficos.arrVarTimeStamp = lstDblReturnReadFile[0].ToArray();
                _modelGVL.GVL_Graficos.arrVarX = lstDblReturnReadFile[5].ToArray();
                _modelGVL.GVL_Graficos.arrVarY1 = lstDblReturnReadFile[4].ToArray();
                _modelGVL.GVL_Graficos.arrVarY2 = lstDblReturnReadFile[2].ToArray();

                #endregion

                #region Calculos

                if (_modelGVL.GVL_T14.bCalculaResultados)
                {
                    _modelGVL.GVL_T14 = HelperTestBase.Model_GVL.GVL_T14;

                    //Define o ponto maximo do array que foi plotado durante o teste
                    _modelGVL.GVL_Graficos.diBuffer = lstDblReturnReadFile[0].Count() > 0 ? lstDblReturnReadFile[0].Count() : 0;

                    diUbound = _modelGVL.GVL_Graficos.diBuffer; //Define o ponto maximo do array que foi plotado durante o teste

                    #region Loop para identificar a forca maxima do teste, e armazenar o ponto de inflexao do teste (quando o atuador comeca a retornar)
                    //========================================================================================================================================================

                    for (di = 0; di < diUbound; di++)
                    {
                        if (_modelGVL.GVL_Graficos.arrVarY2[di] > _modelGVL.GVL_T14.rForcaMaxima)
                        {
                            _modelGVL.GVL_T14.rForcaMaxima = _modelGVL.GVL_Graficos.arrVarY2[di]; //Atualiza o valor de forca maxima com o maior valor obtido no array
                            _modelGVL.GVL_T14.diPosicaoForcaMaxima = di; //Indica em qual posicao do array esta a forca maxima (pico do grafico, aonde comeca o retorno do atuador)
                        }
                    }

                    //========================================================================================================================================================
                    #endregion

                    #region Loop para identificar o deslocamento maximo
                    //========================================================================================================================================================

                    for (di = 0; di < diUbound; di++)
                    {
                        if (_modelGVL.GVL_Graficos.arrVarX[di] > _modelGVL.GVL_T14.rDeslocamentoMaximo)
                        {
                            _modelGVL.GVL_T14.rDeslocamentoMaximo = _modelGVL.GVL_Graficos.arrVarX[di]; //Atualiza o valor de deslocamento maximo
                        }
                    }
                    #endregion

                    #region Calculo do gradiente de aplicacao de força no avanço
                    //========================================================================================================================================================

                    //Busca no array o momento em que a forca comecou a subir (forca >= 100N) e o tempo decorrido desta forca
                    for (di = 0; di <= _modelGVL.GVL_T14.diPosicaoForcaMaxima; di++)
                    {
                        if (_modelGVL.GVL_Graficos.arrVarY2[di] >= 100)//forca comecou a subir (>=100N)
                        {
                            rForcaInicialGradiente = _modelGVL.GVL_Graficos.arrVarY2[di]; //Valor forca inicial para calculo 
                            rTempoInicialGradiente = _modelGVL.GVL_Graficos.arrVarTimeStamp[di]; //Valor to tempo em ms inicial para calculo

                            break; //Encerra a busca pela forca inicial
                        }
                    }

                    //Define a forca final e o tempo final do gradiente como a FMAX obtida no calculo anterior, utilizando seu indice para coletar o tempo respectivo
                    rForcaFinalGradiente = _modelGVL.GVL_Graficos.arrVarY2[_modelGVL.GVL_T14.diPosicaoForcaMaxima];
                    rTempoFinalGradiente = _modelGVL.GVL_Graficos.arrVarTimeStamp[_modelGVL.GVL_T14.diPosicaoForcaMaxima];

                    //Calcula o gradiente de aplicacao de forca no avanco
                    _modelGVL.GVL_T14.rGradienteForcaAvanco = (rForcaFinalGradiente - rForcaInicialGradiente) / (rTempoFinalGradiente - rTempoInicialGradiente);
                    //========================================================================================================================================================

                    #endregion

                    #region Calculo do gradiente de aplicacao de força no retorno
                    //========================================================================================================================================================

                    //Busca no array o momento em que a forca caiu abaixo de 100N (forca <= 100N) e o tempo decorrido desta forca
                    for (di = _modelGVL.GVL_T14.diPosicaoForcaMaxima; di < diUbound; di++)
                    {
                        if (_modelGVL.GVL_Graficos.arrVarY2[di] <= 100) //Forca proxima de 0 (<=100N)
                        {
                            rForcaFinalGradiente = _modelGVL.GVL_Graficos.arrVarY2[di]; //Valor forca final para calculo 
                            rTempoFinalGradiente = _modelGVL.GVL_Graficos.arrVarTimeStamp[di]; //Valor to tempo em ms final para calculo

                            break; //Encerra a busca pela forca final
                        }
                    }

                    //Define a forca inicial e o tempo inicial do gradiente como a FMAX obtida no calculo anterior, utilizando seu indice para coletar o tempo respectivo
                    rForcaInicialGradiente = _modelGVL.GVL_Graficos.arrVarY2[_modelGVL.GVL_T14.diPosicaoForcaMaxima];
                    rTempoInicialGradiente = _modelGVL.GVL_Graficos.arrVarTimeStamp[_modelGVL.GVL_T14.diPosicaoForcaMaxima];

                    //Calcula o gradiente de aplicacao de forca no retorno
                    _modelGVL.GVL_T14.rGradienteForcaRetorno = (rForcaFinalGradiente - rForcaInicialGradiente) / (rTempoFinalGradiente - rTempoInicialGradiente);
                    //========================================================================================================================================================
                    #endregion

                    #region Calculo do gradiente de avanço 
                    //========================================================================================================================================================

                    //Busca no array o momento em que o deslocamento comecou a variar (deslocamento >= 1)
                    for (di = 0; di <= _modelGVL.GVL_T14.diPosicaoForcaMaxima; di++)
                    {
                        if (_modelGVL.GVL_Graficos.arrVarX[di] >= 1) //Deslocamento >= 1mm
                        {
                            rDeslocamentoInicialGradiente = _modelGVL.GVL_Graficos.arrVarX[di]; //Valor deslocamento inicial para calculo 
                            rTempoInicialGradiente = _modelGVL.GVL_Graficos.arrVarTimeStamp[di]; //Valor to tempo em ms inicial para calculo

                            break; //Encerra a busca pelo deslocamento inicial
                        }
                    }

                    //Define a forca final e o tempo final do gradiente como a FMAX obtida no calculo anterior, utilizando seu indice para coletar o tempo respectivo
                    rDeslocamentoFinalGradiente = _modelGVL.GVL_Graficos.arrVarX[_modelGVL.GVL_T14.diPosicaoForcaMaxima];
                    rTempoFinalGradiente = _modelGVL.GVL_Graficos.arrVarTimeStamp[_modelGVL.GVL_T14.diPosicaoForcaMaxima];

                    //Calcula o gradiente de aplicacao de forca no avanco
                    _modelGVL.GVL_T14.rGradienteDeslocamentoAvanco = (rDeslocamentoFinalGradiente - rDeslocamentoInicialGradiente) / (rTempoFinalGradiente - rTempoInicialGradiente);
                    //========================================================================================================================================================

                    #endregion

                    #region Calculo do gradiente de deslocamento no retorno

                    //========================================================================================================================================================

                    //Busca no array o momento em que o deslocamento <= 1
                    for (di = _modelGVL.GVL_T14.diPosicaoForcaMaxima; di < diUbound; di++)
                    {
                        if (_modelGVL.GVL_Graficos.arrVarX[di] <= 1) //Deslocamento <= 1
                        {
                            rDeslocamentoFinalGradiente = _modelGVL.GVL_Graficos.arrVarX[di]; //Deslocamento final para calculo 
                            rTempoFinalGradiente = _modelGVL.GVL_Graficos.arrVarTimeStamp[di]; //Valor to tempo em ms final para calculo

                            break; //Encerra a busca pelo deslocamento final
                        }
                    }


                    //Define o deslocamento inicial e o tempo inicial do gradiente como a FMAX obtida no calculo anterior, utilizando seu indice para coletar o tempo respectivo
                    rDeslocamentoInicialGradiente = _modelGVL.GVL_Graficos.arrVarX[_modelGVL.GVL_T14.diPosicaoForcaMaxima];
                    rTempoInicialGradiente = _modelGVL.GVL_Graficos.arrVarTimeStamp[_modelGVL.GVL_T14.diPosicaoForcaMaxima];

                    //Calcula o gradiente de aplicacao de forca no retorno
                    _modelGVL.GVL_T14.rGradienteDeslocamentoRetorno = (rDeslocamentoFinalGradiente - rDeslocamentoInicialGradiente) / (rTempoFinalGradiente - rTempoInicialGradiente);
                    //========================================================================================================================================================

                    #endregion

                    #region Loop para encontrar o curso morto

                    for (di = 0; di < diUbound; di++)
                    {
                        if (_modelGVL.GVL_Graficos.arrVarY1[di] >= _modelGVL.GVL_T14.rCursoMortoEmDeslocamentoSaida_mm) //Deslocamento <= 1
                        {
                            _modelGVL.GVL_T14.rCursoMorto_mm = GVL_Graficos.arrVarX[di]; //Encontra o valor de curso morto
                            break; //Encerra a busca pelo curso morto
                        }
                    }

                    #endregion

                    #region Calculo dos Consumidores Utilizados

                    //========================================================================================================================================================

                    _modelGVL.GVL_T14.iConsumidoresCP = 0;
                    _modelGVL.GVL_T14.iConsumidoresCS = 0;

                    HelperTestBase.Model_GVL.GVL_Parametros.iTipoConsumidores = HelperMODBUS.CS_wTipoConsumidores;

                    if (HelperMODBUS.CS_wTipoConsumidores != 2)
                    {
                        _modelGVL.GVL_T14.iConsumidoresCP = 0;
                        _modelGVL.GVL_T14.iConsumidoresCS = 0;
                    }
                    else
                    {
                        //HelperMODBUS.CS_wStatusLiga17MangueirasCS 
                        if (HelperMODBUS.CS_wStatusLiga1MangueiraCP)
                            _modelGVL.GVL_T14.iConsumidoresCP = _modelGVL.GVL_T14.iConsumidoresCP + 1;

                        if (HelperMODBUS.CS_wStatusLiga2MangueirasCP)
                            _modelGVL.GVL_T14.iConsumidoresCP = _modelGVL.GVL_T14.iConsumidoresCP + 2;

                        if (HelperMODBUS.CS_wStatusLiga4MangueirasCP)
                            _modelGVL.GVL_T14.iConsumidoresCP = _modelGVL.GVL_T14.iConsumidoresCP + 4;

                        if (HelperMODBUS.CS_wStatusLiga8MangueirasCP)
                            _modelGVL.GVL_T14.iConsumidoresCP = _modelGVL.GVL_T14.iConsumidoresCP + 8;

                        if (HelperMODBUS.CS_wStatusLiga10MangueirasCP)
                            _modelGVL.GVL_T14.iConsumidoresCP = _modelGVL.GVL_T14.iConsumidoresCP + 10;

                        if (HelperMODBUS.CS_wStatusLiga17MangueirasCP)
                            _modelGVL.GVL_T14.iConsumidoresCP = _modelGVL.GVL_T14.iConsumidoresCP + 17;

                        if (HelperMODBUS.CS_wStatusLiga1MangueiraCS)
                            _modelGVL.GVL_T14.iConsumidoresCS = _modelGVL.GVL_T14.iConsumidoresCS + 1;

                        if (HelperMODBUS.CS_wStatusLiga2MangueirasCS)
                            _modelGVL.GVL_T14.iConsumidoresCS = _modelGVL.GVL_T14.iConsumidoresCS + 2;

                        if (HelperMODBUS.CS_wStatusLiga4MangueirasCS)
                            _modelGVL.GVL_T14.iConsumidoresCS = _modelGVL.GVL_T14.iConsumidoresCS + 4;

                        if (HelperMODBUS.CS_wStatusLiga8MangueirasCS)
                            _modelGVL.GVL_T14.iConsumidoresCS = _modelGVL.GVL_T14.iConsumidoresCS + 8;

                        if (HelperMODBUS.CS_wStatusLiga10MangueirasCS)
                            _modelGVL.GVL_T14.iConsumidoresCS = _modelGVL.GVL_T14.iConsumidoresCS + 10;

                        if (HelperMODBUS.CS_wStatusLiga17MangueirasCS)
                            _modelGVL.GVL_T14.iConsumidoresCS = _modelGVL.GVL_T14.iConsumidoresCS + 17;
                    }
                    //============================. ============================================================================================================================

                    #endregion

                    _modelGVL.GVL_T14.bCalculaResultados = false;

                    _modelGVL.GVL_Graficos.bDadosCalculados = true;
                }

                HelperTestBase.Model_GVL.helperTestBase_ModelGVL_Test = HelperTestBase.Model_GVL.GVL_T14;

                HelperTestBase.Model_GVL = _modelGVL;

                #endregion

            }
            catch (Exception ex)
            {
                var err = ex.Message;
                throw;
            }

            return _modelGVL;

            #endregion
        }

        #endregion

        #region T15 - Calculos verificacao Sensores - ET_Adjustment_InputTravelVsInputForce
        public Model_GVL CalcGraphT15_ET_Adjustment_InputTravelVsInputForce(bool bCalculaResultados, List<double>[] lstDblReturnReadFile)
        {
            #region PROGRAM T15_Calculos_Resultados

            try
            {
                #region Limpa ultimos resultados

                dictVarList.Clear();

                _modelGVL.GVL_T15.rForcaMaxima = 0; //Zera o ultimo valor de força obtido
                _modelGVL.GVL_T15.rGradienteForcaAvanco = 0; //Zera o ultimo valor obtido
                _modelGVL.GVL_T15.rGradienteForcaRetorno = 0; //Zera o ultimo valor obtido
                _modelGVL.GVL_T15.rGradienteDeslocamentoAvanco = 0; //Zera o ultimo valor obtido
                _modelGVL.GVL_T15.rGradienteDeslocamentoRetorno = 0; //Zera o ultimo valor obtido
                _modelGVL.GVL_T15.iConsumidoresCP = 0;
                _modelGVL.GVL_T15.iConsumidoresCS = 0;

                _modelGVL.GVL_T15.bCalculaResultados = bCalculaResultados;

                #region VARIABLES

                long diUbound = 0; //  ; DINT;
                long di = 0; //  ; DINT;
                double rForcaInicialGradiente = 0; //  ; REAL;
                double rForcaFinalGradiente = 0; //  ; REAL;
                double rDeslocamentoInicialGradiente = 0; //   ; REAL;
                double rDeslocamentoFinalGradiente = 0; //  ; REAL;
                double rTempoInicialGradiente = 0; //  ; REAL;
                double rTempoFinalGradiente = 0; //   ; REAL;


                #endregion

                #endregion

                #region Variaveis Grafico

                _modelGVL.GVL_Graficos.rEscalaX = 1500;
                _modelGVL.GVL_Graficos.EixoX.wsTLLabel = "AxesChart.1";
                _modelGVL.GVL_Graficos.rEscalaY1 = 150;
                _modelGVL.GVL_Graficos.EixoY1.wsTLLabel = "AxesChart.3";
                _modelGVL.GVL_Graficos.rEscalaY2 = 150;
                _modelGVL.GVL_Graficos.EixoY2.wsTLLabel = string.Empty;
                _modelGVL.GVL_Graficos.rEscalaY3 = 0;
                _modelGVL.GVL_Graficos.EixoY3.wsTLLabel = string.Empty;
                _modelGVL.GVL_Graficos.rEscalaY4 = 0;
                _modelGVL.GVL_Graficos.EixoY4.wsTLLabel = string.Empty;

                _modelGVL.GVL_Graficos.strNomeEixoX = "Input Force (N)";
                _modelGVL.GVL_Graficos.strNomeEixoY1 = "Input Travel (mm)";
                _modelGVL.GVL_Graficos.strNomeEixoY2 = string.Empty;
                _modelGVL.GVL_Graficos.strNomeEixoY3 = string.Empty;
                _modelGVL.GVL_Graficos.strNomeEixoY4 = string.Empty;

                _modelGVL.GVL_Graficos.strUnidadeX = "N";
                _modelGVL.GVL_Graficos.strUnidadeY1 = "mm";
                _modelGVL.GVL_Graficos.strUnidadeY2 = string.Empty;
                _modelGVL.GVL_Graficos.strUnidadeY3 = string.Empty;
                _modelGVL.GVL_Graficos.strUnidadeY4 = string.Empty;

                _modelGVL.GVL_Graficos.bOcultaY2 = false;
                _modelGVL.GVL_Graficos.bOcultaY3 = true;
                _modelGVL.GVL_Graficos.bOcultaY4 = true;

                #endregion

                #region Varriaveis Array Dados

                //os arrays dinamicos obtidos neste teste contem as seguintes grandezas:
                //GVL_Graficos.arrVarX[GVL_Graficos.diBuffer] := rForcaEntradaBooster_N_Lin;
                //GVL_Graficos.arrVarY1[GVL_Graficos.diBuffer] := rDeslocamentoEntradaBooster_mm_Lin;

                ClearArrayGVL_Graficos();

                _modelGVL.GVL_Graficos.arrVarTimeStamp = lstDblReturnReadFile[0].ToArray();
                _modelGVL.GVL_Graficos.arrVarX = lstDblReturnReadFile[2].ToArray();
                _modelGVL.GVL_Graficos.arrVarY1 = lstDblReturnReadFile[5].ToArray();

                #endregion

                #region Calculos

                if (_modelGVL.GVL_T15.bCalculaResultados)
                {
                    _modelGVL.GVL_T15 = HelperTestBase.Model_GVL.GVL_T15;

                    //Define o ponto maximo do array que foi plotado durante o teste
                    _modelGVL.GVL_Graficos.diBuffer = lstDblReturnReadFile[0].Count() > 0 ? lstDblReturnReadFile[0].Count() : 0;

                    diUbound = _modelGVL.GVL_Graficos.diBuffer; //Define o ponto maximo do array que foi plotado durante o teste

                    #region Loop para identificar a forca maxima do teste, e armazenar o ponto de inflexao do teste (quando o atuador comeca a retornar)
                    //========================================================================================================================================================

                    for (di = 0; di < diUbound; di++)
                    {
                        if (_modelGVL.GVL_Graficos.arrVarX[di] > _modelGVL.GVL_T15.rForcaMaxima)
                        {
                            _modelGVL.GVL_T15.rForcaMaxima = _modelGVL.GVL_Graficos.arrVarX[di]; //Atualiza o valor de forca maxima com o maior valor obtido no array
                            _modelGVL.GVL_T15.diPosicaoForcaMaxima = di; //Indica em qual posicao do array esta a forca maxima (pico do grafico, aonde comeca o retorno do atuador)
                        }
                    }

                    //========================================================================================================================================================
                    #endregion

                    #region Calculo do gradiente de aplicacao de força no avanço
                    //========================================================================================================================================================

                    //Busca no array o momento em que a forca comecou a subir (forca >= 100N) e o tempo decorrido desta forca
                    for (di = 0; di <= _modelGVL.GVL_T15.diPosicaoForcaMaxima; di++)
                    {
                        if (_modelGVL.GVL_Graficos.arrVarX[di] >= 100)//forca comecou a subir (>=100N)
                        {
                            rForcaInicialGradiente = _modelGVL.GVL_Graficos.arrVarX[di]; //Valor forca inicial para calculo 
                            rTempoInicialGradiente = _modelGVL.GVL_Graficos.arrVarTimeStamp[di]; //Valor to tempo em ms inicial para calculo

                            break; //Encerra a busca pela forca inicial
                        }
                    }

                    //Define a forca final e o tempo final do gradiente como a FMAX obtida no calculo anterior, utilizando seu indice para coletar o tempo respectivo
                    rForcaFinalGradiente = _modelGVL.GVL_Graficos.arrVarX[_modelGVL.GVL_T15.diPosicaoForcaMaxima];
                    rTempoFinalGradiente = _modelGVL.GVL_Graficos.arrVarTimeStamp[_modelGVL.GVL_T15.diPosicaoForcaMaxima];

                    //Calcula o gradiente de aplicacao de forca no avanco
                    _modelGVL.GVL_T15.rGradienteForcaAvanco = (rForcaFinalGradiente - rForcaInicialGradiente) / (rTempoFinalGradiente - rTempoInicialGradiente);
                    //========================================================================================================================================================

                    #endregion

                    #region Calculo do gradiente de aplicacao de força no retorno
                    //========================================================================================================================================================

                    //Busca no array o momento em que a forca caiu abaixo de 100N (forca <= 100N) e o tempo decorrido desta forca
                    for (di = _modelGVL.GVL_T15.diPosicaoForcaMaxima; di < diUbound; di++)
                    {
                        if (_modelGVL.GVL_Graficos.arrVarX[di] <= 100) //Forca proxima de 0 (<=100N)
                        {
                            rForcaFinalGradiente = _modelGVL.GVL_Graficos.arrVarX[di]; //Valor forca final para calculo 
                            rTempoFinalGradiente = _modelGVL.GVL_Graficos.arrVarTimeStamp[di]; //Valor to tempo em ms final para calculo

                            break; //Encerra a busca pela forca final
                        }
                    }

                    //Define a forca inicial e o tempo inicial do gradiente como a FMAX obtida no calculo anterior, utilizando seu indice para coletar o tempo respectivo
                    rForcaInicialGradiente = _modelGVL.GVL_Graficos.arrVarX[_modelGVL.GVL_T15.diPosicaoForcaMaxima];
                    rTempoInicialGradiente = _modelGVL.GVL_Graficos.arrVarTimeStamp[_modelGVL.GVL_T15.diPosicaoForcaMaxima];

                    //Calcula o gradiente de aplicacao de forca no retorno
                    _modelGVL.GVL_T15.rGradienteForcaRetorno = (rForcaFinalGradiente - rForcaInicialGradiente) / (rTempoFinalGradiente - rTempoInicialGradiente);
                    //========================================================================================================================================================
                    #endregion

                    #region Calculo do gradiente de avanço 
                    //========================================================================================================================================================

                    //Busca no array o momento em que o deslocamento comecou a variar (deslocamento >= 1)
                    for (di = 0; di <= _modelGVL.GVL_T15.diPosicaoForcaMaxima; di++)
                    {
                        if (_modelGVL.GVL_Graficos.arrVarY1[di] >= 1) //Deslocamento >= 1mm
                        {
                            rDeslocamentoInicialGradiente = _modelGVL.GVL_Graficos.arrVarY1[di]; //Valor deslocamento inicial para calculo 
                            rTempoInicialGradiente = _modelGVL.GVL_Graficos.arrVarTimeStamp[di]; //Valor to tempo em ms inicial para calculo

                            break; //Encerra a busca pelo deslocamento inicial
                        }
                    }

                    //Define a forca final e o tempo final do gradiente como a FMAX obtida no calculo anterior, utilizando seu indice para coletar o tempo respectivo
                    rDeslocamentoFinalGradiente = _modelGVL.GVL_Graficos.arrVarY1[_modelGVL.GVL_T15.diPosicaoForcaMaxima];
                    rTempoFinalGradiente = _modelGVL.GVL_Graficos.arrVarTimeStamp[_modelGVL.GVL_T15.diPosicaoForcaMaxima];

                    //Calcula o gradiente de aplicacao de forca no avanco
                    _modelGVL.GVL_T15.rGradienteDeslocamentoAvanco = (rDeslocamentoFinalGradiente - rDeslocamentoInicialGradiente) / (rTempoFinalGradiente - rTempoInicialGradiente);
                    //========================================================================================================================================================

                    #endregion

                    #region Calculo do gradiente de deslocamento no retorno

                    //========================================================================================================================================================

                    //Busca no array o momento em que o deslocamento <= 1
                    for (di = _modelGVL.GVL_T15.diPosicaoForcaMaxima; di < diUbound; di++)
                    {
                        if (_modelGVL.GVL_Graficos.arrVarY1[di] <= 1) //Deslocamento <= 1
                        {
                            rDeslocamentoFinalGradiente = _modelGVL.GVL_Graficos.arrVarY1[di]; //Deslocamento final para calculo 
                            rTempoFinalGradiente = _modelGVL.GVL_Graficos.arrVarTimeStamp[di]; //Valor to tempo em ms final para calculo

                            break; //Encerra a busca pelo deslocamento final
                        }
                    }


                    //Define o deslocamento inicial e o tempo inicial do gradiente como a FMAX obtida no calculo anterior, utilizando seu indice para coletar o tempo respectivo
                    rDeslocamentoInicialGradiente = _modelGVL.GVL_Graficos.arrVarY1[_modelGVL.GVL_T15.diPosicaoForcaMaxima];
                    rTempoInicialGradiente = _modelGVL.GVL_Graficos.arrVarTimeStamp[_modelGVL.GVL_T15.diPosicaoForcaMaxima];

                    //Calcula o gradiente de aplicacao de forca no retorno
                    _modelGVL.GVL_T15.rGradienteDeslocamentoRetorno = (rDeslocamentoFinalGradiente - rDeslocamentoInicialGradiente) / (rTempoFinalGradiente - rTempoInicialGradiente);
                    //========================================================================================================================================================

                    #endregion

                    #region Calculo dos Consumidores Utilizados

                    //========================================================================================================================================================

                    _modelGVL.GVL_T15.iConsumidoresCP = 0;
                    _modelGVL.GVL_T15.iConsumidoresCS = 0;

                    HelperTestBase.Model_GVL.GVL_Parametros.iTipoConsumidores = HelperMODBUS.CS_wTipoConsumidores;

                    if (HelperMODBUS.CS_wTipoConsumidores != 2)
                    {
                        _modelGVL.GVL_T15.iConsumidoresCP = 0;
                        _modelGVL.GVL_T15.iConsumidoresCS = 0;
                    }
                    else
                    {
                        //HelperMODBUS.CS_wStatusLiga17MangueirasCS 
                        if (HelperMODBUS.CS_wStatusLiga1MangueiraCP)
                            _modelGVL.GVL_T15.iConsumidoresCP = _modelGVL.GVL_T15.iConsumidoresCP + 1;

                        if (HelperMODBUS.CS_wStatusLiga2MangueirasCP)
                            _modelGVL.GVL_T15.iConsumidoresCP = _modelGVL.GVL_T15.iConsumidoresCP + 2;

                        if (HelperMODBUS.CS_wStatusLiga4MangueirasCP)
                            _modelGVL.GVL_T15.iConsumidoresCP = _modelGVL.GVL_T15.iConsumidoresCP + 4;

                        if (HelperMODBUS.CS_wStatusLiga8MangueirasCP)
                            _modelGVL.GVL_T15.iConsumidoresCP = _modelGVL.GVL_T15.iConsumidoresCP + 8;

                        if (HelperMODBUS.CS_wStatusLiga10MangueirasCP)
                            _modelGVL.GVL_T15.iConsumidoresCP = _modelGVL.GVL_T15.iConsumidoresCP + 10;

                        if (HelperMODBUS.CS_wStatusLiga17MangueirasCP)
                            _modelGVL.GVL_T15.iConsumidoresCP = _modelGVL.GVL_T15.iConsumidoresCP + 17;

                        if (HelperMODBUS.CS_wStatusLiga1MangueiraCS)
                            _modelGVL.GVL_T15.iConsumidoresCS = _modelGVL.GVL_T15.iConsumidoresCS + 1;

                        if (HelperMODBUS.CS_wStatusLiga2MangueirasCS)
                            _modelGVL.GVL_T15.iConsumidoresCS = _modelGVL.GVL_T15.iConsumidoresCS + 2;

                        if (HelperMODBUS.CS_wStatusLiga4MangueirasCS)
                            _modelGVL.GVL_T15.iConsumidoresCS = _modelGVL.GVL_T15.iConsumidoresCS + 4;

                        if (HelperMODBUS.CS_wStatusLiga8MangueirasCS)
                            _modelGVL.GVL_T15.iConsumidoresCS = _modelGVL.GVL_T15.iConsumidoresCS + 8;

                        if (HelperMODBUS.CS_wStatusLiga10MangueirasCS)
                            _modelGVL.GVL_T15.iConsumidoresCS = _modelGVL.GVL_T15.iConsumidoresCS + 10;

                        if (HelperMODBUS.CS_wStatusLiga17MangueirasCS)
                            _modelGVL.GVL_T15.iConsumidoresCS = _modelGVL.GVL_T15.iConsumidoresCS + 17;
                    }
                    //============================. ============================================================================================================================

                    #endregion

                    _modelGVL.GVL_T15.bCalculaResultados = false;

                    _modelGVL.GVL_Graficos.bDadosCalculados = true;
                }

                HelperTestBase.Model_GVL.helperTestBase_ModelGVL_Test = HelperTestBase.Model_GVL.GVL_T15;

                HelperTestBase.Model_GVL = _modelGVL;

                #endregion

            }
            catch (Exception ex)
            {
                var err = ex.Message;
                throw;
            }

            return _modelGVL;

            #endregion
        }

        #endregion

        #region T16 - Calculos verificacao Sensores - ET_Adjustment_HoseConsumers
        public Model_GVL CalcGraphT16_ET_Adjustment_HoseConsumers(bool bCalculaResultados, List<double>[] lstDblReturnReadFile)
        {
            #region PROGRAM T16_Calculos_Resultados

            try
            {
                #region Limpa ultimos resultados

                dictVarList.Clear();

                _modelGVL.GVL_T16.rForcaMaxima = 0; //Zera o ultimo valor de força obtido
                _modelGVL.GVL_T16.diPosicaoForcaMaxima = 0;
                _modelGVL.GVL_T16.rDeslocamentoMaximo_mm = 0;
                _modelGVL.GVL_T16.rGradienteForcaAvanco = 0; //Zera o ultimo valor obtido
                _modelGVL.GVL_T16.rGradienteForcaRetorno = 0; //Zera o ultimo valor obtido
                _modelGVL.GVL_T16.rGradienteDeslocamentoAvanco = 0; //Zera o ultimo valor obtido
                _modelGVL.GVL_T16.rGradienteDeslocamentoRetorno = 0; //Zera o ultimo valor obtido
                _modelGVL.GVL_T16.iConsumidoresCP = 0;
                _modelGVL.GVL_T16.iConsumidoresCS = 0;

                _modelGVL.GVL_T16.bCalculaResultados = bCalculaResultados;

                #region VARIABLES

                long diUbound = 0; //  ; DINT;
                long di = 0; //  ; DINT;
                double rForcaInicialGradiente = 0; //  ; REAL;
                double rForcaFinalGradiente = 0; //  ; REAL;
                double rDeslocamentoInicialGradiente = 0; //   ; REAL;
                double rDeslocamentoFinalGradiente = 0; //  ; REAL;
                double rTempoInicialGradiente = 0; //  ; REAL;
                double rTempoFinalGradiente = 0; //   ; REAL;


                #endregion

                #endregion

                #region Variaveis Grafico

                _modelGVL.GVL_Graficos.rEscalaX = 1500;
                _modelGVL.GVL_Graficos.EixoX.wsTLLabel = "AxesChart.1";
                _modelGVL.GVL_Graficos.rEscalaY1 = 150;
                _modelGVL.GVL_Graficos.EixoY1.wsTLLabel = "AxesChart.3";
                _modelGVL.GVL_Graficos.rEscalaY2 = 150;
                _modelGVL.GVL_Graficos.EixoY2.wsTLLabel = string.Empty;
                _modelGVL.GVL_Graficos.rEscalaY3 = 0;
                _modelGVL.GVL_Graficos.EixoY3.wsTLLabel = string.Empty;
                _modelGVL.GVL_Graficos.rEscalaY4 = 0;
                _modelGVL.GVL_Graficos.EixoY4.wsTLLabel = string.Empty;

                _modelGVL.GVL_Graficos.strNomeEixoX = "Input Travel (mm)";
                _modelGVL.GVL_Graficos.strNomeEixoY1 = "Pressure CP (bar)";
                _modelGVL.GVL_Graficos.strNomeEixoY2 = "Pressure CS (bar)";
                _modelGVL.GVL_Graficos.strNomeEixoY3 = "Input Force (N)";
                _modelGVL.GVL_Graficos.strNomeEixoY4 = string.Empty;

                _modelGVL.GVL_Graficos.strUnidadeX = "mm";
                _modelGVL.GVL_Graficos.strUnidadeY1 = "bar";
                _modelGVL.GVL_Graficos.strUnidadeY2 = "bar";
                _modelGVL.GVL_Graficos.strUnidadeY3 = "N";
                _modelGVL.GVL_Graficos.strUnidadeY4 = string.Empty;

                _modelGVL.GVL_Graficos.bOcultaY2 = false;
                _modelGVL.GVL_Graficos.bOcultaY3 = true;
                _modelGVL.GVL_Graficos.bOcultaY4 = true;

                #endregion

                #region Varriaveis Array Dados

                //os arrays dinamicos obtidos neste teste contem as seguintes grandezas:
                //GVL_Graficos.arrVarX[GVL_Graficos.diBuffer] := rDeslocamentoEntradaBooster_mm_Lin;
                //GVL_Graficos.arrVarY1[GVL_Graficos.diBuffer] := rPressaoCP_Bar_Lin;
                //GVL_Graficos.arrVarY2[GVL_Graficos.diBuffer] := rPressaoCS_Bar_Lin;
                //GVL_Graficos.arrVarY3[GVL_Graficos.diBuffer] := rForcaEntradaBooster_N_Lin;

                ClearArrayGVL_Graficos();

                _modelGVL.GVL_Graficos.arrVarTimeStamp = lstDblReturnReadFile[0].ToArray();
                _modelGVL.GVL_Graficos.arrVarX = lstDblReturnReadFile[5].ToArray();
                _modelGVL.GVL_Graficos.arrVarY1 = lstDblReturnReadFile[7].ToArray();
                _modelGVL.GVL_Graficos.arrVarY2 = lstDblReturnReadFile[6].ToArray();
                _modelGVL.GVL_Graficos.arrVarY3 = lstDblReturnReadFile[2].ToArray();

                #endregion

                #region Calculos

                if (_modelGVL.GVL_T16.bCalculaResultados)
                {
                    _modelGVL.GVL_T16 = HelperTestBase.Model_GVL.GVL_T16;

                    //Define o ponto maximo do array que foi plotado durante o teste
                    _modelGVL.GVL_Graficos.diBuffer = lstDblReturnReadFile[0].Count() > 0 ? lstDblReturnReadFile[0].Count() : 0;

                    diUbound = _modelGVL.GVL_Graficos.diBuffer; //Define o ponto maximo do array que foi plotado durante o teste

                    #region Loop para identificar a forca maxima do teste, e armazenar o ponto de inflexao do teste (quando o atuador comeca a retornar)
                    //========================================================================================================================================================

                    for (di = 0; di < diUbound; di++)
                    {
                        if (_modelGVL.GVL_Graficos.arrVarY3[di] > _modelGVL.GVL_T16.rForcaMaxima)
                        {
                            _modelGVL.GVL_T16.rForcaMaxima = _modelGVL.GVL_Graficos.arrVarY3[di]; //Atualiza o valor de forca maxima com o maior valor obtido no array
                            _modelGVL.GVL_T16.diPosicaoForcaMaxima = di; //Indica em qual posicao do array esta a forca maxima (pico do grafico, aonde comeca o retorno do atuador)
                        }
                    }

                    //========================================================================================================================================================
                    #endregion

                    #region Loop para identificar o deslocamento maximo
                    //========================================================================================================================================================

                    for (di = 0; di < diUbound; di++)
                    {
                        if (GVL_Graficos.arrVarX[di] > _modelGVL.GVL_T16.rDeslocamentoMaximo_mm)
                        {
                            _modelGVL.GVL_T16.rDeslocamentoMaximo_mm = _modelGVL.GVL_Graficos.arrVarX[di]; //Atualiza o valor de forca maxima com o maior valor obtido no array
                        }
                    }
                    #endregion

                    #region Loop para identificar o deslocamento na pressao solicitada
                    //========================================================================================================================================================
                    for (di = 0; di < diUbound; di++)
                    {
                        if (GVL_Graficos.arrVarY1[di] > _modelGVL.GVL_T16.rDeslocamentoNaPressao_Bar)
                        {
                            _modelGVL.GVL_T16.rDeslocamentoNaPressao_mm = _modelGVL.GVL_Graficos.arrVarX[di]; //Atualiza o valor de forca maxima com o maior valor obtido no array
                            break;
                        }
                    }
                    #endregion

                    #region Calculo do gradiente de aplicacao de força no avanço
                    //========================================================================================================================================================

                    //Busca no array o momento em que a forca comecou a subir (forca >= 100N) e o tempo decorrido desta forca
                    for (di = 0; di <= _modelGVL.GVL_T16.diPosicaoForcaMaxima; di++)
                    {
                        if (_modelGVL.GVL_Graficos.arrVarY3[di] >= 100)//forca comecou a subir (>=100N)
                        {
                            rForcaInicialGradiente = _modelGVL.GVL_Graficos.arrVarY3[di]; //Valor forca inicial para calculo 
                            rTempoInicialGradiente = _modelGVL.GVL_Graficos.arrVarTimeStamp[di]; //Valor to tempo em ms inicial para calculo

                            break; //Encerra a busca pela forca inicial
                        }
                    }

                    //Define a forca final e o tempo final do gradiente como a FMAX obtida no calculo anterior, utilizando seu indice para coletar o tempo respectivo
                    rForcaFinalGradiente = _modelGVL.GVL_Graficos.arrVarY3[_modelGVL.GVL_T16.diPosicaoForcaMaxima];
                    rTempoFinalGradiente = _modelGVL.GVL_Graficos.arrVarTimeStamp[_modelGVL.GVL_T16.diPosicaoForcaMaxima];

                    //Calcula o gradiente de aplicacao de forca no avanco
                    _modelGVL.GVL_T16.rGradienteForcaAvanco = (rForcaFinalGradiente - rForcaInicialGradiente) / (rTempoFinalGradiente - rTempoInicialGradiente);
                    //========================================================================================================================================================

                    #endregion

                    #region Calculo do gradiente de aplicacao de força no retorno
                    //========================================================================================================================================================

                    //Busca no array o momento em que a forca caiu abaixo de 100N (forca <= 100N) e o tempo decorrido desta forca
                    for (di = _modelGVL.GVL_T16.diPosicaoForcaMaxima; di < diUbound; di++)
                    {
                        if (_modelGVL.GVL_Graficos.arrVarY3[di] <= 100) //Forca proxima de 0 (<=100N)
                        {
                            rForcaFinalGradiente = _modelGVL.GVL_Graficos.arrVarY3[di]; //Valor forca final para calculo 
                            rTempoFinalGradiente = _modelGVL.GVL_Graficos.arrVarTimeStamp[di]; //Valor to tempo em ms final para calculo

                            break; //Encerra a busca pela forca final
                        }
                    }

                    //Define a forca inicial e o tempo inicial do gradiente como a FMAX obtida no calculo anterior, utilizando seu indice para coletar o tempo respectivo
                    rForcaInicialGradiente = _modelGVL.GVL_Graficos.arrVarY3[_modelGVL.GVL_T16.diPosicaoForcaMaxima];
                    rTempoInicialGradiente = _modelGVL.GVL_Graficos.arrVarTimeStamp[_modelGVL.GVL_T16.diPosicaoForcaMaxima];

                    //Calcula o gradiente de aplicacao de forca no retorno
                    _modelGVL.GVL_T16.rGradienteForcaRetorno = (rForcaFinalGradiente - rForcaInicialGradiente) / (rTempoFinalGradiente - rTempoInicialGradiente);
                    //========================================================================================================================================================
                    #endregion

                    #region Calculo do gradiente de avanço 
                    //========================================================================================================================================================

                    //Busca no array o momento em que o deslocamento comecou a variar (deslocamento >= 1)
                    for (di = 0; di <= _modelGVL.GVL_T16.diPosicaoForcaMaxima; di++)
                    {
                        if (_modelGVL.GVL_Graficos.arrVarX[di] >= 1) //Deslocamento >= 1mm
                        {
                            rDeslocamentoInicialGradiente = _modelGVL.GVL_Graficos.arrVarX[di]; //Valor deslocamento inicial para calculo 
                            rTempoInicialGradiente = _modelGVL.GVL_Graficos.arrVarTimeStamp[di]; //Valor to tempo em ms inicial para calculo

                            break; //Encerra a busca pelo deslocamento inicial
                        }
                    }

                    //Define a forca final e o tempo final do gradiente como a FMAX obtida no calculo anterior, utilizando seu indice para coletar o tempo respectivo
                    rDeslocamentoFinalGradiente = _modelGVL.GVL_Graficos.arrVarX[_modelGVL.GVL_T16.diPosicaoForcaMaxima];
                    rTempoFinalGradiente = _modelGVL.GVL_Graficos.arrVarTimeStamp[_modelGVL.GVL_T16.diPosicaoForcaMaxima];

                    //Calcula o gradiente de aplicacao de forca no avanco
                    _modelGVL.GVL_T16.rGradienteDeslocamentoAvanco = (rDeslocamentoFinalGradiente - rDeslocamentoInicialGradiente) / (rTempoFinalGradiente - rTempoInicialGradiente);
                    //========================================================================================================================================================

                    #endregion

                    #region Calculo do gradiente de deslocamento no retorno

                    //========================================================================================================================================================

                    //Busca no array o momento em que o deslocamento <= 1
                    for (di = _modelGVL.GVL_T16.diPosicaoForcaMaxima; di < diUbound; di++)
                    {
                        if (_modelGVL.GVL_Graficos.arrVarX[di] <= 1) //Deslocamento <= 1
                        {
                            rDeslocamentoFinalGradiente = _modelGVL.GVL_Graficos.arrVarX[di]; //Deslocamento final para calculo 
                            rTempoFinalGradiente = _modelGVL.GVL_Graficos.arrVarTimeStamp[di]; //Valor to tempo em ms final para calculo

                            break; //Encerra a busca pelo deslocamento final
                        }
                    }
                    //Define o deslocamento inicial e o tempo inicial do gradiente como a FMAX obtida no calculo anterior, utilizando seu indice para coletar o tempo respectivo
                    rDeslocamentoInicialGradiente = _modelGVL.GVL_Graficos.arrVarX[_modelGVL.GVL_T16.diPosicaoForcaMaxima];
                    rTempoInicialGradiente = _modelGVL.GVL_Graficos.arrVarTimeStamp[_modelGVL.GVL_T16.diPosicaoForcaMaxima];

                    //Calcula o gradiente de aplicacao de forca no retorno
                    _modelGVL.GVL_T16.rGradienteDeslocamentoRetorno = (rDeslocamentoFinalGradiente - rDeslocamentoInicialGradiente) / (rTempoFinalGradiente - rTempoInicialGradiente);
                    //========================================================================================================================================================

                    #endregion

                    #region Calculo dos Consumidores Utilizados

                    //========================================================================================================================================================

                    _modelGVL.GVL_T16.iConsumidoresCP = 0;
                    _modelGVL.GVL_T16.iConsumidoresCS = 0;

                    HelperTestBase.Model_GVL.GVL_Parametros.iTipoConsumidores = HelperMODBUS.CS_wTipoConsumidores;

                    if (HelperMODBUS.CS_wTipoConsumidores != 2)
                    {
                        _modelGVL.GVL_T16.iConsumidoresCP = 0;
                        _modelGVL.GVL_T16.iConsumidoresCS = 0;
                    }
                    else
                    {
                        //HelperMODBUS.CS_wStatusLiga17MangueirasCS 
                        if (HelperMODBUS.CS_wStatusLiga1MangueiraCP)
                            _modelGVL.GVL_T16.iConsumidoresCP = _modelGVL.GVL_T16.iConsumidoresCP + 1;

                        if (HelperMODBUS.CS_wStatusLiga2MangueirasCP)
                            _modelGVL.GVL_T16.iConsumidoresCP = _modelGVL.GVL_T16.iConsumidoresCP + 2;

                        if (HelperMODBUS.CS_wStatusLiga4MangueirasCP)
                            _modelGVL.GVL_T16.iConsumidoresCP = _modelGVL.GVL_T16.iConsumidoresCP + 4;

                        if (HelperMODBUS.CS_wStatusLiga8MangueirasCP)
                            _modelGVL.GVL_T16.iConsumidoresCP = _modelGVL.GVL_T16.iConsumidoresCP + 8;

                        if (HelperMODBUS.CS_wStatusLiga10MangueirasCP)
                            _modelGVL.GVL_T16.iConsumidoresCP = _modelGVL.GVL_T16.iConsumidoresCP + 10;

                        if (HelperMODBUS.CS_wStatusLiga17MangueirasCP)
                            _modelGVL.GVL_T16.iConsumidoresCP = _modelGVL.GVL_T16.iConsumidoresCP + 17;

                        if (HelperMODBUS.CS_wStatusLiga1MangueiraCS)
                            _modelGVL.GVL_T16.iConsumidoresCS = _modelGVL.GVL_T16.iConsumidoresCS + 1;

                        if (HelperMODBUS.CS_wStatusLiga2MangueirasCS)
                            _modelGVL.GVL_T16.iConsumidoresCS = _modelGVL.GVL_T16.iConsumidoresCS + 2;

                        if (HelperMODBUS.CS_wStatusLiga4MangueirasCS)
                            _modelGVL.GVL_T16.iConsumidoresCS = _modelGVL.GVL_T16.iConsumidoresCS + 4;

                        if (HelperMODBUS.CS_wStatusLiga8MangueirasCS)
                            _modelGVL.GVL_T16.iConsumidoresCS = _modelGVL.GVL_T16.iConsumidoresCS + 8;

                        if (HelperMODBUS.CS_wStatusLiga10MangueirasCS)
                            _modelGVL.GVL_T16.iConsumidoresCS = _modelGVL.GVL_T16.iConsumidoresCS + 10;

                        if (HelperMODBUS.CS_wStatusLiga17MangueirasCS)
                            _modelGVL.GVL_T16.iConsumidoresCS = _modelGVL.GVL_T16.iConsumidoresCS + 17;
                    }
                    //============================. ============================================================================================================================

                    #endregion

                    _modelGVL.GVL_T16.bCalculaResultados = false;

                    _modelGVL.GVL_Graficos.bDadosCalculados = true;
                }

                HelperTestBase.Model_GVL.helperTestBase_ModelGVL_Test = HelperTestBase.Model_GVL.GVL_T16;

                HelperTestBase.Model_GVL = _modelGVL;

                #endregion

            }
            catch (Exception ex)
            {
                var err = ex.Message;
                throw;
            }

            return _modelGVL;

            #endregion
        }

        #endregion

        #region T17 - Calculos verificacao Sensores - ET_Adjustment_LostTravelACUHydraulic
        public Model_GVL CalcGraphT17_ET_Adjustment_LostTravelACUHydraulic(bool bCalculaResultados, List<double>[] lstDblReturnReadFile)
        {
            #region PROGRAM T17_Calculos_Resultados

            try
            {
                #region Limpa ultimos resultados

                dictVarList.Clear();

                _modelGVL.GVL_T17.rForcaMaxima = 0; //Zera o ultimo valor de força obtido
                _modelGVL.GVL_T17.diPosicaoForcaMaxima = 0;
                _modelGVL.GVL_T17.rDeslocamentoMaximo_mm = 0;
                _modelGVL.GVL_T17.rCursoMorto_mm = 0;
                _modelGVL.GVL_T17.rCursoNaPressao1_mm = 0;
                _modelGVL.GVL_T17.rCursoNaPressao2_mm = 0;
                _modelGVL.GVL_T17.rCursoNaPressao3_mm = 0;
                _modelGVL.GVL_T17.rCursoNaPressao4_mm = 0;
                _modelGVL.GVL_T17.rGradienteForcaAvanco = 0; //Zera o ultimo valor obtido
                _modelGVL.GVL_T17.rGradienteForcaRetorno = 0; //Zera o ultimo valor obtido
                _modelGVL.GVL_T17.rGradienteDeslocamentoAvanco = 0; //Zera o ultimo valor obtido
                _modelGVL.GVL_T17.rGradienteDeslocamentoRetorno = 0; //Zera o ultimo valor obtido
                _modelGVL.GVL_T17.iConsumidoresCP = 0;
                _modelGVL.GVL_T17.iConsumidoresCS = 0;

                _modelGVL.GVL_T17.bCalculaResultados = bCalculaResultados;

                #region VARIABLES

                long diUbound = 0; //  ; DINT;
                long di = 0; //  ; DINT;
                double rForcaInicialGradiente = 0; //  ; REAL;
                double rForcaFinalGradiente = 0; //  ; REAL;
                double rDeslocamentoInicialGradiente = 0; //   ; REAL;
                double rDeslocamentoFinalGradiente = 0; //  ; REAL;
                double rTempoInicialGradiente = 0; //  ; REAL;
                double rTempoFinalGradiente = 0; //   ; REAL;


                #endregion

                #endregion

                #region Variaveis Grafico

                _modelGVL.GVL_Graficos.rEscalaX = 1500;
                _modelGVL.GVL_Graficos.EixoX.wsTLLabel = "AxesChart.1";
                _modelGVL.GVL_Graficos.rEscalaY1 = 150;
                _modelGVL.GVL_Graficos.EixoY1.wsTLLabel = "AxesChart.3";
                _modelGVL.GVL_Graficos.rEscalaY2 = 150;
                _modelGVL.GVL_Graficos.EixoY2.wsTLLabel = string.Empty;
                _modelGVL.GVL_Graficos.rEscalaY3 = 0;
                _modelGVL.GVL_Graficos.EixoY3.wsTLLabel = string.Empty;
                _modelGVL.GVL_Graficos.rEscalaY4 = 0;
                _modelGVL.GVL_Graficos.EixoY4.wsTLLabel = string.Empty;

                _modelGVL.GVL_Graficos.strNomeEixoX = "Input Travel (mm)";
                _modelGVL.GVL_Graficos.strNomeEixoY1 = "Pressure PC (bar)";
                _modelGVL.GVL_Graficos.strNomeEixoY2 = "Pressure SC (bar";
                _modelGVL.GVL_Graficos.strNomeEixoY3 = "Input Force (N)";
                _modelGVL.GVL_Graficos.strNomeEixoY4 = string.Empty;

                _modelGVL.GVL_Graficos.strUnidadeX = "mm";
                _modelGVL.GVL_Graficos.strUnidadeY1 = "bar";
                _modelGVL.GVL_Graficos.strUnidadeY2 = "bar";
                _modelGVL.GVL_Graficos.strUnidadeY3 = "N";
                _modelGVL.GVL_Graficos.strUnidadeY4 = string.Empty;

                _modelGVL.GVL_Graficos.bOcultaY2 = false;
                _modelGVL.GVL_Graficos.bOcultaY3 = true;
                _modelGVL.GVL_Graficos.bOcultaY4 = true;

                #endregion

                #region Varriaveis Array Dados

                //os arrays dinamicos obtidos neste teste contem as seguintes grandezas:
                //GVL_Graficos.arrVarX[GVL_Graficos.diBuffer] := rDeslocamentoEntradaBooster_mm_Lin;
                //GVL_Graficos.arrVarY1[GVL_Graficos.diBuffer] := rPressaoCP_Bar_Lin;
                //GVL_Graficos.arrVarY2[GVL_Graficos.diBuffer] := rPressaoCS_Bar_Lin;
                //GVL_Graficos.arrVarY3[GVL_Graficos.diBuffer] := rForcaEntradaBooster_N_Lin;

                ClearArrayGVL_Graficos();

                _modelGVL.GVL_Graficos.arrVarTimeStamp = lstDblReturnReadFile[0].ToArray();
                _modelGVL.GVL_Graficos.arrVarX = lstDblReturnReadFile[5].ToArray();
                _modelGVL.GVL_Graficos.arrVarY3 = lstDblReturnReadFile[2].ToArray();

                if (_modelGVL.GVL_Parametros.iOutput < 2) //OutputPC
                {
                    _modelGVL.GVL_Parametros.iOutput = 1;
                    _modelGVL.GVL_Graficos.arrVarY1 = lstDblReturnReadFile[7].ToArray();
                    _modelGVL.GVL_Graficos.arrVarY2 = lstDblReturnReadFile[6].ToArray();
                }
                else  //OutputSC
                {
                    _modelGVL.GVL_Graficos.arrVarY1 = lstDblReturnReadFile[6].ToArray();
                    _modelGVL.GVL_Graficos.arrVarY2 = lstDblReturnReadFile[7].ToArray();
                }

                #endregion

                #region Calculos

                if (_modelGVL.GVL_T17.bCalculaResultados)
                {
                    _modelGVL.GVL_T17 = HelperTestBase.Model_GVL.GVL_T17;

                    //Define o ponto maximo do array que foi plotado durante o teste
                    _modelGVL.GVL_Graficos.diBuffer = lstDblReturnReadFile[0].Count() > 0 ? lstDblReturnReadFile[0].Count() : 0;

                    diUbound = _modelGVL.GVL_Graficos.diBuffer; //Define o ponto maximo do array que foi plotado durante o teste

                    #region Loop para identificar a forca maxima do teste, e armazenar o ponto de inflexao do teste (quando o atuador comeca a retornar)
                    //========================================================================================================================================================

                    for (di = 0; di < diUbound; di++)
                    {
                        if (_modelGVL.GVL_Graficos.arrVarY3[di] > _modelGVL.GVL_T17.rForcaMaxima)
                        {
                            _modelGVL.GVL_T17.rForcaMaxima = _modelGVL.GVL_Graficos.arrVarY3[di]; //Atualiza o valor de forca maxima com o maior valor obtido no array
                            _modelGVL.GVL_T17.diPosicaoForcaMaxima = di; //Indica em qual posicao do array esta a forca maxima (pico do grafico, aonde comeca o retorno do atuador)
                        }
                    }

                    //========================================================================================================================================================
                    #endregion

                    #region Loop para identificar o deslocamento maximo
                    //========================================================================================================================================================

                    for (di = 0; di < diUbound; di++)
                    {
                        if (_modelGVL.GVL_Graficos.arrVarX[di] > _modelGVL.GVL_T17.rDeslocamentoMaximo_mm)
                        {
                            _modelGVL.GVL_T17.rDeslocamentoMaximo_mm = _modelGVL.GVL_Graficos.arrVarX[di]; //Atualiza o valor de forca maxima com o maior valor obtido no array
                        }
                    }
                    #endregion

                    #region Loop para identificar o curso morto
                    //========================================================================================================================================================
                    double SomaPressao = 0;
                    double MediaPressao = 0;

                    for (di = 0; di < diUbound; di++)
                    {
                        if (_modelGVL.GVL_Graficos.arrVarY1[di] > _modelGVL.GVL_T17.rCursoMortoNaPressao_Bar)
                        {
                            SomaPressao = 0;

                            for (int j = 0; j < 20; j++)
                            {
                                SomaPressao = SomaPressao + _modelGVL.GVL_Graficos.arrVarY1[di + j];
                            }

                            MediaPressao = SomaPressao / 20;

                            if (MediaPressao > _modelGVL.GVL_T17.rCursoMortoNaPressao_Bar)
                            {
                                _modelGVL.GVL_T17.rCursoMorto_mm = _modelGVL.GVL_Graficos.arrVarX[di]; //Atualiza o valor de forca maxima com o maior valor obtido no array
                                break;
                            }
                        }
                    }
                    #endregion

                    #region Loop para identificar o deslocamento na pressao solicitada (1)
                    //========================================================================================================================================================
                    for (di = 0; di < diUbound; di++) //isso aqui vc tem de ver
                    {
                        if (_modelGVL.GVL_Graficos.arrVarY1[di] > _modelGVL.GVL_T17.rCursoNaPressao1_Bar)
                        {
                            _modelGVL.GVL_T17.rCursoNaPressao1_mm = _modelGVL.GVL_Graficos.arrVarX[di]; //Atualiza o valor de forca maxima com o maior valor obtido no array
                            break;
                        }
                    }
                    #endregion

                    #region Loop para identificar o deslocamento na pressao solicitada (2)
                    //========================================================================================================================================================
                    for (di = 0; di < diUbound; di++)
                    {
                        if (_modelGVL.GVL_Graficos.arrVarY1[di] > _modelGVL.GVL_T17.rCursoNaPressao2_Bar)
                        {
                            _modelGVL.GVL_T17.rCursoNaPressao2_mm = _modelGVL.GVL_Graficos.arrVarX[di]; //Atualiza o valor de forca maxima com o maior valor obtido no array
                            break;
                        }
                    }
                    #endregion

                    #region Loop para identificar o deslocamento na pressao solicitada (3)
                    //========================================================================================================================================================
                    for (di = 0; di < diUbound; di++)
                    {
                        if (_modelGVL.GVL_Graficos.arrVarY1[di] > _modelGVL.GVL_T17.rCursoNaPressao3_Bar)
                        {
                            _modelGVL.GVL_T17.rCursoNaPressao3_mm = _modelGVL.GVL_Graficos.arrVarX[di]; //Atualiza o valor de forca maxima com o maior valor obtido no array
                            break;
                        }
                    }
                    #endregion

                    #region Loop para identificar o deslocamento na pressao solicitada (4)
                    //========================================================================================================================================================
                    for (di = 0; di < diUbound; di++)
                    {
                        if (_modelGVL.GVL_Graficos.arrVarY1[di] > _modelGVL.GVL_T17.rCursoNaPressao4_Bar)
                        {
                            _modelGVL.GVL_T17.rCursoNaPressao4_mm = _modelGVL.GVL_Graficos.arrVarX[di]; //Atualiza o valor de forca maxima com o maior valor obtido no array
                            break;
                        }
                    }
                    #endregion

                    #region Calculo do gradiente de aplicacao de força no avanço
                    //========================================================================================================================================================

                    //Busca no array o momento em que a forca comecou a subir (forca >= 100N) e o tempo decorrido desta forca
                    for (di = 0; di < _modelGVL.GVL_T17.diPosicaoForcaMaxima; di++)
                    {
                        if (_modelGVL.GVL_Graficos.arrVarY3[di] >= 100)//forca comecou a subir (>=100N)
                        {
                            rForcaInicialGradiente = _modelGVL.GVL_Graficos.arrVarY3[di]; //Valor forca inicial para calculo 
                            rTempoInicialGradiente = _modelGVL.GVL_Graficos.arrVarTimeStamp[di]; //Valor to tempo em ms inicial para calculo

                            break; //Encerra a busca pela forca inicial
                        }
                    }

                    //Define a forca final e o tempo final do gradiente como a FMAX obtida no calculo anterior, utilizando seu indice para coletar o tempo respectivo
                    rForcaFinalGradiente = _modelGVL.GVL_Graficos.arrVarY3[_modelGVL.GVL_T17.diPosicaoForcaMaxima];
                    rTempoFinalGradiente = _modelGVL.GVL_Graficos.arrVarTimeStamp[_modelGVL.GVL_T17.diPosicaoForcaMaxima];

                    //Calcula o gradiente de aplicacao de forca no avanco
                    _modelGVL.GVL_T17.rGradienteForcaAvanco = (rForcaFinalGradiente - rForcaInicialGradiente) / (rTempoFinalGradiente - rTempoInicialGradiente);
                    //========================================================================================================================================================

                    #endregion

                    #region Calculo do gradiente de aplicacao de força no retorno
                    //========================================================================================================================================================

                    //Busca no array o momento em que a forca caiu abaixo de 100N (forca <= 100N) e o tempo decorrido desta forca
                    for (di = _modelGVL.GVL_T17.diPosicaoForcaMaxima; di < diUbound; di++)
                    {
                        if (_modelGVL.GVL_Graficos.arrVarY3[di] <= 100) //Forca proxima de 0 (<=100N)
                        {
                            rForcaFinalGradiente = _modelGVL.GVL_Graficos.arrVarY3[di]; //Valor forca final para calculo 
                            rTempoFinalGradiente = _modelGVL.GVL_Graficos.arrVarTimeStamp[di]; //Valor to tempo em ms final para calculo

                            break; //Encerra a busca pela forca final
                        }
                    }

                    //Define a forca inicial e o tempo inicial do gradiente como a FMAX obtida no calculo anterior, utilizando seu indice para coletar o tempo respectivo
                    rForcaInicialGradiente = _modelGVL.GVL_Graficos.arrVarY3[_modelGVL.GVL_T17.diPosicaoForcaMaxima];
                    rTempoInicialGradiente = _modelGVL.GVL_Graficos.arrVarTimeStamp[_modelGVL.GVL_T17.diPosicaoForcaMaxima];

                    //Calcula o gradiente de aplicacao de forca no retorno
                    _modelGVL.GVL_T17.rGradienteForcaRetorno = (rForcaFinalGradiente - rForcaInicialGradiente) / (rTempoFinalGradiente - rTempoInicialGradiente);
                    //========================================================================================================================================================
                    #endregion

                    #region Calculo do gradiente de avanço 
                    //========================================================================================================================================================

                    //Busca no array o momento em que o deslocamento comecou a variar (deslocamento >= 1)
                    for (di = 0; di < _modelGVL.GVL_T17.diPosicaoForcaMaxima; di++)
                    {
                        if (_modelGVL.GVL_Graficos.arrVarX[di] >= 1) //Deslocamento >= 1mm
                        {
                            rDeslocamentoInicialGradiente = _modelGVL.GVL_Graficos.arrVarX[di]; //Valor deslocamento inicial para calculo 
                            rTempoInicialGradiente = _modelGVL.GVL_Graficos.arrVarTimeStamp[di]; //Valor to tempo em ms inicial para calculo

                            break; //Encerra a busca pelo deslocamento inicial
                        }
                    }

                    //Define a forca final e o tempo final do gradiente como a FMAX obtida no calculo anterior, utilizando seu indice para coletar o tempo respectivo
                    rDeslocamentoFinalGradiente = _modelGVL.GVL_Graficos.arrVarX[_modelGVL.GVL_T17.diPosicaoForcaMaxima];
                    rTempoFinalGradiente = _modelGVL.GVL_Graficos.arrVarTimeStamp[_modelGVL.GVL_T17.diPosicaoForcaMaxima];

                    //Calcula o gradiente de aplicacao de forca no avanco
                    _modelGVL.GVL_T17.rGradienteDeslocamentoAvanco = (rDeslocamentoFinalGradiente - rDeslocamentoInicialGradiente) / (rTempoFinalGradiente - rTempoInicialGradiente);
                    //========================================================================================================================================================

                    #endregion

                    #region Calculo do gradiente de deslocamento no retorno

                    //========================================================================================================================================================

                    //Busca no array o momento em que o deslocamento <= 1
                    for (di = _modelGVL.GVL_T17.diPosicaoForcaMaxima; di < diUbound; di++)
                    {
                        if (_modelGVL.GVL_Graficos.arrVarX[di] <= 1) //Deslocamento <= 1
                        {
                            rDeslocamentoFinalGradiente = _modelGVL.GVL_Graficos.arrVarX[di]; //Deslocamento final para calculo 
                            rTempoFinalGradiente = _modelGVL.GVL_Graficos.arrVarTimeStamp[di]; //Valor to tempo em ms final para calculo

                            break; //Encerra a busca pelo deslocamento final
                        }
                    }
                    //Define o deslocamento inicial e o tempo inicial do gradiente como a FMAX obtida no calculo anterior, utilizando seu indice para coletar o tempo respectivo
                    rDeslocamentoInicialGradiente = _modelGVL.GVL_Graficos.arrVarX[_modelGVL.GVL_T17.diPosicaoForcaMaxima];
                    rTempoInicialGradiente = _modelGVL.GVL_Graficos.arrVarTimeStamp[_modelGVL.GVL_T17.diPosicaoForcaMaxima];

                    //Calcula o gradiente de aplicacao de forca no retorno
                    _modelGVL.GVL_T17.rGradienteDeslocamentoRetorno = (rDeslocamentoFinalGradiente - rDeslocamentoInicialGradiente) / (rTempoFinalGradiente - rTempoInicialGradiente);
                    //========================================================================================================================================================

                    #endregion

                    #region Calculo dos Consumidores Utilizados

                    //========================================================================================================================================================

                    _modelGVL.GVL_T17.iConsumidoresCP = 0;
                    _modelGVL.GVL_T17.iConsumidoresCS = 0;

                    HelperTestBase.Model_GVL.GVL_Parametros.iTipoConsumidores = HelperMODBUS.CS_wTipoConsumidores;

                    if (HelperMODBUS.CS_wTipoConsumidores != 2)
                    {
                        _modelGVL.GVL_T17.iConsumidoresCP = 0;
                        _modelGVL.GVL_T17.iConsumidoresCS = 0;
                    }
                    else
                    {
                        //HelperMODBUS.CS_wStatusLiga17MangueirasCS 
                        if (HelperMODBUS.CS_wStatusLiga1MangueiraCP)
                            _modelGVL.GVL_T17.iConsumidoresCP = _modelGVL.GVL_T17.iConsumidoresCP + 1;

                        if (HelperMODBUS.CS_wStatusLiga2MangueirasCP)
                            _modelGVL.GVL_T17.iConsumidoresCP = _modelGVL.GVL_T17.iConsumidoresCP + 2;

                        if (HelperMODBUS.CS_wStatusLiga4MangueirasCP)
                            _modelGVL.GVL_T17.iConsumidoresCP = _modelGVL.GVL_T17.iConsumidoresCP + 4;

                        if (HelperMODBUS.CS_wStatusLiga8MangueirasCP)
                            _modelGVL.GVL_T17.iConsumidoresCP = _modelGVL.GVL_T17.iConsumidoresCP + 8;

                        if (HelperMODBUS.CS_wStatusLiga10MangueirasCP)
                            _modelGVL.GVL_T17.iConsumidoresCP = _modelGVL.GVL_T17.iConsumidoresCP + 10;

                        if (HelperMODBUS.CS_wStatusLiga17MangueirasCP)
                            _modelGVL.GVL_T17.iConsumidoresCP = _modelGVL.GVL_T17.iConsumidoresCP + 17;

                        if (HelperMODBUS.CS_wStatusLiga1MangueiraCS)
                            _modelGVL.GVL_T17.iConsumidoresCS = _modelGVL.GVL_T17.iConsumidoresCS + 1;

                        if (HelperMODBUS.CS_wStatusLiga2MangueirasCS)
                            _modelGVL.GVL_T17.iConsumidoresCS = _modelGVL.GVL_T17.iConsumidoresCS + 2;

                        if (HelperMODBUS.CS_wStatusLiga4MangueirasCS)
                            _modelGVL.GVL_T17.iConsumidoresCS = _modelGVL.GVL_T17.iConsumidoresCS + 4;

                        if (HelperMODBUS.CS_wStatusLiga8MangueirasCS)
                            _modelGVL.GVL_T17.iConsumidoresCS = _modelGVL.GVL_T17.iConsumidoresCS + 8;

                        if (HelperMODBUS.CS_wStatusLiga10MangueirasCS)
                            _modelGVL.GVL_T17.iConsumidoresCS = _modelGVL.GVL_T17.iConsumidoresCS + 10;

                        if (HelperMODBUS.CS_wStatusLiga17MangueirasCS)
                            _modelGVL.GVL_T17.iConsumidoresCS = _modelGVL.GVL_T17.iConsumidoresCS + 17;
                    }
                    //============================. ============================================================================================================================

                    #endregion

                    _modelGVL.GVL_T17.bCalculaResultados = false;

                    _modelGVL.GVL_Graficos.bDadosCalculados = true;
                }

                HelperTestBase.Model_GVL.helperTestBase_ModelGVL_Test = HelperTestBase.Model_GVL.GVL_T17;

                HelperTestBase.Model_GVL = _modelGVL;

                #endregion

            }
            catch (Exception ex)
            {
                var err = ex.Message;
                throw;
            }

            return _modelGVL;

            #endregion
        }

        #endregion

        #region T18 - Calculos verificacao Sensores - ET_Adjustment_LostTravelACUHydraulic_ElectricActuation
        public Model_GVL CalcGraphT18_ET_Adjustment_LostTravelACUHydraulic_ElectricActuation(bool bCalculaResultados, List<double>[] lstDblReturnReadFile)
        {
            #region PROGRAM T18_Calculos_Resultados

            try
            {
                #region Limpa ultimos resultados

                dictVarList.Clear();

                _modelGVL.GVL_T18.rForcaMaxima = 0; //Zera o ultimo valor de força obtido
                _modelGVL.GVL_T18.diPosicaoForcaMaxima = 0;
                _modelGVL.GVL_T18.rDeslocamentoMaximo_mm = 0;
                _modelGVL.GVL_T18.rCursoMorto_mm = 0;
                _modelGVL.GVL_T18.rCursoNaPressao1_mm = 0;
                _modelGVL.GVL_T18.rCursoNaPressao2_mm = 0;
                _modelGVL.GVL_T18.rCursoNaPressao3_mm = 0;
                _modelGVL.GVL_T18.rCursoNaPressao4_mm = 0;
                _modelGVL.GVL_T18.rGradienteForcaAvanco = 0; //Zera o ultimo valor obtido
                _modelGVL.GVL_T18.rGradienteDeslocamentoAvanco = 0; //Zera o ultimo valor obtido
                _modelGVL.GVL_T18.iConsumidoresCP = 0;
                _modelGVL.GVL_T18.iConsumidoresCS = 0;

                _modelGVL.GVL_T18.bCalculaResultados = bCalculaResultados;

                #region VARIABLES

                long diUbound = 0; //  ; DINT;
                long di = 0; //  ; DINT;
                double rForcaInicialGradiente = 0; //  ; REAL;
                double rForcaFinalGradiente = 0; //  ; REAL;
                double rDeslocamentoInicialGradiente = 0; //   ; REAL;
                double rDeslocamentoFinalGradiente = 0; //  ; REAL;
                double rTempoInicialGradiente = 0; //  ; REAL;
                double rTempoFinalGradiente = 0; //   ; REAL;


                #endregion

                #endregion

                #region Variaveis Grafico

                _modelGVL.GVL_Graficos.rEscalaX = 1500;
                _modelGVL.GVL_Graficos.EixoX.wsTLLabel = "AxesChart.1";
                _modelGVL.GVL_Graficos.rEscalaY1 = 150;
                _modelGVL.GVL_Graficos.EixoY1.wsTLLabel = "AxesChart.3";
                _modelGVL.GVL_Graficos.rEscalaY2 = 150;
                _modelGVL.GVL_Graficos.EixoY2.wsTLLabel = string.Empty;
                _modelGVL.GVL_Graficos.rEscalaY3 = 0;
                _modelGVL.GVL_Graficos.EixoY3.wsTLLabel = string.Empty;
                _modelGVL.GVL_Graficos.rEscalaY4 = 0;
                _modelGVL.GVL_Graficos.EixoY4.wsTLLabel = string.Empty;

                _modelGVL.GVL_Graficos.strNomeEixoX = "Input Travel (mm)";
                _modelGVL.GVL_Graficos.strNomeEixoY1 = "Pressure PC (bar)";
                _modelGVL.GVL_Graficos.strNomeEixoY2 = "Pressure SC (bar";
                _modelGVL.GVL_Graficos.strNomeEixoY3 = "Input Force (N)";
                _modelGVL.GVL_Graficos.strNomeEixoY4 = string.Empty;

                _modelGVL.GVL_Graficos.strUnidadeX = "mm";
                _modelGVL.GVL_Graficos.strUnidadeY1 = "bar";
                _modelGVL.GVL_Graficos.strUnidadeY2 = "bar";
                _modelGVL.GVL_Graficos.strUnidadeY3 = "N";
                _modelGVL.GVL_Graficos.strUnidadeY4 = string.Empty;

                _modelGVL.GVL_Graficos.bOcultaY2 = false;
                _modelGVL.GVL_Graficos.bOcultaY3 = true;
                _modelGVL.GVL_Graficos.bOcultaY4 = true;

                #endregion

                #region Varriaveis Array Dados

                //os arrays dinamicos obtidos neste teste contem as seguintes grandezas:
                //GVL_Graficos.arrVarX[GVL_Graficos.diBuffer] := rDeslocamentoEntradaBooster_mm_Lin;
                //GVL_Graficos.arrVarY1[GVL_Graficos.diBuffer] := rPressaoCP_Bar_Lin;
                //GVL_Graficos.arrVarY2[GVL_Graficos.diBuffer] := rPressaoCS_Bar_Lin;
                //GVL_Graficos.arrVarY3[GVL_Graficos.diBuffer] := rForcaEntradaBooster_N_Lin;

                ClearArrayGVL_Graficos();

                _modelGVL.GVL_Graficos.arrVarTimeStamp = lstDblReturnReadFile[0].ToArray();
                _modelGVL.GVL_Graficos.arrVarX = lstDblReturnReadFile[5].ToArray();
                _modelGVL.GVL_Graficos.arrVarY3 = lstDblReturnReadFile[2].ToArray();

                if (_modelGVL.GVL_Parametros.iOutput < 2) //OutputPC
                {
                    _modelGVL.GVL_Parametros.iOutput = 1;
                    _modelGVL.GVL_Graficos.arrVarY1 = lstDblReturnReadFile[7].ToArray();
                    _modelGVL.GVL_Graficos.arrVarY2 = lstDblReturnReadFile[6].ToArray();
                }
                else  //OutputSC
                {
                    _modelGVL.GVL_Graficos.arrVarY1 = lstDblReturnReadFile[6].ToArray();
                    _modelGVL.GVL_Graficos.arrVarY2 = lstDblReturnReadFile[7].ToArray();
                }


                #endregion

                #region Calculos

                if (_modelGVL.GVL_T18.bCalculaResultados)
                {
                    _modelGVL.GVL_T18 = HelperTestBase.Model_GVL.GVL_T18;

                    //Define o ponto maximo do array que foi plotado durante o teste
                    _modelGVL.GVL_Graficos.diBuffer = lstDblReturnReadFile[0].Count() > 0 ? lstDblReturnReadFile[0].Count() : 0;

                    diUbound = _modelGVL.GVL_Graficos.diBuffer; //Define o ponto maximo do array que foi plotado durante o teste

                    #region Loop para identificar a forca maxima do teste, e armazenar o ponto de inflexao do teste (quando o atuador comeca a retornar)
                    //========================================================================================================================================================

                    for (di = 0; di < diUbound; di++)
                    {
                        if (_modelGVL.GVL_Graficos.arrVarY3[di] > _modelGVL.GVL_T18.rForcaMaxima)
                        {
                            _modelGVL.GVL_T18.rForcaMaxima = _modelGVL.GVL_Graficos.arrVarY3[di]; //Atualiza o valor de forca maxima com o maior valor obtido no array
                            _modelGVL.GVL_T18.diPosicaoForcaMaxima = di; //Indica em qual posicao do array esta a forca maxima (pico do grafico, aonde comeca o retorno do atuador)
                        }
                    }

                    //========================================================================================================================================================
                    #endregion

                    #region Loop para identificar o deslocamento maximo
                    //========================================================================================================================================================

                    for (di = 0; di < diUbound; di++)
                    {
                        if (_modelGVL.GVL_Graficos.arrVarX[di] > _modelGVL.GVL_T18.rDeslocamentoMaximo_mm)
                        {
                            _modelGVL.GVL_T18.rDeslocamentoMaximo_mm = _modelGVL.GVL_Graficos.arrVarX[di]; //Atualiza o valor de forca maxima com o maior valor obtido no array
                        }
                    }
                    #endregion

                    #region Loop para identificar o curso morto
                    //========================================================================================================================================================
                    double SomaPressao = 0;
                    double MediaPressao = 0;

                    for (di = 0; di < diUbound; di++)
                    {
                        if (_modelGVL.GVL_Graficos.arrVarY1[di] > 0.1)// _modelGVL.GVL_T18.rCursoMortoNaPressao_Bar)
                        {
                            SomaPressao = 0;

                            for (int j = 0; j < 20; j++)
                            {
                                SomaPressao = SomaPressao + _modelGVL.GVL_Graficos.arrVarY1[di + j];
                            }

                            MediaPressao = SomaPressao / 20;

                            if (MediaPressao > 0.1)//_modelGVL.GVL_T18.rCursoMortoNaPressao_Bar)
                            {
                                _modelGVL.GVL_T18.rCursoMorto_mm = _modelGVL.GVL_Graficos.arrVarX[di]; //Atualiza o valor de forca maxima com o maior valor obtido no array
                                break;
                            }
                        }
                    }

                    #endregion

                    #region Loop para identificar o deslocamento na pressao solicitada (1)
                    //========================================================================================================================================================
                    for (di = 0; di < diUbound; di++)
                    {
                        if (_modelGVL.GVL_Graficos.arrVarY1[di] > _modelGVL.GVL_T18.rCursoNaPressao1_Bar)
                        {
                            _modelGVL.GVL_T18.rCursoNaPressao1_mm = _modelGVL.GVL_Graficos.arrVarX[di]; //Atualiza o valor de forca maxima com o maior valor obtido no array
                            break;
                        }
                    }
                    #endregion

                    #region Loop para identificar o deslocamento na pressao solicitada (2)
                    //========================================================================================================================================================
                    for (di = 0; di < diUbound; di++)
                    {
                        if (_modelGVL.GVL_Graficos.arrVarY1[di] > _modelGVL.GVL_T18.rCursoNaPressao2_Bar)
                        {
                            _modelGVL.GVL_T18.rCursoNaPressao2_mm = _modelGVL.GVL_Graficos.arrVarX[di]; //Atualiza o valor de forca maxima com o maior valor obtido no array
                            break;
                        }
                    }
                    #endregion

                    #region Loop para identificar o deslocamento na pressao solicitada (3)
                    //========================================================================================================================================================
                    for (di = 0; di < diUbound; di++)
                    {
                        if (_modelGVL.GVL_Graficos.arrVarY1[di] > _modelGVL.GVL_T18.rCursoNaPressao3_Bar)
                        {
                            _modelGVL.GVL_T18.rCursoNaPressao3_mm = _modelGVL.GVL_Graficos.arrVarX[di]; //Atualiza o valor de forca maxima com o maior valor obtido no array
                            break;
                        }
                    }
                    #endregion

                    #region Loop para identificar o deslocamento na pressao solicitada (4)
                    //========================================================================================================================================================
                    for (di = 0; di < diUbound; di++)
                    {
                        if (_modelGVL.GVL_Graficos.arrVarY1[di] > _modelGVL.GVL_T18.rCursoNaPressao4_Bar)
                        {
                            _modelGVL.GVL_T18.rCursoNaPressao4_mm = _modelGVL.GVL_Graficos.arrVarX[di]; //Atualiza o valor de forca maxima com o maior valor obtido no array
                            break;
                        }
                    }
                    #endregion

                    #region Calculo do gradiente de aplicacao de força no avanço
                    //========================================================================================================================================================

                    //Busca no array o momento em que a forca comecou a subir (forca >= 100N) e o tempo decorrido desta forca
                    for (di = 0; di <= _modelGVL.GVL_T18.diPosicaoForcaMaxima; di++)
                    {
                        if (_modelGVL.GVL_Graficos.arrVarY3[di] >= 100)//forca comecou a subir (>=100N)
                        {
                            rForcaInicialGradiente = _modelGVL.GVL_Graficos.arrVarY3[di]; //Valor forca inicial para calculo 
                            rTempoInicialGradiente = _modelGVL.GVL_Graficos.arrVarTimeStamp[di]; //Valor to tempo em ms inicial para calculo

                            break; //Encerra a busca pela forca inicial
                        }
                    }

                    //Define a forca final e o tempo final do gradiente como a FMAX obtida no calculo anterior, utilizando seu indice para coletar o tempo respectivo
                    rForcaFinalGradiente = _modelGVL.GVL_Graficos.arrVarY3[_modelGVL.GVL_T18.diPosicaoForcaMaxima];
                    rTempoFinalGradiente = _modelGVL.GVL_Graficos.arrVarTimeStamp[_modelGVL.GVL_T18.diPosicaoForcaMaxima];

                    //Calcula o gradiente de aplicacao de forca no avanco
                    _modelGVL.GVL_T18.rGradienteForcaAvanco = (rForcaFinalGradiente - rForcaInicialGradiente) / (rTempoFinalGradiente - rTempoInicialGradiente);
                    //========================================================================================================================================================

                    #endregion

                    #region Calculo do gradiente de avanço 
                    //========================================================================================================================================================

                    //Busca no array o momento em que o deslocamento comecou a variar (deslocamento >= 1)
                    for (di = 0; di <= _modelGVL.GVL_T18.diPosicaoForcaMaxima; di++)
                    {
                        if (_modelGVL.GVL_Graficos.arrVarX[di] >= 1) //Deslocamento >= 1mm
                        {
                            rDeslocamentoInicialGradiente = _modelGVL.GVL_Graficos.arrVarX[di]; //Valor deslocamento inicial para calculo 
                            rTempoInicialGradiente = _modelGVL.GVL_Graficos.arrVarTimeStamp[di]; //Valor to tempo em ms inicial para calculo

                            break; //Encerra a busca pelo deslocamento inicial
                        }
                    }

                    //Define a forca final e o tempo final do gradiente como a FMAX obtida no calculo anterior, utilizando seu indice para coletar o tempo respectivo
                    rDeslocamentoFinalGradiente = _modelGVL.GVL_Graficos.arrVarX[_modelGVL.GVL_T18.diPosicaoForcaMaxima];
                    rTempoFinalGradiente = _modelGVL.GVL_Graficos.arrVarTimeStamp[_modelGVL.GVL_T18.diPosicaoForcaMaxima];

                    //Calcula o gradiente de aplicacao de forca no avanco
                    _modelGVL.GVL_T18.rGradienteDeslocamentoAvanco = (rDeslocamentoFinalGradiente - rDeslocamentoInicialGradiente) / (rTempoFinalGradiente - rTempoInicialGradiente);
                    //========================================================================================================================================================

                    #endregion

                    #region Calculo dos Consumidores Utilizados

                    //========================================================================================================================================================

                    _modelGVL.GVL_T18.iConsumidoresCP = 0;
                    _modelGVL.GVL_T18.iConsumidoresCS = 0;

                    HelperTestBase.Model_GVL.GVL_Parametros.iTipoConsumidores = HelperMODBUS.CS_wTipoConsumidores;

                    if (HelperMODBUS.CS_wTipoConsumidores != 2)
                    {
                        _modelGVL.GVL_T18.iConsumidoresCP = 0;
                        _modelGVL.GVL_T18.iConsumidoresCS = 0;
                    }
                    else
                    {
                        //HelperMODBUS.CS_wStatusLiga17MangueirasCS 
                        if (HelperMODBUS.CS_wStatusLiga1MangueiraCP)
                            _modelGVL.GVL_T18.iConsumidoresCP = _modelGVL.GVL_T18.iConsumidoresCP + 1;

                        if (HelperMODBUS.CS_wStatusLiga2MangueirasCP)
                            _modelGVL.GVL_T18.iConsumidoresCP = _modelGVL.GVL_T18.iConsumidoresCP + 2;

                        if (HelperMODBUS.CS_wStatusLiga4MangueirasCP)
                            _modelGVL.GVL_T18.iConsumidoresCP = _modelGVL.GVL_T18.iConsumidoresCP + 4;

                        if (HelperMODBUS.CS_wStatusLiga8MangueirasCP)
                            _modelGVL.GVL_T18.iConsumidoresCP = _modelGVL.GVL_T18.iConsumidoresCP + 8;

                        if (HelperMODBUS.CS_wStatusLiga10MangueirasCP)
                            _modelGVL.GVL_T18.iConsumidoresCP = _modelGVL.GVL_T18.iConsumidoresCP + 10;

                        if (HelperMODBUS.CS_wStatusLiga17MangueirasCP)
                            _modelGVL.GVL_T18.iConsumidoresCP = _modelGVL.GVL_T18.iConsumidoresCP + 17;

                        if (HelperMODBUS.CS_wStatusLiga1MangueiraCS)
                            _modelGVL.GVL_T18.iConsumidoresCS = _modelGVL.GVL_T18.iConsumidoresCS + 1;

                        if (HelperMODBUS.CS_wStatusLiga2MangueirasCS)
                            _modelGVL.GVL_T18.iConsumidoresCS = _modelGVL.GVL_T18.iConsumidoresCS + 2;

                        if (HelperMODBUS.CS_wStatusLiga4MangueirasCS)
                            _modelGVL.GVL_T18.iConsumidoresCS = _modelGVL.GVL_T18.iConsumidoresCS + 4;

                        if (HelperMODBUS.CS_wStatusLiga8MangueirasCS)
                            _modelGVL.GVL_T18.iConsumidoresCS = _modelGVL.GVL_T18.iConsumidoresCS + 8;

                        if (HelperMODBUS.CS_wStatusLiga10MangueirasCS)
                            _modelGVL.GVL_T18.iConsumidoresCS = _modelGVL.GVL_T18.iConsumidoresCS + 10;

                        if (HelperMODBUS.CS_wStatusLiga17MangueirasCS)
                            _modelGVL.GVL_T18.iConsumidoresCS = _modelGVL.GVL_T18.iConsumidoresCS + 17;
                    }
                    //============================. ============================================================================================================================

                    #endregion

                    _modelGVL.GVL_T18.bCalculaResultados = false;

                    _modelGVL.GVL_Graficos.bDadosCalculados = true;
                }

                HelperTestBase.Model_GVL.helperTestBase_ModelGVL_Test = HelperTestBase.Model_GVL.GVL_T18;

                HelperTestBase.Model_GVL = _modelGVL;

                #endregion

            }
            catch (Exception ex)
            {
                var err = ex.Message;
                throw;
            }

            return _modelGVL;

            #endregion
        }

        #endregion

        #region T19 - Calculos verificacao Sensores - ET_Adjustment_LostTravelACUPneumatic_Primary

        public Model_GVL CalcGraphT19_ET_Adjustment_LostTravelACUPneumatic_Primary(bool bCalculaResultados, List<double>[] lstDblReturnReadFile)
        {
            #region PROGRAM T19_Calculos_Resultados

            try
            {
                #region Limpa ultimos resultados

                dictVarList.Clear();

                _modelGVL.GVL_T19.rForcaMaxima = 0; //Zera o ultimo valor de força obtido
                _modelGVL.GVL_T19.diPosicaoForcaMaxima = 0;

                _modelGVL.GVL_T19.rGradienteForcaAvanco = 0; //Zera o ultimo valor obtido
                _modelGVL.GVL_T19.rGradienteForcaRetorno = 0; //Zera o ultimo valor obtido
                _modelGVL.GVL_T19.rGradienteDeslocamentoAvanco = 0; //Zera o ultimo valor obtido
                _modelGVL.GVL_T19.rGradienteDeslocamentoRetorno = 0; //Zera o ultimo valor obtido

                _modelGVL.GVL_T19.rDeslocamentoNaPressao_mm = 0;

                _modelGVL.GVL_T19.bCalculaResultados = bCalculaResultados;

                #region VARIABLES

                long diUbound = 0; //  ; DINT;
                long di = 0; //  ; DINT;
                double rForcaInicialGradiente = 0; //  ; REAL;
                double rForcaFinalGradiente = 0; //  ; REAL;
                double rDeslocamentoInicialGradiente = 0; //   ; REAL;
                double rDeslocamentoFinalGradiente = 0; //  ; REAL;
                double rTempoInicialGradiente = 0; //  ; REAL;
                double rTempoFinalGradiente = 0; //   ; REAL;


                #endregion

                #endregion

                #region Variaveis Grafico

                _modelGVL.GVL_Graficos.rEscalaX = 20;
                _modelGVL.GVL_Graficos.EixoX.wsTLLabel = "AxesChart.1";
                _modelGVL.GVL_Graficos.rEscalaY1 = 1;
                _modelGVL.GVL_Graficos.EixoY1.wsTLLabel = "AxesChart.3";
                _modelGVL.GVL_Graficos.rEscalaY2 = 0;
                _modelGVL.GVL_Graficos.EixoY2.wsTLLabel = string.Empty;
                _modelGVL.GVL_Graficos.rEscalaY3 = 0;
                _modelGVL.GVL_Graficos.EixoY3.wsTLLabel = string.Empty;
                _modelGVL.GVL_Graficos.rEscalaY4 = 0;
                _modelGVL.GVL_Graficos.EixoY4.wsTLLabel = string.Empty;

                _modelGVL.GVL_Graficos.strNomeEixoX = "Input Travel (mm)";
                _modelGVL.GVL_Graficos.strNomeEixoY1 = "TestPressure (bar)";
                _modelGVL.GVL_Graficos.strNomeEixoY2 = string.Empty;
                _modelGVL.GVL_Graficos.strNomeEixoY3 = string.Empty;
                _modelGVL.GVL_Graficos.strNomeEixoY4 = string.Empty;

                _modelGVL.GVL_Graficos.strUnidadeX = "mm";
                _modelGVL.GVL_Graficos.strUnidadeY1 = "bar";
                _modelGVL.GVL_Graficos.strUnidadeY2 = string.Empty;
                _modelGVL.GVL_Graficos.strUnidadeY3 = string.Empty;
                _modelGVL.GVL_Graficos.strUnidadeY4 = string.Empty;

                _modelGVL.GVL_Graficos.bOcultaY2 = false;
                _modelGVL.GVL_Graficos.bOcultaY3 = true;
                _modelGVL.GVL_Graficos.bOcultaY4 = true;

                #endregion

                #region Varriaveis Array Dados

                //os arrays dinamicos obtidos neste teste contem as seguintes grandezas:
                //GVL_Graficos.arrVarX[GVL_Graficos.diBuffer] := rDeslocamentoEntradaBooster_mm_Lin;
                //GVL_Graficos.arrVarY1[GVL_Graficos.diBuffer] := rPressaoBubbleTest_Bar_Lin;
                //GVL_Graficos.arrVarY2[GVL_Graficos.diBuffer] := rForcaEntradaBooster_N_Lin;	

                ClearArrayGVL_Graficos();

                _modelGVL.GVL_Graficos.arrVarTimeStamp = lstDblReturnReadFile[0].ToArray();
                _modelGVL.GVL_Graficos.arrVarX = lstDblReturnReadFile[5].ToArray();
                _modelGVL.GVL_Graficos.arrVarY1 = lstDblReturnReadFile[8].ToArray();
                _modelGVL.GVL_Graficos.arrVarY2 = lstDblReturnReadFile[2].ToArray();

                #endregion

                #region Calculos

                if (_modelGVL.GVL_T19.bCalculaResultados)
                {
                    _modelGVL.GVL_T19 = HelperTestBase.Model_GVL.GVL_T19;

                    //Define o ponto maximo do array que foi plotado durante o teste
                    _modelGVL.GVL_Graficos.diBuffer = lstDblReturnReadFile[0].Count() > 0 ? lstDblReturnReadFile[0].Count() : 0;

                    diUbound = _modelGVL.GVL_Graficos.diBuffer; //Define o ponto maximo do array que foi plotado durante o teste

                    #region Loop para identificar a forca maxima do teste, e armazenar o ponto de inflexao do teste (quando o atuador comeca a retornar)
                    //========================================================================================================================================================

                    for (di = 0; di < diUbound; di++)
                    {
                        if (_modelGVL.GVL_Graficos.arrVarY2[di] > _modelGVL.GVL_T19.rForcaMaxima)
                        {
                            _modelGVL.GVL_T19.rForcaMaxima = _modelGVL.GVL_Graficos.arrVarY2[di]; //Atualiza o valor de forca maxima com o maior valor obtido no array
                            _modelGVL.GVL_T19.diPosicaoForcaMaxima = di; //Indica em qual posicao do array esta a forca maxima (pico do grafico, aonde comeca o retorno do atuador)
                        }
                    }

                    //========================================================================================================================================================
                    #endregion

                    #region Loop para identificar o deslocamento ao atingir a pressao
                    //========================================================================================================================================================

                    for (di = 0; di < diUbound; di++)
                    {
                        if (GVL_Graficos.arrVarY1[di] > _modelGVL.GVL_T19.rDeslocamentoNaPressao_Bar)
                        {
                            _modelGVL.GVL_T19.rDeslocamentoNaPressao_mm = _modelGVL.GVL_Graficos.arrVarX[di]; //Atualiza o valor de forca maxima com o maior valor obtido no array
                        }
                    }
                    #endregion

                    #region Calculo do gradiente de aplicacao de força no avanço
                    //========================================================================================================================================================

                    //Busca no array o momento em que a forca comecou a subir (forca >= 100N) e o tempo decorrido desta forca
                    for (di = 0; di <= _modelGVL.GVL_T19.diPosicaoForcaMaxima; di++)
                    {
                        if (_modelGVL.GVL_Graficos.arrVarY2[di] >= 100)//forca comecou a subir (>=100N)
                        {
                            rForcaInicialGradiente = _modelGVL.GVL_Graficos.arrVarY2[di]; //Valor forca inicial para calculo 
                            rTempoInicialGradiente = _modelGVL.GVL_Graficos.arrVarTimeStamp[di]; //Valor to tempo em ms inicial para calculo

                            break; //Encerra a busca pela forca inicial
                        }
                    }

                    //Define a forca final e o tempo final do gradiente como a FMAX obtida no calculo anterior, utilizando seu indice para coletar o tempo respectivo
                    rForcaFinalGradiente = _modelGVL.GVL_Graficos.arrVarY2[_modelGVL.GVL_T19.diPosicaoForcaMaxima];
                    rTempoFinalGradiente = _modelGVL.GVL_Graficos.arrVarTimeStamp[_modelGVL.GVL_T19.diPosicaoForcaMaxima];

                    //Calcula o gradiente de aplicacao de forca no avanco
                    _modelGVL.GVL_T19.rGradienteForcaAvanco = (rForcaFinalGradiente - rForcaInicialGradiente) / (rTempoFinalGradiente - rTempoInicialGradiente);
                    //========================================================================================================================================================

                    #endregion

                    #region Calculo do gradiente de aplicacao de força no retorno
                    //========================================================================================================================================================

                    //Busca no array o momento em que a forca caiu abaixo de 100N (forca <= 100N) e o tempo decorrido desta forca
                    for (di = _modelGVL.GVL_T19.diPosicaoForcaMaxima; di < diUbound; di++)
                    {
                        if (_modelGVL.GVL_Graficos.arrVarY2[di] <= 100) //Forca proxima de 0 (<=100N)
                        {
                            rForcaFinalGradiente = _modelGVL.GVL_Graficos.arrVarY2[di]; //Valor forca final para calculo 
                            rTempoFinalGradiente = _modelGVL.GVL_Graficos.arrVarTimeStamp[di]; //Valor to tempo em ms final para calculo

                            break; //Encerra a busca pela forca final
                        }
                    }

                    //Define a forca inicial e o tempo inicial do gradiente como a FMAX obtida no calculo anterior, utilizando seu indice para coletar o tempo respectivo
                    rForcaInicialGradiente = _modelGVL.GVL_Graficos.arrVarY2[_modelGVL.GVL_T19.diPosicaoForcaMaxima];
                    rTempoInicialGradiente = _modelGVL.GVL_Graficos.arrVarTimeStamp[_modelGVL.GVL_T19.diPosicaoForcaMaxima];

                    //Calcula o gradiente de aplicacao de forca no retorno
                    _modelGVL.GVL_T19.rGradienteForcaRetorno = (rForcaFinalGradiente - rForcaInicialGradiente) / (rTempoFinalGradiente - rTempoInicialGradiente);
                    //========================================================================================================================================================
                    #endregion

                    #region Calculo do gradiente de avanço 
                    //========================================================================================================================================================

                    //Busca no array o momento em que o deslocamento comecou a variar (deslocamento >= 1)
                    for (di = 0; di <= _modelGVL.GVL_T19.diPosicaoForcaMaxima; di++)
                    {
                        if (_modelGVL.GVL_Graficos.arrVarX[di] >= 1) //Deslocamento >= 1mm
                        {
                            rDeslocamentoInicialGradiente = _modelGVL.GVL_Graficos.arrVarX[di]; //Valor deslocamento inicial para calculo 
                            rTempoInicialGradiente = _modelGVL.GVL_Graficos.arrVarTimeStamp[di]; //Valor to tempo em ms inicial para calculo

                            break; //Encerra a busca pelo deslocamento inicial
                        }
                    }

                    //Define a forca final e o tempo final do gradiente como a FMAX obtida no calculo anterior, utilizando seu indice para coletar o tempo respectivo
                    rDeslocamentoFinalGradiente = _modelGVL.GVL_Graficos.arrVarX[_modelGVL.GVL_T19.diPosicaoForcaMaxima];
                    rTempoFinalGradiente = _modelGVL.GVL_Graficos.arrVarTimeStamp[_modelGVL.GVL_T19.diPosicaoForcaMaxima];

                    //Calcula o gradiente de aplicacao de forca no avanco
                    _modelGVL.GVL_T19.rGradienteDeslocamentoAvanco = (rDeslocamentoFinalGradiente - rDeslocamentoInicialGradiente) / (rTempoFinalGradiente - rTempoInicialGradiente);
                    //========================================================================================================================================================

                    #endregion

                    #region Calculo do gradiente de deslocamento no retorno

                    //========================================================================================================================================================

                    //Busca no array o momento em que o deslocamento <= 1
                    for (di = _modelGVL.GVL_T19.diPosicaoForcaMaxima; di < diUbound; di++)
                    {
                        if (_modelGVL.GVL_Graficos.arrVarX[di] <= 1) //Deslocamento <= 1
                        {
                            rDeslocamentoFinalGradiente = _modelGVL.GVL_Graficos.arrVarX[di]; //Deslocamento final para calculo 
                            rTempoFinalGradiente = _modelGVL.GVL_Graficos.arrVarTimeStamp[di]; //Valor to tempo em ms final para calculo

                            break; //Encerra a busca pelo deslocamento final
                        }
                    }
                    //Define o deslocamento inicial e o tempo inicial do gradiente como a FMAX obtida no calculo anterior, utilizando seu indice para coletar o tempo respectivo
                    rDeslocamentoInicialGradiente = _modelGVL.GVL_Graficos.arrVarX[_modelGVL.GVL_T19.diPosicaoForcaMaxima];
                    rTempoInicialGradiente = _modelGVL.GVL_Graficos.arrVarTimeStamp[_modelGVL.GVL_T19.diPosicaoForcaMaxima];

                    //Calcula o gradiente de aplicacao de forca no retorno
                    _modelGVL.GVL_T19.rGradienteDeslocamentoRetorno = (rDeslocamentoFinalGradiente - rDeslocamentoInicialGradiente) / (rTempoFinalGradiente - rTempoInicialGradiente);
                    //========================================================================================================================================================

                    #endregion

                    _modelGVL.GVL_T19.bCalculaResultados = false;

                    _modelGVL.GVL_Graficos.bDadosCalculados = true;
                }

                HelperTestBase.Model_GVL.helperTestBase_ModelGVL_Test = HelperTestBase.Model_GVL.GVL_T19;

                HelperTestBase.Model_GVL = _modelGVL;

                #endregion

            }
            catch (Exception ex)
            {
                var err = ex.Message;
                throw;
            }

            return _modelGVL;

            #endregion
        }

        #endregion

        #region T20 - Calculos verificacao Sensores - ET_Adjustment_LostTravelACUPneumatic_Secondary
        public Model_GVL CalcGraphT20_ET_Adjustment_LostTravelACUPneumatic_Secondary(bool bCalculaResultados, List<double>[] lstDblReturnReadFile)
        {
            #region PROGRAM T20_Calculos_Resultados

            try
            {
                #region Limpa ultimos resultados

                dictVarList.Clear();

                _modelGVL.GVL_T20.rForcaMaxima = 0; //Zera o ultimo valor de força obtido
                _modelGVL.GVL_T20.diPosicaoForcaMaxima = 0;

                _modelGVL.GVL_T20.rGradienteForcaAvanco = 0; //Zera o ultimo valor obtido
                _modelGVL.GVL_T20.rGradienteForcaRetorno = 0; //Zera o ultimo valor obtido
                _modelGVL.GVL_T20.rGradienteDeslocamentoAvanco = 0; //Zera o ultimo valor obtido
                _modelGVL.GVL_T20.rGradienteDeslocamentoRetorno = 0; //Zera o ultimo valor obtido

                _modelGVL.GVL_T20.rDeslocamentoNaPressao_mm = 0;

                _modelGVL.GVL_T20.bCalculaResultados = bCalculaResultados;

                #region VARIABLES

                long diUbound = 0; //  ; DINT;
                long di = 0; //  ; DINT;
                double rForcaInicialGradiente = 0; //  ; REAL;
                double rForcaFinalGradiente = 0; //  ; REAL;
                double rDeslocamentoInicialGradiente = 0; //   ; REAL;
                double rDeslocamentoFinalGradiente = 0; //  ; REAL;
                double rTempoInicialGradiente = 0; //  ; REAL;
                double rTempoFinalGradiente = 0; //   ; REAL;

                #endregion

                #endregion

                #region Variaveis Grafico

                _modelGVL.GVL_Graficos.rEscalaX = 20;
                _modelGVL.GVL_Graficos.EixoX.wsTLLabel = "AxesChart.1";
                _modelGVL.GVL_Graficos.rEscalaY1 = 1;
                _modelGVL.GVL_Graficos.EixoY1.wsTLLabel = "AxesChart.3";
                _modelGVL.GVL_Graficos.rEscalaY2 = 0;
                _modelGVL.GVL_Graficos.EixoY2.wsTLLabel = string.Empty;
                _modelGVL.GVL_Graficos.rEscalaY3 = 0;
                _modelGVL.GVL_Graficos.EixoY3.wsTLLabel = string.Empty;
                _modelGVL.GVL_Graficos.rEscalaY4 = 0;
                _modelGVL.GVL_Graficos.EixoY4.wsTLLabel = string.Empty;

                _modelGVL.GVL_Graficos.strNomeEixoX = "Input Travel (mm)";
                _modelGVL.GVL_Graficos.strNomeEixoY1 = "TestPressure (bar)";
                _modelGVL.GVL_Graficos.strNomeEixoY2 = string.Empty;
                _modelGVL.GVL_Graficos.strNomeEixoY3 = string.Empty;
                _modelGVL.GVL_Graficos.strNomeEixoY4 = string.Empty;

                _modelGVL.GVL_Graficos.strUnidadeX = "mm";
                _modelGVL.GVL_Graficos.strUnidadeY1 = "bar";
                _modelGVL.GVL_Graficos.strUnidadeY2 = string.Empty;
                _modelGVL.GVL_Graficos.strUnidadeY3 = string.Empty;
                _modelGVL.GVL_Graficos.strUnidadeY4 = string.Empty;

                _modelGVL.GVL_Graficos.bOcultaY2 = false;
                _modelGVL.GVL_Graficos.bOcultaY3 = true;
                _modelGVL.GVL_Graficos.bOcultaY4 = true;

                #endregion

                #region Varriaveis Array Dados

                //os arrays dinamicos obtidos neste teste contem as seguintes grandezas:
                //GVL_Graficos.arrVarX[GVL_Graficos.diBuffer] := rDeslocamentoEntradaBooster_mm_Lin;
                //GVL_Graficos.arrVarY1[GVL_Graficos.diBuffer] := rPressaoBubbleTest_Bar_Lin;
                //GVL_Graficos.arrVarY2[GVL_Graficos.diBuffer] := rForcaEntradaBooster_N_Lin;	

                ClearArrayGVL_Graficos();

                _modelGVL.GVL_Graficos.arrVarTimeStamp = lstDblReturnReadFile[0].ToArray();
                _modelGVL.GVL_Graficos.arrVarX = lstDblReturnReadFile[5].ToArray();
                _modelGVL.GVL_Graficos.arrVarY1 = lstDblReturnReadFile[8].ToArray();
                _modelGVL.GVL_Graficos.arrVarY2 = lstDblReturnReadFile[2].ToArray();

                #endregion

                #region Calculos

                if (_modelGVL.GVL_T20.bCalculaResultados)
                {
                    _modelGVL.GVL_T20 = HelperTestBase.Model_GVL.GVL_T20;

                    //Define o ponto maximo do array que foi plotado durante o teste
                    _modelGVL.GVL_Graficos.diBuffer = lstDblReturnReadFile[0].Count() > 0 ? lstDblReturnReadFile[0].Count() : 0;

                    diUbound = _modelGVL.GVL_Graficos.diBuffer; //Define o ponto maximo do array que foi plotado durante o teste

                    #region Loop para identificar a forca maxima do teste, e armazenar o ponto de inflexao do teste (quando o atuador comeca a retornar)
                    //========================================================================================================================================================

                    for (di = 0; di < diUbound; di++)
                    {
                        if (_modelGVL.GVL_Graficos.arrVarY2[di] > _modelGVL.GVL_T20.rForcaMaxima)
                        {
                            _modelGVL.GVL_T20.rForcaMaxima = _modelGVL.GVL_Graficos.arrVarY2[di]; //Atualiza o valor de forca maxima com o maior valor obtido no array
                            _modelGVL.GVL_T20.diPosicaoForcaMaxima = di; //Indica em qual posicao do array esta a forca maxima (pico do grafico, aonde comeca o retorno do atuador)
                        }
                    }

                    //========================================================================================================================================================
                    #endregion

                    #region Loop para identificar o deslocamento ao atingir a pressao
                    //========================================================================================================================================================

                    for (di = 0; di < diUbound; di++)
                    {
                        if (GVL_Graficos.arrVarY1[di] > _modelGVL.GVL_T20.rDeslocamentoNaPressao_Bar)
                        {
                            _modelGVL.GVL_T20.rDeslocamentoNaPressao_mm = _modelGVL.GVL_Graficos.arrVarX[di]; //Atualiza o valor de forca maxima com o maior valor obtido no array
                        }
                    }
                    #endregion

                    #region Calculo do gradiente de aplicacao de força no avanço
                    //========================================================================================================================================================

                    //Busca no array o momento em que a forca comecou a subir (forca >= 100N) e o tempo decorrido desta forca
                    for (di = 0; di <= _modelGVL.GVL_T20.diPosicaoForcaMaxima; di++)
                    {
                        if (_modelGVL.GVL_Graficos.arrVarY2[di] >= 100)//forca comecou a subir (>=100N)
                        {
                            rForcaInicialGradiente = _modelGVL.GVL_Graficos.arrVarY2[di]; //Valor forca inicial para calculo 
                            rTempoInicialGradiente = _modelGVL.GVL_Graficos.arrVarTimeStamp[di]; //Valor to tempo em ms inicial para calculo

                            break; //Encerra a busca pela forca inicial
                        }
                    }

                    //Define a forca final e o tempo final do gradiente como a FMAX obtida no calculo anterior, utilizando seu indice para coletar o tempo respectivo
                    rForcaFinalGradiente = _modelGVL.GVL_Graficos.arrVarY2[_modelGVL.GVL_T20.diPosicaoForcaMaxima];
                    rTempoFinalGradiente = _modelGVL.GVL_Graficos.arrVarTimeStamp[_modelGVL.GVL_T20.diPosicaoForcaMaxima];

                    //Calcula o gradiente de aplicacao de forca no avanco
                    _modelGVL.GVL_T20.rGradienteForcaAvanco = (rForcaFinalGradiente - rForcaInicialGradiente) / (rTempoFinalGradiente - rTempoInicialGradiente);
                    //========================================================================================================================================================

                    #endregion

                    #region Calculo do gradiente de aplicacao de força no retorno
                    //========================================================================================================================================================

                    //Busca no array o momento em que a forca caiu abaixo de 100N (forca <= 100N) e o tempo decorrido desta forca
                    for (di = _modelGVL.GVL_T20.diPosicaoForcaMaxima; di < diUbound; di++)
                    {
                        if (_modelGVL.GVL_Graficos.arrVarY2[di] <= 100) //Forca proxima de 0 (<=100N)
                        {
                            rForcaFinalGradiente = _modelGVL.GVL_Graficos.arrVarY2[di]; //Valor forca final para calculo 
                            rTempoFinalGradiente = _modelGVL.GVL_Graficos.arrVarTimeStamp[di]; //Valor to tempo em ms final para calculo

                            break; //Encerra a busca pela forca final
                        }
                    }

                    //Define a forca inicial e o tempo inicial do gradiente como a FMAX obtida no calculo anterior, utilizando seu indice para coletar o tempo respectivo
                    rForcaInicialGradiente = _modelGVL.GVL_Graficos.arrVarY2[_modelGVL.GVL_T20.diPosicaoForcaMaxima];
                    rTempoInicialGradiente = _modelGVL.GVL_Graficos.arrVarTimeStamp[_modelGVL.GVL_T20.diPosicaoForcaMaxima];

                    //Calcula o gradiente de aplicacao de forca no retorno
                    _modelGVL.GVL_T20.rGradienteForcaRetorno = (rForcaFinalGradiente - rForcaInicialGradiente) / (rTempoFinalGradiente - rTempoInicialGradiente);
                    //========================================================================================================================================================
                    #endregion

                    #region Calculo do gradiente de avanço 
                    //========================================================================================================================================================

                    //Busca no array o momento em que o deslocamento comecou a variar (deslocamento >= 1)
                    for (di = 0; di <= _modelGVL.GVL_T20.diPosicaoForcaMaxima; di++)
                    {
                        if (_modelGVL.GVL_Graficos.arrVarX[di] >= 1) //Deslocamento >= 1mm
                        {
                            rDeslocamentoInicialGradiente = _modelGVL.GVL_Graficos.arrVarX[di]; //Valor deslocamento inicial para calculo 
                            rTempoInicialGradiente = _modelGVL.GVL_Graficos.arrVarTimeStamp[di]; //Valor to tempo em ms inicial para calculo

                            break; //Encerra a busca pelo deslocamento inicial
                        }
                    }

                    //Define a forca final e o tempo final do gradiente como a FMAX obtida no calculo anterior, utilizando seu indice para coletar o tempo respectivo
                    rDeslocamentoFinalGradiente = _modelGVL.GVL_Graficos.arrVarX[_modelGVL.GVL_T20.diPosicaoForcaMaxima];
                    rTempoFinalGradiente = _modelGVL.GVL_Graficos.arrVarTimeStamp[_modelGVL.GVL_T20.diPosicaoForcaMaxima];

                    //Calcula o gradiente de aplicacao de forca no avanco
                    _modelGVL.GVL_T20.rGradienteDeslocamentoAvanco = (rDeslocamentoFinalGradiente - rDeslocamentoInicialGradiente) / (rTempoFinalGradiente - rTempoInicialGradiente);
                    //========================================================================================================================================================

                    #endregion

                    #region Calculo do gradiente de deslocamento no retorno

                    //========================================================================================================================================================

                    //Busca no array o momento em que o deslocamento <= 1
                    for (di = _modelGVL.GVL_T20.diPosicaoForcaMaxima; di < diUbound; di++)
                    {
                        if (_modelGVL.GVL_Graficos.arrVarX[di] <= 1) //Deslocamento <= 1
                        {
                            rDeslocamentoFinalGradiente = _modelGVL.GVL_Graficos.arrVarX[di]; //Deslocamento final para calculo 
                            rTempoFinalGradiente = _modelGVL.GVL_Graficos.arrVarTimeStamp[di]; //Valor to tempo em ms final para calculo

                            break; //Encerra a busca pelo deslocamento final
                        }
                    }
                    //Define o deslocamento inicial e o tempo inicial do gradiente como a FMAX obtida no calculo anterior, utilizando seu indice para coletar o tempo respectivo
                    rDeslocamentoInicialGradiente = _modelGVL.GVL_Graficos.arrVarX[_modelGVL.GVL_T20.diPosicaoForcaMaxima];
                    rTempoInicialGradiente = _modelGVL.GVL_Graficos.arrVarTimeStamp[_modelGVL.GVL_T20.diPosicaoForcaMaxima];

                    //Calcula o gradiente de aplicacao de forca no retorno
                    _modelGVL.GVL_T20.rGradienteDeslocamentoRetorno = (rDeslocamentoFinalGradiente - rDeslocamentoInicialGradiente) / (rTempoFinalGradiente - rTempoInicialGradiente);
                    //========================================================================================================================================================

                    #endregion


                    _modelGVL.GVL_T20.bCalculaResultados = false;

                    _modelGVL.GVL_Graficos.bDadosCalculados = true;
                }

                HelperTestBase.Model_GVL.helperTestBase_ModelGVL_Test = HelperTestBase.Model_GVL.GVL_T20;

                HelperTestBase.Model_GVL = _modelGVL;

                #endregion

            }
            catch (Exception ex)
            {
                var err = ex.Message;
                throw;
            }

            return _modelGVL;

            #endregion
        }

        #endregion

        #region T21 - Calculos Ajuste - ET_Adjustiment_PedalFellingCharacteristics

        public Model_GVL CalcGraphT21_ET_Adjustment_PedalFellingCharacteristics(bool bCalculaResultados, List<double>[] lstDblReturnReadFile)
        {
            #region PROGRAM T21_Calculos_Resultados

            try
            {
                #region Limpa ultimos resultados

                dictVarList.Clear();

                _modelGVL.GVL_T21.rForcaMaxima = 0; //Zera o ultimo valor de força obtido
                _modelGVL.GVL_T21.rGradienteForcaAvanco = 0; //Zera o ultimo valor obtido
                _modelGVL.GVL_T21.rGradienteForcaRetorno = 0; //Zera o ultimo valor obtido
                _modelGVL.GVL_T21.rGradienteDeslocamentoAvanco = 0; //Zera o ultimo valor obtido
                _modelGVL.GVL_T21.rGradienteDeslocamentoRetorno = 0; //Zera o ultimo valor obtido
                _modelGVL.GVL_T21.rDeslocamentoNoJumper_mm = 0;
                _modelGVL.GVL_T21.rForcaCutIn_N = 0;
                _modelGVL.GVL_T21.rPressaoJumper_Bar = 0;
                _modelGVL.GVL_T21.iConsumidoresCP = 0;
                _modelGVL.GVL_T21.iConsumidoresCS = 0;

                _modelGVL.GVL_T21.rRunOutForce_Real_N = 0;
                _modelGVL.GVL_T21.rRunOutPressure_Real_Bar = 0;

                _modelGVL.GVL_T21.bCalculaResultados = bCalculaResultados;

                #region VARIABLES

                long diUbound = 0; //  ; DINT;
                long di = 0; //  ; DINT;
                double rForcaInicialGradiente = 0; //  ; REAL;
                double rForcaFinalGradiente = 0; //  ; REAL;
                double rDeslocamentoInicialGradiente = 0; //   ; REAL;
                double rDeslocamentoFinalGradiente = 0; //  ; REAL;
                double rTempoInicialGradiente = 0; //  ; REAL;
                double rTempoFinalGradiente = 0; //   ; REAL;

                #endregion

                #endregion

                #region Variaveis Grafico

                _modelGVL.GVL_Graficos.rEscalaX = 50;
                _modelGVL.GVL_Graficos.EixoX.wsTLLabel = "AxesChart.1";
                _modelGVL.GVL_Graficos.rEscalaY1 = 150;
                _modelGVL.GVL_Graficos.EixoY1.wsTLLabel = "AxesChart.3";
                _modelGVL.GVL_Graficos.rEscalaY2 = 1500;
                _modelGVL.GVL_Graficos.EixoY2.wsTLLabel = "AxesChart.4";
                _modelGVL.GVL_Graficos.rEscalaY3 = 0;
                _modelGVL.GVL_Graficos.EixoY3.wsTLLabel = string.Empty;
                _modelGVL.GVL_Graficos.rEscalaY4 = 0;
                _modelGVL.GVL_Graficos.EixoY4.wsTLLabel = string.Empty;

                _modelGVL.GVL_Graficos.strNomeEixoX = "Input Travel (mm)";
                _modelGVL.GVL_Graficos.strNomeEixoY1 = "Pressure PC (bar)";
                _modelGVL.GVL_Graficos.strNomeEixoY2 = "Input Force (N)";
                _modelGVL.GVL_Graficos.strNomeEixoY3 = string.Empty;
                _modelGVL.GVL_Graficos.strNomeEixoY4 = string.Empty;

                _modelGVL.GVL_Graficos.strUnidadeX = "mm";
                _modelGVL.GVL_Graficos.strUnidadeY1 = "bar";
                _modelGVL.GVL_Graficos.strUnidadeY2 = "N";
                _modelGVL.GVL_Graficos.strUnidadeY3 = string.Empty;
                _modelGVL.GVL_Graficos.strUnidadeY4 = string.Empty;

                _modelGVL.GVL_Graficos.bOcultaY2 = false;
                _modelGVL.GVL_Graficos.bOcultaY3 = true;
                _modelGVL.GVL_Graficos.bOcultaY4 = true;

                #endregion

                #region Varriaveis Array Dados

                //os arrays dinamicos obtidos neste teste contem as seguintes grandezas:
                //GVL_Graficos.arrVarX[GVL_Graficos.diBuffer] := rDeslocamentoEntradaBooster_mm_Lin;
                //GVL_Graficos.arrVarY1[GVL_Graficos.diBuffer] := rPressaoCP_Bar_Lin;
                //GVL_Graficos.arrVarY2[GVL_Graficos.diBuffer] := rForcaEntradaBooster_N_Lin;

                ClearArrayGVL_Graficos();

                _modelGVL.GVL_Graficos.arrVarTimeStamp = lstDblReturnReadFile[0].ToArray();
                _modelGVL.GVL_Graficos.arrVarX = lstDblReturnReadFile[5].ToArray();
                _modelGVL.GVL_Graficos.arrVarY1 = lstDblReturnReadFile[7].ToArray();
                _modelGVL.GVL_Graficos.arrVarY2 = lstDblReturnReadFile[2].ToArray();

                #endregion

                #region Calculos

                if (_modelGVL.GVL_T21.bCalculaResultados)
                {
                    _modelGVL.GVL_T21 = HelperTestBase.Model_GVL.GVL_T21;

                    //Define o ponto maximo do array que foi plotado durante o teste
                    _modelGVL.GVL_Graficos.diBuffer = lstDblReturnReadFile[0].Count() > 0 ? lstDblReturnReadFile[0].Count() : 0;

                    diUbound = _modelGVL.GVL_Graficos.diBuffer; //Define o ponto maximo do array que foi plotado durante o teste

                    #region Loop para identificar a forca maxima do teste, e armazenar o ponto de inflexao do teste (quando o atuador comeca a retornar)
                    //========================================================================================================================================================

                    for (di = 0; di < diUbound; di++)
                    {
                        if (_modelGVL.GVL_Graficos.arrVarY2[di] > _modelGVL.GVL_T21.rForcaMaxima)
                        {
                            _modelGVL.GVL_T21.rForcaMaxima = _modelGVL.GVL_Graficos.arrVarY2[di]; //Atualiza o valor de forca maxima com o maior valor obtido no array
                            _modelGVL.GVL_T21.diPosicaoForcaMaxima = di; //Indica em qual posicao do array esta a forca maxima (pico do grafico, aonde comeca o retorno do atuador)
                        }
                    }

                    //========================================================================================================================================================
                    #endregion

                    #region Calculo do gradiente de aplicacao de força no avanço
                    //========================================================================================================================================================

                    //Busca no array o momento em que a forca comecou a subir (forca >= 100N) e o tempo decorrido desta forca
                    for (di = 0; di <= _modelGVL.GVL_T21.diPosicaoForcaMaxima; di++)
                    {
                        if (_modelGVL.GVL_Graficos.arrVarY2[di] >= 100)//forca comecou a subir (>=100N)
                        {
                            rForcaInicialGradiente = _modelGVL.GVL_Graficos.arrVarY2[di]; //Valor forca inicial para calculo 
                            rTempoInicialGradiente = _modelGVL.GVL_Graficos.arrVarTimeStamp[di]; //Valor to tempo em ms inicial para calculo

                            break; //Encerra a busca pela forca inicial
                        }
                    }

                    //Define a forca final e o tempo final do gradiente como a FMAX obtida no calculo anterior, utilizando seu indice para coletar o tempo respectivo
                    rForcaFinalGradiente = _modelGVL.GVL_Graficos.arrVarY2[_modelGVL.GVL_T21.diPosicaoForcaMaxima];
                    rTempoFinalGradiente = _modelGVL.GVL_Graficos.arrVarTimeStamp[_modelGVL.GVL_T21.diPosicaoForcaMaxima];

                    //Calcula o gradiente de aplicacao de forca no avanco
                    _modelGVL.GVL_T21.rGradienteForcaAvanco = (rForcaFinalGradiente - rForcaInicialGradiente) / (rTempoFinalGradiente - rTempoInicialGradiente);
                    //========================================================================================================================================================

                    #endregion

                    #region Calculo do gradiente de aplicacao de força no retorno
                    //========================================================================================================================================================

                    //Busca no array o momento em que a forca caiu abaixo de 100N (forca <= 100N) e o tempo decorrido desta forca
                    for (di = _modelGVL.GVL_T21.diPosicaoForcaMaxima; di < diUbound; di++)
                    {
                        if (_modelGVL.GVL_Graficos.arrVarY2[di] <= 100) //Forca proxima de 0 (<=100N)
                        {
                            rForcaFinalGradiente = _modelGVL.GVL_Graficos.arrVarY2[di]; //Valor forca final para calculo 
                            rTempoFinalGradiente = _modelGVL.GVL_Graficos.arrVarTimeStamp[di]; //Valor to tempo em ms final para calculo

                            break; //Encerra a busca pela forca final
                        }
                    }

                    //Define a forca inicial e o tempo inicial do gradiente como a FMAX obtida no calculo anterior, utilizando seu indice para coletar o tempo respectivo
                    rForcaInicialGradiente = _modelGVL.GVL_Graficos.arrVarY2[_modelGVL.GVL_T21.diPosicaoForcaMaxima];
                    rTempoInicialGradiente = _modelGVL.GVL_Graficos.arrVarTimeStamp[_modelGVL.GVL_T21.diPosicaoForcaMaxima];

                    //Calcula o gradiente de aplicacao de forca no retorno
                    _modelGVL.GVL_T21.rGradienteForcaRetorno = (rForcaFinalGradiente - rForcaInicialGradiente) / (rTempoFinalGradiente - rTempoInicialGradiente);
                    //========================================================================================================================================================
                    #endregion

                    #region Calculo do gradiente de avanço 
                    //========================================================================================================================================================

                    //Busca no array o momento em que o deslocamento comecou a variar (deslocamento >= 1)
                    for (di = 0; di <= _modelGVL.GVL_T21.diPosicaoForcaMaxima; di++)
                    {
                        if (_modelGVL.GVL_Graficos.arrVarX[di] >= 1) //Deslocamento >= 1mm
                        {
                            rDeslocamentoInicialGradiente = _modelGVL.GVL_Graficos.arrVarX[di]; //Valor deslocamento inicial para calculo 
                            rTempoInicialGradiente = _modelGVL.GVL_Graficos.arrVarTimeStamp[di]; //Valor to tempo em ms inicial para calculo

                            break; //Encerra a busca pelo deslocamento inicial
                        }
                    }

                    //Define a forca final e o tempo final do gradiente como a FMAX obtida no calculo anterior, utilizando seu indice para coletar o tempo respectivo
                    rDeslocamentoFinalGradiente = _modelGVL.GVL_Graficos.arrVarX[_modelGVL.GVL_T21.diPosicaoForcaMaxima];
                    rTempoFinalGradiente = _modelGVL.GVL_Graficos.arrVarTimeStamp[_modelGVL.GVL_T21.diPosicaoForcaMaxima];

                    //Calcula o gradiente de aplicacao de forca no avanco
                    _modelGVL.GVL_T21.rGradienteDeslocamentoAvanco = (rDeslocamentoFinalGradiente - rDeslocamentoInicialGradiente) / (rTempoFinalGradiente - rTempoInicialGradiente);
                    //========================================================================================================================================================

                    #endregion

                    #region Calculo do gradiente de deslocamento no retorno

                    //========================================================================================================================================================

                    //Busca no array o momento em que o deslocamento <= 1
                    for (di = _modelGVL.GVL_T21.diPosicaoForcaMaxima; di < diUbound; di++)
                    {
                        if (_modelGVL.GVL_Graficos.arrVarX[di] <= 1) //Deslocamento <= 1
                        {
                            rDeslocamentoFinalGradiente = _modelGVL.GVL_Graficos.arrVarX[di]; //Deslocamento final para calculo 
                            rTempoFinalGradiente = _modelGVL.GVL_Graficos.arrVarTimeStamp[di]; //Valor to tempo em ms final para calculo

                            break; //Encerra a busca pelo deslocamento final
                        }
                    }


                    //Define o deslocamento inicial e o tempo inicial do gradiente como a FMAX obtida no calculo anterior, utilizando seu indice para coletar o tempo respectivo
                    rDeslocamentoInicialGradiente = _modelGVL.GVL_Graficos.arrVarX[_modelGVL.GVL_T21.diPosicaoForcaMaxima];
                    rTempoInicialGradiente = _modelGVL.GVL_Graficos.arrVarTimeStamp[_modelGVL.GVL_T21.diPosicaoForcaMaxima];

                    //Calcula o gradiente de aplicacao de forca no retorno
                    _modelGVL.GVL_T21.rGradienteDeslocamentoRetorno = (rDeslocamentoFinalGradiente - rDeslocamentoInicialGradiente) / (rTempoFinalGradiente - rTempoInicialGradiente);
                    //========================================================================================================================================================

                    #endregion

                    #region Recebe runoutpoint de T01

                    //========================================================================================================================================================
                    //Recebe Runout Pressure e Force de T01

                    _modelGVL.GVL_T21.rRunOutForce_Real_N = _modelGVL.GVL_T01.rRunOutForce_Real_N == 0 ? HelperTestBase.Model_GVL.GVL_T01.temp_rRunOutForce_Real_N : _modelGVL.GVL_T01.rRunOutForce_Real_N;
                    _modelGVL.GVL_T21.rRunOutPressure_Real_Bar = _modelGVL.GVL_T01.rRunOutPressure_Real_Bar == 0 ? HelperTestBase.Model_GVL.GVL_T01.temp_rRunOutPressure_Real_Bar : _modelGVL.GVL_T01.rRunOutPressure_Real_Bar;


                    #endregion

                    #region Calcula a forca Cut IN

                    //========================================================================================================================================================

                    for (di = 0; di <= _modelGVL.GVL_T21.diPosicaoForcaMaxima; di++)
                    {
                        if (_modelGVL.GVL_Graficos.arrVarY1[di] >= 0.2)  //Pressao de cut in esta como 0.2, pois é o padrao da norma e não existe campo para digitar este valor.
                        {
                            _modelGVL.GVL_T21.rForcaCutIn_N = _modelGVL.GVL_Graficos.arrVarY2[di]; //Valor da pressao real obtida no grafico valida para 90 runout 

                            break; //Encerra a busca
                        }
                    }

                    //========================================================================================================================================================

                    #endregion

                    #region Calcula a forca a 90%pout

                    //========================================================================================================================================================
                    //tambem salva o deslocamento a 90% do runout, aproveitando o loop de busca
                    _modelGVL.GVL_T21.rPressao_90pout_bar = _modelGVL.GVL_T21.rRunOutPressure_Real_Bar * 0.9; //Calcula a pressao teorica 90%pout

                    for (di = 0; di <= _modelGVL.GVL_T21.diPosicaoForcaMaxima; di++)
                    {
                        if (_modelGVL.GVL_Graficos.arrVarY1[di] >= _modelGVL.GVL_T21.rPressao_90pout_bar)  //Pressao no array >= Pressao RUnout * 0.9
                        {
                            _modelGVL.GVL_T21.rForca_90pout_N = _modelGVL.GVL_Graficos.arrVarY2[di]; //Valor da Forca relacionada a pressao 90% pout
                            _modelGVL.GVL_T21.rForca_F6_N = _modelGVL.GVL_Graficos.arrVarY2[di]; //Valor da Forca relacionada a pressao 90% pout
                            _modelGVL.GVL_T21.rPressao_P6_Bar = _modelGVL.GVL_Graficos.arrVarY1[di];
                            break; //Encerra a busca
                        }
                    }

                    //========================================================================================================================================================
                    #endregion

                    #region Calculo do Jumper

                    //========================================================================================================================================================
                    //Formula na norma - Pjumper = P5 + (Fcutin - Fe200)*((P6-P5)/(F6-FE200))
                    //P6 = pressao runout * 0.9, obtido anteriormente
                    //F6 = Forca correspondente a P6, obtido anteriormente
                    //FE200 = 200N, esta na norma, so muda se for especificado "The point P5 is calculated with an input force of FE200 = 200N, unless otherwise specified"
                    //FAN=Fcutin

                    //Encontra a pressao P5, que corresponde na tabela de dados a forca = 200N

                    for (di = 0; di <= _modelGVL.GVL_T21.diPosicaoForcaMaxima; di++)
                    {
                        if (_modelGVL.GVL_Graficos.arrVarY2[di] >= 200) //Forca 200N para calculo pressao de cut in.
                        {
                            _modelGVL.GVL_T21.rPressao_P5_Bar = _modelGVL.GVL_Graficos.arrVarY1[di]; //Valor da pressao correspondente a uma forca 200N

                            break; //Encerra a busca
                        }
                    }

                    _modelGVL.GVL_T21.rPressaoJumper_Bar = _modelGVL.GVL_T21.rPressao_P5_Bar + (_modelGVL.GVL_T21.rForcaCutIn_N - 200) *
                                                            ((_modelGVL.GVL_T21.rPressao_P6_Bar - _modelGVL.GVL_T21.rPressao_P5_Bar) / (_modelGVL.GVL_T21.rForca_F6_N - 200));

                    #endregion

                    #region Calculo do Deslocamento e Forca no Jumper


                    //Encontra o deslocamento no jumper
                    for (di = 0; di <= _modelGVL.GVL_T21.diPosicaoForcaMaxima; di++)
                    {
                        if (_modelGVL.GVL_Graficos.arrVarY1[di] >= _modelGVL.GVL_T21.rPressaoJumper_Bar) //Pressao de jumper
                        {
                            _modelGVL.GVL_T21.rForcaNoJumper_N = _modelGVL.GVL_Graficos.arrVarY2[di]; //Forca no jumper
                            _modelGVL.GVL_T21.rDeslocamentoNoJumper_mm = _modelGVL.GVL_Graficos.arrVarX[di]; //Deslocamento no jumper
                        break; //Encerra a busca
                        }
                    }

                    #endregion

                    #region Calculo do Deslocamento e Forca na Pressao (Parametro)

                    for (di = 0; di <= _modelGVL.GVL_T21.diPosicaoForcaMaxima; di++)
                    {
                        if (_modelGVL.GVL_Graficos.arrVarY1[di] >= _modelGVL.GVL_T21.rPressaoTeste_Bar)
                        {
                            _modelGVL.GVL_T21.rForcaNaPressao_N = _modelGVL.GVL_Graficos.arrVarY2[di];
                            _modelGVL.GVL_T21.rDeslocamentoNaPressao_mm = _modelGVL.GVL_Graficos.arrVarX[di];
                            break; //Encerra a busca
                        }
                    }

                    #endregion

                    #region Calculo dos Consumidores Utilizados

                    //========================================================================================================================================================

                    _modelGVL.GVL_T21.iConsumidoresCP = 0;
                    _modelGVL.GVL_T21.iConsumidoresCS = 0;

                    HelperTestBase.Model_GVL.GVL_Parametros.iTipoConsumidores = HelperMODBUS.CS_wTipoConsumidores;

                    if (HelperMODBUS.CS_wTipoConsumidores != 2)
                    {
                        _modelGVL.GVL_T21.iConsumidoresCP = 0;
                        _modelGVL.GVL_T21.iConsumidoresCS = 0;
                    }
                    else
                    {
                        //HelperMODBUS.CS_wStatusLiga17MangueirasCS 
                        if (HelperMODBUS.CS_wStatusLiga1MangueiraCP)
                            _modelGVL.GVL_T21.iConsumidoresCP = _modelGVL.GVL_T21.iConsumidoresCP + 1;

                        if (HelperMODBUS.CS_wStatusLiga2MangueirasCP)
                            _modelGVL.GVL_T21.iConsumidoresCP = _modelGVL.GVL_T21.iConsumidoresCP + 2;

                        if (HelperMODBUS.CS_wStatusLiga4MangueirasCP)
                            _modelGVL.GVL_T21.iConsumidoresCP = _modelGVL.GVL_T21.iConsumidoresCP + 4;

                        if (HelperMODBUS.CS_wStatusLiga8MangueirasCP)
                            _modelGVL.GVL_T21.iConsumidoresCP = _modelGVL.GVL_T21.iConsumidoresCP + 8;

                        if (HelperMODBUS.CS_wStatusLiga10MangueirasCP)
                            _modelGVL.GVL_T21.iConsumidoresCP = _modelGVL.GVL_T21.iConsumidoresCP + 10;

                        if (HelperMODBUS.CS_wStatusLiga17MangueirasCP)
                            _modelGVL.GVL_T21.iConsumidoresCP = _modelGVL.GVL_T21.iConsumidoresCP + 17;

                        if (HelperMODBUS.CS_wStatusLiga1MangueiraCS)
                            _modelGVL.GVL_T21.iConsumidoresCS = _modelGVL.GVL_T21.iConsumidoresCS + 1;

                        if (HelperMODBUS.CS_wStatusLiga2MangueirasCS)
                            _modelGVL.GVL_T21.iConsumidoresCS = _modelGVL.GVL_T21.iConsumidoresCS + 2;

                        if (HelperMODBUS.CS_wStatusLiga4MangueirasCS)
                            _modelGVL.GVL_T21.iConsumidoresCS = _modelGVL.GVL_T21.iConsumidoresCS + 4;

                        if (HelperMODBUS.CS_wStatusLiga8MangueirasCS)
                            _modelGVL.GVL_T21.iConsumidoresCS = _modelGVL.GVL_T21.iConsumidoresCS + 8;

                        if (HelperMODBUS.CS_wStatusLiga10MangueirasCS)
                            _modelGVL.GVL_T21.iConsumidoresCS = _modelGVL.GVL_T21.iConsumidoresCS + 10;

                        if (HelperMODBUS.CS_wStatusLiga17MangueirasCS)
                            _modelGVL.GVL_T21.iConsumidoresCS = _modelGVL.GVL_T21.iConsumidoresCS + 17;
                    }
                    //============================. ============================================================================================================================

                    #endregion

                    _modelGVL.GVL_T21.bCalculaResultados = false;

                    _modelGVL.GVL_Graficos.bDadosCalculados = true;
                }

                HelperTestBase.Model_GVL.helperTestBase_ModelGVL_Test = HelperTestBase.Model_GVL.GVL_T21;

                HelperTestBase.Model_GVL = _modelGVL;

                #endregion

            }
            catch (Exception ex)
            {
                var err = ex.Message;
                throw;
            }

            return _modelGVL;

            #endregion
        }

        #endregion

        #region T22 - Calculos Atuacao - ET_ActuationRelease_MechanicalActuation
        public Model_GVL CalcGraphT22_ET_ActuationRelease_MechanicalActuation(bool bCalculaResultados, List<double>[] lstDblReturnReadFile)
        {
            #region PROGRAM T22_Calculos_Resultados

            try
            {
                #region Limpa ultimos resultados

                dictVarList.Clear();

                _modelGVL.GVL_T22.rVacuoInicial = 0;
                _modelGVL.GVL_T22.rTemperaturaInicial = 0;
                _modelGVL.GVL_T22.iConsumidoresCP = 0;
                _modelGVL.GVL_T22.iConsumidoresCS = 0;
                _modelGVL.GVL_T22.diPosicaoForcaMaxima = 0; //indice do array que indica o pico de forca, tambem indica que o gráfico começou a "voltar" a partir daqui
                _modelGVL.GVL_T22.rForcaMaxima = 0; //Zera o ultimo valor de força obtido
                _modelGVL.GVL_T22.diPosicaoPressaoMaxima = 0;
                _modelGVL.GVL_T22.rPressaoEmForcaMaxima_Bar = 0;
                _modelGVL.GVL_T22.rDeslocamentoMaximo = 0;
                _modelGVL.GVL_T22.rGradienteForcaAvanco = 0; //Zera o ultimo valor obtido
                _modelGVL.GVL_T22.rGradienteDeslocamentoAvanco = 0; //Zera o ultimo valor obtido
                _modelGVL.GVL_T22.rGradienteForcaRetorno = 0; //Zera o ultimo valor obtido
                _modelGVL.GVL_T22.rGradienteDeslocamentoRetorno = 0; //Zera o ultimo valor obtido

                _modelGVL.GVL_T22.rTempoAtuacao_s = 0; //tempo total atuacao, baseado nos parametros definidos
                _modelGVL.GVL_T22.rTempoRetorno_s = 0; //tempo total retorno baseado nos parametros definidos

                _modelGVL.GVL_T22.rDiferencaPressaoPCSC_bar = 0; //Diferenca de pressao entre Camara Primaria e Camara Secundaria

                _modelGVL.GVL_T22.rRunOutForceRef = 0; //RunoutForce obtido no teste T01
                _modelGVL.GVL_T22.rRunOutPressureRef = 0; //RunoutForce obtido no teste T01
                _modelGVL.GVL_T22.rPressaoAuxiliarRef = 0; //RunoutForce obtido no teste T01

                _modelGVL.GVL_T22.rDeslocamentoNaPressao_mm = 0; //Deslocamento obtido atraves do parametro "DeslocamentoNaPressao (%Pout)

                _modelGVL.GVL_T22.rGradientePressao = 0; //Gradiente de pressao

                _modelGVL.GVL_T22.bCalculaResultados = bCalculaResultados;

                #region VARIABLES

                long diUbound = 0; //  ; DINT;
                long di = 0; //  ; DINT;
                double rForcaInicialGradiente = 0; //  ; REAL;
                double rForcaFinalGradiente = 0; //  ; REAL;
                double rDeslocamentoInicialGradiente = 0; //   ; REAL;
                double rDeslocamentoFinalGradiente = 0; //  ; REAL;
                double rTempoInicialGradiente = 0; //  ; REAL;
                double rTempoFinalGradiente = 0; //   ; REAL;

                diUbound = _modelGVL.GVL_Graficos.diBuffer; //Define o ponto maximo do array que foi plotado durante o teste

                #endregion

                #endregion

                #region Variaveis Grafico

                _modelGVL.GVL_Graficos.rEscalaX = 1500;
                _modelGVL.GVL_Graficos.EixoX.wsTLLabel = "AxesChart.1";
                _modelGVL.GVL_Graficos.rEscalaY1 = 150;
                _modelGVL.GVL_Graficos.EixoY1.wsTLLabel = "AxesChart.3";
                _modelGVL.GVL_Graficos.rEscalaY2 = 150;
                _modelGVL.GVL_Graficos.EixoY2.wsTLLabel = "AxesChart.4";
                _modelGVL.GVL_Graficos.rEscalaY3 = 0;
                _modelGVL.GVL_Graficos.EixoY3.wsTLLabel = string.Empty;
                _modelGVL.GVL_Graficos.rEscalaY4 = 0;
                _modelGVL.GVL_Graficos.EixoY4.wsTLLabel = string.Empty;

                _modelGVL.GVL_Graficos.strNomeEixoX = "Input Force (N)";
                _modelGVL.GVL_Graficos.strNomeEixoY1 = "Pressure PC (bar)";
                _modelGVL.GVL_Graficos.strNomeEixoY2 = "Pressure SC (bar)";
                _modelGVL.GVL_Graficos.strNomeEixoY3 = string.Empty;
                _modelGVL.GVL_Graficos.strNomeEixoY4 = string.Empty;

                _modelGVL.GVL_Graficos.strUnidadeX = "N";
                _modelGVL.GVL_Graficos.strUnidadeY1 = "bar";
                _modelGVL.GVL_Graficos.strUnidadeY2 = "bar";
                _modelGVL.GVL_Graficos.strUnidadeY3 = string.Empty;
                _modelGVL.GVL_Graficos.strUnidadeY4 = string.Empty;

                _modelGVL.GVL_Graficos.bOcultaY2 = false;
                _modelGVL.GVL_Graficos.bOcultaY3 = true;
                _modelGVL.GVL_Graficos.bOcultaY4 = true;

                //Marcacoes Grafico
                int pointArr = 0;
                int pointPos = 0;
                string pointName = string.Empty;

                #endregion

                #region Varriaveis Array Dados

                //os arrays dinamicos obtidos neste teste contem as seguintes grandezas:
                //GVL_Graficos.arrVarX[GVL_Graficos.diBuffer] := TIME_TO_REAL(etTempoCiclo)/1000;
                //GVL_Graficos.arrVarY1[GVL_Graficos.diBuffer] := rForcaEntradaBooster_N_Lin;
                //GVL_Graficos.arrVarY2[GVL_Graficos.diBuffer] := rPressaoCP_Bar_Lin;
                //GVL_Graficos.arrVarY3[GVL_Graficos.diBuffer] := rDeslocamentoEntradaBooster_mm_Lin;
                //GVL_Graficos.arrVarY4[GVL_Graficos.diBuffer] := rPressaoCS_Bar_Lin;

                ClearArrayGVL_Graficos();

                _modelGVL.GVL_Graficos.arrVarTimeStamp = lstDblReturnReadFile[0].ToArray();
                _modelGVL.GVL_Graficos.arrVarX = lstDblReturnReadFile[2].ToArray();
                _modelGVL.GVL_Graficos.arrVarY1 = lstDblReturnReadFile[7].ToArray();
                _modelGVL.GVL_Graficos.arrVarY2 = lstDblReturnReadFile[6].ToArray();
                _modelGVL.GVL_Graficos.arrVarY3 = lstDblReturnReadFile[5].ToArray();

                #endregion

                #region Obtem valores de referencia de T01

                _modelGVL.GVL_T22.rRunOutForceRef = _modelGVL.GVL_T01.rRunOutForce_Real_N;
                _modelGVL.GVL_T22.rRunOutPressureRef = _modelGVL.GVL_T01.rRunOutPressure_Real_Bar;
                _modelGVL.GVL_T22.rPressaoAuxiliarRef = _modelGVL.GVL_T01.rPressaoAuxiliar_P3_Bar;

                #endregion

                #region Calculos 

                if (_modelGVL.GVL_T22.bCalculaResultados)
                {
                    _modelGVL.GVL_T22 = HelperTestBase.Model_GVL.GVL_T22;

                    //Define o ponto maximo do array que foi plotado durante o teste
                    _modelGVL.GVL_Graficos.diBuffer = lstDblReturnReadFile[0].Count() > 0 ? lstDblReturnReadFile[0].Count() : 0;

                    diUbound = _modelGVL.GVL_Graficos.diBuffer - 1;

                    #region Loop para identificar a forca maxima do teste, e armazenar o ponto de inflexao do teste (quando o atuador comeca a retornar)
                    //========================================================================================================================================================

                    var lstInputForce1 = lstDblReturnReadFile[2];

                    _modelGVL.GVL_T22.rForcaMaxima = lstInputForce1.Max(); //1243.34

                    _modelGVL.GVL_T22.diPosicaoForcaMaxima = lstInputForce1.IndexOf(_modelGVL.GVL_T22.rForcaMaxima); //34272 //Indica em qual posicao do array esta a forca maxima (pico do grafico, aonde comeca o retorno do atuador)

                    HelperTestBase.MaxForce = _modelGVL.GVL_T22.rForcaMaxima; //Atualiza o valor de forca maxima com o maior valor obtido no array

                    //========================================================================================================================================================

                    #endregion

                    #region Loop para identificar o deslocamento maximo

                    //========================================================================================================================================================

                    //FOR di:= 0 TO diUbound DO
                    //    IF GVL_Graficos.arrVarY3[di] > GVL_T22.rDeslocamentoMaximo THEN
                    //        GVL_T22.rDeslocamentoMaximo := GVL_Graficos.arrVarY3[di];//Atualiza o valor de deslocamento maximo			
                    //    END_IF
                    //END_FOR

                    //========================================================================================================================================================

                    #endregion

                    #region Loop para identificar a pressao em Fmax (parametro de forca maxima)

                    //========================================================================================================================================================

                    //FOR di := 0 TO diUbound DO
                    //    IF GVL_Graficos.arrVarY1[di] > GVL_T22.rForcaMaximaAtuacao THEN //Busca a pressao na forca maxima de atuacao definida

                    //        GVL_T22.rPressaoEmForcaMaxima_Bar := GVL_Graficos.arrVarY2[di]; //Atualiza o valor de pressao Maxima quando Fmax = Fparametro
                    //        GVL_T22.diPosicaoPressaoMaxima := di; //Indica de pressao maxima onde F = FmaxAtuacao
                    //    END_IF
                    //END_FOR

                    //========================================================================================================================================================
                    #endregion

                    #region Calculo do gradiente de aplicacao de força no avanço

                    //========================================================================================================================================================

                    //Busca no array o momento em que a forca comecou a subir (forca >= 100N) e o tempo decorrido desta forca
                    //FOR di := 0 TO GVL_T22.diPosicaoPressaoMaxima DO
                    //    IF GVL_Graficos.arrVarY1[di] >= 100 THEN //Forca >= 100
                    //        rForcaInicialGradiente := GVL_Graficos.arrVarY1[di]; //Valor forca inicial para calculo 
                    //        rTempoInicialGradiente:= GVL_Graficos.arrVarTimeStamp[di]; //Valor to tempo em ms inicial para calculo
                    //        EXIT; //Encerra a busca pela forca inicial
                    //    END_IF
                    //END_FOR

                    ////Define a forca final e o tempo final do gradiente como a PMAX obtida no calculo anterior, utilizando seu indice para coletar o tempo respectivo
                    //rForcaFinalGradiente:= GVL_Graficos.arrVarY1[GVL_T22.diPosicaoPressaoMaxima];
                    //rTempoFinalGradiente:= GVL_Graficos.arrVarTimeStamp[GVL_T22.diPosicaoPressaoMaxima];

                    ////Calcula o gradiente de aplicacao de forca no avanco
                    //GVL_T22.rGradienteForcaAvanco := (rForcaFinalGradiente - rForcaInicialGradiente) / (rTempoFinalGradiente - rTempoInicialGradiente);

                    //========================================================================================================================================================

                    #endregion

                    #region Calculo do gradiente de aplicacao de força no retorno

                    //========================================================================================================================================================

                    ////Busca no array o momento em que a forca caiu abaixo de 100N (forca <= 100N) e o tempo decorrido desta forca
                    //FOR di := GVL_T22.diPosicaoForcaMaxima TO diUbound DO
                    //    IF GVL_Graficos.arrVarY1[di] <= GVL_T22.rRunOutForceRef THEN //Forca <= RunoutForce
                    //        rForcaInicialGradiente := GVL_Graficos.arrVarY1[di]; //Valor forca final para calculo 
                    //        rTempoinicialGradiente:= GVL_Graficos.arrVarTimeStamp[di]; //Valor to tempo em ms final para calculo
                    //        EXIT; //Encerra a busca pela forca final
                    //    END_IF
                    //END_FOR


                    //FOR di := GVL_T22.diPosicaoForcaMaxima TO diUbound DO
                    //    IF GVL_Graficos.arrVarY1[di] <= 100 THEN //Forca <= 100
                    //        rForcaFinalGradiente := GVL_Graficos.arrVarY1[di]; //Valor forca final para calculo 
                    //        rTempoFinalGradiente:= GVL_Graficos.arrVarTimeStamp[di]; //Valor to tempo em ms final para calculo
                    //        EXIT; //Encerra a busca pela forca final
                    //        END_IF
                    //END_FOR

                    ////Calcula o gradiente de aplicacao de forca no retorno
                    //GVL_T22.rGradienteForcaRetorno := (rForcaFinalGradiente - rForcaInicialGradiente) / (rTempoFinalGradiente - rTempoInicialGradiente);

                    //========================================================================================================================================================

                    #endregion

                    #region Calculo do gradiente de avanço 

                    //========================================================================================================================================================

                    ////Busca no array o momento em que o deslocamento comecou a variar (deslocamento >= 1)
                    //FOR di := 0 TO GVL_T22.diPosicaoPressaoMaxima DO
                    //    IF GVL_Graficos.arrVarY3[di] >= 1 THEN //Deslocamento >= 1
                    //        rDeslocamentoInicialGradiente := GVL_Graficos.arrVarY3[di]; //Valor deslocamento inicial para calculo 
                    //        rTempoInicialGradiente:= GVL_Graficos.arrVarTimeStamp[di]; //Valor to tempo em ms inicial para calculo
                    //        EXIT; //Encerra a busca pelo deslocamento inicial
                    //    END_IF
                    //END_FOR

                    ////Define a forca final e o tempo final do gradiente como a FMAX obtida no calculo anterior, utilizando seu indice para coletar o tempo respectivo
                    //rDeslocamentoFinalGradiente:= GVL_Graficos.arrVarY3[GVL_T22.diPosicaoPressaoMaxima];
                    //rTempoFinalGradiente:= GVL_Graficos.arrVarTimeStamp[GVL_T22.diPosicaoPressaoMaxima];

                    ////Calcula o gradiente de aplicacao de forca no avanco
                    //GVL_T22.rGradienteDeslocamentoAvanco := (rDeslocamentoFinalGradiente - rDeslocamentoInicialGradiente) / (rTempoFinalGradiente - rTempoInicialGradiente);

                    //========================================================================================================================================================

                    #endregion

                    #region Calculo do gradiente de deslocamento no retorno

                    //========================================================================================================================================================

                    ////Busca no array o momento em que o deslocamento <= 1
                    //FOR di := GVL_T22.diPosicaoForcaMaxima TO diUbound DO
                    //    IF GVL_Graficos.arrVarY1[di] <= GVL_T22.rRunOutForceRef THEN //Ponto Runout
                    //        rDeslocamentoInicialGradiente := GVL_Graficos.arrVarY3[di]; //Deslocamento final para calculo 
                    //        rTempoInicialGradiente:= GVL_Graficos.arrVarTimeStamp[di]; //Valor to tempo em ms final para calculo
                    //        EXIT; //Encerra a busca pelo deslocamento final
                    //    END_IF
                    //END_FOR


                    //FOR di := GVL_T22.diPosicaoForcaMaxima TO diUbound DO
                    //    IF GVL_Graficos.arrVarY3[di] <= 1 THEN //Deslocamento <= 1
                    //        rDeslocamentoFinalGradiente := GVL_Graficos.arrVarY3[di]; //Deslocamento final para calculo 
                    //        rTempoFinalGradiente:= GVL_Graficos.arrVarTimeStamp[di]; //Valor to tempo em ms final para calculo
                    //        EXIT; //Encerra a busca pelo deslocamento final
                    //    END_IF
                    //END_FOR

                    ////Calcula o gradiente de aplicacao de forca no retorno
                    //GVL_T22.rGradienteDeslocamentoRetorno := (rDeslocamentoFinalGradiente - rDeslocamentoInicialGradiente) / (rTempoFinalGradiente - rTempoInicialGradiente);

                    //========================================================================================================================================================

                    #endregion

                    #region Obtem valor de deslocamento em funcao do parametro DeslocamentoNaPressao (%Pout) Input Travel At X% pOut

                    //========================================================================================================================================================

                    ////Calcula a pressao X% da pressao runout
                    //rPresaoXPout:= ((GVL_T22.rDeslocamentoNaPressao / 100) * GVL_T22.rRunOutPressureRef);

                    //FOR di := 0 TO GVL_T22.diPosicaoForcaMaxima DO

                    //IF GVL_Graficos.arrVarY2[di] >= rPresaoXPout THEN

                    //    GVL_T22.rDeslocamentoNaPressao_mm := GVL_Graficos.arrVarY3[di]; //Valor do deslocamento obtido na pressao definida
                    //        EXIT; //Encerra a busca
                    //        END_IF
                    //END_FOR

                    //========================================================================================================================================================

                    #endregion

                    #region Calculo do tempo de atuacao

                    //========================================================================================================================================================

                    //          //Encontra o ponto inicial de atuacao

                    //          FOR di := 0 TO GVL_T22.diPosicaoForcaMaxima DO

                    //          IF GVL_Graficos.arrVarY1[di] >= GVL_T22.rForcaTempoInicialAtuacao_N THEN //Procura a forca inicial de atuacao e obtem o tempo 

                    //              GVL_T22.rTempoInicialAtuacao_s := GVL_Graficos.arrVarTimeStamp[di];
                    //                  //Gera o ponto (X) no grafico
                    //                  GVL_Graficos.arrVarXPoint2[0] := GVL_T22.rTempoInicialAtuacao_s; // tempo em s
                    //                  GVL_Graficos.arrVarYPoint2[0] := GVL_Graficos.arrVarY2[di]; //Pressao CP bar
                    //                  EXIT; //Encerra a busca
                    //                  END_IF
                    //          END_FOR

                    //  //Define o tempo final em funcao do parametro selecionado
                    //                  CASE GVL_T22.iTipoAtuacaoFinal OF

                    //  0:
                    // rPressaoXMaxAvanco:= ((GVL_T22.rPorcentagemCalcTempoFinalAtuacao / 100) * GVL_T22.rPressaoEmForcaMaxima_Bar);

                    //                  FOR di := 0 TO GVL_T22.diPosicaoForcaMaxima DO

                    //          IF GVL_Graficos.arrVarY2[di] >= rPressaoXMaxAvanco THEN // 

                    //              GVL_T22.rTempoFinalAtuacao_s := GVL_Graficos.arrVarTimeStamp[di]; //
                    //                                                                                //Coloca o ponto x no grafico
                    //                  GVL_Graficos.arrVarXPoint2[1] := GVL_T22.rTempoFinalAtuacao_s;
                    //                  GVL_Graficos.arrVarYPoint2[1] := GVL_Graficos.arrVarY2[di];
                    //                  EXIT;
                    //                  END_IF
                    //              END_FOR


                    //  1:
                    //rPressaoXPoutAvanco:= ((GVL_T22.rPorcentagemCalcTempoFinalAtuacao / 100) * GVL_T22.rRunOutPressureRef);

                    //                  FOR di := 0 TO GVL_T22.diPosicaoForcaMaxima DO

                    //          IF GVL_Graficos.arrVarY2[di] >= rPressaoXPoutAvanco THEN // Pressao  >= Pressao Runout

                    //              GVL_T22.rTempoFinalAtuacao_s := GVL_Graficos.arrVarTimeStamp[di]; //
                    //                                                                                //Coloca o ponto x no grafico
                    //                  GVL_Graficos.arrVarXPoint2[1] := GVL_T22.rTempoFinalAtuacao_s;
                    //                  GVL_Graficos.arrVarYPoint2[1] := GVL_Graficos.arrVarY2[di];
                    //                  EXIT;
                    //                  END_IF
                    //              END_FOR


                    //  2:		
                    //rPressaoXPressaoAuxAvanco:= ((GVL_T22.rPorcentagemCalcTempoFinalAtuacao / 100) * GVL_T22.rPressaoAuxiliarRef);

                    //                  FOR di := 0 TO GVL_T22.diPosicaoForcaMaxima DO

                    //          IF GVL_Graficos.arrVarY2[di] >= rPressaoXPressaoAuxAvanco THEN // Forca >= Forca Runout

                    //              GVL_T22.rTempoFinalAtuacao_s := GVL_Graficos.arrVarTimeStamp[di]; //
                    //                                                                                //Coloca o ponto x no grafico
                    //                  GVL_Graficos.arrVarXPoint2[1] := GVL_T22.rTempoFinalAtuacao_s;
                    //                  GVL_Graficos.arrVarYPoint2[1] := GVL_Graficos.arrVarY2[di];
                    //                  EXIT;
                    //                  END_IF
                    //              END_FOR


                    //  END_CASE

                    //  //Calcula o tempo de atuacao	 
                    //                  GVL_T22.rTempoAtuacao_s := GVL_T22.rTempoFinalAtuacao_s - GVL_T22.rTempoInicialAtuacao_s;

                    //========================================================================================================================================================

                    #endregion

                    #region Calculo do tempo de retorno

                    //========================================================================================================================================================

                    //          //Encontra o ponto inicial de atuacao
                    //          FOR di := GVL_T22.diPosicaoForcaMaxima TO diUbound DO
                    //                  IF GVL_Graficos.arrVarY1[di] <= GVL_T22.rRunOutForceRef THEN //Forca <= RunoutForce

                    //              GVL_T22.rTempoInicialRetorno_s := GVL_Graficos.arrVarTimeStamp[di];
                    //                  //Gera o ponto (X) no grafico
                    //                  GVL_Graficos.arrVarXPoint2[2] := GVL_T22.rTempoInicialRetorno_s; // tempo em s
                    //                  GVL_Graficos.arrVarYPoint2[2] := GVL_Graficos.arrVarY2[di]; //Pressao CP bar
                    //                  EXIT; //Encerra a busca
                    //                  END_IF
                    //          END_FOR

                    //  //Define o tempo final em funcao do parametro selecionado
                    //                  CASE GVL_T22.iTipoRetornoFinal OF

                    //  0:
                    ////Calcula a pressao X% da pressao maxima
                    //rPressaoXPmaxRetorno:= ((GVL_T22.rPorcentagemCalcTempoFinalRetorno / 100) * GVL_T22.rPressaoEmForcaMaxima_Bar);

                    //                  FOR di := GVL_T22.diPosicaoForcaMaxima TO diUbound DO
                    //                          IF GVL_Graficos.arrVarY2[di] <= rPressaoXPmaxRetorno THEN

                    //                  GVL_T22.rTempoFinalRetorno_s := GVL_Graficos.arrVarTimeStamp[di];
                    //                  //Gera o ponto (X) no grafico
                    //                  GVL_Graficos.arrVarXPoint2[3] := GVL_T22.rTempoFinalRetorno_s; // tempo em s
                    //                  GVL_Graficos.arrVarYPoint2[3] := GVL_Graficos.arrVarY2[di]; //Pressao CP bar
                    //                  EXIT; //Encerra a busca
                    //                  END_IF
                    //          END_FOR


                    //  1:
                    // //Calcula a forca X% da forca runout
                    //rPressaoXPoutRetorno:= ((GVL_T22.rPorcentagemCalcTempoFinalRetorno / 100) * GVL_T22.rRunOutPressureRef);

                    //                  FOR di := GVL_T22.diPosicaoForcaMaxima TO diUbound DO
                    //                      IF GVL_Graficos.arrVarY1[di] <= rPressaoXPoutRetorno THEN // pressao <= Pressao Runout * %

                    //              GVL_T22.rTempoFinalRetorno_s := GVL_Graficos.arrVarTimeStamp[di]; //
                    //                                                                                //Gera o ponto (X) no grafico
                    //                  GVL_Graficos.arrVarXPoint2[3] := GVL_T22.rTempoFinalRetorno_s;
                    //                  GVL_Graficos.arrVarYPoint2[3] := GVL_Graficos.arrVarY2[di];
                    //                  EXIT;
                    //                  END_IF
                    //              END_FOR


                    //  2:		
                    //rPressaoXPressaoAuxRetorno:= ((GVL_T22.rPorcentagemCalcTempoFinalRetorno / 100) * GVL_T22.rPressaoAuxiliarRef);

                    //                  FOR di := GVL_T22.diPosicaoForcaMaxima  TO diUbound DO
                    //                     IF GVL_Graficos.arrVarY2[di] >= rPressaoXPressaoAuxRetorno THEN //Pressao <= Pressao aux *%

                    //              GVL_T22.rTempoFinalRetorno_s := GVL_Graficos.arrVarTimeStamp[di]; //
                    //                                                                                //Gera o ponto (X) no grafico
                    //                  GVL_Graficos.arrVarXPoint2[3] := GVL_T22.rTempoFinalRetorno_s;
                    //                  GVL_Graficos.arrVarYPoint2[3] := GVL_Graficos.arrVarY2[di];
                    //                  EXIT;
                    //                  END_IF
                    //              END_FOR


                    //  END_CASE

                    //  //Calcula o tempo de atuacao	 
                    //                  GVL_T22.rTempoRetorno_s := GVL_T22.rTempoFinalRetorno_s - GVL_T22.rTempoInicialRetorno_s;

                    //========================================================================================================================================================

                    #endregion

                    #region Calculo do tempo de retorno a posicao

                    //========================================================================================================================================================

                    //        //Encontra o ponto inicial de atuacao
                    //        FOR di := GVL_T22.diPosicaoForcaMaxima TO diUbound DO
                    //                IF GVL_Graficos.arrVarY1[di] <= GVL_T22.rRunOutForceRef THEN //Forca <= RunoutForce

                    //            GVL_T22.rTempoInicialRetornoNoDeslocamento_s := GVL_Graficos.arrVarTimeStamp[di];
                    //                //Gera o ponto (X) no grafico
                    //                EXIT; //Encerra a busca
                    //                END_IF
                    //        END_FOR


                    //FOR di := GVL_T22.diPosicaoForcaMaxima TO diUbound DO
                    //        IF GVL_Graficos.arrVarY3[di] <= GVL_T22.rPosicaoTempoRetornoNoDeslocamento_mm THEN

                    //            GVL_T22.rTempoFinalRetornoNoDeslocamento_s := GVL_Graficos.arrVarTimeStamp[di];
                    //                //Gera o ponto (X) no grafico
                    //                GVL_Graficos.arrVarXPoint3[0] := GVL_T22.rTempoFinalRetorno_s; // tempo em s
                    //                GVL_Graficos.arrVarYPoint3[0] := GVL_Graficos.arrVarY3[di]; //Pressao CP bar
                    //                EXIT; //Encerra a busca
                    //                END_IF
                    //        END_FOR

                    ////Calcula o tempo de atuacao	 
                    //                GVL_T22.rTempoRetornoNoDeslocamento_s := GVL_T22.rTempoFinalRetornoNoDeslocamento_s - GVL_T22.rTempoInicialRetornoNoDeslocamento_s;

                    //========================================================================================================================================================

                    #endregion

                    #region Calculo da diferenca de pressao em runout point

                    //========================================================================================================================================================

                    //                FOR di := 0 TO diUbound DO
                    //    IF GVL_Graficos.arrVarY2[di] >= GVL_T22.rRunOutPressureRef THEN //
                    //            rPressaoCPRunout := GVL_Graficos.arrVarY2[di];
                    //                rPressaoCSRunout:= GVL_Graficos.arrVarY4[di];
                    //                END_IF
                    //            END_FOR


                    //rDiferencaPressaoPCSC_bar:= rPressaoCPRunout - rPressaoCSRunout;

                    //========================================================================================================================================================

                    #endregion

                    #region Calculo do gradiente de pressao

                    //========================================================================================================================================================

                    //                ///Busca no array pressao >= pressao inicial gradiente
                    //                FOR di := 0 TO GVL_T22.diPosicaoForcaMaxima DO

                    //        IF GVL_Graficos.arrVarY2[di] >= rGradientePressaoMin_bar THEN //Pressao >= pressao min grad.
                    //            rPressaoInicialGradiente := GVL_Graficos.arrVarY2[di]; //Pressao inicial 
                    //                rTempoInicialGradiente:= GVL_Graficos.arrVarTimeStamp[di]; //Tempo inicial
                    //                EXIT; //Encerra a busca pela forca inicial
                    //                END_IF
                    //        END_FOR

                    ////Busca no array pressao >= pressao final gradiente
                    //                FOR di := 0 TO GVL_T22.diPosicaoForcaMaxima DO

                    //        IF GVL_Graficos.arrVarY2[di] >= rGradientePressaoMax_bar THEN //Pressao >= pressao min grad.
                    //            rPressaoFinalGradiente := GVL_Graficos.arrVarY2[di]; //Pressao inicial 
                    //                rTempoFinalGradiente:= GVL_Graficos.arrVarTimeStamp[di]; //Tempo inicial
                    //                EXIT; //Encerra a busca pela forca inicial
                    //                END_IF
                    //        END_FOR

                    ////Calcula o gradiente de pressao
                    //                GVL_T22.rGradientePressao := (rPressaoFinalGradiente - rPressaoInicialGradiente) / (rTempoFinalGradiente - rTempoInicialGradiente);

                    //========================================================================================================================================================

                    #endregion

                    #region Calculo dos Consumidores Utilizados

                    //========================================================================================================================================================

                    _modelGVL.GVL_T22.iConsumidoresCP = 0;
                    _modelGVL.GVL_T22.iConsumidoresCS = 0;

                    HelperTestBase.Model_GVL.GVL_Parametros.iTipoConsumidores = HelperMODBUS.CS_wTipoConsumidores;

                    if (HelperMODBUS.CS_wTipoConsumidores != 2)
                    {
                        _modelGVL.GVL_T22.iConsumidoresCP = 0;
                        _modelGVL.GVL_T22.iConsumidoresCS = 0;
                    }
                    else
                    {
                        //HelperMODBUS.CS_wStatusLiga17MangueirasCS 
                        if (HelperMODBUS.CS_wStatusLiga1MangueiraCP)
                            _modelGVL.GVL_T22.iConsumidoresCP = _modelGVL.GVL_T22.iConsumidoresCP + 1;

                        if (HelperMODBUS.CS_wStatusLiga2MangueirasCP)
                            _modelGVL.GVL_T22.iConsumidoresCP = _modelGVL.GVL_T22.iConsumidoresCP + 2;

                        if (HelperMODBUS.CS_wStatusLiga4MangueirasCP)
                            _modelGVL.GVL_T22.iConsumidoresCP = _modelGVL.GVL_T22.iConsumidoresCP + 4;

                        if (HelperMODBUS.CS_wStatusLiga8MangueirasCP)
                            _modelGVL.GVL_T22.iConsumidoresCP = _modelGVL.GVL_T22.iConsumidoresCP + 8;

                        if (HelperMODBUS.CS_wStatusLiga10MangueirasCP)
                            _modelGVL.GVL_T22.iConsumidoresCP = _modelGVL.GVL_T22.iConsumidoresCP + 10;

                        if (HelperMODBUS.CS_wStatusLiga17MangueirasCP)
                            _modelGVL.GVL_T22.iConsumidoresCP = _modelGVL.GVL_T22.iConsumidoresCP + 17;

                        if (HelperMODBUS.CS_wStatusLiga1MangueiraCS)
                            _modelGVL.GVL_T22.iConsumidoresCS = _modelGVL.GVL_T22.iConsumidoresCS + 1;

                        if (HelperMODBUS.CS_wStatusLiga2MangueirasCS)
                            _modelGVL.GVL_T22.iConsumidoresCS = _modelGVL.GVL_T22.iConsumidoresCS + 2;

                        if (HelperMODBUS.CS_wStatusLiga4MangueirasCS)
                            _modelGVL.GVL_T22.iConsumidoresCS = _modelGVL.GVL_T22.iConsumidoresCS + 4;

                        if (HelperMODBUS.CS_wStatusLiga8MangueirasCS)
                            _modelGVL.GVL_T22.iConsumidoresCS = _modelGVL.GVL_T22.iConsumidoresCS + 8;

                        if (HelperMODBUS.CS_wStatusLiga10MangueirasCS)
                            _modelGVL.GVL_T22.iConsumidoresCS = _modelGVL.GVL_T22.iConsumidoresCS + 10;

                        if (HelperMODBUS.CS_wStatusLiga17MangueirasCS)
                            _modelGVL.GVL_T22.iConsumidoresCS = _modelGVL.GVL_T22.iConsumidoresCS + 17;
                    }
                    //============================. ============================================================================================================================

                    #endregion

                    _modelGVL.GVL_T22.bCalculaResultados = false;

                    _modelGVL.GVL_Graficos.bDadosCalculados = true;
                }

                HelperTestBase.Model_GVL.helperTestBase_ModelGVL_Test = HelperTestBase.Model_GVL.GVL_T22;

                HelperTestBase.Model_GVL = _modelGVL;

                #endregion

            }
            catch (Exception ex)
            {
                var err = ex.Message;
                throw;
            }

            return _modelGVL;

            #endregion
        }

        #endregion

        #region T23 - Calculos Verificacao Componente - ET_Adjustment_BreatherHoleCentralValveOpen
        public Model_GVL CalcGraphT23_ET_BreatherHoleCentralValveOpen(bool bCalculaResultados, List<double>[] lstDblReturnReadFile)
        {
            #region PROGRAM T23_Calculos_Resultados

            try
            {
                #region Limpa ultimos resultados

                dictVarList.Clear();

                _modelGVL.GVL_T23.rForcaMaxima = 0; //Zera o ultimo valor de força obtido
                _modelGVL.GVL_T23.rGradienteForcaAvanco = 0; //Zera o ultimo valor obtido
                _modelGVL.GVL_T23.rGradienteForcaRetorno = 0; //Zera o ultimo valor obtido
                _modelGVL.GVL_T23.rGradienteDeslocamentoAvanco = 0; //Zera o ultimo valor obtido
                _modelGVL.GVL_T23.rGradienteDeslocamentoRetorno = 0; //Zera o ultimo valor obtido
                _modelGVL.GVL_T23.iConsumidoresCP = 0;
                _modelGVL.GVL_T23.iConsumidoresCS = 0;

                _modelGVL.GVL_T23.bCalculaResultados = bCalculaResultados;

                #region VARIABLES

                long diUbound = 0; //  ; DINT;
                long di = 0; //  ; DINT;
                double rForcaInicialGradiente = 0; //  ; REAL;
                double rForcaFinalGradiente = 0; //  ; REAL;
                double rDeslocamentoInicialGradiente = 0; //   ; REAL;
                double rDeslocamentoFinalGradiente = 0; //  ; REAL;
                double rTempoInicialGradiente = 0; //  ; REAL;
                double rTempoFinalGradiente = 0; //   ; REAL;

                #endregion

                #endregion

                #region Variaveis Grafico

                _modelGVL.GVL_Graficos.rEscalaX = 30;
                _modelGVL.GVL_Graficos.EixoX.wsTLLabel = "AxesChart.1";
                _modelGVL.GVL_Graficos.rEscalaY1 = 2;
                _modelGVL.GVL_Graficos.EixoY1.wsTLLabel = "AxesChart.3";
                _modelGVL.GVL_Graficos.rEscalaY2 = 0;
                _modelGVL.GVL_Graficos.EixoY2.wsTLLabel = string.Empty; ;
                _modelGVL.GVL_Graficos.rEscalaY3 = 0;
                _modelGVL.GVL_Graficos.EixoY3.wsTLLabel = string.Empty;
                _modelGVL.GVL_Graficos.rEscalaY4 = 0;
                _modelGVL.GVL_Graficos.EixoY4.wsTLLabel = string.Empty;

                _modelGVL.GVL_Graficos.strNomeEixoX = "Time (s)";
                _modelGVL.GVL_Graficos.strNomeEixoY1 = "Hydraulic Pressure (bar)";
                _modelGVL.GVL_Graficos.strNomeEixoY2 = string.Empty;
                _modelGVL.GVL_Graficos.strNomeEixoY3 = string.Empty;
                _modelGVL.GVL_Graficos.strNomeEixoY4 = string.Empty;

                _modelGVL.GVL_Graficos.strUnidadeX = "s";
                _modelGVL.GVL_Graficos.strUnidadeY1 = "bar";
                _modelGVL.GVL_Graficos.strUnidadeY2 = string.Empty;
                _modelGVL.GVL_Graficos.strUnidadeY3 = string.Empty;
                _modelGVL.GVL_Graficos.strUnidadeY4 = string.Empty;

                _modelGVL.GVL_Graficos.bOcultaY2 = false;
                _modelGVL.GVL_Graficos.bOcultaY3 = true;
                _modelGVL.GVL_Graficos.bOcultaY4 = true;

                #endregion

                #region Varriaveis Array Dados

                //os arrays dinamicos obtidos neste teste contem as seguintes grandezas:
                // GVL_Graficos.arrVarX[GVL_Graficos.diBuffer] := TIME_TO_REAL(etTempoCiclo)/1000;
                // GVL_Graficos.arrVarY1[GVL_Graficos.diBuffer] := rPressaoHidraulica_Bar_Lin;
                // GVL_Graficos.arrVarY2[GVL_Graficos.diBuffer] := rForcaEntradaBooster_N_Lin;
                // GVL_Graficos.arrVarY3[GVL_Graficos.diBuffer] := rDeslocamentoEntradaBooster_mm_Lin;

                ClearArrayGVL_Graficos();

                _modelGVL.GVL_Graficos.arrVarTimeStamp = lstDblReturnReadFile[0].ToArray();
                _modelGVL.GVL_Graficos.arrVarX = lstDblReturnReadFile[0].ToArray();
                _modelGVL.GVL_Graficos.arrVarY1 = lstDblReturnReadFile[9].ToArray();
                _modelGVL.GVL_Graficos.arrVarY2 = lstDblReturnReadFile[2].ToArray();
                _modelGVL.GVL_Graficos.arrVarY3 = lstDblReturnReadFile[5].ToArray();

                #endregion

                #region Calculos

                if (_modelGVL.GVL_T23.bCalculaResultados)
                {
                    _modelGVL.GVL_T23 = HelperTestBase.Model_GVL.GVL_T23;

                    //Define o ponto maximo do array que foi plotado durante o teste
                    _modelGVL.GVL_Graficos.diBuffer = lstDblReturnReadFile[0].Count() > 0 ? lstDblReturnReadFile[0].Count() : 0;

                    diUbound = _modelGVL.GVL_Graficos.diBuffer; //Define o ponto maximo do array que foi plotado durante o teste

                    #region Loop para identificar a forca maxima do teste, e armazenar o ponto de inflexao do teste (quando o atuador comeca a retornar)
                    //========================================================================================================================================================

                    for (di = 0; di < diUbound; di++)
                    {
                        if (_modelGVL.GVL_Graficos.arrVarY2[di] > _modelGVL.GVL_T23.rForcaMaxima)
                        {
                            _modelGVL.GVL_T23.rForcaMaxima = _modelGVL.GVL_Graficos.arrVarY2[di]; //Atualiza o valor de forca maxima com o maior valor obtido no array
                            _modelGVL.GVL_T23.diPosicaoForcaMaxima = di; //Indica em qual posicao do array esta a forca maxima (pico do grafico, aonde comeca o retorno do atuador)
                        }
                    }

                    //========================================================================================================================================================
                    #endregion

                    #region //Obtem valor de deslocamento maximo
                    for (di = 0; di < diUbound; di++)
                    {
                        if (_modelGVL.GVL_Graficos.arrVarY3[di] >= _modelGVL.GVL_T23.rDeslocamentoMaximo_mm)
                        {
                            _modelGVL.GVL_T23.rDeslocamentoMaximo_mm = _modelGVL.GVL_Graficos.arrVarY3[di]; //Valor do deslocamento obtido na pressao definida
                        }
                    }
                    #endregion

                    #region Calculo do gradiente de aplicacao de força no avanço
                    //========================================================================================================================================================

                    //Busca no array o momento em que a forca comecou a subir (forca >= 100N) e o tempo decorrido desta forca
                    for (di = 0; di <= _modelGVL.GVL_T23.diPosicaoForcaMaxima; di++)
                    {
                        if (_modelGVL.GVL_Graficos.arrVarY2[di] >= 100)//forca comecou a subir (>=100N)
                        {
                            rForcaInicialGradiente = _modelGVL.GVL_Graficos.arrVarY2[di]; //Valor forca inicial para calculo 
                            rTempoInicialGradiente = _modelGVL.GVL_Graficos.arrVarTimeStamp[di]; //Valor to tempo em ms inicial para calculo

                            break; //Encerra a busca pela forca inicial
                        }
                    }

                    //Define a forca final e o tempo final do gradiente como a FMAX obtida no calculo anterior, utilizando seu indice para coletar o tempo respectivo
                    rForcaFinalGradiente = _modelGVL.GVL_Graficos.arrVarY2[_modelGVL.GVL_T23.diPosicaoForcaMaxima];
                    rTempoFinalGradiente = _modelGVL.GVL_Graficos.arrVarTimeStamp[_modelGVL.GVL_T23.diPosicaoForcaMaxima];

                    //Calcula o gradiente de aplicacao de forca no avanco
                    _modelGVL.GVL_T23.rGradienteForcaAvanco = (rForcaFinalGradiente - rForcaInicialGradiente) / (rTempoFinalGradiente - rTempoInicialGradiente);
                    //========================================================================================================================================================

                    #endregion

                    #region Calculo do gradiente de aplicacao de força no retorno
                    //========================================================================================================================================================

                    //Busca no array o momento em que a forca caiu abaixo de 100N (forca <= 100N) e o tempo decorrido desta forca
                    for (di = _modelGVL.GVL_T23.diPosicaoForcaMaxima; di < diUbound; di++)
                    {
                        if (_modelGVL.GVL_Graficos.arrVarY2[di] <= 100) //Forca proxima de 0 (<=100N)
                        {
                            rForcaFinalGradiente = _modelGVL.GVL_Graficos.arrVarY2[di]; //Valor forca final para calculo 
                            rTempoFinalGradiente = _modelGVL.GVL_Graficos.arrVarTimeStamp[di]; //Valor to tempo em ms final para calculo

                            break; //Encerra a busca pela forca final
                        }
                    }

                    //Define a forca inicial e o tempo inicial do gradiente como a FMAX obtida no calculo anterior, utilizando seu indice para coletar o tempo respectivo
                    rForcaInicialGradiente = _modelGVL.GVL_Graficos.arrVarY2[_modelGVL.GVL_T23.diPosicaoForcaMaxima];
                    rTempoInicialGradiente = _modelGVL.GVL_Graficos.arrVarTimeStamp[_modelGVL.GVL_T23.diPosicaoForcaMaxima];

                    //Calcula o gradiente de aplicacao de forca no retorno
                    _modelGVL.GVL_T23.rGradienteForcaRetorno = (rForcaFinalGradiente - rForcaInicialGradiente) / (rTempoFinalGradiente - rTempoInicialGradiente);
                    //========================================================================================================================================================
                    #endregion

                    #region Calculo do gradiente de avanço 
                    //========================================================================================================================================================

                    //Busca no array o momento em que o deslocamento comecou a variar (deslocamento >= 1)
                    for (di = 0; di <= _modelGVL.GVL_T23.diPosicaoForcaMaxima; di++)
                    {
                        if (_modelGVL.GVL_Graficos.arrVarY3[di] >= 1) //Deslocamento >= 1mm
                        {
                            rDeslocamentoInicialGradiente = _modelGVL.GVL_Graficos.arrVarY3[di]; //Valor deslocamento inicial para calculo 
                            rTempoInicialGradiente = _modelGVL.GVL_Graficos.arrVarTimeStamp[di]; //Valor to tempo em ms inicial para calculo

                            break; //Encerra a busca pelo deslocamento inicial
                        }
                    }

                    //Define a forca final e o tempo final do gradiente como a FMAX obtida no calculo anterior, utilizando seu indice para coletar o tempo respectivo
                    rDeslocamentoFinalGradiente = _modelGVL.GVL_Graficos.arrVarY3[_modelGVL.GVL_T23.diPosicaoForcaMaxima];
                    rTempoFinalGradiente = _modelGVL.GVL_Graficos.arrVarTimeStamp[_modelGVL.GVL_T23.diPosicaoForcaMaxima];

                    //Calcula o gradiente de aplicacao de forca no avanco
                    _modelGVL.GVL_T23.rGradienteDeslocamentoAvanco = (rDeslocamentoFinalGradiente - rDeslocamentoInicialGradiente) / (rTempoFinalGradiente - rTempoInicialGradiente);
                    //========================================================================================================================================================

                    #endregion

                    #region Calculo do gradiente de deslocamento no retorno

                    //========================================================================================================================================================

                    //Busca no array o momento em que o deslocamento <= 1
                    for (di = _modelGVL.GVL_T23.diPosicaoForcaMaxima; di < diUbound; di++)
                    {
                        if (_modelGVL.GVL_Graficos.arrVarY3[di] <= 1) //Deslocamento <= 1
                        {
                            rDeslocamentoFinalGradiente = _modelGVL.GVL_Graficos.arrVarY3[di]; //Deslocamento final para calculo 
                            rTempoFinalGradiente = _modelGVL.GVL_Graficos.arrVarTimeStamp[di]; //Valor to tempo em ms final para calculo

                            break; //Encerra a busca pelo deslocamento final
                        }
                    }


                    //Define o deslocamento inicial e o tempo inicial do gradiente como a FMAX obtida no calculo anterior, utilizando seu indice para coletar o tempo respectivo
                    rDeslocamentoInicialGradiente = _modelGVL.GVL_Graficos.arrVarY3[_modelGVL.GVL_T23.diPosicaoForcaMaxima];
                    rTempoInicialGradiente = _modelGVL.GVL_Graficos.arrVarTimeStamp[_modelGVL.GVL_T23.diPosicaoForcaMaxima];

                    //Calcula o gradiente de aplicacao de forca no retorno
                    _modelGVL.GVL_T23.rGradienteDeslocamentoRetorno = (rDeslocamentoFinalGradiente - rDeslocamentoInicialGradiente) / (rTempoFinalGradiente - rTempoInicialGradiente);
                    //========================================================================================================================================================

                    #endregion

                    #region Calculo dos Consumidores Utilizados

                    //========================================================================================================================================================

                    _modelGVL.GVL_T23.iConsumidoresCP = 0;
                    _modelGVL.GVL_T23.iConsumidoresCS = 0;

                    if (_modelGVL.GVL_Parametros.iTipoConsumidores != 2)
                    {
                        _modelGVL.GVL_T23.iConsumidoresCP = 0;
                        _modelGVL.GVL_T23.iConsumidoresCS = 0;
                    }
                    else
                    {

                        if (_modelGVL.GVL_Parametros.bLiga1MangueiraCP)
                            _modelGVL.GVL_T23.iConsumidoresCP = _modelGVL.GVL_T23.iConsumidoresCP + 1;


                        if (_modelGVL.GVL_Parametros.bLiga2MangueirasCP)
                            _modelGVL.GVL_T23.iConsumidoresCP = _modelGVL.GVL_T23.iConsumidoresCP + 2;

                        if (_modelGVL.GVL_Parametros.bLiga4MangueirasCP)
                            _modelGVL.GVL_T23.iConsumidoresCP = _modelGVL.GVL_T23.iConsumidoresCP + 4;

                        if (_modelGVL.GVL_Parametros.bLiga8MangueirasCP)
                            _modelGVL.GVL_T23.iConsumidoresCP = _modelGVL.GVL_T23.iConsumidoresCP + 8;

                        if (_modelGVL.GVL_Parametros.bLiga10MangueirasCP)
                            _modelGVL.GVL_T23.iConsumidoresCP = _modelGVL.GVL_T23.iConsumidoresCP + 10;

                        if (_modelGVL.GVL_Parametros.bLiga17MangueirasCP)
                            _modelGVL.GVL_T23.iConsumidoresCP = _modelGVL.GVL_T23.iConsumidoresCP + 17;

                        if (_modelGVL.GVL_Parametros.bLiga1MangueiraCS)
                            _modelGVL.GVL_T23.iConsumidoresCS = _modelGVL.GVL_T23.iConsumidoresCS + 1;

                        if (_modelGVL.GVL_Parametros.bLiga2MangueirasCS)
                            _modelGVL.GVL_T23.iConsumidoresCS = _modelGVL.GVL_T23.iConsumidoresCS + 2;

                        if (_modelGVL.GVL_Parametros.bLiga4MangueirasCS)
                            _modelGVL.GVL_T23.iConsumidoresCS = _modelGVL.GVL_T23.iConsumidoresCS + 4;

                        if (_modelGVL.GVL_Parametros.bLiga8MangueirasCS)
                            _modelGVL.GVL_T23.iConsumidoresCS = _modelGVL.GVL_T23.iConsumidoresCS + 8;

                        if (_modelGVL.GVL_Parametros.bLiga10MangueirasCS)
                            _modelGVL.GVL_T23.iConsumidoresCS = _modelGVL.GVL_T23.iConsumidoresCS + 10;

                        if (_modelGVL.GVL_Parametros.bLiga17MangueirasCS)
                            _modelGVL.GVL_T23.iConsumidoresCS = _modelGVL.GVL_T23.iConsumidoresCS + 17;
                    }
                    //========================================================================================================================================================

                    #endregion

                    #region Registro Pressoes
                    //Pressoes que precisam ser obtidas durante o teste
                    //_modelGVL.GVL_T23.rPressaoHidraulicaAbertura_Bar;// : REAL;
                    //_modelGVL.GVL_T23.rPressaoHidraulicaRespiro_Bar;// : REAL;
                    #endregion

                    _modelGVL.GVL_T23.bCalculaResultados = false;

                    _modelGVL.GVL_Graficos.bDadosCalculados = true;
                }

                HelperTestBase.Model_GVL.helperTestBase_ModelGVL_Test = HelperTestBase.Model_GVL.GVL_T23;

                HelperTestBase.Model_GVL = _modelGVL;

                #endregion

            }
            catch (Exception ex)
            {
                var err = ex.Message;
                throw;
            }

            return _modelGVL;

            #endregion
        }

        #endregion

        #region T24 - Calculos Atuacao - ET_Adjustment_Efficiency
        public Model_GVL CalcGraphT24_ET_Efficiency(bool bCalculaResultados, List<double>[] lstDblReturnReadFile)
        {
            #region PROGRAM T24_Calculos_Resultados

            try
            {
                #region Limpa ultimos resultados

                dictVarList.Clear();
                _modelGVL.GVL_T24.rForcaMaximaSlow = 0;
                _modelGVL.GVL_T24.diPosicaoForcaMaximaSlow = 0;
                _modelGVL.GVL_T24.rForcaMaximaFast = 0;
                _modelGVL.GVL_T24.diPosicaoForcaMaximaFast = 0;
                _modelGVL.GVL_T24.iConsumidoresCP = 0;
                _modelGVL.GVL_T24.iConsumidoresCS = 0;
                _modelGVL.GVL_T24.rGradientePressaoSlow = 0;
                _modelGVL.GVL_T24.rGradientePressaoFast = 0;
                _modelGVL.GVL_T24.rForcaEficienciaSlow = 0;
                _modelGVL.GVL_T24.rForcaEficienciaFast = 0;
                _modelGVL.GVL_T24.rEficiencia = 0;

                _modelGVL.GVL_T24.bCalculaResultados = bCalculaResultados;

                #region VARIABLES

                long diUbound = 0; //  ; DINT;
                long di = 0; //  ; DINT;
                double rPressaoInicialGradiente = 0; //  ; REAL;
                double rPressaoFinalGradiente = 0; //  ; REAL;
                double rTempoInicialGradiente = 0; //  ; REAL;
                double rTempoFinalGradiente = 0; //   ; REAL;

                #endregion

                #endregion

                #region Variaveis Grafico

                _modelGVL.GVL_Graficos.rEscalaX = 1500;
                _modelGVL.GVL_Graficos.EixoX.wsTLLabel = "AxesChart.1";
                _modelGVL.GVL_Graficos.rEscalaY1 = 150;
                _modelGVL.GVL_Graficos.EixoY1.wsTLLabel = "AxesChart.3";
                _modelGVL.GVL_Graficos.rEscalaY2 = 150;
                _modelGVL.GVL_Graficos.EixoY2.wsTLLabel = "AxesChart.4";
                _modelGVL.GVL_Graficos.rEscalaY3 = 0;
                _modelGVL.GVL_Graficos.EixoY3.wsTLLabel = string.Empty;
                _modelGVL.GVL_Graficos.rEscalaY4 = 0;
                _modelGVL.GVL_Graficos.EixoY4.wsTLLabel = string.Empty;

                _modelGVL.GVL_Graficos.strNomeEixoX = "Time (s)";
                _modelGVL.GVL_Graficos.strNomeEixoY1 = "Hydraulic Pressure (bar)";
                _modelGVL.GVL_Graficos.strNomeEixoY2 = "Input Force (N)";
                _modelGVL.GVL_Graficos.strNomeEixoY3 = "Input Travel (mm)";
                _modelGVL.GVL_Graficos.strNomeEixoY4 = string.Empty;

                _modelGVL.GVL_Graficos.strUnidadeX = "s";
                _modelGVL.GVL_Graficos.strUnidadeY1 = "bar";
                _modelGVL.GVL_Graficos.strUnidadeY2 = "N";
                _modelGVL.GVL_Graficos.strUnidadeY3 = "mm";
                _modelGVL.GVL_Graficos.strUnidadeY4 = string.Empty;

                _modelGVL.GVL_Graficos.bOcultaY2 = false;
                _modelGVL.GVL_Graficos.bOcultaY3 = true;
                _modelGVL.GVL_Graficos.bOcultaY4 = true;

                #endregion

                #region Varriaveis Array Dados

                //os arrays dinamicos obtidos neste teste contem as seguintes grandezas:
                //Tipo de Grafico = 0
                // 						GVL_Graficos.arrVarX[GVL_Graficos.diBuffer] := rForcaEntradaBooster_N_Lin;
                // 						GVL_Graficos.arrVarY1[GVL_Graficos.diBuffer] := rPressaoCP_Bar_Lin;
                // 						GVL_Graficos.arrVarY2[GVL_Graficos.diBuffer] := 0
                // 						GVL_Graficos.arrVarY3[GVL_Graficos.diBuffer] := TIME_TO_REAL(etTempoCiclo)/1000;
                //Tipo de Grafico = 1
                ///GVL_Graficos.arrVarX[GVL_Graficos.diBuffer] := TIME_TO_REAL(etTempoCiclo)/1000;
                //GVL_Graficos.arrVarY1[GVL_Graficos.diBuffer] := rPressaoCP_Bar_Lin;
                //GVL_Graficos.arrVarY2[GVL_Graficos.diBuffer] := 0;
                //GVL_Graficos.arrVarY3[GVL_Graficos.diBuffer] := rForcaEntradaBooster_N_Lin;

                ClearArrayGVL_Graficos();

                _modelGVL.GVL_Graficos.arrVarTimeStamp = lstDblReturnReadFile[0].ToArray();
                _modelGVL.GVL_Graficos.arrVarX = lstDblReturnReadFile[2].ToArray();
                _modelGVL.GVL_Graficos.arrVarY1 = lstDblReturnReadFile[7].ToArray();
                _modelGVL.GVL_Graficos.arrVarY2 = lstDblReturnReadFile[6].ToArray();
                _modelGVL.GVL_Graficos.arrVarY3 = lstDblReturnReadFile[5].ToArray();

                #endregion

                #region Calculos

                if (_modelGVL.GVL_T24.bCalculaResultados)
                {
                    _modelGVL.GVL_T24 = HelperTestBase.Model_GVL.GVL_T24;

                    //Define o ponto maximo do array que foi plotado durante o teste
                    _modelGVL.GVL_Graficos.diBuffer = lstDblReturnReadFile[0].Count() > 0 ? lstDblReturnReadFile[0].Count() : 0;

                    #region Loop para identificar a forca maxima do teste, slow
                    //========================================================================================================================================================

                    if (_modelGVL.GVL_T24.iTipoGrafico == 0)
                    {
                        for (di = 0; di <= (_modelGVL.GVL_T24.diInicioBufferFast - 10); di++)
                        {
                            if (GVL_Graficos.arrVarX[di] > _modelGVL.GVL_T24.rForcaMaximaSlow)
                            {
                                _modelGVL.GVL_T24.rForcaMaximaSlow = _modelGVL.GVL_Graficos.arrVarX[di]; //Atualiza o valor de forca maxima com o maior valor obtido no array
                                _modelGVL.GVL_T24.diPosicaoForcaMaximaSlow = di; //Indica em qual posicao do array esta a forca maxima (pico do grafico, aonde comeca o retorno do atuador)
                            }
                        }
                    }
                    else
                    {
                        for (di = 0; di <= (_modelGVL.GVL_T24.diInicioBufferFast - 10); di++)
                        {
                            if (_modelGVL.GVL_Graficos.arrVarY3[di] > _modelGVL.GVL_T24.rForcaMaximaSlow)
                            {


                                _modelGVL.GVL_T24.rForcaMaximaSlow = _modelGVL.GVL_Graficos.arrVarY3[di]; //Atualiza o valor de forca maxima com o maior valor obtido no array
                                _modelGVL.GVL_T24.diPosicaoForcaMaximaSlow = di; //Indica em qual posicao do array esta a forca maxima (pico do grafico, aonde comeca o retorno do atuador)
                            }
                        }

                    }

                    //========================================================================================================================================================
                    #endregion

                    #region //Loop para identificar a forca maxima do teste, fast

                    if (_modelGVL.GVL_T24.iTipoGrafico == 0)
                    {
                        for (di = _modelGVL.GVL_T24.diInicioBufferFast; di < diUbound; di++)
                        {
                            if (_modelGVL.GVL_Graficos.arrVarX[di] > _modelGVL.GVL_T24.rForcaMaximaFast)
                            {

                                _modelGVL.GVL_T24.rForcaMaximaFast = _modelGVL.GVL_Graficos.arrVarX[di]; //Atualiza o valor de forca maxima com o maior valor obtido no array
                                _modelGVL.GVL_T24.diPosicaoForcaMaximaFast = di; //Indica em qual posicao do array esta a forca maxima (pico do grafico, aonde comeca o retorno do atuador)
                            }
                        }
                    }
                    else
                    {
                        for (di = _modelGVL.GVL_T24.diInicioBufferFast; di < diUbound; di++)
                        {
                            if (GVL_Graficos.arrVarY3[di] > _modelGVL.GVL_T24.rForcaMaximaSlow)
                            {

                                _modelGVL.GVL_T24.rForcaMaximaFast = _modelGVL.GVL_Graficos.arrVarY3[di]; //Atualiza o valor de forca maxima com o maior valor obtido no array
                                _modelGVL.GVL_T24.diPosicaoForcaMaximaFast = di; //Indica em qual posicao do array esta a forca maxima (pico do grafico, aonde comeca o retorno do atuador)
                            }
                        }
                    }
                    #endregion

                    #region //Calculo do gradiente de pressao teste slow

                    //Busca no array o momento em que a pressao comecou a subir (pressao >= parametroinicial) e o tempo decorrido desta pressao
                    for (di = 0; di <= _modelGVL.GVL_T24.diPosicaoForcaMaximaSlow; di++)
                    {

                        if (_modelGVL.GVL_Graficos.arrVarY1[di] >= _modelGVL.GVL_T24.rInicioGradientePressao_Bar) //Pressao >= parametros
                        {
                            rPressaoInicialGradiente = _modelGVL.GVL_Graficos.arrVarY1[di]; //Valor fde pressao encontrado >= parametro
                            rTempoInicialGradiente = _modelGVL.GVL_Graficos.arrVarTimeStamp[di]; //Valor to tempo em ms inicial para calculo
                            break; //Encerra a busca pela forca inicial
                        }
                    }

                    //Busca no array o momento em que a pressao comecou a subir (pressao >= parametrofinal) e o tempo decorrido desta pressao
                    for (di = 0; di <= _modelGVL.GVL_T24.diPosicaoForcaMaximaSlow; di++)
                    {

                        if (_modelGVL.GVL_Graficos.arrVarY1[di] >= _modelGVL.GVL_T24.rFimGradientePressao_Bar) //Pressao >= parametros
                        {
                            rPressaoFinalGradiente = _modelGVL.GVL_Graficos.arrVarY1[di]; //Valor fde pressao encontrado >= parametro
                            rTempoFinalGradiente = _modelGVL.GVL_Graficos.arrVarTimeStamp[di]; //Valor to tempo em ms inicial para calculo
                            break; //Encerra a busca pela forca inicial
                        }
                    }

                    //Calcula o gradiente de aplicacao de forca no avanco
                    _modelGVL.GVL_T24.rGradientePressaoSlow = (rPressaoFinalGradiente - rPressaoInicialGradiente) / (rTempoFinalGradiente - rTempoInicialGradiente);
                    #endregion

                    #region Calculo do gradiente de pressao teste fast

                    //Busca no array o momento em que a pressao comecou a subir (pressao >= parametroinicial) e o tempo decorrido desta pressao
                    for (di = _modelGVL.GVL_T24.diInicioBufferFast; di <= _modelGVL.GVL_T24.diPosicaoForcaMaximaFast; di++)
                    {

                        if (_modelGVL.GVL_Graficos.arrVarY2[di] >= _modelGVL.GVL_T24.rInicioGradientePressao_Bar) //Pressao >= parametros
                        {
                            rPressaoInicialGradiente = _modelGVL.GVL_Graficos.arrVarY2[di]; //Valor fde pressao encontrado >= parametro
                            rTempoInicialGradiente = _modelGVL.GVL_Graficos.arrVarTimeStamp[di]; //Valor to tempo em ms inicial para calculo
                            break; //Encerra a busca pela forca inicial
                        }
                    }

                    //Busca no array o momento em que a pressao comecou a subir (pressao >= parametrofinal) e o tempo decorrido desta pressao
                    for (di = _modelGVL.GVL_T24.diInicioBufferFast; di <= _modelGVL.GVL_T24.diPosicaoForcaMaximaFast; di++)
                    {
                        if (_modelGVL.GVL_Graficos.arrVarY2[di] >= _modelGVL.GVL_T24.rFimGradientePressao_Bar) //Pressao >= parametros
                        {
                            rPressaoFinalGradiente = _modelGVL.GVL_Graficos.arrVarY2[di]; //Valor fde pressao encontrado >= parametro
                            rTempoFinalGradiente = _modelGVL.GVL_Graficos.arrVarTimeStamp[di]; //Valor to tempo em ms inicial para calculo
                            break; //Encerra a busca pela forca inicial
                        }
                    }

                    //Calcula o gradiente de aplicacao de forca no avanco
                    _modelGVL.GVL_T24.rGradientePressaoFast = (rPressaoFinalGradiente - rPressaoInicialGradiente) / (rTempoFinalGradiente - rTempoInicialGradiente);

                    #endregion

                    #region Calculo da eficiencia

                    //Loop para identificar a forca de eficiencia slow		 
                    if (_modelGVL.GVL_T24.iTipoGrafico == 0)
                    {
                        for (di = 0; di <= _modelGVL.GVL_T24.diPosicaoForcaMaximaFast; di++)
                        {
                            if (_modelGVL.GVL_Graficos.arrVarX[di] >= _modelGVL.GVL_T24.rEficienciaNaForca_N)
                            {
                                _modelGVL.GVL_T24.rForcaEficienciaSlow = _modelGVL.GVL_Graficos.arrVarX[di]; //Atualiza o valor de forca maxima com o maior valor obtido no array
                            }
                        }
                    }
                    else
                    {
                        for (di = 0; di <= _modelGVL.GVL_T24.diPosicaoForcaMaximaFast; di++)
                        {
                            if (_modelGVL.GVL_Graficos.arrVarY3[di] > _modelGVL.GVL_T24.rEficienciaNaForca_N)
                            {
                                _modelGVL.GVL_T24.rForcaEficienciaSlow = _modelGVL.GVL_Graficos.arrVarY3[di]; //Atualiza o valor de forca maxima com o maior valor obtido no array
                            }
                        }

                    }

                    //Loop para identificar a forca de eficiencia fast		 
                    if (_modelGVL.GVL_T24.iTipoGrafico == 0)
                    {
                        for (di = _modelGVL.GVL_T24.diInicioBufferFast; di <= _modelGVL.GVL_T24.diPosicaoForcaMaximaFast; di++)
                        {
                            if (_modelGVL.GVL_Graficos.arrVarX[di] >= _modelGVL.GVL_T24.rEficienciaNaForca_N)
                            {
                                _modelGVL.GVL_T24.rForcaEficienciaFast = _modelGVL.GVL_Graficos.arrVarX[di]; //Atualiza o valor de forca maxima com o maior valor obtido no array
                            }

                        }
                    }
                    else
                    {
                        for (di = _modelGVL.GVL_T24.diInicioBufferFast; di <= _modelGVL.GVL_T24.diPosicaoForcaMaximaFast; di++)
                        {

                            if (_modelGVL.GVL_Graficos.arrVarY3[di] > _modelGVL.GVL_T24.rEficienciaNaForca_N)
                            {
                                _modelGVL.GVL_T24.rForcaEficienciaFast = _modelGVL.GVL_Graficos.arrVarY3[di]; //Atualiza o valor de forca maxima com o maior valor obtido no array
                            }
                        }

                    }

                    //Calculo da eficiencia
                    _modelGVL.GVL_T24.rEficiencia = _modelGVL.GVL_T24.rForcaEficienciaFast / _modelGVL.GVL_T24.rForcaEficienciaSlow;

                    #endregion

                    #region Calculo dos Consumidores Utilizados

                    //========================================================================================================================================================

                    _modelGVL.GVL_T24.iConsumidoresCP = 0;
                    _modelGVL.GVL_T24.iConsumidoresCS = 0;

                    HelperTestBase.Model_GVL.GVL_Parametros.iTipoConsumidores = HelperMODBUS.CS_wTipoConsumidores;

                    if (HelperMODBUS.CS_wTipoConsumidores != 2)
                    {
                        _modelGVL.GVL_T24.iConsumidoresCP = 0;
                        _modelGVL.GVL_T24.iConsumidoresCS = 0;
                    }
                    else
                    {
                        //HelperMODBUS.CS_wStatusLiga17MangueirasCS 
                        if (HelperMODBUS.CS_wStatusLiga1MangueiraCP)
                            _modelGVL.GVL_T24.iConsumidoresCP = _modelGVL.GVL_T24.iConsumidoresCP + 1;

                        if (HelperMODBUS.CS_wStatusLiga2MangueirasCP)
                            _modelGVL.GVL_T24.iConsumidoresCP = _modelGVL.GVL_T24.iConsumidoresCP + 2;

                        if (HelperMODBUS.CS_wStatusLiga4MangueirasCP)
                            _modelGVL.GVL_T24.iConsumidoresCP = _modelGVL.GVL_T24.iConsumidoresCP + 4;

                        if (HelperMODBUS.CS_wStatusLiga8MangueirasCP)
                            _modelGVL.GVL_T24.iConsumidoresCP = _modelGVL.GVL_T24.iConsumidoresCP + 8;

                        if (HelperMODBUS.CS_wStatusLiga10MangueirasCP)
                            _modelGVL.GVL_T24.iConsumidoresCP = _modelGVL.GVL_T24.iConsumidoresCP + 10;

                        if (HelperMODBUS.CS_wStatusLiga17MangueirasCP)
                            _modelGVL.GVL_T24.iConsumidoresCP = _modelGVL.GVL_T24.iConsumidoresCP + 17;

                        if (HelperMODBUS.CS_wStatusLiga1MangueiraCS)
                            _modelGVL.GVL_T24.iConsumidoresCS = _modelGVL.GVL_T24.iConsumidoresCS + 1;

                        if (HelperMODBUS.CS_wStatusLiga2MangueirasCS)
                            _modelGVL.GVL_T24.iConsumidoresCS = _modelGVL.GVL_T24.iConsumidoresCS + 2;

                        if (HelperMODBUS.CS_wStatusLiga4MangueirasCS)
                            _modelGVL.GVL_T24.iConsumidoresCS = _modelGVL.GVL_T24.iConsumidoresCS + 4;

                        if (HelperMODBUS.CS_wStatusLiga8MangueirasCS)
                            _modelGVL.GVL_T24.iConsumidoresCS = _modelGVL.GVL_T24.iConsumidoresCS + 8;

                        if (HelperMODBUS.CS_wStatusLiga10MangueirasCS)
                            _modelGVL.GVL_T24.iConsumidoresCS = _modelGVL.GVL_T24.iConsumidoresCS + 10;

                        if (HelperMODBUS.CS_wStatusLiga17MangueirasCS)
                            _modelGVL.GVL_T24.iConsumidoresCS = _modelGVL.GVL_T24.iConsumidoresCS + 17;
                    }
                    //============================. ============================================================================================================================

                    #endregion

                    _modelGVL.GVL_T24.bCalculaResultados = false;

                    _modelGVL.GVL_Graficos.bDadosCalculados = true;
                }

                HelperTestBase.Model_GVL.helperTestBase_ModelGVL_Test = HelperTestBase.Model_GVL.GVL_T24;

                HelperTestBase.Model_GVL = _modelGVL;

                #endregion

            }
            catch (Exception ex)
            {
                var err = ex.Message;
                throw;
            }

            return _modelGVL;

            #endregion
        }

        #endregion

        #endregion

        #endregion

        #region CHARTS

        ToolTip tooltip = new ToolTip();
        private Random rnd = new Random();

        #region Chart_Validate
        public void ClearArrayGVL_Graficos()
        {
            Array.Clear(GVL_Graficos.arrVarX, 0, GVL_Graficos.arrVarX.Length);
            Array.Clear(GVL_Graficos.arrVarY1, 0, GVL_Graficos.arrVarY1.Length);
            Array.Clear(GVL_Graficos.arrVarY2, 0, GVL_Graficos.arrVarY2.Length);
            Array.Clear(GVL_Graficos.arrVarY3, 0, GVL_Graficos.arrVarY3.Length);
            Array.Clear(GVL_Graficos.arrVarY4, 0, GVL_Graficos.arrVarY4.Length);
            Array.Clear(GVL_Graficos.arrVarY5, 0, GVL_Graficos.arrVarY5.Length);

            //Points Grafico
            GVL_Graficos.lstMarkedPoint_Name.Clear();
            GVL_Graficos.lstMarkedPoint_X.Clear();
            GVL_Graficos.lstMarkedPoint_Y.Clear();
            GVL_Graficos.dictXMarkedPoint.Clear();
            GVL_Graficos.dictYMarkedPoint.Clear();
        }
        public GVL_Graficos ChartValidate(int uiTesteSelecionado, int iOutput, List<ActuationParameters_EvaluationParameters> lstInfoEvaluationParameters = null)
        {
            try
            {
                if (lstInfoEvaluationParameters != null)
                {
                    if (uiTesteSelecionado > 0)
                    {
                        GVL_Graficos.iOutput = iOutput;

                        GVL_Graficos.bResetEixos = true;
                        GVL_Graficos.uiTesteSelecionado = uiTesteSelecionado;

                        switch (uiTesteSelecionado)
                        {
                            case 1:     //Force Diagrams - Force/Pressure With Vacuum
                            case 3:     //Force Diagrams - Force/Pressure Without Vacuum
                            case 25:    //Force Diagrams - Force/Pressure Dual Ratio
                                {
                                    GVL_Graficos.EixoX.wsTLLabel = "AxesChart.1";
                                    GVL_Graficos.rEscalaX = lstInfoEvaluationParameters != null ?
                                        lstInfoEvaluationParameters.Where(x => x.EvalParam_Name.Equals("EForceScale")).Select(x => x.EvalParam_Hi).FirstOrDefault()
                                        : 1500;

                                    GVL_Graficos.EixoY1.wsTLLabel = "AxesChart.2";
                                    GVL_Graficos.rEscalaY1 = lstInfoEvaluationParameters != null ?
                                        lstInfoEvaluationParameters.Where(x => x.EvalParam_Name.Equals("EPressureScale")).Select(x => x.EvalParam_Hi).FirstOrDefault()
                                        : 100;

                                    GVL_Graficos.EixoY2.wsTLLabel = "AxesChart.3";
                                    GVL_Graficos.rEscalaY2 = lstInfoEvaluationParameters != null ?
                                        lstInfoEvaluationParameters.Where(x => x.EvalParam_Name.Equals("EPressureScale")).Select(x => x.EvalParam_Hi).FirstOrDefault()
                                        : 100;

                                    GVL_Graficos.EixoY3.wsTLLabel = string.Empty;
                                    GVL_Graficos.rEscalaY3 = 0;

                                    GVL_Graficos.EixoY4.wsTLLabel = string.Empty;
                                    GVL_Graficos.rEscalaY4 = 0;

                                    var unitX = lstInfoEvaluationParameters != null ?
                                        !string.IsNullOrEmpty(lstInfoEvaluationParameters.Where(x => x.EvalParam_Name.Equals("EForceScale")).Select(x => x.EvalParam_Mksunit).FirstOrDefault()) ?
                                        lstInfoEvaluationParameters.Where(x => x.EvalParam_Name.Equals("EForceScale")).Select(x => x.EvalParam_Mksunit).FirstOrDefault()
                                        : "N"
                                        : "N";

                                    var unitY1 = lstInfoEvaluationParameters != null ?
                                        !string.IsNullOrEmpty(lstInfoEvaluationParameters.Where(x => x.EvalParam_Name.Equals("EPressureScale")).Select(x => x.EvalParam_Mksunit).FirstOrDefault()) ?
                                        lstInfoEvaluationParameters.Where(x => x.EvalParam_Name.Equals("EPressureScale")).Select(x => x.EvalParam_Mksunit).FirstOrDefault()
                                        : "bar"
                                        : "bar";

                                    var unitY2 = lstInfoEvaluationParameters != null ?
                                        !string.IsNullOrEmpty(lstInfoEvaluationParameters.Where(x => x.EvalParam_Name.Equals("EPressureScale")).Select(x => x.EvalParam_Mksunit).FirstOrDefault()) ?
                                        lstInfoEvaluationParameters.Where(x => x.EvalParam_Name.Equals("EPressureScale")).Select(x => x.EvalParam_Mksunit).FirstOrDefault()
                                        : "bar"
                                        : "bar";

                                    GVL_Graficos.strNomeEixoX = string.Concat("Input Force", " ", unitX);
                                    GVL_Graficos.strNomeEixoY1 = GVL_Graficos.iOutput == 2 ? string.Concat("Pressure SC", " ", unitY2) : string.Concat("Pressure PC", " ", unitY1);
                                    GVL_Graficos.strNomeEixoY2 = string.Concat("Pressure SC", " ", unitY2);
                                    GVL_Graficos.strNomeEixoY3 = string.Empty;
                                    GVL_Graficos.strNomeEixoY4 = string.Empty;

                                    GVL_Graficos.strUnidadeX = unitX;
                                    GVL_Graficos.strUnidadeY1 = unitY1;
                                    GVL_Graficos.strUnidadeY2 = unitY2;
                                    GVL_Graficos.strUnidadeY3 = string.Empty;
                                    GVL_Graficos.strUnidadeY4 = string.Empty;

                                    GVL_Graficos.bOcultaY2 = GVL_Graficos.iOutput > 0 ? true : false;
                                    GVL_Graficos.bOcultaY3 = true;
                                    GVL_Graficos.bOcultaY4 = true;



                                    break;
                                }
                            case 2:     //Force Diagrams - Force/Force With Vacuum
                            case 4:     //Force Diagrams - Force/Force Without Vacuum
                            case 26:    //Force Diagrams - Force/Force Dual Ratio
                                {
                                    GVL_Graficos.EixoX.wsTLLabel = "AxesChart.1";
                                    GVL_Graficos.rEscalaX = lstInfoEvaluationParameters != null ?
                                        lstInfoEvaluationParameters.Where(x => x.EvalParam_Name.Equals("EForceScaleI")).Select(x => x.EvalParam_Hi).FirstOrDefault()
                                        : 1500;

                                    GVL_Graficos.EixoY1.wsTLLabel = "AxesChart.2";
                                    GVL_Graficos.rEscalaY1 = lstInfoEvaluationParameters != null ?
                                        lstInfoEvaluationParameters.Where(x => x.EvalParam_Name.Equals("EForceScaleO")).Select(x => x.EvalParam_Hi).FirstOrDefault()
                                        : 5000;

                                    GVL_Graficos.EixoY2.wsTLLabel = string.Empty;
                                    GVL_Graficos.rEscalaY2 = 0;

                                    GVL_Graficos.EixoY3.wsTLLabel = string.Empty;
                                    GVL_Graficos.rEscalaY3 = 0;

                                    GVL_Graficos.EixoY4.wsTLLabel = string.Empty;
                                    GVL_Graficos.rEscalaY4 = 0;

                                    var unitX = lstInfoEvaluationParameters != null ?
                                        !string.IsNullOrEmpty(lstInfoEvaluationParameters.Where(x => x.EvalParam_Name.Equals("EForceScaleI")).Select(x => x.EvalParam_Mksunit).FirstOrDefault()) ?
                                        lstInfoEvaluationParameters.Where(x => x.EvalParam_Name.Equals("EForceScaleI")).Select(x => x.EvalParam_Mksunit).FirstOrDefault()
                                        : "N"
                                        : "N";

                                    var unitY1 = lstInfoEvaluationParameters != null ?
                                        !string.IsNullOrEmpty(lstInfoEvaluationParameters.Where(x => x.EvalParam_Name.Equals("EForceScaleO")).Select(x => x.EvalParam_Mksunit).FirstOrDefault()) ?
                                        lstInfoEvaluationParameters.Where(x => x.EvalParam_Name.Equals("EForceScaleO")).Select(x => x.EvalParam_Mksunit).FirstOrDefault()
                                        : "N"
                                        : "N";

                                    GVL_Graficos.strNomeEixoX = string.Concat("Input Force", " ", unitX);
                                    GVL_Graficos.strNomeEixoY1 = string.Concat("Output Force", " ", unitY1);
                                    GVL_Graficos.strNomeEixoY2 = string.Empty;
                                    GVL_Graficos.strNomeEixoY3 = string.Empty;
                                    GVL_Graficos.strNomeEixoY4 = string.Empty;

                                    GVL_Graficos.strUnidadeX = unitX;
                                    GVL_Graficos.strUnidadeY1 = unitY1;
                                    GVL_Graficos.strUnidadeY2 = string.Empty;
                                    GVL_Graficos.strUnidadeY3 = string.Empty;
                                    GVL_Graficos.strUnidadeY4 = string.Empty;

                                    GVL_Graficos.bOcultaY2 = true;
                                    GVL_Graficos.bOcultaY3 = true;
                                    GVL_Graficos.bOcultaY4 = true;

                                    break;
                                }
                            case 5:     //Vacuum Leakage - Released Position
                            case 6:     //Vacuum Leakage - Fully Applied Position
                            case 7:     //Vacuum Leakage - Lap Position
                                {
                                    GVL_Graficos.EixoX.wsTLLabel = "AxesChart.1";
                                    GVL_Graficos.rEscalaX = lstInfoEvaluationParameters != null ?
                                        lstInfoEvaluationParameters.Where(x => x.EvalParam_Name.Equals("ETimeScale")).Select(x => x.EvalParam_Hi).FirstOrDefault()
                                        : 30;

                                    GVL_Graficos.EixoY1.wsTLLabel = "AxesChart.2";
                                    GVL_Graficos.rEscalaY1 = lstInfoEvaluationParameters != null ?
                                        lstInfoEvaluationParameters.Where(x => x.EvalParam_Name.Equals("EVacuumScale")).Select(x => x.EvalParam_Hi).FirstOrDefault()
                                        : -1;

                                    GVL_Graficos.EixoY2.wsTLLabel = string.Empty;
                                    GVL_Graficos.rEscalaY2 = 0;

                                    GVL_Graficos.EixoY3.wsTLLabel = string.Empty;
                                    GVL_Graficos.rEscalaY3 = 0;

                                    GVL_Graficos.EixoY4.wsTLLabel = string.Empty;
                                    GVL_Graficos.rEscalaY4 = 0;

                                    var unitX = lstInfoEvaluationParameters != null ?
                                        !string.IsNullOrEmpty(lstInfoEvaluationParameters.Where(x => x.EvalParam_Name.Equals("ETimeScale")).Select(x => x.EvalParam_Mksunit).FirstOrDefault()) ?
                                        lstInfoEvaluationParameters.Where(x => x.EvalParam_Name.Equals("ETimeScale")).Select(x => x.EvalParam_Mksunit).FirstOrDefault()
                                        : "s"
                                        : "s";

                                    var unitY1 = lstInfoEvaluationParameters != null ?
                                        !string.IsNullOrEmpty(lstInfoEvaluationParameters.Where(x => x.EvalParam_Name.Equals("EVacuumScale")).Select(x => x.EvalParam_Mksunit).FirstOrDefault()) ?
                                        lstInfoEvaluationParameters.Where(x => x.EvalParam_Name.Equals("EVacuumScale")).Select(x => x.EvalParam_Mksunit).FirstOrDefault()
                                        : "bar"
                                        : "bar";

                                    GVL_Graficos.strNomeEixoX = string.Concat("Time", " ", unitX);
                                    GVL_Graficos.strNomeEixoY1 = string.Concat("Vacuum", " ", unitY1);
                                    GVL_Graficos.strNomeEixoY2 = string.Empty;
                                    GVL_Graficos.strNomeEixoY3 = string.Empty;
                                    GVL_Graficos.strNomeEixoY4 = string.Empty;

                                    GVL_Graficos.strUnidadeX = unitX;
                                    GVL_Graficos.strUnidadeY1 = unitY1;
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
                                    GVL_Graficos.EixoX.wsTLLabel = "AxesChart.1";
                                    GVL_Graficos.rEscalaX = lstInfoEvaluationParameters != null ?
                                        lstInfoEvaluationParameters.Where(x => x.EvalParam_Name.Equals("ETimeScale")).Select(x => x.EvalParam_Hi).FirstOrDefault()
                                        : 30;

                                    GVL_Graficos.EixoY1.wsTLLabel = "AxesChart.2";
                                    GVL_Graficos.rEscalaY1 = lstInfoEvaluationParameters != null ?
                                        lstInfoEvaluationParameters.Where(x => x.EvalParam_Name.Equals("EVacuumScale")).Select(x => x.EvalParam_Hi).FirstOrDefault()
                                        : -1;

                                    GVL_Graficos.EixoY2.wsTLLabel = "AxesChart.3";
                                    GVL_Graficos.rEscalaY2 = lstInfoEvaluationParameters != null ?
                                        lstInfoEvaluationParameters.Where(x => x.EvalParam_Name.Equals("EPressureScale")).Select(x => x.EvalParam_Hi).FirstOrDefault()
                                        : 100;

                                    GVL_Graficos.EixoY3.wsTLLabel = "AxesChart.4";
                                    GVL_Graficos.rEscalaY3 = lstInfoEvaluationParameters != null ?
                                        lstInfoEvaluationParameters.Where(x => x.EvalParam_Name.Equals("EPressureScale")).Select(x => x.EvalParam_Hi).FirstOrDefault()
                                        : 100;

                                    GVL_Graficos.EixoY4.wsTLLabel = "AxesChart.5";
                                    GVL_Graficos.rEscalaY4 = lstInfoEvaluationParameters != null ?
                                        lstInfoEvaluationParameters.Where(x => x.EvalParam_Name.Equals("ETravelScale")).Select(x => x.EvalParam_Hi).FirstOrDefault()
                                        : 50;

                                    var unitX = lstInfoEvaluationParameters != null ?
                                        !string.IsNullOrEmpty(lstInfoEvaluationParameters.Where(x => x.EvalParam_Name.Equals("ETimeScale")).Select(x => x.EvalParam_Mksunit).FirstOrDefault()) ?
                                        lstInfoEvaluationParameters.Where(x => x.EvalParam_Name.Equals("ETimeScale")).Select(x => x.EvalParam_Mksunit).FirstOrDefault()
                                        : "s"
                                        : "s";

                                    var unitY1 = lstInfoEvaluationParameters != null ?
                                        !string.IsNullOrEmpty(lstInfoEvaluationParameters.Where(x => x.EvalParam_Name.Equals("EVacuumScale")).Select(x => x.EvalParam_Mksunit).FirstOrDefault()) ?
                                        lstInfoEvaluationParameters.Where(x => x.EvalParam_Name.Equals("EVacuumScale")).Select(x => x.EvalParam_Mksunit).FirstOrDefault()
                                        : "bar"
                                        : "bar";

                                    var unitY2 = lstInfoEvaluationParameters != null ?
                                        !string.IsNullOrEmpty(lstInfoEvaluationParameters.Where(x => x.EvalParam_Name.Equals("EPressureScale")).Select(x => x.EvalParam_Mksunit).FirstOrDefault()) ?
                                        lstInfoEvaluationParameters.Where(x => x.EvalParam_Name.Equals("EPressureScale")).Select(x => x.EvalParam_Mksunit).FirstOrDefault()
                                        : "bar"
                                        : "bar";

                                    var unitY3 = lstInfoEvaluationParameters != null ?
                                        !string.IsNullOrEmpty(lstInfoEvaluationParameters.Where(x => x.EvalParam_Name.Equals("EPressureScale")).Select(x => x.EvalParam_Mksunit).FirstOrDefault()) ?
                                        lstInfoEvaluationParameters.Where(x => x.EvalParam_Name.Equals("EPressureScale")).Select(x => x.EvalParam_Mksunit).FirstOrDefault()
                                        : "bar"
                                        : "bar";

                                    var unitY4 = lstInfoEvaluationParameters != null ?
                                        !string.IsNullOrEmpty(lstInfoEvaluationParameters.Where(x => x.EvalParam_Name.Equals("ETravelScale")).Select(x => x.EvalParam_Mksunit).FirstOrDefault()) ?
                                        lstInfoEvaluationParameters.Where(x => x.EvalParam_Name.Equals("ETravelScale")).Select(x => x.EvalParam_Mksunit).FirstOrDefault()
                                        : "mm"
                                        : "mm";

                                    GVL_Graficos.strNomeEixoX = string.Concat("Time", " ", unitX);
                                    GVL_Graficos.strNomeEixoY1 = string.Concat("Vacuum", " ", unitY1);
                                    GVL_Graficos.strNomeEixoY2 = string.Concat("Pressure PC", " ", unitY2);
                                    GVL_Graficos.strNomeEixoY3 = string.Concat("Pressure SC", " ", unitY3);
                                    GVL_Graficos.strNomeEixoY4 = string.Concat("Piston Travel", " ", unitY4);

                                    GVL_Graficos.strUnidadeX = unitX;
                                    GVL_Graficos.strUnidadeY1 = unitY1;
                                    GVL_Graficos.strUnidadeY2 = unitY2;
                                    GVL_Graficos.strUnidadeY3 = unitY3;
                                    GVL_Graficos.strUnidadeY4 = unitY4;

                                    GVL_Graficos.bOcultaY2 = false;
                                    GVL_Graficos.bOcultaY3 = false;
                                    GVL_Graficos.bOcultaY4 = false;

                                    break;
                                }
                            case 11:    //Adjustment - Actuation Slow
                            case 12:    //Adjustment - Actuation Fast
                                {
                                    GVL_Graficos.EixoX.wsTLLabel = "AxesChart.1";
                                    GVL_Graficos.rEscalaX = lstInfoEvaluationParameters != null ?
                                        lstInfoEvaluationParameters.Where(x => x.EvalParam_Name.Equals("EScaleTime")).Select(x => x.EvalParam_Hi).FirstOrDefault()
                                        : 30;

                                    GVL_Graficos.EixoY1.wsTLLabel = "AxesChart.2";
                                    GVL_Graficos.rEscalaY1 = lstInfoEvaluationParameters != null ?
                                        lstInfoEvaluationParameters.Where(x => x.EvalParam_Name.Equals("EScaleForce")).Select(x => x.EvalParam_Hi).FirstOrDefault()
                                        : 1500;

                                    GVL_Graficos.EixoY2.wsTLLabel = string.Empty;
                                    GVL_Graficos.rEscalaY2 = 0;

                                    GVL_Graficos.EixoY3.wsTLLabel = string.Empty;
                                    GVL_Graficos.rEscalaY3 = 0;

                                    GVL_Graficos.EixoY4.wsTLLabel = string.Empty;
                                    GVL_Graficos.rEscalaY4 = 0;

                                    var unitX = lstInfoEvaluationParameters != null ?
                                        !string.IsNullOrEmpty(lstInfoEvaluationParameters.Where(x => x.EvalParam_Name.Equals("EScaleTime")).Select(x => x.EvalParam_Mksunit).FirstOrDefault()) ?
                                        lstInfoEvaluationParameters.Where(x => x.EvalParam_Name.Equals("EScaleTime")).Select(x => x.EvalParam_Mksunit).FirstOrDefault()
                                        : "s"
                                        : "s";

                                    var unitY1 = lstInfoEvaluationParameters != null ?
                                        !string.IsNullOrEmpty(lstInfoEvaluationParameters.Where(x => x.EvalParam_Name.Equals("EScaleForce")).Select(x => x.EvalParam_Mksunit).FirstOrDefault()) ?
                                        lstInfoEvaluationParameters.Where(x => x.EvalParam_Name.Equals("EScaleForce")).Select(x => x.EvalParam_Mksunit).FirstOrDefault()
                                        : "N"
                                        : "N";

                                    GVL_Graficos.strNomeEixoX = string.Concat("Time", " ", unitX);
                                    GVL_Graficos.strNomeEixoY1 = string.Concat("Input Force", " ", unitY1);
                                    GVL_Graficos.strNomeEixoY2 = string.Empty;
                                    GVL_Graficos.strNomeEixoY3 = string.Empty;
                                    GVL_Graficos.strNomeEixoY4 = string.Empty;

                                    GVL_Graficos.strUnidadeX = unitX;
                                    GVL_Graficos.strUnidadeY1 = unitY1;
                                    GVL_Graficos.strUnidadeY2 = string.Empty;
                                    GVL_Graficos.strUnidadeY3 = string.Empty;
                                    GVL_Graficos.strUnidadeY4 = string.Empty;

                                    GVL_Graficos.bOcultaY2 = true;
                                    GVL_Graficos.bOcultaY3 = true;
                                    GVL_Graficos.bOcultaY4 = true;

                                    break;
                                }
                            case 13:    //Check Sensors - Pressure Difference
                                {
                                    GVL_Graficos.EixoX.wsTLLabel = "AxesChart.1";
                                    GVL_Graficos.rEscalaX = lstInfoEvaluationParameters != null ?
                                        lstInfoEvaluationParameters.Where(x => x.EvalParam_Name.Equals("EIForceScale")).Select(x => x.EvalParam_Hi).FirstOrDefault()
                                        : 1500;

                                    GVL_Graficos.EixoY1.wsTLLabel = "AxesChart.2";
                                    GVL_Graficos.rEscalaY1 = lstInfoEvaluationParameters != null ?
                                        lstInfoEvaluationParameters.Where(x => x.EvalParam_Name.Equals("EOPressScale")).Select(x => x.EvalParam_Hi).FirstOrDefault()
                                        : 100;

                                    GVL_Graficos.EixoY2.wsTLLabel = "AxesChart.3";
                                    GVL_Graficos.rEscalaY2 = lstInfoEvaluationParameters != null ?
                                        lstInfoEvaluationParameters.Where(x => x.EvalParam_Name.Equals("EOPressScale")).Select(x => x.EvalParam_Hi).FirstOrDefault()
                                        : 100;

                                    GVL_Graficos.EixoY3.wsTLLabel = string.Empty;
                                    GVL_Graficos.rEscalaY3 = 0;

                                    GVL_Graficos.EixoY4.wsTLLabel = string.Empty;
                                    GVL_Graficos.rEscalaY4 = 0;

                                    var unitX = lstInfoEvaluationParameters != null ?
                                        !string.IsNullOrEmpty(lstInfoEvaluationParameters.Where(x => x.EvalParam_Name.Equals("EIForceScale")).Select(x => x.EvalParam_Mksunit).FirstOrDefault()) ?
                                        lstInfoEvaluationParameters.Where(x => x.EvalParam_Name.Equals("EIForceScale")).Select(x => x.EvalParam_Mksunit).FirstOrDefault()
                                        : "N"
                                        : "N";

                                    var unitY1 = lstInfoEvaluationParameters != null ?
                                        !string.IsNullOrEmpty(lstInfoEvaluationParameters.Where(x => x.EvalParam_Name.Equals("EOPressScale")).Select(x => x.EvalParam_Mksunit).FirstOrDefault()) ?
                                        lstInfoEvaluationParameters.Where(x => x.EvalParam_Name.Equals("EOPressScale")).Select(x => x.EvalParam_Mksunit).FirstOrDefault()
                                        : "bar"
                                        : "bar";

                                    var unitY2 = lstInfoEvaluationParameters != null ?
                                        !string.IsNullOrEmpty(lstInfoEvaluationParameters.Where(x => x.EvalParam_Name.Equals("EOPressScale")).Select(x => x.EvalParam_Mksunit).FirstOrDefault()) ?
                                        lstInfoEvaluationParameters.Where(x => x.EvalParam_Name.Equals("EOPressScale")).Select(x => x.EvalParam_Mksunit).FirstOrDefault()
                                        : "bar"
                                        : "bar";

                                    GVL_Graficos.strNomeEixoX = string.Concat("Input Force", " ", unitX);
                                    GVL_Graficos.strNomeEixoY1 = string.Concat("Pressure PC", " ", unitY1);
                                    GVL_Graficos.strNomeEixoY2 = string.Concat("Pressure SC", " ", unitY2);
                                    GVL_Graficos.strNomeEixoY3 = string.Empty;
                                    GVL_Graficos.strNomeEixoY4 = string.Empty;

                                    GVL_Graficos.strUnidadeX = unitX;
                                    GVL_Graficos.strUnidadeY1 = unitY1;
                                    GVL_Graficos.strUnidadeY2 = unitY2;
                                    GVL_Graficos.strUnidadeY3 = string.Empty;
                                    GVL_Graficos.strUnidadeY4 = string.Empty;

                                    GVL_Graficos.bOcultaY2 = false;
                                    GVL_Graficos.bOcultaY3 = true;
                                    GVL_Graficos.bOcultaY4 = true;

                                    break;
                                }
                            case 14:    //Check Sensors - Input/Output Travel
                                {
                                    GVL_Graficos.EixoX.wsTLLabel = "AxesChart.1";
                                    GVL_Graficos.rEscalaX = lstInfoEvaluationParameters != null ?
                                        lstInfoEvaluationParameters.Where(x => x.EvalParam_Name.Equals("EITravelScale")).Select(x => x.EvalParam_Hi).FirstOrDefault()
                                        : 50;

                                    GVL_Graficos.EixoY1.wsTLLabel = "AxesChart.2";
                                    GVL_Graficos.rEscalaY1 = lstInfoEvaluationParameters != null ?
                                        lstInfoEvaluationParameters.Where(x => x.EvalParam_Name.Equals("EOTravelScale")).Select(x => x.EvalParam_Hi).FirstOrDefault()
                                        : 50;

                                    GVL_Graficos.EixoY2.wsTLLabel = string.Empty;
                                    GVL_Graficos.rEscalaY2 = 0;

                                    GVL_Graficos.EixoY3.wsTLLabel = string.Empty;
                                    GVL_Graficos.rEscalaY3 = 0;

                                    GVL_Graficos.EixoY4.wsTLLabel = string.Empty;
                                    GVL_Graficos.rEscalaY4 = 0;

                                    var unitX = lstInfoEvaluationParameters != null ?
                                        !string.IsNullOrEmpty(lstInfoEvaluationParameters.Where(x => x.EvalParam_Name.Equals("EITravelScale")).Select(x => x.EvalParam_Mksunit).FirstOrDefault()) ?
                                        lstInfoEvaluationParameters.Where(x => x.EvalParam_Name.Equals("EITravelScale")).Select(x => x.EvalParam_Mksunit).FirstOrDefault()
                                        : "(mm)"
                                        : "(mm)";

                                    var unitY1 = lstInfoEvaluationParameters != null ?
                                        !string.IsNullOrEmpty(lstInfoEvaluationParameters.Where(x => x.EvalParam_Name.Equals("EOTravelScale")).Select(x => x.EvalParam_Mksunit).FirstOrDefault()) ?
                                        lstInfoEvaluationParameters.Where(x => x.EvalParam_Name.Equals("EOTravelScale")).Select(x => x.EvalParam_Mksunit).FirstOrDefault()
                                        : "(mm)"
                                        : "(mm)";

                                    GVL_Graficos.strNomeEixoX = string.Concat("Piston Travel", " ", unitX);
                                    GVL_Graficos.strNomeEixoY1 = string.Concat("TMC Travel", " ", unitY1);
                                    GVL_Graficos.strNomeEixoY2 = string.Empty;
                                    GVL_Graficos.strNomeEixoY3 = string.Empty;
                                    GVL_Graficos.strNomeEixoY4 = string.Empty;

                                    GVL_Graficos.strUnidadeX = unitX;
                                    GVL_Graficos.strUnidadeY1 = unitY1;
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
                                    GVL_Graficos.EixoX.wsTLLabel = "AxesChart.1";
                                    GVL_Graficos.rEscalaX = lstInfoEvaluationParameters != null ?
                                        lstInfoEvaluationParameters.Where(x => x.EvalParam_Name.Equals("EScaleForce")).Select(x => x.EvalParam_Hi).FirstOrDefault()
                                        : 1500;

                                    GVL_Graficos.EixoY1.wsTLLabel = "AxesChart.2";
                                    GVL_Graficos.rEscalaY1 = lstInfoEvaluationParameters != null ?
                                        lstInfoEvaluationParameters.Where(x => x.EvalParam_Name.Equals("EScaleTravel")).Select(x => x.EvalParam_Hi).FirstOrDefault()
                                        : 50;

                                    GVL_Graficos.EixoY2.wsTLLabel = string.Empty;
                                    GVL_Graficos.rEscalaY2 = 0;

                                    GVL_Graficos.EixoY3.wsTLLabel = string.Empty;
                                    GVL_Graficos.rEscalaY3 = 0;

                                    GVL_Graficos.EixoY4.wsTLLabel = string.Empty;
                                    GVL_Graficos.rEscalaY4 = 0;

                                    var unitX = lstInfoEvaluationParameters != null ?
                                        !string.IsNullOrEmpty(lstInfoEvaluationParameters.Where(x => x.EvalParam_Name.Equals("EScaleForce")).Select(x => x.EvalParam_Mksunit).FirstOrDefault()) ?
                                        lstInfoEvaluationParameters.Where(x => x.EvalParam_Name.Equals("EScaleForce")).Select(x => x.EvalParam_Mksunit).FirstOrDefault()
                                        : "(N)"
                                        : "(N)";

                                    var unitY1 = lstInfoEvaluationParameters != null ?
                                        !string.IsNullOrEmpty(lstInfoEvaluationParameters.Where(x => x.EvalParam_Name.Equals("EScaleTravel")).Select(x => x.EvalParam_Mksunit).FirstOrDefault()) ?
                                        lstInfoEvaluationParameters.Where(x => x.EvalParam_Name.Equals("EScaleTravel")).Select(x => x.EvalParam_Mksunit).FirstOrDefault()
                                        : "(mm)"
                                        : "(mm)";

                                    GVL_Graficos.strNomeEixoX = string.Concat("Input Force", " ", unitX);
                                    GVL_Graficos.strNomeEixoY1 = string.Concat("Piston Travel", " ", unitY1);
                                    GVL_Graficos.strNomeEixoY2 = string.Empty;
                                    GVL_Graficos.strNomeEixoY3 = string.Empty;
                                    GVL_Graficos.strNomeEixoY4 = string.Empty;

                                    GVL_Graficos.strUnidadeX = unitX;
                                    GVL_Graficos.strUnidadeY1 = unitY1;
                                    GVL_Graficos.strUnidadeY2 = string.Empty;
                                    GVL_Graficos.strUnidadeY3 = string.Empty;
                                    GVL_Graficos.strUnidadeY4 = string.Empty;

                                    GVL_Graficos.bOcultaY2 = true;
                                    GVL_Graficos.bOcultaY3 = true;
                                    GVL_Graficos.bOcultaY4 = true;

                                    break;
                                }
                            case 16:    //Adjustment - Hose Consumer
                                {
                                    GVL_Graficos.EixoX.wsTLLabel = "AxesChart.1";
                                    GVL_Graficos.rEscalaX = lstInfoEvaluationParameters != null ?
                                        lstInfoEvaluationParameters.Where(x => x.EvalParam_Name.Equals("EScaleTravel")).Select(x => x.EvalParam_Hi).FirstOrDefault()
                                        : 50;

                                    GVL_Graficos.EixoY1.wsTLLabel = "AxesChart.2";
                                    GVL_Graficos.rEscalaY1 = lstInfoEvaluationParameters != null ?
                                        lstInfoEvaluationParameters.Where(x => x.EvalParam_Name.Equals("EScalePressure")).Select(x => x.EvalParam_Hi).FirstOrDefault()
                                        : 100;

                                    GVL_Graficos.EixoY2.wsTLLabel = "AxesChart.3";
                                    GVL_Graficos.rEscalaY2 = lstInfoEvaluationParameters != null ?
                                        lstInfoEvaluationParameters.Where(x => x.EvalParam_Name.Equals("EScalePressure")).Select(x => x.EvalParam_Hi).FirstOrDefault()
                                        : 100;

                                    GVL_Graficos.EixoY3.wsTLLabel = string.Empty;
                                    GVL_Graficos.rEscalaY3 = 0;

                                    GVL_Graficos.EixoY4.wsTLLabel = string.Empty;
                                    GVL_Graficos.rEscalaY4 = 0;

                                    var unitX = lstInfoEvaluationParameters != null ?
                                        !string.IsNullOrEmpty(lstInfoEvaluationParameters.Where(x => x.EvalParam_Name.Equals("EScaleTravel")).Select(x => x.EvalParam_Mksunit).FirstOrDefault()) ?
                                        lstInfoEvaluationParameters.Where(x => x.EvalParam_Name.Equals("EScaleTravel")).Select(x => x.EvalParam_Mksunit).FirstOrDefault()
                                        : "mm"
                                        : "mm";

                                    var unitY1 = lstInfoEvaluationParameters != null ?
                                        !string.IsNullOrEmpty(lstInfoEvaluationParameters.Where(x => x.EvalParam_Name.Equals("EScalePressure")).Select(x => x.EvalParam_Mksunit).FirstOrDefault()) ?
                                        lstInfoEvaluationParameters.Where(x => x.EvalParam_Name.Equals("EScalePressure")).Select(x => x.EvalParam_Mksunit).FirstOrDefault()
                                        : "bar"
                                        : "bar";

                                    var unitY2 = lstInfoEvaluationParameters != null ?
                                        !string.IsNullOrEmpty(lstInfoEvaluationParameters.Where(x => x.EvalParam_Name.Equals("EScalePressure")).Select(x => x.EvalParam_Mksunit).FirstOrDefault()) ?
                                        lstInfoEvaluationParameters.Where(x => x.EvalParam_Name.Equals("EScalePressure")).Select(x => x.EvalParam_Mksunit).FirstOrDefault()
                                        : "bar"
                                        : "bar";

                                    GVL_Graficos.strNomeEixoX = string.Concat("Piston Travel", " ", unitX);
                                    GVL_Graficos.strNomeEixoY1 = string.Concat("Pressure PC", " ", unitY1);
                                    GVL_Graficos.strNomeEixoY2 = string.Concat("Pressure SC", " ", unitY2);
                                    GVL_Graficos.strNomeEixoY3 = string.Empty;
                                    GVL_Graficos.strNomeEixoY4 = string.Empty;

                                    GVL_Graficos.strUnidadeX = unitX;
                                    GVL_Graficos.strUnidadeY1 = unitY1;
                                    GVL_Graficos.strUnidadeY2 = unitY2;
                                    GVL_Graficos.strUnidadeY3 = string.Empty;
                                    GVL_Graficos.strUnidadeY4 = string.Empty;

                                    GVL_Graficos.bOcultaY2 = false;
                                    GVL_Graficos.bOcultaY3 = true;
                                    GVL_Graficos.bOcultaY4 = true;

                                    break;
                                }
                            case 17:    //Lost Travel ACU - Hydraulic
                            case 18:    //Lost Travel ACU - Hydraulic Electrical Actuation
                                {
                                    GVL_Graficos.EixoX.wsTLLabel = "AxesChart.1";
                                    GVL_Graficos.rEscalaX = lstInfoEvaluationParameters != null ?
                                        lstInfoEvaluationParameters.Where(x => x.EvalParam_Name.Equals("ETravelScale")).Select(x => x.EvalParam_Hi).FirstOrDefault()
                                        : 50;

                                    GVL_Graficos.EixoY1.wsTLLabel = "AxesChart.2";
                                    GVL_Graficos.rEscalaY1 = lstInfoEvaluationParameters != null ?
                                        lstInfoEvaluationParameters.Where(x => x.EvalParam_Name.Equals("EPressScale")).Select(x => x.EvalParam_Hi).FirstOrDefault()
                                        : 100;

                                    GVL_Graficos.EixoY2.wsTLLabel = "AxesChart.3";
                                    GVL_Graficos.rEscalaY2 = lstInfoEvaluationParameters != null ?
                                        lstInfoEvaluationParameters.Where(x => x.EvalParam_Name.Equals("EPressScale")).Select(x => x.EvalParam_Hi).FirstOrDefault()
                                        : 100;

                                    GVL_Graficos.EixoY3.wsTLLabel = string.Empty;
                                    GVL_Graficos.rEscalaY3 = 0;

                                    GVL_Graficos.EixoY4.wsTLLabel = string.Empty;
                                    GVL_Graficos.rEscalaY4 = 0;

                                    var unitX = lstInfoEvaluationParameters != null ?
                                        !string.IsNullOrEmpty(lstInfoEvaluationParameters.Where(x => x.EvalParam_Name.Equals("ETravelScale")).Select(x => x.EvalParam_Mksunit).FirstOrDefault()) ?
                                        lstInfoEvaluationParameters.Where(x => x.EvalParam_Name.Equals("ETravelScale")).Select(x => x.EvalParam_Mksunit).FirstOrDefault()
                                        : "mm"
                                        : "mm";

                                    var unitY1 = lstInfoEvaluationParameters != null ?
                                        !string.IsNullOrEmpty(lstInfoEvaluationParameters.Where(x => x.EvalParam_Name.Equals("EPressScale")).Select(x => x.EvalParam_Mksunit).FirstOrDefault()) ?
                                        lstInfoEvaluationParameters.Where(x => x.EvalParam_Name.Equals("EPressScale")).Select(x => x.EvalParam_Mksunit).FirstOrDefault()
                                        : "bar"
                                        : "bar";

                                    var unitY2 = lstInfoEvaluationParameters != null ?
                                        !string.IsNullOrEmpty(lstInfoEvaluationParameters.Where(x => x.EvalParam_Name.Equals("EPressScale")).Select(x => x.EvalParam_Mksunit).FirstOrDefault()) ?
                                        lstInfoEvaluationParameters.Where(x => x.EvalParam_Name.Equals("EPressScale")).Select(x => x.EvalParam_Mksunit).FirstOrDefault()
                                        : "bar"
                                        : "bar";

                                    GVL_Graficos.strNomeEixoX = string.Concat("Piston Travel", " ", unitX);
                                    GVL_Graficos.strNomeEixoY1 = GVL_Graficos.iOutput == 2 ? string.Concat("Pressure SC", " ", unitY2) : string.Concat("Pressure PC", " ", unitY1);
                                    GVL_Graficos.strNomeEixoY2 = string.Concat("Pressure SC", " ", unitY2);
                                    GVL_Graficos.strNomeEixoY3 = string.Empty;
                                    GVL_Graficos.strNomeEixoY4 = string.Empty;

                                    GVL_Graficos.strUnidadeX = unitX;
                                    GVL_Graficos.strUnidadeY1 = unitY1;
                                    GVL_Graficos.strUnidadeY2 = unitY2;
                                    GVL_Graficos.strUnidadeY3 = string.Empty;
                                    GVL_Graficos.strUnidadeY4 = string.Empty;

                                    GVL_Graficos.bOcultaY2 = GVL_Graficos.iOutput > 0 ? true : false;
                                    GVL_Graficos.bOcultaY3 = true;
                                    GVL_Graficos.bOcultaY4 = true;

                                    break;
                                }
                            case 19:    //Lost Travel ACU - Pneumatic Primary
                            case 20:    //Lost Travel ACU - Pneumatic Secondary
                                {
                                    GVL_Graficos.EixoX.wsTLLabel = "AxesChart.1";
                                    GVL_Graficos.rEscalaX = lstInfoEvaluationParameters != null ?
                                        lstInfoEvaluationParameters.Where(x => x.EvalParam_Name.Equals("ETravelScale")).Select(x => x.EvalParam_Hi).FirstOrDefault()
                                        : 20;

                                    GVL_Graficos.EixoY1.wsTLLabel = "AxesChart.2";
                                    GVL_Graficos.rEscalaY1 = lstInfoEvaluationParameters != null ?
                                        lstInfoEvaluationParameters.Where(x => x.EvalParam_Name.Equals("EPressureScale")).Select(x => x.EvalParam_Hi).FirstOrDefault()
                                        : 1;

                                    GVL_Graficos.EixoY2.wsTLLabel = string.Empty;
                                    GVL_Graficos.rEscalaY2 = 0;

                                    GVL_Graficos.EixoY3.wsTLLabel = string.Empty;
                                    GVL_Graficos.rEscalaY3 = 0;

                                    GVL_Graficos.EixoY4.wsTLLabel = string.Empty;
                                    GVL_Graficos.rEscalaY4 = 0;

                                    var unitX = lstInfoEvaluationParameters != null ?
                                        !string.IsNullOrEmpty(lstInfoEvaluationParameters.Where(x => x.EvalParam_Name.Equals("ETravelScale")).Select(x => x.EvalParam_Mksunit).FirstOrDefault()) ?
                                        lstInfoEvaluationParameters.Where(x => x.EvalParam_Name.Equals("ETravelScale")).Select(x => x.EvalParam_Mksunit).FirstOrDefault()
                                        : "mm"
                                        : "mm";

                                    var unitY1 = lstInfoEvaluationParameters != null ?
                                        !string.IsNullOrEmpty(lstInfoEvaluationParameters.Where(x => x.EvalParam_Name.Equals("EPressureScale")).Select(x => x.EvalParam_Mksunit).FirstOrDefault()) ?
                                        lstInfoEvaluationParameters.Where(x => x.EvalParam_Name.Equals("EPressureScale")).Select(x => x.EvalParam_Mksunit).FirstOrDefault()
                                        : "bar"
                                        : "bar";

                                    GVL_Graficos.strNomeEixoX = string.Concat("Piston Travel", " ", unitX);
                                    GVL_Graficos.strNomeEixoY1 = string.Concat("Test Pressure", " ", unitY1);
                                    GVL_Graficos.strNomeEixoY2 = string.Empty;
                                    GVL_Graficos.strNomeEixoY3 = string.Empty;
                                    GVL_Graficos.strNomeEixoY4 = string.Empty;

                                    GVL_Graficos.strUnidadeX = unitX;
                                    GVL_Graficos.strUnidadeY1 = unitY1;
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
                                    GVL_Graficos.EixoX.wsTLLabel = "AxesChart.1";
                                    GVL_Graficos.rEscalaX = lstInfoEvaluationParameters != null ?
                                        lstInfoEvaluationParameters.Where(x => x.EvalParam_Name.Equals("ETravelScaleHi")).Select(x => x.EvalParam_Hi).FirstOrDefault()
                                        : 50;

                                    GVL_Graficos.EixoY1.wsTLLabel = "AxesChart.2";
                                    GVL_Graficos.rEscalaY1 = lstInfoEvaluationParameters != null ?
                                        lstInfoEvaluationParameters.Where(x => x.EvalParam_Name.Equals("EPressScale")).Select(x => x.EvalParam_Hi).FirstOrDefault()
                                        : 100;

                                    GVL_Graficos.EixoY2.wsTLLabel = "AxesChart.3";
                                    GVL_Graficos.rEscalaY2 = lstInfoEvaluationParameters != null ?
                                        lstInfoEvaluationParameters.Where(x => x.EvalParam_Name.Equals("EForceScale")).Select(x => x.EvalParam_Hi).FirstOrDefault()
                                        : 1500;

                                    GVL_Graficos.EixoY3.wsTLLabel = string.Empty;
                                    GVL_Graficos.rEscalaY3 = 0;

                                    GVL_Graficos.EixoY4.wsTLLabel = string.Empty;
                                    GVL_Graficos.rEscalaY4 = 0;

                                    var unitX = lstInfoEvaluationParameters != null ?
                                        !string.IsNullOrEmpty(lstInfoEvaluationParameters.Where(x => x.EvalParam_Name.Equals("ETravelScaleHi")).Select(x => x.EvalParam_Mksunit).FirstOrDefault()) ?
                                        lstInfoEvaluationParameters.Where(x => x.EvalParam_Name.Equals("ETravelScaleHi")).Select(x => x.EvalParam_Mksunit).FirstOrDefault()
                                        : "mm"
                                        : "mm";

                                    var unitY1 = lstInfoEvaluationParameters != null ?
                                        !string.IsNullOrEmpty(lstInfoEvaluationParameters.Where(x => x.EvalParam_Name.Equals("EPressScale")).Select(x => x.EvalParam_Mksunit).FirstOrDefault()) ?
                                        lstInfoEvaluationParameters.Where(x => x.EvalParam_Name.Equals("EPressScale")).Select(x => x.EvalParam_Mksunit).FirstOrDefault()
                                        : "bar"
                                        : "bar";

                                    var unitY2 = lstInfoEvaluationParameters != null ?
                                        !string.IsNullOrEmpty(lstInfoEvaluationParameters.Where(x => x.EvalParam_Name.Equals("EForceScale")).Select(x => x.EvalParam_Mksunit).FirstOrDefault()) ?
                                        lstInfoEvaluationParameters.Where(x => x.EvalParam_Name.Equals("EForceScale")).Select(x => x.EvalParam_Mksunit).FirstOrDefault()
                                        : "N"
                                        : "N";

                                    GVL_Graficos.strNomeEixoX = string.Concat("Piston Travel", " ", unitX);
                                    GVL_Graficos.strNomeEixoY1 = string.Concat("Pressure PC", " ", unitY1);
                                    GVL_Graficos.strNomeEixoY2 = string.Concat("Input Force", " ", unitY2);
                                    GVL_Graficos.strNomeEixoY3 = string.Empty;
                                    GVL_Graficos.strNomeEixoY4 = string.Empty;

                                    GVL_Graficos.strUnidadeX = unitX;
                                    GVL_Graficos.strUnidadeY1 = unitY1;
                                    GVL_Graficos.strUnidadeY2 = unitY2;
                                    GVL_Graficos.strUnidadeY3 = string.Empty;
                                    GVL_Graficos.strUnidadeY4 = string.Empty;

                                    GVL_Graficos.bOcultaY2 = false;
                                    GVL_Graficos.bOcultaY3 = true;
                                    GVL_Graficos.bOcultaY4 = true;

                                    break;
                                }
                            case 22:    //Actuation / Release - Mechanical Actuation
                                {
                                    GVL_Graficos.EixoX.wsTLLabel = "AxesChart.1";
                                    GVL_Graficos.rEscalaX = lstInfoEvaluationParameters != null ?
                                        lstInfoEvaluationParameters.Where(x => x.EvalParam_Name.Equals("ETimeScale")).Select(x => x.EvalParam_Hi).FirstOrDefault()
                                        : 10;

                                    GVL_Graficos.EixoY1.wsTLLabel = "AxesChart.2";
                                    GVL_Graficos.rEscalaY1 = lstInfoEvaluationParameters != null ?
                                        lstInfoEvaluationParameters.Where(x => x.EvalParam_Name.Equals("EForceScale")).Select(x => x.EvalParam_Hi).FirstOrDefault()
                                        : 2000;

                                    GVL_Graficos.EixoY2.wsTLLabel = "AxesChart.3";
                                    GVL_Graficos.rEscalaY2 = lstInfoEvaluationParameters != null ?
                                        lstInfoEvaluationParameters.Where(x => x.EvalParam_Name.Equals("EPressureScale")).Select(x => x.EvalParam_Hi).FirstOrDefault()
                                        : 100;

                                    GVL_Graficos.EixoY3.wsTLLabel = "AxesChart.4";
                                    GVL_Graficos.rEscalaY3 = lstInfoEvaluationParameters != null ?
                                        lstInfoEvaluationParameters.Where(x => x.EvalParam_Name.Equals("ETravelScale")).Select(x => x.EvalParam_Hi).FirstOrDefault()
                                        : 50;

                                    GVL_Graficos.EixoY4.wsTLLabel = string.Empty;
                                    GVL_Graficos.rEscalaY4 = 0;

                                    var unitX = lstInfoEvaluationParameters != null ?
                                        !string.IsNullOrEmpty(lstInfoEvaluationParameters.Where(x => x.EvalParam_Name.Equals("ETimeScale")).Select(x => x.EvalParam_Mksunit).FirstOrDefault()) ?
                                        lstInfoEvaluationParameters.Where(x => x.EvalParam_Name.Equals("ETimeScale")).Select(x => x.EvalParam_Mksunit).FirstOrDefault()
                                        : "s"
                                        : "s";

                                    var unitY1 = lstInfoEvaluationParameters != null ?
                                        !string.IsNullOrEmpty(lstInfoEvaluationParameters.Where(x => x.EvalParam_Name.Equals("EForceScale")).Select(x => x.EvalParam_Mksunit).FirstOrDefault()) ?
                                        lstInfoEvaluationParameters.Where(x => x.EvalParam_Name.Equals("EForceScale")).Select(x => x.EvalParam_Mksunit).FirstOrDefault()
                                        : "N"
                                        : "N";

                                    var unitY2 = lstInfoEvaluationParameters != null ?
                                        !string.IsNullOrEmpty(lstInfoEvaluationParameters.Where(x => x.EvalParam_Name.Equals("EPressureScale")).Select(x => x.EvalParam_Mksunit).FirstOrDefault()) ?
                                        lstInfoEvaluationParameters.Where(x => x.EvalParam_Name.Equals("EPressureScale")).Select(x => x.EvalParam_Mksunit).FirstOrDefault()
                                        : "bar"
                                        : "bar";

                                    var unitY3 = lstInfoEvaluationParameters != null ?
                                        !string.IsNullOrEmpty(lstInfoEvaluationParameters.Where(x => x.EvalParam_Name.Equals("ETravelScale")).Select(x => x.EvalParam_Mksunit).FirstOrDefault()) ?
                                        lstInfoEvaluationParameters.Where(x => x.EvalParam_Name.Equals("ETravelScale")).Select(x => x.EvalParam_Mksunit).FirstOrDefault()
                                        : "mm"
                                        : "mm";

                                    GVL_Graficos.strNomeEixoX = string.Concat("Time", " ", unitX);
                                    GVL_Graficos.strNomeEixoY1 = string.Concat("Input Force", " ", unitY1);
                                    GVL_Graficos.strNomeEixoY2 = string.Concat("Pressure PC", " ", unitY2);
                                    GVL_Graficos.strNomeEixoY3 = string.Concat("Piston Travel", " ", unitY3);
                                    GVL_Graficos.strNomeEixoY4 = string.Empty;

                                    GVL_Graficos.strUnidadeX = unitX;
                                    GVL_Graficos.strUnidadeY1 = unitY1;
                                    GVL_Graficos.strUnidadeY2 = unitY2;
                                    GVL_Graficos.strUnidadeY3 = unitY3;
                                    GVL_Graficos.strUnidadeY4 = string.Empty;

                                    GVL_Graficos.bOcultaY2 = false;
                                    GVL_Graficos.bOcultaY3 = false;
                                    GVL_Graficos.bOcultaY4 = true;

                                    break;
                                }
                            case 23:    //Breather Hole / Central Valve open
                                {
                                    GVL_Graficos.EixoX.wsTLLabel = "AxesChart.1";
                                    GVL_Graficos.rEscalaX = lstInfoEvaluationParameters != null ?
                                        lstInfoEvaluationParameters.Where(x => x.EvalParam_Name.Equals("ETimeScale")).Select(x => x.EvalParam_Hi).FirstOrDefault()
                                        : 20;

                                    GVL_Graficos.EixoY1.wsTLLabel = "AxesChart.2";
                                    GVL_Graficos.rEscalaY1 = lstInfoEvaluationParameters != null ?
                                        lstInfoEvaluationParameters.Where(x => x.EvalParam_Name.Equals("EHydrFillPressure")).Select(x => x.EvalParam_Hi).FirstOrDefault()
                                        : 2;

                                    GVL_Graficos.EixoY2.wsTLLabel = string.Empty;
                                    GVL_Graficos.rEscalaY2 = 0;

                                    GVL_Graficos.EixoY3.wsTLLabel = string.Empty;
                                    GVL_Graficos.rEscalaY3 = 0;

                                    GVL_Graficos.EixoY4.wsTLLabel = string.Empty;
                                    GVL_Graficos.rEscalaY4 = 0;

                                    var unitX = lstInfoEvaluationParameters != null ?
                                        !string.IsNullOrEmpty(lstInfoEvaluationParameters.Where(x => x.EvalParam_Name.Equals("ETimeScale")).Select(x => x.EvalParam_Mksunit).FirstOrDefault()) ?
                                        lstInfoEvaluationParameters.Where(x => x.EvalParam_Name.Equals("ETimeScale")).Select(x => x.EvalParam_Mksunit).FirstOrDefault()
                                        : "s"
                                        : "s";

                                    var unitY1 = lstInfoEvaluationParameters != null ?
                                        !string.IsNullOrEmpty(lstInfoEvaluationParameters.Where(x => x.EvalParam_Name.Equals("EHydrFillPressure")).Select(x => x.EvalParam_Mksunit).FirstOrDefault()) ?
                                        lstInfoEvaluationParameters.Where(x => x.EvalParam_Name.Equals("EHydrFillPressure")).Select(x => x.EvalParam_Mksunit).FirstOrDefault()
                                        : "bar"
                                        : "bar";

                                    GVL_Graficos.strNomeEixoX = string.Concat("Time", " ", unitX);
                                    GVL_Graficos.strNomeEixoY1 = string.Concat("Hydraulic Fill Pressure", " ", unitY1);
                                    GVL_Graficos.strNomeEixoY2 = string.Empty;
                                    GVL_Graficos.strNomeEixoY3 = string.Empty;
                                    GVL_Graficos.strNomeEixoY4 = string.Empty;

                                    GVL_Graficos.strUnidadeX = unitX;
                                    GVL_Graficos.strUnidadeY1 = unitY1;
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
                                    if (_modelGVL.GVL_Parametros.iTipoGrafico_T24 == 0)
                                    {
                                        GVL_Graficos.EixoX.wsTLLabel = "AxesChart.1";
                                        GVL_Graficos.rEscalaX = lstInfoEvaluationParameters != null ?
                                            lstInfoEvaluationParameters.Where(x => x.EvalParam_Name.Equals("EForceScale")).Select(x => x.EvalParam_Hi).FirstOrDefault()
                                            : 1500;

                                        GVL_Graficos.EixoY1.wsTLLabel = "AxesChart.2";
                                        GVL_Graficos.rEscalaY1 = lstInfoEvaluationParameters != null ?
                                            lstInfoEvaluationParameters.Where(x => x.EvalParam_Name.Equals("EPressureScale")).Select(x => x.EvalParam_Hi).FirstOrDefault()
                                            : 100;

                                        GVL_Graficos.EixoY2.wsTLLabel = "AxesChart.3";
                                        GVL_Graficos.rEscalaY2 = lstInfoEvaluationParameters != null ?
                                            lstInfoEvaluationParameters.Where(x => x.EvalParam_Name.Equals("EPressureScale")).Select(x => x.EvalParam_Hi).FirstOrDefault()
                                            : 100;
                                    }
                                    else
                                    {
                                        GVL_Graficos.EixoX.wsTLLabel = "AxesChart.1";
                                        GVL_Graficos.rEscalaX = lstInfoEvaluationParameters != null ?
                                            lstInfoEvaluationParameters.Where(x => x.EvalParam_Name.Equals("EForceScale")).Select(x => x.EvalParam_Hi).FirstOrDefault()
                                            : 60;

                                        GVL_Graficos.EixoY1.wsTLLabel = "AxesChart.2";
                                        GVL_Graficos.rEscalaY1 = lstInfoEvaluationParameters != null ?
                                            lstInfoEvaluationParameters.Where(x => x.EvalParam_Name.Equals("EPressureScale")).Select(x => x.EvalParam_Hi).FirstOrDefault()
                                            : 100;

                                        GVL_Graficos.EixoY2.wsTLLabel = "AxesChart.3";
                                        GVL_Graficos.rEscalaY2 = lstInfoEvaluationParameters != null ?
                                            lstInfoEvaluationParameters.Where(x => x.EvalParam_Name.Equals("EPressureScale")).Select(x => x.EvalParam_Hi).FirstOrDefault()
                                            : 100;
                                    }

                                    GVL_Graficos.EixoY3.wsTLLabel = string.Empty;
                                    GVL_Graficos.rEscalaY3 = 0;

                                    GVL_Graficos.EixoY4.wsTLLabel = string.Empty;
                                    GVL_Graficos.rEscalaY4 = 0;

                                    var unitX = lstInfoEvaluationParameters != null ?
                                        !string.IsNullOrEmpty(lstInfoEvaluationParameters.Where(x => x.EvalParam_Name.Equals("EForceScale")).Select(x => x.EvalParam_Mksunit).FirstOrDefault()) ?
                                        lstInfoEvaluationParameters.Where(x => x.EvalParam_Name.Equals("EForceScale")).Select(x => x.EvalParam_Mksunit).FirstOrDefault()
                                        : "N"
                                        : "N";

                                    var unitY1 = lstInfoEvaluationParameters != null ?
                                        !string.IsNullOrEmpty(lstInfoEvaluationParameters.Where(x => x.EvalParam_Name.Equals("EPressureScale")).Select(x => x.EvalParam_Mksunit).FirstOrDefault()) ?
                                        lstInfoEvaluationParameters.Where(x => x.EvalParam_Name.Equals("EPressureScale")).Select(x => x.EvalParam_Mksunit).FirstOrDefault()
                                        : "bar"
                                        : "bar";

                                    var unitY2 = lstInfoEvaluationParameters != null ?
                                        !string.IsNullOrEmpty(lstInfoEvaluationParameters.Where(x => x.EvalParam_Name.Equals("EPressureScale")).Select(x => x.EvalParam_Mksunit).FirstOrDefault()) ?
                                        lstInfoEvaluationParameters.Where(x => x.EvalParam_Name.Equals("EPressureScale")).Select(x => x.EvalParam_Mksunit).FirstOrDefault()
                                        : "bar"
                                        : "bar";

                                    GVL_Graficos.strNomeEixoX = string.Concat("Input Force", " ", unitX);
                                    GVL_Graficos.strNomeEixoY1 = string.Concat("Pressure PC", " ", unitY1);
                                    GVL_Graficos.strNomeEixoY2 = string.Concat("Pressure PC", " ", unitY2);
                                    GVL_Graficos.strNomeEixoY3 = string.Empty;
                                    GVL_Graficos.strNomeEixoY4 = string.Empty;

                                    GVL_Graficos.strUnidadeX = unitX;
                                    GVL_Graficos.strUnidadeY1 = unitY1;
                                    GVL_Graficos.strUnidadeY2 = unitY2;
                                    GVL_Graficos.strUnidadeY3 = string.Empty;
                                    GVL_Graficos.strUnidadeY4 = string.Empty;

                                    GVL_Graficos.bOcultaY2 = false;
                                    GVL_Graficos.bOcultaY3 = true;
                                    GVL_Graficos.bOcultaY4 = true;


                                    break;
                                }
                            case 27:    //ADAM - Find Switching Point With TMC
                                {
                                    if (_modelGVL.GVL_Parametros.iTipoGrafico_T27 == 0)
                                    {
                                        GVL_Graficos.EixoX.wsTLLabel = "AxesChart.1";
                                        GVL_Graficos.rEscalaX = lstInfoEvaluationParameters != null ?
                                            lstInfoEvaluationParameters.Where(x => x.EvalParam_Name.Equals("ETravelScale")).Select(x => x.EvalParam_Hi).FirstOrDefault()
                                            : 1500;

                                        GVL_Graficos.EixoY1.wsTLLabel = "AxesChart.2";
                                        GVL_Graficos.rEscalaY1 = lstInfoEvaluationParameters != null ?
                                            lstInfoEvaluationParameters.Where(x => x.EvalParam_Name.Equals("EPressureScale")).Select(x => x.EvalParam_Hi).FirstOrDefault()
                                            : 100;

                                        GVL_Graficos.EixoY2.wsTLLabel = string.Empty;
                                        GVL_Graficos.rEscalaY2 = 0;

                                        GVL_Graficos.EixoY3.wsTLLabel = string.Empty;
                                        GVL_Graficos.rEscalaY3 = 0;

                                        GVL_Graficos.EixoY4.wsTLLabel = string.Empty;
                                        GVL_Graficos.rEscalaY4 = 0;

                                        var unitX = lstInfoEvaluationParameters != null ?
                                            !string.IsNullOrEmpty(lstInfoEvaluationParameters.Where(x => x.EvalParam_Name.Equals("ETravelScale")).Select(x => x.EvalParam_Mksunit).FirstOrDefault()) ?
                                            lstInfoEvaluationParameters.Where(x => x.EvalParam_Name.Equals("ETravelScale")).Select(x => x.EvalParam_Mksunit).FirstOrDefault()
                                            : "N"
                                            : "N";

                                        var unitY1 = lstInfoEvaluationParameters != null ?
                                            !string.IsNullOrEmpty(lstInfoEvaluationParameters.Where(x => x.EvalParam_Name.Equals("EPressureScale")).Select(x => x.EvalParam_Mksunit).FirstOrDefault()) ?
                                            lstInfoEvaluationParameters.Where(x => x.EvalParam_Name.Equals("EPressureScale")).Select(x => x.EvalParam_Mksunit).FirstOrDefault()
                                            : "bar"
                                            : "bar";

                                        GVL_Graficos.strNomeEixoX = string.Concat("Input Force", " ", unitX);
                                        GVL_Graficos.strNomeEixoY1 = string.Concat("Pressure PC", " ", unitY1);
                                        GVL_Graficos.strNomeEixoY2 = string.Empty;
                                        GVL_Graficos.strNomeEixoY3 = string.Empty;
                                        GVL_Graficos.strNomeEixoY4 = string.Empty;

                                        GVL_Graficos.strUnidadeX = unitX;
                                        GVL_Graficos.strUnidadeY1 = unitY1;
                                        GVL_Graficos.strUnidadeY2 = string.Empty;
                                        GVL_Graficos.strUnidadeY3 = string.Empty;
                                        GVL_Graficos.strUnidadeY4 = string.Empty;

                                        GVL_Graficos.bOcultaY2 = false;
                                        GVL_Graficos.bOcultaY3 = true;
                                        GVL_Graficos.bOcultaY4 = true;
                                    }
                                    else
                                    {
                                        GVL_Graficos.EixoX.wsTLLabel = "AxesChart.1";
                                        GVL_Graficos.rEscalaX = lstInfoEvaluationParameters != null ?
                                            lstInfoEvaluationParameters.Where(x => x.EvalParam_Name.Equals("ETestingTime")).Select(x => x.EvalParam_Hi).FirstOrDefault()
                                            : 60;

                                        GVL_Graficos.EixoY1.wsTLLabel = "AxesChart.2";
                                        GVL_Graficos.rEscalaY1 = lstInfoEvaluationParameters != null ?
                                            lstInfoEvaluationParameters.Where(x => x.EvalParam_Name.Equals("EForceScale")).Select(x => x.EvalParam_Hi).FirstOrDefault()
                                            : 1500;

                                        GVL_Graficos.EixoY2.wsTLLabel = "AxesChart.3";
                                        GVL_Graficos.rEscalaY2 = lstInfoEvaluationParameters != null ?
                                            lstInfoEvaluationParameters.Where(x => x.EvalParam_Name.Equals("EPressScale")).Select(x => x.EvalParam_Hi).FirstOrDefault()
                                            : 100;

                                        GVL_Graficos.EixoY3.wsTLLabel = "AxesChart.4";
                                        GVL_Graficos.rEscalaY3 = lstInfoEvaluationParameters != null ?
                                            lstInfoEvaluationParameters.Where(x => x.EvalParam_Name.Equals("ETravelScale")).Select(x => x.EvalParam_Hi).FirstOrDefault()
                                            : 40;

                                        GVL_Graficos.EixoY4.wsTLLabel = "AxesChart.5";
                                        GVL_Graficos.rEscalaY4 = lstInfoEvaluationParameters != null ?
                                            lstInfoEvaluationParameters.Where(x => x.EvalParam_Name.Equals("EDiffTravelScale")).Select(x => x.EvalParam_Hi).FirstOrDefault()
                                            : 10;

                                        var unitX = lstInfoEvaluationParameters != null ?
                                            !string.IsNullOrEmpty(lstInfoEvaluationParameters.Where(x => x.EvalParam_Name.Equals("ETestingTime")).Select(x => x.EvalParam_Mksunit).FirstOrDefault()) ?
                                            lstInfoEvaluationParameters.Where(x => x.EvalParam_Name.Equals("ETestingTime")).Select(x => x.EvalParam_Mksunit).FirstOrDefault()
                                            : "s"
                                            : "s";

                                        var unitY1 = lstInfoEvaluationParameters != null ?
                                            !string.IsNullOrEmpty(lstInfoEvaluationParameters.Where(x => x.EvalParam_Name.Equals("EForceScale")).Select(x => x.EvalParam_Mksunit).FirstOrDefault()) ?
                                            lstInfoEvaluationParameters.Where(x => x.EvalParam_Name.Equals("EForceScale")).Select(x => x.EvalParam_Mksunit).FirstOrDefault()
                                            : "N"
                                            : "N";

                                        var unitY2 = lstInfoEvaluationParameters != null ?
                                            !string.IsNullOrEmpty(lstInfoEvaluationParameters.Where(x => x.EvalParam_Name.Equals("EPressScale")).Select(x => x.EvalParam_Mksunit).FirstOrDefault()) ?
                                            lstInfoEvaluationParameters.Where(x => x.EvalParam_Name.Equals("EPressScale")).Select(x => x.EvalParam_Mksunit).FirstOrDefault()
                                            : "bar"
                                            : "bar";

                                        var unitY3 = lstInfoEvaluationParameters != null ?
                                            !string.IsNullOrEmpty(lstInfoEvaluationParameters.Where(x => x.EvalParam_Name.Equals("ETravelScale")).Select(x => x.EvalParam_Mksunit).FirstOrDefault()) ?
                                            lstInfoEvaluationParameters.Where(x => x.EvalParam_Name.Equals("ETravelScale")).Select(x => x.EvalParam_Mksunit).FirstOrDefault()
                                            : "mm"
                                            : "mm";

                                        var unitY4 = lstInfoEvaluationParameters != null ?
                                            !string.IsNullOrEmpty(lstInfoEvaluationParameters.Where(x => x.EvalParam_Name.Equals("EDiffTravelScale")).Select(x => x.EvalParam_Mksunit).FirstOrDefault()) ?
                                            lstInfoEvaluationParameters.Where(x => x.EvalParam_Name.Equals("EDiffTravelScale")).Select(x => x.EvalParam_Mksunit).FirstOrDefault()
                                            : "mm"
                                            : "mm";

                                        GVL_Graficos.strNomeEixoX = string.Concat("Time", " ", unitX);
                                        GVL_Graficos.strNomeEixoY1 = string.Concat("Input Force", " ", unitY1);
                                        GVL_Graficos.strNomeEixoY2 = string.Concat("Pressure PC", " ", unitY2);
                                        GVL_Graficos.strNomeEixoY3 = string.Concat("Piston Travel", " ", unitY3);
                                        GVL_Graficos.strNomeEixoY4 = string.Concat("Diff. Travel", " ", unitY4);

                                        GVL_Graficos.strUnidadeX = unitX;
                                        GVL_Graficos.strUnidadeY1 = unitY1;
                                        GVL_Graficos.strUnidadeY2 = unitY2;
                                        GVL_Graficos.strUnidadeY3 = unitY3;
                                        GVL_Graficos.strUnidadeY4 = unitY4;
                                    }

                                    break;
                                }
                            case 28:    //ADAM - Switching Point Without TMC
                                {
                                    if (_modelGVL.GVL_Parametros.iTipoGrafico_T27 == 0)
                                    {
                                        GVL_Graficos.EixoX.wsTLLabel = "AxesChart.1";
                                        GVL_Graficos.rEscalaX = lstInfoEvaluationParameters != null ?
                                            lstInfoEvaluationParameters.Where(x => x.EvalParam_Name.Equals("EForceScale")).Select(x => x.EvalParam_Hi).FirstOrDefault()
                                            : 1500;

                                        GVL_Graficos.EixoY1.wsTLLabel = "AxesChart.2";
                                        GVL_Graficos.rEscalaY1 = lstInfoEvaluationParameters != null ?
                                            lstInfoEvaluationParameters.Where(x => x.EvalParam_Name.Equals("EForceScaleO")).Select(x => x.EvalParam_Hi).FirstOrDefault()
                                            : 5000;

                                        GVL_Graficos.EixoY2.wsTLLabel = string.Empty;
                                        GVL_Graficos.rEscalaY2 = 0;

                                        GVL_Graficos.EixoY3.wsTLLabel = string.Empty;
                                        GVL_Graficos.rEscalaY3 = 0;

                                        GVL_Graficos.EixoY4.wsTLLabel = string.Empty;
                                        GVL_Graficos.rEscalaY4 = 0;

                                        var unitX = lstInfoEvaluationParameters != null ?
                                            !string.IsNullOrEmpty(lstInfoEvaluationParameters.Where(x => x.EvalParam_Name.Equals("EForceScale")).Select(x => x.EvalParam_Mksunit).FirstOrDefault()) ?
                                            lstInfoEvaluationParameters.Where(x => x.EvalParam_Name.Equals("EForceScale")).Select(x => x.EvalParam_Mksunit).FirstOrDefault()
                                            : "N"
                                            : "N";

                                        var unitY1 = lstInfoEvaluationParameters != null ?
                                            !string.IsNullOrEmpty(lstInfoEvaluationParameters.Where(x => x.EvalParam_Name.Equals("EForceScaleO")).Select(x => x.EvalParam_Mksunit).FirstOrDefault()) ?
                                            lstInfoEvaluationParameters.Where(x => x.EvalParam_Name.Equals("EForceScaleO")).Select(x => x.EvalParam_Mksunit).FirstOrDefault()
                                            : "N"
                                            : "N";

                                        GVL_Graficos.strNomeEixoX = string.Concat("Input Force", " ", unitX);
                                        GVL_Graficos.strNomeEixoY1 = string.Concat("Output Force", " ", unitY1);
                                        GVL_Graficos.strNomeEixoY2 = string.Empty;
                                        GVL_Graficos.strNomeEixoY3 = string.Empty;
                                        GVL_Graficos.strNomeEixoY4 = string.Empty;

                                        GVL_Graficos.strUnidadeX = unitX;
                                        GVL_Graficos.strUnidadeY1 = unitY1;
                                        GVL_Graficos.strUnidadeY2 = string.Empty;
                                        GVL_Graficos.strUnidadeY3 = string.Empty;
                                        GVL_Graficos.strUnidadeY4 = string.Empty;

                                        GVL_Graficos.bOcultaY2 = true;
                                        GVL_Graficos.bOcultaY3 = true;
                                        GVL_Graficos.bOcultaY4 = true;

                                        break;
                                    }
                                    else
                                    {
                                        GVL_Graficos.EixoX.wsTLLabel = "AxesChart.1";
                                        GVL_Graficos.rEscalaX = lstInfoEvaluationParameters != null ?
                                            lstInfoEvaluationParameters.Where(x => x.EvalParam_Name.Equals("ETestingTime")).Select(x => x.EvalParam_Hi).FirstOrDefault()
                                            : 60;

                                        GVL_Graficos.EixoY1.wsTLLabel = "AxesChart.2";
                                        GVL_Graficos.rEscalaY1 = lstInfoEvaluationParameters != null ?
                                            lstInfoEvaluationParameters.Where(x => x.EvalParam_Name.Equals("EForceScale")).Select(x => x.EvalParam_Hi).FirstOrDefault()
                                            : 1500;

                                        GVL_Graficos.EixoY2.wsTLLabel = "AxesChart.3";
                                        GVL_Graficos.rEscalaY2 = lstInfoEvaluationParameters != null ?
                                            lstInfoEvaluationParameters.Where(x => x.EvalParam_Name.Equals("EPressScale")).Select(x => x.EvalParam_Hi).FirstOrDefault()
                                            : 5000;

                                        GVL_Graficos.EixoY3.wsTLLabel = "AxesChart.4";
                                        GVL_Graficos.rEscalaY3 = lstInfoEvaluationParameters != null ?
                                            lstInfoEvaluationParameters.Where(x => x.EvalParam_Name.Equals("ETravelScale")).Select(x => x.EvalParam_Hi).FirstOrDefault()
                                            : 40;

                                        GVL_Graficos.EixoY4.wsTLLabel = "AxesChart.5";
                                        GVL_Graficos.rEscalaY4 = lstInfoEvaluationParameters != null ?
                                            lstInfoEvaluationParameters.Where(x => x.EvalParam_Name.Equals("EDiffTravelScale")).Select(x => x.EvalParam_Hi).FirstOrDefault()
                                            : 10;

                                        var unitX = lstInfoEvaluationParameters != null ?
                                            !string.IsNullOrEmpty(lstInfoEvaluationParameters.Where(x => x.EvalParam_Name.Equals("ETestingTime")).Select(x => x.EvalParam_Mksunit).FirstOrDefault()) ?
                                            lstInfoEvaluationParameters.Where(x => x.EvalParam_Name.Equals("ETestingTime")).Select(x => x.EvalParam_Mksunit).FirstOrDefault()
                                            : "s"
                                            : "s";

                                        var unitY1 = lstInfoEvaluationParameters != null ?
                                            !string.IsNullOrEmpty(lstInfoEvaluationParameters.Where(x => x.EvalParam_Name.Equals("EForceScale")).Select(x => x.EvalParam_Mksunit).FirstOrDefault()) ?
                                            lstInfoEvaluationParameters.Where(x => x.EvalParam_Name.Equals("EForceScale")).Select(x => x.EvalParam_Mksunit).FirstOrDefault()
                                            : "N"
                                            : "N";

                                        var unitY2 = lstInfoEvaluationParameters != null ?
                                            !string.IsNullOrEmpty(lstInfoEvaluationParameters.Where(x => x.EvalParam_Name.Equals("EPressScale")).Select(x => x.EvalParam_Mksunit).FirstOrDefault()) ?
                                            lstInfoEvaluationParameters.Where(x => x.EvalParam_Name.Equals("EPressScale")).Select(x => x.EvalParam_Mksunit).FirstOrDefault()
                                            : "bar"
                                            : "bar";

                                        var unitY3 = lstInfoEvaluationParameters != null ?
                                            !string.IsNullOrEmpty(lstInfoEvaluationParameters.Where(x => x.EvalParam_Name.Equals("ETravelScale")).Select(x => x.EvalParam_Mksunit).FirstOrDefault()) ?
                                            lstInfoEvaluationParameters.Where(x => x.EvalParam_Name.Equals("ETravelScale")).Select(x => x.EvalParam_Mksunit).FirstOrDefault()
                                            : "mm"
                                            : "mm";

                                        var unitY4 = lstInfoEvaluationParameters != null ?
                                            !string.IsNullOrEmpty(lstInfoEvaluationParameters.Where(x => x.EvalParam_Name.Equals("EDiffTravelScale")).Select(x => x.EvalParam_Mksunit).FirstOrDefault()) ?
                                            lstInfoEvaluationParameters.Where(x => x.EvalParam_Name.Equals("EDiffTravelScale")).Select(x => x.EvalParam_Mksunit).FirstOrDefault()
                                            : "mm"
                                            : "mm";

                                        GVL_Graficos.strNomeEixoX = string.Concat("Time", " ", unitX);
                                        GVL_Graficos.strNomeEixoY1 = string.Concat("Input Force", " ", unitY1);
                                        GVL_Graficos.strNomeEixoY2 = string.Concat("Pressure PC", " ", unitY2);
                                        GVL_Graficos.strNomeEixoY3 = string.Concat("Piston Travel", " ", unitY3);
                                        GVL_Graficos.strNomeEixoY4 = string.Concat("Diff. Travel", " ", unitY4);

                                        GVL_Graficos.strUnidadeX = unitX;
                                        GVL_Graficos.strUnidadeY1 = unitY1;
                                        GVL_Graficos.strUnidadeY2 = unitY2;
                                        GVL_Graficos.strUnidadeY3 = unitY3;
                                        GVL_Graficos.strUnidadeY4 = unitY4;
                                    }

                                    break;
                                }
                            case 29:    //Bleed
                                {
                                    GVL_Graficos.EixoX.wsTLLabel = "AxesChart.1";
                                    GVL_Graficos.rEscalaX = lstInfoEvaluationParameters != null ?
                                        lstInfoEvaluationParameters.Where(x => x.EvalParam_Name.Equals("ETestingTime")).Select(x => x.EvalParam_Hi).FirstOrDefault()
                                        : 60;

                                    GVL_Graficos.EixoY1.wsTLLabel = "AxesChart.2";
                                    GVL_Graficos.rEscalaY1 = lstInfoEvaluationParameters != null ?
                                        lstInfoEvaluationParameters.Where(x => x.EvalParam_Name.Equals("EForceScale")).Select(x => x.EvalParam_Hi).FirstOrDefault()
                                        : 1500;

                                    GVL_Graficos.EixoY2.wsTLLabel = "AxesChart.3";
                                    GVL_Graficos.rEscalaY2 = lstInfoEvaluationParameters != null ?
                                        lstInfoEvaluationParameters.Where(x => x.EvalParam_Name.Equals("EPressScale")).Select(x => x.EvalParam_Hi).FirstOrDefault()
                                        : 5000;

                                    GVL_Graficos.EixoY3.wsTLLabel = "AxesChart.4";
                                    GVL_Graficos.rEscalaY3 = lstInfoEvaluationParameters != null ?
                                        lstInfoEvaluationParameters.Where(x => x.EvalParam_Name.Equals("EPressScale")).Select(x => x.EvalParam_Hi).FirstOrDefault()
                                        : 40;

                                    GVL_Graficos.EixoY4.wsTLLabel = string.Empty;
                                    GVL_Graficos.rEscalaY4 = 0;

                                    var unitX = lstInfoEvaluationParameters != null ?
                                        !string.IsNullOrEmpty(lstInfoEvaluationParameters.Where(x => x.EvalParam_Name.Equals("ETestingTime")).Select(x => x.EvalParam_Mksunit).FirstOrDefault()) ?
                                        lstInfoEvaluationParameters.Where(x => x.EvalParam_Name.Equals("ETestingTime")).Select(x => x.EvalParam_Mksunit).FirstOrDefault()
                                        : "s"
                                        : "s";

                                    var unitY1 = lstInfoEvaluationParameters != null ?
                                        !string.IsNullOrEmpty(lstInfoEvaluationParameters.Where(x => x.EvalParam_Name.Equals("EForceScale")).Select(x => x.EvalParam_Mksunit).FirstOrDefault()) ?
                                        lstInfoEvaluationParameters.Where(x => x.EvalParam_Name.Equals("EForceScale")).Select(x => x.EvalParam_Mksunit).FirstOrDefault()
                                        : "N"
                                        : "N";

                                    var unitY2 = lstInfoEvaluationParameters != null ?
                                        !string.IsNullOrEmpty(lstInfoEvaluationParameters.Where(x => x.EvalParam_Name.Equals("EPressScale")).Select(x => x.EvalParam_Mksunit).FirstOrDefault()) ?
                                        lstInfoEvaluationParameters.Where(x => x.EvalParam_Name.Equals("EPressScale")).Select(x => x.EvalParam_Mksunit).FirstOrDefault()
                                        : "bar"
                                        : "bar";

                                    var unitY3 = lstInfoEvaluationParameters != null ?
                                        !string.IsNullOrEmpty(lstInfoEvaluationParameters.Where(x => x.EvalParam_Name.Equals("EPressScale")).Select(x => x.EvalParam_Mksunit).FirstOrDefault()) ?
                                        lstInfoEvaluationParameters.Where(x => x.EvalParam_Name.Equals("EPressScale")).Select(x => x.EvalParam_Mksunit).FirstOrDefault()
                                        : "bar"
                                        : "bar";

                                    GVL_Graficos.strNomeEixoX = string.Concat("Time", " ", unitX);
                                    GVL_Graficos.strNomeEixoY1 = string.Concat("Input Force", " ", unitY1);
                                    GVL_Graficos.strNomeEixoY2 = string.Concat("Pressure PC", " ", unitY2);
                                    GVL_Graficos.strNomeEixoY3 = string.Concat("Pressure SC", " ", unitY3);
                                    GVL_Graficos.strNomeEixoY4 = string.Empty;

                                    GVL_Graficos.strUnidadeX = unitX;
                                    GVL_Graficos.strUnidadeY1 = unitY1;
                                    GVL_Graficos.strUnidadeY2 = unitY2;
                                    GVL_Graficos.strUnidadeY3 = unitY3;
                                    GVL_Graficos.strUnidadeY4 = string.Empty;

                                    break;
                                }
                            default:
                                break;
                        }

                        int iStartEscalaMin = 0;

                        GVL_Graficos.EixoX.rMin = iStartEscalaMin;
                        GVL_Graficos.EixoX.rMax = GVL_Graficos.rEscalaX;
                        GVL_Graficos.EixoY1.rMin = iStartEscalaMin;
                        GVL_Graficos.EixoY1.rMax = GVL_Graficos.rEscalaY1;
                        GVL_Graficos.EixoY2.rMin = iStartEscalaMin;
                        GVL_Graficos.EixoY2.rMax = GVL_Graficos.rEscalaY2;
                        GVL_Graficos.EixoY3.rMin = iStartEscalaMin;
                        GVL_Graficos.EixoY3.rMax = GVL_Graficos.rEscalaY3;
                        GVL_Graficos.EixoY4.rMin = iStartEscalaMin;
                        GVL_Graficos.EixoY4.rMax = GVL_Graficos.rEscalaY4;
                    }

                    HelperTestBase.Model_GVL.GVL_Graficos = GVL_Graficos;
                }
            }
            catch (Exception ex)
            {
                var err = ex.Message;
                throw;
            }

            return GVL_Graficos;
        }

        #endregion

        #region Legends
        private void AddLegend_Points(Chart chart, double pointX, double pointY, string pointName, System.Drawing.Color poinColor, int k)
        {
            if (poinColor == null)
                poinColor = System.Drawing.Color.Black;

            Legend leg = new Legend();

            if (chart.Legends.Count > 0)
                leg = chart.Legends[0];

            /// Changing the position of the default legend
            leg.Docking = Docking.Bottom;
            leg.Alignment = StringAlignment.Center;
            leg.LegendStyle = LegendStyle.Table;
            //leg.BackColor = Color.Green;
            //leg.ForeColor = Color.Black;
            //leg.DockedToChartArea = "ChartArea1"; // quando hablitado coloca a legenda DENTRO do grafico

            //LegendCellColumnCollection legCells2 = new Legend();

            if (chart.Legends.Count == 0)
                chart.Legends.Add(leg);

            var legCells2 = chart.Legends[0].CellColumns;

            var legPointName = " |     " + pointName;
            var legPointX = "      x: " + Math.Round(pointX, 2);
            var legPointY = "      y: " + Math.Round(pointY, 2);
            var legValues = legPointName + "\r\n" + legPointX + "\r\n" + legPointY;

            legCells2.Add(new LegendCellColumn("", LegendCellColumnType.Text, legValues, ContentAlignment.MiddleCenter));
            legCells2[k].MinimumWidth = 1000;
            legCells2[k].MaximumWidth = 1900;
            legCells2[k].HeaderFont = new Font("Microsoft Sans Serif", 10.25F, FontStyle.Bold);
            legCells2[k].Font = new Font("Microsoft Sans Serif", 10.25F, FontStyle.Bold);
            legCells2[k].Alignment = ContentAlignment.MiddleLeft; //.TopLeft;nt
            legCells2[k].Margins = new Margins(30, 30, 50, 30);
            legCells2[k].ForeColor = poinColor;//Color.Black;
                                               //legCells2[k].BackColor = Color.FromArgb(120, chart1.Series[0].Color);
        }

        #endregion

        #region Points
        void Draw_Points(Chart chart, Dictionary<string, double> varList, bool checkValues)
        {
            int k = 0;
            DataPointCollection chartPoints = chart.Series[0].Points;
            Dictionary<string, string> dictColorList = new Dictionary<string, string>();

            foreach (var item in chartPoints.Select((value, i) => new { i, value }))
            {
                System.Drawing.Color randomColor = System.Drawing.Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));

                int dataPointIndex = item.i;
                DataPoint dataPointValue = item.value;

                string key = string.Empty;
                double pointX = dataPointValue.XValue;
                double pointY = dataPointValue.YValues[0];

                ////check points values
                for (int i = 0; i < varList.Values.Count(); i++)
                {
                    if (checkValues ? pointY == varList.ElementAt(i).Value : pointX == varList.ElementAt(i).Value)
                    {
                        if (!dictColorList.ContainsKey(varList.ElementAt(i).Key))
                        {
                            dictColorList.Add(varList.ElementAt(i).Key, randomColor.Name);
                            key = varList.ElementAt(i).Key;
                        }
                    }
                }

                ////set points colors
                if (dictColorList.Count > 0 && dictColorList.ContainsKey(key))
                {
                    int idx = dictColorList.Count > 2 ? dictColorList.Count - 3 : 0;

                    System.Drawing.Color colorStorage = System.Drawing.Color.FromName(dictColorList.ElementAt(idx).Value);
                    System.Drawing.Color randomFromArgb = System.Drawing.Color.FromArgb(randomColor.A, randomColor.R, randomColor.G, randomColor.B);

                    var str = dictColorList.Count >= 1 && dictColorList.Count < 4 ? "random" : "Storage";
                    dataPointValue.MarkerColor = dictColorList.Count >= 0 && dictColorList.Count < 6 ? randomColor : colorStorage; //Color.Black;
                                                                                                                                   //dataPointValue.MarkerColor = Color.Black;
                    dataPointValue.MarkerSize = 15;
                    dataPointValue.MarkerStyle = MarkerStyle.Cross;
                    dataPointValue.MarkerBorderWidth = 1;

                    //legend
                    AddLegend_Points(chart, pointX, pointY, key, dataPointValue.MarkerColor, k);

                    k++;
                }
            }
        }
        #endregion

        #endregion

        #region TXT FILES
        public bool CheckFileExists(string strFilename)
        {
            if (!File.Exists(strFilename))
                return false;

            return true;
        }

        #region Aquisition Txt Data
        public HelperTestBase TXTFileHBM_HeaderAppendData(int iTesteSelecionado, Model_GVL modelGVL)
        {
            StringBuilder sbHeader = new StringBuilder();
            string strTimeStamp = DateTime.Now.ToString("dd/MM/yyyy - HH:mm:ss", CultureInfo.InvariantCulture); // string.Empty;

            if (iTesteSelecionado > 0)
            {
                //set Variables
                HelperApp.uiTesteSelecionado = iTesteSelecionado;

                #region StringBuilder TxtData_Header - Type Test

                sbHeader.Append($"{strTimeStamp}");
                sbHeader.Append($"\r\n");
                sbHeader.Append($"{HelperTestBase.eExamType}");
                sbHeader.Append($"\r\n");
                sbHeader.Append($"\r\n");

                #endregion

                #region StringBuilder TxtData_Header - Project Info

                string strVarProj = "NaN"; // string.Empty;

                sbHeader.Append($"|- PROJECT -|");
                sbHeader.Append($"\r\n");
                sbHeader.Append($"\r\n");
                sbHeader.Append($"Ident\t\t\t {strCharSplit_TXTHeader_Data}\t{strVarProj}");
                sbHeader.Append($"\r\n");
                sbHeader.Append($"Customer/Type\t {strCharSplit_TXTHeader_Data}\t{strVarProj}");
                sbHeader.Append($"\r\n");
                sbHeader.Append($"Booster\t\t\t {strCharSplit_TXTHeader_Data}\t{strVarProj}");
                sbHeader.Append($"\r\n");
                sbHeader.Append($"TMC\t\t\t\t {strCharSplit_TXTHeader_Data}\t{strVarProj}");
                sbHeader.Append($"\r\n");
                sbHeader.Append($"Production Date\t {strCharSplit_TXTHeader_Data}\t{strVarProj}");
                sbHeader.Append($"\r\n");
                sbHeader.Append($"T.O.\t\t\t {strCharSplit_TXTHeader_Data}\t{strVarProj}");
                sbHeader.Append($"\r\n");
                sbHeader.Append($"Operator\t\t {strCharSplit_TXTHeader_Data}\t{strVarProj}");
                sbHeader.Append($"\r\n");
                sbHeader.Append($"Testing Date\t {strCharSplit_TXTHeader_Data}\t{strVarProj}");
                sbHeader.Append($"\r\n");
                sbHeader.Append($"Comment\t\t\t {strCharSplit_TXTHeader_Data}\t{strVarProj}");
                sbHeader.Append($"\r\n");
                sbHeader.Append($"\r\n");
                sbHeader.Append($"|- PARAMETERS -|");
                sbHeader.Append($"\r\n");
                sbHeader.Append($"\r\n");

                #endregion

                switch (iTesteSelecionado)
                {
                    case 1:     //Force Diagrams - Force/Pressure With Vacuum
                    case 3:     //Force Diagrams - Force/Pressure Without Vacuum
                    case 25:    //Force Diagrams - Force/Pressure Dual Ratio
                        {
                            #region StringBuilder AppendTxtData_Header_ActuationType

                            sbHeader.Append($"Actuation Type \t {strCharSplit_TXTHeader_Data}\t {HelperApp.strActuationMode}");
                            sbHeader.Append($"\r\n");
                            sbHeader.Append($"Output Type \t {strCharSplit_TXTHeader_Data}\t {(HelperTestBase.iOutputType == 1 ? "PC" : "SC")}");
                            sbHeader.Append($"\r\n");
                            sbHeader.Append($"Vacuum (min) \t {strCharSplit_TXTHeader_Data}\t {Math.Round(HelperTestBase.VacuumMin, 2)}");
                            sbHeader.Append($"\r\n");
                            sbHeader.Append($"Vacuum (max) \t {strCharSplit_TXTHeader_Data}\t {Math.Round(HelperTestBase.VacuumMax, 2)}");
                            sbHeader.Append($"\r\n");
                            sbHeader.Append($"Vacuum  \t\t {strCharSplit_TXTHeader_Data}\t {Math.Round(HelperTestBase.Vacuum, 2)}");
                            sbHeader.Append($"\r\n");
                            sbHeader.Append($"Lock Piston \t {strCharSplit_TXTHeader_Data}\t {(HelperTestBase.chkPistonLock ? "Yes" : "No")}");
                            sbHeader.Append($"\r\n");
                            sbHeader.Append($"Gradient \t\t {strCharSplit_TXTHeader_Data}\t {Math.Round(HelperTestBase.ForceGradient, 2)}");
                            sbHeader.Append($"\r\n");
                            sbHeader.Append($"Max. Force \t\t {strCharSplit_TXTHeader_Data}\t {Math.Round(HelperTestBase.MaxForce, 2)}");
                            sbHeader.Append($"\r\n");
                            if (HelperTestBase.iTipoConsumidores > 0)
                                sbHeader.Append($"Consumer \t\t {strCharSplit_TXTHeader_Data}\t {(HelperTestBase.iTipoConsumidores == 1 ? "Original Consumer" : "Tube Consumer")}");
                            else
                                sbHeader.Append($"Consumer \t {strCharSplit_TXTHeader_Data}\t None");
                            sbHeader.Append($"\r\n");
                            sbHeader.Append($"Hose Consumer PC {strCharSplit_TXTHeader_Data}\t {HelperTestBase.iSumHoseConsumerPC}");
                            sbHeader.Append($"\r\n");
                            sbHeader.Append($"Hose Consumer SC {strCharSplit_TXTHeader_Data}\t {HelperTestBase.iSumHoseConsumerSC}");
                            sbHeader.Append($"\r\n");
                            sbHeader.Append($"\r\n");

                            break;

                            #endregion
                        }
                    case 2:     //Force Diagrams - Force/Force With Vacuum
                    case 4:     //Force Diagrams - Force/Force Without Vacuum
                    case 26:    //Force Diagrams - Force/Force Dual Ratio
                        {
                            #region StringBuilder AppendTxtData_Header_ActuationType

                            sbHeader.Append($"Actuation Type \t {strCharSplit_TXTHeader_Data}\t {HelperApp.strActuationMode}");
                            sbHeader.Append($"\r\n");
                            sbHeader.Append($"Output Type \t {strCharSplit_TXTHeader_Data}\t {(HelperTestBase.iOutputType == 1 ? "PC" : "SC")}");
                            sbHeader.Append($"\r\n");
                            sbHeader.Append($"Vacuum (min) \t {strCharSplit_TXTHeader_Data}\t {Math.Round(HelperTestBase.VacuumMin, 2)}");
                            sbHeader.Append($"\r\n");
                            sbHeader.Append($"Vacuum (max) \t {strCharSplit_TXTHeader_Data}\t {Math.Round(HelperTestBase.VacuumMax, 2)}");
                            sbHeader.Append($"\r\n");
                            sbHeader.Append($"Vacuum  \t\t {strCharSplit_TXTHeader_Data}\t {Math.Round(HelperTestBase.Vacuum, 2)}");
                            sbHeader.Append($"\r\n");
                            sbHeader.Append($"Lock Piston \t {strCharSplit_TXTHeader_Data}\t {(HelperTestBase.chkPistonLock ? "Yes" : "No")}");
                            sbHeader.Append($"\r\n");
                            sbHeader.Append($"Gradient \t\t {strCharSplit_TXTHeader_Data}\t {Math.Round(HelperTestBase.ForceGradient, 2)}");
                            sbHeader.Append($"\r\n");
                            sbHeader.Append($"Max. Force \t\t {strCharSplit_TXTHeader_Data}\t {Math.Round(HelperTestBase.MaxForce, 2)}");
                            sbHeader.Append($"\r\n");
                            if (HelperTestBase.iTipoConsumidores > 0)
                                sbHeader.Append($"Consumer \t\t {strCharSplit_TXTHeader_Data}\t {(HelperTestBase.iTipoConsumidores == 1 ? "Original Consumer" : "Tube Consumer")}");
                            else
                                sbHeader.Append($"Consumer \t {strCharSplit_TXTHeader_Data}\t None");
                            sbHeader.Append($"\r\n");
                            sbHeader.Append($"Hose Consumer PC {strCharSplit_TXTHeader_Data}\t {HelperTestBase.iSumHoseConsumerPC}");
                            sbHeader.Append($"\r\n");
                            sbHeader.Append($"Hose Consumer SC {strCharSplit_TXTHeader_Data}\t {HelperTestBase.iSumHoseConsumerSC}");
                            sbHeader.Append($"\r\n");
                            sbHeader.Append($"\r\n");

                            #endregion

                            break;
                        }
                    case 5: //Vacuum Leakage - Released Position
                    case 6: //Vacuum Leakage - Fully Applied Position
                    case 7: //Vacuum Leakage - Lap Position
                        {
                            #region StringBuilder AppendTxtData_Header_ActuationType

                            sbHeader.Append($"Actuation Type \t {strCharSplit_TXTHeader_Data}\t {HelperApp.strActuationMode}");
                            sbHeader.Append($"\r\n");
                            //sbHeader.Append($"Output Type \t {strCharSplit_TXTHeader_Data}\t {(HelperTestBase.iOutputType == 1 ? "PC" : "SC")}");
                            //sbHeader.Append($"\r\n");
                            sbHeader.Append($"Vacuum (min) \t {strCharSplit_TXTHeader_Data}\t {Math.Round(HelperTestBase.VacuumMin, 2)}");
                            sbHeader.Append($"\r\n");
                            sbHeader.Append($"Vacuum (max) \t {strCharSplit_TXTHeader_Data}\t {Math.Round(HelperTestBase.VacuumMax, 2)}");
                            sbHeader.Append($"\r\n");
                            sbHeader.Append($"Vacuum  \t\t {strCharSplit_TXTHeader_Data}\t {Math.Round(HelperTestBase.Vacuum, 2)}");
                            sbHeader.Append($"\r\n");
                            sbHeader.Append($"Lock Piston \t {strCharSplit_TXTHeader_Data}\t {(HelperTestBase.chkPistonLock ? "Yes" : "No")}");
                            sbHeader.Append($"\r\n");
                            sbHeader.Append($"Gradient \t\t {strCharSplit_TXTHeader_Data}\t {Math.Round(HelperTestBase.ForceGradient, 2)}");
                            sbHeader.Append($"\r\n");
                            sbHeader.Append($"Max. Force \t\t {strCharSplit_TXTHeader_Data}\t {Math.Round(HelperTestBase.MaxForce, 2)}");
                            sbHeader.Append($"\r\n");
                            if (HelperTestBase.iTipoConsumidores > 0)
                                sbHeader.Append($"Consumer \t\t {strCharSplit_TXTHeader_Data}\t {(HelperTestBase.iTipoConsumidores == 1 ? "Original Consumer" : "Tube Consumer")}");
                            else
                                sbHeader.Append($"Consumer \t\t {strCharSplit_TXTHeader_Data}\t None");

                            if (iTesteSelecionado != 5)
                            {
                                sbHeader.Append($"\r\n");
                                sbHeader.Append($"Hose Consumer PC {strCharSplit_TXTHeader_Data}\t {HelperTestBase.iSumHoseConsumerPC}");
                                sbHeader.Append($"\r\n");
                                sbHeader.Append($"Hose Consumer SC {strCharSplit_TXTHeader_Data}\t {HelperTestBase.iSumHoseConsumerSC}");
                            }
                            
                            sbHeader.Append($"\r\n");
                            sbHeader.Append($"\r\n");

                            break;

                            #endregion
                        }
                    case 8:     //Hydraulic Leakage - Fully Applied Position
                    case 9:     //Hydraulic Leakage - At Low Pressure
                    case 10:    //Hydraulic Leakage - At High Pressure
                        {
                            #region StringBuilder AppendTxtData_Header_ActuationType

                            sbHeader.Append($"Actuation Type \t {strCharSplit_TXTHeader_Data}\t {HelperApp.strActuationMode}");
                            sbHeader.Append($"\r\n");
                            sbHeader.Append($"Output Type \t {strCharSplit_TXTHeader_Data}\t {(HelperTestBase.iOutputType == 1 ? "PC" : "SC")}");
                            sbHeader.Append($"\r\n");
                            sbHeader.Append($"Vacuum (min) \t {strCharSplit_TXTHeader_Data}\t {Math.Round(HelperTestBase.VacuumMin, 2)}");
                            sbHeader.Append($"\r\n");
                            sbHeader.Append($"Vacuum (max) \t {strCharSplit_TXTHeader_Data}\t {Math.Round(HelperTestBase.VacuumMax, 2)}");
                            sbHeader.Append($"\r\n");
                            sbHeader.Append($"Vacuum  \t\t {strCharSplit_TXTHeader_Data}\t {Math.Round(HelperTestBase.Vacuum, 2)}");
                            sbHeader.Append($"\r\n");
                            sbHeader.Append($"Lock Piston \t {strCharSplit_TXTHeader_Data}\t {(HelperTestBase.chkPistonLock ? "Yes" : "No")}");
                            sbHeader.Append($"\r\n");
                            sbHeader.Append($"Gradient \t\t {strCharSplit_TXTHeader_Data}\t {Math.Round(HelperTestBase.ForceGradient, 2)}");
                            sbHeader.Append($"\r\n");
                            sbHeader.Append($"Max. Force \t\t {strCharSplit_TXTHeader_Data}\t {Math.Round(HelperTestBase.MaxForce, 2)}");
                            sbHeader.Append($"\r\n");

                            if (iTesteSelecionado == 8)
                            {
                                sbHeader.Append($"\r\n");
                                sbHeader.Append($"Hose Consumer PC    : {HelperTestBase.iSumHoseConsumerPC}");
                                sbHeader.Append($"\r\n");
                                sbHeader.Append($"Hose Consumer SC    : {HelperTestBase.iSumHoseConsumerSC}");
                            }

                            sbHeader.Append($"\r\n");
                            sbHeader.Append($"Hose Consumer PC {strCharSplit_TXTHeader_Data}\t {HelperTestBase.iSumHoseConsumerPC}");
                            sbHeader.Append($"\r\n");
                            sbHeader.Append($"Hose Consumer SC {strCharSplit_TXTHeader_Data}\t {HelperTestBase.iSumHoseConsumerSC}");
                            sbHeader.Append($"\r\n");
                            sbHeader.Append($"\r\n");

                            #endregion

                            break;
                        }
                    case 11:    //Adjustment - Actuation Slow
                    case 12:    //Adjustment - Actuation Fast
                        {
                            #region StringBuilder AppendTxtData_Header_ActuationType

                            sbHeader.Append($"Actuation Type \t {strCharSplit_TXTHeader_Data}\t {HelperApp.strActuationMode}");
                            sbHeader.Append($"\r\n");
                            //sbHeader.Append($"Output Type \t {strCharSplit_TXTHeader_Data}\t {(HelperTestBase.iOutputType == 1 ? "PC" : "SC")}");
                            //sbHeader.Append($"\r\n");
                            sbHeader.Append($"Vacuum (min) \t {strCharSplit_TXTHeader_Data}\t {Math.Round(HelperTestBase.VacuumMin, 2)}");
                            sbHeader.Append($"\r\n");
                            sbHeader.Append($"Vacuum (max) \t {strCharSplit_TXTHeader_Data}\t {Math.Round(HelperTestBase.VacuumMax, 2)}");
                            sbHeader.Append($"\r\n");
                            sbHeader.Append($"Vacuum  \t\t {strCharSplit_TXTHeader_Data}\t {Math.Round(HelperTestBase.Vacuum, 2)}");
                            sbHeader.Append($"\r\n");
                            sbHeader.Append($"Lock Piston \t {strCharSplit_TXTHeader_Data}\t {(HelperTestBase.chkPistonLock ? "Yes" : "No")}");
                            sbHeader.Append($"\r\n");
                            sbHeader.Append($"Gradient \t\t {strCharSplit_TXTHeader_Data}\t {Math.Round(HelperTestBase.ForceGradient, 2)}");
                            sbHeader.Append($"\r\n");
                            sbHeader.Append($"Max. Force \t\t {strCharSplit_TXTHeader_Data}\t {Math.Round(HelperTestBase.MaxForce, 2)}");
                            sbHeader.Append($"\r\n");
                            if (HelperTestBase.iTipoConsumidores > 0)
                                sbHeader.Append($"Consumer \t\t {strCharSplit_TXTHeader_Data}\t {(HelperTestBase.iTipoConsumidores == 1 ? "Original Consumer" : "Tube Consumer")}");
                            else
                                sbHeader.Append($"Consumer \t\t {strCharSplit_TXTHeader_Data}\t None");

                            if (iTesteSelecionado != 5)
                            {
                                sbHeader.Append($"\r\n");
                                sbHeader.Append($"Hose Consumer PC {strCharSplit_TXTHeader_Data}\t {HelperTestBase.iSumHoseConsumerPC}");
                                sbHeader.Append($"\r\n");
                                sbHeader.Append($"Hose Consumer SC {strCharSplit_TXTHeader_Data}\t {HelperTestBase.iSumHoseConsumerSC}");
                            }

                            sbHeader.Append($"\r\n");
                            sbHeader.Append($"\r\n");

                            break;

                            #endregion
                        }
                    case 13:    //Check Sensors - Pressure Difference
                        {
                            #region StringBuilder AppendTxtData_Header_ActuationType

                            sbHeader.Append($"Actuation Type \t {strCharSplit_TXTHeader_Data}\t {HelperApp.strActuationMode}");
                            sbHeader.Append($"\r\n");
                            sbHeader.Append($"Output Type \t {strCharSplit_TXTHeader_Data}\t {(HelperTestBase.iOutputType == 1 ? "PC" : "SC")}");
                            sbHeader.Append($"\r\n");
                            sbHeader.Append($"Vacuum (min) \t {strCharSplit_TXTHeader_Data}\t {Math.Round(HelperTestBase.VacuumMin, 2)}");
                            sbHeader.Append($"\r\n");
                            sbHeader.Append($"Vacuum (max) \t {strCharSplit_TXTHeader_Data}\t {Math.Round(HelperTestBase.VacuumMax, 2)}");
                            sbHeader.Append($"\r\n");
                            sbHeader.Append($"Vacuum  \t\t {strCharSplit_TXTHeader_Data}\t {Math.Round(HelperTestBase.Vacuum, 2)}");
                            sbHeader.Append($"\r\n");
                            sbHeader.Append($"Lock Piston \t {strCharSplit_TXTHeader_Data}\t {(HelperTestBase.chkPistonLock ? "Yes" : "No")}");
                            sbHeader.Append($"\r\n");
                            sbHeader.Append($"Gradient \t\t {strCharSplit_TXTHeader_Data}\t {Math.Round(HelperTestBase.ForceGradient, 2)}");
                            sbHeader.Append($"\r\n");
                            sbHeader.Append($"Max. Force \t\t {strCharSplit_TXTHeader_Data}\t {Math.Round(HelperTestBase.MaxForce, 2)}");
                            sbHeader.Append($"\r\n");
                            if (HelperTestBase.iTipoConsumidores > 0)
                                sbHeader.Append($"Consumer \t\t {strCharSplit_TXTHeader_Data}\t {(HelperTestBase.iTipoConsumidores == 1 ? "Original Consumer" : "Tube Consumer")}");
                            else
                                sbHeader.Append($"Consumer \t {strCharSplit_TXTHeader_Data}\t None");
                            sbHeader.Append($"\r\n");
                            sbHeader.Append($"Hose Consumer PC {strCharSplit_TXTHeader_Data}\t {HelperTestBase.iSumHoseConsumerPC}");
                            sbHeader.Append($"\r\n");
                            sbHeader.Append($"Hose Consumer SC {strCharSplit_TXTHeader_Data}\t {HelperTestBase.iSumHoseConsumerSC}");
                            sbHeader.Append($"\r\n");
                            sbHeader.Append($"\r\n");

                            break;

                            #endregion
                        }
                    case 14:    //Check Sensors - Input/Output Travel
                        {
                            #region StringBuilder AppendTxtData_Header_ActuationType

                            HelperTestBase.ETestActuationType = E_TestActuationType.PneumaticSlow;
                            HelperTestBase.VacuumMin = -0.82;
                            HelperTestBase.VacuumMax = -0.78;
                            HelperTestBase.Vacuum = -0.8;
                            HelperTestBase.chkPistonLock = false;
                            HelperTestBase.ForceGradient = 100;
                            HelperTestBase.MaxForce = 1500;
                            HelperTestBase.radHoseConsumer = false;

                            sbHeader.Append($"Actuation Type      : {HelperTestBase.ETestActuationType}");
                            sbHeader.Append($"\r\n");
                            sbHeader.Append($"Vacuum (min)        : {HelperTestBase.VacuumMin}");
                            sbHeader.Append($"\r\n");
                            sbHeader.Append($"Vacuum (max)        : {HelperTestBase.VacuumMax}");
                            sbHeader.Append($"\r\n");
                            sbHeader.Append($"Vacuum              : {HelperTestBase.Vacuum}");
                            sbHeader.Append($"\r\n");
                            sbHeader.Append($"Lock Piston         : {(HelperTestBase.chkPistonLock ? "Yes" : "No")}");
                            sbHeader.Append($"\r\n");
                            sbHeader.Append($"Gradient            : {HelperTestBase.ForceGradient}");
                            sbHeader.Append($"\r\n");
                            sbHeader.Append($"Max. Force          : {HelperTestBase.MaxForce}");
                            sbHeader.Append($"\r\n");
                            sbHeader.Append($"Consumer            : {(HelperTestBase.radHoseConsumer ? "Tube Consumer" : (HelperTestBase.radOriginalConsumer ? "Original Consumer" : "None"))}");
                            sbHeader.Append($"\r\n");
                            sbHeader.Append($"\r\n");

                            #endregion

                            break;
                        }
                    case 15:    //Adjustment - Input Travel VS Input Force
                        {
                            #region StringBuilder AppendTxtData_Header_ActuationType

                            sbHeader.Append($"Actuation Type \t {strCharSplit_TXTHeader_Data}\t {HelperApp.strActuationMode}");
                            sbHeader.Append($"\r\n");
                            sbHeader.Append($"Output Type \t {strCharSplit_TXTHeader_Data}\t {(HelperTestBase.iOutputType == 1 ? "PC" : "SC")}");
                            sbHeader.Append($"\r\n");
                            sbHeader.Append($"Vacuum (min) \t {strCharSplit_TXTHeader_Data}\t {Math.Round(HelperTestBase.VacuumMin, 2)}");
                            sbHeader.Append($"\r\n");
                            sbHeader.Append($"Vacuum (max) \t {strCharSplit_TXTHeader_Data}\t {Math.Round(HelperTestBase.VacuumMax, 2)}");
                            sbHeader.Append($"\r\n");
                            sbHeader.Append($"Vacuum  \t\t {strCharSplit_TXTHeader_Data}\t {Math.Round(HelperTestBase.Vacuum, 2)}");
                            sbHeader.Append($"\r\n");
                            sbHeader.Append($"Lock Piston \t {strCharSplit_TXTHeader_Data}\t {(HelperTestBase.chkPistonLock ? "Yes" : "No")}");
                            sbHeader.Append($"\r\n");
                            sbHeader.Append($"Gradient \t\t {strCharSplit_TXTHeader_Data}\t {Math.Round(HelperTestBase.ForceGradient, 2)}");
                            sbHeader.Append($"\r\n");
                            sbHeader.Append($"Max. Force \t\t {strCharSplit_TXTHeader_Data}\t {Math.Round(HelperTestBase.MaxForce, 2)}");
                            sbHeader.Append($"\r\n");
                            if (HelperTestBase.iTipoConsumidores > 0)
                                sbHeader.Append($"Consumer \t\t {strCharSplit_TXTHeader_Data}\t {(HelperTestBase.iTipoConsumidores == 1 ? "Original Consumer" : "Tube Consumer")}");
                            else
                                sbHeader.Append($"Consumer \t {strCharSplit_TXTHeader_Data}\t None");
                            sbHeader.Append($"\r\n");
                            sbHeader.Append($"Hose Consumer PC {strCharSplit_TXTHeader_Data}\t {HelperTestBase.iSumHoseConsumerPC}");
                            sbHeader.Append($"\r\n");
                            sbHeader.Append($"Hose Consumer SC {strCharSplit_TXTHeader_Data}\t {HelperTestBase.iSumHoseConsumerSC}");
                            sbHeader.Append($"\r\n");
                            sbHeader.Append($"\r\n");

                            break;

                            #endregion

                            break;
                        }
                    case 16:    //Adjustment - Hose Consumer
                    case 17:    //Lost Travel ACU - Hydraulic
                    case 18:    //Lost Travel ACU - Hydraulic Electrical Actuation
                        {
                            #region StringBuilder AppendTxtData_Header_ActuationType

                            sbHeader.Append($"Actuation Type      : {HelperTestBase.ETestActuationType}");
                            sbHeader.Append($"\r\n");
                            sbHeader.Append($"Vacuum (min)        : {HelperTestBase.VacuumMin}");
                            sbHeader.Append($"\r\n");
                            sbHeader.Append($"Vacuum (max)        : {HelperTestBase.VacuumMax}");
                            sbHeader.Append($"\r\n");
                            sbHeader.Append($"Vacuum              : {HelperTestBase.Vacuum}");
                            sbHeader.Append($"\r\n");
                            sbHeader.Append($"Lock Piston         : {(HelperTestBase.chkPistonLock ? "Yes" : "No")}");
                            sbHeader.Append($"\r\n");
                            sbHeader.Append($"Gradient            : {HelperTestBase.ForceGradient}");
                            sbHeader.Append($"\r\n");
                            sbHeader.Append($"Max. Force          : {HelperTestBase.MaxForce}");
                            sbHeader.Append($"\r\n");
                            sbHeader.Append($"Consumer            : {(HelperTestBase.radHoseConsumer ? "Tube Consumer" : (HelperTestBase.radOriginalConsumer ? "Original Consumer" : "None"))}");

                            if (iTesteSelecionado == 17)
                            {
                                sbHeader.Append($"\r\n");
                                sbHeader.Append($"Hose Consumer PC    : {HelperTestBase.iSumHoseConsumerPC}");
                                sbHeader.Append($"\r\n");
                                sbHeader.Append($"Hose Consumer SC    : {HelperTestBase.iSumHoseConsumerSC}");
                            }

                            sbHeader.Append($"\r\n");
                            sbHeader.Append($"\r\n");

                            #endregion

                            break;
                        }
                    case 19:    //Lost Travel ACU - Pneumatic Primary
                    case 20:    //Lost Travel ACU - Pneumatic Secondary
                        {
                            #region StringBuilder AppendTxtData_Header_ActuationType

                            sbHeader.Append($"Actuation Type \t {strCharSplit_TXTHeader_Data}\t {HelperApp.strActuationMode}");
                            sbHeader.Append($"\r\n");
                            sbHeader.Append($"Output Type \t {strCharSplit_TXTHeader_Data}\t {(HelperTestBase.iOutputType == 1 ? "PC" : "SC")}");
                            sbHeader.Append($"\r\n");
                            sbHeader.Append($"Vacuum (min) \t {strCharSplit_TXTHeader_Data}\t {Math.Round(HelperTestBase.VacuumMin, 2)}");
                            sbHeader.Append($"\r\n");
                            sbHeader.Append($"Vacuum (max) \t {strCharSplit_TXTHeader_Data}\t {Math.Round(HelperTestBase.VacuumMax, 2)}");
                            sbHeader.Append($"\r\n");
                            sbHeader.Append($"Vacuum  \t\t {strCharSplit_TXTHeader_Data}\t {Math.Round(HelperTestBase.Vacuum, 2)}");
                            sbHeader.Append($"\r\n");
                            sbHeader.Append($"Lock Piston \t {strCharSplit_TXTHeader_Data}\t {(HelperTestBase.chkPistonLock ? "Yes" : "No")}");
                            sbHeader.Append($"\r\n");
                            sbHeader.Append($"Gradient \t\t {strCharSplit_TXTHeader_Data}\t {Math.Round(HelperTestBase.ForceGradient, 2)}");
                            sbHeader.Append($"\r\n");
                            sbHeader.Append($"Max. Force \t\t {strCharSplit_TXTHeader_Data}\t {Math.Round(HelperTestBase.MaxForce, 2)}");
                            sbHeader.Append($"\r\n");
                            sbHeader.Append($"Consumer \t {strCharSplit_TXTHeader_Data}\t None");
                            sbHeader.Append($"\r\n");
                            sbHeader.Append($"Hose Consumer PC {strCharSplit_TXTHeader_Data}\t {HelperTestBase.iSumHoseConsumerPC}");
                            sbHeader.Append($"\r\n");
                            sbHeader.Append($"Hose Consumer SC {strCharSplit_TXTHeader_Data}\t {HelperTestBase.iSumHoseConsumerSC}");
                            sbHeader.Append($"\r\n");
                            sbHeader.Append($"\r\n");

                            break;

                            #endregion

                            break;
                        }
                    case 21:    //Pedal Feeling Characteristics
                        {
                            #region StringBuilder AppendTxtData_Header_ActuationType

                            sbHeader.Append($"Actuation Type \t {strCharSplit_TXTHeader_Data}\t {HelperApp.strActuationMode}");
                            sbHeader.Append($"\r\n");
                            sbHeader.Append($"Output Type \t {strCharSplit_TXTHeader_Data}\t {(HelperTestBase.iOutputType == 1 ? "PC" : "SC")}");
                            sbHeader.Append($"\r\n");
                            sbHeader.Append($"Vacuum (min) \t {strCharSplit_TXTHeader_Data}\t {Math.Round(HelperTestBase.VacuumMin, 2)}");
                            sbHeader.Append($"\r\n");
                            sbHeader.Append($"Vacuum (max) \t {strCharSplit_TXTHeader_Data}\t {Math.Round(HelperTestBase.VacuumMax, 2)}");
                            sbHeader.Append($"\r\n");
                            sbHeader.Append($"Vacuum  \t\t {strCharSplit_TXTHeader_Data}\t {Math.Round(HelperTestBase.Vacuum, 2)}");
                            sbHeader.Append($"\r\n");
                            sbHeader.Append($"Lock Piston \t {strCharSplit_TXTHeader_Data}\t {(HelperTestBase.chkPistonLock ? "Yes" : "No")}");
                            sbHeader.Append($"\r\n");
                            sbHeader.Append($"Gradient \t\t {strCharSplit_TXTHeader_Data}\t {Math.Round(HelperTestBase.ForceGradient, 2)}");
                            sbHeader.Append($"\r\n");
                            sbHeader.Append($"Max. Force \t\t {strCharSplit_TXTHeader_Data}\t {Math.Round(HelperTestBase.MaxForce, 2)}");
                            sbHeader.Append($"\r\n");
                            if (HelperTestBase.iTipoConsumidores > 0)
                                sbHeader.Append($"Consumer \t\t {strCharSplit_TXTHeader_Data}\t {(HelperTestBase.iTipoConsumidores == 1 ? "Original Consumer" : "Tube Consumer")}");
                            else
                                sbHeader.Append($"Consumer \t {strCharSplit_TXTHeader_Data}\t None");                            
                            sbHeader.Append($"\r\n");
                            sbHeader.Append($"\r\n");

                            #endregion

                            break;
                        }
                    case 22:    //Actuation / Release - Mechanical Actuation
                        {
                            #region StringBuilder AppendTxtData_Header_ActuationType

                            sbHeader.Append($"Actuation Type \t {strCharSplit_TXTHeader_Data}\t {HelperApp.strActuationMode}");
                            sbHeader.Append($"\r\n");
                            sbHeader.Append($"Output Type \t {strCharSplit_TXTHeader_Data}\t {(HelperTestBase.iOutputType == 1 ? "PC" : "SC")}");
                            sbHeader.Append($"\r\n");
                            sbHeader.Append($"Vacuum (min) \t {strCharSplit_TXTHeader_Data}\t {Math.Round(HelperTestBase.VacuumMin, 2)}");
                            sbHeader.Append($"\r\n");
                            sbHeader.Append($"Vacuum (max) \t {strCharSplit_TXTHeader_Data}\t {Math.Round(HelperTestBase.VacuumMax, 2)}");
                            sbHeader.Append($"\r\n");
                            sbHeader.Append($"Vacuum  \t\t {strCharSplit_TXTHeader_Data}\t {Math.Round(HelperTestBase.Vacuum, 2)}");
                            sbHeader.Append($"\r\n");
                            sbHeader.Append($"Lock Piston \t {strCharSplit_TXTHeader_Data}\t {(HelperTestBase.chkPistonLock ? "Yes" : "No")}");
                            sbHeader.Append($"\r\n");
                            sbHeader.Append($"Gradient \t\t {strCharSplit_TXTHeader_Data}\t {Math.Round(HelperTestBase.ForceGradient, 2)}");
                            sbHeader.Append($"\r\n");
                            sbHeader.Append($"Max. Force \t\t {strCharSplit_TXTHeader_Data}\t {Math.Round(HelperTestBase.MaxForce, 2)}");
                            sbHeader.Append($"\r\n");
                            if (HelperTestBase.iTipoConsumidores > 0)
                                sbHeader.Append($"Consumer \t\t {strCharSplit_TXTHeader_Data}\t {(HelperTestBase.iTipoConsumidores == 1 ? "Original Consumer" : "Tube Consumer")}");
                            else
                                sbHeader.Append($"Consumer \t {strCharSplit_TXTHeader_Data}\t None");
                            sbHeader.Append($"\r\n");
                            sbHeader.Append($"Hose Consumer PC {strCharSplit_TXTHeader_Data}\t {HelperTestBase.iSumHoseConsumerPC}");
                            sbHeader.Append($"\r\n");
                            sbHeader.Append($"Hose Consumer SC {strCharSplit_TXTHeader_Data}\t {HelperTestBase.iSumHoseConsumerSC}");
                            sbHeader.Append($"\r\n");
                            sbHeader.Append($"\r\n");

                            #endregion

                            break;
                        }
                    case 23:    //Breather Hole / Central Valve open
                        {
                            #region StringBuilder AppendTxtData_Header_ActuationType

                            sbHeader.Append($"Actuation Type \t {strCharSplit_TXTHeader_Data}\t {HelperApp.strActuationMode}");
                            sbHeader.Append($"\r\n");
                            sbHeader.Append($"Output Type \t {strCharSplit_TXTHeader_Data}\t {(HelperTestBase.iOutputType == 1 ? "PC" : "SC")}");
                            sbHeader.Append($"\r\n");
                            sbHeader.Append($"Vacuum (min) \t {strCharSplit_TXTHeader_Data}\t {Math.Round(HelperTestBase.VacuumMin, 2)}");
                            sbHeader.Append($"\r\n");
                            sbHeader.Append($"Vacuum (max) \t {strCharSplit_TXTHeader_Data}\t {Math.Round(HelperTestBase.VacuumMax, 2)}");
                            sbHeader.Append($"\r\n");
                            sbHeader.Append($"Vacuum  \t\t {strCharSplit_TXTHeader_Data}\t {Math.Round(HelperTestBase.Vacuum, 2)}");
                            sbHeader.Append($"\r\n");
                            sbHeader.Append($"Lock Piston \t {strCharSplit_TXTHeader_Data}\t {(HelperTestBase.chkPistonLock ? "Yes" : "No")}");
                            sbHeader.Append($"\r\n");
                            sbHeader.Append($"Gradient \t\t {strCharSplit_TXTHeader_Data}\t {Math.Round(HelperTestBase.ForceGradient, 2)}");
                            sbHeader.Append($"\r\n");
                            sbHeader.Append($"Max. Force \t\t {strCharSplit_TXTHeader_Data}\t {Math.Round(HelperTestBase.MaxForce, 2)}");
                            sbHeader.Append($"\r\n");
                            if (HelperTestBase.iTipoConsumidores > 0)
                                sbHeader.Append($"Consumer \t\t {strCharSplit_TXTHeader_Data}\t {(HelperTestBase.iTipoConsumidores == 1 ? "Original Consumer" : "Tube Consumer")}");
                            else
                                sbHeader.Append($"Consumer \t {strCharSplit_TXTHeader_Data}\t None");
                            sbHeader.Append($"\r\n");
                            sbHeader.Append($"Hose Consumer PC {strCharSplit_TXTHeader_Data}\t {HelperTestBase.iSumHoseConsumerPC}");
                            sbHeader.Append($"\r\n");
                            sbHeader.Append($"Hose Consumer SC {strCharSplit_TXTHeader_Data}\t {HelperTestBase.iSumHoseConsumerSC}");
                            sbHeader.Append($"\r\n");
                            sbHeader.Append($"\r\n");

                            #endregion

                            break;
                        }
                    case 24:    //Efficiency
                        {
                            #region StringBuilder AppendTxtData_Header_ActuationType

                            sbHeader.Append($"Actuation Type \t {strCharSplit_TXTHeader_Data}\t {HelperApp.strActuationMode}");
                            sbHeader.Append($"\r\n");
                            sbHeader.Append($"Output Type \t {strCharSplit_TXTHeader_Data}\t {(HelperTestBase.iOutputType == 1 ? "PC" : "SC")}");
                            sbHeader.Append($"\r\n");
                            sbHeader.Append($"Vacuum (min) \t {strCharSplit_TXTHeader_Data}\t {Math.Round(HelperTestBase.VacuumMin, 2)}");
                            sbHeader.Append($"\r\n");
                            sbHeader.Append($"Vacuum (max) \t {strCharSplit_TXTHeader_Data}\t {Math.Round(HelperTestBase.VacuumMax, 2)}");
                            sbHeader.Append($"\r\n");
                            sbHeader.Append($"Vacuum  \t\t {strCharSplit_TXTHeader_Data}\t {Math.Round(HelperTestBase.Vacuum, 2)}");
                            sbHeader.Append($"\r\n");
                            sbHeader.Append($"Lock Piston \t {strCharSplit_TXTHeader_Data}\t {(HelperTestBase.chkPistonLock ? "Yes" : "No")}");
                            sbHeader.Append($"\r\n");
                            sbHeader.Append($"Gradient \t\t {strCharSplit_TXTHeader_Data}\t {Math.Round(HelperTestBase.ForceGradient, 2)}");
                            sbHeader.Append($"\r\n");
                            sbHeader.Append($"Max. Force \t\t {strCharSplit_TXTHeader_Data}\t {Math.Round(HelperTestBase.MaxForce, 2)}");
                            sbHeader.Append($"\r\n");
                            if (HelperTestBase.iTipoConsumidores > 0)
                                sbHeader.Append($"Consumer \t\t {strCharSplit_TXTHeader_Data}\t {(HelperTestBase.iTipoConsumidores == 1 ? "Original Consumer" : "Tube Consumer")}");
                            else
                                sbHeader.Append($"Consumer \t {strCharSplit_TXTHeader_Data}\t None");
                            sbHeader.Append($"\r\n");
                            sbHeader.Append($"Hose Consumer PC {strCharSplit_TXTHeader_Data}\t {HelperTestBase.iSumHoseConsumerPC}");
                            sbHeader.Append($"\r\n");
                            sbHeader.Append($"Hose Consumer SC {strCharSplit_TXTHeader_Data}\t {HelperTestBase.iSumHoseConsumerSC}");
                            sbHeader.Append($"\r\n");
                            sbHeader.Append($"\r\n");

                            #endregion

                            break;
                        }

                    case 27:    //ADAM - Find Switching Point With TMC
                        {
                            #region StringBuilder AppendTxtData_Header_ActuationType

                            HelperTestBase.ETestActuationType = E_TestActuationType.E_Motor;
                            HelperTestBase.VacuumMin = -0.82;
                            HelperTestBase.VacuumMax = -0.78;
                            HelperTestBase.Vacuum = -0.8;
                            HelperTestBase.chkPistonLock = false;
                            HelperTestBase.ForceGradient = 0;
                            HelperTestBase.MaxForce = 480;
                            HelperTestBase.radHoseConsumer = true;
                            HelperTestBase.iSumHoseConsumerPC = 12;
                            HelperTestBase.iSumHoseConsumerSC = 12;

                            sbHeader.Append($"Actuation Type      : {HelperTestBase.ETestActuationType}");
                            sbHeader.Append($"\r\n");
                            sbHeader.Append($"Vacuum (min)        : {HelperTestBase.VacuumMin}");
                            sbHeader.Append($"\r\n");
                            sbHeader.Append($"Vacuum (max)        : {HelperTestBase.VacuumMax}");
                            sbHeader.Append($"\r\n");
                            sbHeader.Append($"Vacuum              : {HelperTestBase.Vacuum}");
                            sbHeader.Append($"\r\n");
                            sbHeader.Append($"Lock Piston         : {(HelperTestBase.chkPistonLock ? "Yes" : "No")}");
                            sbHeader.Append($"\r\n");
                            sbHeader.Append($"Gradient            : {HelperTestBase.ForceGradient}");
                            sbHeader.Append($"\r\n");
                            sbHeader.Append($"Max. Force          : {HelperTestBase.MaxForce}");
                            sbHeader.Append($"\r\n");
                            sbHeader.Append($"Consumer            : {(HelperTestBase.radHoseConsumer ? "Tube Consumer" : (HelperTestBase.radOriginalConsumer ? "Original Consumer" : "None"))}");
                            sbHeader.Append($"\r\n");
                            sbHeader.Append($"Hose Consumer PC    : {HelperTestBase.iSumHoseConsumerPC}");
                            sbHeader.Append($"\r\n");
                            sbHeader.Append($"Hose Consumer SC    : {HelperTestBase.iSumHoseConsumerSC}");
                            sbHeader.Append($"\r\n");
                            sbHeader.Append($"\r\n");
                            sbHeader.Append($"\r\n");

                            #endregion

                            break;
                        }

                    case 28:    //ADAM - Switching Point Without TMC
                        {


                            break;
                        }

                    case 29:    //Bleed
                        {


                            break;
                        }

                    default:
                        break;
                }
            }

            HelperTestBase.sbHeaderAppendTxtData = sbHeader;

            return _helperTestBase;
        }
        public HelperTestBase TXTFileHBM_HeaderAppendTableResults(int iTesteSelecionado)
        {
            StringBuilder sbHeaderResults = new StringBuilder();

            if (iTesteSelecionado > 0)
            {
                //set Variables
                HelperApp.uiTesteSelecionado = iTesteSelecionado;

                var lstResultParam = HelperApp.lstResultParam;

                var dicResultParam = HelperApp.dicResultParam;

                #region StringBuilder TxtData_Header - Type Test

                sbHeaderResults.Append($"|- RESULTS -|");
                sbHeaderResults.Append($"\r\n");
                sbHeaderResults.Append($"\r\n");

                #endregion

                switch (iTesteSelecionado)
                {

                    case 1:     //Force Diagrams - Force/Pressure With Vacuum
                    case 3:     //Force Diagrams - Force/Pressure Without Vacuum
                    case 13:    //Check Sensors - Pressure Difference
                    case 25:    //Force Diagrams - Force/Pressure Dual Ratio
                        {
                            #region StringBuilder AppendTxtData_Header_Results

                            #region Common_Header_Results

                            for (int i = 0; i < dicResultParam.Count; i++)
                            {
                                string keyResultParam_Name = dicResultParam.ElementAt(i).Key?.Replace("resultCalcTestParam_", "")?.Trim();

                                string keyResultParam_Value = dicResultParam.ElementAt(i).Value?.Trim();

                                string strResultParam_Measured = !string.IsNullOrEmpty(keyResultParam_Name) ? lstResultParam.Where(x => x.ResultParam_Name.Equals(keyResultParam_Name)).Select(a => a.ResultParam_Measured)?.FirstOrDefault()?.ToString()?.Trim() : string.Empty;

                                if (!string.IsNullOrEmpty(strResultParam_Measured))
                                {
                                    string strResultParam_Caption = !string.IsNullOrEmpty(keyResultParam_Name) ? lstResultParam.Where(x => x.ResultParam_Name.Equals(keyResultParam_Name)).Select(a => a.ResultParam_Caption)?.FirstOrDefault()?.ToString()?.Trim() : string.Empty;

                                    string strResultParam_Unit = !string.IsNullOrEmpty(keyResultParam_Name) ? lstResultParam.Where(x => x.ResultParam_Name.Equals(keyResultParam_Name)).Select(a => a.ResultParam_Unit)?.FirstOrDefault()?.ToString()?.Trim() : string.Empty;

                                    if (!string.IsNullOrEmpty(strResultParam_Caption))
                                        sbHeaderResults.Append($"{strResultParam_Caption}\t {strCharSplit_TXTHeader_Data}\t {strResultParam_Measured} {strResultParam_Unit}");

                                    sbHeaderResults.Append($"\r\n");
                                }
                            }

                            #endregion

                            #region Curves_Header_Results

                            sbHeaderResults.Append($"\r\n");
                            sbHeaderResults.Append($"\r\n");
                            sbHeaderResults.Append($"|- CURVES -|");
                            sbHeaderResults.Append($"\r\n");
                            sbHeaderResults.Append($"\r\n");
                            sbHeaderResults.Append($"NOTE: Sample rate reduced to approx. 167 Hz to fit to Excel-Limitation");
                            sbHeaderResults.Append($"\r\n");
                            sbHeaderResults.Append($"Time [s]\t Input Force 1 [N]\t Input Travel [m]\t Hydraulic Pressure PC [bar]\t Hydraulic Pressure SC [bar]");
                            sbHeaderResults.Append($"\r\n");
                            sbHeaderResults.Append($"\r\n");

                            #endregion

                            #endregion

                            break;
                        }

                    case 2:     //Force Diagrams - Force/Force With Vacuum
                    case 4:     //Force Diagrams - Force/Force Without Vacuum
                    case 26:    //Force Diagrams - Force/Force Dual Ratio
                        {
                            #region StringBuilder AppendTxtData_Header_Results

                            #region Common_Header_Results_Header

                            #region Common_Header_Results

                            for (int i = 0; i < dicResultParam.Count; i++)
                            {
                                string keyResultParam_Name = dicResultParam.ElementAt(i).Key?.Replace("resultCalcTestParam_", "")?.Trim();

                                string keyResultParam_Value = dicResultParam.ElementAt(i).Value?.Trim();

                                string strResultParam_Measured = !string.IsNullOrEmpty(keyResultParam_Name) ? lstResultParam.Where(x => x.ResultParam_Name.Equals(keyResultParam_Name)).Select(a => a.ResultParam_Measured)?.FirstOrDefault()?.ToString()?.Trim() : string.Empty;

                                if (!string.IsNullOrEmpty(strResultParam_Measured))
                                {
                                    string strResultParam_Caption = !string.IsNullOrEmpty(keyResultParam_Name) ? lstResultParam.Where(x => x.ResultParam_Name.Equals(keyResultParam_Name)).Select(a => a.ResultParam_Caption)?.FirstOrDefault()?.ToString()?.Trim() : string.Empty;

                                    string strResultParam_Unit = !string.IsNullOrEmpty(keyResultParam_Name) ? lstResultParam.Where(x => x.ResultParam_Name.Equals(keyResultParam_Name)).Select(a => a.ResultParam_Unit)?.FirstOrDefault()?.ToString()?.Trim() : string.Empty;

                                    if (!string.IsNullOrEmpty(strResultParam_Caption))
                                        sbHeaderResults.Append($"{strResultParam_Caption}\t {strCharSplit_TXTHeader_Data}\t {strResultParam_Measured} {strResultParam_Unit}");

                                    sbHeaderResults.Append($"\r\n");
                                }
                            }

                            #endregion

                            #endregion

                            #region Common_Header_Results_Case

                            //2 //Force Diagrams - Force/Force With Vacuum
                            var helperTestBase_Jumper = 0;
                            var helperTestBase_OutputForceAt200N = 0;
                            var helperTestBase_OutputForceAt400N = 0;
                            var helperTestBase_OutputForceAt1000N = 0;
                            var helperTestBase_OutputForceAt1500N = 0;
                            var helperTestBase_OutputForceRunout = 0;
                            var helperTestBase_OutputInputRatio = 0;
                            var helperTestBase_CutInForce = 0;
                            var helperTestBase_ReleaseForce = 0;
                            var helperTestBase_HysteresiAt50PercentOut = 0;
                            var helperTestBase_ReleaseForceAt020mm = 0;
                            var helperTestBase_AuxiliaryPressure = 0;
                            var helperTestBase_OutputForceAt90Percent = 0;
                            var helperTestBase_OutputForceAt70Percent = 0;
                            var helperTestBase_JumperGradient = 0;

                            //4 //Force Diagrams - Force/Force Without Vacuum
                            //var helperTestBase_OutputForceAt200N = 10;
                            //var helperTestBase_OutputForceAt400N = 10;
                            //var helperTestBase_OutputInputRatio = 10;
                            //var helperTestBase_CutInForce = 10;
                            //var helperTestBase_ReleaseForce = 10;
                            var helperTestBase_ReleaseForceAt010mm = 0;

                            //26 //Force Diagrams - Force/Force Dual Ratio
                            //var helperTestBase_Jumper = 10;
                            var helperTestBase_OutputForceAt120N = 0;
                            //var helperTestBase_OutputForceAt200N = 10;
                            var helperTestBase_OutputForceAt250N = 0;
                            var helperTestBase_OutputForceAt300N = 0;
                            //var helperTestBase_OutputForceRunout = 10;
                            var helperTestBase_RunoutForce = 0;
                            //var helperTestBase_OutputInputRatio = 10;
                            //var helperTestBase_CutInForce = 10;
                            //var helperTestBase_ReleaseForce = 10;
                            //var helperTestBase_HysteresiAt50PercentOut = 10;
                            //var helperTestBase_ReleaseForceAt020mm = 10;
                            var helperTestBase_DRSwitchPointF = 0;
                            var helperTestBase_DRSwitchPointFout = 0;
                            var helperTestBase_DRGradientIeff1 = 0;
                            var helperTestBase_DRGradientIeff2 = 0;

                            switch (iTesteSelecionado)
                            {
                                case 2: //Force Diagrams - Force/Force With Vacuum
                                    #region Force Diagrams - Force/Pressure With Vacuum

                                    sbHeaderResults.Append($"Jumper                         : {helperTestBase_Jumper} N");
                                    sbHeaderResults.Append($"\r\n");
                                    sbHeaderResults.Append($"Output Force at 200.0 N        : {helperTestBase_OutputForceAt200N} N");
                                    sbHeaderResults.Append($"\r\n");
                                    sbHeaderResults.Append($"Output Force at 400.0 N        : {helperTestBase_OutputForceAt400N} N");
                                    sbHeaderResults.Append($"\r\n");
                                    sbHeaderResults.Append($"Output Force at 1000.0 N       : {helperTestBase_OutputForceAt1000N} N");
                                    sbHeaderResults.Append($"\r\n");
                                    sbHeaderResults.Append($"Output Force at 1500.0 N       : {helperTestBase_OutputForceAt1500N} N");
                                    sbHeaderResults.Append($"\r\n");
                                    sbHeaderResults.Append($"Output Force Runout            : {helperTestBase_OutputForceRunout} N");
                                    sbHeaderResults.Append($"\r\n");
                                    sbHeaderResults.Append($"Output Input Ratio             : {helperTestBase_OutputInputRatio}");
                                    sbHeaderResults.Append($"\r\n");
                                    sbHeaderResults.Append($"Cut - In Force                 : {helperTestBase_CutInForce} N");
                                    sbHeaderResults.Append($"\r\n");
                                    sbHeaderResults.Append($"Release Force                  : {helperTestBase_ReleaseForce} N");
                                    sbHeaderResults.Append($"\r\n");
                                    sbHeaderResults.Append($"Hysteresis at 50.0 % p out     : {helperTestBase_HysteresiAt50PercentOut} N");
                                    sbHeaderResults.Append($"\r\n");
                                    sbHeaderResults.Append($"Release Force at 0.20 mm       : {helperTestBase_ReleaseForceAt020mm} N");
                                    sbHeaderResults.Append($"\r\n");
                                    sbHeaderResults.Append($"Auxiliary Pressure             : {helperTestBase_AuxiliaryPressure} bar");
                                    sbHeaderResults.Append($"\r\n");
                                    sbHeaderResults.Append($"Output Force at 90.0 %         : {helperTestBase_OutputForceAt90Percent} N");
                                    sbHeaderResults.Append($"\r\n");
                                    sbHeaderResults.Append($"Output Force at 70.0 %         : {helperTestBase_OutputForceAt70Percent} N");
                                    sbHeaderResults.Append($"\r\n");
                                    sbHeaderResults.Append($"Jumper Gradient                : {helperTestBase_JumperGradient} N / bar");
                                    sbHeaderResults.Append($"\r\n");

                                    #endregion
                                    break;

                                case 4:  //Force Diagrams - Force/Force Without Vacuum
                                    #region Force Diagrams - Force/Pressure Without Vacuum

                                    sbHeaderResults.Append($"Output Force at 200.0 N        : {helperTestBase_OutputForceAt200N} N");
                                    sbHeaderResults.Append($"\r\n");
                                    sbHeaderResults.Append($"Output Force at 400.0 N        : {helperTestBase_OutputForceAt400N} N");
                                    sbHeaderResults.Append($"\r\n");
                                    sbHeaderResults.Append($"Output Input Ratio             : {helperTestBase_OutputInputRatio}");
                                    sbHeaderResults.Append($"\r\n");
                                    sbHeaderResults.Append($"Cut - In Force                 : {helperTestBase_CutInForce} N");
                                    sbHeaderResults.Append($"\r\n");
                                    sbHeaderResults.Append($"Release Force                  : {helperTestBase_ReleaseForce} N");
                                    sbHeaderResults.Append($"\r\n");
                                    sbHeaderResults.Append($"Release Force at 0.10 mm       : {helperTestBase_ReleaseForceAt010mm} N");
                                    sbHeaderResults.Append($"\r\n");

                                    #endregion
                                    break;

                                case 26: //Force Diagrams - Force/Force Dual Ratio
                                    #region Force Diagrams - Force/Pressure Dual Ratio

                                    sbHeaderResults.Append($"Jumper                         : {helperTestBase_Jumper} N");
                                    sbHeaderResults.Append($"\r\n");
                                    sbHeaderResults.Append($"Output Force at 120.0 N        : {helperTestBase_OutputForceAt120N} N");
                                    sbHeaderResults.Append($"\r\n");
                                    sbHeaderResults.Append($"Output Force at 200.0 N        : {helperTestBase_OutputForceAt200N} N");
                                    sbHeaderResults.Append($"\r\n");
                                    sbHeaderResults.Append($"Output Force at 250.0 N        : {helperTestBase_OutputForceAt250N} N");
                                    sbHeaderResults.Append($"\r\n");
                                    sbHeaderResults.Append($"Output Force at 300.0 N        : {helperTestBase_OutputForceAt300N} N");
                                    sbHeaderResults.Append($"\r\n");
                                    sbHeaderResults.Append($"Output Force Runout            : {helperTestBase_OutputForceRunout} N");
                                    sbHeaderResults.Append($"\r\n");
                                    sbHeaderResults.Append($"Runout Force                   : {helperTestBase_RunoutForce} N");
                                    sbHeaderResults.Append($"\r\n");
                                    sbHeaderResults.Append($"Output Input Ratio             : {helperTestBase_OutputInputRatio}");
                                    sbHeaderResults.Append($"\r\n");
                                    sbHeaderResults.Append($"Cut - In Force                 : {helperTestBase_CutInForce} N");
                                    sbHeaderResults.Append($"\r\n");
                                    sbHeaderResults.Append($"Release Force                  : {helperTestBase_ReleaseForce} N");
                                    sbHeaderResults.Append($"\r\n");
                                    sbHeaderResults.Append($"Hysteresis at 50.0 % p out     : {helperTestBase_HysteresiAt50PercentOut} N");
                                    sbHeaderResults.Append($"\r\n");
                                    sbHeaderResults.Append($"Release Force at 0.20 mm       : {helperTestBase_ReleaseForceAt020mm} N");
                                    sbHeaderResults.Append($"\r\n");
                                    sbHeaderResults.Append($"DR Switch Point F              : {helperTestBase_DRSwitchPointF} N");
                                    sbHeaderResults.Append($"\r\n");
                                    sbHeaderResults.Append($"DR Switch Point Fout           : {helperTestBase_DRSwitchPointFout} N");
                                    sbHeaderResults.Append($"\r\n");
                                    sbHeaderResults.Append($"DR Gradient I eff 1            : {helperTestBase_DRGradientIeff1} #");
                                    sbHeaderResults.Append($"\r\n");
                                    sbHeaderResults.Append($"DR Gradient I eff 2            : {helperTestBase_DRGradientIeff2} #");
                                    sbHeaderResults.Append($"\r\n");

                                    #endregion
                                    break;

                                default:
                                    break;
                            }

                            #endregion

                            #region Common_Header_Results_Footer

                            var helperTestBase_PCHoseConsumer = 12;
                            var helperTestBase_SCHoseConsumer = 12;
                            var helperTestBase_RoomTemperature = HelperMODBUS.CS_dwTemperaturaAmbiente_C_LW.ToString("N2");

                            sbHeaderResults.Append($"PC Hose Consumers              : {helperTestBase_PCHoseConsumer} #");
                            sbHeaderResults.Append($"\r\n");
                            sbHeaderResults.Append($"SC Hose Consumers              : {helperTestBase_SCHoseConsumer} #");
                            sbHeaderResults.Append($"\r\n");
                            sbHeaderResults.Append($"Room Temperature               : {helperTestBase_RoomTemperature} °C");
                            sbHeaderResults.Append($"\r\n");
                            sbHeaderResults.Append($"\r\n");

                            #endregion

                            #region Curves_Header_Results

                            sbHeaderResults.Append($"Curves");
                            sbHeaderResults.Append($"\r\n");
                            sbHeaderResults.Append($"\r\n");
                            sbHeaderResults.Append($"NOTE: Sample rate reduced to approx. 125 Hz to fit to Excel-Limitation");
                            sbHeaderResults.Append($"\r\n");
                            sbHeaderResults.Append($"Time [s]\t Input Force 1 [N]\t Input Travel [m]\t Output Force [N]");
                            sbHeaderResults.Append($"\r\n");
                            sbHeaderResults.Append($"\r\n");

                            #endregion

                            #endregion

                            break;
                        }

                    case 5: //Vacuum Leakage - Released Position
                    case 6: //Vacuum Leakage - Fully Applied Position
                    case 7: //Vacuum Leakage - Lap Position
                        {
                            #region StringBuilder AppendTxtData_Header_Results

                            #region Common_Header_Results

                            for (int i = 0; i < dicResultParam.Count; i++)
                            {
                                string keyResultParam_Name = dicResultParam.ElementAt(i).Key?.Replace("resultCalcTestParam_", "")?.Trim();

                                string keyResultParam_Value = dicResultParam.ElementAt(i).Value?.Trim();

                                string strResultParam_Measured = !string.IsNullOrEmpty(keyResultParam_Name) ? lstResultParam.Where(x => x.ResultParam_Name.Equals(keyResultParam_Name)).Select(a => a.ResultParam_Measured)?.FirstOrDefault()?.ToString()?.Trim() : string.Empty;

                                if (!string.IsNullOrEmpty(strResultParam_Measured))
                                {
                                    string strResultParam_Caption = !string.IsNullOrEmpty(keyResultParam_Name) ? lstResultParam.Where(x => x.ResultParam_Name.Equals(keyResultParam_Name)).Select(a => a.ResultParam_Caption)?.FirstOrDefault()?.ToString()?.Trim() : string.Empty;

                                    string strResultParam_Unit = !string.IsNullOrEmpty(keyResultParam_Name) ? lstResultParam.Where(x => x.ResultParam_Name.Equals(keyResultParam_Name)).Select(a => a.ResultParam_Unit)?.FirstOrDefault()?.ToString()?.Trim() : string.Empty;

                                    if (!string.IsNullOrEmpty(strResultParam_Caption))
                                        sbHeaderResults.Append($"{strResultParam_Caption}\t {strCharSplit_TXTHeader_Data}\t {strResultParam_Measured} {strResultParam_Unit}");

                                    sbHeaderResults.Append($"\r\n");
                                }
                            }

                            #endregion

                            #region Curves_Header_Results

                            sbHeaderResults.Append($"\r\n");
                            sbHeaderResults.Append($"\r\n");
                            sbHeaderResults.Append($"|- CURVES -|");
                            sbHeaderResults.Append($"\r\n");
                            sbHeaderResults.Append($"\r\n");
                            sbHeaderResults.Append($"NOTE: Sample rate reduced to approx. 125 Hz to fit to Excel-Limitation");
                            sbHeaderResults.Append($"\r\n");
                            sbHeaderResults.Append($"Time [s]\t Vacuum Pressure [bar]");
                            sbHeaderResults.Append($"\r\n");
                            sbHeaderResults.Append($"\r\n");

                            #endregion

                            #endregion

                            break;
                        }

                    case 8:     //Hydraulic Leakage - Fully Applied Position
                    case 9:     //Hydraulic Leakage - At Low Pressure
                    case 10:    //Hydraulic Leakage - At High Pressure
                        {
                            #region StringBuilder AppendTxtData_Header_Results

                            #region Common_Header_Results_Header

                            for (int i = 0; i < dicResultParam.Count; i++)
                            {
                                string keyResultParam_Name = dicResultParam.ElementAt(i).Key?.Replace("resultCalcTestParam_", "")?.Trim();

                                string keyResultParam_Value = dicResultParam.ElementAt(i).Value?.Trim();

                                string strResultParam_Measured = !string.IsNullOrEmpty(keyResultParam_Name) ? lstResultParam.Where(x => x.ResultParam_Name.Equals(keyResultParam_Name)).Select(a => a.ResultParam_Measured)?.FirstOrDefault()?.ToString()?.Trim() : string.Empty;

                                if (!string.IsNullOrEmpty(strResultParam_Measured))
                                {
                                    string strResultParam_Caption = !string.IsNullOrEmpty(keyResultParam_Name) ? lstResultParam.Where(x => x.ResultParam_Name.Equals(keyResultParam_Name)).Select(a => a.ResultParam_Caption)?.FirstOrDefault()?.ToString()?.Trim() : string.Empty;

                                    string strResultParam_Unit = !string.IsNullOrEmpty(keyResultParam_Name) ? lstResultParam.Where(x => x.ResultParam_Name.Equals(keyResultParam_Name)).Select(a => a.ResultParam_Unit)?.FirstOrDefault()?.ToString()?.Trim() : string.Empty;

                                    if (!string.IsNullOrEmpty(strResultParam_Caption))
                                        sbHeaderResults.Append($"{strResultParam_Caption}\t {strCharSplit_TXTHeader_Data}\t {strResultParam_Measured} {strResultParam_Unit}");

                                    sbHeaderResults.Append($"\r\n");
                                }
                            }

                            #endregion

                            #region Curves_Header_Results

                            sbHeaderResults.Append($"\r\n");
                            sbHeaderResults.Append($"\r\n");
                            sbHeaderResults.Append($"|- CURVES -|");
                            sbHeaderResults.Append($"\r\n");
                            sbHeaderResults.Append($"\r\n");
                            sbHeaderResults.Append($"NOTE: Sample rate reduced to approx. 125 Hz to fit to Excel-Limitation");
                            sbHeaderResults.Append($"\r\n");
                            sbHeaderResults.Append($"Time [s]\t Vacuum Pressure [bar]");
                            sbHeaderResults.Append($"\r\n");
                            sbHeaderResults.Append($"\r\n");

                            #endregion

                            #endregion

                            break;
                        }

                    case 11:    //Adjustment - Actuation Slow
                    case 12:    //Adjustment - Actuation Fast
                        {
                            #region StringBuilder AppendTxtData_Header_Results


                            #region Common_Header_Results

                            for (int i = 0; i < dicResultParam.Count; i++)
                            {
                                string keyResultParam_Name = dicResultParam.ElementAt(i).Key?.Replace("resultCalcTestParam_", "")?.Trim();

                                string keyResultParam_Value = dicResultParam.ElementAt(i).Value?.Trim();

                                string strResultParam_Measured = !string.IsNullOrEmpty(keyResultParam_Name) ? lstResultParam.Where(x => x.ResultParam_Name.Equals(keyResultParam_Name)).Select(a => a.ResultParam_Measured)?.FirstOrDefault()?.ToString()?.Trim() : string.Empty;

                                if (!string.IsNullOrEmpty(strResultParam_Measured))
                                {
                                    string strResultParam_Caption = !string.IsNullOrEmpty(keyResultParam_Name) ? lstResultParam.Where(x => x.ResultParam_Name.Equals(keyResultParam_Name)).Select(a => a.ResultParam_Caption)?.FirstOrDefault()?.ToString()?.Trim() : string.Empty;

                                    string strResultParam_Unit = !string.IsNullOrEmpty(keyResultParam_Name) ? lstResultParam.Where(x => x.ResultParam_Name.Equals(keyResultParam_Name)).Select(a => a.ResultParam_Unit)?.FirstOrDefault()?.ToString()?.Trim() : string.Empty;

                                    if (!string.IsNullOrEmpty(strResultParam_Caption))
                                        sbHeaderResults.Append($"{strResultParam_Caption}\t {strCharSplit_TXTHeader_Data}\t {strResultParam_Measured} {strResultParam_Unit}");

                                    sbHeaderResults.Append($"\r\n");
                                }
                            }

                            #endregion

                            #region Curves_Header_Results

                            sbHeaderResults.Append($"\r\n");
                            sbHeaderResults.Append($"\r\n");
                            sbHeaderResults.Append($"|- CURVES -|");
                            sbHeaderResults.Append($"\r\n");
                            sbHeaderResults.Append($"\r\n");
                            sbHeaderResults.Append($"NOTE: Sample rate reduced to approx. 143 Hz to fit to Excel-Limitation");
                            sbHeaderResults.Append($"\r\n");
                            if (iTesteSelecionado == 11)
                                sbHeaderResults.Append($"Time [s]\t Input Force 1 [N]\t Input Travel [m]");
                            else
                                sbHeaderResults.Append($"Time [s]\t Input Force 1 [N]\t Input Travel [m]\t Hydraulic Pressure SC [bar]\t Hydraulic Pressure PC [bar]");

                            sbHeaderResults.Append($"\r\n");
                            sbHeaderResults.Append($"\r\n");

                            #endregion

                            #endregion

                            break;
                        }

                    case 14:    //Check Sensors - Input/Output Travel
                        {
                            #region StringBuilder AppendTxtData_Header_Results

                            var helperTestBase_Vacuum = 0;
                            var helperTestBase_ForceIncreaseGradient = 0;
                            var helperTestBase_ActuationGradientForward = 0;
                            var helperTestBase_ActuationForce = 0;
                            var helperTestBase_ForceDecreaseGradient = 0;
                            var helperTestBase_ActuationGradientBackward = 0;
                            var helperTestBase_InputTravel = 10;
                            var helperTestBase_LostTravel = 0;
                            var helperTestBase_PCHoseConsumer = 12;
                            var helperTestBase_SCHoseConsumer = 12;
                            var helperTestBase_RoomTemperature = HelperMODBUS.CS_dwTemperaturaAmbiente_C_LW.ToString("N2");

                            sbHeaderResults.Append($"Results");
                            sbHeaderResults.Append($"\r\n");
                            sbHeaderResults.Append($"\r\n");
                            sbHeaderResults.Append($"Vacuum                         : {helperTestBase_Vacuum} bar");
                            sbHeaderResults.Append($"\r\n");
                            sbHeaderResults.Append($"Force Increase Gradient        : {helperTestBase_ForceIncreaseGradient} N / s");
                            sbHeaderResults.Append($"\r\n");
                            sbHeaderResults.Append($"Actuation Gradient Forward     : {helperTestBase_ActuationGradientForward} mm / s");
                            sbHeaderResults.Append($"\r\n");
                            sbHeaderResults.Append($"Actuation Force                : {helperTestBase_ActuationForce} N");
                            sbHeaderResults.Append($"\r\n");
                            sbHeaderResults.Append($"Force Decrease Gradient        : {helperTestBase_ForceDecreaseGradient} N / s");
                            sbHeaderResults.Append($"\r\n");
                            sbHeaderResults.Append($"Actuation Gradient Backward    : {helperTestBase_ActuationGradientBackward} mm / s");
                            sbHeaderResults.Append($"\r\n");
                            sbHeaderResults.Append($"Input Travel                   : {helperTestBase_InputTravel} mm");
                            sbHeaderResults.Append($"\r\n");
                            sbHeaderResults.Append($"Lost Travel                    : {helperTestBase_LostTravel} mm");
                            sbHeaderResults.Append($"\r\n");
                            sbHeaderResults.Append($"PC Hose Consumers              : {helperTestBase_PCHoseConsumer} #");
                            sbHeaderResults.Append($"\r\n");
                            sbHeaderResults.Append($"SC Hose Consumers              : {helperTestBase_SCHoseConsumer} #");
                            sbHeaderResults.Append($"\r\n");
                            sbHeaderResults.Append($"Room Temperature               : {helperTestBase_RoomTemperature} °C");
                            sbHeaderResults.Append($"\r\n");
                            sbHeaderResults.Append($"\r\n");

                            #endregion

                            #region Curves_Header_Results

                            sbHeaderResults.Append($"Curves");
                            sbHeaderResults.Append($"\r\n");
                            sbHeaderResults.Append($"\r\n");
                            sbHeaderResults.Append($"NOTE: Sample rate reduced to approx. 167 Hz to fit to Excel-Limitation");
                            sbHeaderResults.Append($"\r\n");
                            sbHeaderResults.Append($"Time [s]\t Input Force 1 [N]\t Input Travel [m]\t TMC Travel [m]");
                            sbHeaderResults.Append($"\r\n");
                            sbHeaderResults.Append($"\r\n");

                            #endregion

                            break;
                        }

                    case 15:    //Adjustment - Input Travel VS Input Force
                        {
                            #region StringBuilder AppendTxtData_Header_Results

                            for (int i = 0; i < dicResultParam.Count; i++)
                            {
                                string keyResultParam_Name = dicResultParam.ElementAt(i).Key?.Replace("resultCalcTestParam_", "")?.Trim();

                                string keyResultParam_Value = dicResultParam.ElementAt(i).Value?.Trim();

                                string strResultParam_Measured = !string.IsNullOrEmpty(keyResultParam_Name) ? lstResultParam.Where(x => x.ResultParam_Name.Equals(keyResultParam_Name)).Select(a => a.ResultParam_Measured)?.FirstOrDefault()?.ToString()?.Trim() : string.Empty;

                                if (!string.IsNullOrEmpty(strResultParam_Measured))
                                {
                                    string strResultParam_Caption = !string.IsNullOrEmpty(keyResultParam_Name) ? lstResultParam.Where(x => x.ResultParam_Name.Equals(keyResultParam_Name)).Select(a => a.ResultParam_Caption)?.FirstOrDefault()?.ToString()?.Trim() : string.Empty;

                                    string strResultParam_Unit = !string.IsNullOrEmpty(keyResultParam_Name) ? lstResultParam.Where(x => x.ResultParam_Name.Equals(keyResultParam_Name)).Select(a => a.ResultParam_Unit)?.FirstOrDefault()?.ToString()?.Trim() : string.Empty;

                                    if (!string.IsNullOrEmpty(strResultParam_Caption))
                                        sbHeaderResults.Append($"{strResultParam_Caption}\t {strCharSplit_TXTHeader_Data}\t {strResultParam_Measured} {strResultParam_Unit}");

                                    sbHeaderResults.Append($"\r\n");
                                }
                            }

                            #endregion

                            #region Curves_Header_Results

                            sbHeaderResults.Append($"Curves");
                            sbHeaderResults.Append($"\r\n");
                            sbHeaderResults.Append($"\r\n");
                            sbHeaderResults.Append($"NOTE: Sample rate reduced to approx. 111 Hz to fit to Excel-Limitation");
                            sbHeaderResults.Append($"\r\n");
                            sbHeaderResults.Append($"Time [s]\t Input Force 1 [N]\t Input Travel [m]");
                            sbHeaderResults.Append($"\r\n");
                            sbHeaderResults.Append($"\r\n");

                            #endregion

                            break;
                        }

                    case 16:    //Adjustment - Hose Consumer
                    case 17:    //Lost Travel ACU - Hydraulic
                    case 18:    //Lost Travel ACU - Hydraulic Electrical Actuation
                        {
                            #region StringBuilder AppendTxtData_Header_Results


                            #region Common_Header_Results

                            for (int i = 0; i < dicResultParam.Count; i++)
                            {
                                string keyResultParam_Name = dicResultParam.ElementAt(i).Key?.Replace("resultCalcTestParam_", "")?.Trim();

                                string keyResultParam_Value = dicResultParam.ElementAt(i).Value?.Trim();

                                string strResultParam_Measured = !string.IsNullOrEmpty(keyResultParam_Name) ? lstResultParam.Where(x => x.ResultParam_Name.Equals(keyResultParam_Name)).Select(a => a.ResultParam_Measured)?.FirstOrDefault()?.ToString()?.Trim() : string.Empty;

                                if (!string.IsNullOrEmpty(strResultParam_Measured))
                                {
                                    string strResultParam_Caption = !string.IsNullOrEmpty(keyResultParam_Name) ? lstResultParam.Where(x => x.ResultParam_Name.Equals(keyResultParam_Name)).Select(a => a.ResultParam_Caption)?.FirstOrDefault()?.ToString()?.Trim() : string.Empty;

                                    string strResultParam_Unit = !string.IsNullOrEmpty(keyResultParam_Name) ? lstResultParam.Where(x => x.ResultParam_Name.Equals(keyResultParam_Name)).Select(a => a.ResultParam_Unit)?.FirstOrDefault()?.ToString()?.Trim() : string.Empty;

                                    if (!string.IsNullOrEmpty(strResultParam_Caption))
                                        sbHeaderResults.Append($"{strResultParam_Caption}\t {strCharSplit_TXTHeader_Data}\t {strResultParam_Measured} {strResultParam_Unit}");

                                    sbHeaderResults.Append($"\r\n");
                                }
                            }

                            #endregion

                            #region Curves_Header_Results

                            sbHeaderResults.Append($"\r\n");
                            sbHeaderResults.Append($"\r\n");
                            sbHeaderResults.Append($"|- CURVES -|");
                            sbHeaderResults.Append($"\r\n");
                            sbHeaderResults.Append($"\r\n");
                            sbHeaderResults.Append($"NOTE: Sample rate reduced to approx. 167 Hz to fit to Excel-Limitation");
                            sbHeaderResults.Append($"\r\n");
                            sbHeaderResults.Append($"Time [s]\t Input Force 1 [N]\t Input Travel [m]\t Hydraulic Pressure PC [bar]\t Hydraulic Pressure SC [bar]");
                            sbHeaderResults.Append($"\r\n");
                            sbHeaderResults.Append($"\r\n");

                            #endregion

                            #endregion

                            break;
                        }

                    case 19:    //Lost Travel ACU - Pneumatic Primary
                    case 20:    //Lost Travel ACU - Pneumatic Secondary
                        {
                            #region StringBuilder AppendTxtData_Header_Results

                            #region Common_Header_Results_Header

                            for (int i = 0; i < dicResultParam.Count; i++)
                            {
                                string keyResultParam_Name = dicResultParam.ElementAt(i).Key?.Replace("resultCalcTestParam_", "")?.Trim();

                                string keyResultParam_Value = dicResultParam.ElementAt(i).Value?.Trim();

                                string strResultParam_Measured = !string.IsNullOrEmpty(keyResultParam_Name) ? lstResultParam.Where(x => x.ResultParam_Name.Equals(keyResultParam_Name)).Select(a => a.ResultParam_Measured)?.FirstOrDefault()?.ToString()?.Trim() : string.Empty;

                                if (!string.IsNullOrEmpty(strResultParam_Measured))
                                {
                                    string strResultParam_Caption = !string.IsNullOrEmpty(keyResultParam_Name) ? lstResultParam.Where(x => x.ResultParam_Name.Equals(keyResultParam_Name)).Select(a => a.ResultParam_Caption)?.FirstOrDefault()?.ToString()?.Trim() : string.Empty;

                                    string strResultParam_Unit = !string.IsNullOrEmpty(keyResultParam_Name) ? lstResultParam.Where(x => x.ResultParam_Name.Equals(keyResultParam_Name)).Select(a => a.ResultParam_Unit)?.FirstOrDefault()?.ToString()?.Trim() : string.Empty;

                                    if (!string.IsNullOrEmpty(strResultParam_Caption))
                                        sbHeaderResults.Append($"{strResultParam_Caption}\t {strCharSplit_TXTHeader_Data}\t {strResultParam_Measured} {strResultParam_Unit}");

                                    sbHeaderResults.Append($"\r\n");
                                }
                            }

                            #endregion

                            #region Curves_Header_Results

                            sbHeaderResults.Append($"Curves");
                            sbHeaderResults.Append($"\r\n");
                            sbHeaderResults.Append($"\r\n");
                            sbHeaderResults.Append($"NOTE: Sample rate reduced to approx. 143 Hz to fit to Excel-Limitation");
                            sbHeaderResults.Append($"\r\n");
                            sbHeaderResults.Append($"Time [s]\t Input Force 1 [N]\t Input Travel [m]\t Pneumatic Test Pressure [bar]");
                            sbHeaderResults.Append($"\r\n");
                            sbHeaderResults.Append($"\r\n");

                            #endregion

                            #endregion

                            break;
                        }

                    case 21:    //Pedal Feeling Characteristics
                        {
                            #region Common_Header_Results

                            for (int i = 0; i < dicResultParam.Count; i++)
                            {
                                string keyResultParam_Name = dicResultParam.ElementAt(i).Key?.Replace("resultCalcTestParam_", "")?.Trim();

                                string keyResultParam_Value = dicResultParam.ElementAt(i).Value?.Trim();

                                string strResultParam_Measured = !string.IsNullOrEmpty(keyResultParam_Name) ? lstResultParam.Where(x => x.ResultParam_Name.Equals(keyResultParam_Name)).Select(a => a.ResultParam_Measured)?.FirstOrDefault()?.ToString()?.Trim() : string.Empty;

                                if (!string.IsNullOrEmpty(strResultParam_Measured))
                                {
                                    string strResultParam_Caption = !string.IsNullOrEmpty(keyResultParam_Name) ? lstResultParam.Where(x => x.ResultParam_Name.Equals(keyResultParam_Name)).Select(a => a.ResultParam_Caption)?.FirstOrDefault()?.ToString()?.Trim() : string.Empty;

                                    string strResultParam_Unit = !string.IsNullOrEmpty(keyResultParam_Name) ? lstResultParam.Where(x => x.ResultParam_Name.Equals(keyResultParam_Name)).Select(a => a.ResultParam_Unit)?.FirstOrDefault()?.ToString()?.Trim() : string.Empty;

                                    if (!string.IsNullOrEmpty(strResultParam_Caption))
                                        sbHeaderResults.Append($"{strResultParam_Caption}\t {strCharSplit_TXTHeader_Data}\t {strResultParam_Measured} {strResultParam_Unit}");

                                    sbHeaderResults.Append($"\r\n");
                                }
                            }

                            #endregion

                            #region Curves_Header_Results

                            sbHeaderResults.Append($"\r\n");
                            sbHeaderResults.Append($"\r\n");
                            sbHeaderResults.Append($"|- CURVES -|");
                            sbHeaderResults.Append($"\r\n");
                            sbHeaderResults.Append($"\r\n");
                            sbHeaderResults.Append($"NOTE: Sample rate reduced to approx. 167 Hz to fit to Excel-Limitation");
                            sbHeaderResults.Append($"\r\n");
                            sbHeaderResults.Append($"Time [s]\t Input Force 1 [N]\t Input Travel [m]\t Hydraulic Pressure PC [bar]\t Hydraulic Pressure SC [bar]");
                            sbHeaderResults.Append($"\r\n");
                            sbHeaderResults.Append($"\r\n");

                            #endregion

                            break;
                        }

                    case 22:    //Actuation / Release - Mechanical Actuation
                        {
                            #region StringBuilder AppendTxtData_Header_Results

                            for (int i = 0; i < dicResultParam.Count; i++)
                            {
                                string keyResultParam_Name = dicResultParam.ElementAt(i).Key?.Replace("resultCalcTestParam_", "")?.Trim();

                                string keyResultParam_Value = dicResultParam.ElementAt(i).Value?.Trim();

                                string strResultParam_Measured = !string.IsNullOrEmpty(keyResultParam_Name) ? lstResultParam.Where(x => x.ResultParam_Name.Equals(keyResultParam_Name)).Select(a => a.ResultParam_Measured)?.FirstOrDefault()?.ToString()?.Trim() : string.Empty;

                                if (!string.IsNullOrEmpty(strResultParam_Measured))
                                {
                                    string strResultParam_Caption = !string.IsNullOrEmpty(keyResultParam_Name) ? lstResultParam.Where(x => x.ResultParam_Name.Equals(keyResultParam_Name)).Select(a => a.ResultParam_Caption)?.FirstOrDefault()?.ToString()?.Trim() : string.Empty;

                                    string strResultParam_Unit = !string.IsNullOrEmpty(keyResultParam_Name) ? lstResultParam.Where(x => x.ResultParam_Name.Equals(keyResultParam_Name)).Select(a => a.ResultParam_Unit)?.FirstOrDefault()?.ToString()?.Trim() : string.Empty;

                                    if (!string.IsNullOrEmpty(strResultParam_Caption))
                                        sbHeaderResults.Append($"{strResultParam_Caption}\t {strCharSplit_TXTHeader_Data}\t {strResultParam_Measured} {strResultParam_Unit}");

                                    sbHeaderResults.Append($"\r\n");
                                }
                            }

                            #endregion

                            #region Curves_Header_Results

                            sbHeaderResults.Append($"Curves");
                            sbHeaderResults.Append($"\r\n");
                            sbHeaderResults.Append($"\r\n");
                            sbHeaderResults.Append($"NOTE: Sample rate reduced to approx. 111 Hz to fit to Excel-Limitation");
                            sbHeaderResults.Append($"\r\n");
                            sbHeaderResults.Append($"Time [s]\t Input Force 1 [N]\t Input Travel [m]\t Hydraulic Pressure PC [bar]\t Hydraulic Pressure SC [bar]");
                            sbHeaderResults.Append($"\r\n");
                            sbHeaderResults.Append($"\r\n");

                            #endregion

                            break;
                        }

                    case 23:    //Breather Hole / Central Valve open
                        {
                            #region StringBuilder AppendTxtData_Header_Results

                            for (int i = 0; i < dicResultParam.Count; i++)
                            {
                                string keyResultParam_Name = dicResultParam.ElementAt(i).Key?.Replace("resultCalcTestParam_", "")?.Trim();

                                string keyResultParam_Value = dicResultParam.ElementAt(i).Value?.Trim();

                                string strResultParam_Measured = !string.IsNullOrEmpty(keyResultParam_Name) ? lstResultParam.Where(x => x.ResultParam_Name.Equals(keyResultParam_Name)).Select(a => a.ResultParam_Measured)?.FirstOrDefault()?.ToString()?.Trim() : string.Empty;

                                if (!string.IsNullOrEmpty(strResultParam_Measured))
                                {
                                    string strResultParam_Caption = !string.IsNullOrEmpty(keyResultParam_Name) ? lstResultParam.Where(x => x.ResultParam_Name.Equals(keyResultParam_Name)).Select(a => a.ResultParam_Caption)?.FirstOrDefault()?.ToString()?.Trim() : string.Empty;

                                    string strResultParam_Unit = !string.IsNullOrEmpty(keyResultParam_Name) ? lstResultParam.Where(x => x.ResultParam_Name.Equals(keyResultParam_Name)).Select(a => a.ResultParam_Unit)?.FirstOrDefault()?.ToString()?.Trim() : string.Empty;

                                    if (!string.IsNullOrEmpty(strResultParam_Caption))
                                        sbHeaderResults.Append($"{strResultParam_Caption}\t {strCharSplit_TXTHeader_Data}\t {strResultParam_Measured} {strResultParam_Unit}");

                                    sbHeaderResults.Append($"\r\n");
                                }
                            }

                            #endregion

                            #region Curves_Header_Results

                            sbHeaderResults.Append($"Curves");
                            sbHeaderResults.Append($"\r\n");
                            sbHeaderResults.Append($"\r\n");
                            sbHeaderResults.Append($"NOTE: Sample rate reduced to approx. 111 Hz to fit to Excel-Limitation");
                            sbHeaderResults.Append($"\r\n");
                            sbHeaderResults.Append($"Time [s]\t Input Force 1 [N]\t Input Travel [m]\t Hydraulic Fill Pressure [bar]");
                            sbHeaderResults.Append($"\r\n");
                            sbHeaderResults.Append($"\r\n");

                            #endregion

                            break;
                        }

                    case 24:    //Efficiency
                        {
                            #region StringBuilder AppendTxtData_Header_Results

                            for (int i = 0; i < dicResultParam.Count; i++)
                            {
                                string keyResultParam_Name = dicResultParam.ElementAt(i).Key?.Replace("resultCalcTestParam_", "")?.Trim();

                                string keyResultParam_Value = dicResultParam.ElementAt(i).Value?.Trim();

                                string strResultParam_Measured = !string.IsNullOrEmpty(keyResultParam_Name) ? lstResultParam.Where(x => x.ResultParam_Name.Equals(keyResultParam_Name)).Select(a => a.ResultParam_Measured)?.FirstOrDefault()?.ToString()?.Trim() : string.Empty;

                                if (!string.IsNullOrEmpty(strResultParam_Measured))
                                {
                                    string strResultParam_Caption = !string.IsNullOrEmpty(keyResultParam_Name) ? lstResultParam.Where(x => x.ResultParam_Name.Equals(keyResultParam_Name)).Select(a => a.ResultParam_Caption)?.FirstOrDefault()?.ToString()?.Trim() : string.Empty;

                                    string strResultParam_Unit = !string.IsNullOrEmpty(keyResultParam_Name) ? lstResultParam.Where(x => x.ResultParam_Name.Equals(keyResultParam_Name)).Select(a => a.ResultParam_Unit)?.FirstOrDefault()?.ToString()?.Trim() : string.Empty;

                                    if (!string.IsNullOrEmpty(strResultParam_Caption))
                                        sbHeaderResults.Append($"{strResultParam_Caption}\t {strCharSplit_TXTHeader_Data}\t {strResultParam_Measured} {strResultParam_Unit}");

                                    sbHeaderResults.Append($"\r\n");
                                }
                            }

                            #endregion

                            #region Curves_Header_Results

                            sbHeaderResults.Append($"Curves");
                            sbHeaderResults.Append($"\r\n");
                            sbHeaderResults.Append($"\r\n");
                            sbHeaderResults.Append($"NOTE: Sample rate reduced to approx. 111 Hz to fit to Excel-Limitation");
                            sbHeaderResults.Append($"\r\n");
                            sbHeaderResults.Append($"Time [s]\t Input Force 1 [N]\t Input Travel [m]\t Hydraulic Pressure PC[bar]");
                            sbHeaderResults.Append($"\r\n");
                            sbHeaderResults.Append($"\r\n");

                            #endregion

                            break;
                        }

                    case 27:    //ADAM - Find Switching Point With TMC
                        {
                            #region StringBuilder AppendTxtData_Header_Results

                            var helperTestBase_Vacuum = 0;
                            var helperTestBase_ActuationGradientForward = 0;
                            var helperTestBase_ActuationForce = 0;
                            var helperTestBase_PressurePC = 0;
                            var helperTestBase_ActuationPower = 0;
                            var helperTestBase_MaxDiffTravel = 0;
                            var helperTestBase_ActuationVelocity2Point = 0;
                            var helperTestBase_ActuationForceMax = 0;
                            var helperTestBase_ActuationPower2Point = 0;
                            var helperTestBase_NominalVelocity = 0;
                            var helperTestBase_PCHoseConsumer = 12;
                            var helperTestBase_SCHoseConsumer = 12;
                            var helperTestBase_RoomTemperature = HelperMODBUS.CS_dwTemperaturaAmbiente_C_LW.ToString("N2");

                            sbHeaderResults.Append($"Results");
                            sbHeaderResults.Append($"\r\n");
                            sbHeaderResults.Append($"\r\n");
                            sbHeaderResults.Append($"Vacuum                         : {helperTestBase_Vacuum} bar");
                            sbHeaderResults.Append($"\r\n");
                            sbHeaderResults.Append($"Actuation Gradient Forward     : {helperTestBase_ActuationGradientForward} mm / s");
                            sbHeaderResults.Append($"\r\n");
                            sbHeaderResults.Append($"Actuation Force                : {helperTestBase_ActuationForce} N");
                            sbHeaderResults.Append($"\r\n");
                            sbHeaderResults.Append($"Pressure PC                    : {helperTestBase_PressurePC} bar");
                            sbHeaderResults.Append($"\r\n");
                            sbHeaderResults.Append($"Actuation Power                : {helperTestBase_ActuationPower} W");
                            sbHeaderResults.Append($"\r\n");
                            sbHeaderResults.Append($"Max.Diff.Travel                : {helperTestBase_MaxDiffTravel} mm");
                            sbHeaderResults.Append($"\r\n");
                            sbHeaderResults.Append($"Actuation Velocity 2 Point     : {helperTestBase_ActuationVelocity2Point} mm / s");
                            sbHeaderResults.Append($"\r\n");
                            sbHeaderResults.Append($"Actuation Force max            : {helperTestBase_ActuationForceMax} N");
                            sbHeaderResults.Append($"\r\n");
                            sbHeaderResults.Append($"Actuation Power 2 Point        : {helperTestBase_ActuationPower2Point} W");
                            sbHeaderResults.Append($"\r\n");
                            sbHeaderResults.Append($"Nominal Velocity               : {helperTestBase_NominalVelocity} mm / s");
                            sbHeaderResults.Append($"\r\n");
                            sbHeaderResults.Append($"PC Hose Consumers              : {helperTestBase_PCHoseConsumer} #");
                            sbHeaderResults.Append($"\r\n");
                            sbHeaderResults.Append($"SC Hose Consumers              : {helperTestBase_SCHoseConsumer} #");
                            sbHeaderResults.Append($"\r\n");
                            sbHeaderResults.Append($"Room Temperature               : {helperTestBase_RoomTemperature} °C");
                            sbHeaderResults.Append($"\r\n");
                            sbHeaderResults.Append($"\r\n");

                            #endregion

                            #region Curves_Header_Results

                            sbHeaderResults.Append($"Curves");
                            sbHeaderResults.Append($"\r\n");
                            sbHeaderResults.Append($"\r\n");
                            sbHeaderResults.Append($"NOTE: Sample rate reduced to approx. 111 Hz to fit to Excel-Limitation");
                            sbHeaderResults.Append($"\r\n");
                            sbHeaderResults.Append($"Time [s]\t Input Force 1 [N]\t Input Travel [m]\t Hydraulic Pressure PC[bar]\t Hydraulic Pressure SC[bar]\t ADAM Diff. Travel[m]\t Velocity[---]\t Power[---]");
                            sbHeaderResults.Append($"\r\n");
                            sbHeaderResults.Append($"\r\n");

                            #endregion

                            break;
                        }

                    case 28:    //ADAM - Switching Point Without TMC
                        {
                            break;
                        }

                    case 29:    //Bleed
                        {
                            break;
                        }

                    default:
                        break;
                }
            }

            HelperTestBase.sbHeaderResultsAppendTxtData = sbHeaderResults;

            return _helperTestBase;
        }

        #endregion

        #region Export Files
        public void ExportToCsvFile(Chart chart, string path)
        {
            string comma = ",";
            string csvLine = string.Empty;
            string csvContent = string.Empty;

            foreach (Series series in chart.Series)
            {
                string seriesName = series.Name;
                int pointCount = series.Points.Count;
                //string seriesType = series.t.Type.ToString();

                for (int p = 0; p < pointCount; p++)
                {
                    DataPoint point = series.Points[p];
                    string yValuesCSV = string.Empty;
                    int count = point.YValues.Length;

                    for (int i = 0; i < count; i++)
                    {
                        yValuesCSV += point.YValues[i];

                        if (i != count - 1)
                            yValuesCSV += comma;
                    }

                    csvLine = seriesName + "-" + point.XValue + comma + yValuesCSV;
                    csvContent += csvLine + "\r\n";
                }
            }

            ///Using stream writer class the chart points are exported. Create an instance of the stream writer class.
            StreamWriter file = new StreamWriter(path);

            ///Write the datapoints into the file.
            file.WriteLine(csvContent);

            file.Close();
        }
        public void ExportToTxtFile(Chart chart, string path)
        {
            string comma = ",";
            string csvLine = string.Empty;
            string csvContent = string.Empty;

            foreach (Series series in chart.Series)
            {
                string seriesName = series.Name;
                int pointCount = series.Points.Count;
                //string seriesType = series.t.Type.ToString();

                for (int p = 0; p < pointCount; p++)
                {
                    DataPoint point = series.Points[p];
                    string yValuesCSV = string.Empty;
                    int count = point.YValues.Length;

                    for (int i = 0; i < count; i++)
                    {
                        yValuesCSV += point.YValues[i];

                        if (i != count - 1)
                            yValuesCSV += comma;
                    }

                    csvLine = seriesName + "-" + point.XValue + comma + yValuesCSV;
                    csvContent += csvLine + "\r\n";
                }
            }

            ///Using stream writer class the chart points are exported. Create an instance of the stream writer class.
            StreamWriter file = new StreamWriter(path);



            file.WriteLine(csvContent);

            file.Close();
        }
        public void ExportToExcel(Chart chart, string path)
        {
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;

            xlApp = new Excel.Application();
            xlWorkBook = xlApp.Workbooks.Add(misValue);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

            for (int i = 0; i < chart.Series.Count; i++)
            {
                xlWorkSheet.Cells[1, 1] = "";
                xlWorkSheet.Cells[1, 2] = "Name Column 1";//put your column heading here
                xlWorkSheet.Cells[1, 3] = "Name Column 2";// put your column heading here

                for (int j = 0; j < chart.Series[i].Points.Count; j++)
                {
                    xlWorkSheet.Cells[j + 2, 2] = chart.Series[i].Points[j].XValue;
                    xlWorkSheet.Cells[j + 2, 3] = chart.Series[i].Points[j].YValues[0];
                }
            }

            Excel.Range chartRange;

            Excel.ChartObjects xlCharts = (Excel.ChartObjects)xlWorkSheet.ChartObjects(Type.Missing);
            Excel.ChartObject myChart = xlCharts.Add(200, 50, 600, 350);
            Excel.Chart chartPage = myChart.Chart;

            chartRange = xlWorkSheet.get_Range("B2", "c15000");//update the range here
            chartPage.SetSourceData(chartRange, misValue);
            chartPage.ChartType = Excel.XlChartType.xlXYScatter;

            xlWorkBook.SaveAs(path, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();

            releaseObject(xlWorkSheet);
            releaseObject(xlWorkBook);
            releaseObject(xlApp);

            MessageBox.Show($"Excel file created , you can find the file {path} ");
        }
        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Exception Occured while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }

        #endregion

        #endregion

        #region REPORT PDF
        public void Report_CreatePDF(string strImgChart, string strFileName, DataGridViewRowCollection gridResultRows)
        {
            try
            {
                #region REPORT - Define Variables

                string dirReportResources = System.IO.Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, AppReport_PathResources);

                string reportProfile = string.Concat(dirReportResources, "sRGB_CS_profile.icm");
                string reportFont = string.Concat(dirReportResources, "FreeSans.ttf");
                string reportFontBold = string.Concat(dirReportResources, "FreeSansBold.ttf");
                string reportImgLogo = string.Concat(dirReportResources, "img_ReportLogoContinenal.png");
                string reportImgChart = !string.IsNullOrEmpty(strImgChart) ? strImgChart : string.Concat(dirReportResources, "img_ReportChart.jpg");

                //Path to Store PDF file
                string dirReportTestPath = AppReport_PathTests.Trim(); //System.IO.Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, AppReport_PathTests);

                string outputFile = !string.IsNullOrEmpty(strFileName) ? string.Concat(dirReportTestPath, strFileName, AppReport_DefaultExtension) : string.Concat(dirReportTestPath, "ReportContinentalAdam_", DateTime.Now.ToString("ddMMMyyyyHHmmss"), AppReport_DefaultExtension);

                int maxSizeChartAreaTable = 27; //******** DON'T CHANGE THIS DATA*********

                int countForTable = 0;

                int maxSizeChartImage = 445;

                string strInfo = string.Empty; // "INFO - CONTI";

                List<Model_Operational_TestTableParameters> lstResultParamFormated = new List<Model_Operational_TestTableParameters>();

                if (HelperApp.lstResultParamFormated != null)
                {
                    if (gridResultRows.Count == Convert.ToInt32(HelperApp.lstResultParamFormated.Count))
                        lstResultParamFormated = HelperApp.lstResultParamFormated;
                    else
                    {
                        for (int i = 0; i < gridResultRows.Count; i++)
                        {
                            var row = gridResultRows[i];

                            lstResultParamFormated.Add(new Model_Operational_TestTableParameters()
                            {
                                IdResultParam = !string.IsNullOrEmpty(row.Cells["IdResultParam"].Value?.ToString()) ? Convert.ToInt32(row.Cells["IdResultParam"].Value) : 0,
                                ResultParam_Name = !string.IsNullOrEmpty(row.Cells["ResultParam_Name"].Value?.ToString()) ? row.Cells["ResultParam_Name"].Value?.ToString() : string.Empty,
                                ResultParam_Caption = !string.IsNullOrEmpty(row.Cells["ResultParam_Caption"].Value?.ToString()) ? row.Cells["ResultParam_Caption"].Value?.ToString() : string.Empty,
                                ResultParam_Nominal = !string.IsNullOrEmpty(row.Cells["ResultParam_Nominal"].Value?.ToString()) ? row.Cells["ResultParam_Nominal"].Value?.ToString() : string.Empty,
                                ResultParam_Measured = !string.IsNullOrEmpty(row.Cells["ResultParam_Measured"].Value?.ToString()) ? row.Cells["ResultParam_Measured"].Value?.ToString() : string.Empty,
                                ResultParam_Unit = !string.IsNullOrEmpty(row.Cells["ResultParam_Unit"].Value?.ToString()) ? row.Cells["ResultParam_Unit"].Value?.ToString() : string.Empty
                            });
                        }
                    }
                }
                else
                    lstResultParamFormated = null;

                var lstEvaluationParameters = HelperApp.lstEvaluationParameters;

                #endregion

                #region REPORT - Check Exists

                if (CheckFileExists(outputFile))
                {
                    if (DialogResult.No == MessageBox.Show("  File Report already exists!" + "\n\n\n" + "Do you want ovewrite report test ? ", appMsg_Name, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))
                        return;
                    else
                        File.Delete(outputFile);
                }

                #endregion

                #region REPORT - Define Document

                PdfADocument pdfDoc = new PdfADocument(
                    new PdfWriter(outputFile),
                    PdfAConformanceLevel.PDF_A_1B,
                    new PdfOutputIntent("Custom", "", "http://www.color.org", "sRGB IEC61966-2.1",
                    new FileStream(reportProfile, FileMode.Open, FileAccess.Read)));


                PdfFont font = PdfFontFactory.CreateFont(reportFont, PdfEncodings.WINANSI,
                PdfFontFactory.EmbeddingStrategy.FORCE_EMBEDDED);

                PdfFont fontBold = PdfFontFactory.CreateFont(reportFontBold, PdfEncodings.WINANSI,
                PdfFontFactory.EmbeddingStrategy.FORCE_EMBEDDED);

                PageSize pageSize = PageSize.A4.Rotate();   // Set the page size and landscape
                Document document = new Document(pdfDoc, pageSize)
                    .SetFont(font);

                document.SetMargins(5, 10, 5, 10);

                #endregion

                #region REPORT - Define Images

                iText.Layout.Element.Image imgTest_Logo = new iText.Layout.Element.Image(ImageDataFactory.Create(reportImgLogo));

                iText.Layout.Element.Image imgTest_Chart = new iText.Layout.Element.Image(ImageDataFactory.Create(reportImgChart));

                imgTest_Chart
                  //.SetAutoScale(true)
                  //.SetFixedPosition(20, 50)
                  .SetHeight(maxSizeChartImage)
                  .SetWidth(maxSizeChartImage)
                  .SetTextAlignment(TextAlignment.CENTER)
                  .SetHorizontalAlignment(iText.Layout.Properties.HorizontalAlignment.CENTER);

                #endregion

                #region REPORT - Define Layout

                Table table = new Table(UnitValue.CreatePercentArray(12))
                    .UseAllAvailableWidth()
                    .SetFontSize(10);

                //table.SetMarginTop(0);
                //table.SetMarginBottom(0);

                #region Header

                #region Header title

                Cell cell_Title = new Cell(1, 12)
                    .SetTextAlignment(TextAlignment.CENTER)
                    .Add(new Paragraph("Functional Testbench")
                    .SetFontColor(new DeviceRgb(0, 0, 255))
                    .SetFont(fontBold))
                    .SetFontSize(12)
                    .SetPadding(5);
                table.AddCell(cell_Title);

                #endregion

                #region Header Rows

                int sizeFont_RowsHeader = 9;

                #region Header  Row 01

                Cell cell_Ident = new Cell(1, 4)
                    .SetTextAlignment(TextAlignment.LEFT)
                    .SetFontSize(sizeFont_RowsHeader)
                    .Add(new Paragraph($"Ident #: {strInfo}"));
                table.AddCell(cell_Ident);

                Cell cell_Booster = new Cell(1, 4)
                    .SetTextAlignment(TextAlignment.LEFT)
                    .SetFontSize(sizeFont_RowsHeader)
                    .Add(new Paragraph($"Booster #: {strInfo}"));
                table.AddCell(cell_Booster);

                Cell cell_TestOrder = new Cell(1, 4)
                    .SetTextAlignment(TextAlignment.LEFT)
                    .SetFontSize(sizeFont_RowsHeader)
                    .Add(new Paragraph($"Testorder #: {strInfo}"));
                table.AddCell(cell_TestOrder);

                #endregion

                #region Header  Row 02

                Cell cell_CustomerType = new Cell(1, 4)
                    .SetTextAlignment(TextAlignment.LEFT)
                    .SetFontSize(sizeFont_RowsHeader)
                    .Add(new Paragraph($"Customer/Type : {strInfo}"));
                table.AddCell(cell_CustomerType);

                Cell cell_TMC = new Cell(1, 4)
                    .SetTextAlignment(TextAlignment.LEFT)
                    .SetFontSize(sizeFont_RowsHeader)
                    .Add(new Paragraph($"TMC #: {strInfo}"));
                table.AddCell(cell_TMC);

                Cell cell_Operator = new Cell(1, 4)
                    .SetTextAlignment(TextAlignment.LEFT)
                    .SetFontSize(sizeFont_RowsHeader)
                    .Add(new Paragraph($"Operator: {HelperApp.UserName}"));
                table.AddCell(cell_Operator);

                #endregion

                #region Header  Row 03

                Cell cell_ProductionDate = new Cell(1, 4)
                    .SetTextAlignment(TextAlignment.LEFT)
                    .SetFontSize(sizeFont_RowsHeader)
                    .Add(new Paragraph($"Production Date: {strInfo}"));
                table.AddCell(cell_ProductionDate);

                Cell cell_TestingDate = new Cell(1, 4)
                    .SetTextAlignment(TextAlignment.LEFT)
                    .SetFontSize(sizeFont_RowsHeader)
                    .Add(new Paragraph($"Testing Date: {strInfo}"));
                table.AddCell(cell_TestingDate);

                Cell cell_PassedFailed = new Cell(1, 4)
                    .SetTextAlignment(TextAlignment.LEFT)
                    .SetFontSize(sizeFont_RowsHeader)
                    .Add(new Paragraph("[ ] Passed / [ ] Failed"));
                table.AddCell(cell_PassedFailed);

                #endregion

                #endregion

                #endregion

                #region Chart

                Cell cell_Chart = new Cell(maxSizeChartAreaTable + 11, 7)
                    .SetHorizontalAlignment(iText.Layout.Properties.HorizontalAlignment.CENTER)
                    .SetVerticalAlignment(VerticalAlignment.MIDDLE)
                    .SetTextAlignment(TextAlignment.CENTER)
                    .Add(imgTest_Chart);

                table.AddCell(cell_Chart);

                #endregion

                #region Table Result

                #region Table Result Title

                int sizeFont_TableResultHeader = 6;

                Cell cellTable_Title = new Cell(1, 5)
                    .SetTextAlignment(TextAlignment.CENTER)
                    //.SetPadding(3)
                    .SetFont(fontBold)
                    .SetFontSize(8)
                    .Add(new Paragraph($"{HelperApp._strNomeTesteSelecionado}"));
                table.AddCell(cellTable_Title);

                // Table Header
                Cell cellTableHeader_Result = new Cell(1, 3)
                    .SetTextAlignment(TextAlignment.CENTER)
                     .SetFont(fontBold)
                    .SetFontSize(sizeFont_TableResultHeader)
                    .Add(new Paragraph("Result"));
                table.AddCell(cellTableHeader_Result);

                Cell cellTableHeader_Nominal = new Cell(1, 1)
                    .SetTextAlignment(TextAlignment.CENTER)
                     .SetFont(fontBold)
                    .SetFontSize(sizeFont_TableResultHeader)
                    .Add(new Paragraph("Nominal"));
                table.AddCell(cellTableHeader_Nominal);

                Cell cellTableHeader_Measured = new Cell(1, 1)
                    .SetTextAlignment(TextAlignment.CENTER)
                     .SetFont(fontBold)
                    .SetFontSize(sizeFont_TableResultHeader)
                    .Add(new Paragraph("Measured"));
                table.AddCell(cellTableHeader_Measured);

                #endregion

                #region Table Result Content

                countForTable = lstResultParamFormated?.Count < maxSizeChartAreaTable ? lstResultParamFormated.Count : maxSizeChartAreaTable;

                if (lstResultParamFormated != null)
                {
                    for (int i = 0; i < countForTable; i++)
                    {
                        string strResult_Caption = !string.IsNullOrEmpty(lstResultParamFormated[i].ResultParam_Caption?.ToString()) ? lstResultParamFormated[i].ResultParam_Caption?.ToString() : strInfo;
                        string strResult_Unit = !string.IsNullOrEmpty(lstResultParamFormated[i].ResultParam_Unit?.ToString()) ? lstResultParamFormated[i].ResultParam_Unit?.ToString() : strInfo;
                        string strResult_Nominal = !string.IsNullOrEmpty(lstResultParamFormated[i].ResultParam_Nominal?.ToString()) ? lstResultParamFormated[i].ResultParam_Nominal?.ToString() : strInfo;
                        string strResult_Measured = !string.IsNullOrEmpty(lstResultParamFormated[i].ResultParam_Measured?.ToString()) ? lstResultParamFormated[i].ResultParam_Measured?.ToString() : strInfo;

                        Cell cellResult_Name = new Cell(1, 2)
                            .SetTextAlignment(TextAlignment.LEFT)
                            .SetFontSize(5)
                            .SetBorderRight(Border.NO_BORDER)
                            //.Add(new Paragraph(string.Concat($"{strInfo}_", i)));
                            .Add(new Paragraph(strResult_Caption));
                        table.AddCell(cellResult_Name);

                        Cell cellResult_Unit = new Cell(1, 1)
                            .SetTextAlignment(TextAlignment.CENTER)
                            .SetFontSize(5)
                            .SetBorderLeft(Border.NO_BORDER)
                            //.Add(new Paragraph(string.Concat($"{strInfo}_", i + 1)));
                            .Add(new Paragraph(strResult_Unit));
                        table.AddCell(cellResult_Unit);

                        Cell cellResult_Nominal = new Cell(1, 1)
                            .SetTextAlignment(TextAlignment.CENTER)
                            .SetFontSize(5)
                            //.Add(new Paragraph(string.Concat($"{strInfo}_", i + 2)));
                            .Add(new Paragraph(strResult_Nominal));
                        table.AddCell(cellResult_Nominal);

                        Cell cellResult_Measured = new Cell(1, 1)
                            .SetTextAlignment(TextAlignment.CENTER)
                            .SetFontSize(5)
                            //.Add(new Paragraph(string.Concat($"{strInfo}_", i + 3)));
                            .Add(new Paragraph(strResult_Measured));
                        table.AddCell(cellResult_Measured);
                    }
                }

                if (countForTable < maxSizeChartAreaTable)
                {
                    countForTable = maxSizeChartAreaTable - lstResultParamFormated.Count;

                    for (int i = 0; i < countForTable; i++)
                    {
                        Cell cellTableResult_Blank = new Cell(1, 5)
                            .SetBorder(Border.NO_BORDER)
                            .SetBorderRight(new SolidBorder(1))
                            .SetFontColor(new DeviceRgb(255, 255, 255))
                            .SetFontSize(5)
                            .Add(new Paragraph("|"));
                        table.AddCell(cellTableResult_Blank);
                    }
                }
                #endregion

                #region Table Result Footer

                Cell cellResult_FooterBlank = new Cell(1, 5)
                    .SetBorder(Border.NO_BORDER)
                    .SetBorderRight(new SolidBorder(1))
                    .SetFontColor(new DeviceRgb(255, 255, 255))
                    .SetFontSize(5)
                    .Add(new Paragraph("|"));
                table.AddCell(cellResult_FooterBlank);

                Cell cellTable_Footer = new Cell(1, 5)
                    .SetFontSize(7)
                    .SetTextAlignment(TextAlignment.CENTER)
                    .Add(new Paragraph($"{strInfo}"));
                table.AddCell(cellTable_Footer);

                #endregion

                #endregion

                #region Logo

                // Table Footer

                Cell cellTableFooter_Logo = new Cell(3, 3)
               .SetHorizontalAlignment(iText.Layout.Properties.HorizontalAlignment.CENTER)
               .SetVerticalAlignment(VerticalAlignment.MIDDLE)
               .SetTextAlignment(TextAlignment.CENTER)
               .SetBorderBottom(Border.NO_BORDER)
               .SetBorderRight(Border.NO_BORDER)
                //.Add(new Paragraph("LOGO"));
                .Add(imgTest_Logo.SetAutoScale(true));
                table.AddCell(cellTableFooter_Logo);

                // Table Linhas
                Cell cellTableFooter_01 = new Cell(1, 2)
                    .SetTextAlignment(TextAlignment.LEFT)
                    .SetBorder(Border.NO_BORDER)
                    .SetBorderRight(new SolidBorder(1))
                    .Add(new Paragraph("Technological Center"));
                table.AddCell(cellTableFooter_01);

                Cell cellTableFooter_02 = new Cell(1, 2)
                    .SetTextAlignment(TextAlignment.LEFT)
                    .SetBorder(Border.NO_BORDER)
                    .SetBorderRight(new SolidBorder(1))
                    .Add(new Paragraph("Continental"));
                table.AddCell(cellTableFooter_02);

                Cell cellTableFooter_03 = new Cell(1, 2)
                    .SetTextAlignment(TextAlignment.LEFT)
                    .SetBorder(Border.NO_BORDER)
                    .SetBorderRight(new SolidBorder(1))
                    .Add(new Paragraph("Varzea Paulista"));
                table.AddCell(cellTableFooter_03);

                Cell cellTableFooter_Blank = new Cell(3, 5)
                    .SetBorder(Border.NO_BORDER)
                    .SetBorderRight(new SolidBorder(1))
                    .SetFontColor(new DeviceRgb(255, 255, 255))
                    .SetFontSize(5)
                    .Add(new Paragraph("|"));
                table.AddCell(cellTableFooter_Blank);

                Cell cellTableFooter_Confidential = new Cell(1, 3)
                    .SetTextAlignment(TextAlignment.CENTER)
                    .SetBorder(Border.NO_BORDER)
                    .SetBorderBottom(new SolidBorder(1))
                    .Add(new Paragraph("Confidential"));
                table.AddCell(cellTableFooter_Confidential);

                Cell cellTableFooter_AllRights = new Cell(1, 2)
                    .SetTextAlignment(TextAlignment.LEFT)
                    .SetBorder(Border.NO_BORDER)
                    .SetBorderRight(new SolidBorder(1))
                    .SetBorderBottom(new SolidBorder(1))
                    .Add(new Paragraph("All rights reserved"));
                table.AddCell(cellTableFooter_AllRights);

                #endregion

                #endregion

                #region REPORT - Generate Document

                document.Add(table);
                document.Close();

                #endregion

                #region REPORT - Save/Open Document

                if (!CheckFileExists(outputFile))
                    MessageBox.Show("Failed, create report file !", appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    if (DialogResult.Yes == MessageBox.Show("\tFile Report Saved!" + "\n\n\n" + "Do you want Open report test ? ", appMsg_Name, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))
                        System.Diagnostics.Process.Start(outputFile);
                }

                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region Session USER LOGGIN

        //user info
        private static long _userId;

        private static string _userName;

        private static bool _isLoggedIn;

        //get e set
        public static long UserId
        {

            get { return HelperApp._userId; }
            set { HelperApp._userId = value; }
        }

        public static string UserName
        {

            get { return HelperApp._userName; }
            set { HelperApp._userName = value; }
        }

        public static bool IsLoggedIn
        {

            get { return HelperApp._isLoggedIn; }
            set { HelperApp._isLoggedIn = value; }
        }

        public string GetUserName(long id)
        {
            if (id <= 0)
                return string.Empty;

            BLL_Security_User _bll_Security_User = new BLL_Security_User();

            DataTable dt = _bll_Security_User.GetUserById(id);

            string _userName = (string)dt.Rows[0].Field<string>("ULogin");

            return _userName;
        }

        public long GetUserIdByName(string username)
        {
            if (string.IsNullOrEmpty(username))
                return 0;

            BLL_Security_User _bll_Security_User = new BLL_Security_User();

            DataTable dt = _bll_Security_User.GetUserByName(username.Trim().ToLower());

            long _userId = (long)dt.Rows[0].Field<long>("IdUser");

            return _userId;
        }

        public Model_SecurityUser GetUser(long id)
        {
            if (id <= 0)
                return null;

            BLL_Security_User _bll_Security_User = new BLL_Security_User();

            DataTable dt = _bll_Security_User.GetUserById(id);

            Model_SecurityUser modelUser = new Model_SecurityUser()
            {
                IdUser = (long)dt.Rows[0].Field<long>("IdUser"),
                ULogin = (string)dt.Rows[0].Field<string>("ULogin"),
                UName = (string)dt.Rows[0].Field<string>("UName"),
                ChangePassword = (bool)dt.Rows[0].Field<bool>("ChangePassword"),
                BlockedAt = (DateTime)dt.Rows[0].Field<DateTime>("BlockedAt"),
                Status = (bool)dt.Rows[0].Field<bool>("Status"),
                IdProfile = (long)dt.Rows[0].Field<long>("IdProfile")
            };

            return modelUser;
        }


        #endregion

        #region TASK BAR

        private static string _lblstsbar01;
        private static string _lblstsbar02;
        private static string _lblstsbar03;
        private static string _lblstsbar04;

        //get e set
        public static string lblstsbar01
        {

            get { return HelperApp._lblstsbar01; }
            set { HelperApp._lblstsbar01 = value; }
        }

        public static string lblstsbar02
        {

            get { return HelperApp._lblstsbar02; }
            set { HelperApp._lblstsbar02 = value; }
        }

        public static string lblstsbar03
        {

            get { return HelperApp._lblstsbar03; }
            set { HelperApp._lblstsbar03 = value; }
        }

        public static string lblstsbar04
        {

            get { return HelperApp._lblstsbar04; }
            set { HelperApp._lblstsbar04 = value; }
        }

        #endregion

        #region ExamType

        private static eEXAMTYPE _examtype;
        public static eEXAMTYPE examtype
        {
            get { return HelperApp._examtype; }
            set { HelperApp._examtype = value; }
        }

        public eEXAMTYPE SelectedExamType(long Id)
        {
            if (Id > 0)
                return (eEXAMTYPE)Id;

            return eEXAMTYPE.ET_NONE;
        }
        #endregion

        #region Session Project

        private static int _uiProjectSelecionado;
        private static string _strIdentProjectSelecionado;

        private static int _uiProjectTestSelecionado;
        private static string _strProjectTestSelecionado;

        //get e set
        public static int uiProjectSelecionado
        {
            get { return HelperApp._uiProjectSelecionado; }
            set { HelperApp._uiProjectSelecionado = value; }
        }
        public static string strIdentProjectSelecionado
        {
            get { return HelperApp._strIdentProjectSelecionado; }
            set { HelperApp._strIdentProjectSelecionado = value; }
        }

        public static int uiProjectTestSelecionado
        {
            get { return HelperApp._uiProjectTestSelecionado; }
            set { HelperApp._uiProjectTestSelecionado = value; }
        }
        public static string strProjectTestSelecionado
        {
            get { return HelperApp._strProjectTestSelecionado; }
            set { HelperApp._strProjectTestSelecionado = value; }
        }

        #endregion

        #region Session Test

        private static int _uiTesteSelecionado;
        private static string _strNomeTesteSelecionado;

        private static int _uiActuationMode;
        private static string _strActuationMode;

        //get e set
        public static int uiTesteSelecionado
        {
            get { return HelperApp._uiTesteSelecionado; }
            set { HelperApp._uiTesteSelecionado = value; }
        }
        public static string strNomeTesteSelecionado
        {
            get { return HelperApp._strNomeTesteSelecionado; }
            set { HelperApp._strNomeTesteSelecionado = value; }
        }

        public static int uiActuationMode
        {
            get { return HelperApp._uiActuationMode; }
            set { HelperApp._uiActuationMode = value; }
        }
        public static string strActuationMode
        {
            get { return HelperApp._strActuationMode; }
            set { HelperApp._strActuationMode = value; }
        }

        #endregion

        #region Session Tabs

        private static List<ActuationParameters_EvaluationParameters> _lstEvaluationParameters = new List<ActuationParameters_EvaluationParameters>();
        private static List<Model_Operational_TestTableParameters> _lstResultParam = new List<Model_Operational_TestTableParameters>();
        private static List<Model_Operational_TestTableParameters> _lstTempResultParam = new List<Model_Operational_TestTableParameters>();
        private static List<Model_Operational_TestTableParameters> _lstResultParamFormated = new List<Model_Operational_TestTableParameters>();
        private static Dictionary<string, string> _dicResultParam = new Dictionary<string, string>();
        public static List<ActuationParameters_EvaluationParameters> lstEvaluationParameters
        {
            get { return HelperApp._lstEvaluationParameters; }
            set { HelperApp._lstEvaluationParameters = value; }
        }
        public static List<Model_Operational_TestTableParameters> lstResultParam
        {
            get { return HelperApp._lstResultParam; }
            set { HelperApp._lstResultParam = value; }
        }
        public static List<Model_Operational_TestTableParameters> lstTempResultParam
        {
            get { return HelperApp._lstTempResultParam; }
            set { HelperApp._lstTempResultParam = value; }
        }
        public static List<Model_Operational_TestTableParameters> lstResultParamFormated
        {
            get { return HelperApp._lstResultParamFormated; }
            set { HelperApp._lstResultParamFormated = value; }
        }
        public static Dictionary<string, string> dicResultParam
        {
            get { return HelperApp._dicResultParam; }
            set { HelperApp._dicResultParam = value; }
        }

        #endregion

        #region TODO

        //RECUOPERAR VARIAVEIS DA CLASSE

        //Model_GVL cModelGVL = new Model_GVL();

        //var lstStrFieldsModelGVL = cModelGVL.GetType().GetFields().Select(f => f.Name).ToList();

        //var bindingFlags = BindingFlags.Instance |
        //                   BindingFlags.NonPublic |
        //                   BindingFlags.Public;
        //var lstObjFieldValuesModelGVL = cModelGVL.GetType()
        //                     .GetFields(bindingFlags)
        //                     .Select(field => field.GetValue(cModelGVL))
        //                     .ToList();

        #endregion
    }
}
