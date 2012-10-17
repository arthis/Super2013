



using System;
using CommonDomain;
using System.Diagnostics.Contracts;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using Super.Controllo.Commands.Consuntivazione;
using Super.Controllo.Commands.Consuntivazione.Builders;

namespace Super.Controllo.Commands.Consuntivazione.Builders
{


	public class AllowControlInterventoBuilder : ICommandBuilder<AllowControlIntervento>
	{
	
		public AllowControlIntervento Build(Guid id, long version)
		{
			return Build(id, Guid.NewGuid(), version);
		}

		public AllowControlIntervento Build(Guid id, long version,DateTime wakeupTime)
		{
			return Build(id, Guid.NewGuid(), version,wakeupTime);
		}

		public AllowControlIntervento Build(Guid id, Guid commitId, long version)
        {
            return new AllowControlIntervento(id, commitId, version);
		 }

		 public AllowControlIntervento Build(Guid id, Guid commitId, long version,DateTime wakeupTime)
        {
            return new AllowControlIntervento(id, commitId, version, wakeupTime);
		 }
        
	
	}

	public class CloseInterventoBuilder : ICommandBuilder<CloseIntervento>
	{
	 
		private Guid  _idUser ; 
		private DateTime  _closingDate ;
		public CloseInterventoBuilder By(Guid idUser) 
		{
			_idUser = idUser;
			return this;
		}
	
		public CloseInterventoBuilder When(DateTime closingDate) 
		{
			_closingDate = closingDate;
			return this;
		}
	
		public CloseIntervento Build(Guid id, long version)
		{
			return Build(id, Guid.NewGuid(), version);
		}

		public CloseIntervento Build(Guid id, long version,DateTime wakeupTime)
		{
			return Build(id, Guid.NewGuid(), version,wakeupTime);
		}

		public CloseIntervento Build(Guid id, Guid commitId, long version)
        {
            return new CloseIntervento(id, commitId, version, _idUser, _closingDate);
		 }

		 public CloseIntervento Build(Guid id, Guid commitId, long version,DateTime wakeupTime)
        {
            return new CloseIntervento(id, commitId, version, wakeupTime, _idUser, _closingDate);
		 }
        
	
	}

	public class ReopenInterventoBuilder : ICommandBuilder<ReopenIntervento>
	{
	 
		private Guid  _idUser ; 
		private DateTime  _reopeningDate ;
		public ReopenInterventoBuilder By(Guid idUser) 
		{
			_idUser = idUser;
			return this;
		}
	
		public ReopenInterventoBuilder When(DateTime reopeningDate) 
		{
			_reopeningDate = reopeningDate;
			return this;
		}
	
		public ReopenIntervento Build(Guid id, long version)
		{
			return Build(id, Guid.NewGuid(), version);
		}

		public ReopenIntervento Build(Guid id, long version,DateTime wakeupTime)
		{
			return Build(id, Guid.NewGuid(), version,wakeupTime);
		}

		public ReopenIntervento Build(Guid id, Guid commitId, long version)
        {
            return new ReopenIntervento(id, commitId, version, _idUser, _reopeningDate);
		 }

		 public ReopenIntervento Build(Guid id, Guid commitId, long version,DateTime wakeupTime)
        {
            return new ReopenIntervento(id, commitId, version, wakeupTime, _idUser, _reopeningDate);
		 }
        
	
	}

	public class ControlNonResoInterventoBuilder : ICommandBuilder<ControlNonResoIntervento>
	{
	 
		private string  _note ; 
		private Guid  _idCausale ; 
		private DateTime  _controlDate ; 
		private Guid  _idUser ;
		public ControlNonResoInterventoBuilder WithNote(string note) 
		{
			_note = note;
			return this;
		}
	
		public ControlNonResoInterventoBuilder Because(Guid idCausale) 
		{
			_idCausale = idCausale;
			return this;
		}
	
		public ControlNonResoInterventoBuilder When(DateTime controlDate) 
		{
			_controlDate = controlDate;
			return this;
		}
	
		public ControlNonResoInterventoBuilder By(Guid idUser) 
		{
			_idUser = idUser;
			return this;
		}
	
		public ControlNonResoIntervento Build(Guid id, long version)
		{
			return Build(id, Guid.NewGuid(), version);
		}

		public ControlNonResoIntervento Build(Guid id, long version,DateTime wakeupTime)
		{
			return Build(id, Guid.NewGuid(), version,wakeupTime);
		}

		public ControlNonResoIntervento Build(Guid id, Guid commitId, long version)
        {
            return new ControlNonResoIntervento(id, commitId, version, _note, _idCausale, _controlDate, _idUser);
		 }

