using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ThinkerThings.Core.DTOs.Devices.AirConditionerDto;
using ThinkerThings.Core.DTOs.Devices.SmartLampDto;
using ThinkerThings.Core.Entities.Devices;
using ThinkerThings.Core.Services.Device;

namespace ThinkerThings.API.Controllers.Devices
{
    [Route("api/[controller]")]
    [ApiController]
    public class SmartLampsController : ControllerBase
    {
        private readonly ISmartLampService _smartLampService;
        private readonly IMapper _mapper;

        public SmartLampsController(ISmartLampService smartLampService, IMapper mapper)
        {
            _smartLampService = smartLampService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var device = await _smartLampService.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<SmartLampDto>>(device));
        }
        

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SmartLampDto device)
        {
            var newDevice = await _smartLampService.AddAsync(_mapper.Map<SmartLamp>(device));
            return Ok(_mapper.Map<SmartLampDto>(newDevice));
        }
    }
}
