


using System;
using CommonDomain;
using System.Diagnostics.Contracts;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using Super.Controllo.Events.Programmazione;
using Super.Controllo.Events.Programmazione.Builders;

namespace Super.Controllo.Events.Programmazione.Builders
{


	public class InterventoRotProgrammatoBuilder : IEventBuilder<InterventoRotProgrammato>
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
		public InterventoRotProgrammatoBuilder ForProgramma(Guid idProgramma) 
		{
			_idProgramma = idProgramma;
			return this;
		}
	
		public InterventoRotProgrammatoBuilder ForPeriodoProgrammazione(Guid idPeriodoProgrammazione) 
		{
			_idPeriodoProgrammazione = idPeriodoProgrammazione;
			return this;
		}
	
		public InterventoRotProgrammatoBuilder ForCommittente(Guid idCommittente) 
		{
			_idCommittente = idCommittente;
			return this;
		}
	
		public InterventoRotProgrammatoBuilder ForLotto(Guid idLotto) 
		{
			_idLotto = idLotto;
			return this;
		}
	
		public InterventoRotProgrammatoBuilder ForImpianto(Guid idImpianto) 
		{
			_idImpianto = idImpianto;
			return this;
		}
	
		public InterventoRotProgrammatoBuilder OfTipoIntervento(Guid idTipoIntervento) 
		{
			_idTipoIntervento = idTipoIntervento;
			return this;
		}
	
		public InterventoRotProgrammatoBuilder ForAppaltatore(Guid idAppaltatore) 
		{
			_idAppaltatore = idAppaltatore;
			return this;
		}
	
		public InterventoRotProgrammatoBuilder ForCategoriaCommerciale(Guid idCategoriaCommerciale) 
		{
			_idCategoriaCommerciale = idCategoriaCommerciale;
			return this;
		}
	
		public InterventoRotProgrammatoBuilder ForDirezioneRegionale(Guid idDirezioneRegionale) 
		{
			_idDirezioneRegionale = idDirezioneRegionale;
			return this;
		}
	
		public InterventoRotProgrammatoBuilder WithNote(string note) 
		{
			_note = note;
			return this;
		}
	
		public InterventoRotProgrammatoBuilder ForWorkPeriod(WorkPeriod workPeriod) 
		{
			_workPeriod = workPeriod;
			return this;
		}
	
		public InterventoRotProgrammatoBuilder ForConvoglio(string convoglio) 
		{
			_convoglio = convoglio;
			return this;
		}
	
		public InterventoRotProgrammatoBuilder WithRigaTurnoTreno(string rigaTurnoTreno) 
		{
			_rigaTurnoTreno = rigaTurnoTreno;
			return this;
		}
	
		public InterventoRotProgrammatoBuilder WithTurnoTreno(string turnoTreno) 
		{
			_turnoTreno = turnoTreno;
			return this;
		}
	
		public InterventoRotProgrammatoBuilder WithTrenoArrivo(Treno trenoArrivo) 
		{
			_trenoArrivo = trenoArrivo;
			return this;
		}
	
		public InterventoRotProgrammatoBuilder WithTrenoPartenza(Treno trenoPartenza) 
		{
			_trenoPartenza = trenoPartenza;
			return this;
		}
	
		public InterventoRotProgrammatoBuilder WithOggetti(OggettoRot[] oggetti) 
		{
			_oggetti = oggetti;
			return this;
		}
	
		public InterventoRotProgrammato Build(Guid id, long version)
		{
			return Build(id, Guid.NewGuid(), version);
		}

