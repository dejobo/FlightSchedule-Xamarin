using System.Collections.Generic;
using System.Text;

namespace FlightSchedule.Core.Models.Responses
{
    public class FlightsResponse
    {
        public List<Flight> Flights { get; set; }
        public ActionResult ActionResult { get; set; }
    }
}
