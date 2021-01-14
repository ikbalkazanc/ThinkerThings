using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using ThinkerThings.Core.DTOs.UserDto;
using ThinkerThings.Core.Entities;
using ThinkerThings.Core.Services;

namespace ThinkerThings.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UsersController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userService.GetAllAsync();
            return Ok(users);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUserDto user)
        {
            var newUser = await _userService.AddAsync(_mapper.Map<User>(user));
            return Ok(newUser);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _userService.GetByIdAsync(id);
            return Ok(user);
        }
    }
}
