using Autofac;
using SlotMachine.IoCContainer.Autofac;
using SlotMachine.Models;
using SlotMachine.Services;
using System;

namespace SlotMachine.ConsoleInterface
{
    class Startup
    {
        static void Main(string[] args)
        {
            var container = AutofacSetup.ConfigureDependencies();
            var gameEngine = container.Resolve<IGameEngine>();

            decimal depositAmount = ConsoleWorker.GetDepositAmount();
            Result setAmountResult = gameEngine.SetDepositAmount(depositAmount);
            if (setAmountResult.IsError)
            {
                Console.WriteLine(setAmountResult.Message);
            }

            decimal stakeAmount = ConsoleWorker.GetStakeAmount(depositAmount);

            Result result = gameEngine.ExecuteGameTurn(stakeAmount);
        }
    }
}
