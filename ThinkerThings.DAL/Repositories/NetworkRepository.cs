using System;
using System.Collections.Generic;
using System.Text;
using ThinkerThings.Core.Entities;
using ThinkerThings.Core.Repositories;
using ThinkerThings.DAL.Repositories.Common;

namespace ThinkerThings.DAL.Repositories
{
    public class NetworkRepository : Repository<Network> , INetworkRepository
    {
        private AppDbContext appDbContext { get => _context as AppDbContext; }
        public NetworkRepository(AppDbContext context) : base(context)
        {
        }
    }
}
