using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace MTC_Route_Tracker.Mtc.Data.Enums
{
    public enum SearchTypeEnum : int
    {
        [Description("Bus Search")]
        HighFrequency = 0,
        [Description("Route Search")]
        LowFrequency = 1,
    }
}
