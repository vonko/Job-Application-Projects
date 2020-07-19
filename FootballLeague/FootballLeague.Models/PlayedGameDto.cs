namespace FootballLeague.Models
{
    public class PlayedGameDto : AddPlayedGameDto
    {
        public int ID { get; set; }

        public FootballTeamDto HomeTeam { get; set; }

        public FootballTeamDto AwayTeam { get; set; }
    }
}
