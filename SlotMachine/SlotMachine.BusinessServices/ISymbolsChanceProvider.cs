using SlotMachine.Models;
using System.Collections.Generic;

namespace SlotMachine.BusinessServices
{
    public interface ISymbolsChanceProvider
    {
        Dictionary<Symbol, int> GetSymbolsChancesToRoll();
    }
}
