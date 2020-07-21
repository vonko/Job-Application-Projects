using DevelopersSurvey.Models.ProgrammingLanguage;

namespace DevelopersSurvey.Web.Models.Language
{
    public class AddLanguageLearntViewModel
    {
        public ProgrammingLanguage LanguageID { get; set; }

        public SeniorityLevel SeniorityLevel { get; set; }
    }
}