using System;
using System.Collections.Generic;
using System.Text;
using ThinkerThings.Core.Entities;
using ThinkerThings.DAL.Repositories.Common;

namespace ThinkerThings.DAL.Repositories
{
    public class UserRepository : Repository<User>
    {
        private AppDbContext appDbContext { get => _context as AppDbContext; }
        public UserRepository(AppDbContext context) : base(context)
        {
        }
    }
}
