using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Persistence;
using EasyNetQ;
using Super.Saga.Domain;
using Super.Saga.Domain.Intervento;
using Super.Programmazione.Events;
using ISaga = CommonDomain.ISaga;

namespace Super.Saga.Handlers
{
    public class InterventoRotPianificatoHandler : SagaHandler<InterventoRotPianificato>
    {
        public InterventoRotPianificatoHandler(ISagaRepository repository, IBus bus)
            : base(repository, bus)
        {
        }

        public sealed override ISaga OnHandle(InterventoRotPianificato @event)
        {
            var sagaId = @event.Id;

            // purchase correlation 
            var saga = Repository.GetById<InterventoRotSaga>(sagaId);

            saga.ProgrammareIntervento(@event);
            
            Repository.Save(saga, @event.GetCommitId(), null);

            return saga;
        }
    }
}
