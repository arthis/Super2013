﻿using System;
using System.Collections.Generic;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Handlers;
using CommonDomain.Core.Handlers.Commands;
using CommonDomain.Core.Super.Messaging;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using CommonDomain.Persistence;
using NUnit.Framework;
using CommonSpecs;
using Super.Programmazione.Commands;
using Super.Programmazione.Commands.Scenario;
using Super.Programmazione.Commands.Schedulazione;
using Super.Programmazione.Events;
using Super.Programmazione.Handlers.Commands.Schedulazione.Rotabile;

namespace Super.Programmazione.Specs.Schedulazione.Rotabile
{
    public class aggiungere_una_schedulazione_rotabile_gia_esistente_a_un_scenario : CommandBaseClass<AddSchedulazioneRotToScenario>
    {
        private Guid _idScenario = Guid.NewGuid();
        private Guid _idUser = Guid.NewGuid();
        private string _descritpion = "description";

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
        private OggettoRot[] _oggetti = new OggettoRot[] { BuildMessagingVO.MsgOggettoRot.ForDescription("description").ForGruppo(Guid.NewGuid()).OfQuantity(2).OfType(Guid.NewGuid()).Build()};
        private string _rigaTurnoTreno = "rigaTurnoTreno";
        private Treno _trenoArrivo = BuildMessagingVO.MsgTreno.When(DateTime.Now).WithNumeroTreno("1111").Build();
        private Treno _trenoPartenza = BuildMessagingVO.MsgTreno.When(DateTime.Now.AddHours(3)).WithNumeroTreno("1141").Build();
        private string _turnoTreno = "turnoTreno";
        

        protected override CommandHandler<AddSchedulazioneRotToScenario> OnHandle(IEventRepository eventRepository)
        {
            return new AddSchedulazioneRotToScenarioHandler(eventRepository);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield return BuildEvt.ScenarioCreated
                .ByUser(_idUser)
                .ForDescription(_descritpion)
                .Build(_idScenario, 1);
            yield return BuildEvt.SchedulazioneRotAddedToScenario
                        .ForAppaltatore(_idAppaltatore)
                        .ForCategoriaCommerciale(_idCategoriaCommerciale)
                        .ForCommittente(_idCommittente)
                        .ForDirezioneRegionale(_idDirezioneRegionale)
                        .ForImpianto(_idImpianto)
                        .ForLotto(_idLotto)
                        .ForWorkPeriod(_period)
                        .ForPeriodoProgrammazione(_idPeriodoProgrammazione)
                        .ForSchedulazione(_idScenario)
                        .OfTipoIntervento(_tipoIntervento)
                        .WithNote(_note)
                        .WithOggetti(_oggetti)
                        .WithRigaTurnoTreno(_rigaTurnoTreno)
                        .WithTrenoArrivo(_trenoArrivo)
                        .WithTrenoPartenza(_trenoPartenza)
                        .WithTurnoTreno(_turnoTreno)
                        .Build(_id, 1);
        }

        public override AddSchedulazioneRotToScenario When()
        {
            return BuildCmd.AddSchedulazioneRotToScenario
                        .ForAppaltatore(_idAppaltatore)
                        .ForCategoriaCommerciale(_idCategoriaCommerciale)
                        .ForCommittente(_idCommittente)
                        .ForDirezioneRegionale(_idDirezioneRegionale)
                        .ForImpianto(_idImpianto)
                        .ForLotto(_idLotto)
                        .ForWorkPeriod(_period)
                        .ForPeriodoProgrammazione(_idPeriodoProgrammazione)
                        .ForSchedulazione(_idScenario)
                        .OfTipoIntervento(_tipoIntervento)
                        .WithNote(_note)
                        .WithOggetti(_oggetti)
                        .WithRigaTurnoTreno(_rigaTurnoTreno)
                        .WithTrenoArrivo(_trenoArrivo)
                        .WithTrenoPartenza(_trenoPartenza)
                        .WithTurnoTreno(_turnoTreno)
                        .Build(_id, 0);
        }

        public override IEnumerable<IMessage> Expect()
        {
            yield break;
        }

        [Test]
        public void genera_un_eccezzione()
        {
            Assert.IsNotNull(Caught);
            Assert.AreEqual(typeof(AlreadyCreatedAggregateRootException), Caught.GetType());
        }


    }
}
