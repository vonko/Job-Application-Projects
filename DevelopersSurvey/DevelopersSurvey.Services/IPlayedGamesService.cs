using DevelopersSurvey.Models;
using DevelopersSurvey.Models.PlayedGame;
using System.Collections.Generic;

namespace DevelopersSurvey.Services
{
    public interface IPlayedGamesService
    {
        Result<PlayedGameDto> GetGame(int gameId);

        Result<IList<PlayedGameDto>> GetAllGames();

        Result<PlayedGameDto> AddPlayedGame(AddPlayedGameDto teamDto);

        Result UpdateGame(UpdatePlayedGameDto teamDto);

        Result DeleteGame(int gameId);
    }
}
