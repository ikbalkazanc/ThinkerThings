using System;
using System.Collections.Generic;
using System.Text;
using ThinkerThings.Core.Common;
using ThinkerThings.Core.Entities.Devices;
using ThinkerThings.Core.Repositories.Device;
using ThinkerThings.DAL.Repositories.Common;

namespace ThinkerThings.DAL.Repositories.Devices
{
    public class AirConditionerRepository : DeviceRepository<AirConditioner> , IAirConditionerRepository
    {
        private AppDbContext appDbContext { get => _context as AppDbContext; }
        public AirConditionerRepository(AppDbContext context) : base(context)
        {
        }
    }
}
