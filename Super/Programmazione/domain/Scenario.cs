using System;
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

        public void AddSchedulazioneAmb(Guid idAppaltatore, Guid idCategoriaCommerciale, Guid idCommittente, string description, Guid idDirezioneRegionale, Guid idImpianto, Guid idLotto, Period period, Guid idPeriodoProgrammazione, int quantity, Guid idSchedulazione, WorkPeriod workPeriod, Guid idTipoIntervento, string note)
        {
            if (_cancelled)
                throw  new ScenarioCancelledDoNotAllowFurtherChanges();

            if (_promoted)
                throw new ScenarioPromotedDoNotAllowFurtherChanges();

            var periodBuilderMsg = new MsgPeriodBuilder();
            period.BuildValue(periodBuilderMsg);

            var workPeriodBuilderMsg = new MsgWorkPeriodBuilder();
            workPeriod.BuildValue((workPeriodBuilderMsg));

            var evt = BuildEvt.SchedulazioneAmbAddedToScenario
                .ForAppaltatore(idAppaltatore)
                .ForCategoriaCommerciale(idCategoriaCommerciale)
                .ForCommittente(idCommittente)
                .ForDescription(description)
                .ForDirezioneRegionale(idDirezioneRegionale)
                .ForImpianto(idImpianto)
                .ForLotto(idLotto)
                .ForPeriod(periodBuilderMsg.Build())
                .ForPeriodoProgrammazione(idPeriodoProgrammazione)
                .ForQuantity(quantity)
                .ForSchedulazione(idSchedulazione)
                .ForWorkPeriod(workPeriodBuilderMsg.Build())
                .OfTipoIntervento(idTipoIntervento)
                .WithNote(note);

            RaiseEvent(evt);
        }

        public void Apply(SchedulazioneAmbAddedToScenario e)
        {
            //do something ??

        }
    }
}
