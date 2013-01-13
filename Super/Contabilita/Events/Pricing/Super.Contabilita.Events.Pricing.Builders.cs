


using System;
using CommonDomain;
using System.Diagnostics.Contracts;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using Super.Contabilita.Events.Pricing;
using Super.Contabilita.Events.Pricing.Builders;

namespace Super.Contabilita.Events.Pricing.Builders
{


	public class PricingCreatedBuilder : IEventBuilder<PricingCreated>
	{
	
		public PricingCreated Build(Guid id, long version)
		{
			return Build(id, Guid.NewGuid(), version);
		}

		public PricingCreated Build(Guid id, Guid commitId, long version)
        {
            return new PricingCreated(id, commitId, version);
		 }

       
	
	}

	public class BasePriceRotCreatedBuilder : IEventBuilder<BasePriceRotCreated>
	{
	 
		private Guid  _idBasePrice ; 
		private IntervalOpened  _interval ; 
		private Guid  _idTipoIntervento ; 
		private Guid  _idGruppoOggettoIntervento ; 
		private decimal  _value ;
		public BasePriceRotCreatedBuilder ForBasePrice(Guid idBasePrice) 
		{
			_idBasePrice = idBasePrice;
			return this;
		}
	
		public BasePriceRotCreatedBuilder ForInterval(IntervalOpened interval) 
		{
			_interval = interval;
			return this;
		}
	
		public BasePriceRotCreatedBuilder OfTipoIntervento(Guid idTipoIntervento) 
		{
			_idTipoIntervento = idTipoIntervento;
			return this;
		}
	
		public BasePriceRotCreatedBuilder ForGruppoOggettoIntervento(Guid idGruppoOggettoIntervento) 
		{
			_idGruppoOggettoIntervento = idGruppoOggettoIntervento;
			return this;
		}
	
		public BasePriceRotCreatedBuilder ForValue(decimal value) 
		{
			_value = value;
			return this;
		}
	
		public BasePriceRotCreated Build(Guid id, long version)
		{
			return Build(id, Guid.NewGuid(), version);
		}

		public BasePriceRotCreated Build(Guid id, Guid commitId, long version)
        {
            return new BasePriceRotCreated(id, commitId, version, _idBasePrice, _interval, _idTipoIntervento, _idGruppoOggettoIntervento, _value);
		 }

       
	
	}

	public class BasePriceRotManCreatedBuilder : IEventBuilder<BasePriceRotManCreated>
	{
	 
		private Guid  _idBasePrice ; 
		private IntervalOpened  _interval ; 
		private Guid  _idTipoIntervento ; 
		private Guid  _idGruppoOggettoIntervento ; 
		private decimal  _value ;
		public BasePriceRotManCreatedBuilder ForBasePrice(Guid idBasePrice) 
		{
			_idBasePrice = idBasePrice;
			return this;
		}
	
		public BasePriceRotManCreatedBuilder ForInterval(IntervalOpened interval) 
		{
			_interval = interval;
			return this;
		}
	
		public BasePriceRotManCreatedBuilder OfTipoIntervento(Guid idTipoIntervento) 
		{
			_idTipoIntervento = idTipoIntervento;
			return this;
		}
	
		public BasePriceRotManCreatedBuilder ForGruppoOggettoIntervento(Guid idGruppoOggettoIntervento) 
		{
			_idGruppoOggettoIntervento = idGruppoOggettoIntervento;
			return this;
		}
	
		public BasePriceRotManCreatedBuilder ForValue(decimal value) 
		{
			_value = value;
			return this;
		}
	
		public BasePriceRotManCreated Build(Guid id, long version)
		{
			return Build(id, Guid.NewGuid(), version);
		}

		public BasePriceRotManCreated Build(Guid id, Guid commitId, long version)
        {
            return new BasePriceRotManCreated(id, commitId, version, _idBasePrice, _interval, _idTipoIntervento, _idGruppoOggettoIntervento, _value);
		 }

       
	
	}

