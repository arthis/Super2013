



using System;
using CommonDomain;
using System.Diagnostics.Contracts;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using Super.Programmazione.Commands.Plan;
using Super.Programmazione.Commands.Plan.Builders;

namespace Super.Programmazione.Commands.Plan.Builders
{


	public class CancelPlanBuilder : ICommandBuilder<CancelPlan>
	{
	
		
		public CancelPlan Build(Guid id)
		{
			return Build(id, Guid.NewGuid());
		}

		public CancelPlan Build(Guid id, Guid commitId)
        {
            return new CancelPlan(id, commitId);
		 }


		
		public CancelPlan Build(Guid id, long version)
		{
			return Build(id, Guid.NewGuid(), version);
		}

		public CancelPlan Build(Guid id, Guid commitId, long version)
        {
            return new CancelPlan(id, commitId, version);
		 }

		public CancelPlan Build(Guid id, DateTime wakeupTime)
		{
			return Build(id, Guid.NewGuid(), wakeupTime);
		}

		public CancelPlan Build(Guid id, Guid commitId, DateTime wakeupTime)
        {
            return new CancelPlan(id, commitId, wakeupTime);
		 }




		public CancelPlan Build(Guid id, long version,DateTime wakeupTime)
		{
			return Build(id, Guid.NewGuid(), version,wakeupTime);
		}
		 

		public CancelPlan Build(Guid id, Guid commitId, long version, DateTime wakeupTime)
        {
            return new CancelPlan(id, commitId, version, wakeupTime);
		 }
        
	
	}

	public class CreatePlanFromPromotedScenarioBuilder : ICommandBuilder<CreatePlanFromPromotedScenario>
	{
	 
		private Guid  _idScenario ;
		public CreatePlanFromPromotedScenarioBuilder FromScenario(Guid idScenario) 
		{
			_idScenario = idScenario;
			return this;
		}
	
		
		public CreatePlanFromPromotedScenario Build(Guid id)
		{
			return Build(id, Guid.NewGuid());
		}

		public CreatePlanFromPromotedScenario Build(Guid id, Guid commitId)
        {
            return new CreatePlanFromPromotedScenario(id, commitId, _idScenario);
		 }


		
		public CreatePlanFromPromotedScenario Build(Guid id, long version)
		{
			return Build(id, Guid.NewGuid(), version);
		}

		public CreatePlanFromPromotedScenario Build(Guid id, Guid commitId, long version)
        {
            return new CreatePlanFromPromotedScenario(id, commitId, version, _idScenario);
		 }

		public CreatePlanFromPromotedScenario Build(Guid id, DateTime wakeupTime)
		{
			return Build(id, Guid.NewGuid(), wakeupTime);
		}

		public CreatePlanFromPromotedScenario Build(Guid id, Guid commitId, DateTime wakeupTime)
        {
            return new CreatePlanFromPromotedScenario(id, commitId, wakeupTime, _idScenario);
		 }




		public CreatePlanFromPromotedScenario Build(Guid id, long version,DateTime wakeupTime)
		{
			return Build(id, Guid.NewGuid(), version,wakeupTime);
		}
		 

		public CreatePlanFromPromotedScenario Build(Guid id, Guid commitId, long version, DateTime wakeupTime)
        {
            return new CreatePlanFromPromotedScenario(id, commitId, version, wakeupTime, _idScenario);
		 }
        
	
	}

	public class AddSchedulazioneRotToPlanBuilder : ICommandBuilder<AddSchedulazioneRotToPlan>
	{
	 
		private Guid  _idProgramma ; 
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
		public AddSchedulazioneRotToPlanBuilder ForProgramma(Guid idProgramma) 
		{
			_idProgramma = idProgramma;
			return this;
		}
	
		public AddSchedulazioneRotToPlanBuilder ForPeriodoProgrammazione(Guid idPeriodoProgrammazione) 
		{
			_idPeriodoProgrammazione = idPeriodoProgrammazione;
			return this;
		}
	
		public AddSchedulazioneRotToPlanBuilder ForSchedulazione(Guid idSchedulazione) 
		{
			_idSchedulazione = idSchedulazione;
			return this;
		}
	
		public AddSchedulazioneRotToPlanBuilder ForCommittente(Guid idCommittente) 
		{
			_idCommittente = idCommittente;
			return this;
		}
	
		public AddSchedulazioneRotToPlanBuilder ForLotto(Guid idLotto) 
		{
			_idLotto = idLotto;
			return this;
		}
	
		public AddSchedulazioneRotToPlanBuilder ForImpianto(Guid idImpianto) 
		{
			_idImpianto = idImpianto;
			return this;
		}
	
		public AddSchedulazioneRotToPlanBuilder OfTipoIntervento(Guid idTipoIntervento) 
		{
			_idTipoIntervento = idTipoIntervento;
			return this;
		}
	
		public AddSchedulazioneRotToPlanBuilder ForAppaltatore(Guid idAppaltatore) 
		{
			_idAppaltatore = idAppaltatore;
			return this;
		}
	
