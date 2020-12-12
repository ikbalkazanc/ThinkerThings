using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ThinkerThings.BLL.Common;
using ThinkerThings.Core.Entities;
using ThinkerThings.Core.Repositories.Common;
using ThinkerThings.Core.Services;
using ThinkerThings.Core.UnitOfWork;

namespace ThinkerThings.BLL.Service
{
    public class MotionDateService : Service<MotionDate>,IMotionDateService
    {
        public MotionDateService(IUnitOfWork unitofwork, IRepository<MotionDate> repository) : base(unitofwork, repository)
        {
        }

        public override Task<MotionDate> AddAsync(MotionDate entity)
        {
            entity.Date = DateTime.Now;
            return base.AddAsync(entity);
        }
    }
}
