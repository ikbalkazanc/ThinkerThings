using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ThinkerThings.Core.Repositories;
using ThinkerThings.Core.Repositories.Device;
using ThinkerThings.Core.UnitOfWork;
using ThinkerThings.DAL.Repositories;
using ThinkerThings.DAL.Repositories.Common;
using ThinkerThings.DAL.Repositories.Devices;

namespace ThinkerThings.DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private NetworkRepository _networkRepository;
        private UserRepository _userRepository;
        private MotionDateRepository _motionDateRepository;

        private AirConditionerRepository _airConditionerRepository;
        private MotionSensorRepository _motionSensorRepository;
        private SmartLampRepository _smartLambRepository;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public INetworkRepository Networks => (_networkRepository = _networkRepository ?? new NetworkRepository(_context));
        public IUserRepository Users => (_userRepository = _userRepository ?? new UserRepository(_context));
        public IMotionDateRepository MotionDates => (_motionDateRepository = _motionDateRepository ?? new MotionDateRepository(_context));
        public IAirConditionerRepository AirConditioners => (_airConditionerRepository = _airConditionerRepository ?? new AirConditionerRepository(_context));
        public IMotionSensorRepository MotionSensors => (_motionSensorRepository = _motionSensorRepository ?? new MotionSensorRepository(_context));
        public ISmartLampRepository SmartLambs => (_smartLambRepository = _smartLambRepository ?? new SmartLampRepository(_context));

        
        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
