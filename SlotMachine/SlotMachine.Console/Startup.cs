using Autofac;
using SlotMachine.ConsoleServices;
using SlotMachine.IoCContainer.Autofac;

namespace SlotMachine.ConsoleInterface
{
    public class Startup
    {
        static void Main(string[] args)
        {
            var container = AutofacSetup.ConfigureDependencies();
            var gameEnvironment = container.Resolve<IGameEnvironment>();

            gameEnvironment.RunGame();
        }
    }
}
