



using System;
using CommonDomain;
using System.Diagnostics.Contracts;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using Super.Programmazione.Events.Programma;
using Super.Programmazione.Events.Programma.Builders;

namespace Super.Programmazione.Events.Programma.Builders
{


	public class SchedulazioneRotAddedToProgrammaBuilder : IEventBuilder<SchedulazioneRotAddedToProgramma>
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
		public SchedulazioneRotAddedToProgrammaBuilder ForIdPeriodoProgrammazione(Guid idPeriodoProgrammazione) 
		{
			_idPeriodoProgrammazione = idPeriodoProgrammazione;
			return this;
		}
	
		public SchedulazioneRotAddedToProgrammaBuilder ForIdSchedulazione(Guid idSchedulazione) 
		{
			_idSchedulazione = idSchedulazione;
			return this;
		}
	
		public SchedulazioneRotAddedToProgrammaBuilder ForIdCommittente(Guid idCommittente) 
		{
			_idCommittente = idCommittente;
			return this;
		}
	
		public SchedulazioneRotAddedToProgrammaBuilder ForIdLotto(Guid idLotto) 
		{
			_idLotto = idLotto;
			return this;
		}
	
		public SchedulazioneRotAddedToProgrammaBuilder ForIdImpianto(Guid idImpianto) 
		{
			_idImpianto = idImpianto;
			return this;
		}
	
		public SchedulazioneRotAddedToProgrammaBuilder ForIdTipoIntervento(Guid idTipoIntervento) 
		{
			_idTipoIntervento = idTipoIntervento;
			return this;
		}
	
		public SchedulazioneRotAddedToProgrammaBuilder ForIdAppaltatore(Guid idAppaltatore) 
		{
			_idAppaltatore = idAppaltatore;
			return this;
		}
	
		public SchedulazioneRotAddedToProgrammaBuilder ForIdCategoriaCommerciale(Guid idCategoriaCommerciale) 
		{
			_idCategoriaCommerciale = idCategoriaCommerciale;
			return this;
		}
	
		public SchedulazioneRotAddedToProgrammaBuilder ForIdDirezioneRegionale(Guid idDirezioneRegionale) 
		{
			_idDirezioneRegionale = idDirezioneRegionale;
			return this;
		}
	
		public SchedulazioneRotAddedToProgrammaBuilder ForNote(string note) 
		{
			_note = note;
			return this;
		}
	
		public SchedulazioneRotAddedToProgrammaBuilder ForWorkPeriod(WorkPeriod workPeriod) 
		{
			_workPeriod = workPeriod;
			return this;
		}
	
		public SchedulazioneRotAddedToProgrammaBuilder ForPeriod(Period period) 
		{
			_period = period;
			return this;
		}
	
		public SchedulazioneRotAddedToProgrammaBuilder ForConvoglio(string convoglio) 
		{
			_convoglio = convoglio;
			return this;
		}
	
		public SchedulazioneRotAddedToProgrammaBuilder ForRigaTurnoTreno(string rigaTurnoTreno) 
		{
			_rigaTurnoTreno = rigaTurnoTreno;
			return this;
		}
	
		public SchedulazioneRotAddedToProgrammaBuilder ForTurnoTreno(string turnoTreno) 
		{
			_turnoTreno = turnoTreno;
			return this;
		}
	
		public SchedulazioneRotAddedToProgrammaBuilder ForTrenoArrivo(Treno trenoArrivo) 
		{
			_trenoArrivo = trenoArrivo;
			return this;
		}
	
		public SchedulazioneRotAddedToProgrammaBuilder ForTrenoPartenza(Treno trenoPartenza) 
		{
			_trenoPartenza = trenoPartenza;
			return this;
		}
	
		public SchedulazioneRotAddedToProgrammaBuilder ForOggetti(OggettoRot[] oggetti) 
		{
			_oggetti = oggetti;
			return this;
		}
	
		public SchedulazioneRotAddedToProgramma Build(Guid id, long version)
		{
			return Build(id, Guid.NewGuid(), version);
		}

