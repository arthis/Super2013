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
using Super.Contabilita.Handlers.Commands.DirezioneRegionale;

namespace Super.Contabilita.Specs.DirezioneRegionale
{
    public class Cancellazione_di_una_direzione_regionale_non_esistente : CommandBaseClass<DeleteDirezioneRegionale>
    {
        private Guid _id = Guid.NewGuid();

        protected override CommandHandler<DeleteDirezioneRegionale> OnHandle(IEventRepository eventRepository)
        {
            return new DeleteDirezioneRegionaleHandler(eventRepository);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield break;
        }

        public override DeleteDirezioneRegionale When()
        {
            return BuildCmd.DeleteDirezioneRegionale
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
