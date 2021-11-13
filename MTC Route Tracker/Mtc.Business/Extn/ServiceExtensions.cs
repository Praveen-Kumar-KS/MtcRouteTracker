using Microsoft.Extensions.DependencyInjection;
using MTC_Route_Tracker.Mtc.Business.Seeder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MTC_Route_Tracker.Mtc.Business.Extn
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddSeed(this IServiceCollection services)
        {
            services.AddScoped<IDemoDataContributor, DemoDataContributor>();
            services.AddScoped<ITestDataContributor, TestDataContributor>();
            services.AddScoped<ISystemDataContributor, SystemDataContributor>();
            services.AddScoped<IDataSeeder, BusSeed>();
            return services;
        }
    }
}
