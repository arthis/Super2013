

using System;
using System.Linq;
using System.Diagnostics.Contracts;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using CommonDomain;
using CommonDomain.Core;


namespace Super.Contabilita.Commands.Pricing
{


	public class CreateBasePriceRot :  CommandBase  
	{
	 
		public Guid IdBasePrice { get; set;} 
		public decimal Value { get; set;} 
		public IntervalOpened Interval { get; set;} 
		public Guid IdTipoIntervento { get; set;} 
		public Guid IdGruppoOggettoIntervento { get; set;}

		public CreateBasePriceRot ()
		{
			//for serialisation
		}


		public CreateBasePriceRot(Guid id, Guid commitId,Guid idBasePrice,decimal value,IntervalOpened interval,Guid idTipoIntervento,Guid idGruppoOggettoIntervento)
		   : base(id,commitId)
		{
			Contract.Requires(idBasePrice != Guid.Empty);

	Contract.Requires(value != null);

	Contract.Requires(interval != null);

	Contract.Requires(idTipoIntervento != Guid.Empty);

	Contract.Requires(idGruppoOggettoIntervento != Guid.Empty);

			IdBasePrice = idBasePrice ;
			Value = value ;
			Interval = interval ;
			IdTipoIntervento = idTipoIntervento ;
			IdGruppoOggettoIntervento = idGruppoOggettoIntervento ;
		}
	     

		public CreateBasePriceRot(Guid id, Guid commitId, long version,Guid idBasePrice,decimal value,IntervalOpened interval,Guid idTipoIntervento,Guid idGruppoOggettoIntervento)
		   : base(id,commitId,version)
		{
			Contract.Requires(idBasePrice != Guid.Empty);

	Contract.Requires(value != null);

	Contract.Requires(interval != null);

	Contract.Requires(idTipoIntervento != Guid.Empty);

	Contract.Requires(idGruppoOggettoIntervento != Guid.Empty);

			IdBasePrice = idBasePrice ;
			Value = value ;
			Interval = interval ;
			IdTipoIntervento = idTipoIntervento ;
			IdGruppoOggettoIntervento = idGruppoOggettoIntervento ;
		}

		
		public CreateBasePriceRot(Guid id, Guid commitId, DateTime wakeupTime,Guid idBasePrice,decimal value,IntervalOpened interval,Guid idTipoIntervento,Guid idGruppoOggettoIntervento)
		   : base(id,commitId,wakeupTime)
		{
			Contract.Requires(idBasePrice != Guid.Empty);

	Contract.Requires(value != null);

	Contract.Requires(interval != null);

	Contract.Requires(idTipoIntervento != Guid.Empty);

	Contract.Requires(idGruppoOggettoIntervento != Guid.Empty);

			IdBasePrice = idBasePrice ;
			Value = value ;
			Interval = interval ;
			IdTipoIntervento = idTipoIntervento ;
			IdGruppoOggettoIntervento = idGruppoOggettoIntervento ;
		}

		public CreateBasePriceRot(Guid id, Guid commitId, Guid userId,Guid idBasePrice,decimal value,IntervalOpened interval,Guid idTipoIntervento,Guid idGruppoOggettoIntervento)
		   : base(id,commitId,userId)
		{
			Contract.Requires(idBasePrice != Guid.Empty);

	Contract.Requires(value != null);

	Contract.Requires(interval != null);

	Contract.Requires(idTipoIntervento != Guid.Empty);

	Contract.Requires(idGruppoOggettoIntervento != Guid.Empty);

			IdBasePrice = idBasePrice ;
			Value = value ;
			Interval = interval ;
			IdTipoIntervento = idTipoIntervento ;
			IdGruppoOggettoIntervento = idGruppoOggettoIntervento ;
		}


		public CreateBasePriceRot(Guid id, Guid commitId, long version, DateTime wakeupTime,Guid idBasePrice,decimal value,IntervalOpened interval,Guid idTipoIntervento,Guid idGruppoOggettoIntervento)
		   : base(id,commitId,version,wakeupTime)
		{
			Contract.Requires(idBasePrice != Guid.Empty);

	Contract.Requires(value != null);

	Contract.Requires(interval != null);

	Contract.Requires(idTipoIntervento != Guid.Empty);

	Contract.Requires(idGruppoOggettoIntervento != Guid.Empty);

			IdBasePrice = idBasePrice ;
			Value = value ;
			Interval = interval ;
			IdTipoIntervento = idTipoIntervento ;
			IdGruppoOggettoIntervento = idGruppoOggettoIntervento ;
		}

		
		public CreateBasePriceRot(Guid id, Guid commitId, long version, Guid userId,Guid idBasePrice,decimal value,IntervalOpened interval,Guid idTipoIntervento,Guid idGruppoOggettoIntervento)
		   : base(id,commitId,version,userId)
		{
			Contract.Requires(idBasePrice != Guid.Empty);

	Contract.Requires(value != null);

	Contract.Requires(interval != null);

	Contract.Requires(idTipoIntervento != Guid.Empty);

	Contract.Requires(idGruppoOggettoIntervento != Guid.Empty);

			IdBasePrice = idBasePrice ;
			Value = value ;
			Interval = interval ;
			IdTipoIntervento = idTipoIntervento ;
			IdGruppoOggettoIntervento = idGruppoOggettoIntervento ;
		}
			public override string ToDescription()
		{
			return string.Format("Creiamo un prezzo di base per rotabile", Id);
		}
		
