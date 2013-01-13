


using System;
using CommonDomain;
using System.Diagnostics.Contracts;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using Super.Contabilita.Commands.Pricing;
using Super.Contabilita.Commands.Pricing.Builders;

namespace Super.Contabilita.Commands.Pricing.Builders
{


	public class CreateBasePriceRotBuilder : ICommandBuilder<CreateBasePriceRot>
	{
	 
		private Guid  _idBasePrice ; 
		private decimal  _value ; 
		private IntervalOpened  _interval ; 
		private Guid  _idTipoIntervento ; 
		private Guid  _idGruppoOggettoIntervento ;
		public CreateBasePriceRotBuilder ForBasePrice(Guid idBasePrice) 
		{
			_idBasePrice = idBasePrice;
			return this;
		}
	
		public CreateBasePriceRotBuilder ForValue(decimal value) 
		{
			_value = value;
			return this;
		}
	
		public CreateBasePriceRotBuilder ForInterval(IntervalOpened interval) 
		{
			_interval = interval;
			return this;
		}
	
		public CreateBasePriceRotBuilder OfTipoIntervento(Guid idTipoIntervento) 
		{
			_idTipoIntervento = idTipoIntervento;
			return this;
		}
	
		public CreateBasePriceRotBuilder ForGruppoOggettoIntervento(Guid idGruppoOggettoIntervento) 
		{
			_idGruppoOggettoIntervento = idGruppoOggettoIntervento;
			return this;
		}
	
		
		public CreateBasePriceRot Build(Guid id)
		{
			return Build(id, Guid.NewGuid());
		}

		public CreateBasePriceRot Build(Guid id, Guid commitId)
        {
            return new CreateBasePriceRot(id, commitId, _idBasePrice, _value, _interval, _idTipoIntervento, _idGruppoOggettoIntervento);
		 }


		
		public CreateBasePriceRot Build(Guid id, long version)
		{
			return Build(id, Guid.NewGuid(), version);
		}

		public CreateBasePriceRot Build(Guid id, Guid commitId, long version)
        {
            return new CreateBasePriceRot(id, commitId, version, _idBasePrice, _value, _interval, _idTipoIntervento, _idGruppoOggettoIntervento);
		}

		
		public CreateBasePriceRot Build(Guid id, Guid commitId, Guid userId)
        {
            return new CreateBasePriceRot(id, commitId, userId, _idBasePrice, _value, _interval, _idTipoIntervento, _idGruppoOggettoIntervento);
		 }

		 public CreateBasePriceRot Build(Guid id, long version, Guid userId)
		{
			return Build(id, Guid.NewGuid(), version, userId);
		}

		public CreateBasePriceRot Build(Guid id, Guid commitId, long version, Guid userId)
        {
            return new CreateBasePriceRot(id, commitId, version, userId, _idBasePrice, _value, _interval, _idTipoIntervento, _idGruppoOggettoIntervento);
		}

		public CreateBasePriceRot Build(Guid id, DateTime wakeupTime)
		{
			return Build(id, Guid.NewGuid(), wakeupTime);
		}

		public CreateBasePriceRot Build(Guid id, Guid commitId, DateTime wakeupTime)
        {
            return new CreateBasePriceRot(id, commitId, wakeupTime, _idBasePrice, _value, _interval, _idTipoIntervento, _idGruppoOggettoIntervento);
		 }

		public CreateBasePriceRot Build(Guid id, long version,DateTime wakeupTime)
		{
			return Build(id, Guid.NewGuid(), version,wakeupTime);
		}
		 

		public CreateBasePriceRot Build(Guid id, Guid commitId, long version, DateTime wakeupTime)
        {
            return new CreateBasePriceRot(id, commitId, version, wakeupTime, _idBasePrice, _value, _interval, _idTipoIntervento, _idGruppoOggettoIntervento);
		 }
        
	
	}

	public class CreateBasePriceRotManBuilder : ICommandBuilder<CreateBasePriceRotMan>
	{
	 
