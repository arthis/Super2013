using System;
using CommonDomain.Core;
using Stateless;
using Super.Appaltatore.Events.Consuntivazione;
using Super.Programmazione.Events.Intervento;
using Super.Saga.Domain.Exceptions;
using Super.Saga.Domain.Intervento;
using BuildControlloCmd = Super.Controllo.Commands.BuildCmd;
using BuildAppaltatoreCmd = Super.Appaltatore.Commands.BuildCmd;

namespace Super.Saga.Domain.Consuntivazione
{
    public class ConsuntivazioneRotSaga : ConsuntivazioneSaga
    {


        public ConsuntivazioneRotSaga()
        {
            Register<InterventoRotCreated>(OnInterventoRotCreated);
            Register<InterventoRotConsuntivatoReso>(OnInterventoConsuntivato);
            Register<InterventoRotConsuntivatoNonReso>(OnInterventoConsuntivatoNonReso);
            Register<InterventoRotConsuntivatoNonResoTrenitalia>(OnInterventoConsuntivatoNonResoTrenitalia);

        }

        public void ProgrammareIntervento(InterventoRotCreated evt)
        {
            if (!_stateMachine.IsInState(State.Start))
                throw new SagaStateException("Saga already started");

            var cmdProgrammAppaltatore = BuildAppaltatoreCmd.ProgramInterventoRot
                                .ForWorkPeriod(evt.WorkPeriod)
                                .ForImpianto(evt.IdImpianto)
                                .OfTipoIntervento(evt.IdTipoIntervento)
                                .ForAppaltatore(evt.IdAppaltatore)
                                .ForCategoriaCommerciale(evt.IdCategoriaCommerciale)
                                .ForDirezioneRegionale(evt.IdDirezioneRegionale)
                                .WithNote(evt.Note)
                                .ForCommittente(evt.IdCommittente)
                                .ForLotto(evt.IdLotto)
                                .ForPeriodoProgrammazione(evt.IdPeriodoProgrammazione)                     
                                .WithOggetti(evt.Oggetti)
                                .WithTrenoPartenza(evt.TrenoPartenza)
                                .WithTrenoArrivo(evt.TrenoArrivo)
                                .WithTurnoTreno(evt.TurnoTreno)
                                .WithRigaTurnoTreno(evt.RigaTurnoTreno)
                                .ForConvoglio(evt.Convoglio)
                                .ForProgramma(evt.IdProgramma)
                                .Build(evt.Id);

            Dispatch(cmdProgrammAppaltatore);

            var cmdProgrammControllo = BuildControlloCmd.ProgramInterventoRot
                                .ForWorkPeriod(evt.WorkPeriod)
                                .ForImpianto(evt.IdImpianto)
                                .OfTipoIntervento(evt.IdTipoIntervento)
                                .ForAppaltatore(evt.IdAppaltatore)
                                .ForCategoriaCommerciale(evt.IdCategoriaCommerciale)
                                .ForDirezioneRegionale(evt.IdDirezioneRegionale)
                                .WithNote(evt.Note)
                                .ForCommittente(evt.IdCommittente)
                                .ForLotto(evt.IdLotto)
                                .ForPeriodoProgrammazione(evt.IdPeriodoProgrammazione)
                                .WithOggetti(evt.Oggetti)
                                .WithTrenoPartenza(evt.TrenoPartenza)
                                .WithTrenoArrivo(evt.TrenoArrivo)
                                .WithTurnoTreno(evt.TurnoTreno)
                                .WithRigaTurnoTreno(evt.RigaTurnoTreno)
                                .ForConvoglio(evt.Convoglio)
                                .ForProgramma(evt.IdProgramma)
                                .Build(evt.Id);

            Dispatch(cmdProgrammControllo);

            var dataConsuntivazioneAutomatica = evt.WorkPeriod.EndDate.AddMinutes(20);
            var cmdTimeOut = BuildAppaltatoreCmd.ConsuntivareAutomaticamenteNonResoInterventoRot
                .ForDataConsuntivazione(dataConsuntivazioneAutomatica)
                .Build(evt.Id,  dataConsuntivazioneAutomatica);

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


        public void ConsuntivareResoIntervento(InterventoRotConsuntivatoReso evt)
        {
            if (!_stateMachine.IsInState(State.Programmation))
                throw new SagaStateException("Saga is not in programamtion state");

            var cmd = BuildControlloCmd.ConsuntivareResoInterventoRot
                .ForInterventoAppaltatore(evt.IdInterventoAppaltatore)
                .ForWorkPeriod(evt.WorkPeriod)
                .When(evt.DataConsuntivazione)
                .WithNote(evt.Note)
                .WithOggetti(evt.Oggetti)
                .Build(evt.Id);

            Dispatch(cmd);

            Transition(evt);
        }

        private void OnInterventoConsuntivato(IInterventoConsuntivato evt)
        {
            //publish intervento to appaltatore
            _stateMachine.Fire(Trigger.Consuntivato);
        }

        public void ConsuntivareNonResoIntervento(InterventoRotConsuntivatoNonReso evt)
        {
            if (!_stateMachine.IsInState(State.Programmation))
                throw new SagaStateException("Saga is not in programamtion state");

            var cmd = BuildControlloCmd.ConsuntivareNonResoInterventoRot
                .ForInterventoAppaltatore(evt.IdInterventoAppaltatore)
                .When(evt.DataConsuntivazione)
                .WithNote(evt.Note)
                .Because(evt.IdCausaleAppaltatore)
                .Build(evt.Id);

            Dispatch(cmd);

            Transition(evt);
        }

        protected void OnInterventoConsuntivatoNonReso(InterventoRotConsuntivatoNonReso evt)
        {
            //publish intervento to appaltatore
            _stateMachine.Fire(Trigger.Consuntivato);
        }

        public void ConsuntivareNonResoTrenitaliaIntervento(InterventoRotConsuntivatoNonResoTrenitalia evt)
        {
            if (!_stateMachine.IsInState(State.Programmation))
                throw new SagaStateException("Saga is not in programamtion state");

            var cmd = BuildControlloCmd.ConsuntivareNonResoTrenitaliaInterventoRot
                .ForInterventoAppaltatore(evt.IdInterventoAppaltatore)
                .When(evt.DataConsuntivazione)
                .WithNote(evt.Note)
                .Because(evt.IdCausaleTrenitalia)
                .Build(evt.Id);

            Dispatch(cmd);

            Transition(evt);
        }

        protected void OnInterventoConsuntivatoNonResoTrenitalia(IInterventoConsuntivato evt)
        {
            //publish intervento to appaltatore
            _stateMachine.Fire(Trigger.Consuntivato);
        }
    }



}
