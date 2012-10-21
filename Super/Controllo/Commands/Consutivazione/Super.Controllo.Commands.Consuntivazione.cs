﻿



using System;
using System.Linq;
using System.Diagnostics.Contracts;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using CommonDomain;
using CommonDomain.Core;


namespace Super.Controllo.Commands.Consuntivazione
{


	public class AllowInterventoControl :  CommandBase  
	{
	 
		public Guid IdUser { get; set;}

		public AllowInterventoControl ()
		{
			//for serialisation
		}	     

		public AllowInterventoControl(Guid id, Guid commitId, long version,Guid idUser)
		   : base(id,commitId,version)
		{
			Contract.Requires(idUser != Guid.Empty);

			IdUser = idUser ;
		}

		public AllowInterventoControl(Guid id, Guid commitId, long version, DateTime wakeupTime,Guid idUser)
		   : base(id,commitId,version,wakeupTime)
		{
			Contract.Requires(idUser != Guid.Empty);

			IdUser = idUser ;
		}
			public override string ToDescription()
		{
			return string.Format("si permette il controllo dell'intervento {0}.", Id);
		}
		
		public bool Equals(AllowInterventoControl other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other)  	 && Equals(other.IdUser, IdUser) ; 
		}

		public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as AllowInterventoControl);
        }

		public override int GetHashCode()
        {
            unchecked
            {
				int result = base.GetHashCode();
				result = (result*397) ^ (IdUser != null ? IdUser.GetHashCode() : 0);
				return result;
            }
        }
	}

	public class CloseIntervento :  CommandBase  
	{
	 
		public Guid IdUser { get; set;} 
		public DateTime ClosingDate { get; set;}

		public CloseIntervento ()
		{
			//for serialisation
		}	     

		public CloseIntervento(Guid id, Guid commitId, long version,Guid idUser,DateTime closingDate)
		   : base(id,commitId,version)
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
				result = (result*397) ^ (IdUser != null ? IdUser.GetHashCode() : 0);
				result = (result*397) ^ (ClosingDate != null ? ClosingDate.GetHashCode() : 0);
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

		public ReopenIntervento(Guid id, Guid commitId, long version,Guid idUser,DateTime reopeningDate)
		   : base(id,commitId,version)
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
				result = (result*397) ^ (IdUser != null ? IdUser.GetHashCode() : 0);
				result = (result*397) ^ (ReopeningDate != null ? ReopeningDate.GetHashCode() : 0);
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
				result = (result*397) ^ (Note != null ? Note.GetHashCode() : 0);
				result = (result*397) ^ (IdCausale != null ? IdCausale.GetHashCode() : 0);
				result = (result*397) ^ (ControlDate != null ? ControlDate.GetHashCode() : 0);
				result = (result*397) ^ (IdUser != null ? IdUser.GetHashCode() : 0);
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
				result = (result*397) ^ (Note != null ? Note.GetHashCode() : 0);
				result = (result*397) ^ (WorkPeriod != null ? WorkPeriod.GetHashCode() : 0);
				result = (result*397) ^ (ControlDate != null ? ControlDate.GetHashCode() : 0);
				result = (result*397) ^ (IdUser != null ? IdUser.GetHashCode() : 0);
				result = (result*397) ^ (IdInterventoAppaltatore != null ? IdInterventoAppaltatore.GetHashCode() : 0);
				result = (result*397) ^ (Convoglio != null ? Convoglio.GetHashCode() : 0);
				result = (result*397) ^ (RigaTurnoTreno != null ? RigaTurnoTreno.GetHashCode() : 0);
				result = (result*397) ^ (TurnoTreno != null ? TurnoTreno.GetHashCode() : 0);
				result = (result*397) ^ (TrenoArrivo != null ? TrenoArrivo.GetHashCode() : 0);
				result = (result*397) ^ (TrenoPartenza != null ? TrenoPartenza.GetHashCode() : 0);
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
				result = (result*397) ^ (Note != null ? Note.GetHashCode() : 0);
				result = (result*397) ^ (WorkPeriod != null ? WorkPeriod.GetHashCode() : 0);
				result = (result*397) ^ (ControlDate != null ? ControlDate.GetHashCode() : 0);
				result = (result*397) ^ (IdUser != null ? IdUser.GetHashCode() : 0);
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

		public ControlResoInterventoAmb(Guid id, Guid commitId, long version,string note,WorkPeriod workPeriod,DateTime controlDate,Guid idUser,string idInterventoAppaltatore,string description,int quantity)
		   : base(id,commitId,version)
		{
			Contract.Requires(workPeriod != null);

	Contract.Requires(controlDate > DateTime.MinValue);

	Contract.Requires(idUser != Guid.Empty);

	Contract.Requires(!string.IsNullOrEmpty(idInterventoAppaltatore));

	Contract.Requires(quantity != null);

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

	Contract.Requires(quantity != null);

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
				result = (result*397) ^ (Note != null ? Note.GetHashCode() : 0);
				result = (result*397) ^ (WorkPeriod != null ? WorkPeriod.GetHashCode() : 0);
				result = (result*397) ^ (ControlDate != null ? ControlDate.GetHashCode() : 0);
				result = (result*397) ^ (IdUser != null ? IdUser.GetHashCode() : 0);
				result = (result*397) ^ (IdInterventoAppaltatore != null ? IdInterventoAppaltatore.GetHashCode() : 0);
				result = (result*397) ^ (Description != null ? Description.GetHashCode() : 0);
				result = (result*397) ^ (Quantity != null ? Quantity.GetHashCode() : 0);
				return result;
            }
        }
	}
}
