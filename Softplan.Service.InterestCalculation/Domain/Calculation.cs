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

            #region Initial contribution validations

            if (initialContribution < 0)
                throw new SoftException(ErrorCodes.InvalidValue, "Valor inicial não pode ser negativo");

            var initialContributionIsValid = double.TryParse(initialContribution.ToString(), out double initialValue);

            if (!initialContributionIsValid)
                throw new SoftException(ErrorCodes.InvalidFormat, "Valor inicial informado é inválido");

            #endregion

            #region Interest rate validations

            if (interestRate < 0)
                throw new SoftException(ErrorCodes.InvalidValue, "Taxa de juros não pode ser negativo");

            var interestRateIsValid = double.TryParse(interestRate.ToString(), out double interestRateValue);

            if (!interestRateIsValid)
                throw new SoftException(ErrorCodes.InvalidFormat, "Taxa de juros informada é inválido");

            #endregion

            #region Months validations

            if (months < 0)
                throw new SoftException(ErrorCodes.InvalidValue, "Número de meses não pode ser negativo");

            #endregion

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
