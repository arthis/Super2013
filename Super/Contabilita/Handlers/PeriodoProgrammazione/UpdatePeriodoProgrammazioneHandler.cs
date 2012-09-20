using System;
using System.Diagnostics.Contracts;
using CommonDomain.Core;
using CommonDomain.Core.Handlers;
using CommonDomain.Core.Handlers.Commands;
using CommonDomain.Core.Super.Domain.Builders;
using CommonDomain.Core.Super.Domain.ValueObjects;
using CommonDomain.Persistence;
using Super.Contabilita.Commands.PeriodoProgrammazione;

namespace Super.Contabilita.Handlers.PeriodoProgrammazione
{
    public class UpdatePeriodoProgrammazioneHandler : CommandHandler<UpdatePeriodoProgrammazione>
    {
        public UpdatePeriodoProgrammazioneHandler(IEventRepository eventRepository)
            : base(eventRepository)
        {
        }


        public override CommandValidation Execute(UpdatePeriodoProgrammazione cmd)
        {
            Contract.Requires(cmd != null);

            var periodo = EventRepository.GetById<Domain.PeriodoProgrammazione>(cmd.Id);

            if (periodo.IsNull())
                throw new AggregateRootInstanceNotFoundException();

            periodo.Update(cmd.Description,
                               cmd.Interval.ToDomain());

            EventRepository.Save(periodo, cmd.CommitId);

            return periodo.CommandValidationMessages;
        }
      
    }
}
