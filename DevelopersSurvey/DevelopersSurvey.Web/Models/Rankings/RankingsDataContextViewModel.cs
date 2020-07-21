using System.Collections.Generic;

namespace DevelopersSurvey.Web.Models.Rankings
{
    public class RankingsDataContextViewModel
    {
        public IList<RankingViewModel> Rankings { get; set; } = new List<RankingViewModel>();
    }
}