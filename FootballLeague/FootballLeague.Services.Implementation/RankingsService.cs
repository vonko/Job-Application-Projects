using AutoMapper;
using FootballLeague.DataAccess;
using FootballLeague.DataAccess.DbModels;
using FootballLeague.Models;
using FootballLeague.Models.Rankings;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FootballLeague.Services.Implementation
{
    public class RankingsService : IRankingsService
    {
        private readonly IFootballTeamsRepository teamsRepository;

        public RankingsService(IFootballTeamsRepository teamsRepository)
        {
            this.teamsRepository = teamsRepository;
        }

        public Result<IList<RankingDto>> GetTeamRanikings()
        {
            Result<IList<RankingDto>> result = new Result<IList<RankingDto>>();

            try
            {
                List<FootballTeam> teams = this.teamsRepository
                                           .All()
                                           .OrderByDescending(t => t.Points)
                                           .ToList();
                IList<RankingDto> rankingDtos = Mapper.Map<List<FootballTeam>, List<RankingDto>>(teams);
                int ranking = 0;
                foreach(var rankingDto in rankingDtos)
                {
                    ranking++;
                    rankingDto.Ranking = ranking;
                }

                return result.SetData(rankingDtos);
            }
            catch (Exception ex)
            {
                result.SetError(ex.Message);

                return result;
            }
        }
    }
}
