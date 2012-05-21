using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonDomain.Core
{
    public class Message : IMessage
    {
        public IEnumerable<KeyValuePair<string, object>> Headers { get; set; }

        public Message()
        {
            Headers= new Dictionary<string, object>();
        }

        public void SetHeader(string key, object value)
        {
            ((Dictionary<string, object>)Headers).Add(key,value);
        }



        public Guid GetCommitId()
        {
            return (Guid)((Dictionary<string, object>)Headers)["CommitId"];
        }

        public Guid GetCorrelationId()
        {
            return (Guid)((Dictionary<string, object>)Headers)["CommitId"];
        }
    }
}
