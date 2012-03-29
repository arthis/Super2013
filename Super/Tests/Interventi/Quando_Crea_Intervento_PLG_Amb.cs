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
    public class Quando_Crea_Intervento_PLG_Amb : BigBangTestFixture<CreareInterventoPLGAmb>
    {

        public Quando_Crea_Intervento_PLG_Amb()
        {
            Configuration.Configure();
        }

        private DateTime now = DateTime.UtcNow;
        private const int IdSuper = 1;
        private  Guid IdArea = Guid.NewGuid();
        private DateTime Creazione = DateTime.Now;
        private DateTime Inizio = DateTime.Now.AddMinutes(1);
        private DateTime Fine = DateTime.Now.AddMinutes(5);

        private const string descrizione = "ogg desc";
        private const int quantita = 12;

        protected override void RegisterFakesInConfiguration(EnvironmentConfigurationWrapper configuration)
        {
            var clock = new FrozenClock(now);
            configuration.Register<IClock>(clock);
        }

        protected override IEnumerable<object> GivenEvents()
        {
            return new object[0];
        }

        protected override CreareInterventoPLGAmb WhenExecuting()
        {

            return new CreareInterventoPLGAmb(EventSourceId, IdSuper, Inizio, Fine, IdArea, Creazione, quantita, descrizione);
        }

        private InterventoPLGAmbCreato InterventoAmbCreatoEvent
        {
            get { return PublishedEvents.Select(e => e.Payload).OfType<InterventoPLGAmbCreato>().Single(); }
        }

        [Then]
        public void Il_nuovo_intervento_deve_avere_il_stesso_id()
        {
            Assert.That(InterventoAmbCreatoEvent.IdIntervento, Is.EqualTo(EventSourceId));
        }

        [Then]
        public void Il_nuovo_intervento_deve_avere_il_buon_id_super()
        {
            Assert.That(InterventoAmbCreatoEvent.InterventoIdSuper, Is.EqualTo(IdSuper));
        }

        [Then]
        public void Il_nuovo_intervento_deve_avere_la_buona_creazione_data()
        {
            Assert.That(InterventoAmbCreatoEvent.DataCreazione, Is.EqualTo(Creazione));
        }

        [Then]
        public void Il_nuovo_intervento_deve_avere_il_buon_IdArea()
        {
            Assert.That(InterventoAmbCreatoEvent.IdAreaIntervento, Is.EqualTo(IdArea));
        }

        [Then]
        public void Il_nuovo_intervento_deve_avere_il_buon_inizio()
        {
            Assert.That(InterventoAmbCreatoEvent.Inizio, Is.EqualTo(Inizio));
        }

        [Then]
        public void Il_nuovo_intervento_deve_avere_la_buon_fine()
        {
            Assert.That(InterventoAmbCreatoEvent.Fine, Is.EqualTo(Fine));
        }

        [Then]
        public void Il_nuovo_intervento_deve_avere_la_buon_quantita()
        {
            Assert.That(InterventoAmbCreatoEvent.Quantita, Is.EqualTo(quantita));
        }

        [Then]
        public void Il_nuovo_intervento_deve_avere_la_buon_descrizione()
        {
            Assert.That(InterventoAmbCreatoEvent.Descrizione, Is.EqualTo(descrizione));
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
