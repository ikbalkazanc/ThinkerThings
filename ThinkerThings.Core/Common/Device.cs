using System;
using System.Collections.Generic;
using System.Text;
using ThinkerThings.Core.Entities;

namespace ThinkerThings.Core.Common
{
    public class Device : BaseEntity
    {
        public Gateway Gateway { get; set; }
    }
}
