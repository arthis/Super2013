using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Handlers;
using CommonDomain.Persistence;
using Super.Programmazione.Events.Schedulazione;
using Super.Saga.Domain;
using Super.Saga.Domain.Intervento;
using Super.Programmazione.Events;
using ISaga = CommonDomain.ISaga;


namespace Super.Saga.Handlers
{
    public class InterventoRotManGeneratedHandler : SagaHandler<InterventoRotManGenerated>
    {
        public InterventoRotManGeneratedHandler(ISagaRepository repository, IBus bus)
            : base(repository, bus, null)
        {
        }

        public sealed override ISaga OnHandle(InterventoRotManGenerated @event)
        {
            var sagaId = @event.Id;

            // purchase correlation 
            var saga = Repository.GetById<InterventoRotManSaga>(sagaId);

            saga.ProgrammareIntervento(@event);

            Repository.Save(saga, @event.CommitId, null);

            return saga;
        }
    }
}
