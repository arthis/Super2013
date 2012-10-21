using CommonDomain;
using CommonDomain.Core.Handlers;
using CommonDomain.Persistence;
using Super.Appaltatore.Events.Consuntivazione;
using Super.Saga.Domain.Consuntivazione;

namespace Super.Saga.Handlers.Consuntivazione
{
    public class InterventoRotManConsuntivatoNonResoTrenitaliaHandler : SagaHandler<InterventoRotManConsuntivatoNonResoTrenitalia>
    {
        public InterventoRotManConsuntivatoNonResoTrenitaliaHandler(ISagaRepository repository, IBus bus)
            : base(repository, bus, null)
        {
        }

        public sealed override ISaga OnHandle(InterventoRotManConsuntivatoNonResoTrenitalia @event)
        {
            var sagaId = @event.Id;

            // purchase correlation 
            var saga = Repository.GetById<ConsuntivazioneRotManSaga>(sagaId);

            saga.ConsuntivareNonResoTrenitaliaIntervento(@event);

            Repository.Save(saga, @event.CommitId, null);

            return saga;
        }
    }
}