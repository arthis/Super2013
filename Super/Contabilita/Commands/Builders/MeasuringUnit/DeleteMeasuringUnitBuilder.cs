using System;
using CommonDomain;
using Super.Contabilita.Commands.MeasuringUnit;

namespace Super.Contabilita.Commands.Builders.MeasuringUnit
{
    public class DeleteMeasuringUnitBuilder : ICommandBuilder<DeleteMeasuringUnit>
    {

        public DeleteMeasuringUnit Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public DeleteMeasuringUnit Build(Guid id, Guid commitId, long version)
        {
            var cmd = new DeleteMeasuringUnit(id,commitId,version);

            return cmd;
        }


    }
}