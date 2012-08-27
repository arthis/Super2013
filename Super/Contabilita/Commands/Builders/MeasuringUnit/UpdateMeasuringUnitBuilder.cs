using System;
using CommonDomain;
using Super.Contabilita.Commands.MeasuringUnit;

namespace Super.Contabilita.Commands.Builders.MeasuringUnit
{
    public class UpdateMeasuringUnitBuilder : ICommandBuilder<UpdateMeasuringUnit>
    {
        private string _description;

        public UpdateMeasuringUnit Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public UpdateMeasuringUnit Build(Guid id, Guid commitId, long version)
        {
            var cmd = new UpdateMeasuringUnit(id, commitId, version,  _description);
            
            return cmd;
        }



        public UpdateMeasuringUnitBuilder ForDescription(string description)
        {
            _description = description;
            return this;
        }

        
    }
}