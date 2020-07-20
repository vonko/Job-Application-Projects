namespace FootballLeague.Models.PlayedGame
{
    public class PlayedGameDto : AddPlayedGameDto
    {
        public int ID { get; set; }

        public string HomeTeamName { get; set; }

        public string AwayTeamName { get; set; }

        public string ResultName { get; set; }
    }
}
