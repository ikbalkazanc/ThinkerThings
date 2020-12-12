using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ThinkerThings.Core.DTOs.GatewayDto;
using ThinkerThings.Core.DTOs.NetworkDto;
using ThinkerThings.Core.Entities;
using ThinkerThings.Core.Services;

namespace ThinkerThings.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GatewaysController : ControllerBase
    {
        private readonly IGatewayService _gatewayService;
        private readonly IMapper _mapper;

        public GatewaysController(IGatewayService gatewayService, IMapper mapper)
        {
            _gatewayService = gatewayService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var gateways = await _gatewayService.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<GatewayDto>>(gateways));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] GatewayDto gateway)
        {
            var newGateway = await _gatewayService.AddAsync(_mapper.Map<Gateway>(gateway));
            return Ok(_mapper.Map<NetworkDto>(newGateway));
        }
    }
}
