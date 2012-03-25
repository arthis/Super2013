using System;
using Events;
using Ncqrs.Spec;
using Events.AreaIntervento;

namespace Tests.AreaIntervento
{
    public class Quando_serializing_AreaInterventoAggiornata
        : JsonEventSerializationFixture<AreaInterventoAggiornata>
    {
        protected override AreaInterventoAggiornata GivenEvent()
        {
            return new AreaInterventoAggiornata()
                       {
                           Descrizione = "test",
                           Fine = DateTime.Now,
                           Inizio = DateTime.Now,
                           IdAreaInterventoSuper = 12
                       };
        }
    }
}
