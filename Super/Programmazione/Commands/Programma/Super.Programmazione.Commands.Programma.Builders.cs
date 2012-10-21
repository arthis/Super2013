



using System;
using CommonDomain;
using System.Diagnostics.Contracts;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using Super.Programmazione.Commands.Programma;
using Super.Programmazione.Commands.Programma.Builders;

namespace Super.Programmazione.Commands.Programma.Builders
{


	public class AddSchedulazioneRotToProgrammaBuilder : ICommandBuilder<AddSchedulazioneRotToProgramma>
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
		public AddSchedulazioneRotToProgrammaBuilder ForPeriodoProgrammazione(Guid idPeriodoProgrammazione) 
		{
			_idPeriodoProgrammazione = idPeriodoProgrammazione;
			return this;
		}
	
		public AddSchedulazioneRotToProgrammaBuilder ForSchedulazione(Guid idSchedulazione) 
		{
			_idSchedulazione = idSchedulazione;
			return this;
		}
	
		public AddSchedulazioneRotToProgrammaBuilder ForCommittente(Guid idCommittente) 
		{
			_idCommittente = idCommittente;
			return this;
		}
	
		public AddSchedulazioneRotToProgrammaBuilder ForLotto(Guid idLotto) 
		{
			_idLotto = idLotto;
			return this;
		}
	
		public AddSchedulazioneRotToProgrammaBuilder ForImpianto(Guid idImpianto) 
		{
			_idImpianto = idImpianto;
			return this;
		}
	
		public AddSchedulazioneRotToProgrammaBuilder OfTipoIntervento(Guid idTipoIntervento) 
		{
			_idTipoIntervento = idTipoIntervento;
			return this;
		}
	
		public AddSchedulazioneRotToProgrammaBuilder ForAppaltatore(Guid idAppaltatore) 
		{
			_idAppaltatore = idAppaltatore;
			return this;
		}
	
		public AddSchedulazioneRotToProgrammaBuilder ForCategoriaCommerciale(Guid idCategoriaCommerciale) 
		{
			_idCategoriaCommerciale = idCategoriaCommerciale;
			return this;
		}
	
		public AddSchedulazioneRotToProgrammaBuilder ForDirezioneRegionale(Guid idDirezioneRegionale) 
		{
			_idDirezioneRegionale = idDirezioneRegionale;
			return this;
		}
	
		public AddSchedulazioneRotToProgrammaBuilder WithNote(string note) 
		{
			_note = note;
			return this;
		}
	
		public AddSchedulazioneRotToProgrammaBuilder ForWorkPeriod(WorkPeriod workPeriod) 
		{
			_workPeriod = workPeriod;
			return this;
		}
	
		public AddSchedulazioneRotToProgrammaBuilder ForPeriod(Period period) 
		{
			_period = period;
			return this;
		}
	
		public AddSchedulazioneRotToProgrammaBuilder ForConvoglio(string convoglio) 
		{
			_convoglio = convoglio;
			return this;
		}
	
		public AddSchedulazioneRotToProgrammaBuilder WithRigaTurnoTreno(string rigaTurnoTreno) 
		{
			_rigaTurnoTreno = rigaTurnoTreno;
			return this;
		}
	
		public AddSchedulazioneRotToProgrammaBuilder WithTurnoTreno(string turnoTreno) 
		{
			_turnoTreno = turnoTreno;
			return this;
		}
	
		public AddSchedulazioneRotToProgrammaBuilder WithTrenoArrivo(Treno trenoArrivo) 
		{
			_trenoArrivo = trenoArrivo;
			return this;
		}
	
		public AddSchedulazioneRotToProgrammaBuilder WithTrenoPartenza(Treno trenoPartenza) 
		{
			_trenoPartenza = trenoPartenza;
			return this;
		}
	
		public AddSchedulazioneRotToProgrammaBuilder WithOggetti(OggettoRot[] oggetti) 
		{
			_oggetti = oggetti;
			return this;
		}
	
		
		public AddSchedulazioneRotToProgramma Build(Guid id)
		{
			return Build(id, Guid.NewGuid());
		}

