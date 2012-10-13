using System.Diagnostics.Contracts;
using CommonDomain.Core;
using CommonDomain.Core.Handlers.Commands;
using CommonDomain.Persistence;
using Super.Contabilita.Commands.MeasuringUnit;

namespace Super.Contabilita.Handlers.Commands.MeasuringUnit
{
    public class DeleteMeasuringUnitHandler : CommandHandler<DeleteMeasuringUnit>
    {
        public DeleteMeasuringUnitHandler(IEventRepository eventRepository)
            : base(eventRepository)
        {
        }


        public override CommandValidation Execute(DeleteMeasuringUnit cmd)
        {
            Contract.Requires(cmd != null);

            var measuringUnit= EventRepository.GetById<Domain.MeasuringUnit>(cmd.Id);

            if (measuringUnit.IsNull())
                throw new AggregateRootInstanceNotFoundException();

            measuringUnit.Delete();

            EventRepository.Save(measuringUnit, cmd.CommitId);

            return measuringUnit.CommandValidationMessages;
        }
    }
}
