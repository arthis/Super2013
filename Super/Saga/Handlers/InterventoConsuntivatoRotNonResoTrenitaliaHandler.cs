using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Persistence;
using Super.Appaltatore.Events.Consuntivazione;
using Super.Saga.Domain.Intervento;

namespace Super.Saga.Handlers
{
    public class InterventoConsuntivatoRotNonResoTrenitaliaHandler : SagaHandler<InterventoConsuntivatoRotNonResoTrenitalia>
    {
        public InterventoConsuntivatoRotNonResoTrenitaliaHandler(ISagaRepository repository, IBus bus)
            : base(repository, bus)
        {
        }

        public sealed override ISaga OnHandle(InterventoConsuntivatoRotNonResoTrenitalia @event)
        {
            var sagaId = @event.Id;

            // purchase correlation 
            var saga = Repository.GetById<InterventoRotSaga>(sagaId);

            saga.ConsuntivareIntervento(@event);

            Repository.Save(saga, @event.CommitId, null);

            return saga;
        }
    }
}