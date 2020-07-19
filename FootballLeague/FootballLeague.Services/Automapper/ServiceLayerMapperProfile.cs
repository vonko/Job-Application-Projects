using AutoMapper;
using FootballLeague.DataAccess.DbModels;
using FootballLeague.Models;
using FootballLeague.Models.FootballTeam;
using FootballLeague.Models.PlayedGame;
using FootballLeague.Models.Rankings;
using System.Collections.Generic;

namespace FootballLeague.Services.Automapper
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

            CreateMap<PlayedGameDto, PlayedGame>();

            CreateMap<FootballTeamDto, DataSourceDto>();

            CreateMap<List<FootballTeamDto>, List<DataSourceDto>>();
        }
    }
}