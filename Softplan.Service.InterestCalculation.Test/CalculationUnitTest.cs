using Softplan.Financial.Commom.Types;
using Softplan.Service.InterestCalculation.Domain;
using Xunit;

namespace Softplan.Service.InterestCalculation.Test
{
    public class CalculationUnitTest
    {
        [Fact]
        public void InitialContributionLessThanZero() => Assert.Throws<SoftException>(() => new Calculation(-1, 0.01M, 5));

        [Fact]
        public void MonthsLessThanZero() => Assert.Throws<SoftException>(() => new Calculation(100, 0.01M, -5));

        [Fact]
        public void InterestRateLessThanZero() => Assert.Throws<SoftException>(() => new Calculation(100, -0.01M, 5));

        [Theory]
        [InlineData(0, 0, 0, "0,00")]
        [InlineData(100, 0.01, 5, "105,10")]
        [InlineData(199, 1.5, 15, "185333192,34")]
        public void CalculationWithValidArguments(decimal initialContribution, decimal interestRate, int months, string expectedAmount)
        {
            var calculation = new Calculation(initialContribution, interestRate, months);
            var amount = calculation.TotalAmount();

            Assert.Equal(expectedAmount, amount);
        }
    }
}
