using System;
using CommonDomain;
using Super.Contabilita.Commands.MeasuringUnit;

namespace Super.Contabilita.Commands.Builders.MeasuringUnit
{
    public class CreateMeasuringUnitBuilder : ICommandBuilder<CreateMeasuringUnit>
    {
        private string _description;

        public CreateMeasuringUnit Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public CreateMeasuringUnit Build(Guid id, Guid commitId, long version)
        {
            var cmd =  new CreateMeasuringUnit(id, commitId, version,   _description);

            return cmd;
        }

 
        public CreateMeasuringUnitBuilder ForDescription(string description)
        {
            _description = description;
            return this;
        }


    }
}
