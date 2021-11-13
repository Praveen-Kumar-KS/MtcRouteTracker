using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MTC_Route_Tracker.Mtc.Business.Seeder
{
    public interface IDataSeeder
    {
        Task SeedAsync();
        string SeedType { get; }
        int Order { get; }
    }
    public abstract class BaseDataSeeder : IDataSeeder
    {
        public abstract string SeedType { get; }
        public abstract int Order { get; }
        public abstract Task SeedAsync();
    }
}
