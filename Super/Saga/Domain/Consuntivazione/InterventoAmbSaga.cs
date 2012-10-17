using System;
using CommonDomain.Core;
using Stateless;
using Super.Appaltatore.Events.Consuntivazione;
using BuildControlloCmd = Super.Controllo.Commands.BuildCmd;
using BuildAppaltatoreCmd = Super.Appaltatore.Commands.BuildCmd;
using Super.Programmazione.Events.Intervento;
using Super.Saga.Domain.Exceptions;
using Super.Saga.Domain.Intervento;


namespace Super.Saga.Domain.Consuntivazione
{
    public class ConsuntivaziioneAmbSaga : SagaBase<Message>
    {

        private readonly StateMachine<State, Trigger> _stateMachine;
        private State _state = State.Start;

        public ConsuntivaziioneAmbSaga()
        {
            Register<InterventoAmbCreated>(OnInterventoAmbGenerated);
            Register<InterventoAmbConsuntivatoReso>(OnInterventoConsuntivato);
            Register<InterventoAmbConsuntivatoNonReso>(OnInterventoConsuntivato);
            Register<InterventoAmbConsuntivatoNonResoTrenitalia>(OnInterventoConsuntivato);

            _stateMachine = new StateMachine<State, Trigger>(() => _state, newState => _state = newState);

            _stateMachine.Configure(State.Start)
                .Permit(Trigger.Scheduled, State.Programmation);

            _stateMachine.Configure(State.Programmation)
                .Permit(Trigger.Consuntivato, State.Control);

            _stateMachine.Configure(State.Control)
                .Permit(Trigger.Closed, State.End);

        }

        public void ProgrammareIntervento(InterventoAmbCreated evt)
        {
            if (!_stateMachine.IsInState(State.Start))
                throw  new SagaStateException("Saga already started");

            var cmdProgramm = BuildAppaltatoreCmd.ProgramInterventoAmb
                                .ForWorkPeriod(evt.WorkPeriod)
                                .ForImpianto(evt.IdImpianto)
                                .OfTipoIntervento(evt.IdTipoIntervento)
                                .ForAppaltatore(evt.IdAppaltatore)
                                .ForCategoriaCommerciale(evt.IdCategoriaCommerciale)
                                .ForDirezioneRegionale(evt.IdDirezioneRegionale)
                                .WithNote(evt.Note)
                                .ForQuantity(evt.Quantity)
                                .ForDescription(evt.Description)
                                .Build(evt.Id,0);

            Dispatch(cmdProgramm);

            var cmdTimeOut = BuildAppaltatoreCmd.ConsuntivareAutomaticamenteNonReso
                .Build(evt.Id, 999, evt.WorkPeriod.EndDate.AddMinutes(20));

            Dispatch(cmdTimeOut);

            Transition(evt);
        }

        private void OnInterventoAmbGenerated(InterventoAmbCreated evt)
        {
            //assign the Id for the Saga
            Id = evt.Id;
            //publish intervento to appaltatore
            _stateMachine.Fire(Trigger.Scheduled);
        }


        public void ConsuntivareIntervento(IInterventoConsuntivato evt)
        {
            if (!_stateMachine.IsInState(State.Programmation))
                throw new SagaStateException("Saga is not in programamtion state");

            var cmd = BuildControlloCmd.AllowControlIntervento
                                     .Build(Id, 0);

            Dispatch(cmd);

            Transition(evt);
        }

        private void OnInterventoConsuntivato(IInterventoConsuntivato evt)
        {
            //publish intervento to appaltatore
            _stateMachine.Fire(Trigger.Consuntivato);
        }

    }



}
