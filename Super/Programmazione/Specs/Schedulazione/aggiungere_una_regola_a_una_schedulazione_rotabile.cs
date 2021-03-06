﻿//using System;
//using System.Collections.Generic;
//using CommonDomain;
//using CommonDomain.Core.Handlers.Commands;
//using CommonDomain.Core.Super.Messaging;
//using CommonDomain.Core.Super.Messaging.ValueObjects;
//using CommonDomain.Persistence;
//using NUnit.Framework;
//using CommonSpecs;
//using Super.Programmazione.Commands;
//using Super.Programmazione.Commands.Schedulazione;
//using Super.Programmazione.Events;
//using Super.Programmazione.Handlers.Commands.Schedulazione.Rotabile;

//namespace Super.Programmazione.Specs.Schedulazione.Rotabile
//{
//    public class aggiungere_una_regola_a_una_schedulazione_rotabile : CommandBaseClass<AddRuleToSchedulazioneRot>
//    {
//        private Guid _idPlan = Guid.NewGuid();
//        private Guid _idUser = Guid.NewGuid();
//        private string _descritpion = "description";
//        private DateTime _promotingDate = DateTime.Now;

//        private Guid _id = Guid.NewGuid();
//        private Guid _idAppaltatore =Guid.NewGuid();
//        private Guid _idCategoriaCommerciale = Guid.NewGuid();
//        private Guid _idCommittente = Guid.NewGuid();
//        private Guid _idDirezioneRegionale = Guid.NewGuid();
//        private Guid _idImpianto =Guid.NewGuid();
//        private Guid _idLotto = Guid.NewGuid();
//        private WorkPeriod _period = new WorkPeriod(DateTime.Parse("05/08/2012 12:00"), DateTime.Parse("05/08/2012 12:15"));
//        private Guid _idPeriodoProgrammazione = Guid.NewGuid();
//        private Guid _tipoIntervento = Guid.NewGuid();
//        private string _note= "note";
//        private OggettoRot[] _oggetti = new OggettoRot[] { BuildMessagingVO.MsgOggettoRot.ForDescription("description").ForGruppo(Guid.NewGuid()).OfQuantity(2).OfType(Guid.NewGuid()).Build()};
//        private string _rigaTurnoTreno = "rigaTurnoTreno";
//        private Treno _trenoArrivo = BuildMessagingVO.MsgTreno.When(DateTime.Now).WithNumeroTreno("1111").Build();
//        private Treno _trenoPartenza = BuildMessagingVO.MsgTreno.When(DateTime.Now.AddHours(3)).WithNumeroTreno("1141").Build();
//        private string _turnoTreno = "turnoTreno";
        
//        private Treno _trenoArrivoRegola = BuildMessagingVO.MsgTreno.When(DateTime.Now).WithNumeroTreno("1215").Build();
//        private WorkPeriod _workPeriodRegola = new WorkPeriod(DateTime.Parse("06/08/2012 12:00"), DateTime.Parse("06/08/2012 12:15"));

//        private Rule _rule = BuildMessagingVO.MsgRule
//            .ForFriday(true)
//            .ForHolyday(true)
//            .ForInterval(new Interval(DateTime.Now, DateTime.Now.AddDays(25)))
//            .ForMonday(true)
//            .ForPostHolyday(true)
//            .ForPreHolyday(true)
//            .ForSaturday(true)
//            .ForSunday(true)
//            .ForThursday(true)
//            .ForTuesday(true)
//            .ForWedneday(true)
//            .ForWeekEnd(true)
//            .Build();


//        protected override CommandHandler<AddRuleToSchedulazioneRot> OnHandle(IEventRepository eventRepository)
//        {
//            return new AddRuleToSchedulazioneRotHandler(eventRepository);
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
//            yield return BuildEvt.SchedulazioneRotAddedToPlan
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
//                .WithOggetti(_oggetti)
//                .WithRigaTurnoTreno(_rigaTurnoTreno)
//                .WithTrenoArrivo(_trenoArrivo)
//                .WithTrenoPartenza(_trenoPartenza)
//                .WithTurnoTreno(_turnoTreno)
//                .Build(_id, 1);
//        }

//        public override AddRuleToSchedulazioneRot When()
//        {

//            return BuildCmd.AddRuleToSchedulazioneRot
//                .WithRule(_rule)
//                .WithTrenoArrivo(_trenoArrivoRegola)
//                .WithWorkPeriod(_workPeriodRegola)
//                .Build(_id, 1);
//        }

//        public override IEnumerable<IMessage> Expect()
//        {
//            yield return BuildEvt.RuleAddedToSchedulazioneRot
//                .WithRule(_rule)
//                .WithTrenoArrivo(_trenoArrivoRegola)
//                .WithWorkPeriod(_workPeriodRegola)
//                .Build(_id, 2);

//        }

//        [Test]
//        public void non_genera_un_eccezzione()
//        {
//            Assert.IsNull(Caught);
//        }


//    }
//}
