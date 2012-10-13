using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonDomain.Core;
using CommonDomain.Core.Super.Domain.ValueObjects;
using Super.Programmazione.Events;
using Super.Programmazione.Events.Intervento;
using Super.Programmazione.Events.Schedulazione;

namespace Super.Programmazione.Domain.Intervento
{
    public class InterventoRotMan : AggregateBase
    {
        public InterventoRotMan()
        {

        }


        public InterventoRotMan(Guid idProgramma, Guid idAppaltatore, Guid idCategoriaCommerciale, Guid idCommittente, Guid idDirezioneRegionale, Guid idImpianto, Guid idLotto,  Guid idPeriodoProgrammazione, Guid idIntervento, WorkPeriod workPeriod, Guid idTipoIntervento, string note, IEnumerable<OggettoRotMan> oggetti)
        {
            var evt = BuildEvt.InterventoRotManCreated
                .ForAppaltatore(idAppaltatore)
                .ForCategoriaCommerciale(idCategoriaCommerciale)
                .ForCommittente(idCommittente)
                .ForDirezioneRegionale(idDirezioneRegionale)
                .ForImpianto(idImpianto)
                .ForLotto(idLotto)
                .ForPeriodoProgrammazione(idPeriodoProgrammazione)
                .ForProgramma(idProgramma)
                .ForWorkPeriod(workPeriod.ToMessage())
                .OfTipoIntervento(idTipoIntervento)
                .WithNote(note)
                .WithOggetti(oggetti.ToMessage().ToArray());

            RaiseEvent(idIntervento, evt);
        }

        public void Apply(InterventoRotManCreated evt)
        {
            Id = evt.Id;
        }

    }
}
