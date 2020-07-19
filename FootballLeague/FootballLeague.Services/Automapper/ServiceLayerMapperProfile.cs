using AutoMapper;
using FootballLeague.DataAccess.DbModels;
using FootballLeague.Models;

namespace FootballLeague.Services.Automapper
{
    public class ServiceLayerMapperProfile : Profile
    {
        public ServiceLayerMapperProfile()
        {
            CreateMap<AddFootballTeamDto, FootballTeam>();

            CreateMap<FootballTeamDto, FootballTeam>();

            CreateMap<UpdateFootballTeamDto, FootballTeam>();

            CreateMap<AddPlayedGameDto, PlayedGame>();

            CreateMap<PlayedGameDto, PlayedGame>();
        }
    }
}