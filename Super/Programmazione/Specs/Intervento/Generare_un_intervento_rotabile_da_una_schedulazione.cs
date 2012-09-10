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
using Super.Programmazione.Commands.Intervento;
using Super.Programmazione.Events;
using Super.Programmazione.Handlers.Commands.Intervento;


namespace Super.Programmazione.Specs.Intervento
{
    public class Generare_un_intervento_rotabile_da_una_schedulazione : CommandBaseClass<GenerateInterventoRotForSchedulazione>
    {
        private Guid _id = Guid.NewGuid();
        private Guid _idAppaltatore = Guid.NewGuid();
        private Guid _idCategoriaCommerciale = Guid.NewGuid();
        private Guid _idCommittente = Guid.NewGuid();
        private Guid _idDirezioneRegionale = Guid.NewGuid();
        private Guid _idImpianto = Guid.NewGuid();
        private Guid _idLotto = Guid.NewGuid();
        private WorkPeriod _period = new WorkPeriod(DateTime.Parse("05/08/2012 12:00"), DateTime.Parse("05/08/2012 12:15"));
        private Guid _idPeriodoProgrammazione = Guid.NewGuid();
        private Guid _idProgram = Guid.NewGuid();
        private Guid _idSchedulazione = Guid.NewGuid();
        private Guid _idInterventoGeneration = Guid.NewGuid();
        private Guid _tipoIntervento = Guid.NewGuid();
        private string _note = "note";
        private OggettoRot[] _oggetti = new OggettoRot[] { BuildMessagingVO.OggettoRot.ForDescription("description").ForGruppo(Guid.NewGuid()).OfQuantity(2).OfType(Guid.NewGuid()).Build() };
        private string _rigaTurnoTreno = "rigaTurnoTreno";
        private Treno _trenoArrivo = BuildMessagingVO.Treno.When(DateTime.Now).WithNumeroTreno("1111").Build();
        private Treno _trenoPartenza = BuildMessagingVO.Treno.When(DateTime.Now.AddHours(3)).WithNumeroTreno("1141").Build();
        private string _turnoTreno = "turnoTreno";

        protected override CommandHandler<GenerateInterventoRotForSchedulazione> OnHandle(IEventRepository eventRepository)
        {
            return new GenerateInterventoRotForSchedulazioneHandler(eventRepository);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield break;
        }

        public override GenerateInterventoRotForSchedulazione When()
        {
            return BuildCmd.GenerateInterventoRotForSchedulazione
                .ForAppaltatore(_idAppaltatore)
                .ForCategoriaCommerciale(_idCategoriaCommerciale)
                .ForCommittente(_idCommittente)
                .ForDirezioneRegionale(_idDirezioneRegionale)
                .ForImpianto(_idImpianto)
                .ForLotto(_idLotto)
                .ForWorkPeriod(_period)
                .ForPeriodoProgrammazione(_idPeriodoProgrammazione)
                .ForProgram(_idProgram)
                .ForSchedulazione(_idSchedulazione)
                .ForInterventoGeneration(_idInterventoGeneration)
                .OfTipoIntervento(_tipoIntervento)
                .WithNote(_note)
                .WithOggetti(_oggetti)
                .WithRigaTurnoTreno(_rigaTurnoTreno)
                .WithTrenoArrivo(_trenoArrivo)
                .WithTrenoPartenza(_trenoPartenza)
                .WithTurnoTreno(_turnoTreno)
                .Build(_id, 1);
        }

        public override IEnumerable<IMessage> Expect()
        {
            yield return BuildEvt.InterventoRotGeneratedFromSchedulazione
                .ForAppaltatore(_idAppaltatore)
                .OfCategoriaCommerciale(_idCategoriaCommerciale)
                .ForCommittente(_idCommittente)
                .OfDirezioneRegionale(_idDirezioneRegionale)
                .ForImpianto(_idImpianto)
                .ForLotto(_idLotto)
                .ForWorkPeriod(_period)
                .ForPeriodoProgrammazione(_idPeriodoProgrammazione)
                .ForProgram(_idProgram)
                .ForSchedulazione(_idSchedulazione)
                .ForInterventoGeneration(_idInterventoGeneration)
                .OfType(_tipoIntervento)
                .WithNote(_note)
                .WithOggetti(_oggetti)
                .WithRigaTurnoTreno(_rigaTurnoTreno)
                .WithTrenoArrivo(_trenoArrivo)
                .WithTrenoPartenza(_trenoPartenza)
                .WithTurnoTreno(_turnoTreno)
                .Build(_id, 1);
        }

        [Test]
        public void non_genera_un_eccezzione()
        {
            Assert.IsNull(Caught);
        }


    }
}
