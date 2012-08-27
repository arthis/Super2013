using System;
using System.Collections.Generic;
using CommonDomain;
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
    public class Cancellazione_di_una_unita_di_misura_gia_creata : CommandBaseClass<DeleteMeasuringUnit>
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
        }

        public override DeleteMeasuringUnit When()
        {
            return BuildCmd.DeleteMeasuringUnit
                .Build(_id, 1);
        }

        public override IEnumerable<IMessage> Expect()
        {
            yield return BuildEvt.MeasuringUnitDeleted
                .Build(_id, 2);
        }

        [Test]
        public void non_genera_un_eccezzione()
        {
            Assert.IsNull(Caught);
        }

    }
}
