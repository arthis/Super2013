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
using Super.Contabilita.Commands.TipoIntervento.RotabileInManutenzione;
using Super.Contabilita.Handlers.Commands.TipoIntervento;

namespace Super.Contabilita.Specs.TipoIntervento.RotabileInManutenzione
{
    public class Cancellazione_di_un_tipo_intervento_rotabile_in_manutenzione_non_esistente : CommandBaseClass<DeleteTipoInterventoRotMan>
    {
        private Guid _id = Guid.NewGuid();

        protected override CommandHandler<DeleteTipoInterventoRotMan> OnHandle(IEventRepository eventRepository)
        {
            return new DeleteTipoInterventoRotManHandler(eventRepository);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield break;
        }

        public override DeleteTipoInterventoRotMan When()
        {
            return BuildCmd.DeleteTipoInterventoRotMan
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
