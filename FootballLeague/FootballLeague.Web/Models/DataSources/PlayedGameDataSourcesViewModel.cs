using System.Collections.Generic;

namespace FootballLeague.Web.Models.DataSources
{
    public class PlayedGameDataSourcesViewModel
    {
        public Dictionary<int, DataSourceViewModel> Teams { get; set; }

        public Dictionary<int, DataSourceViewModel> Results { get; set; }
    }
}