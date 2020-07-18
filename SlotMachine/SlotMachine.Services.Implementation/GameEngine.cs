using SlotMachine.Models;
using System;

namespace SlotMachine.Services.Implementation
{
    public class GameEngine : IGameEngine
    {
        private decimal playerAmount;

        public Result SetDepositAmount(decimal depositAmount)
        {
            Result result = new Result();
            if (depositAmount <= 0)
            {
                return result.SetError($"Please enter a valid deposit amount!");
            }

            this.playerAmount = depositAmount;

            return result.SetSuccess("Amount set successfully.");
        }

        public Result ExecuteGameTurn(decimal stakeAmount)
        {
            Result result = new Result();
            if (stakeAmount <= 0)
            {
                return result.SetError($"Please enter a valid stake amount!");
            }


            return result.SetSuccess("Turn successful.");
        }
    }
}
