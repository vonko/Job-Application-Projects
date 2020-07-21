using AutoMapper;
using DevelopersSurvey.DataAccess.DbModels;
using DevelopersSurvey.Models;
using DevelopersSurvey.Models.DataSources;
using DevelopersSurvey.Models.FootballTeam;
using DevelopersSurvey.Models.PlayedGame;
using DevelopersSurvey.Models.Rankings;
using System.Collections.Generic;

namespace DevelopersSurvey.Services.Automapper
{
    public class ServiceLayerMapperProfile : Profile
    {
        public ServiceLayerMapperProfile()
        {
            CreateMap<AddFootballTeamDto, FootballTeam>();

            CreateMap<FootballTeamDto, FootballTeam>();

            CreateMap<UpdateFootballTeamDto, FootballTeam>();

            CreateMap<RankingDto, FootballTeam>();

            CreateMap<AddPlayedGameDto, PlayedGame>();

            CreateMap<UpdatePlayedGameDto, PlayedGame>();

            CreateMap<PlayedGameDto, PlayedGame>();

            CreateMap<FootballTeamDto, DataSourceDto>();

            CreateMap<List<FootballTeamDto>, List<DataSourceDto>>();
        }
    }
}