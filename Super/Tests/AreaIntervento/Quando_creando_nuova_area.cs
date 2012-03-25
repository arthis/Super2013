using System;
using System.Collections.Generic;
using Commands;
using Events;
using Ncqrs;
using Ncqrs.Spec;
using Ncqrs.Spec.Fakes;
using NUnit.Framework;
using Commands.AreaIntervento;
using Events.AreaIntervento;

namespace Tests.AreaIntervento
{
    /// <summary>
    /// This is an example of the OneEventTestFixture without event history
    /// </summary>
    /// <remarks>Use this type of test when the command results in exactly one event.
    /// </remarks>
    [Specification]
    public class Quando_creando_nuova_area : OneEventTestFixture<CreareNuovoAreaIntervento, AreaInterventoCreata>
    {

        public Quando_creando_nuova_area()
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

        [Then]
        public void La_nuova_area_deve_avere_il_stesso_id()
        {
            Assert.That(TheEvent.Id, Is.EqualTo(EventSourceId));
        }

        [Then]
        public void La_nuova_area_deve_avere_la_buona_descrizione()
        {
            Assert.That(TheEvent.Descrizione, Is.EqualTo(AreaDescrizione));
        }

        [Then]
        public void La_nuova_area_deve_avere_la_buoan_creazione_data()
        {
            Assert.That(TheEvent.CreationDate, Is.EqualTo(Creazione));
        }

        [Then]
        public void No_ezzeptione_dovrebbe_esser_lanciata()
        {
            Assert.That(CaughtException, Is.EqualTo(null));
        }

 


    }
}
