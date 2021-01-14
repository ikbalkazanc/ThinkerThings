using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ThinkerThings.Core.Entities;
using ThinkerThings.Core.Services.Common;

namespace ThinkerThings.Core.Services
{
    public interface IUserService : IService<User>
    {
        Task<User> GetUserWithMail(string mail);
    }
}
