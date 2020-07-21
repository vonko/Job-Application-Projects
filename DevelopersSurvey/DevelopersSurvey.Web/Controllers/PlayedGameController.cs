using AutoMapper;
using DevelopersSurvey.Models;
using DevelopersSurvey.Models.DataSources;
using DevelopersSurvey.Models.PlayedGame;
using DevelopersSurvey.Services;
using DevelopersSurvey.Web.Models.DataSources;
using DevelopersSurvey.Web.Models.PlayedGames;
using System.Collections.Generic;
using System.Web.Mvc;

namespace DevelopersSurvey.Web.Controllers
{
    public class PlayedGameController : Controller
    {
        private readonly IPlayedGamesService service;
        private readonly IDataSourceService dataSourceService;

        public PlayedGameController(IPlayedGamesService service,
                                    IDataSourceService dataSourceService)
        {
            this.service = service;
            this.dataSourceService = dataSourceService;
        }

        [HttpGet]
        public ActionResult PlayedGames()
        {
            Result<IList<PlayedGameDto>> gamesResult = this.service.GetAllGames();
            PlayedGamesDataContextViewModel dataContext = new PlayedGamesDataContextViewModel();
            if (gamesResult.IsError)
            {
                ModelState.AddModelError("", $"Error: { gamesResult.Message }");

                return View(dataContext);
            }

            IList<PlayedGameViewModel> gamesViewModels = Mapper.Map<IList<PlayedGameDto>, IList<PlayedGameViewModel>>(gamesResult.Data);
            dataContext.PlayedGames = gamesViewModels;

            return View(dataContext);
        }

        [HttpGet]
        public ActionResult AddPlayedGame()
        {
            AddPlayedGameViewModel viewModel = new AddPlayedGameViewModel();
            var teamsDataSourceResult = this.dataSourceService.GetFootballTeamsDataSource();
            if (teamsDataSourceResult.IsError)
            {
                ModelState.AddModelError("", $"Error: { teamsDataSourceResult.Message }");

                return View(viewModel);
            }

            var dataSourcesResult = this.dataSourceService.GetPlayedGameDataSources();
            if (dataSourcesResult.IsError)
            {
                ModelState.AddModelError("", $"Error: { dataSourcesResult.Message }");

                return View(viewModel);
            }
            viewModel.DataSources = this.MapPlayedGamesDataSources(dataSourcesResult.Data);

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddPlayedGame(AddPlayedGameViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }
            // Generate the token and send it
            AddPlayedGameDto gameToAdd = Mapper.Map<AddPlayedGameViewModel, AddPlayedGameDto>(viewModel);
            Result<PlayedGameDto> result = this.service.AddPlayedGame(gameToAdd);
            if (result.IsError)
            {
                ModelState.AddModelError("", $"Error: { result.Message }");
            }

            return RedirectToAction("PlayedGames", "PlayedGame");
        }

        [HttpGet]
        public ActionResult UpdatePlayedGame(int gameId)
        {
            Result<PlayedGameDto> result = this.service.GetGame(gameId);
            if (result.IsError)
            {
                ModelState.AddModelError("", $"Error: { result.Message }");

                return View();
            }

            UpdatePlayedGameViewModel viewModel = Mapper.Map<PlayedGameDto, UpdatePlayedGameViewModel>(result.Data);
            var dataSourcesResult = this.dataSourceService.GetPlayedGameDataSources();
            if (dataSourcesResult.IsError)
            {
                ModelState.AddModelError("", $"Error: { dataSourcesResult.Message }");

                return View(viewModel);
            }
            viewModel.DataSources = this.MapPlayedGamesDataSources(dataSourcesResult.Data);

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdatePlayedGame(UpdatePlayedGameViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            UpdatePlayedGameDto gameToUpdate = Mapper.Map<UpdatePlayedGameViewModel, UpdatePlayedGameDto>(viewModel);
            Result result = this.service.UpdateGame(gameToUpdate);
            if (result.IsError)
            {
                ModelState.AddModelError("", $"Error: { result.Message }");
            }

            return RedirectToAction("PlayedGames", "PlayedGame");
        }

        [HttpGet]
        public ActionResult DeletePlayedGame(int gameId)
        {
            Result result = this.service.DeleteGame(gameId);
            if (result.IsError)
            {
                ModelState.AddModelError("", $"Error: { result.Message }");
            }

            return RedirectToAction("PlayedGames", "PlayedGame");
        }

        private PlayedGameDataSourcesViewModel MapPlayedGamesDataSources(PlayedGameDataSourcesDto data)
        {
            PlayedGameDataSourcesViewModel dataSourceViewModel = new PlayedGameDataSourcesViewModel()
            {
                Teams = new Dictionary<int, DataSourceViewModel>(),
                Results = new Dictionary<int, DataSourceViewModel>()
            };

            foreach (var teamItem in data.Teams)
            {
                DataSourceViewModel sourceViewModel = Mapper.Map<DataSourceDto, DataSourceViewModel>(teamItem.Value);

                dataSourceViewModel.Teams.Add(teamItem.Key, sourceViewModel);
            }

            foreach (var resultItem in data.Results)
            {
                DataSourceViewModel sourceViewModel = Mapper.Map<DataSourceDto, DataSourceViewModel>(resultItem.Value);

                dataSourceViewModel.Results.Add(resultItem.Key, sourceViewModel);
            }

            return dataSourceViewModel;
        }
    }
}