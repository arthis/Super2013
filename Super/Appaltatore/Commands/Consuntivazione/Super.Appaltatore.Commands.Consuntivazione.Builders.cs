



using System;
using CommonDomain;
using System.Diagnostics.Contracts;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using Super.Appaltatore.Commands.Consuntivazione;
using Super.Appaltatore.Commands.Consuntivazione.Builders;

namespace Super.Appaltatore.Commands.Consuntivazione.Builders
{


	public class ConsuntivareAutomaticamenteNonResoInterventoRotBuilder : ICommandBuilder<ConsuntivareAutomaticamenteNonResoInterventoRot>
	{
	 
		private DateTime  _dataConsuntivazione ;
		public ConsuntivareAutomaticamenteNonResoInterventoRotBuilder ForDataConsuntivazione(DateTime dataConsuntivazione) 
		{
			_dataConsuntivazione = dataConsuntivazione;
			return this;
		}
	
		
		public ConsuntivareAutomaticamenteNonResoInterventoRot Build(Guid id)
		{
			return Build(id, Guid.NewGuid());
		}

		public ConsuntivareAutomaticamenteNonResoInterventoRot Build(Guid id, Guid commitId)
        {
            return new ConsuntivareAutomaticamenteNonResoInterventoRot(id, commitId, _dataConsuntivazione);
		 }


		
		public ConsuntivareAutomaticamenteNonResoInterventoRot Build(Guid id, long version)
		{
			return Build(id, Guid.NewGuid(), version);
		}

		public ConsuntivareAutomaticamenteNonResoInterventoRot Build(Guid id, Guid commitId, long version)
        {
            return new ConsuntivareAutomaticamenteNonResoInterventoRot(id, commitId, version, _dataConsuntivazione);
		 }

		public ConsuntivareAutomaticamenteNonResoInterventoRot Build(Guid id, DateTime wakeupTime)
		{
			return Build(id, Guid.NewGuid(), wakeupTime);
		}

		public ConsuntivareAutomaticamenteNonResoInterventoRot Build(Guid id, Guid commitId, DateTime wakeupTime)
        {
            return new ConsuntivareAutomaticamenteNonResoInterventoRot(id, commitId, wakeupTime, _dataConsuntivazione);
		 }




		public ConsuntivareAutomaticamenteNonResoInterventoRot Build(Guid id, long version,DateTime wakeupTime)
		{
			return Build(id, Guid.NewGuid(), version,wakeupTime);
		}
		 

		public ConsuntivareAutomaticamenteNonResoInterventoRot Build(Guid id, Guid commitId, long version, DateTime wakeupTime)
        {
            return new ConsuntivareAutomaticamenteNonResoInterventoRot(id, commitId, version, wakeupTime, _dataConsuntivazione);
		 }
        
	
	}

	public class ConsuntivareAutomaticamenteNonResoInterventoRotManBuilder : ICommandBuilder<ConsuntivareAutomaticamenteNonResoInterventoRotMan>
	{
	 
		private DateTime  _dataConsuntivazione ;
		public ConsuntivareAutomaticamenteNonResoInterventoRotManBuilder ForDataConsuntivazione(DateTime dataConsuntivazione) 
		{
			_dataConsuntivazione = dataConsuntivazione;
			return this;
		}
	
		
		public ConsuntivareAutomaticamenteNonResoInterventoRotMan Build(Guid id)
		{
			return Build(id, Guid.NewGuid());
		}

		public ConsuntivareAutomaticamenteNonResoInterventoRotMan Build(Guid id, Guid commitId)
        {
            return new ConsuntivareAutomaticamenteNonResoInterventoRotMan(id, commitId, _dataConsuntivazione);
		 }


		
		public ConsuntivareAutomaticamenteNonResoInterventoRotMan Build(Guid id, long version)
		{
			return Build(id, Guid.NewGuid(), version);
		}

		public ConsuntivareAutomaticamenteNonResoInterventoRotMan Build(Guid id, Guid commitId, long version)
        {
            return new ConsuntivareAutomaticamenteNonResoInterventoRotMan(id, commitId, version, _dataConsuntivazione);
		 }

		public ConsuntivareAutomaticamenteNonResoInterventoRotMan Build(Guid id, DateTime wakeupTime)
		{
			return Build(id, Guid.NewGuid(), wakeupTime);
		}

