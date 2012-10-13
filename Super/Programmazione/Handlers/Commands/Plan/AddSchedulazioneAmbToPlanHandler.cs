using System;
using System.Diagnostics.Contracts;
using CommonDomain.Core;
using CommonDomain.Core.Handlers.Commands;
using CommonDomain.Core.Super.Domain.ValueObjects;
using CommonDomain.Persistence;
using Super.Programmazione.Commands.Plan;
using Super.Programmazione.Domain.Schedulazione;

namespace Super.Programmazione.Handlers.Commands.Plan
{
    public class AddSchedulazioneAmbToPlanHandler: CommandHandler<AddSchedulazioneAmbToPlan>
    {
        public AddSchedulazioneAmbToPlanHandler(IEventRepository eventRepository)
            : base(eventRepository)
        {
        }

        public override CommandValidation Execute(AddSchedulazioneAmbToPlan cmd)
        {
            Contract.Requires(cmd != null);

            var plan = EventRepository.GetById<Domain.Programma.Plan>(cmd.Id);
            var existingSchedulazione = EventRepository.GetById<SchedulazioneAmb>(cmd.IdSchedulazione);

            if (plan.IsNull())
                throw new AggregateRootInstanceNotFoundException();

            if (!existingSchedulazione.IsNull())
                throw new AlreadyCreatedAggregateRootException();

            plan.AddSchedulazioneAmb(
                cmd.IdAppaltatore,
                cmd.IdCategoriaCommerciale,
                cmd.IdCommittente,
                cmd.Description,
                cmd.IdDirezioneRegionale,
                cmd.IdImpianto,
                cmd.IdLotto,
                cmd.Period.ToDomain(),
                cmd.IdPeriodoProgrammazione,
                cmd.Quantity,
                cmd.IdSchedulazione,
                cmd.WorkPeriod.ToDomain(),
                cmd.IdTipoIntervento,
                cmd.Note);

            EventRepository.Save(plan, cmd.CommitId);

            return plan.CommandValidationMessages; 

        }
    }
}
