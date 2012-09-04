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
using Super.Contabilita.Commands.TipoIntervento.Ambiente;
using Super.Contabilita.Handlers.TipoIntervento;

namespace Super.Contabilita.Specs.TipoIntervento.Ambiente
{
    public class Cancellazione_di_un_tipo_intervento_ambiente_non_esistente : CommandBaseClass<DeleteTipoInterventoAmb>
    {
        private Guid _id = Guid.NewGuid();

        protected override CommandHandler<DeleteTipoInterventoAmb> OnHandle(IEventRepository eventRepository)
        {
            return new DeleteTipoInterventoAmbHandler(eventRepository);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield break;
        }

        public override DeleteTipoInterventoAmb When()
        {
            return BuildCmd.DeleteTipoInterventoAmb
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
