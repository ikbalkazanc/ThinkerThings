using System;
using Microsoft.EntityFrameworkCore;
using ThinkerThings.Core.Entities;
using ThinkerThings.Core.Entities.Devices;
using ThinkerThings.DAL.Configuration;
using ThinkerThings.DAL.Configuration.Devices;

namespace ThinkerThings.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new NetworkConfiguration());
            modelBuilder.ApplyConfiguration(new MotionDateConfiguration());
            modelBuilder.ApplyConfiguration(new GatewayConfiguration());

            modelBuilder.ApplyConfiguration(new AirConditionerConfifuration());
            modelBuilder.ApplyConfiguration(new MotionSensorConfiguration());
            modelBuilder.ApplyConfiguration(new SmartLampConfiguration());

        }
    }
}
