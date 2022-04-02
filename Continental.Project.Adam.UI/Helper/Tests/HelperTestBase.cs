using Continental.Project.Adam.UI.Enum;
using Continental.Project.Adam.UI.Models.COM;
using Continental.Project.Adam.UI.Models.Operational;
using Continental.Project.Adam.UI.Models.Settings;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Continental.Project.Adam.UI.Helper.Tests
{
    public class HelperTestBase
    {
        #region HBM

        private static string _strTimeStamp;
        private static double _dblAnalogVar01;
        private static double _dblAnalogVar02;
        private static double _dblAnalogVar03;
        private static double _dblAnalogVar04;
        private static bool _running;
        public static string strTimeStamp
        {
            get { return HelperTestBase._strTimeStamp; }
            set { HelperTestBase._strTimeStamp = value; }
        }
        public static double dblAnalogVar01
        {
            get { return HelperTestBase._dblAnalogVar01; }
            set { HelperTestBase._dblAnalogVar01 = value; }
        }
        public static double dblAnalogVar02
        {
            get { return HelperTestBase._dblAnalogVar02; }
            set { HelperTestBase._dblAnalogVar02 = value; }
        }
        public static double dblAnalogVar03
        {
            get { return HelperTestBase._dblAnalogVar03; }
            set { HelperTestBase._dblAnalogVar03 = value; }
        }
        public static double dblAnalogVar04
        {
            get { return HelperTestBase._dblAnalogVar04; }
            set { HelperTestBase._dblAnalogVar04 = value; }
        }

        public static bool running
        {
            get { return HelperTestBase._running; }
            set { HelperTestBase._running = value; }
        }
        #endregion

        #region Test Type

        private static eEXAMTYPE _eExamType;
        public static eEXAMTYPE eExamType
        {
            get { return HelperTestBase._eExamType; }
            set { HelperTestBase._eExamType = value; }
        }

        private static Model_Operational_Project _currentProjectTest = new Model_Operational_Project();
        public static Model_Operational_Project currentProjectTest
        {
            get { return HelperTestBase._currentProjectTest; }
            set { HelperTestBase._currentProjectTest = value; }
        }

        //StringBuilder AppendTxtData_Header_ActuationType
        private static StringBuilder _sbHeaderAppendTxtData;
        public static StringBuilder sbHeaderAppendTxtData
        {
            get { return HelperTestBase._sbHeaderAppendTxtData; }
            set { HelperTestBase._sbHeaderAppendTxtData = value; }
        }

        //StringBuilder AppendTxtData_Header_Result
        private static StringBuilder _sbHeaderResultsAppendTxtData;
        public static StringBuilder sbHeaderResultsAppendTxtData
        {
            get { return HelperTestBase._sbHeaderResultsAppendTxtData; }
            set { HelperTestBase._sbHeaderResultsAppendTxtData = value; }
        }

        #endregion

        #region MODEL GVL

        private static Model_GVL _Model_GVL = new Model_GVL();
        public static Model_GVL Model_GVL
        {
            get { return HelperTestBase._Model_GVL; }
            set { HelperTestBase._Model_GVL = value; }
        }
        #endregion

        #region General Settings

        #region check box

        private static bool _chkstartFromActual;
        private static bool _chkWaitForUse;
        private static bool _chkPistonLock;

        //get e set
        public static bool chkstartFromActual
        {

            get { return HelperTestBase._chkstartFromActual; }
            set { HelperTestBase._chkstartFromActual = value; }
        }
        public static bool chkWaitForUse
        {

            get { return HelperTestBase._chkWaitForUse; }
            set { HelperTestBase._chkWaitForUse = value; }
        }

        public static bool chkPistonLock
        {

            get { return HelperTestBase._chkPistonLock; }
            set { HelperTestBase._chkPistonLock = value; }
        }

        #endregion

        #region Vacuum

        private static double _vacuum;
        private static double _vacuumMin;
        private static double _vacuumMax;

        //get e set
        public static double Vacuum
        {
            get { return HelperTestBase._vacuum; }
            set { HelperTestBase._vacuum = value; }
        }
        public static double VacuumMin
        {
            get { return HelperTestBase._vacuumMin; }
            set { HelperTestBase._vacuumMin = value; }
        }
        public static double VacuumMax
        {
            get { return HelperTestBase._vacuumMax; }
            set { HelperTestBase._vacuumMax = value; }
        }

        #endregion

        #region Consumer

        #region check box

        private static bool _radOriginalConsumer;
        private static bool _radHoseConsumer;

        //get e set
        public static bool radOriginalConsumer
        {
            get { return HelperTestBase._radOriginalConsumer; }
            set { HelperTestBase._radOriginalConsumer = value; }
        }
        public static bool radHoseConsumer
        {
            get { return HelperTestBase._radHoseConsumer; }
            set { HelperTestBase._radHoseConsumer = value; }
        }

        #endregion

        #region HoseConsumer
        private static int _hoseConsumerPC { get; set; }
        private static int _hoseConsumerSC { get; set; }

        //get e set
        public static int HoseConsumerPC
        {
            get { return HelperTestBase._hoseConsumerPC; }
            set { HelperTestBase._hoseConsumerPC = value; }
        }
        public static int HoseConsumerSC
        {
            get { return HelperTestBase._hoseConsumerSC; }
            set { HelperTestBase._hoseConsumerSC = value; }
        }

        #endregion

        #endregion

        #endregion

        #region Actuation

        private static E_TestActuationType _eTestActuationType;
        private static int _actuationType;
        private static double _maxForce;
        private static double _forceGradient;

        //get e set
        public static E_TestActuationType ETestActuationType
        {
            get { return HelperTestBase._eTestActuationType; }
            set { HelperTestBase._eTestActuationType = value; }
        }
        public static int ActuationType
        {
            get { return HelperTestBase._actuationType; }
            set { HelperTestBase._actuationType = value; }
        }
        public static double MaxForce
        {
            get { return HelperTestBase._maxForce; }
            set { HelperTestBase._maxForce = value; }
        }
        public static double ForceGradient
        {
            get { return HelperTestBase._forceGradient; }
            set { HelperTestBase._forceGradient = value; }
        }

        #endregion

        #region Evaluation Parameters

        #region check box

        private static string _chkOutputPC_lbl = "Output PC";

        private static string _chkOutputPC10_1_Printer_lbl = "Printer 10:1";
        private static bool _chkOutputPC { get; set; }
        private static bool _chkOutputPC10_1_Printer { get; set; }

        private static string _chkOutputSC_lbl = "Output SC";

        private static string _chkOutputSC10_1_Printer_lbl = "Printer 10:1";
        private static bool _chkOutputSC { get; set; }
        private static bool _chkOutputSC10_1_Printer { get; set; }

        //get e set
        public static string ChkOutputPC_lbl
        {
            get { return HelperTestBase._chkOutputPC_lbl; }
            set { HelperTestBase._chkOutputPC_lbl = value; }
        }
        public static string ChkOutputPC10_1_Printer_lbl
        {
            get { return HelperTestBase._chkOutputPC10_1_Printer_lbl; }
            set { HelperTestBase._chkOutputPC10_1_Printer_lbl = value; }
        }
        public static bool ChkOutputPC
        {
            get { return HelperTestBase._chkOutputPC; }
            set { HelperTestBase._chkOutputPC = value; }
        }
        public static bool ChkOutputPC10_1_Printer
        {
            get { return HelperTestBase._chkOutputPC10_1_Printer; }
            set { HelperTestBase._chkOutputPC10_1_Printer = value; }
        }

        public static string ChkOutputSC_lbl
        {
            get { return HelperTestBase._chkOutputSC_lbl; }
            set { HelperTestBase._chkOutputSC_lbl = value; }
        }
        public static string ChkOutputSC10_1_Printer_lbl
        {
            get { return HelperTestBase._chkOutputSC10_1_Printer_lbl; }
            set { HelperTestBase._chkOutputSC10_1_Printer_lbl = value; }
        }
        public static bool ChkOutputSC
        {
            get { return HelperTestBase._chkOutputSC; }
            set { HelperTestBase._chkOutputSC = value; }
        }
        public static bool ChkOutputSC10_1_Printer
        {
            get { return HelperTestBase._chkOutputSC10_1_Printer; }
            set { HelperTestBase._chkOutputSC10_1_Printer = value; }
        }
        #endregion

        # region ParamList

        private static Model_TabActuationParameters_EvaluationParameters _paramEval = new Model_TabActuationParameters_EvaluationParameters();

        //get e set
        public static Model_TabActuationParameters_EvaluationParameters ParamEval
        {
            get { return HelperTestBase._paramEval; }
            set { HelperTestBase._paramEval = value; }
        }

        #endregion

        #region Grid Evaluation Parameters

        private static BindingList<ActuationParameters_EvaluationParameters> _bindingListGridEvaluationParameters = new BindingList<ActuationParameters_EvaluationParameters>();

        //get e set
        public static BindingList<ActuationParameters_EvaluationParameters> bindingListGridEvaluationParameters
        {
            get { return HelperTestBase._bindingListGridEvaluationParameters; }
            set { HelperTestBase._bindingListGridEvaluationParameters = value; }
        }
        #endregion

        #region Grid Test Table Parameters

        private static BindingList<Model_Operational_TestTableParameters> _bindingListGridTestTableParameters = new BindingList<Model_Operational_TestTableParameters>();

        //get e set
        public static BindingList<Model_Operational_TestTableParameters> bindingListGridTestTableParameters
        {
            get { return HelperTestBase._bindingListGridTestTableParameters; }
            set { HelperTestBase._bindingListGridTestTableParameters = value; }
        }

        private static List<Model_Operational_TestTableParameters> _listGridTestTableParameters = new List<Model_Operational_TestTableParameters>();

        //get e set
        public static List<Model_Operational_TestTableParameters> listGridTestTableParameters
        {
            get { return HelperTestBase._listGridTestTableParameters; }
            set { HelperTestBase._listGridTestTableParameters = value; }
        }
        #endregion

        #endregion
    }
}
