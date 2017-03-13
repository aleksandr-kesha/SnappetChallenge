using System.Web.Http;
using System.Web.Mvc;
using SnappetChallenge.Repository.Interfaces;

namespace SnappetChallenge.Controllers
{
    public class DataApiController : ApiController
    {
        private readonly IDataRepository _dataRepository;

        public DataApiController(IDataRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }

        public JsonResult GetResponseData()
        {
            return _dataRepository.GetResponseData();
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
