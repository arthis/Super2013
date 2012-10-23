


using System;
using CommonDomain;
using System.Diagnostics.Contracts;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using Super.Programmazione.Commands.Scenario;
using Super.Programmazione.Commands.Scenario.Builders;

namespace Super.Programmazione.Commands.Scenario.Builders
{


	public class AddSchedulazioneRotToScenarioBuilder : ICommandBuilder<AddSchedulazioneRotToScenario>
	{
	 
		private Guid  _idPeriodoProgrammazione ; 
		private Guid  _idSchedulazione ; 
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
		public AddSchedulazioneRotToScenarioBuilder ForPeriodoProgrammazione(Guid idPeriodoProgrammazione) 
		{
			_idPeriodoProgrammazione = idPeriodoProgrammazione;
			return this;
		}
	
		public AddSchedulazioneRotToScenarioBuilder ForSchedulazione(Guid idSchedulazione) 
		{
			_idSchedulazione = idSchedulazione;
			return this;
		}
	
		public AddSchedulazioneRotToScenarioBuilder ForCommittente(Guid idCommittente) 
		{
			_idCommittente = idCommittente;
			return this;
		}
	
		public AddSchedulazioneRotToScenarioBuilder ForLotto(Guid idLotto) 
		{
			_idLotto = idLotto;
			return this;
		}
	
		public AddSchedulazioneRotToScenarioBuilder ForImpianto(Guid idImpianto) 
		{
			_idImpianto = idImpianto;
			return this;
		}
	
		public AddSchedulazioneRotToScenarioBuilder OfTipoIntervento(Guid idTipoIntervento) 
		{
			_idTipoIntervento = idTipoIntervento;
			return this;
		}
	
		public AddSchedulazioneRotToScenarioBuilder ForAppaltatore(Guid idAppaltatore) 
		{
			_idAppaltatore = idAppaltatore;
			return this;
		}
	
		public AddSchedulazioneRotToScenarioBuilder ForCategoriaCommerciale(Guid idCategoriaCommerciale) 
		{
			_idCategoriaCommerciale = idCategoriaCommerciale;
			return this;
		}
	
		public AddSchedulazioneRotToScenarioBuilder ForDirezioneRegionale(Guid idDirezioneRegionale) 
		{
			_idDirezioneRegionale = idDirezioneRegionale;
			return this;
		}
	
		public AddSchedulazioneRotToScenarioBuilder WithNote(string note) 
		{
			_note = note;
			return this;
		}
	
		public AddSchedulazioneRotToScenarioBuilder ForWorkPeriod(WorkPeriod workPeriod) 
		{
			_workPeriod = workPeriod;
			return this;
		}
	
		public AddSchedulazioneRotToScenarioBuilder ForPeriod(Period period) 
		{
			_period = period;
			return this;
		}
	
		public AddSchedulazioneRotToScenarioBuilder ForConvoglio(string convoglio) 
		{
			_convoglio = convoglio;
			return this;
		}
	
		public AddSchedulazioneRotToScenarioBuilder WithRigaTurnoTreno(string rigaTurnoTreno) 
		{
			_rigaTurnoTreno = rigaTurnoTreno;
			return this;
		}
	
		public AddSchedulazioneRotToScenarioBuilder WithTurnoTreno(string turnoTreno) 
		{
			_turnoTreno = turnoTreno;
			return this;
		}
	
		public AddSchedulazioneRotToScenarioBuilder WithTrenoArrivo(Treno trenoArrivo) 
		{
			_trenoArrivo = trenoArrivo;
			return this;
		}
	
		public AddSchedulazioneRotToScenarioBuilder WithTrenoPartenza(Treno trenoPartenza) 
		{
			_trenoPartenza = trenoPartenza;
			return this;
		}
	
		public AddSchedulazioneRotToScenarioBuilder WithOggetti(OggettoRot[] oggetti) 
		{
			_oggetti = oggetti;
			return this;
		}
	
		
		public AddSchedulazioneRotToScenario Build(Guid id)
		{
			return Build(id, Guid.NewGuid());
		}

