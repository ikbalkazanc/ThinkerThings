using System;
using System.Collections.Generic;
using System.Text;
using ThinkerThings.Core.DTOs.Common;

namespace ThinkerThings.Core.DTOs.UserDto
{
    public class UserDto : BaseDTO
    {
        public string Mail { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