	public class BasePriceAmbCreatedBuilder : IEventBuilder<BasePriceAmbCreated>
	{
	 
		private Guid  _idBasePrice ; 
		private IntervalOpened  _interval ; 
		private Guid  _idTipoIntervento ; 
		private decimal  _value ;
		public BasePriceAmbCreatedBuilder ForBasePrice(Guid idBasePrice) 
		{
			_idBasePrice = idBasePrice;
			return this;
		}
	
		public BasePriceAmbCreatedBuilder ForInterval(IntervalOpened interval) 
		{
			_interval = interval;
			return this;
		}
	
		public BasePriceAmbCreatedBuilder OfTipoIntervento(Guid idTipoIntervento) 
		{
			_idTipoIntervento = idTipoIntervento;
			return this;
		}
	
		public BasePriceAmbCreatedBuilder ForValue(decimal value) 
		{
			_value = value;
			return this;
		}
	
		public BasePriceAmbCreated Build(Guid id, long version)
		{
			return Build(id, Guid.NewGuid(), version);
		}

		public BasePriceAmbCreated Build(Guid id, Guid commitId, long version)
        {
            return new BasePriceAmbCreated(id, commitId, version, _idBasePrice, _interval, _idTipoIntervento, _value);
		 }

       
	
	}

	public class BasePriceRotUpdatedBuilder : IEventBuilder<BasePriceRotUpdated>
	{
	 
		private Guid  _idBasePrice ; 
		private IntervalOpened  _interval ; 
		private Guid  _idTipoIntervento ; 
		private Guid  _idGruppoOggettoIntervento ; 
		private decimal  _value ;
		public BasePriceRotUpdatedBuilder ForBasePrice(Guid idBasePrice) 
		{
			_idBasePrice = idBasePrice;
			return this;
		}
	
		public BasePriceRotUpdatedBuilder ForInterval(IntervalOpened interval) 
		{
			_interval = interval;
			return this;
		}
	
		public BasePriceRotUpdatedBuilder OfTipoIntervento(Guid idTipoIntervento) 
		{
			_idTipoIntervento = idTipoIntervento;
			return this;
		}
	
		public BasePriceRotUpdatedBuilder ForGruppoOggettoIntervento(Guid idGruppoOggettoIntervento) 
		{
			_idGruppoOggettoIntervento = idGruppoOggettoIntervento;
			return this;
		}
	
		public BasePriceRotUpdatedBuilder ForValue(decimal value) 
		{
			_value = value;
			return this;
		}
	
		public BasePriceRotUpdated Build(Guid id, long version)
		{
			return Build(id, Guid.NewGuid(), version);
		}

		public BasePriceRotUpdated Build(Guid id, Guid commitId, long version)
        {
            return new BasePriceRotUpdated(id, commitId, version, _idBasePrice, _interval, _idTipoIntervento, _idGruppoOggettoIntervento, _value);
		 }

       
	
	}

	public class BasePriceRotManUpdatedBuilder : IEventBuilder<BasePriceRotManUpdated>
	{
	 
		private Guid  _idBasePrice ; 
		private IntervalOpened  _interval ; 
		private Guid  _idTipoIntervento ; 
		private Guid  _idGruppoOggettoIntervento ; 
		private decimal  _value ;
		public BasePriceRotManUpdatedBuilder ForBasePrice(Guid idBasePrice) 
		{
			_idBasePrice = idBasePrice;
			return this;
		}
	
		public BasePriceRotManUpdatedBuilder ForInterval(IntervalOpened interval) 
		{
			_interval = interval;
			return this;
		}
	
		public BasePriceRotManUpdatedBuilder OfTipoIntervento(Guid idTipoIntervento) 
		{
			_idTipoIntervento = idTipoIntervento;
			return this;
		}
	
