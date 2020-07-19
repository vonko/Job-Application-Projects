using System.Collections.Generic;

namespace FootballLeague.Web.Models.FootballTeams
{
    public class FootballTeamsDataContextViewModel
    {
        public IList<FootballTeamViewModel> Teams { get; set; } = new List<FootballTeamViewModel>();
    }
}