using System;
using System.Collections.Generic;
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

        public async Task Alive(int id)
        {
            var device = await _repository.GetByIdAsync(id);
            device.isAlive = true;
            _repository.Update(device);
        }

        public async Task Dead(int id)
        {
            var device = await _repository.GetByIdAsync(id);
            device.isAlive = false;
            _repository.Update(device);
        }

        public async Task<IEnumerable<TDevice>> GetDevicesByUserId(int id)
        {
            var devices = await _repository.Where(x => x.UserId == id);
            return devices;
        }
    }
}
