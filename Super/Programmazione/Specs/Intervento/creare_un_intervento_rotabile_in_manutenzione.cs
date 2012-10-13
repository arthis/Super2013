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
using Super.Programmazione.Commands.Plan;
using Super.Programmazione.Events;
using Super.Programmazione.Handlers.Commands.Intervento;

namespace Super.Programmazione.Specs.Intervento
{
    public class creare_un_intervento_rotabile_in_manutenzione : CommandBaseClass<CreateInterventoRotMan>
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
        private Guid _idIntervento = Guid.NewGuid();
        private OggettoRotMan[] _oggetti = new OggettoRotMan[] { BuildMessagingVO.MsgOggettoRotMan.ForDescription("description").ForGruppo(Guid.NewGuid()).OfQuantity(2).OfType(Guid.NewGuid()).Build() };
        

        protected override CommandHandler<CreateInterventoRotMan> OnHandle(IEventRepository eventRepository)
        {
            return new CreateInterventoRotManHandler(eventRepository);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield return  BuildEvt.ProgrammaCreated
                .ByScenario(_idScenario)
                .Build(_idProgramma,1);
        }

        public override CreateInterventoRotMan When()
        {
            return BuildCmd.CreateInterventoRotMan
                .ForProgramma(_idProgramma)
                .ForAppaltatore(_idAppaltatore)
                .ForCategoriaCommerciale(_idCategoriaCommerciale)
                .ForCommittente(_idCommittente)
                .ForDirezioneRegionale(_idDirezioneRegionale)
                .ForImpianto(_idImpianto)
                .ForLotto(_idLotto)
                .ForWorkPeriod(_workPeriod)
                .ForPeriodoProgrammazione(_idPeriodoProgrammazione)
                .OfTipoIntervento(_tipoIntervento)
                .WithNote(_note)
                .WithOggetti(_oggetti)
                .Build(_idIntervento, 1);
        }

        public override IEnumerable<IMessage> Expect()
        {
            yield return BuildEvt.InterventoRotManCreated
                .ForProgramma(_idProgramma)
                .ForAppaltatore(_idAppaltatore)
                .ForCategoriaCommerciale(_idCategoriaCommerciale)
                .ForCommittente(_idCommittente)
                .ForDirezioneRegionale(_idDirezioneRegionale)
                .ForImpianto(_idImpianto)
                .ForLotto(_idLotto)
                .ForWorkPeriod(_workPeriod)
                .ForPeriodoProgrammazione(_idPeriodoProgrammazione)
                .OfTipoIntervento(_tipoIntervento)
                .WithNote(_note)
                .WithOggetti(_oggetti)
                .Build(_idIntervento, 1);
        }

        [Test]
        public void non_genera_un_eccezzione()
        {
            Assert.IsNull(Caught);
        }


    }
}
