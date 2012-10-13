using System;
using System.Diagnostics.Contracts;
using CommonDomain.Core;
using Super.Programmazione.Commands.Scenario;

namespace Super.Programmazione.Commands.Schedulazione
{
    public class CalculateSchedulazionePriceOfScenario : CommandBase
    {
        public Guid IdScenario { get; set; }
        public decimal Price { get; set; }


        public CalculateSchedulazionePriceOfScenario()
        {
            
        }

        public CalculateSchedulazionePriceOfScenario(Guid id, Guid commitId, long version, Guid idScenario, decimal price)
            : base(id, commitId, version)
        {
            Contract.Requires(idScenario!= Guid.Empty);
            Contract.Requires(price>=0);

            IdScenario = idScenario;
            Price = price;
        }

        public override string ToDescription()
        {
            return string.Format("Calcola il prezzo della schedulazione {0} con i dati di contabilita", Id);
        }

        public bool Equals(CancelScenario other)
        {
            return base.Equals(other);
        }

        protected bool Equals(CalculateSchedulazionePriceOfScenario other)
        {
            return base.Equals(other) && IdScenario.Equals(other.IdScenario) && Price == other.Price;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CalculateSchedulazionePriceOfScenario) obj);
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
