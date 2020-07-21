using System.Collections.Generic;

namespace DevelopersSurvey.Web.Models.DataSources
{
    public class PlayedGameDataSourcesViewModel
    {
        public Dictionary<int, DataSourceViewModel> Teams { get; set; }

        public Dictionary<int, DataSourceViewModel> Results { get; set; }
    }
}