using System;
using System.Collections.Generic;
using System.Text;
using ThinkerThings.Core.Common;

namespace ThinkerThings.Core.Entities
{
    public class User : AuditableBaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }
        public ICollection<Gateway> Gateways { get; set; }

    }
}
