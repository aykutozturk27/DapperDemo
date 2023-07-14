namespace DapperDemo.Core.Entities.DataTable
{
    public class DataTableResponse
    {
        public int draw { get; set; }
        public IEnumerable<object> data { get; set; }
        public int recordsTotal { get; set; }
        public int recordsFiltered { get; set; }
        public DataTableResponse(int draw, IEnumerable<object> data, int recordsFiltered, int recordsTotal)
        {
            this.draw = draw;
            this.data = data;
            this.recordsFiltered = recordsFiltered;
            this.recordsTotal = recordsTotal;
        }
    }
}
