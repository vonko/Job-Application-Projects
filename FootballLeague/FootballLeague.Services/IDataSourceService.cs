using FootballLeague.Models;
using System.Collections.Generic;

namespace FootballLeague.Services
{
    public interface IDataSourceService
    {
        Result<IList<DataSourceDto>> GetFootballTeamsDataSource();

        IList<DataSourceDto> GetResultsDataSource();
    }
}
