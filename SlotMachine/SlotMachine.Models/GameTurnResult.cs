namespace SlotMachine.Models
{
    public class GameTurnResult
    {
        public SymbolsSet Symbols { get; set; }

        public decimal AmountWon { get; set; }

        public decimal CurrentBalance { get; set; }
    }
}
