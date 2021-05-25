using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TollCalculator.interfaces;

namespace TollCalculator.Repository
{
    public class PeakTimePremiumRepository : TimeWork, IPeakTime
    {
        // <SnippetFinalTuplePattern>
        public decimal PeakTime(DateTime timeOfToll, bool inbound) =>
            (IsWeekDay(timeOfToll), GetTimeBand(timeOfToll), inbound) switch
            {
                (true, TimeBand.Overnight, _) => 0.75m,
                (true, TimeBand.Daytime, _) => 1.5m,
                (true, TimeBand.MorningRush, true) => 2.0m,
                (true, TimeBand.EveningRush, false) => 2.0m,
                (_, _, _) => 1.0m,
            };
        // </SnippetFinalTuplePattern>

    }
}
