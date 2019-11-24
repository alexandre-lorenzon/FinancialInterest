using Microsoft.Extensions.Configuration;
using System.Globalization;
using System.Net.Http;
using System.Threading.Tasks;

namespace Softplan.Service.InterestCalculation.Services
{
    public class InterestRateService : IInterestRateService
    {
        private readonly InterestRateServiceConfig _interestRateServiceConfig = new InterestRateServiceConfig();
        public InterestRateService(IConfiguration configuration) => configuration.GetSection("InterestRateService").Bind(_interestRateServiceConfig);

        public async Task<decimal> GetAsync()
        {
            decimal result = 0;

            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(_interestRateServiceConfig.Url);
                var responseContent = await response.Content.ReadAsStringAsync();

                decimal.TryParse(responseContent, 
                    NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign,
                    CultureInfo.InvariantCulture, out result);
            }

            return result;
        }
    }
}
