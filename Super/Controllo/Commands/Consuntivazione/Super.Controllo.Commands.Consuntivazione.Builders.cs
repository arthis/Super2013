


using System;
using CommonDomain;
using System.Diagnostics.Contracts;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using Super.Controllo.Commands.Consuntivazione;
using Super.Controllo.Commands.Consuntivazione.Builders;

namespace Super.Controllo.Commands.Consuntivazione.Builders
{


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
	
		
		public CloseIntervento Build(Guid id)
		{
			return Build(id, Guid.NewGuid());
		}

		public CloseIntervento Build(Guid id, Guid commitId)
        {
            return new CloseIntervento(id, commitId, _idUser, _closingDate);
		 }


		
		public CloseIntervento Build(Guid id, long version)
		{
			return Build(id, Guid.NewGuid(), version);
		}

		public CloseIntervento Build(Guid id, Guid commitId, long version)
        {
            return new CloseIntervento(id, commitId, version, _idUser, _closingDate);
		}

		
		public CloseIntervento Build(Guid id, Guid commitId, Guid userId)
        {
            return new CloseIntervento(id, commitId, userId, _idUser, _closingDate);
		 }

		 public CloseIntervento Build(Guid id, long version, Guid userId)
		{
			return Build(id, Guid.NewGuid(), version, userId);
		}

		public CloseIntervento Build(Guid id, Guid commitId, long version, Guid userId)
        {
            return new CloseIntervento(id, commitId, version, userId, _idUser, _closingDate);
		}

		public CloseIntervento Build(Guid id, DateTime wakeupTime)
		{
			return Build(id, Guid.NewGuid(), wakeupTime);
		}

		public CloseIntervento Build(Guid id, Guid commitId, DateTime wakeupTime)
        {
            return new CloseIntervento(id, commitId, wakeupTime, _idUser, _closingDate);
		 }

		public CloseIntervento Build(Guid id, long version,DateTime wakeupTime)
		{
			return Build(id, Guid.NewGuid(), version,wakeupTime);
		}
		 

		public CloseIntervento Build(Guid id, Guid commitId, long version, DateTime wakeupTime)
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
	
		
		public ReopenIntervento Build(Guid id)
		{
			return Build(id, Guid.NewGuid());
		}

		public ReopenIntervento Build(Guid id, Guid commitId)
        {
            return new ReopenIntervento(id, commitId, _idUser, _reopeningDate);
		 }


		
		public ReopenIntervento Build(Guid id, long version)
		{
			return Build(id, Guid.NewGuid(), version);
		}

		public ReopenIntervento Build(Guid id, Guid commitId, long version)
        {
            return new ReopenIntervento(id, commitId, version, _idUser, _reopeningDate);
		}

		
		public ReopenIntervento Build(Guid id, Guid commitId, Guid userId)
        {
            return new ReopenIntervento(id, commitId, userId, _idUser, _reopeningDate);
		 }

		 public ReopenIntervento Build(Guid id, long version, Guid userId)
		{
			return Build(id, Guid.NewGuid(), version, userId);
		}

		public ReopenIntervento Build(Guid id, Guid commitId, long version, Guid userId)
        {
            return new ReopenIntervento(id, commitId, version, userId, _idUser, _reopeningDate);
		}

		public ReopenIntervento Build(Guid id, DateTime wakeupTime)
		{
			return Build(id, Guid.NewGuid(), wakeupTime);
		}

		public ReopenIntervento Build(Guid id, Guid commitId, DateTime wakeupTime)
        {
            return new ReopenIntervento(id, commitId, wakeupTime, _idUser, _reopeningDate);
		 }

		public ReopenIntervento Build(Guid id, long version,DateTime wakeupTime)
		{
			return Build(id, Guid.NewGuid(), version,wakeupTime);
		}
		 

