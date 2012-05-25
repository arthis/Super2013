using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonDomain.Core
{
    public abstract class Message : IMessage
    {
        public const string CommitKey = "CommitKey";
        public const string CorrelationKey = "CorrelationKey";

        public IEnumerable<KeyValuePair<string, object>> Headers { get; set; }

        public abstract string ToDescription();


        public Message()
        {
            Headers= new Dictionary<string, object>();


            //initialisation of the message headers
            ((Dictionary<string, object>) Headers).Add(CommitKey, Guid.NewGuid());
            ((Dictionary<string, object>)Headers).Add(CorrelationKey, Guid.NewGuid());
        }

        public void SetHeader(string key, object value)
        {
            ((Dictionary<string, object>)Headers).Add(key,value);
        }

        


        public void SetCommitId(Guid id)
        {
            if (!((Dictionary<string, object>)Headers).ContainsKey(CommitKey))
                ((Dictionary<string, object>)Headers)[CommitKey] = id;
            else
                ((Dictionary<string, object>)Headers).Add(CommitKey, id);
        }

        public void SetCorrelationitId(Guid id)
        {
            if (!((Dictionary<string, object>)Headers).ContainsKey(CorrelationKey))
                ((Dictionary<string, object>)Headers)[CorrelationKey] = id;
            else
                ((Dictionary<string, object>)Headers).Add(CorrelationKey, id);
        }

        public Guid GetCommitId()
        {
            if (!((Dictionary<string, object>)Headers).ContainsKey(CommitKey))
                throw new Exception("CommitKey not found for this message");

            return (Guid)((Dictionary<string, object>)Headers)[CommitKey];
        }

        public Guid GetCorrelationId()
        {
            if (!((Dictionary<string, object>)Headers).ContainsKey(CorrelationKey))
                throw new Exception("CorrelationId not found for this message");

            return (Guid)((Dictionary<string, object>)Headers)[CorrelationKey];
        }

       
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;

            if (obj.GetType() != this.GetType()) return false;

            var other = (Message)obj;
            
            // CommitId and CorrelationId are not relevant to see if two messages are equals
            //if there was something different in Headers, we might do something different
            return true;
        }

        public override int GetHashCode()
        {
            return (Headers != null ? Headers.GetHashCode() : 0);
        }
    }
}
