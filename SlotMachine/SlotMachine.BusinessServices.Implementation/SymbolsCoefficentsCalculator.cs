using SlotMachine.Models;

namespace SlotMachine.BusinessServices.Implementation
{
    public class SymbolsCoefficentsCalculator : ISymbolsCoefficentsCalculator
    {
        public decimal CalculateCoefficent(SymbolsSet generatedSymbols)
        {
            return 0.2m;
        }
    }
}
