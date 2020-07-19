using SlotMachine.Models;

namespace SlotMachine.BusinessServices.Implementation
{
    public class GameEngine : IGameEngine
    {
        private decimal currentBalance;
        private readonly ISymbolsRollGenerator symbolsGenerator;
        private readonly INumberRowsAndColumnsProvider rowsAndColumnsProvider;
        private readonly ISymbolsCoefficentsCalculator symbolsCoefficentsCalculator;

        public GameEngine(ISymbolsRollGenerator symbolsGenerator,
                          INumberRowsAndColumnsProvider rowsAndColumnsProvider,
                          ISymbolsCoefficentsCalculator symbolsCoefficentsCalculator)
        {
            this.symbolsGenerator = symbolsGenerator;
            this.rowsAndColumnsProvider = rowsAndColumnsProvider;
            this.symbolsCoefficentsCalculator = symbolsCoefficentsCalculator;
        }

        public Result SetDepositAmount(decimal depositAmount)
        {
            Result result = new Result();
            if (depositAmount <= 0)
            {
                return result.SetError($"Please enter a valid deposit amount!");
            }

            this.currentBalance = depositAmount;

            return result.SetSuccess("Amount set successfully.");
        }

        public Result<GameTurnResult> ExecuteGameTurn(decimal stakeAmount)
        {
            Result<GameTurnResult> result = new Result<GameTurnResult>();
            if (stakeAmount <= 0)
            {
                result.SetError($"Please enter a valid stake amount!");

                return result;
            }

            if (stakeAmount > this.currentBalance)
            {
                result.SetError($"Stake amount cannot be bigger than the remaining deposit amount!");

                return result;
            }

            Result<SymbolsSet> generateSymbolsResult = this.symbolsGenerator.GenerateSymbols(this.rowsAndColumnsProvider.NumberRows, 
                                                                                             this.rowsAndColumnsProvider.NumberColumns);
            if (generateSymbolsResult.IsError)
            {
                result.SetError(generateSymbolsResult.Message);

                return result;
            }

            SymbolsSet generatedSymbols = generateSymbolsResult.Data;

            decimal coefficent = this.symbolsCoefficentsCalculator.CalculateCoefficent(generatedSymbols);
            decimal amountWon = stakeAmount * coefficent;
            if (coefficent == 0)
            {
                this.currentBalance -= stakeAmount;
            }
            else
            {
                amountWon = stakeAmount * coefficent;
                this.currentBalance += amountWon;
            }

            GameTurnResult gameTurnResult = new GameTurnResult()
            {
                Symbols = generatedSymbols,
                AmountWon = amountWon,
                CurrentBalance = this.currentBalance
            };

            return result.SetData(gameTurnResult);
        }
    }
}
