using System;
using System.Collections.Generic;
using CommonDomain;
using CommonDomain.Core.Handlers;
using CommonDomain.Persistence;
using NUnit.Framework;
using CommonSpecs;
using Super.Contabilita.Commands.DirezioneRegionale;
using Super.Contabilita.Events;
using BuildCmd = Super.Contabilita.Commands.Build;
using Super.Contabilita.Handlers.DirezioneRegionale;

namespace Super.Contabilita.Specs.DirezioneRegionale
{
    public class Cancellazione_di_una_direzione_regionale_gia_creata : CommandBaseClass<DeleteDirezioneRegionale>
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
        }

        public override DeleteDirezioneRegionale When()
        {
            return BuildCmd.DeleteDirezioneRegionale
                .Build(_id, 1);
        }

        public override IEnumerable<IMessage> Expect()
        {
            yield return BuildEvt.DirezioneRegionaleDeleted
                .Build(_id, 2);
        }

        [Test]
        public void non_genera_un_eccezzione()
        {
            Assert.IsNull(Caught);
        }

    }
}
