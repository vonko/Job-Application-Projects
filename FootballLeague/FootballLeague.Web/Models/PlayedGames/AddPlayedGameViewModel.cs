using FootballLeague.Models.PlayedGame;
using FootballLeague.Web.Models.DataSources;

namespace FootballLeague.Web.Models.PlayedGames
{
    public class AddPlayedGameViewModel
    {
        public PlayedGameDataSourcesViewModel DataSources { get; set; }

        public int HomeTeamId { get; set; }

        public int AwayTeamId { get; set; }

        public GameResult Result { get; set; }
    }
}