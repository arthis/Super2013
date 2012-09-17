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
using Super.Programmazione.Events.Intervento;
using Super.Programmazione.Events.Schedulazione;
using Super.Saga.Handlers;
using Super.Programmazione.Events;
using BuildCmd = Super.Appaltatore.Commands.Builders.Build;


namespace Super.Saga.Specs.Saga_Intervento.Rotabile_in_Manutenzione
{
    public class Inizio_della_saga_intervento_rotabile_in_manutenzione_non_iniziata : SagaBaseClass<InterventoRotManScheduled>
    {
        readonly Guid _id = Guid.NewGuid();
        readonly Guid _idImpianto = Guid.NewGuid();
        readonly Guid _idTipoIntervento = Guid.NewGuid();
        readonly Guid _idAppaltatore = Guid.NewGuid();
        readonly Guid _idCategoriaCommerciale = Guid.NewGuid();
        readonly Guid _idDirezioneRegionale = Guid.NewGuid();
        readonly Guid _idPeriodoProgrammazione = Guid.NewGuid();
        readonly Guid _idPlan = Guid.NewGuid();
        readonly Guid _idLotto = Guid.NewGuid();
        readonly Guid _idCommittente = Guid.NewGuid();
        List<OggettoRotMan> _oggetti = new List<OggettoRotMan>() { new OggettoRotMan("desc", 15, Guid.NewGuid(), Guid.NewGuid()) };
        readonly WorkPeriod _period = new WorkPeriod(DateTime.Now.AddHours(-20), DateTime.Now.AddMinutes(-18));
        string _note = "note";

        public override string ToDescription()
        {
            return "un inizo di saga normale";
        }

        protected override SagaHandler<InterventoRotManScheduled> SagaHandler(ISagaRepository repository, IBus bus)
        {
            return new InterventoRotManScheduledHandler(repository, bus);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield break;
        }

        public override InterventoRotManScheduled When()
        {
            return new InterventoRotManScheduled()
                       {
                           WorkPeriod = _period,
                           Id = _id,
                           IdImpianto = _idImpianto,
                           IdTipoIntervento = _idTipoIntervento,
                           IdAppaltatore = _idAppaltatore,
                           IdCategoriaCommerciale = _idCategoriaCommerciale,
                           IdDirezioneRegionale = _idDirezioneRegionale,
                           Note = _note,
                           Oggetti = _oggetti.ToArray(),
                           
                       };
        }

        public override IEnumerable<IMessage> Expect()
        {
            yield return BuildCmd.ProgrammareInterventoRotMan
                            .ForPeriod(_period)
                            .ForImpianto(_idImpianto)
                            .OfType(_idTipoIntervento)
                            .ForAppaltatore(_idAppaltatore)
                            .OfCategoriaCommerciale(_idCategoriaCommerciale)
                            .OfDirezioneRegionale(_idDirezioneRegionale)
                            .WithOggetti(_oggetti.ToArray())
                            .WithNote(_note)
                            .Build(_id,0);
        }

        [Test]
        public void non_genera_un_eccezzione()
        {
            Assert.IsNull(Caught);
        }


    }
}
