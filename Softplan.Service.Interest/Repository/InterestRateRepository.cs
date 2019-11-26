using System.Threading.Tasks;

namespace Softplan.Service.InterestRate.Repository
{
    public class InterestRateRepository : IInterestRateRepository
    {
        public decimal Get() => 0.01M;
        
    }
}
