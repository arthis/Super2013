using System;
using System.Collections.Generic;
using CommonDomain;
using CommonDomain.Core.Handlers;
using CommonDomain.Persistence;
using NUnit.Framework;
using CommonSpecs;
using Super.Contabilita.Commands.TipoOggettoIntervento.RotabileInManutenzione;
using Super.Contabilita.Events;
using Super.Contabilita.Events.Builders;
using Super.Contabilita.Handlers.TipoOggettoIntervento.RotabileInManutenzione;

namespace Super.Contabilita.Specs.TipoOggettoIntervento.RotabileInManuenzione
{
    public class Cancellazione_di_un_tipo_oggetto_intervento_rotabile_in_mantenzione_gia_cancellato : CommandBaseClass<DeleteTipoOggettoInterventoRotMan>
    {
        private Guid _id = Guid.NewGuid();
        private string _description = "test";
        private const string _sign = "sign";
        private readonly Guid _idGruppoOggettoIntervento = Guid.NewGuid();
        

        protected override CommandHandler<DeleteTipoOggettoInterventoRotMan> OnHandle(IEventRepository eventRepository)
        {
            return new DeleteTipoOggettoInterventoRotManHandler(eventRepository);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield return BuildEvt.TipoOggettoInterventoRotManCreated
                .Build(_id, 1);
            yield return BuildEvt.LocomotiveRotManCreated
                .ForDescription(_description)
                .ForSign(_sign)
                .ForGruppoOggetto(_idGruppoOggettoIntervento)
                .Build(_id,2);
            yield return BuildEvt.TipoOggettoInterventoRotManDeleted
                .Build(_id, 3);
        }

        public override DeleteTipoOggettoInterventoRotMan When()
        {
            return Commands.BuildCmd.DeleteTipoOggettoInterventoRotMan
                .Build(_id, 3);
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
