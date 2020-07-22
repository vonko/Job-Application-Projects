using DevelopersSurvey.Models.Language;
using System.Collections.Generic;

namespace DevelopersSurvey.Models.Developer
{
    public class AddDeveloperDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PersonalIdNumber { get; set; }

        public int YearsOfExperience { get; set; }

        public string CurrentPosition { get; set; }

        public IList<AddLanguageLearntDto> KnownLanguages { get; set; } = new List<AddLanguageLearntDto>();
    }
}
