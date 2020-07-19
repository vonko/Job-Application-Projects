using FootballLeague.DataAccess.DbModels;
using System;

namespace FootballLeague.DataAccess
{
    public interface IDALContext : IDisposable
    {
        IRepository<FootballTeam> FootballTeamsRepository { get; }

        IRepository<PlayedGame> PlayedGamesRepository { get; }

        int SaveChanges();
    }
}
