namespace DapperDemo.Core.Entities.DataTable
{
    public class DataTableRequest<T>
    {
        public int draw { get; set; }
        public int length { get; set; }
        public int start { get; set; }
        public ColumnRequest[] columns { get; set; }
        public Order[] order { get; set; }
        public SearchRequest search { get; set; }
        public T FilterRequest { get; set; }
    }
}
