using System;
using System.Collections.Generic;
using System.Text;

namespace FlightSchedule.Core.Models
{
    public class EstimatedDateTime : ScheduledDateTime
    {
        public List<DelayInformation> DelayInformation { get; set; }
    }
}
