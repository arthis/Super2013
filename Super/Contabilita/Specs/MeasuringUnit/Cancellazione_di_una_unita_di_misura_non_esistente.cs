using System;
using System.Collections.Generic;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Handlers;
using CommonDomain.Persistence;
using NUnit.Framework;
using CommonSpecs;
using Super.Contabilita.Commands.MeasuringUnit;
using BuildCmd = Super.Contabilita.Commands.Builders.Build;
using BuildEvt = Super.Contabilita.Events.Builders.Build;
using Super.Contabilita.Handlers.MeasuringUnit;

namespace Super.Contabilita.Specs.MeasuringUnit
{
    public class Cancellazione_di_una_unita_di_misura_non_esistente : CommandBaseClass<DeleteMeasuringUnit>
    {
        private Guid _id = Guid.NewGuid();

        protected override CommandHandler<DeleteMeasuringUnit> OnHandle(IEventRepository eventRepository)
        {
            return new DeleteMeasuringUnitHandler(eventRepository);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield break;
        }

        public override DeleteMeasuringUnit When()
        {
            return BuildCmd.DeleteMeasuringUnit
                .Build(_id,0);
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
