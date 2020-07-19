using SlotMachine.Models;

namespace SlotMachine.ConsoleServices
{
    public interface IConsoleWorker
    {
        void WriteLine(string message);

        decimal GetDepositAmount();

        decimal GetStakeAmount(decimal possibleAmount);

        void PrintSymbols(SymbolsSet symbolsSet);

        void PrintBalance(decimal amountWon, decimal currentBalance);
    }
}
