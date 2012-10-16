



using System;
using CommonDomain;
using System.Diagnostics.Contracts;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using Super.Appaltatore.Commands.Consuntivazione;
using Super.Appaltatore.Commands.Consuntivazione.Builders;

namespace Super.Appaltatore.Commands.Consuntivazione.Builders
{


	public class ConsuntivareAutomaticamenteNonResoBuilder : ICommandBuilder<ConsuntivareAutomaticamenteNonReso>
	{
	
		public ConsuntivareAutomaticamenteNonReso Build(Guid id, long version)
		{
			return Build(id, Guid.NewGuid(), version);
		}

		public ConsuntivareAutomaticamenteNonReso Build(Guid id, long version,DateTime wakeupTime)
		{
			return Build(id, Guid.NewGuid(), version,wakeupTime);
		}

		public ConsuntivareAutomaticamenteNonReso Build(Guid id, Guid commitId, long version)
        {
            return new ConsuntivareAutomaticamenteNonReso(id, commitId, version);
		 }

		 public ConsuntivareAutomaticamenteNonReso Build(Guid id, Guid commitId, long version,DateTime wakeupTime)
        {
            return new ConsuntivareAutomaticamenteNonReso(id, commitId, version, wakeupTime);
		 }
        
	
	}

	public class ConsuntivareNonResoBuilder : ICommandBuilder<ConsuntivareNonReso>
	{
	 
		private string  _note ; 
		private Guid  _idCausaleAppaltatore ; 
		private DateTime  _dataConsuntivazione ; 
		private string  _idInterventoAppaltatore ;
		public ConsuntivareNonResoBuilder WithNote(string note) 
		{
			_note = note;
			return this;
		}
	
		public ConsuntivareNonResoBuilder ForCausaleAppaltatore(Guid idCausaleAppaltatore) 
		{
			_idCausaleAppaltatore = idCausaleAppaltatore;
			return this;
		}
	
		public ConsuntivareNonResoBuilder ForDataConsuntivazione(DateTime dataConsuntivazione) 
		{
			_dataConsuntivazione = dataConsuntivazione;
			return this;
		}
	
		public ConsuntivareNonResoBuilder ForInterventoAppaltatore(string idInterventoAppaltatore) 
		{
			_idInterventoAppaltatore = idInterventoAppaltatore;
			return this;
		}
	
		public ConsuntivareNonReso Build(Guid id, long version)
		{
			return Build(id, Guid.NewGuid(), version);
		}

		public ConsuntivareNonReso Build(Guid id, long version,DateTime wakeupTime)
		{
			return Build(id, Guid.NewGuid(), version,wakeupTime);
		}

		public ConsuntivareNonReso Build(Guid id, Guid commitId, long version)
        {
            return new ConsuntivareNonReso(id, commitId, version, _note, _idCausaleAppaltatore, _dataConsuntivazione, _idInterventoAppaltatore);
		 }

		 public ConsuntivareNonReso Build(Guid id, Guid commitId, long version,DateTime wakeupTime)
        {
            return new ConsuntivareNonReso(id, commitId, version, wakeupTime, _note, _idCausaleAppaltatore, _dataConsuntivazione, _idInterventoAppaltatore);
		 }
        
	
	}

	public class ConsuntivareNonResoTrenitaliaBuilder : ICommandBuilder<ConsuntivareNonResoTrenitalia>
	{
	 
		private string  _note ; 
		private Guid  _idCausaleTrenitalia ; 
		private DateTime  _dataConsuntivazione ; 
		private string  _idInterventoAppaltatore ;
		public ConsuntivareNonResoTrenitaliaBuilder WithNote(string note) 
		{
			_note = note;
			return this;
		}
	
		public ConsuntivareNonResoTrenitaliaBuilder ForCausaleTrenitalia(Guid idCausaleTrenitalia) 
		{
			_idCausaleTrenitalia = idCausaleTrenitalia;
			return this;
		}
	
		public ConsuntivareNonResoTrenitaliaBuilder ForDataConsuntivazione(DateTime dataConsuntivazione) 
		{
			_dataConsuntivazione = dataConsuntivazione;
			return this;
		}
	
		public ConsuntivareNonResoTrenitaliaBuilder ForInterventoAppaltatore(string idInterventoAppaltatore) 
		{
			_idInterventoAppaltatore = idInterventoAppaltatore;
			return this;
		}
	
