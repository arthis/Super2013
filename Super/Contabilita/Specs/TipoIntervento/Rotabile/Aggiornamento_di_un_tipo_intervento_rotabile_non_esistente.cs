using System;
using System.Collections.Generic;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Handlers;
using CommonDomain.Persistence;
using NUnit.Framework;
using CommonSpecs;
using Super.Contabilita.Commands.TipoIntervento.Rotabile;
using Super.Contabilita.Commands.Builders;
using Super.Contabilita.Handlers.TipoIntervento;

namespace Super.Contabilita.Specs.TipoIntervento.Rotabile
{
    public class Aggiornamento_di_un_tipo_intervento_rotabile_non_esistente : CommandBaseClass<UpdateTipoInterventoRot>
    {
        private Guid _id = Guid.NewGuid();
        private string _description = "test";
        private const string _mnemo = "mnemo";
        private readonly Guid _idMeasuringUnit = Guid.NewGuid();
        private const char _classe = 'C';
        private const bool _aiTreni = true;
        private const bool _calcoloDetrazioni = true;

        protected override CommandHandler<UpdateTipoInterventoRot> OnHandle(IEventRepository eventRepository)
        {
            return new UpdateTipoInterventoRotHandler(eventRepository);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield break;
        }

        public override UpdateTipoInterventoRot When()
        {

            return Build.UpdateTipoInterventoRot
                .ForDescription(_description)
                .ForMnemo(_mnemo)
                .OfMeasuringUNit(_idMeasuringUnit)
                .ForAiClasse(_classe)
                .ForAiTreni(_aiTreni)
                .ForCalcoloDetrazioni(_calcoloDetrazioni)
                .Build(_id, 0);
        }

        public override IEnumerable<IMessage> Expect()
        {
            yield break;
        }

        [Test]
        public void genera_un_eccezzione()
        {
            Assert.IsNotNull(Caught);
            Assert.AreEqual(typeof(AggregateRootInstanceNotFoundException), Caught.GetType());
        }


    }
}
