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
    public class Deletion_of_an_area_intervento : CommandBaseClass<DeleteAreaIntervento>
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

        public override IEnumerable<IEvent> Given()
        {
            yield return new AreaInterventoCreated()
            {
                Id = _Id,
                Description = _Description,
                CreationDate = _CreationDate,
                End = _End,
                Start = _Start
            };
        }

        public override DeleteAreaIntervento When()
        {
            return new DeleteAreaIntervento(_Id);
        }

        public override IEnumerable<IEvent> Expect()
        {
            yield return new AreaInterventoDeleted()
            {
                Id = _Id
            };
        }

        [Test]
        public void It_does_not_throw_an_Exception()
        {
            Assert.IsNull(Caught);
        }


    }
}
