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
    public class Quando_Crea_Intervento_PLG_Rot : BigBangTestFixture<CreareInterventoPLGRot>
    {

        public Quando_Crea_Intervento_PLG_Rot()
        {
            Configuration.Configure();
        }

        private DateTime now = DateTime.UtcNow;
        private const int IdSuper = 1;
        private  Guid IdArea = Guid.NewGuid();
        private DateTime Creazione = DateTime.Now;
        private DateTime Inizio = DateTime.Now.AddMinutes(1);
        private DateTime Fine = DateTime.Now.AddMinutes(5);

        private const string oggettoDescrizione = "ogg desc";
        private  Guid idTipoOggettoInterventoRot = Guid.NewGuid();
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

        protected override CreareInterventoPLGRot WhenExecuting()
        {
            Commands.Interventi.OggettoRot[] oggetti = new List<Commands.Interventi.OggettoRot>()
                                                    { new Commands.Interventi.OggettoRot(){ 
                                                              Descrizione= oggettoDescrizione,
                                                              IdTipoOggettoInterventoRot=idTipoOggettoInterventoRot,
                                                              Quantita=quantita}}.ToArray();

            return new CreareInterventoPLGRot(EventSourceId, IdSuper, Inizio, Fine, IdArea, Creazione, oggetti);
        }

        private InterventoPLGRotCreato InterventoRotCreatoEvent
        {
            get { return PublishedEvents.Select(e => e.Payload).OfType<InterventoPLGRotCreato>().Single(); }
        }

        [Then]
        public void Il_nuovo_intervento_deve_avere_il_stesso_id()
        {
            Assert.That(InterventoRotCreatoEvent.IdIntervento, Is.EqualTo(EventSourceId));
        }

        [Then]
        public void Il_nuovo_intervento_deve_avere_il_buon_id_super()
        {
            Assert.That(InterventoRotCreatoEvent.InterventoIdSuper, Is.EqualTo(IdSuper));
        }

        [Then]
        public void Il_nuovo_intervento_deve_avere_la_buona_creazione_data()
        {
            Assert.That(InterventoRotCreatoEvent.DataCreazione, Is.EqualTo(Creazione));
        }

        [Then]
        public void Il_nuovo_intervento_deve_avere_il_buon_IdArea()
        {
            Assert.That(InterventoRotCreatoEvent.IdAreaIntervento, Is.EqualTo(IdArea));
        }

        [Then]
        public void Il_nuovo_intervento_deve_avere_il_buon_inizio()
        {
            Assert.That(InterventoRotCreatoEvent.Inizio, Is.EqualTo(Inizio));
        }

        [Then]
        public void Il_nuovo_intervento_deve_avere_la_buon_fine()
        {
            Assert.That(InterventoRotCreatoEvent.Fine, Is.EqualTo(Fine));
        }

        [Then]
        public void Il_nuovo_intervento_deve_avere_un_oggetto()
        {
            Assert.IsNotNull(InterventoRotCreatoEvent.Oggetti);
            Assert.AreEqual(InterventoRotCreatoEvent.Oggetti.Count(),1);
        }

        [Then]
        public void Il_nuovo_intervento_deve_avere_un_oggetto_con_la_buona_descrizione()
        {
            var oggetto = InterventoRotCreatoEvent.Oggetti.FirstOrDefault();
            if (oggetto==null)
              Assert.Inconclusive();

            Assert.AreEqual(oggetto.Descrizione, oggettoDescrizione);
        }

        [Then]
        public void Il_nuovo_intervento_deve_avere_un_oggetto_con_il_buono_TipoOggettoInterventoRot()
        {
            var oggetto = InterventoRotCreatoEvent.Oggetti.FirstOrDefault();
            if (oggetto == null)
                Assert.Inconclusive();

            Assert.AreEqual(oggetto.IdTipoOggettoInterventoRot, idTipoOggettoInterventoRot);
        }

        [Then]
        public void Il_nuovo_intervento_deve_avere_un_oggetto_con_la_buona_quantita()
        {
            var oggetto = InterventoRotCreatoEvent.Oggetti.FirstOrDefault();
            if (oggetto == null)
                Assert.Inconclusive();

            Assert.AreEqual(oggetto.Quantita, quantita);
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
