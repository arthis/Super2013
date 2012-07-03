using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonDomain
{
    public interface IEnvelope<TMsg> where TMsg: class, IMessage
    {
        Guid MessageId { get; }

        TMsg PayLoad { get; }
        
    }
}
