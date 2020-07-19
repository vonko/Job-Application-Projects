using SlotMachine.Models;
using System;

namespace SlotMachine.BusinessServices.Implementation
{
    public class SymbolsRollGenerator : ISymbolsRollGenerator
    {
        private const int APPLE_CHANCE = 45;
        private const int BANANA_CHANCE = 35;
        private const int PINEAPLE_CHANCE = 15;
        private const int WILDCARD_CHANCE = 5;

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

            Symbol symbolRolled;
            //5 % Chance, 0 to 4
            if (percent < WILDCARD_CHANCE)
            {
                symbolRolled = Symbol.W;
            }
            //15 % Chance, 5 to 19
            else if (percent < WILDCARD_CHANCE + PINEAPLE_CHANCE)
            {
                symbolRolled = Symbol.P;
            }
            //35 % Chance, 20 to 55
            else if (percent < WILDCARD_CHANCE + PINEAPLE_CHANCE + BANANA_CHANCE)
            {
                symbolRolled = Symbol.B;
            }
            //15 % Chance, 30 to 44
            else if (percent < WILDCARD_CHANCE + PINEAPLE_CHANCE + BANANA_CHANCE + APPLE_CHANCE)
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
