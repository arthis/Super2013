using System;
using CommonDomain.Core;
using Stateless;
using Super.Appaltatore.Commands;
using Super.Appaltatore.Commands.Builders;
using Super.Appaltatore.Events.Consuntivazione;
using Super.Programmazione.Events;
using Super.Programmazione.Events.Schedulazione;
using BuildApp = Super.Appaltatore.Commands.Builders.Build;
using BuildCtrl = Super.Controllo.Commands.Builders.Build;

namespace Super.Saga.Domain.Intervento
{
    public class InterventoRotSaga : SagaBase<Message>
    {

        private readonly StateMachine<State, Trigger> _stateMachine;
        private State _state = State.Start;

        public InterventoRotSaga()
        {
            Register<InterventoRotGenerated>(OnInterventoRotGenerated);
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

        public void ProgrammareIntervento(InterventoRotGenerated evt)
        {
            if (!_stateMachine.IsInState(State.Start))
                throw  new Exception("Saga already started");

            var cmd = Build.ProgrammareInterventoRot
                                .ForPeriod(evt.Period)
                                .ForImpianto(evt.IdImpianto)
                                .OfType(evt.IdTipoIntervento)
                                .ForAppaltatore(evt.IdAppaltatore)
                                .OfCategoriaCommerciale(evt.IdCategoriaCommerciale)
                                .OfDirezioneRegionale(evt.IdDirezioneRegionale)
                                .WithNote(evt.Note)
                                .WithOggetti(evt.Oggetti)
                                .WithTrenoPartenza(evt.TrenoPartenza)
                                .WithTrenoArrivo(evt.TrenoArrivo)
                                .WithTurnoTreno(evt.TurnoTreno)
                                .WithRigaTurnoTreno(evt.RigaTurnoTreno)
                                .ForConvoglio(evt.Convoglio)
                                .Build(evt.Id, 0);


            Dispatch(cmd);

            Transition(evt);
        }

        private void OnInterventoRotGenerated(InterventoRotGenerated evt)
        {
            //assign the Id for the Saga
            Id = evt.Id;
            //publish intervento to appaltatore
            _stateMachine.Fire(Trigger.Scheduled);
        }


        public void ConsuntivareIntervento(IInterventoRotConsuntivato evt)
        {
            if (!_stateMachine.IsInState(State.Programmation))
                throw new Exception("Saga is not in programamtion state");

            var cmd = BuildCtrl.AllowControlIntervento
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
