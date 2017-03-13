using System.Linq;
using System.Web.Mvc;
using SnappetChallenge.Repository.Interfaces;

namespace SnappetChallenge.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDataRepository _dataRepository;

        public HomeController(IDataRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }

        public ActionResult Index()
        {
            var data = _dataRepository.GetRawData();

            var nullData = data.Where(d => d.Difficulty.Contains("null") || d.Difficulty.Contains("NULL")).ToList();

            var responseData = _dataRepository.GetResponseData();

            var nullResponseData = responseData.Where(d => !d.Difficulty.HasValue).ToList();

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