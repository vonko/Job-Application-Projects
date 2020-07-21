using Autofac;
using Autofac.Integration.Mvc;
using DevelopersSurvey.DataAccess;
using DevelopersSurvey.DataAccess.Implementation;
using DevelopersSurvey.Services;
using DevelopersSurvey.Services.Implementation;
using DevelopersSurvey.Services.Implementation.Utils;
using DevelopersSurvey.Services.Utils;
using System.Web.Mvc;

namespace FootballLeagueAutofacSetup
{
    public static class AutofacSetup
    {
        public static IContainer ConfigureDependencies(ContainerBuilder builder)
        {
            // OPTIONAL: Register web abstractions like HttpContextBase.
            builder.RegisterModule<AutofacWebTypesModule>();

            // OPTIONAL: Enable property injection in view pages.
            builder.RegisterSource(new ViewRegistrationSource());

            // OPTIONAL: Enable property injection into action filters.
            builder.RegisterFilterProvider();

            // OPTIONAL: Enable action method parameter injection (RARE).
            //builder.InjectActionInvoker();

            builder.RegisterType<FootballTeamsRepository>().As<IFootballTeamsRepository>().InstancePerLifetimeScope();
            builder.RegisterType<PlayedGamesRepository>().As<IPlayedGamesRepository>().InstancePerLifetimeScope();

            builder.RegisterType<CacheProviderService>().As<ICacheProviderService>().InstancePerLifetimeScope();
            builder.RegisterType<FootballTeamsService>().As<IFootballTeamsService>().InstancePerLifetimeScope();
            builder.RegisterType<PlayedGamesService>().As<IPlayedGamesService>().InstancePerLifetimeScope();
            builder.RegisterType<RankingsService>().As<IRankingsService>().InstancePerLifetimeScope();
            builder.RegisterType<DataSourceService>().As<IDataSourceService>().InstancePerLifetimeScope();
            builder.RegisterType<DateTimeProvider>().As<IDateTimeProvider>().InstancePerLifetimeScope();

            //builder.RegisterType<IMapper>().As<Mapper>().InstancePerLifetimeScope();

            // Set the dependency resolver to be Autofac.
            IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            return container;
        }
    }
}
