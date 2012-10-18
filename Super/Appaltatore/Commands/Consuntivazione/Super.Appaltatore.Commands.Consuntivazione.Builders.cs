



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
	  	}
}
