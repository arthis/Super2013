using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonDomain
{

   

    public interface IMessage
    {
        Guid Id { get; }
        Guid CommitId { get; }
        DateTime? WakeTime { get; set; }

        string ToDescription();
    }
}
