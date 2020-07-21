using System.Web.Mvc;

namespace DevelopersSurvey.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        { 
            return this.View();
        }
    }
}