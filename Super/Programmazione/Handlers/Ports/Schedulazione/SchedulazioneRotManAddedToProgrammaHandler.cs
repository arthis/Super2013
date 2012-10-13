using CommonDomain.Core.Handlers;
using Super.Programmazione.Commands;
using Super.Programmazione.Commands.Schedulazione;
using Super.Programmazione.Events.Programma;

namespace Super.Programmazione.Handlers.Ports.Schedulazione
{
    public class SchedulazioneRotManAddedToProgrammaHandler : 
        IPortHandler<SchedulazioneRotManAddedToProgramma, CreateSchedulazioneRotMan>
    {
        public CreateSchedulazioneRotMan Port(SchedulazioneRotManAddedToProgramma evt)
        {
            return BuildCmd.CreateSchedulazioneRotMan
                .ForProgramma(evt.Id)
                .ForAppaltatore(evt.IdAppaltatore)
                .ForCategoriaCommerciale(evt.IdCategoriaCommerciale)
                .ForCommittente(evt.IdCommittente)
                .ForDirezioneRegionale(evt.IdDirezioneRegionale)
                .ForImpianto(evt.IdImpianto)
                .ForLotto(evt.IdLotto)
                .ForPeriod(evt.Period)
                .ForPeriodoProgrammazione(evt.IdPeriodoProgrammazione)
                .ForWorkPeriod(evt.WorkPeriod)
                .OfTipoIntervento(evt.IdTipoIntervento)
                .WithNote(evt.Note)
                .WithOggetti(evt.Oggetti)
                .Build(evt.IdSchedulazione, 0);
        }
    }
}