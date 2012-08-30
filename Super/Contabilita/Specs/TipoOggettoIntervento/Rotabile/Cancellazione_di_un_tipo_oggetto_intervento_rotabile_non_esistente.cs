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
using Super.Contabilita.Commands.TipoOggettoIntervento.Rotabile;
using Super.Contabilita.Handlers.TipoOggettoIntervento.Rotabile;

namespace Super.Contabilita.Specs.TipoOggettoIntervento.Rotabile
{
    public class Cancellazione_di_un_tipo_oggetto_intervento_rotabile_non_esistente : CommandBaseClass<DeleteTipoOggettoInterventoRot>
    {
        private Guid _id = Guid.NewGuid();

        protected override CommandHandler<DeleteTipoOggettoInterventoRot> OnHandle(IEventRepository eventRepository)
        {
            return new DeleteTipoOggettoInterventoRotHandler(eventRepository);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield break;
        }

        public override DeleteTipoOggettoInterventoRot When()
        {
            return Build.DeleteTipoOggettoInterventoRot
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
