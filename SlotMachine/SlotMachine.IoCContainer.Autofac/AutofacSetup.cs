using Autofac;
using SlotMachine.Services;
using SlotMachine.Services.Implementation;

namespace SlotMachine.IoCContainer.Autofac
{
    public static class AutofacSetup
    {
        public static IContainer ConfigureDependencies()
        {
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterType<GameEngine>().As<IGameEngine>().InstancePerLifetimeScope();

            // Set the dependency resolver to be Autofac.
            IContainer container = builder.Build();

            return container;
        }
    }
}
