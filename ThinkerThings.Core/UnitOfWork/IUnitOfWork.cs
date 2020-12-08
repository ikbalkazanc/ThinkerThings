using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ThinkerThings.Core.Repositories;
using ThinkerThings.Core.Repositories.Device;

namespace ThinkerThings.Core.UnitOfWork
{
    public interface IUnitOfWork
    {
        IUserRepository Users { get; set; }
        IGatewayRepository Gateways { get; set; }
        IMotionDateRepository MotionDates { get; set; }

        //Devices
        IAirConditionerRepository AirConditioners { get; set; }
        ISmartLampRepository SmartLambs { get; set; }
        IMotionSensorRepository MotionSensors { get; set; }

        Task CommitAsync();
        void Commit();
    }
}
