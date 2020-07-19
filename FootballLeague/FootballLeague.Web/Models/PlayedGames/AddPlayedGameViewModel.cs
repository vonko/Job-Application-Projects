using FootballLeague.Models.PlayedGame;
using System.Collections.Generic;

namespace FootballLeague.Web.Models.PlayedGames
{
    public class AddPlayedGameViewModel
    {
        public IList<DataSourceViewModel> Teams { get; set; } = new List<DataSourceViewModel>();

        public IList<DataSourceViewModel> Results { get; set; } = new List<DataSourceViewModel>();

        public int HomeTeamId { get; set; }

        public int AwayTeamId { get; set; }

        public GameResult Result { get; set; }
    }
}