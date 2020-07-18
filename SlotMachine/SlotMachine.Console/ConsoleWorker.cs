using System;

namespace SlotMachine.ConsoleInterface
{
    public static class ConsoleWorker
    {
        public static decimal GetDepositAmount()
        {
            return GetAmount(statementMessage: "Please deposit money you would like to play with:",
                             errorMessage: "Please enter a valid amount to deposit!");
        }

        public static decimal GetStakeAmount(decimal possibleAmount)
        {
            return GetAmount(statementMessage: "Enter stake amount:",
                             errorMessage: "Please enter a valid stake amount amount!",
                             maxPossibleAmount: possibleAmount);      
        }

        private static decimal GetAmount(string statementMessage, string errorMessage, decimal maxPossibleAmount = int.MaxValue)
        {
            Console.WriteLine(statementMessage);

            decimal amount = 0;
            bool valid = false;

            while (!valid)
            {
                valid = TryGetAmount(out amount, maxPossibleAmount);
                if (!valid)
                {
                    Console.WriteLine(errorMessage);
                }
            }

            return amount;
        }

        private static bool TryGetAmount(out decimal amount, decimal maxPossibleAmount)
        {
            return decimal.TryParse(Console.ReadLine(), out amount)
                && amount > 0 &&
                amount <= maxPossibleAmount;
        }
    }
}
