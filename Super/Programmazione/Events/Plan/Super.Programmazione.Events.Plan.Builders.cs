



using System;
using CommonDomain;
using System.Diagnostics.Contracts;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using Super.Programmazione.Events.Plan;
using Super.Programmazione.Events.Plan.Builders;

namespace Super.Programmazione.Events.Plan.Builders
{


	public class PlanCancelledBuilder : IEventBuilder<PlanCancelled>
	{
	
		public PlanCancelled Build(Guid id, long version)
		{
			return Build(id, Guid.NewGuid(), version);
		}

		public PlanCancelled Build(Guid id, Guid commitId, long version)
        {
            return new PlanCancelled(id, commitId, version);
		 }
        
	
	}

	public class PlanCreatedBuilder : IEventBuilder<PlanCreated>
	{
	 
		private Guid  _idScenario ; 
		private Guid  _idProgramma ;
		public PlanCreatedBuilder ByScenario(Guid idScenario) 
		{
			_idScenario = idScenario;
			return this;
		}
	
		public PlanCreatedBuilder ForProgramma(Guid idProgramma) 
		{
			_idProgramma = idProgramma;
			return this;
		}
	
		public PlanCreated Build(Guid id, long version)
		{
			return Build(id, Guid.NewGuid(), version);
		}

		public PlanCreated Build(Guid id, Guid commitId, long version)
        {
            return new PlanCreated(id, commitId, version, _idScenario, _idProgramma);
		 }
        
	
	}

	public class SchedulazioneRotAddedToPlanBuilder : IEventBuilder<SchedulazioneRotAddedToPlan>
	{
	 
		private Guid  _idSchedulazione ; 
		private Guid  _idProgramma ; 
		private Guid  _idPeriodoProgrammazione ; 
		private Guid  _idCommittente ; 
		private Guid  _idLotto ; 
		private Guid  _idImpianto ; 
		private Guid  _idTipoIntervento ; 
		private Guid  _idAppaltatore ; 
		private Guid  _idCategoriaCommerciale ; 
		private Guid  _idDirezioneRegionale ; 
		private string  _note ; 
		private WorkPeriod  _workPeriod ; 
		private Period  _period ; 
		private string  _convoglio ; 
		private string  _rigaTurnoTreno ; 
		private string  _turnoTreno ; 
		private Treno  _trenoArrivo ; 
		private Treno  _trenoPartenza ; 
		private OggettoRot[]  _oggetti ;
		public SchedulazioneRotAddedToPlanBuilder ForSchedulazione(Guid idSchedulazione) 
		{
			_idSchedulazione = idSchedulazione;
			return this;
		}
	
		public SchedulazioneRotAddedToPlanBuilder ForProgramma(Guid idProgramma) 
		{
			_idProgramma = idProgramma;
			return this;
		}
	
		public SchedulazioneRotAddedToPlanBuilder ForPeriodoProgrammazione(Guid idPeriodoProgrammazione) 
		{
			_idPeriodoProgrammazione = idPeriodoProgrammazione;
			return this;
		}
	
		public SchedulazioneRotAddedToPlanBuilder ForCommittente(Guid idCommittente) 
		{
			_idCommittente = idCommittente;
			return this;
		}
	
		public SchedulazioneRotAddedToPlanBuilder ForLotto(Guid idLotto) 
		{
			_idLotto = idLotto;
			return this;
		}
	
		public SchedulazioneRotAddedToPlanBuilder ForImpianto(Guid idImpianto) 
		{
			_idImpianto = idImpianto;
			return this;
		}
	
		public SchedulazioneRotAddedToPlanBuilder OfTipoIntervento(Guid idTipoIntervento) 
		{
			_idTipoIntervento = idTipoIntervento;
			return this;
		}
	
		public SchedulazioneRotAddedToPlanBuilder ForAppaltatore(Guid idAppaltatore) 
		{
			_idAppaltatore = idAppaltatore;
			return this;
		}
	
		public SchedulazioneRotAddedToPlanBuilder ForCategoriaCommerciale(Guid idCategoriaCommerciale) 
		{
			_idCategoriaCommerciale = idCategoriaCommerciale;
			return this;
		}
	
