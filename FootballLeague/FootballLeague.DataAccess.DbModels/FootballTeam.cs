using System.Collections.Generic;

namespace FootballLeague.DataAccess.DbModels
{
    public class FootballTeam : DbModelBase
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Stadium { get; set; }

        public int YearFound { get; set; }

        public int Points { get; set; }

        public virtual IList<PlayedGame> PlayedGames { get; set; }
    }
}
