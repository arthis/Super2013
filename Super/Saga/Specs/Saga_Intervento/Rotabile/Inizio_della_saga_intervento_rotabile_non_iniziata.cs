using System;
using System.Collections.Generic;
using CommandService;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using CommonDomain.Persistence;
using EasyNetQ;
using NUnit.Framework;
using CommonSpecs;
using Super.Appaltatore.Commands;
using Super.Appaltatore.Commands.Builders;
using Super.Saga.Handlers;
using Super.Programmazione.Events;
using BuildEvt = Super.Programmazione.Events.Builders.Build;
using BuildCmd = Super.Appaltatore.Commands.Builders.Build;


namespace Super.Saga.Specs.Saga_Intervento.Rotabile
{
    public class Inizio_della_saga_intervento_rotabile_non_iniziata : SagaBaseClass<InterventoRotPianificato>
    {
        readonly Guid _id = Guid.NewGuid();
        readonly Guid _idImpianto = Guid.NewGuid();
        readonly Guid _idTipoIntervento = Guid.NewGuid();
        readonly Guid _idAppaltatore = Guid.NewGuid();
        readonly Guid _idCategoriaCommerciale = Guid.NewGuid();
        readonly Guid _idDirezioneRegionale = Guid.NewGuid();
        List<OggettoRot> _oggetti = new List<OggettoRot>() { new OggettoRot("desc", 15, Guid.NewGuid()) };
        readonly WorkPeriod _period = new WorkPeriod(DateTime.Now.AddHours(-20), DateTime.Now.AddMinutes(-18));
        Treno _trenoArrivo = new Treno("numeroA", DateTime.Now.AddHours(9));
        Treno _trenoPartenza = new Treno("numeroP", DateTime.Now.AddHours(14));
        string _turnoTreno = "turno";
        string _rigaTurnoTreno = "rigaturno";
        string _convoglio = "convoglio";
        string _note = "note";

        public override string ToDescription()
        {
            return "un inizo di saga normale";
        }

        protected override SagaHandler<InterventoRotPianificato> SagaHandler(ISagaRepository repository, IBus bus)
        {
            return new InterventoRotPianificatoHandler(repository, bus);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield break;
        }

        public override InterventoRotPianificato When()
        {
            return BuildEvt.InterventoRotPianificato
                .ForPeriod(_period)
                .ForImpianto(_idImpianto)
                .OfType(_idTipoIntervento)
                .ForAppaltatore(_idAppaltatore)
                .OfCategoriaCommerciale(_idCategoriaCommerciale)
                .OfDirezioneRegionale(_idDirezioneRegionale)
                .WithNote(_note)
                .WithOggetti(_oggetti.ToArray())
                .WithTrenoArrivo(_trenoArrivo)
                .WithTrenoPartenza(_trenoPartenza)
                .WithTurnoTreno(_turnoTreno)
                .WithRigaTurnoTreno(_rigaTurnoTreno)
                .ForConvoglio(_convoglio)
                .Build(_id, 0);
        }

        public override IEnumerable<IMessage> Expect()
        {
            yield return BuildCmd.ProgrammareInterventoRot
                            .ForPeriod(_period)
                            .ForImpianto(_idImpianto)
                            .OfType(_idTipoIntervento)
                            .ForAppaltatore(_idAppaltatore)
                            .OfCategoriaCommerciale(_idCategoriaCommerciale)
                            .OfDirezioneRegionale(_idDirezioneRegionale)
                            .WithNote(_note)
                            .WithOggetti(_oggetti.ToArray())
                            .WithTrenoPartenza(_trenoPartenza)
                            .WithTrenoArrivo(_trenoArrivo)
                            .WithTurnoTreno(_turnoTreno)
                            .WithRigaTurnoTreno(_rigaTurnoTreno)
                            .ForConvoglio(_convoglio)
                            .Build(_id, 0);
        }

        [Test]
        public void non_genera_un_eccezzione()
        {
            Assert.IsNull(Caught);
        }


    }
}
