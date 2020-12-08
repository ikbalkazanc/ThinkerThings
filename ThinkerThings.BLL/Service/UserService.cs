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
    public class UserService : Service<User> , IUserService
    {
        public UserService(IUnitOfWork unitofwork, IRepository<User> repository) : base(unitofwork, repository)
        {
        }
    }
}
