using SlotMachine.Models;
using SlotMachine.Models.Symbols;

namespace SlotMachine.BusinessServices.SymbolsProcessorServices
{
    public interface ISymbolsCoefficientsCalculator
    {
        Result<decimal> CalculateTotalCoefficient(SymbolsSet generatedSymbols);
    }
}
