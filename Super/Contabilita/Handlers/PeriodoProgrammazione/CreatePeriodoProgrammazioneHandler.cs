using System;
using System.Diagnostics.Contracts;
using CommonDomain.Core;
using CommonDomain.Core.Handlers;
using CommonDomain.Core.Handlers.Commands;
using CommonDomain.Core.Super.Domain.ValueObjects;
using CommonDomain.Persistence;
using Super.Contabilita.Commands.PeriodoProgrammazione;
using Super.Contabilita.Domain;

namespace Super.Contabilita.Handlers.PeriodoProgrammazione
{

    public class CreatePeriodoProgrammazioneHandler : CommandHandler<CreatePeriodoProgrammazione>
    {
        public CreatePeriodoProgrammazioneHandler(IEventRepository eventRepository)
            : base(eventRepository)
        {
        }


        public override CommandValidation Execute(CreatePeriodoProgrammazione cmd)
        {
            Contract.Requires<ArgumentNullException>(cmd != null);
            

            var existingPeriodoProgrammazione = EventRepository.GetById<Domain.PeriodoProgrammazione>(cmd.Id);

            if (!existingPeriodoProgrammazione.IsNull())
                throw new AlreadyCreatedAggregateRootException();



            var periodo = new Domain.PeriodoProgrammazione(cmd.Id,
                                          cmd.Description,
                                          Interval.FromMessage(cmd.Interval));

            EventRepository.Save(periodo, cmd.CommitId);


            return periodo.CommandValidationMessages;
        }

    }

 
}
