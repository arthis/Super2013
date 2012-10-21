using CommonDomain;
using CommonDomain.Core.Handlers;
using CommonDomain.Persistence;
using Super.Programmazione.Events.Intervento;
using Super.Saga.Domain.Consuntivazione;

namespace Super.Saga.Handlers.Consuntivazione
{
    public class InterventoAmbCreatedHandler : SagaHandler<InterventoAmbCreated>
    {
        public InterventoAmbCreatedHandler(ISagaRepository repository, IBus bus)
            : base(repository, bus, null)
        {
        }

        public sealed override ISaga OnHandle(InterventoAmbCreated @event)
        {
            var sagaId = @event.Id;

            // purchase correlation 
            var saga = Repository.GetById<ConsuntivazioneAmbSaga>(sagaId);

            saga.ProgrammareIntervento(@event);

            Repository.Save(saga, @event.CommitId, null);

            return saga;
        }
    }
}
