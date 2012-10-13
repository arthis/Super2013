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
using Super.Programmazione.Commands.Schedulazione;
using Super.Programmazione.Events;
using Super.Programmazione.Handlers.Commands.Schedulazione;

namespace Super.Programmazione.Specs.Schedulazione
{
    public class creare_una_schedulazione_rotabile : CommandBaseClass<CreateSchedulazioneRot>
    {
        private readonly Guid _idProgramma = Guid.NewGuid();
        private Guid _idScenario = Guid.NewGuid();
        
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
        private Period _period = new Period(DateTime.Parse("05/08/2012 12:00"), DateTime.Parse("05/08/2012 12:15"));
        private Guid _idSchedulazione = Guid.NewGuid();
        private OggettoRot[] _oggetti = new OggettoRot[] { BuildMessagingVO.MsgOggettoRot.ForDescription("description").ForGruppo(Guid.NewGuid()).OfQuantity(2).OfType(Guid.NewGuid()).Build() };
        private string _rigaTurnoTreno = "rigaTurnoTreno";
        private Treno _trenoArrivo = BuildMessagingVO.MsgTreno.When(DateTime.Now).WithNumeroTreno("1111").Build();
        private Treno _trenoPartenza = BuildMessagingVO.MsgTreno.When(DateTime.Now.AddHours(3)).WithNumeroTreno("1141").Build();
        private string _turnoTreno = "turnoTreno";
        private const string _convoglio = "convoglio";

        protected override CommandHandler<CreateSchedulazioneRot> OnHandle(IEventRepository eventRepository)
        {
            return new CreateSchedulazioneRotHandler(eventRepository);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield return  BuildEvt.ProgrammaCreated
                .ByScenario(_idScenario)
                .Build(_idProgramma,1);
        }

        public override CreateSchedulazioneRot When()
        {
            return BuildCmd.CreateSchedulazioneRot
                .ForProgramma(_idProgramma)
                .ForAppaltatore(_idAppaltatore)
                .ForCategoriaCommerciale(_idCategoriaCommerciale)
                .ForCommittente(_idCommittente)
                .ForDirezioneRegionale(_idDirezioneRegionale)
                .ForImpianto(_idImpianto)
                .ForLotto(_idLotto)
                .ForWorkPeriod(_workPeriod)
                .ForPeriod(_period)
                .ForPeriodoProgrammazione(_idPeriodoProgrammazione)
                .OfTipoIntervento(_tipoIntervento)
                .WithNote(_note)
                .ForConvoglio(_convoglio)
                .WithOggetti(_oggetti)
                .WithRigaTurnoTreno(_rigaTurnoTreno)
                .WithTrenoArrivo(_trenoArrivo)
                .WithTrenoPartenza(_trenoPartenza)
                .WithTurnoTreno(_turnoTreno)
                .Build(_idSchedulazione, 1);
        }

        public override IEnumerable<IMessage> Expect()
        {
            yield return BuildEvt.SchedulazioneRotCreated
                .ForProgramma(_idProgramma)
                .ForAppaltatore(_idAppaltatore)
                .ForCategoriaCommerciale(_idCategoriaCommerciale)
                .ForCommittente(_idCommittente)
                .ForDirezioneRegionale(_idDirezioneRegionale)
                .ForImpianto(_idImpianto)
                .ForLotto(_idLotto)
                .ForWorkPeriod(_workPeriod)
                .ForPeriod(_period)
                .ForPeriodoProgrammazione(_idPeriodoProgrammazione)
                .OfTipoIntervento(_tipoIntervento)
                .WithNote(_note)
                .ForConvoglio(_convoglio)
                .WithOggetti(_oggetti)
                .WithRigaTurnoTreno(_rigaTurnoTreno)
                .WithTrenoArrivo(_trenoArrivo)
                .WithTrenoPartenza(_trenoPartenza)
                .WithTurnoTreno(_turnoTreno)
                .Build(_idSchedulazione, 1);
        }

        [Test]
        public void non_genera_un_eccezzione()
        {
            Assert.IsNull(Caught);
        }


    }
}
