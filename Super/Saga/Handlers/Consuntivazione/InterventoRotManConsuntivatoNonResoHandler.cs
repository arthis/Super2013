using CommonDomain;
using CommonDomain.Core.Handlers;
using CommonDomain.Persistence;
using Super.Appaltatore.Events.Consuntivazione;
using Super.Saga.Domain.Consuntivazione;

namespace Super.Saga.Handlers.Consuntivazione
{
    public class InterventoRotManConsuntivatoNonResoHandler : SagaHandler<InterventoRotManConsuntivatoNonReso>
    {
        public InterventoRotManConsuntivatoNonResoHandler(ISagaRepository repository, IBus bus)
            : base(repository, bus, null)
        {
        }

        public sealed override ISaga OnHandle(InterventoRotManConsuntivatoNonReso @event)
        {
            var sagaId = @event.Id;

            // purchase correlation 
            var saga = Repository.GetById<ConsuntivaziioneRotManSaga>(sagaId);

            saga.ConsuntivareNonResoIntervento(@event);

            Repository.Save(saga, @event.CommitId, null);

            return saga;
        }
    }
}