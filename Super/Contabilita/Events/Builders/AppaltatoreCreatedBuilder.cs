using System;
using CommonDomain;
using CommonDomain.Core.Super.Messaging.Builders;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using Super.Contabilita.Events.Appaltatore;

namespace Super.Contabilita.Events.Builders
{
    public class AppaltatoreCreatedBuilder : IEventBuilder<AppaltatoreCreated>
    {
        private string _description;


        public AppaltatoreCreated Build(Guid id, long version)
        {
            var evt = new AppaltatoreCreated(id, Guid.NewGuid() ,version,    _description);
            
            return evt;
        }


        public AppaltatoreCreatedBuilder ForDescription(string description)
        {
            _description = description;
            return this;
        }

    }

}