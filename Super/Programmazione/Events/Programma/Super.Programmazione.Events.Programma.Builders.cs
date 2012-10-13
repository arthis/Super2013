



using System;
using CommonDomain;
using System.Diagnostics.Contracts;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using Super.Programmazione.Events.Programma;
using Super.Programmazione.Events.Programma.Builders;

namespace Super.Programmazione.Events.Programma.Builders
{


	public class ProgrammaCreatedBuilder : IEventBuilder<ProgrammaCreated>
	{
	 
		private Guid  _idScenario ;
		public ProgrammaCreatedBuilder ByScenario(Guid idScenario) 
		{
			_idScenario = idScenario;
			return this;
		}
	
		public ProgrammaCreated Build(Guid id, long version)
		{
			return Build(id, Guid.NewGuid(), version);
		}

		public ProgrammaCreated Build(Guid id, Guid commitId, long version)
        {
            return new ProgrammaCreated(id, commitId, version, _idScenario);
		 }
        
	
	}

	public class SchedulazioneRotAddedToProgrammaBuilder : IEventBuilder<SchedulazioneRotAddedToProgramma>
	{
	 
		private Guid  _idSchedulazione ; 
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
		public SchedulazioneRotAddedToProgrammaBuilder ForSchedulazione(Guid idSchedulazione) 
		{
			_idSchedulazione = idSchedulazione;
			return this;
		}
	
		public SchedulazioneRotAddedToProgrammaBuilder ForPeriodoProgrammazione(Guid idPeriodoProgrammazione) 
		{
			_idPeriodoProgrammazione = idPeriodoProgrammazione;
			return this;
		}
	
		public SchedulazioneRotAddedToProgrammaBuilder ForCommittente(Guid idCommittente) 
		{
			_idCommittente = idCommittente;
			return this;
		}
	
		public SchedulazioneRotAddedToProgrammaBuilder ForLotto(Guid idLotto) 
		{
			_idLotto = idLotto;
			return this;
		}
	
		public SchedulazioneRotAddedToProgrammaBuilder ForImpianto(Guid idImpianto) 
		{
			_idImpianto = idImpianto;
			return this;
		}
	
		public SchedulazioneRotAddedToProgrammaBuilder OfTipoIntervento(Guid idTipoIntervento) 
		{
			_idTipoIntervento = idTipoIntervento;
			return this;
		}
	
		public SchedulazioneRotAddedToProgrammaBuilder ForAppaltatore(Guid idAppaltatore) 
		{
			_idAppaltatore = idAppaltatore;
			return this;
		}
	
		public SchedulazioneRotAddedToProgrammaBuilder ForCategoriaCommerciale(Guid idCategoriaCommerciale) 
		{
			_idCategoriaCommerciale = idCategoriaCommerciale;
			return this;
		}
	
		public SchedulazioneRotAddedToProgrammaBuilder ForDirezioneRegionale(Guid idDirezioneRegionale) 
		{
			_idDirezioneRegionale = idDirezioneRegionale;
			return this;
		}
	
		public SchedulazioneRotAddedToProgrammaBuilder WithNote(string note) 
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
	
		public SchedulazioneRotAddedToProgrammaBuilder WithRigaTurnoTreno(string rigaTurnoTreno) 
		{
			_rigaTurnoTreno = rigaTurnoTreno;
			return this;
		}
	
		public SchedulazioneRotAddedToProgrammaBuilder WithTurnoTreno(string turnoTreno) 
		{
			_turnoTreno = turnoTreno;
			return this;
		}
	
		public SchedulazioneRotAddedToProgrammaBuilder WithTrenoArrivo(Treno trenoArrivo) 
		{
			_trenoArrivo = trenoArrivo;
			return this;
		}
	
		public SchedulazioneRotAddedToProgrammaBuilder WithTrenoPartenza(Treno trenoPartenza) 
		{
			_trenoPartenza = trenoPartenza;
			return this;
		}
	
