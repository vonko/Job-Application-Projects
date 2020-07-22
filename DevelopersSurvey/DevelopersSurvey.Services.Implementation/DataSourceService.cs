using DevelopersSurvey.Models.DataSources;
using DevelopersSurvey.Models.ProgrammingLanguage;
using System;
using System.Collections.Generic;

namespace DevelopersSurvey.Services.Implementation
{
    public class DataSourceService : IDataSourceService
    {
        private const string DRAW_RESULT_TEXT = "X";
        private const string C_SHARP_LANGUAGE_TEXT = "C#";
        private const string C_PLUS_PLUS_LANGUAGE_TEXT = "C++";

        public IList<DataSourceDto> GetLanguagesDataSource()
        {
            IList<DataSourceDto> dataSource = new List<DataSourceDto>();

            foreach (ProgrammingLanguage result in Enum.GetValues(typeof(ProgrammingLanguage)))
            {
                var newDataItem = new DataSourceDto()
                {
                    ID = (int)result,
                    Name = result.ToString()
                };

                if (result == ProgrammingLanguage.CSharp)
                {
                    newDataItem.Name = C_SHARP_LANGUAGE_TEXT;
                }
                else if (result == ProgrammingLanguage.CPlusPlus)
                {
                    newDataItem.Name = C_PLUS_PLUS_LANGUAGE_TEXT;
                }

                dataSource.Add(newDataItem);
            }

            return dataSource;
        }

        public IList<DataSourceDto> GetSeniorityLevelsDataSource()
        {
            IList<DataSourceDto> dataSource = new List<DataSourceDto>();

            foreach (SeniorityLevel result in Enum.GetValues(typeof(SeniorityLevel)))
            {
                var newDataItem = new DataSourceDto()
                {
                    ID = (int)result,
                    Name = result.ToString()
                };

                dataSource.Add(newDataItem);
            }

            return dataSource;
        }
    }
}
