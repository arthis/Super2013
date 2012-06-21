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
    public class Creazione_di_una_nuova_area_intervento_gia_creata : CommandBaseClass<CreateAreaIntervento>
    {
        private Guid _id = Guid.NewGuid();
        private string _description = "test";
        private DateTime _creationDate = DateTime.Now;
        private long _version;
        private Intervall _intervall = new Intervall(DateTime.Now.AddHours(1), DateTime.Now.AddHours(2));

        public override string ToDescription()
        {
            return "Creare un'area intervento gia creata con il stesso Guid non é possibile";
        }
       

        protected override CommandHandler<CreateAreaIntervento> OnHandle(IRepository repository)
        {
            return new CreateAreaInterventoHandler(repository);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield return new AreaInterventoCreated(
                id: _id,
                version: _version,
                period: _intervall,
                creationDate: _creationDate,
                description: _description);
        }

        public override CreateAreaIntervento When()
        {
            return new CreateAreaIntervento(
                                    id: _id,
                                    version: _version,
                                    period: _intervall,
                                    creationDate: _creationDate,
                                    description: _description); 
        }

        public override IEnumerable<IMessage> Expect()
        {
            yield break;
        }

        [Test]
        public void genera_un_eccezzione()
        {
            Assert.IsNotNull(Caught);
            Assert.AreEqual(typeof(AlreadyCreatedAggregateRootException), Caught.GetType());
        }


    }
}
