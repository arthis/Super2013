using System;
using CommonDomain;
using CommonDomain.Core.Handlers;
using CommonDomain.Persistence;
using Super.Contabilita.Events.Schedulazione;
using Super.Programmazione.Events.Schedulazione;
using Super.Saga.Domain.SchedulazioneOfScenarioPrice;


namespace Super.Saga.Handlers.ScenarioPrice
{
    public class SchedulazionePriceOfScenarioCalculatedHandler : SagaHandler<SchedulazionePriceOfScenarioCalculated>
    {
        public SchedulazionePriceOfScenarioCalculatedHandler(ISagaRepository repository, IBus bus)
            : base(repository, bus, null)
        {
        }

        public sealed override ISaga OnHandle(SchedulazionePriceOfScenarioCalculated @event)
        {
            var sagaId = @event.Id;

            var saga = Repository.GetById<SchedulazioneAmbPriceSaga>(sagaId);

            saga.ProjectNumbers(@event);

            Repository.Save(saga, @event.CommitId, null);

            return saga;
        }
    }
}
