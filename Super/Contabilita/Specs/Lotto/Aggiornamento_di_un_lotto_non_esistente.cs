using System;
using System.Collections.Generic;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Handlers;
using CommonDomain.Core.Handlers.Commands;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using CommonDomain.Persistence;
using Moq;
using NUnit.Framework;
using CommonSpecs;
using Super.Contabilita.Commands;
using Super.Contabilita.Commands.Lotto;
using Super.Contabilita.Commands.Builders;
using Super.Contabilita.Handlers;
using Super.Contabilita.Handlers.Commands.Lotto;
using Super.Contabilita.Handlers.Repositories;

namespace Super.Contabilita.Specs.Lotto
{
    public class Aggiornamento_di_un_lotto_non_esistente : CommandBaseClass<UpdateLotto>
    {
        private Guid _id = Guid.NewGuid();
        private string _description = "test";
        private DateTime _creationDate = DateTime.Now;
        private long _version;
        private Interval _interval = new Interval(DateTime.Now.AddHours(1), DateTime.Now.AddHours(2));

        private string _descriptionUpdated = "test 2";
        private Interval _intervalUpdated = new Interval(DateTime.Now.AddHours(14), DateTime.Now.AddHours(15));
        


        protected override CommandHandler<UpdateLotto> OnHandle(IEventRepository eventRepository)
        {
            var mock = new Mock<ILottoRepository>();
            return new UpdateLottoHandler(eventRepository, mock.Object);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield break;
        }

        public override UpdateLotto When()
        {
            return  BuildCmd.UpdateLotto
                         .ForDescription(_description)
                         .ForInterval(_intervalUpdated)
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
            Assert.AreEqual(typeof(AggregateRootInstanceNotFoundException), Caught.GetType());
        }


    }
}
