using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TollCalculator.interfaces;

namespace TollCalculator.Repository
{
    public class PeakTimePremiumFullRepository : TimeWork, IPeakTime
    {
        public decimal PeakTime(DateTime timeOfToll, bool inbound) =>
           (IsWeekDay(timeOfToll), GetTimeBand(timeOfToll), inbound) switch
           {
               (true, TimeBand.MorningRush, true) => 2.00m,
               (true, TimeBand.MorningRush, false) => 1.00m,
               (true, TimeBand.Daytime, true) => 1.50m,
               (true, TimeBand.Daytime, false) => 1.50m,
               (true, TimeBand.EveningRush, true) => 1.00m,
               (true, TimeBand.EveningRush, false) => 2.00m,
               (true, TimeBand.Overnight, true) => 0.75m,
               (true, TimeBand.Overnight, false) => 0.75m,
               (false, TimeBand.MorningRush, true) => 1.00m,
               (false, TimeBand.MorningRush, false) => 1.00m,
               (false, TimeBand.Daytime, true) => 1.00m,
               (false, TimeBand.Daytime, false) => 1.00m,
               (false, TimeBand.EveningRush, true) => 1.00m,
               (false, TimeBand.EveningRush, false) => 1.00m,
               (false, TimeBand.Overnight, true) => 1.00m,
               (false, TimeBand.Overnight, false) => 1.00m,
           };

    }
}