		 public ControlNonResoIntervento Build(Guid id, Guid commitId, long version,DateTime wakeupTime)
        {
            return new ControlNonResoIntervento(id, commitId, version, wakeupTime, _note, _idCausale, _controlDate, _idUser);
		 }
        
	
	}

	public class ControlResoInterventoRotBuilder : ICommandBuilder<ControlResoInterventoRot>
	{
	 
		private string  _note ; 
		private WorkPeriod  _workPeriod ; 
		private DateTime  _controlDate ; 
		private Guid  _idUser ; 
		private string  _idInterventoAppaltatore ; 
		private string  _convoglio ; 
		private string  _rigaTurnoTreno ; 
		private string  _turnoTreno ; 
		private Treno  _trenoArrivo ; 
		private Treno  _trenoPartenza ; 
		private OggettoRot[]  _oggetti ;
		public ControlResoInterventoRotBuilder WithNote(string note) 
		{
			_note = note;
			return this;
		}
	
		public ControlResoInterventoRotBuilder ForWorkPeriod(WorkPeriod workPeriod) 
		{
			_workPeriod = workPeriod;
			return this;
		}
	
		public ControlResoInterventoRotBuilder When(DateTime controlDate) 
		{
			_controlDate = controlDate;
			return this;
		}
	
		public ControlResoInterventoRotBuilder By(Guid idUser) 
		{
			_idUser = idUser;
			return this;
		}
	
		public ControlResoInterventoRotBuilder ForInterventoAppaltatore(string idInterventoAppaltatore) 
		{
			_idInterventoAppaltatore = idInterventoAppaltatore;
			return this;
		}
	
		public ControlResoInterventoRotBuilder ForConvoglio(string convoglio) 
		{
			_convoglio = convoglio;
			return this;
		}
	
		public ControlResoInterventoRotBuilder WithRigaTurnoTreno(string rigaTurnoTreno) 
		{
			_rigaTurnoTreno = rigaTurnoTreno;
			return this;
		}
	
		public ControlResoInterventoRotBuilder WithTurnoTreno(string turnoTreno) 
		{
			_turnoTreno = turnoTreno;
			return this;
		}
	
		public ControlResoInterventoRotBuilder WithTrenoArrivo(Treno trenoArrivo) 
		{
			_trenoArrivo = trenoArrivo;
			return this;
		}
	
		public ControlResoInterventoRotBuilder WithTrenoPartenza(Treno trenoPartenza) 
		{
			_trenoPartenza = trenoPartenza;
			return this;
		}
	
		public ControlResoInterventoRotBuilder WithOggetti(OggettoRot[] oggetti) 
		{
			_oggetti = oggetti;
			return this;
		}
	
		public ControlResoInterventoRot Build(Guid id, long version)
		{
			return Build(id, Guid.NewGuid(), version);
		}

		public ControlResoInterventoRot Build(Guid id, long version,DateTime wakeupTime)
		{
			return Build(id, Guid.NewGuid(), version,wakeupTime);
		}

		public ControlResoInterventoRot Build(Guid id, Guid commitId, long version)
        {
            return new ControlResoInterventoRot(id, commitId, version, _note, _workPeriod, _controlDate, _idUser, _idInterventoAppaltatore, _convoglio, _rigaTurnoTreno, _turnoTreno, _trenoArrivo, _trenoPartenza, _oggetti);
		 }

		 public ControlResoInterventoRot Build(Guid id, Guid commitId, long version,DateTime wakeupTime)
        {
            return new ControlResoInterventoRot(id, commitId, version, wakeupTime, _note, _workPeriod, _controlDate, _idUser, _idInterventoAppaltatore, _convoglio, _rigaTurnoTreno, _turnoTreno, _trenoArrivo, _trenoPartenza, _oggetti);
		 }
        
	
	}

	public class ControlResoInterventoRotManBuilder : ICommandBuilder<ControlResoInterventoRotMan>
	{
	 
		private string  _note ; 
		private WorkPeriod  _workPeriod ; 
		private DateTime  _controlDate ; 
		private Guid  _idUser ; 
		private string  _idInterventoAppaltatore ; 
		private OggettoRotMan[]  _oggetti ;
		public ControlResoInterventoRotManBuilder WithNote(string note) 
		{
			_note = note;
			return this;
		}
	
		public ControlResoInterventoRotManBuilder ForWorkPeriod(WorkPeriod workPeriod) 
		{
			_workPeriod = workPeriod;
			return this;
		}
	
		public ControlResoInterventoRotManBuilder When(DateTime controlDate) 
		{
			_controlDate = controlDate;
			return this;
		}
	
		public ControlResoInterventoRotManBuilder By(Guid idUser) 
		{
			_idUser = idUser;
			return this;
		}
	
