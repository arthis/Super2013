


using System;
using CommonDomain;
using System.Diagnostics.Contracts;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using Super.Contabilita.Events.Intervento;
using Super.Contabilita.Events.Intervento.Builders;

namespace Super.Contabilita.Events.Intervento.Builders
{


	public class InterventoPriceOfPlanCalculatedBuilder : IEventBuilder<InterventoPriceOfPlanCalculated>
	{
	 
		private decimal  _price ; 
		private Guid  _idPlan ;
		public InterventoPriceOfPlanCalculatedBuilder ForPrice(decimal price) 
		{
			_price = price;
			return this;
		}
	
		public InterventoPriceOfPlanCalculatedBuilder ForPlan(Guid idPlan) 
		{
			_idPlan = idPlan;
			return this;
		}
	
		public InterventoPriceOfPlanCalculated Build(Guid id, long version)
		{
			return Build(id, Guid.NewGuid(), version);
		}

		public InterventoPriceOfPlanCalculated Build(Guid id, Guid commitId, long version)
        {
            return new InterventoPriceOfPlanCalculated(id, commitId, version, _price, _idPlan);
		 }

       
	
	}

	public class InterventoPriceOfPlanCancelledBuilder : IEventBuilder<InterventoPriceOfPlanCancelled>
	{
	 
		private Guid  _idPlan ;
		public InterventoPriceOfPlanCancelledBuilder ForPlan(Guid idPlan) 
		{
			_idPlan = idPlan;
			return this;
		}
	
		public InterventoPriceOfPlanCancelled Build(Guid id, long version)
		{
			return Build(id, Guid.NewGuid(), version);
		}

		public InterventoPriceOfPlanCancelled Build(Guid id, Guid commitId, long version)
        {
            return new InterventoPriceOfPlanCancelled(id, commitId, version, _idPlan);
		 }

       
	
	}

	public class InterventoRotCreatedBuilder : IEventBuilder<InterventoRotCreated>
	{
	 
		private Guid  _idTipoIntervento ; 
		private Guid  _idPlan ; 
		private OggettoRot[]  _oggetti ; 
		private WorkPeriod  _workPeriod ;
		public InterventoRotCreatedBuilder OfTipoIntervento(Guid idTipoIntervento) 
		{
			_idTipoIntervento = idTipoIntervento;
			return this;
		}
	
		public InterventoRotCreatedBuilder ForPlan(Guid idPlan) 
		{
			_idPlan = idPlan;
			return this;
		}
	
		public InterventoRotCreatedBuilder WithOggetti(OggettoRot[] oggetti) 
		{
			_oggetti = oggetti;
			return this;
		}
	
		public InterventoRotCreatedBuilder ForWorkPeriod(WorkPeriod workPeriod) 
		{
			_workPeriod = workPeriod;
			return this;
		}
	
		public InterventoRotCreated Build(Guid id, long version)
		{
			return Build(id, Guid.NewGuid(), version);
		}

		public InterventoRotCreated Build(Guid id, Guid commitId, long version)
        {
            return new InterventoRotCreated(id, commitId, version, _idTipoIntervento, _idPlan, _oggetti, _workPeriod);
		 }

       
	
	}

	public class InterventoRotManCreatoBuilder : IEventBuilder<InterventoRotManCreato>
	{
	 
		private Guid  _idTipoIntervento ; 
		private Guid  _idPlan ; 
		private OggettoRotMan[]  _oggetti ; 
		private WorkPeriod  _workPeriod ;
		public InterventoRotManCreatoBuilder OfTipoIntervento(Guid idTipoIntervento) 
		{
			_idTipoIntervento = idTipoIntervento;
			return this;
		}
	
		public InterventoRotManCreatoBuilder ForPlan(Guid idPlan) 
		{
			_idPlan = idPlan;
			return this;
		}
	
		public InterventoRotManCreatoBuilder WithOggetti(OggettoRotMan[] oggetti) 
		{
			_oggetti = oggetti;
			return this;
		}
	
		public InterventoRotManCreatoBuilder ForWorkPeriod(WorkPeriod workPeriod) 
		{
			_workPeriod = workPeriod;
			return this;
		}
	
		public InterventoRotManCreato Build(Guid id, long version)
		{
			return Build(id, Guid.NewGuid(), version);
		}

		public InterventoRotManCreato Build(Guid id, Guid commitId, long version)
        {
            return new InterventoRotManCreato(id, commitId, version, _idTipoIntervento, _idPlan, _oggetti, _workPeriod);
		 }

       
	
	}

	public class InterventoAmbCreatedBuilder : IEventBuilder<InterventoAmbCreated>
	{
	 
		private Guid  _idTipoIntervento ; 
		private Guid  _idPlan ; 
		private int  _quantity ; 
		private WorkPeriod  _workPeriod ;
		public InterventoAmbCreatedBuilder OfTipoIntervento(Guid idTipoIntervento) 
		{
			_idTipoIntervento = idTipoIntervento;
			return this;
		}
	
		public InterventoAmbCreatedBuilder ForPlan(Guid idPlan) 
		{
			_idPlan = idPlan;
			return this;
		}
	
		public InterventoAmbCreatedBuilder ForQuantity(int quantity) 
		{
			_quantity = quantity;
			return this;
		}
	
		public InterventoAmbCreatedBuilder ForWorkPeriod(WorkPeriod workPeriod) 
		{
			_workPeriod = workPeriod;
			return this;
		}
	
		public InterventoAmbCreated Build(Guid id, long version)
		{
			return Build(id, Guid.NewGuid(), version);
		}

		public InterventoAmbCreated Build(Guid id, Guid commitId, long version)
        {
            return new InterventoAmbCreated(id, commitId, version, _idTipoIntervento, _idPlan, _quantity, _workPeriod);
		 }

       
	
	}
}

namespace Super.Contabilita.Events
{
	public static partial class BuildEvt 
	{
		  public static InterventoPriceOfPlanCalculatedBuilder InterventoPriceOfPlanCalculated {get { return new InterventoPriceOfPlanCalculatedBuilder(); } }
	  		  public static InterventoPriceOfPlanCancelledBuilder InterventoPriceOfPlanCancelled {get { return new InterventoPriceOfPlanCancelledBuilder(); } }
	  		  public static InterventoRotCreatedBuilder InterventoRotCreated {get { return new InterventoRotCreatedBuilder(); } }
	  		  public static InterventoRotManCreatoBuilder InterventoRotManCreato {get { return new InterventoRotManCreatoBuilder(); } }
	  		  public static InterventoAmbCreatedBuilder InterventoAmbCreated {get { return new InterventoAmbCreatedBuilder(); } }
	  	}
}
