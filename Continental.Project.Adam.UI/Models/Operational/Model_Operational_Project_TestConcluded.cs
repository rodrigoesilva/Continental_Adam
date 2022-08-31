using System;

namespace Continental.Project.Adam.UI.Models.Operational
{
    public class Model_Operational_Project_TestConcluded
    {
        public long IdProjectTestConcluded { get; set; }

        public long IdProjectTestSample { get; set; }
        //public long IdProject { get; set; }
        public long IdTestAvailable { get; set; }
        //public string TestDateTime { get; set; }
        //public string TestTypeName { get; set; }
        //public string TestIdentName { get; set; }
        public string ProjectTestFileName { get; set; }
        public string LastUpdatePTC { get; set; }
        //public Model_Operational_Project Project { get; set; }

        public Model_Operational_Project_TestSample ProjectTestSample { get; set; }
    }
}
