using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using MTC_Route_Tracker.Mtc.Data.Entities;
using MTC_Route_Tracker.Mtc.Data.Helper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MTC_Route_Tracker.Mtc.Data
{
    public class MtcDbContext : DbContext
    {
        public MtcDbContext(DbContextOptions options)
            : base(options) { }

        public DbSet<BusRouteEntity> BusRoute { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);



            builder.Entity<BusRouteEntity>().ToTable("BusRoute");
        }
        private void BeforeCommit()
        {
            try
            {
                var userName = "Admin";
                try
                {
                    if (HttpContextHelper.Current != null)
                        if (HttpContextHelper.Current.User.Claims.Count() > 0)
                        {
                            userName = HttpContextHelper.Current.User.FindFirst(ClaimTypes.Name).Value;
                        }
                }
                catch (Exception ex)
                {
                    userName = "Admin";
                }
                foreach (var dbEntityEntry in ChangeTracker.Entries())
                {
                    if (dbEntityEntry.Entity.GetType().GetProperty("CreatedOnUtc") != null && dbEntityEntry.Entity.GetType().GetProperty("UpdatedOnUtc") != null
                        && dbEntityEntry.Entity.GetType().GetProperty("CreatedBy") != null && dbEntityEntry.Entity.GetType().GetProperty("UpdatedBy") != null)
                    {
                        if (dbEntityEntry.State == EntityState.Added)
                        {
                            dbEntityEntry.CurrentValues["CreatedOnUtc"] = DateTime.UtcNow;
                            dbEntityEntry.CurrentValues["UpdatedOnUtc"] = DateTime.UtcNow;
                            dbEntityEntry.CurrentValues["CreatedBy"] = userName;
                            dbEntityEntry.CurrentValues["UpdatedBy"] = userName;
                        }
                        else if (dbEntityEntry.State == EntityState.Modified)
                        {
                            dbEntityEntry.CurrentValues["UpdatedOnUtc"] = DateTime.UtcNow;
                            dbEntityEntry.CurrentValues["UpdatedBy"] = userName;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw (ex.InnerException);
            }
            finally
            { }

        }
        public override int SaveChanges()
        {
            int result = 0;
            BeforeCommit();
            try
            {
                result = base.SaveChanges(true);
            }
            catch (Exception ex)
            {

                foreach (var entry in ChangeTracker.Entries())
                {
                    switch (entry.State)
                    {
                        case EntityState.Added:
                            entry.State = EntityState.Detached;
                            break;
                        case EntityState.Modified:
                            entry.CurrentValues.SetValues(entry.OriginalValues);
                            entry.State = EntityState.Unchanged;
                            break;
                        case EntityState.Deleted:
                            entry.State = EntityState.Unchanged;
                            break;
                    }
                }
                throw;
            }
            return result;
        }
    }
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<MtcDbContext>
    {
        public MtcDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables()
                .Build();
            var builder = new DbContextOptionsBuilder<MtcDbContext>();
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            builder.UseSqlServer(connectionString);
            return new MtcDbContext(builder.Options);
        }

    }
}