		public ReopenIntervento Build(Guid id, Guid commitId, long version, DateTime wakeupTime)
        {
            return new ReopenIntervento(id, commitId, version, wakeupTime, _idUser, _reopeningDate);
		 }
        
	
	}

	public class ConsuntivareNonResoInterventoRotBuilder : ICommandBuilder<ConsuntivareNonResoInterventoRot>
	{
	 
		private string  _note ; 
		private Guid  _idCausaleAppaltatore ; 
		private DateTime  _dataConsuntivazione ; 
		private string  _idInterventoAppaltatore ;
		public ConsuntivareNonResoInterventoRotBuilder WithNote(string note) 
		{
			_note = note;
			return this;
		}
	
		public ConsuntivareNonResoInterventoRotBuilder Because(Guid idCausaleAppaltatore) 
		{
			_idCausaleAppaltatore = idCausaleAppaltatore;
			return this;
		}
	
		public ConsuntivareNonResoInterventoRotBuilder When(DateTime dataConsuntivazione) 
		{
			_dataConsuntivazione = dataConsuntivazione;
			return this;
		}
	
		public ConsuntivareNonResoInterventoRotBuilder ForInterventoAppaltatore(string idInterventoAppaltatore) 
		{
			_idInterventoAppaltatore = idInterventoAppaltatore;
			return this;
		}
	
		
		public ConsuntivareNonResoInterventoRot Build(Guid id)
		{
			return Build(id, Guid.NewGuid());
		}

		public ConsuntivareNonResoInterventoRot Build(Guid id, Guid commitId)
        {
            return new ConsuntivareNonResoInterventoRot(id, commitId, _note, _idCausaleAppaltatore, _dataConsuntivazione, _idInterventoAppaltatore);
		 }


		
		public ConsuntivareNonResoInterventoRot Build(Guid id, long version)
		{
			return Build(id, Guid.NewGuid(), version);
		}

		public ConsuntivareNonResoInterventoRot Build(Guid id, Guid commitId, long version)
        {
            return new ConsuntivareNonResoInterventoRot(id, commitId, version, _note, _idCausaleAppaltatore, _dataConsuntivazione, _idInterventoAppaltatore);
		}

		
		public ConsuntivareNonResoInterventoRot Build(Guid id, Guid commitId, Guid userId)
        {
            return new ConsuntivareNonResoInterventoRot(id, commitId, userId, _note, _idCausaleAppaltatore, _dataConsuntivazione, _idInterventoAppaltatore);
		 }

		 public ConsuntivareNonResoInterventoRot Build(Guid id, long version, Guid userId)
		{
			return Build(id, Guid.NewGuid(), version, userId);
		}

		public ConsuntivareNonResoInterventoRot Build(Guid id, Guid commitId, long version, Guid userId)
        {
            return new ConsuntivareNonResoInterventoRot(id, commitId, version, userId, _note, _idCausaleAppaltatore, _dataConsuntivazione, _idInterventoAppaltatore);
		}

		public ConsuntivareNonResoInterventoRot Build(Guid id, DateTime wakeupTime)
		{
			return Build(id, Guid.NewGuid(), wakeupTime);
		}

		public ConsuntivareNonResoInterventoRot Build(Guid id, Guid commitId, DateTime wakeupTime)
        {
            return new ConsuntivareNonResoInterventoRot(id, commitId, wakeupTime, _note, _idCausaleAppaltatore, _dataConsuntivazione, _idInterventoAppaltatore);
		 }

		public ConsuntivareNonResoInterventoRot Build(Guid id, long version,DateTime wakeupTime)
		{
			return Build(id, Guid.NewGuid(), version,wakeupTime);
		}
		 

		public ConsuntivareNonResoInterventoRot Build(Guid id, Guid commitId, long version, DateTime wakeupTime)
        {
            return new ConsuntivareNonResoInterventoRot(id, commitId, version, wakeupTime, _note, _idCausaleAppaltatore, _dataConsuntivazione, _idInterventoAppaltatore);
		 }
        
	
	}

	public class ConsuntivareNonResoInterventoRotManBuilder : ICommandBuilder<ConsuntivareNonResoInterventoRotMan>
	{
	 
		private string  _note ; 
		private Guid  _idCausaleAppaltatore ; 
		private DateTime  _dataConsuntivazione ; 
		private string  _idInterventoAppaltatore ;
		public ConsuntivareNonResoInterventoRotManBuilder WithNote(string note) 
		{
			_note = note;
			return this;
		}
	
		public ConsuntivareNonResoInterventoRotManBuilder Because(Guid idCausaleAppaltatore) 
		{
			_idCausaleAppaltatore = idCausaleAppaltatore;
			return this;
		}
	
		public ConsuntivareNonResoInterventoRotManBuilder When(DateTime dataConsuntivazione) 
		{
			_dataConsuntivazione = dataConsuntivazione;
			return this;
		}
	
		public ConsuntivareNonResoInterventoRotManBuilder ForInterventoAppaltatore(string idInterventoAppaltatore) 
		{
			_idInterventoAppaltatore = idInterventoAppaltatore;
			return this;
		}
	
		
		public ConsuntivareNonResoInterventoRotMan Build(Guid id)
		{
			return Build(id, Guid.NewGuid());
		}

		public ConsuntivareNonResoInterventoRotMan Build(Guid id, Guid commitId)
        {
            return new ConsuntivareNonResoInterventoRotMan(id, commitId, _note, _idCausaleAppaltatore, _dataConsuntivazione, _idInterventoAppaltatore);
		 }


		
		public ConsuntivareNonResoInterventoRotMan Build(Guid id, long version)
		{
			return Build(id, Guid.NewGuid(), version);
		}

		public ConsuntivareNonResoInterventoRotMan Build(Guid id, Guid commitId, long version)
        {
            return new ConsuntivareNonResoInterventoRotMan(id, commitId, version, _note, _idCausaleAppaltatore, _dataConsuntivazione, _idInterventoAppaltatore);
		}

		
		public ConsuntivareNonResoInterventoRotMan Build(Guid id, Guid commitId, Guid userId)
        {
            return new ConsuntivareNonResoInterventoRotMan(id, commitId, userId, _note, _idCausaleAppaltatore, _dataConsuntivazione, _idInterventoAppaltatore);
		 }

		 public ConsuntivareNonResoInterventoRotMan Build(Guid id, long version, Guid userId)
		{
			return Build(id, Guid.NewGuid(), version, userId);
		}

		public ConsuntivareNonResoInterventoRotMan Build(Guid id, Guid commitId, long version, Guid userId)
        {
            return new ConsuntivareNonResoInterventoRotMan(id, commitId, version, userId, _note, _idCausaleAppaltatore, _dataConsuntivazione, _idInterventoAppaltatore);
		}

		public ConsuntivareNonResoInterventoRotMan Build(Guid id, DateTime wakeupTime)
		{
			return Build(id, Guid.NewGuid(), wakeupTime);
		}

		public ConsuntivareNonResoInterventoRotMan Build(Guid id, Guid commitId, DateTime wakeupTime)
        {
            return new ConsuntivareNonResoInterventoRotMan(id, commitId, wakeupTime, _note, _idCausaleAppaltatore, _dataConsuntivazione, _idInterventoAppaltatore);
		 }

		public ConsuntivareNonResoInterventoRotMan Build(Guid id, long version,DateTime wakeupTime)
		{
			return Build(id, Guid.NewGuid(), version,wakeupTime);
		}
		 

		public ConsuntivareNonResoInterventoRotMan Build(Guid id, Guid commitId, long version, DateTime wakeupTime)
        {
            return new ConsuntivareNonResoInterventoRotMan(id, commitId, version, wakeupTime, _note, _idCausaleAppaltatore, _dataConsuntivazione, _idInterventoAppaltatore);
		 }
        
	
	}

	public class ConsuntivareNonResoInterventoAmbBuilder : ICommandBuilder<ConsuntivareNonResoInterventoAmb>
	{
	 
		private string  _note ; 
		private Guid  _idCausaleAppaltatore ; 
		private DateTime  _dataConsuntivazione ; 
		private string  _idInterventoAppaltatore ;
		public ConsuntivareNonResoInterventoAmbBuilder WithNote(string note) 
		{
			_note = note;
			return this;
		}
	
		public ConsuntivareNonResoInterventoAmbBuilder Because(Guid idCausaleAppaltatore) 
		{
			_idCausaleAppaltatore = idCausaleAppaltatore;
			return this;
		}
	
		public ConsuntivareNonResoInterventoAmbBuilder When(DateTime dataConsuntivazione) 
		{
			_dataConsuntivazione = dataConsuntivazione;
			return this;
		}
	
		public ConsuntivareNonResoInterventoAmbBuilder ForInterventoAppaltatore(string idInterventoAppaltatore) 
		{
			_idInterventoAppaltatore = idInterventoAppaltatore;
			return this;
		}
	
		
		public ConsuntivareNonResoInterventoAmb Build(Guid id)
		{
			return Build(id, Guid.NewGuid());
		}

		public ConsuntivareNonResoInterventoAmb Build(Guid id, Guid commitId)
        {
            return new ConsuntivareNonResoInterventoAmb(id, commitId, _note, _idCausaleAppaltatore, _dataConsuntivazione, _idInterventoAppaltatore);
		 }


		
		public ConsuntivareNonResoInterventoAmb Build(Guid id, long version)
		{
			return Build(id, Guid.NewGuid(), version);
		}

		public ConsuntivareNonResoInterventoAmb Build(Guid id, Guid commitId, long version)
        {
            return new ConsuntivareNonResoInterventoAmb(id, commitId, version, _note, _idCausaleAppaltatore, _dataConsuntivazione, _idInterventoAppaltatore);
		}

		
		public ConsuntivareNonResoInterventoAmb Build(Guid id, Guid commitId, Guid userId)
        {
            return new ConsuntivareNonResoInterventoAmb(id, commitId, userId, _note, _idCausaleAppaltatore, _dataConsuntivazione, _idInterventoAppaltatore);
		 }

		 public ConsuntivareNonResoInterventoAmb Build(Guid id, long version, Guid userId)
		{
			return Build(id, Guid.NewGuid(), version, userId);
		}

		public ConsuntivareNonResoInterventoAmb Build(Guid id, Guid commitId, long version, Guid userId)
        {
            return new ConsuntivareNonResoInterventoAmb(id, commitId, version, userId, _note, _idCausaleAppaltatore, _dataConsuntivazione, _idInterventoAppaltatore);
		}

		public ConsuntivareNonResoInterventoAmb Build(Guid id, DateTime wakeupTime)
		{
			return Build(id, Guid.NewGuid(), wakeupTime);
		}

		public ConsuntivareNonResoInterventoAmb Build(Guid id, Guid commitId, DateTime wakeupTime)
        {
            return new ConsuntivareNonResoInterventoAmb(id, commitId, wakeupTime, _note, _idCausaleAppaltatore, _dataConsuntivazione, _idInterventoAppaltatore);
		 }

		public ConsuntivareNonResoInterventoAmb Build(Guid id, long version,DateTime wakeupTime)
		{
			return Build(id, Guid.NewGuid(), version,wakeupTime);
		}
		 

		public ConsuntivareNonResoInterventoAmb Build(Guid id, Guid commitId, long version, DateTime wakeupTime)
        {
            return new ConsuntivareNonResoInterventoAmb(id, commitId, version, wakeupTime, _note, _idCausaleAppaltatore, _dataConsuntivazione, _idInterventoAppaltatore);
		 }
        
	
	}

	public class ConsuntivareNonResoTrenitaliaInterventoRotBuilder : ICommandBuilder<ConsuntivareNonResoTrenitaliaInterventoRot>
	{
	 
		private string  _note ; 
		private Guid  _idCausaleTrenitalia ; 
		private DateTime  _dataConsuntivazione ; 
		private string  _idInterventoAppaltatore ;
		public ConsuntivareNonResoTrenitaliaInterventoRotBuilder WithNote(string note) 
		{
			_note = note;
			return this;
		}
	
		public ConsuntivareNonResoTrenitaliaInterventoRotBuilder Because(Guid idCausaleTrenitalia) 
		{
			_idCausaleTrenitalia = idCausaleTrenitalia;
			return this;
		}
	
		public ConsuntivareNonResoTrenitaliaInterventoRotBuilder When(DateTime dataConsuntivazione) 
		{
			_dataConsuntivazione = dataConsuntivazione;
			return this;
		}
	
		public ConsuntivareNonResoTrenitaliaInterventoRotBuilder ForInterventoAppaltatore(string idInterventoAppaltatore) 
		{
			_idInterventoAppaltatore = idInterventoAppaltatore;
			return this;
		}
	
		
		public ConsuntivareNonResoTrenitaliaInterventoRot Build(Guid id)
		{
			return Build(id, Guid.NewGuid());
		}

		public ConsuntivareNonResoTrenitaliaInterventoRot Build(Guid id, Guid commitId)
        {
            return new ConsuntivareNonResoTrenitaliaInterventoRot(id, commitId, _note, _idCausaleTrenitalia, _dataConsuntivazione, _idInterventoAppaltatore);
		 }


		
		public ConsuntivareNonResoTrenitaliaInterventoRot Build(Guid id, long version)
		{
			return Build(id, Guid.NewGuid(), version);
		}

		public ConsuntivareNonResoTrenitaliaInterventoRot Build(Guid id, Guid commitId, long version)
        {
            return new ConsuntivareNonResoTrenitaliaInterventoRot(id, commitId, version, _note, _idCausaleTrenitalia, _dataConsuntivazione, _idInterventoAppaltatore);
		}

		
		public ConsuntivareNonResoTrenitaliaInterventoRot Build(Guid id, Guid commitId, Guid userId)
        {
            return new ConsuntivareNonResoTrenitaliaInterventoRot(id, commitId, userId, _note, _idCausaleTrenitalia, _dataConsuntivazione, _idInterventoAppaltatore);
		 }

		 public ConsuntivareNonResoTrenitaliaInterventoRot Build(Guid id, long version, Guid userId)
		{
			return Build(id, Guid.NewGuid(), version, userId);
		}

		public ConsuntivareNonResoTrenitaliaInterventoRot Build(Guid id, Guid commitId, long version, Guid userId)
        {
            return new ConsuntivareNonResoTrenitaliaInterventoRot(id, commitId, version, userId, _note, _idCausaleTrenitalia, _dataConsuntivazione, _idInterventoAppaltatore);
		}

		public ConsuntivareNonResoTrenitaliaInterventoRot Build(Guid id, DateTime wakeupTime)
		{
			return Build(id, Guid.NewGuid(), wakeupTime);
		}

		public ConsuntivareNonResoTrenitaliaInterventoRot Build(Guid id, Guid commitId, DateTime wakeupTime)
        {
            return new ConsuntivareNonResoTrenitaliaInterventoRot(id, commitId, wakeupTime, _note, _idCausaleTrenitalia, _dataConsuntivazione, _idInterventoAppaltatore);
		 }

		public ConsuntivareNonResoTrenitaliaInterventoRot Build(Guid id, long version,DateTime wakeupTime)
		{
			return Build(id, Guid.NewGuid(), version,wakeupTime);
		}
		 

		public ConsuntivareNonResoTrenitaliaInterventoRot Build(Guid id, Guid commitId, long version, DateTime wakeupTime)
        {
            return new ConsuntivareNonResoTrenitaliaInterventoRot(id, commitId, version, wakeupTime, _note, _idCausaleTrenitalia, _dataConsuntivazione, _idInterventoAppaltatore);
		 }
        
	
	}

	public class ConsuntivareNonResoTrenitaliaInterventoRotManBuilder : ICommandBuilder<ConsuntivareNonResoTrenitaliaInterventoRotMan>
	{
	 
		private string  _note ; 
		private Guid  _idCausaleTrenitalia ; 
		private DateTime  _dataConsuntivazione ; 
		private string  _idInterventoAppaltatore ;
		public ConsuntivareNonResoTrenitaliaInterventoRotManBuilder WithNote(string note) 
		{
			_note = note;
			return this;
		}
	
		public ConsuntivareNonResoTrenitaliaInterventoRotManBuilder Because(Guid idCausaleTrenitalia) 
		{
			_idCausaleTrenitalia = idCausaleTrenitalia;
			return this;
		}
	
		public ConsuntivareNonResoTrenitaliaInterventoRotManBuilder When(DateTime dataConsuntivazione) 
		{
			_dataConsuntivazione = dataConsuntivazione;
			return this;
		}
	
		public ConsuntivareNonResoTrenitaliaInterventoRotManBuilder ForInterventoAppaltatore(string idInterventoAppaltatore) 
		{
			_idInterventoAppaltatore = idInterventoAppaltatore;
			return this;
		}
	
		
		public ConsuntivareNonResoTrenitaliaInterventoRotMan Build(Guid id)
		{
			return Build(id, Guid.NewGuid());
		}

		public ConsuntivareNonResoTrenitaliaInterventoRotMan Build(Guid id, Guid commitId)
        {
            return new ConsuntivareNonResoTrenitaliaInterventoRotMan(id, commitId, _note, _idCausaleTrenitalia, _dataConsuntivazione, _idInterventoAppaltatore);
		 }


		
		public ConsuntivareNonResoTrenitaliaInterventoRotMan Build(Guid id, long version)
		{
			return Build(id, Guid.NewGuid(), version);
		}

		public ConsuntivareNonResoTrenitaliaInterventoRotMan Build(Guid id, Guid commitId, long version)
        {
            return new ConsuntivareNonResoTrenitaliaInterventoRotMan(id, commitId, version, _note, _idCausaleTrenitalia, _dataConsuntivazione, _idInterventoAppaltatore);
		}

		
		public ConsuntivareNonResoTrenitaliaInterventoRotMan Build(Guid id, Guid commitId, Guid userId)
        {
            return new ConsuntivareNonResoTrenitaliaInterventoRotMan(id, commitId, userId, _note, _idCausaleTrenitalia, _dataConsuntivazione, _idInterventoAppaltatore);
		 }

		 public ConsuntivareNonResoTrenitaliaInterventoRotMan Build(Guid id, long version, Guid userId)
		{
			return Build(id, Guid.NewGuid(), version, userId);
		}

		public ConsuntivareNonResoTrenitaliaInterventoRotMan Build(Guid id, Guid commitId, long version, Guid userId)
        {
            return new ConsuntivareNonResoTrenitaliaInterventoRotMan(id, commitId, version, userId, _note, _idCausaleTrenitalia, _dataConsuntivazione, _idInterventoAppaltatore);
		}

		public ConsuntivareNonResoTrenitaliaInterventoRotMan Build(Guid id, DateTime wakeupTime)
		{
			return Build(id, Guid.NewGuid(), wakeupTime);
		}

		public ConsuntivareNonResoTrenitaliaInterventoRotMan Build(Guid id, Guid commitId, DateTime wakeupTime)
        {
            return new ConsuntivareNonResoTrenitaliaInterventoRotMan(id, commitId, wakeupTime, _note, _idCausaleTrenitalia, _dataConsuntivazione, _idInterventoAppaltatore);
		 }

		public ConsuntivareNonResoTrenitaliaInterventoRotMan Build(Guid id, long version,DateTime wakeupTime)
		{
			return Build(id, Guid.NewGuid(), version,wakeupTime);
		}
		 

		public ConsuntivareNonResoTrenitaliaInterventoRotMan Build(Guid id, Guid commitId, long version, DateTime wakeupTime)
        {
            return new ConsuntivareNonResoTrenitaliaInterventoRotMan(id, commitId, version, wakeupTime, _note, _idCausaleTrenitalia, _dataConsuntivazione, _idInterventoAppaltatore);
		 }
        
	
	}

	public class ConsuntivareNonResoTrenitaliaInterventoAmbBuilder : ICommandBuilder<ConsuntivareNonResoTrenitaliaInterventoAmb>
	{
	 
		private string  _note ; 
		private Guid  _idCausaleTrenitalia ; 
		private DateTime  _dataConsuntivazione ; 
		private string  _idInterventoAppaltatore ;
		public ConsuntivareNonResoTrenitaliaInterventoAmbBuilder WithNote(string note) 
		{
			_note = note;
			return this;
		}
	
		public ConsuntivareNonResoTrenitaliaInterventoAmbBuilder Because(Guid idCausaleTrenitalia) 
		{
			_idCausaleTrenitalia = idCausaleTrenitalia;
			return this;
		}
	
		public ConsuntivareNonResoTrenitaliaInterventoAmbBuilder When(DateTime dataConsuntivazione) 
		{
			_dataConsuntivazione = dataConsuntivazione;
			return this;
		}
	
		public ConsuntivareNonResoTrenitaliaInterventoAmbBuilder ForInterventoAppaltatore(string idInterventoAppaltatore) 
		{
			_idInterventoAppaltatore = idInterventoAppaltatore;
			return this;
		}
	
		
		public ConsuntivareNonResoTrenitaliaInterventoAmb Build(Guid id)
		{
			return Build(id, Guid.NewGuid());
		}

		public ConsuntivareNonResoTrenitaliaInterventoAmb Build(Guid id, Guid commitId)
        {
            return new ConsuntivareNonResoTrenitaliaInterventoAmb(id, commitId, _note, _idCausaleTrenitalia, _dataConsuntivazione, _idInterventoAppaltatore);
		 }


		
		public ConsuntivareNonResoTrenitaliaInterventoAmb Build(Guid id, long version)
		{
			return Build(id, Guid.NewGuid(), version);
		}

		public ConsuntivareNonResoTrenitaliaInterventoAmb Build(Guid id, Guid commitId, long version)
        {
            return new ConsuntivareNonResoTrenitaliaInterventoAmb(id, commitId, version, _note, _idCausaleTrenitalia, _dataConsuntivazione, _idInterventoAppaltatore);
		}

		
		public ConsuntivareNonResoTrenitaliaInterventoAmb Build(Guid id, Guid commitId, Guid userId)
        {
            return new ConsuntivareNonResoTrenitaliaInterventoAmb(id, commitId, userId, _note, _idCausaleTrenitalia, _dataConsuntivazione, _idInterventoAppaltatore);
		 }

		 public ConsuntivareNonResoTrenitaliaInterventoAmb Build(Guid id, long version, Guid userId)
		{
			return Build(id, Guid.NewGuid(), version, userId);
		}

		public ConsuntivareNonResoTrenitaliaInterventoAmb Build(Guid id, Guid commitId, long version, Guid userId)
        {
            return new ConsuntivareNonResoTrenitaliaInterventoAmb(id, commitId, version, userId, _note, _idCausaleTrenitalia, _dataConsuntivazione, _idInterventoAppaltatore);
		}

		public ConsuntivareNonResoTrenitaliaInterventoAmb Build(Guid id, DateTime wakeupTime)
		{
			return Build(id, Guid.NewGuid(), wakeupTime);
		}

		public ConsuntivareNonResoTrenitaliaInterventoAmb Build(Guid id, Guid commitId, DateTime wakeupTime)
        {
            return new ConsuntivareNonResoTrenitaliaInterventoAmb(id, commitId, wakeupTime, _note, _idCausaleTrenitalia, _dataConsuntivazione, _idInterventoAppaltatore);
		 }

		public ConsuntivareNonResoTrenitaliaInterventoAmb Build(Guid id, long version,DateTime wakeupTime)
		{
			return Build(id, Guid.NewGuid(), version,wakeupTime);
		}
		 

		public ConsuntivareNonResoTrenitaliaInterventoAmb Build(Guid id, Guid commitId, long version, DateTime wakeupTime)
        {
            return new ConsuntivareNonResoTrenitaliaInterventoAmb(id, commitId, version, wakeupTime, _note, _idCausaleTrenitalia, _dataConsuntivazione, _idInterventoAppaltatore);
		 }
        
	
	}

	public class ConsuntivareResoInterventoRotBuilder : ICommandBuilder<ConsuntivareResoInterventoRot>
	{
	 
		private string  _note ; 
		private WorkPeriod  _workPeriod ; 
		private DateTime  _dataConsuntivazione ; 
		private string  _idInterventoAppaltatore ; 
		private OggettoRot[]  _oggetti ;
		public ConsuntivareResoInterventoRotBuilder WithNote(string note) 
		{
			_note = note;
			return this;
		}
	
		public ConsuntivareResoInterventoRotBuilder ForWorkPeriod(WorkPeriod workPeriod) 
		{
			_workPeriod = workPeriod;
			return this;
		}
	
		public ConsuntivareResoInterventoRotBuilder When(DateTime dataConsuntivazione) 
		{
			_dataConsuntivazione = dataConsuntivazione;
			return this;
		}
	
		public ConsuntivareResoInterventoRotBuilder ForInterventoAppaltatore(string idInterventoAppaltatore) 
		{
			_idInterventoAppaltatore = idInterventoAppaltatore;
			return this;
		}
	
		public ConsuntivareResoInterventoRotBuilder WithOggetti(OggettoRot[] oggetti) 
		{
			_oggetti = oggetti;
			return this;
		}
	
		
		public ConsuntivareResoInterventoRot Build(Guid id)
		{
			return Build(id, Guid.NewGuid());
		}

		public ConsuntivareResoInterventoRot Build(Guid id, Guid commitId)
        {
            return new ConsuntivareResoInterventoRot(id, commitId, _note, _workPeriod, _dataConsuntivazione, _idInterventoAppaltatore, _oggetti);
		 }


		
		public ConsuntivareResoInterventoRot Build(Guid id, long version)
		{
			return Build(id, Guid.NewGuid(), version);
		}

		public ConsuntivareResoInterventoRot Build(Guid id, Guid commitId, long version)
        {
            return new ConsuntivareResoInterventoRot(id, commitId, version, _note, _workPeriod, _dataConsuntivazione, _idInterventoAppaltatore, _oggetti);
		}

		
		public ConsuntivareResoInterventoRot Build(Guid id, Guid commitId, Guid userId)
        {
            return new ConsuntivareResoInterventoRot(id, commitId, userId, _note, _workPeriod, _dataConsuntivazione, _idInterventoAppaltatore, _oggetti);
		 }

		 public ConsuntivareResoInterventoRot Build(Guid id, long version, Guid userId)
		{
			return Build(id, Guid.NewGuid(), version, userId);
		}

		public ConsuntivareResoInterventoRot Build(Guid id, Guid commitId, long version, Guid userId)
        {
            return new ConsuntivareResoInterventoRot(id, commitId, version, userId, _note, _workPeriod, _dataConsuntivazione, _idInterventoAppaltatore, _oggetti);
		}

		public ConsuntivareResoInterventoRot Build(Guid id, DateTime wakeupTime)
		{
			return Build(id, Guid.NewGuid(), wakeupTime);
		}

		public ConsuntivareResoInterventoRot Build(Guid id, Guid commitId, DateTime wakeupTime)
        {
            return new ConsuntivareResoInterventoRot(id, commitId, wakeupTime, _note, _workPeriod, _dataConsuntivazione, _idInterventoAppaltatore, _oggetti);
		 }

		public ConsuntivareResoInterventoRot Build(Guid id, long version,DateTime wakeupTime)
		{
			return Build(id, Guid.NewGuid(), version,wakeupTime);
		}
		 

		public ConsuntivareResoInterventoRot Build(Guid id, Guid commitId, long version, DateTime wakeupTime)
        {
            return new ConsuntivareResoInterventoRot(id, commitId, version, wakeupTime, _note, _workPeriod, _dataConsuntivazione, _idInterventoAppaltatore, _oggetti);
		 }
        
	
	}

	public class ConsuntivareResoInterventoRotManBuilder : ICommandBuilder<ConsuntivareResoInterventoRotMan>
	{
	 
		private string  _note ; 
		private WorkPeriod  _workPeriod ; 
		private DateTime  _dataConsuntivazione ; 
		private string  _idInterventoAppaltatore ; 
		private OggettoRotMan[]  _oggetti ;
		public ConsuntivareResoInterventoRotManBuilder WithNote(string note) 
		{
			_note = note;
			return this;
		}
	
		public ConsuntivareResoInterventoRotManBuilder ForWorkPeriod(WorkPeriod workPeriod) 
		{
			_workPeriod = workPeriod;
			return this;
		}
	
		public ConsuntivareResoInterventoRotManBuilder When(DateTime dataConsuntivazione) 
		{
			_dataConsuntivazione = dataConsuntivazione;
			return this;
		}
	
		public ConsuntivareResoInterventoRotManBuilder ForInterventoAppaltatore(string idInterventoAppaltatore) 
		{
			_idInterventoAppaltatore = idInterventoAppaltatore;
			return this;
		}
	
		public ConsuntivareResoInterventoRotManBuilder WithOggetti(OggettoRotMan[] oggetti) 
		{
			_oggetti = oggetti;
			return this;
		}
	
		
		public ConsuntivareResoInterventoRotMan Build(Guid id)
		{
			return Build(id, Guid.NewGuid());
		}

		public ConsuntivareResoInterventoRotMan Build(Guid id, Guid commitId)
        {
            return new ConsuntivareResoInterventoRotMan(id, commitId, _note, _workPeriod, _dataConsuntivazione, _idInterventoAppaltatore, _oggetti);
		 }


		
		public ConsuntivareResoInterventoRotMan Build(Guid id, long version)
		{
			return Build(id, Guid.NewGuid(), version);
		}

		public ConsuntivareResoInterventoRotMan Build(Guid id, Guid commitId, long version)
        {
            return new ConsuntivareResoInterventoRotMan(id, commitId, version, _note, _workPeriod, _dataConsuntivazione, _idInterventoAppaltatore, _oggetti);
		}

		
		public ConsuntivareResoInterventoRotMan Build(Guid id, Guid commitId, Guid userId)
        {
            return new ConsuntivareResoInterventoRotMan(id, commitId, userId, _note, _workPeriod, _dataConsuntivazione, _idInterventoAppaltatore, _oggetti);
		 }

		 public ConsuntivareResoInterventoRotMan Build(Guid id, long version, Guid userId)
		{
			return Build(id, Guid.NewGuid(), version, userId);
		}

		public ConsuntivareResoInterventoRotMan Build(Guid id, Guid commitId, long version, Guid userId)
        {
            return new ConsuntivareResoInterventoRotMan(id, commitId, version, userId, _note, _workPeriod, _dataConsuntivazione, _idInterventoAppaltatore, _oggetti);
		}

		public ConsuntivareResoInterventoRotMan Build(Guid id, DateTime wakeupTime)
		{
			return Build(id, Guid.NewGuid(), wakeupTime);
		}

		public ConsuntivareResoInterventoRotMan Build(Guid id, Guid commitId, DateTime wakeupTime)
        {
            return new ConsuntivareResoInterventoRotMan(id, commitId, wakeupTime, _note, _workPeriod, _dataConsuntivazione, _idInterventoAppaltatore, _oggetti);
		 }

		public ConsuntivareResoInterventoRotMan Build(Guid id, long version,DateTime wakeupTime)
		{
			return Build(id, Guid.NewGuid(), version,wakeupTime);
		}
		 

		public ConsuntivareResoInterventoRotMan Build(Guid id, Guid commitId, long version, DateTime wakeupTime)
        {
            return new ConsuntivareResoInterventoRotMan(id, commitId, version, wakeupTime, _note, _workPeriod, _dataConsuntivazione, _idInterventoAppaltatore, _oggetti);
		 }
        
	
	}

	public class ConsuntivareResoInterventoAmbBuilder : ICommandBuilder<ConsuntivareResoInterventoAmb>
	{
	 
		private string  _note ; 
		private WorkPeriod  _workPeriod ; 
		private DateTime  _dataConsuntivazione ; 
		private string  _idInterventoAppaltatore ; 
		private string  _description ; 
		private int  _quantity ;
		public ConsuntivareResoInterventoAmbBuilder WithNote(string note) 
		{
			_note = note;
			return this;
		}
	
		public ConsuntivareResoInterventoAmbBuilder ForWorkPeriod(WorkPeriod workPeriod) 
		{
			_workPeriod = workPeriod;
			return this;
		}
	
		public ConsuntivareResoInterventoAmbBuilder When(DateTime dataConsuntivazione) 
		{
			_dataConsuntivazione = dataConsuntivazione;
			return this;
		}
	
		public ConsuntivareResoInterventoAmbBuilder ForInterventoAppaltatore(string idInterventoAppaltatore) 
		{
			_idInterventoAppaltatore = idInterventoAppaltatore;
			return this;
		}
	
		public ConsuntivareResoInterventoAmbBuilder ForDescription(string description) 
		{
			_description = description;
			return this;
		}
	
		public ConsuntivareResoInterventoAmbBuilder ForQuantity(int quantity) 
		{
			_quantity = quantity;
			return this;
		}
	
		
		public ConsuntivareResoInterventoAmb Build(Guid id)
		{
			return Build(id, Guid.NewGuid());
		}

		public ConsuntivareResoInterventoAmb Build(Guid id, Guid commitId)
        {
            return new ConsuntivareResoInterventoAmb(id, commitId, _note, _workPeriod, _dataConsuntivazione, _idInterventoAppaltatore, _description, _quantity);
		 }


		
		public ConsuntivareResoInterventoAmb Build(Guid id, long version)
		{
			return Build(id, Guid.NewGuid(), version);
		}

		public ConsuntivareResoInterventoAmb Build(Guid id, Guid commitId, long version)
        {
            return new ConsuntivareResoInterventoAmb(id, commitId, version, _note, _workPeriod, _dataConsuntivazione, _idInterventoAppaltatore, _description, _quantity);
		}

		
		public ConsuntivareResoInterventoAmb Build(Guid id, Guid commitId, Guid userId)
        {
            return new ConsuntivareResoInterventoAmb(id, commitId, userId, _note, _workPeriod, _dataConsuntivazione, _idInterventoAppaltatore, _description, _quantity);
		 }

		 public ConsuntivareResoInterventoAmb Build(Guid id, long version, Guid userId)
		{
			return Build(id, Guid.NewGuid(), version, userId);
		}

		public ConsuntivareResoInterventoAmb Build(Guid id, Guid commitId, long version, Guid userId)
        {
            return new ConsuntivareResoInterventoAmb(id, commitId, version, userId, _note, _workPeriod, _dataConsuntivazione, _idInterventoAppaltatore, _description, _quantity);
		}

		public ConsuntivareResoInterventoAmb Build(Guid id, DateTime wakeupTime)
		{
			return Build(id, Guid.NewGuid(), wakeupTime);
		}

		public ConsuntivareResoInterventoAmb Build(Guid id, Guid commitId, DateTime wakeupTime)
        {
            return new ConsuntivareResoInterventoAmb(id, commitId, wakeupTime, _note, _workPeriod, _dataConsuntivazione, _idInterventoAppaltatore, _description, _quantity);
		 }

		public ConsuntivareResoInterventoAmb Build(Guid id, long version,DateTime wakeupTime)
		{
			return Build(id, Guid.NewGuid(), version,wakeupTime);
		}
		 

		public ConsuntivareResoInterventoAmb Build(Guid id, Guid commitId, long version, DateTime wakeupTime)
        {
            return new ConsuntivareResoInterventoAmb(id, commitId, version, wakeupTime, _note, _workPeriod, _dataConsuntivazione, _idInterventoAppaltatore, _description, _quantity);
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
	
		
		public ControlNonResoIntervento Build(Guid id)
		{
			return Build(id, Guid.NewGuid());
		}

		public ControlNonResoIntervento Build(Guid id, Guid commitId)
        {
            return new ControlNonResoIntervento(id, commitId, _note, _idCausale, _controlDate, _idUser);
		 }


		
		public ControlNonResoIntervento Build(Guid id, long version)
		{
			return Build(id, Guid.NewGuid(), version);
		}

		public ControlNonResoIntervento Build(Guid id, Guid commitId, long version)
        {
            return new ControlNonResoIntervento(id, commitId, version, _note, _idCausale, _controlDate, _idUser);
		}

		
		public ControlNonResoIntervento Build(Guid id, Guid commitId, Guid userId)
        {
            return new ControlNonResoIntervento(id, commitId, userId, _note, _idCausale, _controlDate, _idUser);
		 }

		 public ControlNonResoIntervento Build(Guid id, long version, Guid userId)
		{
			return Build(id, Guid.NewGuid(), version, userId);
		}

		public ControlNonResoIntervento Build(Guid id, Guid commitId, long version, Guid userId)
        {
            return new ControlNonResoIntervento(id, commitId, version, userId, _note, _idCausale, _controlDate, _idUser);
		}

		public ControlNonResoIntervento Build(Guid id, DateTime wakeupTime)
		{
			return Build(id, Guid.NewGuid(), wakeupTime);
		}

		public ControlNonResoIntervento Build(Guid id, Guid commitId, DateTime wakeupTime)
        {
            return new ControlNonResoIntervento(id, commitId, wakeupTime, _note, _idCausale, _controlDate, _idUser);
		 }

		public ControlNonResoIntervento Build(Guid id, long version,DateTime wakeupTime)
		{
			return Build(id, Guid.NewGuid(), version,wakeupTime);
		}
		 

		public ControlNonResoIntervento Build(Guid id, Guid commitId, long version, DateTime wakeupTime)
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
	
		
		public ControlResoInterventoRot Build(Guid id)
		{
			return Build(id, Guid.NewGuid());
		}

		public ControlResoInterventoRot Build(Guid id, Guid commitId)
        {
            return new ControlResoInterventoRot(id, commitId, _note, _workPeriod, _controlDate, _idUser, _idInterventoAppaltatore, _convoglio, _rigaTurnoTreno, _turnoTreno, _trenoArrivo, _trenoPartenza, _oggetti);
		 }


		
		public ControlResoInterventoRot Build(Guid id, long version)
		{
			return Build(id, Guid.NewGuid(), version);
		}

		public ControlResoInterventoRot Build(Guid id, Guid commitId, long version)
        {
            return new ControlResoInterventoRot(id, commitId, version, _note, _workPeriod, _controlDate, _idUser, _idInterventoAppaltatore, _convoglio, _rigaTurnoTreno, _turnoTreno, _trenoArrivo, _trenoPartenza, _oggetti);
		}

		
		public ControlResoInterventoRot Build(Guid id, Guid commitId, Guid userId)
        {
            return new ControlResoInterventoRot(id, commitId, userId, _note, _workPeriod, _controlDate, _idUser, _idInterventoAppaltatore, _convoglio, _rigaTurnoTreno, _turnoTreno, _trenoArrivo, _trenoPartenza, _oggetti);
		 }

		 public ControlResoInterventoRot Build(Guid id, long version, Guid userId)
		{
			return Build(id, Guid.NewGuid(), version, userId);
		}

		public ControlResoInterventoRot Build(Guid id, Guid commitId, long version, Guid userId)
        {
            return new ControlResoInterventoRot(id, commitId, version, userId, _note, _workPeriod, _controlDate, _idUser, _idInterventoAppaltatore, _convoglio, _rigaTurnoTreno, _turnoTreno, _trenoArrivo, _trenoPartenza, _oggetti);
		}

		public ControlResoInterventoRot Build(Guid id, DateTime wakeupTime)
		{
			return Build(id, Guid.NewGuid(), wakeupTime);
		}

		public ControlResoInterventoRot Build(Guid id, Guid commitId, DateTime wakeupTime)
        {
            return new ControlResoInterventoRot(id, commitId, wakeupTime, _note, _workPeriod, _controlDate, _idUser, _idInterventoAppaltatore, _convoglio, _rigaTurnoTreno, _turnoTreno, _trenoArrivo, _trenoPartenza, _oggetti);
		 }

		public ControlResoInterventoRot Build(Guid id, long version,DateTime wakeupTime)
		{
			return Build(id, Guid.NewGuid(), version,wakeupTime);
		}
		 

		public ControlResoInterventoRot Build(Guid id, Guid commitId, long version, DateTime wakeupTime)
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
	
		
		public ControlResoInterventoRotMan Build(Guid id)
		{
			return Build(id, Guid.NewGuid());
		}

		public ControlResoInterventoRotMan Build(Guid id, Guid commitId)
        {
            return new ControlResoInterventoRotMan(id, commitId, _note, _workPeriod, _controlDate, _idUser, _idInterventoAppaltatore, _oggetti);
		 }


		
		public ControlResoInterventoRotMan Build(Guid id, long version)
		{
			return Build(id, Guid.NewGuid(), version);
		}

		public ControlResoInterventoRotMan Build(Guid id, Guid commitId, long version)
        {
            return new ControlResoInterventoRotMan(id, commitId, version, _note, _workPeriod, _controlDate, _idUser, _idInterventoAppaltatore, _oggetti);
		}

		
		public ControlResoInterventoRotMan Build(Guid id, Guid commitId, Guid userId)
        {
            return new ControlResoInterventoRotMan(id, commitId, userId, _note, _workPeriod, _controlDate, _idUser, _idInterventoAppaltatore, _oggetti);
		 }

		 public ControlResoInterventoRotMan Build(Guid id, long version, Guid userId)
		{
			return Build(id, Guid.NewGuid(), version, userId);
		}

		public ControlResoInterventoRotMan Build(Guid id, Guid commitId, long version, Guid userId)
        {
            return new ControlResoInterventoRotMan(id, commitId, version, userId, _note, _workPeriod, _controlDate, _idUser, _idInterventoAppaltatore, _oggetti);
		}

		public ControlResoInterventoRotMan Build(Guid id, DateTime wakeupTime)
		{
			return Build(id, Guid.NewGuid(), wakeupTime);
		}

		public ControlResoInterventoRotMan Build(Guid id, Guid commitId, DateTime wakeupTime)
        {
            return new ControlResoInterventoRotMan(id, commitId, wakeupTime, _note, _workPeriod, _controlDate, _idUser, _idInterventoAppaltatore, _oggetti);
		 }

		public ControlResoInterventoRotMan Build(Guid id, long version,DateTime wakeupTime)
		{
			return Build(id, Guid.NewGuid(), version,wakeupTime);
		}
		 

		public ControlResoInterventoRotMan Build(Guid id, Guid commitId, long version, DateTime wakeupTime)
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
	
		
		public ControlResoInterventoAmb Build(Guid id)
		{
			return Build(id, Guid.NewGuid());
		}

		public ControlResoInterventoAmb Build(Guid id, Guid commitId)
        {
            return new ControlResoInterventoAmb(id, commitId, _note, _workPeriod, _controlDate, _idUser, _idInterventoAppaltatore, _description, _quantity);
		 }


		
		public ControlResoInterventoAmb Build(Guid id, long version)
		{
			return Build(id, Guid.NewGuid(), version);
		}

		public ControlResoInterventoAmb Build(Guid id, Guid commitId, long version)
        {
            return new ControlResoInterventoAmb(id, commitId, version, _note, _workPeriod, _controlDate, _idUser, _idInterventoAppaltatore, _description, _quantity);
		}

		
		public ControlResoInterventoAmb Build(Guid id, Guid commitId, Guid userId)
        {
            return new ControlResoInterventoAmb(id, commitId, userId, _note, _workPeriod, _controlDate, _idUser, _idInterventoAppaltatore, _description, _quantity);
		 }

		 public ControlResoInterventoAmb Build(Guid id, long version, Guid userId)
		{
			return Build(id, Guid.NewGuid(), version, userId);
		}

		public ControlResoInterventoAmb Build(Guid id, Guid commitId, long version, Guid userId)
        {
            return new ControlResoInterventoAmb(id, commitId, version, userId, _note, _workPeriod, _controlDate, _idUser, _idInterventoAppaltatore, _description, _quantity);
		}

		public ControlResoInterventoAmb Build(Guid id, DateTime wakeupTime)
		{
			return Build(id, Guid.NewGuid(), wakeupTime);
		}

		public ControlResoInterventoAmb Build(Guid id, Guid commitId, DateTime wakeupTime)
        {
            return new ControlResoInterventoAmb(id, commitId, wakeupTime, _note, _workPeriod, _controlDate, _idUser, _idInterventoAppaltatore, _description, _quantity);
		 }

		public ControlResoInterventoAmb Build(Guid id, long version,DateTime wakeupTime)
		{
			return Build(id, Guid.NewGuid(), version,wakeupTime);
		}
		 

		public ControlResoInterventoAmb Build(Guid id, Guid commitId, long version, DateTime wakeupTime)
        {
            return new ControlResoInterventoAmb(id, commitId, version, wakeupTime, _note, _workPeriod, _controlDate, _idUser, _idInterventoAppaltatore, _description, _quantity);
		 }
        
	
	}
}

