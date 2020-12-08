using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ThinkerThings.DAL.Repositories;
using ThinkerThings.DAL.Repositories.Common;
using ThinkerThings.DAL.Repositories.Devices;

namespace ThinkerThings.DAL.UnitOfWork
{
    public class UnitOfWork
    {
        private readonly AppDbContext _context;
        private GatewayRepository _gatewayRepository;
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
        public GatewayRepository Gateways => (_gatewayRepository = _gatewayRepository ?? new GatewayRepository(_context));
        public NetworkRepository Networks => (_networkRepository = _networkRepository ?? new NetworkRepository(_context));
        public UserRepository Users => (_userRepository = _userRepository ?? new UserRepository(_context));
        public MotionDateRepository MotionDates => (_motionDateRepository = _motionDateRepository ?? new MotionDateRepository(_context));
        public AirConditionerRepository AirConditioners => (_airConditionerRepository = _airConditionerRepository ?? new AirConditionerRepository(_context));
        public MotionSensorRepository MotionSensors => (_motionSensorRepository = _motionSensorRepository ?? new MotionSensorRepository(_context));
        public SmartLampRepository SmartLambs => (_smartLambRepository = _smartLambRepository ?? new SmartLampRepository(_context));


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
