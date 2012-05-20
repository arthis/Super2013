using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Persistence;
using Super.Saga.Domain;
using Super.Schedulazione.Events;

namespace Super.Saga.Handlers
{
    public class InterventoSagaHandler : SagaHandler
    {
        public InterventoSagaHandler(ISagaRepository repository) : base(repository)
        {
        }

        public void Handle( IMessage message)
        {
            var sagaId = message.PayLoad.Id; 
            // purchase correlation 
            var saga = Repository.GetById<InterventoSaga>(sagaId);

            saga.Transition(message);

            Repository.Save(saga, message.CommitId,null);
        }
    }
}
