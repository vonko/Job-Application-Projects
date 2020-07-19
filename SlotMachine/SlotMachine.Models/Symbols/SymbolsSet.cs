using System.Collections.Generic;

namespace SlotMachine.Models.Symbols
{
    public class SymbolsSet
    {
        public IList<SymbolsRow> Rows { get; set; } = new List<SymbolsRow>();
    }
}
