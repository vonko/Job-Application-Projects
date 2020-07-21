using DevelopersSurvey.Models;
using DevelopersSurvey.Models.Developer;
using System.Collections.Generic;

namespace DevelopersSurvey.Services
{
    public interface IDevelopersService
    {
        Result<IList<DeveloperDto>> GetAllDevelopers();

        Result<AddDeveloperDto> AddDeveloper(AddDeveloperDto developerToAdd);
    }
}
