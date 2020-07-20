using AutoMapper;
using FootballLeague.Models.DataSources;
using FootballLeague.Models.FootballTeam;
using FootballLeague.Models.PlayedGame;
using FootballLeague.Models.Rankings;
using FootballLeague.Web.Models.DataSources;
using FootballLeague.Web.Models.FootballTeams;
using FootballLeague.Web.Models.PlayedGames;
using FootballLeague.Web.Models.Rankings;
using System.Collections.Generic;

namespace FootballLeague.Web.Automapper
{
    public class WebLayerMapperProfile : Profile
    {
        public WebLayerMapperProfile()
        {
            CreateMap<AddFootballTeamDto, AddFootballTeamViewModel>();

            CreateMap<UpdateFootballTeamDto, UpdateFootballTeamViewModel>();

            CreateMap<FootballTeamDto, FootballTeamViewModel>();

            CreateMap<List<FootballTeamDto>, List<FootballTeamViewModel>>();

            CreateMap<AddPlayedGameDto, AddPlayedGameViewModel>();

            CreateMap<PlayedGameDto, PlayedGameViewModel>();

            CreateMap<List<PlayedGameDto>, List<PlayedGameViewModel>>();

            CreateMap<RankingDto, RankingViewModel>();

            CreateMap<List<DataSourceDto>, List<DataSourceViewModel>>();

            CreateMap<DataSourceDto, DataSourceViewModel>();
        }
    }
}