		public SchedulazioneRotAddedToProgrammaBuilder WithOggetti(OggettoRot[] oggetti) 
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
            return new SchedulazioneRotAddedToProgramma(id, commitId, version, _idSchedulazione, _idPeriodoProgrammazione, _idCommittente, _idLotto, _idImpianto, _idTipoIntervento, _idAppaltatore, _idCategoriaCommerciale, _idDirezioneRegionale, _note, _workPeriod, _period, _convoglio, _rigaTurnoTreno, _turnoTreno, _trenoArrivo, _trenoPartenza, _oggetti);
		 }
        
	
	}

	public class SchedulazioneRotManAddedToProgrammaBuilder : IEventBuilder<SchedulazioneRotManAddedToProgramma>
	{
	 
		private Guid  _idSchedulazione ; 
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
		public SchedulazioneRotManAddedToProgrammaBuilder ForSchedulazione(Guid idSchedulazione) 
		{
			_idSchedulazione = idSchedulazione;
			return this;
		}
	
		public SchedulazioneRotManAddedToProgrammaBuilder ForPeriodoProgrammazione(Guid idPeriodoProgrammazione) 
		{
			_idPeriodoProgrammazione = idPeriodoProgrammazione;
			return this;
		}
	
		public SchedulazioneRotManAddedToProgrammaBuilder ForCommittente(Guid idCommittente) 
		{
			_idCommittente = idCommittente;
			return this;
		}
	
		public SchedulazioneRotManAddedToProgrammaBuilder ForLotto(Guid idLotto) 
		{
			_idLotto = idLotto;
			return this;
		}
	
		public SchedulazioneRotManAddedToProgrammaBuilder ForImpianto(Guid idImpianto) 
		{
			_idImpianto = idImpianto;
			return this;
		}
	
		public SchedulazioneRotManAddedToProgrammaBuilder OfTipoIntervento(Guid idTipoIntervento) 
		{
			_idTipoIntervento = idTipoIntervento;
			return this;
		}
	
		public SchedulazioneRotManAddedToProgrammaBuilder ForAppaltatore(Guid idAppaltatore) 
		{
			_idAppaltatore = idAppaltatore;
			return this;
		}
	
		public SchedulazioneRotManAddedToProgrammaBuilder ForCategoriaCommerciale(Guid idCategoriaCommerciale) 
		{
			_idCategoriaCommerciale = idCategoriaCommerciale;
			return this;
		}
	
		public SchedulazioneRotManAddedToProgrammaBuilder ForDirezioneRegionale(Guid idDirezioneRegionale) 
		{
			_idDirezioneRegionale = idDirezioneRegionale;
			return this;
		}
	
		public SchedulazioneRotManAddedToProgrammaBuilder WithNote(string note) 
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
	
		public SchedulazioneRotManAddedToProgrammaBuilder WithOggetti(OggettoRotMan[] oggetti) 
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
            return new SchedulazioneRotManAddedToProgramma(id, commitId, version, _idSchedulazione, _idPeriodoProgrammazione, _idCommittente, _idLotto, _idImpianto, _idTipoIntervento, _idAppaltatore, _idCategoriaCommerciale, _idDirezioneRegionale, _note, _workPeriod, _period, _oggetti);
		 }
        
	
	}

	public class SchedulazioneAmbAddedToProgrammaBuilder : IEventBuilder<SchedulazioneAmbAddedToProgramma>
	{
	 
		private Guid  _idSchedulazione ; 
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
		public SchedulazioneAmbAddedToProgrammaBuilder ForSchedulazione(Guid idSchedulazione) 
		{
			_idSchedulazione = idSchedulazione;
			return this;
		}
	
		public SchedulazioneAmbAddedToProgrammaBuilder ForPeriodoProgrammazione(Guid idPeriodoProgrammazione) 
		{
			_idPeriodoProgrammazione = idPeriodoProgrammazione;
			return this;
		}
	
		public SchedulazioneAmbAddedToProgrammaBuilder ForCommittente(Guid idCommittente) 
		{
			_idCommittente = idCommittente;
			return this;
		}
	
		public SchedulazioneAmbAddedToProgrammaBuilder ForLotto(Guid idLotto) 
		{
			_idLotto = idLotto;
			return this;
		}
	
		public SchedulazioneAmbAddedToProgrammaBuilder ForImpianto(Guid idImpianto) 
		{
			_idImpianto = idImpianto;
			return this;
		}
	
		public SchedulazioneAmbAddedToProgrammaBuilder OfTipoIntervento(Guid idTipoIntervento) 
		{
			_idTipoIntervento = idTipoIntervento;
			return this;
		}
	
		public SchedulazioneAmbAddedToProgrammaBuilder ForAppaltatore(Guid idAppaltatore) 
		{
			_idAppaltatore = idAppaltatore;
			return this;
		}
	
		public SchedulazioneAmbAddedToProgrammaBuilder ForCategoriaCommerciale(Guid idCategoriaCommerciale) 
		{
			_idCategoriaCommerciale = idCategoriaCommerciale;
			return this;
		}
	
		public SchedulazioneAmbAddedToProgrammaBuilder ForDirezioneRegionale(Guid idDirezioneRegionale) 
		{
			_idDirezioneRegionale = idDirezioneRegionale;
			return this;
		}
	
		public SchedulazioneAmbAddedToProgrammaBuilder WithNote(string note) 
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
            return new SchedulazioneAmbAddedToProgramma(id, commitId, version, _idSchedulazione, _idPeriodoProgrammazione, _idCommittente, _idLotto, _idImpianto, _idTipoIntervento, _idAppaltatore, _idCategoriaCommerciale, _idDirezioneRegionale, _note, _workPeriod, _period, _quantity, _description);
		 }
        
	
	}

	public class InterventoRotAddedToProgrammaBuilder : IEventBuilder<InterventoRotAddedToProgramma>
	{
	 
		private Guid  _idIntervento ; 
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
		public InterventoRotAddedToProgrammaBuilder ForIntervento(Guid idIntervento) 
		{
			_idIntervento = idIntervento;
			return this;
		}
	
		public InterventoRotAddedToProgrammaBuilder ForPeriodoProgrammazione(Guid idPeriodoProgrammazione) 
		{
			_idPeriodoProgrammazione = idPeriodoProgrammazione;
			return this;
		}
	
		public InterventoRotAddedToProgrammaBuilder ForCommittente(Guid idCommittente) 
		{
			_idCommittente = idCommittente;
			return this;
		}
	
		public InterventoRotAddedToProgrammaBuilder ForLotto(Guid idLotto) 
		{
			_idLotto = idLotto;
			return this;
		}
	
		public InterventoRotAddedToProgrammaBuilder ForImpianto(Guid idImpianto) 
		{
			_idImpianto = idImpianto;
			return this;
		}
	
		public InterventoRotAddedToProgrammaBuilder OfTipoIntervento(Guid idTipoIntervento) 
		{
			_idTipoIntervento = idTipoIntervento;
			return this;
		}
	
		public InterventoRotAddedToProgrammaBuilder ForAppaltatore(Guid idAppaltatore) 
		{
			_idAppaltatore = idAppaltatore;
			return this;
		}
	
		public InterventoRotAddedToProgrammaBuilder ForCategoriaCommerciale(Guid idCategoriaCommerciale) 
		{
			_idCategoriaCommerciale = idCategoriaCommerciale;
			return this;
		}
	
		public InterventoRotAddedToProgrammaBuilder ForDirezioneRegionale(Guid idDirezioneRegionale) 
		{
			_idDirezioneRegionale = idDirezioneRegionale;
			return this;
		}
	
		public InterventoRotAddedToProgrammaBuilder WithNote(string note) 
		{
			_note = note;
			return this;
		}
	
		public InterventoRotAddedToProgrammaBuilder ForWorkPeriod(WorkPeriod workPeriod) 
		{
			_workPeriod = workPeriod;
			return this;
		}
	
		public InterventoRotAddedToProgrammaBuilder ForConvoglio(string convoglio) 
		{
			_convoglio = convoglio;
			return this;
		}
	
		public InterventoRotAddedToProgrammaBuilder WithRigaTurnoTreno(string rigaTurnoTreno) 
		{
			_rigaTurnoTreno = rigaTurnoTreno;
			return this;
		}
	
		public InterventoRotAddedToProgrammaBuilder WithTurnoTreno(string turnoTreno) 
		{
			_turnoTreno = turnoTreno;
			return this;
		}
	
		public InterventoRotAddedToProgrammaBuilder WithTrenoArrivo(Treno trenoArrivo) 
		{
			_trenoArrivo = trenoArrivo;
			return this;
		}
	
		public InterventoRotAddedToProgrammaBuilder WithTrenoPartenza(Treno trenoPartenza) 
		{
			_trenoPartenza = trenoPartenza;
			return this;
		}
	
		public InterventoRotAddedToProgrammaBuilder WithOggetti(OggettoRot[] oggetti) 
		{
			_oggetti = oggetti;
			return this;
		}
	
		public InterventoRotAddedToProgramma Build(Guid id, long version)
		{
			return Build(id, Guid.NewGuid(), version);
		}

		public InterventoRotAddedToProgramma Build(Guid id, Guid commitId, long version)
        {
            return new InterventoRotAddedToProgramma(id, commitId, version, _idIntervento, _idPeriodoProgrammazione, _idCommittente, _idLotto, _idImpianto, _idTipoIntervento, _idAppaltatore, _idCategoriaCommerciale, _idDirezioneRegionale, _note, _workPeriod, _convoglio, _rigaTurnoTreno, _turnoTreno, _trenoArrivo, _trenoPartenza, _oggetti);
		 }
        
	
	}

	public class InterventoRotManAddedToProgrammaBuilder : IEventBuilder<InterventoRotManAddedToProgramma>
	{
	 
		private Guid  _idIntervento ; 
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
		public InterventoRotManAddedToProgrammaBuilder ForIntervento(Guid idIntervento) 
		{
			_idIntervento = idIntervento;
			return this;
		}
	
		public InterventoRotManAddedToProgrammaBuilder ForPeriodoProgrammazione(Guid idPeriodoProgrammazione) 
		{
			_idPeriodoProgrammazione = idPeriodoProgrammazione;
			return this;
		}
	
		public InterventoRotManAddedToProgrammaBuilder ForCommittente(Guid idCommittente) 
		{
			_idCommittente = idCommittente;
			return this;
		}
	
		public InterventoRotManAddedToProgrammaBuilder ForLotto(Guid idLotto) 
		{
			_idLotto = idLotto;
			return this;
		}
	
		public InterventoRotManAddedToProgrammaBuilder ForImpianto(Guid idImpianto) 
		{
			_idImpianto = idImpianto;
			return this;
		}
	
		public InterventoRotManAddedToProgrammaBuilder OfTipoIntervento(Guid idTipoIntervento) 
		{
			_idTipoIntervento = idTipoIntervento;
			return this;
		}
	
		public InterventoRotManAddedToProgrammaBuilder ForAppaltatore(Guid idAppaltatore) 
		{
			_idAppaltatore = idAppaltatore;
			return this;
		}
	
		public InterventoRotManAddedToProgrammaBuilder ForCategoriaCommerciale(Guid idCategoriaCommerciale) 
		{
			_idCategoriaCommerciale = idCategoriaCommerciale;
			return this;
		}
	
		public InterventoRotManAddedToProgrammaBuilder ForDirezioneRegionale(Guid idDirezioneRegionale) 
		{
			_idDirezioneRegionale = idDirezioneRegionale;
			return this;
		}
	
		public InterventoRotManAddedToProgrammaBuilder WithNote(string note) 
		{
			_note = note;
			return this;
		}
	
		public InterventoRotManAddedToProgrammaBuilder ForWorkPeriod(WorkPeriod workPeriod) 
		{
			_workPeriod = workPeriod;
			return this;
		}
	
		public InterventoRotManAddedToProgrammaBuilder WithOggetti(OggettoRotMan[] oggetti) 
		{
			_oggetti = oggetti;
			return this;
		}
	
		public InterventoRotManAddedToProgramma Build(Guid id, long version)
		{
			return Build(id, Guid.NewGuid(), version);
		}

		public InterventoRotManAddedToProgramma Build(Guid id, Guid commitId, long version)
        {
            return new InterventoRotManAddedToProgramma(id, commitId, version, _idIntervento, _idPeriodoProgrammazione, _idCommittente, _idLotto, _idImpianto, _idTipoIntervento, _idAppaltatore, _idCategoriaCommerciale, _idDirezioneRegionale, _note, _workPeriod, _oggetti);
		 }
        
	
	}

	public class InterventoAmbAddedToProgrammaBuilder : IEventBuilder<InterventoAmbAddedToProgramma>
	{
	 
		private Guid  _idIntervento ; 
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
		public InterventoAmbAddedToProgrammaBuilder ForIntervento(Guid idIntervento) 
		{
			_idIntervento = idIntervento;
			return this;
		}
	
		public InterventoAmbAddedToProgrammaBuilder ForPeriodoProgrammazione(Guid idPeriodoProgrammazione) 
		{
			_idPeriodoProgrammazione = idPeriodoProgrammazione;
			return this;
		}
	
		public InterventoAmbAddedToProgrammaBuilder ForCommittente(Guid idCommittente) 
		{
			_idCommittente = idCommittente;
			return this;
		}
	
		public InterventoAmbAddedToProgrammaBuilder ForLotto(Guid idLotto) 
		{
			_idLotto = idLotto;
			return this;
		}
	
		public InterventoAmbAddedToProgrammaBuilder ForImpianto(Guid idImpianto) 
		{
			_idImpianto = idImpianto;
			return this;
		}
	
		public InterventoAmbAddedToProgrammaBuilder OfTipoIntervento(Guid idTipoIntervento) 
		{
			_idTipoIntervento = idTipoIntervento;
			return this;
		}
	
		public InterventoAmbAddedToProgrammaBuilder ForAppaltatore(Guid idAppaltatore) 
		{
			_idAppaltatore = idAppaltatore;
			return this;
		}
	
		public InterventoAmbAddedToProgrammaBuilder ForCategoriaCommerciale(Guid idCategoriaCommerciale) 
		{
			_idCategoriaCommerciale = idCategoriaCommerciale;
			return this;
		}
	
		public InterventoAmbAddedToProgrammaBuilder ForDirezioneRegionale(Guid idDirezioneRegionale) 
		{
			_idDirezioneRegionale = idDirezioneRegionale;
			return this;
		}
	
		public InterventoAmbAddedToProgrammaBuilder WithNote(string note) 
		{
			_note = note;
			return this;
		}
	
		public InterventoAmbAddedToProgrammaBuilder ForWorkPeriod(WorkPeriod workPeriod) 
		{
			_workPeriod = workPeriod;
			return this;
		}
	
		public InterventoAmbAddedToProgrammaBuilder ForQuantity(int quantity) 
		{
			_quantity = quantity;
			return this;
		}
	
		public InterventoAmbAddedToProgrammaBuilder ForDescription(string description) 
		{
			_description = description;
			return this;
		}
	
		public InterventoAmbAddedToProgramma Build(Guid id, long version)
		{
			return Build(id, Guid.NewGuid(), version);
		}

		public InterventoAmbAddedToProgramma Build(Guid id, Guid commitId, long version)
        {
            return new InterventoAmbAddedToProgramma(id, commitId, version, _idIntervento, _idPeriodoProgrammazione, _idCommittente, _idLotto, _idImpianto, _idTipoIntervento, _idAppaltatore, _idCategoriaCommerciale, _idDirezioneRegionale, _note, _workPeriod, _quantity, _description);
		 }
        
	
	}
}

