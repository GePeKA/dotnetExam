using Models;
using Models.DTO.Logs;

namespace GameLogic.Sevices
{
    public interface IBattle
    {
        public Log GetBattleResult(Player player, Monster monster);
    }
}
