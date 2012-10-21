using System;
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
    public class ConsuntivazioneRotManSaga : ConsuntivazioneSaga
    {

        public ConsuntivazioneRotManSaga()
        {
            Register<InterventoRotManCreated>(OnInterventoRotManCreated);
            Register<InterventoRotManConsuntivatoReso>(OnInterventoConsuntivato);
            Register<InterventoRotManConsuntivatoNonReso>(OnInterventoConsuntivatoNonReso);
            Register<InterventoRotManConsuntivatoNonResoTrenitalia>(OnInterventoConsuntivatoNonResoTrenitalia);

        }

        public void ProgrammareIntervento(InterventoRotManCreated evt)
        {
            if (!_stateMachine.IsInState(State.Start))
                throw new SagaStateException("Saga already started");

            var cmdProgrammAppaltatore = BuildAppaltatoreCmd.ProgramInterventoRotMan
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
                                .Build(evt.Id);

            Dispatch(cmdProgrammAppaltatore);

            var cmdProgrammControllo = BuildControlloCmd.ProgramInterventoRotMan
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
                                .Build(evt.Id);

            Dispatch(cmdProgrammControllo);

            var dataConsuntivazioneAutomatica = evt.WorkPeriod.EndDate.AddMinutes(20);
            var cmdTimeOut = BuildAppaltatoreCmd.ConsuntivareAutomaticamenteNonResoInterventoRotMan
                .ForDataConsuntivazione(dataConsuntivazioneAutomatica)
                .Build(evt.Id, dataConsuntivazioneAutomatica);

            Dispatch(cmdTimeOut);

            Transition(evt);
        }

        private void OnInterventoRotManCreated(InterventoRotManCreated evt)
        {
            //assign the Id for the Saga
            Id = evt.Id;
            //publish intervento to appaltatore
            _stateMachine.Fire(Trigger.Scheduled);
        }

        public void ConsuntivareResoIntervento(InterventoRotManConsuntivatoReso evt)
        {
            if (!_stateMachine.IsInState(State.Programmation))
                throw new SagaStateException("Saga is not in programamtion state");

            var cmd = BuildControlloCmd.ConsuntivareResoInterventoRotMan
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

        public void ConsuntivareNonResoIntervento(InterventoRotManConsuntivatoNonReso evt)
        {
            if (!_stateMachine.IsInState(State.Programmation))
                throw new SagaStateException("Saga is not in programamtion state");

            var cmd = BuildControlloCmd.ConsuntivareNonResoInterventoRotMan
                .ForInterventoAppaltatore(evt.IdInterventoAppaltatore)
                .When(evt.DataConsuntivazione)
                .WithNote(evt.Note)
                .Because(evt.IdCausaleAppaltatore)
                .Build(evt.Id);

            Dispatch(cmd);

            Transition(evt);
        }

        protected void OnInterventoConsuntivatoNonReso(InterventoRotManConsuntivatoNonReso evt)
        {
            //publish intervento to appaltatore
            _stateMachine.Fire(Trigger.Consuntivato);
        }

        public void ConsuntivareNonResoTrenitaliaIntervento(InterventoRotManConsuntivatoNonResoTrenitalia evt)
        {
            if (!_stateMachine.IsInState(State.Programmation))
                throw new SagaStateException("Saga is not in programmation state");

            var cmd = BuildControlloCmd.ConsuntivareNonResoTrenitaliaInterventoRotMan
                .ForInterventoAppaltatore(evt.IdInterventoAppaltatore)
                .When(evt.DataConsuntivazione)
                .WithNote(evt.Note)
                .Because(evt.IdCausaleTrenitalia)
                .Build(evt.Id);

            Dispatch(cmd);

            Transition(evt);
        }

        protected void OnInterventoConsuntivatoNonResoTrenitalia(InterventoRotManConsuntivatoNonResoTrenitalia evt)
        {
            //publish intervento to appaltatore
            _stateMachine.Fire(Trigger.Consuntivato);
        }     

    }




}
