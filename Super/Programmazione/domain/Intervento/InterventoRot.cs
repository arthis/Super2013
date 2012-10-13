using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonDomain.Core;
using CommonDomain.Core.Super.Domain.ValueObjects;
using Super.Programmazione.Events;
using Super.Programmazione.Events.Programma;

namespace Super.Programmazione.Domain.Intervento
{
    public class InterventoRot : AggregateBase
    {
        public InterventoRot()
        {

        }

        public InterventoRot(Guid idProgramma, Guid idAppaltatore, Guid idCategoriaCommerciale, Guid idCommittente, Guid idDirezioneRegionale, Guid idImpianto, Guid idLotto,  Guid idPeriodoProgrammazione, Guid idIntervento, WorkPeriod workPeriod, Guid idTipoIntervento, string note, IEnumerable<OggettoRot> oggetti, string convoglio, string rigaTurnoTreno, Treno trenoArrivo, Treno trenoPartenza, string turnoTreno)
        {
            var evt = BuildEvt.InterventoRotCreated
                .ForAppaltatore(idAppaltatore)
                .ForProgramma(idProgramma)
                .ForCategoriaCommerciale(idCategoriaCommerciale)
                .ForCommittente(idCommittente)
                .ForDirezioneRegionale(idDirezioneRegionale)
                .ForImpianto(idImpianto)
                .ForLotto(idLotto)
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

            RaiseEvent(idIntervento, evt);
        }

        public void Apply(InterventoRotAddedToProgramma evt)
        {
            Id = evt.Id;
        }

    }
}
