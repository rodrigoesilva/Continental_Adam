using System;

namespace Continental.Project.Adam.UI.Models.Security
{
    public class Model_SecurityUser
    {
        public long IdUser { get; set; }
        public string ULogin { get; set; }
        public string UName { get; set; }
        public bool ChangePassword { get; set; }
        public DateTime LastUpdate { get; set; }
        public bool Status { get; set; }
        public long IdProfile { get; set; }
    }
}
