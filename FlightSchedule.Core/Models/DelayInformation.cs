using System;
using System.Collections.Generic;
using System.Text;

namespace FlightSchedule.Core.Models
{
    public class DelayInformation
    {
        public string Code { get; set; }
        public string Order { get; set; }
        public string Minutes { get; set; }
        public string Description { get; set; }
        public string Reason { get; set; }
        public List<SubDelayInformation> SubDelayInformationList { get; set; }
    }
}
