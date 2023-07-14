using Autofac;
using DapperDemo.Business.Abstract;
using DapperDemo.Business.Concrete.Managers;
using DapperDemo.DataAccess.Abstract;
using DapperDemo.DataAccess.Concrete.Dapper;

namespace DapperDemo.Business.DependencyResolvers.Autofac
{
    public class BusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ProductManager>().As<IProductService>();
            builder.RegisterType<DpProductDal>().As<IProductDal>();
        }
    }
}
