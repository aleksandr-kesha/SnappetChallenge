using System.Web.Mvc;
using SnappetChallenge.Repository.Interfaces;

namespace SnappetChallenge.Controllers
{
    public class DataController : Controller
    {
        private readonly IDataRepository _dataRepository;

        public DataController(IDataRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }

        public ActionResult GetResponseData()
        {
            return Json(_dataRepository.GetResponseData());
        }

        public ActionResult GetRawData()
        {
            return Json(_dataRepository.GetRawData());
        }

        public ActionResult GetSubjects()
        {
            return Json(_dataRepository.GetSubjects());
        }
    }
}