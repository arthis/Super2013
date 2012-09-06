using System;
using System.Collections.Generic;
using CommonDomain;
using CommonDomain.Core.Handlers;
using CommonDomain.Core.Handlers.Commands;
using CommonDomain.Persistence;
using NUnit.Framework;
using CommonSpecs;
using Super.Contabilita.Commands.TipoOggettoIntervento.Rotabile;
using Super.Contabilita.Events;
using Super.Contabilita.Events.Builders;
using Super.Contabilita.Handlers.TipoOggettoIntervento.Rotabile;


namespace Super.Contabilita.Specs.TipoOggettoIntervento.Rotabile
{
    public class Cancellazione_di_un_tipo_oggetto_intervento_rotabile_gia_cancellato : CommandBaseClass<DeleteTipoOggettoInterventoRot>
    {
        private Guid _id = Guid.NewGuid();
        

        protected override CommandHandler<DeleteTipoOggettoInterventoRot> OnHandle(IEventRepository eventRepository)
        {
            return new DeleteTipoOggettoInterventoRotHandler(eventRepository);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield return BuildEvt.TipoOggettoInterventoRotCreated
                .Build(_id,1);
            yield return BuildEvt.TipoOggettoInterventoRotDeleted
                .Build(_id, 2);
        }

        public override DeleteTipoOggettoInterventoRot When()
        {
            return Commands.BuildCmd.DeleteTipoOggettoInterventoRot
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
