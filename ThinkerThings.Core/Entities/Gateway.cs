using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using ThinkerThings.Core.Common;

namespace ThinkerThings.Core.Entities
{
    public class Gateway : AuditableBaseEntity
    {
        public bool isAlive { get; set; }

        
        public int NetworkId { get; set; }
        public Network Network { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public  User User { get; set; }
    }
}
