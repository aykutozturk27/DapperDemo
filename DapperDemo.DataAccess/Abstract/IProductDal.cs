using DapperDemo.Core.DataAccess;
using DapperDemo.Entities.Concrete;

namespace DapperDemo.DataAccess.Abstract
{
    public interface IProductDal : IEntityRepository<Product>
    {
    }
}
