using System;
using System.Runtime.Serialization;

namespace Super.Programmazione.Domain.Exceptions
{
    public class SchedulazioneAlreadyAddedToProgramma : Exception
    {
        public SchedulazioneAlreadyAddedToProgramma()
        {
        }

        public SchedulazioneAlreadyAddedToProgramma(string message)
            : base(message)
        {
        }

        public SchedulazioneAlreadyAddedToProgramma(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public SchedulazioneAlreadyAddedToProgramma(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public bool Equals(SchedulazioneAlreadyAddedToProgramma other)
        {
            return !ReferenceEquals(null, other);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof(SchedulazioneAlreadyAddedToProgramma)) return false;
            return Equals((SchedulazioneAlreadyAddedToProgramma)obj);
        }

        public override int GetHashCode()
        {
            return 0;
        }
    }
}