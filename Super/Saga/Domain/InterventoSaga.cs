using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonDomain;
using CommonDomain.Core;
using Stateless;
using Super.Saga.Events;
using Super.Schedulazione.Events;

namespace Super.Saga.Domain
{
    public class InterventoSaga : SagaBase<Message>
    {
        enum Trigger
        {
            Scheduled,
            Consuntivato,
            Closed
        }

        public enum State
        {
            Start,
            Programmation,
            Control,
            End
        }

        private StateMachine<State, Trigger> _stateMachine;
        private State _state = State.Start;

        public State GetState()
        {
            return _state;
        }

        public InterventoSaga()
        {
            Register<InterventoSchedulato>(OnInterventoSchedulato);

            _stateMachine = new StateMachine<State, Trigger>(() => _state, newState => _state = newState);

            _stateMachine.Configure(State.Start)
                .Permit(Trigger.Scheduled, State.Programmation);

            _stateMachine.Configure(State.Programmation)
                .Permit(Trigger.Consuntivato, State.Control);

            _stateMachine.Configure(State.Control)
                .Permit(Trigger.Closed, State.End);

        }

        private void OnInterventoSchedulato(InterventoSchedulato evt)
        {
            //publish intervento to appaltatore
            _stateMachine.Fire(Trigger.Scheduled);

        }
    }
}
