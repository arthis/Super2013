



using System;
using CommonDomain;
using System.Diagnostics.Contracts;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using Super.Appaltatore.Commands.Programmazione;
using Super.Appaltatore.Commands.Programmazione.Builders;

namespace Super.Appaltatore.Commands.Programmazione.Builders
{


	public class ProgramInterventoRotBuilder : ICommandBuilder<ProgramInterventoRot>
	{
	 
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
		private string  _convoglio ; 
		private string  _rigaTurnoTreno ; 
		private string  _turnoTreno ; 
		private Treno  _trenoArrivo ; 
		private Treno  _trenoPartenza ; 
		private OggettoRot[]  _oggetti ;
		public ProgramInterventoRotBuilder ForProgramma(Guid idProgramma) 
		{
			_idProgramma = idProgramma;
			return this;
		}
	
		public ProgramInterventoRotBuilder ForPeriodoProgrammazione(Guid idPeriodoProgrammazione) 
		{
			_idPeriodoProgrammazione = idPeriodoProgrammazione;
			return this;
		}
	
		public ProgramInterventoRotBuilder ForCommittente(Guid idCommittente) 
		{
			_idCommittente = idCommittente;
			return this;
		}
	
		public ProgramInterventoRotBuilder ForLotto(Guid idLotto) 
		{
			_idLotto = idLotto;
			return this;
		}
	
		public ProgramInterventoRotBuilder ForImpianto(Guid idImpianto) 
		{
			_idImpianto = idImpianto;
			return this;
		}
	
		public ProgramInterventoRotBuilder OfTipoIntervento(Guid idTipoIntervento) 
		{
			_idTipoIntervento = idTipoIntervento;
			return this;
		}
	
		public ProgramInterventoRotBuilder ForAppaltatore(Guid idAppaltatore) 
		{
			_idAppaltatore = idAppaltatore;
			return this;
		}
	
		public ProgramInterventoRotBuilder ForCategoriaCommerciale(Guid idCategoriaCommerciale) 
		{
			_idCategoriaCommerciale = idCategoriaCommerciale;
			return this;
		}
	
		public ProgramInterventoRotBuilder ForDirezioneRegionale(Guid idDirezioneRegionale) 
		{
			_idDirezioneRegionale = idDirezioneRegionale;
			return this;
		}
	
		public ProgramInterventoRotBuilder WithNote(string note) 
		{
			_note = note;
			return this;
		}
	
		public ProgramInterventoRotBuilder ForWorkPeriod(WorkPeriod workPeriod) 
		{
			_workPeriod = workPeriod;
			return this;
		}
	
		public ProgramInterventoRotBuilder ForConvoglio(string convoglio) 
		{
			_convoglio = convoglio;
			return this;
		}
	
		public ProgramInterventoRotBuilder WithRigaTurnoTreno(string rigaTurnoTreno) 
		{
			_rigaTurnoTreno = rigaTurnoTreno;
			return this;
		}
	
		public ProgramInterventoRotBuilder WithTurnoTreno(string turnoTreno) 
		{
			_turnoTreno = turnoTreno;
			return this;
		}
	
		public ProgramInterventoRotBuilder WithTrenoArrivo(Treno trenoArrivo) 
		{
			_trenoArrivo = trenoArrivo;
			return this;
		}
	
		public ProgramInterventoRotBuilder WithTrenoPartenza(Treno trenoPartenza) 
		{
			_trenoPartenza = trenoPartenza;
			return this;
		}
	
		public ProgramInterventoRotBuilder WithOggetti(OggettoRot[] oggetti) 
		{
			_oggetti = oggetti;
			return this;
		}
	
		
		public ProgramInterventoRot Build(Guid id)
		{
			return Build(id, Guid.NewGuid());
		}

		public ProgramInterventoRot Build(Guid id, Guid commitId)
        {
            return new ProgramInterventoRot(id, commitId, _idProgramma, _idPeriodoProgrammazione, _idCommittente, _idLotto, _idImpianto, _idTipoIntervento, _idAppaltatore, _idCategoriaCommerciale, _idDirezioneRegionale, _note, _workPeriod, _convoglio, _rigaTurnoTreno, _turnoTreno, _trenoArrivo, _trenoPartenza, _oggetti);
		 }


		
		public ProgramInterventoRot Build(Guid id, long version)
		{
			return Build(id, Guid.NewGuid(), version);
		}

