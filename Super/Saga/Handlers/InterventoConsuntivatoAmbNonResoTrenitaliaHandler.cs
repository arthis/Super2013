using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Persistence;
using Super.Appaltatore.Events.Consuntivazione;
using Super.Saga.Domain.Intervento;

namespace Super.Saga.Handlers
{
    public class InterventoConsuntivatoAmbNonResoTrenitaliaHandler : SagaHandler<InterventoConsuntivatoAmbNonResoTrenitalia>
    {
        public InterventoConsuntivatoAmbNonResoTrenitaliaHandler(ISagaRepository repository, IBus bus)
            : base(repository, bus)
        {
        }

        public sealed override ISaga OnHandle(InterventoConsuntivatoAmbNonResoTrenitalia @event)
        {
            var sagaId = @event.Id;

            // purchase correlation 
            var saga = Repository.GetById<InterventoAmbSaga>(sagaId);

            saga.ConsuntivareIntervento(@event);

            Repository.Save(saga, @event.CommitId, null);

            return saga;
        }
    }
}