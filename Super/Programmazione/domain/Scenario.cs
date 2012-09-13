﻿using System;
using CommonDomain.Core;
using Super.Programmazione.Domain.Exceptions;
using Super.Programmazione.Events;
using Super.Programmazione.Events.Scenario;

namespace Super.Programmazione.Domain
{
    public class Scenario : AggregateBase
    {
        private bool _deleted;

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
            if(_deleted)
                throw  new ScenarioCancelledDoNotAllowChangingDescription();

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


    }
}
