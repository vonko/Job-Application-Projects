using DevelopersSurvey.DataAccess.DbModels;
using DevelopersSurvey.Models.Developer;
using System.Collections.Generic;

namespace DevelopersSurvey.DataAccess
{
    public interface IDevelopersRepository : IRepositoryBase<Developer>
    {
        DeveloperDto AddDeveloper(AddDeveloperDto teamToAdd);

        IList<DeveloperDto> AllMaterialed();

        DeveloperDto Find(params object[] keys);
    }
}
