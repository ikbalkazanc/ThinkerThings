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
        IUserRepository Users { get;  }
        IGatewayRepository Gateways { get;  }
        IMotionDateRepository MotionDates { get;  }
        INetworkRepository Networks { get; }

        //Devices
        IAirConditionerRepository AirConditioners { get;  }
        ISmartLampRepository SmartLambs { get;  }
        IMotionSensorRepository MotionSensors { get;  }

        Task CommitAsync();
        void Commit();
    }
}
