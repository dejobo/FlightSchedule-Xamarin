using System;
using System.Collections.Generic;
using System.Text;

namespace FlightSchedule.Core.Models
{
    public class ActualStation : Station
    {
        public int ZuluOffset { get; set; }
        public Gate Gate { get; set; }
        public string CountryCode2Letters { get; set; }
        public string CountryCode3Letters { get; set; }
    }
}
