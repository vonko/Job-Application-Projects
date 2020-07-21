using AutoMapper;
using DevelopersSurvey.Models;
using DevelopersSurvey.Models.Rankings;
using DevelopersSurvey.Services;
using FootballLeague.Web.Models.Rankings;
using System.Collections.Generic;
using System.Web.Mvc;

namespace FootballLeague.Web.Controllers
{
    public class RankingController : Controller
    {
        private readonly IRankingsService service;

        public RankingController(IRankingsService service)
        {
            this.service = service;
        }

        [HttpGet]
        public ActionResult Rankings()
        {
            Result<IList<RankingDto>> teamsResult = this.service.GetTeamRanikings();
            RankingsDataContextViewModel dataContext = new RankingsDataContextViewModel();
            if (teamsResult.IsError)
            {
                ModelState.AddModelError("", $"Error: { teamsResult.Message }");

                return View(dataContext);
            }

            IList<RankingViewModel> rankings = Mapper.Map<IList<RankingDto>, IList<RankingViewModel>>(teamsResult.Data);
            dataContext.Rankings = rankings;

            return View(dataContext);
        }
    }
}