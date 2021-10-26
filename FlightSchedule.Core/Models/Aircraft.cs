using System;
using System.Collections.Generic;
using System.Text;

namespace FlightSchedule.Core.Models
{
    public class Aircraft
    {
        public string AircraftRegistration { get; set; }
        public string FleetType { get; set; }
        public string FleetSeries { get; set; }
        public string IataAircraftCode { get; set; }
        public string OagFleetCode { get; set; }
        public string Manufacturer { get; set; }
        public string ReservationSystemEquipmentTypeCode { get; set; }
    }
}
