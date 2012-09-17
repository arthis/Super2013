using System;
using System.Collections.Generic;
using CommonDomain.Core;
using CommonDomain.Core.Super.Domain.ValueObjects;
using CommonDomain.Core.Super.Messaging.Builders;
using Super.Programmazione.Domain.Exceptions;
using Super.Programmazione.Events;
using Super.Programmazione.Events.Scenario;
using Super.Programmazione.Events.Schedulazione;

namespace Super.Programmazione.Domain
{
    public class Scenario : AggregateBase
    {
        private bool _cancelled;
        private bool _promoted;

        public Scenario()
        {

        }

        public Scenario(Guid id, Guid userId, string description)
        {
            var evt = BuildEvt.ScenarioCreated
                .ByUser(userId)
                .ForDescription(description);

            RaiseEvent(id, evt);
        }

        public void Apply(ScenarioCreated e)
        {
            Id = e.Id;
        }

        public void ChangeDescription(string description)
        {
            if (_cancelled)
                throw new ScenarioCancelledDoNotAllowFurtherChanges();

            if (_promoted)
                throw new ScenarioPromotedDoNotAllowFurtherChanges();

            var evt = BuildEvt.DescriptionOfScenarioChanged
               .ForDescription(description);

            RaiseEvent(evt);
        }

        public void Apply(DescriptionOfScenarioChanged e)
        {
            //do nothing
        }


        public void Cancel(Guid userId)
        {
            if (_promoted)
                throw new ScenarioPromotedDoNotAllowFurtherChanges();

            if (!_cancelled)
            {
                var evt = BuildEvt.ScenarioCancelled
                    .ByUser(userId);

                RaiseEvent(evt);
            }
        }

        public void Apply(ScenarioCancelled e)
        {
            _cancelled = true;
        }


        public void PromoteToPlan(Guid userId,DateTime promotingDate)
        {
            if (_cancelled)
                throw new ScenarioCancelledDoNotAllowFurtherChanges();

            if (_promoted)
                throw new ScenarioPromotedDoNotAllowFurtherChanges();

            var evt = BuildEvt.ScenarioPromotedToPlan
                .ByUser(userId)
                .When(promotingDate);

            RaiseEvent(evt);

        }

        public void Apply(ScenarioPromotedToPlan e)
        {
            _promoted = true;

        }

        public Plan CreatePlan(Guid idPlan)
        {
            if(_cancelled)
                throw new ScenarioCancelledDoNotAllowFurtherChanges();

            if(_promoted)
                throw new  ScenarioPromotedDoNotAllowFurtherChanges(); 

            return new Plan(idPlan);
        }

        public SchedulazioneAmb AddSchedulazioneAmb(Guid idAppaltatore, Guid idCategoriaCommerciale, Guid idCommittente, string description, Guid idDirezioneRegionale, Guid idImpianto, Guid idLotto, Period period, Guid idPeriodoProgrammazione, int quantity, Guid idSchedulazione, WorkPeriod workPeriod, Guid idTipoIntervento, string note)
        {
            if (_cancelled)
                throw  new ScenarioCancelledDoNotAllowFurtherChanges();

            if (_promoted)
                throw new ScenarioPromotedDoNotAllowFurtherChanges();

            var schedulazione = new SchedulazioneAmb();

            schedulazione.AddFromScenario(Id, idAppaltatore,  idCategoriaCommerciale,  idCommittente,  description,  idDirezioneRegionale,  idImpianto,  idLotto, period,  idPeriodoProgrammazione,  quantity,  idSchedulazione,  workPeriod,  idTipoIntervento,  note);

            return schedulazione;
        }

        public SchedulazioneRot AddSchedulazioneRot(Guid idAppaltatore, Guid idCategoriaCommerciale, Guid idCommittente, Guid idDirezioneRegionale, Guid idImpianto, Guid idLotto, Period period, Guid idPeriodoProgrammazione,  Guid idSchedulazione, WorkPeriod workPeriod, Guid idTipoIntervento, string note, string convoglio, string rigaTurnoTreno, string turnoTreno, Treno trenoArrivo, Treno trenoPartenza, IEnumerable< OggettoRot> oggetti)
        {
            if (_cancelled)
                throw new ScenarioCancelledDoNotAllowFurtherChanges();

            if (_promoted)
                throw new ScenarioPromotedDoNotAllowFurtherChanges();

            var schedulazione = new SchedulazioneRot();

            schedulazione.AddFromScenario(Id, idAppaltatore, idCategoriaCommerciale, idCommittente,  idDirezioneRegionale, idImpianto, idLotto, period, idPeriodoProgrammazione,  idSchedulazione, workPeriod, idTipoIntervento, note, convoglio, rigaTurnoTreno, turnoTreno, trenoArrivo, trenoPartenza,  oggetti);

            return schedulazione;
        }

        
    }
}
