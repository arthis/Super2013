﻿using System;
using System.Collections.Generic;
using CommonDomain;
using CommonDomain.Core.Handlers;
using CommonDomain.Core.Handlers.Commands;
using CommonDomain.Persistence;
using NUnit.Framework;
using CommonSpecs;
using Super.Contabilita.Commands.TipoOggettoIntervento.Rotabile;
using Super.Contabilita.Events;
using Super.Contabilita.Events.Builders;
using Super.Contabilita.Handlers.Commands.TipoOggettoIntervento.Rotabile;

namespace Super.Contabilita.Specs.TipoOggettoIntervento.Rotabile
{
    public class Aggiornamento_di_una_locomotiva_rotabile_gia_creata : CommandBaseClass<UpdateLocomotiveRot>
    {
        private Guid _id = Guid.NewGuid();
        private string _description = "test";
        private const string _sign = "sign";
        private readonly Guid _idGruppoOggettoIntervento = Guid.NewGuid();
        
        private string _descriptionUpdated = "test 2";
        private const string _signUpdated = "sign 2";
        private readonly Guid _idGruppoOggettoInterventoUpdated = Guid.NewGuid();

        protected override CommandHandler<UpdateLocomotiveRot> OnHandle(IEventRepository eventRepository)
        {
            return new UpdateLocomotiveRotHandler(eventRepository);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield return BuildEvt.LocomotiveRotCreated
                .ForDescription(_description)
                .ForSign(_sign)
                .ForGruppoOggetto(_idGruppoOggettoIntervento)
                .Build(_id, 1);
        }

        public override UpdateLocomotiveRot When()
        {
            return Commands.BuildCmd.UpdateLocomotiveRot
                .ForDescription(_descriptionUpdated)
                .ForSign(_signUpdated)
                .ForGruppoOggetto(_idGruppoOggettoInterventoUpdated)
                .Build(_id, 1);
        }

        public override IEnumerable<IMessage> Expect()
        {
            yield return BuildEvt.LocomotiveRotUpdated
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
