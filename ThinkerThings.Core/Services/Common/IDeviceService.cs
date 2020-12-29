using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ThinkerThings.Core.Services.Common
{
    public interface IDeviceService<TDevice> where TDevice : class
    {
        Task<IEnumerable<TDevice>> GetDevicesByUserId(int id);
    }
}
