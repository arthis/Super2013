using System;
using CommonDomain;
using Super.Contabilita.Events.MeasuringUnit;

namespace Super.Contabilita.Events.Builders.MeasuringUnit
{
    public class MeasuringUnitUpdatedBuilder : IEventBuilder<MeasuringUnitUpdated>
    {
        private string _description;

        public MeasuringUnitUpdated Build(Guid id, long version)
        {
            var evt = new MeasuringUnitUpdated(id, Guid.NewGuid() ,version,  _description);
            
            return evt;
        }

        public MeasuringUnitUpdatedBuilder ForDescription(string description)
        {
            _description = description;
            return this;
        }

    }


}