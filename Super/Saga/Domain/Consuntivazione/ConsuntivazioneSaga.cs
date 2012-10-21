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

        public void ConsuntivareNonResoIntervento(IInterventoConsuntivato evt)
        {
            if (!_stateMachine.IsInState(State.Programmation))
                throw new SagaStateException("Saga is not in programamtion state");

            var cmd = BuildCmd.AllowInterventoControl
                .Build(Id, 0);

            Dispatch(cmd);

            Transition(evt);
        }

        protected void OnInterventoConsuntivatoNonReso(IInterventoConsuntivato evt)
        {
            //publish intervento to appaltatore
            _stateMachine.Fire(Trigger.Consuntivato);
        }

        public void ConsuntivareNonResoTrenitaliaIntervento(IInterventoConsuntivato evt)
        {
            if (!_stateMachine.IsInState(State.Programmation))
                throw new SagaStateException("Saga is not in programamtion state");

            var cmd = BuildCmd.AllowInterventoControl
                .Build(Id, 0);

            Dispatch(cmd);

            Transition(evt);
        }

        protected void OnInterventoConsuntivatoNonResoTrenitalia(IInterventoConsuntivato evt)
        {
            //publish intervento to appaltatore
            _stateMachine.Fire(Trigger.Consuntivato);
        }
    }
}