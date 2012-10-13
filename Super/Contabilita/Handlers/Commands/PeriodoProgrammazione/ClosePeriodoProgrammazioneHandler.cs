using System.Diagnostics.Contracts;
using CommonDomain.Core;
using CommonDomain.Core.Handlers.Commands;
using CommonDomain.Persistence;
using Super.Contabilita.Commands.PeriodoProgrammazione;

namespace Super.Contabilita.Handlers.Commands.PeriodoProgrammazione
{

    public class ClosePeriodoProgrammazioneHandler : CommandHandler<ClosePeriodoProgrammazione>
    {
        public ClosePeriodoProgrammazioneHandler(IEventRepository eventRepository)
            : base(eventRepository)
        {
        }


        public override CommandValidation Execute(ClosePeriodoProgrammazione cmd)
        {
            Contract.Requires(cmd != null);


            var periodo = EventRepository.GetById<Domain.PeriodoProgrammazione>(cmd.Id);

            if (periodo.IsNull())
                throw new AggregateRootInstanceNotFoundException();


            periodo.Close(cmd.ClosingDate, cmd.IdUser);

            EventRepository.Save(periodo, cmd.CommitId);


            return periodo.CommandValidationMessages;
        }

    }

 
}
