using System.Collections.Generic;

namespace DevelopersSurvey.DataAccess.DbModels
{
    public class Developer : DbModelBase
    {
        public int ID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PersonalIdNumber { get; set; }

        public int YearsOfExperience { get; set; }

        public string CurrentPosition { get; set; }

        public virtual ICollection<LanguageLearnt> KnownLanguages { get; set; }
    }
}
