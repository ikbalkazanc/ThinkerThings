using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThinkerThings.Core.Entities;

namespace ThinkerThings.DAL.Configuration
{
    public class NetworkConfiguration : IEntityTypeConfiguration<Network>
    {
        public void Configure(EntityTypeBuilder<Network> builder)
        {
            throw new NotImplementedException();
        }
    }
}
