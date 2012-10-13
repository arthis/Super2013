using System.Diagnostics.Contracts;
using CommonDomain.Core;
using CommonDomain.Core.Handlers.Commands;
using CommonDomain.Core.Super.Domain.ValueObjects;
using CommonDomain.Persistence;
using Super.Contabilita.Commands.PeriodoProgrammazione;

namespace Super.Contabilita.Handlers.Commands.PeriodoProgrammazione
{

    public class CreatePeriodoProgrammazioneHandler : CommandHandler<CreatePeriodoProgrammazione>
    {
        public CreatePeriodoProgrammazioneHandler(IEventRepository eventRepository)
            : base(eventRepository)
        {
        }


        public override CommandValidation Execute(CreatePeriodoProgrammazione cmd)
        {
            Contract.Requires(cmd != null);
            

            var existingPeriodoProgrammazione = EventRepository.GetById<Domain.PeriodoProgrammazione>(cmd.Id);

            if (!existingPeriodoProgrammazione.IsNull())
                throw new AlreadyCreatedAggregateRootException();



            var periodo = new Domain.PeriodoProgrammazione(cmd.Id,
                                          cmd.Description,
                                          cmd.Interval.ToDomain());

            EventRepository.Save(periodo, cmd.CommitId);


            return periodo.CommandValidationMessages;
        }

    }

 
}
