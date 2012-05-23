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
    public class Creation_of_a_new_area_intervento : CommandBaseClass<CreateAreaIntervento>
    {
        private Guid _Id = Guid.NewGuid();
        private string _Description = "test";
        private DateTime _Start = DateTime.Now.AddHours(12);
        private DateTime _End = DateTime.Now.AddHours(13);
        private DateTime _CreationDate = DateTime.Now;

        protected override CommandHandler<CreateAreaIntervento> OnHandle(IRepository repository)
        {
            return new CreateAreaInterventoHandler(repository);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield break;
        }

        public override CreateAreaIntervento When()
        {
            return new CreateAreaIntervento(_Id, _Start, _End, _Description, _CreationDate);
        }

        public override IEnumerable<IMessage> Expect()
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

        [Test]
        public void It_does_not_throw_an_Exception()
        {
            Assert.IsNull(Caught);
        }


    }
}
