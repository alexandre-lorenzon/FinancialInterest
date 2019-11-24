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

        [HttpGet, Route("v1/[controller]")]
        [ProducesResponseType(typeof(decimal), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public ActionResult<decimal> Get() => _repository.Get();
    }
}