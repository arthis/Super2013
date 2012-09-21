using System;
using System.Collections.Generic;
using CommonDomain;
using CommonDomain.Core.Handlers;
using CommonDomain.Core.Handlers.Commands;
using CommonDomain.Core.Super.Messaging;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using CommonDomain.Persistence;
using NUnit.Framework;
using CommonSpecs;
using Super.Programmazione.Commands;
using Super.Programmazione.Commands.Schedulazione;
using Super.Programmazione.Events;
using Super.Programmazione.Handlers.Commands.Schedulazione.RotabileInManutenzione;

namespace Super.Programmazione.Specs.Schedulazione.RotabileInManutenzione
{
    public class aggiungere_una_regola_a_una_schedulazione_rotabile_in_manutenzione : CommandBaseClass<AddRuleToSchedulazioneRotMan>
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
        private OggettoRotMan[] _oggetti = new OggettoRotMan[] { BuildMessagingVO.MsgOggettoRotMan.ForDescription("description").ForGruppo(Guid.NewGuid()).OfQuantity(2).OfType(Guid.NewGuid()).Build() };

        private Rule _rule = BuildMessagingVO.MsgRule
           .ForFriday(true)
           .ForHolyday(true)
           .ForInterval(new Interval(DateTime.Now, DateTime.Now.AddDays(25)))
           .ForMonday(true)
           .ForPostHolyday(true)
           .ForPreHolyday(true)
           .ForSaturday(true)
           .ForSunday(true)
           .ForThursday(true)
           .ForTuesday(true)
           .ForWedneday(true)
           .ForWeekEnd(true)
           .Build();

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
                       .ForWorkPeriod(_period)
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
                        .WithRule(_rule)
                        .Build(_id, 1);
        }

        public override IEnumerable<IMessage> Expect()
        {
            yield return BuildEvt.RuleAddedToSchedulazioneRotMan
                .WithRule(_rule)
                .Build(_id, 2);

        }

        [Test]
        public void non_genera_un_eccezzione()
        {
            Assert.IsNull(Caught);
        }


    }
}
