using SlotMachine.Models;

namespace SlotMachine.BusinessServices
{
    public interface ISymbolsCoefficentsCalculator
    {
        decimal CalculateCoefficent(SymbolsSet generatedSymbols);
    }
}
