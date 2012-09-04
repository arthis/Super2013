using System;
using System.Collections.Generic;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Handlers;
using CommonDomain.Persistence;
using NUnit.Framework;
using CommonSpecs;
using Super.Contabilita.Commands;
using Super.Contabilita.Commands.Builders;
using Super.Contabilita.Commands.TipoOggettoIntervento.Ambiente;
using Super.Contabilita.Handlers.TipoOggettoIntervento;
using Super.Contabilita.Handlers.TipoOggettoIntervento.Ambiente;

namespace Super.Contabilita.Specs.TipoOggettoIntervento.Ambiente
{
    public class Cancellazione_di_un_tipo_oggetto_intervento_ambiente_non_esistente : CommandBaseClass<DeleteTipoOggettoInterventoAmb>
    {
        private Guid _id = Guid.NewGuid();

        protected override CommandHandler<DeleteTipoOggettoInterventoAmb> OnHandle(IEventRepository eventRepository)
        {
            return new DeleteTipoOggettoInterventoAmbHandler(eventRepository);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield break;
        }

        public override DeleteTipoOggettoInterventoAmb When()
        {
            return BuildCmd.DeleteTipoOggettoInterventoAmb
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
