using System;
using System.Collections.Generic;
using System.Text;
using ThinkerThings.Core.Entities;
using ThinkerThings.DAL.Repositories.Common;

namespace ThinkerThings.DAL.Repositories
{
    public class MotionDateRepository : Repository<MotionDate>
    {
        private AppDbContext appDbContext { get => _context as AppDbContext; }
        public MotionDateRepository(AppDbContext context) : base(context)
        {
        }
    }
}
