using System;
using System.Collections.Generic;
using System.Text;

namespace FlightSchedule.Core.Models
{
    public class Flight
    {
        public string FlightLookupKey { get; set; }
        public int UpdateCount { get; set; }
        public FlightDetails FlightDetails { get; set; }
    }
}
