using System;
using System.Collections.Generic;
using CommonDomain;
using CommonDomain.Core.Handlers;
using CommonDomain.Persistence;
using NUnit.Framework;
using CommonSpecs;
using Super.Contabilita.Commands.GruppoOggettoIntervento;
using Super.Contabilita.Events;
using Super.Contabilita.Handlers.GruppoOggettoIntervento;
using BuildCmd = Super.Contabilita.Commands.Build;

namespace Super.Contabilita.Specs.GruppoOggettoIntervento
{
    public class Aggiornamento_di_un_gruppo_oggetto_intervento_gia_creato : CommandBaseClass<UpdateGruppoOggettoIntervento>
    {
        private Guid _id = Guid.NewGuid();
        private string _description = "test";
        
        private string _descriptionUpdated = "test 2";

        
        protected override CommandHandler<UpdateGruppoOggettoIntervento> OnHandle(IEventRepository eventRepository)
        {
            return new UpdateGruppoOggettoInterventoHandler(eventRepository);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield return  BuildEvt.GruppoOggettoInterventoCreated
                                   .ForDescription(_description)
                                   .Build(_id,1);
        }

        public override UpdateGruppoOggettoIntervento When()
        {
            return BuildCmd.UpdateGruppoOggettoIntervento
                            .ForDescription(_descriptionUpdated)
                            .Build(_id,1);
        }

        public override IEnumerable<IMessage> Expect()
        {
            yield return BuildEvt.GruppoOggettoInterventoUpdated
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