		public SchedulazioneRotAddedToPlanBuilder ForDirezioneRegionale(Guid idDirezioneRegionale) 
		{
			_idDirezioneRegionale = idDirezioneRegionale;
			return this;
		}
	
		public SchedulazioneRotAddedToPlanBuilder WithNote(string note) 
		{
			_note = note;
			return this;
		}
	
		public SchedulazioneRotAddedToPlanBuilder ForWorkPeriod(WorkPeriod workPeriod) 
		{
			_workPeriod = workPeriod;
			return this;
		}
	
		public SchedulazioneRotAddedToPlanBuilder ForPeriod(Period period) 
		{
			_period = period;
			return this;
		}
	
		public SchedulazioneRotAddedToPlanBuilder ForConvoglio(string convoglio) 
		{
			_convoglio = convoglio;
			return this;
		}
	
		public SchedulazioneRotAddedToPlanBuilder WithRigaTurnoTreno(string rigaTurnoTreno) 
		{
			_rigaTurnoTreno = rigaTurnoTreno;
			return this;
		}
	
		public SchedulazioneRotAddedToPlanBuilder WithTurnoTreno(string turnoTreno) 
		{
			_turnoTreno = turnoTreno;
			return this;
		}
	
		public SchedulazioneRotAddedToPlanBuilder WithTrenoArrivo(Treno trenoArrivo) 
		{
			_trenoArrivo = trenoArrivo;
			return this;
		}
	
		public SchedulazioneRotAddedToPlanBuilder WithTrenoPartenza(Treno trenoPartenza) 
		{
			_trenoPartenza = trenoPartenza;
			return this;
		}
	
		public SchedulazioneRotAddedToPlanBuilder WithOggetti(OggettoRot[] oggetti) 
		{
			_oggetti = oggetti;
			return this;
		}
	
		public SchedulazioneRotAddedToPlan Build(Guid id, long version)
		{
			return Build(id, Guid.NewGuid(), version);
		}

		public SchedulazioneRotAddedToPlan Build(Guid id, Guid commitId, long version)
        {
            return new SchedulazioneRotAddedToPlan(id, commitId, version, _idSchedulazione, _idProgramma, _idPeriodoProgrammazione, _idCommittente, _idLotto, _idImpianto, _idTipoIntervento, _idAppaltatore, _idCategoriaCommerciale, _idDirezioneRegionale, _note, _workPeriod, _period, _convoglio, _rigaTurnoTreno, _turnoTreno, _trenoArrivo, _trenoPartenza, _oggetti);
		 }
        
	
	}

	public class SchedulazioneRotManAddedToPlanBuilder : IEventBuilder<SchedulazioneRotManAddedToPlan>
	{
	 
		private Guid  _idSchedulazione ; 
		private Guid  _idProgramma ; 
		private Guid  _idPeriodoProgrammazione ; 
		private Guid  _idCommittente ; 
		private Guid  _idLotto ; 
		private Guid  _idImpianto ; 
		private Guid  _idTipoIntervento ; 
		private Guid  _idAppaltatore ; 
		private Guid  _idCategoriaCommerciale ; 
		private Guid  _idDirezioneRegionale ; 
		private string  _note ; 
		private WorkPeriod  _workPeriod ; 
		private Period  _period ; 
		private OggettoRotMan[]  _oggetti ;
		public SchedulazioneRotManAddedToPlanBuilder ForSchedulazione(Guid idSchedulazione) 
		{
			_idSchedulazione = idSchedulazione;
			return this;
		}
	
		public SchedulazioneRotManAddedToPlanBuilder ForProgramma(Guid idProgramma) 
		{
			_idProgramma = idProgramma;
			return this;
		}
	
		public SchedulazioneRotManAddedToPlanBuilder ForPeriodoProgrammazione(Guid idPeriodoProgrammazione) 
		{
			_idPeriodoProgrammazione = idPeriodoProgrammazione;
			return this;
		}
	
		public SchedulazioneRotManAddedToPlanBuilder ForCommittente(Guid idCommittente) 
		{
			_idCommittente = idCommittente;
			return this;
		}
	
		public SchedulazioneRotManAddedToPlanBuilder ForLotto(Guid idLotto) 
		{
			_idLotto = idLotto;
			return this;
		}
	