		private Guid  _idBasePrice ; 
		private decimal  _value ; 
		private IntervalOpened  _interval ; 
		private Guid  _idTipoIntervento ; 
		private Guid  _idGruppoOggettoIntervento ;
		public CreateBasePriceRotManBuilder ForBasePrice(Guid idBasePrice) 
		{
			_idBasePrice = idBasePrice;
			return this;
		}
	
		public CreateBasePriceRotManBuilder ForValue(decimal value) 
		{
			_value = value;
			return this;
		}
	
		public CreateBasePriceRotManBuilder ForInterval(IntervalOpened interval) 
		{
			_interval = interval;
			return this;
		}
	
		public CreateBasePriceRotManBuilder OfTipoIntervento(Guid idTipoIntervento) 
		{
			_idTipoIntervento = idTipoIntervento;
			return this;
		}
	
		public CreateBasePriceRotManBuilder ForGruppoOggettoIntervento(Guid idGruppoOggettoIntervento) 
		{
			_idGruppoOggettoIntervento = idGruppoOggettoIntervento;
			return this;
		}
	
		
		public CreateBasePriceRotMan Build(Guid id)
		{
			return Build(id, Guid.NewGuid());
		}

		public CreateBasePriceRotMan Build(Guid id, Guid commitId)
        {
            return new CreateBasePriceRotMan(id, commitId, _idBasePrice, _value, _interval, _idTipoIntervento, _idGruppoOggettoIntervento);
		 }


		
		public CreateBasePriceRotMan Build(Guid id, long version)
		{
			return Build(id, Guid.NewGuid(), version);
		}

		public CreateBasePriceRotMan Build(Guid id, Guid commitId, long version)
        {
            return new CreateBasePriceRotMan(id, commitId, version, _idBasePrice, _value, _interval, _idTipoIntervento, _idGruppoOggettoIntervento);
		}

		
		public CreateBasePriceRotMan Build(Guid id, Guid commitId, Guid userId)
        {
            return new CreateBasePriceRotMan(id, commitId, userId, _idBasePrice, _value, _interval, _idTipoIntervento, _idGruppoOggettoIntervento);
		 }

		 public CreateBasePriceRotMan Build(Guid id, long version, Guid userId)
		{
			return Build(id, Guid.NewGuid(), version, userId);
		}

		public CreateBasePriceRotMan Build(Guid id, Guid commitId, long version, Guid userId)
        {
            return new CreateBasePriceRotMan(id, commitId, version, userId, _idBasePrice, _value, _interval, _idTipoIntervento, _idGruppoOggettoIntervento);
		}

		public CreateBasePriceRotMan Build(Guid id, DateTime wakeupTime)
		{
			return Build(id, Guid.NewGuid(), wakeupTime);
		}

		public CreateBasePriceRotMan Build(Guid id, Guid commitId, DateTime wakeupTime)
        {
            return new CreateBasePriceRotMan(id, commitId, wakeupTime, _idBasePrice, _value, _interval, _idTipoIntervento, _idGruppoOggettoIntervento);
		 }

		public CreateBasePriceRotMan Build(Guid id, long version,DateTime wakeupTime)
		{
			return Build(id, Guid.NewGuid(), version,wakeupTime);
		}
		 

		public CreateBasePriceRotMan Build(Guid id, Guid commitId, long version, DateTime wakeupTime)
        {
            return new CreateBasePriceRotMan(id, commitId, version, wakeupTime, _idBasePrice, _value, _interval, _idTipoIntervento, _idGruppoOggettoIntervento);
		 }
        
	
	}

	public class CreateBasePriceAmbBuilder : ICommandBuilder<CreateBasePriceAmb>
	{
	 
		private Guid  _idBasePrice ; 
		private decimal  _value ; 
		private IntervalOpened  _interval ; 
		private Guid  _idTipoIntervento ;
		public CreateBasePriceAmbBuilder ForBasePrice(Guid idBasePrice) 
		{
			_idBasePrice = idBasePrice;
			return this;
		}
	
