using AutoMapper;
using FootballLeague.Models;
using FootballLeague.Web.Models;
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

            CreateMap<IList<FootballTeamDto>, IList<FootballTeamViewModel>>();

            CreateMap<AddPlayedGameDto, AddPlayedGameViewModel>();

            CreateMap<PlayedGameDto, PlayedGameViewModel>();

            CreateMap<IList<PlayedGameDto>, IList<PlayedGameViewModel>>();
        }
    }
}