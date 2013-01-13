


using System;
using System.Linq;
using System.Diagnostics.Contracts;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using CommonDomain;
using CommonDomain.Core;


namespace Super.Contabilita.Events.Pricing
{


	public class PricingCreated : EventBase  
	{
	

		public PricingCreated ()
		{
			//for serialisation
		}	     

		public PricingCreated(Guid id, Guid commitId, long version)
		   : base(id,commitId,version)
		{
				}

		
			public override string ToDescription()
		{
			return string.Format("il prezzarrio é stato creato", Id);
		}
		
		public bool Equals(PricingCreated other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) ; 
		}

		public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as PricingCreated);
        }

		public override int GetHashCode()
        {
            unchecked
            {
				int result = base.GetHashCode();
				return result;
            }
        }
	}

	public class BasePriceRotCreated : EventBase  
	{
	 
		public Guid IdBasePrice { get; set;} 
		public IntervalOpened Interval { get; set;} 
		public Guid IdTipoIntervento { get; set;} 
		public Guid IdGruppoOggettoIntervento { get; set;} 
		public decimal Value { get; set;}

		public BasePriceRotCreated ()
		{
			//for serialisation
		}	     

		public BasePriceRotCreated(Guid id, Guid commitId, long version,Guid idBasePrice,IntervalOpened interval,Guid idTipoIntervento,Guid idGruppoOggettoIntervento,decimal value)
		   : base(id,commitId,version)
		{
			Contract.Requires(idBasePrice != Guid.Empty);

	Contract.Requires(interval != null);

	Contract.Requires(idTipoIntervento != Guid.Empty);

	Contract.Requires(idGruppoOggettoIntervento != Guid.Empty);

	Contract.Requires(value != null);

			IdBasePrice = idBasePrice ;
			Interval = interval ;
			IdTipoIntervento = idTipoIntervento ;
			IdGruppoOggettoIntervento = idGruppoOggettoIntervento ;
			Value = value ;
		}

		
			public override string ToDescription()
		{
			return string.Format("Il prezzo di base per rotabile é stato creato", Id);
		}
		
		public bool Equals(BasePriceRotCreated other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other)  	 && Equals(other.IdBasePrice, IdBasePrice)  	 && Equals(other.Interval, Interval)  	 && Equals(other.IdTipoIntervento, IdTipoIntervento)  	 && Equals(other.IdGruppoOggettoIntervento, IdGruppoOggettoIntervento)  	 && Equals(other.Value, Value) ; 
		}

		public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as BasePriceRotCreated);
        }

		public override int GetHashCode()
        {
            unchecked
            {
				int result = base.GetHashCode();
				result = (result*397) ^ (IdBasePrice != null ? IdBasePrice.GetHashCode() : 0);
				result = (result*397) ^ (Interval != null ? Interval.GetHashCode() : 0);
				result = (result*397) ^ (IdTipoIntervento != null ? IdTipoIntervento.GetHashCode() : 0);
				result = (result*397) ^ (IdGruppoOggettoIntervento != null ? IdGruppoOggettoIntervento.GetHashCode() : 0);
				result = (result*397) ^ (Value != null ? Value.GetHashCode() : 0);
				return result;
            }
        }
	}

	public class BasePriceRotManCreated : EventBase  
	{
	 
		public Guid IdBasePrice { get; set;} 
		public IntervalOpened Interval { get; set;} 
		public Guid IdTipoIntervento { get; set;} 
		public Guid IdGruppoOggettoIntervento { get; set;} 
		public decimal Value { get; set;}

		public BasePriceRotManCreated ()
		{
			//for serialisation
		}	     

		public BasePriceRotManCreated(Guid id, Guid commitId, long version,Guid idBasePrice,IntervalOpened interval,Guid idTipoIntervento,Guid idGruppoOggettoIntervento,decimal value)
		   : base(id,commitId,version)
		{
			Contract.Requires(idBasePrice != Guid.Empty);

	Contract.Requires(interval != null);

	Contract.Requires(idTipoIntervento != Guid.Empty);

	Contract.Requires(idGruppoOggettoIntervento != Guid.Empty);

	Contract.Requires(value != null);

			IdBasePrice = idBasePrice ;
			Interval = interval ;
			IdTipoIntervento = idTipoIntervento ;
			IdGruppoOggettoIntervento = idGruppoOggettoIntervento ;
			Value = value ;
		}

		
			public override string ToDescription()
		{
			return string.Format("Il prezzo di base per rotabile in manutenzione é stato creato", Id);
		}
		
		public bool Equals(BasePriceRotManCreated other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other)  	 && Equals(other.IdBasePrice, IdBasePrice)  	 && Equals(other.Interval, Interval)  	 && Equals(other.IdTipoIntervento, IdTipoIntervento)  	 && Equals(other.IdGruppoOggettoIntervento, IdGruppoOggettoIntervento)  	 && Equals(other.Value, Value) ; 
		}

		public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as BasePriceRotManCreated);
        }

		public override int GetHashCode()
        {
            unchecked
            {
				int result = base.GetHashCode();
				result = (result*397) ^ (IdBasePrice != null ? IdBasePrice.GetHashCode() : 0);
				result = (result*397) ^ (Interval != null ? Interval.GetHashCode() : 0);
				result = (result*397) ^ (IdTipoIntervento != null ? IdTipoIntervento.GetHashCode() : 0);
				result = (result*397) ^ (IdGruppoOggettoIntervento != null ? IdGruppoOggettoIntervento.GetHashCode() : 0);
				result = (result*397) ^ (Value != null ? Value.GetHashCode() : 0);
				return result;
            }
        }
	}

	public class BasePriceAmbCreated : EventBase  
	{
	 
		public Guid IdBasePrice { get; set;} 
		public IntervalOpened Interval { get; set;} 
		public Guid IdTipoIntervento { get; set;} 
		public decimal Value { get; set;}

		public BasePriceAmbCreated ()
		{
			//for serialisation
		}	     

		public BasePriceAmbCreated(Guid id, Guid commitId, long version,Guid idBasePrice,IntervalOpened interval,Guid idTipoIntervento,decimal value)
		   : base(id,commitId,version)
		{
			Contract.Requires(idBasePrice != Guid.Empty);

	Contract.Requires(interval != null);

	Contract.Requires(idTipoIntervento != Guid.Empty);

	Contract.Requires(value != null);

			IdBasePrice = idBasePrice ;
			Interval = interval ;
			IdTipoIntervento = idTipoIntervento ;
			Value = value ;
		}

		
			public override string ToDescription()
		{
			return string.Format("Il prezzo di base per ambiente é stato creato", Id);
		}
		
		public bool Equals(BasePriceAmbCreated other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other)  	 && Equals(other.IdBasePrice, IdBasePrice)  	 && Equals(other.Interval, Interval)  	 && Equals(other.IdTipoIntervento, IdTipoIntervento)  	 && Equals(other.Value, Value) ; 
		}

		public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as BasePriceAmbCreated);
        }

		public override int GetHashCode()
        {
            unchecked
            {
				int result = base.GetHashCode();
				result = (result*397) ^ (IdBasePrice != null ? IdBasePrice.GetHashCode() : 0);
				result = (result*397) ^ (Interval != null ? Interval.GetHashCode() : 0);
				result = (result*397) ^ (IdTipoIntervento != null ? IdTipoIntervento.GetHashCode() : 0);
				result = (result*397) ^ (Value != null ? Value.GetHashCode() : 0);
				return result;
            }
        }
	}

	public class BasePriceRotUpdated : EventBase  
	{
	 
		public Guid IdBasePrice { get; set;} 
		public IntervalOpened Interval { get; set;} 
		public Guid IdTipoIntervento { get; set;} 
		public Guid IdGruppoOggettoIntervento { get; set;} 
		public decimal Value { get; set;}

		public BasePriceRotUpdated ()
		{
			//for serialisation
		}	     

		public BasePriceRotUpdated(Guid id, Guid commitId, long version,Guid idBasePrice,IntervalOpened interval,Guid idTipoIntervento,Guid idGruppoOggettoIntervento,decimal value)
		   : base(id,commitId,version)
		{
			Contract.Requires(idBasePrice != Guid.Empty);

	Contract.Requires(interval != null);

	Contract.Requires(idTipoIntervento != Guid.Empty);

	Contract.Requires(idGruppoOggettoIntervento != Guid.Empty);

	Contract.Requires(value != null);

			IdBasePrice = idBasePrice ;
			Interval = interval ;
			IdTipoIntervento = idTipoIntervento ;
			IdGruppoOggettoIntervento = idGruppoOggettoIntervento ;
			Value = value ;
		}

		
			public override string ToDescription()
		{
			return string.Format("Il prezzo di base per rotabile é stato aggiornato", Id);
		}
		
		public bool Equals(BasePriceRotUpdated other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other)  	 && Equals(other.IdBasePrice, IdBasePrice)  	 && Equals(other.Interval, Interval)  	 && Equals(other.IdTipoIntervento, IdTipoIntervento)  	 && Equals(other.IdGruppoOggettoIntervento, IdGruppoOggettoIntervento)  	 && Equals(other.Value, Value) ; 
		}

		public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as BasePriceRotUpdated);
        }

		public override int GetHashCode()
        {
            unchecked
            {
				int result = base.GetHashCode();
				result = (result*397) ^ (IdBasePrice != null ? IdBasePrice.GetHashCode() : 0);
				result = (result*397) ^ (Interval != null ? Interval.GetHashCode() : 0);
				result = (result*397) ^ (IdTipoIntervento != null ? IdTipoIntervento.GetHashCode() : 0);
				result = (result*397) ^ (IdGruppoOggettoIntervento != null ? IdGruppoOggettoIntervento.GetHashCode() : 0);
				result = (result*397) ^ (Value != null ? Value.GetHashCode() : 0);
				return result;
            }
        }
	}

	public class BasePriceRotManUpdated : EventBase  
	{
	 
		public Guid IdBasePrice { get; set;} 
		public IntervalOpened Interval { get; set;} 
		public Guid IdTipoIntervento { get; set;} 
		public Guid IdGruppoOggettoIntervento { get; set;} 
		public decimal Value { get; set;}

		public BasePriceRotManUpdated ()
		{
			//for serialisation
		}	     

		public BasePriceRotManUpdated(Guid id, Guid commitId, long version,Guid idBasePrice,IntervalOpened interval,Guid idTipoIntervento,Guid idGruppoOggettoIntervento,decimal value)
		   : base(id,commitId,version)
		{
			Contract.Requires(idBasePrice != Guid.Empty);

	Contract.Requires(interval != null);

	Contract.Requires(idTipoIntervento != Guid.Empty);

	Contract.Requires(idGruppoOggettoIntervento != Guid.Empty);

	Contract.Requires(value != null);

			IdBasePrice = idBasePrice ;
			Interval = interval ;
			IdTipoIntervento = idTipoIntervento ;
			IdGruppoOggettoIntervento = idGruppoOggettoIntervento ;
			Value = value ;
		}

		
			public override string ToDescription()
		{
			return string.Format("Il prezzo di base per rotabile in manutenzione é stato aggiornato", Id);
		}
		
		public bool Equals(BasePriceRotManUpdated other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other)  	 && Equals(other.IdBasePrice, IdBasePrice)  	 && Equals(other.Interval, Interval)  	 && Equals(other.IdTipoIntervento, IdTipoIntervento)  	 && Equals(other.IdGruppoOggettoIntervento, IdGruppoOggettoIntervento)  	 && Equals(other.Value, Value) ; 
		}

		public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as BasePriceRotManUpdated);
        }

		public override int GetHashCode()
        {
            unchecked
            {
				int result = base.GetHashCode();
				result = (result*397) ^ (IdBasePrice != null ? IdBasePrice.GetHashCode() : 0);
				result = (result*397) ^ (Interval != null ? Interval.GetHashCode() : 0);
				result = (result*397) ^ (IdTipoIntervento != null ? IdTipoIntervento.GetHashCode() : 0);
				result = (result*397) ^ (IdGruppoOggettoIntervento != null ? IdGruppoOggettoIntervento.GetHashCode() : 0);
				result = (result*397) ^ (Value != null ? Value.GetHashCode() : 0);
				return result;
            }
        }
	}

	public class BasePriceAmbUpdated : EventBase  
	{
	 
		public Guid IdBasePrice { get; set;} 
		public IntervalOpened Interval { get; set;} 
		public Guid IdTipoIntervento { get; set;} 
		public decimal Value { get; set;}

		public BasePriceAmbUpdated ()
		{
			//for serialisation
		}	     

		public BasePriceAmbUpdated(Guid id, Guid commitId, long version,Guid idBasePrice,IntervalOpened interval,Guid idTipoIntervento,decimal value)
		   : base(id,commitId,version)
		{
			Contract.Requires(idBasePrice != Guid.Empty);

	Contract.Requires(interval != null);

	Contract.Requires(idTipoIntervento != Guid.Empty);

	Contract.Requires(value != null);

			IdBasePrice = idBasePrice ;
			Interval = interval ;
			IdTipoIntervento = idTipoIntervento ;
			Value = value ;
		}

		
			public override string ToDescription()
		{
			return string.Format("Il prezzo di base per ambiente é stato aggiornato", Id);
		}
		
		public bool Equals(BasePriceAmbUpdated other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other)  	 && Equals(other.IdBasePrice, IdBasePrice)  	 && Equals(other.Interval, Interval)  	 && Equals(other.IdTipoIntervento, IdTipoIntervento)  	 && Equals(other.Value, Value) ; 
		}

		public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as BasePriceAmbUpdated);
        }

		public override int GetHashCode()
        {
            unchecked
            {
				int result = base.GetHashCode();
				result = (result*397) ^ (IdBasePrice != null ? IdBasePrice.GetHashCode() : 0);
				result = (result*397) ^ (Interval != null ? Interval.GetHashCode() : 0);
				result = (result*397) ^ (IdTipoIntervento != null ? IdTipoIntervento.GetHashCode() : 0);
				result = (result*397) ^ (Value != null ? Value.GetHashCode() : 0);
				return result;
            }
        }
	}

	public class BasePriceDeleted : EventBase  
	{
	 
		public Guid IdBasePrice { get; set;}

		public BasePriceDeleted ()
		{
			//for serialisation
		}	     

		public BasePriceDeleted(Guid id, Guid commitId, long version,Guid idBasePrice)
		   : base(id,commitId,version)
		{
			Contract.Requires(idBasePrice != Guid.Empty);

			IdBasePrice = idBasePrice ;
		}

		
			public override string ToDescription()
		{
			return string.Format("Il prezzo di base  é stato cancellato", Id);
		}
		
		public bool Equals(BasePriceDeleted other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other)  	 && Equals(other.IdBasePrice, IdBasePrice) ; 
		}

		public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as BasePriceDeleted);
        }

		public override int GetHashCode()
        {
            unchecked
            {
				int result = base.GetHashCode();
				result = (result*397) ^ (IdBasePrice != null ? IdBasePrice.GetHashCode() : 0);
				return result;
            }
        }
	}
}
