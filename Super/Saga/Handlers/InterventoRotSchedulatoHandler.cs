using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Persistence;
using EasyNetQ;
using Super.Saga.Domain;
using Super.Saga.Domain.Intervento;
using Super.Schedulazione.Events;
using ISaga = CommonDomain.ISaga;

namespace Super.Saga.Handlers
{
    public class InterventoRotSchedulatoHandler : SagaHandler<InterventoRotSchedulato>
    {
        public InterventoRotSchedulatoHandler(ISagaRepository repository, IBus bus)
            : base(repository, bus)
        {
        }

        protected sealed override ISaga OnHandle(InterventoRotSchedulato @event)
        {
            var sagaId = @event.GetCorrelationId();

            // purchase correlation 
            var saga = Repository.GetById<InterventoRotSaga>(sagaId);

            saga.ProgrammareIntervento(@event);
            
            Repository.Save(saga, @event.GetCommitId(), null);

            return saga;
        }
    }
}
