using System;
using System.Collections.Generic;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using CommonDomain.Persistence;
using NUnit.Framework;
using CommonSpecs;
using Super.Contabilita.Commands.Lotto;
using Super.Contabilita.Events.Lotto;
using Super.Contabilita.Events.Builders;
using Super.Contabilita.Handlers;

namespace Super.Contabilita.Specs.Lotto
{
    public class Cancellazione_di_un_lotto_gia_cancellato : CommandBaseClass<DeleteLotto>
    {
        private Guid _id = Guid.NewGuid();
        private string _description = "test";
        private DateTime _creationDate = DateTime.Now;
        private long _version;
        private Intervall _intervall = new Intervall(DateTime.Now.AddHours(1), DateTime.Now.AddHours(2));

        protected override CommandHandler<DeleteLotto> OnHandle(IRepository repository)
        {
            return new DeleteLottoHandler(repository);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield return Build.LottoCreated
                .ForIntervall(_intervall)
                .ForDescription(_description)
                .ForCreationDate(_creationDate)
                .Build(_id);
            yield return new LottoDeleted()
            {
                Id = _id
            };
        }

        public override DeleteLotto When()
        {
            return new DeleteLotto()
                       {
                           Id = _id
                       };
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
