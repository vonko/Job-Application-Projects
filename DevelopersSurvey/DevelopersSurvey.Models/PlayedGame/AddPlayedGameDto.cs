using System;

namespace DevelopersSurvey.Models.PlayedGame
{
    public class AddPlayedGameDto
    {
        public int HomeTeamId { get; set; }

        public int AwayTeamId { get; set; }

        public GameResult Result { get; set; }

        public DateTime DatePlayed { get; set; }
    }
}
