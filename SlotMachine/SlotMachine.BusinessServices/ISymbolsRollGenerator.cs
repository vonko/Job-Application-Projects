using SlotMachine.Models;

namespace SlotMachine.BusinessServices
{
    public interface ISymbolsRollGenerator
    {
        Result<SymbolsSet> GenerateSymbols(int rowsNumber, int columnsNumber);
    }
}
