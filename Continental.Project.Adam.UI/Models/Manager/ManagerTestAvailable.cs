namespace Continental.Project.Adam.UI.Models.Manager
{
    public class ManagerTestAvailable
    {
        public long Id { get; set; }
        public string Test { get; set; }
        public bool IsOriginalConsumer { get; set; }
        public long IdTestGroup { get; set; }
        public int Status { get; set; }
        public virtual ManagerTestGroup TestGroup { get; set; }
    }
}