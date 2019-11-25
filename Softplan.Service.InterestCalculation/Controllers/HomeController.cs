using Microsoft.AspNetCore.Mvc;

namespace Softplan.Service.InterestCalculation.Controllers
{
    [Route("/")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        /// <summary>
        /// Endpoint para valida status do serviço
        /// </summary>
        /// <returns>Mensagem informando que o serviço está sendo executado</returns>
        [HttpGet]
        public ActionResult Get() => Ok("Interest Rate Calculation Service is running");
    }
}