		public CreateBasePriceAmbBuilder ForValue(decimal value) 
		{
			_value = value;
			return this;
		}
	
		public CreateBasePriceAmbBuilder ForInterval(IntervalOpened interval) 
		{
			_interval = interval;
			return this;
		}
	
		public CreateBasePriceAmbBuilder OfTipoIntervento(Guid idTipoIntervento) 
		{
			_idTipoIntervento = idTipoIntervento;
			return this;
		}
	
		
		public CreateBasePriceAmb Build(Guid id)
		{
			return Build(id, Guid.NewGuid());
		}

		public CreateBasePriceAmb Build(Guid id, Guid commitId)
        {
            return new CreateBasePriceAmb(id, commitId, _idBasePrice, _value, _interval, _idTipoIntervento);
		 }


		
		public CreateBasePriceAmb Build(Guid id, long version)
		{
			return Build(id, Guid.NewGuid(), version);
		}

		public CreateBasePriceAmb Build(Guid id, Guid commitId, long version)
        {
            return new CreateBasePriceAmb(id, commitId, version, _idBasePrice, _value, _interval, _idTipoIntervento);
		}

		
		public CreateBasePriceAmb Build(Guid id, Guid commitId, Guid userId)
        {
            return new CreateBasePriceAmb(id, commitId, userId, _idBasePrice, _value, _interval, _idTipoIntervento);
		 }

		 public CreateBasePriceAmb Build(Guid id, long version, Guid userId)
		{
			return Build(id, Guid.NewGuid(), version, userId);
		}

		public CreateBasePriceAmb Build(Guid id, Guid commitId, long version, Guid userId)
        {
            return new CreateBasePriceAmb(id, commitId, version, userId, _idBasePrice, _value, _interval, _idTipoIntervento);
		}

		public CreateBasePriceAmb Build(Guid id, DateTime wakeupTime)
		{
			return Build(id, Guid.NewGuid(), wakeupTime);
		}

		public CreateBasePriceAmb Build(Guid id, Guid commitId, DateTime wakeupTime)
        {
            return new CreateBasePriceAmb(id, commitId, wakeupTime, _idBasePrice, _value, _interval, _idTipoIntervento);
		 }

		public CreateBasePriceAmb Build(Guid id, long version,DateTime wakeupTime)
		{
			return Build(id, Guid.NewGuid(), version,wakeupTime);
		}
		 

		public CreateBasePriceAmb Build(Guid id, Guid commitId, long version, DateTime wakeupTime)
        {
            return new CreateBasePriceAmb(id, commitId, version, wakeupTime, _idBasePrice, _value, _interval, _idTipoIntervento);
		 }
        
	
	}

	public class UpdateBasePriceRotBuilder : ICommandBuilder<UpdateBasePriceRot>
	{
	 
		private Guid  _idBasePrice ; 
		private decimal  _value ; 
		private IntervalOpened  _interval ; 
		private Guid  _idTipoIntervento ; 
		private Guid  _idGruppoOggettoIntervento ;
		public UpdateBasePriceRotBuilder ForBasePrice(Guid idBasePrice) 
		{
			_idBasePrice = idBasePrice;
			return this;
		}
	
		public UpdateBasePriceRotBuilder ForValue(decimal value) 
		{
			_value = value;
			return this;
		}
	
		public UpdateBasePriceRotBuilder ForInterval(IntervalOpened interval) 
		{
			_interval = interval;
			return this;
		}
	
		public UpdateBasePriceRotBuilder OfTipoIntervento(Guid idTipoIntervento) 
		{
			_idTipoIntervento = idTipoIntervento;
			return this;
		}
	
		public UpdateBasePriceRotBuilder ForGruppoOggettoIntervento(Guid idGruppoOggettoIntervento) 
		{
			_idGruppoOggettoIntervento = idGruppoOggettoIntervento;
			return this;
		}
	
		
		public UpdateBasePriceRot Build(Guid id)
		{
			return Build(id, Guid.NewGuid());
		}

