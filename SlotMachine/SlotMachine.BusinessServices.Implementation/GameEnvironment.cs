using SlotMachine.ConsoleServices;
using SlotMachine.Models;

namespace SlotMachine.BusinessServices.Implementation
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

        public void StartGame()
        {
            bool canUserContinuePlaying = true;

            decimal currentBalance = this.consoleWorker.GetDepositAmount();
            Result setDepositResult = this.gameEngine.SetDepositAmount(currentBalance);
            if (setDepositResult.IsError)
            {
                this.consoleWorker.WriteLine(setDepositResult.Message);
                canUserContinuePlaying = false;
            }

            while (canUserContinuePlaying)
            {
                Result<GameTurnResult> gameTurnResult = this.RunGame(currentBalance);
                if (gameTurnResult.IsError)
                {
                    this.consoleWorker.WriteLine(gameTurnResult.Message);
                    break;
                }
                currentBalance = gameTurnResult.Data.CurrentBalance;

                if (currentBalance <= 0)
                {
                    canUserContinuePlaying = false;
                }
            }
        }

        private Result<GameTurnResult> RunGame(decimal depositAmount)
        {
            decimal stakeAmount = this.consoleWorker.GetStakeAmount(depositAmount);

            Result<GameTurnResult> result = this.gameEngine.ExecuteGameTurn(stakeAmount);
            if (result.IsError)
            {
                return result;
            }

            this.consoleWorker.PrintSymbols(result.Data.Symbols);
            this.consoleWorker.PrintBalance(result.Data.AmountWon, result.Data.CurrentBalance);

            return result;
        }
    }
}
