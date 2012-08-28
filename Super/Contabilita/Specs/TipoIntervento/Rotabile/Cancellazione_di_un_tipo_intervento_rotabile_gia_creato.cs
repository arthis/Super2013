using System;
using System.Collections.Generic;
using CommonDomain;
using CommonDomain.Core.Handlers;
using CommonDomain.Persistence;
using NUnit.Framework;
using CommonSpecs;
using Super.Contabilita.Commands.TipoIntervento.Rotabile;
using Super.Contabilita.Events.Builders;
using Super.Contabilita.Handlers.TipoIntervento;

namespace Super.Contabilita.Specs.TipoIntervento.Rotabile
{
    public class Cancellazione_di_un_tipo_intervento_rotabile_gia_creato : CommandBaseClass<DeleteTipoInterventoRot>
    {
        private Guid _id = Guid.NewGuid();
        private string _description = "test";
        private const string _mnemo = "mnemo";
        private readonly Guid _idMeasuringUnit = Guid.NewGuid();
        private const char _classe = 'C';
        private const bool _aiTreni = true;
        private const bool _calcoloDetrazioni = true;
        
        protected override CommandHandler<DeleteTipoInterventoRot> OnHandle(IEventRepository eventRepository)
        {
            return new DeleteTipoInterventoRotHandler(eventRepository);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield return Build.TipoInterventoRotCreated
                .ForDescription(_description)
                .ForMnemo(_mnemo)
                .OfMeasuringUNit(_idMeasuringUnit)
                .ForClasse(_classe)
                .ForAiTreni(_aiTreni)
                .ForCalcoloDetrazioni(_calcoloDetrazioni)
                .Build(_id,1);
        }

        public override DeleteTipoInterventoRot When()
        {
            return Commands.Builders.Build.DeleteTipoInterventoRot
                .Build(_id, 1);
        }

        public override IEnumerable<IMessage> Expect()
        {
            yield return Build.TipoInterventoRotDeleted
                .Build(_id, 2);
        }

        [Test]
        public void non_genera_un_eccezzione()
        {
            Assert.IsNull(Caught);
        }

    }
}
