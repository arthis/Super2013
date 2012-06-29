using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Persistence;
using Super.Appaltatore.Events.Consuntivazione;
using Super.Saga.Domain.Intervento;

namespace Super.Saga.Handlers
{
    public class InterventoConsuntivatoRotManNonResoTrenitaliaHandler : SagaHandler<InterventoConsuntivatoRotManNonResoTrenitalia>
    {
        public InterventoConsuntivatoRotManNonResoTrenitaliaHandler(ISagaRepository repository, IBus bus)
            : base(repository, bus)
        {
        }

        public sealed override ISaga OnHandle(InterventoConsuntivatoRotManNonResoTrenitalia @event)
        {
            var sagaId = @event.Id;

            // purchase correlation 
            var saga = Repository.GetById<InterventoRotManSaga>(sagaId);

            saga.ConsuntivareIntervento(@event);

            Repository.Save(saga, @event.CommitId, null);

            return saga;
        }
    }
}