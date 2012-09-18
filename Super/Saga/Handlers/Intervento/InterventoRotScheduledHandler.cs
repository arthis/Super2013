using CommonDomain;
using CommonDomain.Core.Handlers;
using CommonDomain.Persistence;
using Super.Programmazione.Events.Intervento;
using Super.Saga.Domain.Intervento;

namespace Super.Saga.Handlers.Intervento
{
    public class InterventoRotScheduledHandler : SagaHandler<InterventoRotScheduled>
    {
        public InterventoRotScheduledHandler(ISagaRepository repository, IBus bus)
            : base(repository, bus, null)
        {
        }

        public sealed override ISaga OnHandle(InterventoRotScheduled @event)
        {
            var sagaId = @event.Id;

            // purchase correlation 
            var saga = Repository.GetById<InterventoRotSaga>(sagaId);

            

            saga.ProgrammareIntervento(@event);
            
            Repository.Save(saga, @event.CommitId, null);

            return saga;
        }
    }
}
