//using System;
//using System.Collections.Generic;
//using CommonDomain;
//using CommonDomain.Core.Handlers;
//using CommonDomain.Core.Handlers.Commands;
//using CommonDomain.Core.Super.Messaging.ValueObjects;
//using CommonDomain.Persistence;
//using NUnit.Framework;
//using CommonSpecs;
//using Super.Programmazione.Commands;
//using Super.Programmazione.Commands.Schedulazione;
//using Super.Programmazione.Domain.Exceptions;
//using Super.Programmazione.Events;
//using Super.Programmazione.Handlers.Commands.Schedulazione;

//namespace Super.Programmazione.Specs.Schedulazione
//{
//    public class generare_interventi_di_una_schedulazione_in_corso_di_generazione : CommandBaseClass<AskToGenerateInterventi>
//    {
//        private Guid _idPlan = Guid.NewGuid();
//        private Guid _idUser = Guid.NewGuid();
//        private string _descritpion = "description";
//        private DateTime _promotingDate = DateTime.Now;

//        private Guid _id = Guid.NewGuid();
//        private Guid _idAppaltatore = Guid.NewGuid();
//        private Guid _idCategoriaCommerciale = Guid.NewGuid();
//        private Guid _idCommittente = Guid.NewGuid();
//        private Guid _idDirezioneRegionale = Guid.NewGuid();
//        private Guid _idImpianto = Guid.NewGuid();
//        private Guid _idLotto = Guid.NewGuid();
//        private WorkPeriod _period = new WorkPeriod(DateTime.Parse("05/08/2012 12:00"), DateTime.Parse("05/08/2012 12:15"));
//        private Guid _idPeriodoProgrammazione = Guid.NewGuid();
//        private Guid _tipoIntervento = Guid.NewGuid();
//        private string _note = "note";
//        int _quantity = 12;
//        private string _description = "description";

//        public override string ToDescription()
//        {
//            return "generare interventi di una schedulazione in corso di generezione non é autorisato";
//        }


//        protected override CommandHandler<AskToGenerateInterventi> OnHandle(IEventRepository eventRepository)
//        {
//            return new AskToGenerateInterventiHandler(eventRepository);
//        }

//        public override IEnumerable<IMessage> Given()
//        {
//            yield return BuildEvt.ScenarioCreated
//                .ByUser(_idUser)
//                .ForDescription(_descritpion)
//                .Build(_idPlan, 1);
//            yield return BuildEvt.ScenarioPromotedToPlan
//                .ByUser(_idUser)
//                .When(_promotingDate)
//                .Build(_idPlan, 2);

//            yield return BuildEvt.SchedulazioneAmbAddedToPlan
//                .ForAppaltatore(_idAppaltatore)
//                .ForCategoriaCommerciale(_idCategoriaCommerciale)
//                .ForCommittente(_idCommittente)
//                .ForDirezioneRegionale(_idDirezioneRegionale)
//                .ForImpianto(_idImpianto)
//                .ForLotto(_idLotto)
//                .ForWorkPeriod(_period)
//                .ForPeriodoProgrammazione(_idPeriodoProgrammazione)
//                .ForPlan(_idPlan)
//                .OfTipoIntervento(_tipoIntervento)
//                .WithNote(_note)
//                .ForQuantity(_quantity)
//                .ForDescription(_description)
//                .Build(_id, 1);
//            yield return BuildEvt.InterventiAskedTobeGenerated
//                .Build(_id, 2);
//        }

//        public override AskToGenerateInterventi When()
//        {
//            return BuildCmd.AskToGenerateInterventi
//                .Build(_id, 2);
//        }

//        public override IEnumerable<IMessage> Expect()
//        {
//            yield break;
//        }

//        [Test]
//        public void genera_un_eccezzione()
//        {
//            Assert.IsNotNull(Caught);
//            Assert.AreEqual(typeof(SchedulazioneInCorsoDiGenerazioneException), Caught.GetType());
//        }


//    }
//}
