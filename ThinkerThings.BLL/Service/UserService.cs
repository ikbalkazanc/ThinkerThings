using System.Threading.Tasks;
using ThinkerThings.BLL.Common;
using ThinkerThings.Core.Entities;
using ThinkerThings.Core.Repositories.Common;
using ThinkerThings.Core.Services;
using ThinkerThings.Core.UnitOfWork;

namespace ThinkerThings.BLL.Service
{
    public class UserService : Service<User>, IUserService
    {
        public UserService(IUnitOfWork unitofwork, IRepository<User> repository) : base(unitofwork, repository)
        {
        }

        public async Task<User> GetUserWithMail(string mail)
        {
            return await _repository.SingleWhere(x => x.Mail == mail);
        }
    }
}
