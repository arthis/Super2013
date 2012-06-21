using System;
using System.Collections.Generic;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using CommonDomain.Persistence;
using NUnit.Framework;
using CommonSpecs;
using Super.Administration.Commands.AreaIntervento;
using Super.Administration.Events.AreaIntervento;
using Super.Administration.Handlers;

namespace Super.Administration.Specs.AreaIntervento
{
    public class Cancellazione_di_una_area_intervento_gia_cancellata : CommandBaseClass<DeleteAreaIntervento>
    {
        private Guid _id = Guid.NewGuid();
        private string _description = "test";
        private DateTime _creationDate = DateTime.Now;
        private long _version;
        private Intervall _intervall = new Intervall(DateTime.Now.AddHours(1), DateTime.Now.AddHours(2));

        protected override CommandHandler<DeleteAreaIntervento> OnHandle(IRepository repository)
        {
            return new DeleteAreaInterventoHandler(repository);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield return new AreaInterventoCreated(
                id: _id,
                version: _version,
                period: _intervall,
                creationDate: _creationDate,
                description: _description);
            yield return new AreaInterventoDeleted()
            {
                Id = _id
            };
        }

        public override DeleteAreaIntervento When()
        {
            return new DeleteAreaIntervento()
                       {
                           Id = _id
                       };
        }

        public override IEnumerable<IMessage> Expect()
        {
            yield break;
        }

        [Test]
        public void non_genera_un_eccezzione()
        {
            Assert.IsNull(Caught);
        }


    }
}