		public AddSchedulazioneRotToScenario Build(Guid id, Guid commitId)
        {
            return new AddSchedulazioneRotToScenario(id, commitId, _idPeriodoProgrammazione, _idSchedulazione, _idCommittente, _idLotto, _idImpianto, _idTipoIntervento, _idAppaltatore, _idCategoriaCommerciale, _idDirezioneRegionale, _note, _workPeriod, _period, _convoglio, _rigaTurnoTreno, _turnoTreno, _trenoArrivo, _trenoPartenza, _oggetti);
		 }


		
		public AddSchedulazioneRotToScenario Build(Guid id, long version)
		{
			return Build(id, Guid.NewGuid(), version);
		}

		public AddSchedulazioneRotToScenario Build(Guid id, Guid commitId, long version)
        {
            return new AddSchedulazioneRotToScenario(id, commitId, version, _idPeriodoProgrammazione, _idSchedulazione, _idCommittente, _idLotto, _idImpianto, _idTipoIntervento, _idAppaltatore, _idCategoriaCommerciale, _idDirezioneRegionale, _note, _workPeriod, _period, _convoglio, _rigaTurnoTreno, _turnoTreno, _trenoArrivo, _trenoPartenza, _oggetti);
		 }

		public AddSchedulazioneRotToScenario Build(Guid id, DateTime wakeupTime)
		{
			return Build(id, Guid.NewGuid(), wakeupTime);
		}

		public AddSchedulazioneRotToScenario Build(Guid id, Guid commitId, DateTime wakeupTime)
        {
            return new AddSchedulazioneRotToScenario(id, commitId, wakeupTime, _idPeriodoProgrammazione, _idSchedulazione, _idCommittente, _idLotto, _idImpianto, _idTipoIntervento, _idAppaltatore, _idCategoriaCommerciale, _idDirezioneRegionale, _note, _workPeriod, _period, _convoglio, _rigaTurnoTreno, _turnoTreno, _trenoArrivo, _trenoPartenza, _oggetti);
		 }

		public AddSchedulazioneRotToScenario Build(Guid id, long version,DateTime wakeupTime)
		{
			return Build(id, Guid.NewGuid(), version,wakeupTime);
		}
		 

		public AddSchedulazioneRotToScenario Build(Guid id, Guid commitId, long version, DateTime wakeupTime)
        {
            return new AddSchedulazioneRotToScenario(id, commitId, version, wakeupTime, _idPeriodoProgrammazione, _idSchedulazione, _idCommittente, _idLotto, _idImpianto, _idTipoIntervento, _idAppaltatore, _idCategoriaCommerciale, _idDirezioneRegionale, _note, _workPeriod, _period, _convoglio, _rigaTurnoTreno, _turnoTreno, _trenoArrivo, _trenoPartenza, _oggetti);
		 }
        
	
	}

	public class AddSchedulazioneRotManToScenarioBuilder : ICommandBuilder<AddSchedulazioneRotManToScenario>
	{
	 
		private Guid  _idPeriodoProgrammazione ; 
		private Guid  _idSchedulazione ; 
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
		public AddSchedulazioneRotManToScenarioBuilder ForPeriodoProgrammazione(Guid idPeriodoProgrammazione) 
		{
			_idPeriodoProgrammazione = idPeriodoProgrammazione;
			return this;
		}
	
		public AddSchedulazioneRotManToScenarioBuilder ForSchedulazione(Guid idSchedulazione) 
		{
			_idSchedulazione = idSchedulazione;
			return this;
		}
	
		public AddSchedulazioneRotManToScenarioBuilder ForCommittente(Guid idCommittente) 
		{
			_idCommittente = idCommittente;
			return this;
		}
	
		public AddSchedulazioneRotManToScenarioBuilder ForLotto(Guid idLotto) 
		{
			_idLotto = idLotto;
			return this;
		}
	
		public AddSchedulazioneRotManToScenarioBuilder ForImpianto(Guid idImpianto) 
		{
			_idImpianto = idImpianto;
			return this;
		}
	
		public AddSchedulazioneRotManToScenarioBuilder OfTipoIntervento(Guid idTipoIntervento) 
		{
			_idTipoIntervento = idTipoIntervento;
			return this;
		}
	
		public AddSchedulazioneRotManToScenarioBuilder ForAppaltatore(Guid idAppaltatore) 
		{
			_idAppaltatore = idAppaltatore;
			return this;
		}
	
