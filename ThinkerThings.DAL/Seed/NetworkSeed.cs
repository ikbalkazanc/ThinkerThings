using Microsoft.EntityFrameworkCore;
using ThinkerThings.Core.Entities;

namespace ThinkerThings.DAL.Seed
{
    public class NetworkSeed : IEntityTypeConfiguration<Network>
    {

        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Network> builder)
        {
            builder.HasData(
                new Network { Id = 1, SSID = "Network", Password = "123" }
                );
        }
    }
}
