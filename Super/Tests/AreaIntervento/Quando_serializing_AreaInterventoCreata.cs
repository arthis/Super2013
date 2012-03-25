using System;
using Events;
using Ncqrs.Spec;
using Events.AreaIntervento;

namespace Tests.AreaIntervento
{
    public class Quando_serializing_AreaInterventoCreata
        : JsonEventSerializationFixture<AreaInterventoCreata>
    {
        protected override AreaInterventoCreata GivenEvent()
        {
            return new AreaInterventoCreata()
                       {
                           Descrizione = "test",
                           Fine = DateTime.Now,
                           Inizio = DateTime.Now,
                           IdAreaInterventoSuper = 12,
                           CreationDate = DateTime.Now,
                           Id = Guid.NewGuid()
                       };
        }
    }
}
