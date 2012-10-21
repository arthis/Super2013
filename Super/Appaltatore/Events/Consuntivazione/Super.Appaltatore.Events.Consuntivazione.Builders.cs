


using System;
using CommonDomain;
using System.Diagnostics.Contracts;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using Super.Appaltatore.Events.Consuntivazione;
using Super.Appaltatore.Events.Consuntivazione.Builders;

namespace Super.Appaltatore.Events.Consuntivazione.Builders
{


	public class InterventoRotConsuntivatoNonResoBuilder : IEventBuilder<InterventoRotConsuntivatoNonReso>
	{
	 
		private string  _note ; 
		private Guid  _idCausaleAppaltatore ; 
		private DateTime  _dataConsuntivazione ; 
		private string  _idInterventoAppaltatore ;
		public InterventoRotConsuntivatoNonResoBuilder WithNote(string note) 
		{
			_note = note;
			return this;
		}
	
		public InterventoRotConsuntivatoNonResoBuilder Because(Guid idCausaleAppaltatore) 
		{
			_idCausaleAppaltatore = idCausaleAppaltatore;
			return this;
		}
	
		public InterventoRotConsuntivatoNonResoBuilder When(DateTime dataConsuntivazione) 
		{
			_dataConsuntivazione = dataConsuntivazione;
			return this;
		}
	
		public InterventoRotConsuntivatoNonResoBuilder ForInterventoAppaltatore(string idInterventoAppaltatore) 
		{
			_idInterventoAppaltatore = idInterventoAppaltatore;
			return this;
		}
	
		public InterventoRotConsuntivatoNonReso Build(Guid id, long version)
		{
			return Build(id, Guid.NewGuid(), version);
		}

		public InterventoRotConsuntivatoNonReso Build(Guid id, long version,DateTime wakeupTime)
		{
			return Build(id, Guid.NewGuid(), version,wakeupTime);
		}

		public InterventoRotConsuntivatoNonReso Build(Guid id, Guid commitId, long version)
        {
            return new InterventoRotConsuntivatoNonReso(id, commitId, version, _note, _idCausaleAppaltatore, _dataConsuntivazione, _idInterventoAppaltatore);
		 }

		public InterventoRotConsuntivatoNonReso Build(Guid id, Guid commitId, long version, DateTime wakeupTime)
        {
            return new InterventoRotConsuntivatoNonReso(id, commitId, version, wakeupTime, _note, _idCausaleAppaltatore, _dataConsuntivazione, _idInterventoAppaltatore);
		 }
        
	
	}

	public class InterventoRotManConsuntivatoNonResoBuilder : IEventBuilder<InterventoRotManConsuntivatoNonReso>
	{
	 
		private string  _note ; 
		private Guid  _idCausaleAppaltatore ; 
		private DateTime  _dataConsuntivazione ; 
		private string  _idInterventoAppaltatore ;
		public InterventoRotManConsuntivatoNonResoBuilder WithNote(string note) 
		{
			_note = note;
			return this;
		}
	
		public InterventoRotManConsuntivatoNonResoBuilder Because(Guid idCausaleAppaltatore) 
		{
			_idCausaleAppaltatore = idCausaleAppaltatore;
			return this;
		}
	
		public InterventoRotManConsuntivatoNonResoBuilder When(DateTime dataConsuntivazione) 
		{
			_dataConsuntivazione = dataConsuntivazione;
			return this;
		}
	
		public InterventoRotManConsuntivatoNonResoBuilder ForInterventoAppaltatore(string idInterventoAppaltatore) 
		{
			_idInterventoAppaltatore = idInterventoAppaltatore;
			return this;
		}
	
		public InterventoRotManConsuntivatoNonReso Build(Guid id, long version)
		{
			return Build(id, Guid.NewGuid(), version);
		}

		public InterventoRotManConsuntivatoNonReso Build(Guid id, long version,DateTime wakeupTime)
		{
			return Build(id, Guid.NewGuid(), version,wakeupTime);
		}

		public InterventoRotManConsuntivatoNonReso Build(Guid id, Guid commitId, long version)
        {
            return new InterventoRotManConsuntivatoNonReso(id, commitId, version, _note, _idCausaleAppaltatore, _dataConsuntivazione, _idInterventoAppaltatore);
		 }

		public InterventoRotManConsuntivatoNonReso Build(Guid id, Guid commitId, long version, DateTime wakeupTime)
        {
            return new InterventoRotManConsuntivatoNonReso(id, commitId, version, wakeupTime, _note, _idCausaleAppaltatore, _dataConsuntivazione, _idInterventoAppaltatore);
		 }
        
	
	}

