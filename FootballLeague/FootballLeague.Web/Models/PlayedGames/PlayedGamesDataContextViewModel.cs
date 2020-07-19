using System.Collections.Generic;

namespace FootballLeague.Web.Models.PlayedGames
{
    public class PlayedGamesDataContextViewModel
    {
        public IList<PlayedGameViewModel> PlayedGames { get; set; } = new List<PlayedGameViewModel>();
    }
}