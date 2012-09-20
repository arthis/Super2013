using System;
using System.Diagnostics.Contracts;
using CommonDomain.Core;
using CommonDomain.Core.Handlers;
using CommonDomain.Core.Handlers.Commands;
using CommonDomain.Persistence;
using Super.Contabilita.Commands.MeasuringUnit;
using Super.Contabilita.Domain;

namespace Super.Contabilita.Handlers.MeasuringUnit
{

    public class CreateMeasuringUnitHandler : CommandHandler<CreateMeasuringUnit>
    {
        public CreateMeasuringUnitHandler(IEventRepository eventRepository)
            : base(eventRepository)
        {
        }


        public override CommandValidation Execute(CreateMeasuringUnit cmd)
        {
            Contract.Requires(cmd != null);
            

            var existingMeasuringUnit = EventRepository.GetById<Domain.MeasuringUnit>(cmd.Id);

            if (!existingMeasuringUnit.IsNull())
                throw new AlreadyCreatedAggregateRootException();



            var measuringUnit = new Domain.MeasuringUnit(cmd.Id,
                                          cmd.Description);

            EventRepository.Save(measuringUnit, cmd.CommitId);


            return measuringUnit.CommandValidationMessages;
        }

    }

 
}
