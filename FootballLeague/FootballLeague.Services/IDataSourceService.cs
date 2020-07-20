using FootballLeague.Models;
using FootballLeague.Models.DataSources;
using System.Collections.Generic;

namespace FootballLeague.Services
{
    public interface IDataSourceService
    {
        Result<IList<DataSourceDto>> GetFootballTeamsDataSource();

        IList<DataSourceDto> GetResultsDataSource();

        Result<PlayedGameDataSourcesDto> GetPlayedGameDataSources();
    }
}
