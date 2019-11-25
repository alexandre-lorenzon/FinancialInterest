using Microsoft.AspNetCore.Mvc;
using Softplan.Service.InterestRate.Repository;
using System.Net;

namespace Softplan.Service.Interest.Controllers
{
    [Route("api/")]
    [ApiController]
    public class InterestRateController : ControllerBase
    {
        private readonly IInterestRateRepository _repository;

        public InterestRateController(IInterestRateRepository repository) => _repository = repository;

        /// <summary>
        /// Endpoint que retorna a taxa de juros
        /// </summary>
        /// <returns>Retorna a taxa de juros que está sendo praticada</returns>
        [HttpGet, Route("v1/[controller]")]
        [ProducesResponseType(typeof(decimal), (int)HttpStatusCode.OK)]
        public ActionResult<decimal> Get() => _repository.Get();
    }
}