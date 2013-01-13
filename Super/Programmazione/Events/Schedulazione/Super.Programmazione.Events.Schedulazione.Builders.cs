


using System;
using CommonDomain;
using System.Diagnostics.Contracts;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using Super.Programmazione.Events.Schedulazione;
using Super.Programmazione.Events.Schedulazione.Builders;

namespace Super.Programmazione.Events.Schedulazione.Builders
{


	public class SchedulazioneRotCreatedBuilder : IEventBuilder<SchedulazioneRotCreated>
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
		private Period  _period ; 
		private string  _convoglio ; 
		private string  _rigaTurnoTreno ; 
		private string  _turnoTreno ; 
		private Treno  _trenoArrivo ; 
		private Treno  _trenoPartenza ; 
		private OggettoRot[]  _oggetti ;
		public SchedulazioneRotCreatedBuilder ForProgramma(Guid idProgramma) 
		{
			_idProgramma = idProgramma;
			return this;
		}
	
		public SchedulazioneRotCreatedBuilder ForPeriodoProgrammazione(Guid idPeriodoProgrammazione) 
		{
			_idPeriodoProgrammazione = idPeriodoProgrammazione;
			return this;
		}
	
		public SchedulazioneRotCreatedBuilder ForCommittente(Guid idCommittente) 
		{
			_idCommittente = idCommittente;
			return this;
		}
	
		public SchedulazioneRotCreatedBuilder ForLotto(Guid idLotto) 
		{
			_idLotto = idLotto;
			return this;
		}
	
		public SchedulazioneRotCreatedBuilder ForImpianto(Guid idImpianto) 
		{
			_idImpianto = idImpianto;
			return this;
		}
	
		public SchedulazioneRotCreatedBuilder OfTipoIntervento(Guid idTipoIntervento) 
		{
			_idTipoIntervento = idTipoIntervento;
			return this;
		}
	
		public SchedulazioneRotCreatedBuilder ForAppaltatore(Guid idAppaltatore) 
		{
			_idAppaltatore = idAppaltatore;
			return this;
		}
	
		public SchedulazioneRotCreatedBuilder ForCategoriaCommerciale(Guid idCategoriaCommerciale) 
		{
			_idCategoriaCommerciale = idCategoriaCommerciale;
			return this;
		}
	
		public SchedulazioneRotCreatedBuilder ForDirezioneRegionale(Guid idDirezioneRegionale) 
		{
			_idDirezioneRegionale = idDirezioneRegionale;
			return this;
		}
	
		public SchedulazioneRotCreatedBuilder WithNote(string note) 
		{
			_note = note;
			return this;
		}
	
		public SchedulazioneRotCreatedBuilder ForWorkPeriod(WorkPeriod workPeriod) 
		{
			_workPeriod = workPeriod;
			return this;
		}
	
		public SchedulazioneRotCreatedBuilder ForPeriod(Period period) 
		{
			_period = period;
			return this;
		}
	
		public SchedulazioneRotCreatedBuilder ForConvoglio(string convoglio) 
		{
			_convoglio = convoglio;
			return this;
		}
	
		public SchedulazioneRotCreatedBuilder WithRigaTurnoTreno(string rigaTurnoTreno) 
		{
			_rigaTurnoTreno = rigaTurnoTreno;
			return this;
		}
	
		public SchedulazioneRotCreatedBuilder WithTurnoTreno(string turnoTreno) 
		{
			_turnoTreno = turnoTreno;
			return this;
		}
	
		public SchedulazioneRotCreatedBuilder WithTrenoArrivo(Treno trenoArrivo) 
		{
			_trenoArrivo = trenoArrivo;
			return this;
		}
	
		public SchedulazioneRotCreatedBuilder WithTrenoPartenza(Treno trenoPartenza) 
		{
			_trenoPartenza = trenoPartenza;
			return this;
		}
	
