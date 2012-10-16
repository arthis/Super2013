﻿using System;
using CommonDomain.Core;
using Stateless;
using Super.Appaltatore.Commands;

using Super.Appaltatore.Events.Consuntivazione;
using Super.Programmazione.Events;
using Super.Programmazione.Events.Intervento;
using Super.Programmazione.Events.Schedulazione;
using BuildApp = Super.Appaltatore.Commands.BuildCmd;
using BuildCtrl = Super.Controllo.Commands.Builders.Build;

namespace Super.Saga.Domain.Intervento
{
    public class InterventoRotManSaga : SagaBase<Message>
    {

        private readonly StateMachine<State, Trigger> _stateMachine;
        private State _state = State.Start;

        public InterventoRotManSaga()
        {
            Register<InterventoRotManCreated>(OnInterventoRotManGenerated);
            Register<InterventoConsuntivatoRotManReso>(OnInterventoConsuntivato);
            Register<InterventoConsuntivatoRotManNonReso>(OnInterventoConsuntivato);
            Register<InterventoConsuntivatoRotManNonResoTrenitalia>(OnInterventoConsuntivato);

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
                throw new Exception("Saga already started");

            var cmd = BuildApp.ProgramInterventoRotMan
                                .ForWorkPeriod(evt.WorkPeriod)
                                .ForImpianto(evt.IdImpianto)
                                .OfTipoIntervento(evt.IdTipoIntervento)
                                .ForAppaltatore(evt.IdAppaltatore)
                                .ForCategoriaCommerciale(evt.IdCategoriaCommerciale)
                                .ForDirezioneRegionale(evt.IdDirezioneRegionale)
                                .WithNote(evt.Note)
                                .WithOggetti(evt.Oggetti)
                                .Build(evt.Id, 0);

            Dispatch(cmd);

            Transition(evt);
        }

        private void OnInterventoRotManGenerated(InterventoRotManCreated evt)
        {
            //assign the Id for the Saga
            Id = evt.Id;
            //publish intervento to appaltatore
            _stateMachine.Fire(Trigger.Scheduled);
        }

        public void ConsuntivareIntervento(IInterventoRotManConsuntivato evt)
        {
            if (!_stateMachine.IsInState(State.Programmation))
                throw new Exception("Saga is not in programamtion state");

            var cmd = BuildCtrl.AllowControlIntervento
                                     .Build(Id, 0);

            Dispatch(cmd);

            Transition(evt);
        }

        private void OnInterventoConsuntivato(IInterventoRotManConsuntivato evt)
        {
            //publish intervento to appaltatore
            _stateMachine.Fire(Trigger.Consuntivato);
        }

     

    }




}
