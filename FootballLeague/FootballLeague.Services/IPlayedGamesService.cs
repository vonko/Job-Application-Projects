using FootballLeague.Models;
using System.Collections.Generic;

namespace FootballLeague.Services
{
    public interface IPlayedGamesService
    {
        Result<PlayedGameDto> GetGame(int gameId);

        Result<IList<PlayedGameDto>> GetAllGames();

        Result<PlayedGameDto> PlayGame(AddPlayedGameDto teamDto);

        Result UpdateGame(PlayedGameDto teamDto);

        Result DeleteGame(int gameId);
    }
}
