using System;
using System.Collections.Generic;
using CommonDomain;
using CommonDomain.Core.Handlers;
using CommonDomain.Persistence;
using NUnit.Framework;
using CommonSpecs;
using Super.Contabilita.Commands.TipoIntervento.Ambiente;
using Super.Contabilita.Events.Builders;
using Super.Contabilita.Handlers.TipoIntervento;

namespace Super.Contabilita.Specs.TipoIntervento.Ambiente
{
    public class Aggiornamento_di_un_tipo_intervento_ambiente_gia_creato : CommandBaseClass<UpdateTipoInterventoAmb>
    {
        private Guid _id = Guid.NewGuid();
        private string _description = "test";
        private const string _mnemo = "mnemo";
        private readonly Guid _idMeasuringUnit = Guid.NewGuid();
        
        private string _descriptionUpdated = "test 2";
        private const string _mnemoUpdated = "mnemo 2";
        private readonly Guid _idMeasuringUnitUpdated = Guid.NewGuid();

        
        protected override CommandHandler<UpdateTipoInterventoAmb> OnHandle(IEventRepository eventRepository)
        {
            return new UpdateTipoInterventoAmbHandler(eventRepository);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield return Build.TipoInterventoAmbCreated
                .ForDescription(_description)
                .ForMnemo(_mnemo)
                .OfMeasuringUNit(_idMeasuringUnit)
                .Build(_id, 1);
        }

        public override UpdateTipoInterventoAmb When()
        {
            return Commands.Builders.Build.UpdateTipoInterventoAmb
                .ForDescription(_descriptionUpdated)
                .ForMnemo(_mnemoUpdated)
                .OfMeasuringUNit(_idMeasuringUnitUpdated)
                .Build(_id, 1);
        }

        public override IEnumerable<IMessage> Expect()
        {
            yield return Build.TipoInterventoAmbUpdated
                .ForDescription(_descriptionUpdated)
                .ForMnemo(_mnemoUpdated)
                .OfMeasuringUNit(_idMeasuringUnitUpdated)
                .Build(_id,2);
                            
        }

        [Test]
        public void non_genera_un_eccezzione()
        {
            Assert.IsNull(Caught);
        }


    }
}
