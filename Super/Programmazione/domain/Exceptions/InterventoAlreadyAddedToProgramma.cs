using System;
using System.Runtime.Serialization;

namespace Super.Programmazione.Domain.Exceptions
{
    public class InterventoAlreadyAddedToProgramma : Exception
    {
        public InterventoAlreadyAddedToProgramma()
        {
        }

        public InterventoAlreadyAddedToProgramma(string message)
            : base(message)
        {
        }

        public InterventoAlreadyAddedToProgramma(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public InterventoAlreadyAddedToProgramma(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public bool Equals(InterventoAlreadyAddedToProgramma other)
        {
            return !ReferenceEquals(null, other);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof(InterventoAlreadyAddedToProgramma)) return false;
            return Equals((InterventoAlreadyAddedToProgramma)obj);
        }

        public override int GetHashCode()
        {
            return 0;
        }
    }
}