		public AddSchedulazioneRotToPlanBuilder ForCategoriaCommerciale(Guid idCategoriaCommerciale) 
		{
			_idCategoriaCommerciale = idCategoriaCommerciale;
			return this;
		}
	
		public AddSchedulazioneRotToPlanBuilder ForDirezioneRegionale(Guid idDirezioneRegionale) 
		{
			_idDirezioneRegionale = idDirezioneRegionale;
			return this;
		}
	
		public AddSchedulazioneRotToPlanBuilder WithNote(string note) 
		{
			_note = note;
			return this;
		}
	
		public AddSchedulazioneRotToPlanBuilder ForWorkPeriod(WorkPeriod workPeriod) 
		{
			_workPeriod = workPeriod;
			return this;
		}
	
		public AddSchedulazioneRotToPlanBuilder ForPeriod(Period period) 
		{
			_period = period;
			return this;
		}
	
		public AddSchedulazioneRotToPlanBuilder ForConvoglio(string convoglio) 
		{
			_convoglio = convoglio;
			return this;
		}
	
		public AddSchedulazioneRotToPlanBuilder WithRigaTurnoTreno(string rigaTurnoTreno) 
		{
			_rigaTurnoTreno = rigaTurnoTreno;
			return this;
		}
	
		public AddSchedulazioneRotToPlanBuilder WithTurnoTreno(string turnoTreno) 
		{
			_turnoTreno = turnoTreno;
			return this;
		}
	
		public AddSchedulazioneRotToPlanBuilder WithTrenoArrivo(Treno trenoArrivo) 
		{
			_trenoArrivo = trenoArrivo;
			return this;
		}
	
		public AddSchedulazioneRotToPlanBuilder WithTrenoPartenza(Treno trenoPartenza) 
		{
			_trenoPartenza = trenoPartenza;
			return this;
		}
	
		public AddSchedulazioneRotToPlanBuilder WithOggetti(OggettoRot[] oggetti) 
		{
			_oggetti = oggetti;
			return this;
		}
	
		
		public AddSchedulazioneRotToPlan Build(Guid id)
		{
			return Build(id, Guid.NewGuid());
		}

		public AddSchedulazioneRotToPlan Build(Guid id, Guid commitId)
        {
            return new AddSchedulazioneRotToPlan(id, commitId, _idProgramma, _idPeriodoProgrammazione, _idSchedulazione, _idCommittente, _idLotto, _idImpianto, _idTipoIntervento, _idAppaltatore, _idCategoriaCommerciale, _idDirezioneRegionale, _note, _workPeriod, _period, _convoglio, _rigaTurnoTreno, _turnoTreno, _trenoArrivo, _trenoPartenza, _oggetti);
		 }


		
		public AddSchedulazioneRotToPlan Build(Guid id, long version)
		{
			return Build(id, Guid.NewGuid(), version);
		}

		public AddSchedulazioneRotToPlan Build(Guid id, Guid commitId, long version)
        {
            return new AddSchedulazioneRotToPlan(id, commitId, version, _idProgramma, _idPeriodoProgrammazione, _idSchedulazione, _idCommittente, _idLotto, _idImpianto, _idTipoIntervento, _idAppaltatore, _idCategoriaCommerciale, _idDirezioneRegionale, _note, _workPeriod, _period, _convoglio, _rigaTurnoTreno, _turnoTreno, _trenoArrivo, _trenoPartenza, _oggetti);
		 }

		public AddSchedulazioneRotToPlan Build(Guid id, DateTime wakeupTime)
		{
			return Build(id, Guid.NewGuid(), wakeupTime);
		}

		public AddSchedulazioneRotToPlan Build(Guid id, Guid commitId, DateTime wakeupTime)
        {
            return new AddSchedulazioneRotToPlan(id, commitId, wakeupTime, _idProgramma, _idPeriodoProgrammazione, _idSchedulazione, _idCommittente, _idLotto, _idImpianto, _idTipoIntervento, _idAppaltatore, _idCategoriaCommerciale, _idDirezioneRegionale, _note, _workPeriod, _period, _convoglio, _rigaTurnoTreno, _turnoTreno, _trenoArrivo, _trenoPartenza, _oggetti);
		 }




		public AddSchedulazioneRotToPlan Build(Guid id, long version,DateTime wakeupTime)
		{
			return Build(id, Guid.NewGuid(), version,wakeupTime);
		}
		 

		public AddSchedulazioneRotToPlan Build(Guid id, Guid commitId, long version, DateTime wakeupTime)
        {
            return new AddSchedulazioneRotToPlan(id, commitId, version, wakeupTime, _idProgramma, _idPeriodoProgrammazione, _idSchedulazione, _idCommittente, _idLotto, _idImpianto, _idTipoIntervento, _idAppaltatore, _idCategoriaCommerciale, _idDirezioneRegionale, _note, _workPeriod, _period, _convoglio, _rigaTurnoTreno, _turnoTreno, _trenoArrivo, _trenoPartenza, _oggetti);
		 }
        
	
	}

