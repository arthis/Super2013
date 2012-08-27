using System;
using CommonDomain;
using Super.Contabilita.Events.Intervento;

namespace Super.Contabilita.Events.Builders.Intervento
{
    public class InterventoPriceOfPlanCalculatedBuilder : IEventBuilder<InterventoPriceOfPlanCalculated>
    {
        private Guid _idPlan;
        private decimal _price;


        public InterventoPriceOfPlanCalculated Build(Guid id, long version)
        {
            var evt = new InterventoPriceOfPlanCalculated(id, Guid.NewGuid(), version, _idPlan, _price );
            
            return evt;
        }


        public InterventoPriceOfPlanCalculatedBuilder ForPlan(Guid idPlan)
        {
            _idPlan = idPlan;
            return this;
        }

        public InterventoPriceOfPlanCalculatedBuilder ToPrice(decimal price)
        {
            _price = price;
            return this;
        }



    }

}