using System.Diagnostics.Contracts;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Handlers.Commands;
using CommonDomain.Persistence;
using Super.Contabilita.Commands.MeasuringUnit;

namespace Super.Contabilita.Handlers.Commands.MeasuringUnit
{
    public class UpdateMeasuringUnitHandler : CommandHandler<UpdateMeasuringUnit>
    {
        public UpdateMeasuringUnitHandler(IEventRepository eventRepository)
            : base(eventRepository)
        {
        }


        public override CommandValidation Execute(UpdateMeasuringUnit cmd)
        {
            Contract.Requires(cmd != null);

            var measuringUnit = EventRepository.GetById<Domain.MeasuringUnit>(cmd.Id);

            if (measuringUnit.IsNull())
                throw new AggregateRootInstanceNotFoundException();

            measuringUnit.Update( cmd.Description);

            EventRepository.Save(measuringUnit, cmd.CommitId);

            return measuringUnit.CommandValidationMessages;
        }
      
    }
}
