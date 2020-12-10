using System;
using System.Collections.Generic;
using System.Text;
using ThinkerThings.Core.Common;

namespace ThinkerThings.Core.Entities.Devices
{
    public class SmartLamp : BaseEntity, IDevice 
    {
        public bool isOpen { get; set; }

        public int GatewayId { get; set; }
        public Gateway Gateway { get; set; }

        public bool IsDeleted { get; set; }
        public DateTime? DeletedOn { get; set; }
        public string DeleteRemarks { get; set; }
    }
}
