using System;
using System.Collections.Generic;
using System.Text;
using ThinkerThings.Core.Entities.Devices;
using ThinkerThings.Core.Repositories.Device;

namespace ThinkerThings.DAL.Repositories.Common
{
    public class SmartLampRepository : DeviceRepository<SmartLamp> , ISmartLampRepository
    {
        private AppDbContext appDbContext { get => _context as AppDbContext; }
        public SmartLampRepository(AppDbContext context) : base(context)
        {
        }
    }
}
