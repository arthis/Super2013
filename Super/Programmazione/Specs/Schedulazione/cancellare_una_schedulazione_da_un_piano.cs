﻿using System;
using System.Collections.Generic;
using CommonDomain;
using CommonDomain.Core.Handlers;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using CommonDomain.Persistence;
using NUnit.Framework;
using CommonSpecs;
using Super.Programmazione.Commands;
using Super.Programmazione.Commands.Schedulazione;
using Super.Programmazione.Events;
using Super.Programmazione.Handlers.Schedulazione;

namespace Super.Programmazione.Specs.Schedulazione
{
    public class cancellare_una_schedulazione_da_un_piano : CommandBaseClass<CancelSchedulazioneFromPlan>
    {
        private Guid _idPlan = Guid.NewGuid();
        private Guid _idUser = Guid.NewGuid();
        private string _descritpion = "description";
        private DateTime _promotingDate = DateTime.Now;

        private Guid _id = Guid.NewGuid();
        private Guid _idAppaltatore = Guid.NewGuid();
        private Guid _idCategoriaCommerciale = Guid.NewGuid();
        private Guid _idCommittente = Guid.NewGuid();
        private Guid _idDirezioneRegionale = Guid.NewGuid();
        private Guid _idImpianto = Guid.NewGuid();
        private Guid _idLotto = Guid.NewGuid();
        private WorkPeriod _period = new WorkPeriod(DateTime.Parse("05/08/2012 12:00"), DateTime.Parse("05/08/2012 12:15"));
        private Guid _idPeriodoProgrammazione = Guid.NewGuid();
        private Guid _tipoIntervento = Guid.NewGuid();
        private string _note = "note";
        int _quantity=12;
        private string _description = "description";

        private Guid _idUserCancelling = Guid.Empty;
        private bool _deleteGeneratedInterventi = true;
        

        public override string ToDescription()
        {
            return "cancellare una schedulazione da un piano (senza interventi generati)";
        }


        protected override CommandHandler<CancelSchedulazioneFromPlan> OnHandle(IEventRepository eventRepository)
        {
            return new CancelSchedulazioneFromPlanHandler(eventRepository);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield return BuildEvt.ScenarioCreated
                .ByUser(_idUser)
                .ForDescription(_descritpion)
                .Build(_idPlan, 1);
            yield return BuildEvt.ScenarioPromotedToPlan
                .ByUser(_idUser)
                .When(_promotingDate)
                .Build(_idPlan, 2);
            
            yield return BuildEvt.SchedulazioneAmbAddedToPlan
                .ForAppaltatore(_idAppaltatore)
                .ForCategoriaCommerciale(_idCategoriaCommerciale)
                .ForCommittente(_idCommittente)
                .ForDirezioneRegionale(_idDirezioneRegionale)
                .ForImpianto(_idImpianto)
                .ForLotto(_idLotto)
                .ForPeriod(_period)
                .ForPeriodoProgrammazione(_idPeriodoProgrammazione)
                .ForPlan(_idPlan)
                .OfTipoIntervento(_tipoIntervento)
                .WithNote(_note)
                .ForQuantity(_quantity)
                .ForDescription(_description)
                .Build(_id, 1);
        }

        public override CancelSchedulazioneFromPlan When()
        {
            return BuildCmd.CancelSchedulazioneFromPlan
                .ByUser(_idUserCancelling)
                .ForAllGeneratedInterventi(_deleteGeneratedInterventi)
                .Build(_id, 1);
        }

        public override IEnumerable<IMessage> Expect()
        {
            yield break;
        }

        [Test]
        public void non_genera_un_eccezzione()
        {
            Assert.IsNull(Caught);
        }


    }
}
