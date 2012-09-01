using System;
using System.Collections.Generic;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Handlers;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using CommonDomain.Persistence;
using NUnit.Framework;
using Super.Appaltatore.Commands;
using CommonSpecs;
using Super.Appaltatore.Commands.Builders;
using Super.Appaltatore.Events.Builders;
using Super.Appaltatore.Events.Programmazione;
using Super.Appaltatore.Handlers;
using BuildCmd = Super.Appaltatore.Commands.Builders.Build;
using Super.Appaltatore.Events;


namespace Super.Appaltatore.Specs.Programmazione.Rotabile_in_Manutenzione
{
    public class Programmazione_di_intervento_rotabile_in_manutenzione_non_esistente : CommandBaseClass<ProgrammareInterventoRotMan>
    {
        readonly Guid _id = Guid.NewGuid();
        readonly Guid _commitId = Guid.NewGuid();
        readonly Guid _idImpianto = Guid.NewGuid();
        readonly Guid _idTipoIntervento = Guid.NewGuid();
        readonly Guid _idAppaltatore = Guid.NewGuid();
        readonly Guid _idCategoriaCommerciale = Guid.NewGuid();
        readonly Guid _idDirezioneRegionale = Guid.NewGuid();
        readonly WorkPeriod _period = new WorkPeriod(DateTime.Now.AddHours(-17), DateTime.Now.AddMinutes(-10));
        List<OggettoRotMan> _oggetti = new List<OggettoRotMan>() { new OggettoRotMan("desccons", 22, Guid.NewGuid()) };
        string _note = "note";

        protected override CommandHandler<ProgrammareInterventoRotMan> OnHandle(IEventRepository eventRepository)
        {
            return new ProgrammareInterventoRotManHandler(eventRepository);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield break;
        }

        public override ProgrammareInterventoRotMan When()
        {
            return BuildCmd.ProgrammareInterventoRotMan
                .WithOggetti(_oggetti.ToArray())
                .ForPeriod(_period)
                .In(_idImpianto)
                .OfType(_idTipoIntervento)
                .ForAppaltatore(_idAppaltatore)
                .OfCategoriaCommerciale(_idCategoriaCommerciale)
                .OfDirezioneRegionale(_idDirezioneRegionale)
                .WithNote(_note)
                .Build(_id,_commitId,0);
        }

        public override IEnumerable<IMessage> Expect()
        {
            yield return BuildEvt.InterventoRotManProgrammato
                .WithOggetti(_oggetti.ToArray())
                .ForPeriod(_period)
                .ForImpianto(_idImpianto)
                .OfType(_idTipoIntervento)
                .ForAppaltatore(_idAppaltatore)
                .OfCategoriaCommerciale(_idCategoriaCommerciale)
                .OfDirezioneRegionale(_idDirezioneRegionale)
                .WithNote(_note)
                .Build(_id, 1);
        }

        [Test]
        public void non_genera_un_eccezzione()
        {
            Assert.IsNull(Caught);
        }


    }
}
