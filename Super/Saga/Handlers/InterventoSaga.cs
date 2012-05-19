using CommonDomain.Core;
using Super.Schedulazione.Events;

namespace Super.Saga.Handlers
{
    public class InterventoSaga :IEventHandler<InterventoSchedulato>
    {
        public void Handle(InterventoSchedulato @event)
        {
            var sagaId = @event.Id; 
            // purchase correlation 
            var saga = repository.GetById(sagaId);
            saga.Transition(message); 
            
            repository.Save(saga);
        }
    }
}
