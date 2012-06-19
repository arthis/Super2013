using System;
using System.Collections.Generic;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Super.Domain.ValueObjects;
using CommonDomain.Persistence;
using NUnit.Framework;
using CommonSpecs;
using Super.Administration.Commands.AreaIntervento;
using Super.Administration.Events.AreaIntervento;
using Super.Administration.Events.Builders;
using Super.Administration.Handlers;
using RollonPeriod = CommonDomain.Core.Super.Messaging.ValueObjects.RollonPeriod;

namespace Super.Administration.Specs.AreaIntervento
{
    public class Aggiornamento_di_una_area_intervento_gia_creata : CommandBaseClass<UpdateAreaIntervento>
    {
        private Guid _id = Guid.NewGuid();
        private string _description = "test";
        private DateTime _creationDate = DateTime.Now;
        private long _version;
        private CommonDomain.Core.Super.Messaging.ValueObjects.RollonPeriod _rollonPeriod = new RollonPeriod(DateTime.Now.AddHours(1), DateTime.Now.AddHours(2));

        private string _DescriptionUpdated = "test 2";
        private DateTime _StartUpdated = DateTime.Now.AddHours(14);
        private DateTime _EndUpdated = DateTime.Now.AddHours(15);

        
        protected override CommandHandler<UpdateAreaIntervento> OnHandle(IRepository repository)
        {
            return new UpdateAreaInterventoHandler(repository);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield return new AreaInterventoCreated(
                            id: _id,
                            version: _version,
                            period: _rollonPeriod,
                            creationDate: _creationDate,
                            description: _description);
        }

        public override UpdateAreaIntervento When()
        {
            return new UpdateAreaIntervento()
                       {
                           Id = _id,
                           Start = _StartUpdated,
                           End = _EndUpdated,
                           Description = _DescriptionUpdated,
                           Headers = Headers
                       };
        }

        public override IEnumerable<IMessage> Expect()
        {
            yield return new AreaInterventoUpdated()
            {
                Id = _id,
                Start = _StartUpdated,
                End = _EndUpdated,
                Description = _DescriptionUpdated,
                Headers = Headers
            };
        }

        [Test]
        public void non_genera_un_eccezzione()
        {
            Assert.IsNull(Caught);
        }


    }
}
