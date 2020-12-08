using System;
using System.Collections.Generic;
using System.Text;
using ThinkerThings.Core.Entities.Devices;
using ThinkerThings.DAL.Repositories.Common;

namespace ThinkerThings.DAL.Repositories.Devices
{
    public class MotionSensorRepository : DeviceRepository<MotionSensor>
    {
        private AppDbContext appDbContext { get => _context as AppDbContext; }
        public MotionSensorRepository(AppDbContext context) : base(context)
        {
        }
    }
}
