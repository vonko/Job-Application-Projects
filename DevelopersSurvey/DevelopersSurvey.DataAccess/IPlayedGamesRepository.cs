using DevelopersSurvey.DataAccess.DbModels;
using DevelopersSurvey.Models.PlayedGame;
using System.Collections.Generic;

namespace DevelopersSurvey.DataAccess
{
    public interface IPlayedGamesRepository : IRepositoryBase<PlayedGame>
    {
        PlayedGameDto AddGame(AddPlayedGameDto gameToAdd);

        IList<PlayedGameDto> AllMaterialed();

        PlayedGameDto Find(params object[] keys);
    }
}
