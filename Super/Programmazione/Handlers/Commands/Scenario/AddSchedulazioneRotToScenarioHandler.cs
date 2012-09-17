using System;
using System.Diagnostics.Contracts;
using CommonDomain.Core;
using CommonDomain.Core.Handlers.Commands;
using CommonDomain.Core.Super.Domain.ValueObjects;
using CommonDomain.Persistence;
using Super.Programmazione.Commands.Scenario;

namespace Super.Programmazione.Handlers.Commands.Scenario
{
    public class AddSchedulazioneRotToScenarioHandler: CommandHandler<AddSchedulazioneRotToScenario>
    {
        public AddSchedulazioneRotToScenarioHandler(IEventRepository eventRepository)
            : base(eventRepository)
        {
        }

        public override CommandValidation Execute(AddSchedulazioneRotToScenario cmd)
        {
            Contract.Requires(cmd != null);

            var existingSchedulazione = EventRepository.GetById<Domain.SchedulazioneRot>(cmd.IdSchedulazione);

            if(!existingSchedulazione.IsNull())
                throw new AlreadyCreatedAggregateRootException();

            var scenario = EventRepository.GetById<Domain.Scenario>(cmd.Id);

            if (scenario.IsNull())
                throw new AggregateRootInstanceNotFoundException();



            var schedulazione = scenario.AddSchedulazioneRot(
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
                cmd.Convoglio,
                cmd.RigaTurnoTreno,
                cmd.TurnoTreno,
                cmd.TrenoArrivo.ToDomain(),
                cmd.TrenoPartenza.ToDomain(),
                cmd.Oggetti.ToDomain()
                );
            
            EventRepository.Save(schedulazione, cmd.CommitId);

            return schedulazione.CommandValidationMessages; 
        }
    }
}

