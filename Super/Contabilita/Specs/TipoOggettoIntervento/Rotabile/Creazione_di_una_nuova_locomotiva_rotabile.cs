using System;
using System.Collections.Generic;
using CommonDomain;
using CommonDomain.Core.Handlers;
using CommonDomain.Persistence;
using NUnit.Framework;
using CommonSpecs;
using Super.Contabilita.Commands.TipoOggettoIntervento.Rotabile;
using Super.Contabilita.Events;
using Super.Contabilita.Events.Builders;
using Super.Contabilita.Handlers.TipoOggettoIntervento.Rotabile;


namespace Super.Contabilita.Specs.TipoOggettoIntervento.Rotabile
{
    public class Creazione_di_una_nuova_locomotiva_rotabile : CommandBaseClass<CreateLocomotiveRot>
    {
        private readonly Guid _id = Guid.NewGuid();
        private const string _description = "test";
        private const string _sign = "sign";
        private readonly Guid _idGruppoOggettoIntervento = Guid.NewGuid();


        protected override CommandHandler<CreateLocomotiveRot> OnHandle(IEventRepository eventRepository)
        {
            return new CreateLocomotiveRotHandler(eventRepository);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield break;
        }

        public override CreateLocomotiveRot When()
        {
            return Commands.BuildCmd.CreateLocomotiveRot
                .ForDescription(_description)
                .ForSign(_sign)
                .ForGruppoOggetto(_idGruppoOggettoIntervento)
                .Build(_id, 1);
        }

        public override IEnumerable<IMessage> Expect()
        {
            yield return BuildEvt.TipoOggettoInterventoRotCreated
               .Build(_id, 1);
            yield return BuildEvt.LocomotiveRotCreated
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