		public ConsuntivareAutomaticamenteNonResoInterventoRotMan Build(Guid id, Guid commitId, DateTime wakeupTime)
        {
            return new ConsuntivareAutomaticamenteNonResoInterventoRotMan(id, commitId, wakeupTime, _dataConsuntivazione);
		 }




		public ConsuntivareAutomaticamenteNonResoInterventoRotMan Build(Guid id, long version,DateTime wakeupTime)
		{
			return Build(id, Guid.NewGuid(), version,wakeupTime);
		}
		 

		public ConsuntivareAutomaticamenteNonResoInterventoRotMan Build(Guid id, Guid commitId, long version, DateTime wakeupTime)
        {
            return new ConsuntivareAutomaticamenteNonResoInterventoRotMan(id, commitId, version, wakeupTime, _dataConsuntivazione);
		 }
        
	
	}

	public class ConsuntivareAutomaticamenteNonResoInterventoAmbBuilder : ICommandBuilder<ConsuntivareAutomaticamenteNonResoInterventoAmb>
	{
	 
		private DateTime  _dataConsuntivazione ;
		public ConsuntivareAutomaticamenteNonResoInterventoAmbBuilder ForDataConsuntivazione(DateTime dataConsuntivazione) 
		{
			_dataConsuntivazione = dataConsuntivazione;
			return this;
		}
	
		
		public ConsuntivareAutomaticamenteNonResoInterventoAmb Build(Guid id)
		{
			return Build(id, Guid.NewGuid());
		}

		public ConsuntivareAutomaticamenteNonResoInterventoAmb Build(Guid id, Guid commitId)
        {
            return new ConsuntivareAutomaticamenteNonResoInterventoAmb(id, commitId, _dataConsuntivazione);
		 }


		
		public ConsuntivareAutomaticamenteNonResoInterventoAmb Build(Guid id, long version)
		{
			return Build(id, Guid.NewGuid(), version);
		}

		public ConsuntivareAutomaticamenteNonResoInterventoAmb Build(Guid id, Guid commitId, long version)
        {
            return new ConsuntivareAutomaticamenteNonResoInterventoAmb(id, commitId, version, _dataConsuntivazione);
		 }

		public ConsuntivareAutomaticamenteNonResoInterventoAmb Build(Guid id, DateTime wakeupTime)
		{
			return Build(id, Guid.NewGuid(), wakeupTime);
		}

		public ConsuntivareAutomaticamenteNonResoInterventoAmb Build(Guid id, Guid commitId, DateTime wakeupTime)
        {
            return new ConsuntivareAutomaticamenteNonResoInterventoAmb(id, commitId, wakeupTime, _dataConsuntivazione);
		 }




		public ConsuntivareAutomaticamenteNonResoInterventoAmb Build(Guid id, long version,DateTime wakeupTime)
		{
			return Build(id, Guid.NewGuid(), version,wakeupTime);
		}
		 

