using System;
using System.Collections.Generic;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Handlers;
using CommonDomain.Core.Handlers.Commands;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using CommonDomain.Persistence;
using NUnit.Framework;
using CommonSpecs;
using Super.Contabilita.Commands;
using Super.Contabilita.Commands.DirezioneRegionale;
using Super.Contabilita.Commands.Builders;
using Super.Contabilita.Handlers;
using Super.Contabilita.Handlers.Commands.DirezioneRegionale;

namespace Super.Contabilita.Specs.DirezioneRegionale
{
    public class Aggiornamento_di_una_direzione_regionale_non_esistente : CommandBaseClass<UpdateDirezioneRegionale>
    {
        private Guid _id = Guid.NewGuid();
        private string _description = "test";

        protected override CommandHandler<UpdateDirezioneRegionale> OnHandle(IEventRepository eventRepository)
        {
            return new UpdateDirezioneRegionaleHandler(eventRepository);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield break;
        }

        public override UpdateDirezioneRegionale When()
        {

            return  BuildCmd.UpdateDirezioneRegionale
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
            Assert.AreEqual(typeof(AggregateRootInstanceNotFoundException), Caught.GetType());
        }


    }
}