	public class InterventoAmbConsuntivatoNonResoBuilder : IEventBuilder<InterventoAmbConsuntivatoNonReso>
	{
	 
		private string  _note ; 
		private Guid  _idCausaleAppaltatore ; 
		private DateTime  _dataConsuntivazione ; 
		private string  _idInterventoAppaltatore ;
		public InterventoAmbConsuntivatoNonResoBuilder WithNote(string note) 
		{
			_note = note;
			return this;
		}
	
		public InterventoAmbConsuntivatoNonResoBuilder Because(Guid idCausaleAppaltatore) 
		{
			_idCausaleAppaltatore = idCausaleAppaltatore;
			return this;
		}
	
		public InterventoAmbConsuntivatoNonResoBuilder When(DateTime dataConsuntivazione) 
		{
			_dataConsuntivazione = dataConsuntivazione;
			return this;
		}
	
		public InterventoAmbConsuntivatoNonResoBuilder ForInterventoAppaltatore(string idInterventoAppaltatore) 
		{
			_idInterventoAppaltatore = idInterventoAppaltatore;
			return this;
		}
	
		public InterventoAmbConsuntivatoNonReso Build(Guid id, long version)
		{
			return Build(id, Guid.NewGuid(), version);
		}

		public InterventoAmbConsuntivatoNonReso Build(Guid id, long version,DateTime wakeupTime)
		{
			return Build(id, Guid.NewGuid(), version,wakeupTime);
		}

		public InterventoAmbConsuntivatoNonReso Build(Guid id, Guid commitId, long version)
        {
            return new InterventoAmbConsuntivatoNonReso(id, commitId, version, _note, _idCausaleAppaltatore, _dataConsuntivazione, _idInterventoAppaltatore);
		 }

		public InterventoAmbConsuntivatoNonReso Build(Guid id, Guid commitId, long version, DateTime wakeupTime)
        {
            return new InterventoAmbConsuntivatoNonReso(id, commitId, version, wakeupTime, _note, _idCausaleAppaltatore, _dataConsuntivazione, _idInterventoAppaltatore);
		 }
        
	
	}

	public class InterventoRotConsuntivatoNonResoTrenitaliaBuilder : IEventBuilder<InterventoRotConsuntivatoNonResoTrenitalia>
	{
	 
		private string  _note ; 
		private Guid  _idCausaleTrenitalia ; 
		private DateTime  _dataConsuntivazione ; 
		private string  _idInterventoAppaltatore ;
		public InterventoRotConsuntivatoNonResoTrenitaliaBuilder WithNote(string note) 
		{
			_note = note;
			return this;
		}
	
		public InterventoRotConsuntivatoNonResoTrenitaliaBuilder Because(Guid idCausaleTrenitalia) 
		{
			_idCausaleTrenitalia = idCausaleTrenitalia;
			return this;
		}
	
		public InterventoRotConsuntivatoNonResoTrenitaliaBuilder When(DateTime dataConsuntivazione) 
		{
			_dataConsuntivazione = dataConsuntivazione;
			return this;
		}
	
		public InterventoRotConsuntivatoNonResoTrenitaliaBuilder ForInterventoAppaltatore(string idInterventoAppaltatore) 
		{
			_idInterventoAppaltatore = idInterventoAppaltatore;
			return this;
		}
	
		public InterventoRotConsuntivatoNonResoTrenitalia Build(Guid id, long version)
		{
			return Build(id, Guid.NewGuid(), version);
		}

		public InterventoRotConsuntivatoNonResoTrenitalia Build(Guid id, long version,DateTime wakeupTime)
		{
			return Build(id, Guid.NewGuid(), version,wakeupTime);
		}

		public InterventoRotConsuntivatoNonResoTrenitalia Build(Guid id, Guid commitId, long version)
        {
            return new InterventoRotConsuntivatoNonResoTrenitalia(id, commitId, version, _note, _idCausaleTrenitalia, _dataConsuntivazione, _idInterventoAppaltatore);
		 }

		public InterventoRotConsuntivatoNonResoTrenitalia Build(Guid id, Guid commitId, long version, DateTime wakeupTime)
        {
            return new InterventoRotConsuntivatoNonResoTrenitalia(id, commitId, version, wakeupTime, _note, _idCausaleTrenitalia, _dataConsuntivazione, _idInterventoAppaltatore);
		 }
        
	
	}

