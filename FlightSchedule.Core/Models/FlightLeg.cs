using System;
using System.Collections.Generic;
using System.Text;

namespace FlightSchedule.Core.Models
{
    public class FlightLeg
    {
        public int LegNumber { get; set; }
        public ScheduledDateTime ScheduledDateTimeUTC { get; set; }
        public EstimatedDateTime EstimatedDateTimeUTC { get; set; }
        public ActualStation ActualDepartureStation { get; set; }
        public ActualStation ActualArrivalStation { get; set; }
        public ActualDateTime ActualDateTimeUTC { get; set; }
        public string IrropsType { get; set; }
        public string OpsReason { get; set; }
        public Station ScheduledArrivalStation { get; set; }
        public Station ScheduledDepartureStation { get; set; }
        public List<CodeShare> CodeShares { get; set; }
        public Aircraft Aircraft { get; set; }
        public string IataFlightServiceType { get; set; }
        public bool IsETOPSFlight { get; set; }
        public string FlightRangeCode { get; set; }
        public string OperatingAirlineCode { get; set; }
        public string OperatingAirlineName { get; set; }
        public string SourceInternalId { get; set; }
        public string ScheduledDepartureDateStnLocal { get; set; }
        public string OnwardOperatingAirlineCode { get; set; }
        public string OnwardOperatingFlightNumber { get; set; }
    }
}
