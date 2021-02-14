using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApiKurssi
{
    public class FMIAsema
    {
        public int stationId { get; set; }
        public long latestObservationTime { get; set; }
        public DateTime LatestObservationTime {
            get
            {
                return DateTimeOffset.FromUnixTimeMilliseconds(latestObservationTime).DateTime;
            }
        }
        public IEnumerable<long[]> t2m { get; set; }

        public double LatestTemp {
            get
            {
                return (double)(from t in t2m where t[0] == latestObservationTime select t[1]).First();
            }
        }
    }
}
