using System;
using System.Collections.Generic;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Persistence;
using EventStore;
using NUnit.Framework;
using CommonSpecs;
using Super.Contabilita.Commands.Lotto;
using Super.Contabilita.Handlers;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using BuildCmd = Super.Contabilita.Commands.Builders.Build;
using BuildEvt = Super.Contabilita.Events.Builders.Build;

namespace Super.Contabilita.Specs.Lotto
{
    public class non_riprocessare_un_commando_gia_letto : CommandBaseClass<UpdateLotto>
    {
        private Guid _id = Guid.NewGuid();
        private string _description = "test";
        private DateTime _creationDate = DateTime.Now;
        private long _version;
        private Intervall _intervall = new Intervall(DateTime.Now.AddHours(1), DateTime.Now.AddHours(2));

        private string _descriptionUpdated = "test 2";
        private Intervall _intervallUpdated = new Intervall(DateTime.Now.AddHours(14), DateTime.Now.AddHours(15));
        private Guid _updateCommitId = Guid.NewGuid();
        

        
        protected override CommandHandler<UpdateLotto> OnHandle(IEventRepository eventRepository)
        {
            return new UpdateLottoHandler(eventRepository);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield return BuildEvt.LottoCreated
                                   .ForCreationDate(_creationDate)
                                   .ForDescription(_descriptionUpdated)
                                   .ForIntervall(_intervall)
                                   .Build(_id,1);
            var evt = BuildEvt.LottoUpdated
                .ForDescription(_description)
                .ForIntervall(_intervall)
                .Build(_id,2);
            evt.CommitId = _updateCommitId;
            yield return evt;
        }

        public override UpdateLotto When()
        {
            return BuildCmd.UpdateLotto
                            .ForIntervall(_intervallUpdated)
                            .ForDescription(_description)
                            .Build(_id, _updateCommitId,2);
        }

        public override IEnumerable<IMessage> Expect()
        {
            yield break;
                            
        }

        [Test]
        public void genera_un_eccezzione()
        {
            Assert.IsNotNull(Caught);
            Assert.AreEqual(typeof(DuplicateCommitException), Caught.GetType());
        }


    }
}
