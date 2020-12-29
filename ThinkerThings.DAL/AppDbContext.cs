using System;
using Microsoft.EntityFrameworkCore;
using ThinkerThings.Core.Entities;
using ThinkerThings.Core.Entities.Devices;
using ThinkerThings.DAL.Configuration;
using ThinkerThings.DAL.Configuration.Devices;
using ThinkerThings.DAL.Seed;
using ThinkerThings.DAL.Seed.Devices;

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

            modelBuilder.ApplyConfiguration(new AirConditionerConfiguration());
            modelBuilder.ApplyConfiguration(new MotionSensorConfiguration());
            modelBuilder.ApplyConfiguration(new SmartLampConfiguration());

            modelBuilder.ApplyConfiguration(new UserSeed(new int[] { 1 }));
            modelBuilder.ApplyConfiguration(new NetworkSeed());
            modelBuilder.ApplyConfiguration(new MotionDateSeed(new int[] { 1 }));
            modelBuilder.ApplyConfiguration(new AirConditionerSeed(new int[] { 1 }));
            modelBuilder.ApplyConfiguration(new MotionSensorSeed(new int[] { 1 }));
            modelBuilder.ApplyConfiguration(new SmartLampSeed(new int[] { 1 }));

        }
    }
}
