using System;
using System.Collections.Generic;
using System.Linq;

namespace Klear.Financial.Lib
{
    public class XIRRCalculator
    {
        public XIRRCalculator(double lowRate, double highRate, List<CashFlowDates> cashFlow)
        {
            var cashFlowYears = ToFractionOfYears(cashFlow);
            Initialize(lowRate, highRate, cashFlowYears);

        }
        private XIRRCalculator(double lowRate, double highRate, List<CashFlowFractionOfYear> cashFlow)
        {
            Initialize(lowRate, highRate, cashFlow);
        }
        private void Initialize(double lowRate, double highRate, List<CashFlowFractionOfYear> cashFlow)
        {
            LowRate = lowRate;
            HighRate = highRate;
            CashFlow = cashFlow;
            LowResult = CalcEquation(CashFlow, LowRate);
            HighResult = CalcEquation(CashFlow, HighRate);
        }
        private double LowRate { get; set; }
        private double HighRate { get; set; }
        private double LowResult { get; set; }
        private double HighResult { get; set; }
        private List<CashFlowFractionOfYear> CashFlow { get; set; }

        private double CalcEquation(List<CashFlowFractionOfYear> cashflows, double interestRate)
        {
            return cashflows.Select(x => (x.Amount / (Math.Pow((1 + interestRate), x.Years)))).Sum(x => x);
        }
        private static List<CashFlowFractionOfYear> ToFractionOfYears(List<CashFlowDates> cashflows)
        {
            var firstDate = cashflows.Min(x => x.Date);
            return cashflows
                .Select(x => new CashFlowFractionOfYear(x.Amount, ((double)x.Date.Subtract(firstDate).Days) / 365))
                .ToList();
        }

        public double Calculate(double precision, int decimals)
        {
            if (Math.Sign(LowResult) == Math.Sign(HighResult))
            {
                throw new Exception("Value cannot be calculated");
            }

            var middleRate = (LowRate + HighRate) / 2;
            var middleResult = CalcEquation(CashFlow, middleRate);
            if (Math.Sign(middleResult) == Math.Sign(LowResult))
            {
                LowRate = middleRate;
                LowResult = middleResult;
            }
            else
            {
                HighRate = middleRate;
                HighResult = middleResult;
            }
            if (Math.Abs(middleResult) > precision)
            {
                return Calculate(precision, decimals);
            }
            else
            {
                return Math.Round((HighRate + LowRate) / 2, decimals);
            }

        }

    }

}
