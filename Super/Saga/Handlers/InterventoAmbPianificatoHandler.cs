using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Persistence;
using EasyNetQ;
using Super.Saga.Domain.Intervento;
using Super.Programmazione.Events;
using ISaga = CommonDomain.ISaga;

namespace Super.Saga.Handlers
{
    public class InterventoAmbPianificatoHandler : SagaHandler<InterventoAmbPianificato>
    {
        public InterventoAmbPianificatoHandler(ISagaRepository repository, IBus bus)
            : base(repository, bus)
        {
        }

        public sealed override ISaga OnHandle(InterventoAmbPianificato @event)
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
