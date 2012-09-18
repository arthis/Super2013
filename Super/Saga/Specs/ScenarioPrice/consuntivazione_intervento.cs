using System;
using System.Collections.Generic;
using CommonDomain;
using CommonDomain.Core.Handlers;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using CommonDomain.Persistence;
using NUnit.Framework;
using CommonSpecs;
using Super.Appaltatore.Events.Consuntivazione;
using Super.Controllo.Commands.Builders;
using Super.Programmazione.Events.Schedulazione;
using Super.Saga.Handlers;
using Super.Programmazione.Events;


namespace Super.Saga.Specs.ScenarioPrice
{
    public class consuntivazione_intervento : SagaBaseClass<SchedulazioneAmbAddedToScenario>
    {
        private Guid _idScenario = Guid.NewGuid();
        private Guid _idAppaltatore = Guid.NewGuid();
        private Guid _idCategoriaCommerciale = Guid.NewGuid();
        private Guid _idCommittente = Guid.NewGuid();
        private Guid _idDirezioneRegionale = Guid.NewGuid();
        private Guid _idImpianto = Guid.NewGuid();
        private Guid _idLotto = Guid.NewGuid();
        private WorkPeriod _workPeriod = new WorkPeriod(DateTime.Parse("05/08/2012 12:00"), DateTime.Parse("05/08/2012 12:15"));
        private Guid _idPeriodoProgrammazione = Guid.NewGuid();
        private Guid _tipoIntervento = Guid.NewGuid();
        private string _note = "note";
        private int _quantity = 25;
        private string _description = "description";
        private Period _period = new Period(DateTime.Parse("05/08/2012 12:00"), DateTime.Parse("05/08/2012 12:15"));
        private Guid _idSchedulazione = Guid.NewGuid();


        public override string ToDescription()
        {
            return "";
        }

        protected override SagaHandler<SchedulazioneAmbAddedToScenario> SagaHandler(ISagaRepository repository, IBus bus)
        {
            return new SchedulazioneAmbAddedToScenarioHandler(repository, bus);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield break;
        }

        public override SchedulazioneAmbAddedToScenario When()
        {
            return BuildEvt.SchedulazioneAmbAddedToScenario
                .ForAppaltatore(_idAppaltatore)
                .ForCategoriaCommerciale(_idCategoriaCommerciale)
                .ForCommittente(_idCommittente)
                .ForDirezioneRegionale(_idDirezioneRegionale)
                .ForImpianto(_idImpianto)
                .ForLotto(_idLotto)
                .ForWorkPeriod(_workPeriod)
                .ForPeriod(_period)
                .ForPeriodoProgrammazione(_idPeriodoProgrammazione)
                .ForScenario(_idScenario)
                .OfTipoIntervento(_tipoIntervento)
                .WithNote(_note)
                .ForQuantity(_quantity)
                .ForDescription(_description)
                .Build(_idSchedulazione, 1);
            
        }

        public override IEnumerable<IMessage> Expect()
        {
            yield return BuildC.AllowControlIntervento
                                     .Build(_id,0);
        }

        [Test]
        public void non_genera_un_eccezzione()
        {
            Assert.IsNull(Caught);
        }


    }
}