	public class AddSchedulazioneRotManToPlanBuilder : ICommandBuilder<AddSchedulazioneRotManToPlan>
	{
	 
		private Guid  _idProgramma ; 
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
		public AddSchedulazioneRotManToPlanBuilder ForProgramma(Guid idProgramma) 
		{
			_idProgramma = idProgramma;
			return this;
		}
	
		public AddSchedulazioneRotManToPlanBuilder ForPeriodoProgrammazione(Guid idPeriodoProgrammazione) 
		{
			_idPeriodoProgrammazione = idPeriodoProgrammazione;
			return this;
		}
	
		public AddSchedulazioneRotManToPlanBuilder ForSchedulazione(Guid idSchedulazione) 
		{
			_idSchedulazione = idSchedulazione;
			return this;
		}
	
		public AddSchedulazioneRotManToPlanBuilder ForCommittente(Guid idCommittente) 
		{
			_idCommittente = idCommittente;
			return this;
		}
	
		public AddSchedulazioneRotManToPlanBuilder ForLotto(Guid idLotto) 
		{
			_idLotto = idLotto;
			return this;
		}
	
		public AddSchedulazioneRotManToPlanBuilder ForImpianto(Guid idImpianto) 
		{
			_idImpianto = idImpianto;
			return this;
		}
	
		public AddSchedulazioneRotManToPlanBuilder OfTipoIntervento(Guid idTipoIntervento) 
		{
			_idTipoIntervento = idTipoIntervento;
			return this;
		}
	
		public AddSchedulazioneRotManToPlanBuilder ForAppaltatore(Guid idAppaltatore) 
		{
			_idAppaltatore = idAppaltatore;
			return this;
		}
	
		public AddSchedulazioneRotManToPlanBuilder ForCategoriaCommerciale(Guid idCategoriaCommerciale) 
		{
			_idCategoriaCommerciale = idCategoriaCommerciale;
			return this;
		}
	
		public AddSchedulazioneRotManToPlanBuilder ForDirezioneRegionale(Guid idDirezioneRegionale) 
		{
			_idDirezioneRegionale = idDirezioneRegionale;
			return this;
		}
	
		public AddSchedulazioneRotManToPlanBuilder WithNote(string note) 
		{
			_note = note;
			return this;
		}
	
		public AddSchedulazioneRotManToPlanBuilder ForWorkPeriod(WorkPeriod workPeriod) 
		{
			_workPeriod = workPeriod;
			return this;
		}
	
		public AddSchedulazioneRotManToPlanBuilder ForPeriod(Period period) 
		{
			_period = period;
			return this;
		}
	
		public AddSchedulazioneRotManToPlanBuilder WithOggetti(OggettoRotMan[] oggetti) 
		{
			_oggetti = oggetti;
			return this;
		}
	
		
		public AddSchedulazioneRotManToPlan Build(Guid id)
		{
			return Build(id, Guid.NewGuid());
		}

		public AddSchedulazioneRotManToPlan Build(Guid id, Guid commitId)
        {
            return new AddSchedulazioneRotManToPlan(id, commitId, _idProgramma, _idPeriodoProgrammazione, _idSchedulazione, _idCommittente, _idLotto, _idImpianto, _idTipoIntervento, _idAppaltatore, _idCategoriaCommerciale, _idDirezioneRegionale, _note, _workPeriod, _period, _oggetti);
		 }


		
		public AddSchedulazioneRotManToPlan Build(Guid id, long version)
		{
			return Build(id, Guid.NewGuid(), version);
		}

		public AddSchedulazioneRotManToPlan Build(Guid id, Guid commitId, long version)
        {
            return new AddSchedulazioneRotManToPlan(id, commitId, version, _idProgramma, _idPeriodoProgrammazione, _idSchedulazione, _idCommittente, _idLotto, _idImpianto, _idTipoIntervento, _idAppaltatore, _idCategoriaCommerciale, _idDirezioneRegionale, _note, _workPeriod, _period, _oggetti);
		 }

		public AddSchedulazioneRotManToPlan Build(Guid id, DateTime wakeupTime)
		{
			return Build(id, Guid.NewGuid(), wakeupTime);
		}

		public AddSchedulazioneRotManToPlan Build(Guid id, Guid commitId, DateTime wakeupTime)
        {
            return new AddSchedulazioneRotManToPlan(id, commitId, wakeupTime, _idProgramma, _idPeriodoProgrammazione, _idSchedulazione, _idCommittente, _idLotto, _idImpianto, _idTipoIntervento, _idAppaltatore, _idCategoriaCommerciale, _idDirezioneRegionale, _note, _workPeriod, _period, _oggetti);
		 }




		public AddSchedulazioneRotManToPlan Build(Guid id, long version,DateTime wakeupTime)
		{
			return Build(id, Guid.NewGuid(), version,wakeupTime);
		}
		 

