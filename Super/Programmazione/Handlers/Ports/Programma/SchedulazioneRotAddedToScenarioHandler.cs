using CommonDomain.Core.Handlers;
using Super.Programmazione.Commands;
using Super.Programmazione.Commands.Plan;
using Super.Programmazione.Commands.Programma;
using Super.Programmazione.Events.Scenario;

namespace Super.Programmazione.Handlers.Ports.Programma
{
 
    public class SchedulazioneRotAddedToScenarioHandler : 
        IPortHandler<SchedulazioneRotAddedToScenario, AddSchedulazioneRotToProgramma>
        

    {
        public AddSchedulazioneRotToProgramma Port(SchedulazioneRotAddedToScenario evt)
        {
            return BuildCmd.AddSchedulazioneRotToProgramma
                .ForAppaltatore(evt.IdAppaltatore)
                .ForCategoriaCommerciale(evt.IdCategoriaCommerciale)
                .ForCommittente(evt.IdCommittente)
                .ForConvoglio(evt.Convoglio)
                .ForDirezioneRegionale(evt.IdDirezioneRegionale)
                .ForImpianto(evt.IdImpianto)
                .ForLotto(evt.IdLotto)
                .ForPeriod(evt.Period)
                .ForPeriodoProgrammazione(evt.IdPeriodoProgrammazione)
                .ForSchedulazione(evt.IdSchedulazione)
                .ForWorkPeriod(evt.WorkPeriod)
                .OfTipoIntervento(evt.IdTipoIntervento)
                .WithNote(evt.Note)
                .WithOggetti(evt.Oggetti)
                .WithRigaTurnoTreno(evt.RigaTurnoTreno)
                .WithTrenoArrivo(evt.TrenoArrivo)
                .WithTrenoPartenza(evt.TrenoPartenza)
                .WithTurnoTreno(evt.TurnoTreno)
                .Build(evt.IdProgramma,0);
        }

        

        
    }
}