		public ControlResoInterventoRotManBuilder ForInterventoAppaltatore(string idInterventoAppaltatore) 
		{
			_idInterventoAppaltatore = idInterventoAppaltatore;
			return this;
		}
	
		public ControlResoInterventoRotManBuilder WithOggetti(OggettoRotMan[] oggetti) 
		{
			_oggetti = oggetti;
			return this;
		}
	
		public ControlResoInterventoRotMan Build(Guid id, long version)
		{
			return Build(id, Guid.NewGuid(), version);
		}

		public ControlResoInterventoRotMan Build(Guid id, long version,DateTime wakeupTime)
		{
			return Build(id, Guid.NewGuid(), version,wakeupTime);
		}

		public ControlResoInterventoRotMan Build(Guid id, Guid commitId, long version)
        {
            return new ControlResoInterventoRotMan(id, commitId, version, _note, _workPeriod, _controlDate, _idUser, _idInterventoAppaltatore, _oggetti);
		 }

		 public ControlResoInterventoRotMan Build(Guid id, Guid commitId, long version,DateTime wakeupTime)
        {
            return new ControlResoInterventoRotMan(id, commitId, version, wakeupTime, _note, _workPeriod, _controlDate, _idUser, _idInterventoAppaltatore, _oggetti);
		 }
        
	
	}

	public class ControlResoInterventoAmbBuilder : ICommandBuilder<ControlResoInterventoAmb>
	{
	 
		private string  _note ; 
		private WorkPeriod  _workPeriod ; 
		private DateTime  _controlDate ; 
		private Guid  _idUser ; 
		private string  _idInterventoAppaltatore ; 
		private string  _description ; 
		private int  _quantity ;
		public ControlResoInterventoAmbBuilder WithNote(string note) 
		{
			_note = note;
			return this;
		}
	
		public ControlResoInterventoAmbBuilder ForWorkPeriod(WorkPeriod workPeriod) 
		{
			_workPeriod = workPeriod;
			return this;
		}
	
		public ControlResoInterventoAmbBuilder When(DateTime controlDate) 
		{
			_controlDate = controlDate;
			return this;
		}
	
		public ControlResoInterventoAmbBuilder By(Guid idUser) 
		{
			_idUser = idUser;
			return this;
		}
	
		public ControlResoInterventoAmbBuilder ForInterventoAppaltatore(string idInterventoAppaltatore) 
		{
			_idInterventoAppaltatore = idInterventoAppaltatore;
			return this;
		}
	
		public ControlResoInterventoAmbBuilder ForDescription(string description) 
		{
			_description = description;
			return this;
		}
	
		public ControlResoInterventoAmbBuilder ForQuantity(int quantity) 
		{
			_quantity = quantity;
			return this;
		}
	
		public ControlResoInterventoAmb Build(Guid id, long version)
		{
			return Build(id, Guid.NewGuid(), version);
		}

		public ControlResoInterventoAmb Build(Guid id, long version,DateTime wakeupTime)
		{
			return Build(id, Guid.NewGuid(), version,wakeupTime);
		}

		public ControlResoInterventoAmb Build(Guid id, Guid commitId, long version)
        {
            return new ControlResoInterventoAmb(id, commitId, version, _note, _workPeriod, _controlDate, _idUser, _idInterventoAppaltatore, _description, _quantity);
		 }

		 public ControlResoInterventoAmb Build(Guid id, Guid commitId, long version,DateTime wakeupTime)
        {
            return new ControlResoInterventoAmb(id, commitId, version, wakeupTime, _note, _workPeriod, _controlDate, _idUser, _idInterventoAppaltatore, _description, _quantity);
		 }
        
	
	}
}

namespace Super.Controllo.Commands
{
	public static partial class BuildCmd 
	{
		  public static AllowControlInterventoBuilder AllowControlIntervento {get { return new AllowControlInterventoBuilder(); } }
	  		  public static CloseInterventoBuilder CloseIntervento {get { return new CloseInterventoBuilder(); } }
	  		  public static ReopenInterventoBuilder ReopenIntervento {get { return new ReopenInterventoBuilder(); } }
	  		  public static ControlNonResoInterventoBuilder ControlNonResoIntervento {get { return new ControlNonResoInterventoBuilder(); } }
	  		  public static ControlResoInterventoRotBuilder ControlResoInterventoRot {get { return new ControlResoInterventoRotBuilder(); } }
	  		  public static ControlResoInterventoRotManBuilder ControlResoInterventoRotMan {get { return new ControlResoInterventoRotManBuilder(); } }
	  		  public static ControlResoInterventoAmbBuilder ControlResoInterventoAmb {get { return new ControlResoInterventoAmbBuilder(); } }
	  	}
}
