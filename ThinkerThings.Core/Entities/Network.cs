using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using ThinkerThings.Core.Common;

namespace ThinkerThings.Core.Entities
{
    public class Network : BaseEntity
    {
        public string SSID { get; set; }
        public string Password { get; set; }

        public Gateway Gateway { get; set; }

    }
}
