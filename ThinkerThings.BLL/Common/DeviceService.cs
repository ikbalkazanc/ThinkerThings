using System;
using System.Collections.Generic;
using System.Text;
using ThinkerThings.Core.Repositories.Common;
using ThinkerThings.Core.UnitOfWork;

namespace ThinkerThings.BLL.Common
{
    public class DeviceService<TDevice> : Service<TDevice> where TDevice : class
    {
        public DeviceService(IUnitOfWork unitofwork, IRepository<TDevice> repository) : base(unitofwork, repository)
        {
        }
    }
}
 