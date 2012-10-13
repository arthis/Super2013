using System.Diagnostics.Contracts;
using CommonDomain.Core;
using CommonDomain.Core.Handlers.Commands;
using CommonDomain.Persistence;
using Super.Contabilita.Commands.PeriodoProgrammazione;

namespace Super.Contabilita.Handlers.Commands.PeriodoProgrammazione
{
    public class DeletePeriodoProgrammazioneHandler : CommandHandler<DeletePeriodoProgrammazione>
    {
        public DeletePeriodoProgrammazioneHandler(IEventRepository eventRepository)
            : base(eventRepository)
        {
        }


        public override CommandValidation Execute(DeletePeriodoProgrammazione cmd)
        {
            Contract.Requires(cmd != null);

            var periodo= EventRepository.GetById<Domain.PeriodoProgrammazione>(cmd.Id);

            if (periodo.IsNull())
                throw new AggregateRootInstanceNotFoundException();

            periodo.Delete();

            EventRepository.Save(periodo, cmd.CommitId);

            return periodo.CommandValidationMessages;
        }
    }
}