		public ProgramInterventoRot Build(Guid id, Guid commitId, long version)
        {
            return new ProgramInterventoRot(id, commitId, version, _idProgramma, _idPeriodoProgrammazione, _idCommittente, _idLotto, _idImpianto, _idTipoIntervento, _idAppaltatore, _idCategoriaCommerciale, _idDirezioneRegionale, _note, _workPeriod, _convoglio, _rigaTurnoTreno, _turnoTreno, _trenoArrivo, _trenoPartenza, _oggetti);
		 }

		public ProgramInterventoRot Build(Guid id, DateTime wakeupTime)
		{
			return Build(id, Guid.NewGuid(), wakeupTime);
		}

		public ProgramInterventoRot Build(Guid id, Guid commitId, DateTime wakeupTime)
        {
            return new ProgramInterventoRot(id, commitId, wakeupTime, _idProgramma, _idPeriodoProgrammazione, _idCommittente, _idLotto, _idImpianto, _idTipoIntervento, _idAppaltatore, _idCategoriaCommerciale, _idDirezioneRegionale, _note, _workPeriod, _convoglio, _rigaTurnoTreno, _turnoTreno, _trenoArrivo, _trenoPartenza, _oggetti);
		 }




		public ProgramInterventoRot Build(Guid id, long version,DateTime wakeupTime)
		{
			return Build(id, Guid.NewGuid(), version,wakeupTime);
		}
		 

		public ProgramInterventoRot Build(Guid id, Guid commitId, long version, DateTime wakeupTime)
        {
            return new ProgramInterventoRot(id, commitId, version, wakeupTime, _idProgramma, _idPeriodoProgrammazione, _idCommittente, _idLotto, _idImpianto, _idTipoIntervento, _idAppaltatore, _idCategoriaCommerciale, _idDirezioneRegionale, _note, _workPeriod, _convoglio, _rigaTurnoTreno, _turnoTreno, _trenoArrivo, _trenoPartenza, _oggetti);
		 }
        
	
	}

	public class ProgramInterventoRotManBuilder : ICommandBuilder<ProgramInterventoRotMan>
	{
	 
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
		private OggettoRotMan[]  _oggetti ;
		public ProgramInterventoRotManBuilder ForProgramma(Guid idProgramma) 
		{
			_idProgramma = idProgramma;
			return this;
		}
	
		public ProgramInterventoRotManBuilder ForPeriodoProgrammazione(Guid idPeriodoProgrammazione) 
		{
			_idPeriodoProgrammazione = idPeriodoProgrammazione;
			return this;
		}
	
		public ProgramInterventoRotManBuilder ForCommittente(Guid idCommittente) 
		{
			_idCommittente = idCommittente;
			return this;
		}
	
		public ProgramInterventoRotManBuilder ForLotto(Guid idLotto) 
		{
			_idLotto = idLotto;
			return this;
		}
	
		public ProgramInterventoRotManBuilder ForImpianto(Guid idImpianto) 
		{
			_idImpianto = idImpianto;
			return this;
		}
	
		public ProgramInterventoRotManBuilder OfTipoIntervento(Guid idTipoIntervento) 
		{
			_idTipoIntervento = idTipoIntervento;
			return this;
		}
	
		public ProgramInterventoRotManBuilder ForAppaltatore(Guid idAppaltatore) 
		{
			_idAppaltatore = idAppaltatore;
			return this;
		}
	
		public ProgramInterventoRotManBuilder ForCategoriaCommerciale(Guid idCategoriaCommerciale) 
		{
			_idCategoriaCommerciale = idCategoriaCommerciale;
			return this;
		}
	
		public ProgramInterventoRotManBuilder ForDirezioneRegionale(Guid idDirezioneRegionale) 
		{
			_idDirezioneRegionale = idDirezioneRegionale;
			return this;
		}
	
