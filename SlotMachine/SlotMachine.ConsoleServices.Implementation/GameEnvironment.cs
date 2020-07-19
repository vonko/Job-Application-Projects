using SlotMachine.Models;
using SlotMachine.Services;

namespace SlotMachine.ConsoleServices.Implementation
{
    public class GameEnvironment : IGameEnvironment
    {
        private readonly IConsoleWorker consoleWorker;
        private readonly IGameEngine gameEngine;

        public GameEnvironment(IConsoleWorker consoleWorker,
                               IGameEngine gameEngine)
        {
            this.consoleWorker = consoleWorker;
            this.gameEngine = gameEngine;
        }

        public void RunGame()
        {
            decimal depositAmount = this.consoleWorker.GetDepositAmount();
            Result setAmountResult = this.gameEngine.SetDepositAmount(depositAmount);
            if (setAmountResult.IsError)
            {
                this.consoleWorker.WriteLine(setAmountResult.Message);
            }

            decimal stakeAmount = this.consoleWorker.GetStakeAmount(depositAmount);

            Result<GameTurnResult> result = this.gameEngine.ExecuteGameTurn(stakeAmount);
            if (result.IsError)
            {
                this.consoleWorker.WriteLine(result.Message);
            }

            this.consoleWorker.PrintSymbols(result.Data.Symbols);
        }
    }
}
