using AutoMapper;
using DevelopersSurvey.Models;
using DevelopersSurvey.Models.DataSources;
using DevelopersSurvey.Models.Developer;
using DevelopersSurvey.Models.Language;
using DevelopersSurvey.Models.ProgrammingLanguage;
using DevelopersSurvey.Services;
using DevelopersSurvey.Web.Attributes;
using DevelopersSurvey.Web.Models.DataSources;
using DevelopersSurvey.Web.Models.Developer;
using DevelopersSurvey.Web.Models.Language;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace DevelopersSurvey.Web.Controllers
{
    public class DeveloperController : Controller
    {
        private readonly IDevelopersService service;
        private readonly IDataSourceService dataSourceService;

        public DeveloperController(IDevelopersService service,
                                   IDataSourceService dataSourceService)
        {
            this.service = service;
            this.dataSourceService = dataSourceService;
        }

        [HttpGet]
        public ActionResult Developers()
        {
            Result<IList<DeveloperDto>> developersResult = this.service.GetAllDevelopers();
            DevelopersDataContextViewModel dataContext = new DevelopersDataContextViewModel();
            if (developersResult.IsError)
            {
                ModelState.AddModelError("", $"Error: { developersResult.Message }");

                return View(dataContext);
            }

            IList<DeveloperViewModel> developerViewModels = Mapper.Map<IList<DeveloperDto>, IList<DeveloperViewModel>>(developersResult.Data);
            dataContext.Developers = developerViewModels;

            return View(dataContext);
        }

        [HttpGet]
        public ActionResult AddDeveloper()
        {
            AddDeveloperViewModel viewModel = new AddDeveloperViewModel();

            viewModel = this.FillDataSources(viewModel);

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddDeveloper(AddDeveloperViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel = this.FillDataSources(viewModel);

                return View(viewModel);
            }
            // Generate the token and send it
            var developerToAddResult = this.MapDeveloper(viewModel);
            if (developerToAddResult.IsError)
            {
                ModelState.AddModelError("", $"Error: { developerToAddResult.Message }");
                viewModel = this.FillDataSources(viewModel);

                return View(viewModel);
            }

            AddDeveloperDto developerToAdd = developerToAddResult.Data;

            Result<AddDeveloperDto> result = this.service.AddDeveloper(developerToAdd);
            if (result.IsError)
            {
                viewModel = this.FillDataSources(viewModel);
                ModelState.AddModelError("", $"Error: { result.Message }");

                return View(viewModel);
            }

            return RedirectToAction("Developers", "Developer");
        }

        private Result<AddDeveloperDto> MapDeveloper(AddDeveloperViewModel viewModel)
        {
            Result<AddDeveloperDto> result = new Result<AddDeveloperDto>();

            try
            {
                AddDeveloperDto dto = Mapper.Map<AddDeveloperViewModel, AddDeveloperDto>(viewModel);
                if (viewModel.FirstKnownLanguage != null && 
                    viewModel.FirstKnownLanguage.LanguageID != ProgrammingLanguage.Select &&
                    viewModel.FirstKnownLanguage.SeniorityLevel != SeniorityLevel.Select)
                {
                    dto.KnownLanguages.Add(Mapper.Map<AddLanguageLearntViewModel, AddLanguageLearntDto>(viewModel.FirstKnownLanguage));
                }
                if (viewModel.SecondKnownLanguage != null && 
                    viewModel.SecondKnownLanguage.LanguageID != ProgrammingLanguage.Select &&
                    viewModel.SecondKnownLanguage.SeniorityLevel != SeniorityLevel.Select)
                {
                    dto.KnownLanguages.Add(Mapper.Map<AddLanguageLearntViewModel, AddLanguageLearntDto>(viewModel.SecondKnownLanguage));
                }
                if (viewModel.ThirdKnownLanguage != null && 
                    viewModel.ThirdKnownLanguage.LanguageID != ProgrammingLanguage.Select &&
                    viewModel.ThirdKnownLanguage.SeniorityLevel != SeniorityLevel.Select)
                {
                    dto.KnownLanguages.Add(Mapper.Map<AddLanguageLearntViewModel, AddLanguageLearntDto>(viewModel.ThirdKnownLanguage));
                }
                if (viewModel.FourthKnownLanguage != null && 
                    viewModel.FourthKnownLanguage.LanguageID != ProgrammingLanguage.Select &&
                    viewModel.FourthKnownLanguage.SeniorityLevel != SeniorityLevel.Select)
                {
                    dto.KnownLanguages.Add(Mapper.Map<AddLanguageLearntViewModel, AddLanguageLearntDto>(viewModel.FourthKnownLanguage));
                }
                if (viewModel.FifthKnownLanguage != null && 
                    viewModel.FifthKnownLanguage.LanguageID != ProgrammingLanguage.Select &&
                    viewModel.FifthKnownLanguage.SeniorityLevel != SeniorityLevel.Select)
                {
                    dto.KnownLanguages.Add(Mapper.Map<AddLanguageLearntViewModel, AddLanguageLearntDto>(viewModel.FifthKnownLanguage));
                }

                if (dto.KnownLanguages.Count == 0)
                {
                    result.SetError("Select at least one language!");

                    return result;
                }

                return result.SetData(dto);
            }
            catch(Exception ex)
            {
                result.SetError(ex.Message);

                return result;
            }
        }

        private AddDeveloperViewModel FillDataSources(AddDeveloperViewModel viewModel)
        {
            IList<DataSourceDto> languagesDataSource = this.dataSourceService.GetLanguagesDataSource();
            viewModel.Languages = Mapper.Map<IList<DataSourceDto>, IList<DataSourceViewModel>>(languagesDataSource);

            IList<DataSourceDto> seniorityLevelsDataSource = this.dataSourceService.GetSeniorityLevelsDataSource();
            viewModel.SeniorityLevels = Mapper.Map<IList<DataSourceDto>, IList<DataSourceViewModel>>(seniorityLevelsDataSource);

            return viewModel;
        }
    }
}