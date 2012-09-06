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
using Super.Contabilita.Commands.Builders;
using Super.Contabilita.Commands.TipoOggettoIntervento.RotabileInManutenzione;
using Super.Contabilita.Handlers.TipoOggettoIntervento.RotabileInManutenzione;

namespace Super.Contabilita.Specs.TipoOggettoIntervento.RotabileInManuenzione
{
    public class Cancellazione_di_un_tipo_oggetto_intervento_rotabile_in_mantenzione_non_esistente : CommandBaseClass<DeleteTipoOggettoInterventoRotMan>
    {
        private Guid _id = Guid.NewGuid();

        protected override CommandHandler<DeleteTipoOggettoInterventoRotMan> OnHandle(IEventRepository eventRepository)
        {
            return new DeleteTipoOggettoInterventoRotManHandler(eventRepository);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield break;
        }

        public override DeleteTipoOggettoInterventoRotMan When()
        {
            return BuildCmd.DeleteTipoOggettoInterventoRotMan
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
