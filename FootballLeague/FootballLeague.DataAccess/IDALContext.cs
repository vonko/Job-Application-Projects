using FootballLeague.DataAccess.DbModels;
using LiveResults.DataAccess;
using System;

namespace FootballLeague.DataAccess
{
    public interface IDALContext : IDisposable
    {
        IFootballTeamsRepository FootballTeamsRepository { get; }

        IRepository<PlayedGame> PlayedGamesRepository { get; }

        int SaveChanges();
    }
}
