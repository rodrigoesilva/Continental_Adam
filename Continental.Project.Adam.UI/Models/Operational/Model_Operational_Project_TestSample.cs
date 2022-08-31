using Continental.Project.Adam.UI.Enum;
using Continental.Project.Adam.UI.Models.Manager;
using Continental.Project.Adam.UI.Models.Security;

namespace Continental.Project.Adam.UI.Models.Operational
{
    public class Model_Operational_Project_TestSample
    {
        public long IdProjectTestSample { get; set; }
        public long IdProject { get; set; }
        public long SampleSequence { get; set; }
        public string CustomerType { get; set; }
        public string Booster { get; set; }
        public string TMC { get; set; }
        public string ProductionDate { get; set; }
        public string T_O { get; set; }
        public long IdUser { get; set; }
        public string TestingDate { get; set; }
        public string Comment { get; set; }
        public string LastUpdatePTS { get; set; }

        public Model_Operational_Project Project { get; set; }
        public Model_SecurityUser User { get; set; }
        public Model_Manager_TestAvailable TestAvailable { get; set; }
    }
}
