using CommonDomain.Core.Handlers;
using Super.Programmazione.Commands;
using Super.Programmazione.Commands.Programma;
using Super.Programmazione.Events.Plan;
using Super.Programmazione.Events.Scenario;

namespace Super.Programmazione.Handlers.Ports.Programma
{
    public class SchedulazioneAmbAddedToPlanHandler : 
        IPortHandler<SchedulazioneAmbAddedToPlan, AddSchedulazioneAmbToProgramma>
    {
        public AddSchedulazioneAmbToProgramma Port(SchedulazioneAmbAddedToPlan evt)
        {
            return BuildCmd.AddSchedulazioneAmbToProgramma
                .ForAppaltatore(evt.IdAppaltatore)
                .ForCategoriaCommerciale(evt.IdCategoriaCommerciale)
                .ForCommittente(evt.IdCommittente)
                .ForDirezioneRegionale(evt.IdDirezioneRegionale)
                .ForImpianto(evt.IdImpianto)
                .ForLotto(evt.IdLotto)
                .ForPeriod(evt.Period)
                .ForPeriodoProgrammazione(evt.IdPeriodoProgrammazione)
                .ForSchedulazione(evt.IdSchedulazione)
                .ForWorkPeriod(evt.WorkPeriod)
                .OfTipoIntervento(evt.IdTipoIntervento)
                .WithNote(evt.Note)
                .ForQuantity(evt.Quantity)
                .ForDescription(evt.Description)
                .Build(evt.IdProgramma, 0);
        }
        
    }
}