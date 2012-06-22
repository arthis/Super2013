using System;
using CommonDomain.Core;
using Stateless;
using Super.Appaltatore.Commands;
using Super.Appaltatore.Commands.Builders;
using Super.Appaltatore.Events.Consuntivazione;
using Super.Programmazione.Events;

namespace Super.Saga.Domain.Intervento
{
    public class InterventoRotManSaga : SagaBase<Message>
    {

        private readonly StateMachine<State, Trigger> _stateMachine;
        private State _state = State.Start;

        public InterventoRotManSaga()
        {
            Register<InterventoRotManPianificato>(OnInterventoRotManPianificato);

            _stateMachine = new StateMachine<State, Trigger>(() => _state, newState => _state = newState);

            _stateMachine.Configure(State.Start)
                .Permit(Trigger.Scheduled, State.Programmation);

            _stateMachine.Configure(State.Programmation)
                .Permit(Trigger.Consuntivato, State.Control);

            _stateMachine.Configure(State.Control)
                .Permit(Trigger.Closed, State.End);

        }

        public void ProgrammareIntervento(InterventoRotManPianificato evt)
        {
            if (!_stateMachine.IsInState(State.Start))
                throw new Exception("Saga already started");

            var builder = new ProgrammareInterventoRotManBuilder();
            var cmd = builder.ForId(evt.Id)
                                .ForPeriod(evt.Period)
                                .ForArea(evt.IdAreaIntervento)
                                .ForTipo(evt.IdTipoIntervento)
                                .ForAppaltatore(evt.IdAppaltatore)
                                .OfCategoriaCommerciale(evt.IdCategoriaCommerciale)
                                .OfDirezioneRegionale(evt.IdDirezioneRegionale)
                                .WithNote(evt.Note)
                                .WithOggetti(evt.Oggetti)
                                .Build();

            Dispatch(cmd);

            Transition(evt);
        }

        private void OnInterventoRotManPianificato(InterventoRotManPianificato evt)
        {
            //assign the Id for the Saga
            Id = evt.Id;
            //publish intervento to appaltatore
            _stateMachine.Fire(Trigger.Scheduled);
        }

        public void ConsuntivareIntervento(IInterventoRotManConsuntivato @event)
        {
            throw new NotImplementedException();
        }

        private void OnInterventoAmbConsuntivato(IInterventoRotManConsuntivato evt)
        {
            throw new NotImplementedException();
        }

    }




}
