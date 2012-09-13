using System;
using CommonDomain.Core;
using Super.Programmazione.Events;
using Super.Programmazione.Events.Scenario;

namespace Super.Programmazione.Domain
{
    public class Scenario : AggregateBase
    {
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
            var evt = BuildEvt.DescriptionOfScenarioChanged
               .ForDescription(description);

            RaiseEvent(evt);
        }

        public void Apply(DescriptionOfScenarioChanged e)
        {
            //do nothing
        }


    }
}
