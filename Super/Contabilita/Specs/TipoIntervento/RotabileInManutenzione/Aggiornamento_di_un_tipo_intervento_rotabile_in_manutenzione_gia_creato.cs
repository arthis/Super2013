using System;
using System.Collections.Generic;
using CommonDomain;
using CommonDomain.Core.Handlers;
using CommonDomain.Core.Handlers.Commands;
using CommonDomain.Persistence;
using NUnit.Framework;
using CommonSpecs;
using Super.Contabilita.Commands.TipoIntervento.RotabileInManutenzione;
using Super.Contabilita.Events;
using Super.Contabilita.Events.Builders;
using Super.Contabilita.Handlers.Commands.TipoIntervento;

namespace Super.Contabilita.Specs.TipoIntervento.RotabileInManutenzione
{
    public class Aggiornamento_di_un_tipo_intervento_rotabile_in_manutenzione_gia_creato : CommandBaseClass<UpdateTipoInterventoRotMan>
    {
        private Guid _id = Guid.NewGuid();
        private string _description = "test";
        private const string _mnemo = "mnemo";
        private readonly Guid _idMeasuringUnit = Guid.NewGuid();
        
        private string _descriptionUpdated = "test 2";
        private const string _mnemoUpdated = "mnemo 2";
        private readonly Guid _idMeasuringUnitUpdated = Guid.NewGuid();

        
        protected override CommandHandler<UpdateTipoInterventoRotMan> OnHandle(IEventRepository eventRepository)
        {
            return new UpdateTipoInterventoRotManHandler(eventRepository);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield return BuildEvt.TipoInterventoRotManCreated
                .ForDescription(_description)
                .ForMnemo(_mnemo)
                .OfMeasuringUNit(_idMeasuringUnit)
                .Build(_id, 1);
        }

        public override UpdateTipoInterventoRotMan When()
        {
            return Commands.BuildCmd.UpdateTipoInterventoRotMan
                .ForDescription(_descriptionUpdated)
                .ForMnemo(_mnemoUpdated)
                .OfMeasuringUNit(_idMeasuringUnitUpdated)
                .Build(_id, 1);
        }

        public override IEnumerable<IMessage> Expect()
        {
            yield return BuildEvt.TipoInterventoRotManUpdated
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
