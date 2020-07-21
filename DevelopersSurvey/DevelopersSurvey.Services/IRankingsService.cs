using DevelopersSurvey.Models;
using DevelopersSurvey.Models.Rankings;
using System.Collections.Generic;

namespace DevelopersSurvey.Services
{
    public interface IRankingsService
    {
        Result<IList<RankingDto>> GetTeamRanikings();
    }
}
