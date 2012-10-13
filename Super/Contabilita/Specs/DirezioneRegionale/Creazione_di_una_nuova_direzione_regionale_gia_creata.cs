using System;
using System.Collections.Generic;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Handlers;
using CommonDomain.Core.Handlers.Commands;
using CommonDomain.Persistence;
using NUnit.Framework;
using CommonSpecs;
using Super.Contabilita.Commands;
using Super.Contabilita.Commands.DirezioneRegionale;
using Super.Contabilita.Events;
using Super.Contabilita.Handlers.Commands.DirezioneRegionale;

namespace Super.Contabilita.Specs.DirezioneRegionale
{
    public class Creazione_di_una_nuova_direzione_regionale_gia_creata : CommandBaseClass<CreateDirezioneRegionale>
    {
        private Guid _id = Guid.NewGuid();
        private string _description = "test";

        public override string ToDescription()
        {
            return "Creare un'direzione_regionale gia creata con il stesso Guid non é possibile";
        }
       

        protected override CommandHandler<CreateDirezioneRegionale> OnHandle(IEventRepository eventRepository)
        {
            return new CreateDirezioneRegionaleHandler(eventRepository);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield return BuildEvt.DirezioneRegionaleCreated
                .ForDescription(_description)
                .Build(_id, 1);
        }

        public override CreateDirezioneRegionale When()
        {
            return BuildCmd.CreateDirezioneRegionale
                .ForDescription(_description)
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
            Assert.AreEqual(typeof(AlreadyCreatedAggregateRootException), Caught.GetType());
        }


    }
}
