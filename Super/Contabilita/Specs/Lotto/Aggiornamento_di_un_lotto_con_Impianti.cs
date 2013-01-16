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
using Super.Contabilita.Events;
using Super.Contabilita.Handlers;
using Super.Contabilita.Handlers.Commands.Lotto;
using Super.Contabilita.Handlers.Repositories;

namespace Super.Contabilita.Specs.Lotto
{
    public class Aggiornamento_di_un_lotto_con_Impianti : CommandBaseClass<UpdateLotto>
    {
        private Guid _id = Guid.NewGuid();
        private string _description = "test";
        private DateTime _creationDate = DateTime.Now;
        
        private Interval _interval = new Interval(DateTime.Now.AddHours(1), DateTime.Now.AddHours(10));
        

        private Guid _IdImpianto = Guid.NewGuid();
        
        private DateTime _creationDateImpianto = DateTime.Now;
        private Interval _intervalImpianto = new Interval(DateTime.Now.AddHours(2), DateTime.Now.AddHours(3));


        private Interval _intervalUpdated = new Interval(DateTime.Now.AddHours(3), DateTime.Now.AddHours(10));


        protected override CommandHandler<UpdateLotto> OnHandle(IEventRepository eventRepository)
        {
            var mock = new Mock<ILottoRepository>();
            mock.Setup(x => x.AreImpiantoAssociatedOutOfInterval(It.IsAny<Guid>(), It.IsAny<Interval>()))
                .Returns(true);
            return new UpdateLottoHandler(eventRepository, mock.Object);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield return BuildEvt.LottoCreated
                                   .ForDescription(_description)
                                   .ForInterval(_interval)
                                   .Build(_id, 1);
            yield return BuildEvt.ImpiantoCreated
                                   .ForDescription(_description)
                                   .ForInterval(_interval)
                                   .ForLotto(_id)
                                   .Build(_IdImpianto, 1);
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
        public void Genera_un_eccezzione()
        {
            Assert.IsNotNull(Caught);
            Assert.IsInstanceOf<CommandValidationException>(Caught);
        }


    }
}
