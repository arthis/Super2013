using System;
using System.Collections.Generic;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Handlers;
using CommonDomain.Persistence;
using NUnit.Framework;
using CommonSpecs;
using Super.Contabilita.Commands;
using Super.Contabilita.Commands.MeasuringUnit;
using Super.Contabilita.Events;
using Super.Contabilita.Handlers.MeasuringUnit;

namespace Super.Contabilita.Specs.MeasuringUnit
{
    public class Creazione_di_una_nuova_unita_di_misura_gia_creata : CommandBaseClass<CreateMeasuringUnit>
    {
        private Guid _id = Guid.NewGuid();
        private string _description = "test";

        public override string ToDescription()
        {
            return "Creare un'unita_di_misura gia creata con il stesso Guid non é possibile";
        }
       

        protected override CommandHandler<CreateMeasuringUnit> OnHandle(IEventRepository eventRepository)
        {
            return new CreateMeasuringUnitHandler(eventRepository);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield return BuildEvt.MeasuringUnitCreated
                .ForDescription(_description)
                .Build(_id, 1);
        }

        public override CreateMeasuringUnit When()
        {
            return BuildCmd.CreateMeasuringUnit
                .ForDescription(_description)
                .Build(_id, 1);
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
