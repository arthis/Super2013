using System;
using System.Collections.Generic;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Handlers;
using CommonDomain.Core.Handlers.Commands;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using CommonDomain.Persistence;
using NUnit.Framework;
using Super.Controllo.Commands;
using CommonSpecs;
using Super.Controllo.Commands.Programmazione;
using Super.Controllo.Events.Programmazione;
using Super.Controllo.Handlers;
using BuildCmd = Super.Controllo.Commands.BuildCmd;
using Super.Controllo.Events;

namespace Super.Controllo.Specs.Programmazione.Rotabile_in_Manutenzione
{
    public class Programmazione_di_intervento_rotabile_in_manutenzione_gia_esistente : CommandBaseClass<ProgramInterventoRotMan>
    {
        readonly Guid _id = Guid.NewGuid();
        readonly Guid _commitId = Guid.NewGuid();
        readonly Guid _idImpianto = Guid.NewGuid();
        readonly Guid _idTipoIntervento = Guid.NewGuid();
        readonly Guid _idAppaltatore = Guid.NewGuid();
        readonly Guid _idCategoriaCommerciale = Guid.NewGuid();
        readonly Guid _idDirezioneRegionale = Guid.NewGuid();
        readonly WorkPeriod _workPeriod = new WorkPeriod(DateTime.Now.AddHours(-17), DateTime.Now.AddMinutes(-10));
        List<OggettoRotMan> _oggetti = new List<OggettoRotMan>() { new OggettoRotMan("desccons", 22, Guid.NewGuid(), Guid.NewGuid()) };
        string _note = "note";

        protected override CommandHandler<ProgramInterventoRotMan> OnHandle(IEventRepository eventRepository)
        {
            return new ProgramInterventoRotManHandler(eventRepository);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield return BuildEvt.InterventoRotManProgrammato
                .WithOggetti(_oggetti.ToArray())
                .ForWorkPeriod(_workPeriod)
                .ForImpianto(_idImpianto)
                .OfTipoIntervento(_idTipoIntervento)
                .ForAppaltatore(_idAppaltatore)
                .ForCategoriaCommerciale(_idCategoriaCommerciale)
                .ForDirezioneRegionale(_idDirezioneRegionale)
                .WithNote(_note)
                .Build(_id, 1);
        }

        public override ProgramInterventoRotMan When()
        {
            return BuildCmd.ProgramInterventoRotMan
                .WithOggetti(_oggetti.ToArray())
                .ForWorkPeriod(_workPeriod)
                .ForImpianto(_idImpianto)
                .OfTipoIntervento(_idTipoIntervento)
                .ForAppaltatore(_idAppaltatore)
                .ForCategoriaCommerciale(_idCategoriaCommerciale)
                .ForDirezioneRegionale(_idDirezioneRegionale)
                .WithNote(_note)
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
