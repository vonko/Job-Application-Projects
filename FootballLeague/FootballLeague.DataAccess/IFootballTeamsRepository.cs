using FootballLeague.DataAccess.DbModels;
using FootballLeague.Models.FootballTeam;
using System.Collections.Generic;

namespace FootballLeague.DataAccess
{
    public interface IFootballTeamsRepository : IRepositoryBase<FootballTeam>
    {
        FootballTeamDto AddTeam(AddFootballTeamDto teamToAdd);

        IList<FootballTeamDto> AllMaterialed();

        FootballTeamDto Find(params object[] keys);
    }
}
