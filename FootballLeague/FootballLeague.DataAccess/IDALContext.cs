using System;

namespace FootballLeague.DataAccess
{
    public interface IDALContext : IDisposable
    {
        IFootballTeamsRepository FootballTeamsRepository { get; }

        IPlayedGamesRepository PlayedGamesRepository { get; }

        int SaveChanges();
    }
}
