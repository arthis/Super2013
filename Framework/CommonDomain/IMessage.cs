using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonDomain
{
    public interface IMessage
    {
        Guid CommitId { get; }
        string ToDescription();
    }
}
