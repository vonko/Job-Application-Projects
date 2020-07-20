using FootballLeague.Models.PlayedGame;
using System;

namespace FootballLeague.Web.Models.PlayedGames
{
    public class PlayedGameViewModel
    {
        public int ID { get; set; }

        public int HomeTeamId { get; set; }

        public int AwayTeamId { get; set; }

        public GameResult Result { get; set; }

        public string ResultName { get; set; }

        public string HomeTeamName { get; set; }

        public string AwayTeamName { get; set; }

        public DateTime DatePlayed { get; set; }
    }
}