using System;
using CommonDomain.Core;
using Stateless;
using Super.Appaltatore.Commands;
using Super.Schedulazione.Events;

namespace Super.Saga.Domain.Intervento
{
    public class InterventoAmbSaga : SagaBase<Message>
    {

        private readonly StateMachine<State, Trigger> _stateMachine;
        private State _state = State.Start;

        public InterventoAmbSaga()
        {
            Register<InterventoAmbSchedulato>(OnInterventoAmbSchedulato);

            _stateMachine = new StateMachine<State, Trigger>(() => _state, newState => _state = newState);

            _stateMachine.Configure(State.Start)
                .Permit(Trigger.Scheduled, State.Programmation);

            _stateMachine.Configure(State.Programmation)
                .Permit(Trigger.Consuntivato, State.Control);

            _stateMachine.Configure(State.Control)
                .Permit(Trigger.Closed, State.End);

        }

        public void ProgrammareIntervento(InterventoAmbSchedulato evt)
        {
            if (!_stateMachine.IsInState(State.Start))
                throw  new Exception("Saga already started");

            var cmd = new ProgrammareInterventoAmb()
                          {
                              Id = evt.Id,
                              End = evt.End,
                              Headers = evt.Headers,
                              IdAreaIntervento = evt.IdAreaIntervento,
                              Start = evt.Start
                          };
            Dispatch(cmd);

            Transition(evt);
        }

        private void OnInterventoAmbSchedulato(InterventoAmbSchedulato evt)
        {
            //publish intervento to appaltatore
            _stateMachine.Fire(Trigger.Scheduled);
        }


    }



}
