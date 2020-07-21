using AutoMapper;
using DevelopersSurvey.DataAccess.DbModels;
using DevelopersSurvey.Models.Developer;
using System.Collections.Generic;
using System.Linq;

namespace DevelopersSurvey.DataAccess.Implementation
{
    public class DevelopersRepository : RepositoryBase<Developer>, IDevelopersRepository
    {
        public DeveloperDto AddDeveloper(AddDeveloperDto developerToAdd)
        {
            Developer developer = Mapper.Map<AddDeveloperDto, Developer>(developerToAdd);
            this.context.Developers.Add(developer);

            this.context.SaveChanges();

            DeveloperDto addedDeveloper = Mapper.Map<Developer, DeveloperDto>(developer);

            return addedDeveloper;
        }

        public virtual IList<DeveloperDto> AllMaterialed()
        {
            var developers = this.DbSet.AsQueryable();
            IList<DeveloperDto> developerDtos = Mapper.Map<IList<Developer>, IList<DeveloperDto>>(developers.ToList());

            return developerDtos;
        }

        public virtual DeveloperDto Find(params object[] keys)
        {
            Developer developer = this.DbSet.Find(keys);
            DeveloperDto developerDto = Mapper.Map<Developer, DeveloperDto>(developer);

            return developerDto;
        }
    }
}