		public SchedulazioneRotAddedToProgramma Build(Guid id, Guid commitId, long version)
        {
            return new SchedulazioneRotAddedToProgramma(id, commitId, version, _idPeriodoProgrammazione, _idSchedulazione, _idCommittente, _idLotto, _idImpianto, _idTipoIntervento, _idAppaltatore, _idCategoriaCommerciale, _idDirezioneRegionale, _note, _workPeriod, _period, _convoglio, _rigaTurnoTreno, _turnoTreno, _trenoArrivo, _trenoPartenza, _oggetti);
		 }
        
	
	}

	public class SchedulazioneRotManAddedToProgrammaBuilder : IEventBuilder<SchedulazioneRotManAddedToProgramma>
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
		public SchedulazioneRotManAddedToProgrammaBuilder ForIdPeriodoProgrammazione(Guid idPeriodoProgrammazione) 
		{
			_idPeriodoProgrammazione = idPeriodoProgrammazione;
			return this;
		}
	
		public SchedulazioneRotManAddedToProgrammaBuilder ForIdSchedulazione(Guid idSchedulazione) 
		{
			_idSchedulazione = idSchedulazione;
			return this;
		}
	
		public SchedulazioneRotManAddedToProgrammaBuilder ForIdCommittente(Guid idCommittente) 
		{
			_idCommittente = idCommittente;
			return this;
		}
	
		public SchedulazioneRotManAddedToProgrammaBuilder ForIdLotto(Guid idLotto) 
		{
			_idLotto = idLotto;
			return this;
		}
	
		public SchedulazioneRotManAddedToProgrammaBuilder ForIdImpianto(Guid idImpianto) 
		{
			_idImpianto = idImpianto;
			return this;
		}
	
		public SchedulazioneRotManAddedToProgrammaBuilder ForIdTipoIntervento(Guid idTipoIntervento) 
		{
			_idTipoIntervento = idTipoIntervento;
			return this;
		}
	
		public SchedulazioneRotManAddedToProgrammaBuilder ForIdAppaltatore(Guid idAppaltatore) 
		{
			_idAppaltatore = idAppaltatore;
			return this;
		}
	
		public SchedulazioneRotManAddedToProgrammaBuilder ForIdCategoriaCommerciale(Guid idCategoriaCommerciale) 
		{
			_idCategoriaCommerciale = idCategoriaCommerciale;
			return this;
		}
	
		public SchedulazioneRotManAddedToProgrammaBuilder ForIdDirezioneRegionale(Guid idDirezioneRegionale) 
		{
			_idDirezioneRegionale = idDirezioneRegionale;
			return this;
		}
	
		public SchedulazioneRotManAddedToProgrammaBuilder ForNote(string note) 
		{
			_note = note;
			return this;
		}
	
		public SchedulazioneRotManAddedToProgrammaBuilder ForWorkPeriod(WorkPeriod workPeriod) 
		{
			_workPeriod = workPeriod;
			return this;
		}
	
		public SchedulazioneRotManAddedToProgrammaBuilder ForPeriod(Period period) 
		{
			_period = period;
			return this;
		}
	
		public SchedulazioneRotManAddedToProgrammaBuilder ForOggetti(OggettoRotMan[] oggetti) 
		{
			_oggetti = oggetti;
			return this;
		}
	
		public SchedulazioneRotManAddedToProgramma Build(Guid id, long version)
		{
			return Build(id, Guid.NewGuid(), version);
		}

		public SchedulazioneRotManAddedToProgramma Build(Guid id, Guid commitId, long version)
        {
            return new SchedulazioneRotManAddedToProgramma(id, commitId, version, _idPeriodoProgrammazione, _idSchedulazione, _idCommittente, _idLotto, _idImpianto, _idTipoIntervento, _idAppaltatore, _idCategoriaCommerciale, _idDirezioneRegionale, _note, _workPeriod, _period, _oggetti);
		 }
        
	
	}

	public class SchedulazioneAmbAddedToProgrammaBuilder : IEventBuilder<SchedulazioneAmbAddedToProgramma>
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
		public SchedulazioneAmbAddedToProgrammaBuilder ForIdPeriodoProgrammazione(Guid idPeriodoProgrammazione) 
		{
			_idPeriodoProgrammazione = idPeriodoProgrammazione;
			return this;
		}
	
		public SchedulazioneAmbAddedToProgrammaBuilder ForIdSchedulazione(Guid idSchedulazione) 
		{
			_idSchedulazione = idSchedulazione;
			return this;
		}
	
		public SchedulazioneAmbAddedToProgrammaBuilder ForIdCommittente(Guid idCommittente) 
		{
			_idCommittente = idCommittente;
			return this;
		}
	
		public SchedulazioneAmbAddedToProgrammaBuilder ForIdLotto(Guid idLotto) 
		{
			_idLotto = idLotto;
			return this;
		}
	
		public SchedulazioneAmbAddedToProgrammaBuilder ForIdImpianto(Guid idImpianto) 
		{
			_idImpianto = idImpianto;
			return this;
		}
	
		public SchedulazioneAmbAddedToProgrammaBuilder ForIdTipoIntervento(Guid idTipoIntervento) 
		{
			_idTipoIntervento = idTipoIntervento;
			return this;
		}
	
		public SchedulazioneAmbAddedToProgrammaBuilder ForIdAppaltatore(Guid idAppaltatore) 
		{
			_idAppaltatore = idAppaltatore;
			return this;
		}
	
		public SchedulazioneAmbAddedToProgrammaBuilder ForIdCategoriaCommerciale(Guid idCategoriaCommerciale) 
		{
			_idCategoriaCommerciale = idCategoriaCommerciale;
			return this;
		}
	
		public SchedulazioneAmbAddedToProgrammaBuilder ForIdDirezioneRegionale(Guid idDirezioneRegionale) 
		{
			_idDirezioneRegionale = idDirezioneRegionale;
			return this;
		}
	
		public SchedulazioneAmbAddedToProgrammaBuilder ForNote(string note) 
		{
			_note = note;
			return this;
		}
	
		public SchedulazioneAmbAddedToProgrammaBuilder ForWorkPeriod(WorkPeriod workPeriod) 
		{
			_workPeriod = workPeriod;
			return this;
		}
	
		public SchedulazioneAmbAddedToProgrammaBuilder ForPeriod(Period period) 
		{
			_period = period;
			return this;
		}
	
		public SchedulazioneAmbAddedToProgrammaBuilder ForQuantity(int quantity) 
		{
			_quantity = quantity;
			return this;
		}
	
		public SchedulazioneAmbAddedToProgrammaBuilder ForDescription(string description) 
		{
			_description = description;
			return this;
		}
	
		public SchedulazioneAmbAddedToProgramma Build(Guid id, long version)
		{
			return Build(id, Guid.NewGuid(), version);
		}

		public SchedulazioneAmbAddedToProgramma Build(Guid id, Guid commitId, long version)
        {
            return new SchedulazioneAmbAddedToProgramma(id, commitId, version, _idPeriodoProgrammazione, _idSchedulazione, _idCommittente, _idLotto, _idImpianto, _idTipoIntervento, _idAppaltatore, _idCategoriaCommerciale, _idDirezioneRegionale, _note, _workPeriod, _period, _quantity, _description);
		 }
        
	
	}
}

namespace Super.Programmazione.Events
{
	public static partial class BuildEvt 
	{
		  public static SchedulazioneRotAddedToProgrammaBuilder SchedulazioneRotAddedToProgramma {get { return new SchedulazioneRotAddedToProgrammaBuilder(); } }
	  		  public static SchedulazioneRotManAddedToProgrammaBuilder SchedulazioneRotManAddedToProgramma {get { return new SchedulazioneRotManAddedToProgrammaBuilder(); } }
	  		  public static SchedulazioneAmbAddedToProgrammaBuilder SchedulazioneAmbAddedToProgramma {get { return new SchedulazioneAmbAddedToProgrammaBuilder(); } }
	  	}
}
