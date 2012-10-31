using System;
using System.Diagnostics.Contracts;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Handlers.Commands;
using CommonDomain.Core.Super.Domain.ValueObjects;
using CommonDomain.Persistence;
using Super.Programmazione.Commands.Scenario;
using Super.Programmazione.Domain.Schedulazione;

namespace Super.Programmazione.Handlers.Commands.Scenario
{
    public class AddSchedulazioneAmbToScenarioHandler : CommandHandler<AddSchedulazioneAmbToScenario>
    {
        public AddSchedulazioneAmbToScenarioHandler(IEventRepository eventRepository)
            : base(eventRepository)
        {
        }

        public override CommandValidation Execute(AddSchedulazioneAmbToScenario cmd)
        {
            Contract.Requires(cmd != null);

            var scenario = EventRepository.GetById<Domain.Programma.Scenario>(cmd.Id);
            var existingSchedulazione = EventRepository.GetById<SchedulazioneAmb>(cmd.IdSchedulazione);

            if (scenario.IsNull())
                throw new AggregateRootInstanceNotFoundException();

            if (!existingSchedulazione.IsNull())
                throw new AlreadyCreatedAggregateRootException();


            scenario.AddSchedulazioneAmb(
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

            EventRepository.Save(scenario, cmd.CommitId);

            return scenario.CommandValidationMessages; 
        }
    }
}
