using System.Diagnostics.Contracts;
using CommonDomain.Core;
using CommonDomain.Core.Handlers.Commands;
using CommonDomain.Core.Super.Domain.ValueObjects;
using CommonDomain.Persistence;
using Super.Programmazione.Commands.Intervento;
using Super.Programmazione.Commands.Plan;

namespace Super.Programmazione.Handlers.Commands.Intervento
{
    public class CreateInterventoRotHandler : CommandHandler<CreateInterventoRot>
    {
        public CreateInterventoRotHandler(IEventRepository eventRepository)
            : base(eventRepository)
        {
        }

        public override CommandValidation Execute(CreateInterventoRot cmd)
        {
            Contract.Requires(cmd != null);

            var existingIntervento = EventRepository.GetById<Domain.Intervento.InterventoRot>(cmd.Id);
            var programma = EventRepository.GetById<Domain.Programma.Programma>(cmd.IdProgramma);

            if (!existingIntervento.IsNull())
                throw new AlreadyCreatedAggregateRootException();

            if (programma.IsNull())
                throw new AggregateRootInstanceNotFoundException();


            var intervento = programma.CreateInterventoRot(
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
                cmd.Oggetti.ToDomain(),
                cmd.Convoglio,
                cmd.RigaTurnoTreno,
                cmd.TrenoArrivo.ToDomain(),
                cmd.TrenoPartenza.ToDomain(),
                cmd.TurnoTreno);

            EventRepository.Save(intervento, cmd.CommitId);

            return intervento.CommandValidationMessages; 
        }
    }
}