		public UpdateBasePriceRot Build(Guid id, Guid commitId)
        {
            return new UpdateBasePriceRot(id, commitId, _idBasePrice, _value, _interval, _idTipoIntervento, _idGruppoOggettoIntervento);
		 }


		
		public UpdateBasePriceRot Build(Guid id, long version)
		{
			return Build(id, Guid.NewGuid(), version);
		}

		public UpdateBasePriceRot Build(Guid id, Guid commitId, long version)
        {
            return new UpdateBasePriceRot(id, commitId, version, _idBasePrice, _value, _interval, _idTipoIntervento, _idGruppoOggettoIntervento);
		}

		
		public UpdateBasePriceRot Build(Guid id, Guid commitId, Guid userId)
        {
            return new UpdateBasePriceRot(id, commitId, userId, _idBasePrice, _value, _interval, _idTipoIntervento, _idGruppoOggettoIntervento);
		 }

		 public UpdateBasePriceRot Build(Guid id, long version, Guid userId)
		{
			return Build(id, Guid.NewGuid(), version, userId);
		}

		public UpdateBasePriceRot Build(Guid id, Guid commitId, long version, Guid userId)
        {
            return new UpdateBasePriceRot(id, commitId, version, userId, _idBasePrice, _value, _interval, _idTipoIntervento, _idGruppoOggettoIntervento);
		}

		public UpdateBasePriceRot Build(Guid id, DateTime wakeupTime)
		{
			return Build(id, Guid.NewGuid(), wakeupTime);
		}

		public UpdateBasePriceRot Build(Guid id, Guid commitId, DateTime wakeupTime)
        {
            return new UpdateBasePriceRot(id, commitId, wakeupTime, _idBasePrice, _value, _interval, _idTipoIntervento, _idGruppoOggettoIntervento);
		 }

		public UpdateBasePriceRot Build(Guid id, long version,DateTime wakeupTime)
		{
			return Build(id, Guid.NewGuid(), version,wakeupTime);
		}
		 

		public UpdateBasePriceRot Build(Guid id, Guid commitId, long version, DateTime wakeupTime)
        {
            return new UpdateBasePriceRot(id, commitId, version, wakeupTime, _idBasePrice, _value, _interval, _idTipoIntervento, _idGruppoOggettoIntervento);
		 }
        
	
	}

	public class UpdateBasePriceRotManBuilder : ICommandBuilder<UpdateBasePriceRotMan>
	{
	 
		private Guid  _idBasePrice ; 
		private decimal  _value ; 
		private IntervalOpened  _interval ; 
		private Guid  _idTipoIntervento ; 
		private Guid  _idGruppoOggettoIntervento ;
		public UpdateBasePriceRotManBuilder ForBasePrice(Guid idBasePrice) 
		{
			_idBasePrice = idBasePrice;
			return this;
		}
	
		public UpdateBasePriceRotManBuilder ForValue(decimal value) 
		{
			_value = value;
			return this;
		}
	
		public UpdateBasePriceRotManBuilder ForInterval(IntervalOpened interval) 
		{
			_interval = interval;
			return this;
		}
	
		public UpdateBasePriceRotManBuilder OfTipoIntervento(Guid idTipoIntervento) 
		{
			_idTipoIntervento = idTipoIntervento;
			return this;
		}
	
		public UpdateBasePriceRotManBuilder ForGruppoOggettoIntervento(Guid idGruppoOggettoIntervento) 
		{
			_idGruppoOggettoIntervento = idGruppoOggettoIntervento;
			return this;
		}
	
		
		public UpdateBasePriceRotMan Build(Guid id)
		{
			return Build(id, Guid.NewGuid());
		}

		public UpdateBasePriceRotMan Build(Guid id, Guid commitId)
        {
            return new UpdateBasePriceRotMan(id, commitId, _idBasePrice, _value, _interval, _idTipoIntervento, _idGruppoOggettoIntervento);
		 }


		
		public UpdateBasePriceRotMan Build(Guid id, long version)
		{
			return Build(id, Guid.NewGuid(), version);
		}

