using DevelopersSurvey.Web.Models.DataSources;
using System.Collections.Generic;

namespace DevelopersSurvey.Web.Models.PlayedGames
{
    public class PlayedGamesDataContextViewModel
    {
        public PlayedGameDataSourcesViewModel DataSources { get; set; }

        public IList<PlayedGameViewModel> PlayedGames { get; set; } = new List<PlayedGameViewModel>();
    }
}