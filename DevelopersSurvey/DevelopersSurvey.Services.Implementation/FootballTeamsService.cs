using DevelopersSurvey.DataAccess.DbModels;
using DevelopersSurvey.Models;
using DevelopersSurvey.Models.FootballTeam;
using DevelopersSurvey.Services;
using System;
using System.Collections.Generic;

namespace DevelopersSurvey.DataAccess.Implementation
{
    public class FootballTeamsService : IFootballTeamsService
    {
        private readonly IFootballTeamsRepository teamsRepository;

        public FootballTeamsService(IFootballTeamsRepository teamsRepository)
        {
            this.teamsRepository = teamsRepository;
        }

        public Result<FootballTeamDto> GetTeam(int teamId)
        {
            Result<FootballTeamDto> result = new Result<FootballTeamDto>();

            try
            {
                FootballTeamDto teamDto = this.teamsRepository.Find(teamId);
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
                IList<FootballTeamDto> teamDtos = this.teamsRepository.AllMaterialed();

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
                FootballTeamDto newTeamDto = this.teamsRepository.AddTeam(teamDto);

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
                FootballTeam footballTeam = this.teamsRepository.FindRough(teamDto.ID);
                if (footballTeam == null)
                {
                    return result.SetError($"There is no team with #{ teamDto.ID }!");
                }

                footballTeam.Name = teamDto.Name;
                footballTeam.YearFound = teamDto.YearFound;
                footballTeam.Stadium = teamDto.Stadium;

                this.teamsRepository.Update(footballTeam);
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
                this.teamsRepository.Delete(teamId);
            }
            catch (Exception ex)
            {
                return result.SetError(ex.Message);
            }

            return result.SetSuccess($"Team with #{ teamId } deleted successfully.");
        }
    }
}
