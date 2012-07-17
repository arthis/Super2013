using System;
using System.Collections.Generic;
using CommandService;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Handlers;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using CommonDomain.Persistence;
using NUnit.Framework;
using CommonSpecs;
using Super.Appaltatore.Events.Builders;
using Super.Appaltatore.Events.Consuntivazione;
using Super.Controllo.Commands;
using Super.Saga.Handlers;
using Super.Programmazione.Events;
using BuildEvtProg = Super.Programmazione.Events.Builders.Build;
using BuildEvtApp = Super.Appaltatore.Events.Builders.Build;
using BuildCmdCtrl = Super.Controllo.Commands.Builders.Build;


namespace Super.Saga.Specs.Saga_Intervento.Rotabile_in_Manutenzione
{
    public class consuntivazione_intervento : SagaBaseClass<InterventoConsuntivatoRotManReso>
    {
        readonly Guid _id = Guid.NewGuid();
        readonly Guid _idImpianto = Guid.NewGuid();
        readonly Guid _idTipoIntervento = Guid.NewGuid();
        readonly Guid _idAppaltatore = Guid.NewGuid();
        readonly Guid _idCategoriaCommerciale = Guid.NewGuid();
        readonly Guid _idDirezioneRegionale = Guid.NewGuid();
        List<OggettoRotMan> _oggetti = new List<OggettoRotMan>() { new OggettoRotMan("desc", 15, Guid.NewGuid()) };
        readonly WorkPeriod _period = new WorkPeriod(DateTime.Now.AddHours(-20), DateTime.Now.AddMinutes(-18));
        string _note = "note";

        readonly string _idInterventoAppaltatore = "dsfsd";
        readonly WorkPeriod _periodCons = new WorkPeriod(DateTime.Now.AddHours(-18), DateTime.Now.AddMinutes(-16));
        private DateTime DataCons = DateTime.Now;
        string _noteCons = "note cons";
        List<OggettoRotMan> _oggettiCons = new List<OggettoRotMan>() { new OggettoRotMan("desc cons", 15, Guid.NewGuid()) };
       

        public override string ToDescription()
        {
            return "";
        }

        protected override SagaHandler<InterventoConsuntivatoRotManReso> SagaHandler(ISagaRepository repository, IBus bus)
        {
            return new InterventoConsuntivatoRotManResoHandler(repository, bus);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield return BuildEvtProg.InterventoRotManPianificato
              .ForPeriod(_period)
              .ForImpianto(_idImpianto)
              .OfType(_idTipoIntervento)
              .ForAppaltatore(_idAppaltatore)
              .OfCategoriaCommerciale(_idCategoriaCommerciale)
              .OfDirezioneRegionale(_idDirezioneRegionale)
              .WithOggetti(_oggetti.ToArray())
              .WithNote(_note)
              .Build(_id, 1);
        }

        public override InterventoConsuntivatoRotManReso When()
        {
            return BuildEvtApp.InterventoConsuntivatoRotManReso
                .ForInterventoAppaltatore(_idInterventoAppaltatore)
                .ForPeriod(_periodCons)
                .When(DataCons)
                .WithNote(_noteCons)
                .WithOggetti(_oggettiCons.ToArray())
                .Build(_id,25);
        }

        public override IEnumerable<IMessage> Expect()
        {
            yield return BuildCmdCtrl.AllowControlIntervento
                                     .Build(_id, 0);
        }

        [Test]
        public void non_genera_un_eccezzione()
        {
            Assert.IsNull(Caught);
        }


    }
}
