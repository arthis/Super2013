using System;
using System.Collections.Generic;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Handlers;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using CommonDomain.Persistence;
using Moq;
using NUnit.Framework;
using CommonSpecs;
using Super.Contabilita.Commands.Lotto;
using Super.Contabilita.Commands.Builders;
using Super.Contabilita.Handlers;
using Super.Contabilita.Handlers.Repositories;
using BuildCmd = Super.Contabilita.Commands.Builders.Build;
using BuildEvt = Super.Contabilita.Events.Builders.Build;

namespace Super.Contabilita.Specs.Lotto
{
    public class Aggiornamento_di_un_lotto_con_Impianti : CommandBaseClass<UpdateLotto>
    {
        private Guid _id = Guid.NewGuid();
        private string _description = "test";
        private DateTime _creationDate = DateTime.Now;
        private long _version;
        private Intervall _intervall = new Intervall(DateTime.Now.AddHours(1), DateTime.Now.AddHours(10));
        

        private Guid _IdImpianto = Guid.NewGuid();
        private string _descriptionImpianto = "test";
        private DateTime _creationDateImpianto = DateTime.Now;
        private Intervall _intervallImpianto = new Intervall(DateTime.Now.AddHours(2), DateTime.Now.AddHours(3));


        private Intervall _intervallUpdated = new Intervall(DateTime.Now.AddHours(3), DateTime.Now.AddHours(10));


        protected override CommandHandler<UpdateLotto> OnHandle(IEventRepository eventRepository)
        {
            var mock = new Mock<ILottoRepository>();
            mock.Setup(x => x.AreImpiantoAssociatedWihtinIntervall(It.IsAny<Guid>(), It.IsAny<Intervall>()))
                .Returns(false);
            return new UpdateLottoHandler(eventRepository, mock.Object);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield return BuildEvt.LottoCreated
                                   .ForCreationDate(_creationDate)
                                   .ForDescription(_description)
                                   .ForIntervall(_intervall)
                                   .Build(_id, 1);
            yield return BuildEvt.ImpiantoCreated
                                   .ForCreationDate(_creationDate)
                                   .ForDescription(_description)
                                   .ForIntervall(_intervall)
                                   .ForLotto(_id)
                                   .Build(_IdImpianto, 1);
        }

        public override UpdateLotto When()
        {

            return  Build.UpdateLotto
                         .ForDescription(_description)
                         .ForIntervall(_intervallUpdated)
                         .Build(_id,0);
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
