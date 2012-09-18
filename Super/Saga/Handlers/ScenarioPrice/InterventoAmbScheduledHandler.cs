using System;
using CommonDomain;
using CommonDomain.Core.Handlers;
using CommonDomain.Persistence;
using Super.Programmazione.Events.Schedulazione;


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
            throw  new NotImplementedException();
            //var sagaId = @event.Id;

            //// purchase correlation 
            //var saga = Repository.GetById<InterventoAmbSaga>(sagaId);

            //saga.ProgrammareIntervento(@event);

            //Repository.Save(saga, @event.CommitId, null);

            //return saga;
        }
    }
}
