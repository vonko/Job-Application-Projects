using System.Collections.Generic;

namespace FootballLeague.Models.DataSources
{
    public class PlayedGameDataSourcesDto
    {
        public Dictionary<int, DataSourceDto> Teams { get; set; }

        public Dictionary<int, DataSourceDto> Results { get; set; }
    }
}