		public UpdateBasePriceRotMan Build(Guid id, Guid commitId, long version)
        {
            return new UpdateBasePriceRotMan(id, commitId, version, _idBasePrice, _value, _interval, _idTipoIntervento, _idGruppoOggettoIntervento);
		}

		
		public UpdateBasePriceRotMan Build(Guid id, Guid commitId, Guid userId)
        {
            return new UpdateBasePriceRotMan(id, commitId, userId, _idBasePrice, _value, _interval, _idTipoIntervento, _idGruppoOggettoIntervento);
		 }

		 public UpdateBasePriceRotMan Build(Guid id, long version, Guid userId)
		{
			return Build(id, Guid.NewGuid(), version, userId);
		}

		public UpdateBasePriceRotMan Build(Guid id, Guid commitId, long version, Guid userId)
        {
            return new UpdateBasePriceRotMan(id, commitId, version, userId, _idBasePrice, _value, _interval, _idTipoIntervento, _idGruppoOggettoIntervento);
		}

		public UpdateBasePriceRotMan Build(Guid id, DateTime wakeupTime)
		{
			return Build(id, Guid.NewGuid(), wakeupTime);
		}

		public UpdateBasePriceRotMan Build(Guid id, Guid commitId, DateTime wakeupTime)
        {
            return new UpdateBasePriceRotMan(id, commitId, wakeupTime, _idBasePrice, _value, _interval, _idTipoIntervento, _idGruppoOggettoIntervento);
		 }

		public UpdateBasePriceRotMan Build(Guid id, long version,DateTime wakeupTime)
		{
			return Build(id, Guid.NewGuid(), version,wakeupTime);
		}
		 

		public UpdateBasePriceRotMan Build(Guid id, Guid commitId, long version, DateTime wakeupTime)
        {
            return new UpdateBasePriceRotMan(id, commitId, version, wakeupTime, _idBasePrice, _value, _interval, _idTipoIntervento, _idGruppoOggettoIntervento);
		 }
        
	
	}

	public class UpdateBasePriceAmbBuilder : ICommandBuilder<UpdateBasePriceAmb>
	{
	 
		private Guid  _idBasePrice ; 
		private decimal  _value ; 
		private IntervalOpened  _interval ; 
		private Guid  _idTipoIntervento ;
		public UpdateBasePriceAmbBuilder ForBasePrice(Guid idBasePrice) 
		{
			_idBasePrice = idBasePrice;
			return this;
		}
	
		public UpdateBasePriceAmbBuilder ForValue(decimal value) 
		{
			_value = value;
			return this;
		}
	
		public UpdateBasePriceAmbBuilder ForInterval(IntervalOpened interval) 
		{
			_interval = interval;
			return this;
		}
	
		public UpdateBasePriceAmbBuilder OfTipoIntervento(Guid idTipoIntervento) 
		{
			_idTipoIntervento = idTipoIntervento;
			return this;
		}
	
		
		public UpdateBasePriceAmb Build(Guid id)
		{
			return Build(id, Guid.NewGuid());
		}

		public UpdateBasePriceAmb Build(Guid id, Guid commitId)
        {
            return new UpdateBasePriceAmb(id, commitId, _idBasePrice, _value, _interval, _idTipoIntervento);
		 }


		
		public UpdateBasePriceAmb Build(Guid id, long version)
		{
			return Build(id, Guid.NewGuid(), version);
		}

		public UpdateBasePriceAmb Build(Guid id, Guid commitId, long version)
        {
            return new UpdateBasePriceAmb(id, commitId, version, _idBasePrice, _value, _interval, _idTipoIntervento);
		}

		
		public UpdateBasePriceAmb Build(Guid id, Guid commitId, Guid userId)
        {
            return new UpdateBasePriceAmb(id, commitId, userId, _idBasePrice, _value, _interval, _idTipoIntervento);
		 }

		 public UpdateBasePriceAmb Build(Guid id, long version, Guid userId)
		{
			return Build(id, Guid.NewGuid(), version, userId);
		}

