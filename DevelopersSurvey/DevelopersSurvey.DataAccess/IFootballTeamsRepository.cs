using DevelopersSurvey.DataAccess.DbModels;
using DevelopersSurvey.Models.FootballTeam;
using System.Collections.Generic;

namespace DevelopersSurvey.DataAccess
{
    public interface IFootballTeamsRepository : IRepositoryBase<FootballTeam>
    {
        FootballTeamDto AddTeam(AddFootballTeamDto teamToAdd);

        IList<FootballTeamDto> AllMaterialed();

        FootballTeamDto Find(params object[] keys);
    }
}
