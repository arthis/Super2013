using CommonDomain.Core.Handlers;
using Super.Programmazione.Commands;
using Super.Programmazione.Commands.Plan;
using Super.Programmazione.Commands.Programma;
using Super.Programmazione.Commands.Intervento;
using Super.Programmazione.Events.Programma;
using Super.Programmazione.Events.Scenario;

namespace Super.Programmazione.Handlers.Ports.Intervento
{
    public class InterventoRotAddedToProgrammaHandler : IPortHandler<InterventoRotAddedToProgramma, CreateInterventoRot>
    {
        public CreateInterventoRot Port(InterventoRotAddedToProgramma evt)
        {
            return BuildCmd.CreateInterventoRot
                .ForProgramma(evt.Id)
                .ForAppaltatore(evt.IdAppaltatore)
                .ForCategoriaCommerciale(evt.IdCategoriaCommerciale)
                .ForCommittente(evt.IdCommittente)
                .ForConvoglio(evt.Convoglio)
                .ForDirezioneRegionale(evt.IdDirezioneRegionale)
                .ForImpianto(evt.IdImpianto)
                .ForLotto(evt.IdLotto)
                .ForPeriodoProgrammazione(evt.IdPeriodoProgrammazione)
                .ForWorkPeriod(evt.WorkPeriod)
                .OfTipoIntervento(evt.IdTipoIntervento)
                .WithNote(evt.Note)
                .WithOggetti(evt.Oggetti)
                .WithRigaTurnoTreno(evt.RigaTurnoTreno)
                .WithTrenoArrivo(evt.TrenoArrivo)
                .WithTrenoPartenza(evt.TrenoPartenza)
                .WithTurnoTreno(evt.TurnoTreno)
                .Build(evt.IdIntervento, 0);
        }
    }
}
