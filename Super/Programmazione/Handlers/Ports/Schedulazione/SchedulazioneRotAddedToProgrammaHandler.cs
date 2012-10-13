using CommonDomain.Core.Handlers;
using Super.Programmazione.Commands;
using Super.Programmazione.Commands.Programma;
using Super.Programmazione.Commands.Schedulazione;
using Super.Programmazione.Events.Programma;
using Super.Programmazione.Events.Scenario;

namespace Super.Programmazione.Handlers.Ports.Schedulazione
{
    public class SchedulazioneRotAddedToProgrammaHandler : IPortHandler<SchedulazioneRotAddedToProgramma, CreateSchedulazioneRot>
    {
        public CreateSchedulazioneRot Port(SchedulazioneRotAddedToProgramma evt)
        {
            return BuildCmd.CreateSchedulazioneRot
                .ForProgramma(evt.Id)
                .ForAppaltatore(evt.IdAppaltatore)
                .ForCategoriaCommerciale(evt.IdCategoriaCommerciale)
                .ForCommittente(evt.IdCommittente)
                .ForConvoglio(evt.Convoglio)
                .ForDirezioneRegionale(evt.IdDirezioneRegionale)
                .ForImpianto(evt.IdImpianto)
                .ForLotto(evt.IdLotto)
                .ForPeriod(evt.Period)
                .ForPeriodoProgrammazione(evt.IdPeriodoProgrammazione)
                .ForWorkPeriod(evt.WorkPeriod)
                .OfTipoIntervento(evt.IdTipoIntervento)
                .WithNote(evt.Note)
                .WithOggetti(evt.Oggetti)
                .WithRigaTurnoTreno(evt.RigaTurnoTreno)
                .WithTrenoArrivo(evt.TrenoArrivo)
                .WithTrenoPartenza(evt.TrenoPartenza)
                .WithTurnoTreno(evt.TurnoTreno)
                .Build(evt.IdSchedulazione, 0);
        }
    }
}
