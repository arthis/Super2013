


using System;
using CommonDomain;
using System.Diagnostics.Contracts;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using Super.Contabilita.Events.Schedulazione;
using Super.Contabilita.Events.Schedulazione.Builders;

namespace Super.Contabilita.Events.Schedulazione.Builders
{


	public class SchedulazionePriceOfScenarioCalculatedBuilder : IEventBuilder<SchedulazionePriceOfScenarioCalculated>
	{
	 
		private decimal  _price ; 
		private Guid  _idScenario ;
		public SchedulazionePriceOfScenarioCalculatedBuilder ForPrice(decimal price) 
		{
			_price = price;
			return this;
		}
	
		public SchedulazionePriceOfScenarioCalculatedBuilder ForScenario(Guid idScenario) 
		{
			_idScenario = idScenario;
			return this;
		}
	
		public SchedulazionePriceOfScenarioCalculated Build(Guid id, long version)
		{
			return Build(id, Guid.NewGuid(), version);
		}

		public SchedulazionePriceOfScenarioCalculated Build(Guid id, Guid commitId, long version)
        {
            return new SchedulazionePriceOfScenarioCalculated(id, commitId, version, _price, _idScenario);
		 }

       
	
	}

	public class SchedulazioneRotCreatedBuilder : IEventBuilder<SchedulazioneRotCreated>
	{
	 
		private Guid  _idTipoIntervento ; 
		private Guid  _idScenario ; 
		private OggettoRot[]  _oggetti ; 
		private Period  _period ; 
		private WorkPeriod  _workPeriod ;
		public SchedulazioneRotCreatedBuilder OfTipoIntervento(Guid idTipoIntervento) 
		{
			_idTipoIntervento = idTipoIntervento;
			return this;
		}
	
		public SchedulazioneRotCreatedBuilder ForScenario(Guid idScenario) 
		{
			_idScenario = idScenario;
			return this;
		}
	
		public SchedulazioneRotCreatedBuilder WithOggetti(OggettoRot[] oggetti) 
		{
			_oggetti = oggetti;
			return this;
		}
	
		public SchedulazioneRotCreatedBuilder ForPeriod(Period period) 
		{
			_period = period;
			return this;
		}
	
		public SchedulazioneRotCreatedBuilder ForWorkPeriod(WorkPeriod workPeriod) 
		{
			_workPeriod = workPeriod;
			return this;
		}
	
		public SchedulazioneRotCreated Build(Guid id, long version)
		{
			return Build(id, Guid.NewGuid(), version);
		}

		public SchedulazioneRotCreated Build(Guid id, Guid commitId, long version)
        {
            return new SchedulazioneRotCreated(id, commitId, version, _idTipoIntervento, _idScenario, _oggetti, _period, _workPeriod);
		 }

       
	
	}

	public class SchedulazioneRotManCreatedBuilder : IEventBuilder<SchedulazioneRotManCreated>
	{
	 
		private Guid  _idTipoIntervento ; 
		private Guid  _idScenario ; 
		private OggettoRotMan[]  _oggetti ; 
		private Period  _period ; 
		private WorkPeriod  _workPeriod ;
		public SchedulazioneRotManCreatedBuilder OfTipoIntervento(Guid idTipoIntervento) 
		{
			_idTipoIntervento = idTipoIntervento;
			return this;
		}
	
		public SchedulazioneRotManCreatedBuilder ForScenario(Guid idScenario) 
		{
			_idScenario = idScenario;
			return this;
		}
	
		public SchedulazioneRotManCreatedBuilder WithOggetti(OggettoRotMan[] oggetti) 
		{
			_oggetti = oggetti;
			return this;
		}
	
		public SchedulazioneRotManCreatedBuilder ForPeriod(Period period) 
		{
			_period = period;
			return this;
		}
	
		public SchedulazioneRotManCreatedBuilder ForWorkPeriod(WorkPeriod workPeriod) 
		{
			_workPeriod = workPeriod;
			return this;
		}
	
		public SchedulazioneRotManCreated Build(Guid id, long version)
		{
			return Build(id, Guid.NewGuid(), version);
		}

		public SchedulazioneRotManCreated Build(Guid id, Guid commitId, long version)
        {
            return new SchedulazioneRotManCreated(id, commitId, version, _idTipoIntervento, _idScenario, _oggetti, _period, _workPeriod);
		 }

       
	
	}

	public class SchedulazioneAmbCreatedBuilder : IEventBuilder<SchedulazioneAmbCreated>
	{
	 
		private Guid  _idTipoIntervento ; 
		private Guid  _idScenario ; 
		private int  _quantity ; 
		private Period  _period ; 
		private WorkPeriod  _workPeriod ;
		public SchedulazioneAmbCreatedBuilder OfTipoIntervento(Guid idTipoIntervento) 
		{
			_idTipoIntervento = idTipoIntervento;
			return this;
		}
	
		public SchedulazioneAmbCreatedBuilder ForScenario(Guid idScenario) 
		{
			_idScenario = idScenario;
			return this;
		}
	
		public SchedulazioneAmbCreatedBuilder ForQuantity(int quantity) 
		{
			_quantity = quantity;
			return this;
		}
	
		public SchedulazioneAmbCreatedBuilder ForPeriod(Period period) 
		{
			_period = period;
			return this;
		}
	
		public SchedulazioneAmbCreatedBuilder ForWorkPeriod(WorkPeriod workPeriod) 
		{
			_workPeriod = workPeriod;
			return this;
		}
	
		public SchedulazioneAmbCreated Build(Guid id, long version)
		{
			return Build(id, Guid.NewGuid(), version);
		}

		public SchedulazioneAmbCreated Build(Guid id, Guid commitId, long version)
        {
            return new SchedulazioneAmbCreated(id, commitId, version, _idTipoIntervento, _idScenario, _quantity, _period, _workPeriod);
		 }

       
	
	}
}

namespace Super.Contabilita.Events
{
	public static partial class BuildEvt 
	{
		  public static SchedulazionePriceOfScenarioCalculatedBuilder SchedulazionePriceOfScenarioCalculated {get { return new SchedulazionePriceOfScenarioCalculatedBuilder(); } }
	  		  public static SchedulazioneRotCreatedBuilder SchedulazioneRotCreated {get { return new SchedulazioneRotCreatedBuilder(); } }
	  		  public static SchedulazioneRotManCreatedBuilder SchedulazioneRotManCreated {get { return new SchedulazioneRotManCreatedBuilder(); } }
	  		  public static SchedulazioneAmbCreatedBuilder SchedulazioneAmbCreated {get { return new SchedulazioneAmbCreatedBuilder(); } }
	  	}
}
