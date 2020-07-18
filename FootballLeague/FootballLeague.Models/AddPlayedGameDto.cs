namespace FootballLeague.Models
{
    public class AddPlayedGameDto
    {
        public int HomeTeamId { get; set; }

        public int AwayTeamId { get; set; }

        public GameResult Result { get; set; }
    }
}
