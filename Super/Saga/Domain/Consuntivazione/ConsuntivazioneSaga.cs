using CommonDomain.Core;
using Stateless;
using Super.Appaltatore.Events.Consuntivazione;
using Super.Controllo.Commands;
using Super.Saga.Domain.Exceptions;
using Super.Saga.Domain.Intervento;

namespace Super.Saga.Domain.Consuntivazione
{
    public abstract class ConsuntivazioneSaga : SagaBase<Message>
    {
        protected readonly StateMachine<State, Trigger> _stateMachine;
        protected State _state = State.Start;

        public ConsuntivazioneSaga()
        {
            
            
            _stateMachine = new StateMachine<State, Trigger>(() => _state, newState => _state = newState);

            _stateMachine.Configure(State.Start)
                .Permit(Trigger.Scheduled, State.Programmation);

            _stateMachine.Configure(State.Programmation)
                .Permit(Trigger.Consuntivato, State.Control);

            _stateMachine.Configure(State.Control)
                .Permit(Trigger.Closed, State.End);
        }

        
    }
}