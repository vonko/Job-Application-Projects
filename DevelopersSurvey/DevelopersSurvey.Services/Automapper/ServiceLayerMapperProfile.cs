using AutoMapper;
using DevelopersSurvey.DataAccess.DbModels;
using DevelopersSurvey.Models.Developer;
using DevelopersSurvey.Models.Language;
using System.Collections.Generic;

namespace DevelopersSurvey.Services.Automapper
{
    public class ServiceLayerMapperProfile : Profile
    {
        public ServiceLayerMapperProfile()
        {
            CreateMap<List<AddDeveloperDto>, List<Developer>>();

            CreateMap<List<DeveloperDto>, List<Developer>>();

            CreateMap<List<AddLanguageLearntDto>, List<LanguageLearnt>>();

            CreateMap<List<LanguageLearntDto>, List<LanguageLearnt>>();
        }
    }
}