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
using Super.Contabilita.Commands.TipoIntervento.Rotabile;
using Super.Contabilita.Handlers.Commands.TipoIntervento;

namespace Super.Contabilita.Specs.TipoIntervento.Rotabile
{
    public class Cancellazione_di_un_tipo_intervento_rotabile_non_esistente : CommandBaseClass<DeleteTipoInterventoRot>
    {
        private Guid _id = Guid.NewGuid();

        protected override CommandHandler<DeleteTipoInterventoRot> OnHandle(IEventRepository eventRepository)
        {
            return new DeleteTipoInterventoRotHandler(eventRepository);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield break;
        }

        public override DeleteTipoInterventoRot When()
        {
            return BuildCmd.DeleteTipoInterventoRot
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
