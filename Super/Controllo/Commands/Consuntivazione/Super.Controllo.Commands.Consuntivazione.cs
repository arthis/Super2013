


using System;
using System.Linq;
using System.Diagnostics.Contracts;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using CommonDomain;
using CommonDomain.Core;


namespace Super.Controllo.Commands.Consuntivazione
{


	public class CloseIntervento :  CommandBase  
	{
	 
		public Guid IdUser { get; set;} 
		public DateTime ClosingDate { get; set;}

		public CloseIntervento ()
		{
			//for serialisation
		}


		public CloseIntervento(Guid id, Guid commitId,Guid idUser,DateTime closingDate)
		   : base(id,commitId)
		{
			Contract.Requires(idUser != Guid.Empty);

	Contract.Requires(closingDate > DateTime.MinValue);

			IdUser = idUser ;
			ClosingDate = closingDate ;
		}
	     

		public CloseIntervento(Guid id, Guid commitId, long version,Guid idUser,DateTime closingDate)
		   : base(id,commitId,version)
		{
			Contract.Requires(idUser != Guid.Empty);

	Contract.Requires(closingDate > DateTime.MinValue);

			IdUser = idUser ;
			ClosingDate = closingDate ;
		}

		
		public CloseIntervento(Guid id, Guid commitId, DateTime wakeupTime,Guid idUser,DateTime closingDate)
		   : base(id,commitId,wakeupTime)
		{
			Contract.Requires(idUser != Guid.Empty);

	Contract.Requires(closingDate > DateTime.MinValue);

			IdUser = idUser ;
			ClosingDate = closingDate ;
		}

		public CloseIntervento(Guid id, Guid commitId, Guid userId,Guid idUser,DateTime closingDate)
		   : base(id,commitId,userId)
		{
			Contract.Requires(idUser != Guid.Empty);

	Contract.Requires(closingDate > DateTime.MinValue);

			IdUser = idUser ;
			ClosingDate = closingDate ;
		}


		public CloseIntervento(Guid id, Guid commitId, long version, DateTime wakeupTime,Guid idUser,DateTime closingDate)
		   : base(id,commitId,version,wakeupTime)
		{
			Contract.Requires(idUser != Guid.Empty);

	Contract.Requires(closingDate > DateTime.MinValue);

			IdUser = idUser ;
			ClosingDate = closingDate ;
		}

		
		public CloseIntervento(Guid id, Guid commitId, long version, Guid userId,Guid idUser,DateTime closingDate)
		   : base(id,commitId,version,userId)
		{
			Contract.Requires(idUser != Guid.Empty);

	Contract.Requires(closingDate > DateTime.MinValue);

			IdUser = idUser ;
			ClosingDate = closingDate ;
		}
			public override string ToDescription()
		{
			return string.Format("si chiude il intervento {0}.", Id);
		}
		
		public bool Equals(CloseIntervento other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other)  	 && Equals(other.IdUser, IdUser)  	 && Equals(other.ClosingDate, ClosingDate) ; 
		}

