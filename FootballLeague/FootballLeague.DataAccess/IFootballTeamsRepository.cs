using FootballLeague.DataAccess.DbModels;
using FootballLeague.Models;
using System.Collections.Generic;
using System.Linq;

namespace LiveResults.DataAccess
{
    public interface IFootballTeamsRepository : IRepositoryBase<FootballTeam>
    {
        FootballTeamDto AddTeam(AddFootballTeamDto teamToAdd);

        IQueryable<FootballTeam> All();

        IList<FootballTeamDto> AllMaterialed();

        FootballTeamDto Find(params object[] keys);

        int Update(FootballTeam team);
    }
}
