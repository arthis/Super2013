using System;
using System.Collections.Generic;
using CommonDomain;
using CommonDomain.Core.Handlers.Commands;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using CommonDomain.Persistence;
using NUnit.Framework;
using CommonSpecs;
using Super.Programmazione.Commands;
using Super.Programmazione.Commands.Programma;
using Super.Programmazione.Commands.Scenario;
using Super.Programmazione.Events;
using Super.Programmazione.Handlers.Commands.Programma;
using Super.Programmazione.Handlers.Commands.Scenario;

namespace Super.Programmazione.Specs.Programma
{
    public class aggiungere_una_schedulazione_ambiente_a_un_programma : CommandBaseClass<AddSchedulazioneAmbToProgramma>
    {
        private readonly Guid _idProgramma = Guid.NewGuid();
        private Guid _idScenario = Guid.NewGuid();
        private string _description = "description";

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
        private int _quantity = 25;
        private Period _period = new Period(DateTime.Parse("05/08/2012 12:00"), DateTime.Parse("05/08/2012 12:15"));
        private Guid _idSchedulazione = Guid.NewGuid();

        protected override CommandHandler<AddSchedulazioneAmbToProgramma> OnHandle(IEventRepository eventRepository)
        {
            return new AddSchedulazioneAmbToProgrammaHandler(eventRepository);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield return  BuildEvt.ProgrammaCreated
                .ByScenario(_idScenario)
                .Build(_idProgramma,1);
        }

        public override AddSchedulazioneAmbToProgramma When()
        {
            return BuildCmd.AddSchedulazioneAmbToProgramma
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
                .ForDescription(_description)
                .ForQuantity(_quantity)
                .Build(_idProgramma, 1);
        }

        public override IEnumerable<IMessage> Expect()
        {
            yield return BuildEvt.SchedulazioneAmbAddedToProgramma
                .ForAppaltatore(_idAppaltatore)
                .ForSchedulazione(_idSchedulazione)
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
                .ForDescription(_description)
                .ForQuantity(_quantity)
                .Build(_idProgramma, 2);
        }

        [Test]
        public void non_genera_un_eccezzione()
        {
            Assert.IsNull(Caught);
        }


    }
}
