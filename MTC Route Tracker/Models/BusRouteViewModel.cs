using MTC_Route_Tracker.Mtc.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MTC_Route_Tracker.Models
{
    public class BusRouteViewModel
    {
        public int Id { get; set; }
        public string BusNumber { get; set; }
        public string StartingPoint { get; set; }
        public string EndingPoint { get; set; }
        public string Via { get; set; }
        public FrequencyTypeEnum FrequencyType { get; set; }
    }
}