		public SchedulazioneRotManAddedToPlanBuilder ForImpianto(Guid idImpianto) 
		{
			_idImpianto = idImpianto;
			return this;
		}
	
		public SchedulazioneRotManAddedToPlanBuilder OfTipoIntervento(Guid idTipoIntervento) 
		{
			_idTipoIntervento = idTipoIntervento;
			return this;
		}
	
		public SchedulazioneRotManAddedToPlanBuilder ForAppaltatore(Guid idAppaltatore) 
		{
			_idAppaltatore = idAppaltatore;
			return this;
		}
	
		public SchedulazioneRotManAddedToPlanBuilder ForCategoriaCommerciale(Guid idCategoriaCommerciale) 
		{
			_idCategoriaCommerciale = idCategoriaCommerciale;
			return this;
		}
	
		public SchedulazioneRotManAddedToPlanBuilder ForDirezioneRegionale(Guid idDirezioneRegionale) 
		{
			_idDirezioneRegionale = idDirezioneRegionale;
			return this;
		}
	
		public SchedulazioneRotManAddedToPlanBuilder WithNote(string note) 
		{
			_note = note;
			return this;
		}
	
		public SchedulazioneRotManAddedToPlanBuilder ForWorkPeriod(WorkPeriod workPeriod) 
		{
			_workPeriod = workPeriod;
			return this;
		}
	
		public SchedulazioneRotManAddedToPlanBuilder ForPeriod(Period period) 
		{
			_period = period;
			return this;
		}
	
		public SchedulazioneRotManAddedToPlanBuilder WithOggetti(OggettoRotMan[] oggetti) 
		{
			_oggetti = oggetti;
			return this;
		}
	
		public SchedulazioneRotManAddedToPlan Build(Guid id, long version)
		{
			return Build(id, Guid.NewGuid(), version);
		}

		public SchedulazioneRotManAddedToPlan Build(Guid id, Guid commitId, long version)
        {
            return new SchedulazioneRotManAddedToPlan(id, commitId, version, _idSchedulazione, _idProgramma, _idPeriodoProgrammazione, _idCommittente, _idLotto, _idImpianto, _idTipoIntervento, _idAppaltatore, _idCategoriaCommerciale, _idDirezioneRegionale, _note, _workPeriod, _period, _oggetti);
		 }
        
	
	}

	public class SchedulazioneAmbAddedToPlanBuilder : IEventBuilder<SchedulazioneAmbAddedToPlan>
	{
	 
		private Guid  _idSchedulazione ; 
		private Guid  _idProgramma ; 
		private Guid  _idPeriodoProgrammazione ; 
		private Guid  _idCommittente ; 
		private Guid  _idLotto ; 
		private Guid  _idImpianto ; 
		private Guid  _idTipoIntervento ; 
		private Guid  _idAppaltatore ; 
		private Guid  _idCategoriaCommerciale ; 
		private Guid  _idDirezioneRegionale ; 
		private string  _note ; 
		private WorkPeriod  _workPeriod ; 
		private Period  _period ; 
		private int  _quantity ; 
		private string  _description ;
		public SchedulazioneAmbAddedToPlanBuilder ForSchedulazione(Guid idSchedulazione) 
		{
			_idSchedulazione = idSchedulazione;
			return this;
		}
	
		public SchedulazioneAmbAddedToPlanBuilder ForProgramma(Guid idProgramma) 
		{
			_idProgramma = idProgramma;
			return this;
		}
	
		public SchedulazioneAmbAddedToPlanBuilder ForPeriodoProgrammazione(Guid idPeriodoProgrammazione) 
		{
			_idPeriodoProgrammazione = idPeriodoProgrammazione;
			return this;
		}
	
		public SchedulazioneAmbAddedToPlanBuilder ForCommittente(Guid idCommittente) 
		{
			_idCommittente = idCommittente;
			return this;
		}
	
		public SchedulazioneAmbAddedToPlanBuilder ForLotto(Guid idLotto) 
		{
			_idLotto = idLotto;
			return this;
		}
	
		public SchedulazioneAmbAddedToPlanBuilder ForImpianto(Guid idImpianto) 
		{
			_idImpianto = idImpianto;
			return this;
		}
	
		public SchedulazioneAmbAddedToPlanBuilder OfTipoIntervento(Guid idTipoIntervento) 
		{
			_idTipoIntervento = idTipoIntervento;
			return this;
		}
	