namespace Super.Controllo.Commands
{
	public static partial class BuildCmd 
	{
		  public static CloseInterventoBuilder CloseIntervento {get { return new CloseInterventoBuilder(); } }
	  		  public static ReopenInterventoBuilder ReopenIntervento {get { return new ReopenInterventoBuilder(); } }
	  		  public static ConsuntivareNonResoInterventoRotBuilder ConsuntivareNonResoInterventoRot {get { return new ConsuntivareNonResoInterventoRotBuilder(); } }
	  		  public static ConsuntivareNonResoInterventoRotManBuilder ConsuntivareNonResoInterventoRotMan {get { return new ConsuntivareNonResoInterventoRotManBuilder(); } }
	  		  public static ConsuntivareNonResoInterventoAmbBuilder ConsuntivareNonResoInterventoAmb {get { return new ConsuntivareNonResoInterventoAmbBuilder(); } }
	  		  public static ConsuntivareNonResoTrenitaliaInterventoRotBuilder ConsuntivareNonResoTrenitaliaInterventoRot {get { return new ConsuntivareNonResoTrenitaliaInterventoRotBuilder(); } }
	  		  public static ConsuntivareNonResoTrenitaliaInterventoRotManBuilder ConsuntivareNonResoTrenitaliaInterventoRotMan {get { return new ConsuntivareNonResoTrenitaliaInterventoRotManBuilder(); } }
	  		  public static ConsuntivareNonResoTrenitaliaInterventoAmbBuilder ConsuntivareNonResoTrenitaliaInterventoAmb {get { return new ConsuntivareNonResoTrenitaliaInterventoAmbBuilder(); } }
	  		  public static ConsuntivareResoInterventoRotBuilder ConsuntivareResoInterventoRot {get { return new ConsuntivareResoInterventoRotBuilder(); } }
	  		  public static ConsuntivareResoInterventoRotManBuilder ConsuntivareResoInterventoRotMan {get { return new ConsuntivareResoInterventoRotManBuilder(); } }
	  		  public static ConsuntivareResoInterventoAmbBuilder ConsuntivareResoInterventoAmb {get { return new ConsuntivareResoInterventoAmbBuilder(); } }
	  		  public static ControlNonResoInterventoBuilder ControlNonResoIntervento {get { return new ControlNonResoInterventoBuilder(); } }
	  		  public static ControlResoInterventoRotBuilder ControlResoInterventoRot {get { return new ControlResoInterventoRotBuilder(); } }
	  		  public static ControlResoInterventoRotManBuilder ControlResoInterventoRotMan {get { return new ControlResoInterventoRotManBuilder(); } }
	  		  public static ControlResoInterventoAmbBuilder ControlResoInterventoAmb {get { return new ControlResoInterventoAmbBuilder(); } }
	  	}
}
