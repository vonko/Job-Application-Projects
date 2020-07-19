using AutoMapper;
using FootballLeague.DataAccess;
using FootballLeague.Models;
using FootballLeague.Models.FootballTeam;
using FootballLeague.Models.PlayedGame;
using System;
using System.Collections.Generic;

namespace FootballLeague.Services.Implementation
{
    public class DataSourceService : IDataSourceService
    {
        private readonly IDALContext dalCotext;

        public DataSourceService(IDALContext dalCotext)
        {
            this.dalCotext = dalCotext;
        }

        public Result<IList<DataSourceDto>> GetFootballTeamsDataSource()
        {
            Result<IList<DataSourceDto>> result = new Result<IList<DataSourceDto>>();

            try
            {
                IList<FootballTeamDto> teamDtos = this.dalCotext.FootballTeamsRepository.AllMaterialed();
                IList<DataSourceDto> dataSources = Mapper.Map<IList<FootballTeamDto>, IList<DataSourceDto>> (teamDtos);

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
                    newDataItem.Name = "X";
                }

                dataSource.Add(newDataItem);
            }

            return dataSource;
        }
    }
}
