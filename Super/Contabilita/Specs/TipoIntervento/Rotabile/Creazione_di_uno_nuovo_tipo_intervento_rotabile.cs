using System;
using System.Collections.Generic;
using CommonDomain;
using CommonDomain.Core.Handlers;
using CommonDomain.Persistence;
using NUnit.Framework;
using CommonSpecs;
using Super.Contabilita.Commands;
using Super.Contabilita.Commands.Builders;
using Super.Contabilita.Commands.TipoIntervento.Rotabile;
using Super.Contabilita.Handlers.TipoIntervento;

namespace Super.Contabilita.Specs.TipoIntervento.Rotabile
{
    public class Creazione_di_uno_nuovo_tipo_intervento_rotabile : CommandBaseClass<CreateTipoInterventoRot>
    {
        private readonly Guid _id = Guid.NewGuid();
        private const string _description = "test";
        private const string _mnemo = "mnemo";
        private readonly Guid _idMeasuringUnit = Guid.NewGuid();
        private const char _classe = 'C';
        private const bool _aiTreni = true;
        private const bool _calcoloDetrazioni = true;


        protected override CommandHandler<CreateTipoInterventoRot> OnHandle(IEventRepository eventRepository)
        {
            return new CreateTipoInterventoRotHandler(eventRepository);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield break;
        }

        public override CreateTipoInterventoRot When()
        {
            return Build.CreateTipoInterventoRot
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
            yield return Events.BuildEvt.TipoInterventoRotCreated
                .ForDescription(_description)
                .ForMnemo(_mnemo)
                .OfMeasuringUNit(_idMeasuringUnit)
                .ForClasse(_classe)
                .ForAiTreni(_aiTreni)
                .ForCalcoloDetrazioni(_calcoloDetrazioni)
                .Build(_id, 1);
        }

        [Test]
        public void non_genera_un_eccezzione()
        {
            Assert.IsNull(Caught);
        }


    }
}
