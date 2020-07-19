using SlotMachine.Models.Symbols;
using System.Collections.Generic;

namespace SlotMachine.BusinessServices.Providers
{
    public interface ISymbolsCoefficientsProvider
    {
        Dictionary<Symbol, decimal> GetCoefficients();
    }
}
