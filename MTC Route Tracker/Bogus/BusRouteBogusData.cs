using MTC_Route_Tracker.Mtc.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MTC_Route_Tracker.Bogus;
using Bogus;
using MTC_Route_Tracker.Mtc.Data.Enums;

namespace MTC_Route_Tracker.Bogus
{
    public class BusRouteBogusData
    {
        public static Faker<BusRouteEntity> Bus { get; } =
            new Faker<BusRouteEntity>()
            .RuleFor(x => x.Id, f => f.Random.Number(1, 10000))
            .RuleFor(x => x.StartingPoint, f => f.Random.ArrayElement<string>(Origin().ToArray()))
            .RuleFor(x => x.EndingPoint, f => f.Random.ArrayElement<string>(Destination().ToArray()))
            .RuleFor(x => x.Via, f => f.Random.ArrayElement<string>(Via().ToArray()))
            .RuleFor(x => x.FrequencyType, f => f.PickRandom(FrequencyTypeEnum.HighFrequency, FrequencyTypeEnum.LowFrequency, FrequencyTypeEnum.NightService, FrequencyTypeEnum.NoFrequency))
            ;

        public static List<string> Origin()
        {
            return new List<string> 
            { "Thiruvottiyur","Thiruvottiyur", "Tollgate", "Ekkaduthangal","Broadway","Red Hills","Red Hills"

            };
        }
        public static List<string> Destination()
        {
            return new List<string>
            { "Thiruvanmiyur", "Poonamallee", "Saidapet West", "Broadway", "T.Nagar", "Vandalur Zoo", "Koyambedu Market"
            };
        }
        public static List<string> Via() 
        {
            return new List<string>
            {
                "Adyar, Mylapore, Royapettah, Parry's Corner, Kalmandapam, Tollgate, Rajakadai, Theradi",
                "Tollgate, Central, KMC, Mathuravoyal, Karayanchavadi",
                "Kal mandapam, Parrys, Central R.S, Egmore R.S, Maternity Hospital, DPI, Sterling road, Valluvar Kottam, Panagal park, T.Nagar, Srinivasa Theater, Mettupalayam",
                "Central R.S, Egmore R.S, Maternity Hospital, DPI, Sterling road, Valluvar Kottam, Panagal park, T.Nagar, Srinivasa Theater, Mettupalayam, Ashok Nagar, Jaffarkhanpet",
                "Panagal park, Vani mahal, Thousand Lights, TVS, Central R.S",
                "Tambaram, Pallavaram, Guindy, Ashok nagar, Vadapalani, CMBT, Thirumangalam, Anna nagar west, Padi, Thathankuppam, Kolathur, Retteri, Puzhal, Kavangarai, Ayurveda Ashramam",
                "Puzhal, Nethaji Circle(byepass), Retteri, Thirumangalam"
            };
        }
        public static List<BusRouteEntity> GetBusInfo()
        {
            return Bus.Generate(10000);
        }

    }
}
