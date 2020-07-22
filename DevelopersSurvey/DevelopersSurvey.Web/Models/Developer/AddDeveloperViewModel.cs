using DevelopersSurvey.Web.Models.DataSources;
using DevelopersSurvey.Web.Models.Language;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace DevelopersSurvey.Web.Models.Developer
{
    public class AddDeveloperViewModel
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string PersonalIdNumber { get; set; }

        [Range(1, 70)]
        public int YearsOfExperience { get; set; }

        [Required]
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