using SlotMachine.Models;
using SlotMachine.Models.Symbols;

namespace SlotMachine.UserInteractionServices
{
    public interface IUserInteracter
    {
        void WriteLine(string message);

        decimal GetDepositAmount();

        decimal GetStakeAmount(decimal possibleAmount);

        void PrintSymbols(SymbolsSet symbolsSet);

        void PrintBalance(GameTurnBalance gameTurnBalance);
    }
}
