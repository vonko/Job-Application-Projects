using SlotMachine.Models;

namespace SlotMachine.Services
{
    public interface IGameEngine
    {
        Result SetDepositAmount(decimal depositAmount);

        Result<GameTurnResult> ExecuteGameTurn(decimal stakeAmount);
    }
}
