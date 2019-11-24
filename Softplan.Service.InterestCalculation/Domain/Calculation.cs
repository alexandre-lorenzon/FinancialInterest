using Softplan.Financial.Commom.Types;
using System;

namespace Softplan.Service.InterestCalculation.Domain
{
    public class Calculation
    {
        public double InitialContribution { get; private set; }
        public double InterestRate { get; private set; }
        public int Months { get; private set; }

        public Calculation(decimal initialContribution, decimal interestRate, int months)
        {
            var initialContributionIsValid = double.TryParse(initialContribution.ToString(), out double initialValue);

            if (!initialContributionIsValid)
                throw new SoftException(ErrorCodes.InvalidValue, "Valor inicial informado é inválido");

            var interestRateIsValid = double.TryParse(interestRate.ToString(), out double interestRateValue);

            if (!interestRateIsValid)
                throw new SoftException(ErrorCodes.InvalidValue, "Taxa de juros informada é inválido");

            if (months < 0)
                throw new SoftException(ErrorCodes.InvalidValue, "Número de meses informado é inválido");

            InitialContribution = initialValue;
            InterestRate = interestRateValue;
            Months = months;
        }

        public string TotalAmount()
        {
            var totalInterest = Math.Pow((1 + InterestRate), Months);
            var amount = InitialContribution * totalInterest;

            var truncateAmount = Math.Truncate(100 * amount) / 100;

            var result = string.Format("{0:0.00}", truncateAmount);
            return result;
        }
    }
}
