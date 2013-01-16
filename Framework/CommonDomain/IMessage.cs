using System;
using System.Collections.Generic;
using System.Text;

namespace CommonDomain
{

   

    public interface IMessage
    {
        Guid Id { get; set; }
        Guid CommitId { get; set; }

        string ToDescription();
    }
}
