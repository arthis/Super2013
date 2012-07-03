using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;

namespace CommonDomain.Core
{
    public class Envelope<T> : IEnvelope<T> where T: class, IMessage
    {
        private Guid _messageId;
        private T _payLoad;

        public Guid MessageId
        {
            get { return _messageId; }
        }

        public T PayLoad
        {
            get { return _payLoad; }
        }

        public Envelope(Guid messageId, T payLoad)
        {
            Contract.Requires(messageId!=Guid.Empty);
            Contract.Requires(payLoad!= null);

            _messageId = messageId;
            _payLoad = payLoad;
        }

    }
}
