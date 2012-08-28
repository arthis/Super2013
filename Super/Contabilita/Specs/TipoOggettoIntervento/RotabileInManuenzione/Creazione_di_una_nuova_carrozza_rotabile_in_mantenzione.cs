using System;
using System.Collections.Generic;
using CommonDomain;
using CommonDomain.Core.Handlers;
using CommonDomain.Persistence;
using NUnit.Framework;
using CommonSpecs;
using Super.Contabilita.Commands.TipoOggettoIntervento.RotabileInManutenzione;
using Super.Contabilita.Events.Builders;
using Super.Contabilita.Handlers.TipoOggettoIntervento.RotabileInManutenzione;

namespace Super.Contabilita.Specs.TipoOggettoIntervento.RotabileInManuenzione
{
    public class Creazione_di_una_nuova_carrozza_rotabile_in_mantenzione : CommandBaseClass<CreateCarriageRotMan>
    {
        private readonly Guid _id = Guid.NewGuid();
        private const bool _isInternational = true;
        private const string _description = "test";
        private const string _sign = "sign";


        protected override CommandHandler<CreateCarriageRotMan> OnHandle(IEventRepository eventRepository)
        {
            return new CreateCarriageRotManHandler(eventRepository);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield break;
        }

        public override CreateCarriageRotMan When()
        {
            return Commands.Builders.Build.CreateCarriageRotMan
                .ForDescription(_description)
                .ForSign(_sign)
                .IsInternational(_isInternational)
                .Build(_id, 0);
        }

        public override IEnumerable<IMessage> Expect()
        {
            yield return Build.CarriageRotManCreated
                .ForDescription(_description)
                .ForSign(_sign)
                .IsInternational(_isInternational)
                .Build(_id, 1);
        }

        [Test]
        public void non_genera_un_eccezzione()
        {
            Assert.IsNull(Caught);
        }


    }
}
