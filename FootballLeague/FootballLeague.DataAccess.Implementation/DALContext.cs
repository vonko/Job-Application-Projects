using FootballLeague.DataAccess.DbModels;
using LiveResults.DataAccess;
using System;

namespace FootballLeague.DataAccess.Implementation
{
    public class DALContext : IDALContext
    {
        private FootballLeagueDbContext dbContext;

        private IFootballTeamsRepository footballTeamRepository;
        private IRepository<PlayedGame> playedGamesRepository;

        public DALContext()
        {
            this.dbContext = new FootballLeagueDbContext();
        }

        public IFootballTeamsRepository FootballTeamsRepository
        {
            get
            {
                if (this.footballTeamRepository == null)
                {
                    this.footballTeamRepository = new FootballTeamsRepository(this.dbContext);
                }

                return this.footballTeamRepository;
            }
        }

        public IRepository<PlayedGame> PlayedGamesRepository
        {
            get
            {
                if (this.playedGamesRepository == null)
                {
                    this.playedGamesRepository = new Repository<PlayedGame>(this.dbContext);
                }

                return this.playedGamesRepository;
            }
        }

        public int SaveChanges()
        {
            return this.dbContext.SaveChanges();
        }

        public void Dispose()
        {
            if (this.footballTeamRepository != null)
            {
                this.footballTeamRepository.Dispose();
            }

            if (this.playedGamesRepository != null)
            {
                this.playedGamesRepository.Dispose();
            }

            if (dbContext != null)
            {
                dbContext.Dispose();
            }

            GC.SuppressFinalize(this);
        }
    }
}
