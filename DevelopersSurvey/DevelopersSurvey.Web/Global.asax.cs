using Autofac;
using Autofac.Integration.Mvc;
using DevelopersSurvey.Services.Automapper;
using DevelopersSurvey.Web.Automapper;
using DevelopersSurveyAutofacSetup;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace DevelopersSurvey.Web
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

            //var config = new HubConfiguration();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            //builder.RegisterHubs(Assembly.GetExecutingAssembly());

            IContainer container = AutofacSetup.ConfigureDependencies(builder);

            //GlobalHost.DependencyResolver = new Autofac.Integration.SignalR.AutofacDependencyResolver(container);
        }
    }
}
