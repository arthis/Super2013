using System;
using System.Collections.Generic;
using System.Linq;
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
    /// This is an example of the OneEventTestFixture with event history
    /// </summary>
    /// <remarks>Use this type of test when the command results in exactly one event.
    /// </remarks>
    [Specification]
    public class Quando_aggiornando_area : OneEventTestFixture<AggiornareAreaIntervento, AreaInterventoAggiornata>
    {

        public Quando_aggiornando_area()
        {
            Configuration.Configure();
        }

        private DateTime now = DateTime.UtcNow;
        private const int OldIdAreaSuper = 1;
        private const string OldAreaDescrizione = "descrizione area";
        private DateTime Creazione = DateTime.Now;
        private DateTime OldInizio = DateTime.Now.AddMinutes(1);
        private DateTime OLdFine = DateTime.Now.AddMinutes(5);

        private const int NewIdAreaSuper = 2;
        private const string NewAreaDescrizione = "descrizione area 2";
        private DateTime NewInizio = DateTime.Now.AddMinutes(10);
        private DateTime NewFine = DateTime.Now.AddMinutes(50);

        protected override void RegisterFakesInConfiguration(EnvironmentConfigurationWrapper configuration)
        {
            var clock = new FrozenClock(now);
            configuration.Register<IClock>(clock);
        }

        protected override IEnumerable<object> GivenEvents()
        {
            yield return new AreaInterventoCreata()
                             {
                                 CreationDate = Creazione,
                                 Descrizione = OldAreaDescrizione,
                                  Inizio = OldInizio,
                                  Fine =OLdFine,
                                 IdAreaInterventoSuper = OldIdAreaSuper
                             };
        }

        protected override AggiornareAreaIntervento WhenExecuting()
        {
            return new AggiornareAreaIntervento()
                       {
                           Id = EventSourceId,
                           Descrizione = NewAreaDescrizione,
                           Inizio = NewInizio,
                           Fine = NewFine,
                           IdAreaInterventoSuper = NewIdAreaSuper
                       };
        }

        [Then]
        public void dovrebbe_cambiare_la_descrizione()
        {
            Assert.That(TheEvent.Descrizione, Is.EqualTo(NewAreaDescrizione));
        }

        [Then]
        public void dovrebbe_cambiare_l_inizio()
        {
            Assert.That(TheEvent.Inizio, Is.EqualTo(NewInizio));
        }

        [Then]
        public void dovrebbe_cambiare_la_fine()
        {
            Assert.That(TheEvent.Fine, Is.EqualTo(NewFine));
        }

        [Then]
        public void dovrebbe_cambiare_il_id_Super()
        {
            Assert.That(TheEvent.IdAreaInterventoSuper, Is.EqualTo(NewIdAreaSuper));
        }

        

        [Then]
        public void it_should_change_the_right_note()
        {
            Assert.That(PublishedEvents.Single().EventSourceId, Is.EqualTo(EventSourceId));
        }

    }
}
