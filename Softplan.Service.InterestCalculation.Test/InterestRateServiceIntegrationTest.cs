using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Softplan.Service.InterestCalculation.Test
{
    public class InterestRateServiceIntegrationTest
    {
        [Fact]
        public async Task GetInterestRate()
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync("http://localhost:54597/api/v1/interestrate/");
                response.EnsureSuccessStatusCode();
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
        }
    }
}
