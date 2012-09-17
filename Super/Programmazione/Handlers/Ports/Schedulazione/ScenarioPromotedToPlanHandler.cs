using CommonDomain.Core.Handlers;
using Super.Programmazione.Commands;
using Super.Programmazione.Commands.Schedulazione;
using Super.Programmazione.Events.Scenario;

namespace Super.Programmazione.Handlers.Ports.Schedulazione
{
    public class SchedulazioneAmbAddedToScenarioHandler : IPortHandler<SchedulazioneAmbAddedToScenario, CreateSchedulazioneAmb>
    {
        public CreateSchedulazioneAmb Port(SchedulazioneAmbAddedToScenario evt)
        {
            return BuildCmd.CreateSchedulazioneAmb
                .ForAppaltatore(evt.IdAppaltatore)
                .ForCategoriaCommerciale(evt.IdCategoriaCommerciale)
                .ForCommittente(evt.IdCommittente)
                .ForDescription(evt.Description)
                .ForDirezioneRegionale(evt.IdDirezioneRegionale)
                .ForImpianto(evt.IdImpianto)
                .ForLotto(evt.IdLotto)
                .ForPeriod(evt.Period)
                .ForPeriodoProgrammazione(evt.IdPeriodoProgrammazione)
                .ForQuantity(evt.Quantity)
                .ForSchedulazione(evt.IdSchedulazione)
                .ForWorkPeriod(evt.WorkPeriod)
                .OfTipoIntervento(evt.IdTipoIntervento)
                .WithNote(evt.Note)
                .Build(evt.Id, evt.CommitId, 1);
        }
    }
}