		public AddSchedulazioneRotToProgramma Build(Guid id, Guid commitId)
        {
            return new AddSchedulazioneRotToProgramma(id, commitId, _idPeriodoProgrammazione, _idSchedulazione, _idCommittente, _idLotto, _idImpianto, _idTipoIntervento, _idAppaltatore, _idCategoriaCommerciale, _idDirezioneRegionale, _note, _workPeriod, _period, _convoglio, _rigaTurnoTreno, _turnoTreno, _trenoArrivo, _trenoPartenza, _oggetti);
		 }


		
		public AddSchedulazioneRotToProgramma Build(Guid id, long version)
		{
			return Build(id, Guid.NewGuid(), version);
		}

		public AddSchedulazioneRotToProgramma Build(Guid id, Guid commitId, long version)
        {
            return new AddSchedulazioneRotToProgramma(id, commitId, version, _idPeriodoProgrammazione, _idSchedulazione, _idCommittente, _idLotto, _idImpianto, _idTipoIntervento, _idAppaltatore, _idCategoriaCommerciale, _idDirezioneRegionale, _note, _workPeriod, _period, _convoglio, _rigaTurnoTreno, _turnoTreno, _trenoArrivo, _trenoPartenza, _oggetti);
		 }

		public AddSchedulazioneRotToProgramma Build(Guid id, DateTime wakeupTime)
		{
			return Build(id, Guid.NewGuid(), wakeupTime);
		}

		public AddSchedulazioneRotToProgramma Build(Guid id, Guid commitId, DateTime wakeupTime)
        {
            return new AddSchedulazioneRotToProgramma(id, commitId, wakeupTime, _idPeriodoProgrammazione, _idSchedulazione, _idCommittente, _idLotto, _idImpianto, _idTipoIntervento, _idAppaltatore, _idCategoriaCommerciale, _idDirezioneRegionale, _note, _workPeriod, _period, _convoglio, _rigaTurnoTreno, _turnoTreno, _trenoArrivo, _trenoPartenza, _oggetti);
		 }




		public AddSchedulazioneRotToProgramma Build(Guid id, long version,DateTime wakeupTime)
		{
			return Build(id, Guid.NewGuid(), version,wakeupTime);
		}
		 

