using Autofac;
using SlotMachine.ConsoleServices;
using SlotMachine.ConsoleServices.Implementation;
using SlotMachine.Services;
using SlotMachine.Services.Implementation;

namespace SlotMachine.IoCContainer.Autofac
{
    public static class AutofacSetup
    {
        public static IContainer ConfigureDependencies()
        {
            ContainerBuilder builder = new ContainerBuilder();

            builder.RegisterType<ConsoleWorker>().As<IConsoleWorker>().InstancePerLifetimeScope();
            builder.RegisterType<GameEnvironment>().As<IGameEnvironment>().InstancePerLifetimeScope();
            builder.RegisterType<SymbolsRollGenerator>().As<ISymbolsRollGenerator>().InstancePerLifetimeScope();
            builder.RegisterType<NumberRowsAndColumnsProvider>().As<INumberRowsAndColumnsProvider>().InstancePerLifetimeScope();
            builder.RegisterType<SymbolsCoefficentsCalculator>().As<ISymbolsCoefficentsCalculator>().InstancePerLifetimeScope();
            builder.RegisterType<GameEngine>().As<IGameEngine>().InstancePerLifetimeScope();

            // Set the dependency resolver to be Autofac.
            IContainer container = builder.Build();

            return container;
        }
    }
}
