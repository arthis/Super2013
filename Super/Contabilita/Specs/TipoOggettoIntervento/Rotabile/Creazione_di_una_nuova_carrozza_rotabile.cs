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
    public class Creazione_di_una_nuova_carrozza_rotabile : CommandBaseClass<CreateCarriageRot>
    {
        private readonly Guid _id = Guid.NewGuid();
        private const bool _isInternational = true;
        private const string _description = "test";
        private const string _sign = "sign";
        private readonly Guid _idGruppoOggettoIntervento = Guid.NewGuid();



        protected override CommandHandler<CreateCarriageRot> OnHandle(IEventRepository eventRepository)
        {
            return new CreateCarriageRotHandler(eventRepository);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield break;
        }

        public override CreateCarriageRot When()
        {
            return Commands.Build.CreateCarriageRot
                .ForDescription(_description)
                .ForSign(_sign)
                .IsInternational(_isInternational)
                .ForGruppoOggetto(_idGruppoOggettoIntervento)
                .Build(_id, 1);
        }

        public override IEnumerable<IMessage> Expect()
        {
            yield return BuildEvt.TipoOggettoInterventoRotCreated
               .Build(_id, 1);
            yield return BuildEvt.CarriageRotCreated
                .ForDescription(_description)
                .ForSign(_sign)
                .IsInternational(_isInternational)
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
