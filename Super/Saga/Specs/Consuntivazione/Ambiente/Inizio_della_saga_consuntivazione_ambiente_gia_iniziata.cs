using System;
using System.Collections.Generic;
using CommonDomain;
using CommonDomain.Core.Handlers;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using CommonDomain.Persistence;
using NUnit.Framework;
using CommonSpecs;
using Super.Programmazione.Events.Intervento;
using Super.Programmazione.Events;
using Super.Saga.Domain.Exceptions;
using Super.Saga.Handlers.Consuntivazione;
using Super.Saga.Handlers.Intervento;
using BuildAppaltatoreCmd = Super.Appaltatore.Commands.BuildCmd;
using BuildControlloCmd = Super.Controllo.Commands.BuildCmd;

namespace Super.Saga.Specs.Consuntivazione.Ambiente
{
    public class Inizio_della_saga_consuntivazione_ambiente_gia_iniziata : SagaBaseClass<InterventoAmbCreated>
    {
        readonly Guid _id = Guid.NewGuid();
        readonly Guid _idImpianto = Guid.NewGuid();
        readonly Guid _idTipoIntervento = Guid.NewGuid();
        readonly Guid _idAppaltatore = Guid.NewGuid();
        readonly Guid _idCategoriaCommerciale = Guid.NewGuid();
        readonly Guid _idDirezioneRegionale = Guid.NewGuid();
        readonly Guid _idPeriodoProgrammazione = Guid.NewGuid();
        readonly Guid _idProgramma = Guid.NewGuid();
        readonly Guid _idLotto = Guid.NewGuid();
        readonly Guid _idCommittente = Guid.NewGuid();
        readonly WorkPeriod _period = new WorkPeriod(DateTime.Now.AddHours(-19), DateTime.Now.AddMinutes(-17));
        string _note = "note";
        private int _quantity = 12;
        private string _description = "desc";


        public override string ToDescription()
        {
            return "Une saga gia inziata non può essere iniziata di nuovo. vero?.";
        }

        protected override SagaHandler<InterventoAmbCreated> SagaHandler(ISagaRepository repository, IBus bus)
        {
            return new InterventoAmbCreatedHandler(repository, bus);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield return BuildEvt.InterventoAmbCreated
                .ForWorkPeriod(_period)
                .ForImpianto(_idImpianto)
                .OfTipoIntervento(_idTipoIntervento)
                .ForAppaltatore(_idAppaltatore)
                .ForCategoriaCommerciale(_idCategoriaCommerciale)
                .ForDirezioneRegionale(_idDirezioneRegionale)
                .ForQuantity(_quantity)
                .ForDescription(_description)
                .WithNote(_note)
                .ForPeriodoProgrammazione(_idPeriodoProgrammazione)
                .ForCommittente(_idCommittente)
                .ForProgramma(_idProgramma)
                .ForLotto(_idLotto)
                .Build(_id, 1);
        }

        public override InterventoAmbCreated When()
        {
            return BuildEvt.InterventoAmbCreated
                .ForWorkPeriod(_period)
                .ForImpianto(_idImpianto)
                .OfTipoIntervento(_idTipoIntervento)
                .ForAppaltatore(_idAppaltatore)
                .ForCategoriaCommerciale(_idCategoriaCommerciale)
                .ForDirezioneRegionale(_idDirezioneRegionale)
                .ForQuantity(_quantity)
                .ForDescription(_description)
                .WithNote(_note)
                .ForPeriodoProgrammazione(_idPeriodoProgrammazione)
                .ForCommittente(_idCommittente)
                .ForProgramma(_idProgramma)
                .ForLotto(_idLotto)
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
            Assert.AreEqual(typeof(SagaStateException), Caught.GetType());
        }


    }
}
