



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
		public AddSchedulazioneRotToProgrammaBuilder ForIdPeriodoProgrammazione(Guid idPeriodoProgrammazione) 
		{
			_idPeriodoProgrammazione = idPeriodoProgrammazione;
			return this;
		}
	
		public AddSchedulazioneRotToProgrammaBuilder ForIdSchedulazione(Guid idSchedulazione) 
		{
			_idSchedulazione = idSchedulazione;
			return this;
		}
	
		public AddSchedulazioneRotToProgrammaBuilder ForIdCommittente(Guid idCommittente) 
		{
			_idCommittente = idCommittente;
			return this;
		}
	
		public AddSchedulazioneRotToProgrammaBuilder ForIdLotto(Guid idLotto) 
		{
			_idLotto = idLotto;
			return this;
		}
	
		public AddSchedulazioneRotToProgrammaBuilder ForIdImpianto(Guid idImpianto) 
		{
			_idImpianto = idImpianto;
			return this;
		}
	
		public AddSchedulazioneRotToProgrammaBuilder ForIdTipoIntervento(Guid idTipoIntervento) 
		{
			_idTipoIntervento = idTipoIntervento;
			return this;
		}
	
		public AddSchedulazioneRotToProgrammaBuilder ForIdAppaltatore(Guid idAppaltatore) 
		{
			_idAppaltatore = idAppaltatore;
			return this;
		}
	
		public AddSchedulazioneRotToProgrammaBuilder ForIdCategoriaCommerciale(Guid idCategoriaCommerciale) 
		{
			_idCategoriaCommerciale = idCategoriaCommerciale;
			return this;
		}
	
		public AddSchedulazioneRotToProgrammaBuilder ForIdDirezioneRegionale(Guid idDirezioneRegionale) 
		{
			_idDirezioneRegionale = idDirezioneRegionale;
			return this;
		}
	
		public AddSchedulazioneRotToProgrammaBuilder ForNote(string note) 
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
	
		public AddSchedulazioneRotToProgrammaBuilder ForRigaTurnoTreno(string rigaTurnoTreno) 
		{
			_rigaTurnoTreno = rigaTurnoTreno;
			return this;
		}
	
		public AddSchedulazioneRotToProgrammaBuilder ForTurnoTreno(string turnoTreno) 
		{
			_turnoTreno = turnoTreno;
			return this;
		}
	
		public AddSchedulazioneRotToProgrammaBuilder ForTrenoArrivo(Treno trenoArrivo) 
		{
			_trenoArrivo = trenoArrivo;
			return this;
		}
	
		public AddSchedulazioneRotToProgrammaBuilder ForTrenoPartenza(Treno trenoPartenza) 
		{
			_trenoPartenza = trenoPartenza;
			return this;
		}
	
		public AddSchedulazioneRotToProgrammaBuilder ForOggetti(OggettoRot[] oggetti) 
		{
			_oggetti = oggetti;
			return this;
		}
	
		public AddSchedulazioneRotToProgramma Build(Guid id, long version)
		{
			return Build(id, Guid.NewGuid(), version);
		}

		public AddSchedulazioneRotToProgramma Build(Guid id, Guid commitId, long version)
        {
            return new AddSchedulazioneRotToProgramma(id, commitId, version, _idPeriodoProgrammazione, _idSchedulazione, _idCommittente, _idLotto, _idImpianto, _idTipoIntervento, _idAppaltatore, _idCategoriaCommerciale, _idDirezioneRegionale, _note, _workPeriod, _period, _convoglio, _rigaTurnoTreno, _turnoTreno, _trenoArrivo, _trenoPartenza, _oggetti);
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
		public AddSchedulazioneRotManToProgrammaBuilder ForIdPeriodoProgrammazione(Guid idPeriodoProgrammazione) 
		{
			_idPeriodoProgrammazione = idPeriodoProgrammazione;
			return this;
		}
	
		public AddSchedulazioneRotManToProgrammaBuilder ForIdSchedulazione(Guid idSchedulazione) 
		{
			_idSchedulazione = idSchedulazione;
			return this;
		}
	
		public AddSchedulazioneRotManToProgrammaBuilder ForIdCommittente(Guid idCommittente) 
		{
			_idCommittente = idCommittente;
			return this;
		}
	
		public AddSchedulazioneRotManToProgrammaBuilder ForIdLotto(Guid idLotto) 
		{
			_idLotto = idLotto;
			return this;
		}
	
		public AddSchedulazioneRotManToProgrammaBuilder ForIdImpianto(Guid idImpianto) 
		{
			_idImpianto = idImpianto;
			return this;
		}
	
		public AddSchedulazioneRotManToProgrammaBuilder ForIdTipoIntervento(Guid idTipoIntervento) 
		{
			_idTipoIntervento = idTipoIntervento;
			return this;
		}
	
		public AddSchedulazioneRotManToProgrammaBuilder ForIdAppaltatore(Guid idAppaltatore) 
		{
			_idAppaltatore = idAppaltatore;
			return this;
		}
	
		public AddSchedulazioneRotManToProgrammaBuilder ForIdCategoriaCommerciale(Guid idCategoriaCommerciale) 
		{
			_idCategoriaCommerciale = idCategoriaCommerciale;
			return this;
		}
	
		public AddSchedulazioneRotManToProgrammaBuilder ForIdDirezioneRegionale(Guid idDirezioneRegionale) 
		{
			_idDirezioneRegionale = idDirezioneRegionale;
			return this;
		}
	
		public AddSchedulazioneRotManToProgrammaBuilder ForNote(string note) 
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
	
		public AddSchedulazioneRotManToProgrammaBuilder ForOggetti(OggettoRotMan[] oggetti) 
		{
			_oggetti = oggetti;
			return this;
		}
	
		public AddSchedulazioneRotManToProgramma Build(Guid id, long version)
		{
			return Build(id, Guid.NewGuid(), version);
		}

		public AddSchedulazioneRotManToProgramma Build(Guid id, Guid commitId, long version)
        {
            return new AddSchedulazioneRotManToProgramma(id, commitId, version, _idPeriodoProgrammazione, _idSchedulazione, _idCommittente, _idLotto, _idImpianto, _idTipoIntervento, _idAppaltatore, _idCategoriaCommerciale, _idDirezioneRegionale, _note, _workPeriod, _period, _oggetti);
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
		public AddSchedulazioneAmbToProgrammaBuilder ForIdPeriodoProgrammazione(Guid idPeriodoProgrammazione) 
		{
			_idPeriodoProgrammazione = idPeriodoProgrammazione;
			return this;
		}
	
		public AddSchedulazioneAmbToProgrammaBuilder ForIdSchedulazione(Guid idSchedulazione) 
		{
			_idSchedulazione = idSchedulazione;
			return this;
		}
	
		public AddSchedulazioneAmbToProgrammaBuilder ForIdCommittente(Guid idCommittente) 
		{
			_idCommittente = idCommittente;
			return this;
		}
	
		public AddSchedulazioneAmbToProgrammaBuilder ForIdLotto(Guid idLotto) 
		{
			_idLotto = idLotto;
			return this;
		}
	
		public AddSchedulazioneAmbToProgrammaBuilder ForIdImpianto(Guid idImpianto) 
		{
			_idImpianto = idImpianto;
			return this;
		}
	
		public AddSchedulazioneAmbToProgrammaBuilder ForIdTipoIntervento(Guid idTipoIntervento) 
		{
			_idTipoIntervento = idTipoIntervento;
			return this;
		}
	
		public AddSchedulazioneAmbToProgrammaBuilder ForIdAppaltatore(Guid idAppaltatore) 
		{
			_idAppaltatore = idAppaltatore;
			return this;
		}
	
		public AddSchedulazioneAmbToProgrammaBuilder ForIdCategoriaCommerciale(Guid idCategoriaCommerciale) 
		{
			_idCategoriaCommerciale = idCategoriaCommerciale;
			return this;
		}
	
		public AddSchedulazioneAmbToProgrammaBuilder ForIdDirezioneRegionale(Guid idDirezioneRegionale) 
		{
			_idDirezioneRegionale = idDirezioneRegionale;
			return this;
		}
	
		public AddSchedulazioneAmbToProgrammaBuilder ForNote(string note) 
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
	
		public AddSchedulazioneAmbToProgramma Build(Guid id, long version)
		{
			return Build(id, Guid.NewGuid(), version);
		}

		public AddSchedulazioneAmbToProgramma Build(Guid id, Guid commitId, long version)
        {
            return new AddSchedulazioneAmbToProgramma(id, commitId, version, _idPeriodoProgrammazione, _idSchedulazione, _idCommittente, _idLotto, _idImpianto, _idTipoIntervento, _idAppaltatore, _idCategoriaCommerciale, _idDirezioneRegionale, _note, _workPeriod, _period, _quantity, _description);
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
	  	}
}