	public class InterventoRotManConsuntivatoNonResoTrenitaliaBuilder : IEventBuilder<InterventoRotManConsuntivatoNonResoTrenitalia>
	{
	 
		private string  _note ; 
		private Guid  _idCausaleTrenitalia ; 
		private DateTime  _dataConsuntivazione ; 
		private string  _idInterventoAppaltatore ;
		public InterventoRotManConsuntivatoNonResoTrenitaliaBuilder WithNote(string note) 
		{
			_note = note;
			return this;
		}
	
		public InterventoRotManConsuntivatoNonResoTrenitaliaBuilder Because(Guid idCausaleTrenitalia) 
		{
			_idCausaleTrenitalia = idCausaleTrenitalia;
			return this;
		}
	
		public InterventoRotManConsuntivatoNonResoTrenitaliaBuilder When(DateTime dataConsuntivazione) 
		{
			_dataConsuntivazione = dataConsuntivazione;
			return this;
		}
	
		public InterventoRotManConsuntivatoNonResoTrenitaliaBuilder ForInterventoAppaltatore(string idInterventoAppaltatore) 
		{
			_idInterventoAppaltatore = idInterventoAppaltatore;
			return this;
		}
	
		public InterventoRotManConsuntivatoNonResoTrenitalia Build(Guid id, long version)
		{
			return Build(id, Guid.NewGuid(), version);
		}

		public InterventoRotManConsuntivatoNonResoTrenitalia Build(Guid id, long version,DateTime wakeupTime)
		{
			return Build(id, Guid.NewGuid(), version,wakeupTime);
		}

		public InterventoRotManConsuntivatoNonResoTrenitalia Build(Guid id, Guid commitId, long version)
        {
            return new InterventoRotManConsuntivatoNonResoTrenitalia(id, commitId, version, _note, _idCausaleTrenitalia, _dataConsuntivazione, _idInterventoAppaltatore);
		 }

		public InterventoRotManConsuntivatoNonResoTrenitalia Build(Guid id, Guid commitId, long version, DateTime wakeupTime)
        {
            return new InterventoRotManConsuntivatoNonResoTrenitalia(id, commitId, version, wakeupTime, _note, _idCausaleTrenitalia, _dataConsuntivazione, _idInterventoAppaltatore);
		 }
        
	
	}

	public class InterventoAmbConsuntivatoNonResoTrenitaliaBuilder : IEventBuilder<InterventoAmbConsuntivatoNonResoTrenitalia>
	{
	 
		private string  _note ; 
		private Guid  _idCausaleTrenitalia ; 
		private DateTime  _dataConsuntivazione ; 
		private string  _idInterventoAppaltatore ;
		public InterventoAmbConsuntivatoNonResoTrenitaliaBuilder WithNote(string note) 
		{
			_note = note;
			return this;
		}
	
		public InterventoAmbConsuntivatoNonResoTrenitaliaBuilder Because(Guid idCausaleTrenitalia) 
		{
			_idCausaleTrenitalia = idCausaleTrenitalia;
			return this;
		}
	
		public InterventoAmbConsuntivatoNonResoTrenitaliaBuilder When(DateTime dataConsuntivazione) 
		{
			_dataConsuntivazione = dataConsuntivazione;
			return this;
		}
	
		public InterventoAmbConsuntivatoNonResoTrenitaliaBuilder ForInterventoAppaltatore(string idInterventoAppaltatore) 
		{
			_idInterventoAppaltatore = idInterventoAppaltatore;
			return this;
		}
	
		public InterventoAmbConsuntivatoNonResoTrenitalia Build(Guid id, long version)
		{
			return Build(id, Guid.NewGuid(), version);
		}

		public InterventoAmbConsuntivatoNonResoTrenitalia Build(Guid id, long version,DateTime wakeupTime)
		{
			return Build(id, Guid.NewGuid(), version,wakeupTime);
		}

		public InterventoAmbConsuntivatoNonResoTrenitalia Build(Guid id, Guid commitId, long version)
        {
            return new InterventoAmbConsuntivatoNonResoTrenitalia(id, commitId, version, _note, _idCausaleTrenitalia, _dataConsuntivazione, _idInterventoAppaltatore);
		 }

		public InterventoAmbConsuntivatoNonResoTrenitalia Build(Guid id, Guid commitId, long version, DateTime wakeupTime)
        {
            return new InterventoAmbConsuntivatoNonResoTrenitalia(id, commitId, version, wakeupTime, _note, _idCausaleTrenitalia, _dataConsuntivazione, _idInterventoAppaltatore);
		 }
        
	
	}

