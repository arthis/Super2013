using System;
using System.Collections.Generic;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Handlers;
using CommonDomain.Persistence;
using NUnit.Framework;
using CommonSpecs;
using Super.Contabilita.Commands.TipoOggettoIntervento.Ambiente;
using Super.Contabilita.Events.Builders;
using Super.Contabilita.Handlers.TipoOggettoIntervento;
using Super.Contabilita.Handlers.TipoOggettoIntervento.Ambiente;

namespace Super.Contabilita.Specs.TipoOggettoIntervento.Ambiente
{
    public class Creazione_di_uno_nuovo_tipo_oggetto_intervento_ambiente_gia_creato : CommandBaseClass<CreateTipoOggettoInterventoAmb>
    {
        private Guid _id = Guid.NewGuid();
        private const string _description = "test";
        private const string _sign = "sign";

        public override string ToDescription()
        {
            return "Creare un tipo oggetto intervento ambiente gia creato con il stesso Guid non é possibile";
        }
       

        protected override CommandHandler<CreateTipoOggettoInterventoAmb> OnHandle(IEventRepository eventRepository)
        {
            return new CreateTipoOggettoInterventoAmbHandler(eventRepository);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield return Build.TipoOggettoInterventoAmbCreated
                .ForDescription(_description)
                .ForSign(_sign)
                .Build(_id, 1);
        }

        public override CreateTipoOggettoInterventoAmb When()
        {
            return Commands.Builders.Build.CreateTipoOggettoInterventoAmb
                .ForDescription(_description)
                .ForSign(_sign)
                .Build(_id,0);
        }

        public override IEnumerable<IMessage> Expect()
        {
            yield break;
        }

        [Test]
        public void genera_un_eccezzione()
        {
            Assert.IsNotNull(Caught);
            Assert.AreEqual(typeof(AlreadyCreatedAggregateRootException), Caught.GetType());
        }


    }
}
