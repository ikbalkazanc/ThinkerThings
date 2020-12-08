using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThinkerThings.Core.Entities;
using ThinkerThings.Core.Entities.Devices;

namespace ThinkerThings.DAL.Configuration.Devices
{
    public class MotionSensorConfiguration : IEntityTypeConfiguration<MotionSensor>
    {
        public void Configure(EntityTypeBuilder<MotionSensor> builder)
        {
            throw new NotImplementedException();
        }
    }
}
