using System;
using System.Collections.Generic;
using System.Text;
using ThinkerThings.Core.Contracts;
using ThinkerThings.Core.Entities;

namespace ThinkerThings.Core.Common
{
    public interface IDevice :  IDeleteable
    {
        public int GatewayId { get; set; }
        public Gateway Gateway { get; set; }

    }
}
