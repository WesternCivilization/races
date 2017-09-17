using Autofac;
using Autofac.Integration.WebApi;
using Race.BusinessService;
using Race.BusinessService.Contract;
using Race.Common.Service;
using System.Reflection;
using System.Web.Http;
using Race.ApplicationService.Services;

namespace Race.Host
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
                        
            ContainerBuilder builder = new ContainerBuilder();
            RegisterServices(builder);

            HttpConfiguration config = GlobalConfiguration.Configuration;

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterWebApiFilterProvider(config);

            IContainer container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        private void RegisterServices(ContainerBuilder builder)
        {
            builder.RegisterType<RaceDayService>().As<IRaceDayService>();
            builder.RegisterType<ConfigManager>().As<IConfigManager>();
            builder.RegisterType<RaceService>().As<IRaceService>();
            builder.RegisterType<RaceDataProvider>().As<IRaceDataProvider>();
        }
    }
}
