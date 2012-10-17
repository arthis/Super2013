


using System;
using CommonDomain;
using System.Diagnostics.Contracts;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using Super.Controllo.Events.Consuntivazione;
using Super.Controllo.Events.Consuntivazione.Builders;

namespace Super.Controllo.Events.Consuntivazione.Builders
{


	public class InterventoControlAllowedBuilder : IEventBuilder<InterventoControlAllowed>
	{
	
		public InterventoControlAllowed Build(Guid id, long version)
		{
			return Build(id, Guid.NewGuid(), version);
		}

		public InterventoControlAllowed Build(Guid id, long version,DateTime wakeupTime)
		{
			return Build(id, Guid.NewGuid(), version,wakeupTime);
		}

		public InterventoControlAllowed Build(Guid id, Guid commitId, long version)
        {
            return new InterventoControlAllowed(id, commitId, version);
		 }

		public InterventoControlAllowed Build(Guid id, Guid commitId, long version, DateTime wakeupTime)
        {
            return new InterventoControlAllowed(id, commitId, version, wakeupTime);
		 }
        
	
	}

	public class InterventoClosedBuilder : IEventBuilder<InterventoClosed>
	{
	 
		private Guid  _idUser ; 
		private DateTime  _closingDate ;
		public InterventoClosedBuilder By(Guid idUser) 
		{
			_idUser = idUser;
			return this;
		}
	
		public InterventoClosedBuilder When(DateTime closingDate) 
		{
			_closingDate = closingDate;
			return this;
		}
	
		public InterventoClosed Build(Guid id, long version)
		{
			return Build(id, Guid.NewGuid(), version);
		}

		public InterventoClosed Build(Guid id, long version,DateTime wakeupTime)
		{
			return Build(id, Guid.NewGuid(), version,wakeupTime);
		}

		public InterventoClosed Build(Guid id, Guid commitId, long version)
        {
            return new InterventoClosed(id, commitId, version, _idUser, _closingDate);
		 }

		public InterventoClosed Build(Guid id, Guid commitId, long version, DateTime wakeupTime)
        {
            return new InterventoClosed(id, commitId, version, wakeupTime, _idUser, _closingDate);
		 }
        
	
	}

	public class InterventoReopenedBuilder : IEventBuilder<InterventoReopened>
	{
	 
		private Guid  _idUser ; 
		private DateTime  _reopeningDate ;
		public InterventoReopenedBuilder By(Guid idUser) 
		{
			_idUser = idUser;
			return this;
		}
	
		public InterventoReopenedBuilder When(DateTime reopeningDate) 
		{
			_reopeningDate = reopeningDate;
			return this;
		}
	
		public InterventoReopened Build(Guid id, long version)
		{
			return Build(id, Guid.NewGuid(), version);
		}

		public InterventoReopened Build(Guid id, long version,DateTime wakeupTime)
		{
			return Build(id, Guid.NewGuid(), version,wakeupTime);
		}

		public InterventoReopened Build(Guid id, Guid commitId, long version)
        {
            return new InterventoReopened(id, commitId, version, _idUser, _reopeningDate);
		 }

		public InterventoReopened Build(Guid id, Guid commitId, long version, DateTime wakeupTime)
        {
            return new InterventoReopened(id, commitId, version, wakeupTime, _idUser, _reopeningDate);
		 }
        
	
	}

	public class InterventoControlledNonResoBuilder : IEventBuilder<InterventoControlledNonReso>
	{
	 
		private string  _note ; 
		private Guid  _idCausale ; 
		private DateTime  _controlDate ; 
		private Guid  _idUser ;
		public InterventoControlledNonResoBuilder WithNote(string note) 
		{
			_note = note;
			return this;
		}
	
		public InterventoControlledNonResoBuilder Because(Guid idCausale) 
		{
			_idCausale = idCausale;
			return this;
		}
	
		public InterventoControlledNonResoBuilder When(DateTime controlDate) 
		{
			_controlDate = controlDate;
			return this;
		}
	
		public InterventoControlledNonResoBuilder By(Guid idUser) 
		{
			_idUser = idUser;
			return this;
		}
	
		public InterventoControlledNonReso Build(Guid id, long version)
		{
			return Build(id, Guid.NewGuid(), version);
		}

		public InterventoControlledNonReso Build(Guid id, long version,DateTime wakeupTime)
		{
			return Build(id, Guid.NewGuid(), version,wakeupTime);
		}

		public InterventoControlledNonReso Build(Guid id, Guid commitId, long version)
        {
            return new InterventoControlledNonReso(id, commitId, version, _note, _idCausale, _controlDate, _idUser);
		 }

