using System;
using System.Collections.Generic;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using CommonDomain.Core.Super.Messaging.Builders;
using CommonDomain.Persistence;
using NUnit.Framework;
using Super.Appaltatore.Commands;
using CommonSpecs;
using Super.Appaltatore.Commands.Builders;
using Super.Appaltatore.Events.Builders;
using Super.Appaltatore.Events.Programmazione;
using Super.Appaltatore.Handlers;
using BuildCmd = Super.Appaltatore.Commands.Builders.Build;
using BuildEvt = Super.Appaltatore.Events.Builders.Build;

namespace Super.Appaltatore.Specs.Programmazione.Rotabile
{
    public class Programmazione_di_intervento_rotabile_gia_esistente : CommandBaseClass<ProgrammareInterventoRot>
    {
        readonly Guid _id = Guid.NewGuid();
        readonly Guid _commitId = Guid.NewGuid();
        readonly Guid _idImpianto = Guid.NewGuid();
        readonly Guid _idTipoIntervento = Guid.NewGuid();
        readonly Guid _idAppaltatore = Guid.NewGuid();
        readonly Guid _idCategoriaCommerciale = Guid.NewGuid();
        readonly Guid _idDirezioneRegionale = Guid.NewGuid();
        readonly WorkPeriod _period = new WorkPeriod(DateTime.Now.AddHours(-17), DateTime.Now.AddMinutes(-10));
        List<OggettoRot> _oggetti = new List<OggettoRot>() { new OggettoRot("desccons", 22, Guid.NewGuid()) };
        Treno _trenoArrivo = new Treno("numeroA cons", DateTime.Now.AddHours(10));
        Treno _trenoPartenza = new Treno("numeroP cons", DateTime.Now.AddHours(15));

        string _turnoTreno = "turno";
        string _rigaTurnoTreno = "rigaturno";
        string _convoglio = "convoglio";
        string _note = "note";

        protected override CommandHandler<ProgrammareInterventoRot> OnHandle(IEventRepository eventRepository)
        {
            return new ProgrammareInterventoRotHandler(eventRepository);
        }

        public override IEnumerable<IMessage> Given()
        {
            var builder = new InterventoRotProgrammatoBuilder();

            yield return BuildEvt.InterventoRotProgrammato
                .WithOggetti(_oggetti.ToArray())
                .ForPeriod(_period)
                .ForImpianto(_idImpianto)
                .OfType(_idTipoIntervento)
                .ForAppaltatore(_idAppaltatore)
                .OfCategoriaCommerciale(_idCategoriaCommerciale)
                .OfDirezioneRegionale(_idDirezioneRegionale)
                .WithNote(_note)
                .WithTrenoPartenza(_trenoPartenza)
                .WithTrenoArrivo(_trenoArrivo)
                .WithTurnoTreno(_turnoTreno)
                .WithRigaTurnoTreno(_rigaTurnoTreno)
                .ForConvoglio(_convoglio)
                .Build(_id, 1);
        }

        public override ProgrammareInterventoRot When()
        {

            return BuildCmd.ProgrammareInterventoRot
                .WithOggetti(_oggetti.ToArray())
                .ForPeriod(_period)
                .ForImpianto(_idImpianto)
                .OfType(_idTipoIntervento)
                .ForAppaltatore(_idAppaltatore)
                .OfCategoriaCommerciale(_idCategoriaCommerciale)
                .OfDirezioneRegionale(_idDirezioneRegionale)
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
