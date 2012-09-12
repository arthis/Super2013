using System;
using System.Collections.Generic;
using CommonDomain;
using CommonDomain.Core.Handlers.Commands;
using CommonDomain.Persistence;
using NUnit.Framework;
using CommonSpecs;
using Super.Programmazione.Commands;
using Super.Programmazione.Commands.System;
using Super.Programmazione.Events;
using Super.Programmazione.Handlers.Commands.System;

namespace Super.Programmazione.Specs.System
{
    public class il_sistema_aggiunge_un_utente : CommandBaseClass<AddUserToSystem>
    {
        private Guid _id = Guid.NewGuid();
        private string _lastName = "lastname";
        private string _firstName = "firstName";
        

        public override string ToDescription()
        {
            return "Il sistema aggiunge un utente per poter interagire con la programmazione";
        }


        protected override CommandHandler<AddUserToSystem> OnHandle(IEventRepository eventRepository)
        {
            return new AddUserToSystemHandler(eventRepository);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield break;
        }

        public override AddUserToSystem When()
        {
            return BuildCmd.AddUserToSystem
                .WithFirstName(_firstName)
                .WithLastName(_lastName)
                .Build(_id, 1);
        }

        public override IEnumerable<IMessage> Expect()
        {
            yield return BuildEvt.UserAddedToSystem
                .WithFirstName(_firstName)
                .WithLastName(_lastName)
                .Build(_id, 1);
        }

        [Test]
        public void non_genera_un_eccezzione()
        {
            Assert.IsNull(Caught);
        }


    }
}
