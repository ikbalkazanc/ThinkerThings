using System;
using System.Collections.Generic;
using System.Text;
using ThinkerThings.Core.Contracts;
using ThinkerThings.Core.Entities;

namespace ThinkerThings.Core.Common
{
    public class Device : BaseEntity , IDeleteable
    {
        public Gateway Gateway { get; set; }

        public bool IsDeleted { get; set; }
        public DateTime? DeletedOn { get; set; }
        public string DeleteRemarks { get; set; }
    }
}
