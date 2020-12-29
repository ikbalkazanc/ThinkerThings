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
    public class SmartLampService : DeviceService<SmartLamp>, ISmartLampService
    {
        public SmartLampService(IUnitOfWork unitofwork, IRepository<SmartLamp> repository) : base(unitofwork, repository)
        {
        }
    }
}
