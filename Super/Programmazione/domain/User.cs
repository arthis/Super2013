using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonDomain.Core;
using Super.Programmazione.Events;
using Super.Programmazione.Events.System;

namespace Super.Programmazione.Domain
{
    public class User : AggregateBase
    {
        public User(Guid id, string firstName, string lastName, string username, string password)
        {
            var evt = BuildEvt.UserAddedToSystem
                .WithFirstName(firstName)
                .WithLastName(lastName)
                .ForUserName(username)
                .ForPassword(password);


            RaiseEvent(id, evt);
        }

        public void Apply(UserAddedToSystem evt)
        {
            
        }
    }
}
