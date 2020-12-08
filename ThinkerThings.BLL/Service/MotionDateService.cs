using System;
using System.Collections.Generic;
using System.Text;
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
    }
}
