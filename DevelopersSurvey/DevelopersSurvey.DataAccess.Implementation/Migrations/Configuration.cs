using DevelopersSurvey.DataAccess.Implementation.Context;
using System.Data.Entity.Migrations;

namespace DevelopersSurvey.DataAccess.Implementation.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<DevelopersSurveyDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(DevelopersSurveyDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
