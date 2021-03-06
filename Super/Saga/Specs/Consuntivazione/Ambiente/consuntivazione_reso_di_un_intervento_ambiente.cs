﻿using System;
using System.Collections.Generic;
using CommonDomain;
using CommonDomain.Core.Handlers;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using CommonDomain.Persistence;
using NUnit.Framework;
using CommonSpecs;
using Super.Appaltatore.Events.Consuntivazione;
using Super.Saga.Handlers.Consuntivazione;
using BuildAppaltatoreCmd = Super.Appaltatore.Commands.BuildCmd;
using BuildControlloCmd = Super.Controllo.Commands.BuildCmd;

using Super.Programmazione.Events;
using Super.Saga.Handlers.Intervento;

namespace Super.Saga.Specs.Consuntivazione.Ambiente
{
    public class consuntivazione_reso_di_un_intervento_ambiente : SagaBaseClass<InterventoAmbConsuntivatoReso>
    {
        readonly Guid _id = Guid.NewGuid();
        readonly Guid _idImpianto = Guid.NewGuid();
        readonly Guid _idTipoIntervento = Guid.NewGuid();
        readonly Guid _idAppaltatore = Guid.NewGuid();
        readonly Guid _idCategoriaCommerciale = Guid.NewGuid();
        readonly Guid _idDirezioneRegionale = Guid.NewGuid();
        readonly Guid _idPeriodoProgrammazione = Guid.NewGuid();
        readonly Guid _idPlan = Guid.NewGuid();
        readonly Guid _idLotto = Guid.NewGuid();
        readonly Guid _idCommittente = Guid.NewGuid();
        readonly WorkPeriod _workPeriod = new WorkPeriod(DateTime.Now.AddHours(-20), DateTime.Now.AddMinutes(-18));
        private int _quantity = 12;
        private string _description = "desc";
        string _note = "note";

        readonly string _idInterventoAppaltatore = "dsfsd";
        readonly WorkPeriod _periodCons = new WorkPeriod(DateTime.Now.AddHours(-19), DateTime.Now.AddMinutes(-17));
        private int _quantityCons = 13;
        private DateTime DataCons = DateTime.Now;
        string _noteCons = "note cons";
        private Guid _idProgramma = Guid.NewGuid();

        public override string ToDescription()
        {
            return "";
        }

        protected override SagaHandler<InterventoAmbConsuntivatoReso> SagaHandler(ISagaRepository repository, IBus bus)
        {
            return new InterventoAmbConsuntivatoResoHandler(repository, bus);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield return   BuildEvt.InterventoAmbCreated
                .ForWorkPeriod(_workPeriod)
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

        public override InterventoAmbConsuntivatoReso When()
        {
            return Appaltatore.Events.BuildEvt.InterventoAmbConsuntivatoReso
                .ForDescription(_description)
                .ForInterventoAppaltatore(_idInterventoAppaltatore)
                .ForWorkPeriod(_periodCons)
                .ForQuantity(_quantityCons)
                .When(DataCons)
                .WithNote(_noteCons)
                .Build(_id, 14);

        }

        public override IEnumerable<IMessage> Expect()
        {
            yield return BuildControlloCmd.ConsuntivareResoInterventoAmb
                .ForDescription(_description)
                .ForInterventoAppaltatore(_idInterventoAppaltatore)
                .ForWorkPeriod(_periodCons)
                .ForQuantity(_quantityCons)
                .When(DataCons)
                .WithNote(_noteCons)
                .Build(_id);
        }

        [Test]
        public void non_genera_un_eccezzione()
        {
            Assert.IsNull(Caught);
        }


    }
}
