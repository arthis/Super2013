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
    public class Quando_cancellando_area : OneEventTestFixture<CancellareAreaIntervento, AreaInterventoCancellata>
    {

        public Quando_cancellando_area()
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
            yield return new AreaInterventoCreata()
                             {
                                 CreationDate = Creazione,
                                 Descrizione = AreaDescrizione,
                                  Inizio = Inizio,
                                  Fine =Fine,
                                 IdAreaInterventoSuper = IdAreaSuper
                             };
        }

        protected override CancellareAreaIntervento WhenExecuting()
        {
            return new CancellareAreaIntervento()
                       {
                           Id = EventSourceId
                       };
        }

        [Then]
        public void it_should_change_the_right_note()
        {
            Assert.That(PublishedEvents.Single().EventSourceId, Is.EqualTo(EventSourceId));
        }

    }
}
