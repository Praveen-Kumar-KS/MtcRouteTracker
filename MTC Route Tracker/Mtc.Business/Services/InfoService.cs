using MTC_Route_Tracker.Mtc.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MTC_Route_Tracker.Mtc.Business.Services
{
    public interface IInfoService
    {
        BusInfoModel SearchFunctionality(BusInfoModel busInfoModel);

    }
    public class InfoService
    {
        public BusInfoModel SearchFunctionality(BusInfoModel busInfoModel)
        {
            return busInfoModel;
        }
    }
}
