using System;

namespace Continental.Project.Adam.UI.Models.Operational
{
    public class Model_Operational_Project_TestConcluded
    {
        public long IdProjectTestConcluded { get; set; }
        public long IdProject { get; set; }
        public long IdTestAvailable { get; set; }
        public string TestDateTime { get; set; }
        public string TestTypeName { get; set; }
        public string TestIdentName { get; set; }
        public string TestFileName { get; set; }
        public string LastUpdate { get; set; }
        public Model_Operational_Project Project { get; set; }
    }
}
