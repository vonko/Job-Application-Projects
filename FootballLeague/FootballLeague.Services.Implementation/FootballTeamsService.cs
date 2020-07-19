using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using FootballLeague.DataAccess.DbModels;
using FootballLeague.Models;
using FootballLeague.Services;

namespace FootballLeague.DataAccess.Implementation
{
    public class FootballTeamsService : IFootballTeamsService
    {
        private readonly IDALContext dalCotext;

        public FootballTeamsService(IDALContext dalCotext)
        {
            this.dalCotext = dalCotext;
        }

        public Result<FootballTeamDto> GetTeam(int teamId)
        {
            Result<FootballTeamDto> result = new Result<FootballTeamDto>();

            try
            {
                FootballTeamDto teamDto = this.dalCotext.FootballTeamsRepository.Find(teamId);
                if (teamDto == null)
                {
                    result.SetError($"There is no team with #{ teamId }!");

                    return result;
                }
                return result.SetData(teamDto);
            }
            catch (Exception ex)
            {
                result.SetError(ex.Message);

                return result;
            }
        }

        public Result<IList<FootballTeamDto>> GetAllTeams()
        {
            Result<IList<FootballTeamDto>> result = new Result<IList<FootballTeamDto>>();

            try
            {
                IList<FootballTeamDto> teamDtos = this.dalCotext.FootballTeamsRepository.AllMaterialed();

                return result.SetData(teamDtos);
            }
            catch(Exception ex)
            {
                result.SetError(ex.Message);

                return result;
            }
        }

        public Result<FootballTeamDto> AddFootballTeam(AddFootballTeamDto teamDto)
        {
            Result<FootballTeamDto> result = new Result<FootballTeamDto>();
            if (teamDto == null)
            {
                result.SetError("Please provide a team to add!");

                return result;
            }

            try
            {
                FootballTeamDto newTeamDto = this.dalCotext.FootballTeamsRepository.AddTeam(teamDto);

                result.SetSuccess("Team added successfully.");

                return result.SetData(newTeamDto);
            }
            catch(Exception ex)
            {
                result.SetError(ex.Message);
                return result;
            }
        }

        public Result UpdateFootballTeam(UpdateFootballTeamDto teamDto)
        {
            Result result = new Result();
            if (teamDto == null)
            {
                return result.SetError("Plase provide a team to delete!");
            }

            try
            {
                FootballTeam footballTeam = this.dalCotext.FootballTeamsRepository.FindRough(teamDto.ID);
                if (footballTeam == null)
                {
                    return result.SetError($"There is no team with #{ teamDto.ID }!");
                }

                footballTeam.Name = teamDto.Name;
                footballTeam.YearFound = teamDto.YearFound;
                footballTeam.Stadium = teamDto.Stadium;

                this.dalCotext.FootballTeamsRepository.Update(footballTeam);
            }
            catch(Exception ex)
            {
                return result.SetError(ex.Message);
            }

            return result.SetSuccess($"Team with #{ teamDto.ID } updated successfully.");
        }

        public Result DeleteTeam(int teamId)
        {
            Result result = new Result();

            try
            {
                this.dalCotext.FootballTeamsRepository.Delete(t => t.ID == teamId);
            }
            catch (Exception ex)
            {
                return result.SetError(ex.Message);
            }

            return result.SetSuccess($"Team with #{ teamId } deleted successfully.");
        }

        public Result<IList<FootballTeamDto>> GetTeamRanikings()
        {
            Result<IList<FootballTeamDto>> result = new Result<IList<FootballTeamDto>>();

            try
            {
                List<FootballTeam> teams = this.dalCotext.FootballTeamsRepository
                                           .All()
                                           .OrderByDescending(t => t.Points)
                                           .ToList();
                IList<FootballTeamDto> teamDtos = Mapper.Map<List<FootballTeam>, List<FootballTeamDto>>(teams);

                return result.SetData(teamDtos);
            }
            catch (Exception ex)
            {
                result.SetError(ex.Message);

                return result;
            }
        }
    }
}
