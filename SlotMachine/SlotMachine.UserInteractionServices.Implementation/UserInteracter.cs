using SlotMachine.BusinessServices;
using SlotMachine.Models;
using SlotMachine.Models.Symbols;
using System;

namespace SlotMachine.UserInteractionServices
{
    //independent console interaction interface so its implementation can be replaced by other means of communication with the user
    public class UserInteracter : IUserInteracter
    {
        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }

        public decimal GetDepositAmount()
        {
            return this.GetAmount(statementMessage: MessageConstants.DEPOSIT_MONEY_STATEMENT,
                                  errorMessage: MessageConstants.ENTER_VALID_DEPOSIT_AMOUNT_ERROR);
        }

        public decimal GetStakeAmount(decimal possibleAmount)
        {
            return this.GetAmount(statementMessage: MessageConstants.ENTER_STAKE_AMOUNT_STATEMENT,
                                  errorMessage: MessageConstants.STAKE_AMOUNT_ERROR,
                                  maxPossibleAmount: possibleAmount);      
        }

        public void PrintSymbols(SymbolsSet symbolsSet)
        {
            Console.WriteLine();
            foreach (SymbolsRow row in symbolsSet.Rows)
            {
                foreach(Symbol symbol in row.Symbols)
                {
                    Console.Write(symbol);
                }

                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public void PrintBalance(GameTurnBalance gameTurnBalance)
        {
            Console.WriteLine($"You have won: { gameTurnBalance.AmountWon }");
            Console.Write($"Current balance is: { gameTurnBalance.CurrentBalance }");
            Console.WriteLine();
        }

        private decimal GetAmount(string statementMessage, string errorMessage, decimal maxPossibleAmount = int.MaxValue)
        {
            Console.WriteLine(statementMessage);

            decimal amount = 0;
            bool valid = false;

            while (!valid)
            {
                valid = this.TryGetAmount(out amount, maxPossibleAmount);
                if (!valid)
                {
                    Console.WriteLine(errorMessage);
                }
            }

            return amount;
        }

        private bool TryGetAmount(out decimal amount, decimal maxPossibleAmount)
        {
            return decimal.TryParse(Console.ReadLine(), out amount)
                && amount > 0 &&
                amount <= maxPossibleAmount;
        }
    }
}
