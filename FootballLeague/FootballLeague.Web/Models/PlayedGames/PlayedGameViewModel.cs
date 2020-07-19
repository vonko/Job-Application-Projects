using FootballLeague.Models.PlayedGame;
using FootballLeague.Web.Models.FootballTeams;
using System;

namespace FootballLeague.Web.Models.PlayedGames
{
    public class PlayedGameViewModel
    {
        public int ID { get; set; }

        public int HomeTeamId { get; set; }

        public int AwayTeamId { get; set; }

        public GameResult Result { get; set; }

        public FootballTeamViewModel HomeTeam { get; set; }
        
        public FootballTeamViewModel AwayTeam { get; set; }

        public DateTime DatePlayed { get; set; }
    }
}