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
using Super.Contabilita.Events;
using Super.Contabilita.Handlers.DirezioneRegionale;

namespace Super.Contabilita.Specs.DirezioneRegionale
{
    public class Cancellazione_di_una_direzione_regionale_gia_cancellata : CommandBaseClass<DeleteDirezioneRegionale>
    {
        private Guid _id = Guid.NewGuid();
        private string _description = "test";
        

        protected override CommandHandler<DeleteDirezioneRegionale> OnHandle(IEventRepository eventRepository)
        {
            return new DeleteDirezioneRegionaleHandler(eventRepository);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield return BuildEvt.DirezioneRegionaleCreated
                .ForDescription(_description)
                .Build(_id,1);
            yield return BuildEvt.DirezioneRegionaleDeleted
                .Build(_id, 2);
        }

        public override DeleteDirezioneRegionale When()
        {
            return BuildCmd.DeleteDirezioneRegionale
                .Build(_id, 2);
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
