using System;
using CommonDomain;
using CommonDomain.Core.Handlers;
using CommonDomain.Persistence;
using Super.Programmazione.Events.Scenario;
using Super.Programmazione.Events.Schedulazione;
using Super.Saga.Domain.SchedulazioneOfScenarioPrice;


namespace Super.Saga.Handlers.ScenarioPrice
{
    public class SchedulazioneAmbAddedToScenarioHandler : SagaHandler<SchedulazioneAmbAddedToScenario>
    {
        public SchedulazioneAmbAddedToScenarioHandler(ISagaRepository repository, IBus bus)
            : base(repository, bus, null)
        {
        }

        public sealed override ISaga OnHandle(SchedulazioneAmbAddedToScenario @event)
        {
            var sagaId = @event.Id;

            var saga = Repository.GetById<SchedulazioneAmbPriceSaga>(sagaId);

            saga.CalculateSchedulazionePrice(@event);

            Repository.Save(saga, @event.CommitId, null);

            return saga;
        }
    }
}
