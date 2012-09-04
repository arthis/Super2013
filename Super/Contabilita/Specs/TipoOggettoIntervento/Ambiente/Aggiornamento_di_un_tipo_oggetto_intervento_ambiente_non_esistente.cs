using System;
using System.Collections.Generic;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Handlers;
using CommonDomain.Persistence;
using NUnit.Framework;
using CommonSpecs;
using Super.Contabilita.Commands;
using Super.Contabilita.Commands.TipoOggettoIntervento.Ambiente;
using Super.Contabilita.Commands.Builders;
using Super.Contabilita.Handlers.TipoOggettoIntervento;
using Super.Contabilita.Handlers.TipoOggettoIntervento.Ambiente;

namespace Super.Contabilita.Specs.TipoOggettoIntervento.Ambiente
{
    public class Aggiornamento_di_un_tipo_oggetto_intervento_ambiente_non_esistente : CommandBaseClass<UpdateTipoOggettoInterventoAmb>
    {
        private Guid _id = Guid.NewGuid();
        private string _description = "test";
        private const string _sign = "sign";
        private readonly Guid _idGruppoOggettoIntervento = Guid.NewGuid();

        protected override CommandHandler<UpdateTipoOggettoInterventoAmb> OnHandle(IEventRepository eventRepository)
        {
            return new UpdateTipoOggettoInterventoAmbHandler(eventRepository);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield break;
        }

        public override UpdateTipoOggettoInterventoAmb When()
        {

            return  BuildCmd.UpdateTipoOggettoInterventoAmb
                         .ForDescription(_description)
                         .ForSign(_sign)
                         .ForGruppoOggetto(_idGruppoOggettoIntervento)
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