namespace Super.Programmazione.Events
{
	public static partial class BuildEvt 
	{
		  public static ProgrammaCreatedBuilder ProgrammaCreated {get { return new ProgrammaCreatedBuilder(); } }
	  		  public static SchedulazioneRotAddedToProgrammaBuilder SchedulazioneRotAddedToProgramma {get { return new SchedulazioneRotAddedToProgrammaBuilder(); } }
	  		  public static SchedulazioneRotManAddedToProgrammaBuilder SchedulazioneRotManAddedToProgramma {get { return new SchedulazioneRotManAddedToProgrammaBuilder(); } }
	  		  public static SchedulazioneAmbAddedToProgrammaBuilder SchedulazioneAmbAddedToProgramma {get { return new SchedulazioneAmbAddedToProgrammaBuilder(); } }
	  		  public static InterventoRotAddedToProgrammaBuilder InterventoRotAddedToProgramma {get { return new InterventoRotAddedToProgrammaBuilder(); } }
	  		  public static InterventoRotManAddedToProgrammaBuilder InterventoRotManAddedToProgramma {get { return new InterventoRotManAddedToProgrammaBuilder(); } }
	  		  public static InterventoAmbAddedToProgrammaBuilder InterventoAmbAddedToProgramma {get { return new InterventoAmbAddedToProgrammaBuilder(); } }
	  	}
}
