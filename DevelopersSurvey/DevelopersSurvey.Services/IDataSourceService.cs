using DevelopersSurvey.Models;
using DevelopersSurvey.Models.DataSources;
using System.Collections.Generic;

namespace DevelopersSurvey.Services
{
    public interface IDataSourceService
    {
        Result<IList<DataSourceDto>> GetFootballTeamsDataSource();

        IList<DataSourceDto> GetResultsDataSource();

        Result<PlayedGameDataSourcesDto> GetPlayedGameDataSources();
    }
}
