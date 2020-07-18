using SlotMachine.Models;

namespace SlotMachine.Services
{
    public interface IGameEngine
    {
        Result SetDepositAmount(decimal depositAmount);

        Result ExecuteGameTurn(decimal stakeAmount);
    }
}
