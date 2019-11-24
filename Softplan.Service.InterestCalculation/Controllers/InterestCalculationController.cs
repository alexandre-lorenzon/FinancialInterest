using Microsoft.AspNetCore.Mvc;
using Softplan.Service.InterestCalculation.Domain;
using Softplan.Service.InterestCalculation.Services;
using System.Net;
using System.Threading.Tasks;

namespace Softplan.Service.InterestCalculation.Controllers
{
    [Route("api/")]
    [ApiController]
    public class InterestCalculationController : ControllerBase
    {
        private readonly IInterestRateService _interestRateService;

        public InterestCalculationController(IInterestRateService interestRateService) => _interestRateService = interestRateService;

        [HttpGet, Route("v1/[controller]")]
        [ProducesResponseType(typeof(decimal), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<decimal>> Get([FromQuery] decimal valorInicial, int meses) 
        {
            var interestRate = await _interestRateService.GetAsync();

            var calculationDomain = new Calculation(valorInicial, interestRate, meses);
            var result = calculationDomain.TotalAmount();

            return Ok(result);
        }
    }
}