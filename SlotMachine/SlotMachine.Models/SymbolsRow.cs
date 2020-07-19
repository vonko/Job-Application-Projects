using System.Collections.Generic;

namespace SlotMachine.Models
{
    public class SymbolsRow
    {
        public IList<Symbol> Symbols { get; set; } = new List<Symbol>();
    }
}
