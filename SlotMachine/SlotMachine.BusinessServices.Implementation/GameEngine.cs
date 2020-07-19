using SlotMachine.BusinessServices.Providers;
using SlotMachine.BusinessServices.SymbolsProcessorServices;
using SlotMachine.Models;
using SlotMachine.Models.Symbols;

namespace SlotMachine.BusinessServices.Implementation
{
    public class GameEngine : IGameEngine
    {
        private decimal currentBalance;
        private readonly ISymbolsRollGenerator symbolsGenerator;
        private readonly INumberRowsAndColumnsProvider rowsAndColumnsProvider;
        private readonly ISymbolsCoefficientsCalculator symbolsCoefficientsCalculator;

        public GameEngine(ISymbolsRollGenerator symbolsGenerator,
                          INumberRowsAndColumnsProvider rowsAndColumnsProvider,
                          ISymbolsCoefficientsCalculator symbolsCoefficientsCalculator)
        {
            this.symbolsGenerator = symbolsGenerator;
            this.rowsAndColumnsProvider = rowsAndColumnsProvider;
            this.symbolsCoefficientsCalculator = symbolsCoefficientsCalculator;
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

            Result validateStakeResult = this.ValidateStakeAmount(stakeAmount);
            if (validateStakeResult.IsError)
            {
                result.SetError(validateStakeResult.Message);

                return result;
            }

            this.currentBalance -= stakeAmount;

            Result<SymbolsSet> generateSymbolsResult = this.symbolsGenerator.GenerateSymbols(this.rowsAndColumnsProvider.NumberRowsPerTurn,
                                                                                             this.rowsAndColumnsProvider.NumberColumns);
            if (generateSymbolsResult.IsError)
            {
                result.SetError(generateSymbolsResult.Message);

                return result;
            }

            SymbolsSet generatedSymbols = generateSymbolsResult.Data;
            //test
            //SymbolsSet generatedSymbols = new SymbolsSet();
            //generatedSymbols.Rows.Add(new SymbolsRow()
            //{
            //    Symbols = new List<Symbol>() { Symbol.B, Symbol.A, Symbol.A }
            //});
            //generatedSymbols.Rows.Add(new SymbolsRow()
            //{
            //    Symbols = new List<Symbol>() { Symbol.A, Symbol.A, Symbol.A }
            //});
            //generatedSymbols.Rows.Add(new SymbolsRow()
            //{
            //    Symbols = new List<Symbol>() { Symbol.W, Symbol.W, Symbol.W }
            //});
            //generatedSymbols.Rows.Add(new SymbolsRow()
            //{
            //    Symbols = new List<Symbol>() { Symbol.W, Symbol.A , Symbol.A }
            //});
            //test

            Result<decimal> coefficientsResult = this.symbolsCoefficientsCalculator.CalculateTotalCoefficient(generatedSymbols);
            if (coefficientsResult.IsError)
            {
                result.SetError(coefficientsResult.Message);

                return result;
            }

            decimal coefficent = coefficientsResult.Data;
            decimal amountWon = stakeAmount * coefficent;

            this.currentBalance += amountWon;

            GameTurnResult gameTurnResult = new GameTurnResult()
            {
                Symbols = generatedSymbols,
                AmountWon = amountWon,
                CurrentBalance = this.currentBalance
            };

            return result.SetData(gameTurnResult);
        }

        private Result ValidateStakeAmount(decimal stakeAmount)
        {
            Result result = new Result();
            if (this.currentBalance <= 0)
            {
                return result.SetError("You do not have balance to continue playing!");
            }

            if (stakeAmount <= 0)
            {
                return result.SetError($"Please enter a valid stake amount!");
            }

            if (stakeAmount > this.currentBalance)
            {
                return result.SetError($"Stake amount cannot be bigger than the remaining deposit amount!");
            }

            return result.SetSuccess("Data is valid.");
        }
    }
}
