using CommonDomain.Core.Handlers;
using Super.Programmazione.Commands;
using Super.Programmazione.Commands.Intervento;
using Super.Programmazione.Commands.Plan;
using Super.Programmazione.Events.Programma;

namespace Super.Programmazione.Handlers.Ports.Intervento
{
    public class InterventoAmbAddedToProgrammaHandler :
        IPortHandler<InterventoAmbAddedToProgramma, CreateInterventoAmb>
    {
        public CreateInterventoAmb Port(InterventoAmbAddedToProgramma evt)
        {
            return BuildCmd.CreateInterventoAmb
                .ForProgramma(evt.Id)
                .ForAppaltatore(evt.IdAppaltatore)
                .ForCategoriaCommerciale(evt.IdCategoriaCommerciale)
                .ForCommittente(evt.IdCommittente)
                .ForDirezioneRegionale(evt.IdDirezioneRegionale)
                .ForImpianto(evt.IdImpianto)
                .ForLotto(evt.IdLotto)
                .ForPeriodoProgrammazione(evt.IdPeriodoProgrammazione)
                .ForWorkPeriod(evt.WorkPeriod)
                .OfTipoIntervento(evt.IdTipoIntervento)
                .WithNote(evt.Note)
                .ForQuantity(evt.Quantity)
                .ForDescription(evt.Description)
                .Build(evt.IdIntervento, 0);
        }
        
    }
}