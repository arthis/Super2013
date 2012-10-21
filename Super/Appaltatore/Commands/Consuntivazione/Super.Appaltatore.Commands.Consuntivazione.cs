



using System;
using System.Linq;
using System.Diagnostics.Contracts;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using CommonDomain;
using CommonDomain.Core;


namespace Super.Appaltatore.Commands.Consuntivazione
{


	public class ConsuntivareAutomaticamenteNonResoInterventoRot :  CommandBase  
	{
	

		public ConsuntivareAutomaticamenteNonResoInterventoRot ()
		{
			//for serialisation
		}	     

		public ConsuntivareAutomaticamenteNonResoInterventoRot(Guid id, Guid commitId, long version)
		   : base(id,commitId,version)
		{
				}

		public ConsuntivareAutomaticamenteNonResoInterventoRot(Guid id, Guid commitId, long version, DateTime wakeupTime)
		   : base(id,commitId,version,wakeupTime)
		{
				}
			public override string ToDescription()
		{
			return string.Format("Consuntivare automaticamente non reso appaltatore il intervento rotabile", Id);
		}
		
		public bool Equals(ConsuntivareAutomaticamenteNonResoInterventoRot other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) ; 
		}

		public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as ConsuntivareAutomaticamenteNonResoInterventoRot);
        }

		public override int GetHashCode()
        {
            unchecked
            {
				int result = base.GetHashCode();
				return result;
            }
        }
	}

	public class ConsuntivareAutomaticamenteNonResoInterventoRotMan :  CommandBase  
	{
	

		public ConsuntivareAutomaticamenteNonResoInterventoRotMan ()
		{
			//for serialisation
		}	     

		public ConsuntivareAutomaticamenteNonResoInterventoRotMan(Guid id, Guid commitId, long version)
		   : base(id,commitId,version)
		{
				}

		public ConsuntivareAutomaticamenteNonResoInterventoRotMan(Guid id, Guid commitId, long version, DateTime wakeupTime)
		   : base(id,commitId,version,wakeupTime)
		{
				}
			public override string ToDescription()
		{
			return string.Format("Consuntivare automaticamente non reso appaltatore il intervento rotabile in manutenzione", Id);
		}
		
		public bool Equals(ConsuntivareAutomaticamenteNonResoInterventoRotMan other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) ; 
		}

		public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as ConsuntivareAutomaticamenteNonResoInterventoRotMan);
        }

		public override int GetHashCode()
        {
            unchecked
            {
				int result = base.GetHashCode();
				return result;
            }
        }
	}

	public class ConsuntivareAutomaticamenteNonResoInterventoAmb :  CommandBase  
	{
	

		public ConsuntivareAutomaticamenteNonResoInterventoAmb ()
		{
			//for serialisation
		}	     

		public ConsuntivareAutomaticamenteNonResoInterventoAmb(Guid id, Guid commitId, long version)
		   : base(id,commitId,version)
		{
				}

		public ConsuntivareAutomaticamenteNonResoInterventoAmb(Guid id, Guid commitId, long version, DateTime wakeupTime)
		   : base(id,commitId,version,wakeupTime)
		{
				}
			public override string ToDescription()
		{
			return string.Format("Consuntivare automaticamente non reso appaltatore il intervento Ambiente", Id);
		}
		
		public bool Equals(ConsuntivareAutomaticamenteNonResoInterventoAmb other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) ; 
		}

		public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as ConsuntivareAutomaticamenteNonResoInterventoAmb);
        }

		public override int GetHashCode()
        {
            unchecked
            {
				int result = base.GetHashCode();
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
				result = (result*397) ^ (Note != null ? Note.GetHashCode() : 0);
				result = (result*397) ^ (IdCausaleAppaltatore != null ? IdCausaleAppaltatore.GetHashCode() : 0);
				result = (result*397) ^ (DataConsuntivazione != null ? DataConsuntivazione.GetHashCode() : 0);
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
				result = (result*397) ^ (Note != null ? Note.GetHashCode() : 0);
				result = (result*397) ^ (IdCausaleAppaltatore != null ? IdCausaleAppaltatore.GetHashCode() : 0);
				result = (result*397) ^ (DataConsuntivazione != null ? DataConsuntivazione.GetHashCode() : 0);
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
				result = (result*397) ^ (Note != null ? Note.GetHashCode() : 0);
				result = (result*397) ^ (IdCausaleAppaltatore != null ? IdCausaleAppaltatore.GetHashCode() : 0);
				result = (result*397) ^ (DataConsuntivazione != null ? DataConsuntivazione.GetHashCode() : 0);
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
				result = (result*397) ^ (Note != null ? Note.GetHashCode() : 0);
				result = (result*397) ^ (IdCausaleTrenitalia != null ? IdCausaleTrenitalia.GetHashCode() : 0);
				result = (result*397) ^ (DataConsuntivazione != null ? DataConsuntivazione.GetHashCode() : 0);
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
				result = (result*397) ^ (Note != null ? Note.GetHashCode() : 0);
				result = (result*397) ^ (IdCausaleTrenitalia != null ? IdCausaleTrenitalia.GetHashCode() : 0);
				result = (result*397) ^ (DataConsuntivazione != null ? DataConsuntivazione.GetHashCode() : 0);
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
				result = (result*397) ^ (Note != null ? Note.GetHashCode() : 0);
				result = (result*397) ^ (IdCausaleTrenitalia != null ? IdCausaleTrenitalia.GetHashCode() : 0);
				result = (result*397) ^ (DataConsuntivazione != null ? DataConsuntivazione.GetHashCode() : 0);
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
				result = (result*397) ^ (Note != null ? Note.GetHashCode() : 0);
				result = (result*397) ^ (WorkPeriod != null ? WorkPeriod.GetHashCode() : 0);
				result = (result*397) ^ (DataConsuntivazione != null ? DataConsuntivazione.GetHashCode() : 0);
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
				result = (result*397) ^ (Note != null ? Note.GetHashCode() : 0);
				result = (result*397) ^ (WorkPeriod != null ? WorkPeriod.GetHashCode() : 0);
				result = (result*397) ^ (DataConsuntivazione != null ? DataConsuntivazione.GetHashCode() : 0);
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

		public ConsuntivareResoInterventoAmb(Guid id, Guid commitId, long version,string note,WorkPeriod workPeriod,DateTime dataConsuntivazione,string idInterventoAppaltatore,string description,int quantity)
		   : base(id,commitId,version)
		{
			Contract.Requires(workPeriod != null);

	Contract.Requires(dataConsuntivazione > DateTime.MinValue);

	Contract.Requires(!string.IsNullOrEmpty(idInterventoAppaltatore));

	Contract.Requires(quantity != null);

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

	Contract.Requires(quantity != null);

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
				result = (result*397) ^ (Note != null ? Note.GetHashCode() : 0);
				result = (result*397) ^ (WorkPeriod != null ? WorkPeriod.GetHashCode() : 0);
				result = (result*397) ^ (DataConsuntivazione != null ? DataConsuntivazione.GetHashCode() : 0);
				result = (result*397) ^ (IdInterventoAppaltatore != null ? IdInterventoAppaltatore.GetHashCode() : 0);
				result = (result*397) ^ (Description != null ? Description.GetHashCode() : 0);
				result = (result*397) ^ (Quantity != null ? Quantity.GetHashCode() : 0);
				return result;
            }
        }
	}
}
