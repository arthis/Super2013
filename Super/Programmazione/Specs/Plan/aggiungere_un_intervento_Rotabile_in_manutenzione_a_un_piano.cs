using System;
using System.Collections.Generic;
using CommonDomain;
using CommonDomain.Core.Handlers.Commands;
using CommonDomain.Core.Super.Messaging;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using CommonDomain.Persistence;
using NUnit.Framework;
using CommonSpecs;
using Super.Programmazione.Commands;
using Super.Programmazione.Commands.Plan;
using Super.Programmazione.Events;
using Super.Programmazione.Handlers.Commands.Plan;


namespace Super.Programmazione.Specs.Plan
{
    public class aggiungere_un_intervento_rotabile_in_manutenzione_a_un_piano : CommandBaseClass<AddInterventoRotManToPlan>
    {
        private Guid _idPlan = Guid.NewGuid();
        private string _descritpion = "description";
        
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
        private Guid _idScenario = Guid.NewGuid();
        private Guid _idProgramma = Guid.NewGuid();
        private Guid _idIntervento = Guid.NewGuid();
        private OggettoRotMan[] _oggetti = new OggettoRotMan[] { BuildMessagingVO.MsgOggettoRotMan.ForDescription("description").ForGruppo(Guid.NewGuid()).OfQuantity(2).OfType(Guid.NewGuid()).Build() };

        protected override CommandHandler<AddInterventoRotManToPlan> OnHandle(IEventRepository eventRepository)
        {
            return new AddInterventoRotManToPlanHandler(eventRepository);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield return BuildEvt.ProgrammaCreated
                .ByScenario(_idScenario)
                .Build(_idProgramma, 1);
            yield return BuildEvt.PlanCreated
                .ByScenario(_idScenario)
                .ForProgramma(_idProgramma)
                .Build(_idPlan, 1);
        }

        public override AddInterventoRotManToPlan When()
        {
            return BuildCmd.AddInterventoRotManToPlan
                .ForIntervento(_idIntervento)
                .ForAppaltatore(_idAppaltatore)
                .ForCategoriaCommerciale(_idCategoriaCommerciale)
                .ForCommittente(_idCommittente)
                .ForDirezioneRegionale(_idDirezioneRegionale)
                .ForImpianto(_idImpianto)
                .ForLotto(_idLotto)
                .ForWorkPeriod(_workPeriod)
                .ForPeriodoProgrammazione(_idPeriodoProgrammazione)
                .ForProgramma(_idProgramma)
                .OfTipoIntervento(_tipoIntervento)
                .WithNote(_note)
                .WithOggetti(_oggetti)
                .Build(_idPlan, 1);
        }

        public override IEnumerable<IMessage> Expect()
        {
            yield return BuildEvt.InterventoRotManAddedToProgramma 
                .ForIntervento(_idIntervento)
                .ForAppaltatore(_idAppaltatore)
                .ForCategoriaCommerciale(_idCategoriaCommerciale)
                .ForCommittente(_idCommittente)
                .ForDirezioneRegionale(_idDirezioneRegionale)
                .ForImpianto(_idImpianto)
                .ForLotto(_idLotto)
                .ForWorkPeriod(_workPeriod)
                .ForPeriodoProgrammazione(_idPeriodoProgrammazione)
                .OfTipoIntervento(_tipoIntervento)
                .WithNote(_note)
                .WithOggetti(_oggetti)
                .Build(_idProgramma, 2);
        }

        [Test]
        public void non_genera_un_eccezzione()
        {
            Assert.IsNull(Caught);
        }


    }
}
