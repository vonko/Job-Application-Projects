using DevelopersSurvey.DataAccess;
using DevelopersSurvey.Models;
using DevelopersSurvey.Models.Developer;
using System;
using System.Collections.Generic;

namespace DevelopersSurvey.Services.Implementation
{
    public class DevelopersService : IDevelopersService
    {
        private readonly IDevelopersRepository developersRepository;

        public DevelopersService(IDevelopersRepository developersRepository)
        {
            this.developersRepository = developersRepository;
        }

        public Result<IList<DeveloperDto>> GetAllDevelopers()
        {
            Result<IList<DeveloperDto>> result = new Result<IList<DeveloperDto>>();

            try
            {
                IList<DeveloperDto> developerDtos = this.developersRepository.AllMaterialed();

                return result.SetData(developerDtos);
            }
            catch (Exception ex)
            {
                result.SetError(ex.Message);

                return result;
            }
        }

        public Result<AddDeveloperDto> AddDeveloper(AddDeveloperDto developerToAdd)
        {
            Result<AddDeveloperDto> result = new Result<AddDeveloperDto>();

            try
            {
                AddDeveloperDto addedDeveloper = this.developersRepository.AddDeveloper(developerToAdd);

                return result.SetData(addedDeveloper);
            }
            catch(Exception ex)
            {
                result.SetError(ex.Message);

                return result;
            }
        }
    }
}
