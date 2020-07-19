using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.SignalR;
using FootballLeague.Services.Automapper;
using FootballLeague.Web.Automapper;
using FootballLeagueAutofacSetup;
using Microsoft.AspNet.SignalR;
using System.Reflection;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace FootballLeague.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);

            RouteConfig.RegisterRoutes(RouteTable.Routes);

            BundleConfig.RegisterBundles(BundleTable.Bundles);

            ConfigureDependencyInjection();

            AutomapperConfiguration.Configure<WebLayerMapperProfile>(cfg =>
            {
                cfg.AddProfile(new ServiceLayerMapperProfile());
                cfg.IgnoreUnmapped();
            });      
        }

        private static void ConfigureDependencyInjection()
        {
            ContainerBuilder builder = new ContainerBuilder();

            var config = new HubConfiguration();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterHubs(Assembly.GetExecutingAssembly());

            IContainer container = AutofacSetup.ConfigureDependencies(builder);

            GlobalHost.DependencyResolver = new Autofac.Integration.SignalR.AutofacDependencyResolver(container);
        }
    }
}
