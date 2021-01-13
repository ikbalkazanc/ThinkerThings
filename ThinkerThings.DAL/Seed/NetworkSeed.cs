using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using ThinkerThings.Core.Entities;

namespace ThinkerThings.DAL.Seed
{
    public class NetworkSeed : IEntityTypeConfiguration<Network>
    {

        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Network> builder)
        {
            builder.HasData(
                new Network { Id = 1,SSID="Network",Password="123" }
                );
        }
    }
}
