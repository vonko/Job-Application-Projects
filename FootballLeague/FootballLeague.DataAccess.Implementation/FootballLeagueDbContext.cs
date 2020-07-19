using FootballLeague.DataAccess.DbModels;
using System.Data.Entity;

namespace FootballLeague.DataAccess.Implementation
{
    public class FootballLeagueDbContext : DbContext
    {
        public FootballLeagueDbContext() 
            : base("name=FootballLeagueDBConnectionString")
        {
            //this.Configuration.LazyLoadingEnabled = true;

            Database.SetInitializer(new MigrateDatabaseToLatestVersion<FootballLeagueDbContext, Migrations.Configuration>());
        }

        public DbSet<FootballTeam> FootballTeams { get; set; }

        public DbSet<PlayedGame> PlayedGames { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FootballTeam>()
              .HasMany(s => s.PlayedGames)
              .WithOptional()
              .WillCascadeOnDelete(true);

            modelBuilder.Entity<PlayedGame>()
               .HasRequired(m => m.HomeTeam)
               .WithMany(t => t.PlayedGames)
               .HasForeignKey(m => m.HomeTeamId)
               .WillCascadeOnDelete(false);

            modelBuilder.Entity<PlayedGame>()
                        .HasRequired(m => m.AwayTeam)
                        .WithMany(t => t.PlayedGames)
                        .HasForeignKey(m => m.AwayTeamId)
                        .WillCascadeOnDelete(false);
        }
    }
}
