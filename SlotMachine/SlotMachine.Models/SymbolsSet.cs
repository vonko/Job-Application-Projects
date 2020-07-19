using System;
using System.Collections.Generic;
using System.Text;

namespace SlotMachine.Models
{
    public class SymbolsSet
    {
        public IList<SymbolsRow> Rows { get; set; } = new List<SymbolsRow>();
    }
}