		public InterventoControlledNonReso Build(Guid id, Guid commitId, long version, DateTime wakeupTime)
        {
            return new InterventoControlledNonReso(id, commitId, version, wakeupTime, _note, _idCausale, _controlDate, _idUser);
		 }
        
	
	}

	public class InterventoRotControlledResoBuilder : IEventBuilder<InterventoRotControlledReso>
	{
	 
		private string  _note ; 
		private WorkPeriod  _workPeriod ; 
		private DateTime  _controlDate ; 
		private Guid  _idUser ; 
		private string  _idInterventoAppaltatore ; 
		private string  _convoglio ; 
		private string  _rigaTurnoTreno ; 
		private string  _turnoTreno ; 
		private Treno  _trenoArrivo ; 
		private Treno  _trenoPartenza ; 
		private OggettoRot[]  _oggetti ;
		public InterventoRotControlledResoBuilder WithNote(string note) 
		{
			_note = note;
			return this;
		}
	
		public InterventoRotControlledResoBuilder ForWorkPeriod(WorkPeriod workPeriod) 
		{
			_workPeriod = workPeriod;
			return this;
		}
	
		public InterventoRotControlledResoBuilder When(DateTime controlDate) 
		{
			_controlDate = controlDate;
			return this;
		}
	
		public InterventoRotControlledResoBuilder By(Guid idUser) 
		{
			_idUser = idUser;
			return this;
		}
	
		public InterventoRotControlledResoBuilder ForInterventoAppaltatore(string idInterventoAppaltatore) 
		{
			_idInterventoAppaltatore = idInterventoAppaltatore;
			return this;
		}
	
		public InterventoRotControlledResoBuilder ForConvoglio(string convoglio) 
		{
			_convoglio = convoglio;
			return this;
		}
	
		public InterventoRotControlledResoBuilder WithRigaTurnoTreno(string rigaTurnoTreno) 
		{
			_rigaTurnoTreno = rigaTurnoTreno;
			return this;
		}
	
		public InterventoRotControlledResoBuilder WithTurnoTreno(string turnoTreno) 
		{
			_turnoTreno = turnoTreno;
			return this;
		}
	
		public InterventoRotControlledResoBuilder WithTrenoArrivo(Treno trenoArrivo) 
		{
			_trenoArrivo = trenoArrivo;
			return this;
		}
	
		public InterventoRotControlledResoBuilder WithTrenoPartenza(Treno trenoPartenza) 
		{
			_trenoPartenza = trenoPartenza;
			return this;
		}
	
		public InterventoRotControlledResoBuilder WithOggetti(OggettoRot[] oggetti) 
		{
			_oggetti = oggetti;
			return this;
		}
	
		public InterventoRotControlledReso Build(Guid id, long version)
		{
			return Build(id, Guid.NewGuid(), version);
		}

		public InterventoRotControlledReso Build(Guid id, long version,DateTime wakeupTime)
		{
			return Build(id, Guid.NewGuid(), version,wakeupTime);
		}

		public InterventoRotControlledReso Build(Guid id, Guid commitId, long version)
        {
            return new InterventoRotControlledReso(id, commitId, version, _note, _workPeriod, _controlDate, _idUser, _idInterventoAppaltatore, _convoglio, _rigaTurnoTreno, _turnoTreno, _trenoArrivo, _trenoPartenza, _oggetti);
		 }

		public InterventoRotControlledReso Build(Guid id, Guid commitId, long version, DateTime wakeupTime)
        {
            return new InterventoRotControlledReso(id, commitId, version, wakeupTime, _note, _workPeriod, _controlDate, _idUser, _idInterventoAppaltatore, _convoglio, _rigaTurnoTreno, _turnoTreno, _trenoArrivo, _trenoPartenza, _oggetti);
		 }
        
	
	}

	public class InterventoRotManControlledResoBuilder : IEventBuilder<InterventoRotManControlledReso>
	{
	 
		private string  _note ; 
		private WorkPeriod  _workPeriod ; 
		private DateTime  _controlDate ; 
		private Guid  _idUser ; 
		private string  _idInterventoAppaltatore ; 
		private OggettoRotMan[]  _oggetti ;
		public InterventoRotManControlledResoBuilder WithNote(string note) 
		{
			_note = note;
			return this;
		}
	
		public InterventoRotManControlledResoBuilder ForWorkPeriod(WorkPeriod workPeriod) 
		{
			_workPeriod = workPeriod;
			return this;
		}
	
		public InterventoRotManControlledResoBuilder When(DateTime controlDate) 
		{
			_controlDate = controlDate;
			return this;
		}
	
		public InterventoRotManControlledResoBuilder By(Guid idUser) 
		{
			_idUser = idUser;
			return this;
		}
	
