using Autofac;
using Autofac.Integration.WebApi;
using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using MongoDB.Driver;
using Business;
using Common.BusinessContracts;
using Common.DataAccessContracts;
using DataAccess;
using UbigeoApi.Filters;

namespace UbigeoApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        public static IContainer Container { get; set; }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            GlobalConfiguration.Configuration.Filters.Add(new ExceptionActionFilter());
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var builder = new ContainerBuilder();
            var config = GlobalConfiguration.Configuration;

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterWebApiFilterProvider(config);
            builder.RegisterType<MongoClient>().As<IMongoClient>().SingleInstance();
            builder.RegisterType<PoliceRepository>().As<IPoliceRepository>();
            builder.RegisterType<DepartmentRepository>().As<IDepartmentRepository>();
            builder.RegisterType<DistrictRepository>().As<IDistrictRepository>();
            builder.RegisterType<ProvinceRepository>().As<IProvinceRepository>();
            builder.RegisterType<PoliceManager>().As<IPoliceManager>();
            builder.RegisterType<UbigeoManager>().As<IUbigeoManager>();

            Container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(Container);
        }
    }
}
