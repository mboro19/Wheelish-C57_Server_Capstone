using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Wheelish.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserVehicleController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
    }
}
        