		public bool Equals(CreateBasePriceRot other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other)  	 && Equals(other.IdBasePrice, IdBasePrice)  	 && Equals(other.Value, Value)  	 && Equals(other.Interval, Interval)  	 && Equals(other.IdTipoIntervento, IdTipoIntervento)  	 && Equals(other.IdGruppoOggettoIntervento, IdGruppoOggettoIntervento) ; 
		}

		public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as CreateBasePriceRot);
        }

		public override int GetHashCode()
        {
            unchecked
            {
				int result = base.GetHashCode();
				result = (result*397) ^ (IdBasePrice != null ? IdBasePrice.GetHashCode() : 0);
				result = (result*397) ^ (Value != null ? Value.GetHashCode() : 0);
				result = (result*397) ^ (Interval != null ? Interval.GetHashCode() : 0);
				result = (result*397) ^ (IdTipoIntervento != null ? IdTipoIntervento.GetHashCode() : 0);
				result = (result*397) ^ (IdGruppoOggettoIntervento != null ? IdGruppoOggettoIntervento.GetHashCode() : 0);
				return result;
            }
        }
	}

	public class CreateBasePriceRotMan :  CommandBase  
	{
	 
		public Guid IdBasePrice { get; set;} 
		public decimal Value { get; set;} 
		public IntervalOpened Interval { get; set;} 
		public Guid IdTipoIntervento { get; set;} 
		public Guid IdGruppoOggettoIntervento { get; set;}

		public CreateBasePriceRotMan ()
		{
			//for serialisation
		}


		public CreateBasePriceRotMan(Guid id, Guid commitId,Guid idBasePrice,decimal value,IntervalOpened interval,Guid idTipoIntervento,Guid idGruppoOggettoIntervento)
		   : base(id,commitId)
		{
			Contract.Requires(idBasePrice != Guid.Empty);

	Contract.Requires(value != null);

	Contract.Requires(interval != null);

	Contract.Requires(idTipoIntervento != Guid.Empty);

	Contract.Requires(idGruppoOggettoIntervento != Guid.Empty);

			IdBasePrice = idBasePrice ;
			Value = value ;
			Interval = interval ;
			IdTipoIntervento = idTipoIntervento ;
			IdGruppoOggettoIntervento = idGruppoOggettoIntervento ;
		}
	     

		public CreateBasePriceRotMan(Guid id, Guid commitId, long version,Guid idBasePrice,decimal value,IntervalOpened interval,Guid idTipoIntervento,Guid idGruppoOggettoIntervento)
		   : base(id,commitId,version)
		{
			Contract.Requires(idBasePrice != Guid.Empty);

	Contract.Requires(value != null);

	Contract.Requires(interval != null);

	Contract.Requires(idTipoIntervento != Guid.Empty);

	Contract.Requires(idGruppoOggettoIntervento != Guid.Empty);

			IdBasePrice = idBasePrice ;
			Value = value ;
			Interval = interval ;
			IdTipoIntervento = idTipoIntervento ;
			IdGruppoOggettoIntervento = idGruppoOggettoIntervento ;
		}

		
		public CreateBasePriceRotMan(Guid id, Guid commitId, DateTime wakeupTime,Guid idBasePrice,decimal value,IntervalOpened interval,Guid idTipoIntervento,Guid idGruppoOggettoIntervento)
		   : base(id,commitId,wakeupTime)
		{
			Contract.Requires(idBasePrice != Guid.Empty);

	Contract.Requires(value != null);

	Contract.Requires(interval != null);

	Contract.Requires(idTipoIntervento != Guid.Empty);

	Contract.Requires(idGruppoOggettoIntervento != Guid.Empty);

			IdBasePrice = idBasePrice ;
			Value = value ;
			Interval = interval ;
			IdTipoIntervento = idTipoIntervento ;
			IdGruppoOggettoIntervento = idGruppoOggettoIntervento ;
		}

		public CreateBasePriceRotMan(Guid id, Guid commitId, Guid userId,Guid idBasePrice,decimal value,IntervalOpened interval,Guid idTipoIntervento,Guid idGruppoOggettoIntervento)
		   : base(id,commitId,userId)
		{
			Contract.Requires(idBasePrice != Guid.Empty);

	Contract.Requires(value != null);

	Contract.Requires(interval != null);

	Contract.Requires(idTipoIntervento != Guid.Empty);

	Contract.Requires(idGruppoOggettoIntervento != Guid.Empty);

			IdBasePrice = idBasePrice ;
			Value = value ;
			Interval = interval ;
			IdTipoIntervento = idTipoIntervento ;
			IdGruppoOggettoIntervento = idGruppoOggettoIntervento ;
		}


		public CreateBasePriceRotMan(Guid id, Guid commitId, long version, DateTime wakeupTime,Guid idBasePrice,decimal value,IntervalOpened interval,Guid idTipoIntervento,Guid idGruppoOggettoIntervento)
		   : base(id,commitId,version,wakeupTime)
		{
			Contract.Requires(idBasePrice != Guid.Empty);

	Contract.Requires(value != null);

	Contract.Requires(interval != null);

	Contract.Requires(idTipoIntervento != Guid.Empty);

	Contract.Requires(idGruppoOggettoIntervento != Guid.Empty);

			IdBasePrice = idBasePrice ;
			Value = value ;
			Interval = interval ;
			IdTipoIntervento = idTipoIntervento ;
			IdGruppoOggettoIntervento = idGruppoOggettoIntervento ;
		}

		
		public CreateBasePriceRotMan(Guid id, Guid commitId, long version, Guid userId,Guid idBasePrice,decimal value,IntervalOpened interval,Guid idTipoIntervento,Guid idGruppoOggettoIntervento)
		   : base(id,commitId,version,userId)
		{
			Contract.Requires(idBasePrice != Guid.Empty);

	Contract.Requires(value != null);

	Contract.Requires(interval != null);

	Contract.Requires(idTipoIntervento != Guid.Empty);

	Contract.Requires(idGruppoOggettoIntervento != Guid.Empty);

			IdBasePrice = idBasePrice ;
			Value = value ;
			Interval = interval ;
			IdTipoIntervento = idTipoIntervento ;
			IdGruppoOggettoIntervento = idGruppoOggettoIntervento ;
		}
			public override string ToDescription()
		{
			return string.Format("Creiamo un prezzo di base per rotabile in manutenzione", Id);
		}
		
		public bool Equals(CreateBasePriceRotMan other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other)  	 && Equals(other.IdBasePrice, IdBasePrice)  	 && Equals(other.Value, Value)  	 && Equals(other.Interval, Interval)  	 && Equals(other.IdTipoIntervento, IdTipoIntervento)  	 && Equals(other.IdGruppoOggettoIntervento, IdGruppoOggettoIntervento) ; 
		}

		public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as CreateBasePriceRotMan);
        }

		public override int GetHashCode()
        {
            unchecked
            {
				int result = base.GetHashCode();
				result = (result*397) ^ (IdBasePrice != null ? IdBasePrice.GetHashCode() : 0);
				result = (result*397) ^ (Value != null ? Value.GetHashCode() : 0);
				result = (result*397) ^ (Interval != null ? Interval.GetHashCode() : 0);
				result = (result*397) ^ (IdTipoIntervento != null ? IdTipoIntervento.GetHashCode() : 0);
				result = (result*397) ^ (IdGruppoOggettoIntervento != null ? IdGruppoOggettoIntervento.GetHashCode() : 0);
				return result;
            }
        }
	}

	public class CreateBasePriceAmb :  CommandBase  
	{
	 
		public Guid IdBasePrice { get; set;} 
		public decimal Value { get; set;} 
		public IntervalOpened Interval { get; set;} 
		public Guid IdTipoIntervento { get; set;}

		public CreateBasePriceAmb ()
		{
			//for serialisation
		}


		public CreateBasePriceAmb(Guid id, Guid commitId,Guid idBasePrice,decimal value,IntervalOpened interval,Guid idTipoIntervento)
		   : base(id,commitId)
		{
			Contract.Requires(idBasePrice != Guid.Empty);

	Contract.Requires(value != null);

	Contract.Requires(interval != null);

	Contract.Requires(idTipoIntervento != Guid.Empty);

			IdBasePrice = idBasePrice ;
			Value = value ;
			Interval = interval ;
			IdTipoIntervento = idTipoIntervento ;
		}
	     

		public CreateBasePriceAmb(Guid id, Guid commitId, long version,Guid idBasePrice,decimal value,IntervalOpened interval,Guid idTipoIntervento)
		   : base(id,commitId,version)
		{
			Contract.Requires(idBasePrice != Guid.Empty);

	Contract.Requires(value != null);

	Contract.Requires(interval != null);

	Contract.Requires(idTipoIntervento != Guid.Empty);

			IdBasePrice = idBasePrice ;
			Value = value ;
			Interval = interval ;
			IdTipoIntervento = idTipoIntervento ;
		}

		
		public CreateBasePriceAmb(Guid id, Guid commitId, DateTime wakeupTime,Guid idBasePrice,decimal value,IntervalOpened interval,Guid idTipoIntervento)
		   : base(id,commitId,wakeupTime)
		{
			Contract.Requires(idBasePrice != Guid.Empty);

	Contract.Requires(value != null);

	Contract.Requires(interval != null);

	Contract.Requires(idTipoIntervento != Guid.Empty);

			IdBasePrice = idBasePrice ;
			Value = value ;
			Interval = interval ;
			IdTipoIntervento = idTipoIntervento ;
		}

		public CreateBasePriceAmb(Guid id, Guid commitId, Guid userId,Guid idBasePrice,decimal value,IntervalOpened interval,Guid idTipoIntervento)
		   : base(id,commitId,userId)
		{
			Contract.Requires(idBasePrice != Guid.Empty);

	Contract.Requires(value != null);

	Contract.Requires(interval != null);

	Contract.Requires(idTipoIntervento != Guid.Empty);

			IdBasePrice = idBasePrice ;
			Value = value ;
			Interval = interval ;
			IdTipoIntervento = idTipoIntervento ;
		}


		public CreateBasePriceAmb(Guid id, Guid commitId, long version, DateTime wakeupTime,Guid idBasePrice,decimal value,IntervalOpened interval,Guid idTipoIntervento)
		   : base(id,commitId,version,wakeupTime)
		{
			Contract.Requires(idBasePrice != Guid.Empty);

	Contract.Requires(value != null);

	Contract.Requires(interval != null);

	Contract.Requires(idTipoIntervento != Guid.Empty);

			IdBasePrice = idBasePrice ;
			Value = value ;
			Interval = interval ;
			IdTipoIntervento = idTipoIntervento ;
		}

		
		public CreateBasePriceAmb(Guid id, Guid commitId, long version, Guid userId,Guid idBasePrice,decimal value,IntervalOpened interval,Guid idTipoIntervento)
		   : base(id,commitId,version,userId)
		{
			Contract.Requires(idBasePrice != Guid.Empty);

	Contract.Requires(value != null);

	Contract.Requires(interval != null);

	Contract.Requires(idTipoIntervento != Guid.Empty);

			IdBasePrice = idBasePrice ;
			Value = value ;
			Interval = interval ;
			IdTipoIntervento = idTipoIntervento ;
		}
			public override string ToDescription()
		{
			return string.Format("Creiamo un prezzo di base per ambiente", Id);
		}
		
		public bool Equals(CreateBasePriceAmb other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other)  	 && Equals(other.IdBasePrice, IdBasePrice)  	 && Equals(other.Value, Value)  	 && Equals(other.Interval, Interval)  	 && Equals(other.IdTipoIntervento, IdTipoIntervento) ; 
		}

		public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as CreateBasePriceAmb);
        }

		public override int GetHashCode()
        {
            unchecked
            {
				int result = base.GetHashCode();
				result = (result*397) ^ (IdBasePrice != null ? IdBasePrice.GetHashCode() : 0);
				result = (result*397) ^ (Value != null ? Value.GetHashCode() : 0);
				result = (result*397) ^ (Interval != null ? Interval.GetHashCode() : 0);
				result = (result*397) ^ (IdTipoIntervento != null ? IdTipoIntervento.GetHashCode() : 0);
				return result;
            }
        }
	}

	public class UpdateBasePriceRot :  CommandBase  
	{
	 
		public Guid IdBasePrice { get; set;} 
		public decimal Value { get; set;} 
		public IntervalOpened Interval { get; set;} 
		public Guid IdTipoIntervento { get; set;} 
		public Guid IdGruppoOggettoIntervento { get; set;}

		public UpdateBasePriceRot ()
		{
			//for serialisation
		}


		public UpdateBasePriceRot(Guid id, Guid commitId,Guid idBasePrice,decimal value,IntervalOpened interval,Guid idTipoIntervento,Guid idGruppoOggettoIntervento)
		   : base(id,commitId)
		{
			Contract.Requires(idBasePrice != Guid.Empty);

	Contract.Requires(value != null);

	Contract.Requires(interval != null);

	Contract.Requires(idTipoIntervento != Guid.Empty);

	Contract.Requires(idGruppoOggettoIntervento != Guid.Empty);

			IdBasePrice = idBasePrice ;
			Value = value ;
			Interval = interval ;
			IdTipoIntervento = idTipoIntervento ;
			IdGruppoOggettoIntervento = idGruppoOggettoIntervento ;
		}
	     

		public UpdateBasePriceRot(Guid id, Guid commitId, long version,Guid idBasePrice,decimal value,IntervalOpened interval,Guid idTipoIntervento,Guid idGruppoOggettoIntervento)
		   : base(id,commitId,version)
		{
			Contract.Requires(idBasePrice != Guid.Empty);

	Contract.Requires(value != null);

	Contract.Requires(interval != null);

	Contract.Requires(idTipoIntervento != Guid.Empty);

	Contract.Requires(idGruppoOggettoIntervento != Guid.Empty);

			IdBasePrice = idBasePrice ;
			Value = value ;
			Interval = interval ;
			IdTipoIntervento = idTipoIntervento ;
			IdGruppoOggettoIntervento = idGruppoOggettoIntervento ;
		}

		
		public UpdateBasePriceRot(Guid id, Guid commitId, DateTime wakeupTime,Guid idBasePrice,decimal value,IntervalOpened interval,Guid idTipoIntervento,Guid idGruppoOggettoIntervento)
		   : base(id,commitId,wakeupTime)
		{
			Contract.Requires(idBasePrice != Guid.Empty);

	Contract.Requires(value != null);

	Contract.Requires(interval != null);

	Contract.Requires(idTipoIntervento != Guid.Empty);

	Contract.Requires(idGruppoOggettoIntervento != Guid.Empty);

			IdBasePrice = idBasePrice ;
			Value = value ;
			Interval = interval ;
			IdTipoIntervento = idTipoIntervento ;
			IdGruppoOggettoIntervento = idGruppoOggettoIntervento ;
		}

		public UpdateBasePriceRot(Guid id, Guid commitId, Guid userId,Guid idBasePrice,decimal value,IntervalOpened interval,Guid idTipoIntervento,Guid idGruppoOggettoIntervento)
		   : base(id,commitId,userId)
		{
			Contract.Requires(idBasePrice != Guid.Empty);

	Contract.Requires(value != null);

	Contract.Requires(interval != null);

	Contract.Requires(idTipoIntervento != Guid.Empty);

	Contract.Requires(idGruppoOggettoIntervento != Guid.Empty);

			IdBasePrice = idBasePrice ;
			Value = value ;
			Interval = interval ;
			IdTipoIntervento = idTipoIntervento ;
			IdGruppoOggettoIntervento = idGruppoOggettoIntervento ;
		}


		public UpdateBasePriceRot(Guid id, Guid commitId, long version, DateTime wakeupTime,Guid idBasePrice,decimal value,IntervalOpened interval,Guid idTipoIntervento,Guid idGruppoOggettoIntervento)
		   : base(id,commitId,version,wakeupTime)
		{
			Contract.Requires(idBasePrice != Guid.Empty);

	Contract.Requires(value != null);

	Contract.Requires(interval != null);

	Contract.Requires(idTipoIntervento != Guid.Empty);

	Contract.Requires(idGruppoOggettoIntervento != Guid.Empty);

			IdBasePrice = idBasePrice ;
			Value = value ;
			Interval = interval ;
			IdTipoIntervento = idTipoIntervento ;
			IdGruppoOggettoIntervento = idGruppoOggettoIntervento ;
		}

		
		public UpdateBasePriceRot(Guid id, Guid commitId, long version, Guid userId,Guid idBasePrice,decimal value,IntervalOpened interval,Guid idTipoIntervento,Guid idGruppoOggettoIntervento)
		   : base(id,commitId,version,userId)
		{
			Contract.Requires(idBasePrice != Guid.Empty);

	Contract.Requires(value != null);

	Contract.Requires(interval != null);

	Contract.Requires(idTipoIntervento != Guid.Empty);

	Contract.Requires(idGruppoOggettoIntervento != Guid.Empty);

			IdBasePrice = idBasePrice ;
			Value = value ;
			Interval = interval ;
			IdTipoIntervento = idTipoIntervento ;
			IdGruppoOggettoIntervento = idGruppoOggettoIntervento ;
		}
			public override string ToDescription()
		{
			return string.Format("Aggiornamo un prezzo di base per rotabile", Id);
		}
		
		public bool Equals(UpdateBasePriceRot other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other)  	 && Equals(other.IdBasePrice, IdBasePrice)  	 && Equals(other.Value, Value)  	 && Equals(other.Interval, Interval)  	 && Equals(other.IdTipoIntervento, IdTipoIntervento)  	 && Equals(other.IdGruppoOggettoIntervento, IdGruppoOggettoIntervento) ; 
		}

		public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as UpdateBasePriceRot);
        }

		public override int GetHashCode()
        {
            unchecked
            {
				int result = base.GetHashCode();
				result = (result*397) ^ (IdBasePrice != null ? IdBasePrice.GetHashCode() : 0);
				result = (result*397) ^ (Value != null ? Value.GetHashCode() : 0);
				result = (result*397) ^ (Interval != null ? Interval.GetHashCode() : 0);
				result = (result*397) ^ (IdTipoIntervento != null ? IdTipoIntervento.GetHashCode() : 0);
				result = (result*397) ^ (IdGruppoOggettoIntervento != null ? IdGruppoOggettoIntervento.GetHashCode() : 0);
				return result;
            }
        }
	}

	public class UpdateBasePriceRotMan :  CommandBase  
	{
	 
		public Guid IdBasePrice { get; set;} 
		public decimal Value { get; set;} 
		public IntervalOpened Interval { get; set;} 
		public Guid IdTipoIntervento { get; set;} 
		public Guid IdGruppoOggettoIntervento { get; set;}

		public UpdateBasePriceRotMan ()
		{
			//for serialisation
		}


		public UpdateBasePriceRotMan(Guid id, Guid commitId,Guid idBasePrice,decimal value,IntervalOpened interval,Guid idTipoIntervento,Guid idGruppoOggettoIntervento)
		   : base(id,commitId)
		{
			Contract.Requires(idBasePrice != Guid.Empty);

	Contract.Requires(value != null);

	Contract.Requires(interval != null);

	Contract.Requires(idTipoIntervento != Guid.Empty);

	Contract.Requires(idGruppoOggettoIntervento != Guid.Empty);

			IdBasePrice = idBasePrice ;
			Value = value ;
			Interval = interval ;
			IdTipoIntervento = idTipoIntervento ;
			IdGruppoOggettoIntervento = idGruppoOggettoIntervento ;
		}
	     

		public UpdateBasePriceRotMan(Guid id, Guid commitId, long version,Guid idBasePrice,decimal value,IntervalOpened interval,Guid idTipoIntervento,Guid idGruppoOggettoIntervento)
		   : base(id,commitId,version)
		{
			Contract.Requires(idBasePrice != Guid.Empty);

	Contract.Requires(value != null);

	Contract.Requires(interval != null);

	Contract.Requires(idTipoIntervento != Guid.Empty);

	Contract.Requires(idGruppoOggettoIntervento != Guid.Empty);

			IdBasePrice = idBasePrice ;
			Value = value ;
			Interval = interval ;
			IdTipoIntervento = idTipoIntervento ;
			IdGruppoOggettoIntervento = idGruppoOggettoIntervento ;
		}

		
		public UpdateBasePriceRotMan(Guid id, Guid commitId, DateTime wakeupTime,Guid idBasePrice,decimal value,IntervalOpened interval,Guid idTipoIntervento,Guid idGruppoOggettoIntervento)
		   : base(id,commitId,wakeupTime)
		{
			Contract.Requires(idBasePrice != Guid.Empty);

	Contract.Requires(value != null);

	Contract.Requires(interval != null);

	Contract.Requires(idTipoIntervento != Guid.Empty);

	Contract.Requires(idGruppoOggettoIntervento != Guid.Empty);

			IdBasePrice = idBasePrice ;
			Value = value ;
			Interval = interval ;
			IdTipoIntervento = idTipoIntervento ;
			IdGruppoOggettoIntervento = idGruppoOggettoIntervento ;
		}

		public UpdateBasePriceRotMan(Guid id, Guid commitId, Guid userId,Guid idBasePrice,decimal value,IntervalOpened interval,Guid idTipoIntervento,Guid idGruppoOggettoIntervento)
		   : base(id,commitId,userId)
		{
			Contract.Requires(idBasePrice != Guid.Empty);

	Contract.Requires(value != null);

	Contract.Requires(interval != null);

	Contract.Requires(idTipoIntervento != Guid.Empty);

	Contract.Requires(idGruppoOggettoIntervento != Guid.Empty);

			IdBasePrice = idBasePrice ;
			Value = value ;
			Interval = interval ;
			IdTipoIntervento = idTipoIntervento ;
			IdGruppoOggettoIntervento = idGruppoOggettoIntervento ;
		}


		public UpdateBasePriceRotMan(Guid id, Guid commitId, long version, DateTime wakeupTime,Guid idBasePrice,decimal value,IntervalOpened interval,Guid idTipoIntervento,Guid idGruppoOggettoIntervento)
		   : base(id,commitId,version,wakeupTime)
		{
			Contract.Requires(idBasePrice != Guid.Empty);

	Contract.Requires(value != null);

	Contract.Requires(interval != null);

	Contract.Requires(idTipoIntervento != Guid.Empty);

	Contract.Requires(idGruppoOggettoIntervento != Guid.Empty);

			IdBasePrice = idBasePrice ;
			Value = value ;
			Interval = interval ;
			IdTipoIntervento = idTipoIntervento ;
			IdGruppoOggettoIntervento = idGruppoOggettoIntervento ;
		}

		
		public UpdateBasePriceRotMan(Guid id, Guid commitId, long version, Guid userId,Guid idBasePrice,decimal value,IntervalOpened interval,Guid idTipoIntervento,Guid idGruppoOggettoIntervento)
		   : base(id,commitId,version,userId)
		{
			Contract.Requires(idBasePrice != Guid.Empty);

	Contract.Requires(value != null);

	Contract.Requires(interval != null);

	Contract.Requires(idTipoIntervento != Guid.Empty);

	Contract.Requires(idGruppoOggettoIntervento != Guid.Empty);

			IdBasePrice = idBasePrice ;
			Value = value ;
			Interval = interval ;
			IdTipoIntervento = idTipoIntervento ;
			IdGruppoOggettoIntervento = idGruppoOggettoIntervento ;
		}
			public override string ToDescription()
		{
			return string.Format("Aggiornamo il prezzo di base per rotabile in manutenzione", Id);
		}
		
		public bool Equals(UpdateBasePriceRotMan other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other)  	 && Equals(other.IdBasePrice, IdBasePrice)  	 && Equals(other.Value, Value)  	 && Equals(other.Interval, Interval)  	 && Equals(other.IdTipoIntervento, IdTipoIntervento)  	 && Equals(other.IdGruppoOggettoIntervento, IdGruppoOggettoIntervento) ; 
		}

		public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as UpdateBasePriceRotMan);
        }

		public override int GetHashCode()
        {
            unchecked
            {
				int result = base.GetHashCode();
				result = (result*397) ^ (IdBasePrice != null ? IdBasePrice.GetHashCode() : 0);
				result = (result*397) ^ (Value != null ? Value.GetHashCode() : 0);
				result = (result*397) ^ (Interval != null ? Interval.GetHashCode() : 0);
				result = (result*397) ^ (IdTipoIntervento != null ? IdTipoIntervento.GetHashCode() : 0);
				result = (result*397) ^ (IdGruppoOggettoIntervento != null ? IdGruppoOggettoIntervento.GetHashCode() : 0);
				return result;
            }
        }
	}

	public class UpdateBasePriceAmb :  CommandBase  
	{
	 
		public Guid IdBasePrice { get; set;} 
		public decimal Value { get; set;} 
		public IntervalOpened Interval { get; set;} 
		public Guid IdTipoIntervento { get; set;}

		public UpdateBasePriceAmb ()
		{
			//for serialisation
		}


		public UpdateBasePriceAmb(Guid id, Guid commitId,Guid idBasePrice,decimal value,IntervalOpened interval,Guid idTipoIntervento)
		   : base(id,commitId)
		{
			Contract.Requires(idBasePrice != Guid.Empty);

	Contract.Requires(value != null);

	Contract.Requires(interval != null);

	Contract.Requires(idTipoIntervento != Guid.Empty);

			IdBasePrice = idBasePrice ;
			Value = value ;
			Interval = interval ;
			IdTipoIntervento = idTipoIntervento ;
		}
	     

		public UpdateBasePriceAmb(Guid id, Guid commitId, long version,Guid idBasePrice,decimal value,IntervalOpened interval,Guid idTipoIntervento)
		   : base(id,commitId,version)
		{
			Contract.Requires(idBasePrice != Guid.Empty);

	Contract.Requires(value != null);

	Contract.Requires(interval != null);

	Contract.Requires(idTipoIntervento != Guid.Empty);

			IdBasePrice = idBasePrice ;
			Value = value ;
			Interval = interval ;
			IdTipoIntervento = idTipoIntervento ;
		}

		
		public UpdateBasePriceAmb(Guid id, Guid commitId, DateTime wakeupTime,Guid idBasePrice,decimal value,IntervalOpened interval,Guid idTipoIntervento)
		   : base(id,commitId,wakeupTime)
		{
			Contract.Requires(idBasePrice != Guid.Empty);

	Contract.Requires(value != null);

	Contract.Requires(interval != null);

	Contract.Requires(idTipoIntervento != Guid.Empty);

			IdBasePrice = idBasePrice ;
			Value = value ;
			Interval = interval ;
			IdTipoIntervento = idTipoIntervento ;
		}

		public UpdateBasePriceAmb(Guid id, Guid commitId, Guid userId,Guid idBasePrice,decimal value,IntervalOpened interval,Guid idTipoIntervento)
		   : base(id,commitId,userId)
		{
			Contract.Requires(idBasePrice != Guid.Empty);

	Contract.Requires(value != null);

	Contract.Requires(interval != null);

	Contract.Requires(idTipoIntervento != Guid.Empty);

			IdBasePrice = idBasePrice ;
			Value = value ;
			Interval = interval ;
			IdTipoIntervento = idTipoIntervento ;
		}


		public UpdateBasePriceAmb(Guid id, Guid commitId, long version, DateTime wakeupTime,Guid idBasePrice,decimal value,IntervalOpened interval,Guid idTipoIntervento)
		   : base(id,commitId,version,wakeupTime)
		{
			Contract.Requires(idBasePrice != Guid.Empty);

	Contract.Requires(value != null);

	Contract.Requires(interval != null);

	Contract.Requires(idTipoIntervento != Guid.Empty);

			IdBasePrice = idBasePrice ;
			Value = value ;
			Interval = interval ;
			IdTipoIntervento = idTipoIntervento ;
		}

		
		public UpdateBasePriceAmb(Guid id, Guid commitId, long version, Guid userId,Guid idBasePrice,decimal value,IntervalOpened interval,Guid idTipoIntervento)
		   : base(id,commitId,version,userId)
		{
			Contract.Requires(idBasePrice != Guid.Empty);

	Contract.Requires(value != null);

	Contract.Requires(interval != null);

	Contract.Requires(idTipoIntervento != Guid.Empty);

			IdBasePrice = idBasePrice ;
			Value = value ;
			Interval = interval ;
			IdTipoIntervento = idTipoIntervento ;
		}
			public override string ToDescription()
		{
			return string.Format("Aggiornamo il prezzo di base per ambiente", Id);
		}
		
		public bool Equals(UpdateBasePriceAmb other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other)  	 && Equals(other.IdBasePrice, IdBasePrice)  	 && Equals(other.Value, Value)  	 && Equals(other.Interval, Interval)  	 && Equals(other.IdTipoIntervento, IdTipoIntervento) ; 
		}

		public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as UpdateBasePriceAmb);
        }

		public override int GetHashCode()
        {
            unchecked
            {
				int result = base.GetHashCode();
				result = (result*397) ^ (IdBasePrice != null ? IdBasePrice.GetHashCode() : 0);
				result = (result*397) ^ (Value != null ? Value.GetHashCode() : 0);
				result = (result*397) ^ (Interval != null ? Interval.GetHashCode() : 0);
				result = (result*397) ^ (IdTipoIntervento != null ? IdTipoIntervento.GetHashCode() : 0);
				return result;
            }
        }
	}

	public class CreatePricingRot :  CommandBase  
	{
	

		public CreatePricingRot ()
		{
			//for serialisation
		}


		public CreatePricingRot(Guid id, Guid commitId)
		   : base(id,commitId)
		{
				}
	     

		public CreatePricingRot(Guid id, Guid commitId, long version)
		   : base(id,commitId,version)
		{
				}

		
		public CreatePricingRot(Guid id, Guid commitId, DateTime wakeupTime)
		   : base(id,commitId,wakeupTime)
		{
				}

		public CreatePricingRot(Guid id, Guid commitId, Guid userId)
		   : base(id,commitId,userId)
		{
				}


		public CreatePricingRot(Guid id, Guid commitId, long version, DateTime wakeupTime)
		   : base(id,commitId,version,wakeupTime)
		{
				}

		
		public CreatePricingRot(Guid id, Guid commitId, long version, Guid userId)
		   : base(id,commitId,version,userId)
		{
				}
			public override string ToDescription()
		{
			return string.Format("Creiamo il pricing per rotabile.", Id);
		}
		
		public bool Equals(CreatePricingRot other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) ; 
		}

		public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as CreatePricingRot);
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

	public class CreatePricingRotMan :  CommandBase  
	{
	

		public CreatePricingRotMan ()
		{
			//for serialisation
		}


		public CreatePricingRotMan(Guid id, Guid commitId)
		   : base(id,commitId)
		{
				}
	     

		public CreatePricingRotMan(Guid id, Guid commitId, long version)
		   : base(id,commitId,version)
		{
				}

		
		public CreatePricingRotMan(Guid id, Guid commitId, DateTime wakeupTime)
		   : base(id,commitId,wakeupTime)
		{
				}

		public CreatePricingRotMan(Guid id, Guid commitId, Guid userId)
		   : base(id,commitId,userId)
		{
				}


		public CreatePricingRotMan(Guid id, Guid commitId, long version, DateTime wakeupTime)
		   : base(id,commitId,version,wakeupTime)
		{
				}

		
		public CreatePricingRotMan(Guid id, Guid commitId, long version, Guid userId)
		   : base(id,commitId,version,userId)
		{
				}
			public override string ToDescription()
		{
			return string.Format("Creiamo il pricing per rotabile in manutenzione.", Id);
		}
		
		public bool Equals(CreatePricingRotMan other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) ; 
		}

		public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as CreatePricingRotMan);
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

	public class CreatePricingAmb :  CommandBase  
	{
	

		public CreatePricingAmb ()
		{
			//for serialisation
		}


		public CreatePricingAmb(Guid id, Guid commitId)
		   : base(id,commitId)
		{
				}
	     

		public CreatePricingAmb(Guid id, Guid commitId, long version)
		   : base(id,commitId,version)
		{
				}

		
		public CreatePricingAmb(Guid id, Guid commitId, DateTime wakeupTime)
		   : base(id,commitId,wakeupTime)
		{
				}

		public CreatePricingAmb(Guid id, Guid commitId, Guid userId)
		   : base(id,commitId,userId)
		{
				}


		public CreatePricingAmb(Guid id, Guid commitId, long version, DateTime wakeupTime)
		   : base(id,commitId,version,wakeupTime)
		{
				}

		
		public CreatePricingAmb(Guid id, Guid commitId, long version, Guid userId)
		   : base(id,commitId,version,userId)
		{
				}
			public override string ToDescription()
		{
			return string.Format("Creiamo il pricing per ambiente.", Id);
		}
		
		public bool Equals(CreatePricingAmb other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) ; 
		}

		public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as CreatePricingAmb);
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
}
