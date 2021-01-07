using Microsoft.EntityFrameworkCore;
using System;
using ThinkerThings.Core.Entities;

namespace ThinkerThings.DAL.Seed
{
    public class MotionDateSeed : IEntityTypeConfiguration<MotionDate>
    {
        private int[] _ids;
        public MotionDateSeed(int[] ids)
        {
            _ids = ids;
        }
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<MotionDate> builder)
        {
            builder.HasData(
                new MotionDate { Id = 1, Date = DateTime.Now, MotionSensorId = _ids[0] },
                new MotionDate { Id = 2, Date = DateTime.Now, MotionSensorId = _ids[0] },
                new MotionDate { Id = 3, Date = DateTime.Now, MotionSensorId = _ids[0] }
                );
        }
    }
}
