using Continental.Project.Adam.UI.Enum;
using Continental.Project.Adam.UI.Models.Security;

namespace Continental.Project.Adam.UI.Models.Operational
{
    public class Model_Operational_Project
    {
        public long Id { get; set; }
        public string Identification { get; set; }
        public string CustomerType { get; set; }
        public string Booster { get; set; }
        public string TMC { get; set; }
        public string ProductionDate { get; set; }
        public string T_O { get; set; }
        public long IdUserTester { get; set; }
        public string TestingDate { get; set; }
        public string Comment { get; set; }
        public eEXAMTYPE examtype { get; set; }

        public bool is_user_defined { get; set; }
        public bool is_Created { get; set; }
        public string PrjTestFileName { get; set; }

        public Model_SecurityUser User { get; set; }
    }
}
