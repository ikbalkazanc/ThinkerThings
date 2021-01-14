using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThinkerThings.Core.DTOs.UserDto;
using ThinkerThings.Core.Services;

namespace ThinkerThings.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public AuthController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            if (loginDto == null) return NotFound();
            var user = await _userService.GetUserWithMail(loginDto.Mail);
            if (user == null) return NotFound();
            if (loginDto.Password == user.Password)
            {
                return Ok(_mapper.Map<UserDto>(user));
            }
            return NotFound();
        }
    }
}
