using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonDomain.Core
{
    public abstract class Message : IMessage
    {
        public const string CommitId = "CommitId";
        public const string CorrelationitId = "CorrelationitId";

        public IEnumerable<KeyValuePair<string, object>> Headers { get; set; }

        public abstract string ToDescription();


        public Message()
        {
            Headers= new Dictionary<string, object>();


            //initialisation of the message headers
            ((Dictionary<string, object>) Headers).Add(CommitId, Guid.NewGuid());
            ((Dictionary<string, object>)Headers).Add(CorrelationitId, Guid.NewGuid());
        }

        public void SetHeader(string key, object value)
        {
            ((Dictionary<string, object>)Headers).Add(key,value);
        }

        


        public void SetCommitId(Guid id)
        {
            if (!((Dictionary<string, object>)Headers).ContainsKey(CommitId))
                ((Dictionary<string, object>)Headers)[CommitId] = id;
            else
                ((Dictionary<string, object>)Headers).Add(CommitId, id);
        }

        public void SetCorrelationitId(Guid id)
        {
            if (!((Dictionary<string, object>)Headers).ContainsKey(CorrelationitId))
                ((Dictionary<string, object>)Headers)[CorrelationitId] = id;
            else
                ((Dictionary<string, object>)Headers).Add(CorrelationitId, id);
        }

        public Guid GetCommitId()
        {
            if (!((Dictionary<string, object>)Headers).ContainsKey(CommitId))
                throw new Exception("CommitId not found for this message");

            return (Guid)((Dictionary<string, object>)Headers)[CommitId];
        }

        public Guid GetCorrelationId()
        {
            if (!((Dictionary<string, object>)Headers).ContainsKey(CorrelationitId))
                throw new Exception("CorrelationId not found for this message");

            return (Guid)((Dictionary<string, object>)Headers)[CorrelationitId];
        }

       
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;

            if (obj.GetType() != this.GetType()) return false;

            var other = (Message)obj;

            return Equals(other.Headers, Headers);
        }

        public override int GetHashCode()
        {
            return (Headers != null ? Headers.GetHashCode() : 0);
        }
    }
}
