using DevelopersSurvey.Web.Models.DataSources;
using DevelopersSurvey.Web.Models.Language;
using System.Collections.Generic;

namespace DevelopersSurvey.Web.Models.Developer
{
    public class AddDeveloperViewModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int PersonalIdNumber { get; set; }

        public int YearsOfExperience { get; set; }

        public string CurrentPosition { get; set; }

        public AddLanguageLearntViewModel FirstKnownLanguage { get; set; } = new AddLanguageLearntViewModel();

        public AddLanguageLearntViewModel SecondKnownLanguage { get; set; } = new AddLanguageLearntViewModel();

        public AddLanguageLearntViewModel ThirdKnownLanguage { get; set; } = new AddLanguageLearntViewModel();

        public AddLanguageLearntViewModel FourthKnownLanguage { get; set; } = new AddLanguageLearntViewModel();

        public AddLanguageLearntViewModel FifthKnownLanguage { get; set; } = new AddLanguageLearntViewModel();

        public IList<DataSourceViewModel> Languages { get; set; }

        public IList<DataSourceViewModel> SeniorityLevels { get; set; }
    }
}