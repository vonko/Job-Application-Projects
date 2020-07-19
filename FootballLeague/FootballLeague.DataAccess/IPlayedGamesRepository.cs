using FootballLeague.DataAccess.DbModels;
using FootballLeague.Models.PlayedGame;
using System.Collections.Generic;

namespace FootballLeague.DataAccess
{
    public interface IPlayedGamesRepository : IRepositoryBase<PlayedGame>
    {
        PlayedGameDto AddGame(AddPlayedGameDto gameToAdd);

        IList<PlayedGameDto> AllMaterialed();

        PlayedGameDto Find(params object[] keys);
    }
}
