using System;
using System.Collections.Generic;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using CommonDomain.Persistence;
using NUnit.Framework;
using Super.Appaltatore.Commands;
using CommonSpecs;
using Super.Appaltatore.Events.Consuntivazione;
using Super.Appaltatore.Events.Programmazione;
using Super.Appaltatore.Handlers;
using BuildCmd = Super.Appaltatore.Commands.Builders.Build;
using BuildEvt = Super.Appaltatore.Events.Builders.Build;

namespace Super.Appaltatore.Specs.Consuntivazione.Rotabile
{
    public class Consuntivazione_reso_di_intervento_rotabile_programmato : CommandBaseClass<ConsuntivareRotReso>
    {
        //programmato
        readonly Guid _id = Guid.NewGuid();
        readonly Guid _idImpianto = Guid.NewGuid();
        readonly Guid _idTipoIntervento = Guid.NewGuid();
        readonly Guid _idAppaltatore = Guid.NewGuid();
        readonly Guid _idCategoriaCommerciale = Guid.NewGuid();
        readonly Guid _idDirezioneRegionale = Guid.NewGuid();
        List<OggettoRot> _oggetti = new List<OggettoRot>() { new OggettoRot("desc", 15 , Guid.NewGuid())};
        readonly WorkPeriod _period = new WorkPeriod(DateTime.Now.AddHours(-20), DateTime.Now.AddMinutes(-18));
        Treno _trenoArrivo = new Treno("numeroA" , DateTime.Now.AddHours(9));
        Treno _trenoPartenza = new Treno("numeroP", DateTime.Now.AddHours(14));
        string _turnoTreno = "turno";
        string _rigaTurnoTreno = "rigaturno";
        string _convoglio = "convoglio";
        string _note = "note";

        //Cons
        private readonly Guid _commitId = Guid.NewGuid();
        readonly string _idInterventoAppaltatore = "id intervento appaltatore";
        readonly DateTime _dataConsuntivazione = DateTime.Now;
        string _noteCons = "note";
        readonly WorkPeriod _periodCons = new WorkPeriod(DateTime.Now.AddHours(-17), DateTime.Now.AddMinutes(-10));
        List<OggettoRot> _oggettiCons = new List<OggettoRot>() { new OggettoRot("desccons", 22, Guid.NewGuid()) };
        Treno _trenoArrivoCons = new Treno("numeroA cons", DateTime.Now.AddHours(10));
        Treno _trenoPartenzaCons = new Treno("numeroP cons", DateTime.Now.AddHours(15));
        string _turnoTrenoCons = "turno Cons";
        string _rigaTurnoTrenoCons = "rigaturno Cons";
        string _convoglioCons = "convoglio Cons";
        
        protected override CommandHandler<ConsuntivareRotReso> OnHandle(IEventRepository eventRepository)
        {
            return new ConsuntivareRotResoHandler(eventRepository);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield return BuildEvt.InterventoRotProgrammato
                .ForImpianto(_idImpianto)
                .OfType(_idTipoIntervento)
                .ForAppaltatore(_idAppaltatore)
                .OfCategoriaCommerciale(_idCategoriaCommerciale)
                .OfDirezioneRegionale(_idDirezioneRegionale)
                .ForPeriod(_period)
                .WithNote(_note)
                .WithOggetti(_oggetti.ToArray())
                .WithTrenoPartenza(_trenoPartenza)
                .WithTrenoArrivo(_trenoArrivo)
                .WithTurnoTreno(_turnoTreno)
                .WithRigaTurnoTreno(_rigaTurnoTreno)
                .ForConvoglio(_convoglio)
                .Build(_id, 1);
        }

        public override ConsuntivareRotReso When()
        {
            return BuildCmd.ConsuntivareRotReso
               .ForInterventoAppaltatore(_idInterventoAppaltatore)
               .When(_dataConsuntivazione)
               .ForPeriod(_periodCons)
               .WithNote(_noteCons)
               .WithOggetti(_oggettiCons.ToArray())
               .WithTrenoPartenza(_trenoPartenzaCons)
               .WithTrenoArrivo(_trenoArrivoCons)
               .WithTurnoTreno(_turnoTrenoCons)
               .WithRigaTurnoTreno(_rigaTurnoTrenoCons)
               .ForConvoglio(_convoglioCons)
               .Build(_id, _commitId, 1);
        }

        public override IEnumerable<IMessage> Expect()
        {
            yield return BuildEvt.InterventoConsuntivatoRotReso
                .ForInterventoAppaltatore(_idInterventoAppaltatore)
                .When(_dataConsuntivazione)
                .ForPeriod(_periodCons)
                .WithNote(_noteCons)
                .WithOggetti(_oggettiCons.ToArray())
                .WithTrenoPartenza(_trenoPartenzaCons)
                .WithTrenoArrivo(_trenoArrivoCons)
                .WithTurnoTreno(_turnoTrenoCons)
                .WithRigaTurnoTreno(_rigaTurnoTrenoCons)
                .ForConvoglio(_convoglioCons)
                .Build(_id, 2);

        }

        [Test]
        public void non_genera_un_eccezzione()
        {
            Assert.IsNull(Caught);
        }


    }
}
