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

namespace Tests.AreaIntervento
{
    /// <summary>
    /// This is an example of the BigBangTestFixture
    /// </summary>
    /// <remarks>
    /// Use this fixture when the command results in multiple events
    /// </remarks>
    [Specification]
    public class BigBang_quando_creando_nuova_area : BigBangTestFixture<CreareNuovoAreaIntervento>
    {

        public BigBang_quando_creando_nuova_area()
        {
            Configuration.Configure();
        }

        private DateTime now = DateTime.UtcNow;
        private const int IdAreaSuper = 1;
        private const string AreaDescrizione = "descrizione area";
        private DateTime Creazione = DateTime.Now;
        private DateTime Inizio = DateTime.Now.AddMinutes(1);
        private DateTime Fine = DateTime.Now.AddMinutes(5);

        protected override void RegisterFakesInConfiguration(EnvironmentConfigurationWrapper configuration)
        {
            var clock = new FrozenClock(now);
            configuration.Register<IClock>(clock);
        }

        protected override IEnumerable<object> GivenEvents()
        {
            return new object[0];
        }

        protected override CreareNuovoAreaIntervento WhenExecuting()
        {
            return new CreareNuovoAreaIntervento(EventSourceId, IdAreaSuper, Inizio, Fine, AreaDescrizione, Creazione);
        }

        private AreaInterventoCreata AreaInterventoCreataEvent
        {
            get { return PublishedEvents.Select(e => e.Payload).OfType<AreaInterventoCreata>().Single(); }
        }

        [Then]
        public void La_nuova_area_deve_avere_il_stesso_id()
        {
            Assert.That(AreaInterventoCreataEvent.Id, Is.EqualTo(EventSourceId));
        }

        [Then]
        public void La_nuova_area_deve_avere_la_buona_descrizione()
        {
            Assert.That(AreaInterventoCreataEvent.Descrizione, Is.EqualTo(AreaDescrizione));
        }

        [Then]
        public void La_nuova_area_deve_avere_la_buoan_creazione_data()
        {
            Assert.That(AreaInterventoCreataEvent.CreationDate, Is.EqualTo(Creazione));
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
