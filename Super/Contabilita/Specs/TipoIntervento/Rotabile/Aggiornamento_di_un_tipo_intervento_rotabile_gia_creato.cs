using System;
using System.Collections.Generic;
using CommonDomain;
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
    public class Aggiornamento_di_un_tipo_intervento_rotabile_gia_creato : CommandBaseClass<UpdateTipoInterventoRot>
    {
        private Guid _id = Guid.NewGuid();
        private string _description = "test";
        private const string _mnemo = "mnemo";
        private readonly Guid _idMeasuringUnit = Guid.NewGuid();
        private const char _classe = 'C';
        private const bool _aiTreni = true;
        private const bool _calcoloDetrazioni = true;
        
        private string _descriptionUpdated = "test 2";
        private const string _mnemoUpdated = "mnemo 2";
        private readonly Guid _idMeasuringUnitUpdated = Guid.NewGuid();
        private const char _classeUpdated = 'A';
        private const bool _aiTreniUpdated = false;
        private const bool _calcoloDetrazioniUpdated = false;

        
        protected override CommandHandler<UpdateTipoInterventoRot> OnHandle(IEventRepository eventRepository)
        {
            return new UpdateTipoInterventoRotHandler(eventRepository);
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
                .Build(_id, 1);
        }

        public override UpdateTipoInterventoRot When()
        {
            return Commands.Build.UpdateTipoInterventoRot
                .ForDescription(_descriptionUpdated)
                .ForMnemo(_mnemoUpdated)
                .OfMeasuringUNit(_idMeasuringUnitUpdated)
                .ForAiClasse(_classeUpdated)
                .ForAiTreni(_aiTreniUpdated)
                .ForCalcoloDetrazioni(_calcoloDetrazioniUpdated)
                .Build(_id, 1);
        }

        public override IEnumerable<IMessage> Expect()
        {
            yield return Build.TipoInterventoRotUpdated
                .ForDescription(_descriptionUpdated)
                .ForMnemo(_mnemoUpdated)
                .OfMeasuringUNit(_idMeasuringUnitUpdated)
                .ForClasse(_classeUpdated)
                .ForAiTreni(_aiTreniUpdated)
                .ForCalcoloDetrazioni(_calcoloDetrazioniUpdated)
                .Build(_id,2);
                            
        }

        [Test]
        public void non_genera_un_eccezzione()
        {
            Assert.IsNull(Caught);
        }


    }
}
