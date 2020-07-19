using SlotMachine.Models;

namespace SlotMachine.BusinessServices
{
    public interface IGameEngine
    {
        Result SetDepositAmount(decimal depositAmount);

        Result<GameTurnResult> ExecuteGameTurn(decimal stakeAmount);
    }
}
