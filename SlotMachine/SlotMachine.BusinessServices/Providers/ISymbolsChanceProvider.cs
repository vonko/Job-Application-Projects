using SlotMachine.Models.Symbols;
using System.Collections.Generic;

namespace SlotMachine.BusinessServices.Providers
{
    public interface ISymbolsChanceProvider
    {
        Dictionary<Symbol, int> GetSymbolsChancesToRoll();
    }
}