		public AddSchedulazioneRotToProgramma Build(Guid id, Guid commitId, long version, DateTime wakeupTime)
        {
            return new AddSchedulazioneRotToProgramma(id, commitId, version, wakeupTime, _idPeriodoProgrammazione, _idSchedulazione, _idCommittente, _idLotto, _idImpianto, _idTipoIntervento, _idAppaltatore, _idCategoriaCommerciale, _idDirezioneRegionale, _note, _workPeriod, _period, _convoglio, _rigaTurnoTreno, _turnoTreno, _trenoArrivo, _trenoPartenza, _oggetti);
		 }
        
	
	}

	public class AddSchedulazioneRotManToProgrammaBuilder : ICommandBuilder<AddSchedulazioneRotManToProgramma>
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
		public AddSchedulazioneRotManToProgrammaBuilder ForPeriodoProgrammazione(Guid idPeriodoProgrammazione) 
		{
			_idPeriodoProgrammazione = idPeriodoProgrammazione;
			return this;
		}
	
		public AddSchedulazioneRotManToProgrammaBuilder ForSchedulazione(Guid idSchedulazione) 
		{
			_idSchedulazione = idSchedulazione;
			return this;
		}
	
		public AddSchedulazioneRotManToProgrammaBuilder ForCommittente(Guid idCommittente) 
		{
			_idCommittente = idCommittente;
			return this;
		}
	
		public AddSchedulazioneRotManToProgrammaBuilder ForLotto(Guid idLotto) 
		{
			_idLotto = idLotto;
			return this;
		}
	
		public AddSchedulazioneRotManToProgrammaBuilder ForImpianto(Guid idImpianto) 
		{
			_idImpianto = idImpianto;
			return this;
		}
	
		public AddSchedulazioneRotManToProgrammaBuilder OfTipoIntervento(Guid idTipoIntervento) 
		{
			_idTipoIntervento = idTipoIntervento;
			return this;
		}
	
		public AddSchedulazioneRotManToProgrammaBuilder ForAppaltatore(Guid idAppaltatore) 
		{
			_idAppaltatore = idAppaltatore;
			return this;
		}
	
		public AddSchedulazioneRotManToProgrammaBuilder ForCategoriaCommerciale(Guid idCategoriaCommerciale) 
		{
			_idCategoriaCommerciale = idCategoriaCommerciale;
			return this;
		}
	
		public AddSchedulazioneRotManToProgrammaBuilder ForDirezioneRegionale(Guid idDirezioneRegionale) 
		{
			_idDirezioneRegionale = idDirezioneRegionale;
			return this;
		}
	
		public AddSchedulazioneRotManToProgrammaBuilder WithNote(string note) 
		{
			_note = note;
			return this;
		}
	
		public AddSchedulazioneRotManToProgrammaBuilder ForWorkPeriod(WorkPeriod workPeriod) 
		{
			_workPeriod = workPeriod;
			return this;
		}
	
		public AddSchedulazioneRotManToProgrammaBuilder ForPeriod(Period period) 
		{
			_period = period;
			return this;
		}
	
		public AddSchedulazioneRotManToProgrammaBuilder WithOggetti(OggettoRotMan[] oggetti) 
		{
			_oggetti = oggetti;
			return this;
		}
	
		
		public AddSchedulazioneRotManToProgramma Build(Guid id)
		{
			return Build(id, Guid.NewGuid());
		}

		public AddSchedulazioneRotManToProgramma Build(Guid id, Guid commitId)
        {
            return new AddSchedulazioneRotManToProgramma(id, commitId, _idPeriodoProgrammazione, _idSchedulazione, _idCommittente, _idLotto, _idImpianto, _idTipoIntervento, _idAppaltatore, _idCategoriaCommerciale, _idDirezioneRegionale, _note, _workPeriod, _period, _oggetti);
		 }


		
		public AddSchedulazioneRotManToProgramma Build(Guid id, long version)
		{
			return Build(id, Guid.NewGuid(), version);
		}

		public AddSchedulazioneRotManToProgramma Build(Guid id, Guid commitId, long version)
        {
            return new AddSchedulazioneRotManToProgramma(id, commitId, version, _idPeriodoProgrammazione, _idSchedulazione, _idCommittente, _idLotto, _idImpianto, _idTipoIntervento, _idAppaltatore, _idCategoriaCommerciale, _idDirezioneRegionale, _note, _workPeriod, _period, _oggetti);
		 }

		public AddSchedulazioneRotManToProgramma Build(Guid id, DateTime wakeupTime)
		{
			return Build(id, Guid.NewGuid(), wakeupTime);
		}

		public AddSchedulazioneRotManToProgramma Build(Guid id, Guid commitId, DateTime wakeupTime)
        {
            return new AddSchedulazioneRotManToProgramma(id, commitId, wakeupTime, _idPeriodoProgrammazione, _idSchedulazione, _idCommittente, _idLotto, _idImpianto, _idTipoIntervento, _idAppaltatore, _idCategoriaCommerciale, _idDirezioneRegionale, _note, _workPeriod, _period, _oggetti);
		 }




		public AddSchedulazioneRotManToProgramma Build(Guid id, long version,DateTime wakeupTime)
		{
			return Build(id, Guid.NewGuid(), version,wakeupTime);
		}
		 

		public AddSchedulazioneRotManToProgramma Build(Guid id, Guid commitId, long version, DateTime wakeupTime)
        {
            return new AddSchedulazioneRotManToProgramma(id, commitId, version, wakeupTime, _idPeriodoProgrammazione, _idSchedulazione, _idCommittente, _idLotto, _idImpianto, _idTipoIntervento, _idAppaltatore, _idCategoriaCommerciale, _idDirezioneRegionale, _note, _workPeriod, _period, _oggetti);
		 }
        
	
	}

	public class AddSchedulazioneAmbToProgrammaBuilder : ICommandBuilder<AddSchedulazioneAmbToProgramma>
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
		public AddSchedulazioneAmbToProgrammaBuilder ForPeriodoProgrammazione(Guid idPeriodoProgrammazione) 
		{
			_idPeriodoProgrammazione = idPeriodoProgrammazione;
			return this;
		}
	
		public AddSchedulazioneAmbToProgrammaBuilder ForSchedulazione(Guid idSchedulazione) 
		{
			_idSchedulazione = idSchedulazione;
			return this;
		}
	
		public AddSchedulazioneAmbToProgrammaBuilder ForCommittente(Guid idCommittente) 
		{
			_idCommittente = idCommittente;
			return this;
		}
	
		public AddSchedulazioneAmbToProgrammaBuilder ForLotto(Guid idLotto) 
		{
			_idLotto = idLotto;
			return this;
		}
	
		public AddSchedulazioneAmbToProgrammaBuilder ForImpianto(Guid idImpianto) 
		{
			_idImpianto = idImpianto;
			return this;
		}
	
		public AddSchedulazioneAmbToProgrammaBuilder OfTipoIntervento(Guid idTipoIntervento) 
		{
			_idTipoIntervento = idTipoIntervento;
			return this;
		}
	
		public AddSchedulazioneAmbToProgrammaBuilder ForAppaltatore(Guid idAppaltatore) 
		{
			_idAppaltatore = idAppaltatore;
			return this;
		}
	
		public AddSchedulazioneAmbToProgrammaBuilder ForCategoriaCommerciale(Guid idCategoriaCommerciale) 
		{
			_idCategoriaCommerciale = idCategoriaCommerciale;
			return this;
		}
	
		public AddSchedulazioneAmbToProgrammaBuilder ForDirezioneRegionale(Guid idDirezioneRegionale) 
		{
			_idDirezioneRegionale = idDirezioneRegionale;
			return this;
		}
	
		public AddSchedulazioneAmbToProgrammaBuilder WithNote(string note) 
		{
			_note = note;
			return this;
		}
	
		public AddSchedulazioneAmbToProgrammaBuilder ForWorkPeriod(WorkPeriod workPeriod) 
		{
			_workPeriod = workPeriod;
			return this;
		}
	
		public AddSchedulazioneAmbToProgrammaBuilder ForPeriod(Period period) 
		{
			_period = period;
			return this;
		}
	
		public AddSchedulazioneAmbToProgrammaBuilder ForQuantity(int quantity) 
		{
			_quantity = quantity;
			return this;
		}
	
		public AddSchedulazioneAmbToProgrammaBuilder ForDescription(string description) 
		{
			_description = description;
			return this;
		}
	
		
		public AddSchedulazioneAmbToProgramma Build(Guid id)
		{
			return Build(id, Guid.NewGuid());
		}

		public AddSchedulazioneAmbToProgramma Build(Guid id, Guid commitId)
        {
            return new AddSchedulazioneAmbToProgramma(id, commitId, _idPeriodoProgrammazione, _idSchedulazione, _idCommittente, _idLotto, _idImpianto, _idTipoIntervento, _idAppaltatore, _idCategoriaCommerciale, _idDirezioneRegionale, _note, _workPeriod, _period, _quantity, _description);
		 }


		
		public AddSchedulazioneAmbToProgramma Build(Guid id, long version)
		{
			return Build(id, Guid.NewGuid(), version);
		}

		public AddSchedulazioneAmbToProgramma Build(Guid id, Guid commitId, long version)
        {
            return new AddSchedulazioneAmbToProgramma(id, commitId, version, _idPeriodoProgrammazione, _idSchedulazione, _idCommittente, _idLotto, _idImpianto, _idTipoIntervento, _idAppaltatore, _idCategoriaCommerciale, _idDirezioneRegionale, _note, _workPeriod, _period, _quantity, _description);
		 }

		public AddSchedulazioneAmbToProgramma Build(Guid id, DateTime wakeupTime)
		{
			return Build(id, Guid.NewGuid(), wakeupTime);
		}

		public AddSchedulazioneAmbToProgramma Build(Guid id, Guid commitId, DateTime wakeupTime)
        {
            return new AddSchedulazioneAmbToProgramma(id, commitId, wakeupTime, _idPeriodoProgrammazione, _idSchedulazione, _idCommittente, _idLotto, _idImpianto, _idTipoIntervento, _idAppaltatore, _idCategoriaCommerciale, _idDirezioneRegionale, _note, _workPeriod, _period, _quantity, _description);
		 }




		public AddSchedulazioneAmbToProgramma Build(Guid id, long version,DateTime wakeupTime)
		{
			return Build(id, Guid.NewGuid(), version,wakeupTime);
		}
		 

		public AddSchedulazioneAmbToProgramma Build(Guid id, Guid commitId, long version, DateTime wakeupTime)
        {
            return new AddSchedulazioneAmbToProgramma(id, commitId, version, wakeupTime, _idPeriodoProgrammazione, _idSchedulazione, _idCommittente, _idLotto, _idImpianto, _idTipoIntervento, _idAppaltatore, _idCategoriaCommerciale, _idDirezioneRegionale, _note, _workPeriod, _period, _quantity, _description);
		 }
        
	
	}

	public class CreateProgrammaBuilder : ICommandBuilder<CreateProgramma>
	{
	 
		private Guid  _idScenario ;
		public CreateProgrammaBuilder ByScenario(Guid idScenario) 
		{
			_idScenario = idScenario;
			return this;
		}
	
		
		public CreateProgramma Build(Guid id)
		{
			return Build(id, Guid.NewGuid());
		}

		public CreateProgramma Build(Guid id, Guid commitId)
        {
            return new CreateProgramma(id, commitId, _idScenario);
		 }


		
		public CreateProgramma Build(Guid id, long version)
		{
			return Build(id, Guid.NewGuid(), version);
		}

		public CreateProgramma Build(Guid id, Guid commitId, long version)
        {
            return new CreateProgramma(id, commitId, version, _idScenario);
		 }

		public CreateProgramma Build(Guid id, DateTime wakeupTime)
		{
			return Build(id, Guid.NewGuid(), wakeupTime);
		}

		public CreateProgramma Build(Guid id, Guid commitId, DateTime wakeupTime)
        {
            return new CreateProgramma(id, commitId, wakeupTime, _idScenario);
		 }




		public CreateProgramma Build(Guid id, long version,DateTime wakeupTime)
		{
			return Build(id, Guid.NewGuid(), version,wakeupTime);
		}
		 

		public CreateProgramma Build(Guid id, Guid commitId, long version, DateTime wakeupTime)
        {
            return new CreateProgramma(id, commitId, version, wakeupTime, _idScenario);
		 }
        
	
	}
}

namespace Super.Programmazione.Commands
{
	public static partial class BuildCmd 
	{
		  public static AddSchedulazioneRotToProgrammaBuilder AddSchedulazioneRotToProgramma {get { return new AddSchedulazioneRotToProgrammaBuilder(); } }
	  		  public static AddSchedulazioneRotManToProgrammaBuilder AddSchedulazioneRotManToProgramma {get { return new AddSchedulazioneRotManToProgrammaBuilder(); } }
	  		  public static AddSchedulazioneAmbToProgrammaBuilder AddSchedulazioneAmbToProgramma {get { return new AddSchedulazioneAmbToProgrammaBuilder(); } }
	  		  public static CreateProgrammaBuilder CreateProgramma {get { return new CreateProgrammaBuilder(); } }
	  	}
}
