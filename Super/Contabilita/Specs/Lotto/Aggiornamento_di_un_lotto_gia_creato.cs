using System;
using System.Collections.Generic;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Handlers;
using CommonDomain.Persistence;
using Moq;
using NUnit.Framework;
using CommonSpecs;
using Super.Contabilita.Commands.Lotto;
using Super.Contabilita.Events.Lotto;
using Super.Contabilita.Handlers;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using Super.Contabilita.Handlers.Repositories;
using BuildCmd = Super.Contabilita.Commands.Builders.Build;
using BuildEvt = Super.Contabilita.Events.Builders.Build;

namespace Super.Contabilita.Specs.Lotto
{
    public class Aggiornamento_di_un_lotto_gia_creato : CommandBaseClass<UpdateLotto>
    {
        private Guid _id = Guid.NewGuid();
        private string _description = "test";
        private DateTime _creationDate = DateTime.Now;
        private long _version; 
        private Intervall _intervall = new Intervall(DateTime.Now.AddHours(1), DateTime.Now.AddHours(2));

        private string _descriptionUpdated = "test 2";
        private Intervall _intervallUpdated = new Intervall(DateTime.Now.AddHours(14), DateTime.Now.AddHours(15));
        

        
        protected override CommandHandler<UpdateLotto> OnHandle(IEventRepository eventRepository)
        {
            var mock = new Mock<ILottoRepository>();
            return new UpdateLottoHandler(eventRepository, mock.Object);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield return  BuildEvt.LottoCreated
                                   .ForCreationDate(_creationDate)
                                   .ForDescription(_descriptionUpdated)
                                   .ForIntervall(_intervall)
                                   .Build(_id,1);
        }

        public override UpdateLotto When()
        {
            return BuildCmd.UpdateLotto
                            .ForIntervall(_intervallUpdated)
                            .ForDescription(_descriptionUpdated)
                            .Build(_id,1);
        }

        public override IEnumerable<IMessage> Expect()
        {
            yield return BuildEvt.LottoUpdated
                .ForDescription(_descriptionUpdated)
                .ForIntervall(_intervallUpdated)
                .Build(_id,2);
                            
        }

        [Test]
        public void non_genera_un_eccezzione()
        {
            Assert.IsNull(Caught);
        }


    }
}
