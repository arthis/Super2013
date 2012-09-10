using System;
using System.Collections.Generic;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Handlers;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using CommonDomain.Persistence;
using NUnit.Framework;
using CommonSpecs;
using Super.Programmazione.Events.Intervento;
using Super.Programmazione.Events.Schedulazione;
using Super.Saga.Handlers;
using Super.Programmazione.Events;
using BuildCmd = Super.Appaltatore.Commands.Builders.Build;



namespace Super.Saga.Specs.Saga_Intervento.Ambiente
{
    public class Inizio_della_saga_intervento_ambiente_gia_iniziata : SagaBaseClass<InterventoAmbScheduled>
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
        readonly WorkPeriod _period = new WorkPeriod(DateTime.Now.AddHours(-19), DateTime.Now.AddMinutes(-17));
        string _note = "note";
        private int _quantity = 12;
        private string _description = "desc";


        public override string ToDescription()
        {
            return "Une saga gia inziata non può essere iniziata di nuovo. vero?.";
        }

        protected override SagaHandler<InterventoAmbScheduled> SagaHandler(ISagaRepository repository, IBus bus)
        {
            return new InterventoAmbScheduledHandler(repository, bus);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield return BuildEvt.InterventoAmbScheduled
                .ForWorkPeriod(_period)
                .ForImpianto(_idImpianto)
                .OfType(_idTipoIntervento)
                .ForAppaltatore(_idAppaltatore)
                .OfCategoriaCommerciale(_idCategoriaCommerciale)
                .OfDirezioneRegionale(_idDirezioneRegionale)
                .ForQuantity(_quantity)
                .ForDescription(_description)
                .WithNote(_note)
                .ForPeriodoProgrammazione(_idPeriodoProgrammazione)
              .ForCommittente(_idCommittente)
              .ForPlan(_idPlan)
              .ForLotto(_idLotto)
                .Build(_id, 1);
        }

        public override InterventoAmbScheduled When()
        {
            return BuildEvt.InterventoAmbScheduled
                .ForWorkPeriod(_period)
                .ForImpianto(_idImpianto)
                .OfType(_idTipoIntervento)
                .ForAppaltatore(_idAppaltatore)
                .OfCategoriaCommerciale(_idCategoriaCommerciale)
                .OfDirezioneRegionale(_idDirezioneRegionale)
                .ForQuantity(_quantity)
                .ForDescription(_description)
                .WithNote(_note)
                .ForPeriodoProgrammazione(_idPeriodoProgrammazione)
              .ForCommittente(_idCommittente)
              .ForPlan(_idPlan)
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
            Assert.AreEqual(typeof(Exception), Caught.GetType());
        }


    }
}
