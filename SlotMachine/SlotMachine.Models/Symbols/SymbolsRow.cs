using System.Collections.Generic;

namespace SlotMachine.Models.Symbols
{
    public class SymbolsRow
    {
        public IList<Symbol> Symbols { get; set; } = new List<Symbol>();
    }
}
