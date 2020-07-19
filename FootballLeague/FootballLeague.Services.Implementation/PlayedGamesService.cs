using AutoMapper;
using FootballLeague.DataAccess;
using FootballLeague.DataAccess.DbModels;
using FootballLeague.Models;
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

        public PlayedGamesService(IDALContext dalCotext)
        {
            this.dalCotext = dalCotext;
        }

        public Result<PlayedGameDto> GetGame(int gameId)
        {
            Result<PlayedGameDto> result = new Result<PlayedGameDto>();

            try
            {
                PlayedGame playedGame = this.dalCotext.PlayedGamesRepository.Find(gameId);
                if (playedGame == null)
                {
                    result.SetError($"There is no game with #{ gameId }!");

                    return result;
                }

                PlayedGameDto gameDto = Mapper.Map<PlayedGame, PlayedGameDto>(playedGame);

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

                return result.SetData(gameDtos);
            }
            catch (Exception ex)
            {
                result.SetError(ex.Message);

                return result;
            }
        }

        public Result<PlayedGameDto> PlayGame(AddPlayedGameDto gameDto)
        {
            Result<PlayedGameDto> result = new Result<PlayedGameDto>();

            try
            {
                using (var scope = new TransactionScope(TransactionScopeOption.Required))
                {
                    PlayedGame game = Mapper.Map<AddPlayedGameDto, PlayedGame>(gameDto);
                    PlayedGame addedGame = this.dalCotext.PlayedGamesRepository.Create(game);

                    PlayedGameDto newGameDto = Mapper.Map<PlayedGame, PlayedGameDto>(addedGame);

                    Result updatePointsResult = this.UpdateTeamsPoints(addedGame, gameDeletion: false);
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

        public Result UpdateGame(PlayedGameDto gameDto)
        {
            Result result = new Result();

            try
            { 
                PlayedGame playedGame = this.dalCotext.PlayedGamesRepository.Find(gameDto.ID);
                if (playedGame == null)
                {
                    return result.SetError($"There is no game with #{ gameDto.ID }!");
                }

                using (var scope = new TransactionScope(TransactionScopeOption.Required))
                {
                    Result updatePointsResult = this.UpdateTeamsPoints(playedGame, gameDeletion: true);
                    if (updatePointsResult.IsError)
                    {
                        result.SetError(updatePointsResult.Message);

                        return result;
                    }

                    playedGame.Result = gameDto.Result;

                    this.dalCotext.PlayedGamesRepository.Update(playedGame);

                    updatePointsResult = this.UpdateTeamsPoints(playedGame, gameDeletion: false);
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
                    PlayedGame playedGame = this.dalCotext.PlayedGamesRepository.Find(gameId);
                    if (playedGame == null)
                    {
                        return result.SetError($"There is no game with #{ gameId }!");
                    }

                    this.dalCotext.PlayedGamesRepository.Delete(playedGame);

                    Result updateTeamPointsResult = this.UpdateTeamsPoints(playedGame, gameDeletion: true);
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

        private Result UpdateTeamsPoints(PlayedGame game, bool gameDeletion)
        {
            Result result = this.UpdateHomeTeamWinOrDraw(game, gameDeletion);

            result = this.UpdateAwayTeamWinOrDraw(game, gameDeletion);

            return result;
        }

        private Result UpdateHomeTeamWinOrDraw(PlayedGame game, bool gameDeletion)
        {
            Result result = new Result();

            if (game.Result == GameResult.Won ||
                game.Result == GameResult.Draw)
            {
                FootballTeam homeTeam = this.dalCotext.FootballTeamsRepository.Find(game.HomeTeamId);
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

        private Result UpdateAwayTeamWinOrDraw(PlayedGame game, bool gameDeletion)
        {
            Result result = new Result();

            if (game.Result == GameResult.Lost ||
               game.Result == GameResult.Draw)
            {
                FootballTeam awayTeam = this.dalCotext.FootballTeamsRepository.Find(game.AwayTeamId);
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
    }
}
