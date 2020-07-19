using SlotMachine.BusinessServices.Providers;
using SlotMachine.BusinessServices.SymbolsProcessorServices;
using SlotMachine.Models;
using SlotMachine.Models.Symbols;
using System.Collections.Generic;
using System.Linq;

namespace SlotMachine.BusinessServices.Implementation.SymbolsProcessorServices
{
    public class SymbolsCoefficientsCalculator : ISymbolsCoefficientsCalculator
    {
        private const Symbol UNIVERSAL_SYMBOL = Symbol.W;

        private readonly ISymbolsCoefficientsProvider symbolsCoefficientsProvider;

        public SymbolsCoefficientsCalculator(ISymbolsCoefficientsProvider symbolsCoefficientsProvider)
        {
            this.symbolsCoefficientsProvider = symbolsCoefficientsProvider;
        }

        public Result<decimal> CalculateTotalCoefficient(SymbolsSet generatedSymbols)
        {
            Result<decimal> result = new Result<decimal>();

            decimal totalCoefficient = 0;
            foreach(SymbolsRow symbolsRow in generatedSymbols.Rows)
            {
                Result<decimal> rowCoefficentResult = this.CalculateRowCoefficient(symbolsRow);
                if (rowCoefficentResult.IsError)
                {
                    return rowCoefficentResult;
                }

                totalCoefficient += rowCoefficentResult.Data;
            }

            return result.SetData(totalCoefficient);
        }

        private Result<decimal> CalculateRowCoefficient(SymbolsRow symbolsRow)
        {
            Result<decimal> result = new Result<decimal>();

            bool isWinningRow = this.IsAWinningSymbolsRow(symbolsRow);
            if (!isWinningRow)
            {
                return result.SetData(0);
            }

            decimal totalRowCoefficient = this.GetTotalRowCoefficient(symbolsRow);

            return result.SetData(totalRowCoefficient);
        }

        private bool IsAWinningSymbolsRow(SymbolsRow symbolsRow)
        {
            if (symbolsRow == null || symbolsRow.Symbols == null || symbolsRow.Symbols.Count == 0)
            {
                return false;
            }

            bool isThereNonWildcardSymbol = symbolsRow.Symbols.Any(s => s != Symbol.W);
            if (!isThereNonWildcardSymbol) /*From the example seems the requirement is wildcard does not bring coefficient on its own*/
            {
                return false;
            }

            Symbol nonWildcardSymbol = symbolsRow.Symbols.First(s => s != Symbol.W);

            for(int index = 0; index < symbolsRow.Symbols.Count; index ++)
            {
                Symbol currentSymbol = symbolsRow.Symbols[index];
                if (currentSymbol != nonWildcardSymbol && currentSymbol != Symbol.W)
                {
                    return false;
                }
            }

            return true;
        }

        private decimal GetTotalRowCoefficient(SymbolsRow symbolsRow)
        {
            Dictionary<Symbol, decimal> coefficients = this.symbolsCoefficientsProvider.GetCoefficients();
            decimal totalRowCoefficient = 0;
            foreach (Symbol symbol in symbolsRow.Symbols)
            {
                totalRowCoefficient += coefficients[symbol];
            }

            return totalRowCoefficient;
        }
    }
}
