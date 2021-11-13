using Microsoft.EntityFrameworkCore;
using MTC_Route_Tracker.Bogus;
using MTC_Route_Tracker.Mtc.Data;
using MTC_Route_Tracker.Mtc.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MTC_Route_Tracker.Mtc.Business.Seeder
{
    public class BusSeed : BaseDataSeeder
    {
        public override string SeedType => SeedDataType.System;
        public override int Order => 1;
        private readonly MtcDbContext _mtcDbContext;
        public BusSeed(MtcDbContext mtcDbContext)
        {
            _mtcDbContext = mtcDbContext;
        }
        public override async Task SeedAsync()
        {
            var buslist = BusRouteBogusData.GetBusInfo();
            var buscount = _mtcDbContext.BusRoute.ToList().Count;
            if(buscount < 7 )
            {
                foreach (var fakebusdata in buslist)
                {
                    var bus = new BusRouteEntity
                    {
                        Id = fakebusdata.Id,
                        StartingPoint = fakebusdata.StartingPoint,
                        EndingPoint = fakebusdata.EndingPoint,
                        Via = fakebusdata.Via,
                        FrequencyType = fakebusdata.FrequencyType
                    };
                    _mtcDbContext.BusRoute.Add(bus);
                }
                await _mtcDbContext.SaveChangesAsync();
            }
            await _mtcDbContext.SaveChangesAsync();

        }

    }
    

}
