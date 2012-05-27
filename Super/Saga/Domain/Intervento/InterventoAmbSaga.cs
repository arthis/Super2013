using System;
using CommonDomain.Core;
using Stateless;
using Super.Appaltatore.Commands;
using Super.Programmazione.Events;

namespace Super.Saga.Domain.Intervento
{
    public class InterventoAmbSaga : SagaBase<Message>
    {

        private readonly StateMachine<State, Trigger> _stateMachine;
        private State _state = State.Start;

        public InterventoAmbSaga()
        {
            Register<InterventoAmbPianificato>(OnInterventoAmbPianificato);

            _stateMachine = new StateMachine<State, Trigger>(() => _state, newState => _state = newState);

            _stateMachine.Configure(State.Start)
                .Permit(Trigger.Scheduled, State.Programmation);

            _stateMachine.Configure(State.Programmation)
                .Permit(Trigger.Consuntivato, State.Control);

            _stateMachine.Configure(State.Control)
                .Permit(Trigger.Closed, State.End);

        }

        public void ProgrammareIntervento(InterventoAmbPianificato evt)
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

            cmd.SetCorrelationitId(evt.Id);

            Dispatch(cmd);

            Transition(evt);
        }

        private void OnInterventoAmbPianificato(InterventoAmbPianificato evt)
        {
            //publish intervento to appaltatore
            _stateMachine.Fire(Trigger.Scheduled);
        }


    }



}
