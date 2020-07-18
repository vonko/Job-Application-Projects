using System.Data.Entity.Migrations;

namespace FootballLeague.DataAccess.Implementation.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<FootballLeagueDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(FootballLeagueDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
