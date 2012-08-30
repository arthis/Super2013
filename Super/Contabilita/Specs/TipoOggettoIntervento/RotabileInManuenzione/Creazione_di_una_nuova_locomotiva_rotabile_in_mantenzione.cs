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
    public class Creazione_di_una_nuova_locomotiva_rotabile_in_mantenzione : CommandBaseClass<CreateLocomotiveRotMan>
    {
        private readonly Guid _id = Guid.NewGuid();
        private const string _description = "test";
        private const string _sign = "sign";
        private readonly Guid _idGruppoOggettoIntervento = Guid.NewGuid();


        protected override CommandHandler<CreateLocomotiveRotMan> OnHandle(IEventRepository eventRepository)
        {
            return new CreateLocomotiveRotManHandler(eventRepository);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield break;
        }

        public override CreateLocomotiveRotMan When()
        {
            return Commands.Build.CreateLocomotiveRotMan
                .ForDescription(_description)
                .ForSign(_sign)
                .ForGruppoOggetto(_idGruppoOggettoIntervento)
                .Build(_id, 2);
        }

        public override IEnumerable<IMessage> Expect()
        {
            yield return Build.TipoOggettoInterventoRotManCreated
                .Build(_id, 1);
            yield return Build.LocomotiveRotManCreated
                .ForDescription(_description)
                .ForSign(_sign)
                .ForGruppoOggetto(_idGruppoOggettoIntervento)
                .Build(_id, 2);
        }

        [Test]
        public void non_genera_un_eccezzione()
        {
            Assert.IsNull(Caught);
        }


    }

    
}
