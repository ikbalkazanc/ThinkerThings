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
    public class AirConditionerService : DeviceService<AirConditioner>, IAirConditionerService
    {
        public AirConditionerService(IUnitOfWork unitofwork, IRepository<AirConditioner> repository) : base(unitofwork, repository)
        {
        }
    }
}
