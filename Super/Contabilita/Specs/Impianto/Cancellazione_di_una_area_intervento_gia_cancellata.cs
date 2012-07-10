using System;
using System.Collections.Generic;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Handlers;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using CommonDomain.Persistence;
using NUnit.Framework;
using CommonSpecs;
using Super.Contabilita.Commands.Impianto;
using Super.Contabilita.Events.Impianto;
using Super.Contabilita.Handlers;
using BuildEvt = Super.Contabilita.Events.Builders.Build;
using BuildCmd = Super.Contabilita.Commands.Builders.Build;

namespace Super.Contabilita.Specs.Impianto
{
    public class Cancellazione_di_una_impianto_gia_cancellata : CommandBaseClass<DeleteImpianto>
    {
        private Guid _id = Guid.NewGuid();
        private string _description = "test";
        private DateTime _creationDate = DateTime.Now;
        private Guid _idLotto = Guid.NewGuid();
        private long _version;
        private Intervall _intervall = new Intervall(DateTime.Now.AddHours(1), DateTime.Now.AddHours(2));

        protected override CommandHandler<DeleteImpianto> OnHandle(IEventRepository eventRepository)
        {
            return new DeleteImpiantoHandler(eventRepository);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield return BuildEvt.ImpiantoCreated
                .ForIntervall(_intervall)
                .ForDescription(_description)
                .ForCreationDate(_creationDate)
                .ForLotto(_idLotto)
                .Build(_id,1);
            yield return BuildEvt.ImpiantoDeleted
                .Build(_id, 2);
        }

        public override DeleteImpianto When()
        {
            return BuildCmd.DeleteImpianto
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
