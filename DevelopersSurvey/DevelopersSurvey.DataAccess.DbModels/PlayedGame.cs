using DevelopersSurvey.Models.PlayedGame;
using System;

namespace DevelopersSurvey.DataAccess.DbModels
{
    public class PlayedGame : DbModelBase
    {
        public int ID { get; set; }

        public DateTime DatePlayed { get; set; }
        
        public int HomeTeamId { get; set; }
        public FootballTeam HomeTeam { get; set; }
        
        public int AwayTeamId { get; set; }
        public FootballTeam AwayTeam { get; set; }

        public GameResult Result { get; set; }
    }
}