		public ConsuntivareNonResoTrenitalia Build(Guid id, long version)
		{
			return Build(id, Guid.NewGuid(), version);
		}

		public ConsuntivareNonResoTrenitalia Build(Guid id, long version,DateTime wakeupTime)
		{
			return Build(id, Guid.NewGuid(), version,wakeupTime);
		}

		public ConsuntivareNonResoTrenitalia Build(Guid id, Guid commitId, long version)
        {
            return new ConsuntivareNonResoTrenitalia(id, commitId, version, _note, _idCausaleTrenitalia, _dataConsuntivazione, _idInterventoAppaltatore);
		 }

		 public ConsuntivareNonResoTrenitalia Build(Guid id, Guid commitId, long version,DateTime wakeupTime)
        {
            return new ConsuntivareNonResoTrenitalia(id, commitId, version, wakeupTime, _note, _idCausaleTrenitalia, _dataConsuntivazione, _idInterventoAppaltatore);
		 }
        
	
	}

	public class ConsuntivareResoRotBuilder : ICommandBuilder<ConsuntivareResoRot>
	{
	 
		private string  _note ; 
		private WorkPeriod  _workPeriod ; 
		private DateTime  _dataConsuntivazione ; 
		private string  _idInterventoAppaltatore ; 
		private string  _convoglio ; 
		private string  _rigaTurnoTreno ; 
		private string  _turnoTreno ; 
		private Treno  _trenoArrivo ; 
		private Treno  _trenoPartenza ; 
		private OggettoRot[]  _oggetti ;
		public ConsuntivareResoRotBuilder WithNote(string note) 
		{
			_note = note;
			return this;
		}
	
		public ConsuntivareResoRotBuilder ForWorkPeriod(WorkPeriod workPeriod) 
		{
			_workPeriod = workPeriod;
			return this;
		}
	
		public ConsuntivareResoRotBuilder ForDataConsuntivazione(DateTime dataConsuntivazione) 
		{
			_dataConsuntivazione = dataConsuntivazione;
			return this;
		}
	
		public ConsuntivareResoRotBuilder ForInterventoAppaltatore(string idInterventoAppaltatore) 
		{
			_idInterventoAppaltatore = idInterventoAppaltatore;
			return this;
		}
	
		public ConsuntivareResoRotBuilder ForConvoglio(string convoglio) 
		{
			_convoglio = convoglio;
			return this;
		}
	
		public ConsuntivareResoRotBuilder WithRigaTurnoTreno(string rigaTurnoTreno) 
		{
			_rigaTurnoTreno = rigaTurnoTreno;
			return this;
		}
	
		public ConsuntivareResoRotBuilder WithTurnoTreno(string turnoTreno) 
		{
			_turnoTreno = turnoTreno;
			return this;
		}
	
		public ConsuntivareResoRotBuilder WithTrenoArrivo(Treno trenoArrivo) 
		{
			_trenoArrivo = trenoArrivo;
			return this;
		}
	
		public ConsuntivareResoRotBuilder WithTrenoPartenza(Treno trenoPartenza) 
		{
			_trenoPartenza = trenoPartenza;
			return this;
		}
	
		public ConsuntivareResoRotBuilder WithOggetti(OggettoRot[] oggetti) 
		{
			_oggetti = oggetti;
			return this;
		}
	
		public ConsuntivareResoRot Build(Guid id, long version)
		{
			return Build(id, Guid.NewGuid(), version);
		}

		public ConsuntivareResoRot Build(Guid id, long version,DateTime wakeupTime)
		{
			return Build(id, Guid.NewGuid(), version,wakeupTime);
		}

		public ConsuntivareResoRot Build(Guid id, Guid commitId, long version)
        {
            return new ConsuntivareResoRot(id, commitId, version, _note, _workPeriod, _dataConsuntivazione, _idInterventoAppaltatore, _convoglio, _rigaTurnoTreno, _turnoTreno, _trenoArrivo, _trenoPartenza, _oggetti);
		 }

		 public ConsuntivareResoRot Build(Guid id, Guid commitId, long version,DateTime wakeupTime)
        {
            return new ConsuntivareResoRot(id, commitId, version, wakeupTime, _note, _workPeriod, _dataConsuntivazione, _idInterventoAppaltatore, _convoglio, _rigaTurnoTreno, _turnoTreno, _trenoArrivo, _trenoPartenza, _oggetti);
		 }
        
	
	}

	public class ConsuntivareResoRotManBuilder : ICommandBuilder<ConsuntivareResoRotMan>
	{
	 