		public AddSchedulazioneRotManToPlan Build(Guid id, Guid commitId, long version, DateTime wakeupTime)
        {
            return new AddSchedulazioneRotManToPlan(id, commitId, version, wakeupTime, _idProgramma, _idPeriodoProgrammazione, _idSchedulazione, _idCommittente, _idLotto, _idImpianto, _idTipoIntervento, _idAppaltatore, _idCategoriaCommerciale, _idDirezioneRegionale, _note, _workPeriod, _period, _oggetti);
		 }
        
	
	}

	public class AddSchedulazioneAmbToPlanBuilder : ICommandBuilder<AddSchedulazioneAmbToPlan>
	{
	 
		private Guid  _idProgramma ; 
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
		public AddSchedulazioneAmbToPlanBuilder ForProgramma(Guid idProgramma) 
		{
			_idProgramma = idProgramma;
			return this;
		}
	
		public AddSchedulazioneAmbToPlanBuilder ForPeriodoProgrammazione(Guid idPeriodoProgrammazione) 
		{
			_idPeriodoProgrammazione = idPeriodoProgrammazione;
			return this;
		}
	
		public AddSchedulazioneAmbToPlanBuilder ForSchedulazione(Guid idSchedulazione) 
		{
			_idSchedulazione = idSchedulazione;
			return this;
		}
	
		public AddSchedulazioneAmbToPlanBuilder ForCommittente(Guid idCommittente) 
		{
			_idCommittente = idCommittente;
			return this;
		}
	
		public AddSchedulazioneAmbToPlanBuilder ForLotto(Guid idLotto) 
		{
			_idLotto = idLotto;
			return this;
		}
	
		public AddSchedulazioneAmbToPlanBuilder ForImpianto(Guid idImpianto) 
		{
			_idImpianto = idImpianto;
			return this;
		}
	
		public AddSchedulazioneAmbToPlanBuilder OfTipoIntervento(Guid idTipoIntervento) 
		{
			_idTipoIntervento = idTipoIntervento;
			return this;
		}
	
		public AddSchedulazioneAmbToPlanBuilder ForAppaltatore(Guid idAppaltatore) 
		{
			_idAppaltatore = idAppaltatore;
			return this;
		}
	
		public AddSchedulazioneAmbToPlanBuilder ForCategoriaCommerciale(Guid idCategoriaCommerciale) 
		{
			_idCategoriaCommerciale = idCategoriaCommerciale;
			return this;
		}
	
		public AddSchedulazioneAmbToPlanBuilder ForDirezioneRegionale(Guid idDirezioneRegionale) 
		{
			_idDirezioneRegionale = idDirezioneRegionale;
			return this;
		}
	
		public AddSchedulazioneAmbToPlanBuilder WithNote(string note) 
		{
			_note = note;
			return this;
		}
	
		public AddSchedulazioneAmbToPlanBuilder ForWorkPeriod(WorkPeriod workPeriod) 
		{
			_workPeriod = workPeriod;
			return this;
		}
	
		public AddSchedulazioneAmbToPlanBuilder ForPeriod(Period period) 
		{
			_period = period;
			return this;
		}
	
		public AddSchedulazioneAmbToPlanBuilder ForQuantity(int quantity) 
		{
			_quantity = quantity;
			return this;
		}
	
		public AddSchedulazioneAmbToPlanBuilder ForDescription(string description) 
		{
			_description = description;
			return this;
		}
	
		
		public AddSchedulazioneAmbToPlan Build(Guid id)
		{
			return Build(id, Guid.NewGuid());
		}

		public AddSchedulazioneAmbToPlan Build(Guid id, Guid commitId)
        {
            return new AddSchedulazioneAmbToPlan(id, commitId, _idProgramma, _idPeriodoProgrammazione, _idSchedulazione, _idCommittente, _idLotto, _idImpianto, _idTipoIntervento, _idAppaltatore, _idCategoriaCommerciale, _idDirezioneRegionale, _note, _workPeriod, _period, _quantity, _description);
		 }


		
		public AddSchedulazioneAmbToPlan Build(Guid id, long version)
		{
			return Build(id, Guid.NewGuid(), version);
		}

		public AddSchedulazioneAmbToPlan Build(Guid id, Guid commitId, long version)
        {
            return new AddSchedulazioneAmbToPlan(id, commitId, version, _idProgramma, _idPeriodoProgrammazione, _idSchedulazione, _idCommittente, _idLotto, _idImpianto, _idTipoIntervento, _idAppaltatore, _idCategoriaCommerciale, _idDirezioneRegionale, _note, _workPeriod, _period, _quantity, _description);
		 }

		public AddSchedulazioneAmbToPlan Build(Guid id, DateTime wakeupTime)
		{
			return Build(id, Guid.NewGuid(), wakeupTime);
		}

		public AddSchedulazioneAmbToPlan Build(Guid id, Guid commitId, DateTime wakeupTime)
        {
            return new AddSchedulazioneAmbToPlan(id, commitId, wakeupTime, _idProgramma, _idPeriodoProgrammazione, _idSchedulazione, _idCommittente, _idLotto, _idImpianto, _idTipoIntervento, _idAppaltatore, _idCategoriaCommerciale, _idDirezioneRegionale, _note, _workPeriod, _period, _quantity, _description);
		 }




