using System;
using System.Collections.Generic;
using System.Text;
using ThinkerThings.BLL.Common;
using ThinkerThings.Core.Entities.Devices;
using ThinkerThings.Core.Repositories.Common;
using ThinkerThings.Core.Services.Device;
using ThinkerThings.Core.UnitOfWork;

namespace ThinkerThings.BLL.Service.Devices
{
    public class MotionSensorService : DeviceService<MotionSensor> , IMotionSensorService
    {
        public MotionSensorService(IUnitOfWork unitofwork, IRepository<MotionSensor> repository) : base(unitofwork, repository)
        {
        }
    }
}
