﻿using System;
using CommonDomain.Core;
using Stateless;
using Super.Appaltatore.Events.Consuntivazione;
using Super.Controllo.Commands;
using Super.Programmazione.Events.Intervento;
using Super.Saga.Domain.Exceptions;
using Super.Saga.Domain.Intervento;
using BuildControlloCmd = Super.Controllo.Commands.BuildCmd;
using BuildAppaltatoreCmd = Super.Appaltatore.Commands.BuildCmd;

namespace Super.Saga.Domain.Consuntivazione
{
    public class ConsuntivaziioneRotManSaga : SagaBase<Message>
    {

        private readonly StateMachine<State, Trigger> _stateMachine;
        private State _state = State.Start;

        public ConsuntivaziioneRotManSaga()
        {
            Register<InterventoRotManCreated>(OnInterventoRotManGenerated);
            Register<InterventoRotManConsuntivatoReso>(OnInterventoConsuntivato);
            Register<InterventoRotManConsuntivatoNonReso>(OnInterventoConsuntivato);
            Register<InterventoRotManConsuntivatoNonResoTrenitalia>(OnInterventoConsuntivato);

            _stateMachine = new StateMachine<State, Trigger>(() => _state, newState => _state = newState);

            _stateMachine.Configure(State.Start)
                .Permit(Trigger.Scheduled, State.Programmation);

            _stateMachine.Configure(State.Programmation)
                .Permit(Trigger.Consuntivato, State.Control);

            _stateMachine.Configure(State.Control)
                .Permit(Trigger.Closed, State.End);

        }

        public void ProgrammareIntervento(InterventoRotManCreated evt)
        {
            if (!_stateMachine.IsInState(State.Start))
                throw new SagaStateException("Saga already started");

            var cmd = BuildAppaltatoreCmd.ProgramInterventoRotMan
                                .ForWorkPeriod(evt.WorkPeriod)
                                .ForImpianto(evt.IdImpianto)
                                .OfTipoIntervento(evt.IdTipoIntervento)
                                .ForAppaltatore(evt.IdAppaltatore)
                                .ForCategoriaCommerciale(evt.IdCategoriaCommerciale)
                                .ForDirezioneRegionale(evt.IdDirezioneRegionale)
                                .WithNote(evt.Note)
                                .WithOggetti(evt.Oggetti)
                                .ForProgramma(evt.IdProgramma)
                                .ForCommittente(evt.IdCommittente)
                                .ForLotto(evt.IdLotto)
                                .ForPeriodoProgrammazione(evt.IdPeriodoProgrammazione)
                                .WithNote(evt.Note)
                                .Build(evt.Id, 0);

            Dispatch(cmd);

            var cmdTimeOut = BuildAppaltatoreCmd.ConsuntivareAutomaticamenteNonReso
                .Build(evt.Id, 999, evt.WorkPeriod.EndDate.AddMinutes(20));

            Dispatch(cmdTimeOut);

            Transition(evt);
        }

        private void OnInterventoRotManGenerated(InterventoRotManCreated evt)
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
