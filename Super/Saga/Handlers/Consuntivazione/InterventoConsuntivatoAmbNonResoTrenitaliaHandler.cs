using CommonDomain;
using CommonDomain.Core.Handlers;
using CommonDomain.Persistence;
using Super.Appaltatore.Events.Consuntivazione;
using Super.Saga.Domain.Consuntivazione;
using Super.Saga.Domain.Intervento;

namespace Super.Saga.Handlers.Intervento
{
    public class InterventoAmbConsuntivatoNonResoTrenitaliaHandler : SagaHandler<InterventoAmbConsuntivatoNonResoTrenitalia>
    {
        public InterventoAmbConsuntivatoNonResoTrenitaliaHandler(ISagaRepository repository, IBus bus)
            : base(repository, bus, null)
        {
        }

        public sealed override ISaga OnHandle(InterventoAmbConsuntivatoNonResoTrenitalia @event)
        {
            var sagaId = @event.Id;

            // purchase correlation 
            var saga = Repository.GetById<ConsuntivaziioneAmbSaga>(sagaId);

            saga.ConsuntivareIntervento(@event);

            Repository.Save(saga, @event.CommitId, null);

            return saga;
        }
    }
}