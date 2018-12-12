namespace Klear.Financial.Lib
{
    public class CashFlowFractionOfYear
    {
        public CashFlowFractionOfYear(double amount, double years)
        {
            Amount = amount;
            Years = years;
        }
        public double Amount { get; set; }
        public double Years { get; set; }
    }
}
