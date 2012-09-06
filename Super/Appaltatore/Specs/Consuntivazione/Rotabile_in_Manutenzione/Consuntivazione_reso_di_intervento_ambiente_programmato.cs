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
using Super.Appaltatore.Events.Consuntivazione;
using Super.Appaltatore.Events.Programmazione;
using Super.Appaltatore.Handlers;
using BuildCmd = Super.Appaltatore.Commands.Builders.Build;
using Super.Appaltatore.Events;

namespace Super.Appaltatore.Specs.Consuntivazione.Rotabile_in_Manutenzione
{
    public class Consuntivazione_reso_di_intervento_rotabile_in_manutenzione_programmato : CommandBaseClass<ConsuntivareRotManReso>
    {
        //programmato
        readonly Guid _id = Guid.NewGuid();
        readonly Guid _idImpianto = Guid.NewGuid();
        readonly Guid _idTipoIntervento = Guid.NewGuid();
        readonly Guid _idAppaltatore = Guid.NewGuid();
        readonly Guid _idCategoriaCommerciale = Guid.NewGuid();
        readonly Guid _idDirezioneRegionale = Guid.NewGuid();
        List<OggettoRotMan> _oggetti = new List<OggettoRotMan>() { new OggettoRotMan("desc", 15, Guid.NewGuid(), Guid.NewGuid()) };
        readonly WorkPeriod _period = new WorkPeriod(DateTime.Now.AddHours(-20), DateTime.Now.AddMinutes(-18));
        string _note = "note";

        //Cons
        private readonly Guid _commitId = Guid.NewGuid();
        readonly string _idInterventoAppaltatore = "id intervento appaltatore";
        readonly DateTime _dataConsuntivazione = DateTime.Now;
        List<OggettoRotMan> _oggettiCons = new List<OggettoRotMan>() { new OggettoRotMan("desc cons", 22, Guid.NewGuid(), Guid.NewGuid()) };
        readonly WorkPeriod _periodCons = new WorkPeriod(DateTime.Now.AddHours(-15), DateTime.Now.AddMinutes(-12));
        string _noteCons = "note";
        

        
        protected override CommandHandler<ConsuntivareRotManReso> OnHandle(IEventRepository eventRepository)
        {
            return new ConsuntivareRotManResoHandler(eventRepository);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield return  BuildEvt.InterventoRotManProgrammato
                .ForImpianto(_idImpianto)
                .OfType(_idTipoIntervento)
                .ForAppaltatore(_idAppaltatore)
                .OfCategoriaCommerciale(_idCategoriaCommerciale)
                .OfDirezioneRegionale(_idDirezioneRegionale)
                .ForPeriod(_period)
                .WithNote(_note)
                .WithOggetti(_oggetti.ToArray())
                .Build(_id, 1);
        }

        public override ConsuntivareRotManReso When()
        {
            return BuildCmd.ConsuntivareRotManReso
              .ForInterventoAppaltatore(_idInterventoAppaltatore)
              .When(_dataConsuntivazione)
              .ForPeriod(_periodCons)
              .WithNote(_noteCons)
              .WithOggetti(_oggettiCons.ToArray())
              .Build(_id, _commitId, 1);

        }

        public override IEnumerable<IMessage> Expect()
        {
            yield return BuildEvt.InterventoConsuntivatoRotManReso
                .ForInterventoAppaltatore(_idInterventoAppaltatore)
                .When(_dataConsuntivazione)
                .ForPeriod(_periodCons)
                .WithNote(_noteCons)
                .WithOggetti(_oggettiCons.ToArray())
                .Build(_id, 2);

        }

        [Test]
        public void non_genera_un_eccezzione()
        {
            Assert.IsNull(Caught);
        }


    }
}
