﻿using System;
using System.Collections.Generic;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Handlers;
using CommonDomain.Core.Handlers.Commands;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using CommonDomain.Core.Super.Messaging.Builders;
using CommonDomain.Persistence;
using NUnit.Framework;
using Super.Controllo.Commands;
using CommonSpecs;
using Super.Controllo.Commands.Programmazione;
using Super.Controllo.Events.Programmazione;
using Super.Controllo.Events.Programmazione.Builders;
using Super.Controllo.Handlers;
using BuildCmd = Super.Controllo.Commands.BuildCmd;
using Super.Controllo.Events;

namespace Super.Controllo.Specs.Programmazione.Rotabile
{
    public class Programmazione_di_intervento_rotabile_gia_esistente : CommandBaseClass<ProgramInterventoRot>
    {
        readonly Guid _id = Guid.NewGuid();
        readonly Guid _commitId = Guid.NewGuid();
        readonly Guid _idImpianto = Guid.NewGuid();
        readonly Guid _idTipoIntervento = Guid.NewGuid();
        readonly Guid _idAppaltatore = Guid.NewGuid();
        readonly Guid _idCategoriaCommerciale = Guid.NewGuid();
        readonly Guid _idDirezioneRegionale = Guid.NewGuid();
        readonly WorkPeriod _workPeriod = new WorkPeriod(DateTime.Now.AddHours(-17), DateTime.Now.AddMinutes(-10));
        List<OggettoRot> _oggetti = new List<OggettoRot>() { new OggettoRot("desccons", 22, Guid.NewGuid(), Guid.NewGuid()) };
        Treno _trenoArrivo = new Treno("numeroA cons", DateTime.Now.AddHours(10));
        Treno _trenoPartenza = new Treno("numeroP cons", DateTime.Now.AddHours(15));

        string _turnoTreno = "turno";
        string _rigaTurnoTreno = "rigaturno";
        string _convoglio = "convoglio";
        string _note = "note";

        protected override CommandHandler<ProgramInterventoRot> OnHandle(IEventRepository eventRepository)
        {
            return new ProgramInterventoRotHandler(eventRepository);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield return BuildEvt.InterventoRotProgrammato
                .WithOggetti(_oggetti.ToArray())
                .ForWorkPeriod(_workPeriod)
                .ForImpianto(_idImpianto)
                .OfTipoIntervento(_idTipoIntervento)
                .ForAppaltatore(_idAppaltatore)
                .ForCategoriaCommerciale(_idCategoriaCommerciale)
                .ForDirezioneRegionale(_idDirezioneRegionale)
                .WithNote(_note)
                .WithTrenoPartenza(_trenoPartenza)
                .WithTrenoArrivo(_trenoArrivo)
                .WithTurnoTreno(_turnoTreno)
                .WithRigaTurnoTreno(_rigaTurnoTreno)
                .ForConvoglio(_convoglio)
                .Build(_id, 1);
        }

        public override ProgramInterventoRot When()
        {
            return BuildCmd.ProgramInterventoRot
                .WithOggetti(_oggetti.ToArray())
                .ForWorkPeriod(_workPeriod)
                .ForImpianto(_idImpianto)
                .OfTipoIntervento(_idTipoIntervento)
                .ForAppaltatore(_idAppaltatore)
                .ForCategoriaCommerciale(_idCategoriaCommerciale)
                .ForDirezioneRegionale(_idDirezioneRegionale)
                .WithNote(_note)
                .WithTrenoPartenza(_trenoPartenza)
                .WithTrenoArrivo(_trenoArrivo)
                .WithTurnoTreno(_turnoTreno)
                .WithRigaTurnoTreno(_rigaTurnoTreno)
                .ForConvoglio(_convoglio)
                .Build(_id, _commitId, 1);

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
