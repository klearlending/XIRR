# XIRR
A library to calculate XIRR in .NET\
Usage:\
The method is `public static double XIRR(List<CashFlowDates> cashflows, int decimals = 4, double maxRate = 1000000)`\
Example:\
```cs
           var cashFlows = new List<CashFlowDates>()
            {
                new CashFlowDates(-1000, new DateTime(2017, 1, 1)),
                new CashFlowDates(500, new DateTime(2017, 7, 1)),
                new CashFlowDates(507.5, new DateTime(2018, 1, 1))
            };
            var xirr = CalculationWrapper.XIRR(cashFlows, 6);

```

You can find a detailed explanation of the algorithm and implementation [here](https://www.klearlending.com).
