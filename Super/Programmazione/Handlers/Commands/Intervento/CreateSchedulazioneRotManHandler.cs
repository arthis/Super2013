using System.Diagnostics.Contracts;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Handlers.Commands;
using CommonDomain.Core.Super.Domain.ValueObjects;
using CommonDomain.Persistence;
using Super.Programmazione.Commands.Intervento;
using Super.Programmazione.Commands.Plan;

namespace Super.Programmazione.Handlers.Commands.Intervento
{
    public class CreateInterventoRotManHandler : CommandHandler<CreateInterventoRotMan>
    {
        public CreateInterventoRotManHandler(IEventRepository eventRepository)
            : base(eventRepository)
        {
        }

        public override CommandValidation Execute(CreateInterventoRotMan cmd)
        {
            Contract.Requires(cmd != null);

            var existingIntervento = EventRepository.GetById<Domain.Intervento.InterventoRotMan>(cmd.Id);
            var programma = EventRepository.GetById<Domain.Programma.Programma>(cmd.IdProgramma);

            if (!existingIntervento.IsNull())
                throw new AlreadyCreatedAggregateRootException();

            if (programma.IsNull())
                throw new AggregateRootInstanceNotFoundException();

            var intervento =  programma.CreateInterventoRotMan(
                cmd.IdProgramma,
                cmd.IdAppaltatore,
                cmd.IdCategoriaCommerciale,
                cmd.IdCommittente,
                cmd.IdDirezioneRegionale,
                cmd.IdImpianto,
                cmd.IdLotto,
                cmd.IdPeriodoProgrammazione,
                cmd.Id,
                cmd.WorkPeriod.ToDomain(),
                cmd.IdTipoIntervento,
                cmd.Note,
                cmd.Oggetti.ToDomain());

            EventRepository.Save(intervento, cmd.CommitId);

            return intervento.CommandValidationMessages; 
        }
    }
}
