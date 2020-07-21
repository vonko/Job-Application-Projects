using DevelopersSurvey.Models;
using DevelopersSurvey.Models.FootballTeam;
using System.Collections.Generic;

namespace DevelopersSurvey.Services
{
    public interface IFootballTeamsService
    {
        Result<FootballTeamDto> GetTeam(int teamId);

        Result<IList<FootballTeamDto>> GetAllTeams();

        Result<FootballTeamDto> AddFootballTeam(AddFootballTeamDto teamDto);

        Result UpdateFootballTeam(UpdateFootballTeamDto teamDto);

        Result DeleteTeam(int teamId);
    }
}
