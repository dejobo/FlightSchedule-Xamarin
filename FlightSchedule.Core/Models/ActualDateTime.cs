using System;
using System.Collections.Generic;
using System.Text;

namespace FlightSchedule.Core.Models
{
    public class ActualDateTime
    {
        public DateTime? Out { get; set; }
        public DateTime? In { get; set; }
        public DateTime? On { get; set; }
        public DateTime? Off { get; set; }
    }
}
