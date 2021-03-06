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


namespace Super.Contabilita.Specs.TipoOggettoIntervento.Ambiente
{
    public class Aggiornamento_di_un_tipo_oggetto_intervento_ambiente_gia_creato : CommandBaseClass<UpdateTipoOggettoInterventoAmb>
    {
        private Guid _id = Guid.NewGuid();
        private string _description = "test";
        private readonly Guid _idGruppoOggettoIntervento = Guid.NewGuid();
        private const string _sign = "sign";
        
        private string _descriptionUpdated = "test 2";
        private const string _signUpdated = "sign 2";
        private readonly Guid _idGruppoOggettoInterventoUpdated = Guid.NewGuid();
        
        protected override CommandHandler<UpdateTipoOggettoInterventoAmb> OnHandle(IEventRepository eventRepository)
        {
            return new UpdateTipoOggettoInterventoAmbHandler(eventRepository);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield return BuildEvt.TipoOggettoInterventoAmbCreated
                .ForDescription(_description)
                .ForSign(_sign)
                .ForGruppoOggetto(_idGruppoOggettoIntervento)
                .Build(_id, 1);
        }

        public override UpdateTipoOggettoInterventoAmb When()
        {
            return Commands.BuildCmd.UpdateTipoOggettoInterventoAmb
                .ForDescription(_descriptionUpdated)
                .ForSign(_signUpdated)
                .ForGruppoOggetto(_idGruppoOggettoInterventoUpdated)
                .Build(_id, 1);
        }

        public override IEnumerable<IMessage> Expect()
        {
            yield return BuildEvt.TipoOggettoInterventoAmbUpdated
                .ForDescription(_descriptionUpdated)
                .ForSign(_signUpdated)
                .ForGruppoOggetto(_idGruppoOggettoInterventoUpdated)
                .Build(_id,2);
                            
        }

        [Test]
        public void non_genera_un_eccezzione()
        {
            Assert.IsNull(Caught);
        }


    }
}
