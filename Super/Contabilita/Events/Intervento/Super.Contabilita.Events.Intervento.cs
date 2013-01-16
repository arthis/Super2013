


using System;
using System.Linq;
using System.Diagnostics.Contracts;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using CommonDomain;
using CommonDomain.Core;


namespace Super.Contabilita.Events.Intervento
{


	public class InterventoPriceOfPlanCalculated : EventBase  
	{
	 
		public decimal Price { get; set;} 
		public Guid IdPlan { get; set;}

		public InterventoPriceOfPlanCalculated ()
		{
			//for serialisation
		}	     

		public InterventoPriceOfPlanCalculated(Guid id, Guid commitId, long version,decimal price,Guid idPlan)
		   : base(id,commitId,version)
		{
			
	Contract.Requires(idPlan != Guid.Empty);

			Price = price ;
			IdPlan = idPlan ;
		}

		
			public override string ToDescription()
		{
			return string.Format("il prezzo dell'intervento é stato  calcolato", Id);
		}
		
		public bool Equals(InterventoPriceOfPlanCalculated other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other)  	 && Equals(other.Price, Price)  	 && Equals(other.IdPlan, IdPlan) ; 
		}

		public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as InterventoPriceOfPlanCalculated);
        }

		public override int GetHashCode()
        {
            unchecked
            {
				int result = base.GetHashCode();
				result = (result*397) ^  Price.GetHashCode();
				result = (result*397) ^ (IdPlan != null ? IdPlan.GetHashCode() : 0);
				return result;
            }
        }
	}

	public class InterventoPriceOfPlanCancelled : EventBase  
	{
	 
		public Guid IdPlan { get; set;}

		public InterventoPriceOfPlanCancelled ()
		{
			//for serialisation
		}	     

		public InterventoPriceOfPlanCancelled(Guid id, Guid commitId, long version,Guid idPlan)
		   : base(id,commitId,version)
		{
			Contract.Requires(idPlan != Guid.Empty);

			IdPlan = idPlan ;
		}

		
			public override string ToDescription()
		{
			return string.Format("il prezzo dell'intervento é stato  cancellato", Id);
		}
		
		public bool Equals(InterventoPriceOfPlanCancelled other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other)  	 && Equals(other.IdPlan, IdPlan) ; 
		}

		public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as InterventoPriceOfPlanCancelled);
        }

		public override int GetHashCode()
        {
            unchecked
            {
				int result = base.GetHashCode();
				result = (result*397) ^ (IdPlan != null ? IdPlan.GetHashCode() : 0);
				return result;
            }
        }
	}

	public class InterventoRotCreated : EventBase  
	{
	 
		public Guid IdTipoIntervento { get; set;} 
		public Guid IdPlan { get; set;} 
		public OggettoRot[] Oggetti { get; set;} 
		public WorkPeriod WorkPeriod { get; set;}

		public InterventoRotCreated ()
		{
			//for serialisation
		}	     

		public InterventoRotCreated(Guid id, Guid commitId, long version,Guid idTipoIntervento,Guid idPlan,OggettoRot[] oggetti,WorkPeriod workPeriod)
		   : base(id,commitId,version)
		{
			Contract.Requires(idTipoIntervento != Guid.Empty);

	Contract.Requires(idPlan != Guid.Empty);

	Contract.Requires(oggetti != null);

	Contract.Requires(workPeriod != null);

			IdTipoIntervento = idTipoIntervento ;
			IdPlan = idPlan ;
			Oggetti = oggetti ;
			WorkPeriod = workPeriod ;
		}

		
			public override string ToDescription()
		{
			return string.Format("l'intervento rotabile {0} é stato creato", Id);
		}
		
		public bool Equals(InterventoRotCreated other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other)  	 && Equals(other.IdTipoIntervento, IdTipoIntervento)  	 && Equals(other.IdPlan, IdPlan)  	 && other.Oggetti.SequenceEqual(Oggetti)  	 && Equals(other.WorkPeriod, WorkPeriod) ; 
		}

		public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as InterventoRotCreated);
        }

		public override int GetHashCode()
        {
            unchecked
            {
				int result = base.GetHashCode();
				result = (result*397) ^ (IdTipoIntervento != null ? IdTipoIntervento.GetHashCode() : 0);
				result = (result*397) ^ (IdPlan != null ? IdPlan.GetHashCode() : 0);
				result = (result*397) ^ (Oggetti != null ? Oggetti.GetHashCode() : 0);
				result = (result*397) ^ (WorkPeriod != null ? WorkPeriod.GetHashCode() : 0);
				return result;
            }
        }
	}

	public class InterventoRotManCreato : EventBase  
	{
	 
		public Guid IdTipoIntervento { get; set;} 
		public Guid IdPlan { get; set;} 
		public OggettoRotMan[] Oggetti { get; set;} 
		public WorkPeriod WorkPeriod { get; set;}

		public InterventoRotManCreato ()
		{
			//for serialisation
		}	     

		public InterventoRotManCreato(Guid id, Guid commitId, long version,Guid idTipoIntervento,Guid idPlan,OggettoRotMan[] oggetti,WorkPeriod workPeriod)
		   : base(id,commitId,version)
		{
			Contract.Requires(idTipoIntervento != Guid.Empty);

	Contract.Requires(idPlan != Guid.Empty);

	Contract.Requires(oggetti != null);

	Contract.Requires(workPeriod != null);

			IdTipoIntervento = idTipoIntervento ;
			IdPlan = idPlan ;
			Oggetti = oggetti ;
			WorkPeriod = workPeriod ;
		}

		
			public override string ToDescription()
		{
			return string.Format("L'intervento rotabile in manutenzione é stata creata", Id);
		}
		
		public bool Equals(InterventoRotManCreato other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other)  	 && Equals(other.IdTipoIntervento, IdTipoIntervento)  	 && Equals(other.IdPlan, IdPlan)  	 && other.Oggetti.SequenceEqual(Oggetti)  	 && Equals(other.WorkPeriod, WorkPeriod) ; 
		}

		public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as InterventoRotManCreato);
        }

		public override int GetHashCode()
        {
            unchecked
            {
				int result = base.GetHashCode();
				result = (result*397) ^ (IdTipoIntervento != null ? IdTipoIntervento.GetHashCode() : 0);
				result = (result*397) ^ (IdPlan != null ? IdPlan.GetHashCode() : 0);
				result = (result*397) ^ (Oggetti != null ? Oggetti.GetHashCode() : 0);
				result = (result*397) ^ (WorkPeriod != null ? WorkPeriod.GetHashCode() : 0);
				return result;
            }
        }
	}

	public class InterventoAmbCreated : EventBase  
	{
	 
		public Guid IdTipoIntervento { get; set;} 
		public Guid IdPlan { get; set;} 
		public int Quantity { get; set;} 
		public WorkPeriod WorkPeriod { get; set;}

		public InterventoAmbCreated ()
		{
			//for serialisation
		}	     

		public InterventoAmbCreated(Guid id, Guid commitId, long version,Guid idTipoIntervento,Guid idPlan,int quantity,WorkPeriod workPeriod)
		   : base(id,commitId,version)
		{
			Contract.Requires(idTipoIntervento != Guid.Empty);

	Contract.Requires(idPlan != Guid.Empty);

	

	Contract.Requires(workPeriod != null);

			IdTipoIntervento = idTipoIntervento ;
			IdPlan = idPlan ;
			Quantity = quantity ;
			WorkPeriod = workPeriod ;
		}

		
			public override string ToDescription()
		{
			return string.Format("L'intervento ambiente é stato creato", Id);
		}
		
		public bool Equals(InterventoAmbCreated other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other)  	 && Equals(other.IdTipoIntervento, IdTipoIntervento)  	 && Equals(other.IdPlan, IdPlan)  	 && Equals(other.Quantity, Quantity)  	 && Equals(other.WorkPeriod, WorkPeriod) ; 
		}

		public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as InterventoAmbCreated);
        }

		public override int GetHashCode()
        {
            unchecked
            {
				int result = base.GetHashCode();
				result = (result*397) ^ IdTipoIntervento.GetHashCode();
				result = (result*397) ^  IdPlan.GetHashCode() ;
				result = (result*397) ^ Quantity.GetHashCode();
				result = (result*397) ^ (WorkPeriod != null ? WorkPeriod.GetHashCode() : 0);
				return result;
            }
        }
	}
}
