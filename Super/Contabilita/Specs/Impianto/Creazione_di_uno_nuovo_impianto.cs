using System;
using System.Collections.Generic;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Handlers;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using CommonDomain.Persistence;
using NUnit.Framework;
using CommonSpecs;
using Super.Contabilita.Commands;
using Super.Contabilita.Commands.Impianto;
using Super.Contabilita.Commands.Builders;
using Super.Contabilita.Events;
using Super.Contabilita.Events.Impianto;
using Super.Contabilita.Handlers;
using Super.Contabilita.Handlers.Impianto;

namespace Super.Contabilita.Specs.Impianto
{
    public class Creazione_di_uno_nuovo_impianto : CommandBaseClass<CreateImpianto>
    {
        private Guid _id = Guid.NewGuid();
        private string _description = "test";
        private DateTime _creationDate = DateTime.Now;
        private long _version;
        private Interval _interval = new Interval(DateTime.Now.AddHours(1), DateTime.Now.AddHours(2));
        private Guid _idLotto = Guid.NewGuid();
        private Interval _intervalLotto = new Interval(DateTime.Now, DateTime.Now.AddHours(4));
        

        protected override CommandHandler<CreateImpianto> OnHandle(IEventRepository eventRepository)
        {
            return new CreateImpiantoHandler(eventRepository);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield return BuildEvt.LottoCreated
                .ForDescription("lotto")
                .ForInterval(_intervalLotto)
                .Build(_idLotto, 0);

        }

        public override CreateImpianto When()
        {
            return BuildCmd.CreateImpianto
                .ForDescription(_description)
                .ForLotto(_idLotto)
                .ForInterval(_interval)
                .Build(_id, 1);
        }

        public override IEnumerable<IMessage> Expect()
        {
            yield return BuildEvt.ImpiantoCreated
                                 .ForDescription(_description)
                                 .ForLotto(_idLotto)
                                 .ForInterval(_interval)
                                 .Build(_id,1);
        }

        [Test]
        public void non_genera_un_eccezzione()
        {
            Assert.IsNull(Caught);
        }


    }
}
