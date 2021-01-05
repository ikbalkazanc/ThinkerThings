using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using ThinkerThings.Core.DTOs.MotionDateDto;
using ThinkerThings.Core.Entities;
using ThinkerThings.Core.Services;

namespace ThinkerThings.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MotionDatesController : ControllerBase
    {
        private readonly IMotionDateService _motionDateService;
        private readonly IMapper _mapper;

        public MotionDatesController(IMotionDateService motionDateService, IMapper mapper)
        {
            _motionDateService = motionDateService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var motions = await _motionDateService.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<MotionDateDto>>(motions));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSensorDatesByUserId(int id)
        {
            var motions = await _motionDateService.GetSensorDatesByUserId(id);
            return Ok(_mapper.Map<IEnumerable<MotionDateDto>>(motions));
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] MotionDateDto motion)
        {
            var newMotion = await _motionDateService.AddAsync(_mapper.Map<MotionDate>(motion));
            return Ok(_mapper.Map<MotionDateDto>(newMotion));
        }
    }
}
