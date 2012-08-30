using System;
using System.Collections.Generic;
using CommonDomain;
using CommonDomain.Core.Handlers;
using CommonDomain.Persistence;
using NUnit.Framework;
using CommonSpecs;
using Super.Contabilita.Commands.DirezioneRegionale;
using Super.Contabilita.Handlers.DirezioneRegionale;
using BuildCmd = Super.Contabilita.Commands.Build;
using BuildEvt = Super.Contabilita.Events.Build;

namespace Super.Contabilita.Specs.DirezioneRegionale
{
    public class Aggiornamento_di_una_direzione_regionale_gia_creata : CommandBaseClass<UpdateDirezioneRegionale>
    {
        private Guid _id = Guid.NewGuid();
        private string _description = "test";
        
        private string _descriptionUpdated = "test 2";

        
        protected override CommandHandler<UpdateDirezioneRegionale> OnHandle(IEventRepository eventRepository)
        {
            return new UpdateDirezioneRegionaleHandler(eventRepository);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield return  BuildEvt.DirezioneRegionaleCreated
                                   .ForDescription(_description)
                                   .Build(_id,1);
        }

        public override UpdateDirezioneRegionale When()
        {
            return BuildCmd.UpdateDirezioneRegionale
                            .ForDescription(_descriptionUpdated)
                            .Build(_id,1);
        }

        public override IEnumerable<IMessage> Expect()
        {
            yield return BuildEvt.DirezioneRegionaleUpdated
                .ForDescription(_descriptionUpdated)
                .Build(_id,2);
                            
        }

        [Test]
        public void non_genera_un_eccezzione()
        {
            Assert.IsNull(Caught);
        }


    }
}
