using System;
using System.Collections.Generic;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Persistence;
using NUnit.Framework;
using CommonSpecs;
using Super.Administration.Commands.AreaIntervento;
using Super.Administration.Events.AreaIntervento;
using Super.Administration.Events.Builders;
using Super.Administration.Handlers;
using CommonDomain.Core.Super.Messaging.ValueObjects;

namespace Super.Administration.Specs.AreaIntervento
{
    public class Aggiornamento_di_una_area_intervento_gia_creata : CommandBaseClass<UpdateAreaIntervento>
    {
        private Guid _id = Guid.NewGuid();
        private string _description = "test";
        private DateTime _creationDate = DateTime.Now;
        private long _version;
        private Intervall _intervall = new Intervall(DateTime.Now.AddHours(1), DateTime.Now.AddHours(2));

        private string _descriptionUpdated = "test 2";
        private Intervall _intervallUpdated = new Intervall(DateTime.Now.AddHours(14), DateTime.Now.AddHours(15));
        

        
        protected override CommandHandler<UpdateAreaIntervento> OnHandle(IRepository repository)
        {
            return new UpdateAreaInterventoHandler(repository);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield return new AreaInterventoCreated(
                            id: _id,
                            version: _version,
                            period: _intervall,
                            creationDate: _creationDate,
                            description: _descriptionUpdated);
        }

        public override UpdateAreaIntervento When()
        {
            return new UpdateAreaIntervento(
                            id: _id,
                            version: _version,
                            period: _intervallUpdated,
                            description: _description);
        }

        public override IEnumerable<IMessage> Expect()
        {
            yield return new UpdateAreaIntervento(
                            id: _id,
                            version: _version,
                            period: _intervall,
                            description: _description);
        }

        [Test]
        public void non_genera_un_eccezzione()
        {
            Assert.IsNull(Caught);
        }


    }
}
