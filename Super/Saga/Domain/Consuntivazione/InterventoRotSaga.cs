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
    public class ConsuntivaziioneRotSaga : ConsuntivazioneSaga
    {


        public ConsuntivaziioneRotSaga()
        {
            Register<InterventoRotCreated>(OnInterventoRotCreated);
            Register<InterventoRotConsuntivatoReso>(OnInterventoConsuntivato);
            Register<InterventoRotConsuntivatoNonReso>(OnInterventoConsuntivato);
            Register<InterventoRotConsuntivatoNonResoTrenitalia>(OnInterventoConsuntivato);

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
                                .Build(evt.Id, 0);

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
                                .Build(evt.Id, 0);

            Dispatch(cmdProgrammControllo);

            var cmdTimeOut = BuildAppaltatoreCmd.ConsuntivareAutomaticamenteNonReso
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


        public void ConsuntivareResoIntervento(IInterventoConsuntivato evt)
        {
            if (!_stateMachine.IsInState(State.Programmation))
                throw new SagaStateException("Saga is not in programamtion state");

            var cmd = BuildControlloCmd.AllowInterventoControl
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
