using SlotMachine.Models;
using SlotMachine.UserInteractionServices;

namespace SlotMachine.BusinessServices.Implementation
{
    public class GameEnvironment : IGameEnvironment
    {
        private readonly IUserInteracter userInteracter;
        private readonly IGameEngine gameEngine;

        public GameEnvironment(IUserInteracter userInteracter,
                               IGameEngine gameEngine)
        {
            this.userInteracter = userInteracter;
            this.gameEngine = gameEngine;
        }

        public void StartGame()
        {
            bool canUserContinuePlaying = true;

            decimal currentBalance = this.userInteracter.GetDepositAmount();
            Result setDepositResult = this.gameEngine.SetDepositAmount(currentBalance);
            if (setDepositResult.IsError)
            {
                this.userInteracter.WriteLine(setDepositResult.Message);
                canUserContinuePlaying = false;
            }

            while (canUserContinuePlaying)
            {
                Result<GameTurnResult> gameTurnResult = this.RunGame(currentBalance);
                if (gameTurnResult.IsError)
                {
                    this.userInteracter.WriteLine(gameTurnResult.Message);
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
            decimal stakeAmount = this.userInteracter.GetStakeAmount(depositAmount);

            Result<GameTurnResult> result = this.gameEngine.ExecuteGameTurn(stakeAmount);
            if (result.IsError)
            {
                return result;
            }

            this.userInteracter.PrintSymbols(result.Data.Symbols);
            this.userInteracter.PrintBalance(result.Data.AmountWon, result.Data.CurrentBalance);

            return result;
        }
    }
}
