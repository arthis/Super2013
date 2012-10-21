using CommonDomain;
using CommonDomain.Core.Handlers;
using CommonDomain.Persistence;
using Super.Appaltatore.Events.Consuntivazione;
using Super.Saga.Domain.Consuntivazione;

namespace Super.Saga.Handlers.Consuntivazione
{

    public class InterventoAmbConsuntivatoResoHandler : SagaHandler<InterventoAmbConsuntivatoReso>
    {
        public InterventoAmbConsuntivatoResoHandler(ISagaRepository repository, IBus bus)
            : base(repository, bus, null)
        {
        }

        public sealed override ISaga OnHandle(InterventoAmbConsuntivatoReso @event)
        {
            var sagaId = @event.Id;

            // purchase correlation 
            var saga = Repository.GetById<ConsuntivazioneAmbSaga>(sagaId);

            saga.ConsuntivareResoIntervento(@event);

            Repository.Save(saga, @event.CommitId, null);

            return saga;
        }
    }
}
