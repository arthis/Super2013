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
    public class aggiungere_una_schedulazione_rotabile_in_manutenzione_a_un_piano : CommandBaseClass<AddSchedulazioneRotManToPlan>
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
        private Period _period = new Period(DateTime.Parse("05/08/2012 12:00"), DateTime.Parse("05/08/2012 12:15"));
        private Guid _idPeriodoProgrammazione = Guid.NewGuid();
        private Guid _tipoIntervento = Guid.NewGuid();
        private string _note = "note";


        private Guid _idScenario = Guid.NewGuid();
        private Guid _idProgramma = Guid.NewGuid();
        private Guid _idSchedulazione = Guid.NewGuid();
        private string _convoglio = "convoglio";
        private OggettoRotMan[] _oggetti = new OggettoRotMan[] { BuildMessagingVO.MsgOggettoRotMan.ForDescription("description").ForGruppo(Guid.NewGuid()).OfQuantity(2).OfType(Guid.NewGuid()).Build() };
        private string _rigaTurnoTreno = "rigaTurnoTreno";
        private Treno _trenoArrivo = BuildMessagingVO.MsgTreno.When(DateTime.Now).WithNumeroTreno("1111").Build();
        private Treno _trenoPartenza = BuildMessagingVO.MsgTreno.When(DateTime.Now.AddHours(3)).WithNumeroTreno("1141").Build();
        private string _turnoTreno = "turnoTreno";


        protected override CommandHandler<AddSchedulazioneRotManToPlan> OnHandle(IEventRepository eventRepository)
        {
            return new AddSchedulazioneRotManToPlanHandler(eventRepository);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield return BuildEvt.PlanCreated
                .ByScenario(_idScenario)
                .ForProgramma(_idProgramma)
                .Build(_idPlan, 1);
        }

        public override AddSchedulazioneRotManToPlan When()
        {
            return BuildCmd.AddSchedulazioneRotManToPlan
                .ForSchedulazione(_idSchedulazione)
                .ForAppaltatore(_idAppaltatore)
                .ForCategoriaCommerciale(_idCategoriaCommerciale)
                .ForCommittente(_idCommittente)
                .ForDirezioneRegionale(_idDirezioneRegionale)
                .ForImpianto(_idImpianto)
                .ForLotto(_idLotto)
                .ForWorkPeriod(_workPeriod)
                .ForPeriod(_period)
                .ForPeriodoProgrammazione(_idPeriodoProgrammazione)
                .ForProgramma(_idProgramma)
                .OfTipoIntervento(_tipoIntervento)
                .WithNote(_note)
                .WithOggetti(_oggetti)
                .Build(_idPlan, 1);
        }

        public override IEnumerable<IMessage> Expect()
        {
            yield return BuildEvt.SchedulazioneRotManAddedToPlan
                .ForSchedulazione(_idSchedulazione)
                .ForAppaltatore(_idAppaltatore)
                .ForCategoriaCommerciale(_idCategoriaCommerciale)
                .ForCommittente(_idCommittente)
                .ForDirezioneRegionale(_idDirezioneRegionale)
                .ForImpianto(_idImpianto)
                .ForLotto(_idLotto)
                .ForWorkPeriod(_workPeriod)
                .ForPeriod(_period)
                .ForPeriodoProgrammazione(_idPeriodoProgrammazione)
                .ForProgramma(_idProgramma)
                .OfTipoIntervento(_tipoIntervento)
                .WithNote(_note)
                .WithOggetti(_oggetti)
                .Build(_idPlan, 2);
        }

        [Test]
        public void non_genera_un_eccezzione()
        {
            Assert.IsNull(Caught);
        }


    }
}