		public AddSchedulazioneAmbToPlan Build(Guid id, long version,DateTime wakeupTime)
		{
			return Build(id, Guid.NewGuid(), version,wakeupTime);
		}
		 

		public AddSchedulazioneAmbToPlan Build(Guid id, Guid commitId, long version, DateTime wakeupTime)
        {
            return new AddSchedulazioneAmbToPlan(id, commitId, version, wakeupTime, _idProgramma, _idPeriodoProgrammazione, _idSchedulazione, _idCommittente, _idLotto, _idImpianto, _idTipoIntervento, _idAppaltatore, _idCategoriaCommerciale, _idDirezioneRegionale, _note, _workPeriod, _period, _quantity, _description);
		 }
        
	
	}

	public class AddInterventoRotToPlanBuilder : ICommandBuilder<AddInterventoRotToPlan>
	{
	 
		private Guid  _idProgramma ; 
		private Guid  _idPeriodoProgrammazione ; 
		private Guid  _idIntervento ; 
		private Guid  _idCommittente ; 
		private Guid  _idLotto ; 
		private Guid  _idImpianto ; 
		private Guid  _idTipoIntervento ; 
		private Guid  _idAppaltatore ; 
		private Guid  _idCategoriaCommerciale ; 
		private Guid  _idDirezioneRegionale ; 
		private string  _note ; 
		private WorkPeriod  _workPeriod ; 
		private string  _convoglio ; 
		private string  _rigaTurnoTreno ; 
		private string  _turnoTreno ; 
		private Treno  _trenoArrivo ; 
		private Treno  _trenoPartenza ; 
		private OggettoRot[]  _oggetti ;
		public AddInterventoRotToPlanBuilder ForProgramma(Guid idProgramma) 
		{
			_idProgramma = idProgramma;
			return this;
		}
	
		public AddInterventoRotToPlanBuilder ForPeriodoProgrammazione(Guid idPeriodoProgrammazione) 
		{
			_idPeriodoProgrammazione = idPeriodoProgrammazione;
			return this;
		}
	
		public AddInterventoRotToPlanBuilder ForIntervento(Guid idIntervento) 
		{
			_idIntervento = idIntervento;
			return this;
		}
	
		public AddInterventoRotToPlanBuilder ForCommittente(Guid idCommittente) 
		{
			_idCommittente = idCommittente;
			return this;
		}
	
		public AddInterventoRotToPlanBuilder ForLotto(Guid idLotto) 
		{
			_idLotto = idLotto;
			return this;
		}
	
		public AddInterventoRotToPlanBuilder ForImpianto(Guid idImpianto) 
		{
			_idImpianto = idImpianto;
			return this;
		}
	
		public AddInterventoRotToPlanBuilder OfTipoIntervento(Guid idTipoIntervento) 
		{
			_idTipoIntervento = idTipoIntervento;
			return this;
		}
	
		public AddInterventoRotToPlanBuilder ForAppaltatore(Guid idAppaltatore) 
		{
			_idAppaltatore = idAppaltatore;
			return this;
		}
	
		public AddInterventoRotToPlanBuilder ForCategoriaCommerciale(Guid idCategoriaCommerciale) 
		{
			_idCategoriaCommerciale = idCategoriaCommerciale;
			return this;
		}
	
		public AddInterventoRotToPlanBuilder ForDirezioneRegionale(Guid idDirezioneRegionale) 
		{
			_idDirezioneRegionale = idDirezioneRegionale;
			return this;
		}
	
		public AddInterventoRotToPlanBuilder WithNote(string note) 
		{
			_note = note;
			return this;
		}
	
		public AddInterventoRotToPlanBuilder ForWorkPeriod(WorkPeriod workPeriod) 
		{
			_workPeriod = workPeriod;
			return this;
		}
	
		public AddInterventoRotToPlanBuilder ForConvoglio(string convoglio) 
		{
			_convoglio = convoglio;
			return this;
		}
	
		public AddInterventoRotToPlanBuilder WithRigaTurnoTreno(string rigaTurnoTreno) 
		{
			_rigaTurnoTreno = rigaTurnoTreno;
			return this;
		}
	
		public AddInterventoRotToPlanBuilder WithTurnoTreno(string turnoTreno) 
		{
			_turnoTreno = turnoTreno;
			return this;
		}
	
		public AddInterventoRotToPlanBuilder WithTrenoArrivo(Treno trenoArrivo) 
		{
			_trenoArrivo = trenoArrivo;
			return this;
		}
	
		public AddInterventoRotToPlanBuilder WithTrenoPartenza(Treno trenoPartenza) 
		{
			_trenoPartenza = trenoPartenza;
			return this;
		}
	
		public AddInterventoRotToPlanBuilder WithOggetti(OggettoRot[] oggetti) 
		{
			_oggetti = oggetti;
			return this;
		}
	
		
		public AddInterventoRotToPlan Build(Guid id)
		{
			return Build(id, Guid.NewGuid());
		}

