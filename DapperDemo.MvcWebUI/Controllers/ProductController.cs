using DapperDemo.Business.Abstract;
using DapperDemo.Core.Entities.DataTable;
using DapperDemo.Core.Utilities.Constants;
using DapperDemo.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace DapperDemo.MvcWebUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public ActionResult Index()
        {
           return View();
        }

        [HttpPost]
        public ActionResult GetProducts(DataTableRequest<Product> model)
        {
            var draw = model.draw;
            var start = model.start;
            var pageSize = model.length;

            var productList = _productService.GetAll(SqlProsedure.GetProductList);
            var resultList = productList.Skip(start).Take(pageSize).ToList();
            var result = new DataTableResponse(draw, resultList, productList.Count(), productList.Count());
            return Json(result);
        }
    }
}
