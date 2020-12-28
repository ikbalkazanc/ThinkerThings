using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ThinkerThings.Core.DTOs.Devices.MotionSensorDto;
using ThinkerThings.Core.DTOs.Devices.SmartLampDto;
using ThinkerThings.Core.Entities.Devices;
using ThinkerThings.Core.Services.Device;

namespace ThinkerThings.API.Controllers.Devices
{
    [Route("api/[controller]")]
    [ApiController]
    public class MotionSensorsController : ControllerBase
    {
        private readonly IMotionSensorService _motionSensorService;
        private readonly IMapper _mapper;

        public MotionSensorsController(IMotionSensorService motionSensorService, IMapper mapper)
        {
            _motionSensorService = motionSensorService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var device = await _motionSensorService.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<MotionSensorDto>>(device));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] MotionSensorCreateDto device)
        {
            var newDevice = await _motionSensorService.AddAsync(_mapper.Map<MotionSensor>(device));
            return Ok(_mapper.Map<MotionSensorDto>(newDevice));
        }
    }
}
