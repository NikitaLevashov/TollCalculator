using System;

namespace TollCalculator
{
    public class TimeWork
    {
        public static bool IsWeekDay(DateTime timeOfToll) =>
           timeOfToll.DayOfWeek switch
           {
               DayOfWeek.Saturday => false,
               DayOfWeek.Sunday => false,
               _ => true
           };

        public enum TimeBand
        {
            MorningRush,
            Daytime,
            EveningRush,
            Overnight
        }

        public static TimeBand GetTimeBand(DateTime timeOfToll) =>
            timeOfToll.Hour switch
            {
                < 6 or > 19 => TimeBand.Overnight,
                < 10 => TimeBand.MorningRush,
                < 16 => TimeBand.Daytime,
                _ => TimeBand.EveningRush,
            };
    }
}
