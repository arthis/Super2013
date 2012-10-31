using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonDomain.Core;
using Super.Programmazione.Domain.Programma;
using Super.Programmazione.Events;
using Super.Programmazione.Events.System;

namespace Super.Programmazione.Domain
{
    public class User : AggregateBase
    {
        public User()
        {
            
        }

        public User(Guid id, string firstName, string lastName)
        {
            var evt = BuildEvt.UserAddedToSystem
                .WithFirstName(firstName)
                .WithLastName(lastName);


            RaiseEvent(id, evt);
        }

        public void Apply(UserAddedToSystem evt)
        {
            Id = evt.Id;
        }

        public Scenario CreateScenario(Guid idScenario, Guid idProgrammma,  string description)
        {
            return new Scenario(idScenario, Id, description, idProgrammma);
        }


        public void CancelScenario(Scenario scenario)
        {
            scenario.Cancel(Id);
        }

        public void PromoteToPlan(Scenario scenario, DateTime promotionDate, Guid idPlan)
        {
            scenario.PromoteToPlan(Id,promotionDate,idPlan);
        }
    }
}
