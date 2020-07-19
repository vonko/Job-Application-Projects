using SlotMachine.BusinessServices.Providers;
using SlotMachine.Models.Symbols;
using System.Collections.Generic;

namespace SlotMachine.BusinessServices.Implementation.Providers
{
    public class SymbolsCoefficientsProvider : ISymbolsCoefficientsProvider
    {
        private const decimal APPLE_COEFFICENT = 0.4m;
        private const decimal BANANA_COEFFICENT = 0.6m;
        private const decimal PINEAPPLE_COEFFICENT = 0.8m;

        /*From the example seems wildcard brings no points, so if we have row only of wildcards it should get 0 coefficient*/
        private const decimal WILDCARD_COEFFICENT = 0;

        public Dictionary<Symbol, decimal> GetCoefficients()
        {
            return new Dictionary<Symbol, decimal>()
            {
                { Symbol.A, APPLE_COEFFICENT },
                { Symbol.B, BANANA_COEFFICENT },
                { Symbol.P, PINEAPPLE_COEFFICENT },
                { Symbol.W, WILDCARD_COEFFICENT }
            };
        }
    }
}
