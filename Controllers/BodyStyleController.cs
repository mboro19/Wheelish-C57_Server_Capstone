using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Wheelish.Controllers
{
    public class BodyStyleController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
    }
}