	public class InterventoAmbConsuntivatoResoBuilder : IEventBuilder<InterventoAmbConsuntivatoReso>
	{
	 
		private string  _note ; 
		private WorkPeriod  _workPeriod ; 
		private DateTime  _dataConsuntivazione ; 
		private string  _idInterventoAppaltatore ; 
		private int  _quantity ; 
		private string  _description ;
		public InterventoAmbConsuntivatoResoBuilder WithNote(string note) 
		{
			_note = note;
			return this;
		}
	
		public InterventoAmbConsuntivatoResoBuilder ForWorkPeriod(WorkPeriod workPeriod) 
		{
			_workPeriod = workPeriod;
			return this;
		}
	
		public InterventoAmbConsuntivatoResoBuilder When(DateTime dataConsuntivazione) 
		{
			_dataConsuntivazione = dataConsuntivazione;
			return this;
		}
	
		public InterventoAmbConsuntivatoResoBuilder ForInterventoAppaltatore(string idInterventoAppaltatore) 
		{
			_idInterventoAppaltatore = idInterventoAppaltatore;
			return this;
		}
	
		public InterventoAmbConsuntivatoResoBuilder ForQuantity(int quantity) 
		{
			_quantity = quantity;
			return this;
		}
	
		public InterventoAmbConsuntivatoResoBuilder ForDescription(string description) 
		{
			_description = description;
			return this;
		}
	
		public InterventoAmbConsuntivatoReso Build(Guid id, long version)
		{
			return Build(id, Guid.NewGuid(), version);
		}

		public InterventoAmbConsuntivatoReso Build(Guid id, long version,DateTime wakeupTime)
		{
			return Build(id, Guid.NewGuid(), version,wakeupTime);
		}

		public InterventoAmbConsuntivatoReso Build(Guid id, Guid commitId, long version)
        {
            return new InterventoAmbConsuntivatoReso(id, commitId, version, _note, _workPeriod, _dataConsuntivazione, _idInterventoAppaltatore, _quantity, _description);
		 }

		public InterventoAmbConsuntivatoReso Build(Guid id, Guid commitId, long version, DateTime wakeupTime)
        {
            return new InterventoAmbConsuntivatoReso(id, commitId, version, wakeupTime, _note, _workPeriod, _dataConsuntivazione, _idInterventoAppaltatore, _quantity, _description);
		 }
        
	
	}

	public class InterventoRotConsuntivatoResoBuilder : IEventBuilder<InterventoRotConsuntivatoReso>
	{
	 
		private string  _note ; 
		private WorkPeriod  _workPeriod ; 
		private DateTime  _dataConsuntivazione ; 
		private string  _idInterventoAppaltatore ; 
		private OggettoRot[]  _oggetti ;
		public InterventoRotConsuntivatoResoBuilder WithNote(string note) 
		{
			_note = note;
			return this;
		}
	
		public InterventoRotConsuntivatoResoBuilder ForWorkPeriod(WorkPeriod workPeriod) 
		{
			_workPeriod = workPeriod;
			return this;
		}
	
		public InterventoRotConsuntivatoResoBuilder When(DateTime dataConsuntivazione) 
		{
			_dataConsuntivazione = dataConsuntivazione;
			return this;
		}
	
		public InterventoRotConsuntivatoResoBuilder ForInterventoAppaltatore(string idInterventoAppaltatore) 
		{
			_idInterventoAppaltatore = idInterventoAppaltatore;
			return this;
		}
	
		public InterventoRotConsuntivatoResoBuilder WithOggetti(OggettoRot[] oggetti) 
		{
			_oggetti = oggetti;
			return this;
		}
	
		public InterventoRotConsuntivatoReso Build(Guid id, long version)
		{
			return Build(id, Guid.NewGuid(), version);
		}

		public InterventoRotConsuntivatoReso Build(Guid id, long version,DateTime wakeupTime)
		{
			return Build(id, Guid.NewGuid(), version,wakeupTime);
		}

		public InterventoRotConsuntivatoReso Build(Guid id, Guid commitId, long version)
        {
            return new InterventoRotConsuntivatoReso(id, commitId, version, _note, _workPeriod, _dataConsuntivazione, _idInterventoAppaltatore, _oggetti);
		 }

