using System;
using CommonDomain.Core;
using Stateless;
using Super.Appaltatore.Commands;
using Super.Appaltatore.Events.Consuntivazione;
using Super.Controllo.Commands.Builders;
using Super.Programmazione.Events.Intervento;
using Super.Saga.Domain.Exceptions;
using Super.Saga.Domain.Intervento;

namespace Super.Saga.Domain.Consuntivazione
{
    public class ConsuntivaziioneRotSaga : SagaBase<Message>
    {

        private readonly StateMachine<State, Trigger> _stateMachine;
        private State _state = State.Start;

        public ConsuntivaziioneRotSaga()
        {
            Register<InterventoRotCreated>(OnInterventoRotCreated);
            Register<InterventoConsuntivatoRotReso>(OnInterventoConsuntivato);
            Register<InterventoConsuntivatoRotNonReso>(OnInterventoConsuntivato);
            Register<InterventoConsuntivatoRotNonResoTrenitalia>(OnInterventoConsuntivato);

            _stateMachine = new StateMachine<State, Trigger>(() => _state, newState => _state = newState);

            _stateMachine.Configure(State.Start)
                .Permit(Trigger.Scheduled, State.Programmation);

            _stateMachine.Configure(State.Programmation)
                .Permit(Trigger.Consuntivato, State.Control);

            _stateMachine.Configure(State.Control)
                .Permit(Trigger.Closed, State.End);

        }

        public void ProgrammareIntervento(InterventoRotCreated evt)
        {
            if (!_stateMachine.IsInState(State.Start))
                throw new SagaStateException("Saga already started");

            var cmdProgramm = BuildCmd.ProgramInterventoRot
                                .ForWorkPeriod(evt.WorkPeriod)
                                .ForImpianto(evt.IdImpianto)
                                .OfTipoIntervento(evt.IdTipoIntervento)
                                .ForAppaltatore(evt.IdAppaltatore)
                                .ForCategoriaCommerciale(evt.IdCategoriaCommerciale)
                                .ForDirezioneRegionale(evt.IdDirezioneRegionale)
                                .WithNote(evt.Note)
                                .WithOggetti(evt.Oggetti)
                                .WithTrenoPartenza(evt.TrenoPartenza)
                                .WithTrenoArrivo(evt.TrenoArrivo)
                                .WithTurnoTreno(evt.TurnoTreno)
                                .WithRigaTurnoTreno(evt.RigaTurnoTreno)
                                .ForConvoglio(evt.Convoglio)
                                .ForProgramma(evt.IdProgramma)
                                .Build(evt.Id, 0);


            Dispatch(cmdProgramm);

            var cmdTimeOut = BuildCmd.ConsuntivareAutomaticamenteNonReso
                .Build(evt.Id, 999, evt.WorkPeriod.EndDate.AddMinutes(20));

            Dispatch(cmdTimeOut);

            Transition(evt);
        }

        private void OnInterventoRotCreated(InterventoRotCreated evt)
        {
            //assign the Id for the Saga
            Id = evt.Id;
            //publish intervento to appaltatore
            _stateMachine.Fire(Trigger.Scheduled);
        }


        public void ConsuntivareIntervento(IInterventoRotConsuntivato evt)
        {
            if (!_stateMachine.IsInState(State.Programmation))
                throw new SagaStateException("Saga is not in programamtion state");

            var cmd = Build.AllowControlIntervento
                                     .Build(Id, 0);

            Dispatch(cmd);

            Transition(evt);
        }
        private void OnInterventoConsuntivato(IInterventoRotConsuntivato evt)
        {
            //publish intervento to appaltatore
            _stateMachine.Fire(Trigger.Consuntivato);
        }
    }



}
