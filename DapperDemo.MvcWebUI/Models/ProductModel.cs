namespace DapperDemo.MvcWebUI.Models
{
    public class ProductModel
    {
        public int ProductID { get; set; }
        public string? ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public string? QuantityPerUnit { get; set; }
        public short UnitsInStock { get; set; }
    }
}
