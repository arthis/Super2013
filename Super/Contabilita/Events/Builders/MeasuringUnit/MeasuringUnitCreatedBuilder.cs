using System;
using CommonDomain;
using Super.Contabilita.Events.MeasuringUnit;

namespace Super.Contabilita.Events.Builders.MeasuringUnit
{
    public class MeasuringUnitCreatedBuilder : IEventBuilder<MeasuringUnitCreated>
    {
        private string _description;


        public MeasuringUnitCreated Build(Guid id, long version)
        {
            var evt = new MeasuringUnitCreated(id, Guid.NewGuid() ,version,    _description);
            
            return evt;
        }


        public MeasuringUnitCreatedBuilder ForDescription(string description)
        {
            _description = description;
            return this;
        }

    }

}