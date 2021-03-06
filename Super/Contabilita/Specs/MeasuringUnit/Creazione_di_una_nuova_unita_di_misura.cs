﻿using System;
using System.Collections.Generic;
using CommonDomain;
using CommonDomain.Core.Handlers;
using CommonDomain.Core.Handlers.Commands;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using CommonDomain.Persistence;
using NUnit.Framework;
using CommonSpecs;
using Super.Contabilita.Commands;
using Super.Contabilita.Commands.MeasuringUnit;
using Super.Contabilita.Events;
using Super.Contabilita.Handlers.Commands.MeasuringUnit;

namespace Super.Contabilita.Specs.MeasuringUnit
{
    public class Creazione_di_una_nuova_unita_di_misura : CommandBaseClass<CreateMeasuringUnit>
    {
        private Guid _id = Guid.NewGuid();
        private string _description = "test";
        

        protected override CommandHandler<CreateMeasuringUnit> OnHandle(IEventRepository eventRepository)
        {
            return new CreateMeasuringUnitHandler(eventRepository);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield break;
        }

        public override CreateMeasuringUnit When()
        {
            return BuildCmd.CreateMeasuringUnit
                .ForDescription(_description)
                .Build(_id, 1);
        }

        public override IEnumerable<IMessage> Expect()
        {
            yield return BuildEvt.MeasuringUnitCreated
                                 .ForDescription(_description)
                                 .Build(_id,1);
        }

        [Test]
        public void non_genera_un_eccezzione()
        {
            Assert.IsNull(Caught);
        }


    }
}