		private string  _note ; 
		private WorkPeriod  _workPeriod ; 
		private DateTime  _dataConsuntivazione ; 
		private string  _idInterventoAppaltatore ; 
		private OggettoRotMan[]  _oggetti ;
		public ConsuntivareResoRotManBuilder WithNote(string note) 
		{
			_note = note;
			return this;
		}
	
		public ConsuntivareResoRotManBuilder ForWorkPeriod(WorkPeriod workPeriod) 
		{
			_workPeriod = workPeriod;
			return this;
		}
	
		public ConsuntivareResoRotManBuilder ForDataConsuntivazione(DateTime dataConsuntivazione) 
		{
			_dataConsuntivazione = dataConsuntivazione;
			return this;
		}
	
		public ConsuntivareResoRotManBuilder ForInterventoAppaltatore(string idInterventoAppaltatore) 
		{
			_idInterventoAppaltatore = idInterventoAppaltatore;
			return this;
		}
	
		public ConsuntivareResoRotManBuilder WithOggetti(OggettoRotMan[] oggetti) 
		{
			_oggetti = oggetti;
			return this;
		}
	
		public ConsuntivareResoRotMan Build(Guid id, long version)
		{
			return Build(id, Guid.NewGuid(), version);
		}

		public ConsuntivareResoRotMan Build(Guid id, long version,DateTime wakeupTime)
		{
			return Build(id, Guid.NewGuid(), version,wakeupTime);
		}

		public ConsuntivareResoRotMan Build(Guid id, Guid commitId, long version)
        {
            return new ConsuntivareResoRotMan(id, commitId, version, _note, _workPeriod, _dataConsuntivazione, _idInterventoAppaltatore, _oggetti);
		 }

		 public ConsuntivareResoRotMan Build(Guid id, Guid commitId, long version,DateTime wakeupTime)
        {
            return new ConsuntivareResoRotMan(id, commitId, version, wakeupTime, _note, _workPeriod, _dataConsuntivazione, _idInterventoAppaltatore, _oggetti);
		 }
        
	
	}

	public class ConsuntivareResoAmbBuilder : ICommandBuilder<ConsuntivareResoAmb>
	{
	 
		private string  _note ; 
		private WorkPeriod  _workPeriod ; 
		private DateTime  _dataConsuntivazione ; 
		private string  _idInterventoAppaltatore ; 
		private string  _description ; 
		private int  _quantity ;
		public ConsuntivareResoAmbBuilder WithNote(string note) 
		{
			_note = note;
			return this;
		}
	
		public ConsuntivareResoAmbBuilder ForWorkPeriod(WorkPeriod workPeriod) 
		{
			_workPeriod = workPeriod;
			return this;
		}
	
		public ConsuntivareResoAmbBuilder ForDataConsuntivazione(DateTime dataConsuntivazione) 
		{
			_dataConsuntivazione = dataConsuntivazione;
			return this;
		}
	
		public ConsuntivareResoAmbBuilder ForInterventoAppaltatore(string idInterventoAppaltatore) 
		{
			_idInterventoAppaltatore = idInterventoAppaltatore;
			return this;
		}
	
		public ConsuntivareResoAmbBuilder ForDescription(string description) 
		{
			_description = description;
			return this;
		}
	
		public ConsuntivareResoAmbBuilder ForQuantity(int quantity) 
		{
			_quantity = quantity;
			return this;
		}
	
		public ConsuntivareResoAmb Build(Guid id, long version)
		{
			return Build(id, Guid.NewGuid(), version);
		}

		public ConsuntivareResoAmb Build(Guid id, long version,DateTime wakeupTime)
		{
			return Build(id, Guid.NewGuid(), version,wakeupTime);
		}

		public ConsuntivareResoAmb Build(Guid id, Guid commitId, long version)
        {
            return new ConsuntivareResoAmb(id, commitId, version, _note, _workPeriod, _dataConsuntivazione, _idInterventoAppaltatore, _description, _quantity);
		 }

		 public ConsuntivareResoAmb Build(Guid id, Guid commitId, long version,DateTime wakeupTime)
        {
            return new ConsuntivareResoAmb(id, commitId, version, wakeupTime, _note, _workPeriod, _dataConsuntivazione, _idInterventoAppaltatore, _description, _quantity);
		 }
        
	
	}

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
	
		public ProgramInterventoRot Build(Guid id, long version)
		{
			return Build(id, Guid.NewGuid(), version);
		}

