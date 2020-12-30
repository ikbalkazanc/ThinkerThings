using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ThinkerThings.Core.Services.Device;

namespace ThinkerThings.API.Controllers.Devices
{
    [Route("api/[controller]")]
    [ApiController]
    public class DevicesController : ControllerBase
    {
        private readonly ISmartLampService _smartLampService;
        private readonly IAirConditionerService _airConditionerService;
        private readonly IMotionSensorService _motionSensorService;
        private readonly IMapper _mapper;
        public DevicesController(ISmartLampService smartLampService, IMapper mapper, IMotionSensorService motionSensorService, IAirConditionerService airConditionerService)
        {
            _smartLampService = smartLampService;
            _mapper = mapper;
            _airConditionerService = airConditionerService;
            _motionSensorService = motionSensorService;
        }
        [HttpGet("getAllDeviceByUserId/{id}")]
        public async Task<IActionResult> GetAllDevicesByUserId(int id)
        {
            Models.Devices devices = new Models.Devices();
            devices.SmartLamps = await _smartLampService.GetDevicesByUserId(id);
            devices.MotionSensors = await _motionSensorService.GetDevicesByUserId(id);
            devices.AirConditioners = await _airConditionerService.GetDevicesByUserId(id);
            return Ok(devices);
        }

    }
}
