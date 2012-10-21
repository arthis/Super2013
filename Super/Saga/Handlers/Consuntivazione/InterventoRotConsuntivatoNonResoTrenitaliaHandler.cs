using CommonDomain;
using CommonDomain.Core.Handlers;
using CommonDomain.Persistence;
using Super.Appaltatore.Events.Consuntivazione;
using Super.Saga.Domain.Consuntivazione;

namespace Super.Saga.Handlers.Consuntivazione
{
    public class InterventoRotConsuntivatoNonResoTrenitaliaHandler : SagaHandler<InterventoRotConsuntivatoNonResoTrenitalia>
    {
        public InterventoRotConsuntivatoNonResoTrenitaliaHandler(ISagaRepository repository, IBus bus)
            : base(repository, bus, null)
        {
        }

        public sealed override ISaga OnHandle(InterventoRotConsuntivatoNonResoTrenitalia @event)
        {
            var sagaId = @event.Id;

            // purchase correlation 
            var saga = Repository.GetById<ConsuntivazioneRotSaga>(sagaId);

            saga.ConsuntivareNonResoTrenitaliaIntervento(@event);

            Repository.Save(saga, @event.CommitId, null);

            return saga;
        }
    }
}