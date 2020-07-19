using FootballLeague.Models;
using FootballLeague.Models.FootballTeam;
using System.Collections.Generic;

namespace FootballLeague.Services
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
