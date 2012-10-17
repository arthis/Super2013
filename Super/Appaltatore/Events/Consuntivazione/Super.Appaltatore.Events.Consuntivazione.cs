


using System;
using System.Linq;
using System.Diagnostics.Contracts;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using CommonDomain;
using CommonDomain.Core;


namespace Super.Appaltatore.Events.Consuntivazione
{


	public class InterventoRotConsuntivatoNonReso : Message, IEvent ,IInterventoRotConsuntivato 
	{
	 
		public string Note { get; set;} 
		public Guid IdCausaleAppaltatore { get; set;} 
		public DateTime DataConsuntivazione { get; set;} 
		public string IdInterventoAppaltatore { get; set;}

		public InterventoRotConsuntivatoNonReso ()
		{
			//for serialisation
		}	     

		public InterventoRotConsuntivatoNonReso(Guid id, Guid commitId, long version,string note,Guid idCausaleAppaltatore,DateTime dataConsuntivazione,string idInterventoAppaltatore)
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

		public InterventoRotConsuntivatoNonReso(Guid id, Guid commitId, long version,DateTime wakeupTime,string note,Guid idCausaleAppaltatore,DateTime dataConsuntivazione,string idInterventoAppaltatore)
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
			return string.Format("il intervento rotabile é stato  consuntivato non reso appaltatore", Id);
		}
		
