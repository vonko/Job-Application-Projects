using SlotMachine.Models;

namespace SlotMachine.BusinessServices
{
    public interface ISymbolsCoefficientsCalculator
    {
        Result<decimal> CalculateTotalCoefficient(SymbolsSet generatedSymbols);
    }
}
