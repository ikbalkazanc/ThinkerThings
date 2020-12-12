using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ThinkerThings.Core.DTOs.NetworkDto;
using ThinkerThings.Core.DTOs.UserDto;
using ThinkerThings.Core.Entities;
using ThinkerThings.Core.Services;

namespace ThinkerThings.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NetworksController : ControllerBase
    {
        private readonly INetworkService _networkService;
        private readonly IMapper _mapper;

        public NetworksController(INetworkService networkService, IMapper mapper)
        {
            _networkService = networkService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var networks = await _networkService.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<NetworkDto>>(networks));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] NetworkDto network)
        {
            var newNetwork = await _networkService.AddAsync(_mapper.Map<Network>(network));
            return Ok(_mapper.Map<NetworkDto>(newNetwork));
        }
    }
}