		public AddInterventoRotToPlan Build(Guid id, Guid commitId)
        {
            return new AddInterventoRotToPlan(id, commitId, _idProgramma, _idPeriodoProgrammazione, _idIntervento, _idCommittente, _idLotto, _idImpianto, _idTipoIntervento, _idAppaltatore, _idCategoriaCommerciale, _idDirezioneRegionale, _note, _workPeriod, _convoglio, _rigaTurnoTreno, _turnoTreno, _trenoArrivo, _trenoPartenza, _oggetti);
		 }


		
		public AddInterventoRotToPlan Build(Guid id, long version)
		{
			return Build(id, Guid.NewGuid(), version);
		}

		public AddInterventoRotToPlan Build(Guid id, Guid commitId, long version)
        {
            return new AddInterventoRotToPlan(id, commitId, version, _idProgramma, _idPeriodoProgrammazione, _idIntervento, _idCommittente, _idLotto, _idImpianto, _idTipoIntervento, _idAppaltatore, _idCategoriaCommerciale, _idDirezioneRegionale, _note, _workPeriod, _convoglio, _rigaTurnoTreno, _turnoTreno, _trenoArrivo, _trenoPartenza, _oggetti);
		 }

		public AddInterventoRotToPlan Build(Guid id, DateTime wakeupTime)
		{
			return Build(id, Guid.NewGuid(), wakeupTime);
		}

		public AddInterventoRotToPlan Build(Guid id, Guid commitId, DateTime wakeupTime)
        {
            return new AddInterventoRotToPlan(id, commitId, wakeupTime, _idProgramma, _idPeriodoProgrammazione, _idIntervento, _idCommittente, _idLotto, _idImpianto, _idTipoIntervento, _idAppaltatore, _idCategoriaCommerciale, _idDirezioneRegionale, _note, _workPeriod, _convoglio, _rigaTurnoTreno, _turnoTreno, _trenoArrivo, _trenoPartenza, _oggetti);
		 }




		public AddInterventoRotToPlan Build(Guid id, long version,DateTime wakeupTime)
		{
			return Build(id, Guid.NewGuid(), version,wakeupTime);
		}
		 

		public AddInterventoRotToPlan Build(Guid id, Guid commitId, long version, DateTime wakeupTime)
        {
            return new AddInterventoRotToPlan(id, commitId, version, wakeupTime, _idProgramma, _idPeriodoProgrammazione, _idIntervento, _idCommittente, _idLotto, _idImpianto, _idTipoIntervento, _idAppaltatore, _idCategoriaCommerciale, _idDirezioneRegionale, _note, _workPeriod, _convoglio, _rigaTurnoTreno, _turnoTreno, _trenoArrivo, _trenoPartenza, _oggetti);
		 }
        
	
	}

	public class AddInterventoRotManToPlanBuilder : ICommandBuilder<AddInterventoRotManToPlan>
	{
	 
		private Guid  _idProgramma ; 
		private Guid  _idPeriodoProgrammazione ; 
		private Guid  _idIntervento ; 
		private Guid  _idCommittente ; 
		private Guid  _idLotto ; 
		private Guid  _idImpianto ; 
		private Guid  _idTipoIntervento ; 
		private Guid  _idAppaltatore ; 
		private Guid  _idCategoriaCommerciale ; 
		private Guid  _idDirezioneRegionale ; 
		private string  _note ; 
		private WorkPeriod  _workPeriod ; 
		private OggettoRotMan[]  _oggetti ;
		public AddInterventoRotManToPlanBuilder ForProgramma(Guid idProgramma) 
		{
			_idProgramma = idProgramma;
			return this;
		}
	
		public AddInterventoRotManToPlanBuilder ForPeriodoProgrammazione(Guid idPeriodoProgrammazione) 
		{
			_idPeriodoProgrammazione = idPeriodoProgrammazione;
			return this;
		}
	
		public AddInterventoRotManToPlanBuilder ForIntervento(Guid idIntervento) 
		{
			_idIntervento = idIntervento;
			return this;
		}
	
		public AddInterventoRotManToPlanBuilder ForCommittente(Guid idCommittente) 
		{
			_idCommittente = idCommittente;
			return this;
		}
	
		public AddInterventoRotManToPlanBuilder ForLotto(Guid idLotto) 
		{
			_idLotto = idLotto;
			return this;
		}
	
		public AddInterventoRotManToPlanBuilder ForImpianto(Guid idImpianto) 
		{
			_idImpianto = idImpianto;
			return this;
		}
	
		public AddInterventoRotManToPlanBuilder OfTipoIntervento(Guid idTipoIntervento) 
		{
			_idTipoIntervento = idTipoIntervento;
			return this;
		}
	
		public AddInterventoRotManToPlanBuilder ForAppaltatore(Guid idAppaltatore) 
		{
			_idAppaltatore = idAppaltatore;
			return this;
		}
	
		public AddInterventoRotManToPlanBuilder ForCategoriaCommerciale(Guid idCategoriaCommerciale) 
		{
			_idCategoriaCommerciale = idCategoriaCommerciale;
			return this;
		}
	
