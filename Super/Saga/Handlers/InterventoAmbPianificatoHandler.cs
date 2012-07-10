using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Handlers;
using CommonDomain.Persistence;
using Super.Saga.Domain.Intervento;
using Super.Programmazione.Events;
using ISaga = CommonDomain.ISaga;

namespace Super.Saga.Handlers
{
    public class InterventoAmbPianificatoHandler : SagaHandler<InterventoAmbPianificato>
    {
        public InterventoAmbPianificatoHandler(ISagaRepository repository, IBus bus)
            : base(repository, bus, null)
        {
        }

        public sealed override ISaga OnHandle(InterventoAmbPianificato @event)
        {
            var sagaId = @event.Id;

            // purchase correlation 
            var saga = Repository.GetById<InterventoAmbSaga>(sagaId);

            saga.ProgrammareIntervento(@event);

            Repository.Save(saga, @event.CommitId, null);

            return saga;
        }
    }
}
