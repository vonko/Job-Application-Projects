using FootballLeague.Models;
using FootballLeague.Models.Rankings;
using System.Collections.Generic;

namespace FootballLeague.Services
{
    public interface IRankingsService
    {
        Result<IList<RankingDto>> GetTeamRanikings();
    }
}
