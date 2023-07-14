using DapperDemo.Core.DataAccess.Dapper;
using DapperDemo.DataAccess.Abstract;
using DapperDemo.Entities.Concrete;

namespace DapperDemo.DataAccess.Concrete.Dapper
{
    public class DpProductDal : DpEntityRepositoryBase<Product>, IProductDal
    {
    }
}
