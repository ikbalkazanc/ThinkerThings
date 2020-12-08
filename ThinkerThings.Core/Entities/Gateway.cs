using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using ThinkerThings.Core.Common;
using ThinkerThings.Core.Contracts;

namespace ThinkerThings.Core.Entities
{
    public class Gateway : AuditableBaseEntity , IDeleteable
    {
        public bool isAlive { get; set; }

        
        public int NetworkId { get; set; }
        public Network Network { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public  User User { get; set; }

        public bool IsDeleted { get; set; }
        public DateTime? DeletedOn { get; set; }
        public string DeleteRemarks { get; set; }
    }
}
