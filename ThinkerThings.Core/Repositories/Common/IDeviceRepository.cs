using System;
using System.Collections.Generic;
using System.Text;

namespace ThinkerThings.Core.Repositories.Common
{
    public interface IDeviceRepository<TDevice> : IRepository<TDevice> where TDevice : class
    {

    }
}
