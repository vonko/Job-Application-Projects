using AutoMapper;
using FootballLeague.DataAccess.DbModels;
using FootballLeague.Models.FootballTeam;
using System.Collections.Generic;
using System.Linq;

namespace FootballLeague.DataAccess.Implementation
{
    public class FootballTeamsRepository : RepositoryBase<FootballTeam>, IFootballTeamsRepository
    {
        public FootballTeamsRepository(FootballLeagueDbContext context)
            : base(context)
        {
        }

        public FootballTeamDto AddTeam(AddFootballTeamDto teamToAdd)
        {
            FootballTeam team = Mapper.Map<AddFootballTeamDto, FootballTeam>(teamToAdd);
            this.context.FootballTeams.Add(team);

            this.context.SaveChanges();

            FootballTeamDto addedTeam = Mapper.Map<FootballTeam, FootballTeamDto>(team);

            return addedTeam;
        }

        public virtual IList<FootballTeamDto> AllMaterialed()
        {
            var teams = this.DbSet.AsQueryable();
            IList<FootballTeamDto> teamDtos = Mapper.Map<IList<FootballTeam>, IList<FootballTeamDto>>(teams.ToList());

            return teamDtos;
        }

        public virtual FootballTeamDto Find(params object[] keys)
        {
            FootballTeam team = this.DbSet.Find(keys);
            FootballTeamDto foundTeamDto = Mapper.Map<FootballTeam, FootballTeamDto>(team);

            return foundTeamDto;
        }
    }
}
