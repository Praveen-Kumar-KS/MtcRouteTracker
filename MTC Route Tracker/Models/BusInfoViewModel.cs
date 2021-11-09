using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MTC_Route_Tracker.Models
{
    public class BusInfoViewModel
    {
        public int Id { get; set; }
        public bool BusSearch { get; set; }
        public bool RouteSearch { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string BusSearchRoute { get; set; }
        public DateTime ArrivesOn { get; set; }
        public DateTime DropOff { get; set; }
        public int? UserId { get; set; }
        public string CustomerName { get; set; }
        public string Via { get; set; }

    }
}
