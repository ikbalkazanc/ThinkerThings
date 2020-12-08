using System;
using System.Collections.Generic;
using System.Text;
using ThinkerThings.Core.Repositories.Common;

namespace ThinkerThings.DAL.Repositories.Common
{
    public class DeviceRepository<TDevice> : Repository<TDevice>, IDeviceRepository<TDevice> where TDevice : class
    {
        private AppDbContext appDbContext { get => _context as AppDbContext; }
        public DeviceRepository(AppDbContext context) : base(context)
        {
        }
    }
}
