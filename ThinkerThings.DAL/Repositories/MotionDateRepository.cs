using System;
using System.Collections.Generic;
using System.Text;
using ThinkerThings.Core.Entities;
using ThinkerThings.Core.Repositories;
using ThinkerThings.DAL.Repositories.Common;

namespace ThinkerThings.DAL.Repositories
{
    public class MotionDateRepository : Repository<MotionDate> , IMotionDateRepository
    {
        private AppDbContext appDbContext { get => _context as AppDbContext; }
        public MotionDateRepository(AppDbContext context) : base(context)
        {
        }
    }
}
