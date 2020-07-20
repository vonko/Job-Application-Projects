using AutoMapper;
using FootballLeague.DataAccess.DbModels;
using FootballLeague.Models.PlayedGame;
using System.Collections.Generic;
using System.Linq;

namespace FootballLeague.DataAccess.Implementation
{
    public class PlayedGamesRepository : RepositoryBase<PlayedGame>, IPlayedGamesRepository
    {
        public PlayedGameDto AddGame(AddPlayedGameDto gameToAdd)
        {
            PlayedGame game = Mapper.Map<AddPlayedGameDto, PlayedGame>(gameToAdd);
            this.context.PlayedGames.Add(game);

            this.context.SaveChanges();

            PlayedGameDto addedGame = Mapper.Map<PlayedGame, PlayedGameDto>(game);

            return addedGame;
        }

        public virtual IList<PlayedGameDto> AllMaterialed()
        {
            var games = this.DbSet.AsQueryable();
            IList<PlayedGameDto> gameDtos = Mapper.Map<IList<PlayedGame>, IList<PlayedGameDto>>(games.ToList());

            return gameDtos;
        }

        public virtual PlayedGameDto Find(params object[] keys)
        {
            PlayedGame game = this.DbSet.Find(keys);
            PlayedGameDto gameDto = Mapper.Map<PlayedGame, PlayedGameDto>(game);

            return gameDto;
        }
    }
}
