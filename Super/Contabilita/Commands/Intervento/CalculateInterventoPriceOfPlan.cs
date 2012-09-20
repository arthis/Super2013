using System;
using System.Diagnostics.Contracts;
using System.Linq;
using CommonDomain.Core;
using CommonDomain.Core.Super.Messaging.ValueObjects;

namespace Super.Contabilita.Commands.Intervento
{
    public abstract class CalculateInterventoPriceOfPlan:CommandBase
    {
        public Guid IdPlan { get; set; }
        public Guid IdBachBouzouk { get; set; }
        public Guid IdTipoIntervento { get; set; }
        public WorkPeriod WorkPeriod { get; set; }

        public CalculateInterventoPriceOfPlan()
        {
            
        }

        public CalculateInterventoPriceOfPlan(Guid id,
                                   Guid commitId,
                                   long version,
                                   Guid idPlan,
                                   Guid idBachBouzouk,
                                   Guid idTipoIntervento,
                                   WorkPeriod workPeriod)
            : base(id,commitId,  version)
        {
        
            Contract.Requires(idPlan != Guid.Empty);
            Contract.Requires(idBachBouzouk != Guid.Empty);
            Contract.Requires(idTipoIntervento != Guid.Empty);
            Contract.Requires(workPeriod != null);

            IdPlan = idPlan;
            IdBachBouzouk = idBachBouzouk;
            IdTipoIntervento = idTipoIntervento;
            WorkPeriod = workPeriod;
        }

        public bool Equals(CalculateInterventoPriceOfPlan other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && other.IdPlan.Equals(IdPlan) && other.IdTipoIntervento.Equals(IdTipoIntervento) && Equals(other.WorkPeriod, WorkPeriod);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as CalculateInterventoPriceOfPlan);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = base.GetHashCode();
                result = (result*397) ^ IdPlan.GetHashCode();
                result = (result*397) ^ IdTipoIntervento.GetHashCode();
                result = (result*397) ^ (WorkPeriod != null ? WorkPeriod.GetHashCode() : 0);
                return result;
            }
        }
    }

    public class CalculateInterventoRotPriceOfPlan : CalculateInterventoPriceOfPlan
    {
       public CalculateInterventoRotPriceOfPlan()
        {

        }

       public CalculateInterventoRotPriceOfPlan(Guid id,
           Guid commitId,
           long version,
           Guid idPlan,
           Guid idBachBouzouk,
           Guid idTipoIntervento,
           WorkPeriod workPeriod,
           OggettoRot[] oggetti)
            : base(id, commitId, version,   idPlan, idBachBouzouk,  idTipoIntervento,  workPeriod)
        {
            Contract.Requires(oggetti != null);

            Oggetti = oggetti;
        }

        public OggettoRot[] Oggetti { get; set; }

        public override string ToDescription()
        {
            return string.Format("Calcolare il prezzo del intervento rotabile {0}", Id);
        }

        public bool Equals(CalculateInterventoRotPriceOfPlan other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && Equals(other.Oggetti, Oggetti);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as CalculateInterventoRotPriceOfPlan);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (base.GetHashCode()*397) ^ (Oggetti != null ? Oggetti.GetHashCode() : 0);
            }
        }
    }

    public class CalculateInterventoRotManPriceOfPlan : CalculateInterventoPriceOfPlan
    {
        public CalculateInterventoRotManPriceOfPlan()
        {

        }

        public CalculateInterventoRotManPriceOfPlan(Guid id,
            Guid commitId,
            long version,
            Guid idPlan,
            Guid idBachBouzouk,
            Guid idTipoIntervento,
            WorkPeriod workPeriod, 
            OggettoRotMan[] oggetti)
            : base(id, commitId, version,   idPlan,idBachBouzouk,   idTipoIntervento,  workPeriod)
        {
            Contract.Requires(oggetti != null);

            Oggetti = oggetti;
        }

        public OggettoRotMan[] Oggetti { get; set; }

        public override string ToDescription()
        {
            return string.Format("Calcolare il prezzo del intervento rotabile in manutenzione {0}", Id);
        }


        public bool Equals(CalculateInterventoRotManPriceOfPlan other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && Equals(other.Oggetti, Oggetti);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as CalculateInterventoRotManPriceOfPlan);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (base.GetHashCode()*397) ^ (Oggetti != null ? Oggetti.GetHashCode() : 0);
            }
        }
    }

    public class CalculateInterventoAmbPriceOfPlan : CalculateInterventoPriceOfPlan
    {
        public CalculateInterventoAmbPriceOfPlan()
        {

        }

        public CalculateInterventoAmbPriceOfPlan(Guid id,
            Guid commitId,
            long version,
            Guid idPlan,
            Guid idBachBouzouk,
            Guid idTipoIntervento,
            WorkPeriod workPeriod,
            int quantity)
            : base(id, commitId, version,   idPlan, idBachBouzouk,   idTipoIntervento,    workPeriod)
        {
            Quantity = quantity;
        }

        public int Quantity { get; set; }

        public override string ToDescription()
        {
            return string.Format("Calcolare il prezzo del intervento ambiente {0}", Id);
        }

        public bool Equals(CalculateInterventoAmbPriceOfPlan other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && other.Quantity == Quantity;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as CalculateInterventoAmbPriceOfPlan);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (base.GetHashCode()*397) ^ Quantity;
            }
        }
    }
}
