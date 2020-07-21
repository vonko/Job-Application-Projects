using System.Collections.Generic;

namespace DevelopersSurvey.Models.DataSources
{
    public class PlayedGameDataSourcesDto
    {
        public Dictionary<int, DataSourceDto> Teams { get; set; }

        public Dictionary<int, DataSourceDto> Results { get; set; }
    }
}
