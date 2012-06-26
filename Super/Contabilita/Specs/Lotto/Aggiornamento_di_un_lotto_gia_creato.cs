using System;
using System.Collections.Generic;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Persistence;
using NUnit.Framework;
using CommonSpecs;
using Super.Contabilita.Commands.Lotto;
using Super.Contabilita.Events.Lotto;
using Super.Contabilita.Handlers;
using CommonDomain.Core.Super.Messaging.ValueObjects;
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
        

        
        protected override CommandHandler<UpdateLotto> OnHandle(IRepository repository)
        {
            return new UpdateLottoHandler(repository);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield return  BuildEvt.LottoCreated
                                   .ForCreationDate(_creationDate)
                                   .ForDescription(_descriptionUpdated)
                                   .ForIntervall(_intervall)
                                   .Build(_id);
        }

        public override UpdateLotto When()
        {
            return BuildCmd.UpdateLotto
                            .ForIntervall(_intervallUpdated)
                            .ForDescription(_description)
                            .Build(_id);
        }

        public override IEnumerable<IMessage> Expect()
        {
            yield return BuildEvt.LottoUpdated
                .ForDescription(_description)
                .ForIntervall(_intervall)
                .Build(_id);
                            
        }

        [Test]
        public void non_genera_un_eccezzione()
        {
            Assert.IsNull(Caught);
        }


    }
}
