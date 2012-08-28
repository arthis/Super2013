using System;
using System.Collections.Generic;
using CommonDomain;
using CommonDomain.Core.Handlers;
using CommonDomain.Persistence;
using NUnit.Framework;
using CommonSpecs;
using Super.Contabilita.Commands.Builders;
using Super.Contabilita.Commands.TipoIntervento.RotabileInManutenzione;
using Super.Contabilita.Handlers.TipoIntervento;

namespace Super.Contabilita.Specs.TipoIntervento.RotabileInManutenzione
{
    public class Creazione_di_uno_nuovo_tipo_intervento_rotabile_in_manutenzione : CommandBaseClass<CreateTipoInterventoRotMan>
    {
        private readonly Guid _id = Guid.NewGuid();
        private const string _description = "test";
        private const string _mnemo = "mnemo";
        private readonly Guid _idMeasuringUnit = Guid.NewGuid();


        protected override CommandHandler<CreateTipoInterventoRotMan> OnHandle(IEventRepository eventRepository)
        {
            return new CreateTipoInterventoRotManHandler(eventRepository);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield break;
        }

        public override CreateTipoInterventoRotMan When()
        {
            return Build.CreateTipoInterventoRotMan
                .ForDescription(_description)
                .ForMnemo(_mnemo)
                .OfMeasuringUNit(_idMeasuringUnit)
                .Build(_id, 0);
        }

        public override IEnumerable<IMessage> Expect()
        {
            yield return Events.Builders.Build.TipoInterventoRotManCreated
                .ForDescription(_description)
                .ForMnemo(_mnemo)
                .OfMeasuringUNit(_idMeasuringUnit)
                .Build(_id, 1);
        }

        [Test]
        public void non_genera_un_eccezzione()
        {
            Assert.IsNull(Caught);
        }


    }
}
