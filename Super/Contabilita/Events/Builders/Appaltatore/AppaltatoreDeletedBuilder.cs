using System;
using CommonDomain;
using Super.Contabilita.Events.Appaltatore;

namespace Super.Contabilita.Events.Builders.Appaltatore
{
    public class AppaltatoreDeletedBuilder : IEventBuilder<AppaltatoreDeleted>
    {

        public AppaltatoreDeleted Build(Guid id, long version)
        {
            var evt = new AppaltatoreDeleted(id, Guid.NewGuid() ,version);
            
            return evt;
        }

    }


}