using System;
using System.Collections.Generic;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Handlers;
using CommonDomain.Core.Handlers.Commands;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using CommonDomain.Persistence;
using NUnit.Framework;
using Super.Appaltatore.Commands;
using CommonSpecs;
using Super.Appaltatore.Commands.Consuntivazione;
using Super.Appaltatore.Events.Consuntivazione;
using Super.Appaltatore.Events.Programmazione;
using Super.Appaltatore.Handlers;
using BuildCmd = Super.Appaltatore.Commands.BuildCmd;
using Super.Appaltatore.Events;

namespace Super.Appaltatore.Specs.Consuntivazione.Rotabile
{
    public class Consuntivazione_reso_di_intervento_rotabile_gia_consutivato_reso : CommandBaseClass<ConsuntivareResoInterventoRot>
    {
        //programmato
        readonly Guid _id = Guid.NewGuid();
        readonly Guid _idImpianto = Guid.NewGuid();
        readonly Guid _idTipoIntervento = Guid.NewGuid();
        readonly Guid _idAppaltatore = Guid.NewGuid();
        readonly Guid _idCategoriaCommerciale = Guid.NewGuid();
        readonly Guid _idDirezioneRegionale = Guid.NewGuid();
        List<OggettoRot> _oggetti = new List<OggettoRot>() { new OggettoRot("desc", 15, Guid.NewGuid(), Guid.NewGuid()) };
        readonly WorkPeriod _workPeriod = new WorkPeriod(DateTime.Now.AddHours(-20), DateTime.Now.AddMinutes(-18));
        Treno _trenoArrivo = new Treno("numeroA", DateTime.Now.AddHours(9));
        Treno _trenoPartenza = new Treno("numeroP", DateTime.Now.AddHours(14));
        string _turnoTreno = "turno";
        string _rigaTurnoTreno = "rigaturno";
        string _convoglio = "convoglio";
        string _note = "note";

        //Cons
        readonly string _idInterventoAppaltatore = "id intervento appaltatore";
        readonly DateTime _dataConsuntivazione = DateTime.Now;
        string _noteCons = "note";
        List<OggettoRot> _oggettiCons = new List<OggettoRot>() { new OggettoRot("desc cons ", 12, Guid.NewGuid(), Guid.NewGuid()) };
        readonly WorkPeriod _workPeriodCons = new WorkPeriod(DateTime.Now.AddHours(-20), DateTime.Now.AddMinutes(-19));
        

        //Cons 2
        private readonly Guid _commitId = Guid.NewGuid();
        readonly string _idInterventoAppaltatoreCons2 = "id intervento appaltatore Cons2";
        readonly DateTime _dataConsuntivazioneCons2 = DateTime.Now.AddSeconds(-20);

        string _noteCons2 = "note  Cons2";
        List<OggettoRot> _oggettiCons2 = new List<OggettoRot>() { new OggettoRot("desc cons 2", 15, Guid.NewGuid(), Guid.NewGuid()) };
        readonly WorkPeriod _workPeriodCons2 = new WorkPeriod(DateTime.Now.AddHours(-20), DateTime.Now.AddMinutes(-20));
        private Guid _idProgramma = Guid.NewGuid();
        private Guid _idPeriodoProgrammazione = Guid.NewGuid();
        private Guid _idCommittente = Guid.NewGuid();
        private Guid _idlotto = Guid.NewGuid();
        

        protected override CommandHandler<ConsuntivareResoInterventoRot> OnHandle(IEventRepository eventRepository)
        {
            return new ConsuntivareResoRotHandler(eventRepository);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield return BuildEvt.InterventoRotProgrammato
                .ForImpianto(_idImpianto)
                .OfTipoIntervento(_idTipoIntervento)
                .ForAppaltatore(_idAppaltatore)
                .ForCategoriaCommerciale(_idCategoriaCommerciale)
                .ForDirezioneRegionale(_idDirezioneRegionale)
                .ForWorkPeriod(_workPeriod)
                .WithNote(_note)
                .WithOggetti(_oggetti.ToArray())
                .WithTrenoPartenza(_trenoPartenza)
                .WithTrenoArrivo(_trenoArrivo)
                .WithTurnoTreno(_turnoTreno)
                .WithRigaTurnoTreno(_rigaTurnoTreno)
                .ForConvoglio(_convoglio)
                .ForProgramma(_idProgramma)
                .ForPeriodoProgrammazione(_idPeriodoProgrammazione)
                .ForCommittente(_idCommittente)
                .ForLotto(_idlotto)
                .Build(_id, 1);
            yield return BuildEvt.InterventoRotConsuntivatoReso
                .ForInterventoAppaltatore(_idInterventoAppaltatore)
                .When(_dataConsuntivazione)
                .ForWorkPeriod(_workPeriodCons)
                .WithNote(_noteCons)
                .WithOggetti(_oggettiCons.ToArray())
                .Build(_id, 2);
        }

        public override ConsuntivareResoInterventoRot When()
        {
            return BuildCmd.ConsuntivareResoInterventoRot
                .ForInterventoAppaltatore(_idInterventoAppaltatoreCons2)
                .ForDataConsuntivazione(_dataConsuntivazioneCons2)
                .ForWorkPeriod(_workPeriodCons2)
                .WithNote(_noteCons2)
                .WithOggetti(_oggettiCons2.ToArray())
                .Build(_id, _commitId, 2);
        }

        public override IEnumerable<IMessage> Expect()
        {
            yield return BuildEvt.InterventoRotConsuntivatoReso
                .ForInterventoAppaltatore(_idInterventoAppaltatoreCons2)
                .When(_dataConsuntivazioneCons2)
                .ForWorkPeriod(_workPeriodCons2)
                .WithNote(_noteCons2)
                .WithOggetti(_oggettiCons2.ToArray())
                .Build(_id, 3);
        }

        [Test]
        public void non_genera_un_eccezzione()
        {
            Assert.IsNull(Caught);
        }


    }
}