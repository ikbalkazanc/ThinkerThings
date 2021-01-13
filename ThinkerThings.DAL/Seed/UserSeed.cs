using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using ThinkerThings.Core.Entities;

namespace ThinkerThings.DAL.Seed
{
    public class UserSeed : IEntityTypeConfiguration<User>
    {
        private int[] _ids;
        public UserSeed(int[] ids)
        {
            _ids = ids;
        }
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<User> builder)
        {
            builder.HasData(
                new User { Id = 1, Name = "ikbal",Surname = "Kazancı",Password="123",NetworkId=_ids[0],Mail="ikbalkazanc" }
                );
        } 
    }
}
