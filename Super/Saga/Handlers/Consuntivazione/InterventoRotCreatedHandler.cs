using CommonDomain;
using CommonDomain.Core.Handlers;
using CommonDomain.Persistence;
using Super.Programmazione.Events.Intervento;
using Super.Saga.Domain.Consuntivazione;

namespace Super.Saga.Handlers.Consuntivazione
{
    public class InterventoRotCreatedHandler : SagaHandler<InterventoRotCreated>
    {
        public InterventoRotCreatedHandler(ISagaRepository repository, IBus bus)
            : base(repository, bus, null)
        {
        }

        public sealed override ISaga OnHandle(InterventoRotCreated @event)
        {
            var sagaId = @event.Id;

            // purchase correlation 
            var saga = Repository.GetById<ConsuntivazioneRotSaga>(sagaId);

            

            saga.ProgrammareIntervento(@event);
            
            Repository.Save(saga, @event.CommitId, null);

            return saga;
        }
    }
}