		public SchedulazioneRotCreatedBuilder WithOggetti(OggettoRot[] oggetti) 
		{
			_oggetti = oggetti;
			return this;
		}
	
		public SchedulazioneRotCreated Build(Guid id, long version)
		{
			return Build(id, Guid.NewGuid(), version);
		}

		public SchedulazioneRotCreated Build(Guid id, Guid commitId, long version)
        {
            return new SchedulazioneRotCreated(id, commitId, version, _idProgramma, _idPeriodoProgrammazione, _idCommittente, _idLotto, _idImpianto, _idTipoIntervento, _idAppaltatore, _idCategoriaCommerciale, _idDirezioneRegionale, _note, _workPeriod, _period, _convoglio, _rigaTurnoTreno, _turnoTreno, _trenoArrivo, _trenoPartenza, _oggetti);
		 }

       
	
	}

	public class SchedulazioneRotManCreatedBuilder : IEventBuilder<SchedulazioneRotManCreated>
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
		private Period  _period ; 
		private OggettoRotMan[]  _oggetti ;
		public SchedulazioneRotManCreatedBuilder ForProgramma(Guid idProgramma) 
		{
			_idProgramma = idProgramma;
			return this;
		}
	
		public SchedulazioneRotManCreatedBuilder ForPeriodoProgrammazione(Guid idPeriodoProgrammazione) 
		{
			_idPeriodoProgrammazione = idPeriodoProgrammazione;
			return this;
		}
	
		public SchedulazioneRotManCreatedBuilder ForCommittente(Guid idCommittente) 
		{
			_idCommittente = idCommittente;
			return this;
		}
	
		public SchedulazioneRotManCreatedBuilder ForLotto(Guid idLotto) 
		{
			_idLotto = idLotto;
			return this;
		}
	
		public SchedulazioneRotManCreatedBuilder ForImpianto(Guid idImpianto) 
		{
			_idImpianto = idImpianto;
			return this;
		}
	
		public SchedulazioneRotManCreatedBuilder OfTipoIntervento(Guid idTipoIntervento) 
		{
			_idTipoIntervento = idTipoIntervento;
			return this;
		}
	
		public SchedulazioneRotManCreatedBuilder ForAppaltatore(Guid idAppaltatore) 
		{
			_idAppaltatore = idAppaltatore;
			return this;
		}
	
		public SchedulazioneRotManCreatedBuilder ForCategoriaCommerciale(Guid idCategoriaCommerciale) 
		{
			_idCategoriaCommerciale = idCategoriaCommerciale;
			return this;
		}
	
		public SchedulazioneRotManCreatedBuilder ForDirezioneRegionale(Guid idDirezioneRegionale) 
		{
			_idDirezioneRegionale = idDirezioneRegionale;
			return this;
		}
	
		public SchedulazioneRotManCreatedBuilder WithNote(string note) 
		{
			_note = note;
			return this;
		}
	
		public SchedulazioneRotManCreatedBuilder ForWorkPeriod(WorkPeriod workPeriod) 
		{
			_workPeriod = workPeriod;
			return this;
		}
	
		public SchedulazioneRotManCreatedBuilder ForPeriod(Period period) 
		{
			_period = period;
			return this;
		}
	
		public SchedulazioneRotManCreatedBuilder WithOggetti(OggettoRotMan[] oggetti) 
		{
			_oggetti = oggetti;
			return this;
		}
	
		public SchedulazioneRotManCreated Build(Guid id, long version)
		{
			return Build(id, Guid.NewGuid(), version);
		}

		public SchedulazioneRotManCreated Build(Guid id, Guid commitId, long version)
        {
            return new SchedulazioneRotManCreated(id, commitId, version, _idProgramma, _idPeriodoProgrammazione, _idCommittente, _idLotto, _idImpianto, _idTipoIntervento, _idAppaltatore, _idCategoriaCommerciale, _idDirezioneRegionale, _note, _workPeriod, _period, _oggetti);
		 }

       
	
	}

	public class SchedulazioneAmbCreatedBuilder : IEventBuilder<SchedulazioneAmbCreated>
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
		private Period  _period ; 
		private int  _quantity ; 
		private string  _description ;
		public SchedulazioneAmbCreatedBuilder ForProgramma(Guid idProgramma) 
		{
			_idProgramma = idProgramma;
			return this;
		}
	
		public SchedulazioneAmbCreatedBuilder ForPeriodoProgrammazione(Guid idPeriodoProgrammazione) 
		{
			_idPeriodoProgrammazione = idPeriodoProgrammazione;
			return this;
		}
	
		public SchedulazioneAmbCreatedBuilder ForCommittente(Guid idCommittente) 
		{
			_idCommittente = idCommittente;
			return this;
		}
	
		public SchedulazioneAmbCreatedBuilder ForLotto(Guid idLotto) 
		{
			_idLotto = idLotto;
			return this;
		}
	
		public SchedulazioneAmbCreatedBuilder ForImpianto(Guid idImpianto) 
		{
			_idImpianto = idImpianto;
			return this;
		}
	
		public SchedulazioneAmbCreatedBuilder OfTipoIntervento(Guid idTipoIntervento) 
		{
			_idTipoIntervento = idTipoIntervento;
			return this;
		}
	
		public SchedulazioneAmbCreatedBuilder ForAppaltatore(Guid idAppaltatore) 
		{
			_idAppaltatore = idAppaltatore;
			return this;
		}
	
		public SchedulazioneAmbCreatedBuilder ForCategoriaCommerciale(Guid idCategoriaCommerciale) 
		{
			_idCategoriaCommerciale = idCategoriaCommerciale;
			return this;
		}
	
		public SchedulazioneAmbCreatedBuilder ForDirezioneRegionale(Guid idDirezioneRegionale) 
		{
			_idDirezioneRegionale = idDirezioneRegionale;
			return this;
		}
	
		public SchedulazioneAmbCreatedBuilder WithNote(string note) 
		{
			_note = note;
			return this;
		}
	
		public SchedulazioneAmbCreatedBuilder ForWorkPeriod(WorkPeriod workPeriod) 
		{
			_workPeriod = workPeriod;
			return this;
		}
	
		public SchedulazioneAmbCreatedBuilder ForPeriod(Period period) 
		{
			_period = period;
			return this;
		}
	
		public SchedulazioneAmbCreatedBuilder ForQuantity(int quantity) 
		{
			_quantity = quantity;
			return this;
		}
	
		public SchedulazioneAmbCreatedBuilder ForDescription(string description) 
		{
			_description = description;
			return this;
		}
	
		public SchedulazioneAmbCreated Build(Guid id, long version)
		{
			return Build(id, Guid.NewGuid(), version);
		}

		public SchedulazioneAmbCreated Build(Guid id, Guid commitId, long version)
        {
            return new SchedulazioneAmbCreated(id, commitId, version, _idProgramma, _idPeriodoProgrammazione, _idCommittente, _idLotto, _idImpianto, _idTipoIntervento, _idAppaltatore, _idCategoriaCommerciale, _idDirezioneRegionale, _note, _workPeriod, _period, _quantity, _description);
		 }

       
	
	}
}

namespace Super.Programmazione.Events
{
	public static partial class BuildEvt 
	{
		  public static SchedulazioneRotCreatedBuilder SchedulazioneRotCreated {get { return new SchedulazioneRotCreatedBuilder(); } }
	  		  public static SchedulazioneRotManCreatedBuilder SchedulazioneRotManCreated {get { return new SchedulazioneRotManCreatedBuilder(); } }
	  		  public static SchedulazioneAmbCreatedBuilder SchedulazioneAmbCreated {get { return new SchedulazioneAmbCreatedBuilder(); } }
	  	}
}
