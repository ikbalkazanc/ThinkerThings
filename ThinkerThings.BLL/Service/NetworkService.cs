using ThinkerThings.BLL.Common;
using ThinkerThings.Core.Entities;
using ThinkerThings.Core.Repositories.Common;
using ThinkerThings.Core.Services;
using ThinkerThings.Core.UnitOfWork;

namespace ThinkerThings.BLL.Service
{
    public class NetworkService : Service<Network>, INetworkService
    {
        public NetworkService(IUnitOfWork unitofwork, IRepository<Network> repository) : base(unitofwork, repository)
        {
        }
    }
}
