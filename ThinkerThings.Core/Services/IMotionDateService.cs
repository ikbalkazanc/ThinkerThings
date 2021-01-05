using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ThinkerThings.Core.Entities;
using ThinkerThings.Core.Services.Common;

namespace ThinkerThings.Core.Services
{
    public interface IMotionDateService : IService<MotionDate>
    {
        Task<IEnumerable<MotionDate>> GetSensorDatesByUserId(int id);
    }
}
