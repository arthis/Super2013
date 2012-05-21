using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Persistence;
using EasyNetQ;
using Super.Saga.Domain;
using Super.Saga.Events;
using Super.Schedulazione.Events;

namespace Super.Saga.Handlers
{
    public class InterventoSagaHandler : SagaHandler, IEventHandler<InterventoSchedulato>
    {

        public InterventoProgrammato CreateInterventoProgramato(InterventoSchedulato e)
        {
            var evt =  new InterventoProgrammato()
            {
                End = e.End,
                Id = e.Id,
                IdAreaIntervento = e.IdAreaIntervento,
                Start = e.Start,
                Headers = e.Headers
            };

            return evt;
        }

        public InterventoSagaHandler(ISagaRepository repository, IBus bus)
            : base(repository, bus)
        {
        }

        public void Handle(InterventoSchedulato @event)
        {
            var sagaId = @event.GetCorrelationId();

            // purchase correlation 
            var saga = Repository.GetById<InterventoSaga>(sagaId);

            if (saga.GetState() == InterventoSaga.State.Start)
            {
                var interventoProgrammato = CreateInterventoProgramato(@event);

                Bus.Publish(interventoProgrammato);

                saga.Transition(@event);

                Repository.Save(saga, @event.GetCommitId(), null);
            }
        }
    }
}
