using Microsoft.AspNetCore.Mvc;

namespace Softplan.Service.Interest.Controllers
{
    [Route("/")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public ActionResult Get() => Ok("Interest Rate Service is running");
    }
}
