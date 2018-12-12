using System;

namespace Klear.Financial.Lib
{
    public class CashFlowDates
    {
        public CashFlowDates(double amount, DateTime date)
        {
            Amount = amount;
            Date = date.Date;
        }
        public double Amount { get; set; }
        public DateTime Date { get; set; }
    }
}
