using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Persistence;
using Super.Appaltatore.Events.Consuntivazione;
using Super.Saga.Domain.Intervento;

namespace Super.Saga.Handlers
{
    public class InterventoConsuntivatoAmbNonResoHandler : SagaHandler<InterventoConsuntivatoAmbNonReso>
    {
        public InterventoConsuntivatoAmbNonResoHandler(ISagaRepository repository, IBus bus)
            : base(repository, bus)
        {
        }

        public sealed override ISaga OnHandle(InterventoConsuntivatoAmbNonReso @event)
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