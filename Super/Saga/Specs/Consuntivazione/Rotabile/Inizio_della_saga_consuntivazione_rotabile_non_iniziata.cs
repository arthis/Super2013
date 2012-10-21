using System;
using System.Collections.Generic;
using CommonDomain;
using CommonDomain.Core.Handlers;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using CommonDomain.Persistence;
using NUnit.Framework;
using CommonSpecs;
using Super.Saga.Handlers.Consuntivazione;
using BuildAppaltatoreCmd = Super.Appaltatore.Commands.BuildCmd;
using BuildControlloCmd = Super.Controllo.Commands.BuildCmd;
using Super.Programmazione.Events.Intervento;
using Super.Programmazione.Events;
using Super.Saga.Handlers.Intervento;

namespace Super.Saga.Specs.Consuntivazione.Rotabile
{
    public class Inizio_della_saga_consuntivazione_rotabile_non_iniziata : SagaBaseClass<InterventoRotCreated>
    {
        readonly Guid _id = Guid.NewGuid();
        readonly Guid _idImpianto = Guid.NewGuid();
        readonly Guid _idTipoIntervento = Guid.NewGuid();
        readonly Guid _idAppaltatore = Guid.NewGuid();
        readonly Guid _idCategoriaCommerciale = Guid.NewGuid();
        readonly Guid _idDirezioneRegionale = Guid.NewGuid();
        readonly Guid _idPeriodoProgrammazione = Guid.NewGuid();
        readonly Guid _idProgramma = Guid.NewGuid();
        readonly Guid _idLotto = Guid.NewGuid();
        readonly Guid _idCommittente = Guid.NewGuid();
        List<OggettoRot> _oggetti = new List<OggettoRot>() { new OggettoRot("desc", 15, Guid.NewGuid(), Guid.NewGuid()) };
        private readonly DateTime _dataConsuntivazioneAutomatica = DateTime.Now.AddHours(-17).AddMinutes(20);
        readonly WorkPeriod _workPeriod = new WorkPeriod(DateTime.Now.AddHours(-20), DateTime.Now.AddHours(-17));
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

        protected override SagaHandler<InterventoRotCreated> SagaHandler(ISagaRepository repository, IBus bus)
        {
            return new InterventoRotCreatedHandler(repository, bus);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield break;
        }

        public override InterventoRotCreated When()
        {
            return BuildEvt.InterventoRotCreated
                .ForWorkPeriod(_workPeriod)
                .ForImpianto(_idImpianto)
                .OfTipoIntervento(_idTipoIntervento)
                .ForAppaltatore(_idAppaltatore)
                .ForCategoriaCommerciale(_idCategoriaCommerciale)
                .ForDirezioneRegionale(_idDirezioneRegionale)
                .WithNote(_note)
                .WithOggetti(_oggetti.ToArray())
                .WithTrenoArrivo(_trenoArrivo)
                .WithTrenoPartenza(_trenoPartenza)
                .WithTurnoTreno(_turnoTreno)
                .WithRigaTurnoTreno(_rigaTurnoTreno)
                .ForConvoglio(_convoglio)
                .ForPeriodoProgrammazione(_idPeriodoProgrammazione)
                .ForCommittente(_idCommittente)
                .ForProgramma(_idProgramma)
                .ForLotto(_idLotto)
                .Build(_id, 0);
        }

        public override IEnumerable<IMessage> Expect()
        {
            yield return BuildAppaltatoreCmd.ProgramInterventoRot
                .ForWorkPeriod(_workPeriod)
                .ForImpianto(_idImpianto)
                .OfTipoIntervento(_idTipoIntervento)
                .ForAppaltatore(_idAppaltatore)
                .ForCategoriaCommerciale(_idCategoriaCommerciale)
                .ForDirezioneRegionale(_idDirezioneRegionale)
                .WithNote(_note)
                .WithOggetti(_oggetti.ToArray())
                .WithTrenoArrivo(_trenoArrivo)
                .WithTrenoPartenza(_trenoPartenza)
                .WithTurnoTreno(_turnoTreno)
                .WithRigaTurnoTreno(_rigaTurnoTreno)
                .ForConvoglio(_convoglio)
                .ForPeriodoProgrammazione(_idPeriodoProgrammazione)
                .ForCommittente(_idCommittente)
                .ForProgramma(_idProgramma)
                .ForLotto(_idLotto)
                .Build(_id);

            yield return BuildControlloCmd.ProgramInterventoRot
                .ForWorkPeriod(_workPeriod)
                .ForImpianto(_idImpianto)
                .OfTipoIntervento(_idTipoIntervento)
                .ForAppaltatore(_idAppaltatore)
                .ForCategoriaCommerciale(_idCategoriaCommerciale)
                .ForDirezioneRegionale(_idDirezioneRegionale)
                .WithNote(_note)
                .WithOggetti(_oggetti.ToArray())
                .WithTrenoArrivo(_trenoArrivo)
                .WithTrenoPartenza(_trenoPartenza)
                .WithTurnoTreno(_turnoTreno)
                .WithRigaTurnoTreno(_rigaTurnoTreno)
                .ForConvoglio(_convoglio)
                .ForPeriodoProgrammazione(_idPeriodoProgrammazione)
                .ForCommittente(_idCommittente)
                .ForProgramma(_idProgramma)
                .ForLotto(_idLotto)
                .Build(_id);


            yield return BuildAppaltatoreCmd.ConsuntivareAutomaticamenteNonResoInterventoRot
                .ForDataConsuntivazione(_dataConsuntivazioneAutomatica)
                .Build(_id,  _dataConsuntivazioneAutomatica);

        }

        [Test]
        public void non_genera_un_eccezzione()
        {
            Assert.IsNull(Caught);
        }


    }
}
