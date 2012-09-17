using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonDomain.Core;
using CommonDomain.Core.Super.Domain.ValueObjects;
using CommonDomain.Core.Super.Messaging.Builders;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using Super.Programmazione.Events;
using Super.Programmazione.Events.Scenario;
using Super.Programmazione.Events.Schedulazione;
using Period = CommonDomain.Core.Super.Domain.ValueObjects.Period;
using WorkPeriod = CommonDomain.Core.Super.Domain.ValueObjects.WorkPeriod;
using Treno = CommonDomain.Core.Super.Domain.ValueObjects.Treno;
using OggettoRot = CommonDomain.Core.Super.Domain.ValueObjects.OggettoRot;

namespace Super.Programmazione.Domain
{
    public class SchedulazioneRot : AggregateBase
    {
        public SchedulazioneRot()
        {
            
        }

        public void AddFromScenario(Guid idScenario, Guid idAppaltatore, Guid idCategoriaCommerciale, Guid idCommittente,  Guid idDirezioneRegionale, Guid idImpianto, Guid idLotto, Period period, Guid idPeriodoProgrammazione, Guid idSchedulazione, WorkPeriod workPeriod, Guid idTipoIntervento, string note, string convoglio, string rigaTurnoTreno, string turnoTreno, Treno trenoArrivo, Treno trenoPartenza, IEnumerable<OggettoRot> oggetti)
        {

            var evt = BuildEvt.SchedulazioneRotAddedToScenario
                .ForAppaltatore(idAppaltatore)
                .ForCategoriaCommerciale(idCategoriaCommerciale)
                .ForCommittente(idCommittente)
                .ForDirezioneRegionale(idDirezioneRegionale)
                .ForImpianto(idImpianto)
                .ForLotto(idLotto)
                .ForPeriod(period.ToMessage())
                .ForPeriodoProgrammazione(idPeriodoProgrammazione)
                .ForScenario(idScenario)
                .ForWorkPeriod(workPeriod.ToMessage())
                .OfTipoIntervento(idTipoIntervento)
                .WithNote(note)
                .ForConvoglio(convoglio)
                .WithRigaTurnoTreno(rigaTurnoTreno)
                .WithTurnoTreno(turnoTreno)
                .WithTrenoArrivo(trenoArrivo.ToMessage())
                .WithTrenoPartenza(trenoPartenza.ToMessage())
                .WithOggetti(oggetti.ToMessage().ToArray());

            RaiseEvent(idSchedulazione, evt);
        }

        public void Apply(SchedulazioneRotAddedToScenario evt)
        {
            Id = evt.Id;
        }
    }
}
