using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using ThinkerThings.Core.Common;

namespace ThinkerThings.Core.Entities
{
    public class Network : AuditableBaseEntity
    {
        public string SSID { get; set; }
        public string Passsword { get; set; }

        [ForeignKey("Gateway")]
        public int gatewayId { get; set; }
        public Gateway Gateway { get; set; }

    }
}