		public SchedulazioneAmbAddedToPlanBuilder ForAppaltatore(Guid idAppaltatore) 
		{
			_idAppaltatore = idAppaltatore;
			return this;
		}
	
		public SchedulazioneAmbAddedToPlanBuilder ForCategoriaCommerciale(Guid idCategoriaCommerciale) 
		{
			_idCategoriaCommerciale = idCategoriaCommerciale;
			return this;
		}
	
		public SchedulazioneAmbAddedToPlanBuilder ForDirezioneRegionale(Guid idDirezioneRegionale) 
		{
			_idDirezioneRegionale = idDirezioneRegionale;
			return this;
		}
	
		public SchedulazioneAmbAddedToPlanBuilder WithNote(string note) 
		{
			_note = note;
			return this;
		}
	
		public SchedulazioneAmbAddedToPlanBuilder ForWorkPeriod(WorkPeriod workPeriod) 
		{
			_workPeriod = workPeriod;
			return this;
		}
	
		public SchedulazioneAmbAddedToPlanBuilder ForPeriod(Period period) 
		{
			_period = period;
			return this;
		}
	
		public SchedulazioneAmbAddedToPlanBuilder ForQuantity(int quantity) 
		{
			_quantity = quantity;
			return this;
		}
	
		public SchedulazioneAmbAddedToPlanBuilder ForDescription(string description) 
		{
			_description = description;
			return this;
		}
	
		public SchedulazioneAmbAddedToPlan Build(Guid id, long version)
		{
			return Build(id, Guid.NewGuid(), version);
		}

		public SchedulazioneAmbAddedToPlan Build(Guid id, Guid commitId, long version)
        {
            return new SchedulazioneAmbAddedToPlan(id, commitId, version, _idSchedulazione, _idProgramma, _idPeriodoProgrammazione, _idCommittente, _idLotto, _idImpianto, _idTipoIntervento, _idAppaltatore, _idCategoriaCommerciale, _idDirezioneRegionale, _note, _workPeriod, _period, _quantity, _description);
		 }
        
	
	}

	public class SchedulazioneCancelledFromPlanBuilder : IEventBuilder<SchedulazioneCancelledFromPlan>
	{
	 
		private Guid  _idUser ; 
		private Guid  _deleteGeneratedInterventoToo ;
		public SchedulazioneCancelledFromPlanBuilder ByUser(Guid idUser) 
		{
			_idUser = idUser;
			return this;
		}
	
		public SchedulazioneCancelledFromPlanBuilder AndDeleteGeneratedInterventoToo(Guid deleteGeneratedInterventoToo) 
		{
			_deleteGeneratedInterventoToo = deleteGeneratedInterventoToo;
			return this;
		}
	
		public SchedulazioneCancelledFromPlan Build(Guid id, long version)
		{
			return Build(id, Guid.NewGuid(), version);
		}

		public SchedulazioneCancelledFromPlan Build(Guid id, Guid commitId, long version)
        {
            return new SchedulazioneCancelledFromPlan(id, commitId, version, _idUser, _deleteGeneratedInterventoToo);
		 }
        
	
	}
}

namespace Super.Programmazione.Events
{
	public static partial class BuildEvt 
	{
		  public static PlanCancelledBuilder PlanCancelled {get { return new PlanCancelledBuilder(); } }
	  		  public static PlanCreatedBuilder PlanCreated {get { return new PlanCreatedBuilder(); } }
	  		  public static SchedulazioneRotAddedToPlanBuilder SchedulazioneRotAddedToPlan {get { return new SchedulazioneRotAddedToPlanBuilder(); } }
	  		  public static SchedulazioneRotManAddedToPlanBuilder SchedulazioneRotManAddedToPlan {get { return new SchedulazioneRotManAddedToPlanBuilder(); } }
	  		  public static SchedulazioneAmbAddedToPlanBuilder SchedulazioneAmbAddedToPlan {get { return new SchedulazioneAmbAddedToPlanBuilder(); } }
	  		  public static SchedulazioneCancelledFromPlanBuilder SchedulazioneCancelledFromPlan {get { return new SchedulazioneCancelledFromPlanBuilder(); } }
	  	}
}