		public InterventoRotManControlledResoBuilder ForInterventoAppaltatore(string idInterventoAppaltatore) 
		{
			_idInterventoAppaltatore = idInterventoAppaltatore;
			return this;
		}
	
		public InterventoRotManControlledResoBuilder WithOggetti(OggettoRotMan[] oggetti) 
		{
			_oggetti = oggetti;
			return this;
		}
	
		public InterventoRotManControlledReso Build(Guid id, long version)
		{
			return Build(id, Guid.NewGuid(), version);
		}

		public InterventoRotManControlledReso Build(Guid id, long version,DateTime wakeupTime)
		{
			return Build(id, Guid.NewGuid(), version,wakeupTime);
		}

		public InterventoRotManControlledReso Build(Guid id, Guid commitId, long version)
        {
            return new InterventoRotManControlledReso(id, commitId, version, _note, _workPeriod, _controlDate, _idUser, _idInterventoAppaltatore, _oggetti);
		 }

		public InterventoRotManControlledReso Build(Guid id, Guid commitId, long version, DateTime wakeupTime)
        {
            return new InterventoRotManControlledReso(id, commitId, version, wakeupTime, _note, _workPeriod, _controlDate, _idUser, _idInterventoAppaltatore, _oggetti);
		 }
        
	
	}

	public class InterventoAmbControlledResoBuilder : IEventBuilder<InterventoAmbControlledReso>
	{
	 
		private string  _note ; 
		private WorkPeriod  _workPeriod ; 
		private DateTime  _controlDate ; 
		private Guid  _idUser ; 
		private string  _idInterventoAppaltatore ; 
		private string  _description ; 
		private int  _quantity ;
		public InterventoAmbControlledResoBuilder WithNote(string note) 
		{
			_note = note;
			return this;
		}
	
		public InterventoAmbControlledResoBuilder ForWorkPeriod(WorkPeriod workPeriod) 
		{
			_workPeriod = workPeriod;
			return this;
		}
	
		public InterventoAmbControlledResoBuilder When(DateTime controlDate) 
		{
			_controlDate = controlDate;
			return this;
		}
	
		public InterventoAmbControlledResoBuilder By(Guid idUser) 
		{
			_idUser = idUser;
			return this;
		}
	
		public InterventoAmbControlledResoBuilder ForInterventoAppaltatore(string idInterventoAppaltatore) 
		{
			_idInterventoAppaltatore = idInterventoAppaltatore;
			return this;
		}
	
		public InterventoAmbControlledResoBuilder ForDescription(string description) 
		{
			_description = description;
			return this;
		}
	
		public InterventoAmbControlledResoBuilder ForQuantity(int quantity) 
		{
			_quantity = quantity;
			return this;
		}
	
		public InterventoAmbControlledReso Build(Guid id, long version)
		{
			return Build(id, Guid.NewGuid(), version);
		}

		public InterventoAmbControlledReso Build(Guid id, long version,DateTime wakeupTime)
		{
			return Build(id, Guid.NewGuid(), version,wakeupTime);
		}

		public InterventoAmbControlledReso Build(Guid id, Guid commitId, long version)
        {
            return new InterventoAmbControlledReso(id, commitId, version, _note, _workPeriod, _controlDate, _idUser, _idInterventoAppaltatore, _description, _quantity);
		 }

		public InterventoAmbControlledReso Build(Guid id, Guid commitId, long version, DateTime wakeupTime)
        {
            return new InterventoAmbControlledReso(id, commitId, version, wakeupTime, _note, _workPeriod, _controlDate, _idUser, _idInterventoAppaltatore, _description, _quantity);
		 }
        
	
	}
}

namespace Super.Controllo.Events
{
	public static partial class BuildEvt 
	{
		  public static InterventoControlAllowedBuilder InterventoControlAllowed {get { return new InterventoControlAllowedBuilder(); } }
	  		  public static InterventoClosedBuilder InterventoClosed {get { return new InterventoClosedBuilder(); } }
	  		  public static InterventoReopenedBuilder InterventoReopened {get { return new InterventoReopenedBuilder(); } }
	  		  public static InterventoControlledNonResoBuilder InterventoControlledNonReso {get { return new InterventoControlledNonResoBuilder(); } }
	  		  public static InterventoRotControlledResoBuilder InterventoRotControlledReso {get { return new InterventoRotControlledResoBuilder(); } }
	  		  public static InterventoRotManControlledResoBuilder InterventoRotManControlledReso {get { return new InterventoRotManControlledResoBuilder(); } }
	  		  public static InterventoAmbControlledResoBuilder InterventoAmbControlledReso {get { return new InterventoAmbControlledResoBuilder(); } }
	  	}
}
