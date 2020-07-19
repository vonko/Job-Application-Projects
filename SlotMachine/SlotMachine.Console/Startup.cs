using Autofac;
using SlotMachine.BusinessServices;
using SlotMachine.IoCContainer.Autofac;

namespace SlotMachine.ConsoleInterface
{
    public class Startup
    {
        static void Main(string[] args)
        {
            var container = AutofacSetup.ConfigureDependencies();
            var gameEnvironment = container.Resolve<IGameEnvironment>();

            gameEnvironment.StartGame();
        }
    }
}
