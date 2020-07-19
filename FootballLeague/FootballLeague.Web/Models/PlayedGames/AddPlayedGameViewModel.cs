using FootballLeague.Models.PlayedGame;

namespace FootballLeague.Web.Models.PlayedGames
{
    public class AddPlayedGameViewModel
    {
        public int HomeTeamId { get; set; }

        public int AwayTeamId { get; set; }

        public GameResult Result { get; set; }
    }
}