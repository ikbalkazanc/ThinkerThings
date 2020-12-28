using System;
using System.Collections.Generic;
using System.Text;
using ThinkerThings.Core.Contracts;
using ThinkerThings.Core.Entities;

namespace ThinkerThings.Core.Common
{
    public class Device : BaseEntity
    {
        public int UserId { get; set; }
        public User Gateway { get; set; }

    }
}
