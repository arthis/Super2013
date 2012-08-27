using System;
using CommonDomain;
using Super.Contabilita.Events.MeasuringUnit;

namespace Super.Contabilita.Events.Builders.MeasuringUnit
{
    public class MeasuringUnitDeletedBuilder : IEventBuilder<MeasuringUnitDeleted>
    {

        public MeasuringUnitDeleted Build(Guid id, long version)
        {
            var evt = new MeasuringUnitDeleted(id, Guid.NewGuid() ,version);
            
            return evt;
        }

    }


}