		public ProgramInterventoRotManBuilder WithNote(string note) 
		{
			_note = note;
			return this;
		}
	
		public ProgramInterventoRotManBuilder ForWorkPeriod(WorkPeriod workPeriod) 
		{
			_workPeriod = workPeriod;
			return this;
		}
	
		public ProgramInterventoRotManBuilder WithOggetti(OggettoRotMan[] oggetti) 
		{
			_oggetti = oggetti;
			return this;
		}
	
		
		public ProgramInterventoRotMan Build(Guid id)
		{
			return Build(id, Guid.NewGuid());
		}

		public ProgramInterventoRotMan Build(Guid id, Guid commitId)
        {
            return new ProgramInterventoRotMan(id, commitId, _idProgramma, _idPeriodoProgrammazione, _idCommittente, _idLotto, _idImpianto, _idTipoIntervento, _idAppaltatore, _idCategoriaCommerciale, _idDirezioneRegionale, _note, _workPeriod, _oggetti);
		 }


		
		public ProgramInterventoRotMan Build(Guid id, long version)
		{
			return Build(id, Guid.NewGuid(), version);
		}

		public ProgramInterventoRotMan Build(Guid id, Guid commitId, long version)
        {
            return new ProgramInterventoRotMan(id, commitId, version, _idProgramma, _idPeriodoProgrammazione, _idCommittente, _idLotto, _idImpianto, _idTipoIntervento, _idAppaltatore, _idCategoriaCommerciale, _idDirezioneRegionale, _note, _workPeriod, _oggetti);
		 }

		public ProgramInterventoRotMan Build(Guid id, DateTime wakeupTime)
		{
			return Build(id, Guid.NewGuid(), wakeupTime);
		}

		public ProgramInterventoRotMan Build(Guid id, Guid commitId, DateTime wakeupTime)
        {
            return new ProgramInterventoRotMan(id, commitId, wakeupTime, _idProgramma, _idPeriodoProgrammazione, _idCommittente, _idLotto, _idImpianto, _idTipoIntervento, _idAppaltatore, _idCategoriaCommerciale, _idDirezioneRegionale, _note, _workPeriod, _oggetti);
		 }




		public ProgramInterventoRotMan Build(Guid id, long version,DateTime wakeupTime)
		{
			return Build(id, Guid.NewGuid(), version,wakeupTime);
		}
		 

		public ProgramInterventoRotMan Build(Guid id, Guid commitId, long version, DateTime wakeupTime)
        {
            return new ProgramInterventoRotMan(id, commitId, version, wakeupTime, _idProgramma, _idPeriodoProgrammazione, _idCommittente, _idLotto, _idImpianto, _idTipoIntervento, _idAppaltatore, _idCategoriaCommerciale, _idDirezioneRegionale, _note, _workPeriod, _oggetti);
		 }
        
	
	}

	public class ProgramInterventoAmbBuilder : ICommandBuilder<ProgramInterventoAmb>
	{
	 
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
		private int  _quantity ; 
		private string  _description ;
		public ProgramInterventoAmbBuilder ForProgramma(Guid idProgramma) 
		{
			_idProgramma = idProgramma;
			return this;
		}
	
		public ProgramInterventoAmbBuilder ForPeriodoProgrammazione(Guid idPeriodoProgrammazione) 
		{
			_idPeriodoProgrammazione = idPeriodoProgrammazione;
			return this;
		}
	
		public ProgramInterventoAmbBuilder ForCommittente(Guid idCommittente) 
		{
			_idCommittente = idCommittente;
			return this;
		}
	
		public ProgramInterventoAmbBuilder ForLotto(Guid idLotto) 
		{
			_idLotto = idLotto;
			return this;
		}
	
		public ProgramInterventoAmbBuilder ForImpianto(Guid idImpianto) 
		{
			_idImpianto = idImpianto;
			return this;
		}
	
		public ProgramInterventoAmbBuilder OfTipoIntervento(Guid idTipoIntervento) 
		{
			_idTipoIntervento = idTipoIntervento;
			return this;
		}
	