		public AddSchedulazioneRotManToScenarioBuilder ForCategoriaCommerciale(Guid idCategoriaCommerciale) 
		{
			_idCategoriaCommerciale = idCategoriaCommerciale;
			return this;
		}
	
		public AddSchedulazioneRotManToScenarioBuilder ForDirezioneRegionale(Guid idDirezioneRegionale) 
		{
			_idDirezioneRegionale = idDirezioneRegionale;
			return this;
		}
	
		public AddSchedulazioneRotManToScenarioBuilder WithNote(string note) 
		{
			_note = note;
			return this;
		}
	
		public AddSchedulazioneRotManToScenarioBuilder ForWorkPeriod(WorkPeriod workPeriod) 
		{
			_workPeriod = workPeriod;
			return this;
		}
	
		public AddSchedulazioneRotManToScenarioBuilder ForPeriod(Period period) 
		{
			_period = period;
			return this;
		}
	
		public AddSchedulazioneRotManToScenarioBuilder WithOggetti(OggettoRotMan[] oggetti) 
		{
			_oggetti = oggetti;
			return this;
		}
	
		
		public AddSchedulazioneRotManToScenario Build(Guid id)
		{
			return Build(id, Guid.NewGuid());
		}

		public AddSchedulazioneRotManToScenario Build(Guid id, Guid commitId)
        {
            return new AddSchedulazioneRotManToScenario(id, commitId, _idPeriodoProgrammazione, _idSchedulazione, _idCommittente, _idLotto, _idImpianto, _idTipoIntervento, _idAppaltatore, _idCategoriaCommerciale, _idDirezioneRegionale, _note, _workPeriod, _period, _oggetti);
		 }


		
		public AddSchedulazioneRotManToScenario Build(Guid id, long version)
		{
			return Build(id, Guid.NewGuid(), version);
		}

		public AddSchedulazioneRotManToScenario Build(Guid id, Guid commitId, long version)
        {
            return new AddSchedulazioneRotManToScenario(id, commitId, version, _idPeriodoProgrammazione, _idSchedulazione, _idCommittente, _idLotto, _idImpianto, _idTipoIntervento, _idAppaltatore, _idCategoriaCommerciale, _idDirezioneRegionale, _note, _workPeriod, _period, _oggetti);
		 }

		public AddSchedulazioneRotManToScenario Build(Guid id, DateTime wakeupTime)
		{
			return Build(id, Guid.NewGuid(), wakeupTime);
		}

		public AddSchedulazioneRotManToScenario Build(Guid id, Guid commitId, DateTime wakeupTime)
        {
            return new AddSchedulazioneRotManToScenario(id, commitId, wakeupTime, _idPeriodoProgrammazione, _idSchedulazione, _idCommittente, _idLotto, _idImpianto, _idTipoIntervento, _idAppaltatore, _idCategoriaCommerciale, _idDirezioneRegionale, _note, _workPeriod, _period, _oggetti);
		 }

		public AddSchedulazioneRotManToScenario Build(Guid id, long version,DateTime wakeupTime)
		{
			return Build(id, Guid.NewGuid(), version,wakeupTime);
		}
		 

		public AddSchedulazioneRotManToScenario Build(Guid id, Guid commitId, long version, DateTime wakeupTime)
        {
            return new AddSchedulazioneRotManToScenario(id, commitId, version, wakeupTime, _idPeriodoProgrammazione, _idSchedulazione, _idCommittente, _idLotto, _idImpianto, _idTipoIntervento, _idAppaltatore, _idCategoriaCommerciale, _idDirezioneRegionale, _note, _workPeriod, _period, _oggetti);
		 }
        
	
	}

	public class AddSchedulazioneAmbToScenarioBuilder : ICommandBuilder<AddSchedulazioneAmbToScenario>
	{
	 
		private Guid  _idPeriodoProgrammazione ; 
		private Guid  _idSchedulazione ; 
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
		public AddSchedulazioneAmbToScenarioBuilder ForPeriodoProgrammazione(Guid idPeriodoProgrammazione) 
		{
			_idPeriodoProgrammazione = idPeriodoProgrammazione;
			return this;
		}
	
