using System;
using CommonDomain.Core;
using Stateless;
using Super.Appaltatore.Events.Consuntivazione;
using Super.Contabilita.Commands;
using Super.Contabilita.Events.Schedulation;
using Super.Programmazione.Events.Intervento;
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
            Register<SchedulationPriceOfScenarioCalculated>(OnSchedulationPriceOfScenarioCalculated);

            _stateMachine = new StateMachine<State, Trigger>(() => _state, newState => _state = newState);

            _stateMachine.Configure(State.Start)
                .Permit(Trigger.SchedulazionAdded, State.Calculating);

            _stateMachine.Configure(State.Calculating)
                .Permit(Trigger.SchedulazioneCalculated, State.End);

        }

        public void CalcolarePrezzoSchedulazione(SchedulazioneAmbAddedToScenario evt)
        {
            if (!_stateMachine.IsInState(State.Start))
                throw  new Exception("Saga already started");

            var cmd = BuildCmd.CalculateSchedulazioneAmbPriceOfScenario
                                 .ForPeriod(evt.Period)
                                 .ForScenario(evt.IdScenario)
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


        public void CalculateSchedulazionePrice(SchedulationPriceOfScenarioCalculated evt)
        {
            if (!_stateMachine.IsInState(State.Calculating))
                throw new Exception("Saga is not in calculating state");

            var cmd = Super.Programmazione.Commands.BuildCmd.CalculateSchedulazionePrice
                                     .Build(Id, 0);

            Dispatch(cmd);

            Transition(evt);
        }

        private void OnSchedulationPriceOfScenarioCalculated(SchedulationPriceOfScenarioCalculated evt)
        {
            //publish intervento to appaltatore
            _stateMachine.Fire(Trigger.SchedulazioneCalculated);
        }

    }



}
