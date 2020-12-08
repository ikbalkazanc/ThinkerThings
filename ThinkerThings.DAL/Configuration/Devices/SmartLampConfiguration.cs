using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThinkerThings.Core.Entities;
using ThinkerThings.Core.Entities.Devices;

namespace ThinkerThings.DAL.Configuration.Devices
{
    public class SmartLampConfiguration : IEntityTypeConfiguration<SmartLamp>
    {
        public void Configure(EntityTypeBuilder<SmartLamp> builder)
        {
            throw new NotImplementedException();
        }
    }
}
