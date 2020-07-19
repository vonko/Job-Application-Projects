﻿using SlotMachine.Models;
using System;

namespace SlotMachine.ConsoleServices.Implementation
{
    public class ConsoleWorker : IConsoleWorker
    {
        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }

        public decimal GetDepositAmount()
        {
            return this.GetAmount(statementMessage: "Please deposit money you would like to play with:",
                                  errorMessage: "Please enter a valid amount to deposit!");
        }

        public decimal GetStakeAmount(decimal possibleAmount)
        {
            return this.GetAmount(statementMessage: "Enter stake amount:",
                                  errorMessage: "Please enter a valid stake amount amount!",
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