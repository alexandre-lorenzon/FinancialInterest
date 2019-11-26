using Microsoft.AspNetCore.Mvc;

namespace Softplan.Service.Interest.Controllers
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
        public ActionResult Get() => Ok("Interest Rate Service is running");
    }
}
