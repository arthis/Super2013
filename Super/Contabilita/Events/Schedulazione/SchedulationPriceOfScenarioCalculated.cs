using System;
using System.Diagnostics.Contracts;
using System.Linq;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Super.Messaging.ValueObjects;

namespace Super.Contabilita.Events.Schedulazione
{
    public class SchedulazionePriceOfScenarioCalculated:Message, IEvent
    {
        public Guid IdScenario { get; set; }
        public decimal Price { get; set; }

        public SchedulazionePriceOfScenarioCalculated()
        {
            
        }

        public SchedulazionePriceOfScenarioCalculated(Guid id,
            Guid commitId,
            long version,
            Guid idScenario,
            decimal price)
            : base(id,commitId,  version)
        {
            Contract.Requires(idScenario!= Guid.Empty);
            Contract.Requires(price>=0);

            IdScenario = idScenario;
            Price = price;
        }


        public override string ToDescription()
        {
            return string.Format("Il prezzo della schedulazione {0} é stata calcolato.", Id);
        }

        protected bool Equals(SchedulazionePriceOfScenarioCalculated other)
        {
            return base.Equals(other) && IdScenario.Equals(other.IdScenario) && Price == other.Price;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((SchedulazionePriceOfScenarioCalculated) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = base.GetHashCode();
                hashCode = (hashCode*397) ^ IdScenario.GetHashCode();
                hashCode = (hashCode*397) ^ Price.GetHashCode();
                return hashCode;
            }
        }
    }

    
}