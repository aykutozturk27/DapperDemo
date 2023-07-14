using DapperDemo.Entities.Concrete;

namespace DapperDemo.Business.Abstract
{
    public interface IProductService
    {
        IEnumerable<Product> GetAll(string prosedureName);
    }
}
