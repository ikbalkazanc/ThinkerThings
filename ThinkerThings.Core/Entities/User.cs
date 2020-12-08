using System;
using System.Collections.Generic;
using System.Text;
using ThinkerThings.Core.Common;
using ThinkerThings.Core.Contracts;

namespace ThinkerThings.Core.Entities
{
    public class User : AuditableBaseEntity , IDeleteable
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }
        public ICollection<Gateway> Gateways { get; set; }

        public bool IsDeleted { get; set; }
        public DateTime? DeletedOn { get; set; }
        public string DeleteRemarks { get; set; }
    }
}