		public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as CloseIntervento);
        }

		public override int GetHashCode()
        {
            unchecked
            {
				int result = base.GetHashCode();
				result = (result*397) ^ IdUser.GetHashCode();
				result = (result*397) ^ ClosingDate.GetHashCode();
				return result;
            }
        }
	}

	public class ReopenIntervento :  CommandBase  
	{
	 
		public Guid IdUser { get; set;} 
		public DateTime ReopeningDate { get; set;}

		public ReopenIntervento ()
		{
			//for serialisation
		}


		public ReopenIntervento(Guid id, Guid commitId,Guid idUser,DateTime reopeningDate)
		   : base(id,commitId)
		{
			Contract.Requires(idUser != Guid.Empty);

	Contract.Requires(reopeningDate > DateTime.MinValue);

			IdUser = idUser ;
			ReopeningDate = reopeningDate ;
		}
	     

		public ReopenIntervento(Guid id, Guid commitId, long version,Guid idUser,DateTime reopeningDate)
		   : base(id,commitId,version)
		{
			Contract.Requires(idUser != Guid.Empty);

	Contract.Requires(reopeningDate > DateTime.MinValue);

			IdUser = idUser ;
			ReopeningDate = reopeningDate ;
		}

		
		public ReopenIntervento(Guid id, Guid commitId, DateTime wakeupTime,Guid idUser,DateTime reopeningDate)
		   : base(id,commitId,wakeupTime)
		{
			Contract.Requires(idUser != Guid.Empty);

	Contract.Requires(reopeningDate > DateTime.MinValue);

			IdUser = idUser ;
			ReopeningDate = reopeningDate ;
		}

		public ReopenIntervento(Guid id, Guid commitId, Guid userId,Guid idUser,DateTime reopeningDate)
		   : base(id,commitId,userId)
		{
			Contract.Requires(idUser != Guid.Empty);

	Contract.Requires(reopeningDate > DateTime.MinValue);

			IdUser = idUser ;
			ReopeningDate = reopeningDate ;
		}


		public ReopenIntervento(Guid id, Guid commitId, long version, DateTime wakeupTime,Guid idUser,DateTime reopeningDate)
		   : base(id,commitId,version,wakeupTime)
		{
			Contract.Requires(idUser != Guid.Empty);

	Contract.Requires(reopeningDate > DateTime.MinValue);

			IdUser = idUser ;
			ReopeningDate = reopeningDate ;
		}

		
		public ReopenIntervento(Guid id, Guid commitId, long version, Guid userId,Guid idUser,DateTime reopeningDate)
		   : base(id,commitId,version,userId)
		{
			Contract.Requires(idUser != Guid.Empty);

	Contract.Requires(reopeningDate > DateTime.MinValue);

			IdUser = idUser ;
			ReopeningDate = reopeningDate ;
		}
			public override string ToDescription()
		{
			return string.Format("si apri di nuovo il intervento {0}.", Id);
		}
		
		public bool Equals(ReopenIntervento other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other)  	 && Equals(other.IdUser, IdUser)  	 && Equals(other.ReopeningDate, ReopeningDate) ; 
		}

		public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as ReopenIntervento);
        }

		public override int GetHashCode()
        {
            unchecked
            {
				int result = base.GetHashCode();
				result = (result*397) ^ IdUser.GetHashCode();
				result = (result*397) ^ ReopeningDate.GetHashCode();
				return result;
            }
        }
	}

	public class ConsuntivareNonResoInterventoRot :  CommandBase  
	{
	 
		public string Note { get; set;} 
		public Guid IdCausaleAppaltatore { get; set;} 
		public DateTime DataConsuntivazione { get; set;} 
		public string IdInterventoAppaltatore { get; set;}

		public ConsuntivareNonResoInterventoRot ()
		{
			//for serialisation
		}


		public ConsuntivareNonResoInterventoRot(Guid id, Guid commitId,string note,Guid idCausaleAppaltatore,DateTime dataConsuntivazione,string idInterventoAppaltatore)
		   : base(id,commitId)
		{
			Contract.Requires(idCausaleAppaltatore != Guid.Empty);

	Contract.Requires(dataConsuntivazione > DateTime.MinValue);

	Contract.Requires(!string.IsNullOrEmpty(idInterventoAppaltatore));

			Note = note ;
			IdCausaleAppaltatore = idCausaleAppaltatore ;
			DataConsuntivazione = dataConsuntivazione ;
			IdInterventoAppaltatore = idInterventoAppaltatore ;
		}
	     

		public ConsuntivareNonResoInterventoRot(Guid id, Guid commitId, long version,string note,Guid idCausaleAppaltatore,DateTime dataConsuntivazione,string idInterventoAppaltatore)
		   : base(id,commitId,version)
		{
			Contract.Requires(idCausaleAppaltatore != Guid.Empty);

	Contract.Requires(dataConsuntivazione > DateTime.MinValue);

	Contract.Requires(!string.IsNullOrEmpty(idInterventoAppaltatore));

			Note = note ;
			IdCausaleAppaltatore = idCausaleAppaltatore ;
			DataConsuntivazione = dataConsuntivazione ;
			IdInterventoAppaltatore = idInterventoAppaltatore ;
		}

		
		public ConsuntivareNonResoInterventoRot(Guid id, Guid commitId, DateTime wakeupTime,string note,Guid idCausaleAppaltatore,DateTime dataConsuntivazione,string idInterventoAppaltatore)
		   : base(id,commitId,wakeupTime)
		{
			Contract.Requires(idCausaleAppaltatore != Guid.Empty);

	Contract.Requires(dataConsuntivazione > DateTime.MinValue);

	Contract.Requires(!string.IsNullOrEmpty(idInterventoAppaltatore));

			Note = note ;
			IdCausaleAppaltatore = idCausaleAppaltatore ;
			DataConsuntivazione = dataConsuntivazione ;
			IdInterventoAppaltatore = idInterventoAppaltatore ;
		}

		public ConsuntivareNonResoInterventoRot(Guid id, Guid commitId, Guid userId,string note,Guid idCausaleAppaltatore,DateTime dataConsuntivazione,string idInterventoAppaltatore)
		   : base(id,commitId,userId)
		{
			Contract.Requires(idCausaleAppaltatore != Guid.Empty);

	Contract.Requires(dataConsuntivazione > DateTime.MinValue);

	Contract.Requires(!string.IsNullOrEmpty(idInterventoAppaltatore));

			Note = note ;
			IdCausaleAppaltatore = idCausaleAppaltatore ;
			DataConsuntivazione = dataConsuntivazione ;
			IdInterventoAppaltatore = idInterventoAppaltatore ;
		}


		public ConsuntivareNonResoInterventoRot(Guid id, Guid commitId, long version, DateTime wakeupTime,string note,Guid idCausaleAppaltatore,DateTime dataConsuntivazione,string idInterventoAppaltatore)
		   : base(id,commitId,version,wakeupTime)
		{
			Contract.Requires(idCausaleAppaltatore != Guid.Empty);

	Contract.Requires(dataConsuntivazione > DateTime.MinValue);

	Contract.Requires(!string.IsNullOrEmpty(idInterventoAppaltatore));

			Note = note ;
			IdCausaleAppaltatore = idCausaleAppaltatore ;
			DataConsuntivazione = dataConsuntivazione ;
			IdInterventoAppaltatore = idInterventoAppaltatore ;
		}

		
		public ConsuntivareNonResoInterventoRot(Guid id, Guid commitId, long version, Guid userId,string note,Guid idCausaleAppaltatore,DateTime dataConsuntivazione,string idInterventoAppaltatore)
		   : base(id,commitId,version,userId)
		{
			Contract.Requires(idCausaleAppaltatore != Guid.Empty);

	Contract.Requires(dataConsuntivazione > DateTime.MinValue);

	Contract.Requires(!string.IsNullOrEmpty(idInterventoAppaltatore));

			Note = note ;
			IdCausaleAppaltatore = idCausaleAppaltatore ;
			DataConsuntivazione = dataConsuntivazione ;
			IdInterventoAppaltatore = idInterventoAppaltatore ;
		}
			public override string ToDescription()
		{
			return string.Format("Consuntivare non reso appaltatore il intervento rotabile", Id);
		}
		
		public bool Equals(ConsuntivareNonResoInterventoRot other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other)  	 && Equals(other.Note, Note)  	 && Equals(other.IdCausaleAppaltatore, IdCausaleAppaltatore)  	 && Equals(other.DataConsuntivazione, DataConsuntivazione)  	 && Equals(other.IdInterventoAppaltatore, IdInterventoAppaltatore) ; 
		}

		public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as ConsuntivareNonResoInterventoRot);
        }

		public override int GetHashCode()
        {
            unchecked
            {
				int result = base.GetHashCode();
				
				result = (result*397) ^ IdCausaleAppaltatore.GetHashCode();
				result = (result*397) ^ DataConsuntivazione.GetHashCode();
				result = (result*397) ^ (IdInterventoAppaltatore != null ? IdInterventoAppaltatore.GetHashCode() : 0);
				return result;
            }
        }
	}

	public class ConsuntivareNonResoInterventoRotMan :  CommandBase  
	{
	 
		public string Note { get; set;} 
		public Guid IdCausaleAppaltatore { get; set;} 
		public DateTime DataConsuntivazione { get; set;} 
		public string IdInterventoAppaltatore { get; set;}

		public ConsuntivareNonResoInterventoRotMan ()
		{
			//for serialisation
		}


		public ConsuntivareNonResoInterventoRotMan(Guid id, Guid commitId,string note,Guid idCausaleAppaltatore,DateTime dataConsuntivazione,string idInterventoAppaltatore)
		   : base(id,commitId)
		{
			Contract.Requires(idCausaleAppaltatore != Guid.Empty);

	Contract.Requires(dataConsuntivazione > DateTime.MinValue);

	Contract.Requires(!string.IsNullOrEmpty(idInterventoAppaltatore));

			Note = note ;
			IdCausaleAppaltatore = idCausaleAppaltatore ;
			DataConsuntivazione = dataConsuntivazione ;
			IdInterventoAppaltatore = idInterventoAppaltatore ;
		}
	     

		public ConsuntivareNonResoInterventoRotMan(Guid id, Guid commitId, long version,string note,Guid idCausaleAppaltatore,DateTime dataConsuntivazione,string idInterventoAppaltatore)
		   : base(id,commitId,version)
		{
			Contract.Requires(idCausaleAppaltatore != Guid.Empty);

	Contract.Requires(dataConsuntivazione > DateTime.MinValue);

	Contract.Requires(!string.IsNullOrEmpty(idInterventoAppaltatore));

			Note = note ;
			IdCausaleAppaltatore = idCausaleAppaltatore ;
			DataConsuntivazione = dataConsuntivazione ;
			IdInterventoAppaltatore = idInterventoAppaltatore ;
		}

		
		public ConsuntivareNonResoInterventoRotMan(Guid id, Guid commitId, DateTime wakeupTime,string note,Guid idCausaleAppaltatore,DateTime dataConsuntivazione,string idInterventoAppaltatore)
		   : base(id,commitId,wakeupTime)
		{
			Contract.Requires(idCausaleAppaltatore != Guid.Empty);

	Contract.Requires(dataConsuntivazione > DateTime.MinValue);

	Contract.Requires(!string.IsNullOrEmpty(idInterventoAppaltatore));

			Note = note ;
			IdCausaleAppaltatore = idCausaleAppaltatore ;
			DataConsuntivazione = dataConsuntivazione ;
			IdInterventoAppaltatore = idInterventoAppaltatore ;
		}

		public ConsuntivareNonResoInterventoRotMan(Guid id, Guid commitId, Guid userId,string note,Guid idCausaleAppaltatore,DateTime dataConsuntivazione,string idInterventoAppaltatore)
		   : base(id,commitId,userId)
		{
			Contract.Requires(idCausaleAppaltatore != Guid.Empty);

	Contract.Requires(dataConsuntivazione > DateTime.MinValue);

	Contract.Requires(!string.IsNullOrEmpty(idInterventoAppaltatore));

			Note = note ;
			IdCausaleAppaltatore = idCausaleAppaltatore ;
			DataConsuntivazione = dataConsuntivazione ;
			IdInterventoAppaltatore = idInterventoAppaltatore ;
		}


		public ConsuntivareNonResoInterventoRotMan(Guid id, Guid commitId, long version, DateTime wakeupTime,string note,Guid idCausaleAppaltatore,DateTime dataConsuntivazione,string idInterventoAppaltatore)
		   : base(id,commitId,version,wakeupTime)
		{
			Contract.Requires(idCausaleAppaltatore != Guid.Empty);

	Contract.Requires(dataConsuntivazione > DateTime.MinValue);

	Contract.Requires(!string.IsNullOrEmpty(idInterventoAppaltatore));

			Note = note ;
			IdCausaleAppaltatore = idCausaleAppaltatore ;
			DataConsuntivazione = dataConsuntivazione ;
			IdInterventoAppaltatore = idInterventoAppaltatore ;
		}

		
		public ConsuntivareNonResoInterventoRotMan(Guid id, Guid commitId, long version, Guid userId,string note,Guid idCausaleAppaltatore,DateTime dataConsuntivazione,string idInterventoAppaltatore)
		   : base(id,commitId,version,userId)
		{
			Contract.Requires(idCausaleAppaltatore != Guid.Empty);

	Contract.Requires(dataConsuntivazione > DateTime.MinValue);

	Contract.Requires(!string.IsNullOrEmpty(idInterventoAppaltatore));

			Note = note ;
			IdCausaleAppaltatore = idCausaleAppaltatore ;
			DataConsuntivazione = dataConsuntivazione ;
			IdInterventoAppaltatore = idInterventoAppaltatore ;
		}
			public override string ToDescription()
		{
			return string.Format("Consuntivare non reso appaltatore il intervento rotabile in Manutenzione", Id);
		}
		
		public bool Equals(ConsuntivareNonResoInterventoRotMan other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other)  	 && Equals(other.Note, Note)  	 && Equals(other.IdCausaleAppaltatore, IdCausaleAppaltatore)  	 && Equals(other.DataConsuntivazione, DataConsuntivazione)  	 && Equals(other.IdInterventoAppaltatore, IdInterventoAppaltatore) ; 
		}

		public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as ConsuntivareNonResoInterventoRotMan);
        }

		public override int GetHashCode()
        {
            unchecked
            {
				int result = base.GetHashCode();
				
				result = (result*397) ^ IdCausaleAppaltatore.GetHashCode();
				result = (result*397) ^ DataConsuntivazione.GetHashCode();
				result = (result*397) ^ (IdInterventoAppaltatore != null ? IdInterventoAppaltatore.GetHashCode() : 0);
				return result;
            }
        }
	}

	public class ConsuntivareNonResoInterventoAmb :  CommandBase  
	{
	 
		public string Note { get; set;} 
		public Guid IdCausaleAppaltatore { get; set;} 
		public DateTime DataConsuntivazione { get; set;} 
		public string IdInterventoAppaltatore { get; set;}

		public ConsuntivareNonResoInterventoAmb ()
		{
			//for serialisation
		}


		public ConsuntivareNonResoInterventoAmb(Guid id, Guid commitId,string note,Guid idCausaleAppaltatore,DateTime dataConsuntivazione,string idInterventoAppaltatore)
		   : base(id,commitId)
		{
			Contract.Requires(idCausaleAppaltatore != Guid.Empty);

	Contract.Requires(dataConsuntivazione > DateTime.MinValue);

	Contract.Requires(!string.IsNullOrEmpty(idInterventoAppaltatore));

			Note = note ;
			IdCausaleAppaltatore = idCausaleAppaltatore ;
			DataConsuntivazione = dataConsuntivazione ;
			IdInterventoAppaltatore = idInterventoAppaltatore ;
		}
	     

		public ConsuntivareNonResoInterventoAmb(Guid id, Guid commitId, long version,string note,Guid idCausaleAppaltatore,DateTime dataConsuntivazione,string idInterventoAppaltatore)
		   : base(id,commitId,version)
		{
			Contract.Requires(idCausaleAppaltatore != Guid.Empty);

	Contract.Requires(dataConsuntivazione > DateTime.MinValue);

	Contract.Requires(!string.IsNullOrEmpty(idInterventoAppaltatore));

			Note = note ;
			IdCausaleAppaltatore = idCausaleAppaltatore ;
			DataConsuntivazione = dataConsuntivazione ;
			IdInterventoAppaltatore = idInterventoAppaltatore ;
		}

		
		public ConsuntivareNonResoInterventoAmb(Guid id, Guid commitId, DateTime wakeupTime,string note,Guid idCausaleAppaltatore,DateTime dataConsuntivazione,string idInterventoAppaltatore)
		   : base(id,commitId,wakeupTime)
		{
			Contract.Requires(idCausaleAppaltatore != Guid.Empty);

	Contract.Requires(dataConsuntivazione > DateTime.MinValue);

	Contract.Requires(!string.IsNullOrEmpty(idInterventoAppaltatore));

			Note = note ;
			IdCausaleAppaltatore = idCausaleAppaltatore ;
			DataConsuntivazione = dataConsuntivazione ;
			IdInterventoAppaltatore = idInterventoAppaltatore ;
		}

		public ConsuntivareNonResoInterventoAmb(Guid id, Guid commitId, Guid userId,string note,Guid idCausaleAppaltatore,DateTime dataConsuntivazione,string idInterventoAppaltatore)
		   : base(id,commitId,userId)
		{
			Contract.Requires(idCausaleAppaltatore != Guid.Empty);

	Contract.Requires(dataConsuntivazione > DateTime.MinValue);

	Contract.Requires(!string.IsNullOrEmpty(idInterventoAppaltatore));

			Note = note ;
			IdCausaleAppaltatore = idCausaleAppaltatore ;
			DataConsuntivazione = dataConsuntivazione ;
			IdInterventoAppaltatore = idInterventoAppaltatore ;
		}


		public ConsuntivareNonResoInterventoAmb(Guid id, Guid commitId, long version, DateTime wakeupTime,string note,Guid idCausaleAppaltatore,DateTime dataConsuntivazione,string idInterventoAppaltatore)
		   : base(id,commitId,version,wakeupTime)
		{
			Contract.Requires(idCausaleAppaltatore != Guid.Empty);

	Contract.Requires(dataConsuntivazione > DateTime.MinValue);

	Contract.Requires(!string.IsNullOrEmpty(idInterventoAppaltatore));

			Note = note ;
			IdCausaleAppaltatore = idCausaleAppaltatore ;
			DataConsuntivazione = dataConsuntivazione ;
			IdInterventoAppaltatore = idInterventoAppaltatore ;
		}

		
		public ConsuntivareNonResoInterventoAmb(Guid id, Guid commitId, long version, Guid userId,string note,Guid idCausaleAppaltatore,DateTime dataConsuntivazione,string idInterventoAppaltatore)
		   : base(id,commitId,version,userId)
		{
			Contract.Requires(idCausaleAppaltatore != Guid.Empty);

	Contract.Requires(dataConsuntivazione > DateTime.MinValue);

	Contract.Requires(!string.IsNullOrEmpty(idInterventoAppaltatore));

			Note = note ;
			IdCausaleAppaltatore = idCausaleAppaltatore ;
			DataConsuntivazione = dataConsuntivazione ;
			IdInterventoAppaltatore = idInterventoAppaltatore ;
		}
			public override string ToDescription()
		{
			return string.Format("Consuntivare non reso appaltatore il intervento ambiente", Id);
		}
		
		public bool Equals(ConsuntivareNonResoInterventoAmb other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other)  	 && Equals(other.Note, Note)  	 && Equals(other.IdCausaleAppaltatore, IdCausaleAppaltatore)  	 && Equals(other.DataConsuntivazione, DataConsuntivazione)  	 && Equals(other.IdInterventoAppaltatore, IdInterventoAppaltatore) ; 
		}

		public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as ConsuntivareNonResoInterventoAmb);
        }

		public override int GetHashCode()
        {
            unchecked
            {
				int result = base.GetHashCode();
				
				result = (result*397) ^ IdCausaleAppaltatore.GetHashCode();
				result = (result*397) ^ DataConsuntivazione.GetHashCode();
				result = (result*397) ^ (IdInterventoAppaltatore != null ? IdInterventoAppaltatore.GetHashCode() : 0);
				return result;
            }
        }
	}

	public class ConsuntivareNonResoTrenitaliaInterventoRot :  CommandBase  
	{
	 
		public string Note { get; set;} 
		public Guid IdCausaleTrenitalia { get; set;} 
		public DateTime DataConsuntivazione { get; set;} 
		public string IdInterventoAppaltatore { get; set;}

		public ConsuntivareNonResoTrenitaliaInterventoRot ()
		{
			//for serialisation
		}


		public ConsuntivareNonResoTrenitaliaInterventoRot(Guid id, Guid commitId,string note,Guid idCausaleTrenitalia,DateTime dataConsuntivazione,string idInterventoAppaltatore)
		   : base(id,commitId)
		{
			Contract.Requires(idCausaleTrenitalia != Guid.Empty);

	Contract.Requires(dataConsuntivazione > DateTime.MinValue);

	Contract.Requires(!string.IsNullOrEmpty(idInterventoAppaltatore));

			Note = note ;
			IdCausaleTrenitalia = idCausaleTrenitalia ;
			DataConsuntivazione = dataConsuntivazione ;
			IdInterventoAppaltatore = idInterventoAppaltatore ;
		}
	     

		public ConsuntivareNonResoTrenitaliaInterventoRot(Guid id, Guid commitId, long version,string note,Guid idCausaleTrenitalia,DateTime dataConsuntivazione,string idInterventoAppaltatore)
		   : base(id,commitId,version)
		{
			Contract.Requires(idCausaleTrenitalia != Guid.Empty);

	Contract.Requires(dataConsuntivazione > DateTime.MinValue);

	Contract.Requires(!string.IsNullOrEmpty(idInterventoAppaltatore));

			Note = note ;
			IdCausaleTrenitalia = idCausaleTrenitalia ;
			DataConsuntivazione = dataConsuntivazione ;
			IdInterventoAppaltatore = idInterventoAppaltatore ;
		}

		
		public ConsuntivareNonResoTrenitaliaInterventoRot(Guid id, Guid commitId, DateTime wakeupTime,string note,Guid idCausaleTrenitalia,DateTime dataConsuntivazione,string idInterventoAppaltatore)
		   : base(id,commitId,wakeupTime)
		{
			Contract.Requires(idCausaleTrenitalia != Guid.Empty);

	Contract.Requires(dataConsuntivazione > DateTime.MinValue);

	Contract.Requires(!string.IsNullOrEmpty(idInterventoAppaltatore));

			Note = note ;
			IdCausaleTrenitalia = idCausaleTrenitalia ;
			DataConsuntivazione = dataConsuntivazione ;
			IdInterventoAppaltatore = idInterventoAppaltatore ;
		}

		public ConsuntivareNonResoTrenitaliaInterventoRot(Guid id, Guid commitId, Guid userId,string note,Guid idCausaleTrenitalia,DateTime dataConsuntivazione,string idInterventoAppaltatore)
		   : base(id,commitId,userId)
		{
			Contract.Requires(idCausaleTrenitalia != Guid.Empty);

	Contract.Requires(dataConsuntivazione > DateTime.MinValue);

	Contract.Requires(!string.IsNullOrEmpty(idInterventoAppaltatore));

			Note = note ;
			IdCausaleTrenitalia = idCausaleTrenitalia ;
			DataConsuntivazione = dataConsuntivazione ;
			IdInterventoAppaltatore = idInterventoAppaltatore ;
		}


		public ConsuntivareNonResoTrenitaliaInterventoRot(Guid id, Guid commitId, long version, DateTime wakeupTime,string note,Guid idCausaleTrenitalia,DateTime dataConsuntivazione,string idInterventoAppaltatore)
		   : base(id,commitId,version,wakeupTime)
		{
			Contract.Requires(idCausaleTrenitalia != Guid.Empty);

	Contract.Requires(dataConsuntivazione > DateTime.MinValue);

	Contract.Requires(!string.IsNullOrEmpty(idInterventoAppaltatore));

			Note = note ;
			IdCausaleTrenitalia = idCausaleTrenitalia ;
			DataConsuntivazione = dataConsuntivazione ;
			IdInterventoAppaltatore = idInterventoAppaltatore ;
		}

		
		public ConsuntivareNonResoTrenitaliaInterventoRot(Guid id, Guid commitId, long version, Guid userId,string note,Guid idCausaleTrenitalia,DateTime dataConsuntivazione,string idInterventoAppaltatore)
		   : base(id,commitId,version,userId)
		{
			Contract.Requires(idCausaleTrenitalia != Guid.Empty);

	Contract.Requires(dataConsuntivazione > DateTime.MinValue);

	Contract.Requires(!string.IsNullOrEmpty(idInterventoAppaltatore));

			Note = note ;
			IdCausaleTrenitalia = idCausaleTrenitalia ;
			DataConsuntivazione = dataConsuntivazione ;
			IdInterventoAppaltatore = idInterventoAppaltatore ;
		}
			public override string ToDescription()
		{
			return string.Format("Consuntivare non reso trenitalia il intervento rotabile", Id);
		}
		
		public bool Equals(ConsuntivareNonResoTrenitaliaInterventoRot other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other)  	 && Equals(other.Note, Note)  	 && Equals(other.IdCausaleTrenitalia, IdCausaleTrenitalia)  	 && Equals(other.DataConsuntivazione, DataConsuntivazione)  	 && Equals(other.IdInterventoAppaltatore, IdInterventoAppaltatore) ; 
		}

		public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as ConsuntivareNonResoTrenitaliaInterventoRot);
        }

		public override int GetHashCode()
        {
            unchecked
            {
				int result = base.GetHashCode();
				
				result = (result*397) ^ IdCausaleTrenitalia.GetHashCode();
				result = (result*397) ^ DataConsuntivazione.GetHashCode();
				result = (result*397) ^ (IdInterventoAppaltatore != null ? IdInterventoAppaltatore.GetHashCode() : 0);
				return result;
            }
        }
	}

	public class ConsuntivareNonResoTrenitaliaInterventoRotMan :  CommandBase  
	{
	 
		public string Note { get; set;} 
		public Guid IdCausaleTrenitalia { get; set;} 
		public DateTime DataConsuntivazione { get; set;} 
		public string IdInterventoAppaltatore { get; set;}

		public ConsuntivareNonResoTrenitaliaInterventoRotMan ()
		{
			//for serialisation
		}


		public ConsuntivareNonResoTrenitaliaInterventoRotMan(Guid id, Guid commitId,string note,Guid idCausaleTrenitalia,DateTime dataConsuntivazione,string idInterventoAppaltatore)
		   : base(id,commitId)
		{
			Contract.Requires(idCausaleTrenitalia != Guid.Empty);

	Contract.Requires(dataConsuntivazione > DateTime.MinValue);

	Contract.Requires(!string.IsNullOrEmpty(idInterventoAppaltatore));

			Note = note ;
			IdCausaleTrenitalia = idCausaleTrenitalia ;
			DataConsuntivazione = dataConsuntivazione ;
			IdInterventoAppaltatore = idInterventoAppaltatore ;
		}
	     

		public ConsuntivareNonResoTrenitaliaInterventoRotMan(Guid id, Guid commitId, long version,string note,Guid idCausaleTrenitalia,DateTime dataConsuntivazione,string idInterventoAppaltatore)
		   : base(id,commitId,version)
		{
			Contract.Requires(idCausaleTrenitalia != Guid.Empty);

	Contract.Requires(dataConsuntivazione > DateTime.MinValue);

	Contract.Requires(!string.IsNullOrEmpty(idInterventoAppaltatore));

			Note = note ;
			IdCausaleTrenitalia = idCausaleTrenitalia ;
			DataConsuntivazione = dataConsuntivazione ;
			IdInterventoAppaltatore = idInterventoAppaltatore ;
		}

		
		public ConsuntivareNonResoTrenitaliaInterventoRotMan(Guid id, Guid commitId, DateTime wakeupTime,string note,Guid idCausaleTrenitalia,DateTime dataConsuntivazione,string idInterventoAppaltatore)
		   : base(id,commitId,wakeupTime)
		{
			Contract.Requires(idCausaleTrenitalia != Guid.Empty);

	Contract.Requires(dataConsuntivazione > DateTime.MinValue);

	Contract.Requires(!string.IsNullOrEmpty(idInterventoAppaltatore));

			Note = note ;
			IdCausaleTrenitalia = idCausaleTrenitalia ;
			DataConsuntivazione = dataConsuntivazione ;
			IdInterventoAppaltatore = idInterventoAppaltatore ;
		}

		public ConsuntivareNonResoTrenitaliaInterventoRotMan(Guid id, Guid commitId, Guid userId,string note,Guid idCausaleTrenitalia,DateTime dataConsuntivazione,string idInterventoAppaltatore)
		   : base(id,commitId,userId)
		{
			Contract.Requires(idCausaleTrenitalia != Guid.Empty);

	Contract.Requires(dataConsuntivazione > DateTime.MinValue);

	Contract.Requires(!string.IsNullOrEmpty(idInterventoAppaltatore));

			Note = note ;
			IdCausaleTrenitalia = idCausaleTrenitalia ;
			DataConsuntivazione = dataConsuntivazione ;
			IdInterventoAppaltatore = idInterventoAppaltatore ;
		}


		public ConsuntivareNonResoTrenitaliaInterventoRotMan(Guid id, Guid commitId, long version, DateTime wakeupTime,string note,Guid idCausaleTrenitalia,DateTime dataConsuntivazione,string idInterventoAppaltatore)
		   : base(id,commitId,version,wakeupTime)
		{
			Contract.Requires(idCausaleTrenitalia != Guid.Empty);

	Contract.Requires(dataConsuntivazione > DateTime.MinValue);

	Contract.Requires(!string.IsNullOrEmpty(idInterventoAppaltatore));

			Note = note ;
			IdCausaleTrenitalia = idCausaleTrenitalia ;
			DataConsuntivazione = dataConsuntivazione ;
			IdInterventoAppaltatore = idInterventoAppaltatore ;
		}

		
		public ConsuntivareNonResoTrenitaliaInterventoRotMan(Guid id, Guid commitId, long version, Guid userId,string note,Guid idCausaleTrenitalia,DateTime dataConsuntivazione,string idInterventoAppaltatore)
		   : base(id,commitId,version,userId)
		{
			Contract.Requires(idCausaleTrenitalia != Guid.Empty);

	Contract.Requires(dataConsuntivazione > DateTime.MinValue);

	Contract.Requires(!string.IsNullOrEmpty(idInterventoAppaltatore));

			Note = note ;
			IdCausaleTrenitalia = idCausaleTrenitalia ;
			DataConsuntivazione = dataConsuntivazione ;
			IdInterventoAppaltatore = idInterventoAppaltatore ;
		}
			public override string ToDescription()
		{
			return string.Format("Consuntivare non reso trenitalia il intervento rotabile in manutenzione", Id);
		}
		
		public bool Equals(ConsuntivareNonResoTrenitaliaInterventoRotMan other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other)  	 && Equals(other.Note, Note)  	 && Equals(other.IdCausaleTrenitalia, IdCausaleTrenitalia)  	 && Equals(other.DataConsuntivazione, DataConsuntivazione)  	 && Equals(other.IdInterventoAppaltatore, IdInterventoAppaltatore) ; 
		}

		public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as ConsuntivareNonResoTrenitaliaInterventoRotMan);
        }

		public override int GetHashCode()
        {
            unchecked
            {
				int result = base.GetHashCode();
				
				result = (result*397) ^ IdCausaleTrenitalia.GetHashCode();
				result = (result*397) ^ DataConsuntivazione.GetHashCode();
				result = (result*397) ^ (IdInterventoAppaltatore != null ? IdInterventoAppaltatore.GetHashCode() : 0);
				return result;
            }
        }
	}

	public class ConsuntivareNonResoTrenitaliaInterventoAmb :  CommandBase  
	{
	 
		public string Note { get; set;} 
		public Guid IdCausaleTrenitalia { get; set;} 
		public DateTime DataConsuntivazione { get; set;} 
		public string IdInterventoAppaltatore { get; set;}

		public ConsuntivareNonResoTrenitaliaInterventoAmb ()
		{
			//for serialisation
		}


		public ConsuntivareNonResoTrenitaliaInterventoAmb(Guid id, Guid commitId,string note,Guid idCausaleTrenitalia,DateTime dataConsuntivazione,string idInterventoAppaltatore)
		   : base(id,commitId)
		{
			Contract.Requires(idCausaleTrenitalia != Guid.Empty);

	Contract.Requires(dataConsuntivazione > DateTime.MinValue);

	Contract.Requires(!string.IsNullOrEmpty(idInterventoAppaltatore));

			Note = note ;
			IdCausaleTrenitalia = idCausaleTrenitalia ;
			DataConsuntivazione = dataConsuntivazione ;
			IdInterventoAppaltatore = idInterventoAppaltatore ;
		}
	     

		public ConsuntivareNonResoTrenitaliaInterventoAmb(Guid id, Guid commitId, long version,string note,Guid idCausaleTrenitalia,DateTime dataConsuntivazione,string idInterventoAppaltatore)
		   : base(id,commitId,version)
		{
			Contract.Requires(idCausaleTrenitalia != Guid.Empty);

	Contract.Requires(dataConsuntivazione > DateTime.MinValue);

	Contract.Requires(!string.IsNullOrEmpty(idInterventoAppaltatore));

			Note = note ;
			IdCausaleTrenitalia = idCausaleTrenitalia ;
			DataConsuntivazione = dataConsuntivazione ;
			IdInterventoAppaltatore = idInterventoAppaltatore ;
		}

		
		public ConsuntivareNonResoTrenitaliaInterventoAmb(Guid id, Guid commitId, DateTime wakeupTime,string note,Guid idCausaleTrenitalia,DateTime dataConsuntivazione,string idInterventoAppaltatore)
		   : base(id,commitId,wakeupTime)
		{
			Contract.Requires(idCausaleTrenitalia != Guid.Empty);

	Contract.Requires(dataConsuntivazione > DateTime.MinValue);

	Contract.Requires(!string.IsNullOrEmpty(idInterventoAppaltatore));

			Note = note ;
			IdCausaleTrenitalia = idCausaleTrenitalia ;
			DataConsuntivazione = dataConsuntivazione ;
			IdInterventoAppaltatore = idInterventoAppaltatore ;
		}

		public ConsuntivareNonResoTrenitaliaInterventoAmb(Guid id, Guid commitId, Guid userId,string note,Guid idCausaleTrenitalia,DateTime dataConsuntivazione,string idInterventoAppaltatore)
		   : base(id,commitId,userId)
		{
			Contract.Requires(idCausaleTrenitalia != Guid.Empty);

	Contract.Requires(dataConsuntivazione > DateTime.MinValue);

	Contract.Requires(!string.IsNullOrEmpty(idInterventoAppaltatore));

			Note = note ;
			IdCausaleTrenitalia = idCausaleTrenitalia ;
			DataConsuntivazione = dataConsuntivazione ;
			IdInterventoAppaltatore = idInterventoAppaltatore ;
		}


		public ConsuntivareNonResoTrenitaliaInterventoAmb(Guid id, Guid commitId, long version, DateTime wakeupTime,string note,Guid idCausaleTrenitalia,DateTime dataConsuntivazione,string idInterventoAppaltatore)
		   : base(id,commitId,version,wakeupTime)
		{
			Contract.Requires(idCausaleTrenitalia != Guid.Empty);

	Contract.Requires(dataConsuntivazione > DateTime.MinValue);

	Contract.Requires(!string.IsNullOrEmpty(idInterventoAppaltatore));

			Note = note ;
			IdCausaleTrenitalia = idCausaleTrenitalia ;
			DataConsuntivazione = dataConsuntivazione ;
			IdInterventoAppaltatore = idInterventoAppaltatore ;
		}

		
		public ConsuntivareNonResoTrenitaliaInterventoAmb(Guid id, Guid commitId, long version, Guid userId,string note,Guid idCausaleTrenitalia,DateTime dataConsuntivazione,string idInterventoAppaltatore)
		   : base(id,commitId,version,userId)
		{
			Contract.Requires(idCausaleTrenitalia != Guid.Empty);

	Contract.Requires(dataConsuntivazione > DateTime.MinValue);

	Contract.Requires(!string.IsNullOrEmpty(idInterventoAppaltatore));

			Note = note ;
			IdCausaleTrenitalia = idCausaleTrenitalia ;
			DataConsuntivazione = dataConsuntivazione ;
			IdInterventoAppaltatore = idInterventoAppaltatore ;
		}
			public override string ToDescription()
		{
			return string.Format("Consuntivare non reso trenitalia il intervento ambiente", Id);
		}
		
		public bool Equals(ConsuntivareNonResoTrenitaliaInterventoAmb other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other)  	 && Equals(other.Note, Note)  	 && Equals(other.IdCausaleTrenitalia, IdCausaleTrenitalia)  	 && Equals(other.DataConsuntivazione, DataConsuntivazione)  	 && Equals(other.IdInterventoAppaltatore, IdInterventoAppaltatore) ; 
		}

		public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as ConsuntivareNonResoTrenitaliaInterventoAmb);
        }

		public override int GetHashCode()
        {
            unchecked
            {
				int result = base.GetHashCode();
				
				result = (result*397) ^ IdCausaleTrenitalia.GetHashCode();
				result = (result*397) ^ DataConsuntivazione.GetHashCode();
				result = (result*397) ^ (IdInterventoAppaltatore != null ? IdInterventoAppaltatore.GetHashCode() : 0);
				return result;
            }
        }
	}

	public class ConsuntivareResoInterventoRot :  CommandBase  
	{
	 
		public string Note { get; set;} 
		public WorkPeriod WorkPeriod { get; set;} 
		public DateTime DataConsuntivazione { get; set;} 
		public string IdInterventoAppaltatore { get; set;} 
		public OggettoRot[] Oggetti { get; set;}

		public ConsuntivareResoInterventoRot ()
		{
			//for serialisation
		}


		public ConsuntivareResoInterventoRot(Guid id, Guid commitId,string note,WorkPeriod workPeriod,DateTime dataConsuntivazione,string idInterventoAppaltatore,OggettoRot[] oggetti)
		   : base(id,commitId)
		{
			Contract.Requires(workPeriod != null);

	Contract.Requires(dataConsuntivazione > DateTime.MinValue);

	Contract.Requires(!string.IsNullOrEmpty(idInterventoAppaltatore));

	Contract.Requires(oggetti != null);

			Note = note ;
			WorkPeriod = workPeriod ;
			DataConsuntivazione = dataConsuntivazione ;
			IdInterventoAppaltatore = idInterventoAppaltatore ;
			Oggetti = oggetti ;
		}
	     

		public ConsuntivareResoInterventoRot(Guid id, Guid commitId, long version,string note,WorkPeriod workPeriod,DateTime dataConsuntivazione,string idInterventoAppaltatore,OggettoRot[] oggetti)
		   : base(id,commitId,version)
		{
			Contract.Requires(workPeriod != null);

	Contract.Requires(dataConsuntivazione > DateTime.MinValue);

	Contract.Requires(!string.IsNullOrEmpty(idInterventoAppaltatore));

	Contract.Requires(oggetti != null);

			Note = note ;
			WorkPeriod = workPeriod ;
			DataConsuntivazione = dataConsuntivazione ;
			IdInterventoAppaltatore = idInterventoAppaltatore ;
			Oggetti = oggetti ;
		}

		
		public ConsuntivareResoInterventoRot(Guid id, Guid commitId, DateTime wakeupTime,string note,WorkPeriod workPeriod,DateTime dataConsuntivazione,string idInterventoAppaltatore,OggettoRot[] oggetti)
		   : base(id,commitId,wakeupTime)
		{
			Contract.Requires(workPeriod != null);

	Contract.Requires(dataConsuntivazione > DateTime.MinValue);

	Contract.Requires(!string.IsNullOrEmpty(idInterventoAppaltatore));

	Contract.Requires(oggetti != null);

			Note = note ;
			WorkPeriod = workPeriod ;
			DataConsuntivazione = dataConsuntivazione ;
			IdInterventoAppaltatore = idInterventoAppaltatore ;
			Oggetti = oggetti ;
		}

		public ConsuntivareResoInterventoRot(Guid id, Guid commitId, Guid userId,string note,WorkPeriod workPeriod,DateTime dataConsuntivazione,string idInterventoAppaltatore,OggettoRot[] oggetti)
		   : base(id,commitId,userId)
		{
			Contract.Requires(workPeriod != null);

	Contract.Requires(dataConsuntivazione > DateTime.MinValue);

	Contract.Requires(!string.IsNullOrEmpty(idInterventoAppaltatore));

	Contract.Requires(oggetti != null);

			Note = note ;
			WorkPeriod = workPeriod ;
			DataConsuntivazione = dataConsuntivazione ;
			IdInterventoAppaltatore = idInterventoAppaltatore ;
			Oggetti = oggetti ;
		}


		public ConsuntivareResoInterventoRot(Guid id, Guid commitId, long version, DateTime wakeupTime,string note,WorkPeriod workPeriod,DateTime dataConsuntivazione,string idInterventoAppaltatore,OggettoRot[] oggetti)
		   : base(id,commitId,version,wakeupTime)
		{
			Contract.Requires(workPeriod != null);

	Contract.Requires(dataConsuntivazione > DateTime.MinValue);

	Contract.Requires(!string.IsNullOrEmpty(idInterventoAppaltatore));

	Contract.Requires(oggetti != null);

			Note = note ;
			WorkPeriod = workPeriod ;
			DataConsuntivazione = dataConsuntivazione ;
			IdInterventoAppaltatore = idInterventoAppaltatore ;
			Oggetti = oggetti ;
		}

		
		public ConsuntivareResoInterventoRot(Guid id, Guid commitId, long version, Guid userId,string note,WorkPeriod workPeriod,DateTime dataConsuntivazione,string idInterventoAppaltatore,OggettoRot[] oggetti)
		   : base(id,commitId,version,userId)
		{
			Contract.Requires(workPeriod != null);

	Contract.Requires(dataConsuntivazione > DateTime.MinValue);

	Contract.Requires(!string.IsNullOrEmpty(idInterventoAppaltatore));

	Contract.Requires(oggetti != null);

			Note = note ;
			WorkPeriod = workPeriod ;
			DataConsuntivazione = dataConsuntivazione ;
			IdInterventoAppaltatore = idInterventoAppaltatore ;
			Oggetti = oggetti ;
		}
			public override string ToDescription()
		{
			return string.Format("Consuntivato reso  il intervento rotabile", Id);
		}
		
		public bool Equals(ConsuntivareResoInterventoRot other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other)  	 && Equals(other.Note, Note)  	 && Equals(other.WorkPeriod, WorkPeriod)  	 && Equals(other.DataConsuntivazione, DataConsuntivazione)  	 && Equals(other.IdInterventoAppaltatore, IdInterventoAppaltatore)  	 && other.Oggetti.SequenceEqual(Oggetti) ; 
		}

		public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as ConsuntivareResoInterventoRot);
        }

		public override int GetHashCode()
        {
            unchecked
            {
				int result = base.GetHashCode();
				
				result = (result*397) ^ (WorkPeriod != null ? WorkPeriod.GetHashCode() : 0);
				result = (result*397) ^ DataConsuntivazione.GetHashCode();
				result = (result*397) ^ (IdInterventoAppaltatore != null ? IdInterventoAppaltatore.GetHashCode() : 0);
				result = (result*397) ^ (Oggetti != null ? Oggetti.GetHashCode() : 0);
				return result;
            }
        }
	}

	public class ConsuntivareResoInterventoRotMan :  CommandBase  
	{
	 
		public string Note { get; set;} 
		public WorkPeriod WorkPeriod { get; set;} 
		public DateTime DataConsuntivazione { get; set;} 
		public string IdInterventoAppaltatore { get; set;} 
		public OggettoRotMan[] Oggetti { get; set;}

		public ConsuntivareResoInterventoRotMan ()
		{
			//for serialisation
		}


		public ConsuntivareResoInterventoRotMan(Guid id, Guid commitId,string note,WorkPeriod workPeriod,DateTime dataConsuntivazione,string idInterventoAppaltatore,OggettoRotMan[] oggetti)
		   : base(id,commitId)
		{
			Contract.Requires(workPeriod != null);

	Contract.Requires(dataConsuntivazione > DateTime.MinValue);

	Contract.Requires(!string.IsNullOrEmpty(idInterventoAppaltatore));

	Contract.Requires(oggetti != null);

			Note = note ;
			WorkPeriod = workPeriod ;
			DataConsuntivazione = dataConsuntivazione ;
			IdInterventoAppaltatore = idInterventoAppaltatore ;
			Oggetti = oggetti ;
		}
	     

		public ConsuntivareResoInterventoRotMan(Guid id, Guid commitId, long version,string note,WorkPeriod workPeriod,DateTime dataConsuntivazione,string idInterventoAppaltatore,OggettoRotMan[] oggetti)
		   : base(id,commitId,version)
		{
			Contract.Requires(workPeriod != null);

	Contract.Requires(dataConsuntivazione > DateTime.MinValue);

	Contract.Requires(!string.IsNullOrEmpty(idInterventoAppaltatore));

	Contract.Requires(oggetti != null);

			Note = note ;
			WorkPeriod = workPeriod ;
			DataConsuntivazione = dataConsuntivazione ;
			IdInterventoAppaltatore = idInterventoAppaltatore ;
			Oggetti = oggetti ;
		}

		
		public ConsuntivareResoInterventoRotMan(Guid id, Guid commitId, DateTime wakeupTime,string note,WorkPeriod workPeriod,DateTime dataConsuntivazione,string idInterventoAppaltatore,OggettoRotMan[] oggetti)
		   : base(id,commitId,wakeupTime)
		{
			Contract.Requires(workPeriod != null);

	Contract.Requires(dataConsuntivazione > DateTime.MinValue);

	Contract.Requires(!string.IsNullOrEmpty(idInterventoAppaltatore));

	Contract.Requires(oggetti != null);

			Note = note ;
			WorkPeriod = workPeriod ;
			DataConsuntivazione = dataConsuntivazione ;
			IdInterventoAppaltatore = idInterventoAppaltatore ;
			Oggetti = oggetti ;
		}

		public ConsuntivareResoInterventoRotMan(Guid id, Guid commitId, Guid userId,string note,WorkPeriod workPeriod,DateTime dataConsuntivazione,string idInterventoAppaltatore,OggettoRotMan[] oggetti)
		   : base(id,commitId,userId)
		{
			Contract.Requires(workPeriod != null);

	Contract.Requires(dataConsuntivazione > DateTime.MinValue);

	Contract.Requires(!string.IsNullOrEmpty(idInterventoAppaltatore));

	Contract.Requires(oggetti != null);

			Note = note ;
			WorkPeriod = workPeriod ;
			DataConsuntivazione = dataConsuntivazione ;
			IdInterventoAppaltatore = idInterventoAppaltatore ;
			Oggetti = oggetti ;
		}


		public ConsuntivareResoInterventoRotMan(Guid id, Guid commitId, long version, DateTime wakeupTime,string note,WorkPeriod workPeriod,DateTime dataConsuntivazione,string idInterventoAppaltatore,OggettoRotMan[] oggetti)
		   : base(id,commitId,version,wakeupTime)
		{
			Contract.Requires(workPeriod != null);

	Contract.Requires(dataConsuntivazione > DateTime.MinValue);

	Contract.Requires(!string.IsNullOrEmpty(idInterventoAppaltatore));

	Contract.Requires(oggetti != null);

			Note = note ;
			WorkPeriod = workPeriod ;
			DataConsuntivazione = dataConsuntivazione ;
			IdInterventoAppaltatore = idInterventoAppaltatore ;
			Oggetti = oggetti ;
		}

		
		public ConsuntivareResoInterventoRotMan(Guid id, Guid commitId, long version, Guid userId,string note,WorkPeriod workPeriod,DateTime dataConsuntivazione,string idInterventoAppaltatore,OggettoRotMan[] oggetti)
		   : base(id,commitId,version,userId)
		{
			Contract.Requires(workPeriod != null);

	Contract.Requires(dataConsuntivazione > DateTime.MinValue);

	Contract.Requires(!string.IsNullOrEmpty(idInterventoAppaltatore));

	Contract.Requires(oggetti != null);

			Note = note ;
			WorkPeriod = workPeriod ;
			DataConsuntivazione = dataConsuntivazione ;
			IdInterventoAppaltatore = idInterventoAppaltatore ;
			Oggetti = oggetti ;
		}
			public override string ToDescription()
		{
			return string.Format("Consuntivare reso il intervento rotabile in manutenzione", Id);
		}
		
		public bool Equals(ConsuntivareResoInterventoRotMan other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other)  	 && Equals(other.Note, Note)  	 && Equals(other.WorkPeriod, WorkPeriod)  	 && Equals(other.DataConsuntivazione, DataConsuntivazione)  	 && Equals(other.IdInterventoAppaltatore, IdInterventoAppaltatore)  	 && other.Oggetti.SequenceEqual(Oggetti) ; 
		}

		public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as ConsuntivareResoInterventoRotMan);
        }

		public override int GetHashCode()
        {
            unchecked
            {
				int result = base.GetHashCode();
				
				result = (result*397) ^ (WorkPeriod != null ? WorkPeriod.GetHashCode() : 0);
				result = (result*397) ^ DataConsuntivazione.GetHashCode();
				result = (result*397) ^ (IdInterventoAppaltatore != null ? IdInterventoAppaltatore.GetHashCode() : 0);
				result = (result*397) ^ (Oggetti != null ? Oggetti.GetHashCode() : 0);
				return result;
            }
        }
	}

	public class ConsuntivareResoInterventoAmb :  CommandBase  
	{
	 
		public string Note { get; set;} 
		public WorkPeriod WorkPeriod { get; set;} 
		public DateTime DataConsuntivazione { get; set;} 
		public string IdInterventoAppaltatore { get; set;} 
		public string Description { get; set;} 
		public int Quantity { get; set;}

		public ConsuntivareResoInterventoAmb ()
		{
			//for serialisation
		}


		public ConsuntivareResoInterventoAmb(Guid id, Guid commitId,string note,WorkPeriod workPeriod,DateTime dataConsuntivazione,string idInterventoAppaltatore,string description,int quantity)
		   : base(id,commitId)
		{
			Contract.Requires(workPeriod != null);

	Contract.Requires(dataConsuntivazione > DateTime.MinValue);

	Contract.Requires(!string.IsNullOrEmpty(idInterventoAppaltatore));

	Contract.Requires(quantity > 0);

			Note = note ;
			WorkPeriod = workPeriod ;
			DataConsuntivazione = dataConsuntivazione ;
			IdInterventoAppaltatore = idInterventoAppaltatore ;
			Description = description ;
			Quantity = quantity ;
		}
	     

		public ConsuntivareResoInterventoAmb(Guid id, Guid commitId, long version,string note,WorkPeriod workPeriod,DateTime dataConsuntivazione,string idInterventoAppaltatore,string description,int quantity)
		   : base(id,commitId,version)
		{
			Contract.Requires(workPeriod != null);

	Contract.Requires(dataConsuntivazione > DateTime.MinValue);

	Contract.Requires(!string.IsNullOrEmpty(idInterventoAppaltatore));

	Contract.Requires(quantity > 0);

			Note = note ;
			WorkPeriod = workPeriod ;
			DataConsuntivazione = dataConsuntivazione ;
			IdInterventoAppaltatore = idInterventoAppaltatore ;
			Description = description ;
			Quantity = quantity ;
		}

		
		public ConsuntivareResoInterventoAmb(Guid id, Guid commitId, DateTime wakeupTime,string note,WorkPeriod workPeriod,DateTime dataConsuntivazione,string idInterventoAppaltatore,string description,int quantity)
		   : base(id,commitId,wakeupTime)
		{
			Contract.Requires(workPeriod != null);

	Contract.Requires(dataConsuntivazione > DateTime.MinValue);

	Contract.Requires(!string.IsNullOrEmpty(idInterventoAppaltatore));

	Contract.Requires(quantity > 0);

			Note = note ;
			WorkPeriod = workPeriod ;
			DataConsuntivazione = dataConsuntivazione ;
			IdInterventoAppaltatore = idInterventoAppaltatore ;
			Description = description ;
			Quantity = quantity ;
		}

		public ConsuntivareResoInterventoAmb(Guid id, Guid commitId, Guid userId,string note,WorkPeriod workPeriod,DateTime dataConsuntivazione,string idInterventoAppaltatore,string description,int quantity)
		   : base(id,commitId,userId)
		{
			Contract.Requires(workPeriod != null);

	Contract.Requires(dataConsuntivazione > DateTime.MinValue);

	Contract.Requires(!string.IsNullOrEmpty(idInterventoAppaltatore));

	Contract.Requires(quantity > 0);

			Note = note ;
			WorkPeriod = workPeriod ;
			DataConsuntivazione = dataConsuntivazione ;
			IdInterventoAppaltatore = idInterventoAppaltatore ;
			Description = description ;
			Quantity = quantity ;
		}


		public ConsuntivareResoInterventoAmb(Guid id, Guid commitId, long version, DateTime wakeupTime,string note,WorkPeriod workPeriod,DateTime dataConsuntivazione,string idInterventoAppaltatore,string description,int quantity)
		   : base(id,commitId,version,wakeupTime)
		{
			Contract.Requires(workPeriod != null);

	Contract.Requires(dataConsuntivazione > DateTime.MinValue);

	Contract.Requires(!string.IsNullOrEmpty(idInterventoAppaltatore));

	Contract.Requires(quantity > 0);

			Note = note ;
			WorkPeriod = workPeriod ;
			DataConsuntivazione = dataConsuntivazione ;
			IdInterventoAppaltatore = idInterventoAppaltatore ;
			Description = description ;
			Quantity = quantity ;
		}

		
		public ConsuntivareResoInterventoAmb(Guid id, Guid commitId, long version, Guid userId,string note,WorkPeriod workPeriod,DateTime dataConsuntivazione,string idInterventoAppaltatore,string description,int quantity)
		   : base(id,commitId,version,userId)
		{
			Contract.Requires(workPeriod != null);

	Contract.Requires(dataConsuntivazione > DateTime.MinValue);

	Contract.Requires(!string.IsNullOrEmpty(idInterventoAppaltatore));

	Contract.Requires(quantity > 0);

			Note = note ;
			WorkPeriod = workPeriod ;
			DataConsuntivazione = dataConsuntivazione ;
			IdInterventoAppaltatore = idInterventoAppaltatore ;
			Description = description ;
			Quantity = quantity ;
		}
			public override string ToDescription()
		{
			return string.Format("Consuntivare reso il intervento ambiente", Id);
		}
		
		public bool Equals(ConsuntivareResoInterventoAmb other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other)  	 && Equals(other.Note, Note)  	 && Equals(other.WorkPeriod, WorkPeriod)  	 && Equals(other.DataConsuntivazione, DataConsuntivazione)  	 && Equals(other.IdInterventoAppaltatore, IdInterventoAppaltatore)  	 && Equals(other.Description, Description)  	 && Equals(other.Quantity, Quantity) ; 
		}

		public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as ConsuntivareResoInterventoAmb);
        }

		public override int GetHashCode()
        {
            unchecked
            {
				int result = base.GetHashCode();
				
				result = (result*397) ^ (WorkPeriod != null ? WorkPeriod.GetHashCode() : 0);
				result = (result*397) ^ DataConsuntivazione.GetHashCode();
				result = (result*397) ^ (IdInterventoAppaltatore != null ? IdInterventoAppaltatore.GetHashCode() : 0);
				
				result = (result*397) ^ Quantity.GetHashCode();
				return result;
            }
        }
	}

	public class ControlNonResoIntervento :  CommandBase  
	{
	 
		public string Note { get; set;} 
		public Guid IdCausale { get; set;} 
		public DateTime ControlDate { get; set;} 
		public Guid IdUser { get; set;}

		public ControlNonResoIntervento ()
		{
			//for serialisation
		}


		public ControlNonResoIntervento(Guid id, Guid commitId,string note,Guid idCausale,DateTime controlDate,Guid idUser)
		   : base(id,commitId)
		{
			Contract.Requires(idCausale != Guid.Empty);

	Contract.Requires(controlDate > DateTime.MinValue);

	Contract.Requires(idUser != Guid.Empty);

			Note = note ;
			IdCausale = idCausale ;
			ControlDate = controlDate ;
			IdUser = idUser ;
		}
	     

		public ControlNonResoIntervento(Guid id, Guid commitId, long version,string note,Guid idCausale,DateTime controlDate,Guid idUser)
		   : base(id,commitId,version)
		{
			Contract.Requires(idCausale != Guid.Empty);

	Contract.Requires(controlDate > DateTime.MinValue);

	Contract.Requires(idUser != Guid.Empty);

			Note = note ;
			IdCausale = idCausale ;
			ControlDate = controlDate ;
			IdUser = idUser ;
		}

		
		public ControlNonResoIntervento(Guid id, Guid commitId, DateTime wakeupTime,string note,Guid idCausale,DateTime controlDate,Guid idUser)
		   : base(id,commitId,wakeupTime)
		{
			Contract.Requires(idCausale != Guid.Empty);

	Contract.Requires(controlDate > DateTime.MinValue);

	Contract.Requires(idUser != Guid.Empty);

			Note = note ;
			IdCausale = idCausale ;
			ControlDate = controlDate ;
			IdUser = idUser ;
		}

		public ControlNonResoIntervento(Guid id, Guid commitId, Guid userId,string note,Guid idCausale,DateTime controlDate,Guid idUser)
		   : base(id,commitId,userId)
		{
			Contract.Requires(idCausale != Guid.Empty);

	Contract.Requires(controlDate > DateTime.MinValue);

	Contract.Requires(idUser != Guid.Empty);

			Note = note ;
			IdCausale = idCausale ;
			ControlDate = controlDate ;
			IdUser = idUser ;
		}


		public ControlNonResoIntervento(Guid id, Guid commitId, long version, DateTime wakeupTime,string note,Guid idCausale,DateTime controlDate,Guid idUser)
		   : base(id,commitId,version,wakeupTime)
		{
			Contract.Requires(idCausale != Guid.Empty);

	Contract.Requires(controlDate > DateTime.MinValue);

	Contract.Requires(idUser != Guid.Empty);

			Note = note ;
			IdCausale = idCausale ;
			ControlDate = controlDate ;
			IdUser = idUser ;
		}

		
		public ControlNonResoIntervento(Guid id, Guid commitId, long version, Guid userId,string note,Guid idCausale,DateTime controlDate,Guid idUser)
		   : base(id,commitId,version,userId)
		{
			Contract.Requires(idCausale != Guid.Empty);

	Contract.Requires(controlDate > DateTime.MinValue);

	Contract.Requires(idUser != Guid.Empty);

			Note = note ;
			IdCausale = idCausale ;
			ControlDate = controlDate ;
			IdUser = idUser ;
		}
			public override string ToDescription()
		{
			return string.Format("si rileva non reso il intervento {0}.", Id);
		}
		
		public bool Equals(ControlNonResoIntervento other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other)  	 && Equals(other.Note, Note)  	 && Equals(other.IdCausale, IdCausale)  	 && Equals(other.ControlDate, ControlDate)  	 && Equals(other.IdUser, IdUser) ; 
		}

		public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as ControlNonResoIntervento);
        }

		public override int GetHashCode()
        {
            unchecked
            {
				int result = base.GetHashCode();
				
				result = (result*397) ^ IdCausale.GetHashCode();
				result = (result*397) ^ ControlDate.GetHashCode();
				result = (result*397) ^ IdUser.GetHashCode();
				return result;
            }
        }
	}

	public class ControlResoInterventoRot :  CommandBase  
	{
	 
		public string Note { get; set;} 
		public WorkPeriod WorkPeriod { get; set;} 
		public DateTime ControlDate { get; set;} 
		public Guid IdUser { get; set;} 
		public string IdInterventoAppaltatore { get; set;} 
		public string Convoglio { get; set;} 
		public string RigaTurnoTreno { get; set;} 
		public string TurnoTreno { get; set;} 
		public Treno TrenoArrivo { get; set;} 
		public Treno TrenoPartenza { get; set;} 
		public OggettoRot[] Oggetti { get; set;}

		public ControlResoInterventoRot ()
		{
			//for serialisation
		}


		public ControlResoInterventoRot(Guid id, Guid commitId,string note,WorkPeriod workPeriod,DateTime controlDate,Guid idUser,string idInterventoAppaltatore,string convoglio,string rigaTurnoTreno,string turnoTreno,Treno trenoArrivo,Treno trenoPartenza,OggettoRot[] oggetti)
		   : base(id,commitId)
		{
			Contract.Requires(workPeriod != null);

	Contract.Requires(controlDate > DateTime.MinValue);

	Contract.Requires(idUser != Guid.Empty);

	Contract.Requires(!string.IsNullOrEmpty(idInterventoAppaltatore));

	Contract.Requires(oggetti != null);

			Note = note ;
			WorkPeriod = workPeriod ;
			ControlDate = controlDate ;
			IdUser = idUser ;
			IdInterventoAppaltatore = idInterventoAppaltatore ;
			Convoglio = convoglio ;
			RigaTurnoTreno = rigaTurnoTreno ;
			TurnoTreno = turnoTreno ;
			TrenoArrivo = trenoArrivo ;
			TrenoPartenza = trenoPartenza ;
			Oggetti = oggetti ;
		}
	     

		public ControlResoInterventoRot(Guid id, Guid commitId, long version,string note,WorkPeriod workPeriod,DateTime controlDate,Guid idUser,string idInterventoAppaltatore,string convoglio,string rigaTurnoTreno,string turnoTreno,Treno trenoArrivo,Treno trenoPartenza,OggettoRot[] oggetti)
		   : base(id,commitId,version)
		{
			Contract.Requires(workPeriod != null);

	Contract.Requires(controlDate > DateTime.MinValue);

	Contract.Requires(idUser != Guid.Empty);

	Contract.Requires(!string.IsNullOrEmpty(idInterventoAppaltatore));

	Contract.Requires(oggetti != null);

			Note = note ;
			WorkPeriod = workPeriod ;
			ControlDate = controlDate ;
			IdUser = idUser ;
			IdInterventoAppaltatore = idInterventoAppaltatore ;
			Convoglio = convoglio ;
			RigaTurnoTreno = rigaTurnoTreno ;
			TurnoTreno = turnoTreno ;
			TrenoArrivo = trenoArrivo ;
			TrenoPartenza = trenoPartenza ;
			Oggetti = oggetti ;
		}

		
		public ControlResoInterventoRot(Guid id, Guid commitId, DateTime wakeupTime,string note,WorkPeriod workPeriod,DateTime controlDate,Guid idUser,string idInterventoAppaltatore,string convoglio,string rigaTurnoTreno,string turnoTreno,Treno trenoArrivo,Treno trenoPartenza,OggettoRot[] oggetti)
		   : base(id,commitId,wakeupTime)
		{
			Contract.Requires(workPeriod != null);

	Contract.Requires(controlDate > DateTime.MinValue);

	Contract.Requires(idUser != Guid.Empty);

	Contract.Requires(!string.IsNullOrEmpty(idInterventoAppaltatore));

	Contract.Requires(oggetti != null);

			Note = note ;
			WorkPeriod = workPeriod ;
			ControlDate = controlDate ;
			IdUser = idUser ;
			IdInterventoAppaltatore = idInterventoAppaltatore ;
			Convoglio = convoglio ;
			RigaTurnoTreno = rigaTurnoTreno ;
			TurnoTreno = turnoTreno ;
			TrenoArrivo = trenoArrivo ;
			TrenoPartenza = trenoPartenza ;
			Oggetti = oggetti ;
		}

		public ControlResoInterventoRot(Guid id, Guid commitId, Guid userId,string note,WorkPeriod workPeriod,DateTime controlDate,Guid idUser,string idInterventoAppaltatore,string convoglio,string rigaTurnoTreno,string turnoTreno,Treno trenoArrivo,Treno trenoPartenza,OggettoRot[] oggetti)
		   : base(id,commitId,userId)
		{
			Contract.Requires(workPeriod != null);

	Contract.Requires(controlDate > DateTime.MinValue);

	Contract.Requires(idUser != Guid.Empty);

	Contract.Requires(!string.IsNullOrEmpty(idInterventoAppaltatore));

	Contract.Requires(oggetti != null);

			Note = note ;
			WorkPeriod = workPeriod ;
			ControlDate = controlDate ;
			IdUser = idUser ;
			IdInterventoAppaltatore = idInterventoAppaltatore ;
			Convoglio = convoglio ;
			RigaTurnoTreno = rigaTurnoTreno ;
			TurnoTreno = turnoTreno ;
			TrenoArrivo = trenoArrivo ;
			TrenoPartenza = trenoPartenza ;
			Oggetti = oggetti ;
		}


		public ControlResoInterventoRot(Guid id, Guid commitId, long version, DateTime wakeupTime,string note,WorkPeriod workPeriod,DateTime controlDate,Guid idUser,string idInterventoAppaltatore,string convoglio,string rigaTurnoTreno,string turnoTreno,Treno trenoArrivo,Treno trenoPartenza,OggettoRot[] oggetti)
		   : base(id,commitId,version,wakeupTime)
		{
			Contract.Requires(workPeriod != null);

	Contract.Requires(controlDate > DateTime.MinValue);

	Contract.Requires(idUser != Guid.Empty);

	Contract.Requires(!string.IsNullOrEmpty(idInterventoAppaltatore));

	Contract.Requires(oggetti != null);

			Note = note ;
			WorkPeriod = workPeriod ;
			ControlDate = controlDate ;
			IdUser = idUser ;
			IdInterventoAppaltatore = idInterventoAppaltatore ;
			Convoglio = convoglio ;
			RigaTurnoTreno = rigaTurnoTreno ;
			TurnoTreno = turnoTreno ;
			TrenoArrivo = trenoArrivo ;
			TrenoPartenza = trenoPartenza ;
			Oggetti = oggetti ;
		}

		
		public ControlResoInterventoRot(Guid id, Guid commitId, long version, Guid userId,string note,WorkPeriod workPeriod,DateTime controlDate,Guid idUser,string idInterventoAppaltatore,string convoglio,string rigaTurnoTreno,string turnoTreno,Treno trenoArrivo,Treno trenoPartenza,OggettoRot[] oggetti)
		   : base(id,commitId,version,userId)
		{
			Contract.Requires(workPeriod != null);

	Contract.Requires(controlDate > DateTime.MinValue);

	Contract.Requires(idUser != Guid.Empty);

	Contract.Requires(!string.IsNullOrEmpty(idInterventoAppaltatore));

	Contract.Requires(oggetti != null);

			Note = note ;
			WorkPeriod = workPeriod ;
			ControlDate = controlDate ;
			IdUser = idUser ;
			IdInterventoAppaltatore = idInterventoAppaltatore ;
			Convoglio = convoglio ;
			RigaTurnoTreno = rigaTurnoTreno ;
			TurnoTreno = turnoTreno ;
			TrenoArrivo = trenoArrivo ;
			TrenoPartenza = trenoPartenza ;
			Oggetti = oggetti ;
		}
			public override string ToDescription()
		{
			return string.Format("si rileva reso il intervento rotabile", Id);
		}
		
		public bool Equals(ControlResoInterventoRot other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other)  	 && Equals(other.Note, Note)  	 && Equals(other.WorkPeriod, WorkPeriod)  	 && Equals(other.ControlDate, ControlDate)  	 && Equals(other.IdUser, IdUser)  	 && Equals(other.IdInterventoAppaltatore, IdInterventoAppaltatore)  	 && Equals(other.Convoglio, Convoglio)  	 && Equals(other.RigaTurnoTreno, RigaTurnoTreno)  	 && Equals(other.TurnoTreno, TurnoTreno)  	 && Equals(other.TrenoArrivo, TrenoArrivo)  	 && Equals(other.TrenoPartenza, TrenoPartenza)  	 && other.Oggetti.SequenceEqual(Oggetti) ; 
		}

		public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as ControlResoInterventoRot);
        }

		public override int GetHashCode()
        {
            unchecked
            {
				int result = base.GetHashCode();
				
				result = (result*397) ^ (WorkPeriod != null ? WorkPeriod.GetHashCode() : 0);
				result = (result*397) ^ ControlDate.GetHashCode();
				result = (result*397) ^ IdUser.GetHashCode();
				result = (result*397) ^ (IdInterventoAppaltatore != null ? IdInterventoAppaltatore.GetHashCode() : 0);
				
				
				
				
				
				result = (result*397) ^ (Oggetti != null ? Oggetti.GetHashCode() : 0);
				return result;
            }
        }
	}

	public class ControlResoInterventoRotMan :  CommandBase  
	{
	 
		public string Note { get; set;} 
		public WorkPeriod WorkPeriod { get; set;} 
		public DateTime ControlDate { get; set;} 
		public Guid IdUser { get; set;} 
		public string IdInterventoAppaltatore { get; set;} 
		public OggettoRotMan[] Oggetti { get; set;}

		public ControlResoInterventoRotMan ()
		{
			//for serialisation
		}


		public ControlResoInterventoRotMan(Guid id, Guid commitId,string note,WorkPeriod workPeriod,DateTime controlDate,Guid idUser,string idInterventoAppaltatore,OggettoRotMan[] oggetti)
		   : base(id,commitId)
		{
			Contract.Requires(workPeriod != null);

	Contract.Requires(controlDate > DateTime.MinValue);

	Contract.Requires(idUser != Guid.Empty);

	Contract.Requires(!string.IsNullOrEmpty(idInterventoAppaltatore));

	Contract.Requires(oggetti != null);

			Note = note ;
			WorkPeriod = workPeriod ;
			ControlDate = controlDate ;
			IdUser = idUser ;
			IdInterventoAppaltatore = idInterventoAppaltatore ;
			Oggetti = oggetti ;
		}
	     

		public ControlResoInterventoRotMan(Guid id, Guid commitId, long version,string note,WorkPeriod workPeriod,DateTime controlDate,Guid idUser,string idInterventoAppaltatore,OggettoRotMan[] oggetti)
		   : base(id,commitId,version)
		{
			Contract.Requires(workPeriod != null);

	Contract.Requires(controlDate > DateTime.MinValue);

	Contract.Requires(idUser != Guid.Empty);

	Contract.Requires(!string.IsNullOrEmpty(idInterventoAppaltatore));

	Contract.Requires(oggetti != null);

			Note = note ;
			WorkPeriod = workPeriod ;
			ControlDate = controlDate ;
			IdUser = idUser ;
			IdInterventoAppaltatore = idInterventoAppaltatore ;
			Oggetti = oggetti ;
		}

		
		public ControlResoInterventoRotMan(Guid id, Guid commitId, DateTime wakeupTime,string note,WorkPeriod workPeriod,DateTime controlDate,Guid idUser,string idInterventoAppaltatore,OggettoRotMan[] oggetti)
		   : base(id,commitId,wakeupTime)
		{
			Contract.Requires(workPeriod != null);

	Contract.Requires(controlDate > DateTime.MinValue);

	Contract.Requires(idUser != Guid.Empty);

	Contract.Requires(!string.IsNullOrEmpty(idInterventoAppaltatore));

	Contract.Requires(oggetti != null);

			Note = note ;
			WorkPeriod = workPeriod ;
			ControlDate = controlDate ;
			IdUser = idUser ;
			IdInterventoAppaltatore = idInterventoAppaltatore ;
			Oggetti = oggetti ;
		}

		public ControlResoInterventoRotMan(Guid id, Guid commitId, Guid userId,string note,WorkPeriod workPeriod,DateTime controlDate,Guid idUser,string idInterventoAppaltatore,OggettoRotMan[] oggetti)
		   : base(id,commitId,userId)
		{
			Contract.Requires(workPeriod != null);

	Contract.Requires(controlDate > DateTime.MinValue);

	Contract.Requires(idUser != Guid.Empty);

	Contract.Requires(!string.IsNullOrEmpty(idInterventoAppaltatore));

	Contract.Requires(oggetti != null);

			Note = note ;
			WorkPeriod = workPeriod ;
			ControlDate = controlDate ;
			IdUser = idUser ;
			IdInterventoAppaltatore = idInterventoAppaltatore ;
			Oggetti = oggetti ;
		}


		public ControlResoInterventoRotMan(Guid id, Guid commitId, long version, DateTime wakeupTime,string note,WorkPeriod workPeriod,DateTime controlDate,Guid idUser,string idInterventoAppaltatore,OggettoRotMan[] oggetti)
		   : base(id,commitId,version,wakeupTime)
		{
			Contract.Requires(workPeriod != null);

	Contract.Requires(controlDate > DateTime.MinValue);

	Contract.Requires(idUser != Guid.Empty);

	Contract.Requires(!string.IsNullOrEmpty(idInterventoAppaltatore));

	Contract.Requires(oggetti != null);

			Note = note ;
			WorkPeriod = workPeriod ;
			ControlDate = controlDate ;
			IdUser = idUser ;
			IdInterventoAppaltatore = idInterventoAppaltatore ;
			Oggetti = oggetti ;
		}

		
		public ControlResoInterventoRotMan(Guid id, Guid commitId, long version, Guid userId,string note,WorkPeriod workPeriod,DateTime controlDate,Guid idUser,string idInterventoAppaltatore,OggettoRotMan[] oggetti)
		   : base(id,commitId,version,userId)
		{
			Contract.Requires(workPeriod != null);

	Contract.Requires(controlDate > DateTime.MinValue);

	Contract.Requires(idUser != Guid.Empty);

	Contract.Requires(!string.IsNullOrEmpty(idInterventoAppaltatore));

	Contract.Requires(oggetti != null);

			Note = note ;
			WorkPeriod = workPeriod ;
			ControlDate = controlDate ;
			IdUser = idUser ;
			IdInterventoAppaltatore = idInterventoAppaltatore ;
			Oggetti = oggetti ;
		}
			public override string ToDescription()
		{
			return string.Format("si controlla reso il intervento rotabile in manutenzione {0}.", Id);
		}
		
		public bool Equals(ControlResoInterventoRotMan other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other)  	 && Equals(other.Note, Note)  	 && Equals(other.WorkPeriod, WorkPeriod)  	 && Equals(other.ControlDate, ControlDate)  	 && Equals(other.IdUser, IdUser)  	 && Equals(other.IdInterventoAppaltatore, IdInterventoAppaltatore)  	 && other.Oggetti.SequenceEqual(Oggetti) ; 
		}

		public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as ControlResoInterventoRotMan);
        }

		public override int GetHashCode()
        {
            unchecked
            {
				int result = base.GetHashCode();
				
				result = (result*397) ^ (WorkPeriod != null ? WorkPeriod.GetHashCode() : 0);
				result = (result*397) ^ ControlDate.GetHashCode();
				result = (result*397) ^ IdUser.GetHashCode();
				result = (result*397) ^ (IdInterventoAppaltatore != null ? IdInterventoAppaltatore.GetHashCode() : 0);
				result = (result*397) ^ (Oggetti != null ? Oggetti.GetHashCode() : 0);
				return result;
            }
        }
	}

	public class ControlResoInterventoAmb :  CommandBase  
	{
	 
		public string Note { get; set;} 
		public WorkPeriod WorkPeriod { get; set;} 
		public DateTime ControlDate { get; set;} 
		public Guid IdUser { get; set;} 
		public string IdInterventoAppaltatore { get; set;} 
		public string Description { get; set;} 
		public int Quantity { get; set;}

		public ControlResoInterventoAmb ()
		{
			//for serialisation
		}


		public ControlResoInterventoAmb(Guid id, Guid commitId,string note,WorkPeriod workPeriod,DateTime controlDate,Guid idUser,string idInterventoAppaltatore,string description,int quantity)
		   : base(id,commitId)
		{
			Contract.Requires(workPeriod != null);

	Contract.Requires(controlDate > DateTime.MinValue);

	Contract.Requires(idUser != Guid.Empty);

	Contract.Requires(!string.IsNullOrEmpty(idInterventoAppaltatore));

	Contract.Requires(quantity > 0);

			Note = note ;
			WorkPeriod = workPeriod ;
			ControlDate = controlDate ;
			IdUser = idUser ;
			IdInterventoAppaltatore = idInterventoAppaltatore ;
			Description = description ;
			Quantity = quantity ;
		}
	     

		public ControlResoInterventoAmb(Guid id, Guid commitId, long version,string note,WorkPeriod workPeriod,DateTime controlDate,Guid idUser,string idInterventoAppaltatore,string description,int quantity)
		   : base(id,commitId,version)
		{
			Contract.Requires(workPeriod != null);

	Contract.Requires(controlDate > DateTime.MinValue);

	Contract.Requires(idUser != Guid.Empty);

	Contract.Requires(!string.IsNullOrEmpty(idInterventoAppaltatore));

	Contract.Requires(quantity > 0);

			Note = note ;
			WorkPeriod = workPeriod ;
			ControlDate = controlDate ;
			IdUser = idUser ;
			IdInterventoAppaltatore = idInterventoAppaltatore ;
			Description = description ;
			Quantity = quantity ;
		}

		
		public ControlResoInterventoAmb(Guid id, Guid commitId, DateTime wakeupTime,string note,WorkPeriod workPeriod,DateTime controlDate,Guid idUser,string idInterventoAppaltatore,string description,int quantity)
		   : base(id,commitId,wakeupTime)
		{
			Contract.Requires(workPeriod != null);

	Contract.Requires(controlDate > DateTime.MinValue);

	Contract.Requires(idUser != Guid.Empty);

	Contract.Requires(!string.IsNullOrEmpty(idInterventoAppaltatore));

	Contract.Requires(quantity > 0);

			Note = note ;
			WorkPeriod = workPeriod ;
			ControlDate = controlDate ;
			IdUser = idUser ;
			IdInterventoAppaltatore = idInterventoAppaltatore ;
			Description = description ;
			Quantity = quantity ;
		}

		public ControlResoInterventoAmb(Guid id, Guid commitId, Guid userId,string note,WorkPeriod workPeriod,DateTime controlDate,Guid idUser,string idInterventoAppaltatore,string description,int quantity)
		   : base(id,commitId,userId)
		{
			Contract.Requires(workPeriod != null);

	Contract.Requires(controlDate > DateTime.MinValue);

	Contract.Requires(idUser != Guid.Empty);

	Contract.Requires(!string.IsNullOrEmpty(idInterventoAppaltatore));

	Contract.Requires(quantity > 0);

			Note = note ;
			WorkPeriod = workPeriod ;
			ControlDate = controlDate ;
			IdUser = idUser ;
			IdInterventoAppaltatore = idInterventoAppaltatore ;
			Description = description ;
			Quantity = quantity ;
		}


		public ControlResoInterventoAmb(Guid id, Guid commitId, long version, DateTime wakeupTime,string note,WorkPeriod workPeriod,DateTime controlDate,Guid idUser,string idInterventoAppaltatore,string description,int quantity)
		   : base(id,commitId,version,wakeupTime)
		{
			Contract.Requires(workPeriod != null);

	Contract.Requires(controlDate > DateTime.MinValue);

	Contract.Requires(idUser != Guid.Empty);

	Contract.Requires(!string.IsNullOrEmpty(idInterventoAppaltatore));

	Contract.Requires(quantity > 0);

			Note = note ;
			WorkPeriod = workPeriod ;
			ControlDate = controlDate ;
			IdUser = idUser ;
			IdInterventoAppaltatore = idInterventoAppaltatore ;
			Description = description ;
			Quantity = quantity ;
		}

		
		public ControlResoInterventoAmb(Guid id, Guid commitId, long version, Guid userId,string note,WorkPeriod workPeriod,DateTime controlDate,Guid idUser,string idInterventoAppaltatore,string description,int quantity)
		   : base(id,commitId,version,userId)
		{
			Contract.Requires(workPeriod != null);

	Contract.Requires(controlDate > DateTime.MinValue);

	Contract.Requires(idUser != Guid.Empty);

	Contract.Requires(!string.IsNullOrEmpty(idInterventoAppaltatore));

	Contract.Requires(quantity > 0);

			Note = note ;
			WorkPeriod = workPeriod ;
			ControlDate = controlDate ;
			IdUser = idUser ;
			IdInterventoAppaltatore = idInterventoAppaltatore ;
			Description = description ;
			Quantity = quantity ;
		}
			public override string ToDescription()
		{
			return string.Format("si controlla reso il intervento ambiente '{0}' ", Id);
		}
		
		public bool Equals(ControlResoInterventoAmb other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other)  	 && Equals(other.Note, Note)  	 && Equals(other.WorkPeriod, WorkPeriod)  	 && Equals(other.ControlDate, ControlDate)  	 && Equals(other.IdUser, IdUser)  	 && Equals(other.IdInterventoAppaltatore, IdInterventoAppaltatore)  	 && Equals(other.Description, Description)  	 && Equals(other.Quantity, Quantity) ; 
		}

		public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as ControlResoInterventoAmb);
        }

		public override int GetHashCode()
        {
            unchecked
            {
				int result = base.GetHashCode();
				
				result = (result*397) ^ (WorkPeriod != null ? WorkPeriod.GetHashCode() : 0);
				result = (result*397) ^ ControlDate.GetHashCode();
				result = (result*397) ^ IdUser.GetHashCode();
				result = (result*397) ^ (IdInterventoAppaltatore != null ? IdInterventoAppaltatore.GetHashCode() : 0);
				
				result = (result*397) ^ Quantity.GetHashCode();
				return result;
            }
        }
	}
}