		public ConsuntivareAutomaticamenteNonResoInterventoAmb Build(Guid id, Guid commitId, long version, DateTime wakeupTime)
        {
            return new ConsuntivareAutomaticamenteNonResoInterventoAmb(id, commitId, version, wakeupTime, _dataConsuntivazione);
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
	
		public ConsuntivareNonResoInterventoRotBuilder ForCausaleAppaltatore(Guid idCausaleAppaltatore) 
		{
			_idCausaleAppaltatore = idCausaleAppaltatore;
			return this;
		}
	
		public ConsuntivareNonResoInterventoRotBuilder ForDataConsuntivazione(DateTime dataConsuntivazione) 
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
	
		public ConsuntivareNonResoInterventoRotManBuilder ForCausaleAppaltatore(Guid idCausaleAppaltatore) 
		{
			_idCausaleAppaltatore = idCausaleAppaltatore;
			return this;
		}
	
		public ConsuntivareNonResoInterventoRotManBuilder ForDataConsuntivazione(DateTime dataConsuntivazione) 
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
	
		public ConsuntivareNonResoInterventoAmbBuilder ForCausaleAppaltatore(Guid idCausaleAppaltatore) 
		{
			_idCausaleAppaltatore = idCausaleAppaltatore;
			return this;
		}
	
		public ConsuntivareNonResoInterventoAmbBuilder ForDataConsuntivazione(DateTime dataConsuntivazione) 
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
	
		public ConsuntivareNonResoTrenitaliaInterventoRotBuilder ForCausaleTrenitalia(Guid idCausaleTrenitalia) 
		{
			_idCausaleTrenitalia = idCausaleTrenitalia;
			return this;
		}
	
		public ConsuntivareNonResoTrenitaliaInterventoRotBuilder ForDataConsuntivazione(DateTime dataConsuntivazione) 
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
	
		public ConsuntivareNonResoTrenitaliaInterventoRotManBuilder ForCausaleTrenitalia(Guid idCausaleTrenitalia) 
		{
			_idCausaleTrenitalia = idCausaleTrenitalia;
			return this;
		}
	
		public ConsuntivareNonResoTrenitaliaInterventoRotManBuilder ForDataConsuntivazione(DateTime dataConsuntivazione) 
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
	
		public ConsuntivareNonResoTrenitaliaInterventoAmbBuilder ForCausaleTrenitalia(Guid idCausaleTrenitalia) 
		{
			_idCausaleTrenitalia = idCausaleTrenitalia;
			return this;
		}
	
		public ConsuntivareNonResoTrenitaliaInterventoAmbBuilder ForDataConsuntivazione(DateTime dataConsuntivazione) 
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
	
		public ConsuntivareResoInterventoRotBuilder ForDataConsuntivazione(DateTime dataConsuntivazione) 
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
	
		public ConsuntivareResoInterventoRotManBuilder ForDataConsuntivazione(DateTime dataConsuntivazione) 
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
	
		public ConsuntivareResoInterventoAmbBuilder ForDataConsuntivazione(DateTime dataConsuntivazione) 
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
}

namespace Super.Appaltatore.Commands
{
	public static partial class BuildCmd 
	{
		  public static ConsuntivareAutomaticamenteNonResoInterventoRotBuilder ConsuntivareAutomaticamenteNonResoInterventoRot {get { return new ConsuntivareAutomaticamenteNonResoInterventoRotBuilder(); } }
	  		  public static ConsuntivareAutomaticamenteNonResoInterventoRotManBuilder ConsuntivareAutomaticamenteNonResoInterventoRotMan {get { return new ConsuntivareAutomaticamenteNonResoInterventoRotManBuilder(); } }
	  		  public static ConsuntivareAutomaticamenteNonResoInterventoAmbBuilder ConsuntivareAutomaticamenteNonResoInterventoAmb {get { return new ConsuntivareAutomaticamenteNonResoInterventoAmbBuilder(); } }
	  		  public static ConsuntivareNonResoInterventoRotBuilder ConsuntivareNonResoInterventoRot {get { return new ConsuntivareNonResoInterventoRotBuilder(); } }
	  		  public static ConsuntivareNonResoInterventoRotManBuilder ConsuntivareNonResoInterventoRotMan {get { return new ConsuntivareNonResoInterventoRotManBuilder(); } }
	  		  public static ConsuntivareNonResoInterventoAmbBuilder ConsuntivareNonResoInterventoAmb {get { return new ConsuntivareNonResoInterventoAmbBuilder(); } }
	  		  public static ConsuntivareNonResoTrenitaliaInterventoRotBuilder ConsuntivareNonResoTrenitaliaInterventoRot {get { return new ConsuntivareNonResoTrenitaliaInterventoRotBuilder(); } }
	  		  public static ConsuntivareNonResoTrenitaliaInterventoRotManBuilder ConsuntivareNonResoTrenitaliaInterventoRotMan {get { return new ConsuntivareNonResoTrenitaliaInterventoRotManBuilder(); } }
	  		  public static ConsuntivareNonResoTrenitaliaInterventoAmbBuilder ConsuntivareNonResoTrenitaliaInterventoAmb {get { return new ConsuntivareNonResoTrenitaliaInterventoAmbBuilder(); } }
	  		  public static ConsuntivareResoInterventoRotBuilder ConsuntivareResoInterventoRot {get { return new ConsuntivareResoInterventoRotBuilder(); } }
	  		  public static ConsuntivareResoInterventoRotManBuilder ConsuntivareResoInterventoRotMan {get { return new ConsuntivareResoInterventoRotManBuilder(); } }
	  		  public static ConsuntivareResoInterventoAmbBuilder ConsuntivareResoInterventoAmb {get { return new ConsuntivareResoInterventoAmbBuilder(); } }
	  	}
}