		public AddInterventoRotManToPlanBuilder ForDirezioneRegionale(Guid idDirezioneRegionale) 
		{
			_idDirezioneRegionale = idDirezioneRegionale;
			return this;
		}
	
		public AddInterventoRotManToPlanBuilder WithNote(string note) 
		{
			_note = note;
			return this;
		}
	
		public AddInterventoRotManToPlanBuilder ForWorkPeriod(WorkPeriod workPeriod) 
		{
			_workPeriod = workPeriod;
			return this;
		}
	
		public AddInterventoRotManToPlanBuilder WithOggetti(OggettoRotMan[] oggetti) 
		{
			_oggetti = oggetti;
			return this;
		}
	
		
		public AddInterventoRotManToPlan Build(Guid id)
		{
			return Build(id, Guid.NewGuid());
		}

		public AddInterventoRotManToPlan Build(Guid id, Guid commitId)
        {
            return new AddInterventoRotManToPlan(id, commitId, _idProgramma, _idPeriodoProgrammazione, _idIntervento, _idCommittente, _idLotto, _idImpianto, _idTipoIntervento, _idAppaltatore, _idCategoriaCommerciale, _idDirezioneRegionale, _note, _workPeriod, _oggetti);
		 }


		
		public AddInterventoRotManToPlan Build(Guid id, long version)
		{
			return Build(id, Guid.NewGuid(), version);
		}

		public AddInterventoRotManToPlan Build(Guid id, Guid commitId, long version)
        {
            return new AddInterventoRotManToPlan(id, commitId, version, _idProgramma, _idPeriodoProgrammazione, _idIntervento, _idCommittente, _idLotto, _idImpianto, _idTipoIntervento, _idAppaltatore, _idCategoriaCommerciale, _idDirezioneRegionale, _note, _workPeriod, _oggetti);
		 }

		public AddInterventoRotManToPlan Build(Guid id, DateTime wakeupTime)
		{
			return Build(id, Guid.NewGuid(), wakeupTime);
		}

		public AddInterventoRotManToPlan Build(Guid id, Guid commitId, DateTime wakeupTime)
        {
            return new AddInterventoRotManToPlan(id, commitId, wakeupTime, _idProgramma, _idPeriodoProgrammazione, _idIntervento, _idCommittente, _idLotto, _idImpianto, _idTipoIntervento, _idAppaltatore, _idCategoriaCommerciale, _idDirezioneRegionale, _note, _workPeriod, _oggetti);
		 }




		public AddInterventoRotManToPlan Build(Guid id, long version,DateTime wakeupTime)
		{
			return Build(id, Guid.NewGuid(), version,wakeupTime);
		}
		 

		public AddInterventoRotManToPlan Build(Guid id, Guid commitId, long version, DateTime wakeupTime)
        {
            return new AddInterventoRotManToPlan(id, commitId, version, wakeupTime, _idProgramma, _idPeriodoProgrammazione, _idIntervento, _idCommittente, _idLotto, _idImpianto, _idTipoIntervento, _idAppaltatore, _idCategoriaCommerciale, _idDirezioneRegionale, _note, _workPeriod, _oggetti);
		 }
        
	
	}

	public class AddInterventoAmbToPlanBuilder : ICommandBuilder<AddInterventoAmbToPlan>
	{
	 
		private Guid  _idProgramma ; 
		private Guid  _idPeriodoProgrammazione ; 
		private Guid  _idIntervento ; 
		private Guid  _idCommittente ; 
		private Guid  _idLotto ; 
		private Guid  _idImpianto ; 
		private Guid  _idTipoIntervento ; 
		private Guid  _idAppaltatore ; 
		private Guid  _idCategoriaCommerciale ; 
		private Guid  _idDirezioneRegionale ; 
		private string  _note ; 
		private WorkPeriod  _workPeriod ; 
		private int  _quantity ; 
		private string  _description ;
		public AddInterventoAmbToPlanBuilder ForProgramma(Guid idProgramma) 
		{
			_idProgramma = idProgramma;
			return this;
		}
	
		public AddInterventoAmbToPlanBuilder ForPeriodoProgrammazione(Guid idPeriodoProgrammazione) 
		{
			_idPeriodoProgrammazione = idPeriodoProgrammazione;
			return this;
		}
	
		public AddInterventoAmbToPlanBuilder ForIntervento(Guid idIntervento) 
		{
			_idIntervento = idIntervento;
			return this;
		}
	
		public AddInterventoAmbToPlanBuilder ForCommittente(Guid idCommittente) 
		{
			_idCommittente = idCommittente;
			return this;
		}
	
		public AddInterventoAmbToPlanBuilder ForLotto(Guid idLotto) 
		{
			_idLotto = idLotto;
			return this;
		}
	
		public AddInterventoAmbToPlanBuilder ForImpianto(Guid idImpianto) 
		{
			_idImpianto = idImpianto;
			return this;
		}
	
		public AddInterventoAmbToPlanBuilder OfTipoIntervento(Guid idTipoIntervento) 
		{
			_idTipoIntervento = idTipoIntervento;
			return this;
		}
	
