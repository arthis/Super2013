using System;
using System.Collections.Generic;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Persistence;
using NUnit.Framework;
using CommonSpecs;
using Super.Administration.Commands.AreaIntervento;
using Super.Administration.Events.AreaIntervento;
using Super.Administration.Handlers;

namespace Super.Administration.Specs.AreaIntervento
{
    public class Cancellazione_di_una_area_intervento_non_esistente : CommandBaseClass<DeleteAreaIntervento>
    {
        private Guid _Id = Guid.NewGuid();
        private string _Description = "test";
        private DateTime _Start = DateTime.Now.AddHours(12);
        private DateTime _End = DateTime.Now.AddHours(13);
        private DateTime _CreationDate = DateTime.Now;

        protected override CommandHandler<DeleteAreaIntervento> OnHandle(IRepository repository)
        {
            return new DeleteAreaInterventoHandler(repository);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield break;
        }

        public override DeleteAreaIntervento When()
        {
            return new DeleteAreaIntervento(_Id);
        }

        public override IEnumerable<IMessage> Expect()
        {
            yield break;
        }

        [Test]
        public void genera_un_eccezzione()
        {
            Assert.IsNotNull(Caught);
            Assert.AreEqual(typeof(AggregateRootInstanceNotFoundException), Caught.GetType());
        }


    }
}
