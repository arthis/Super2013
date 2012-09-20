using System;
using CommonDomain;
using Super.Contabilita.Events.Schedulazione;

namespace Super.Contabilita.Events.Builders.Schedulazione
{
    public class SchedulazionePriceOfScenarioCalculatedBuilder : IEventBuilder<SchedulazionePriceOfScenarioCalculated>
    {
        private decimal _price;
        private Guid _idScenario;


        public SchedulazionePriceOfScenarioCalculated Build(Guid id, long version)
        {
            var evt = new SchedulazionePriceOfScenarioCalculated(id, Guid.NewGuid(), version, _idScenario,  _price);
            
            return evt;
        }


        public SchedulazionePriceOfScenarioCalculatedBuilder ForScenario(Guid idScenario)
        {
            _idScenario = idScenario;
            return this;
        }



        public SchedulazionePriceOfScenarioCalculatedBuilder ToPrice(decimal price)
        {
            _price = price;
            return this;
        }



    }

}