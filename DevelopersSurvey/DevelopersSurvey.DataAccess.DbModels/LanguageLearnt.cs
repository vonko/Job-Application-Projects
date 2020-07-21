using DevelopersSurvey.Models.ProgrammingLanguage;

namespace DevelopersSurvey.DataAccess.DbModels
{
    public class LanguageLearnt
    {
        public int ID { get; set; }

        public ProgrammingLanguage LanguageID { get; set; }

        public SeniorityLevel SeniorityLevel { get; set; }

        public int DeveloperID { get; set; }
        public Developer Developer { get; set; }
    }
}
