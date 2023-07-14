using DapperDemo.Core.Entities;

namespace DapperDemo.Entities.Concrete
{
    public class Product : IEntity
    {
        public int ProductID { get; set; }
        public string? ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public string? QuantityPerUnit { get; set; }
        public short UnitsInStock { get; set; }
    }
}
