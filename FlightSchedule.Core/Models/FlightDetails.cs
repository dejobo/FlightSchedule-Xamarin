using System;
using System.Collections.Generic;
using System.Text;

namespace FlightSchedule.Core.Models
{
    public class FlightDetails
    {
        public string SourceSystemName { get; set; }
        public DateTime SourceSystemLastModifiedDateTimeUtc { get; set; }
        public string SchemaVersion { get; set; }
        public string LastEventType { get; set; }
        public string OperatingFlightNumber { get; set; }
        public DateTime ScheduledFlightOriginationDateUTC { get; set; }
        public DateTime ScheduledFlightOriginationDateLocal { get; set; }
        public List<FlightLeg> FlightLegs { get; set; }
    }
}