		public BasePriceRotManUpdatedBuilder ForGruppoOggettoIntervento(Guid idGruppoOggettoIntervento) 
		{
			_idGruppoOggettoIntervento = idGruppoOggettoIntervento;
			return this;
		}
	
		public BasePriceRotManUpdatedBuilder ForValue(decimal value) 
		{
			_value = value;
			return this;
		}
	
		public BasePriceRotManUpdated Build(Guid id, long version)
		{
			return Build(id, Guid.NewGuid(), version);
		}

		public BasePriceRotManUpdated Build(Guid id, Guid commitId, long version)
        {
            return new BasePriceRotManUpdated(id, commitId, version, _idBasePrice, _interval, _idTipoIntervento, _idGruppoOggettoIntervento, _value);
		 }

       
	
	}

	public class BasePriceAmbUpdatedBuilder : IEventBuilder<BasePriceAmbUpdated>
	{
	 
		private Guid  _idBasePrice ; 
		private IntervalOpened  _interval ; 
		private Guid  _idTipoIntervento ; 
		private decimal  _value ;
		public BasePriceAmbUpdatedBuilder ForBasePrice(Guid idBasePrice) 
		{
			_idBasePrice = idBasePrice;
			return this;
		}
	
		public BasePriceAmbUpdatedBuilder ForInterval(IntervalOpened interval) 
		{
			_interval = interval;
			return this;
		}
	
		public BasePriceAmbUpdatedBuilder OfTipoIntervento(Guid idTipoIntervento) 
		{
			_idTipoIntervento = idTipoIntervento;
			return this;
		}
	
		public BasePriceAmbUpdatedBuilder ForValue(decimal value) 
		{
			_value = value;
			return this;
		}
	
		public BasePriceAmbUpdated Build(Guid id, long version)
		{
			return Build(id, Guid.NewGuid(), version);
		}

		public BasePriceAmbUpdated Build(Guid id, Guid commitId, long version)
        {
            return new BasePriceAmbUpdated(id, commitId, version, _idBasePrice, _interval, _idTipoIntervento, _value);
		 }

       
	
	}

	public class BasePriceDeletedBuilder : IEventBuilder<BasePriceDeleted>
	{
	 
		private Guid  _idBasePrice ;
		public BasePriceDeletedBuilder ForBasePrice(Guid idBasePrice) 
		{
			_idBasePrice = idBasePrice;
			return this;
		}
	
		public BasePriceDeleted Build(Guid id, long version)
		{
			return Build(id, Guid.NewGuid(), version);
		}

		public BasePriceDeleted Build(Guid id, Guid commitId, long version)
        {
            return new BasePriceDeleted(id, commitId, version, _idBasePrice);
		 }

       
	
	}
}

namespace Super.Contabilita.Events
{
	public static partial class BuildEvt 
	{
		  public static PricingCreatedBuilder PricingCreated {get { return new PricingCreatedBuilder(); } }
	  		  public static BasePriceRotCreatedBuilder BasePriceRotCreated {get { return new BasePriceRotCreatedBuilder(); } }
	  		  public static BasePriceRotManCreatedBuilder BasePriceRotManCreated {get { return new BasePriceRotManCreatedBuilder(); } }
	  		  public static BasePriceAmbCreatedBuilder BasePriceAmbCreated {get { return new BasePriceAmbCreatedBuilder(); } }
	  		  public static BasePriceRotUpdatedBuilder BasePriceRotUpdated {get { return new BasePriceRotUpdatedBuilder(); } }
	  		  public static BasePriceRotManUpdatedBuilder BasePriceRotManUpdated {get { return new BasePriceRotManUpdatedBuilder(); } }
	  		  public static BasePriceAmbUpdatedBuilder BasePriceAmbUpdated {get { return new BasePriceAmbUpdatedBuilder(); } }
	  		  public static BasePriceDeletedBuilder BasePriceDeleted {get { return new BasePriceDeletedBuilder(); } }
	  	}
}