		public ProgramInterventoRot Build(Guid id, long version,DateTime wakeupTime)
		{
			return Build(id, Guid.NewGuid(), version,wakeupTime);
		}

		public ProgramInterventoRot Build(Guid id, Guid commitId, long version)
        {
            return new ProgramInterventoRot(id, commitId, version, _idProgramma, _idPeriodoProgrammazione, _idCommittente, _idLotto, _idImpianto, _idTipoIntervento, _idAppaltatore, _idCategoriaCommerciale, _idDirezioneRegionale, _note, _workPeriod, _convoglio, _rigaTurnoTreno, _turnoTreno, _trenoArrivo, _trenoPartenza, _oggetti);
		 }

		 public ProgramInterventoRot Build(Guid id, Guid commitId, long version,DateTime wakeupTime)
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
	
		public ProgramInterventoRotMan Build(Guid id, long version)
		{
			return Build(id, Guid.NewGuid(), version);
		}

		public ProgramInterventoRotMan Build(Guid id, long version,DateTime wakeupTime)
		{
			return Build(id, Guid.NewGuid(), version,wakeupTime);
		}

		public ProgramInterventoRotMan Build(Guid id, Guid commitId, long version)
        {
            return new ProgramInterventoRotMan(id, commitId, version, _idProgramma, _idPeriodoProgrammazione, _idCommittente, _idLotto, _idImpianto, _idTipoIntervento, _idAppaltatore, _idCategoriaCommerciale, _idDirezioneRegionale, _note, _workPeriod, _oggetti);
		 }

		 public ProgramInterventoRotMan Build(Guid id, Guid commitId, long version,DateTime wakeupTime)
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
	
		public ProgramInterventoAmb Build(Guid id, long version)
		{
			return Build(id, Guid.NewGuid(), version);
		}

		public ProgramInterventoAmb Build(Guid id, long version,DateTime wakeupTime)
		{
			return Build(id, Guid.NewGuid(), version,wakeupTime);
		}

		public ProgramInterventoAmb Build(Guid id, Guid commitId, long version)
        {
            return new ProgramInterventoAmb(id, commitId, version, _idProgramma, _idPeriodoProgrammazione, _idCommittente, _idLotto, _idImpianto, _idTipoIntervento, _idAppaltatore, _idCategoriaCommerciale, _idDirezioneRegionale, _note, _workPeriod, _quantity, _description);
		 }

		 public ProgramInterventoAmb Build(Guid id, Guid commitId, long version,DateTime wakeupTime)
        {
            return new ProgramInterventoAmb(id, commitId, version, wakeupTime, _idProgramma, _idPeriodoProgrammazione, _idCommittente, _idLotto, _idImpianto, _idTipoIntervento, _idAppaltatore, _idCategoriaCommerciale, _idDirezioneRegionale, _note, _workPeriod, _quantity, _description);
		 }
        
	
	}
}

namespace Super.Appaltatore.Commands
{
	public static partial class BuildCmd 
	{
		  public static ConsuntivareAutomaticamenteNonResoBuilder ConsuntivareAutomaticamenteNonReso {get { return new ConsuntivareAutomaticamenteNonResoBuilder(); } }
	  		  public static ConsuntivareNonResoBuilder ConsuntivareNonReso {get { return new ConsuntivareNonResoBuilder(); } }
	  		  public static ConsuntivareNonResoTrenitaliaBuilder ConsuntivareNonResoTrenitalia {get { return new ConsuntivareNonResoTrenitaliaBuilder(); } }
	  		  public static ConsuntivareResoRotBuilder ConsuntivareResoRot {get { return new ConsuntivareResoRotBuilder(); } }
	  		  public static ConsuntivareResoRotManBuilder ConsuntivareResoRotMan {get { return new ConsuntivareResoRotManBuilder(); } }
	  		  public static ConsuntivareResoAmbBuilder ConsuntivareResoAmb {get { return new ConsuntivareResoAmbBuilder(); } }
	  		  public static ProgramInterventoRotBuilder ProgramInterventoRot {get { return new ProgramInterventoRotBuilder(); } }
	  		  public static ProgramInterventoRotManBuilder ProgramInterventoRotMan {get { return new ProgramInterventoRotManBuilder(); } }
	  		  public static ProgramInterventoAmbBuilder ProgramInterventoAmb {get { return new ProgramInterventoAmbBuilder(); } }
	  	}
}