		public bool Equals(InterventoRotConsuntivatoNonReso other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other)  	 && Equals(other.Note, Note)  	 && Equals(other.IdCausaleAppaltatore, IdCausaleAppaltatore)  	 && Equals(other.DataConsuntivazione, DataConsuntivazione)  	 && Equals(other.IdInterventoAppaltatore, IdInterventoAppaltatore) ; 
		}

		public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as InterventoRotConsuntivatoNonReso);
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

	public class InterventoRotManConsuntivatoNonReso : Message, IEvent ,IInterventoRotManConsuntivato 
	{
	 
		public string Note { get; set;} 
		public Guid IdCausaleAppaltatore { get; set;} 
		public DateTime DataConsuntivazione { get; set;} 
		public string IdInterventoAppaltatore { get; set;}

		public InterventoRotManConsuntivatoNonReso ()
		{
			//for serialisation
		}	     

		public InterventoRotManConsuntivatoNonReso(Guid id, Guid commitId, long version,string note,Guid idCausaleAppaltatore,DateTime dataConsuntivazione,string idInterventoAppaltatore)
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

		public InterventoRotManConsuntivatoNonReso(Guid id, Guid commitId, long version,DateTime wakeupTime,string note,Guid idCausaleAppaltatore,DateTime dataConsuntivazione,string idInterventoAppaltatore)
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
			return string.Format("il intervento rotabile in manutenzione é stato  consuntivato non reso appaltatore", Id);
		}
		
		public bool Equals(InterventoRotManConsuntivatoNonReso other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other)  	 && Equals(other.Note, Note)  	 && Equals(other.IdCausaleAppaltatore, IdCausaleAppaltatore)  	 && Equals(other.DataConsuntivazione, DataConsuntivazione)  	 && Equals(other.IdInterventoAppaltatore, IdInterventoAppaltatore) ; 
		}

		public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as InterventoRotManConsuntivatoNonReso);
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

	public class InterventoAmbConsuntivatoNonReso : Message, IEvent ,IInterventoAmbConsuntivato 
	{
	 
		public string Note { get; set;} 
		public Guid IdCausaleAppaltatore { get; set;} 
		public DateTime DataConsuntivazione { get; set;} 
		public string IdInterventoAppaltatore { get; set;}

		public InterventoAmbConsuntivatoNonReso ()
		{
			//for serialisation
		}	     

		public InterventoAmbConsuntivatoNonReso(Guid id, Guid commitId, long version,string note,Guid idCausaleAppaltatore,DateTime dataConsuntivazione,string idInterventoAppaltatore)
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

		public InterventoAmbConsuntivatoNonReso(Guid id, Guid commitId, long version,DateTime wakeupTime,string note,Guid idCausaleAppaltatore,DateTime dataConsuntivazione,string idInterventoAppaltatore)
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
			return string.Format("il intervento ambiente é stato  consuntivato non reso appaltatore", Id);
		}
		
		public bool Equals(InterventoAmbConsuntivatoNonReso other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other)  	 && Equals(other.Note, Note)  	 && Equals(other.IdCausaleAppaltatore, IdCausaleAppaltatore)  	 && Equals(other.DataConsuntivazione, DataConsuntivazione)  	 && Equals(other.IdInterventoAppaltatore, IdInterventoAppaltatore) ; 
		}

		public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as InterventoAmbConsuntivatoNonReso);
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

	public class InterventoRotConsuntivatoNonResoTrenitalia : Message, IEvent ,IInterventoRotConsuntivato 
	{
	 
		public string Note { get; set;} 
		public Guid IdCausaleTrenitalia { get; set;} 
		public DateTime DataConsuntivazione { get; set;} 
		public string IdInterventoAppaltatore { get; set;}

		public InterventoRotConsuntivatoNonResoTrenitalia ()
		{
			//for serialisation
		}	     

		public InterventoRotConsuntivatoNonResoTrenitalia(Guid id, Guid commitId, long version,string note,Guid idCausaleTrenitalia,DateTime dataConsuntivazione,string idInterventoAppaltatore)
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

		public InterventoRotConsuntivatoNonResoTrenitalia(Guid id, Guid commitId, long version,DateTime wakeupTime,string note,Guid idCausaleTrenitalia,DateTime dataConsuntivazione,string idInterventoAppaltatore)
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
			return string.Format("il intervento rotabile é stato  consuntivato non reso trenitalia", Id);
		}
		
		public bool Equals(InterventoRotConsuntivatoNonResoTrenitalia other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other)  	 && Equals(other.Note, Note)  	 && Equals(other.IdCausaleTrenitalia, IdCausaleTrenitalia)  	 && Equals(other.DataConsuntivazione, DataConsuntivazione)  	 && Equals(other.IdInterventoAppaltatore, IdInterventoAppaltatore) ; 
		}

		public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as InterventoRotConsuntivatoNonResoTrenitalia);
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

	public class InterventoRotManConsuntivatoNonResoTrenitalia : Message, IEvent ,IInterventoRotManConsuntivato 
	{
	 
		public string Note { get; set;} 
		public Guid IdCausaleTrenitalia { get; set;} 
		public DateTime DataConsuntivazione { get; set;} 
		public string IdInterventoAppaltatore { get; set;}

		public InterventoRotManConsuntivatoNonResoTrenitalia ()
		{
			//for serialisation
		}	     

		public InterventoRotManConsuntivatoNonResoTrenitalia(Guid id, Guid commitId, long version,string note,Guid idCausaleTrenitalia,DateTime dataConsuntivazione,string idInterventoAppaltatore)
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

		public InterventoRotManConsuntivatoNonResoTrenitalia(Guid id, Guid commitId, long version,DateTime wakeupTime,string note,Guid idCausaleTrenitalia,DateTime dataConsuntivazione,string idInterventoAppaltatore)
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
			return string.Format("il intervento rotabile in manutenzione é stato  consuntivato non reso trenitalia", Id);
		}
		
		public bool Equals(InterventoRotManConsuntivatoNonResoTrenitalia other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other)  	 && Equals(other.Note, Note)  	 && Equals(other.IdCausaleTrenitalia, IdCausaleTrenitalia)  	 && Equals(other.DataConsuntivazione, DataConsuntivazione)  	 && Equals(other.IdInterventoAppaltatore, IdInterventoAppaltatore) ; 
		}

		public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as InterventoRotManConsuntivatoNonResoTrenitalia);
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

	public class InterventoAmbConsuntivatoNonResoTrenitalia : Message, IEvent ,IInterventoAmbConsuntivato 
	{
	 
		public string Note { get; set;} 
		public Guid IdCausaleTrenitalia { get; set;} 
		public DateTime DataConsuntivazione { get; set;} 
		public string IdInterventoAppaltatore { get; set;}

		public InterventoAmbConsuntivatoNonResoTrenitalia ()
		{
			//for serialisation
		}	     

		public InterventoAmbConsuntivatoNonResoTrenitalia(Guid id, Guid commitId, long version,string note,Guid idCausaleTrenitalia,DateTime dataConsuntivazione,string idInterventoAppaltatore)
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

		public InterventoAmbConsuntivatoNonResoTrenitalia(Guid id, Guid commitId, long version,DateTime wakeupTime,string note,Guid idCausaleTrenitalia,DateTime dataConsuntivazione,string idInterventoAppaltatore)
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
			return string.Format("il intervento ambiente é stato  consuntivato non reso trenitalia", Id);
		}
		
		public bool Equals(InterventoAmbConsuntivatoNonResoTrenitalia other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other)  	 && Equals(other.Note, Note)  	 && Equals(other.IdCausaleTrenitalia, IdCausaleTrenitalia)  	 && Equals(other.DataConsuntivazione, DataConsuntivazione)  	 && Equals(other.IdInterventoAppaltatore, IdInterventoAppaltatore) ; 
		}

		public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as InterventoAmbConsuntivatoNonResoTrenitalia);
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

	public class InterventoAmbConsuntivatoReso : Message, IEvent ,IInterventoAmbConsuntivato 
	{
	 
		public string Note { get; set;} 
		public WorkPeriod WorkPeriod { get; set;} 
		public DateTime DataConsuntivazione { get; set;} 
		public string IdInterventoAppaltatore { get; set;} 
		public int Quantity { get; set;} 
		public string Description { get; set;}

		public InterventoAmbConsuntivatoReso ()
		{
			//for serialisation
		}	     

		public InterventoAmbConsuntivatoReso(Guid id, Guid commitId, long version,string note,WorkPeriod workPeriod,DateTime dataConsuntivazione,string idInterventoAppaltatore,int quantity,string description)
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
			Quantity = quantity ;
			Description = description ;
		}

		public InterventoAmbConsuntivatoReso(Guid id, Guid commitId, long version,DateTime wakeupTime,string note,WorkPeriod workPeriod,DateTime dataConsuntivazione,string idInterventoAppaltatore,int quantity,string description)
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
			Quantity = quantity ;
			Description = description ;
		}
			public override string ToDescription()
		{
			return string.Format("Il intervento ambiente é stato consuntivato reso", Id);
		}
		
		public bool Equals(InterventoAmbConsuntivatoReso other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other)  	 && Equals(other.Note, Note)  	 && Equals(other.WorkPeriod, WorkPeriod)  	 && Equals(other.DataConsuntivazione, DataConsuntivazione)  	 && Equals(other.IdInterventoAppaltatore, IdInterventoAppaltatore)  	 && Equals(other.Quantity, Quantity)  	 && Equals(other.Description, Description) ; 
		}

		public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as InterventoAmbConsuntivatoReso);
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
				result = (result*397) ^ (Quantity != null ? Quantity.GetHashCode() : 0);
				result = (result*397) ^ (Description != null ? Description.GetHashCode() : 0);
				return result;
            }
        }
	}

	public class InterventoRotConsuntivatoReso : Message, IEvent ,IInterventoRotConsuntivato 
	{
	 
		public string Note { get; set;} 
		public WorkPeriod WorkPeriod { get; set;} 
		public DateTime DataConsuntivazione { get; set;} 
		public string IdInterventoAppaltatore { get; set;} 
		public string Convoglio { get; set;} 
		public string TurnoTreno { get; set;} 
		public Treno TrenoArrivo { get; set;} 
		public string RigaTurnoTreno { get; set;} 
		public Treno TrenoPartenza { get; set;} 
		public OggettoRot[] Oggetti { get; set;}

		public InterventoRotConsuntivatoReso ()
		{
			//for serialisation
		}	     

		public InterventoRotConsuntivatoReso(Guid id, Guid commitId, long version,string note,WorkPeriod workPeriod,DateTime dataConsuntivazione,string idInterventoAppaltatore,string convoglio,string turnoTreno,Treno trenoArrivo,string rigaTurnoTreno,Treno trenoPartenza,OggettoRot[] oggetti)
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
			Convoglio = convoglio ;
			TurnoTreno = turnoTreno ;
			TrenoArrivo = trenoArrivo ;
			RigaTurnoTreno = rigaTurnoTreno ;
			TrenoPartenza = trenoPartenza ;
			Oggetti = oggetti ;
		}

		public InterventoRotConsuntivatoReso(Guid id, Guid commitId, long version,DateTime wakeupTime,string note,WorkPeriod workPeriod,DateTime dataConsuntivazione,string idInterventoAppaltatore,string convoglio,string turnoTreno,Treno trenoArrivo,string rigaTurnoTreno,Treno trenoPartenza,OggettoRot[] oggetti)
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
			Convoglio = convoglio ;
			TurnoTreno = turnoTreno ;
			TrenoArrivo = trenoArrivo ;
			RigaTurnoTreno = rigaTurnoTreno ;
			TrenoPartenza = trenoPartenza ;
			Oggetti = oggetti ;
		}
			public override string ToDescription()
		{
			return string.Format("Il intervento rotabile é stato consuntivato reso", Id);
		}
		
		public bool Equals(InterventoRotConsuntivatoReso other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other)  	 && Equals(other.Note, Note)  	 && Equals(other.WorkPeriod, WorkPeriod)  	 && Equals(other.DataConsuntivazione, DataConsuntivazione)  	 && Equals(other.IdInterventoAppaltatore, IdInterventoAppaltatore)  	 && Equals(other.Convoglio, Convoglio)  	 && Equals(other.TurnoTreno, TurnoTreno)  	 && Equals(other.TrenoArrivo, TrenoArrivo)  	 && Equals(other.RigaTurnoTreno, RigaTurnoTreno)  	 && Equals(other.TrenoPartenza, TrenoPartenza)  	 && other.Oggetti.SequenceEqual(Oggetti) ; 
		}

		public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as InterventoRotConsuntivatoReso);
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
				result = (result*397) ^ (Convoglio != null ? Convoglio.GetHashCode() : 0);
				result = (result*397) ^ (TurnoTreno != null ? TurnoTreno.GetHashCode() : 0);
				result = (result*397) ^ (TrenoArrivo != null ? TrenoArrivo.GetHashCode() : 0);
				result = (result*397) ^ (RigaTurnoTreno != null ? RigaTurnoTreno.GetHashCode() : 0);
				result = (result*397) ^ (TrenoPartenza != null ? TrenoPartenza.GetHashCode() : 0);
				result = (result*397) ^ (Oggetti != null ? Oggetti.GetHashCode() : 0);
				return result;
            }
        }
	}

	public class InterventoRotManConsuntivatoReso : Message, IEvent ,IInterventoRotManConsuntivato 
	{
	 
		public string Note { get; set;} 
		public WorkPeriod WorkPeriod { get; set;} 
		public DateTime DataConsuntivazione { get; set;} 
		public string IdInterventoAppaltatore { get; set;} 
		public OggettoRotMan[] Oggetti { get; set;}

		public InterventoRotManConsuntivatoReso ()
		{
			//for serialisation
		}	     

		public InterventoRotManConsuntivatoReso(Guid id, Guid commitId, long version,string note,WorkPeriod workPeriod,DateTime dataConsuntivazione,string idInterventoAppaltatore,OggettoRotMan[] oggetti)
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

		public InterventoRotManConsuntivatoReso(Guid id, Guid commitId, long version,DateTime wakeupTime,string note,WorkPeriod workPeriod,DateTime dataConsuntivazione,string idInterventoAppaltatore,OggettoRotMan[] oggetti)
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
			return string.Format("Il intervento rotabile in manutenzione é stato consuntivato reso", Id);
		}
		
		public bool Equals(InterventoRotManConsuntivatoReso other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other)  	 && Equals(other.Note, Note)  	 && Equals(other.WorkPeriod, WorkPeriod)  	 && Equals(other.DataConsuntivazione, DataConsuntivazione)  	 && Equals(other.IdInterventoAppaltatore, IdInterventoAppaltatore)  	 && other.Oggetti.SequenceEqual(Oggetti) ; 
		}

		public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as InterventoRotManConsuntivatoReso);
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
}