		public UpdateBasePriceAmb Build(Guid id, Guid commitId, long version, Guid userId)
        {
            return new UpdateBasePriceAmb(id, commitId, version, userId, _idBasePrice, _value, _interval, _idTipoIntervento);
		}

		public UpdateBasePriceAmb Build(Guid id, DateTime wakeupTime)
		{
			return Build(id, Guid.NewGuid(), wakeupTime);
		}

		public UpdateBasePriceAmb Build(Guid id, Guid commitId, DateTime wakeupTime)
        {
            return new UpdateBasePriceAmb(id, commitId, wakeupTime, _idBasePrice, _value, _interval, _idTipoIntervento);
		 }

		public UpdateBasePriceAmb Build(Guid id, long version,DateTime wakeupTime)
		{
			return Build(id, Guid.NewGuid(), version,wakeupTime);
		}
		 

		public UpdateBasePriceAmb Build(Guid id, Guid commitId, long version, DateTime wakeupTime)
        {
            return new UpdateBasePriceAmb(id, commitId, version, wakeupTime, _idBasePrice, _value, _interval, _idTipoIntervento);
		 }
        
	
	}

	public class CreatePricingRotBuilder : ICommandBuilder<CreatePricingRot>
	{
	
		
		public CreatePricingRot Build(Guid id)
		{
			return Build(id, Guid.NewGuid());
		}

		public CreatePricingRot Build(Guid id, Guid commitId)
        {
            return new CreatePricingRot(id, commitId);
		 }


		
		public CreatePricingRot Build(Guid id, long version)
		{
			return Build(id, Guid.NewGuid(), version);
		}

		public CreatePricingRot Build(Guid id, Guid commitId, long version)
        {
            return new CreatePricingRot(id, commitId, version);
		}

		
		public CreatePricingRot Build(Guid id, Guid commitId, Guid userId)
        {
            return new CreatePricingRot(id, commitId, userId);
		 }

		 public CreatePricingRot Build(Guid id, long version, Guid userId)
		{
			return Build(id, Guid.NewGuid(), version, userId);
		}

		public CreatePricingRot Build(Guid id, Guid commitId, long version, Guid userId)
        {
            return new CreatePricingRot(id, commitId, version, userId);
		}

		public CreatePricingRot Build(Guid id, DateTime wakeupTime)
		{
			return Build(id, Guid.NewGuid(), wakeupTime);
		}

		public CreatePricingRot Build(Guid id, Guid commitId, DateTime wakeupTime)
        {
            return new CreatePricingRot(id, commitId, wakeupTime);
		 }

		public CreatePricingRot Build(Guid id, long version,DateTime wakeupTime)
		{
			return Build(id, Guid.NewGuid(), version,wakeupTime);
		}
		 

		public CreatePricingRot Build(Guid id, Guid commitId, long version, DateTime wakeupTime)
        {
            return new CreatePricingRot(id, commitId, version, wakeupTime);
		 }
        
	
	}

	public class CreatePricingRotManBuilder : ICommandBuilder<CreatePricingRotMan>
	{
	
		
		public CreatePricingRotMan Build(Guid id)
		{
			return Build(id, Guid.NewGuid());
		}

		public CreatePricingRotMan Build(Guid id, Guid commitId)
        {
            return new CreatePricingRotMan(id, commitId);
		 }


		
		public CreatePricingRotMan Build(Guid id, long version)
		{
			return Build(id, Guid.NewGuid(), version);
		}

		public CreatePricingRotMan Build(Guid id, Guid commitId, long version)
        {
            return new CreatePricingRotMan(id, commitId, version);
		}

		
		public CreatePricingRotMan Build(Guid id, Guid commitId, Guid userId)
        {
            return new CreatePricingRotMan(id, commitId, userId);
		 }

		 public CreatePricingRotMan Build(Guid id, long version, Guid userId)
		{
			return Build(id, Guid.NewGuid(), version, userId);
		}

		public CreatePricingRotMan Build(Guid id, Guid commitId, long version, Guid userId)
        {
            return new CreatePricingRotMan(id, commitId, version, userId);
		}

