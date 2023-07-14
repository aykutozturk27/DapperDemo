namespace DapperDemo.Core.Entities.DataTable
{
    public class ColumnRequest
    {
        public string data { get; set; }
        public string name { get; set; }
        public bool orderable { get; set; }
        public bool searchable { get; set; }
        public SearchRequest search { get; set; }
    }
}
