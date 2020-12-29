using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using ThinkerThings.Core.Entities.Devices;

namespace ThinkerThings.DAL.Seed.Devices
{
    public class AirConditionerSeed : IEntityTypeConfiguration<AirConditioner>
    {
        private int[] _ids;
        public AirConditionerSeed(int[] ids)
        {
            _ids = ids;
        }
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<AirConditioner> builder)
        {
            builder.HasData(
                new AirConditioner { Id = 1,UserId= _ids[0], FanSpeed=0,Tempature=0,isOpen=false}
                );
        }
    }
}