		public AddSchedulazioneAmbToScenarioBuilder ForSchedulazione(Guid idSchedulazione) 
		{
			_idSchedulazione = idSchedulazione;
			return this;
		}
	
		public AddSchedulazioneAmbToScenarioBuilder ForCommittente(Guid idCommittente) 
		{
			_idCommittente = idCommittente;
			return this;
		}
	
		public AddSchedulazioneAmbToScenarioBuilder ForLotto(Guid idLotto) 
		{
			_idLotto = idLotto;
			return this;
		}
	
		public AddSchedulazioneAmbToScenarioBuilder ForImpianto(Guid idImpianto) 
		{
			_idImpianto = idImpianto;
			return this;
		}
	
		public AddSchedulazioneAmbToScenarioBuilder OfTipoIntervento(Guid idTipoIntervento) 
		{
			_idTipoIntervento = idTipoIntervento;
			return this;
		}
	
		public AddSchedulazioneAmbToScenarioBuilder ForAppaltatore(Guid idAppaltatore) 
		{
			_idAppaltatore = idAppaltatore;
			return this;
		}
	
		public AddSchedulazioneAmbToScenarioBuilder ForCategoriaCommerciale(Guid idCategoriaCommerciale) 
		{
			_idCategoriaCommerciale = idCategoriaCommerciale;
			return this;
		}
	
		public AddSchedulazioneAmbToScenarioBuilder ForDirezioneRegionale(Guid idDirezioneRegionale) 
		{
			_idDirezioneRegionale = idDirezioneRegionale;
			return this;
		}
	
		public AddSchedulazioneAmbToScenarioBuilder WithNote(string note) 
		{
			_note = note;
			return this;
		}
	
		public AddSchedulazioneAmbToScenarioBuilder ForWorkPeriod(WorkPeriod workPeriod) 
		{
			_workPeriod = workPeriod;
			return this;
		}
	
		public AddSchedulazioneAmbToScenarioBuilder ForPeriod(Period period) 
		{
			_period = period;
			return this;
		}
	
		public AddSchedulazioneAmbToScenarioBuilder ForQuantity(int quantity) 
		{
			_quantity = quantity;
			return this;
		}
	
		public AddSchedulazioneAmbToScenarioBuilder ForDescription(string description) 
		{
			_description = description;
			return this;
		}
	
		
		public AddSchedulazioneAmbToScenario Build(Guid id)
		{
			return Build(id, Guid.NewGuid());
		}

		public AddSchedulazioneAmbToScenario Build(Guid id, Guid commitId)
        {
            return new AddSchedulazioneAmbToScenario(id, commitId, _idPeriodoProgrammazione, _idSchedulazione, _idCommittente, _idLotto, _idImpianto, _idTipoIntervento, _idAppaltatore, _idCategoriaCommerciale, _idDirezioneRegionale, _note, _workPeriod, _period, _quantity, _description);
		 }


		
		public AddSchedulazioneAmbToScenario Build(Guid id, long version)
		{
			return Build(id, Guid.NewGuid(), version);
		}

		public AddSchedulazioneAmbToScenario Build(Guid id, Guid commitId, long version)
        {
            return new AddSchedulazioneAmbToScenario(id, commitId, version, _idPeriodoProgrammazione, _idSchedulazione, _idCommittente, _idLotto, _idImpianto, _idTipoIntervento, _idAppaltatore, _idCategoriaCommerciale, _idDirezioneRegionale, _note, _workPeriod, _period, _quantity, _description);
		 }

		public AddSchedulazioneAmbToScenario Build(Guid id, DateTime wakeupTime)
		{
			return Build(id, Guid.NewGuid(), wakeupTime);
		}

		public AddSchedulazioneAmbToScenario Build(Guid id, Guid commitId, DateTime wakeupTime)
        {
            return new AddSchedulazioneAmbToScenario(id, commitId, wakeupTime, _idPeriodoProgrammazione, _idSchedulazione, _idCommittente, _idLotto, _idImpianto, _idTipoIntervento, _idAppaltatore, _idCategoriaCommerciale, _idDirezioneRegionale, _note, _workPeriod, _period, _quantity, _description);
		 }

