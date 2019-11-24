using System.Threading.Tasks;

namespace Softplan.Service.InterestCalculation.Services
{
    public interface IInterestRateService
    {
        Task<decimal> GetAsync();
    }
}