		public CreatePricingRotMan Build(Guid id, DateTime wakeupTime)
		{
			return Build(id, Guid.NewGuid(), wakeupTime);
		}

		public CreatePricingRotMan Build(Guid id, Guid commitId, DateTime wakeupTime)
        {
            return new CreatePricingRotMan(id, commitId, wakeupTime);
		 }

		public CreatePricingRotMan Build(Guid id, long version,DateTime wakeupTime)
		{
			return Build(id, Guid.NewGuid(), version,wakeupTime);
		}
		 

		public CreatePricingRotMan Build(Guid id, Guid commitId, long version, DateTime wakeupTime)
        {
            return new CreatePricingRotMan(id, commitId, version, wakeupTime);
		 }
        
	
	}

	public class CreatePricingAmbBuilder : ICommandBuilder<CreatePricingAmb>
	{
	
		
		public CreatePricingAmb Build(Guid id)
		{
			return Build(id, Guid.NewGuid());
		}

		public CreatePricingAmb Build(Guid id, Guid commitId)
        {
            return new CreatePricingAmb(id, commitId);
		 }


		
		public CreatePricingAmb Build(Guid id, long version)
		{
			return Build(id, Guid.NewGuid(), version);
		}

		public CreatePricingAmb Build(Guid id, Guid commitId, long version)
        {
            return new CreatePricingAmb(id, commitId, version);
		}

		
		public CreatePricingAmb Build(Guid id, Guid commitId, Guid userId)
        {
            return new CreatePricingAmb(id, commitId, userId);
		 }

		 public CreatePricingAmb Build(Guid id, long version, Guid userId)
		{
			return Build(id, Guid.NewGuid(), version, userId);
		}

		public CreatePricingAmb Build(Guid id, Guid commitId, long version, Guid userId)
        {
            return new CreatePricingAmb(id, commitId, version, userId);
		}

		public CreatePricingAmb Build(Guid id, DateTime wakeupTime)
		{
			return Build(id, Guid.NewGuid(), wakeupTime);
		}

		public CreatePricingAmb Build(Guid id, Guid commitId, DateTime wakeupTime)
        {
            return new CreatePricingAmb(id, commitId, wakeupTime);
		 }

		public CreatePricingAmb Build(Guid id, long version,DateTime wakeupTime)
		{
			return Build(id, Guid.NewGuid(), version,wakeupTime);
		}
		 

		public CreatePricingAmb Build(Guid id, Guid commitId, long version, DateTime wakeupTime)
        {
            return new CreatePricingAmb(id, commitId, version, wakeupTime);
		 }
        
	
	}
}

namespace Super.Contabilita.Commands
{
	public static partial class BuildCmd 
	{
		  public static CreateBasePriceRotBuilder CreateBasePriceRot {get { return new CreateBasePriceRotBuilder(); } }
	  		  public static CreateBasePriceRotManBuilder CreateBasePriceRotMan {get { return new CreateBasePriceRotManBuilder(); } }
	  		  public static CreateBasePriceAmbBuilder CreateBasePriceAmb {get { return new CreateBasePriceAmbBuilder(); } }
	  		  public static UpdateBasePriceRotBuilder UpdateBasePriceRot {get { return new UpdateBasePriceRotBuilder(); } }
	  		  public static UpdateBasePriceRotManBuilder UpdateBasePriceRotMan {get { return new UpdateBasePriceRotManBuilder(); } }
	  		  public static UpdateBasePriceAmbBuilder UpdateBasePriceAmb {get { return new UpdateBasePriceAmbBuilder(); } }
	  		  public static CreatePricingRotBuilder CreatePricingRot {get { return new CreatePricingRotBuilder(); } }
	  		  public static CreatePricingRotManBuilder CreatePricingRotMan {get { return new CreatePricingRotManBuilder(); } }
	  		  public static CreatePricingAmbBuilder CreatePricingAmb {get { return new CreatePricingAmbBuilder(); } }
	  	}
}
