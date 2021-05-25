using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TollCalculator.interfaces
{
    public interface IPeakTime
    {
        public decimal PeakTime(DateTime timeOfToll, bool inbound);
    }
}