		public AddSchedulazioneAmbToScenario Build(Guid id, long version,DateTime wakeupTime)
		{
			return Build(id, Guid.NewGuid(), version,wakeupTime);
		}
		 

		public AddSchedulazioneAmbToScenario Build(Guid id, Guid commitId, long version, DateTime wakeupTime)
        {
            return new AddSchedulazioneAmbToScenario(id, commitId, version, wakeupTime, _idPeriodoProgrammazione, _idSchedulazione, _idCommittente, _idLotto, _idImpianto, _idTipoIntervento, _idAppaltatore, _idCategoriaCommerciale, _idDirezioneRegionale, _note, _workPeriod, _period, _quantity, _description);
		 }
        
	
	}

	public class CreateScenarioBuilder : ICommandBuilder<CreateScenario>
	{
	 
		private string  _description ; 
		private Guid  _idProgramma ;
		public CreateScenarioBuilder WithDescription(string description) 
		{
			_description = description;
			return this;
		}
	
		public CreateScenarioBuilder WithProgramma(Guid idProgramma) 
		{
			_idProgramma = idProgramma;
			return this;
		}
	
		
		public CreateScenario Build(Guid id)
		{
			return Build(id, Guid.NewGuid());
		}

		public CreateScenario Build(Guid id, Guid commitId)
        {
            return new CreateScenario(id, commitId, _description, _idProgramma);
		 }


		
		public CreateScenario Build(Guid id, long version)
		{
			return Build(id, Guid.NewGuid(), version);
		}

		public CreateScenario Build(Guid id, Guid commitId, long version)
        {
            return new CreateScenario(id, commitId, version, _description, _idProgramma);
		 }

		public CreateScenario Build(Guid id, DateTime wakeupTime)
		{
			return Build(id, Guid.NewGuid(), wakeupTime);
		}

		public CreateScenario Build(Guid id, Guid commitId, DateTime wakeupTime)
        {
            return new CreateScenario(id, commitId, wakeupTime, _description, _idProgramma);
		 }

		public CreateScenario Build(Guid id, long version,DateTime wakeupTime)
		{
			return Build(id, Guid.NewGuid(), version,wakeupTime);
		}
		 

		public CreateScenario Build(Guid id, Guid commitId, long version, DateTime wakeupTime)
        {
            return new CreateScenario(id, commitId, version, wakeupTime, _description, _idProgramma);
		 }
        
	
	}

	public class CancelScenarioBuilder : ICommandBuilder<CancelScenario>
	{
	
		
		public CancelScenario Build(Guid id)
		{
			return Build(id, Guid.NewGuid());
		}

		public CancelScenario Build(Guid id, Guid commitId)
        {
            return new CancelScenario(id, commitId);
		 }


		
		public CancelScenario Build(Guid id, long version)
		{
			return Build(id, Guid.NewGuid(), version);
		}

		public CancelScenario Build(Guid id, Guid commitId, long version)
        {
            return new CancelScenario(id, commitId, version);
		 }

		public CancelScenario Build(Guid id, DateTime wakeupTime)
		{
			return Build(id, Guid.NewGuid(), wakeupTime);
		}

		public CancelScenario Build(Guid id, Guid commitId, DateTime wakeupTime)
        {
            return new CancelScenario(id, commitId, wakeupTime);
		 }

		public CancelScenario Build(Guid id, long version,DateTime wakeupTime)
		{
			return Build(id, Guid.NewGuid(), version,wakeupTime);
		}
		 

		public CancelScenario Build(Guid id, Guid commitId, long version, DateTime wakeupTime)
        {
            return new CancelScenario(id, commitId, version, wakeupTime);
		 }
        
	
	}

	public class ChangeDescriptionScenarioBuilder : ICommandBuilder<ChangeDescriptionScenario>
	{
	 
		private string  _description ;
		public ChangeDescriptionScenarioBuilder ForDescription(string description) 
		{
			_description = description;
			return this;
		}
	
		
		public ChangeDescriptionScenario Build(Guid id)
		{
			return Build(id, Guid.NewGuid());
		}

		public ChangeDescriptionScenario Build(Guid id, Guid commitId)
        {
            return new ChangeDescriptionScenario(id, commitId, _description);
		 }


		
		public ChangeDescriptionScenario Build(Guid id, long version)
		{
			return Build(id, Guid.NewGuid(), version);
		}

