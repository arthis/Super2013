//using System;
//using System.Collections.Generic;
//using CommonDomain;
//using CommonDomain.Core.Handlers;
//using CommonDomain.Core.Super.Messaging.ValueObjects;
//using CommonDomain.Persistence;
//using NUnit.Framework;
//using CommonSpecs;
//using Super.Contabilita.Commands;
//using Super.Programmazione.Events.Scenario;
//using Super.Programmazione.Events.Schedulazione;
//using Super.Programmazione.Events;
//using Super.Saga.Handlers.ScenarioPrice;


//namespace Super.Saga.Specs.ScenarioPrice
//{
//    public class calcolo_del_prezzo_della_schedulazione_ambiente : SagaBaseClass<SchedulazioneAmbAddedToScenario>
//    {
//        private Guid _idScenario = Guid.NewGuid();
//        private Guid _idAppaltatore = Guid.NewGuid();
//        private Guid _idCategoriaCommerciale = Guid.NewGuid();
//        private Guid _idCommittente = Guid.NewGuid();
//        private Guid _idDirezioneRegionale = Guid.NewGuid();
//        private Guid _idImpianto = Guid.NewGuid();
//        private Guid _idLotto = Guid.NewGuid();
//        private WorkPeriod _workPeriod = new WorkPeriod(DateTime.Parse("05/08/2012 12:00"), DateTime.Parse("05/08/2012 12:15"));
//        private Guid _idPeriodoProgrammazione = Guid.NewGuid();
//        private Guid _idTipoIntervento = Guid.NewGuid();
//        private string _note = "note";
//        private int _quantity = 25;
//        private string _description = "description";
//        private WorkPeriod _period = new WorkPeriod(DateTime.Parse("05/08/2012 12:00"), DateTime.Parse("05/08/2012 12:15"));
//        private Guid _idSchedulazione = Guid.NewGuid();


//        public override string ToDescription()
//        {
//            return "";
//        }

//        protected override SagaHandler<SchedulazioneAmbAddedToScenario> SagaHandler(ISagaRepository repository, IBus bus)
//        {
//            return new SchedulazioneAmbAddedToScenarioHandler(repository, bus);
//        }

//        public override IEnumerable<IMessage> Given()
//        {
//            yield break;
//        }

//        public override SchedulazioneAmbAddedToScenario When()
//        {
//            return BuildEvt.SchedulazioneAmbAddedToScenario
//                .ForAppaltatore(_idAppaltatore)
//                .ForCategoriaCommerciale(_idCategoriaCommerciale)
//                .ForCommittente(_idCommittente)
//                .ForDirezioneRegionale(_idDirezioneRegionale)
//                .ForImpianto(_idImpianto)
//                .ForLotto(_idLotto)
//                .ForWorkPeriod(_workPeriod)
//                .ForWorkPeriod(_period)
//                .ForPeriodoProgrammazione(_idPeriodoProgrammazione)
//                .ForScenario(_idScenario)
//                .OfTipoIntervento(_idTipoIntervento)
//                .WithNote(_note)
//                .ForQuantity(_quantity)
//                .ForDescription(_description)
//                .Build(_idSchedulazione, 1);
            
//        }

//        public override IEnumerable<IMessage> Expect()
//        {
//            yield return BuildCmd.CalculateSchedulazioneAmbPriceOfScenario
//                                 .ForWorkPeriod(_period)
//                                 .ForScenario(_idScenario)
//                                 .ForSchedulazione(_idSchedulazione)
//                                 .ForTipoIntervento(_idTipoIntervento)
//                                 .ForWorkPeriod(_workPeriod)
//                                 .ForQuantity(_quantity)
//                                 .ForDescription(_description)
//                                 .Build(_idSchedulazione,0);
            
//        }

//        [Test]
//        public void non_genera_un_eccezzione()
//        {
//            Assert.IsNull(Caught);
//        }


//    }
//}
