using System;
using System.Collections.Generic;
using CommonDomain;
using CommonDomain.Core.Handlers;
using CommonDomain.Core.Handlers.Commands;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using CommonDomain.Persistence;
using NUnit.Framework;
using CommonSpecs;
using Super.Contabilita.Commands;
using Super.Contabilita.Commands.DirezioneRegionale;
using Super.Contabilita.Events;
using Super.Contabilita.Handlers.Commands.DirezioneRegionale;

namespace Super.Contabilita.Specs.DirezioneRegionale
{
    public class Creazione_di_una_nuova_direzione_regionale : CommandBaseClass<CreateDirezioneRegionale>
    {
        private Guid _id = Guid.NewGuid();
        private string _description = "test";
        

        protected override CommandHandler<CreateDirezioneRegionale> OnHandle(IEventRepository eventRepository)
        {
            return new CreateDirezioneRegionaleHandler(eventRepository);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield break;
        }

        public override CreateDirezioneRegionale When()
        {
            return BuildCmd.CreateDirezioneRegionale
                .ForDescription(_description)
                .Build(_id, 1);
        }

        public override IEnumerable<IMessage> Expect()
        {
            yield return BuildEvt.DirezioneRegionaleCreated
                                 .ForDescription(_description)
                                 .Build(_id,1);
        }

        [Test]
        public void non_genera_un_eccezzione()
        {
            Assert.IsNull(Caught);
        }


    }
}
