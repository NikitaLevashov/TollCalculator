using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TollCalculator.interfaces;

namespace TollCalculator.Repository
{
    public class RepositoryPeakTimePremiumIfElseRepository : IPeakTime 
    {
        // <SnippetPremiumWithoutPattern>
        public decimal PeakTime(DateTime timeOfToll, bool inbound)
        {
            if ((timeOfToll.DayOfWeek == DayOfWeek.Saturday) ||
                (timeOfToll.DayOfWeek == DayOfWeek.Sunday))
            {
                return 1.0m;
            }
            else
            {
                int hour = timeOfToll.Hour;
                if (hour < 6)
                {
                    return 0.75m;
                }
                else if (hour < 10)
                {
                    if (inbound)
                    {
                        return 2.0m;
                    }
                    else
                    {
                        return 1.0m;
                    }
                }
                else if (hour < 16)
                {
                    return 1.5m;
                }
                else if (hour < 20)
                {
                    if (inbound)
                    {
                        return 1.0m;
                    }
                    else
                    {
                        return 2.0m;
                    }
                }
                else // Overnight
                {
                    return 0.75m;
                }
            }
        }
        // </SnippetPremiumWithoutPattern>
    }
}
