using AutoMapper;
using FootballLeague.DataAccess;
using FootballLeague.DataAccess.DbModels;
using FootballLeague.Models;
using FootballLeague.Models.DataSources;
using FootballLeague.Models.PlayedGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;

namespace FootballLeague.Services.Implementation
{
    public class PlayedGamesService : IPlayedGamesService
    {
        private const int WINNING_POINTS = 3;
        private const int DRAW_POINTS = 1;

        private readonly IDALContext dalCotext;
        private readonly IDataSourceService dataSourceService;

        public PlayedGamesService(IDALContext dalCotext,
                                  IDataSourceService dataSourceService)
        {
            this.dalCotext = dalCotext;
            this.dataSourceService = dataSourceService;
        }

        public Result<PlayedGameDto> GetGame(int gameId)
        {
            Result<PlayedGameDto> result = new Result<PlayedGameDto>();

            try
            {
                PlayedGameDto gameDto = this.dalCotext.PlayedGamesRepository.Find(gameId);
                if (gameDto == null)
                {
                    result.SetError($"There is no game with #{ gameId }!");

                    return result;
                }

                var dataSourcesResult = this.dataSourceService.GetPlayedGameDataSources();
                if (dataSourcesResult.IsError)
                {
                    result.SetError(dataSourcesResult.Message);

                    return result;
                }

                var dataSources = dataSourcesResult.Data;

                gameDto = this.FillGameAdditionalData(dataSources, gameDto);

                return result.SetData(gameDto);
            }
            catch(Exception ex)
            {
                result.SetError(ex.Message);

                return result;
            }
        }

        public Result<IList<PlayedGameDto>> GetAllGames()
        {
            Result<IList<PlayedGameDto>> result = new Result<IList<PlayedGameDto>>();

            try
            {
                List<PlayedGame> games = this.dalCotext.PlayedGamesRepository.All().ToList();
                IList<PlayedGameDto> gameDtos = Mapper.Map<List<PlayedGame>, List<PlayedGameDto>>(games);

                var dataSourcesResult = this.dataSourceService.GetPlayedGameDataSources();
                if (dataSourcesResult.IsError)
                {
                    result.SetError(dataSourcesResult.Message);

                    return result;
                }

                var dataSources = dataSourcesResult.Data;

                foreach(var gameDto in gameDtos)
                {
                    this.FillGameAdditionalData(dataSources, gameDto);
                }

                return result.SetData(gameDtos);
            }
            catch (Exception ex)
            {
                result.SetError(ex.Message);

                return result;
            }
        }

        public Result<PlayedGameDto> AddPlayedGame(AddPlayedGameDto gameDto)
        {
            Result<PlayedGameDto> result = new Result<PlayedGameDto>();

            try
            {
                using (var scope = new TransactionScope(TransactionScopeOption.Required))
                {
                    gameDto.DatePlayed = DateTime.Now;
                    PlayedGameDto newGameDto = this.dalCotext.PlayedGamesRepository.AddGame(gameDto);

                    Result updatePointsResult = this.UpdateTeamsPoints(newGameDto, gameDeletion: false);
                    if (updatePointsResult.IsError)
                    {
                        result.SetError(updatePointsResult.Message);

                        return result;
                    }

                    scope.Complete();

                    result.SetSuccess("Game added successfully.");

                    return result.SetData(newGameDto);
                }
            }
            catch (Exception ex)
            {
                result.SetError(ex.Message);

                return result;
            }
        }

        public Result UpdateGame(PlayedGameDto newGameDto)
        {
            Result result = new Result();

            try
            { 
                PlayedGame oldPlayedGame = this.dalCotext.PlayedGamesRepository.FindRough(newGameDto.ID);
                if (newGameDto == null)
                {
                    return result.SetError($"There is no game with #{ newGameDto.ID }!");
                }

                using (var scope = new TransactionScope(TransactionScopeOption.Required))
                {
                    PlayedGameDto oldGameDto = Mapper.Map<PlayedGame, PlayedGameDto>(oldPlayedGame);
                    Result updatePointsResult = this.UpdateTeamsPoints(oldGameDto, gameDeletion: true);
                    if (updatePointsResult.IsError)
                    {
                        result.SetError(updatePointsResult.Message);

                        return result;
                    }

                    oldPlayedGame.Result = newGameDto.Result;

                    this.dalCotext.PlayedGamesRepository.Update(oldPlayedGame);

                    updatePointsResult = this.UpdateTeamsPoints(newGameDto, gameDeletion: false);
                    if (updatePointsResult.IsError)
                    {
                        result.SetError(updatePointsResult.Message);

                        return result;
                    }

                    scope.Complete();
                }

                return result.SetSuccess("Game updated successfully.");
            }
            catch (Exception ex)
            {
                return result.SetError(ex.Message);
            }
        }

