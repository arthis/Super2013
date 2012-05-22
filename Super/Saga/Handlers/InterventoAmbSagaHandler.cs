using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Persistence;
using EasyNetQ;
using Super.Saga.Domain.Intervento;
using Super.Schedulazione.Events;
using ISaga = CommonDomain.ISaga;

namespace Super.Saga.Handlers
{
    public class InterventoAmbSchedulatoHandler : SagaHandler<InterventoAmbSchedulato>
    {
        public InterventoAmbSchedulatoHandler(ISagaRepository repository, IBus bus)
            : base(repository, bus)
        {
        }

        protected sealed override ISaga OnHandle(InterventoAmbSchedulato @event)
        {
            var sagaId = @event.GetCorrelationId();

            // purchase correlation 
            var saga = Repository.GetById<InterventoAmbSaga>(sagaId);

            saga.ProgrammareIntervento(@event);

            Repository.Save(saga, @event.GetCommitId(), null);

            return saga;
        }
    }
}
