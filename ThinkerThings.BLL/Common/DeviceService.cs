using System;
using System.Collections.Generic;
using System.Text;
using ThinkerThings.Core.Repositories.Common;
using ThinkerThings.Core.UnitOfWork;

namespace ThinkerThings.BLL.Common
{
    public class DeviceService<TEntity> : Service<TEntity> where TEntity : class
    {
        public DeviceService(IUnitOfWork unitofwork, IRepository<TEntity> repository) : base(unitofwork, repository)
        {
        }
    }
}
 