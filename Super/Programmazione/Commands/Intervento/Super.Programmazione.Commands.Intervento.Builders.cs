



using System;
using CommonDomain;
using System.Diagnostics.Contracts;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using Super.Programmazione.Commands.Plan;
using Super.Programmazione.Commands.Plan.Builders;

namespace Super.Programmazione.Commands.Plan.Builders
{


	public class CreateInterventoRotBuilder : ICommandBuilder<CreateInterventoRot>
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
		public CreateInterventoRotBuilder ForProgramma(Guid idProgramma) 
		{
			_idProgramma = idProgramma;
			return this;
		}
	
		public CreateInterventoRotBuilder ForPeriodoProgrammazione(Guid idPeriodoProgrammazione) 
		{
			_idPeriodoProgrammazione = idPeriodoProgrammazione;
			return this;
		}
	
		public CreateInterventoRotBuilder ForCommittente(Guid idCommittente) 
		{
			_idCommittente = idCommittente;
			return this;
		}
	
		public CreateInterventoRotBuilder ForLotto(Guid idLotto) 
		{
			_idLotto = idLotto;
			return this;
		}
	
		public CreateInterventoRotBuilder ForImpianto(Guid idImpianto) 
		{
			_idImpianto = idImpianto;
			return this;
		}
	
		public CreateInterventoRotBuilder OfTipoIntervento(Guid idTipoIntervento) 
		{
			_idTipoIntervento = idTipoIntervento;
			return this;
		}
	
		public CreateInterventoRotBuilder ForAppaltatore(Guid idAppaltatore) 
		{
			_idAppaltatore = idAppaltatore;
			return this;
		}
	
		public CreateInterventoRotBuilder ForCategoriaCommerciale(Guid idCategoriaCommerciale) 
		{
			_idCategoriaCommerciale = idCategoriaCommerciale;
			return this;
		}
	
		public CreateInterventoRotBuilder ForDirezioneRegionale(Guid idDirezioneRegionale) 
		{
			_idDirezioneRegionale = idDirezioneRegionale;
			return this;
		}
	
		public CreateInterventoRotBuilder WithNote(string note) 
		{
			_note = note;
			return this;
		}
	
		public CreateInterventoRotBuilder ForWorkPeriod(WorkPeriod workPeriod) 
		{
			_workPeriod = workPeriod;
			return this;
		}
	
		public CreateInterventoRotBuilder ForConvoglio(string convoglio) 
		{
			_convoglio = convoglio;
			return this;
		}
	
		public CreateInterventoRotBuilder WithRigaTurnoTreno(string rigaTurnoTreno) 
		{
			_rigaTurnoTreno = rigaTurnoTreno;
			return this;
		}
	
		public CreateInterventoRotBuilder WithTurnoTreno(string turnoTreno) 
		{
			_turnoTreno = turnoTreno;
			return this;
		}
	
		public CreateInterventoRotBuilder WithTrenoArrivo(Treno trenoArrivo) 
		{
			_trenoArrivo = trenoArrivo;
			return this;
		}
	
		public CreateInterventoRotBuilder WithTrenoPartenza(Treno trenoPartenza) 
		{
			_trenoPartenza = trenoPartenza;
			return this;
		}
	
		public CreateInterventoRotBuilder WithOggetti(OggettoRot[] oggetti) 
		{
			_oggetti = oggetti;
			return this;
		}
	
		public CreateInterventoRot Build(Guid id, long version)
		{
			return Build(id, Guid.NewGuid(), version);
		}

