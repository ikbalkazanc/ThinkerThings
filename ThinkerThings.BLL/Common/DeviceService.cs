using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ThinkerThings.Core.Common;
using ThinkerThings.Core.Repositories.Common;
using ThinkerThings.Core.Services.Common;
using ThinkerThings.Core.UnitOfWork;

namespace ThinkerThings.BLL.Common
{
    public class DeviceService<TDevice> : Service<TDevice>, IDeviceService<TDevice> where TDevice : Device
    {
        public DeviceService(IUnitOfWork unitofwork, IRepository<TDevice> repository) : base(unitofwork, repository)
        {
        }
        public async Task<IEnumerable<TDevice>> GetDevicesByUserId(int id)
        {
            var devices = await _repository.Where(x => x.UserId == id);
            return devices;
        }
    }
}
