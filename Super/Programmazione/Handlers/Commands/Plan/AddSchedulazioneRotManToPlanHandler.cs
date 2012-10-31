using System;
using System.Diagnostics.Contracts;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Handlers.Commands;
using CommonDomain.Core.Super.Domain.ValueObjects;
using CommonDomain.Persistence;
using Super.Programmazione.Commands.Plan;
using Super.Programmazione.Domain.Schedulazione;

namespace Super.Programmazione.Handlers.Commands.Plan
{
    public class AddSchedulazioneRotManToPlanHandler : CommandHandler<AddSchedulazioneRotManToPlan>
    {
        public AddSchedulazioneRotManToPlanHandler(IEventRepository eventRepository)
            : base(eventRepository)
        {
        }

        public override CommandValidation Execute(AddSchedulazioneRotManToPlan cmd)
        {
            Contract.Requires(cmd != null);

            var existingSchedulazione = EventRepository.GetById<SchedulazioneRotMan>(cmd.IdSchedulazione);

            if (!existingSchedulazione.IsNull())
                throw new AlreadyCreatedAggregateRootException();

            var plan = EventRepository.GetById<Domain.Programma.Plan>(cmd.Id);

            if (plan.IsNull())
                throw new AggregateRootInstanceNotFoundException();

            plan.AddSchedulazioneRotMan(
                cmd.IdAppaltatore,
                cmd.IdCategoriaCommerciale,
                cmd.IdCommittente,
                cmd.IdDirezioneRegionale,
                cmd.IdImpianto,
                cmd.IdLotto,
                cmd.Period.ToDomain(),
                cmd.IdPeriodoProgrammazione,
                cmd.IdSchedulazione,
                cmd.WorkPeriod.ToDomain(),
                cmd.IdTipoIntervento,
                cmd.Note,
                cmd.Oggetti.ToDomain()
                );

            EventRepository.Save(plan, cmd.CommitId);

            return plan.CommandValidationMessages; 
        }
    }
}
