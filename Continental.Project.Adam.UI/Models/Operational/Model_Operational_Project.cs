
namespace Continental.Project.Adam.UI.Models.Operational
{
    public class Model_Operational_Project
    {
        public long IdProject { get; set; }
        public string PartNumber { get; set; }
        public string Identification { get; set; }
        public string LastUpdatePRJ { get; set; }

        //Not BD
        public bool is_user_defined { get; set; }
        public bool is_Created { get; set; }
        public bool is_OnLIne { get; set; }
    }
}
