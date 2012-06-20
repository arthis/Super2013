using System;
using CommonDomain.Core;
using Stateless;
using Super.Appaltatore.Commands;
using Super.Appaltatore.Events.Consuntivazione;
using Super.Programmazione.Events;

namespace Super.Saga.Domain.Intervento
{
    public class InterventoRotSaga : SagaBase<Message>
    {

        private readonly StateMachine<State, Trigger> _stateMachine;
        private State _state = State.Start;

        public InterventoRotSaga()
        {
            Register<InterventoRotPianificato>(OnInterventoRotPianificato);

            _stateMachine = new StateMachine<State, Trigger>(() => _state, newState => _state = newState);

            _stateMachine.Configure(State.Start)
                .Permit(Trigger.Scheduled, State.Programmation);

            _stateMachine.Configure(State.Programmation)
                .Permit(Trigger.Consuntivato, State.Control);

            _stateMachine.Configure(State.Control)
                .Permit(Trigger.Closed, State.End);

        }

        public void ProgrammareIntervento(InterventoRotPianificato evt)
        {
            if (!_stateMachine.IsInState(State.Start))
                throw  new Exception("Saga already started");

            

            var cmd = new ProgrammareInterventoRot()
                          {
                              Id = evt.Id,
                              End = evt.End,
                              CommitId = Guid.NewGuid(),
                              IdAreaIntervento = evt.IdAreaIntervento,
                              Start = evt.Start,
                              IdTipoIntervento = evt.IdTipoIntervento,
                              IdAppaltatore = evt.IdAppaltatore,
                              IdCategoriaCommerciale = evt.IdCategoriaCommerciale,
                              IdDirezioneRegionale = evt.IdDirezioneRegionale,
                              Note = evt.Note,
                              Oggetti = evt.Oggetti,
                              NumeroTrenoArrivo = evt.NumeroTrenoArrivo,
                              DataTrenoArrivo = evt.DataTrenoArrivo,
                              NumeroTrenoPartenza = evt.NumeroTrenoPartenza,
                              DataTrenoPartenza = evt.DataTrenoPartenza,
                              TurnoTreno = evt.TurnoTreno,
                              RigaTurnoTreno = evt.RigaTurnoTreno,
                              Convoglio = evt.Convoglio
                          };
            Dispatch(cmd);

            Transition(evt);
        }

        private void OnInterventoRotPianificato(InterventoRotPianificato evt)
        {
            //assign the Id for the Saga
            Id = evt.Id;
            //publish intervento to appaltatore
            _stateMachine.Fire(Trigger.Scheduled);
        }


        public void ConsuntivareIntervento(IInterventoRotConsuntivato @event)
        {
            throw new NotImplementedException();
        }
        private void OnInterventoAmbConsuntivato(IInterventoRotConsuntivato evt)
        {
            throw new NotImplementedException();
        }
    }



}
