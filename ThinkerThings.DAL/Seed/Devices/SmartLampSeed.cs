using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using ThinkerThings.Core.Entities.Devices;

namespace ThinkerThings.DAL.Seed.Devices
{
    public class SmartLampSeed : IEntityTypeConfiguration<SmartLamp>
    {
        private int[] _ids;
        public SmartLampSeed(int[] ids)
        {
            _ids = ids;
        }
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<SmartLamp> builder)
        {
            builder.HasData(
                new SmartLamp { Id = 1, UserId = _ids[0], isOpen=false }
                );
        }
    }
}