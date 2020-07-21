using AutoMapper;
using DevelopersSurvey.DataAccess;
using DevelopersSurvey.Models;
using DevelopersSurvey.Models.DataSources;
using DevelopersSurvey.Models.FootballTeam;
using DevelopersSurvey.Models.PlayedGame;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DevelopersSurvey.Services.Implementation
{
    public class DataSourceService : IDataSourceService
    {
        private const string DRAW_RESULT_TEXT = "X";

        private readonly IFootballTeamsRepository teamsRepository;

        public DataSourceService(IFootballTeamsRepository teamsRepository)
        {
            this.teamsRepository = teamsRepository;
        }

        public Result<IList<DataSourceDto>> GetFootballTeamsDataSource()
        {
            Result<IList<DataSourceDto>> result = new Result<IList<DataSourceDto>>();

            try
            {
                IList<FootballTeamDto> teamDtos = this.teamsRepository.AllMaterialed();
                IList<DataSourceDto> dataSources = Mapper.Map<IList<FootballTeamDto>, IList<DataSourceDto>>(teamDtos);

                return result.SetData(dataSources);
            }
            catch (Exception ex)
            {
                result.SetError(ex.Message);

                return result;
            }
        }

        public IList<DataSourceDto> GetResultsDataSource()
        {
            IList<DataSourceDto> dataSource = new List<DataSourceDto>();

            foreach (GameResult result in Enum.GetValues(typeof(GameResult)))
            {
                var newDataItem = new DataSourceDto()
                {
                    ID = (int)result,
                    Name = result.ToString()
                };

                if (result == GameResult.Draw)
                {
                    newDataItem.Name = DRAW_RESULT_TEXT;
                }

                dataSource.Add(newDataItem);
            }

            return dataSource;
        }

        public Result<PlayedGameDataSourcesDto> GetPlayedGameDataSources()
        {
            Result<PlayedGameDataSourcesDto> result = new Result<PlayedGameDataSourcesDto>();

            try
            {
                var resultsDataSourceList = this.GetResultsDataSource();
                var teamsDataSourceResult = this.GetFootballTeamsDataSource();
                if (teamsDataSourceResult.IsError)
                {
                    result.SetError(teamsDataSourceResult.Message);

                    return result;
                }

                PlayedGameDataSourcesDto dataSourceDto = new PlayedGameDataSourcesDto
                {
                    Teams = teamsDataSourceResult.Data.ToDictionary(t => t.ID, t => t ),
                    Results = resultsDataSourceList.ToDictionary(r => r.ID, r => r)
                };

                return result.SetData(dataSourceDto);
            }
            catch(Exception ex)
            {
                result.SetError(ex.Message);

                return result;
            }
        }
    }
}
