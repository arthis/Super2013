using System;
using System.Collections.Generic;
using System.Linq;
using CommonDomain.Core;
using CommonDomain.Core.Super.Domain.ValueObjects;
using Super.Programmazione.Events;
using Super.Programmazione.Events.Programma;
using Super.Programmazione.Events.Scenario;
using Super.Programmazione.Events.Schedulazione;

namespace Super.Programmazione.Domain.Schedulazione
{
    public class SchedulazioneRot : AggregateBase
    {
        public SchedulazioneRot()
        {
            
        }

        public SchedulazioneRot(Guid idProgramma, Guid idAppaltatore, Guid idCategoriaCommerciale, Guid idCommittente, Guid idDirezioneRegionale, Guid idImpianto, Guid idLotto, Period period, Guid idPeriodoProgrammazione, Guid idSchedulazione, WorkPeriod workPeriod, Guid idTipoIntervento, string note, IEnumerable<OggettoRot> oggetti, string convoglio, string rigaTurnoTreno, Treno trenoArrivo, Treno trenoPartenza, string turnoTreno)
        {
            var evt = BuildEvt.SchedulazioneRotCreated
                .ForAppaltatore(idAppaltatore)
                .ForProgramma(idProgramma)
                .ForCategoriaCommerciale(idCategoriaCommerciale)
                .ForCommittente(idCommittente)
                .ForDirezioneRegionale(idDirezioneRegionale)
                .ForImpianto(idImpianto)
                .ForLotto(idLotto)
                .ForPeriod(period.ToMessage())
                .ForPeriodoProgrammazione(idPeriodoProgrammazione)
                .ForWorkPeriod(workPeriod.ToMessage())
                .OfTipoIntervento(idTipoIntervento)
                .ForConvoglio(convoglio)
                .WithNote(note)
                .WithOggetti(oggetti.ToMessage().ToArray())
                .WithRigaTurnoTreno(rigaTurnoTreno)
                .WithTrenoArrivo(trenoArrivo.ToMessage())
                .WithTrenoPartenza(trenoPartenza.ToMessage())
                .WithTurnoTreno(turnoTreno);

            RaiseEvent(idSchedulazione, evt);
        }

        public void Apply(SchedulazioneRotAddedToProgramma evt)
        {
            Id = evt.Id;
        }

    
    }
}
