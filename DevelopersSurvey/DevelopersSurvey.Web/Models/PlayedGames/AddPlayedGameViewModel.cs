using DevelopersSurvey.Models.PlayedGame;
using DevelopersSurvey.Web.Models.DataSources;

namespace DevelopersSurvey.Web.Models.PlayedGames
{
    public class AddPlayedGameViewModel
    {
        public PlayedGameDataSourcesViewModel DataSources { get; set; }

        public int HomeTeamId { get; set; }

        public int AwayTeamId { get; set; }

        public GameResult Result { get; set; }
    }
}