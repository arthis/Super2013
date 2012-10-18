using System;
using System.Collections.Generic;
using CommonDomain;
using CommonDomain.Core.Handlers;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using CommonDomain.Persistence;
using NUnit.Framework;
using CommonSpecs;
using Super.Appaltatore.Events.Consuntivazione;
using Super.Controllo.Commands;
using Super.Programmazione.Events;
using Super.Saga.Handlers.Intervento;

namespace Super.Saga.Specs.Consuntivazione.Rotabile_in_Manutenzione
{
    public class consuntivazione_non_reso_trenitalia_di_un_intervento_rotabile_in_manutenzione : SagaBaseClass<InterventoRotManConsuntivatoNonResoTrenitalia>
    {
        readonly Guid _id = Guid.NewGuid();
        readonly Guid _idImpianto = Guid.NewGuid();
        readonly Guid _idTipoIntervento = Guid.NewGuid();
        readonly Guid _idAppaltatore = Guid.NewGuid();
        readonly Guid _idCategoriaCommerciale = Guid.NewGuid();
        readonly Guid _idDirezioneRegionale = Guid.NewGuid();
        readonly Guid _idPeriodoProgrammazione = Guid.NewGuid();
        readonly Guid _idProgramma = Guid.NewGuid();
        readonly Guid _idLotto = Guid.NewGuid();
        readonly Guid _idCommittente = Guid.NewGuid();
        List<OggettoRotMan> _oggetti = new List<OggettoRotMan>() { new OggettoRotMan("desc", 15, Guid.NewGuid(), Guid.NewGuid()) };
        readonly WorkPeriod _period = new WorkPeriod(DateTime.Now.AddHours(-20), DateTime.Now.AddMinutes(-18));
        string _note = "note";

        readonly string _idInterventoAppaltatore = "dsfsd";
        private DateTime DataCons = DateTime.Now;
        string _noteCons = "note cons";
        private Guid _idCausaleTrenitalia = Guid.NewGuid();


        public override string ToDescription()
        {
            return "";
        }

        protected override SagaHandler<InterventoRotManConsuntivatoNonResoTrenitalia> SagaHandler(ISagaRepository repository, IBus bus)
        {
            return new InterventoRotManConsuntivatoNonResoTrenitaliaHandler(repository, bus);
        }

        public override IEnumerable<IMessage> Given()
        {
            yield return BuildEvt.InterventoRotManCreated
               .WithOggetti(_oggetti.ToArray())
              .ForWorkPeriod(_period)
              .ForImpianto(_idImpianto)
              .OfTipoIntervento(_idTipoIntervento)
              .ForAppaltatore(_idAppaltatore)
              .ForCategoriaCommerciale(_idCategoriaCommerciale)
              .ForDirezioneRegionale(_idDirezioneRegionale)
              .ForPeriodoProgrammazione(_idPeriodoProgrammazione)
              .ForCommittente(_idCommittente)
              .ForProgramma(_idProgramma)
              .ForLotto(_idLotto)
              .WithNote(_note)
              .Build(_id, 1);
        }

        public override InterventoRotManConsuntivatoNonResoTrenitalia When()
        {
            return Appaltatore.Events.BuildEvt.InterventoRotManConsuntivatoNonResoTrenitalia
                .ForInterventoAppaltatore(_idInterventoAppaltatore)
                .When(DataCons)
                .WithNote(_noteCons)
                .Because(_idCausaleTrenitalia)
                .Build(_id, 25);
        }

        public override IEnumerable<IMessage> Expect()
        {
            yield return BuildCmd.AllowInterventoControl
                                     .Build(_id, 0);
        }

        [Test]
        public void non_genera_un_eccezzione()
        {
            Assert.IsNull(Caught);
        }


    }
}
