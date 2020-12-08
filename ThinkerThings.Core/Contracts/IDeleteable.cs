using System;
using System.Collections.Generic;
using System.Text;

namespace ThinkerThings.Core.Contracts
{
    public interface IDeleteable
    {
        bool IsDeleted { get; set; }
        DateTime? DeletedOn { get; set; }
        string DeleteRemarks { get; set; }
    }
}
