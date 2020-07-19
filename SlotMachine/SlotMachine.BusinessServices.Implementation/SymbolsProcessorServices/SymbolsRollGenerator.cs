using SlotMachine.BusinessServices.Providers;
using SlotMachine.BusinessServices.SymbolsProcessorServices;
using SlotMachine.Models;
using SlotMachine.Models.Symbols;
using System;

namespace SlotMachine.BusinessServices.Implementation.SymbolsProcessorServices
{
    public class SymbolsRollGenerator : ISymbolsRollGenerator
    {
        private readonly ISymbolsChanceProvider symbolsChanceProvider;

        public SymbolsRollGenerator(ISymbolsChanceProvider symbolsChanceProvider)
        {
            this.symbolsChanceProvider = symbolsChanceProvider;
        }

        public Result<SymbolsSet> GenerateSymbols(int rowsNumber, int columnsNumber)
        {
            Result<SymbolsSet> result = new Result<SymbolsSet>();

            SymbolsSet symbolsSet = new SymbolsSet();
            Random randomGenerator = new Random();

            for(int row = 1; row <= rowsNumber; row++)
            {
                SymbolsRow symbolsRow = new SymbolsRow();

                for(int column = 1; column <= columnsNumber; column++)
                {
                    try
                    {
                        Symbol symbolRolled = this.GenerateSymbol(randomGenerator);

                        symbolsRow.Symbols.Add(symbolRolled);
                    }
                    catch(Exception ex)
                    {
                        result.SetError(ex.Message);
                    }
                }

                symbolsSet.Rows.Add(symbolsRow);
            }

            return result.SetData(symbolsSet);
        }

        private Symbol GenerateSymbol(Random randomGenerator)
        {
           //generate an number with min 0, max 99
            int percent = randomGenerator.Next(0, 100);

            var symbolsChances = this.symbolsChanceProvider.GetSymbolsChancesToRoll();
            int wildCardChance = symbolsChances[Symbol.W];
            int pineapleChance = symbolsChances[Symbol.P];
            int bananaChance = symbolsChances[Symbol.B];
            int appleChance = symbolsChances[Symbol.A];

            Symbol symbolRolled;
            //5 % Chance, 0 to 4
            if (percent < wildCardChance)
            {
                symbolRolled = Symbol.W;
            }
            //15 % Chance, 5 to 19
            else if (percent < wildCardChance + pineapleChance)
            {
                symbolRolled = Symbol.P;
            }
            //35 % Chance, 20 to 55
            else if (percent < wildCardChance + pineapleChance + bananaChance)
            {
                symbolRolled = Symbol.B;
            }
            //15 % Chance, 30 to 44
            else if (percent < wildCardChance + pineapleChance + bananaChance + appleChance)
            {
                symbolRolled = Symbol.A;
            }
            else
            {
                throw new ApplicationException("Chance generation error.");
            }

            return symbolRolled;
        }
    }
}
