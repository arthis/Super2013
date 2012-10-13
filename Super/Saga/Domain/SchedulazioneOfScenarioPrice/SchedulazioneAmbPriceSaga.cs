using System;
using CommonDomain.Core;
using Stateless;
using Super.Appaltatore.Events.Consuntivazione;
using Super.Contabilita.Commands;
using Super.Contabilita.Events.Schedulazione;
using Super.Programmazione.Events.Intervento;
using Super.Programmazione.Events.Scenario;
using Super.Programmazione.Events.Schedulazione;

namespace Super.Saga.Domain.SchedulazioneOfScenarioPrice
{
    public class SchedulazioneAmbPriceSaga : SagaBase<Message>
    {

        private readonly StateMachine<State, Trigger> _stateMachine;
        private State _state = State.Start;

        public SchedulazioneAmbPriceSaga()
        {
            Register<SchedulazioneAmbAddedToScenario>(OnSchedulazioneAmbAddedToScenario);
            Register<SchedulazionePriceOfScenarioCalculated>(OnSchedulazionePriceOfScenarioCalculated);

            _stateMachine = new StateMachine<State, Trigger>(() => _state, newState => _state = newState);

            _stateMachine.Configure(State.Start)
                .Permit(Trigger.SchedulazionAdded, State.Calculating);

            _stateMachine.Configure(State.Calculating)
                .Permit(Trigger.SchedulazioneCalculated, State.End);

        }

        public void CalculateSchedulazionePrice(SchedulazioneAmbAddedToScenario evt)
        {
            if (!_stateMachine.IsInState(State.Start))
                throw  new Exception("Saga already started");

            var cmd = BuildCmd.CalculateSchedulazioneAmbPriceOfScenario
                                 .ForPeriod(evt.Period)
                                 .ForScenario(evt.IdSchedulazione)
                                 .ForSchedulazione(evt.Id)
                                 .ForTipoIntervento(evt.IdTipoIntervento)
                                 .ForWorkPeriod(evt.WorkPeriod)
                                 .ForQuantity(evt.Quantity)
                                 .ForDescription(evt.Description)
                                .Build(evt.Id,0);

            Dispatch(cmd);

            Transition(evt);
        }

        private void OnSchedulazioneAmbAddedToScenario(SchedulazioneAmbAddedToScenario evt)
        {
            //assign the Id for the Saga  which is the Id Schedulazione
            Id = evt.Id;
            //asks the contabilita to calculate the price of the schedulazione
            _stateMachine.Fire(Trigger.SchedulazionAdded);
        }


        public void ProjectNumbers(SchedulazionePriceOfScenarioCalculated evt)
        {
            if (!_stateMachine.IsInState(State.Calculating))
                throw new Exception("Saga is not in calculating state");

            var cmd = Programmazione.Commands.BuildCmd.CalculateSchedulazionePrice
                .ForScenario(evt.IdScenario)
                .ToPrice(evt.Price)
                .Build(Id, 0);

            Dispatch(cmd);

            Transition(evt);
        }

        private void OnSchedulazionePriceOfScenarioCalculated(SchedulazionePriceOfScenarioCalculated evt)
        {
            //publish intervento to appaltatore
            _stateMachine.Fire(Trigger.SchedulazioneCalculated);
        }

    }



}
