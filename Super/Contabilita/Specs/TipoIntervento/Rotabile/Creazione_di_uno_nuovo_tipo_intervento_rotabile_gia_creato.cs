using System;
using System.Collections.Generic;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Handlers;
using CommonDomain.Persistence;
using NUnit.Framework;
using CommonSpecs;
using Super.Contabilita.Commands.TipoIntervento.Rotabile;
using Super.Contabilita.Events;
using Super.Contabilita.Events.Builders;
using Super.Contabilita.Handlers.TipoIntervento;

namespace Super.Contabilita.Specs.TipoIntervento.Rotabile
{
    public class Creazione_di_uno_nuovo_tipo_intervento_rotabile_gia_creato : CommandBaseClass<CreateTipoInterventoRot>
    {
        private Guid _id = Guid.NewGuid();
        private const string _description = "test";
        private const string _mnemo = "mnemo";
        private readonly Guid _idMeasuringUnit = Guid.NewGuid();
        private const char _classe = 'C';
        private const bool _aiTreni = true;
        private const bool _calcoloDetrazioni = true;

        public override string ToDescription()
        {
            return "Creare un tipo intervento rotabile gia creato con il stesso Guid non é possibile";
        }
       

        protected override CommandHandler<CreateTipoInterventoRot> OnHandle(IEventRepository eventRepository)
        {
            return new CreateTipoInterventoRotHandler(eventRepository);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield return BuildEvt.TipoInterventoRotCreated
                .ForDescription(_description)
                .ForMnemo(_mnemo)
                .OfMeasuringUNit(_idMeasuringUnit)
                 .ForClasse(_classe)
                .ForAiTreni(_aiTreni)
                .ForCalcoloDetrazioni(_calcoloDetrazioni)
                .Build(_id, 1);
        }

        public override CreateTipoInterventoRot When()
        {
            return Commands.Build.CreateTipoInterventoRot
                .ForDescription(_description)
                .ForMnemo(_mnemo)
                .OfMeasuringUNit(_idMeasuringUnit)
                 .ForAiClasse(_classe)
                .ForAiTreni(_aiTreni)
                .ForCalcoloDetrazioni(_calcoloDetrazioni)
                .Build(_id, 1);
        }

        public override IEnumerable<IMessage> Expect()
        {
            yield break;
        }

        [Test]
        public void genera_un_eccezzione()
        {
            Assert.IsNotNull(Caught);
            Assert.AreEqual(typeof(AlreadyCreatedAggregateRootException), Caught.GetType());
        }


    }
}
