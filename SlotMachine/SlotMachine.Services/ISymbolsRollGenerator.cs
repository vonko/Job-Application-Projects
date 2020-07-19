using SlotMachine.Models;

namespace SlotMachine.Services
{
    public interface ISymbolsRollGenerator
    {
        Result<SymbolsSet> GenerateSymbols(int rowsNumber, int columnsNumber);
    }
}
