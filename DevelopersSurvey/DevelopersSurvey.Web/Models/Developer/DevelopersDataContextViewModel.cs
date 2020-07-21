using DevelopersSurvey.Web.Models.DataSources;
using System.Collections.Generic;

namespace DevelopersSurvey.Web.Models.Developer
{
    public class DevelopersDataContextViewModel
    {
        public IList<DeveloperViewModel> Developers { get; set; }

        public IList<DataSourceViewModel> Languages { get; set; }

        public IList<DataSourceViewModel> SeniorityLevels { get; set; }
    }
}