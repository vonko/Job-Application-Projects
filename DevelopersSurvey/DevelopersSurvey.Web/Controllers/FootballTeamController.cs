using AutoMapper;
using DevelopersSurvey.Models;
using DevelopersSurvey.Models.FootballTeam;
using DevelopersSurvey.Services;
using DevelopersSurvey.Web.Models.FootballTeams;
using System.Collections.Generic;
using System.Web.Mvc;

namespace DevelopersSurvey.Web.Controllers
{
    public class FootballTeamController : Controller
    {
        private readonly IFootballTeamsService service;

        public FootballTeamController(IFootballTeamsService service)
        {
            this.service = service;
        }

        [HttpGet]
        public ActionResult FootballTeams()
        {
            Result<IList<FootballTeamDto>> teamsResult = this.service.GetAllTeams();
            FootballTeamsDataContextViewModel dataContext = new FootballTeamsDataContextViewModel();
            if (teamsResult.IsError)
            {
                ModelState.AddModelError("", $"Error: { teamsResult.Message }");

                return View(dataContext);
            }

            IList<FootballTeamViewModel> footballTeamViewModels = Mapper.Map<IList<FootballTeamDto>, IList<FootballTeamViewModel>>(teamsResult.Data);
            dataContext.Teams = footballTeamViewModels;

            return View(dataContext);
        }

        [HttpGet]
        public ActionResult AddFootballTeam()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddFootballTeam(AddFootballTeamViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }
            // Generate the token and send it
            AddFootballTeamDto teamToAdd = Mapper.Map<AddFootballTeamViewModel, AddFootballTeamDto>(viewModel);
            Result<FootballTeamDto> result = this.service.AddFootballTeam(teamToAdd);
            if (result.IsError)
            {
                ModelState.AddModelError("", $"Error: { result.Message }");
            }

            return RedirectToAction("FootballTeams", "FootballTeam");
        }

        [HttpGet]
        public ActionResult UpdateFootballTeam(int teamId)
        {
            Result<FootballTeamDto> result = this.service.GetTeam(teamId);
            if (result.IsError)
            {
                ModelState.AddModelError("", $"Error: { result.Message }");

                return View();
            }

            UpdateFootballTeamViewModel viewModel = Mapper.Map<FootballTeamDto, UpdateFootballTeamViewModel>(result.Data);

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateFootballTeam(UpdateFootballTeamViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            UpdateFootballTeamDto teamToUpdate = Mapper.Map<UpdateFootballTeamViewModel, UpdateFootballTeamDto>(viewModel);
            Result result = this.service.UpdateFootballTeam(teamToUpdate);
            if (result.IsError)
            {
                ModelState.AddModelError("", $"Error: { result.Message }");
            }

            return RedirectToAction("FootballTeams", "FootballTeam");
        }

        [HttpGet]
        public ActionResult DeleteFootballTeam(int teamId)
        {
            Result result = this.service.DeleteTeam(teamId);
            if (result.IsError)
            {
                ModelState.AddModelError("", $"Error: { result.Message }");
            }

            return RedirectToAction("FootballTeams", "FootballTeam");
        }
    }
}