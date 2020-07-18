using FootballLeague.Models;

namespace FootballLeague.Web.Models
{
    public class AddPlayedGameViewModel
    {
        public int HomeTeamId { get; set; }

        public int AwayTeamId { get; set; }

        public GameResult Result { get; set; }
    }
}