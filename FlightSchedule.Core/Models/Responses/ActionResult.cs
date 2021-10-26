using System.Collections.Generic;
using System.Text;

namespace FlightSchedule.Core.Models.Responses
{
    public class ActionResult
    {
        public int Code { get; set; }
        public string[] Messages { get; set; }
    }
}
