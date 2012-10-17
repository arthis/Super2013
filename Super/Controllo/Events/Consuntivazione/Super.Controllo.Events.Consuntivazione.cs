


using System;
using System.Linq;
using System.Diagnostics.Contracts;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using CommonDomain;
using CommonDomain.Core;


namespace Super.Controllo.Events.Consuntivazione
{


	public class InterventoControlAllowed : Message, IEvent  
	{
	

		public InterventoControlAllowed ()
		{
			//for serialisation
		}	     

		public InterventoControlAllowed(Guid id, Guid commitId, long version)
		   : base(id,commitId,version)
		{
				}

		public InterventoControlAllowed(Guid id, Guid commitId, long version,DateTime wakeupTime)
		   : base(id,commitId,version,wakeupTime)
		{
				}
			public override string ToDescription()
		{
			return string.Format("E permesso controllare il intervento '{0}'.", Id);
		}
		
		public bool Equals(InterventoControlAllowed other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) ; 
		}

		public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as InterventoControlAllowed);
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

	public class InterventoClosed : Message, IEvent  
	{
	 
		public Guid IdUser { get; set;} 
		public DateTime ClosingDate { get; set;}

		public InterventoClosed ()
		{
			//for serialisation
		}	     

		public InterventoClosed(Guid id, Guid commitId, long version,Guid idUser,DateTime closingDate)
		   : base(id,commitId,version)
		{
			Contract.Requires(idUser != Guid.Empty);

	Contract.Requires(closingDate > DateTime.MinValue);

			IdUser = idUser ;
			ClosingDate = closingDate ;
		}

		public InterventoClosed(Guid id, Guid commitId, long version,DateTime wakeupTime,Guid idUser,DateTime closingDate)
		   : base(id,commitId,version,wakeupTime)
		{
			Contract.Requires(idUser != Guid.Empty);

	Contract.Requires(closingDate > DateTime.MinValue);

			IdUser = idUser ;
			ClosingDate = closingDate ;
		}
			public override string ToDescription()
		{
			return string.Format("Il intervento '{0}' é stato chiuso.", Id);
		}
		
		public bool Equals(InterventoClosed other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other)  	 && Equals(other.IdUser, IdUser)  	 && Equals(other.ClosingDate, ClosingDate) ; 
		}

		public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as InterventoClosed);
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

	public class InterventoReopened : Message, IEvent  
	{
	 
		public Guid IdUser { get; set;} 
		public DateTime ReopeningDate { get; set;}

		public InterventoReopened ()
		{
			//for serialisation
		}	     

		public InterventoReopened(Guid id, Guid commitId, long version,Guid idUser,DateTime reopeningDate)
		   : base(id,commitId,version)
		{
			Contract.Requires(idUser != Guid.Empty);

	Contract.Requires(reopeningDate > DateTime.MinValue);

			IdUser = idUser ;
			ReopeningDate = reopeningDate ;
		}

		public InterventoReopened(Guid id, Guid commitId, long version,DateTime wakeupTime,Guid idUser,DateTime reopeningDate)
		   : base(id,commitId,version,wakeupTime)
		{
			Contract.Requires(idUser != Guid.Empty);

	Contract.Requires(reopeningDate > DateTime.MinValue);

			IdUser = idUser ;
			ReopeningDate = reopeningDate ;
		}
			public override string ToDescription()
		{
			return string.Format("Il intervento {0} é stato aperto di nuovo.", Id);
		}
		
		public bool Equals(InterventoReopened other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other)  	 && Equals(other.IdUser, IdUser)  	 && Equals(other.ReopeningDate, ReopeningDate) ; 
		}

		public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as InterventoReopened);
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

	public class InterventoControlledNonReso : Message, IEvent  
	{
	 
		public string Note { get; set;} 
		public Guid IdCausale { get; set;} 
		public DateTime ControlDate { get; set;} 
		public Guid IdUser { get; set;}

		public InterventoControlledNonReso ()
		{
			//for serialisation
		}	     

		public InterventoControlledNonReso(Guid id, Guid commitId, long version,string note,Guid idCausale,DateTime controlDate,Guid idUser)
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

		public InterventoControlledNonReso(Guid id, Guid commitId, long version,DateTime wakeupTime,string note,Guid idCausale,DateTime controlDate,Guid idUser)
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
			return string.Format("Il intervento '{0}' é stato rilevato non reso.", Id);
		}
		
		public bool Equals(InterventoControlledNonReso other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other)  	 && Equals(other.Note, Note)  	 && Equals(other.IdCausale, IdCausale)  	 && Equals(other.ControlDate, ControlDate)  	 && Equals(other.IdUser, IdUser) ; 
		}

		public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as InterventoControlledNonReso);
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

	public class InterventoRotControlledReso : Message, IEvent  
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

		public InterventoRotControlledReso ()
		{
			//for serialisation
		}	     

		public InterventoRotControlledReso(Guid id, Guid commitId, long version,string note,WorkPeriod workPeriod,DateTime controlDate,Guid idUser,string idInterventoAppaltatore,string convoglio,string rigaTurnoTreno,string turnoTreno,Treno trenoArrivo,Treno trenoPartenza,OggettoRot[] oggetti)
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

		public InterventoRotControlledReso(Guid id, Guid commitId, long version,DateTime wakeupTime,string note,WorkPeriod workPeriod,DateTime controlDate,Guid idUser,string idInterventoAppaltatore,string convoglio,string rigaTurnoTreno,string turnoTreno,Treno trenoArrivo,Treno trenoPartenza,OggettoRot[] oggetti)
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
			return string.Format("Il intervento rotabile '{0}' é stato controllato reso.", Id);
		}
		
		public bool Equals(InterventoRotControlledReso other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other)  	 && Equals(other.Note, Note)  	 && Equals(other.WorkPeriod, WorkPeriod)  	 && Equals(other.ControlDate, ControlDate)  	 && Equals(other.IdUser, IdUser)  	 && Equals(other.IdInterventoAppaltatore, IdInterventoAppaltatore)  	 && Equals(other.Convoglio, Convoglio)  	 && Equals(other.RigaTurnoTreno, RigaTurnoTreno)  	 && Equals(other.TurnoTreno, TurnoTreno)  	 && Equals(other.TrenoArrivo, TrenoArrivo)  	 && Equals(other.TrenoPartenza, TrenoPartenza)  	 && other.Oggetti.SequenceEqual(Oggetti) ; 
		}

		public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as InterventoRotControlledReso);
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

	public class InterventoRotManControlledReso : Message, IEvent  
	{
	 
		public string Note { get; set;} 
		public WorkPeriod WorkPeriod { get; set;} 
		public DateTime ControlDate { get; set;} 
		public Guid IdUser { get; set;} 
		public string IdInterventoAppaltatore { get; set;} 
		public OggettoRotMan[] Oggetti { get; set;}

		public InterventoRotManControlledReso ()
		{
			//for serialisation
		}	     

		public InterventoRotManControlledReso(Guid id, Guid commitId, long version,string note,WorkPeriod workPeriod,DateTime controlDate,Guid idUser,string idInterventoAppaltatore,OggettoRotMan[] oggetti)
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

		public InterventoRotManControlledReso(Guid id, Guid commitId, long version,DateTime wakeupTime,string note,WorkPeriod workPeriod,DateTime controlDate,Guid idUser,string idInterventoAppaltatore,OggettoRotMan[] oggetti)
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
			return string.Format("Il intervento rotabile in manutenzione '{0}' é stato controllato reso.", Id);
		}
		
		public bool Equals(InterventoRotManControlledReso other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other)  	 && Equals(other.Note, Note)  	 && Equals(other.WorkPeriod, WorkPeriod)  	 && Equals(other.ControlDate, ControlDate)  	 && Equals(other.IdUser, IdUser)  	 && Equals(other.IdInterventoAppaltatore, IdInterventoAppaltatore)  	 && other.Oggetti.SequenceEqual(Oggetti) ; 
		}

		public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as InterventoRotManControlledReso);
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

	public class InterventoAmbControlledReso : Message, IEvent  
	{
	 
		public string Note { get; set;} 
		public WorkPeriod WorkPeriod { get; set;} 
		public DateTime ControlDate { get; set;} 
		public Guid IdUser { get; set;} 
		public string IdInterventoAppaltatore { get; set;} 
		public string Description { get; set;} 
		public int Quantity { get; set;}

		public InterventoAmbControlledReso ()
		{
			//for serialisation
		}	     

		public InterventoAmbControlledReso(Guid id, Guid commitId, long version,string note,WorkPeriod workPeriod,DateTime controlDate,Guid idUser,string idInterventoAppaltatore,string description,int quantity)
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

		public InterventoAmbControlledReso(Guid id, Guid commitId, long version,DateTime wakeupTime,string note,WorkPeriod workPeriod,DateTime controlDate,Guid idUser,string idInterventoAppaltatore,string description,int quantity)
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
			return string.Format("Il intervento ambiente '{0}' é stato controllato reso.", Id);
		}
		
		public bool Equals(InterventoAmbControlledReso other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other)  	 && Equals(other.Note, Note)  	 && Equals(other.WorkPeriod, WorkPeriod)  	 && Equals(other.ControlDate, ControlDate)  	 && Equals(other.IdUser, IdUser)  	 && Equals(other.IdInterventoAppaltatore, IdInterventoAppaltatore)  	 && Equals(other.Description, Description)  	 && Equals(other.Quantity, Quantity) ; 
		}

		public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as InterventoAmbControlledReso);
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
