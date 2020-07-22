using DevelopersSurvey.DataAccess.DbModels;
using System.Data.Entity;

namespace DevelopersSurvey.DataAccess.Implementation.Context
{
    public class DevelopersSurveyDbContext : DbContext
    {
        public DevelopersSurveyDbContext() 
            : base("name=DevelopersSurveyDBConnectionString")
        {
            //this.Configuration.LazyLoadingEnabled = true;

            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DevelopersSurveyDbContext, Migrations.Configuration>());
        }

        public DbSet<Developer> Developers { get; set; }

        public DbSet<LanguageLearnt> KnownLanguages { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LanguageLearnt>()
                        .HasRequired(m => m.Developer)
                        .WithMany(t => t.KnownLanguages)
                        .HasForeignKey(m => m.DeveloperID)
                        .WillCascadeOnDelete(false);
        }
    }
}
