using SlotMachine.Models;
using System.Collections.Generic;

namespace SlotMachine.BusinessServices
{
    public interface ISymbolsCoefficientsProvider
    {
        Dictionary<Symbol, decimal> GetCoefficients();
    }
}
