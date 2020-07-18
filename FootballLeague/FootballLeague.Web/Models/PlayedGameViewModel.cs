namespace FootballLeague.Web.Models
{
    public class PlayedGameViewModel : AddPlayedGameViewModel
    {
        public int ID { get; set; }
        
        public FootballTeamViewModel HomeTeam { get; set; }
        
        public FootballTeamViewModel AwayTeam { get; set; }
    }
}