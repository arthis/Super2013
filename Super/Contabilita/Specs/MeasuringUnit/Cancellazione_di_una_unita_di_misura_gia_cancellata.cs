using System;
using System.Collections.Generic;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Handlers;
using CommonDomain.Core.Handlers.Commands;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using CommonDomain.Persistence;
using NUnit.Framework;
using CommonSpecs;
using Super.Contabilita.Commands;
using Super.Contabilita.Commands.MeasuringUnit;
using Super.Contabilita.Events;
using Super.Contabilita.Handlers.MeasuringUnit;

namespace Super.Contabilita.Specs.MeasuringUnit
{
    public class Cancellazione_di_una_unita_di_misura_gia_cancellata : CommandBaseClass<DeleteMeasuringUnit>
    {
        private Guid _id = Guid.NewGuid();
        private string _description = "test";
        

        protected override CommandHandler<DeleteMeasuringUnit> OnHandle(IEventRepository eventRepository)
        {
            return new DeleteMeasuringUnitHandler(eventRepository);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield return BuildEvt.MeasuringUnitCreated
                .ForDescription(_description)
                .Build(_id,1);
            yield return BuildEvt.MeasuringUnitDeleted
                .Build(_id, 2);
        }

        public override DeleteMeasuringUnit When()
        {
            return BuildCmd.DeleteMeasuringUnit
                .Build(_id, 2);
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