		public ProgramInterventoAmbBuilder ForAppaltatore(Guid idAppaltatore) 
		{
			_idAppaltatore = idAppaltatore;
			return this;
		}
	
		public ProgramInterventoAmbBuilder ForCategoriaCommerciale(Guid idCategoriaCommerciale) 
		{
			_idCategoriaCommerciale = idCategoriaCommerciale;
			return this;
		}
	
		public ProgramInterventoAmbBuilder ForDirezioneRegionale(Guid idDirezioneRegionale) 
		{
			_idDirezioneRegionale = idDirezioneRegionale;
			return this;
		}
	
		public ProgramInterventoAmbBuilder WithNote(string note) 
		{
			_note = note;
			return this;
		}
	
		public ProgramInterventoAmbBuilder ForWorkPeriod(WorkPeriod workPeriod) 
		{
			_workPeriod = workPeriod;
			return this;
		}
	
		public ProgramInterventoAmbBuilder ForQuantity(int quantity) 
		{
			_quantity = quantity;
			return this;
		}
	
		public ProgramInterventoAmbBuilder ForDescription(string description) 
		{
			_description = description;
			return this;
		}
	
		
		public ProgramInterventoAmb Build(Guid id)
		{
			return Build(id, Guid.NewGuid());
		}

		public ProgramInterventoAmb Build(Guid id, Guid commitId)
        {
            return new ProgramInterventoAmb(id, commitId, _idProgramma, _idPeriodoProgrammazione, _idCommittente, _idLotto, _idImpianto, _idTipoIntervento, _idAppaltatore, _idCategoriaCommerciale, _idDirezioneRegionale, _note, _workPeriod, _quantity, _description);
		 }


		
		public ProgramInterventoAmb Build(Guid id, long version)
		{
			return Build(id, Guid.NewGuid(), version);
		}

		public ProgramInterventoAmb Build(Guid id, Guid commitId, long version)
        {
            return new ProgramInterventoAmb(id, commitId, version, _idProgramma, _idPeriodoProgrammazione, _idCommittente, _idLotto, _idImpianto, _idTipoIntervento, _idAppaltatore, _idCategoriaCommerciale, _idDirezioneRegionale, _note, _workPeriod, _quantity, _description);
		 }

		public ProgramInterventoAmb Build(Guid id, DateTime wakeupTime)
		{
			return Build(id, Guid.NewGuid(), wakeupTime);
		}

		public ProgramInterventoAmb Build(Guid id, Guid commitId, DateTime wakeupTime)
        {
            return new ProgramInterventoAmb(id, commitId, wakeupTime, _idProgramma, _idPeriodoProgrammazione, _idCommittente, _idLotto, _idImpianto, _idTipoIntervento, _idAppaltatore, _idCategoriaCommerciale, _idDirezioneRegionale, _note, _workPeriod, _quantity, _description);
		 }




		public ProgramInterventoAmb Build(Guid id, long version,DateTime wakeupTime)
		{
			return Build(id, Guid.NewGuid(), version,wakeupTime);
		}
		 

		public ProgramInterventoAmb Build(Guid id, Guid commitId, long version, DateTime wakeupTime)
        {
            return new ProgramInterventoAmb(id, commitId, version, wakeupTime, _idProgramma, _idPeriodoProgrammazione, _idCommittente, _idLotto, _idImpianto, _idTipoIntervento, _idAppaltatore, _idCategoriaCommerciale, _idDirezioneRegionale, _note, _workPeriod, _quantity, _description);
		 }
        
	
	}
}

namespace Super.Appaltatore.Commands
{
	public static partial class BuildCmd 
	{
		  public static ProgramInterventoRotBuilder ProgramInterventoRot {get { return new ProgramInterventoRotBuilder(); } }
	  		  public static ProgramInterventoRotManBuilder ProgramInterventoRotMan {get { return new ProgramInterventoRotManBuilder(); } }
	  		  public static ProgramInterventoAmbBuilder ProgramInterventoAmb {get { return new ProgramInterventoAmbBuilder(); } }
	  	}
}
