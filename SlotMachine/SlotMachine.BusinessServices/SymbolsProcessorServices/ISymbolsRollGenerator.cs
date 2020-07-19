using SlotMachine.Models;
using SlotMachine.Models.Symbols;

namespace SlotMachine.BusinessServices.SymbolsProcessorServices
{
    public interface ISymbolsRollGenerator
    {
        Result<SymbolsSet> GenerateSymbols(int rowsNumber, int columnsNumber);
    }
}
