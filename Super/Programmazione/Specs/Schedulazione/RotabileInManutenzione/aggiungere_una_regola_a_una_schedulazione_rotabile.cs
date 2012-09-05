using System;
using System.Collections.Generic;
using CommonDomain;
using CommonDomain.Core.Handlers;
using CommonDomain.Core.Super.Messaging;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using CommonDomain.Persistence;
using NUnit.Framework;
using CommonSpecs;
using Super.Programmazione.Commands;
using Super.Programmazione.Commands.Schedulazione;
using Super.Programmazione.Events;
using Super.Programmazione.Handlers.Schedulazione.RotabileInManutenzione;

namespace Super.Programmazione.Specs.Schedulazione.RotabileInManutenzione
{
    public class aggiungere_una_regola_a_una_schedulazione_rotabile_in_manutenzione : CommandBaseClass<AddRuleToSchedulazioneRotMan>
    {
        private Guid _idPlan = Guid.NewGuid();
        private Guid _idUser = Guid.NewGuid();
        private string _descritpion = "description";
        private DateTime _promotingDate = DateTime.Now;

        private Guid _id = Guid.NewGuid();
        private Guid _idAppaltatore =Guid.NewGuid();
        private Guid _idCategoriaCommerciale = Guid.NewGuid();
        private Guid _idCommittente = Guid.NewGuid();
        private Guid _idDirezioneRegionale = Guid.NewGuid();
        private Guid _idImpianto =Guid.NewGuid();
        private Guid _idLotto = Guid.NewGuid();
        private WorkPeriod _period = new WorkPeriod(DateTime.Parse("05/08/2012 12:00"), DateTime.Parse("05/08/2012 12:15"));
        private Guid _idPeriodoProgrammazione = Guid.NewGuid();
        private Guid _tipoIntervento = Guid.NewGuid();
        private string _note= "note";
        private OggettoRotMan[] _oggetti = new OggettoRotMan[] { BuildMessagingVO.OggettoRotMan.ForDescription("description").ForGruppo(Guid.NewGuid()).OfQuantity(2).OfType(Guid.NewGuid()).Build()};
        
        private bool _friday = true;
        private bool _holyday = true;
        private Interval _interval = new Interval(DateTime.Now,DateTime.Now.AddDays(25));
        private bool _monday =true;
        private bool _postholyday = true;
        private bool _preholyday = true;
        private bool _saturday = true;
        private bool _sunday = true;
        private bool _thursday = true;
        private bool _tuesday=true;
        private bool _wednesday = true;
        private bool _weekend = true;

        protected override CommandHandler<AddRuleToSchedulazioneRotMan> OnHandle(IEventRepository eventRepository)
        {
            return new AddRuleToSchedulazioneRotManHandler(eventRepository);
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
            yield return BuildEvt.SchedulazioneRotManAddedToPlan
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
                       .WithOggetti(_oggetti)
               .Build(_id, 1);
        }

        public override AddRuleToSchedulazioneRotMan When()
        {
            return BuildCmd.AddRuleToSchedulazioneRotMan
                        .WithFriday(_friday)
                        .WithHolyDay(_holyday)
                        .WithInterval(_interval)
                        .WithMonday(_monday)
                        .WithPostHolyDay(_postholyday)
                        .WithPreHolyDay(_preholyday)
                        .WithSaturday(_saturday)
                        .WithSunday(_sunday)
                        .WithThursday(_thursday)
                        .WithTuesday(_tuesday)
                        .WithWedneday(_wednesday)
                        .WithWeekEnd(_weekend)
                        .Build(_id, 1);
        }

        public override IEnumerable<IMessage> Expect()
        {
            yield return BuildEvt.RuleAddedToSchedulazioneRotMan
                .WithFriday(_friday)
                .WithHolyDay(_holyday)
                .WithInterval(_interval)
                .WithMonday(_monday)
                .WithPostHolyDay(_postholyday)
                .WithPreHolyDay(_preholyday)
                .WithSaturday(_saturday)
                .WithSunday(_sunday)
                .WithThursday(_thursday)
                .WithTuesday(_tuesday)
                .WithWedneday(_wednesday)
                .WithWeekEnd(_weekend)
                .Build(_id, 2);

        }

        [Test]
        public void non_genera_un_eccezzione()
        {
            Assert.IsNull(Caught);
        }


    }
}
