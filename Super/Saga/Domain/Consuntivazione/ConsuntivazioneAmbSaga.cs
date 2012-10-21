using System;
using Super.Appaltatore.Events.Consuntivazione;
using BuildControlloCmd = Super.Controllo.Commands.BuildCmd;
using BuildAppaltatoreCmd = Super.Appaltatore.Commands.BuildCmd;
using Super.Programmazione.Events.Intervento;
using Super.Saga.Domain.Exceptions;
using Super.Saga.Domain.Intervento;


namespace Super.Saga.Domain.Consuntivazione
{
    public class ConsuntivazioneAmbSaga : ConsuntivazioneSaga
    {

        public ConsuntivazioneAmbSaga()
        {
            Register<InterventoAmbConsuntivatoNonReso>(OnInterventoConsuntivatoNonReso);
            Register<InterventoAmbConsuntivatoNonResoTrenitalia>(OnInterventoConsuntivatoNonResoTrenitalia);
            Register<InterventoAmbCreated>(OnInterventoAmbCreated);
            Register<InterventoAmbConsuntivatoReso>(OnInterventoConsuntivato);

        }

        public void ProgrammareIntervento(InterventoAmbCreated evt)
        {
            if (!_stateMachine.IsInState(State.Start))
                throw  new SagaStateException("Saga already started");

            var cmdAppaltatore = BuildAppaltatoreCmd.ProgramInterventoAmb
                                .ForWorkPeriod(evt.WorkPeriod)
                                .ForImpianto(evt.IdImpianto)
                                .OfTipoIntervento(evt.IdTipoIntervento)
                                .ForAppaltatore(evt.IdAppaltatore)
                                .ForCategoriaCommerciale(evt.IdCategoriaCommerciale)
                                .ForDirezioneRegionale(evt.IdDirezioneRegionale)
                                .ForQuantity(evt.Quantity)
                                .ForDescription(evt.Description)
                                .WithNote(evt.Note)
                                .ForPeriodoProgrammazione(evt.IdPeriodoProgrammazione)
                                .ForCommittente(evt.IdCommittente)
                                .ForProgramma(evt.IdProgramma)
                                .ForLotto(evt.IdLotto)
                                .Build(evt.Id);

            Dispatch(cmdAppaltatore);

            var cmdControllo = BuildControlloCmd.ProgramInterventoAmb
                                .ForWorkPeriod(evt.WorkPeriod)
                                .ForImpianto(evt.IdImpianto)
                                .OfTipoIntervento(evt.IdTipoIntervento)
                                .ForAppaltatore(evt.IdAppaltatore)
                                .ForCategoriaCommerciale(evt.IdCategoriaCommerciale)
                                .ForDirezioneRegionale(evt.IdDirezioneRegionale)
                                .ForQuantity(evt.Quantity)
                                .ForDescription(evt.Description)
                                .WithNote(evt.Note)
                                .ForPeriodoProgrammazione(evt.IdPeriodoProgrammazione)
                                .ForCommittente(evt.IdCommittente)
                                .ForProgramma(evt.IdProgramma)
                                .ForLotto(evt.IdLotto)
                                .Build(evt.Id);

            Dispatch(cmdControllo);

            var dataConsuntivazioneAutomatica = evt.WorkPeriod.EndDate.AddMinutes(20);
            var cmdTimeOut = BuildAppaltatoreCmd.ConsuntivareAutomaticamenteNonResoInterventoAmb
                .ForDataConsuntivazione(dataConsuntivazioneAutomatica)
                .Build(evt.Id,  dataConsuntivazioneAutomatica);

            Dispatch(cmdTimeOut);

            Transition(evt);
        }

        private void OnInterventoAmbCreated(InterventoAmbCreated evt)
        {
            //assign the Id for the Saga
            Id = evt.Id;
            //publish intervento to appaltatore
            _stateMachine.Fire(Trigger.Scheduled);
        }

        public void ConsuntivareResoIntervento(InterventoAmbConsuntivatoReso evt)
        {
            if (!_stateMachine.IsInState(State.Programmation))
                throw new SagaStateException("Saga is not in programamtion state");

            var cmd = BuildControlloCmd.ConsuntivareResoInterventoAmb
                .ForInterventoAppaltatore(evt.IdInterventoAppaltatore)
                .ForWorkPeriod(evt.WorkPeriod)
                .When(evt.DataConsuntivazione)
                .WithNote(evt.Note)
                .ForQuantity(evt.Quantity)
                .ForDescription(evt.Description)
                .Build(evt.Id);

            Dispatch(cmd);

            Transition(evt);
        }

        private void OnInterventoConsuntivato(InterventoAmbConsuntivatoReso evt)
        {
            //publish intervento to appaltatore
            _stateMachine.Fire(Trigger.Consuntivato);
        }

        public void ConsuntivareNonResoIntervento(InterventoAmbConsuntivatoNonReso evt)
        {
            if (!_stateMachine.IsInState(State.Programmation))
                throw new SagaStateException("Saga is not in programamtion state");

            var cmd = BuildControlloCmd.ConsuntivareNonResoInterventoAmb
                .ForInterventoAppaltatore(evt.IdInterventoAppaltatore)
                .When(evt.DataConsuntivazione)
                .WithNote(evt.Note)
                .Because(evt.IdCausaleAppaltatore)
                .Build(evt.Id);

            Dispatch(cmd);

            Transition(evt);
        }

        protected void OnInterventoConsuntivatoNonReso(InterventoAmbConsuntivatoNonReso evt)
        {
            //publish intervento to appaltatore
            _stateMachine.Fire(Trigger.Consuntivato);
        }

        public void ConsuntivareNonResoTrenitaliaIntervento(InterventoAmbConsuntivatoNonResoTrenitalia evt)
        {
            if (!_stateMachine.IsInState(State.Programmation))
                throw new SagaStateException("Saga is not in programamtion state");

            var cmd = BuildControlloCmd.ConsuntivareNonResoTrenitaliaInterventoAmb
                .ForInterventoAppaltatore(evt.IdInterventoAppaltatore)
                .When(evt.DataConsuntivazione)
                .WithNote(evt.Note)
                .Because(evt.IdCausaleTrenitalia)
                .Build(evt.Id);

            Dispatch(cmd);

            Transition(evt);
        }

        protected void OnInterventoConsuntivatoNonResoTrenitalia(InterventoAmbConsuntivatoNonResoTrenitalia evt)
        {
            //publish intervento to appaltatore
            _stateMachine.Fire(Trigger.Consuntivato);
        }

    }



}
