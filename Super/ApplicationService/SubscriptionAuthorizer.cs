using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NServiceBus;

namespace ApplicationService
{
    public class SubscriptionAuthorizer : IAuthorizeSubscriptions
    {
        public bool AuthorizeSubscribe(string messageType, string clientEndpoint, IDictionary<string, string> headers)
        {
            return true;
        }

        public bool AuthorizeUnsubscribe(string messageType, string clientEndpoint, IDictionary<string, string> headers)
        {
            return true;
        }
    }
}
