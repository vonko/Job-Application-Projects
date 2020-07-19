using SlotMachine.Models.Symbols;

namespace SlotMachine.Models
{
    public class GameTurnResult : GameTurnBalance
    {
        public SymbolsSet Symbols { get; set; }
    }
}
