using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace MTC_Route_Tracker.Mtc.Data.Enums
{
    public enum FrequencyTypeEnum : int
    {
        [Description("High Frequency")]
        HighFrequency = 0,
        [Description("Low Frequency")]
        LowFrequency = 1,
        [Description("Night Service")]
        NightService = 2,
        [Description("No Frequency")]
        NoFrequency = 3
    }
}
