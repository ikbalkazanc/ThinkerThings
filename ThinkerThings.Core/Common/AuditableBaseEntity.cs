using System;
using System.Collections.Generic;
using System.Text;

namespace ThinkerThings.Core.Common
{
    public class AuditableBaseEntity : BaseEntity 
    {
        public string CreatedBy { get; set; }
        public DateTime Created { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModified { get; set; }
    }
}
