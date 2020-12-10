using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThinkerThings.Core.Entities;
using ThinkerThings.Core.Entities.Devices;

namespace ThinkerThings.DAL.Configuration.Devices
{
    public class AirConditionerConfiguration : IEntityTypeConfiguration<AirConditioner>
    {
        public void Configure(EntityTypeBuilder<AirConditioner> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("AirConditioners");
        }
    }
}
