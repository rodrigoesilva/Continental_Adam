using System;

namespace Continental.Project.Adam.UI.Models.Security
{
    public class Model_SecurityPassword
    {
        public long IdPassword { get; set; }
        public string UPass { get; set; }
        public DateTime LastUpdate { get; set; }
        public long IdUser { get; set; }
        public Model_SecurityUser User { get; set; }
    }
}
