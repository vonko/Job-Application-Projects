using AutoMapper;
using FootballLeague.Models;
using FootballLeague.Models.PlayedGame;
using FootballLeague.Services;
using FootballLeague.Web.Models.PlayedGames;
using System.Collections.Generic;
using System.Web.Mvc;

namespace FootballLeague.Web.Controllers
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

            viewModel.Teams = Mapper.Map<IList<DataSourceDto>, IList<DataSourceViewModel>>(teamsDataSourceResult.Data);

            var resultsDataSource = this.dataSourceService.GetResultsDataSource();
            viewModel.Results = Mapper.Map<IList<DataSourceDto>, IList<DataSourceViewModel>>(resultsDataSource);

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
    }
}