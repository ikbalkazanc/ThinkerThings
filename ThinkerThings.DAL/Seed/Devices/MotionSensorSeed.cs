using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using ThinkerThings.Core.Entities.Devices;

namespace ThinkerThings.DAL.Seed.Devices
{
    public class MotionSensorSeed : IEntityTypeConfiguration<MotionSensor>
    {
        private int[] _ids;
        public MotionSensorSeed(int[] ids)
        {
            _ids = ids;
        }
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<MotionSensor> builder)
        {
            builder.HasData(
                new MotionSensor { Id = 1, UserId = _ids[0], isAnyMotion=false}
                );
        }
    }
}