		public InterventoRotProgrammato Build(Guid id, Guid commitId, long version)
        {
            return new InterventoRotProgrammato(id, commitId, version, _idProgramma, _idPeriodoProgrammazione, _idCommittente, _idLotto, _idImpianto, _idTipoIntervento, _idAppaltatore, _idCategoriaCommerciale, _idDirezioneRegionale, _note, _workPeriod, _convoglio, _rigaTurnoTreno, _turnoTreno, _trenoArrivo, _trenoPartenza, _oggetti);
		 }

       
	
	}

	public class InterventoRotManProgrammatoBuilder : IEventBuilder<InterventoRotManProgrammato>
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
		public InterventoRotManProgrammatoBuilder ForProgramma(Guid idProgramma) 
		{
			_idProgramma = idProgramma;
			return this;
		}
	
		public InterventoRotManProgrammatoBuilder ForPeriodoProgrammazione(Guid idPeriodoProgrammazione) 
		{
			_idPeriodoProgrammazione = idPeriodoProgrammazione;
			return this;
		}
	
		public InterventoRotManProgrammatoBuilder ForCommittente(Guid idCommittente) 
		{
			_idCommittente = idCommittente;
			return this;
		}
	
		public InterventoRotManProgrammatoBuilder ForLotto(Guid idLotto) 
		{
			_idLotto = idLotto;
			return this;
		}
	
		public InterventoRotManProgrammatoBuilder ForImpianto(Guid idImpianto) 
		{
			_idImpianto = idImpianto;
			return this;
		}
	
		public InterventoRotManProgrammatoBuilder OfTipoIntervento(Guid idTipoIntervento) 
		{
			_idTipoIntervento = idTipoIntervento;
			return this;
		}
	
		public InterventoRotManProgrammatoBuilder ForAppaltatore(Guid idAppaltatore) 
		{
			_idAppaltatore = idAppaltatore;
			return this;
		}
	
		public InterventoRotManProgrammatoBuilder ForCategoriaCommerciale(Guid idCategoriaCommerciale) 
		{
			_idCategoriaCommerciale = idCategoriaCommerciale;
			return this;
		}
	
		public InterventoRotManProgrammatoBuilder ForDirezioneRegionale(Guid idDirezioneRegionale) 
		{
			_idDirezioneRegionale = idDirezioneRegionale;
			return this;
		}
	
		public InterventoRotManProgrammatoBuilder WithNote(string note) 
		{
			_note = note;
			return this;
		}
	
		public InterventoRotManProgrammatoBuilder ForWorkPeriod(WorkPeriod workPeriod) 
		{
			_workPeriod = workPeriod;
			return this;
		}
	
		public InterventoRotManProgrammatoBuilder WithOggetti(OggettoRotMan[] oggetti) 
		{
			_oggetti = oggetti;
			return this;
		}
	
		public InterventoRotManProgrammato Build(Guid id, long version)
		{
			return Build(id, Guid.NewGuid(), version);
		}

		public InterventoRotManProgrammato Build(Guid id, Guid commitId, long version)
        {
            return new InterventoRotManProgrammato(id, commitId, version, _idProgramma, _idPeriodoProgrammazione, _idCommittente, _idLotto, _idImpianto, _idTipoIntervento, _idAppaltatore, _idCategoriaCommerciale, _idDirezioneRegionale, _note, _workPeriod, _oggetti);
		 }

       
	
	}

	public class InterventoAmbProgrammatoBuilder : IEventBuilder<InterventoAmbProgrammato>
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
		public InterventoAmbProgrammatoBuilder ForProgramma(Guid idProgramma) 
		{
			_idProgramma = idProgramma;
			return this;
		}
	
		public InterventoAmbProgrammatoBuilder ForPeriodoProgrammazione(Guid idPeriodoProgrammazione) 
		{
			_idPeriodoProgrammazione = idPeriodoProgrammazione;
			return this;
		}
	
		public InterventoAmbProgrammatoBuilder ForCommittente(Guid idCommittente) 
		{
			_idCommittente = idCommittente;
			return this;
		}
	
		public InterventoAmbProgrammatoBuilder ForLotto(Guid idLotto) 
		{
			_idLotto = idLotto;
			return this;
		}
	
		public InterventoAmbProgrammatoBuilder ForImpianto(Guid idImpianto) 
		{
			_idImpianto = idImpianto;
			return this;
		}
	
		public InterventoAmbProgrammatoBuilder OfTipoIntervento(Guid idTipoIntervento) 
		{
			_idTipoIntervento = idTipoIntervento;
			return this;
		}
	
		public InterventoAmbProgrammatoBuilder ForAppaltatore(Guid idAppaltatore) 
		{
			_idAppaltatore = idAppaltatore;
			return this;
		}
	
		public InterventoAmbProgrammatoBuilder ForCategoriaCommerciale(Guid idCategoriaCommerciale) 
		{
			_idCategoriaCommerciale = idCategoriaCommerciale;
			return this;
		}
	
		public InterventoAmbProgrammatoBuilder ForDirezioneRegionale(Guid idDirezioneRegionale) 
		{
			_idDirezioneRegionale = idDirezioneRegionale;
			return this;
		}
	
		public InterventoAmbProgrammatoBuilder WithNote(string note) 
		{
			_note = note;
			return this;
		}
	
		public InterventoAmbProgrammatoBuilder ForWorkPeriod(WorkPeriod workPeriod) 
		{
			_workPeriod = workPeriod;
			return this;
		}
	
		public InterventoAmbProgrammatoBuilder ForQuantity(int quantity) 
		{
			_quantity = quantity;
			return this;
		}
	
		public InterventoAmbProgrammatoBuilder ForDescription(string description) 
		{
			_description = description;
			return this;
		}
	
		public InterventoAmbProgrammato Build(Guid id, long version)
		{
			return Build(id, Guid.NewGuid(), version);
		}

		public InterventoAmbProgrammato Build(Guid id, Guid commitId, long version)
        {
            return new InterventoAmbProgrammato(id, commitId, version, _idProgramma, _idPeriodoProgrammazione, _idCommittente, _idLotto, _idImpianto, _idTipoIntervento, _idAppaltatore, _idCategoriaCommerciale, _idDirezioneRegionale, _note, _workPeriod, _quantity, _description);
		 }

       
	
	}
}

namespace Super.Controllo.Events
{
	public static partial class BuildEvt 
	{
		  public static InterventoRotProgrammatoBuilder InterventoRotProgrammato {get { return new InterventoRotProgrammatoBuilder(); } }
	  		  public static InterventoRotManProgrammatoBuilder InterventoRotManProgrammato {get { return new InterventoRotManProgrammatoBuilder(); } }
	  		  public static InterventoAmbProgrammatoBuilder InterventoAmbProgrammato {get { return new InterventoAmbProgrammatoBuilder(); } }
	  	}
}
