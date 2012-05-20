using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonDomain.Core
{
    public class Message : IMessage
    {
        public Guid AggregateId { get; set; }
        public Guid CommitId { get; set; }
        public IEvent PayLoad { get; set; }

    }
}
