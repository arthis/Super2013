using System;
using CommonDomain;
using Super.Contabilita.Events.Appaltatore;

namespace Super.Contabilita.Events.Builders.Appaltatore
{
    public class AppaltatoreUpdatedBuilder : IEventBuilder<AppaltatoreUpdated>
    {
        private string _description;

        public AppaltatoreUpdated Build(Guid id, long version)
        {
            var evt = new AppaltatoreUpdated(id, Guid.NewGuid() ,version,  _description);
            
            return evt;
        }

        public AppaltatoreUpdatedBuilder ForDescription(string description)
        {
            _description = description;
            return this;
        }

    }


}