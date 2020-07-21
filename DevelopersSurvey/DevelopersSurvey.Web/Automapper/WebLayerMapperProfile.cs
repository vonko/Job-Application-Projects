using AutoMapper;
using DevelopersSurvey.Models.DataSources;
using DevelopersSurvey.Models.FootballTeam;
using DevelopersSurvey.Models.PlayedGame;
using DevelopersSurvey.Models.Rankings;
using DevelopersSurvey.Web.Models.DataSources;
using DevelopersSurvey.Web.Models.FootballTeams;
using DevelopersSurvey.Web.Models.PlayedGames;
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

            CreateMap<UpdatePlayedGameDto, UpdatePlayedGameViewModel>();

            CreateMap<PlayedGameDto, UpdatePlayedGameViewModel>();

            CreateMap<PlayedGameDto, PlayedGameViewModel>();

            CreateMap<List<PlayedGameDto>, List<PlayedGameViewModel>>();

            CreateMap<RankingDto, RankingViewModel>();

            CreateMap<List<DataSourceDto>, List<DataSourceViewModel>>();

            CreateMap<DataSourceDto, DataSourceViewModel>();
        }
    }
}