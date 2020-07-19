using SlotMachine.BusinessServices.Providers;
using SlotMachine.Models.Symbols;
using System.Collections.Generic;

namespace SlotMachine.BusinessServices.Implementation.Providers
{
    public class SymbolsChanceProvider : ISymbolsChanceProvider
    {
        //Provides the chance to roll for every symbol in percentage
        private const int APPLE_CHANCE = 45;
        private const int BANANA_CHANCE = 35;
        private const int PINEAPLE_CHANCE = 15;
        private const int WILDCARD_CHANCE = 5;

        public Dictionary<Symbol, int> GetSymbolsChancesToRoll()
        {
            return new Dictionary<Symbol, int>()
            {
                { Symbol.A, APPLE_CHANCE },
                { Symbol.B, BANANA_CHANCE },
                { Symbol.P, PINEAPLE_CHANCE },
                { Symbol.W, WILDCARD_CHANCE }
            };
        }
    }
}
