using SlotMachine.Models;

namespace SlotMachine.Services
{
    public interface ISymbolsCoefficentsCalculator
    {
        decimal CalculateCoefficent(SymbolsSet generatedSymbols);
    }
}