		public AddInterventoAmbToPlanBuilder ForAppaltatore(Guid idAppaltatore) 
		{
			_idAppaltatore = idAppaltatore;
			return this;
		}
	
		public AddInterventoAmbToPlanBuilder ForCategoriaCommerciale(Guid idCategoriaCommerciale) 
		{
			_idCategoriaCommerciale = idCategoriaCommerciale;
			return this;
		}
	
		public AddInterventoAmbToPlanBuilder ForDirezioneRegionale(Guid idDirezioneRegionale) 
		{
			_idDirezioneRegionale = idDirezioneRegionale;
			return this;
		}
	
		public AddInterventoAmbToPlanBuilder WithNote(string note) 
		{
			_note = note;
			return this;
		}
	
		public AddInterventoAmbToPlanBuilder ForWorkPeriod(WorkPeriod workPeriod) 
		{
			_workPeriod = workPeriod;
			return this;
		}
	
		public AddInterventoAmbToPlanBuilder ForQuantity(int quantity) 
		{
			_quantity = quantity;
			return this;
		}
	
		public AddInterventoAmbToPlanBuilder ForDescription(string description) 
		{
			_description = description;
			return this;
		}
	
		
		public AddInterventoAmbToPlan Build(Guid id)
		{
			return Build(id, Guid.NewGuid());
		}

		public AddInterventoAmbToPlan Build(Guid id, Guid commitId)
        {
            return new AddInterventoAmbToPlan(id, commitId, _idProgramma, _idPeriodoProgrammazione, _idIntervento, _idCommittente, _idLotto, _idImpianto, _idTipoIntervento, _idAppaltatore, _idCategoriaCommerciale, _idDirezioneRegionale, _note, _workPeriod, _quantity, _description);
		 }


		
		public AddInterventoAmbToPlan Build(Guid id, long version)
		{
			return Build(id, Guid.NewGuid(), version);
		}

		public AddInterventoAmbToPlan Build(Guid id, Guid commitId, long version)
        {
            return new AddInterventoAmbToPlan(id, commitId, version, _idProgramma, _idPeriodoProgrammazione, _idIntervento, _idCommittente, _idLotto, _idImpianto, _idTipoIntervento, _idAppaltatore, _idCategoriaCommerciale, _idDirezioneRegionale, _note, _workPeriod, _quantity, _description);
		 }

		public AddInterventoAmbToPlan Build(Guid id, DateTime wakeupTime)
		{
			return Build(id, Guid.NewGuid(), wakeupTime);
		}

		public AddInterventoAmbToPlan Build(Guid id, Guid commitId, DateTime wakeupTime)
        {
            return new AddInterventoAmbToPlan(id, commitId, wakeupTime, _idProgramma, _idPeriodoProgrammazione, _idIntervento, _idCommittente, _idLotto, _idImpianto, _idTipoIntervento, _idAppaltatore, _idCategoriaCommerciale, _idDirezioneRegionale, _note, _workPeriod, _quantity, _description);
		 }




		public AddInterventoAmbToPlan Build(Guid id, long version,DateTime wakeupTime)
		{
			return Build(id, Guid.NewGuid(), version,wakeupTime);
		}
		 

		public AddInterventoAmbToPlan Build(Guid id, Guid commitId, long version, DateTime wakeupTime)
        {
            return new AddInterventoAmbToPlan(id, commitId, version, wakeupTime, _idProgramma, _idPeriodoProgrammazione, _idIntervento, _idCommittente, _idLotto, _idImpianto, _idTipoIntervento, _idAppaltatore, _idCategoriaCommerciale, _idDirezioneRegionale, _note, _workPeriod, _quantity, _description);
		 }
        
	
	}
}

namespace Super.Programmazione.Commands
{
	public static partial class BuildCmd 
	{
		  public static CancelPlanBuilder CancelPlan {get { return new CancelPlanBuilder(); } }
	  		  public static CreatePlanFromPromotedScenarioBuilder CreatePlanFromPromotedScenario {get { return new CreatePlanFromPromotedScenarioBuilder(); } }
	  		  public static AddSchedulazioneRotToPlanBuilder AddSchedulazioneRotToPlan {get { return new AddSchedulazioneRotToPlanBuilder(); } }
	  		  public static AddSchedulazioneRotManToPlanBuilder AddSchedulazioneRotManToPlan {get { return new AddSchedulazioneRotManToPlanBuilder(); } }
	  		  public static AddSchedulazioneAmbToPlanBuilder AddSchedulazioneAmbToPlan {get { return new AddSchedulazioneAmbToPlanBuilder(); } }
	  		  public static AddInterventoRotToPlanBuilder AddInterventoRotToPlan {get { return new AddInterventoRotToPlanBuilder(); } }
	  		  public static AddInterventoRotManToPlanBuilder AddInterventoRotManToPlan {get { return new AddInterventoRotManToPlanBuilder(); } }
	  		  public static AddInterventoAmbToPlanBuilder AddInterventoAmbToPlan {get { return new AddInterventoAmbToPlanBuilder(); } }
	  	}
}