		public ChangeDescriptionScenario Build(Guid id, Guid commitId, long version)
        {
            return new ChangeDescriptionScenario(id, commitId, version, _description);
		 }

		public ChangeDescriptionScenario Build(Guid id, DateTime wakeupTime)
		{
			return Build(id, Guid.NewGuid(), wakeupTime);
		}

		public ChangeDescriptionScenario Build(Guid id, Guid commitId, DateTime wakeupTime)
        {
            return new ChangeDescriptionScenario(id, commitId, wakeupTime, _description);
		 }

		public ChangeDescriptionScenario Build(Guid id, long version,DateTime wakeupTime)
		{
			return Build(id, Guid.NewGuid(), version,wakeupTime);
		}
		 

		public ChangeDescriptionScenario Build(Guid id, Guid commitId, long version, DateTime wakeupTime)
        {
            return new ChangeDescriptionScenario(id, commitId, version, wakeupTime, _description);
		 }
        
	
	}

	public class PromoteScenarioToPlanBuilder : ICommandBuilder<PromoteScenarioToPlan>
	{
	 
		private DateTime  _promotionDate ; 
		private Guid  _idPlan ;
		public PromoteScenarioToPlanBuilder WhenPromotionDate(DateTime promotionDate) 
		{
			_promotionDate = promotionDate;
			return this;
		}
	
		public PromoteScenarioToPlanBuilder ForPlan(Guid idPlan) 
		{
			_idPlan = idPlan;
			return this;
		}
	
		
		public PromoteScenarioToPlan Build(Guid id)
		{
			return Build(id, Guid.NewGuid());
		}

		public PromoteScenarioToPlan Build(Guid id, Guid commitId)
        {
            return new PromoteScenarioToPlan(id, commitId, _promotionDate, _idPlan);
		 }


		
		public PromoteScenarioToPlan Build(Guid id, long version)
		{
			return Build(id, Guid.NewGuid(), version);
		}

		public PromoteScenarioToPlan Build(Guid id, Guid commitId, long version)
        {
            return new PromoteScenarioToPlan(id, commitId, version, _promotionDate, _idPlan);
		 }

		public PromoteScenarioToPlan Build(Guid id, DateTime wakeupTime)
		{
			return Build(id, Guid.NewGuid(), wakeupTime);
		}

		public PromoteScenarioToPlan Build(Guid id, Guid commitId, DateTime wakeupTime)
        {
            return new PromoteScenarioToPlan(id, commitId, wakeupTime, _promotionDate, _idPlan);
		 }

		public PromoteScenarioToPlan Build(Guid id, long version,DateTime wakeupTime)
		{
			return Build(id, Guid.NewGuid(), version,wakeupTime);
		}
		 

		public PromoteScenarioToPlan Build(Guid id, Guid commitId, long version, DateTime wakeupTime)
        {
            return new PromoteScenarioToPlan(id, commitId, version, wakeupTime, _promotionDate, _idPlan);
		 }
        
	
	}
}

namespace Super.Programmazione.Commands
{
	public static partial class BuildCmd 
	{
		  public static AddSchedulazioneRotToScenarioBuilder AddSchedulazioneRotToScenario {get { return new AddSchedulazioneRotToScenarioBuilder(); } }
	  		  public static AddSchedulazioneRotManToScenarioBuilder AddSchedulazioneRotManToScenario {get { return new AddSchedulazioneRotManToScenarioBuilder(); } }
	  		  public static AddSchedulazioneAmbToScenarioBuilder AddSchedulazioneAmbToScenario {get { return new AddSchedulazioneAmbToScenarioBuilder(); } }
	  		  public static CreateScenarioBuilder CreateScenario {get { return new CreateScenarioBuilder(); } }
	  		  public static CancelScenarioBuilder CancelScenario {get { return new CancelScenarioBuilder(); } }
	  		  public static ChangeDescriptionScenarioBuilder ChangeDescriptionScenario {get { return new ChangeDescriptionScenarioBuilder(); } }
	  		  public static PromoteScenarioToPlanBuilder PromoteScenarioToPlan {get { return new PromoteScenarioToPlanBuilder(); } }
	  	}
}
