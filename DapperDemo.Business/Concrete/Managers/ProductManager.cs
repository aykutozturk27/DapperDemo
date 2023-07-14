using DapperDemo.Business.Abstract;
using DapperDemo.DataAccess.Abstract;
using DapperDemo.Entities.Concrete;

namespace DapperDemo.Business.Concrete.Managers
{
    public class ProductManager : IProductService
    {
        private readonly IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public IEnumerable<Product> GetAll(string prosedureName)
        {
            return _productDal.ExecuteStoreProcedureToList(prosedureName);
        }
    }
}
