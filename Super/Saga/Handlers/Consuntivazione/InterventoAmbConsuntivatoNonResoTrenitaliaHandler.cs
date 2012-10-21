using CommonDomain;
using CommonDomain.Core.Handlers;
using CommonDomain.Persistence;
using Super.Appaltatore.Events.Consuntivazione;
using Super.Saga.Domain.Consuntivazione;

namespace Super.Saga.Handlers.Consuntivazione
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
            var saga = Repository.GetById<ConsuntivazioneAmbSaga>(sagaId);

            saga.ConsuntivareNonResoTrenitaliaIntervento(@event);

            Repository.Save(saga, @event.CommitId, null);

            return saga;
        }
    }
}