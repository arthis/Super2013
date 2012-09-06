using System;
using System.Collections.Generic;
using CommonDomain;
using CommonDomain.Core.Handlers;
using CommonDomain.Core.Handlers.Commands;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using CommonDomain.Persistence;
using NUnit.Framework;
using CommonSpecs;
using Super.Programmazione.Commands;
using Super.Programmazione.Commands.Schedulazione;
using Super.Programmazione.Events;
using Super.Programmazione.Handlers.Commands.Schedulazione.Ambiente;

namespace Super.Programmazione.Specs.Schedulazione.Ambiente
{
    public class aggiungere_una_regola_a_una_schedulazione_ambiente : CommandBaseClass<AddRuleToSchedulazioneAmb>
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
        int _quantity = 12;
        private string _description = "description";
        
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



        protected override CommandHandler<AddRuleToSchedulazioneAmb> OnHandle(IEventRepository eventRepository)
        {
            return new AddRuleToSchedulazioneAmbHandler(eventRepository);
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

        public override AddRuleToSchedulazioneAmb When()
        {
            return BuildCmd.AddRuleToSchedulazioneAmb
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
            yield return BuildEvt.RuleAddedToSchedulazioneAmb
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
