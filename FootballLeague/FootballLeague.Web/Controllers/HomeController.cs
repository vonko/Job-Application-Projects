using System.Web.Mvc;

namespace FootballLeague.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        { 
            return this.View();
        }
    }
}