using Microsoft.AspNetCore.Mvc;

namespace Softplan.Service.InterestCalculation.Controllers
{
    [Route("/")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public ActionResult Get() => Ok("Interest Rate Calculation Service is running");
    }
}
