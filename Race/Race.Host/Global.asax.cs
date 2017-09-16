using Autofac;
using Autofac.Integration.WebApi;
using Race.BusinessService;
using Race.BusinessService.Contract;
using Race.Common.Service;
using Race.Host.Services;
using System.Reflection;
using System.Web.Http;

namespace Race.Host
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            ContainerBuilder builder = new ContainerBuilder();
            RegisterServices(builder);

            var config = GlobalConfiguration.Configuration;

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterWebApiFilterProvider(config);

            IContainer container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        private void RegisterServices(ContainerBuilder builder)
        {
            builder.RegisterType<RaceDayService>().As<IRaceDayService>();
            builder.RegisterType<ConfigManager>().As<IConfigManager>();
            builder.RegisterType<Serializer>().As<ISerializer>();
            builder.RegisterType<RaceService>().As<IRaceService>();
            builder.RegisterType<RaceDataProvider>().As<IRaceDataProvider>();
        }
    }
}
