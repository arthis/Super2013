using System;
using System.Collections.Generic;
using CommonDomain;
using CommonDomain.Core.Handlers;
using CommonDomain.Persistence;
using NUnit.Framework;
using CommonSpecs;
using Super.Contabilita.Commands.TipoIntervento.RotabileInManutenzione;
using Super.Contabilita.Events;
using Super.Contabilita.Events.Builders;
using Super.Contabilita.Handlers.TipoIntervento;

namespace Super.Contabilita.Specs.TipoIntervento.RotabileInManutenzione
{
    public class Cancellazione_di_un_tipo_intervento_rotabile_in_manutenzione_gia_creato : CommandBaseClass<DeleteTipoInterventoRotMan>
    {
        private Guid _id = Guid.NewGuid();
        private string _description = "test";
        private const string _mnemo = "mnemo";
        private readonly Guid _idMeasuringUnit = Guid.NewGuid();
        
        protected override CommandHandler<DeleteTipoInterventoRotMan> OnHandle(IEventRepository eventRepository)
        {
            return new DeleteTipoInterventoRotManHandler(eventRepository);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield return BuildEvt.TipoInterventoRotManCreated
                .ForDescription(_description)
                .ForMnemo(_mnemo)
                .OfMeasuringUNit(_idMeasuringUnit)
                .Build(_id,1);
        }

        public override DeleteTipoInterventoRotMan When()
        {
            return Commands.BuildCmd.DeleteTipoInterventoRotMan
                .Build(_id, 1);
        }

        public override IEnumerable<IMessage> Expect()
        {
            yield return BuildEvt.TipoInterventoRotManDeleted
                .Build(_id, 2);
        }

        [Test]
        public void non_genera_un_eccezzione()
        {
            Assert.IsNull(Caught);
        }

    }
}
