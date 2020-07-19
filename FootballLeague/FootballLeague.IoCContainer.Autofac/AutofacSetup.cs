using Autofac;
using Autofac.Integration.Mvc;
using FootballLeague.DataAccess;
using FootballLeague.DataAccess.Implementation;
using FootballLeague.Services;
using FootballLeague.Services.Implementation;
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
            
            builder.RegisterType<DALContext>().As<IDALContext>().InstancePerLifetimeScope();

            builder.RegisterType<CacheProviderService>().As<ICacheProviderService>().InstancePerLifetimeScope();
            builder.RegisterType<FootballTeamsService>().As<IFootballTeamsService>().InstancePerLifetimeScope();
            builder.RegisterType<PlayedGamesService>().As<IPlayedGamesService>().InstancePerLifetimeScope();
            builder.RegisterType<RankingsService>().As<IRankingsService>().InstancePerLifetimeScope();

            //builder.RegisterType<IMapper>().As<Mapper>().InstancePerLifetimeScope();

            // Set the dependency resolver to be Autofac.
            IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            return container;
        }
    }
}
