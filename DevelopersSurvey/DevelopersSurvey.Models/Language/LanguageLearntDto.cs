using DevelopersSurvey.Models.ProgrammingLanguage;

namespace DevelopersSurvey.Models.Language
{
    public class AddLanguageLearntDto
    {
        public ProgrammingLanguage.ProgrammingLanguage LanguageID { get; set; }

        public SeniorityLevel SeniorityLevel { get; set; }
    }
}
