using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ThinkerThings.Core.DTOs.Devices.AirConditionerDto;
using ThinkerThings.Core.DTOs.GatewayDto;
using ThinkerThings.Core.DTOs.NetworkDto;
using ThinkerThings.Core.Entities;
using ThinkerThings.Core.Entities.Devices;
using ThinkerThings.Core.Services;
using ThinkerThings.Core.Services.Device;

namespace ThinkerThings.API.Controllers.Devices
{
    [Route("api/[controller]")]
    [ApiController]
    public class AirConditionersController : ControllerBase
    {
        private readonly IAirConditionerService _airConditionerService;
        private readonly IMapper _mapper;

        public AirConditionersController(IAirConditionerService gatewayService, IMapper mapper)
        {
            _airConditionerService = gatewayService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var device = await _airConditionerService.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<AirConditionerCreateDto>>(device));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AirConditionerCreateDto device)
        {
            var newDevice = await _airConditionerService.AddAsync(_mapper.Map<AirConditioner>(device));
            return Ok(_mapper.Map<AirConditionerCreateDto>(newDevice));
        }
    }
}
