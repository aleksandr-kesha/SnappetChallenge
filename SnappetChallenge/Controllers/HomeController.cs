using System.Linq;
using System.Web.Mvc;

namespace SnappetChallenge.Controllers
{
    public class HomeController : Controller
    {
        private readonly DataRepository _dataRepository = new DataRepository();

        public ActionResult Index()
        {
            var data = _dataRepository.GetData();

            var nullData = data.Where(d => d.Difficulty.Contains("null") || d.Difficulty.Contains("NULL")).ToList();

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}