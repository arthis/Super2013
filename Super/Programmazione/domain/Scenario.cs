using System;
using CommonDomain.Core;
using Super.Programmazione.Domain.Exceptions;
using Super.Programmazione.Events;
using Super.Programmazione.Events.Scenario;

namespace Super.Programmazione.Domain
{
    public class Scenario : AggregateBase
    {
        private bool _deleted;
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
            if (_deleted)
                throw new ScenarioCancelledDoNotAllowFurtherChanges();

            if (_promoted)
                throw new ScenarioPromotedDoNotAllowChangingDescription();

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
                throw new ScenarioPromotedDoNotAllowChangingDescription();

            if (!_deleted)
            {
                var evt = BuildEvt.ScenarioCancelled
                    .ByUser(userId);

                RaiseEvent(evt);
            }
        }

        public void Apply(ScenarioCancelled e)
        {
            _deleted = true;
        }


        public void PromoteToPlan(Guid userId,DateTime promotingDate)
        {
            if (_deleted)
                throw new ScenarioCancelledDoNotAllowFurtherChanges();

            if (_promoted)
                throw new ScenarioPromotedDoNotAllowChangingDescription();

            var evt = BuildEvt.ScenarioPromotedToPlan
                .ByUser(userId)
                .When(promotingDate);


            RaiseEvent(evt);
        }

        public void Apply(ScenarioPromotedToPlan e)
        {
            _promoted = true;
        }
    }
}
