using System;
using System.Collections.Generic;
using CommonDomain;
using CommonDomain.Core.Handlers.Commands;
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
    public class Generare_un_intervento_ambiente_da_una_schedulazione : CommandBaseClass<GenerateInterventoAmbForSchedulazione>
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
        private int _quantity = 12;
        private string _description = "sdsdsd";

        protected override CommandHandler<GenerateInterventoAmbForSchedulazione> OnHandle(IEventRepository eventRepository)
        {
            return new GenerateInterventoAmbForSchedulazioneHandler(eventRepository);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield break;
        }

        public override GenerateInterventoAmbForSchedulazione When()
        {
            return BuildCmd.GenerateInterventoAmbForSchedulazione
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
                .ForQuantity(_quantity)
                .ForDescription(_description)
                .Build(_id, 1);
        }

        public override IEnumerable<IMessage> Expect()
        {
            yield return BuildEvt.InterventoAmbGeneratedFromSchedulazione
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
                .ForQuantity(_quantity)
                .ForDescription(_description)
                .Build(_id, 1);
        }

        [Test]
        public void non_genera_un_eccezzione()
        {
            Assert.IsNull(Caught);
        }


    }
}
