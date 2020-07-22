using DevelopersSurvey.Models.DataSources;
using System.Collections.Generic;

namespace DevelopersSurvey.Services
{
    public interface IDataSourceService
    {
        IList<DataSourceDto> GetLanguagesDataSource();

        IList<DataSourceDto> GetSeniorityLevelsDataSource();
    }
}
