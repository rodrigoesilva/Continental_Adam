namespace Continental.Project.Adam.UI.Models.Manager
{
    public class Model_Manager_TestAvailable
    {
        public long IdTestAvailable { get; set; }
        public string Test { get; set; }
        public bool IsOriginalConsumer { get; set; }
        public long IdTestGroup { get; set; }
        public int Status { get; set; }
        public virtual Model_Manager_TestGroup TestGroup { get; set; }
    }
}