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
using Super.Programmazione.Commands.Scenario;
using Super.Programmazione.Domain.Exceptions;
using Super.Programmazione.Events;
using Super.Programmazione.Handlers.Commands.Scenario;

namespace Super.Programmazione.Specs.Scenario
{
    public class aggiungere_una_schedulazione_rotabile_in_manutenzione_a_un_scenario_cancellato : CommandBaseClass<AddSchedulazioneRotManToScenario>
    {
        private Guid _idScenario = Guid.NewGuid();
        private Guid _idUser = Guid.NewGuid();
        private string _descritpion = "description";
        private Guid _idProgramma = Guid.NewGuid();

        private Guid _idSchedulazione = Guid.NewGuid();
        private Guid _idAppaltatore =Guid.NewGuid();
        private Guid _idCategoriaCommerciale = Guid.NewGuid();
        private Guid _idCommittente = Guid.NewGuid();
        private Guid _idDirezioneRegionale = Guid.NewGuid();
        private Guid _idImpianto =Guid.NewGuid();
        private Guid _idLotto = Guid.NewGuid();
        private WorkPeriod _workPeriod = new WorkPeriod(DateTime.Parse("05/08/2012 12:00"), DateTime.Parse("05/08/2012 12:15"));
        private Period _period = new Period(DateTime.Parse("05/08/2012 12:00"), DateTime.Parse("05/08/2012 12:15"));
        private Guid _idPeriodoProgrammazione = Guid.NewGuid();
        private Guid _tipoIntervento = Guid.NewGuid();
        private string _note= "note";
        private OggettoRotMan[] _oggetti = new OggettoRotMan[] { BuildMessagingVO.MsgOggettoRotMan.ForDescription("description").ForGruppo(Guid.NewGuid()).OfQuantity(2).OfType(Guid.NewGuid()).Build()};
        

        protected override CommandHandler<AddSchedulazioneRotManToScenario> OnHandle(IEventRepository eventRepository)
        {
            return new AddSchedulazioneRotManToScenarioHandler(eventRepository);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield return BuildEvt.ScenarioCreated
                .ByUser(_idUser)
                .ForDescription(_descritpion)
                .ForProgramma(_idProgramma)
                .Build(_idScenario, 1);
            yield return BuildEvt.ScenarioCancelled
                .ByUser(_idUser)
                .Build(_idScenario, 2);
        }

        public override AddSchedulazioneRotManToScenario When()
        {
            return BuildCmd.AddSchedulazioneRotManToScenario
                        .ForAppaltatore(_idAppaltatore)
                        .ForCategoriaCommerciale(_idCategoriaCommerciale)
                        .ForCommittente(_idCommittente)
                        .ForDirezioneRegionale(_idDirezioneRegionale)
                        .ForImpianto(_idImpianto)
                        .ForLotto(_idLotto)
                        .ForWorkPeriod(_workPeriod)
                        .ForPeriod(_period)
                        .ForPeriodoProgrammazione(_idPeriodoProgrammazione)
                        .ForSchedulazione(_idSchedulazione)
                        .OfTipoIntervento(_tipoIntervento)
                        .WithNote(_note)
                        .WithOggetti(_oggetti)
                        .Build(_idScenario, 2);
        }

        public override IEnumerable<IMessage> Expect()
        {
            yield break;
        }

        [Test]
        public void genera_un_eccezzione()
        {
            Assert.IsNotNull(Caught);
            Assert.AreEqual(typeof(ScenarioCancelledDoNotAllowFurtherChanges), Caught.GetType());
        }


    }

}