		public InterventoRotConsuntivatoReso Build(Guid id, Guid commitId, long version, DateTime wakeupTime)
        {
            return new InterventoRotConsuntivatoReso(id, commitId, version, wakeupTime, _note, _workPeriod, _dataConsuntivazione, _idInterventoAppaltatore, _oggetti);
		 }
        
	
	}

	public class InterventoRotManConsuntivatoResoBuilder : IEventBuilder<InterventoRotManConsuntivatoReso>
	{
	 
		private string  _note ; 
		private WorkPeriod  _workPeriod ; 
		private DateTime  _dataConsuntivazione ; 
		private string  _idInterventoAppaltatore ; 
		private OggettoRotMan[]  _oggetti ;
		public InterventoRotManConsuntivatoResoBuilder WithNote(string note) 
		{
			_note = note;
			return this;
		}
	
		public InterventoRotManConsuntivatoResoBuilder ForWorkPeriod(WorkPeriod workPeriod) 
		{
			_workPeriod = workPeriod;
			return this;
		}
	
		public InterventoRotManConsuntivatoResoBuilder When(DateTime dataConsuntivazione) 
		{
			_dataConsuntivazione = dataConsuntivazione;
			return this;
		}
	
		public InterventoRotManConsuntivatoResoBuilder ForInterventoAppaltatore(string idInterventoAppaltatore) 
		{
			_idInterventoAppaltatore = idInterventoAppaltatore;
			return this;
		}
	
		public InterventoRotManConsuntivatoResoBuilder WithOggetti(OggettoRotMan[] oggetti) 
		{
			_oggetti = oggetti;
			return this;
		}
	
		public InterventoRotManConsuntivatoReso Build(Guid id, long version)
		{
			return Build(id, Guid.NewGuid(), version);
		}

		public InterventoRotManConsuntivatoReso Build(Guid id, long version,DateTime wakeupTime)
		{
			return Build(id, Guid.NewGuid(), version,wakeupTime);
		}

		public InterventoRotManConsuntivatoReso Build(Guid id, Guid commitId, long version)
        {
            return new InterventoRotManConsuntivatoReso(id, commitId, version, _note, _workPeriod, _dataConsuntivazione, _idInterventoAppaltatore, _oggetti);
		 }

		public InterventoRotManConsuntivatoReso Build(Guid id, Guid commitId, long version, DateTime wakeupTime)
        {
            return new InterventoRotManConsuntivatoReso(id, commitId, version, wakeupTime, _note, _workPeriod, _dataConsuntivazione, _idInterventoAppaltatore, _oggetti);
		 }
        
	
	}
}

namespace Super.Appaltatore.Events
{
	public static partial class BuildEvt 
	{
		  public static InterventoRotConsuntivatoNonResoBuilder InterventoRotConsuntivatoNonReso {get { return new InterventoRotConsuntivatoNonResoBuilder(); } }
	  		  public static InterventoRotManConsuntivatoNonResoBuilder InterventoRotManConsuntivatoNonReso {get { return new InterventoRotManConsuntivatoNonResoBuilder(); } }
	  		  public static InterventoAmbConsuntivatoNonResoBuilder InterventoAmbConsuntivatoNonReso {get { return new InterventoAmbConsuntivatoNonResoBuilder(); } }
	  		  public static InterventoRotConsuntivatoNonResoTrenitaliaBuilder InterventoRotConsuntivatoNonResoTrenitalia {get { return new InterventoRotConsuntivatoNonResoTrenitaliaBuilder(); } }
	  		  public static InterventoRotManConsuntivatoNonResoTrenitaliaBuilder InterventoRotManConsuntivatoNonResoTrenitalia {get { return new InterventoRotManConsuntivatoNonResoTrenitaliaBuilder(); } }
	  		  public static InterventoAmbConsuntivatoNonResoTrenitaliaBuilder InterventoAmbConsuntivatoNonResoTrenitalia {get { return new InterventoAmbConsuntivatoNonResoTrenitaliaBuilder(); } }
	  		  public static InterventoAmbConsuntivatoResoBuilder InterventoAmbConsuntivatoReso {get { return new InterventoAmbConsuntivatoResoBuilder(); } }
	  		  public static InterventoRotConsuntivatoResoBuilder InterventoRotConsuntivatoReso {get { return new InterventoRotConsuntivatoResoBuilder(); } }
	  		  public static InterventoRotManConsuntivatoResoBuilder InterventoRotManConsuntivatoReso {get { return new InterventoRotManConsuntivatoResoBuilder(); } }
	  	}
}
