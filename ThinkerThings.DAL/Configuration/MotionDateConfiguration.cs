using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThinkerThings.Core.Entities;

namespace ThinkerThings.DAL.Configuration
{
    public class MotionDateConfiguration : IEntityTypeConfiguration<MotionDate>
    {
        public void Configure(EntityTypeBuilder<MotionDate> builder)
        {
            throw new NotImplementedException();
        }
    }
}
