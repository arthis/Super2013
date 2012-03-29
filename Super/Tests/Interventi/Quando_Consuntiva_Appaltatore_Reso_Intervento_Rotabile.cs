using System;
using System.Collections.Generic;
using System.Linq;
using Commands.AreaIntervento;
using Events;
using Ncqrs;
using Ncqrs.Spec;
using Ncqrs.Spec.Fakes;
using NUnit.Framework;
using Events.AreaIntervento;
using Commands.Interventi;
using Events.Interventi;

namespace Tests.AreaIntervento
{
    /// <summary>
    /// This is an example of the BigBangTestFixture
    /// </summary>
    /// <remarks>
    /// Use this fixture when the command results in multiple events
    /// </remarks>
    [Specification]
    public class Quando_Consuntiva_Appaltatore_Reso_Intervento_Rot : BigBangTestFixture<ConsuntivareRotResoDaAppaltatore>
    {

        public Quando_Consuntiva_Appaltatore_Reso_Intervento_Rot()
        {
            Configuration.Configure();
        }

        private DateTime now = DateTime.UtcNow;
        private const int idSuper = 1;
        private Guid idArea = Guid.NewGuid();
        private const string areaDescrizione = "descrizione area";
        private DateTime creazione = DateTime.Now;
        private DateTime inizio = DateTime.Now.AddMinutes(1);
        private DateTime fine = DateTime.Now.AddMinutes(5);
        private Events.Interventi.OggettoRot oggettoScheduled = new Events.Interventi.OggettoRot()
        {
            Descrizione = "desc iniziale",
            Quantita = 1,
            IdTipoOggettoInterventoRot = Guid.NewGuid()
        };

        public const string idAppaltatore = "idapp";
        public DateTime dataConsuntivazione = DateTime.Now.AddMinutes(7);
        public DateTime inizioConsuntivazione = DateTime.Now.AddMinutes(2);
        public DateTime fineConsuntivazione = DateTime.Now.AddMinutes(6);
        private Commands.Interventi.OggettoRot oggettoConsuntivated = new Commands.Interventi.OggettoRot()
        {
            Descrizione = "desc cons",
            Quantita = 2,
            IdTipoOggettoInterventoRot = Guid.NewGuid()
        };
        private const string noteConsuntivazione = "note";


        protected override void RegisterFakesInConfiguration(EnvironmentConfigurationWrapper configuration)
        {
            var clock = new FrozenClock(now);
            configuration.Register<IClock>(clock);
        }

        protected override IEnumerable<object> GivenEvents()
        {
            yield return new InterventoPLGRotCreato()
            {
                IdIntervento = EventSourceId, //should i have an id in my event???
                InterventoIdSuper = idSuper,
                Inizio = inizio,
                Fine = fine,
                IdAreaIntervento = idArea,
                DataCreazione = creazione,
                Oggetti = new List<Events.Interventi.OggettoRot>() { oggettoScheduled }
            };
        }

        protected override ConsuntivareRotResoDaAppaltatore WhenExecuting()
        {
            var oggetti = new List<Commands.Interventi.OggettoRot>() { oggettoConsuntivated }.ToArray();
            return new ConsuntivareRotResoDaAppaltatore(EventSourceId, idAppaltatore, dataConsuntivazione, inizioConsuntivazione, fineConsuntivazione,noteConsuntivazione, oggetti);
        }

        private ConsAppaltatoreRotResoCreato RotConsuntivatoEvent
        {
            get { return PublishedEvents.Select(e => e.Payload).OfType<ConsAppaltatoreRotResoCreato>().Single(); }
        }

        [Then]
        public void La_consuntivazione_deve_avere_il_buon_id_intervento_appaltatore()
        {
            Assert.That(RotConsuntivatoEvent.IdInterventoAppaltatore, Is.EqualTo(idAppaltatore));
        }

        [Then]
        public void La_consuntivazione_deve_avere_la_buona_data_di_consuntivazione()
        {
            Assert.That(RotConsuntivatoEvent.DataConsuntivazione, Is.EqualTo(dataConsuntivazione));
        }

        [Then]
        public void La_consuntivazione_deve_avere_la_buona_data_di_inizio()
        {
            Assert.That(RotConsuntivatoEvent.Inizio, Is.EqualTo(inizioConsuntivazione));
        }

        [Then]
        public void La_consuntivazione_deve_avere_la_buona_data_di_fine()
        {
            Assert.That(RotConsuntivatoEvent.Fine, Is.EqualTo(fineConsuntivazione));
        }

        [Then]
        public void La_consuntivazione_deve_avere_la_buona_note()
        {
            Assert.That(RotConsuntivatoEvent.Note, Is.EqualTo(noteConsuntivazione));
        }

        [Then]
        public void No_ezzeptione_dovrebbe_esser_lanciata()
        {
            Assert.That(CaughtException, Is.EqualTo(null));
        }

        [Then]
        public void No_dovrebbe_far_di_piu()
        {
            Assert.That(PublishedEvents.Count(), Is.EqualTo(1));
        }

    }
}