		public CreateInterventoRot Build(Guid id, Guid commitId, long version)
        {
            return new CreateInterventoRot(id, commitId, version, _idProgramma, _idPeriodoProgrammazione, _idCommittente, _idLotto, _idImpianto, _idTipoIntervento, _idAppaltatore, _idCategoriaCommerciale, _idDirezioneRegionale, _note, _workPeriod, _convoglio, _rigaTurnoTreno, _turnoTreno, _trenoArrivo, _trenoPartenza, _oggetti);
		 }
        
	
	}

	public class CreateInterventoRotManBuilder : ICommandBuilder<CreateInterventoRotMan>
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
		public CreateInterventoRotManBuilder ForProgramma(Guid idProgramma) 
		{
			_idProgramma = idProgramma;
			return this;
		}
	
		public CreateInterventoRotManBuilder ForPeriodoProgrammazione(Guid idPeriodoProgrammazione) 
		{
			_idPeriodoProgrammazione = idPeriodoProgrammazione;
			return this;
		}
	
		public CreateInterventoRotManBuilder ForCommittente(Guid idCommittente) 
		{
			_idCommittente = idCommittente;
			return this;
		}
	
		public CreateInterventoRotManBuilder ForLotto(Guid idLotto) 
		{
			_idLotto = idLotto;
			return this;
		}
	
		public CreateInterventoRotManBuilder ForImpianto(Guid idImpianto) 
		{
			_idImpianto = idImpianto;
			return this;
		}
	
		public CreateInterventoRotManBuilder OfTipoIntervento(Guid idTipoIntervento) 
		{
			_idTipoIntervento = idTipoIntervento;
			return this;
		}
	
		public CreateInterventoRotManBuilder ForAppaltatore(Guid idAppaltatore) 
		{
			_idAppaltatore = idAppaltatore;
			return this;
		}
	
		public CreateInterventoRotManBuilder ForCategoriaCommerciale(Guid idCategoriaCommerciale) 
		{
			_idCategoriaCommerciale = idCategoriaCommerciale;
			return this;
		}
	
		public CreateInterventoRotManBuilder ForDirezioneRegionale(Guid idDirezioneRegionale) 
		{
			_idDirezioneRegionale = idDirezioneRegionale;
			return this;
		}
	
		public CreateInterventoRotManBuilder WithNote(string note) 
		{
			_note = note;
			return this;
		}
	
		public CreateInterventoRotManBuilder ForWorkPeriod(WorkPeriod workPeriod) 
		{
			_workPeriod = workPeriod;
			return this;
		}
	
		public CreateInterventoRotManBuilder WithOggetti(OggettoRotMan[] oggetti) 
		{
			_oggetti = oggetti;
			return this;
		}
	
		public CreateInterventoRotMan Build(Guid id, long version)
		{
			return Build(id, Guid.NewGuid(), version);
		}

		public CreateInterventoRotMan Build(Guid id, Guid commitId, long version)
        {
            return new CreateInterventoRotMan(id, commitId, version, _idProgramma, _idPeriodoProgrammazione, _idCommittente, _idLotto, _idImpianto, _idTipoIntervento, _idAppaltatore, _idCategoriaCommerciale, _idDirezioneRegionale, _note, _workPeriod, _oggetti);
		 }
        
	
	}

	public class CreateInterventoAmbBuilder : ICommandBuilder<CreateInterventoAmb>
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
		public CreateInterventoAmbBuilder ForProgramma(Guid idProgramma) 
		{
			_idProgramma = idProgramma;
			return this;
		}
	
		public CreateInterventoAmbBuilder ForPeriodoProgrammazione(Guid idPeriodoProgrammazione) 
		{
			_idPeriodoProgrammazione = idPeriodoProgrammazione;
			return this;
		}
	
		public CreateInterventoAmbBuilder ForCommittente(Guid idCommittente) 
		{
			_idCommittente = idCommittente;
			return this;
		}
	
		public CreateInterventoAmbBuilder ForLotto(Guid idLotto) 
		{
			_idLotto = idLotto;
			return this;
		}
	
		public CreateInterventoAmbBuilder ForImpianto(Guid idImpianto) 
		{
			_idImpianto = idImpianto;
			return this;
		}
	
		public CreateInterventoAmbBuilder OfTipoIntervento(Guid idTipoIntervento) 
		{
			_idTipoIntervento = idTipoIntervento;
			return this;
		}
	
		public CreateInterventoAmbBuilder ForAppaltatore(Guid idAppaltatore) 
		{
			_idAppaltatore = idAppaltatore;
			return this;
		}
	
		public CreateInterventoAmbBuilder ForCategoriaCommerciale(Guid idCategoriaCommerciale) 
		{
			_idCategoriaCommerciale = idCategoriaCommerciale;
			return this;
		}
	
		public CreateInterventoAmbBuilder ForDirezioneRegionale(Guid idDirezioneRegionale) 
		{
			_idDirezioneRegionale = idDirezioneRegionale;
			return this;
		}
	
		public CreateInterventoAmbBuilder WithNote(string note) 
		{
			_note = note;
			return this;
		}
	
		public CreateInterventoAmbBuilder ForWorkPeriod(WorkPeriod workPeriod) 
		{
			_workPeriod = workPeriod;
			return this;
		}
	
		public CreateInterventoAmbBuilder ForQuantity(int quantity) 
		{
			_quantity = quantity;
			return this;
		}
	
		public CreateInterventoAmbBuilder ForDescription(string description) 
		{
			_description = description;
			return this;
		}
	
		public CreateInterventoAmb Build(Guid id, long version)
		{
			return Build(id, Guid.NewGuid(), version);
		}

		public CreateInterventoAmb Build(Guid id, Guid commitId, long version)
        {
            return new CreateInterventoAmb(id, commitId, version, _idProgramma, _idPeriodoProgrammazione, _idCommittente, _idLotto, _idImpianto, _idTipoIntervento, _idAppaltatore, _idCategoriaCommerciale, _idDirezioneRegionale, _note, _workPeriod, _quantity, _description);
		 }
        
	
	}
}

namespace Super.Programmazione.Commands
{
	public static partial class BuildCmd 
	{
		  public static CreateInterventoRotBuilder CreateInterventoRot {get { return new CreateInterventoRotBuilder(); } }
	  		  public static CreateInterventoRotManBuilder CreateInterventoRotMan {get { return new CreateInterventoRotManBuilder(); } }
	  		  public static CreateInterventoAmbBuilder CreateInterventoAmb {get { return new CreateInterventoAmbBuilder(); } }
	  	}
}