        public Result DeleteGame(int gameId)
        {
            Result result = new Result();

            try
            {
                using (var scope = new TransactionScope(TransactionScopeOption.Required))
                {
                    PlayedGameDto gameDto = this.dalCotext.PlayedGamesRepository.Find(gameId);
                    if (gameDto == null)
                    {
                        return result.SetError($"There is no game with #{ gameId }!");
                    }

                    this.dalCotext.PlayedGamesRepository.Delete(gameDto.ID);

                    Result updateTeamPointsResult = this.UpdateTeamsPoints(gameDto, gameDeletion: true);
                    if (updateTeamPointsResult.IsError)
                    {
                        return updateTeamPointsResult;
                    }

                    scope.Complete();
                }

                return result.SetSuccess("Game deleted.");
            }
            catch (Exception ex)
            {
                return result.SetError(ex.Message);
            }
        }

        private Result UpdateTeamsPoints(PlayedGameDto game, bool gameDeletion)
        {
            Result result = this.UpdateHomeTeamWinOrDraw(game, gameDeletion);

            result = this.UpdateAwayTeamWinOrDraw(game, gameDeletion);

            return result;
        }

        private Result UpdateHomeTeamWinOrDraw(PlayedGameDto game, bool gameDeletion)
        {
            Result result = new Result();

            if (game.Result == GameResult.Won ||
                game.Result == GameResult.Draw)
            {
                FootballTeam homeTeam = this.dalCotext.FootballTeamsRepository.FindRough(game.HomeTeamId);
                if (homeTeam == null)
                {
                    return result.SetError($"There is no team with id #{ game.HomeTeamId }!");
                }

                if (game.Result == GameResult.Won)
                {
                    if (!gameDeletion)
                    {
                        homeTeam.Points += WINNING_POINTS;
                    }
                    else
                    {
                        homeTeam.Points -= WINNING_POINTS;
                    }
                }
                else if (game.Result == GameResult.Draw)
                {
                    if (!gameDeletion)
                    {
                        homeTeam.Points += DRAW_POINTS;
                    }
                    else
                    {
                        homeTeam.Points -= DRAW_POINTS;
                    }
                }

                this.dalCotext.FootballTeamsRepository.Update(homeTeam);
            }

            return result.SetSuccess("Team points updated.");
        }

        private Result UpdateAwayTeamWinOrDraw(PlayedGameDto game, bool gameDeletion)
        {
            Result result = new Result();

            if (game.Result == GameResult.Lost ||
               game.Result == GameResult.Draw)
            {
                FootballTeam awayTeam = this.dalCotext.FootballTeamsRepository.FindRough(game.AwayTeamId);
                if (awayTeam == null)
                {
                    return result.SetError($"There is no team with id #{ game.AwayTeamId }!");
                }

                if (game.Result == GameResult.Lost)
                {
                    if (!gameDeletion)
                    {
                        awayTeam.Points += WINNING_POINTS;
                    }
                    else
                    {
                        awayTeam.Points -= WINNING_POINTS;
                    }
                }
                else if (game.Result == GameResult.Draw)
                {
                    if (!gameDeletion)
                    {
                        awayTeam.Points += DRAW_POINTS;
                    }
                    else
                    {
                        awayTeam.Points -= DRAW_POINTS;
                    }
                }

                this.dalCotext.FootballTeamsRepository.Update(awayTeam);
            }

            return result.SetSuccess("Team points updated.");
        }

        private PlayedGameDto FillGameAdditionalData(PlayedGameDataSourcesDto dataSources, PlayedGameDto gameDto)
        {
            gameDto.HomeTeamName = dataSources.Teams[gameDto.HomeTeamId].Name;
            gameDto.AwayTeamName = dataSources.Teams[gameDto.AwayTeamId].Name;
            gameDto.ResultName = dataSources.Results[(int)gameDto.Result].Name;

            return gameDto;
        }
    }
}
