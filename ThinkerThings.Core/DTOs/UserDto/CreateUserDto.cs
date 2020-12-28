using System;
using System.Collections.Generic;
using System.Text;
using ThinkerThings.Core.Entities;

namespace ThinkerThings.Core.DTOs.UserDto
{
    public class CreateUserDto
    {
        public string Mail { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }

    }
}
