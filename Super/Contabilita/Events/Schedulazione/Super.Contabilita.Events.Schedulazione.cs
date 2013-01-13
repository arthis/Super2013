


using System;
using System.Linq;
using System.Diagnostics.Contracts;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using CommonDomain;
using CommonDomain.Core;


namespace Super.Contabilita.Events.Schedulazione
{


	public class SchedulazionePriceOfScenarioCalculated : EventBase  
	{
	 
		public decimal Price { get; set;} 
		public Guid IdScenario { get; set;}

		public SchedulazionePriceOfScenarioCalculated ()
		{
			//for serialisation
		}	     

		public SchedulazionePriceOfScenarioCalculated(Guid id, Guid commitId, long version,decimal price,Guid idScenario)
		   : base(id,commitId,version)
		{
			Contract.Requires(price != null);

	Contract.Requires(idScenario != Guid.Empty);

			Price = price ;
			IdScenario = idScenario ;
		}

		
			public override string ToDescription()
		{
			return string.Format("il prezzo della schedulazione é stato  calcolato", Id);
		}
		
		public bool Equals(SchedulazionePriceOfScenarioCalculated other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other)  	 && Equals(other.Price, Price)  	 && Equals(other.IdScenario, IdScenario) ; 
		}

		public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as SchedulazionePriceOfScenarioCalculated);
        }

		public override int GetHashCode()
        {
            unchecked
            {
				int result = base.GetHashCode();
				result = (result*397) ^ (Price != null ? Price.GetHashCode() : 0);
				result = (result*397) ^ (IdScenario != null ? IdScenario.GetHashCode() : 0);
				return result;
            }
        }
	}

	public class SchedulazioneRotCreated : EventBase  
	{
	 
		public Guid IdTipoIntervento { get; set;} 
		public Guid IdScenario { get; set;} 
		public OggettoRot[] Oggetti { get; set;} 
		public Period Period { get; set;} 
		public WorkPeriod WorkPeriod { get; set;}

		public SchedulazioneRotCreated ()
		{
			//for serialisation
		}	     

		public SchedulazioneRotCreated(Guid id, Guid commitId, long version,Guid idTipoIntervento,Guid idScenario,OggettoRot[] oggetti,Period period,WorkPeriod workPeriod)
		   : base(id,commitId,version)
		{
			Contract.Requires(idTipoIntervento != Guid.Empty);

	Contract.Requires(idScenario != Guid.Empty);

	Contract.Requires(oggetti != null);

	Contract.Requires(period != null);

	Contract.Requires(workPeriod != null);

			IdTipoIntervento = idTipoIntervento ;
			IdScenario = idScenario ;
			Oggetti = oggetti ;
			Period = period ;
			WorkPeriod = workPeriod ;
		}

		
			public override string ToDescription()
		{
			return string.Format("La schedulazione rotabile é stata creata", Id);
		}
		
		public bool Equals(SchedulazioneRotCreated other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other)  	 && Equals(other.IdTipoIntervento, IdTipoIntervento)  	 && Equals(other.IdScenario, IdScenario)  	 && other.Oggetti.SequenceEqual(Oggetti)  	 && Equals(other.Period, Period)  	 && Equals(other.WorkPeriod, WorkPeriod) ; 
		}

		public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as SchedulazioneRotCreated);
        }

		public override int GetHashCode()
        {
            unchecked
            {
				int result = base.GetHashCode();
				result = (result*397) ^ (IdTipoIntervento != null ? IdTipoIntervento.GetHashCode() : 0);
				result = (result*397) ^ (IdScenario != null ? IdScenario.GetHashCode() : 0);
				result = (result*397) ^ (Oggetti != null ? Oggetti.GetHashCode() : 0);
				result = (result*397) ^ (Period != null ? Period.GetHashCode() : 0);
				result = (result*397) ^ (WorkPeriod != null ? WorkPeriod.GetHashCode() : 0);
				return result;
            }
        }
	}

	public class SchedulazioneRotManCreated : EventBase  
	{
	 
		public Guid IdTipoIntervento { get; set;} 
		public Guid IdScenario { get; set;} 
		public OggettoRotMan[] Oggetti { get; set;} 
		public Period Period { get; set;} 
		public WorkPeriod WorkPeriod { get; set;}

		public SchedulazioneRotManCreated ()
		{
			//for serialisation
		}	     

		public SchedulazioneRotManCreated(Guid id, Guid commitId, long version,Guid idTipoIntervento,Guid idScenario,OggettoRotMan[] oggetti,Period period,WorkPeriod workPeriod)
		   : base(id,commitId,version)
		{
			Contract.Requires(idTipoIntervento != Guid.Empty);

	Contract.Requires(idScenario != Guid.Empty);

	Contract.Requires(oggetti != null);

	Contract.Requires(period != null);

	Contract.Requires(workPeriod != null);

			IdTipoIntervento = idTipoIntervento ;
			IdScenario = idScenario ;
			Oggetti = oggetti ;
			Period = period ;
			WorkPeriod = workPeriod ;
		}

		
			public override string ToDescription()
		{
			return string.Format("La schedulazione rotabile in manutenzione é stata creata", Id);
		}
		
		public bool Equals(SchedulazioneRotManCreated other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other)  	 && Equals(other.IdTipoIntervento, IdTipoIntervento)  	 && Equals(other.IdScenario, IdScenario)  	 && other.Oggetti.SequenceEqual(Oggetti)  	 && Equals(other.Period, Period)  	 && Equals(other.WorkPeriod, WorkPeriod) ; 
		}

		public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as SchedulazioneRotManCreated);
        }

		public override int GetHashCode()
        {
            unchecked
            {
				int result = base.GetHashCode();
				result = (result*397) ^ (IdTipoIntervento != null ? IdTipoIntervento.GetHashCode() : 0);
				result = (result*397) ^ (IdScenario != null ? IdScenario.GetHashCode() : 0);
				result = (result*397) ^ (Oggetti != null ? Oggetti.GetHashCode() : 0);
				result = (result*397) ^ (Period != null ? Period.GetHashCode() : 0);
				result = (result*397) ^ (WorkPeriod != null ? WorkPeriod.GetHashCode() : 0);
				return result;
            }
        }
	}

	public class SchedulazioneAmbCreated : EventBase  
	{
	 
		public Guid IdTipoIntervento { get; set;} 
		public Guid IdScenario { get; set;} 
		public int Quantity { get; set;} 
		public Period Period { get; set;} 
		public WorkPeriod WorkPeriod { get; set;}

		public SchedulazioneAmbCreated ()
		{
			//for serialisation
		}	     

		public SchedulazioneAmbCreated(Guid id, Guid commitId, long version,Guid idTipoIntervento,Guid idScenario,int quantity,Period period,WorkPeriod workPeriod)
		   : base(id,commitId,version)
		{
			Contract.Requires(idTipoIntervento != Guid.Empty);

	Contract.Requires(idScenario != Guid.Empty);

	Contract.Requires(quantity != null);

	Contract.Requires(period != null);

	Contract.Requires(workPeriod != null);

			IdTipoIntervento = idTipoIntervento ;
			IdScenario = idScenario ;
			Quantity = quantity ;
			Period = period ;
			WorkPeriod = workPeriod ;
		}

		
			public override string ToDescription()
		{
			return string.Format("La schedulazione ambiente é stata creata", Id);
		}
		
		public bool Equals(SchedulazioneAmbCreated other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other)  	 && Equals(other.IdTipoIntervento, IdTipoIntervento)  	 && Equals(other.IdScenario, IdScenario)  	 && Equals(other.Quantity, Quantity)  	 && Equals(other.Period, Period)  	 && Equals(other.WorkPeriod, WorkPeriod) ; 
		}

		public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as SchedulazioneAmbCreated);
        }

		public override int GetHashCode()
        {
            unchecked
            {
				int result = base.GetHashCode();
				result = (result*397) ^ (IdTipoIntervento != null ? IdTipoIntervento.GetHashCode() : 0);
				result = (result*397) ^ (IdScenario != null ? IdScenario.GetHashCode() : 0);
				result = (result*397) ^ (Quantity != null ? Quantity.GetHashCode() : 0);
				result = (result*397) ^ (Period != null ? Period.GetHashCode() : 0);
				result = (result*397) ^ (WorkPeriod != null ? WorkPeriod.GetHashCode() : 0);
				return result;
            }
        }
	}
}
