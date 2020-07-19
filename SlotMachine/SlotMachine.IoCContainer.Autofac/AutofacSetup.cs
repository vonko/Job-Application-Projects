using Autofac;
using SlotMachine.BusinessServices;
using SlotMachine.BusinessServices.Implementation;
using SlotMachine.ConsoleServices;
using SlotMachine.ConsoleServices.Implementation;

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
            builder.RegisterType<SymbolsCoefficientsProvider>().As<ISymbolsCoefficientsProvider>().InstancePerLifetimeScope();
            builder.RegisterType<SymbolsCoefficientsCalculator>().As<ISymbolsCoefficientsCalculator>().InstancePerLifetimeScope();
            builder.RegisterType<SymbolsChanceProvider>().As<ISymbolsChanceProvider>().InstancePerLifetimeScope();
            builder.RegisterType<GameEngine>().As<IGameEngine>().InstancePerLifetimeScope();

            // Set the dependency resolver to be Autofac.
            IContainer container = builder.Build();

            return container;
        }
    }
}
