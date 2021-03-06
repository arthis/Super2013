﻿using System;
using System.Collections.Generic;
using CommonDomain;
using CommonDomain.Core.Handlers;
using CommonDomain.Core.Handlers.Commands;
using CommonDomain.Persistence;
using NUnit.Framework;
using CommonSpecs;
using Super.Contabilita.Commands.TipoOggettoIntervento.Ambiente;
using Super.Contabilita.Events;
using Super.Contabilita.Events.Builders;
using Super.Contabilita.Handlers.Commands.TipoOggettoIntervento.Ambiente;

namespace Super.Contabilita.Specs.TipoOggettoIntervento.RotabileInManuenzione
{
    public class Cancellazione_di_un_tipo_oggetto_intervento_rotabile_in_mantenzione_gia_creato : CommandBaseClass<DeleteTipoOggettoInterventoAmb>
    {
        private Guid _id = Guid.NewGuid();
        private string _description = "test";
        private const string _sign = "sign";
        private readonly Guid _idGruppoOggettoIntervento = Guid.NewGuid();
        
        protected override CommandHandler<DeleteTipoOggettoInterventoAmb> OnHandle(IEventRepository eventRepository)
        {
            return new DeleteTipoOggettoInterventoAmbHandler(eventRepository);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield return BuildEvt.TipoOggettoInterventoAmbCreated
                .ForDescription(_description)
                .ForSign(_sign)
                .ForGruppoOggetto(_idGruppoOggettoIntervento)
                .Build(_id, 1);
        }

        public override DeleteTipoOggettoInterventoAmb When()
        {
            return Commands.BuildCmd.DeleteTipoOggettoInterventoAmb
                .Build(_id, 1);
        }

        public override IEnumerable<IMessage> Expect()
        {
            yield return BuildEvt.TipoOggettoInterventoAmbDeleted
                .Build(_id, 2);
        }

        [Test]
        public void non_genera_un_eccezzione()
        {
            Assert.IsNull(Caught);
        }

    }
}
