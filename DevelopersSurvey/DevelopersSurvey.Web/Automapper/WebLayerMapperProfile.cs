using AutoMapper;
using DevelopersSurvey.Models.DataSources;
using DevelopersSurvey.Models.Developer;
using DevelopersSurvey.Models.Language;
using DevelopersSurvey.Web.Models.DataSources;
using DevelopersSurvey.Web.Models.Developer;
using DevelopersSurvey.Web.Models.Language;
using System.Collections.Generic;

namespace DevelopersSurvey.Web.Automapper
{
    public class WebLayerMapperProfile : Profile
    {
        public WebLayerMapperProfile()
        {
            CreateMap<List<DataSourceDto>, List<DataSourceViewModel>>();

            CreateMap<DataSourceDto, DataSourceViewModel>();

            CreateMap<AddLanguageLearntDto, AddLanguageLearntViewModel>();

            CreateMap<AddDeveloperDto, AddDeveloperViewModel>();

            CreateMap<DeveloperDto, DeveloperViewModel>();
        }
    }
}